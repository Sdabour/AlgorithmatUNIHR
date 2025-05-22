using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class CostCenterHRBiz : CostCenterBiz
    {
        #region Private Data
        ApplicantWorkerCol _ApplicantCol;
        ApplicantWorkerStatementCol _StatementCol;
        CostCenterTypeBiz _CostCenterTypeBiz;
        CostCenterHRBiz _CostCenterParentBiz;
        CostCenterHRBiz _CostCenterParentInMotivationStatementBiz;
        //CostCenterHRCol _Children;

        #endregion
        #region Constructors
        public CostCenterHRBiz() 
        {
            //_CostCenterParentBiz = new CostCenterHRBiz();
        }
        public CostCenterHRBiz(DataRow objDr)
        {
            _BaseDb = new CostCenterHRDb(objDr);
            _CostCenterTypeBiz = new CostCenterTypeBiz(objDr);         
            _CostCenterParentInMotivationStatementBiz = new CostCenterHRBiz();
        }
        public CostCenterHRBiz(DataRow objDr,bool blSetCostcenterparent)
        {
            _BaseDb = new CostCenterHRDb(objDr);
            _CostCenterTypeBiz = new CostCenterTypeBiz(objDr);
            if (blSetCostcenterparent)
            {
                if (CostCenterHRCol.CacheCostCenterHRCol != null)
                {
                    _CostCenterParentBiz =
                        CostCenterHRCol.GetCostCenterHRBiz(((CostCenterHRDb)_BaseDb).ParentID);
                }
                else
                {
                    _CostCenterParentBiz = new CostCenterHRBiz(((CostCenterHRDb)_BaseDb).ParentID);
                }
                _CostCenterParentInMotivationStatementBiz = new CostCenterHRBiz();
            }
            else
            {
                _CostCenterParentBiz = new CostCenterHRBiz();
                _CostCenterParentInMotivationStatementBiz = new CostCenterHRBiz();
            }
        }
        public CostCenterHRBiz(DataRow objDr, MotivationStatementBiz objMotivationStatementBiz)
        {
            _BaseDb = new CostCenterHRDb(objDr);
            _CostCenterTypeBiz = new CostCenterTypeBiz(objDr);          
            _CostCenterParentInMotivationStatementBiz = GetCostCenterParentInMotivationStatementBiz(objMotivationStatementBiz);
        }
        public CostCenterHRBiz(int intID)
        {
            if (intID == 0)
                return;
            _BaseDb = new CostCenterHRDb(intID);
            //_CostCenterTypeBiz = new CostCenterTypeBiz(((CostCenterHRDb)_BaseDb).CostCenterType);
            _CostCenterTypeBiz = new CostCenterTypeBiz();
            if (_BaseDb.ID != intID)
            {
                //if (CostCenterHRCol.CacheCostCenterHRCol != null)
                //{
                //    _CostCenterParentBiz =
                //        CostCenterHRCol.GetCostCenterHRBiz(((CostCenterHRDb)_BaseDb).ParentID);
                //}
                //else
                //{
                //    _CostCenterParentBiz = new CostCenterHRBiz(((CostCenterHRDb)_BaseDb).ParentID);
                //}
            }
            else
                _CostCenterParentBiz = this;

        _CostCenterParentInMotivationStatementBiz = new CostCenterHRBiz();
        }        
        #endregion
        #region Public Properties
        public ApplicantWorkerCol ApplicantCol
        {
            set
            {
                _ApplicantCol = value;
            }
            get
            {
                if (_ApplicantCol == null)
                {
                    _ApplicantCol = new ApplicantWorkerCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerDb objDb = new ApplicantWorkerDb();
                        objDb.CostCenter = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _ApplicantCol.Add(new ApplicantWorkerBiz(objDr));
                        }

                    }
                }
                return _ApplicantCol;
 
            }
        }
        public ApplicantWorkerStatementCol StatementCol
        {
            set
            {
                _StatementCol = value;
            }
            get
            {
                if (_StatementCol == null)
                    _StatementCol = new ApplicantWorkerStatementCol(true);
                return _StatementCol;
            }
        }
        public CostCenterTypeBiz CostCenterTypeBiz
        {
            set
            {
                _CostCenterTypeBiz = value;
            }
            get
            {

                if (_CostCenterTypeBiz == null)
                    _CostCenterTypeBiz = new CostCenterTypeBiz();
                return _CostCenterTypeBiz;
            }
        }
        public CostCenterHRBiz CostCenterParentBiz
        {
            set
            {
                _CostCenterParentBiz = value;
            }
            get
            {
                if (_CostCenterParentBiz == null)
                    if (CostCenterHRCol.CacheCostCenterHRCol != null && CostCenterHRCol.CacheCostCenterHRCol.Count != 0)
                    {
                        _CostCenterParentBiz =
                            CostCenterHRCol.GetCostCenterHRBiz(((SharpVision.GL.GLDataBase.CostCenterDb)_BaseDb).ParentID);
                    }
                    else
                    {
                        _CostCenterParentBiz = new CostCenterHRBiz(((SharpVision.GL.GLDataBase.CostCenterDb)_BaseDb).ParentID);
                    }
                return _CostCenterParentBiz;
            }
        }
        public CostCenterHRBiz CostCenterParentInMotivationStatementBiz
        {
            set
            {
                _CostCenterParentInMotivationStatementBiz = value;
            }
            get
            {               
                return _CostCenterParentInMotivationStatementBiz;
            }
        }
        public double MotivationAddValue
        {
            set
            {
                ((CostCenterHRDb)_BaseDb).MotivationAddValue = value;
            }
            get
            {
                return ((CostCenterHRDb)_BaseDb).MotivationAddValue;
            }
        }
        //static string _CostCentIDs;
        //public static string CostCenterIDs { set => _CostCentIDs = value; get => _CostCentIDs; }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.ID = _BaseDb.ID;
            objDb.CostCenterType = _CostCenterTypeBiz.ID;
            objDb.Add();
        }
        public void Delete()
        {
            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.ID = _BaseDb.ID;
            objDb.CostCenterType = _CostCenterTypeBiz.ID;
            objDb.Delete();
        }
        public void JoinApplicantWorker()
        {
            if (_ApplicantCol == null)
                return;
            _ApplicantCol.EditCostCenter(ID);
        }
        public void EditCostCenterType()
        {
            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.ID = _BaseDb.ID;
            objDb.CostCenterType = _CostCenterTypeBiz.ID;
            objDb.EditCostCenterType();
        }
        public void EditMotivationAddValue()
        {
            CostCenterHRDb objDb = new CostCenterHRDb();
            objDb.ID = _BaseDb.ID;
            objDb.MotivationAddValue = MotivationAddValue;
            objDb.EditMotivationAddValue();
        }
        public CostCenterHRCol Children
        {
            set
            {
                _Children = value;
            }
            get
            {
                if (_Children == null)
                {
                    //_Children = new SectorCol(ID, ((SectorDb)_BaseDb).GetChildrenTable());
                    _Children = new CostCenterHRCol(true);
                }
                return (CostCenterHRCol)_Children;
            }
        }
        public CostCenterHRBiz GetCostCenterParentInMotivationStatementBiz(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementCostcenterTreeCol objCol 
                = new MotivationStatementCostcenterTreeCol(objMotivationStatementBiz, new CostCenterHRBiz(), this);
            if (objCol.Count == 0)
                return this;
            else
                return objCol[0].CostCenterParentHRBiz;
        }
        public CostCenterHRCol GetCostCenterChildInMotivationStatementBiz(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementCostcenterTreeCol objCol
                = new MotivationStatementCostcenterTreeCol(objMotivationStatementBiz, this, new CostCenterHRBiz());
            return objCol.GetCostCenterChildHRCol();
        }
        #endregion
    }
}
