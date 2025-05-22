using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.SystemBase;
using SharpVision.CRM.CRMBusiness;
using SharpVision.UMS.UMSBusiness;
using System.Web.Helpers;
namespace AlgorithmatMVC.Controllers.CRMController
{
    public class UnitController : Controller
    {
        #region Private Method
        string GetUnitColHTMLTable(UnitCol objCol)
        {
            string Returned = "<table>";
            Returned += "<tr>";
            Returned += "<th>الكود</th>";
            Returned += "<th>النوع</th>";
            Returned += "<th>المشروع</th>";
            Returned += "<th>البرج</th>";
            Returned += "<th>الدور</th>";
            Returned += "<th>الحالة</th>";
            Returned += "<th>المساحة</th>";
            Returned += "<th>العميل</th>";
            Returned += "<th>الملحقات</th>";
            Returned += "<th>ملاحظات</th>";
            Returned += "</tr>";
            foreach (UnitBiz objBiz in objCol)
            {
                Returned += "<tr>";
                Returned += "<td>" + objBiz.FullName + "</td>";
                Returned += "<td>" +  objBiz.UsageTypeBiz.Name +"</td>";
                Returned += "<td>" +  objBiz.TowerBiz.ProjectBiz.Name +"</td>";
                Returned += "<td>" + objBiz.TowerBiz.Name + "</td>";
                Returned += "<td>" +  objBiz.FloorBiz.Name + "</td>";
                Returned += "<td>" +  objBiz.StatusStr + "</td>";
                Returned += "<td>" +   objBiz.Survey +"</td>";
                Returned += "<td>" +  objBiz.CustomerStr +"</td>";
                Returned += "<td>" +  objBiz.PeripheralFullName +"</td>";
                Returned += "<td>" + objBiz.Desc + "</td>";
                Returned += "</tr>";
            }
            Returned += "</table>";

            return Returned;
        }
        #endregion
        // GET: Unit
        [Authorize]
        public ActionResult Index()
        {
          
            return View("Unit");
        }
        [Authorize]
       [HttpPost]
        public ActionResult Search()
        {
            #region IntializeConnection
            
            #endregion
          
            int intStatus = 0;
            string strReservationStatus = "";
            int intDelivereryStatus = 0;
            int intTowerDeliveryStatus = 0;
             string strTowerDelivered = Request.Form["rdTowerDelivered"];
            int intTemp;
            int intFloorOrder = 0;
            string strTemp = Request.Form["cmbFloor"];
            int.TryParse(strTemp,out intFloorOrder);
            strTemp = Request.Form["txtFloorOrder"];
            
            strTemp = Request.Form["rdReserved"];
            if (strTemp == "")
            { }
            strTemp = Request.Form["cmbModel"];
            intTemp = 0;
            int.TryParse(strTemp, out intTemp);
            UnitModelBiz objModelBiz = new UnitModelBiz() { ID = intTemp };
            double dblTemp = 0;
            double dblSurveyStart = 0;
            strTemp = Request.Form["txtSurveyStart"];
            double.TryParse(strTemp, out dblSurveyStart);

            double dblSurveyEnd = 0;
            strTemp = Request.Form["txtSurveyEnd"];
            double.TryParse(strTemp, out dblSurveyEnd);
            strTemp = Request.Form["cmbType"];
            intTemp = 0;
            int.TryParse(strTemp, out intTemp);


            bool blIsDeliveryDateRange = false;
            DateTime dtStartDelivery = DateTime.Now;
            DateTime dtEndDelivery = DateTime.Now;
            string strUnitCode = "";
            strTemp = Request.Form["cmbPeripheral"];
            intTemp = 0;
            int.TryParse(strTemp, out intTemp);
            PeripheralTypeBiz objPeripheralType = new PeripheralTypeBiz() { ID = intTemp };
            strTemp = Request.Form["txtPeripheralSurveyStart"];

            double dblStartPeripheralSurvey = 0;
            double.TryParse(strTemp,out dblStartPeripheralSurvey);
            strTemp = Request.Form["txtPeripheralSurveyEnd"];
            double dblEndPeripheralSurvey = 0;
            double.TryParse(strTemp, out dblEndPeripheralSurvey);

            int intUserClose = 0;
            string strFlatNo = Request.Form["txtFlatOrder"];
            strTemp = Request.Form["cmbUsageType"];
            intTemp = 0;
            int.TryParse(strTemp, out intTemp);
            UnitUsageTypeBiz objUsageTypeBiz = new UnitUsageTypeBiz() { ID = intTemp };
            string strFloor = Request.Form["txtFloorOrder"];
            double dblStartPrice = 0;
            strTemp = Request.Form["txtPriceStart"];
            
            double.TryParse(strTemp, out dblStartPrice);

            double dblEndPrice = 0;
            strTemp = Request.Form["txtPriceEnd"];

            double.TryParse(strTemp, out dblEndPrice);
            string strProjectIDs = Request.Form["ProjectCheckedCol"];
            int[] arrIndex;
           arrIndex =  System.Web.Helpers.Json.Decode<int[]>(strProjectIDs);
            if (arrIndex!= null && arrIndex.Length > 0)
            {
                strProjectIDs = "";
                foreach (int intID in arrIndex)
                {
                    if (strProjectIDs != "")
                        strProjectIDs += ",";
                    strProjectIDs += intID.ToString();
                }
            }
            string strTowerIDs = "";
            string strFloorIDs = Request.Form["FloorCheckedCol"];
            arrIndex = System.Web.Helpers.Json.Decode<int[]>(strFloorIDs);
            if (arrIndex!= null && arrIndex.Length > 0)
            {
                strFloorIDs = "";
                foreach (int intID in arrIndex)
                {
                    if (strFloorIDs != "")
                        strFloorIDs += ",";
                    strFloorIDs += intID.ToString();
                }
            }
            strTemp = Request.Form["rdReserved"];
            int.TryParse(strTemp, out intStatus);
            string strUnitName = Request.Form["txtUnitName"];
            CustomerCol objCustomerCol = new CustomerCol(true);
            strTemp = Request.Form["SelectedCustomerCol"];
            if (strTemp != "")
            {
                List<SingleCustomer> arrCustomer = System.Web.Helpers.Json.Decode<List<SingleCustomer>>(strTemp);
                foreach (SingleCustomer objSingleCustomer in arrCustomer)
                    objCustomerCol.Add(new CustomerBiz() { ID = objSingleCustomer._ID });
            }
            UnitTypeBiz objUnitTYpeBiz = new UnitTypeBiz() { ID = intTemp };
            UnitCol objUnitCol = new UnitCol(null, objModelBiz, objCustomerCol,strUnitName, ""
                , dblSurveyStart, dblSurveyEnd, intStatus, strReservationStatus,
                intFloorOrder, objUnitTYpeBiz, intDelivereryStatus, intTowerDeliveryStatus,
                blIsDeliveryDateRange, dtStartDelivery,
               dtEndDelivery, strUnitCode, objPeripheralType,
               dblStartPeripheralSurvey, dblEndPeripheralSurvey,
              intUserClose, strFlatNo,
              objUsageTypeBiz, strFloor
            , dblStartPrice, dblEndPrice,
            strProjectIDs, strTowerIDs, strFloorIDs);
             //string strHTML =  GetUnitColHTMLTable(objUnitCol);

            ViewBag.UnitCol = objUnitCol;
            IEnumerable<string> objIDCol = from objUnit in objUnitCol.Cast<UnitBiz>()
                             select objUnit.ID.ToString();
            
            string[] arrUnitIDs = objIDCol.ToArray<string>();//new string[objIDCol.Count()];
            //for (int intIndex = 0; intIndex < objIDCol.Count(); intIndex++)
            //    arrUnitIDs[intIndex] = objIDCol.ElementAt<string>(intIndex);

            ViewBag.UnitIDs = System.Web.Helpers.Json.Encode(arrUnitIDs);
            Session["UnitIDs"] = ViewBag.UnitIDs;
            Session["UnitCol"] = objUnitCol;
            return View("Unit");
        }
        

    [Authorize]
    [HttpPost]
        public ActionResult UnitClose()
        {
            UnitCol objSelectedCol = new UnitCol(true);
            if (Session["UnitCol"]!= null)
            {
                string strTemp = "";
                string strCheck = "chkUnit";
                string strResult = "";
                UnitCol objCol = new UnitCol(true);
                objCol = (UnitCol)Session["UnitCol"];
                IEnumerable<UnitBiz> objUnitCol = from objUnitBiz in objCol.Cast<UnitBiz>()
                                                  where new List<int>() { 2, 3, 4 }.IndexOf(objUnitBiz.Status) == -1
                                                  select objUnitBiz;

                foreach (UnitBiz objBiz in objUnitCol)
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
            ViewBag.UnitCol =objSelectedCol ;
            IEnumerable<string> objIDCol = from objUnit in objSelectedCol.Cast<UnitBiz>()
                                           select objUnit.ID.ToString();

            string[] arrUnitIDs = objIDCol.ToArray<string>();
            ViewBag.UnitIDs = System.Web.Helpers.Json.Encode(arrUnitIDs);
            Session["SelectedUnitCol"] = objSelectedCol;
            return View("UnitClose");
        }
        [Authorize]
        [HttpPost]
        public ActionResult CloseUnit()
        {
            

            UnitCol objCol = new UnitCol(true);
            if(Session["SelectedUnitCol"]!= null)
            {
                objCol = (UnitCol)Session["SelectedUnitCol"];
                string strCloseReason = Request.Form["txtCloseReason"];
                string strTemp = Request.Form["txtPeriod"];
                bool blIsPermanent = false;
                double dblPeriodVal = 0;
                int intPeriod = 0;
                if (Request.Form["chkIsPermanent"] == "on")
                {
                    blIsPermanent = true;

                }
                else
                {
                    
                    int.TryParse(strTemp, out intPeriod);
                    strTemp = Request.Form["txtPeriod"];
                    double.TryParse(strTemp, out dblPeriodVal);
                    strTemp = Request.Form["cmbPeriod"];
                    int.TryParse(strTemp, out intPeriod);
                }
                if (objCol.Count > 0)
                {
                    UserBiz objUserBiz = (UserBiz)Session["CurrentUser"];
                    objCol.Close(dblPeriodVal, blIsPermanent, (TimeClosePeriod)intPeriod, strCloseReason, objUserBiz);
                 }
            }
            return View("Unit");
        }

        [Authorize]
        [HttpPost]
        public ActionResult OpenUnit()
        {


            UnitCol objCol = new UnitCol(true);
            UnitCol objSelectedCol = new UnitCol(true);
            if (Session["UnitCol"] != null)
            {
                string strTemp = "";
                string strCheck = "chkUnit";
                string strResult = "";
                 
                objCol = (UnitCol)Session["UnitCol"];
                IEnumerable<UnitBiz> objUnitCol = from objUnitBiz in objCol.Cast<UnitBiz>()
                                                  where new List<int>() { 2, 3 }.IndexOf(objUnitBiz.Status) == -1
                                                  select objUnitBiz;

                foreach (UnitBiz objBiz in objCol)
                {
                    //strTemp = Request.Form["ProjectCheckedCol"];
                    strTemp = strCheck + objBiz.ID.ToString();

                    strResult = Request.Form[strTemp];
                    if (strResult == "on")
                    {
                        objSelectedCol.Add(objBiz);
                    }
                }
                if (objSelectedCol.Count> 0)
                {
                    UserBiz objUserBiz = (UserBiz)Session["CurrentUser"];
                    UserBiz objTemp = SysData.CurrentUser;
                    //SysData.CurrentUser = objUserBiz;
                    objSelectedCol.Open();
                    //SysData.CurrentUser = objTemp;
                }

            }
        
            return View("Unit");
        }

        [Authorize]
        [HttpPost]
        public ActionResult UnitResubmission()
        {
            UnitCol objSelectedCol = new UnitCol(true);
            if (Session["UnitCol"] != null)
            {
                string strTemp = "";
                string strCheck = "chkUnit";
                string strResult = "";
                UnitCol objCol = new UnitCol(true);
                objCol = (UnitCol)Session["UnitCol"];
                IEnumerable<UnitBiz> objUnitCol = from objUnitBiz in objCol.Cast<UnitBiz>()
                                                  where new List<int>() { 2, 3, 4 }.IndexOf(objUnitBiz.Status) == -1
                                                  select objUnitBiz;

                foreach (UnitBiz objBiz in objUnitCol)
                {
                    //strTemp = Request.Form["ProjectCheckedCol"];
                    strTemp = strCheck + objBiz.ID.ToString();

                    strResult = Request[strTemp];
                    if (strResult == "on")
                    {
                        objSelectedCol.Add(objBiz);
                    }
                }
            }
            ViewBag.UnitCol = objSelectedCol;
            Session["SelectedUnitCol"] = objSelectedCol;
            return View("UnitClose");
        }
        [Authorize]
        [HttpPost]
        public ActionResult AsignUnitResubmission()
        {


            UnitCol objCol = new UnitCol(true);
            if (Session["SelectedUnitCol"] != null)
            {
                objCol = (UnitCol)Session["SelectedUnitCol"];
                string strCloseReason = Request.Form["txtCloseReason"];
                string strTemp = Request.Form["txtPeriod"];
                bool blIsPermanent = false;
                double dblPeriodVal = 0;
                int intPeriod = 0;
                if (Request.Form["chkIsPermanent"] == "on")
                {
                    blIsPermanent = true;

                }
                else
                {
                    int.TryParse(strTemp, out intPeriod);
                    strTemp = Request.Form["txtPeriod"];
                    double.TryParse(strTemp, out dblPeriodVal);
                }
                if (objCol.Count > 0)
                {
                    UserBiz objUserBiz = (UserBiz)Session["CurrentUser"];
                    objCol.Close(dblPeriodVal, blIsPermanent, (TimeClosePeriod)intPeriod, strCloseReason, objUserBiz);
                }
            }
            return View("Unit");
        }
        public ActionResult SubUnit()
        {

            return View("SubUnit");
        }
    }
}