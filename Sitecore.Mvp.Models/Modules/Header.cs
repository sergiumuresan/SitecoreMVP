namespace Sitecore.Mvp.Models.Modules
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;

    using Sitecore.Data;

    [SitecoreType(AutoMap = true)]
    public class Header
    {
        public virtual ID Id { get; set; }

        public virtual string Title { get; set; }

        [SitecoreQuery("/sitecore/content/home/child::*[@@templateid='{2C8E5F42-7C29-44DA-95A9-D18ED669DB07}']")]
        public virtual IEnumerable<BasePage> MenuItems { get; set; }
    }
}
