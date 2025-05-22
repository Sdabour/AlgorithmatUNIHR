using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlgorithmatMVC.Controllers.CRMController
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult SubCustomer()
        {

            return View("SubCustomer");
        }
    }
}