namespace Sitecore.Mvp.Tests
{
    using Glass.Mapper.Sc;

    using Moq;

    using NUnit.Framework;

    using Core.Presenters.Modules;
    using Models.Modules;

    using ServiceModels;

    using ViewInterfaces.Modules;

    public class ContactFormTests
    {
        private Mock<IContactFormView> contactFormView;
        private Mock<ISitecoreContext> sitecoreContext;
        private Mock<IEmailService> emailService;

        [SetUp]
        public void Setup()
        {
            contactFormView = new Mock<IContactFormView>();
            sitecoreContext = new Mock<ISitecoreContext>();
            emailService = new Mock<IEmailService>();

            sitecoreContext.Setup(x => x.GetItem<ContactForm>(It.IsAny<string>(), false, false)).Returns(new ContactForm());
            contactFormView.Setup(x => x.Model).Returns(new ContactForm());
        }

        [Test]
        public void SubmitEmptyValues()
        {
            var formPresenter = new ContactFormPresenter(contactFormView.Object, sitecoreContext.Object, this.emailService.Object);

            var args = new ContactFormArgs { Email = string.Empty, Name = string.Empty };

            formPresenter.SubmitData(null, args);

            Assert.IsFalse(args.IsValid);
        }

        [Test]
        public void SubmitEmptyName()
        {
            var formPresenter = new ContactFormPresenter(contactFormView.Object, sitecoreContext.Object, this.emailService.Object);

            var args = new ContactFormArgs { Email = "test@test.com", Name = string.Empty };

            formPresenter.SubmitData(null, args);

            Assert.IsFalse(args.IsValid);
        }

        [Test]
        public void SubmitEmptyEmail()
        {
            var formPresenter = new ContactFormPresenter(contactFormView.Object, sitecoreContext.Object, this.emailService.Object);

            var args = new ContactFormArgs { Email = string.Empty, Name = "Test" };

            formPresenter.SubmitData(null, args);

            Assert.IsFalse(args.IsValid);
        }

        [Test]
        public void SubmitInvalidEmail()
        {
            var formPresenter = new ContactFormPresenter(contactFormView.Object, sitecoreContext.Object, this.emailService.Object);

            var args = new ContactFormArgs { Email = "Test", Name = "Test" };

            formPresenter.SubmitData(null, args);

            Assert.IsFalse(args.IsValid);
        }

        [Test]
        public void SubmitSuccess()
        {
            var formPresenter = new ContactFormPresenter(contactFormView.Object, sitecoreContext.Object, this.emailService.Object);

            var args = new ContactFormArgs { Email = "test@test.com", Name = "Test" };

            formPresenter.SubmitData(null, args);

            Assert.IsTrue(args.IsValid);
        }
    }
}
