using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{
    public partial class Page_Site
    {
        [SitecoreChildren]
        public virtual IEnumerable<Posts_Template> Children { set; get; }
    }
}