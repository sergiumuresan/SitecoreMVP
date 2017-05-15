namespace Sitecore.Mvp.Core.Presenters.Modules
{
    using System;

    using Glass.Mapper.Sc;

    using Models.Modules;

    using ViewInterfaces.Modules;

    using WebFormsMvp;

    public class BodyContentPresenter : Presenter<IBodyContentView>
    {
        private readonly ISitecoreContext sitecoreContext;

        public BodyContentPresenter(IBodyContentView view, ISitecoreContext sitecoreContext) : base(view)
        {
            this.View.Load += this.Load;
            this.sitecoreContext = sitecoreContext;
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model = this.sitecoreContext.GetItem<BodyContent>(this.View.SitecoreItemPath);
        }
    }
}
