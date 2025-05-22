using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerFellowShipPaymentCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerFellowShipPaymentCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerFellowShipPaymentCol()
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));   
            }
        }
        public ApplicantWorkerFellowShipPaymentCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));
            }
        }
        public ApplicantWorkerFellowShipPaymentCol(ApplicantWorkerBiz objApplicantWorkerBiz, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));
            }
        }
        public ApplicantWorkerFellowShipPaymentCol(ApplicantWorkerCol objApplicantWorkerCol)
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));
            }
        }
        public ApplicantWorkerFellowShipPaymentCol(ApplicantWorkerCol objApplicantWorkerCol, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerFellowShipPaymentBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerFellowShipPaymentBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ApplicantWorkerFellowShipPaymentBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(ApplicantWorkerFellowShipPaymentBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == objBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        public double TotalValue
        {
            get
            {
                double dlReturned = 0;
                foreach (ApplicantWorkerFellowShipPaymentBiz objbiz in this)
                {
                    dlReturned += objbiz.Value;   
                }
                return dlReturned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerFellowShipPaymentBiz objBiz in this)
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

        #endregion
        #region Public Methods
        public void EditStatement(int intStatementID)
        {
            ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
            objDb.Statement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditStatement();
        }
        #endregion
    }
}
