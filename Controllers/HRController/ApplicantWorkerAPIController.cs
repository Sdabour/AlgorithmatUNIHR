using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.HR.HRBusiness;
using System.Text.Json;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class ApplicantWorkerAPIController : ApiController
    {
        public List<ApplicantSingle> GetApplicantSingleByName(string strName)
        {
            List<ApplicantSingle> Returned = new List<ApplicantSingle>();
            ApplicantWorkerCol objCol = new ApplicantWorkerCol("", "", "", strName);
            Returned = (objCol.Cast<ApplicantWorkerBiz>().Select(x => x.GetApplicantSingle())).ToList();
            return Returned;
        }
       

    }
}
