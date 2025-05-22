using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerBillCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerBillCol(bool IsEmpty)
        {
            
        }
        public ApplicantWorkerBillCol()
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(DateTime dtFrom,DateTime dtTo)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.BillDateSearch = true;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(ApplicantWorkerCol objApplicantWorkerCol, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            _ApplicantWorkerBillDb.BillDateSearch = blSearch;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }
        }
        public ApplicantWorkerBillCol(ApplicantWorkerBiz objApplicantWorkerBiz, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.Applicant = objApplicantWorkerBiz.ID;
            _ApplicantWorkerBillDb.BillDateSearch = blSearch;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(bool blSearch, DateTime dtFrom, DateTime dtTo,int intServiceTypeID,int intServiceProviderID)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.ServiceProviderSearch = intServiceProviderID;
            _ApplicantWorkerBillDb.ServiceTypeSearch = intServiceTypeID;
            _ApplicantWorkerBillDb.BillDateSearch = blSearch;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(ApplicantWorkerCol objApplicantWorkerCol, GlobalStatementBiz objGlobalStatementBiz,
            bool blSearch, DateTime dtFrom, DateTime dtTo, int intServiceID)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            _ApplicantWorkerBillDb.GlobalStatement = objGlobalStatementBiz.ID;
            _ApplicantWorkerBillDb.BillDateSearch = blSearch;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            _ApplicantWorkerBillDb.ServiceSearch = intServiceID;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }
        }
        public ApplicantWorkerBillCol(ApplicantWorkerBiz objApplicantWorkerBiz, GlobalStatementBiz objGlobalStatementBiz,
            bool blSearch, DateTime dtFrom, DateTime dtTo, int intServiceID)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.Applicant = objApplicantWorkerBiz.ID;
            _ApplicantWorkerBillDb.GlobalStatement = objGlobalStatementBiz.ID;
            _ApplicantWorkerBillDb.BillDateSearch = blSearch;
            _ApplicantWorkerBillDb.BillDateFromSearch = dtFrom;
            _ApplicantWorkerBillDb.BillDateToSearch = dtTo;
            _ApplicantWorkerBillDb.ServiceSearch = intServiceID;
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(GlobalStatementBiz objGlobalStatementBiz, int intServiceTypeID, int intServiceProviderID)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.ServiceProviderSearch = intServiceProviderID;
            _ApplicantWorkerBillDb.ServiceTypeSearch = intServiceTypeID;
            _ApplicantWorkerBillDb.GlobalStatement = objGlobalStatementBiz.ID;

           
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }

        }
        public ApplicantWorkerBillCol(ApplicantWorkerServiceParticipationBiz objServiceParticipationBiz)
        {
            ApplicantWorkerBillDb _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ApplicantWorkerBillDb.ApplicantParticipation = objServiceParticipationBiz.ID;
            _ApplicantWorkerBillDb.StatementStatus = 1;
          
            DataTable dtApplicantWorkerBill = _ApplicantWorkerBillDb.Search();
            ApplicantWorkerBillBiz objApplicantWorkerBillBiz;

            foreach (DataRow DR in dtApplicantWorkerBill.Rows)
            {
                objApplicantWorkerBillBiz = new ApplicantWorkerBillBiz(DR);
                this.Add(objApplicantWorkerBillBiz);
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerBillBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerBillBiz)this.List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerBillBiz objBiz in this)
                {
                    Returned+= (double)objBiz.BillValue;
                }
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerBillBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }

                return Returned;
            }
        }
        #endregion
        #region Private Methods
    
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerBill");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("BillID"), new DataColumn("ApplicantParticipation"), 
                new DataColumn("BillDate"),new DataColumn("BillValue"), 
                new DataColumn("BillStatement") 
            });
            DataRow objDr;
            foreach (ApplicantWorkerBillBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["BillID"] = objBiz.ID;
                objDr["ApplicantParticipation"] = objBiz.ServiceParticipationBiz.ID;
                objDr["BillDate"] = objBiz.BillDate;
                objDr["BillValue"] = objBiz.BillValue;
                objDr["BillStatement"] = objBiz.BillStatement;
               
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public virtual void Add(ApplicantWorkerBillBiz objApplicantWorkerBillBiz)
        {
            if(GetIndex(objApplicantWorkerBillBiz.ID)== -1)
               this.List.Add(objApplicantWorkerBillBiz);
        }

        public int GetIndex(int intBillID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == intBillID)
                    return intIndex;
            }
            return -1;
        }
        public void EditStatement(int intStatementID)
        {
            ApplicantWorkerBillDb objDb = new ApplicantWorkerBillDb();
            objDb.BillStatement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditStatement();
        }
        public ApplicantWorkerBillCol GetBillCol(DateTime dtFrom, DateTime dtTo)
        {
            
            ApplicantWorkerBillCol Returned = new ApplicantWorkerBillCol(true);
            foreach (ApplicantWorkerBillBiz objBiz in this)
            {
                if (objBiz.BillDate.Date >= dtFrom.Date && objBiz.BillDate.Date <= dtTo.Date)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        #endregion
    }
}
