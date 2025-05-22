using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.UMS.UMSBusiness;
using System.Web.Mvc;
namespace AlgorithmatMVC.Controllers.HRController
{
    [Serializable]
    public class EmployeeSimpleBiz
    {
        public int ID;
        public string Code;
        public string Name;
        public string Job;
        public string Sector;

    }
    public class EmployeeWebController : ApiController
    {


        [System.Web.Http.Route("api/EmployeeWeb/GetEmployee")]
        [System.Web.Http.ActionName("GetEmployee")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.AcceptVerbs("GET")]
        public IEnumerable<EmployeeSimple> GetEmployee
       (int intSectorID, string strEmpCode, string strEmpName)
        {
            IEnumerable<EmployeeSimple> Returned;
            EmployeeCol objCol = new EmployeeCol(intSectorID, 0, strEmpCode, strEmpName, new DepartmentBiz(), 1);
            Returned = from objBiz in objCol.Cast<EmployeeBiz>()
                       select objBiz.GetSimple();

            return Returned;

        }
    }
}