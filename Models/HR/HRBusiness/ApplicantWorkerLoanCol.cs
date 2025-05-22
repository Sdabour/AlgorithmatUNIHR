using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerLoanCol : CollectionBase
    {
        #region Private Data
        protected double _TotalLoan=-1;

        #endregion
        #region Constructors
        public ApplicantWorkerLoanCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerLoanCol()
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;

            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerLoanCol(string strApplicantIDs, bool blSearch, DateTime dtFrom, DateTime dtTo, byte blIsfinsh)
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.InstallmentDateSearch = blSearch;
            objDb.InstallmentDateFromSearch = dtFrom;
            objDb.InstallmentDateToSearch = dtTo;
            objDb.FinishStatus = blIsfinsh; 
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;

            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerLoanCol(int intApplicantID)
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            objDb.LoanApplicant = intApplicantID;
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;
            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerLoanCol(int intApplicantID, bool blSearch, DateTime dtFrom, DateTime dtTo, byte blIsfinsh)
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            objDb.LoanApplicant = intApplicantID;
            objDb.InstallmentDateSearch = blSearch;
            objDb.InstallmentDateFromSearch = dtFrom;
            objDb.InstallmentDateToSearch = dtTo;
            objDb.FinishStatus = blIsfinsh; 
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;
            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerLoanCol(byte blIsfinsh)
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            objDb.FinishStatus = blIsfinsh; 
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;
            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerLoanCol(GlobalStatementBiz objGlobalStatementBiz,byte byBelongStatus)
        {
            ApplicantWorkerLoanDb objDb = new ApplicantWorkerLoanDb();
            objDb.GlobalStatementIDSearch = objGlobalStatementBiz.ID;
            objDb.BelongInStatement = byBelongStatus;
            DataTable dtApplicantWorkerLaon = objDb.Search();
            ApplicantWorkerLoanBiz objBiz;

            foreach (DataRow DR in dtApplicantWorkerLaon.Rows)
            {
                objBiz = new ApplicantWorkerLoanBiz(DR);
                this.Add(objBiz);
            }
        }
        #endregion
        #region Public Properties
        public double TotalLoan
        {
            set
            {
                _TotalLoan = value;
            }
            get
            {
                if (_TotalLoan == -1.0)
                {
                    _TotalLoan = 0;
                    foreach (ApplicantWorkerLoanBiz objBiz in this)
                    {
                        _TotalLoan += objBiz.LoanValue;
                    }
                }
                return _TotalLoan;
            }
        }
        public string ApplicantIDs
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerLoanBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ApplicantWorkerBiz.ID.ToString();
                }

                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerLoanBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerLoanBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerLoanBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerLoanBiz objBiz)
        {

            this.List.Add(objBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerLoan");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("LoanID"),new DataColumn("LoanApplicant"), new DataColumn("LoanValue"),new DataColumn("LoanPrepaidValue"),
                new DataColumn("LoanDesc"),new DataColumn("LoanRequestDate") ,new DataColumn("LoanGrantDate") ,
                new DataColumn("LoanInstallmentValue"),new DataColumn("LoanInstallmentDate"),new DataColumn("LoanImage")
            });     
            DataRow objDr;
            foreach (ApplicantWorkerLoanBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["LoanID"] = objBiz.ID;
                objDr["LoanApplicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["LoanValue"] = objBiz.LoanValue;
                objDr["LoanInstallmentValue"] = objBiz.InstallmentValue;
                objDr["LoanInstallmentDate"] = objBiz.InstallmentDate;
                objDr["LoanPrepaidValue"] = objBiz.LoanPrepaidValue;
                objDr["LoanDesc"] = objBiz.LoanDesc;
                objDr["LoanRequestDate"] = objBiz.LoanRequestDate;
                objDr["LoanGrantDate"] = objBiz.LoanGrantDate;
                objDr["LoanImage"] = objBiz.LoanImage;               
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public ApplicantWorkerLoanCol GetLoanCol(DateTime dtFrom, DateTime dtTo)
        {            
            ApplicantWorkerLoanCol Returned = new ApplicantWorkerLoanCol(true);
            foreach (ApplicantWorkerLoanBiz objBiz in this)
            {
                if (objBiz.LoanGrantDate.Date >= dtFrom.Date && objBiz.LoanGrantDate.Date <= dtTo.Date)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        public void SetLoanDiscount()
        {
            ApplicantWorkerLoanPaymentDb objDb = new ApplicantWorkerLoanPaymentDb();
            objDb.LoanIDs = IDsStr;
            DataTable dtPayment = objDb.Search();
            ApplicantWorkerStatementLoanDiscountDb objDiscount = new ApplicantWorkerStatementLoanDiscountDb();
            objDiscount.LoanIDs = IDsStr;
            DataTable dtDiscount = objDiscount.Search();

            DataRow[] arrDr;
            
            foreach (ApplicantWorkerLoanBiz objBiz in this)
            {
                objBiz.LoanDiscountCol = new ApplicantWorkerStatementLoanDiscountCol(true);
                objBiz.LoanPaymentCol = new ApplicantWorkerLoanPaymentCol(true);
                arrDr = dtPayment.Select("Loan="+objBiz.ID);
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.LoanPaymentCol.Add(new ApplicantWorkerLoanPaymentBiz(objDr));

                }
                arrDr = dtDiscount.Select("DiscountLoan=" + objBiz.ID);
                foreach (DataRow objDr in arrDr)
                {
                    objBiz.LoanDiscountCol.Add(new ApplicantWorkerStatementLoanDiscountBiz(objDr));

                }
 
            }
        }
        #endregion
    }
}
