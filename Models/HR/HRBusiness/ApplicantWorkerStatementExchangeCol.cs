using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementExchangeCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerStatementExchangeCol(bool blIsEmpty)
        {
        }
        public ApplicantWorkerStatementExchangeCol()
        {
            ApplicantWorkerStatementExchangeDb objDb = new ApplicantWorkerStatementExchangeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementExchangeBiz(objDr));
            }
        }
        public ApplicantWorkerStatementExchangeCol(ApplicantWorkerStatementBiz objStatementBiz)
        {
            ApplicantWorkerStatementExchangeDb objDb = new ApplicantWorkerStatementExchangeDb();
            objDb.OriginStatement = objStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementExchangeBiz(objDr));
            }
        }
        public ApplicantWorkerStatementExchangeCol(ApplicantWorkerStatementCol objStatementCol)
        {
            ApplicantWorkerStatementExchangeDb objDb = new ApplicantWorkerStatementExchangeDb();
            objDb.OriginStatementIDs = objStatementCol.IDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementExchangeBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerStatementExchangeBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerStatementExchangeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerStatementExchangeBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public double TotalValue
        {
            get
            {
                double dlVal = 0;
                foreach (ApplicantWorkerStatementExchangeBiz objBiz in this)
                {
                    dlVal += objBiz.ExchangeValue;
                }
                return dlVal;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
