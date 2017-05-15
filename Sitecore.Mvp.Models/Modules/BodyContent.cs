namespace Sitecore.Mvp.Models.Modules
{
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Sitecore.Data;

    [SitecoreType(AutoMap = true)]
    public class BodyContent
    {
        public virtual ID Id { get; set; }

        public virtual string Content { get; set; }
    }
}
