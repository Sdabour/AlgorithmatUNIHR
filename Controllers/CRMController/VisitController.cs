using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgorithmatMVC.Controllers.CRMController
{
    public class SingleObject
    {

    }
    public class VisitController : Controller
    {
        // GET: Visit
         
        public ActionResult Index()
        {

            return View("Visit");
        }
        public ActionResult VisitNew()
        {
            return View("VisitNew");
        }
    }
}