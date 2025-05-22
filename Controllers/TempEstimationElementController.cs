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
    public class EstimationElementSimple
    {
        public int ID;
        public string Name;
        public bool IsFuzzy;
        public double Value;
        public double Weight;
        public int Order;
    }
    public class TempEstimationElementController : ApiController
    {
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
        [Route("api/TempEstimationElementController/AddNewElement")]
        [ActionName("AddNewElement")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public IEnumerable<EstimationElementSimple> AddNewElement(int intAppID, string strElementName, bool blIsFuzzy, double dblValue)
        {
            TempEstimationElementBiz objElementBiz = new TempEstimationElementBiz();
            objElementBiz.IsFuzzy = blIsFuzzy;
            objElementBiz.NameA = strElementName;
            objElementBiz.GradeValue = dblValue;
            objElementBiz.Applicant = intAppID;
            objElementBiz.Add();
            TempEstimationElementCol objCol = new TempEstimationElementCol(intAppID);

            IEnumerable<EstimationElementSimple> Returned = from objElement in objCol.Cast<TempEstimationElementBiz>()
                                                            select new EstimationElementSimple() { ID = objElement.ID, Name = objElement.NameA, IsFuzzy = objElement.IsFuzzy, Value = objElement.GradeValue };
            return Returned;

        }
        [Route("api/TempEstimationElementController/GetElementCol")]
        [ActionName("GetElementCol")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public IEnumerable<EstimationElementSimple> GetElementCol(int intAppID)
        {
            TempEstimationElementCol objCol = new TempEstimationElementCol(intAppID);

            IEnumerable<EstimationElementSimple> Returned = from objElement in objCol.Cast<TempEstimationElementBiz>()
                                                            select new EstimationElementSimple() { ID = objElement.ID, Name = objElement.NameA, IsFuzzy = objElement.IsFuzzy, Value = objElement.GradeValue };
            return Returned;
        }
    }
}