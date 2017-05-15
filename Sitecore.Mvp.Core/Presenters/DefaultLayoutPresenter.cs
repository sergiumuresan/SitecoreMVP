using System;

namespace Sitecore.Mvp.Core.Presenters
{
    using Glass.Mapper.Sc;

    using Models;
    using ViewInterfaces;

    using WebFormsMvp;

    public class DefaultLayoutPresenter : Presenter<IDefaultLayoutView>
    {
        private readonly ISitecoreContext sitecoreContext;

        public DefaultLayoutPresenter(IDefaultLayoutView view, ISitecoreContext sitecoreContext) : base(view)
        {
            this.View.Load += Load;
            this.sitecoreContext = sitecoreContext;
        }

        private void Load(object sender, EventArgs e)
        {
            View.Model = sitecoreContext.GetItem<BasePage>(View.SitecoreItemPath);
        }
    }
}