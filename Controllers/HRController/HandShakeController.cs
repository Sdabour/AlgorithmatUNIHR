using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.HR.HRBusiness;
namespace AlgorithmatMVC.Controllers.HRController
{
    [Serializable]
    public class ApplicantIDsParameter
    {
        public string strApplicantIDs;
    }
    [Serializable]
    public class HandShakeParameter
    {
        public string applicantCode;
        public string Lat;
        public string Long;
    }
    public class HandShakeController : ApiController
    {
        [Route("api/HandShake/GetOnline")]
        [ActionName("GetOnline")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public List<ApplicantHandShakeSimple> GetOnline([FromBody] ApplicantIDsParameter objParam)
        {
            string strApplicantIDs = objParam.strApplicantIDs;
            List<ApplicantHandShakeSimple> Returned;
            
            if (strApplicantIDs == null)
                return new List<ApplicantHandShakeSimple>();
            List<ApplicantHandShakeBiz> objHandShakeCol = ApplicantHandShakeCol.GetOnlineHandShakeCol(strApplicantIDs).Cast<ApplicantHandShakeBiz>().ToList();
            Returned = (from objHandshake in objHandShakeCol.Cast<ApplicantHandShakeBiz>()
                        select objHandshake.HandShakeSimple).ToList();//= 
          
            return Returned;

        }

        [Route("api/HandShake/GetTodayHandShaked")]
        [ActionName("GetTodayHandShaked")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public List<ApplicantHandShakeSimple> GetTodayHandShaked([FromBody] ApplicantIDsParameter objParam)
        {
            string strApplicantIDs = objParam.strApplicantIDs;
            List<ApplicantHandShakeSimple> Returned;

            if (strApplicantIDs == null)
                return new List<ApplicantHandShakeSimple>();
            List<ApplicantHandShakeBiz> objHandShakeCol = ApplicantHandShakeCol.GetTodayHandShakeCol(strApplicantIDs).Cast<ApplicantHandShakeBiz>().ToList();
            Returned = (from objHandshake in objHandShakeCol.Cast<ApplicantHandShakeBiz>()
                        orderby (int)objHandshake.Status
                        select objHandshake.HandShakeSimple).ToList();//= 

            return Returned;

        }
    }
}
