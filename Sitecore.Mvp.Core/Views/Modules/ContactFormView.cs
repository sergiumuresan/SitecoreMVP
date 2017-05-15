namespace Sitecore.Mvp.Core.Views.Modules
{
    using System;
    using System.Web.UI.HtmlControls;

    using Models.Modules;

    using Common;

    using Web.UI.WebControls;

    using ViewInterfaces.Modules;

    public class ContactFormView : MvpGlassUserControl<ContactForm>, IContactFormView
    {
        protected HtmlControl SuccessMessage;

        public string SitecoreItemPath => ((Sublayout)this.Parent).DataSource;

        public event EventHandler<ContactFormArgs> SubmitData;

        public ContactFormArgs CollectData()
        {
            return new ContactFormArgs
            {
                Email = Request.Form["email"],
                Name = Request.Form["name"]
            };
        }

        public void BtnSubmitClick(object sender, EventArgs e)
        {
            if (SubmitData != null)
            {
                var args = this.CollectData();
                this.SubmitData(sender, args);

                SuccessMessage.Visible = !args.IsValid;
            }
        }
    }
}