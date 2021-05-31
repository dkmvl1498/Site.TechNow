using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{
    public partial class Popular_News
    {
        [SitecoreField("List posts")]
        public virtual IEnumerable<Posts_Template> ListPosts { get; set; }
    }
}