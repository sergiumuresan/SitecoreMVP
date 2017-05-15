namespace Sitecore.Mvp.ViewInterfaces.Base
{
    using System;

    public interface IBaseFormView<TModel, TEventArgs> : IBaseView<TModel> where TModel : class, new() where TEventArgs : EventArgs
    {
        event EventHandler<TEventArgs> SubmitData;

        TEventArgs CollectData();
    }
}
