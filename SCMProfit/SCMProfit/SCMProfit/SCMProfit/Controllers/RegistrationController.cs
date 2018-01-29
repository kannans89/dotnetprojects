using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCMProfit.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Customer");
        }

    }
}
