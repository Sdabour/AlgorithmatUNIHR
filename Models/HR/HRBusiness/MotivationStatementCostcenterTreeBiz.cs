using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementCostcenterTreeBiz
    {
        #region Private Data
        MotivationStatementCostcenterTreeDb _MotivationStatementCostcenterTreeDb;
        MotivationStatementBiz _MotivationStatementBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        CostCenterHRBiz _CostCenterParentHRBiz;
        #endregion
        #region Constructors
        public MotivationStatementCostcenterTreeBiz()
        {
            _MotivationStatementCostcenterTreeDb = new MotivationStatementCostcenterTreeDb();
            _MotivationStatementBiz = new MotivationStatementBiz();
            _CostCenterHRBiz = new CostCenterHRBiz();
            _CostCenterParentHRBiz = new CostCenterHRBiz();
        }
        public MotivationStatementCostcenterTreeBiz(DataRow objDr)
        {
            _MotivationStatementCostcenterTreeDb = new MotivationStatementCostcenterTreeDb(objDr);
            //_MotivationStatementBiz = new MotivationStatementBiz(_MotivationStatementCostcenterTreeDb.MotivationStatement);
            //_CostCenterHRBiz = new CostCenterHRBiz(_MotivationStatementCostcenterTreeDb.CostCenter);
            //_CostCenterParentHRBiz = new CostCenterHRBiz(_MotivationStatementCostcenterTreeDb.CostCenterParent);
            _MotivationStatementBiz = new MotivationStatementBiz(objDr);
            _CostCenterHRBiz = new CostCenterHRBiz(objDr);

            _CostCenterParentHRBiz = new CostCenterHRBiz();
            _CostCenterParentHRBiz.ID = _MotivationStatementCostcenterTreeDb.CostCenterParent;
            _CostCenterParentHRBiz.NameA = _MotivationStatementCostcenterTreeDb.CostCenterParentName;
            //_CostCenterParentHRBiz.
        }
        
        #endregion
        #region Public Properties
        public MotivationStatementBiz MotivationStatementBiz
        {
            set { _MotivationStatementBiz = value; }
            get { return _MotivationStatementBiz; }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set { _CostCenterHRBiz = value; }
            get { return _CostCenterHRBiz; }
        }
        public CostCenterHRBiz CostCenterParentHRBiz
        {
            set { _CostCenterParentHRBiz = value; }
            get { return _CostCenterParentHRBiz; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementCostcenterTreeDb.MotivationStatement = _MotivationStatementBiz.ID;
            _MotivationStatementCostcenterTreeDb.CostCenter = _CostCenterHRBiz.ID;
            _MotivationStatementCostcenterTreeDb.CostCenterParent = _CostCenterParentHRBiz.ID;
            _MotivationStatementCostcenterTreeDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementCostcenterTreeDb.MotivationStatement = _MotivationStatementBiz.ID;
            _MotivationStatementCostcenterTreeDb.CostCenter = _CostCenterHRBiz.ID;
            _MotivationStatementCostcenterTreeDb.CostCenterParent = _CostCenterParentHRBiz.ID;
            _MotivationStatementCostcenterTreeDb.Delete();
        }
        #endregion
    }
}
