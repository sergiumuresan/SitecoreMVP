namespace Sitecore.Mvp.Core
{
    using System.Collections.Generic;

    using WebFormsMvp;
    using WebFormsMvp.Binder;

    internal class PresenterDiscoveryStrategy : ConventionBasedPresenterDiscoveryStrategy
    {
        private static readonly IEnumerable<string> NameFormats = new[]
                                                                      {
                                                                          "{namespace}.Presenters.{presenter}",
                                                                          "{namespace}.Presenters.Modules.{presenter}",
                                                                          "{namespace}.Presenters.Pages.{presenter}",
                                                                          "{namespace}.Presenters.Services.{presenter}"
                                                                      };

        public PresenterDiscoveryStrategy(IBuildManager buildManager) : base(buildManager)
        {

        }

        protected override IEnumerable<string> ViewInstanceSuffixes => new[] { "UserControl", "Control", "View", "Handler" };

        public override IEnumerable<string> CandidatePresenterTypeFullNameFormats => NameFormats;
    }
}