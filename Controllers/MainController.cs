using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.UMS.UMSBusiness;

namespace AlgorithmatMVC.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
[Authorize]
        public ActionResult Index()
        {
            if (Session["CurrentUser"] == null || ((UserBiz)Session["CurrentUser"]).ID == 0)

            {
                return RedirectToAction("Index", "Login");
            }
            UserBiz objUserBiz = (UserBiz)Session["CurrentUser"];
            UserFunctionInstantCol objFunctionCol = new UserFunctionInstantCol(true);
            IEnumerable<UserFunctionInstantBiz> objCol = from objFunction in objUserBiz.UserFunctionInstantCol.Cast<UserFunctionInstantBiz>()
                                                         where objFunction.Url != ""
                                                         select objFunction;
            foreach (UserFunctionInstantBiz objBiz in objCol)
                objFunctionCol.Add(objBiz);

            return View(objFunctionCol);
        }
    }
}