using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.GL.GLDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationCostCenterCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerMotivationCostCenterCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerMotivationCostCenterCol()
        {
            ApplicantWorkerMotivationCostCenterDb objDb = new ApplicantWorkerMotivationCostCenterDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationCostCenterBiz(objDr));   
            }
        }
        public ApplicantWorkerMotivationCostCenterCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerMotivationCostCenterDb objDb = new ApplicantWorkerMotivationCostCenterDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerMotivationCostCenterBiz(objDr, objApplicantWorkerBiz));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerMotivationCostCenterBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationCostCenterBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerMotivationCostCenterBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerMotivationCostCenter");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("CostCenterApplicant"), new DataColumn("CostCenterIDValue") });
            DataRow objDr;
            foreach (ApplicantWorkerMotivationCostCenterBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["CostCenterApplicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["CostCenterIDValue"] = objBiz.CostCenterHRBiz.ID;                
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods

        #endregion
    }
}
