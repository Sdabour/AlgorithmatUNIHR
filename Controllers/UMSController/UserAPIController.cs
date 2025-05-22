using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.UMS.UMSBusiness;
namespace AlgorithmatNewMVC.Controllers.UMSController
{
    public class UserAPIController : ApiController
    {
        [Route("api/UserAPI/GetUserList")]
        [ActionName("GetUserList")]
        [HttpGet]
       
        public List<UserSimple> GetUserList(int intGroupID, string strUserName, string strFullName, int intEmpID)
        {
            UserCol objUserCol = new UserCol(intGroupID, strUserName, strFullName, intEmpID);
            List<UserSimple> Returned = objUserCol.Cast<UserBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;

        }
        [Route("api/UserAPI/GetUserFunctionInstant")]
        [ActionName("GetUserFunctionInstant")]
        [HttpGet]

        public List<FunctionInstantSimple> GetUserFunctionInstant(int intUserID)
        {
            UserCol objUserCol = new UserCol();// new UserCol(intGroupID, strUserName, strFullName, intEmpID);
            
            List<FunctionInstantSimple> Returned = new List<FunctionInstantSimple>();
            if (intUserID != 0)
            {
                UserBiz objBiz = new UserBiz() { ID = intUserID };
                Returned = objBiz.AllUserFunctionInstantCol.Cast<UserFunctionInstantBiz>().Select(x => x.GetFunctionInstant()).ToList();
            }
            //objUserCol.Cast<UserBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;

        }

        [Route("api/UserAPI/AddEditUser")]
        [ActionName("AddEditUser")]
        [HttpPost]

        public void AddEditUser(UserSimple objUser)
        {
            UserFunctionInstantCol objFunctionCol = new UserFunctionInstantCol(true);
            foreach (FunctionInstantSimple objSimple in objUser.LstFunction)
                objFunctionCol.Add(objSimple.GetUserFunctionInstant());
            if (objUser.Name != "" && objUser.FullName != "" && objUser.Password != "")
            {
                if (objUser.ID == 0)
                    UserBiz.Add(objUser.FullName, objUser.Name, objUser.Password, objUser.Group, false, false, objFunctionCol, new EmployeeBiz() { ID = objUser.EmpID }, new UserBiz());
                else
                    UserBiz.Edit(objUser.ID, objUser.FullName, objUser.Name, objUser.Password, objUser.Group, false, false, objFunctionCol, new EmployeeBiz() { ID = objUser.EmpID }, new UserBiz());
            }

        }
    }
}
