using Glass.Mapper.Sc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.TechNow.Models;
using Site.TechNow.Models.sitecore.templates.TechNow_template;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.SecurityModel;

namespace Site.TechNow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Header()
        {
            var context = new MvcContext();
            var contextData = new SitecoreContext();
            //var model = contextData.GetItem<Header_Template>(context.DataSourceItem);
            var model = contextData.Cast<Header_Template>(context.DataSourceItem);
            return View("~/Views/Shared/ShareLayout/Header.cshtml", model);
        }
        public ActionResult MenuHeader()
        {
            var context = new MvcContext();
            var contetxData = new SitecoreContext();
            var model = contetxData.Cast<Menu_Mutilist>(context.DataSourceItem);
            return View("~/Views/Shared/ShareLayout/MenuSection.cshtml", model);
        }

        public ActionResult IndexFeatureNews()
        {
            var context = new MvcContext();
            var contetxData = new SitecoreContext();
            var model = contetxData.Cast<Feature_New>(context.DataSourceItem);
            return View("~/Views/Rendering/Index/FeatureNew.cshtml", model);
        }

        public void SearchIndex()
        {
            /*dữ liệu có thể truyền vào là key hoặc value*/
            ISearchIndex index = ContentSearchManager.GetIndex("Sitecore_Master_Index");
            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                var result = context.GetQueryable<SearchResultItem>().Where(x => x.Content.Contains("hello world"));
            }
        }

        public ActionResult ContainerHeadPhones()
        {
            var context = new SitecoreContext();
            var model = context.GetCurrentItem<Page_Site>();
            return View("~/Views/Rendering/HeadePhones/Container.cshtml");
        }

        public ActionResult ContainerLeftHP()
        {
            var context = new SitecoreContext();
            var model = context.GetCurrentItem<Page_Site>();
            return View("~/Views/Rendering/HeadePhones/ContainerLeft.cshtml", model);
        }

        public ActionResult containerRight()
        {
            var context = new MvcContext();
            var contetxData = new SitecoreContext();
            var model = contetxData.Cast<Popular_News>(context.DataSourceItem);
            return View("~/Views/Rendering/HeadePhones/ContainerRight.cshtml", model);
        }
        public ActionResult containerDetail()
        {
            var context = new MvcContext();
            var contextDB = new SitecoreContext();
            var model = contextDB.GetCurrentItem<Posts_Template>();
            //var itemParent = contextDB.GetItem<Item>(model.Id.ToString());
            return View("~/Views/Rendering/HeadePhones/ContainerLeftDetail.cshtml", model);

        }

        public PartialViewResult listCmt()
        {
            var context = new MvcContext();
            var contextDB = new SitecoreContext();
            var model = contextDB.GetCurrentItem<Posts_Template>();
            return PartialView("~/Views/PageLayout/CommentList.cshtml", model);
        }

        [HttpPost]
        public PartialViewResult addComment(CommentTemp dataCmt)
        {
            var contextService = new SitecoreContext();
            //var model = contextService.GetCurrentItem<Posts_Template>();
            var masterService = new SitecoreService("master");
            var itemParent = masterService.GetItem<Item>(dataCmt.idParent.ToString());
            //var itemParent = masterService.GetItem<Item>(model.Id.ToString());

            if (itemParent != null)
            {
                string nameNewItem = "User" + DateTime.Now.ToString("yy-MM-ddThh-mm-ss");
                var template = contextService.GetItem<Item>(ICommentTempConstants.TemplateIdString);
                //var template = contextService.GetItem<Item>("{7F2D992E-9249-4B9C-9C2F-650912953C27}");
                using (new SecurityDisabler())
                {
                    var templateItem = new TemplateItem(template);
                    var itemChild = itemParent.Add(nameNewItem, templateItem);
                    itemChild.Editing.BeginEdit();
                    itemChild.Fields["name"].Value = dataCmt.Name;
                    itemChild.Fields["email"].Value = dataCmt.Email;
                    itemChild.Fields["comment"].Value = dataCmt.Comment;
                    itemChild.Fields["date time"].Value = Sitecore.DateUtil.ToIsoDate(DateTime.Now);
                    itemChild.Editing.EndEdit();
                    return PartialView(listCmt());
;                }
            }
            else
            {
                return PartialView(listCmt());
            }
        }
    }
}