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
    public class MotivationStatementApplicantCol : CollectionBase
    {
        #region Private Data
       
        #endregion
        #region Constructors
        public MotivationStatementApplicantCol()
        {
            MotivationStatementApplicantDb objDb = new MotivationStatementApplicantDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementApplicantBiz(objDr));
            }
        }
        public MotivationStatementApplicantCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementApplicantDb objDb = new MotivationStatementApplicantDb();
            objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementApplicantBiz(objDr));
            }
        }
        public MotivationStatementApplicantCol(MotivationStatementBiz objMotivationStatementBiz,byte byStatementStatus)
        {
            MotivationStatementApplicantDb objDb = new MotivationStatementApplicantDb();
            objDb.MotivationStatementSearch = objMotivationStatementBiz.ID;
            objDb.MotivationStatusSearch = byStatementStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementApplicantBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementApplicantBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementApplicantBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementApplicantBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (ApplicantWorkerBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public ApplicantWorkerCol GetWorkerCol(string strName)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            strName = strName.Replace(" ", "");
            foreach (MotivationStatementApplicantBiz objBiz in this)
            {
                if (objBiz.ApplicantWorkerBiz.NameComp.IndexOf(strName) != -1)
                {
                    Returned.Add(objBiz.ApplicantWorkerBiz);
                }
            }
            return Returned;
        }
        public ApplicantWorkerCol GetWorkerCol()
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            foreach (MotivationStatementApplicantBiz objBiz in this)
            {
                Returned.Add(objBiz.ApplicantWorkerBiz);
            }
            return Returned;
        }
        #endregion
    }
}
