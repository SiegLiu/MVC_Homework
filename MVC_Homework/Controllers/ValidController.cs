using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Homework.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult ValidateDateLessOrEqual(DateTime Billdate)
        {
            bool isValidate = Billdate <= DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}