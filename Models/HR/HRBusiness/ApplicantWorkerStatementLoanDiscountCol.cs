using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.HR.HRBusiness;
using SharpVision.SystemBase;


namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementLoanDiscountCol : CollectionBase
    {
         #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerStatementLoanDiscountCol(bool IsEmpty)
        {
            
        }
        public ApplicantWorkerStatementLoanDiscountCol()
        {
            ApplicantWorkerStatementLoanDiscountDb _ApplicantWorkerStatementLoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            DataTable dtApplicantWorkerStatementLoanDiscount = _ApplicantWorkerStatementLoanDiscountDb.Search();
            ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementLoanDiscount.Rows)
            {
                objApplicantWorkerStatementLoanDiscountBiz = new ApplicantWorkerStatementLoanDiscountBiz(DR);
                this.Add(objApplicantWorkerStatementLoanDiscountBiz);
            }

        }
        public ApplicantWorkerStatementLoanDiscountCol(ApplicantWorkerLoanBiz objBiz)
        {
            ApplicantWorkerStatementLoanDiscountDb _ApplicantWorkerStatementLoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            _ApplicantWorkerStatementLoanDiscountDb.Loan = objBiz.ID;
            
            DataTable dtApplicantWorkerStatementLoanDiscount = _ApplicantWorkerStatementLoanDiscountDb.Search();
            ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementLoanDiscount.Rows)
            {
                objApplicantWorkerStatementLoanDiscountBiz = new ApplicantWorkerStatementLoanDiscountBiz(DR);
                this.Add(objApplicantWorkerStatementLoanDiscountBiz);
            }

        }
        public ApplicantWorkerStatementLoanDiscountCol(ApplicantWorkerLoanBiz objBiz,int intNotGreaterThanID)
        {
            ApplicantWorkerStatementLoanDiscountDb _ApplicantWorkerStatementLoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            _ApplicantWorkerStatementLoanDiscountDb.Loan = objBiz.ID;
            _ApplicantWorkerStatementLoanDiscountDb.NotGreaterThanIDSearch = intNotGreaterThanID;
            DataTable dtApplicantWorkerStatementLoanDiscount = _ApplicantWorkerStatementLoanDiscountDb.Search();
            ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementLoanDiscount.Rows)
            {
                objApplicantWorkerStatementLoanDiscountBiz = new ApplicantWorkerStatementLoanDiscountBiz(DR);
                this.Add(objApplicantWorkerStatementLoanDiscountBiz);
            }

        }
        public ApplicantWorkerStatementLoanDiscountCol(GlobalStatementBiz objGlobalStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerStatementLoanDiscountDb _ApplicantWorkerStatementLoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            _ApplicantWorkerStatementLoanDiscountDb.GlobalStatementSearch = objGlobalStatementBiz.ID;
            _ApplicantWorkerStatementLoanDiscountDb.ApplicantSearch = objApplicantWorkerBiz.ID;
            DataTable dtApplicantWorkerStatementLoanDiscount = _ApplicantWorkerStatementLoanDiscountDb.Search();
            ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementLoanDiscount.Rows)
            {
                objApplicantWorkerStatementLoanDiscountBiz = new ApplicantWorkerStatementLoanDiscountBiz(DR);
                this.Add(objApplicantWorkerStatementLoanDiscountBiz);
            }

        }
        public ApplicantWorkerStatementLoanDiscountCol(GlobalStatementBiz objGlobalStatementBiz, ApplicantWorkerCol objApplicantWorkerCol)
        {
            ApplicantWorkerStatementLoanDiscountDb _ApplicantWorkerStatementLoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            _ApplicantWorkerStatementLoanDiscountDb.GlobalStatementSearch = objGlobalStatementBiz.ID;
            _ApplicantWorkerStatementLoanDiscountDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            DataTable dtApplicantWorkerStatementLoanDiscount = _ApplicantWorkerStatementLoanDiscountDb.Search();
            ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementLoanDiscount.Rows)
            {
                objApplicantWorkerStatementLoanDiscountBiz = new ApplicantWorkerStatementLoanDiscountBiz(DR);
                this.Add(objApplicantWorkerStatementLoanDiscountBiz);
            }

        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerStatementLoanDiscountBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerStatementLoanDiscountBiz)this.List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementLoanDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
    

     
        #endregion
        #region Public Methods
        public virtual void Add(ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz)
        {
            if(GetIndex(objApplicantWorkerStatementLoanDiscountBiz) ==-1)
            this.List.Add(objApplicantWorkerStatementLoanDiscountBiz);
        }
        public int GetIndex(ApplicantWorkerStatementLoanDiscountBiz objApplicantWorkerStatementLoanDiscountBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].LoanBiz.ID == objApplicantWorkerStatementLoanDiscountBiz.LoanBiz.ID
                    && this[intIndex].StatementBiz.ID == objApplicantWorkerStatementLoanDiscountBiz.StatementBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerStatementLoanDiscount");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DiscountID"), new DataColumn("DiscountStatement"), 
                new DataColumn("DiscountLoan"),new DataColumn("DiscountValue"), 
                
            });
            DataRow objDr;
            foreach (ApplicantWorkerStatementLoanDiscountBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["DiscountID"] = objBiz.ID;
                objDr["DiscountStatement"] = objBiz.StatementBiz.ID;
                objDr["DiscountLoan"] = objBiz.LoanBiz.ID;
                objDr["DiscountValue"] = objBiz.Value;

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

        #endregion
    }
}
