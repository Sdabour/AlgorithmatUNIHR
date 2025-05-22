using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
using SharpVision.UMS.UMSBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerManyStatementCol : CollectionBase
    {
        #region Private Data
        double _SumBaseSalary = -1;
        double _SumIncreaseValue = -1;
        double _SumTelSalaryDetail = -1;
        double _SumTransferSalaryDetail = -1;
        double _SumFeedingSalaryDetail = -1;
        double _SumTotalSalary = -1;
        double _SumTotalAbsence = -1;
        double _SumTotalPenalty = -1;
        #endregion
        #region Constructors
        public ApplicantWorkerManyStatementCol(bool IsEmpty)
        {
        }
        //MainUsed
        public ApplicantWorkerManyStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementCol objGlobalStatementCol,
            CostCenterHRBiz objCostCenterHRBiz, byte btOnlyWork,
            byte btHasMotivation, bool blIsDependOnStartDate, DateTime dtStartDate, bool blInCludeAllApplicant, string strApplicantIDs,
            byte byStatementStatus, CostCenterHRBiz objCostCenterCheckHRBiz)
        {
            //MotivationStatementBiz objMotivationStatementBiz = MotivationStatementBiz.MotivationStatement;
            //GlobalStatementCol objGlobalStatementCol = objMotivationStatementBiz.GlobalStatementCol.GlobalStatementCol;
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
            if (objGlobalStatementCol == null || objGlobalStatementCol.Count == 0)
            {
                objGlobalStatementCol = objMotivationStatementBiz.GlobalStatementCol.GlobalStatementCol;
            }
            objDb.MotivationStatementCostCenterIDSearch = objCostCenterHRBiz.ID;
            //objDb.MotivationStatementCostCenterIDsSearch = strCostCenterIDs
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.MotivationCostCenterIDs = objCostCenterHRBiz.ID.ToString();
            if (objCostCenterCheckHRBiz == null)
                objCostCenterCheckHRBiz = new CostCenterHRBiz();
            if (objCostCenterCheckHRBiz.ID != 0 && objCostCenterHRBiz.ID != objCostCenterCheckHRBiz.ID)
                objDb.MotivationCostCenterChildID = objCostCenterCheckHRBiz.ID;
            objDb.WorkStatus = btOnlyWork;

            objDb.HasMotivationSearch = btHasMotivation;
            objDb.MotivationTypeSearch = objMotivationStatementBiz.MotivationTypeBiz.ID;

            objDb.IsDependOnStartDateInMotivation = blIsDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;
            objDb.MotivationStatusSearch = byStatementStatus;
            if (!blInCludeAllApplicant)
                objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.GetApplicantMainData();
            DataTable dtTempValue = new DataTable();
            
 
            DataRow[] arrDr = dtTemp.Select("MotivationStopped=1");
            FillCachApplicantTable(dtTemp);
            FillCachCostCenterTable(dtTemp);
            FillCachJobNatureTypeTable(dtTemp);

            ApplicantWorkerStatementCol objStatementCol = new ApplicantWorkerStatementCol(true);
            if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
            {
                string strTempID = "";
                if (objMotivationStatementBiz.VacationDay != 0)
                {
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        if (strTempID != "")
                            strTempID += ',' + objDr["Applicant"].ToString();
                        else
                            strTempID = objDr["Applicant"].ToString();
                    }
                    objStatementCol = new ApplicantWorkerStatementCol(objGlobalStatementCol, strTempID);

                }
            }

            List<string> lsNonStoppedIDs = new List<string>();
            string [] arrNonStopped =    strApplicantIDs.Split(',');
            foreach (string strTemp in arrNonStopped) lsNonStoppedIDs.Add(strTemp);

            List<string> lstIDs = SysUtility.GetStringArr(dtTemp, "Applicant", 5000);
            string strNewIDs = lstIDs.Count > 0 ? lstIDs[0] : "";
            if (objMotivationStatementBiz != null && objMotivationStatementBiz.ID != 0)
            {
                ApplicantWorkerMotivationStatementDb objMotivationDb = new ApplicantWorkerMotivationStatementDb() { ApplicantIDs = strNewIDs, MotivationStatement = objMotivationStatementBiz.ID };
                dtTempValue = objMotivationDb.GetMotivationValue();


            }

            ApplicantWorkerManyStatementBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
               
                string str = objDr["Applicant"].ToString();
                
                if (str == "6135")
                {
                    int s = 0;
                }
                if (dtTempValue != null && dtTempValue.Rows.Count > 0)
                {
                    arrDr = dtTempValue.Select("Applicant=" + str);
                }
                if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
                {
                    if (CheckVacationDayCount(objStatementCol, int.Parse(objDr["Applicant"].ToString()), objMotivationStatementBiz.VacationDay))
                    {
                        objBiz = new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz);

                        if(dtTempValue!= null&&dtTempValue.Rows.Count>0)
                        {
                            arrDr = dtTempValue.Select("Applicant=" + objBiz.ApplicantWorkerBiz.ID);
                            if(arrDr.Length>0)
                            {
                                objBiz.SavedValue =double.Parse( arrDr[0]["MotivationValue"].ToString());
                                objBiz.Reviewed = bool.Parse(arrDr[0]["MotivationStatementReview"].ToString());
                            }
                        }
                        objBiz.Stopped = !lsNonStoppedIDs.Contains(objBiz.ApplicantWorkerBiz.ID.ToString());
                        this.Add(objBiz);
                    }
                    else
                    {
                        string strTemp = objDr["Applicant"].ToString();
                    }
                }
                else
                {
                    objBiz = new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz);
                    if (dtTempValue != null && dtTempValue.Rows.Count > 0)
                    {
                        arrDr = dtTempValue.Select("Applicant=" + objBiz.ApplicantWorkerBiz.ID);
                        if (arrDr.Length > 0)
                        {
                            objBiz.SavedValue = double.Parse(arrDr[0]["MotivationValue"].ToString());
                            objBiz.Reviewed = bool.Parse(arrDr[0]["MotivationStatementReview"].ToString());
                        }
                    }
                    objBiz.Stopped = !lsNonStoppedIDs.Contains(objBiz.ApplicantWorkerBiz.ID.ToString());
                   
                    this.Add(objBiz);
                }
                    
            }
            

        }

        public ApplicantWorkerManyStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementCol objGlobalStatementCol,
           CostCenterHRBiz objCostCenterHRBiz, byte btOnlyWork,
           byte btHasMotivation, bool blIsDependOnStartDate, DateTime dtStartDate, bool blInCludeAllApplicant, string strApplicantIDs,
           byte byStatementStatus, CostCenterHRBiz objCostCenterCheckHRBiz, string strCostCenterIDs )
        {
            //MotivationStatementBiz objMotivationStatementBiz = MotivationStatementBiz.MotivationStatement;
            //GlobalStatementCol objGlobalStatementCol = objMotivationStatementBiz.GlobalStatementCol.GlobalStatementCol;
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
            if (objGlobalStatementCol == null || objGlobalStatementCol.Count == 0)
            {
                objGlobalStatementCol = objMotivationStatementBiz.GlobalStatementCol.GlobalStatementCol;
            }
            objDb.MotivationStatementCostCenterIDSearch = objCostCenterHRBiz.ID;
            objDb.MotivationStatementCostCenterIDsSearch = strCostCenterIDs;
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.MotivationCostCenterIDs = strCostCenterIDs;
            if (objCostCenterCheckHRBiz == null)
                objCostCenterCheckHRBiz = new CostCenterHRBiz();
            if (objCostCenterCheckHRBiz.ID != 0 && objCostCenterHRBiz.ID != objCostCenterCheckHRBiz.ID)
                objDb.MotivationCostCenterChildID = objCostCenterCheckHRBiz.ID;
            objDb.WorkStatus = btOnlyWork;

            objDb.HasMotivationSearch = btHasMotivation;
            objDb.MotivationTypeSearch = objMotivationStatementBiz.MotivationTypeBiz.ID;

            objDb.IsDependOnStartDateInMotivation = blIsDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;
            objDb.MotivationStatusSearch = byStatementStatus;
            if (!blInCludeAllApplicant)
                objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.GetApplicantMainData();
            DataTable dtTempValue = new DataTable();


            DataRow[] arrDr = dtTemp.Select("MotivationStopped=1");
            FillCachApplicantTable(dtTemp);
            FillCachCostCenterTable(dtTemp);
            FillCachJobNatureTypeTable(dtTemp);

            ApplicantWorkerStatementCol objStatementCol = new ApplicantWorkerStatementCol(true);
            if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
            {
                string strTempID = "";
                if (objMotivationStatementBiz.VacationDay != 0)
                {
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        if (strTempID != "")
                            strTempID += ',' + objDr["Applicant"].ToString();
                        else
                            strTempID = objDr["Applicant"].ToString();
                    }
                    objStatementCol = new ApplicantWorkerStatementCol(objGlobalStatementCol, strTempID);

                }
            }

            List<string> lsNonStoppedIDs = new List<string>();
            string[] arrNonStopped = strApplicantIDs.Split(',');
            foreach (string strTemp in arrNonStopped) lsNonStoppedIDs.Add(strTemp);

            List<string> lstIDs = SysUtility.GetStringArr(dtTemp, "Applicant", 5000);
            string strNewIDs = lstIDs.Count > 0 ? lstIDs[0] : "";
            if (objMotivationStatementBiz != null && objMotivationStatementBiz.ID != 0)
            {
                ApplicantWorkerMotivationStatementDb objMotivationDb = new ApplicantWorkerMotivationStatementDb() { ApplicantIDs = strNewIDs, MotivationStatement = objMotivationStatementBiz.ID };
                dtTempValue = objMotivationDb.GetMotivationValue();


            }

            ApplicantWorkerManyStatementBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {

                string str = objDr["Applicant"].ToString();

                if (str == "6135")
                {
                    int s = 0;
                }
                if (dtTempValue != null && dtTempValue.Rows.Count > 0)
                {
                    arrDr = dtTempValue.Select("Applicant=" + str);
                }
                if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
                {
                    if (CheckVacationDayCount(objStatementCol, int.Parse(objDr["Applicant"].ToString()), objMotivationStatementBiz.VacationDay))
                    {
                        objBiz = new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz);

                        if (dtTempValue != null && dtTempValue.Rows.Count > 0)
                        {
                            arrDr = dtTempValue.Select("Applicant=" + objBiz.ApplicantWorkerBiz.ID);
                            if (arrDr.Length > 0)
                            {
                                objBiz.SavedValue = double.Parse(arrDr[0]["MotivationValue"].ToString());
                                objBiz.Reviewed = bool.Parse(arrDr[0]["MotivationStatementReview"].ToString());
                            }
                        }
                        objBiz.Stopped = !lsNonStoppedIDs.Contains(objBiz.ApplicantWorkerBiz.ID.ToString());
                        this.Add(objBiz);
                    }
                    else
                    {
                        string strTemp = objDr["Applicant"].ToString();
                    }
                }
                else
                {
                    objBiz = new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz);
                    if (dtTempValue != null && dtTempValue.Rows.Count > 0)
                    {
                        arrDr = dtTempValue.Select("Applicant=" + objBiz.ApplicantWorkerBiz.ID);
                        if (arrDr.Length > 0)
                        {
                            objBiz.SavedValue = double.Parse(arrDr[0]["MotivationValue"].ToString());
                            objBiz.Reviewed = bool.Parse(arrDr[0]["MotivationStatementReview"].ToString());
                        }
                    }
                    objBiz.Stopped = !lsNonStoppedIDs.Contains(objBiz.ApplicantWorkerBiz.ID.ToString());

                    this.Add(objBiz);
                }

            }


        }




        //public ApplicantWorkerManyStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementCol objGlobalStatementCol, 
        //    CostCenterHRCol objCostCenterHRCol, byte btOnlyWork,
        //    byte btHasMotivation, bool blIsDependOnStartDate, DateTime dtStartDate, bool blInCludeAllApplicant, string strApplicantIDs, byte byStatementStatus)
        //{
        //    ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
        //    objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
        //    objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
        //    objDb.MotivationCostCenterIDs = objCostCenterHRCol.IDsStr;
        //    objDb.WorkStatus = btOnlyWork;
        //    objDb.HasMotivationSearch = btHasMotivation;
        //    objDb.MotivationTypeSearch = objMotivationStatementBiz.MotivationTypeBiz.ID;
        //    objDb.IsDependOnStartDateInMotivation = blIsDependOnStartDate;
        //    objDb.StartDateInMotivation = dtStartDate;
        //    objDb.MotivationStatusSearch = byStatementStatus;
        //    if (!blInCludeAllApplicant)
        //        objDb.ApplicantIDs = strApplicantIDs;
        //    DataTable dtTemp = objDb.GetApplicantMainData();
        //    FillCachApplicantTable(dtTemp);
        //    FillCachCostCenterTable(dtTemp);
        //    FillCachJobNatureTypeTable(dtTemp);

        //    ApplicantWorkerStatementCol objStatementCol = new ApplicantWorkerStatementCol(true);
        //    if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
        //    {
        //        string strTempID = "";
        //        if (objMotivationStatementBiz.VacationDay != 0)
        //        {
        //            foreach (DataRow objDr in dtTemp.Rows)
        //            {
        //                if (strTempID != "")
        //                    strTempID += ',' + objDr["Applicant"].ToString();
        //                else
        //                    strTempID = objDr["Applicant"].ToString();
        //            }
        //            objStatementCol = new ApplicantWorkerStatementCol(objGlobalStatementCol, strTempID);

        //        }
        //    }

        //    foreach (DataRow objDr in dtTemp.Rows)
        //    {
        //        if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
        //        {
        //            if (CheckVacationDayCount(objStatementCol, int.Parse(objDr["Applicant"].ToString()), objMotivationStatementBiz.VacationDay))
        //                this.Add(new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz));
        //        }
        //        else
        //            this.Add(new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz));
        //    }
        //}


        public ApplicantWorkerManyStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementCol objGlobalStatementCol,
            ApplicantWorkerCol objApplicantWorkerCol, byte byStatementStatus)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.MotivationStatusSearch = byStatementStatus;
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            DataTable dtTemp = objDb.GetApplicantMainData();
            FillCachApplicantTable(dtTemp);
            FillCachCostCenterTable(dtTemp);
            FillCachJobNatureTypeTable(dtTemp);

            ApplicantWorkerStatementCol objStatementCol = new ApplicantWorkerStatementCol(true);
            if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
            {
                string strTempID = "";
                if (objMotivationStatementBiz.VacationDay != 0)
                {
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        if (strTempID != "")
                            strTempID += ',' + objDr["Applicant"].ToString();
                        else
                            strTempID = objDr["Applicant"].ToString();
                    }
                    objStatementCol = new ApplicantWorkerStatementCol(objGlobalStatementCol, strTempID);

                }
            }

            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (byStatementStatus != 1 && objDb.ApplicantIDs == null)
                {
                    if (CheckVacationDayCount(objStatementCol, int.Parse(objDr["Applicant"].ToString()), objMotivationStatementBiz.VacationDay))
                        this.Add(new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz));
                }
                else
                    this.Add(new ApplicantWorkerManyStatementBiz(objDr, objMotivationStatementBiz));
            }
        }
        #region New Constructor
        public ApplicantWorkerManyStatementCol(ApplicantWorkerMotivationStatementCol objMotivationStatementCol)
        {

            //ApplicantWorkerMotivationStatementBiz objBiz = new ApplicantWorkerMotivationStatementBiz();
            ApplicantWorkerManyStatementBiz objManyBiz = new ApplicantWorkerManyStatementBiz();
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in objMotivationStatementCol)
            {
                objManyBiz = new ApplicantWorkerManyStatementBiz(objBiz);
                objBiz.ManyStatementBiz = objManyBiz;
            }
        }
        #endregion
        public ApplicantWorkerManyStatementCol(MotivationStatementBiz objMotivationStatementBiz,byte byApplicantSpecialCase)
        {
            if (byApplicantSpecialCase !=0)
            {
                MotivationStatementApplicantCol objMotivationStatementApplicantCol = new MotivationStatementApplicantCol(objMotivationStatementBiz, byApplicantSpecialCase);
                ApplicantWorkerManyStatementBiz objApplicantWorkerManyStatementBiz = new ApplicantWorkerManyStatementBiz();
                foreach (MotivationStatementApplicantBiz objBiz in objMotivationStatementApplicantCol)
                {
                    objApplicantWorkerManyStatementBiz = new ApplicantWorkerManyStatementBiz();
                    objApplicantWorkerManyStatementBiz.ApplicantWorkerBiz = objBiz.ApplicantWorkerBiz;
                    objApplicantWorkerManyStatementBiz.CostCenterHRBiz = new CostCenterHRBiz();
                    
                    this.Add(objApplicantWorkerManyStatementBiz);
                }
            }
        }
        #endregion
        #region Public Properties
        public double SumBaseSalary
        {
            get { return _SumBaseSalary; }
        }
        public double SumIncreaseValue
        {
            get { return _SumIncreaseValue; }
        }
        public double SumTelSalaryDetail
        {
            get { return _SumTelSalaryDetail; }
        }
        public double SumTransferSalaryDetail
        {
            get { return _SumTransferSalaryDetail; }
        }
        public double SumFeedingSalaryDetail
        {
            get { return _SumFeedingSalaryDetail; }
        }
        public double SumTotalSalary
        {
            get { return _SumTotalSalary; }
        }
        public virtual ApplicantWorkerManyStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerManyStatementBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ApplicantWorkerManyStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public string ApplicantIDs
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerManyStatementBiz objBiz in this)
                {
                    if (objBiz.ApplicantWorkerBiz.ID == 0)
                        continue;
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ApplicantWorkerBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public MotivationStatementCostCenterCol MotivationCostCenterCol
        {
            get
            {
                MotivationStatementCostCenterCol Returned = new MotivationStatementCostCenterCol(true);
                Hashtable hsTemp = new Hashtable();
                MotivationStatementCostCenterBiz objCostCenterBiz;
                foreach (ApplicantWorkerManyStatementBiz objBiz in this)
                {
                    if (hsTemp[objBiz.CostCenterHRBiz.ID.ToString()] == null)
                    {

                        objCostCenterBiz = new MotivationStatementCostCenterBiz();
                        objCostCenterBiz.CostCenterHRBiz = objBiz.CostCenterHRBiz;
                        objCostCenterBiz.CostCenterTypeBiz = objBiz.CostCenterHRBiz.CostCenterTypeBiz;
                        objCostCenterBiz.ManyStatementCol = new ApplicantWorkerManyStatementCol(true);
                        objCostCenterBiz.ManyStatementCol.Add(objBiz);
                        hsTemp.Add(objCostCenterBiz.CostCenterHRBiz.ID.ToString(), objCostCenterBiz);

                    }
                    else
                    {
                        objCostCenterBiz = (MotivationStatementCostCenterBiz)hsTemp[objBiz.CostCenterHRBiz.ID.ToString()];
                        objCostCenterBiz.ManyStatementCol.Add(objBiz);

                    }
 
                }
                return Returned;
            }
        }

        #endregion
        #region Private Methods
        static void FillCachApplicantTable(DataTable dtApplicant)
        {
            DataRow[] arrDR;
            arrDR = dtApplicant.Select("", "Applicant");
            string strTempApplicant = "";
            string strApplicantIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (strTempApplicant != objDr["Applicant"].ToString())
                {
                    if (strApplicantIDs != "")
                        strApplicantIDs += ",";
                    strApplicantIDs += objDr["Applicant"].ToString();
                    strTempApplicant = objDr["Applicant"].ToString();
                }
            }

            ApplicantWorkerDb objApplicantWorkerDb = new ApplicantWorkerDb();
            objApplicantWorkerDb.ApplicantSearchIDs = strApplicantIDs;
            objApplicantWorkerDb.ShortApplicantOnly = true;

            ApplicantWorkerStatementDb.CachApplicantTable = objApplicantWorkerDb.Search();
        }
        static void FillCachCostCenterTable(DataTable dtCostCenter)
        {
            DataRow[] arrDR;
            arrDR = dtCostCenter.Select("", "MotivationCostCenter");
            string strTempCostCenter = "";
            string strCostCenterIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (strTempCostCenter != objDr["MotivationCostCenter"].ToString())
                {
                    if (strCostCenterIDs != "")
                        strCostCenterIDs += ",";
                    strCostCenterIDs += objDr["MotivationCostCenter"].ToString();
                    strTempCostCenter = objDr["MotivationCostCenter"].ToString();
                }
            }

            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.CostCenterIDs = strCostCenterIDs;

            ApplicantWorkerStatementDb.CachCostCenterTable = objDb.Search();
        }
        static void FillCachJobNatureTypeTable(DataTable dtJobNatureType)
        {
            DataRow[] arrDR;
            arrDR = dtJobNatureType.Select("", "JobNature");
            string strTempJobNatureType = "";
            string strJobNatureTypeIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (strTempJobNatureType != objDr["JobNature"].ToString())
                {
                    if (strJobNatureTypeIDs != "")
                        strJobNatureTypeIDs += ",";
                    strJobNatureTypeIDs += objDr["JobNature"].ToString();
                    strTempJobNatureType = objDr["JobNature"].ToString();
                }
            }

            JobNatureTypeDb objDb = new JobNatureTypeDb();
            objDb.IDs = strJobNatureTypeIDs;

            ApplicantWorkerStatementDb.CachJobNatureTypeTable = objDb.Search();
        }
        #endregion
        #region Public Methods
        public void SetSumVariable()
        {
             _SumBaseSalary = -1;
             _SumIncreaseValue = -1;
             _SumTelSalaryDetail = -1;
             _SumTransferSalaryDetail = -1;
             _SumFeedingSalaryDetail = -1;
             _SumTotalSalary = -1;
             _SumTotalAbsence = -1;
             _SumTotalPenalty = -1;
        }
        public void GetSumVariable()
        {
            
            _SumBaseSalary = 0;
            _SumIncreaseValue = 0;
            _SumTelSalaryDetail = 0;
            _SumTransferSalaryDetail = 0;
            _SumFeedingSalaryDetail = 0;
            _SumTotalSalary = 0;
            _SumTotalAbsence = 0;
            _SumTotalPenalty = 0;
            foreach (ApplicantWorkerManyStatementBiz objBiz in this)
            {
                if (objBiz.MotivationStopped)
                    continue;
                _SumBaseSalary += objBiz.BaseSalary;
                _SumIncreaseValue += objBiz.IncreaseValue;
                _SumTelSalaryDetail += objBiz.TelSalaryDetail;
                _SumTransferSalaryDetail += objBiz.TransferSalaryDetail;
                _SumFeedingSalaryDetail += objBiz.FeedingSalaryDetail;
                _SumTotalAbsence += objBiz.AbsenceValue;
                _SumTotalPenalty += objBiz.PenaltyValue;
            }
            _SumTotalSalary = _SumBaseSalary + _SumIncreaseValue + _SumTransferSalaryDetail + _SumTelSalaryDetail + _SumFeedingSalaryDetail;

        }
        public ApplicantWorkerCol GetApplicantCol()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();
            foreach (ApplicantWorkerManyStatementBiz objBiz in this)
            {
                objBiz.ApplicantWorkerBiz.VirualCostCenterBiz = objBiz.CostCenterHRBiz;
                objBiz.ApplicantWorkerBiz.VirualJobNatureTypeBiz = objBiz.JobNatureTypeBiz;
                objCol.Add(objBiz.ApplicantWorkerBiz);
            }
            return objCol;
        }
        public ApplicantWorkerManyStatementBiz GetManyStatementBiz(ApplicantWorkerBiz objApplicantWorkerBiz)
        {            
            foreach (ApplicantWorkerManyStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantWorkerBiz.ID)
                    return objBiz;                
            }
            return new ApplicantWorkerManyStatementBiz(); ;
        }
        public ApplicantWorkerManyStatementCol GetManyStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(true);
            foreach (ApplicantWorkerManyStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantWorkerBiz.ID)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        public ApplicantWorkerManyStatementCol GetManyStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz, MotivationStatementBiz objMotivationStatementBiz)
        {
            ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(true);
            foreach (ApplicantWorkerManyStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantWorkerBiz.ID && objBiz.VirtualMotivationStatementBiz.ID == objMotivationStatementBiz.ID)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        public static ApplicantWorkerManyStatementCol GetManyStatementCol(MotivationStatementBiz objMotivationStatementBiz
            , MotivationStatementCostCenterCol objMotivationStatementCostCenterCol, byte byStatementStatus
            )
        {
            ApplicantWorkerManyStatementCol objManyStatementCol = new ApplicantWorkerManyStatementCol(true);

            foreach (MotivationStatementCostCenterBiz objBiz in objMotivationStatementCostCenterCol)
            {
                bool blIsDependonStartDate = false;
                if (objMotivationStatementBiz.DateStartDateLimit.Year != 1900)
                    blIsDependonStartDate = true;
                ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(objMotivationStatementBiz, objMotivationStatementBiz.GetGlobalStatementCol,
                    objBiz.CostCenterHRBiz, (byte)objBiz.ApplicantStatus, 1, blIsDependonStartDate,
                    objMotivationStatementBiz.DateStartDateLimit
                    , objBiz.IsIncludeAllApplicant, objBiz.GetApplicantCol().IDs, byStatementStatus,new CostCenterHRBiz());

                AddToCol(ref objManyStatementCol, objCol, objMotivationStatementBiz);
            }

            return objManyStatementCol;
        }
        public static ApplicantWorkerManyStatementCol GetManyStatementCol(MotivationStatementBiz objMotivationStatementBiz
            , MotivationStatementCostCenterBiz objBiz, byte byStatementStatus
            )
        {
            ApplicantWorkerManyStatementCol objManyStatementCol = new ApplicantWorkerManyStatementCol(true);

            
                bool blIsDependonStartDate = false;
                if (objMotivationStatementBiz.DateStartDateLimit.Year != 1900)
                    blIsDependonStartDate = true;
                ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(objMotivationStatementBiz, objMotivationStatementBiz.GetGlobalStatementCol,
                    objBiz.CostCenterHRBiz, (byte)objBiz.ApplicantStatus, 1, blIsDependonStartDate,
                    objMotivationStatementBiz.DateStartDateLimit
                    , objBiz.IsIncludeAllApplicant, objBiz.GetApplicantCol().IDs, byStatementStatus, new CostCenterHRBiz());

                AddToCol(ref objManyStatementCol, objCol, objMotivationStatementBiz);
            

            return objManyStatementCol;
        }
        public static ApplicantWorkerManyStatementCol GetManyStatementCol(MotivationStatementBiz objMotivationStatementBiz
            , ApplicantWorkerCol objApplicantWorkerCol, byte byStatementStatus
            )
        {
            ApplicantWorkerManyStatementCol objManyStatementCol = new ApplicantWorkerManyStatementCol(true);



            ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(objMotivationStatementBiz, objMotivationStatementBiz.GetGlobalStatementCol,

                objApplicantWorkerCol, byStatementStatus);

            AddToCol(ref objManyStatementCol, objCol, objMotivationStatementBiz);


            return objManyStatementCol;
        }
        public static ApplicantWorkerManyStatementCol GetManyStatementCol(MotivationStatementCol objMotivationStatementCol
            , ApplicantWorkerCol objApplicantWorkerCol, byte byStatementStatus
            )
        {
            ApplicantWorkerManyStatementCol objManyStatementCol = new ApplicantWorkerManyStatementCol(true);


            foreach (MotivationStatementBiz objMotivationStatementBiz in objMotivationStatementCol)
            {
                ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(objMotivationStatementBiz, objMotivationStatementBiz.GetGlobalStatementCol,

                objApplicantWorkerCol, byStatementStatus);

                AddToCol(ref objManyStatementCol, objCol, objMotivationStatementBiz);
            }            
            return objManyStatementCol;
        }
        private static void AddToCol(ref ApplicantWorkerManyStatementCol objMainCol, ApplicantWorkerManyStatementCol objCol, MotivationStatementBiz objMotivationStatementBiz)
        {
            foreach (ApplicantWorkerManyStatementBiz objBiz in objCol)
            {
                objBiz.VirtualMotivationStatementBiz = objMotivationStatementBiz;
                objMainCol.Add(objBiz);
            }
        }


        bool CheckVacationDayCount(ApplicantWorkerStatementCol objStatementCol, int intApplicantID, int intVacationDayCount)
        {
            if (intVacationDayCount == 0)
                return true;
            foreach (ApplicantWorkerStatementBiz objBiz in objStatementCol)
            {
                if (objBiz.ApplicantBiz.ID == intApplicantID)
                {
                    if (objBiz.AttendanceStatementCol.VacationWithoutCommonAndAccidentAndAbsentDay >= intVacationDayCount)
                        return false;
                }
            }

            return true;
        }
        #endregion
    }
}
