using MVC_Homework.CustomResults;
using MVC_Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class FeedsController : Controller
    {
        private readonly KeepAccountService _KeepAccountSvc;

        public FeedsController()
        {
            _KeepAccountSvc = new KeepAccountService();
        }
        
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                "帳單",
                "帳單RSS",
                new Uri(Url.Action("Index", "Feeds", null, "http")));

            var items = new List<SyndicationItem>();

            var accounts = _KeepAccountSvc.GetAllAccount()
                .Where(x => x.Billdate <= DateTime.Now)
                .OrderByDescending(x => x.Billdate);

            foreach (var account in accounts)
            {
                var item = new SyndicationItem(
                    (account.Category == "0")? "支出" : "收入",
                    "金額：" + account.Amount.ToString() + "(元)",
                    new Uri(Url.Action("BillPage", "KeepAccountWithService", "", "http")),
                    "Id",
                    account.Billdate);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
    }
}