namespace Sitecore.Mvp.Core.Views.Modules
{
    using Models.Modules;

    using Common;

    using Web.UI.WebControls;

    using ViewInterfaces.Modules;

    public class HeaderView : MvpGlassUserControl<Header>, IHeaderView
    {
        public string SitecoreItemPath => ((Sublayout)this.Parent).DataSource;
    }
}