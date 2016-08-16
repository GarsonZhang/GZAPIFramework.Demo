using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GZAPIFramework.Demo.Controllers
{
    public class APIHelpController : Controller
    {
        // GET: APIHelp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logs()
        {
            return View();
        }
    }
}