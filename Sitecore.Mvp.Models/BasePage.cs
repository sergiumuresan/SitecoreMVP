namespace Sitecore.Mvp.Models
{
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    [SitecoreType(AutoMap = true)]
    public class BasePage
    {
        public virtual string Title { get; set; }

        public virtual string Keywords { get; set; }

        public virtual string Description { get; set; }

        public virtual Image OgImage { get; set; }

        public virtual string OgDescription { get; set; }

        public virtual string CanonicalUrl { get; set; }

        public virtual string OgTitle { get; set; }

        public virtual string Name { get; set; }

        public virtual string Url { get; set; }
    }
}
