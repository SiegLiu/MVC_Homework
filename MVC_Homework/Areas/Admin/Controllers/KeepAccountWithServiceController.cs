using MVC_Homework.Models.ViewModels;
using MVC_Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Areas.Admin.Controllers
{
    public class KeepAccountWithServiceController : Controller
    {
        private readonly KeepAccountService _KeepAccountSvc;

        public KeepAccountWithServiceController()
        {
            _KeepAccountSvc = new KeepAccountService();
        }

        // GET: Admin/KeepAccountWithService
        [Authorize]
        public ActionResult Index(int? page)
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
            return View(_KeepAccountSvc.GetAllAccount(page));
        }

        [Authorize]
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountViewModel AccountBook = _KeepAccountSvc.GetSingle(id);
            if (AccountBook == null)
            {
                return HttpNotFound();
            }
            return View(AccountBook);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Amount,Billdate,Remark")] AccountViewModel AccountBook)
        {
            _KeepAccountSvc.Edit(AccountBook);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountViewModel AccountBook = _KeepAccountSvc.GetSingle(id);
            if (AccountBook == null)
            {
                return HttpNotFound();
            }
            return View(AccountBook);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Category,Amount,Billdate,Remark")] AccountViewModel AccountBook)
        {   
            _KeepAccountSvc.Delete(AccountBook);
            return RedirectToAction("Index");
        }
    }
}