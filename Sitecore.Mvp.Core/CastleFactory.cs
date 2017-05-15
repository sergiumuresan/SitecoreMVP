namespace Sitecore.Mvp.Core
{
    using System;
    using System.Collections.Generic;

    using WebFormsMvp;
    using WebFormsMvp.Binder;

    internal class CastleFactory : IPresenterFactory
    {
        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var parameters = new Dictionary<string, object> { { "view", viewInstance } };
            var presenter = CastleContainer.Instance.Resolve(presenterType, parameters);

            return (IPresenter)presenter;
        }

        public void Release(IPresenter presenter)
        {
            CastleContainer.Instance.Release(presenter);
        }
    }
}