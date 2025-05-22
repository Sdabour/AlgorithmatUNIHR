using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.CRM.CRMBusiness;
using SharpVision.RP.RPBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.UMS.UMSBusiness;
namespace AlgorithmatMVC.Controllers.CRMController
{
    [Serializable]
    public class TokenData
    {
        public string grant_type;
        public string client_id;
        public string client_secret;
        public string scope;

    }
    public class ReservationController : Controller
    {
        // GET: Reservation
       [Authorize]
        public ActionResult Index()
        {
            return View("Reservation");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Search()
        {
            string _Status = "";
            string strTemp;
            int intTemp = 0;
            int[] arrInt;
            strTemp = Request.Form["chkStatusReservedWithAmount"];
            if (strTemp!= null&& strTemp.ToUpper() == "ON")
            {
                if (_Status != "")
                    _Status += ",";
                _Status +=  "2" ;
            }
            strTemp = Request.Form["chkStatusContracted"];
            if (strTemp != null && strTemp.ToUpper() == "ON")
            {
                if (_Status != "")
                    _Status += ",";
                _Status += "3";
            }
            strTemp = Request.Form["chkStatusFinished"];
            if (strTemp != null && strTemp.ToUpper() == "ON")
            {
                if (_Status != "")
                    _Status += ",";
                _Status += "4";
            }
            strTemp = Request.Form["chkStatusCanceled"];
            if (strTemp!= null && strTemp.ToUpper() == "ON")
            {
                if (_Status != "")
                    _Status += ",";
                _Status += "6";
            }
            string _Note = Request.Form["txtReservationNote"];
            bool _ReservationDateRange = true;
            DateTime _ReservationStartDate = DateTime.Now;
            DateTime _ReservationEndDate = DateTime.Now;
            strTemp = Request.Form["dtReservationFrom"];
            _ReservationDateRange &= DateTime.TryParse(strTemp,out _ReservationStartDate);
            strTemp = Request.Form["dtReservationTo"];
            _ReservationDateRange &= DateTime.TryParse(strTemp, out _ReservationEndDate);

            bool _ContractDateRange = true;
            DateTime _ContractingStartDate = DateTime.Now;
            DateTime _ContractingEndDate = DateTime.Now;
            strTemp = Request.Form["dtContractFrom"];
            _ContractDateRange &= DateTime.TryParse(strTemp, out _ContractingStartDate);

            strTemp = Request.Form["dtContractTo"];
            _ContractDateRange &= DateTime.TryParse(strTemp, out _ContractingEndDate);

            string _CustomerName = "";
            //_JobBiz, _CountryBiz;
            strTemp = Request.Form["txtUnitCode"];
            string _UnitName = strTemp == null ? "" : strTemp;

            CellBiz _SearchCellBiz = new CellBiz();
            double _FromSurvey = 0;
            double _ToSurvey = 0;
            int _DealStatus = 0;
            strTemp = Request.Form["rdDeal"];
            _DealStatus = strTemp!= null &&  strTemp != ""&& int.TryParse(strTemp,out intTemp)?intTemp:0;


            int _FloorOrder = 0;
            int _AttchmentStatus = 0;
            strTemp = Request.Form["rdFree"];
            int intFreeStatus = strTemp!= null&& int.TryParse(strTemp,out intTemp) ? 
                intTemp :0;
            strTemp = Request.Form["rdNew"];
            int _NewStatus = strTemp != null && int.TryParse(strTemp, out intTemp) ?
                intTemp : 0;
            int _ParentStatus = 0;
            UnitTypeBiz _UnitTypeBiz;
            List<int> lstIDs;
            BranchCol _SelectedBranchCol = new BranchCol(true);
            strTemp = Request.Form["BranchCheckedCol"];
            if(strTemp!=null&& strTemp!= "")
             {
                lstIDs = System.Web.Helpers.Json.Decode<List<int>>(strTemp);
                foreach (int intID in lstIDs)
                    _SelectedBranchCol.Add(new BranchBiz() { ID = intID });
            }
            SalesManCol _SelectedSalesManCol = new SalesManCol(true);

            bool _StatusDateRange = true;
            DateTime _StatusStartDate = DateTime.Now;
            DateTime _StatusEndDate = DateTime.Now;
            strTemp = Request.Form["dtStatusFrom"];
            _StatusDateRange &= DateTime.TryParse(strTemp, out _StatusStartDate);
            strTemp = Request.Form["dtStatusTo"];
            _StatusDateRange &= DateTime.TryParse(strTemp, out _StatusEndDate);

            int _DelegateStatus = 0;
            int _SoldStatus = 0;
            strTemp = Request.Form["rdSold"];
            _SoldStatus = strTemp != null && int.TryParse(strTemp, out intTemp) ? intTemp : 0;

            int _IsReservedStatus = 0;

            CampaignBiz _CampaignBiz = new CampaignBiz();
            ResubmissionTypeCol _ResubmissionTypeCol = new ResubmissionTypeCol(true);
           
            strTemp = Request.Form["ResubmissionTypeCheckedCol"];
            
            if ( strTemp!= null&& strTemp != "")
            {
                 lstIDs = System.Web.Helpers.Json.Decode<List<int>>(strTemp);
                foreach (int intID in lstIDs)
                    _ResubmissionTypeCol.Add(new  ResubmissionTypeBiz { ID = intID });
            }
            strTemp = Request.Form["cmbCancelationType"];
            intTemp = 0;
            CancelationTypeBiz _CancelationTypeBiz = new CancelationTypeBiz();
            if (int.TryParse(strTemp,out intTemp))
             _CancelationTypeBiz = new CancelationTypeBiz() { ID=intTemp};
            //_CancelationTypeBiz.ID =  Request.Form[""];
            int _PayBackCompletedStatus = 0;
            bool _IsResubmissionDateRange = false;
            DateTime dtResubmissionStartDate = DateTime.Now;

            DateTime dtResubmissionEndDate = DateTime.Now;
            string _ResubmissionSerial = "";
            int _TenancyStatus = 0;
            BrandCol _SelectedBrandCol = new BrandCol(true);
            ProjectCol _SelectedProjectCol = new ProjectCol(true);
            strTemp = Request.Form["ProjectCheckedCol"];

            if (strTemp != null && strTemp != "")
            {
                lstIDs = System.Web.Helpers.Json.Decode<List<int>>(strTemp);
                foreach (int intID in lstIDs)
                    _SelectedProjectCol.Add(new ProjectBiz { ID = intID });
            }
            TowerCol _SelectedTowerCol = new TowerCol(true);
          ReservationCol  _ReservationCol =
                new ReservationCol(_Status, _Note,
           _ReservationDateRange
           , _ReservationStartDate, _ReservationEndDate, _ContractDateRange, _ContractingStartDate
           , _ContractingEndDate, _CustomerName, null, null, _UnitName, _SearchCellBiz, _FromSurvey, _ToSurvey,
           _DealStatus, _FloorOrder, _AttchmentStatus, intFreeStatus, _NewStatus, _ParentStatus, null, _SelectedBranchCol, _SelectedSalesManCol, _StatusDateRange, _StatusStartDate, _StatusEndDate,
           _DelegateStatus, _SoldStatus, 0, 0, 0, 0, null, 0, 0, _IsReservedStatus, _CampaignBiz, 0, _ResubmissionTypeCol, _CancelationTypeBiz, _PayBackCompletedStatus
           , _IsResubmissionDateRange, dtResubmissionStartDate,
           dtResubmissionEndDate
           , _ResubmissionSerial, _TenancyStatus, _SelectedBrandCol, _SelectedProjectCol, _SelectedTowerCol);

            ViewBag.ReservationCol = _ReservationCol;
            IEnumerable<int> objIDCol = from objReservation in _ReservationCol.Cast<ReservationBiz>()
                                        select objReservation.ID;
            int[] arrIDs = objIDCol.ToArray<int>();
            ViewBag.ReservationIDs = System.Web.Helpers.Json.Encode(arrIDs);
            Session["ReservationCol"] = _ReservationCol;
            
            return View("Reservation");
        }
        [Authorize]
        [HttpPost]
        public ActionResult ReservationComment()
        {
            ReservationCol objSelectedCol = new ReservationCol(true);
            if (Session["ReservationCol"] != null)
            {
                string strTemp = "";
                string strCheck = "chkReservation";
                string strResult = "";
                ReservationCol objCol = new ReservationCol(true);
                objCol = (ReservationCol)Session["ReservationCol"];
                IEnumerable<ReservationBiz> objReservationCol = from objReservationBiz in objCol.Cast<ReservationBiz>()
                                                       select objReservationBiz;

                foreach (ReservationBiz objBiz in objReservationCol)
                {
                    //strTemp = Request.Form["ProjectCheckedCol"];
                    strTemp = strCheck + objBiz.ID.ToString();

                    strResult = Request.Form[strTemp];
                    if (strResult == "on")
                    {
                        objSelectedCol.Add(objBiz);
                    }
                }
            }
            ViewBag.ReservationCol = objSelectedCol;
            Session["SelectedReservationCol"] = objSelectedCol;
            return View("ReservationComment");
        }
        [Authorize]
        [HttpPost]
        public ActionResult CommentReservation()
        {


            ReservationCol objCol = new ReservationCol(true);
            if (Session["SelectedReservationCol"] != null)
            {
                objCol = (ReservationCol)Session["SelectedReservationCol"];
                string strComment = Request.Form["txtComment"];
              
                if (objCol.Count > 0)
                {
                    UserBiz objUserBiz = (UserBiz)Session["CurrentUser"];
                    objCol.AddNote(strComment);
                }
            }
            return View("Reservation");
        }
    }
}