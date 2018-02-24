using MVC_Homework.Models.ViewModels;
using MVC_Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class KeepAccountWithServiceController : Controller
    {
        private readonly KeepAccountService _KeepAccountSvc;

        public KeepAccountWithServiceController()
        {
            _KeepAccountSvc = new KeepAccountService();
        }

        public ActionResult KeepAccounts()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem()
            {
                Value = "0",
                Text = "支出",
            });
            items.Add(new SelectListItem()
            {
                Value = "1",
                Text = "收入",
            });
            ViewBag.Category = items;
            return View();
        }

        // GET: KeepAccountWithService
        public ActionResult BillPage(int? page)
        {
            return View(_KeepAccountSvc.GetAllAccount(page));
        }

        // POST: AccountBook/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KeepAccounts([Bind(Include = "Id,Category,Amount,Billdate,Remark")] AccountViewModel AccountBook)
        {
            if (ModelState.IsValid)
            {
                //AccountBook.Id = Guid.NewGuid();
                _KeepAccountSvc.Add(AccountBook);
                
            }
            //return View(AccountBook);
            return RedirectToAction("KeepAccounts");
        }
    }
}