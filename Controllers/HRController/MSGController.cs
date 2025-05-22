using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgorithmatMVC.Controllers.HRController
{
    public class MSGController : Controller
    {
        // GET: MSG
        public ActionResult Index()
        {
            return View("MSG");
        }
    }
}