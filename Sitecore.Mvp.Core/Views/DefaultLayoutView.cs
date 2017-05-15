namespace Sitecore.Mvp.Core.Views
{
    using Models;
    using ViewInterfaces;

    using WebFormsMvp.Web;
    public class DefaultLayoutView : MvpPage<BasePage>, IDefaultLayoutView
    {
        public string SitecoreItemPath => Sitecore.Context.Item.Paths.FullPath;
    }
}