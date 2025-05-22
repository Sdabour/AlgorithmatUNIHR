using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.CRM.CRMBusiness;
namespace AlgorithmatMVC.Controllers.CRMController
{
    [Serializable]
    public class SingleReservation
    {
        int _ID;
        string _UnitCode;
        string _CustomerName;
        string _Project;
        bool _IsContracted;
        DateTime _ContractingDate;
        DateTime _ReservationDate;
        string _StatusStr;


        public int ID { get => _ID; set => _ID = value; }
        public string UnitCode { get => _UnitCode; set => _UnitCode = value; }
        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public string Project { get => _Project; set => _Project = value; }
        public bool IsContracted { get => _IsContracted; set => _IsContracted = value; }
        public DateTime ContractingDate { get => _ContractingDate; set => _ContractingDate = value; }
        public DateTime ReservationDate { get => _ReservationDate; set => _ReservationDate = value; }
        public string StatusStr { get => _StatusStr; set => _StatusStr = value; }
    }
    [Serializable]
    public class CamaignCustomerContactSingle
    {
        string _CustomerName;
        string _Date;
        string _Type;
        string _Desc;
        string _Campaign;
        string _Direction;
        string _SMS;
        string _ContactPerson;

    }
    public class ReservationWebController : ApiController
    {
        #region Native Web Function

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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        #endregion
        [Authorize]
        [Route("api/ReservationWebController/GetReservation")]
        [ActionName("GetReservation")]
        [AcceptVerbs("GET", "POST")]

        public IEnumerable<SingleReservation> GetReservation
            (bool blIsContractingDateRange,DateTime dtStartContractingDate
            ,DateTime dtEndContractingDate,bool blIsReservationDateRange
            ,DateTime dtReservationDateStart,DateTime dtReservationEnd
            ,string strUnitCode,string strProjectIDs
            ,string strTowerIDs
            ,string strResubmissionTypeIDs,string strBranchIDs
          )
        {
            //string jsonString1 = Request.

            ProjectCol objProjectCol = new ProjectCol(true);
            TowerCol objTowerCol = new TowerCol(true);
            ResubmissionTypeCol objResubmissionTypeCol
                = new ResubmissionTypeCol(true);

            int[] arrIndex = new int[0];
            if (strProjectIDs != null && strProjectIDs != "")
                arrIndex = System.Web.Helpers.Json.Decode<int[]>(strProjectIDs);
            foreach (int intProjectID in arrIndex)
                objProjectCol.Add(new ProjectBiz() { ID = intProjectID });
            string strCustomerName = "";
            int intDealStatus = 0;
            int intFloorOrder = 0;
            int intFreeStatus = 0;
            int intSoldStatus = 0;
            int intIsReservedStatus = 0;
            int intPayBackCompletedStatus = 0;
            bool blIsResubmissionDateRange = false;

            DateTime dtResubmissionStartDate = DateTime.Now;
            DateTime dtResubmissionEndDate = DateTime.Now;
            CampaignBiz objCampaignBiz = new CampaignBiz();
            int intTenancyStatus = 0;
            CancelationTypeBiz objCancelationTypeBiz = new CancelationTypeBiz();
            ReservationCol objReservationCol =
                new ReservationCol("", "",
           blIsReservationDateRange
           , dtReservationDateStart, dtReservationEnd
           , blIsContractingDateRange, dtStartContractingDate
           , dtEndContractingDate, strCustomerName, null, null, strUnitCode
           , null, 0, 0,
           intDealStatus, intFloorOrder, 0, intFreeStatus
           , 0, 0, null, null, null, false,
           DateTime.Now, DateTime.Now,
           0, intSoldStatus, 0, 0, 0, 0, null, 0, 0
           , intIsReservedStatus, objCampaignBiz, 0
           , objResubmissionTypeCol, objCancelationTypeBiz
           , intPayBackCompletedStatus
           , blIsResubmissionDateRange, dtResubmissionStartDate,
           dtResubmissionEndDate
           , "", intTenancyStatus, new BrandCol(true)
           , objProjectCol, objTowerCol);




            IEnumerable<SingleReservation> Returned = from objReservation in objReservationCol.Cast<ReservationBiz>()
                                                   select new SingleReservation() { ID = objReservation.ID, UnitCode = objReservation.DirectUnitCodeStr
                                                   , CustomerName = objReservation.DirectCustomerStr
                                                   ,Project = objReservation.DirectProjectName,IsContracted=objReservation.IsContracted
                                                   ,ContractingDate=objReservation.ContractingDate
                                                   ,ReservationDate = objReservation.Date
                                                   ,StatusStr=objReservation.StatusStr };



            return Returned;
        }
    }
}