using System;

namespace Sitecore.Mvp.Core.Common
{
    using System.IO;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.UI;

    using Glass.Mapper;
    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.IoC;
    using Glass.Mapper.Sc.Web;
    using Glass.Mapper.Sc.Web.Ui;

    using Data.Items;

    using WebFormsMvp.Web;

    public abstract class MvpAbstractGlassUserControl<TModel> : MvpUserControl<TModel> where TModel : class, new()
    {
        private TextWriter writer;
        private IRenderingContext renderingContext;
        private ISitecoreContext sitecoreContext;
        private IGlassHtml glassHtml;

        public ISitecoreContextFactory SitecoreContextFactory { get; protected set; }

        public virtual IRenderingContext RenderingContext
        {
            get
            {
                return this.renderingContext ?? (this.renderingContext = new RenderingContextUserControlWrapper(this));
            }
            set
            {
                this.renderingContext = value;
            }
        }

        protected TextWriter Output => this.writer ?? HttpContext.Current.Response.Output;

        public bool IsInEditingMode => Glass.Mapper.Sc.GlassHtml.IsInEditingMode;

        public virtual ISitecoreContext SitecoreContext
        {
            get
            {
                return this.sitecoreContext ?? (this.sitecoreContext = this.SitecoreContextFactory.GetSitecoreContext());
            }
            set
            {
                this.sitecoreContext = value;
            }
        }

        public virtual IGlassHtml GlassHtml
        {
            get
            {
                return this.glassHtml ?? (this.glassHtml = this.SitecoreContext.GlassHtml);
            }
            set
            {
                this.glassHtml = value;
            }
        }

        public string DataSource => this.RenderingContext.GetDataSource();

        public Item LayoutItem => this.DataSourceItem ?? this.ContextItem;

        public Item ContextItem => Sitecore.Context.Item;

        public Item DataSourceItem => !this.DataSource.IsNullOrEmpty() ? Sitecore.Context.Database.GetItem(this.DataSource) : null;

        public virtual string RenderingParameters => this.RenderingContext.GetRenderingParameters();

        protected MvpAbstractGlassUserControl(ISitecoreContextFactory sitecoreContextFactory)
        {
            this.SitecoreContextFactory = sitecoreContextFactory;
        }

        protected MvpAbstractGlassUserControl(ISitecoreContext context, IGlassHtml glassHtml, IRenderingContext renderingContext) : this(Glass.Mapper.Sc.IoC.SitecoreContextFactory.Default)
        {
            this.renderingContext = renderingContext;
            this.glassHtml = glassHtml;
            this.sitecoreContext = context;
        }

        protected MvpAbstractGlassUserControl(ISitecoreContext context, IGlassHtml glassHtml) : this(context, glassHtml, null)
        {
        }

        protected MvpAbstractGlassUserControl(ISitecoreContext context) : this(context, ((AbstractDependencyResolver)context.GlassContext.DependencyResolver).GlassHtmlFactory.GetGlassHtml(context))
        {
        }

        protected MvpAbstractGlassUserControl() : this(Glass.Mapper.Sc.IoC.SitecoreContextFactory.Default)
        {
        }

        public T GetContextItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return this.SitecoreContext.GetCurrentItem<T>(isLazy, inferType);
        }

        public T GetDataSourceItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            string dataSource = this.RenderingContext.GetDataSource();
            if (string.IsNullOrEmpty(dataSource))
            {
                return default(T);
            }
            return this.SitecoreContext.GetItem<T>(dataSource, isLazy, inferType);
        }

        public T GetLayoutItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            if (string.IsNullOrEmpty(this.RenderingContext.GetDataSource()))
            {
                return this.GetContextItem<T>(isLazy, inferType);
            }
            return this.GetDataSourceItem<T>(isLazy, inferType);
        }

        public string Editable<T>(T model, Expression<Func<T, object>> field, object parameters = null)
        {
            return this.GlassHtml.Editable(model, field, parameters);
        }

        public string Editable<T>(T model, Expression<Func<T, object>> field, Expression<Func<T, string>> standardOutput, object parameters = null)
        {
            return this.GlassHtml.Editable(model, field, standardOutput, parameters);
        }

        public virtual string RenderImage<T>(T model, Expression<Func<T, object>> field, object parameters = null, bool isEditable = false, bool outputHeightWidth = true)
        {
            return this.GlassHtml.RenderImage(model, field, parameters, isEditable, outputHeightWidth);
        }

        public virtual RenderingResult BeginRenderLink<T>(T model, Expression<Func<T, object>> field, object attributes = null, bool isEditable = false)
        {
            return this.GlassHtml.BeginRenderLink(model, field, this.Output, attributes, isEditable);
        }

        public virtual string RenderLink<T>(T model, Expression<Func<T, object>> field, object attributes = null, bool isEditable = false, string contents = null)
        {
            return this.GlassHtml.RenderLink(model, field, attributes, isEditable, contents);
        }

        public GlassEditFrame BeginEditFrame<T>(T model, string title = null, params Expression<Func<T, object>>[] fields) where T : class
        {
            return this.GlassHtml.EditFrame(model, title, this.Output, fields);
        }

        // ReSharper disable once ParameterHidesMember
        public override void RenderControl(HtmlTextWriter writer)
        {
            this.writer = writer;
            base.RenderControl(writer);
        }

        public virtual TParam GetRenderingParameters<TParam>() where TParam : class
        {
            if (!this.RenderingParameters.HasValue())
            {
                return default(TParam);
            }
            return this.GlassHtml.GetRenderingParameters<TParam>(this.RenderingParameters);
        }
    }
}
