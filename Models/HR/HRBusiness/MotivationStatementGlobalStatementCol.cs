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
    public class MotivationStatementGlobalStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationStatementGlobalStatementCol(bool IsEmpty)
        {
        }
        public MotivationStatementGlobalStatementCol()
        {
            MotivationStatementGlobalStatementDb objDb = new MotivationStatementGlobalStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementGlobalStatementBiz(objDr));
            }
        }
        public MotivationStatementGlobalStatementCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementGlobalStatementDb objDb = new MotivationStatementGlobalStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objMotivationStatementBiz.ID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementGlobalStatementBiz(objDr));
            }
        }
        public MotivationStatementGlobalStatementCol(GlobalStatementBiz objGlobalStatementBiz)
        {
            MotivationStatementGlobalStatementDb objDb = new MotivationStatementGlobalStatementDb();
            objDb.GlobalStatement = objGlobalStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementGlobalStatementBiz(objDr));
            }
        }
        public MotivationStatementGlobalStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementBiz objGlobalStatementBiz)
        {
            MotivationStatementGlobalStatementDb objDb = new MotivationStatementGlobalStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.GlobalStatement = objGlobalStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementGlobalStatementBiz(objDr));
            }
        }
        public MotivationStatementGlobalStatementCol(MotivationStatementBiz objMotivationStatementBiz, GlobalStatementCol objGlobalStatementCol)
        {
            MotivationStatementGlobalStatementDb objDb = new MotivationStatementGlobalStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementGlobalStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementGlobalStatementBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementGlobalStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementGlobalStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public GlobalStatementCol GlobalStatementCol
        {
            get
            {
                GlobalStatementCol Returned = new GlobalStatementCol(true);
                foreach (MotivationStatementGlobalStatementBiz objBiz in this)
                {
                    Returned.Add(objBiz.GlobalStatementBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRMotivationStatementGlobalStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("MotivationStatement"), new DataColumn("GlobalStatement") });
            DataRow objDr;
            foreach (MotivationStatementGlobalStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["MotivationStatement"] = objBiz.MotivationStatement;
                objDr["GlobalStatement"] = objBiz.GlobalStatementBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
