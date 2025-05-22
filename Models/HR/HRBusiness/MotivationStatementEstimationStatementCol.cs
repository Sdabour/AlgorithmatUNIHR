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
    public class MotivationStatementEstimationStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationStatementEstimationStatementCol(bool IsEmpty)
        {
        }
        public MotivationStatementEstimationStatementCol()
        {
            MotivationStatementEstimationStatementDb objDb = new MotivationStatementEstimationStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementEstimationStatementBiz(objDr));
            }
        }
        public MotivationStatementEstimationStatementCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementEstimationStatementDb objDb = new MotivationStatementEstimationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objMotivationStatementBiz.ID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementEstimationStatementBiz(objDr));
            }
        }
        public MotivationStatementEstimationStatementCol(EstimationStatementBiz objEstimationStatementBiz)
        {
            MotivationStatementEstimationStatementDb objDb = new MotivationStatementEstimationStatementDb();
            objDb.EstimationStatement = objEstimationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementEstimationStatementBiz(objDr));
            }
        }
        public MotivationStatementEstimationStatementCol(MotivationStatementBiz objMotivationStatementBiz, EstimationStatementBiz objEstimationStatementBiz)
        {
            MotivationStatementEstimationStatementDb objDb = new MotivationStatementEstimationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.EstimationStatement = objEstimationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementEstimationStatementBiz(objDr));
            }
        }
        public MotivationStatementEstimationStatementCol(MotivationStatementBiz objMotivationStatementBiz, EstimationStatementCol objEstimationStatementCol)
        {
            MotivationStatementEstimationStatementDb objDb = new MotivationStatementEstimationStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.EstimationStatementIDs = objEstimationStatementCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementEstimationStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementEstimationStatementBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementEstimationStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementEstimationStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRMotivationStatementEstimationStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("MotivationStatement"), new DataColumn("EstimationStatement")
            ,new DataColumn("OrderVal"),new DataColumn("MainEstimation")});
            DataRow objDr;
            foreach (MotivationStatementEstimationStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["MotivationStatement"] = objBiz.MotivationStatement;
                objDr["EstimationStatement"] = objBiz.EstimationStatementBiz.ID;
                objDr["OrderVal"] = objBiz.OrderVal;
                objDr["MainEstimation"] = objBiz.MainEstimation;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        public string EstimationStatementIDs
        {
            get
            {
                string Returned = "";
                foreach (MotivationStatementEstimationStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.EstimationStatementBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
