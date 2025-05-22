using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlgorithmatMN.MN.MNBiz;
using AlgorithmatMN.MN.MNReport;
using System.Data;
using SharpVision.SystemBase;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using SharpVision.UMS.UMSBusiness;
using System.Text;
using System.Net.Http;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
namespace AlgorithmatMVC.Controllers.MNController
{
    public enum ROCreditReportType
    {
        RO,
        ROCredit,
        ROLastCredit,
        Project,
        ProjectTower,
        ProjectCredited,
        ProjectTowerCredited,
        ProjectRange

    }

    public enum ProjectCostReportType
    {
        ProjectCostProjectGroup,
        ProjectCostYearGroup
    }
   
    public class MaintainanceController : Controller
    {
        // GET: Maintainance
        public ActionResult Index()
        {
            int intUser = 2;
            string strTemp = Request["User"];
            if (!int.TryParse(strTemp, out intUser))
                intUser = 2;
            UserBiz objUser;
            if (Session["CurrentUser"] != null)
            {
                objUser = (UserBiz)Session["CurrentUser"];
            }
            else
                objUser = new UserBiz(intUser);

            Session["CurrentUser"] = objUser;
            return View("ProjectYear");
        }
       [HttpPost]
       public ActionResult Search()
        {
            int intCreditedStatus=0;
            int intDebitStatus = 0;
            int intRoType = 0;
            string strRo = Request.Form["txtRO"];
            string strProject = Request.Form["cmbProject"];
            string strTower = Request.Form["txtTower"];
            string strTemp = Request.Form["rdDebitCredit"];
            int.TryParse(strTemp, out intDebitStatus);
            strTemp = Request.Form["rdCredited"];
            int.TryParse(strTemp, out intCreditedStatus);
            strTemp = Request.Form["rdType"];
            int.TryParse(strTemp, out intRoType);
             _ProjectYearCol =new ProjectYearCol();
            if (Session["ProjectYear"] != null&& ((ProjectYearCol)Session["ProjectYear"])[0].ProjectCode==strProject)
                _ProjectYearCol = (ProjectYearCol)Session["ProjectYear"];
            else
            {
                int intLastYear = DateTime.Now.Year-1;
                _ProjectYearCol = new ProjectYearCol(intLastYear,strProject);
                Session["ProjectYear"] = _ProjectYearCol;
            }
                DateTime dtStart = DateTime.Now;
            DateTime dtEnd = DateTime.Now;
            bool blIsDateRange = false;
          ROCol  objROCol = _ProjectYearCol.ROCol;
            objROCol = objROCol.GetCol(strRo, blIsDateRange, dtStart, dtEnd, strTower, intDebitStatus, intCreditedStatus, intRoType,0);
            if (objROCol.Count > 100)
                objROCol = objROCol.GetTop100();
            ViewBag.ROCol= objROCol;

            return View("ProjectYear");
        }

        public ActionResult RO()
        {
             
          
            return View("RO");
        }

        
        [Authorize]
        [HttpPost]
        [AcceptVerbs("GET")]

        public ActionResult BankPayment1()
        {
            string objMsg = this.HttpContext.Request.Headers["Authorization"];
            if (objMsg == null ||
           !objMsg.Contains("Bearer"))
            {
               // return null;

            }
            string strTransactionID = Request["TransactionID"];
           
            int intCredit = 0;
            int intCondition = 0;
            int intRO = 0;
            double dblValue = 0;
            string strDesc = "";
            string strTemp = "";
            strTemp = Request["Credit"];
            int.TryParse(strTemp, out intCredit);
            strTemp = Request["RO"];
            int.TryParse(strTemp, out intRO);
            ViewBag.RO = intRO;
            strTemp = Request["Condition"];
            int.TryParse(strTemp, out intCondition);
            strTemp = Request["Desc"];
            strDesc = strTemp;
            strTemp = Request["Value"];
            double.TryParse(strTemp, out dblValue);
            ViewBag.Credit = intCredit;
            ViewBag.Condition = intCondition;
            ViewBag.Value = dblValue;
            ViewBag.Desc = strDesc;
            ViewBag.Transaction = strTransactionID;
            ViewBag.Token = objMsg;
            return View("MNBankPayment");
        }
       
        [HttpGet]
        [AcceptVerbs("GET")]

        public ActionResult BankPayment(string strTransactionID)
        {
            string objMsg = this.HttpContext.Request.Headers["Authorization"];
            if (objMsg == null ||
           objMsg.Contains("Bearer"))
            {
                // return null;

            }
            //string strTransactionID = Request["TransactionID"];

            int intCredit = 0;
            int intCondition = 0;
            int intRO = 0;
            double dblValue = 0;
            string strDesc = "";
            string strTemp = "";

            ViewBag.Credit = intCredit;
            ViewBag.Condition = intCondition;
            ViewBag.Value = dblValue;
            ViewBag.Desc = strDesc;
            ViewBag.Transaction = strTransactionID;
            ViewBag.Token = objMsg;
            if (strTransactionID == null)
                strTransactionID = "";
            TempMaintainancePaymentBiz objPaymetBiz = new TempMaintainancePaymentBiz(strTransactionID);
            if (objPaymetBiz.ID != 0)
            {
                ROBiz objRO = objPaymetBiz.GetROBiz();

                if (CheckTokenProjectRO(objRO.Code, objRO.ProjectCode))
               // if (objRO.Code!= "")
                    return View("MNBankPayment");
                else
                    return null;
            }
            else
                return null;
        }
        #region Security
        bool CheckTokenProjectRO(string strRO, string strProjectCode)
        {
            string objMsg = this.HttpContext.Request.Headers["Authorization"];
            if (objMsg == null ||
           !objMsg.Contains("Bearer"))
            {
                return false;

            }
            //return false;

            
            string strToken = objMsg;
            string strTokenRo = GetClaimValue(strToken, "RO");
            string strTokenProjectCode = GetClaimValue(strToken, "ProjectCode");
            //if(strRO != strTokenRo|| strProjectCode!= strTokenProjectCode)
            return strRO.ToUpper() == strTokenRo.ToUpper() && strProjectCode.ToUpper() == strTokenProjectCode.ToUpper();
        }
        string GetClaimValue(string strToken, string strCalimKey)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = strToken;
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            string Returned = tokenS.Claims.First(claim => claim.Type == strCalimKey).Value;
            return Returned.Replace("'","");
        }
        #endregion
        [HttpPost]
        public ActionResult ROPayment()
        {

            string strRo = Request.Form["lblROCode"];
            string strProject = Request.Form["lblProjectCode"];
            //string strTower = Request.Form["txtTower"];
            ROCol objRoCol = new ROCol(strProject, strRo);

            System.Web.Security.FormsAuthentication.SetAuthCookie("UserName:Anonymous", false);
            ROBiz objRO = new ROBiz();
            if (objRoCol.Count > 0)
                objRO = objRoCol[0];
            ViewBag.ROBiz = objRO;
            return View("ROPayment");
        }

        [HttpPost]
        public ActionResult OnlinePayment()
        {
            
            string strRo = Request.Form["lblID"];
            int intID = 0;
            int.TryParse(strRo, out intID);
            
            //string strTower = Request.Form["txtTower"];
            TempMaintainancePaymentBiz objBiz = new TempMaintainancePaymentBiz() { Desc = "سداد قيمة من مصروفات الصيانة",InternalRef=intID };
            objBiz.Add();
            string strKey = objBiz.TempPaymentRef;
          
            return View("ROPayment");
        }
        [HttpPost]
        public ActionResult ROSearch()
        {
            int intCreditedStatus = 0;
            int intDebitStatus = 0;
            int intRoType = 0;
            string strRo = Request.Form["txtRO"];
            string strProject = Request.Form["cmbProject"];
            string strTower = Request.Form["txtTower"];
            ROCol objRoCol = new ROCol(strProject, strRo);
            ROBiz objRO = new ROBiz();
            if (objRoCol.Count > 0)
                objRO = objRoCol[0];
            ViewBag.ROBiz = objRO;
            //ViewBag.ROCol = objROCol;

            return View("RO");
        }
        [HttpPost]
        public ActionResult Download_CreditPDF()
        {
            int intCreditedStatus = 0;
            int intDebitStatus = 0;
            int intRoType = 0;
            string strRo = Request.Form["txtRO"];
            string strProject = Request.Form["txtProject"];
            string strTower = Request.Form["txtTower"];
            string strTemp = Request.Form["rdDebitCredit"];
            int.TryParse(strTemp, out intDebitStatus);
            strTemp = Request.Form["rdCredited"];
            int.TryParse(strTemp, out intCreditedStatus);
            strTemp = Request.Form["rdType"];
            int.TryParse(strTemp, out intRoType);
             _ProjectYearCol = new ProjectYearCol();
           
            int intTemp = 0;
             strTemp = Request.Form["rdReportType"];
       
            int.TryParse(strTemp, out intTemp);
            ROCreditReportType objRoType =  (ROCreditReportType)intTemp;

            ReportDocument rd = new ReportDocument();

            if (Session["ProjectYear"] != null)
                _ProjectYearCol = (ProjectYearCol)Session["ProjectYear"];
            else
            {
                int intLastYear = DateTime.Now.Year - 1;
                _ProjectYearCol = new ProjectYearCol(intLastYear,strProject);
            }
                _RoCol = _ProjectYearCol.ROCol;
            ROCreditReportType objType = (ROCreditReportType)intTemp;
            if (objType == ROCreditReportType.ROCredit)
            {
                SetRoCreditCol();
              //  rep = new repMNROCredit();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNROCredit.rpt"));
            }
            else if (objType == ROCreditReportType.RO || objType == ROCreditReportType.ROLastCredit)
            {
                SetRoCol();
                if (objType == ROCreditReportType.RO)
                  //  rep = new repMNRO();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNRO.rpt"));
                else
                    //rep = new repMNROLastCredit();
                    rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNROLastCredit.rpt"));
            }
            else if (objType == ROCreditReportType.Project)
            {
                SetProjectTowerSummary();
                //rep = new repMNProjectSUMMARY();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNProjectSUMMARY.rpt"));
            }
            else if (objType == ROCreditReportType.ProjectCredited)
            {
                SetProjectTowerSummary();
                //rep = new repMNProjectSUMMARYC();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNProjectSUMMARYC.rpt"));
            }
            else if (objType == ROCreditReportType.ProjectRange)
            {
                _IsRangeGroup = true;
                SetProjectTowerSummary();
                //  rep = new repMNProjectRangeSUMMARYC();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNProjectRangeSUMMARYC.rpt"));
            }
            else if (objType == ROCreditReportType.ProjectTowerCredited)
            {
                _IsTowerGroup = true;
                SetProjectTowerSummary();
               // rep = new repMNProjectTowerSUMMARYC();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNProjectTowerSUMMARYC.rpt"));
            }
            else
            {
                _IsTowerGroup = true;
                SetProjectTowerSummary();
                // rep = new repMNProjectTowerSUMMARY();
                rd.Load(Path.Combine(Server.MapPath("~/views/MNReports"), "repMNProjectTowerSUMMARY.rpt"));
            }
            #region PDF
            rd.SetDataSource(_Ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "ROCredit_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
            #endregion

        }
        #region Private Data For Reports
        ROCol _RoCol;
        dsMNROCredit _Ds = new dsMNROCredit();
        string _Title = "";
        ProjectCostCol _CostCol;
        ROCostCol _ROCostCol;
        ProjectYearCol _ProjectYearCol;
        bool _IsTowerGroup;
        bool _IsRangeGroup;
        ROCreditReportType _ROReportType = ROCreditReportType.RO;

        void SetMainData()
        {

            DataTable dtMain = _Ds.Tables["Main"];
            DataRow objDr = dtMain.NewRow();
            objDr["Title"] = _Title;
            objDr["User"] = SysData.CurrentUser.Name;

            dtMain.Rows.Add(objDr);

        }
        void SetRoCol()
        {
            SetMainData();
            DataTable dtCredit = _Ds.Tables["ROCredit"];
            List<ROBiz> lstRO = (from objROBiz in _RoCol.Cast<ROBiz>()
                                 where objROBiz.RangeBiz.Desc != ""
                                 select objROBiz).ToList();
            if (lstRO.Count == 0)
                lstRO = _RoCol.Cast<ROBiz>().ToList();
            foreach (ROBiz objRo in lstRO)
            {
                DataRow objDr = dtCredit.NewRow();
                SetRo(objDr, objRo);
                dtCredit.Rows.Add(objDr);
            }

        }
        void SetRoCreditCol()
        {
            SetMainData();
            DataTable dtCredit = _Ds.Tables["ROCredit"];
            DataRow objDr;
            foreach (ROBiz objRo in _RoCol)
            {
                foreach (CreditBiz objCreditBiz in objRo.CreditCol)
                {
                    objDr = dtCredit.NewRow();
                    objCreditBiz.ROBiz = objRo;
                    SetCredit(objDr, objCreditBiz);
                    dtCredit.Rows.Add(objDr);
                }
            }

        }
        void SetRo(DataRow objDr, ROBiz objBiz)
        {
            CreditBiz objCreditBiz = new CreditBiz();
            if (objBiz.CreditCol.Count > 0)
                objCreditBiz = objBiz.CreditCol[objBiz.CreditCol.Count - 1];
            double dblIntialValue, dblClosingValue;
            dblIntialValue = objBiz.InitialMaintainanceValue;
            dblClosingValue = objBiz.Closing;
            objDr["ROID"] = objBiz.ID;
            objDr["ROCode"] = objBiz.Code;
            objDr["ROProjectCode"] = objBiz.ProjectCode;
            objDr["CustomerName"] = objBiz.Customer;
            objDr["ContractNo"] = objBiz.SapContract;
            objDr["ROArea"] = objBiz.Area;
            objDr["ROType"] = objBiz.Type == 1 ? "سكنى" : (objBiz.Type == 2 ? "تجاري" : "اداري");
            //objDr["StartDate"] = objBiz.;
            objDr["DeliveryDate"] = objBiz.DeliveryDate.ToString("yyyy-MM-dd");
            objDr["IsEnded"] = objBiz.IsEnded;
            objDr["EndDate"] = objBiz.IsEnded ? objBiz.EndDate.ToString("yyyy-MM-d") : "";
            objDr["InitialValue"] = objBiz.InitialMaintainanceValue.ToString("0,0");
            objDr["FirstYear"] = objBiz.CreditCol.Count > 0 ? objBiz.CreditCol[0].Year.ToString() : "";
            objDr["LastYear"] = objCreditBiz.Year.ToString();
            objDr["TotalBonus"] = _ROReportType != ROCreditReportType.ROLastCredit ? ((objBiz.CreditCol.Count > 0 ? objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.BonusValue) : 0).ToString("0,0")) : (objCreditBiz.BonusValue > 0 ? objCreditBiz.BonusValue : 0).ToString();
            objDr["TotalCost"] = _ROReportType != ROCreditReportType.ROLastCredit ? (objBiz.CreditCol.Count > 0 ? objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.Cost) : 0).ToString("0,0") : (objCreditBiz.Cost.ToString("0,0"));

            objDr["LastCredit"] = _ROReportType != ROCreditReportType.ROLastCredit ? objBiz.Closing.ToString("0,0") :
                ((objCreditBiz.CrditInitialValue > 0 ? objCreditBiz.CrditInitialValue : 0) - objCreditBiz.Cost + objCreditBiz.BonusValue).ToString();
            objDr["ROArea"] = objBiz.Area;
            objDr["Required"] = objBiz.InitialMaintainanceValue - objBiz.Closing > 0 ? objBiz.InitialMaintainanceValue - objBiz.Closing : 0;
            objDr["RequiredMaintainance"] = dblIntialValue - dblClosingValue > 0 ? (dblIntialValue - dblClosingValue > dblIntialValue ? dblIntialValue : dblIntialValue - dblClosingValue) : 0;

            objDr["RangeStart"] = objBiz.RangeBiz.StartValue;
            objDr["RangeDesc"] = objBiz.RangeBiz.Desc;
            if (_ROReportType == ROCreditReportType.ROLastCredit)
            {
                double dblCLosing = ((objCreditBiz.CrditInitialValue > 0 ? objCreditBiz.CrditInitialValue : 0) - objCreditBiz.Cost + objCreditBiz.BonusValue);
                objDr["CreditClosingValue"] = dblCLosing > 0 ? 0 : -1 * dblCLosing;
                if (objCreditBiz.ROBiz.Area > 0)
                    objDr["CreditCostPerMeter"] = objCreditBiz.Cost / objCreditBiz.ROBiz.Area;
                objDr["CreditCost"] = objCreditBiz.Cost;
                objDr["TotalPayment"] = objCreditBiz.PaymentValue;
            }
            objDr["Value"] = objBiz.Value;
            objDr["ContractingDate"] = objBiz.ContractingDate;
        }
        void SetCredit(DataRow objDr, CreditBiz objBiz)
        {
            SetRo(objDr, objBiz.ROBiz);
            objDr["CreditID"] = objBiz.ID;
            objDr["CreditYear"] = objBiz.Year;
            objDr["CreditInitialValue"] = objBiz.CrditInitialValue.ToString("0,0");
            objDr["CreditBonus"] = objBiz.BonusValue.ToString("0,0");
            objDr["CreditCost"] = objBiz.Cost.ToString("0,0");

            objDr["CreditClosingValue"] = _ROReportType == ROCreditReportType.ROLastCredit ? objBiz.CostDiff.ToString("0, 0") : objBiz.Closing.ToString("0,0");
            objDr["TotalPayment"] = objBiz.PaymentValue.ToString("0");
            objDr["Required"] = objBiz.ROBiz.InitialMaintainanceValue - objBiz.ROBiz.Closing > 0 ? objBiz.ROBiz.InitialMaintainanceValue - objBiz.ROBiz.Closing : 0;




        }
        void SetProjectCostCol()
        {
            SetMainData();
            DataTable dtCost = _Ds.Tables["ProjectCost"];

            foreach (ProjectCostBiz objCost in _CostCol)
            {
                DataRow objDr = dtCost.NewRow();
                SetProjectCost(objDr, objCost);
                dtCost.Rows.Add(objDr);
            }
        }
        void SetProjectCost(DataRow objDr, ProjectCostBiz objBiz)
        {

            objDr["ProjectCode"] = objBiz.Project;
            objDr["CostDate"] = objBiz.Date.ToString("yyyy-MM-dd");
            objDr["CostYear"] = objBiz.Year;
            objDr["CostType"] = objBiz.TypeBiz.NameA;
            //objDr["StartDate"] = objBiz.;
            objDr["CostValue"] = objBiz.Value;


        }

        void SetROCostCol()
        {
            SetMainData();
            DataTable dtCost = _Ds.Tables["ROCost"];

            foreach (ROCostBiz objCost in _ROCostCol)
            {
                DataRow objDr = dtCost.NewRow();
                SetROCost(objDr, objCost);
                dtCost.Rows.Add(objDr);
            }
        }
        void SetROCost(DataRow objDr, ROCostBiz objBiz)
        {

            objDr["ROProject"] = objBiz.ROBiz.ProjectCode;
            objDr["ROID"] = objBiz.ROBiz.ID;
            objDr["ROCode"] = objBiz.ROBiz.Code;
            objDr["Customer"] = objBiz.ROBiz.Customer;
            objDr["CostDate"] = objBiz.Date.ToString("yyyy-MM-dd");
            objDr["CostYear"] = objBiz.Year;
            objDr["CostType"] = objBiz.TypeBiz.NameA;
            //objDr["StartDate"] = objBiz.;
            objDr["CostValue"] = objBiz.Value;
            objDr["ROPart"] = objBiz.ProjectCost == 0 ? "" : "جزأ من مصروف المشروع";
            objDr["CostCredited"] = objBiz.CreditID == 0 ? "" : "تم التسوية";

        }


        void SetProjectYearCol()
        {
            SetMainData();
            DataTable dtProjectYear = _Ds.Tables["ProjectYear"];
            List<ProjectYearBiz> objCol = (from objProjectYear in _ProjectYearCol.Cast<ProjectYearBiz>() where objProjectYear.CreditCol.Count > 0 select objProjectYear).ToList();
            foreach (ProjectYearBiz objYear in objCol)
            {
                DataRow objDr = dtProjectYear.NewRow();
                SetProjectYear(objDr, objYear);
                dtProjectYear.Rows.Add(objDr);
            }
        }
        void SetProjectYear(DataRow objDr, ProjectYearBiz objBiz)
        {

            objDr["ProjectCode"] = objBiz.ProjectCode;
            objDr["Year"] = objBiz.Year;
            objDr["TotalArea"] = objBiz.CreditCol.ROCol.Cast<ROBiz>().Sum(x => x.Area).ToString("0,0");
            objDr["TotalDays"] = objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.Days);
            //objDr["StartDate"] = objBiz.;
            objDr["CountingUnit"] = objBiz.CostPart;
            objDr["TotalCost"] = objBiz.CostCol.Cast<ProjectCostBiz>().Sum(x => x.Value);
            objDr["RONo"] = objBiz.CreditCol.Count;
            objDr["InitialValue"] = objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.CrditInitialValue);
            objDr["TotalProfit"] = objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.BonusValue);
            objDr["ClosingValue"] = objBiz.CreditCol.Cast<CreditBiz>().Sum(x => x.Closing);

        }
        void SetProjectTowerSummary()
        {
            SetMainData();
            var vrTowerCol = from objRo in _RoCol.Cast<ROBiz>()
                             where !_IsRangeGroup || objRo.RangeBiz.Desc != ""
                             orderby objRo.ProjectCode, objRo.TowerCode
                             group objRo by new { ProjectCode = objRo.ProjectCode, TowerCode = _IsTowerGroup ? objRo.TowerCode : "", RangeDesc = _IsRangeGroup ? objRo.RangeBiz.Desc : "", RangeStart = _IsRangeGroup ? objRo.RangeBiz.StartValue : 0 } into objTower
                             select objTower;
            DataTable Returned = _Ds.Tables["ProjectTowerSummary"];
            DataRow objDr;
            double dblTemp = 0;
            foreach (var vrTower in vrTowerCol)
            {
                objDr = Returned.NewRow();
                objDr["ProjectCode"] = vrTower.Key.ProjectCode;

                objDr["TowerCode"] = vrTower.Key.TowerCode;
                // objDr["اجمالى_مساحة"] = vrTower.ToList().Sum(x => x.Area);

                objDr["RONo"] = vrTower.ToList().Count;


                objDr["TotalCost"] = vrTower.ToList().Sum(x => x.CreditCol.Cast<CreditBiz>().Sum(objCredit => objCredit.Cost));

                objDr["TotalProfit"] = vrTower.ToList().Sum(x => x.CreditCol.Cast<CreditBiz>().Sum(objCredit => objCredit.BonusValue));
                objDr["DebitCount"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing < 0 ? 1 : 0).ToString("0");
                objDr["DebitValue"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing < 0 ? (x.CreditCol[x.CreditCol.Count - 1].Closing * -1) : 0).ToString("0,000");
                //objDr["عدد_مصفر"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing == 0 ? 1 : 0).ToString("0");
                objDr["CreditCount"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing > 0 ? 1 : 0).ToString("0");


                objDr["CreditValue"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 && x.CreditCol[x.CreditCol.Count - 1].Closing > 0 ? x.CreditCol[x.CreditCol.Count - 1].Closing : 0).ToString("0,000");

                objDr["ClosingValue"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 ? x.CreditCol[x.CreditCol.Count - 1].Closing : 0).ToString("0,000");

                objDr["InitialValue"] = vrTower.ToList().Sum(x => x.CreditCol.Count > 0 ? x.CreditCol[0].CrditInitialValue : 0).ToString("0,000");

                objDr["Required"] = (vrTower.ToList().Sum(x => x.Required)).ToString("0,000");
                objDr["CreditedPlusMoreCount"] = vrTower.ToList().Sum(x => x.Closing > x.InitialMaintainanceValue ? 1 : 0).ToString("0");
                objDr["CreditedPlusMoreValue"] = vrTower.ToList().Sum(x => x.Closing > x.InitialMaintainanceValue ? x.Closing : 0).ToString("0");

                objDr["CreditedPlusLessCount"] = vrTower.ToList().Sum(x => x.Closing > 0 && x.Closing < x.InitialMaintainanceValue ? 1 : 0).ToString("0");
                objDr["CreditedPlusLessValue"] = vrTower.ToList().Sum(x => x.Closing > 0 && x.Closing < x.InitialMaintainanceValue ? x.Closing : 0).ToString("0");
                objDr["CreditedPlusLessRequired"] = vrTower.ToList().Sum(x => x.Closing > 0 && x.Closing < x.InitialMaintainanceValue ? x.InitialMaintainanceValue - x.Closing : 0).ToString("0");


                objDr["CreditedMinusCount"] = vrTower.ToList().Sum(x => x.Closing < 0 ? 1 : 0).ToString("0");
                objDr["CreditedMinusValue"] = vrTower.ToList().Sum(x => x.Closing < 0 ? x.Closing : 0).ToString("0");

                objDr["CreditedMinusRequired"] = vrTower.ToList().Sum(x => x.Closing < 0 ? x.InitialMaintainanceValue - x.Closing : 0).ToString("0");
                objDr["RangeDesc"] = vrTower.Key.RangeDesc;
                objDr["RangeStart"] = vrTower.Key.RangeStart;
                Returned.Rows.Add(objDr);
            }

        }
        #endregion
    }
}