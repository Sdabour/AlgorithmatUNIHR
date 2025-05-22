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
    public class ApplicantWorkerLoanPaymentCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerLoanPaymentCol(bool IsEmpty)
        {
           
        }
        public ApplicantWorkerLoanPaymentCol()
        {
            ApplicantWorkerLoanPaymentDb objDb = new ApplicantWorkerLoanPaymentDb();
            DataTable objTemp = objDb.Search();
            foreach (DataRow  objDr in objTemp.Rows)
            {
                this.Add(new ApplicantWorkerLoanPaymentBiz(objDr));
            }
        }
         public ApplicantWorkerLoanPaymentCol(ApplicantWorkerLoanBiz objLoanBiz) 
        {
            ApplicantWorkerLoanPaymentDb objDb = new ApplicantWorkerLoanPaymentDb();
            objDb.Loan = objLoanBiz.ID;
            DataTable objTemp = objDb.Search();
            foreach (DataRow  objDr in objTemp.Rows)
            {
                this.Add(new ApplicantWorkerLoanPaymentBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerLoanPaymentBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerLoanPaymentBiz)this.List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerLoanPaymentBiz objBiz in this)
                {
                    Returned += objBiz.PaymenetValue;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        //public virtual void Add(ApplicantWorkerLoanPaymentBiz objBiz)
        //{

        //    this.List.Add(objBiz);
        //}
        public virtual void Add(ApplicantWorkerLoanPaymentBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
                this.List.Add(objBiz);
        }
        public int GetIndex(ApplicantWorkerLoanPaymentBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].LoanPaymentID == objBiz.LoanPaymentID
                    && this[intIndex].StatementBiz.ID == objBiz.StatementBiz.ID)
                    return intIndex;
            }
            return -1;
        }

        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerLoanPayment");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("Loan"),new DataColumn("LoanPaymentID"), 
                new DataColumn("PaymenetValue"),new DataColumn("PaymenetDate"),
               
            });
            DataRow objDr;
            foreach (ApplicantWorkerLoanPaymentBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["Loan"] = objBiz.LoanBiz.ID;
                objDr["LoanPaymentID"] = objBiz.LoanPaymentID;
                objDr["PaymenetValue"] = objBiz.PaymenetValue;
                objDr["PaymenetDate"] = objBiz.PaymenetDate;
              

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
    }
}
