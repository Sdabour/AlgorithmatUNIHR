using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using SharpVision.HR.HRBusiness;

namespace AlgorithmatMVC.Controllers.HRController
{
    public class MSGGroupAPIController : ApiController
    {
        public List<MSGGroupBiz> GetApplicantGroup(int intApplicant)
        {
            List<MSGGroupBiz> Returned =MSGGroupBiz.GetAppGroupCol(intApplicant).Cast<MSGGroupBiz>().ToList();
            return Returned;
        }
        [Authorize]
        [HttpPost]
        [AcceptVerbs("GET")]
        public void SaveNewGroup([FromBody] MSGGroupBiz objGroup)
        {
       
            HttpRequestHeaders objHeaders = Request.Headers;

            string strName = MaintainancePaymentController.GetClaimValue(objHeaders.Authorization.ToString(), "UserName");
            string objMsg = "";
           // if (objMsg == null ||
           //!objMsg.Contains("Bearer"))
           // {
           //     // return null;

           // }
            if ((objGroup.NameA != null && objGroup.NameA != "")&& objGroup.ApplicantLst.Count>0)
            {
                objGroup.Add();
            }
        }
    }
}
