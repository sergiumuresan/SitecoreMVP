using System;

namespace Sitecore.Mvp.Core.Common
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    using Glass.Mapper.Sc;
    using Glass.Mapper.Sc.Web;

    public class MvpGlassUserControl<T> : MvpAbstractGlassUserControl<T> where T : class, new()
    {
        public bool InferType { get; set; }

        public bool IsLazy { get; set; }

        public MvpGlassUserControl(ISitecoreContext context, IGlassHtml glassHtml, IRenderingContext renderingContext) : base(context, glassHtml, renderingContext)
        {
        }

        [ExcludeFromCodeCoverage]
        public MvpGlassUserControl(ISitecoreContext context) : base(context)
        {
        }

        public MvpGlassUserControl()
        {
        }

        protected virtual void GetModel()
        {
            this.Model = this.GetLayoutItem<T>(this.IsLazy, this.InferType);
        }

        public string Editable(Expression<Func<T, object>> field, object parameters = null)
        {
            return this.Editable(this.Model, field, parameters);
        }

        public string Editable(Expression<Func<T, object>> field, Expression<Func<T, string>> standardOutput, object parameters = null)
        {
            return this.Editable(this.Model, field, standardOutput, parameters);
        }

        public virtual string RenderImage(Expression<Func<T, object>> field, object parameters = null, bool isEditable = false, bool outputHeightWidth = false)
        {
            return this.RenderImage(this.Model, field, parameters, isEditable, outputHeightWidth);
        }

        public virtual RenderingResult BeginRenderLink(Expression<Func<T, object>> field, object attributes = null, bool isEditable = false)
        {
            return this.GlassHtml.BeginRenderLink(this.Model, field, this.Output, attributes, isEditable);
        }

        public virtual string RenderLink(Expression<Func<T, object>> field, object attributes = null, bool isEditable = false, string contents = null)
        {
            return this.GlassHtml.RenderLink(this.Model, field, attributes, isEditable, contents);
        }
    }
}
