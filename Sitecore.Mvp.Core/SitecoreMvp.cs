namespace Sitecore.Mvp.Core
{
    using WebFormsMvp.Binder;
    using WebFormsMvp.Web;

    public class SitecoreMvp
    {
        public static void Init()
        {
            PresenterBinder.Factory = new CastleFactory();
            PresenterBinder.DiscoveryStrategy = new PresenterDiscoveryStrategy(new BuildManagerWrapper());
        }
    }
}