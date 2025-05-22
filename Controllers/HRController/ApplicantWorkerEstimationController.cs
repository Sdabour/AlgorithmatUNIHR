using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.HR.HRBusiness;
using CrystalDecisions.CrystalReports.Engine;
using HRReports;
using System.IO;
using System.Data;
using System.Collections;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class ApplicantWorkerEstimationController : Controller
    {
        // GET: ApplicantWorkerEstimation
       [Authorize]
        public ActionResult Index()
        {
            int intAppID = 0;
            int intStatementID = 0;
            string strTemp = Request["AppID"];
            int.TryParse(strTemp, out intAppID);

            strTemp = "";
            strTemp = Request["StatementID"];
            int.TryParse(strTemp, out intStatementID);
            if (intAppID == 0 || intStatementID == 0)
            {
                return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml");
            }
            if (Session["StatementBiz"] == null|| ((EstimationStatementBiz)Session["StatementBiz"]).ID!= intStatementID || Session["ApplicantCol"] == null|| ((ApplicantWorkerCol)Session["ApplicantCol"])[intAppID.ToString()].ID!= intAppID)
            {
                return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml");
            }

            ApplicantWorkerBiz objApplicantWorkerBiz = ((ApplicantWorkerCol)Session["ApplicantCol"])[intAppID.ToString()];
            EstimationStatementBiz objEstimationStatementBiz = ((EstimationStatementBiz)Session["StatementBiz"]);
            ApplicantWorkerEstimationStatementBiz objStatementBiz = new ApplicantWorkerEstimationStatementBiz(objEstimationStatementBiz, objApplicantWorkerBiz);
            Session["ApplicantEstimationStatement"] = objStatementBiz;
            ViewBag.EstimationStatement = objStatementBiz;
            return View("ApplicantWorkerEstimation");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Save()
        {
            if (Session["ApplicantEstimationStatement"] != null)
            {
                ApplicantWorkerEstimationStatementBiz objStatementBiz = (ApplicantWorkerEstimationStatementBiz)Session["ApplicantEstimationStatement"];
                double dblTemp = 0;
                string strTemp = "";
                string strControl = "";
                strTemp = Request.Form["rdSummary"];
                if (strTemp == "1")
                {
                    objStatementBiz.EstimationStatementIsSum = true;
                    strTemp = Request.Form["txtSummaryTotalPerc"];
                    if (strTemp != null)
                    {
                        double.TryParse(strTemp, out dblTemp);
                        objStatementBiz.EstimationStatementIsSum = true;
                        objStatementBiz.EstimationValue = dblTemp;
                    }
                }
                else
                    objStatementBiz.EstimationStatementIsSum = false;

                if (Request.Form["txtRemarks"] != null)
                    objStatementBiz.Remarks = Request.Form["txtRemarks"];
                if (Request.Form["txtRemarks1"] != null)
                    objStatementBiz.Remarks1 = Request.Form["txtRemarks1"];
                if (Request.Form["txtRemarks2"] != null)
                    objStatementBiz.Remarks2 = Request.Form["txtRemarks2"];

                if (Request.Form["txtRemarks3"] != null)
                    objStatementBiz.Remarks3 = Request.Form["txtRemarks3"];
                if (Request.Form["txtRemarks4"] != null)
                    objStatementBiz.Remarks4 = Request.Form["txtRemarks4"];
                if (Request.Form["txtRemarks5"] != null)
                    objStatementBiz.Remarks5 = Request.Form["txtRemarks5"];
                IEnumerable<ApplicantWorkerEstimationStatementElementBiz> objElementCol = from objElement in objStatementBiz.EstimationStatementElementCol.Cast<ApplicantWorkerEstimationStatementElementBiz>()
                                                                                          where objElement.ElementBiz.ID > 0
                                                                                          select objElement;
                ApplicantWorkerEstimationStatementElementCol objCol = new ApplicantWorkerEstimationStatementElementCol(true);
                                                                            
                foreach (ApplicantWorkerEstimationStatementElementBiz objEstimationElementBiz in objElementCol)//objStatementBiz.EstimationStatementElementCol)
                {
                    dblTemp = 0;
                    strControl = "txtEstimationValue" + objEstimationElementBiz.ElementBiz.ID.ToString();
                    strTemp = Request.Form[strControl];
                    if (double.TryParse(strTemp, out dblTemp))
                    {
                        objEstimationElementBiz.EstimationValue = dblTemp;
                        
                    }
                    //  strControl = "rdFuzzy" + objEstimationElementBiz.ElementBiz.ID.ToString();
                    //strTemp = Request[strControl];
                    //  objEstimationElementBiz.IsFuzzyValue = strTemp == "1";
                    strControl = "chkStopElement" + objEstimationElementBiz.ElementBiz.ID.ToString();
                    if (Request.Form[strControl] != null && Request.Form[strControl].ToLower() == "on")
                    {
                        objEstimationElementBiz.EstimationValue = -1;
                        continue;
                    }


                    strControl = "rdFuzzyDegree"+objEstimationElementBiz.ElementBiz.ID.ToString();
                    strTemp = Request[strControl];
                    if (strTemp != null && objEstimationElementBiz.IsFuzzyValue)
                    {
                        int intFuzzyValue = 0;
                        int.TryParse(strTemp, out intFuzzyValue);
                        objEstimationElementBiz.FuzzyValue = (EstimationFuzzyValue)intFuzzyValue;
                    }
                    
                    
                    objCol.Add(objEstimationElementBiz);
                }

                objStatementBiz.EstimationStatementElementCol.Clear();
                objStatementBiz.EstimationStatementElementCol.Add(objCol);
                objCol.Clear();
                strTemp = Request.Form["lblFlexableElementCount"];
                int intFelxCount = 0;
                //intFelxCount = 2;
                int.TryParse(strTemp, out intFelxCount);
                ApplicantWorkerEstimationStatementElementBiz objElementBiz;
                for (int intIndex = 1; intIndex <= intFelxCount; intIndex++)
                {
                    //                    txtFlexableEstimationDesc
                    //txtFlexableEstimationValue
                    //txtFlexableElementValue
                    strTemp = Request.Form["txtFlexableTempElementDesc" + intIndex.ToString()];
                    if (strTemp == "")
                        continue;
                    objElementBiz = new ApplicantWorkerEstimationStatementElementBiz();
                    objElementBiz.Desc = strTemp;
                    strTemp = Request.Form["txtFlexableEstimationValue" + intIndex.ToString()];
                    dblTemp = 0;
                    double.TryParse(strTemp, out dblTemp);
                    objElementBiz.EstimationValue = dblTemp;
                    strTemp = Request.Form["txtFlexableElementValue" + intIndex.ToString()];
                    dblTemp = 0;
                    double.TryParse(strTemp, out dblTemp);
                    objElementBiz.ElementValue = dblTemp;

                    dblTemp = 0;
                    strTemp = Request.Form["lblFlexableTempElement" + intIndex.ToString()];
                   
                    double.TryParse(strTemp, out dblTemp);
                    objElementBiz.TempElement =(int) dblTemp;

                    dblTemp = 0;
                    strTemp = Request.Form["txtFlexableElementWeight" + intIndex.ToString()];

                    double.TryParse(strTemp, out dblTemp);
                    if (dblTemp > 100)
                        dblTemp = 0;
                    objElementBiz.Weight = dblTemp;

                    objCol.Add(objElementBiz);
                }
                if(objCol.Count>0)
                   objStatementBiz.EstimationStatementElementCol.Add(objCol);

                if (objStatementBiz.ID == 0)
                    objStatementBiz.Add();
                else
                    objStatementBiz.Edit();
                if (Session["StatementBiz"] != null)
                {
                    EstimationStatementBiz objEstimationBiz = (EstimationStatementBiz)Session["StatementBiz"];
                    objEstimationBiz.ApplicantHash = null;
                    Session["StatementBiz"] = objEstimationBiz;
                }
            }

            return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml");
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete()
        {
            if (Session["ApplicantEstimationStatement"] != null)
            {
                ApplicantWorkerEstimationStatementBiz objStatementBiz = (ApplicantWorkerEstimationStatementBiz)Session["ApplicantEstimationStatement"];
                 
                objStatementBiz.Delete();
                if (Session["StatementBiz"] != null)
                {
                    EstimationStatementBiz objEstimationBiz = (EstimationStatementBiz)Session["StatementBiz"];
                    objEstimationBiz.ApplicantHash = null;
                    Session["StatementBiz"] = objEstimationBiz;
                }
            }

            return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml");
        }
        public ActionResult Download_EstimationPDF()
        {

            dsHREstimationApplicant ds = new dsHREstimationApplicant();
            ApplicantWorkerEstimationStatementCol objStatemenetCol = new ApplicantWorkerEstimationStatementCol(true);
            if (Session["ApplicantEstimationStatement"] != null)
            {
                ApplicantWorkerEstimationStatementBiz objStatementBiz = (ApplicantWorkerEstimationStatementBiz)Session["ApplicantEstimationStatement"];
                objStatemenetCol.Add(objStatementBiz);
            }
            else if (Session["EstimationStatementColPrint"] != null)
            {
                objStatemenetCol = (ApplicantWorkerEstimationStatementCol)Session["EstimationStatementColPrint"];
            }
            else
            { return View("~/views/ApplicantWorkerEstimationSearch/ApplicantWorkerEstimationSearch.cshtml"); }
               
            SetKPIData(ds,objStatemenetCol);
            ReportDocument rd = new ReportDocument();
            
            if (objStatemenetCol.Count > 0 && !objStatemenetCol[0].EstimationStatementElementCol.IsAr)
            {
                //rd.Load(Path.Combine(Server.MapPath("~/views/Reports"), "repHREstimationApplicantJobCategoryEstimationFuzzyMIXEDKPIEN.rpt"));
                rd.Load(Path.Combine(Server.MapPath("~/views/Reports"), "SAMEH.rpt"));
            }
            else
            rd.Load(Path.Combine(Server.MapPath("~/views/Reports"), "repHREstimationApplicantJobCategoryEstimationFuzzyMIXEDKPI1.rpt"));
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Evaluation_" + DateTime.Now.ToString("yyyyMMddHHmmss")+".pdf";
            return File(stream, "application/pdf", strPdf);
        }

        #region Private Method
        void SetKPIData(DataSet ds,ApplicantWorkerEstimationStatementCol objStatementCol)
        {
          DataTable  dtSector = ds.Tables["Sector"];
           DataTable dtSectorAdmin = ds.Tables["SectorAdmin"];
            DataTable dtApplicantElement = ds.Tables["ApplicantElement"];
            DataRow drApplicantElement;
           DataTable dtApplicant = ds.Tables["Applicant"];
            DataTable dtGroup = ds.Tables["ApplicantGroup"];
            DataRow drGroup;
            DataRow drApplicant;
            int intSerial = 1;
            GroupElementBiz objGroupElement;
            ApplicantWorkerBiz objApplicantBiz;
            GroupElementCol objGroupCol = new GroupElementCol(true);
            double dblTotalValue, dblValue;
            Hashtable hsTemp;
            foreach (ApplicantWorkerEstimationStatementBiz objStatement in objStatementCol)
            {
                objApplicantBiz = objStatement.ApplicantWorkerBiz;
                drApplicant = dtApplicant.NewRow();
                objGroupCol = new GroupElementCol(true);
                hsTemp = new Hashtable();
                FillApplicantData(intSerial, drApplicant, objStatement);
                dtApplicant.Rows.Add(drApplicant);
                DataRow objDr;
                DataTable dtTemp = objStatement.EstimationStatementElementCol.GetTable();
                var vrGroupCol = from objElement in objStatement.EstimationStatementElementCol.Cast<ApplicantWorkerEstimationStatementElementBiz>()
                                 group objElement by new { ID = objElement.Group, NameA = objElement.ElementBiz.GroupBiz.Name, Order = objElement.Group, Perc = objElement.GroupPerc } into objGroup
                                 select objGroup;


                int intCount = vrGroupCol.Count();
                foreach (var objVr in vrGroupCol)
                {
                    objGroupElement = new GroupElementBiz() { ID = objVr.Key.ID, NameA = objVr.Key.NameA, Order = objVr.Key.Order, Perc = objVr.Key.Perc };
                    //
                    dblTotalValue = objVr.ToList().Sum(X =>
                    {
                        double dblReturned = 0;
                        dblReturned = (X.IsFuzzyValue ? (EstimationFuzzyValueBiz.GetFuzzyValueBiz(X.FuzzyValue).AVGValue / 100) * (X.GroupPerc / 100) :
                        (X.EstimationValue / X.ElementValue) * (X.GroupPerc / 100)) * 100;
                        dblReturned *= (X.Weight / 100);
                        return dblReturned;
                    }
                    );

                    objGroupElement.TotalValue = dblTotalValue;
                    dblValue = objVr.ToList().Sum(X =>
                    {
                        double dblReturned = 0;
                        dblReturned = (X.IsFuzzyValue ? (EstimationFuzzyValueBiz.GetFuzzyValueBiz(X.FuzzyValue).AVGValue / 100) : (X.EstimationValue / X.ElementValue)) * 100;
                        dblReturned *= (X.Weight / 100);
                        return dblReturned;
                    }
                  );

                    objGroupElement.Value = dblValue;
                    drGroup = dtGroup.NewRow();
                    FillGroupData(drGroup, objGroupElement, objApplicantBiz.ID, dblTotalValue, dblValue);
                    dtGroup.Rows.Add(drGroup);
                    if (hsTemp[objGroupElement.ID.ToString()] == null)
                    {
                        hsTemp.Add(objGroupElement.ID.ToString(), objGroupElement);
                        objGroupCol.Add(objGroupElement);
                    }
                }

                drGroup = dtGroup.NewRow();
                objGroupElement = new GroupElementBiz() { NameA = "النتيجة", Perc = 100, Order = 100 };
                dblValue = objGroupCol.Cast<GroupElementBiz>().Sum(x => x.TotalValue);
                dblTotalValue = dblValue;
                objGroupElement.Value = dblValue;
                objGroupElement.TotalValue = dblTotalValue;
                FillGroupData(drGroup, objGroupElement, objApplicantBiz.ID, dblTotalValue, dblValue);
                drGroup["RecommendedAction"] = objGroupElement.FuzzyValue.ProposedAction;
                dtGroup.Rows.Add(drGroup);
                foreach (ApplicantWorkerEstimationStatementElementBiz objElementBiz in objStatement.EstimationStatementElementCol)
                {
                    drApplicantElement = dtApplicantElement.NewRow();
                    FillEstimationElement(drApplicantElement, objElementBiz, objApplicantBiz.ID, intSerial);
                    dtApplicantElement.Rows.Add(drApplicantElement);
                }

                #region Old


                #endregion
                //dtApplicant.Rows.Add(drApplicant);
                intSerial++;
            }


            DataTable dtMainData = ds.Tables["MainData"];
            DataRow drMainData = dtMainData.NewRow();
            string _ReportTitle = "";
            drMainData["ReportTitle"] = _ReportTitle;
            dtMainData.Rows.Add(drMainData);


        }
        void FillEstimationElement(DataRow objDr, ApplicantWorkerEstimationStatementElementBiz objElementBiz, int intApplicantID, int intSeial)
        {
            objDr["ApplicantID"] = intApplicantID;
            objDr["ElementID"] = objElementBiz.ID;
            objDr["Serial"] = intSeial;
            objDr["ElementName"] = objElementBiz.ElementBiz.ID == 0 ? objElementBiz.Desc : objElementBiz.ElementBiz.Name;
            objDr["ElementGroup"] = objElementBiz.ElementBiz.GroupBiz.Name;
            objDr["ElementGroupValue"] = objElementBiz.GroupPerc;
            objDr["ElementResult"] = objElementBiz.EstimationValue;
            objDr["ElementRejected"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.Rejected ? "1" : "";
            objDr["ElementPoor"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.Poor ? "1" : "";
            objDr["ElementAccepted"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.Accepted ? "1" : "";
            objDr["ElementGood"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.Good ? "1" : "";
            objDr["ElementDistinctive"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.Distinctive ? "1" : "";
            objDr["ElementVeryGood"] = objElementBiz.FuzzyValue == EstimationFuzzyValue.VeryGood ? "1" : "";
            objDr["ElementGroupOrder"] = objElementBiz.GroupOrder;
            objDr["ElementGroupPerc"] = objElementBiz.GroupPerc;
            objDr["ElementIsFuzzy"] = objElementBiz.IsFuzzyValue ? "1" : "0";
            objDr["ElementValue"] = objElementBiz.IsFuzzyValue ? 0 : objElementBiz.ElementValue;
            objDr["ElementEstimation"] = objElementBiz.IsFuzzyValue ? "" : (objElementBiz.EstimationValue == 0 ? "" : objElementBiz.EstimationValue.ToString());
            objDr["ElementWeight"] = objElementBiz.Weight.ToString("0");
            double dblPerc = objElementBiz.IsFuzzyValue ? 0 : (
             objElementBiz.EstimationValue == 0 ? 0 :
             ((objElementBiz.EstimationValue * 100) / objElementBiz.ElementValue));
            objDr["ElementPerc"] = objElementBiz.IsFuzzyValue ? "" : (
                objElementBiz.EstimationValue == 0 ? "" :
                ((objElementBiz.EstimationValue * 100) / objElementBiz.ElementValue).ToString("0"));
            objDr["ElementFinalPerc"] = (dblPerc * (objElementBiz.Weight / 100)).ToString("0.0");


        }
        void FillGroupData(DataRow objDr, GroupElementBiz objBiz, int intApplicantID, double dblTotalValue, double dblValue)
        {
            if (intApplicantID == 268)
            {

            }
            objDr["ApplicantID"] = intApplicantID;
            objDr["ApplicantGroup"] = objBiz.Name;
            objDr["ApplicantGroupValue"] = dblValue == 0 ? "" : dblValue.ToString("0");
            objDr["ApplicantGroupTotalValue"] = dblTotalValue == 0 ? "" : dblTotalValue.ToString("0");
            objDr["ApplicantGroupPerc"] = objBiz.Perc.ToString("0");
            objDr["ApplicantGroupOrder"] = objBiz.Order.ToString("0");
            objDr["ApplicantGroupFuzzyVaue"] = objBiz.FuzzyValue.NameA;
        }
        void FillApplicantData(int intSerial, DataRow drApplicant, ApplicantWorkerEstimationStatementBiz objStatementBiz)
        {
            ApplicantWorkerBiz objApplicantBiz = objStatementBiz.ApplicantWorkerBiz;
            drApplicant["Serial"] = intSerial.ToString();

            drApplicant["ApplicantID"] = objApplicantBiz.ID;

            drApplicant["ApplicantName"] = objApplicantBiz.Name;
            drApplicant["ApplicantCode"] = objApplicantBiz.Code;
            if (objApplicantBiz.StartDate.Year != 1900)
                drApplicant["StartDate"] = objApplicantBiz.StartDate.ToString("yyyy-MM-dd");
            else
                drApplicant["StartDate"] = "";

            drApplicant["AdminSector"] = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.FamilyBiz.Name;
            drApplicant["Sector"] = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.Name;
            drApplicant["Branch"] = ((SubSectorBranchBiz)objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz).BranchName;
            drApplicant["Job"] = objApplicantBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
            drApplicant["JobOrder"] = objApplicantBiz.VirualJobNatureTypeBiz.JobCategory.OrderValue;
            drApplicant["ImageLocation"] = objApplicantBiz.ImageBiz.FullURL;
            string strQR = SharpVision.SystemBase.SysUtility.GenerateBarcode(objApplicantBiz.QRStr);
            string imgQRURL = string.Format("data:image/jpg;base64,{0}", strQR);
            drApplicant["QRImage"] = imgQRURL;
            int _CurrentSectorID = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.ID;
            string _CurrentSectorName = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.Name;
           int  _CurrentSectorAdminID = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.FamilyBiz.ID;
            string _CurrentSectorAdminName = objApplicantBiz.CurrentSubSectorBiz.SubSectorBiz.SectorBiz.FamilyBiz.Name;
            drApplicant["SectorID"] = _CurrentSectorID;
            if (objApplicantBiz.VirualJobCategoryEstimationBiz != null)
                drApplicant["JobCategoryEstimationID"] = objApplicantBiz.VirualJobCategoryEstimationBiz.ID;
            else
                drApplicant["JobCategoryEstimationID"] = "0";
            drApplicant["Remarks"] = objStatementBiz.Remarks;
            drApplicant["Remarks1"] = objStatementBiz.Remarks1;
            drApplicant["Remarks2"] = objStatementBiz.Remarks2;
            drApplicant["Remarks3"] = objStatementBiz.Remarks3;
            drApplicant["Remarks4"] = objStatementBiz.Remarks4;
            drApplicant["Remarks5"] = objStatementBiz.Remarks5;
           // FilldtSectorTotals(drApplicant);


        }
      
        #endregion

    }
}