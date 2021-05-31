using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Site.TechNow.Models;
using Site.TechNow.Models.sitecore.templates.TechNow_template;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{ 
    public partial class Header_Template
    {
        [SitecoreField("Link Contact")]
        //[SitecoreField("{50E1F64F-7C2D-4A9A-83FB-21038BAA9330}")]
        public IEnumerable<Link_Action> Link_icon { set; get; }
    }
}