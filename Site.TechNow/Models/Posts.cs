using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.TechNow.Models.sitecore.templates.TechNow_template
{
    public partial class Posts_Template
    {
        [SitecoreChildren]
        public virtual IEnumerable<CommentTemp> listCmt { set; get; }
    }
}