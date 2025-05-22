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
    public class MotivationStatementRelatedStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationStatementRelatedStatementCol(bool IsEmpty)
        {
        }
        public MotivationStatementRelatedStatementCol()
        {
            MotivationStatementRelatedStatementDb objDb = new MotivationStatementRelatedStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRelatedStatementBiz(objDr));
            }
        }
        public MotivationStatementRelatedStatementCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementRelatedStatementDb objDb = new MotivationStatementRelatedStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objMotivationStatementBiz.ID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRelatedStatementBiz(objDr));
            }
        }
        public MotivationStatementRelatedStatementCol(MotivationStatementBiz objRelatedStatementBiz,bool blRelated)
        {
            MotivationStatementRelatedStatementDb objDb = new MotivationStatementRelatedStatementDb();
            objDb.RelatedStatement = objRelatedStatementBiz.ID;
            if (objRelatedStatementBiz.ID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRelatedStatementBiz(objDr));
            }
        }
        public MotivationStatementRelatedStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementBiz objRelatedStatementBiz)
        {
            MotivationStatementRelatedStatementDb objDb = new MotivationStatementRelatedStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.RelatedStatement = objRelatedStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRelatedStatementBiz(objDr));
            }
        }
        public MotivationStatementRelatedStatementCol(MotivationStatementBiz objMotivationStatementBiz, MotivationStatementCol objRelatedStatementCol)
        {
            MotivationStatementRelatedStatementDb objDb = new MotivationStatementRelatedStatementDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.RelatedStatementIDs = objRelatedStatementCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRelatedStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementRelatedStatementBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementRelatedStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementRelatedStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRMotivationStatementRelatedStatement");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("MotivationStatement"), new DataColumn("RelatedStatement"), new DataColumn("OrderVal") });
            DataRow objDr;
            foreach (MotivationStatementRelatedStatementBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["MotivationStatement"] = objBiz.MotivationStatement;
                objDr["RelatedStatement"] = objBiz.RelatedStatementBiz.ID;
                objDr["OrderVal"] = objBiz.OrderVal;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        public string RelatedStatementIDs
        {
            get
            {
                string Returned = "";
                foreach (MotivationStatementRelatedStatementBiz objBiz in this)
                {
                    if (Returned != "")
                    {
                        Returned += "," + objBiz.RelatedStatementBiz.ID.ToString();
                        if (objBiz.RelatedStatementBiz.MotivationStatementChildCol.IDsStr!="")
                            Returned += "," + objBiz.RelatedStatementBiz.MotivationStatementChildCol.IDsStr.ToString();                        
                    }
                    else
                    {
                        Returned += objBiz.RelatedStatementBiz.ID.ToString();
                        if (objBiz.RelatedStatementBiz.MotivationStatementChildCol.IDsStr != "")
                            Returned += "," + objBiz.RelatedStatementBiz.MotivationStatementChildCol.IDsStr.ToString();                        
                    }

                    
                }
                return Returned;
            }
        }
        #endregion
        #region Public Methods
        public MotivationStatementCol GetMotivationStatementCol()
        {
            MotivationStatementCol objCol = new MotivationStatementCol(true);
            foreach (MotivationStatementRelatedStatementBiz objBiz in this)
            {
                objCol.Add(objBiz.RelatedStatementBiz);
            }
            return objCol;
        }
        #endregion
    }
}
