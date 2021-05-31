using Glass.Mapper.Sc.Configuration.Attributes;
using Site.TechNow.Models.sitecore.templates.TechNow_template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{
    public partial class Feature_New
    {
        [SitecoreField("list new")]
        public virtual IEnumerable<Posts_Template> Children { set; get; }
    }
}