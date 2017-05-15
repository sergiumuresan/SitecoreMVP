namespace Sitecore.Mvp.Core
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Glass.Mapper.Sc;

    using WebFormsMvp;

    internal class WindsorInstall : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ISitecoreContext>().ImplementedBy<SitecoreContext>().LifestyleTransient());
            container.Register(Classes.FromThisAssembly().BasedOn<IPresenter>().Configure(c => c.LifestyleTransient()));
            container.Register(Classes.FromThisAssembly().Where(t => t.Name.EndsWith("View")).Configure(c => c.LifestyleTransient()));

            container.Register(Classes.FromAssemblyNamed("Sitecore.Mvp.Services").Where(c => c.Name.EndsWith("Service")).WithService.DefaultInterfaces().LifestyleTransient());
        }
    }
}