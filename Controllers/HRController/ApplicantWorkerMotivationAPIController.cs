using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using SharpVision.HR.HRBusiness;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class ApplicantValue
    {
        public int Reference;
        public string Code;
        public string Name;
        public double Value;
        public int User;
    }
    public class MotivationCostFactor
    {
        public bool Reviewed;
        public List<ApplicantValue> lstValue;
    }
    public class ApplicantMotivationSearch {
        public List<int> lstCostIDs = new List<int>();
        public int Statement;
    }
    public class ApplicantWorkerMotivationAPIController : ApiController
    {
        [HttpPost]
        public void UploadMotivationLst(MotivationCostFactor objFactor)
        {
            List<ApplicantValue> lstApplicantValue = objFactor.lstValue;
            DataTable dtTemp = new DataTable();
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ApplicantCode"), new DataColumn("Value"), new DataColumn("CurrentUser") });
            DataRow objDr;
            int intStatement = lstApplicantValue.Count > 0 ? lstApplicantValue[0].Reference : 0;

            foreach(ApplicantValue objValue in lstApplicantValue)
            {
                objDr = dtTemp.NewRow();
                objDr["ApplicantCode"] = objValue.Code;
                objDr["Value"] = objValue.Value;
                objDr["CurrentUser"] = objValue.User;
                dtTemp.Rows.Add(objDr);
            }
            MotivationStatementBiz objBiz = new MotivationStatementBiz() { ID = intStatement };
            objBiz.UploadData(objFactor.Reviewed,dtTemp);
        }
        [Route("api/ApplicantWorkerMotivationAPI/GetMotivationStatemet")]
        [ActionName("GetMotivationStatemet")]

        [HttpGet]
        public List<MotivationStatementSimple> GetMotivationStatemet()
        {
            MotivationStatementCol objCol = new MotivationStatementCol();
            List<MotivationStatementSimple> Returned =objCol.Cast<MotivationStatementBiz>().OrderByDescending(x=>x.ID).Select(y=>y.GetSimple()).ToList();

            return Returned;
        }
        [Route("api/ApplicantWorkerMotivationAPI/GetCostCenter")]
        [ActionName("GetCostCenter")]
        
        [HttpGet]
        public List<CostCenterSimple> GetCostCenter()
        {
            CostCenterHRCol objCol = new CostCenterHRCol();

            return objCol.Cast<CostCenterHRBiz>().Select(x => x.GetSimple()).ToList();


        }


        [Route("api/ApplicantWorkerMotivationAPI/GetApplicantWorkerMotivation")]
        [ActionName("GetApplicantWorkerMotivation")]

        [HttpPost]
        public List<ApplicantWorkerMotivationSimple> GetApplicantWorkerMotivation(ApplicantMotivationSearch objSearch)
        {
            MotivationStatementBiz objMotivation = new MotivationStatementBiz() { ID = objSearch.Statement };
            MotivationStatementCol objMotivationCol = new MotivationStatementCol(true);
            if(objMotivation.ID!=0)
            objMotivationCol.Add(objMotivation);
            CostCenterHRCol objCostCol = new CostCenterHRCol(true);
            if (objSearch.lstCostIDs.Count > 0)
            {
                foreach (int intID in objSearch.lstCostIDs)
                {
                    if (intID > 0)
                    { objCostCol.Add(new CostCenterHRBiz() { ID = intID }); }
                }
            }
                ApplicantWorkerMotivationStatementCol objCol = new ApplicantWorkerMotivationStatementCol(objMotivationCol, objCostCol, "");

            return objCol.Cast<ApplicantWorkerMotivationStatementBiz>().Select(x => x.GetSimple()).ToList();


        }

    }
}
