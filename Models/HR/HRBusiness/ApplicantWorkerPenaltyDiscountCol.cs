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
    public class ApplicantWorkerPenaltyDiscountCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyDiscountCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerPenaltyDiscountCol()
        {
            ApplicantWorkerPenaltyDiscountDb _ApplicantWorkerPenaltyDiscountDb = new ApplicantWorkerPenaltyDiscountDb();
            DataTable dtApplicantWorkerPenaltyDiscount = _ApplicantWorkerPenaltyDiscountDb.Search();
            ApplicantWorkerPenaltyDiscountBiz objApplicantWorkerPenaltyDiscountBiz;

            foreach (DataRow DR in dtApplicantWorkerPenaltyDiscount.Rows)
            {
                objApplicantWorkerPenaltyDiscountBiz = new ApplicantWorkerPenaltyDiscountBiz(DR);
                this.Add(objApplicantWorkerPenaltyDiscountBiz);
            }

        }        
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerPenaltyDiscountBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerPenaltyDiscountBiz objBiz in this)
                {
                    
                    Returned += objBiz.DiscountValue;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerPenaltyDiscountBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerPenaltyDiscountBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerPenaltyDiscountBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(ApplicantWorkerPenaltyDiscountBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == objBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerPenaltyDiscount");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DiscountID"),new DataColumn("DiscountPenalty"),
                new DataColumn("DiscountDesc"),new DataColumn("DiscountStatement"),new DataColumn("DiscountValue")});     
            DataRow objDr;
            foreach (ApplicantWorkerPenaltyDiscountBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["DiscountID"] = objBiz.ID;
                objDr["DiscountPenalty"] = objBiz.PenaltyBiz.PenaltyID;
                objDr["DiscountDesc"] = objBiz.DiscountDesc;
                objDr["DiscountStatement"] = objBiz.DiscountStatement;
                objDr["DiscountValue"] = objBiz.DiscountValue;      
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        #endregion
        #region Public Methods
        public void EditStatement(int intStatement)
        {
            ApplicantWorkerPenaltyDiscountDb objDb = new ApplicantWorkerPenaltyDiscountDb();
            objDb.IDsStr = IDsStr;
            objDb.DiscountStatement = intStatement;
            objDb.EditStatement();
         
        }
        #endregion
    }
}
