using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementCol : CollectionBase
    {
        #region Private Data
        ApplicantWorkerCol _ApplicantWorkerCol;
        bool _DiscountIsSet;
        ApplicantWorkerMotivationStatementDiscountCol _DiscountCol = new ApplicantWorkerMotivationStatementDiscountCol(true);
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementCol(bool Isempty)
        {            
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementCostCenterCol objCostCenterCol,
            byte byIsStop, int intDiscountType, int intBankID,bool blIncludePreviousSalary)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.IntDiscountType = intDiscountType;
            objDb.IntBankID = intBankID;
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.CostCenterIDs;
            objDb.IsStopSearch = (int)byIsStop;
            objDb.IncludePreviousSalary = blIncludePreviousSalary;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("ApplicantID=3338");
            ApplicantWorkerMotivationStatementBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerMotivationStatementBiz(objDr);
                objBiz.MotivationStatementBiz = objMotivationStatementBiz;
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerMotivationStatementCol()
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            DataTable dtTemp = objDb.Search();  
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(ApplicantWorkerCol objApplicantWorkerCol)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(ApplicantWorkerCol objApplicantWorkerCol
            ,bool blLastMotivation,int intIsAddedBonusStatus,MotivationStatementBiz objStatementBiz)
        {
            if (objStatementBiz == null)
                objStatementBiz = new MotivationStatementBiz();
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.LastMotivation = objStatementBiz.ID==0&& blLastMotivation;
            objDb.AddedBonusStatus = intIsAddedBonusStatus;
            objDb.MotivationStatement = objStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(ApplicantWorkerCol objApplicantWorkerCol, MotivationStatementBiz objMotivationStatementBiz, byte byOrder)// byOrder 1 ,2 desc
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.OrderStatue = byOrder;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(CostCenterHRBiz objCostcenterBiz)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.CostCenter = objCostcenterBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz,ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz, ApplicantWorkerCol objApplicantWorkerCol)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementCostCenterCol objCostCenterCol)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.CostCenterIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementCostCenterCol objCostCenterCol,byte byIsStop)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.CostCenterIDs;
            objDb.IsStopSearch =(int) byIsStop;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementCol objMotivationStatementCol, MotivationStatementCostCenterCol objCostCenterCol, byte byIsStop)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatementIDs = objMotivationStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.CostCenterIDs;
            objDb.IsStopSearch = (int)byIsStop;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementCol objMotivationStatementCol, CostCenterHRCol objCostCenterCol)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatementIDs = objMotivationStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;            
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementCol objMotivationStatementCol, CostCenterHRCol objCostCenterCol,string strApplicantIDs)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatementIDs = objMotivationStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        public ApplicantWorkerMotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementCostCenterBiz objCostCenterBiz)
        {
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterBiz.CostCenterHRBiz.ID.ToString();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public double TotalDeserved
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                {
                    dlValue += objBiz.MotivationValue;
                }
                return dlValue;
            }
        }
        public ApplicantWorkerCol ApplicantCol
        {
            get
            {
                ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                {
                    Returned.Add(objBiz.ApplicantWorkerBiz);
 
                }
                    return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public double TotalSalary
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                {
                    dlValue += objBiz.ManyStatementBiz.TotalSalary;
                }
                return dlValue;
            }
        }
        //public BankHRCol BankCol
        //{
        //    get
        //    {
        //        BankHRCol Returned = new BankHRCol();
        //        BankHRBiz objBankBiz;
        //        Hashtable hsTemp = new Hashtable();
        //        foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
        //        {
        //            if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
        //            {
        //                if (hsTemp[objBiz.BankBiz.ID.ToString()] != null)
        //                {
        //                    objBankBiz = (BankHRBiz)hsTemp[objBiz.BankBiz.ID.ToString()];


        //                }
        //                else
        //                {
        //                    objBankBiz = new BankHRBiz();
        //                    objBankBiz.BankBiz = objBiz.BankBiz;
        //                    Returned.Add(objBankBiz);
        //                    hsTemp.Add(objBankBiz.BankBiz.ID.ToString(), objBankBiz);
                           
        //                }
        //                objBankBiz.MotivationStatementCol.Add(objBiz);
                        
        //            }
        //        }
        //        return Returned;
        //    }
        //}
        public MotivationStatementCostCenterCol MotivationCostCenterCol
        {
            get
            {
                MotivationStatementCostCenterCol Returned = new MotivationStatementCostCenterCol(true);
                Hashtable hsTemp = new Hashtable();
                MotivationStatementCostCenterBiz objCostCenterBiz;
                string strTemp = "";
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                {
                    strTemp = objBiz.CostCenterHRBiz.ID.ToString() + "-" + objBiz.MotivationStatementBiz.ID.ToString();
                    if (hsTemp[strTemp] == null)
                    {

                        objCostCenterBiz = new MotivationStatementCostCenterBiz();
                        objCostCenterBiz.CostCenterHRBiz = objBiz.CostCenterHRBiz;
                        objCostCenterBiz.CostCenterTypeBiz = objBiz.CostCenterHRBiz.CostCenterTypeBiz;
                        objCostCenterBiz.MotivationStatementBiz = objBiz.MotivationStatementBiz;
                        objCostCenterBiz.MotivationRatio = objBiz.CostCenterMotivationRatio;
                        objCostCenterBiz.Remarks = objBiz.CostCenterRemarks;
                        objCostCenterBiz.BounsOnDeserved = objBiz.CostCenterBonusOnDeserved;
                        objCostCenterBiz.MotivationStatementAddValue = objBiz.CostCenterAddValue;
                        objCostCenterBiz.ManyStatementCol = new ApplicantWorkerManyStatementCol(true);
                        objCostCenterBiz.ManyStatementCol.Add(objBiz.ManyStatementBiz);
                        objCostCenterBiz.ApplicantWorkerMotivationStatementCol = new ApplicantWorkerMotivationStatementCol(true);
                        hsTemp.Add(strTemp, objCostCenterBiz);
                        Returned.Add(objCostCenterBiz);

                    }
                    else
                    {
                        objCostCenterBiz = (MotivationStatementCostCenterBiz)hsTemp[strTemp];
                        objCostCenterBiz.ManyStatementCol.Add(objBiz.ManyStatementBiz);

                    }
                    objCostCenterBiz.ApplicantWorkerMotivationStatementCol.Add(objBiz);

                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public ApplicantWorkerCol ApplicantWorkerCol
        {
            set { _ApplicantWorkerCol = value; }
            get
            {
                if (_ApplicantWorkerCol == null)
                {
                    _ApplicantWorkerCol = new ApplicantWorkerCol(true);
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
                    {
                        _ApplicantWorkerCol.Add(objBiz.ApplicantWorkerBiz);
                    }
                }
                return _ApplicantWorkerCol;
            }
        }
        #endregion
        #region Public Methods
        public virtual ApplicantWorkerMotivationStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerMotivationStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public ApplicantWorkerMotivationStatementCol GetStatementByName(string strApplicantName,
            SharpVision.GL.GLBusiness.BankBiz objBankBiz,int intAccountNoStatus)
        {
            ApplicantWorkerMotivationStatementCol Returned = new ApplicantWorkerMotivationStatementCol(true);
            if (objBankBiz == null)
                objBankBiz = new GL.GLBusiness.BankBiz();
            string[] arrStr = strApplicantName.Split("%".ToCharArray());
            bool blIsFound;
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz == null || objBiz.ApplicantWorkerBiz.NameComp == null)
                    continue;
                if ((intAccountNoStatus == 1 && objBiz.AccountBankNo.Trim() == "") ||
                    (intAccountNoStatus == 2 && objBiz.AccountBankNo.Trim() != ""))
                    continue;
                blIsFound = false;
                foreach (string strTemp in arrStr)
                {

                    if (
                        SysUtility.ReplaceStringComp(objBiz.ApplicantWorkerBiz.Name).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp)) != -1 ||
                        SysUtility.ReplaceStringComp(objBiz.ApplicantWorkerBiz.Code).IndexOf(
                        SysUtility.ReplaceStringComp(strTemp)) != -1)
                    {
                        blIsFound = true;
                        break;
                    }
                }
                if ((objBankBiz.ID == 0 || objBankBiz.ID == objBiz.BankBiz.ID) &&blIsFound)
                    Returned.Add(objBiz);
            }
            return Returned;

        }
        public ApplicantWorkerMotivationStatementBiz GetStatementBiz(ApplicantWorkerBiz objApplicantbiz)
        {
            ApplicantWorkerMotivationStatementBiz ObjStatementBiz = new ApplicantWorkerMotivationStatementBiz();
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantbiz.ID)
                {
                    ObjStatementBiz = objBiz;
                    break;
                }
            }
            return ObjStatementBiz;
        }
        public DataTable GetBankTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[]
            {
              new DataColumn("Serial")  ,new DataColumn( "«”„")
            ,new DataColumn("Õ”«»",Type.GetType("System.String"))
            ,new DataColumn("ﬁÌ„…")
            ,new DataColumn("ID")
             });
            DataRow objDr;
            string strTemp = "";
            int intIndex = 0;
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                intIndex++;
                objDr[0] = intIndex.ToString();
                objDr[1] = objBiz.ApplicantWorkerBiz.Name;
                strTemp = objBiz.AccountBankNo.ToString();
                if (objBiz.BankBranchCode != "")
                    strTemp = objBiz.BankBranchCode + "-" + strTemp;
                if (objBiz.AccountTypeCode != "")
                    strTemp = strTemp + "-" + objBiz.AccountTypeCode;

                objDr[2] = strTemp; //objBiz.AccountBankNo.ToString() ;
                strTemp = "[" +  objBiz.ApplicantWorkerBiz.IDTypeInstantBiz.IDValue  + "]";
                objDr[3] = objBiz.MotivationValue;
                objDr[4] =  strTemp ;// objBiz.ApplicantWorkerBiz.IDTypeInstantBiz.IDValue;

               
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetDiscountCol()
        {
            if (_DiscountIsSet)
                return;
            ApplicantWorkerMotivationStatementDiscountDb objDb = new ApplicantWorkerMotivationStatementDiscountDb();
            objDb.StatementIDs = IDsStr;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            ApplicantWorkerMotivationStatementDiscountBiz objDiscountBiz;
            _DiscountCol = new ApplicantWorkerMotivationStatementDiscountCol(true);
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in this)
            {
                objBiz.DiscountCol = new ApplicantWorkerMotivationStatementDiscountCol(true);
                arrDr = dtTemp.Select("ApplicantWorkerMotivationStatement=" + objBiz.ID, "");
                foreach (DataRow objDr in arrDr)
                {
                    objDiscountBiz = new ApplicantWorkerMotivationStatementDiscountBiz(objDr);
                    objDiscountBiz.StatementBiz = objBiz;
                    objBiz.DiscountCol.Add(objDiscountBiz);
                    _DiscountCol.Add(objDiscountBiz);
                }
            }


        }
        public ApplicantWorkerMotivationStatementDiscountCol GetDiscountCol(MotivationDiscountTypeBiz objTypeBiz)
        {
            SetDiscountCol();
            ApplicantWorkerMotivationStatementDiscountCol Returned =
                new ApplicantWorkerMotivationStatementDiscountCol(true);
            foreach (ApplicantWorkerMotivationStatementDiscountBiz objBiz in _DiscountCol )
            {
                if (objTypeBiz.ID == 0 || 
                    objBiz.MotivationDiscountTypeBiz.ID == objTypeBiz.ID)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }

        #endregion
    }
}
