namespace Sitecore.Mvp.Models.Modules
{
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Sitecore.Data;

    [SitecoreType(AutoMap = true)]
    public class ContactForm
    {
        public virtual ID Id { get; set; }

        public virtual string Title { get; set; }

        [SitecoreField("Name")]
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual Link Submit { get; set; }

        public virtual string ErrorMessage { get; set; }
    }
}
