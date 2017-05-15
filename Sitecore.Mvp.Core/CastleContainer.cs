namespace Sitecore.Mvp.Core
{
    using Castle.Windsor;

    internal class CastleContainer
    {
        private static WindsorContainer container;

        public static WindsorContainer Instance
        {
            get
            {
                if (container == null)
                {
                    container = new WindsorContainer();
                    container.Install(new WindsorInstall());
                }

                return container;
            }
        }

    }
}