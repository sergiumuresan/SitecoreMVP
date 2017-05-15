namespace Sitecore.Mvp.ViewInterfaces.Base
{
    using WebFormsMvp;

    public interface IBaseView<TModel> : IView<TModel> where TModel : class, new()
    {
        bool IsPostBack { get; }

        string SitecoreItemPath { get; }
    }
}
