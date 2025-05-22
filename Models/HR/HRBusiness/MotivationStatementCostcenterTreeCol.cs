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
    public class MotivationStatementCostcenterTreeCol : CollectionBase
    {
        #region Private Data
        DataTable dtCostcenterParent;
        DataTable dtCostcenter;
        #endregion
        #region Constructors
        public MotivationStatementCostcenterTreeCol(bool IsEmpty)
        {
        }
        public MotivationStatementCostcenterTreeCol()
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostcenterTreeBiz(objDr));
            }
        }
        public MotivationStatementCostcenterTreeCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostcenterTreeBiz(objDr));
            }
        }
        public MotivationStatementCostcenterTreeCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterTypeBiz objCostCenterTypeBiz)
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objCostCenterTypeBiz!=null)
            objDb.CostCenterTypeSearch = objCostCenterTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostcenterTreeBiz(objDr));
            }
        }
        public MotivationStatementCostcenterTreeCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRBiz objCostCenterParentHRBiz)
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterParent = objCostCenterParentHRBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostcenterTreeBiz(objDr));
            }
        }
        public MotivationStatementCostcenterTreeCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRBiz objCostCenterParentBiz
            , CostCenterHRBiz objCostCenterChildBiz)
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterParent = objCostCenterParentBiz.ID;
            objDb.CostCenter = objCostCenterChildBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostcenterTreeBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementCostcenterTreeBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementCostcenterTreeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementCostcenterTreeBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        //private DataTable GetCostcenterParentTable(DataTable dtTemp)
        //{
        //    dtCostcenterParent = new DataTable();
        //}
        #endregion
        #region Public Methods
        public CostCenterHRCol GetCostCenterChildHRCol()
        {
            CostCenterHRCol objCol = new CostCenterHRCol(true);
            foreach(MotivationStatementCostcenterTreeBiz objBiz in this)
            {
                objCol.Add(objBiz.CostCenterHRBiz);
            }
            return objCol;
        }
        public CostCenterHRCol GetCostCenterParentHRCol()
        {
            CostCenterHRCol objCol = new CostCenterHRCol(true);
            foreach (MotivationStatementCostcenterTreeBiz objBiz in this)
            {
                objCol.Add(objBiz.CostCenterParentHRBiz);
            }
            return objCol;
        }
        #endregion
    }
}
