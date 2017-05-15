using System;

namespace Sitecore.Mvp.Startup
{
    using Sitecore.Mvp.Core;

    public class Application : Web.Application
    {
        public override void Application_Start(object sender, EventArgs args)
        {
            SitecoreMvp.Init();
            base.Application_Start(sender, args);
        }
    }
}