using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.UMS.UMSBusiness;
namespace AlgorithmatNewMVC.Controllers.UMSController
{
    public class UMSAPIController : ApiController
    {
        public List<FunctionSimple> GetSystemFunctionLst(int intSys)
        {
            List<FunctionSimple> Returned = new List<FunctionSimple>();
            FunctionCol objFunctionCol = new FunctionCol(intSys);
            Returned = objFunctionCol.LinearCol.Cast<FunctionBiz>().Select(x => x.GetFunctionSimple()).ToList();
            return Returned;
        }
    }
}
