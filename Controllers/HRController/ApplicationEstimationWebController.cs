using SharpVision.HR.HRBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlgorithmatMVC.Controllers.HRController
{
    
    public class EstimationStatementSingle
    {
        public int ID;
        public string Desc;
        public DateTime Date;
        public bool IsGlobal;

    }
    public class ApplicantEstimationStatementSingle
    {
        public ApplicantSingle Applicant ;
        public EstimationStatementSingle EstimationStatement;
       public string CostCenter;
       public string EstimationGroup;
        public bool IsSummary;
}
    public class ApplicantEstimationStatementElementSingle
    {
        public int Statement;
        public int ElementID;
        public string ElementDesc;
        public double EstimationValue;
        public double ElementValue;
        public double ElementWeight;
        public bool IsFuzzyValue;
        public int FuzzyValue;
       public string Group;
        public int GroupOrder;
        public double GroupPerc;
        public string GroupName;

       
    }

    public class ApplicationEstimationWebController : ApiController
    {
        #region NativeWebAPI
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion


    }
}