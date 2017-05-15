namespace Sitecore.Mvp.Core.Presenters.Modules
{
    using System;
    using System.Net.Mail;

    using Glass.Mapper.Sc;

    using Models.Modules;

    using ServiceModels;

    using ViewInterfaces.Modules;

    using WebFormsMvp;

    public class ContactFormPresenter : Presenter<IContactFormView>
    {
        private readonly ISitecoreContext sitecoreContext;

        private readonly IEmailService emailService;

        public ContactFormPresenter(IContactFormView view, ISitecoreContext sitecoreContext, IEmailService emailService) : base(view)
        {
            this.View.Load += this.Load;
            this.View.SubmitData += this.SubmitData;

            this.sitecoreContext = sitecoreContext;
            this.emailService = emailService;
        }

        public void SubmitData(object sender, ContactFormArgs e)
        {
            this.IsValidForm(e);

            if (e.IsValid)
            {
                //todo save information
                this.emailService.SendEmail("test@test.com", "test@test.com", "Subject", "Body");
            }
        }

        private static bool IsValidEmailAddress(string emailAddress)
        {
            try
            {
                // ReSharper disable once UnusedVariable
                var email = new MailAddress(emailAddress);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void IsValidForm(ContactFormArgs e)
        {
            View.Model.ErrorMessage = string.Empty;

            e.IsValid = true;

            if (string.IsNullOrEmpty(e.Name) || string.IsNullOrEmpty(e.Email))
            {
                View.Model.ErrorMessage = "Error. Fields are required.";
                e.IsValid = false;
                return;
            }

            if (!IsValidEmailAddress(e.Email))
            {
                this.View.Model.ErrorMessage = "Error. Email is not valid.";
                e.IsValid = false;
            }
        }

        private void Load(object sender, EventArgs e)
        {
            this.View.Model = this.sitecoreContext.GetItem<ContactForm>(this.View.SitecoreItemPath);
        }
    }
}
