namespace Sitecore.Mvp.Core.Presenters.Modules
{
    using System;

    using Glass.Mapper.Sc;

    using Models.Modules;

    using ViewInterfaces.Modules;

    using WebFormsMvp;

    public class HeaderPresenter : Presenter<IHeaderView>
    {
        private readonly ISitecoreContext sitecoreContext;

        public HeaderPresenter(IHeaderView view, ISitecoreContext sitecoreContext) : base(view)
        {
            this.View.Load += this.Load;
            this.sitecoreContext = sitecoreContext;
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model = this.sitecoreContext.GetItem<Header>(this.View.SitecoreItemPath);
        }
    }
}