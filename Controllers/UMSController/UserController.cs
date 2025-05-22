using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.UMS.UMSBusiness;
using System.Text.Json;
namespace AlgorithmatNewMVC.Controllers.UMSController
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GroupIndex()
        {
            GroupBiz objBiz = new GroupBiz();
            return View("GroupDisplay", objBiz);
        }
        public ActionResult GroupAddEditIndex()
        {
            string strTemp = Request["GroupID"];
            int intGroup = 0;
            if (strTemp != "")
                int.TryParse(strTemp, out intGroup);

            GroupBiz objBiz = new GroupBiz(intGroup);
            return View("GroupAddEdit",objBiz);
        }
        public ActionResult AddEditSaveGroup(GroupBiz objBiz)
        {
            if (objBiz == null)
                objBiz = new GroupBiz();
            string strFunction = Request.Form["lblAllFunctionInstant"];
            List<FunctionInstantSimple> arrFunction = System.Web.Helpers.Json.Decode<List<FunctionInstantSimple>>(strFunction);
            GroupFunctionInstantCol objFunctionCol = new GroupFunctionInstantCol(true);
            foreach (FunctionInstantSimple objSimple in arrFunction)
                objFunctionCol.Add(objSimple.GetGroupFunctionInstant());
            //objBiz.GroupFunctionInstantCol = objFunctionCol;
            if (objBiz.Name != null && objBiz.Name != "")
            {
                if (objBiz.ID == 0)
                    GroupBiz.Add(objBiz.Name, objBiz.ParentID, objBiz.FamilyID, objBiz.GroupTypeID, objFunctionCol);
                else
                    GroupBiz.Edit(objBiz.ID, objBiz.Name, objBiz.ParentID, objBiz.FamilyID, objBiz.GroupTypeID, objFunctionCol);
            }
            return View("GroupAddEdit",objBiz);
        }
        public ActionResult UserAddEditIndex()
        {
            string strTemp = Request["UserID"];
            int intTemp = 0;
            int.TryParse(strTemp, out intTemp);
            UserBiz objBiz = new UserBiz(intTemp);
            if(objBiz.EmployeeBiz.ID == 0 )
            {
                strTemp = Request["EmpID"];
                 intTemp = 0;
                int.TryParse(strTemp, out intTemp);
                if (intTemp > 0)
                    objBiz.EmployeeBiz = new EmployeeBiz(intTemp);
            }
            return View("UserAddEdit", objBiz);
        }

        public ActionResult AddEditSave(UserBiz objBiz)
        {
            if (objBiz == null)
                objBiz = new UserBiz();
            string strFunction = Request.Form["lblAllFunctionInstant"];
            List<FunctionInstantSimple> arrFunction = System.Web.Helpers.Json.Decode<List<FunctionInstantSimple>>(strFunction);
            UserFunctionInstantCol objFunctionCol = new UserFunctionInstantCol(true);
            foreach (FunctionInstantSimple objSimple in arrFunction)
                objFunctionCol.Add(objSimple.GetUserFunctionInstant());
            //objBiz.GroupFunctionInstantCol = objFunctionCol;
            bool blIsAdmin = false;
            EmployeeBiz objEmployeeBiz = new EmployeeBiz();
            string strEmployee = Request.Form["lblEmployeeValue"];
            if (strEmployee != "")
            {
                EmployeeSimple objSimple = System.Web.Helpers.Json.Decode<EmployeeSimple>(strEmployee);
                objEmployeeBiz = new EmployeeBiz() { ID = objSimple.ID, Name = objSimple.Name };
            }
            UserBiz objSrcUser = new UserBiz();
            if (objBiz.Name != null && objBiz.Name != "")
            {
                if (objBiz.ID == 0)
                    UserBiz.Add(objBiz.FullName, objBiz.Name, objBiz.Password, objBiz.GroupID, false, blIsAdmin, objFunctionCol, objEmployeeBiz, objSrcUser);
                else
                    UserBiz.Edit(objBiz.ID, objBiz.FullName, objBiz.Name, objBiz.Password, objBiz.GroupID, false, blIsAdmin, objFunctionCol, objEmployeeBiz, objSrcUser);
            }
            return View("UserAddEdit", objBiz);
        }
    }
}