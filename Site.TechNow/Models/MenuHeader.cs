using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{
    public partial class Menu_Mutilist
    {
        [SitecoreField("List Menu")]
        public virtual IEnumerable<Page_Site> listSite { get; set; }
    }
}