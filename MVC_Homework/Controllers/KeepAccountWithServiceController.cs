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
            //return View(_KeepAccountSvc.GetAllAccount());
            return View();
        }

        // GET: KeepAccountWithService
        public ActionResult BillPage()
        {
            return View(_KeepAccountSvc.GetAllAccount());
        }

        // POST: AccountBook/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category, amount, billdate")] AccountViewModel AccountBook)
        {
            if (ModelState.IsValid)
            {
                //AccountBook.Id = Guid.NewGuid();
                _KeepAccountSvc.Add(AccountBook);
                return RedirectToAction("Index");
            }
            return View(AccountBook);
        }
    }
}