using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementBiz
    {
        #region Private Data
        static CostCenterTypeBiz _CostCenterTypeBiz;
        MotivationTypeBiz _MotivationTypeBiz;
        MotivationStatementDb _MotivationStatementDb;
        MotivationStatementBiz _ParentBiz;
        MotivationStatementEstimationStatementCol _EstimationStatementCol;
        MotivationStatementGlobalStatementCol _GlobalStatementCol;
        MotivationStatementCostCenterCol _CostCenterCol;
        MotivationStatementRelatedStatementCol _RelatedStatementCol;

        EstimationStatementBiz _MainEstimationStatementBiz;
        EstimationStatementBiz _EstimationStatement1Biz;
        EstimationStatementBiz _EstimationStatement2Biz;
        EstimationStatementBiz _EstimationStatement3Biz;

        MotivationStatementBiz _RelatedStatement1Biz;
        MotivationStatementBiz _RelatedStatement2Biz;
        MotivationStatementBiz _RelatedStatement3Biz;

        ApplicantWorkerMotivationStatementCol _ApplicantWorkerMotivationStatementCol;

        MotivationStatementApplicantCol _MotivationStatementApplicantCol;
        
        MotivationStatementCostcenterTreeCol _CostcenterTreeCol;
        MotivationStatementRangesCol _RangesCol;
        Hashtable _StatementHash ;
        #endregion
        #region Constructors
        public MotivationStatementBiz()
        {
            _MotivationStatementDb = new MotivationStatementDb();
            //_ParentBiz = new MotivationStatementBiz();
            _MotivationTypeBiz = new MotivationTypeBiz();
        }
        public MotivationStatementBiz(DataRow objDr)
        {
            _MotivationStatementDb = new MotivationStatementDb(objDr);
            _ParentBiz = new MotivationStatementBiz();
            if (_MotivationStatementDb.ParentStatementID != 0)
            {
                _ParentBiz = new MotivationStatementBiz();
                _ParentBiz.ID = _MotivationStatementDb.ParentStatementID;
                _ParentBiz.Desc = _MotivationStatementDb.ParentStatementDesc;
                _ParentBiz.DateFrom = _MotivationStatementDb.ParentStatementDateFrom;
                _ParentBiz.DateTo = _MotivationStatementDb.ParentStatementDateTo;
                _ParentBiz.MonthName = _MotivationStatementDb.ParentStatementMonthName;
                _ParentBiz.VacationDay = _MotivationStatementDb.ParentStatementVacationDay;
                _ParentBiz._MotivationTypeBiz = new MotivationTypeBiz();
                _ParentBiz.MotivationTypeBiz.ID = _MotivationStatementDb.ParentStatementType;
                _ParentBiz.MotivationTypeBiz.NameA = _MotivationStatementDb.ParentStatmentTypeNameA;
                _ParentBiz.MotivationTypeBiz.NameE = _MotivationStatementDb.ParentStatementTypeNameE;
            }
                //else
            //    _ParentBiz = new MotivationStatementBiz();
            _MotivationTypeBiz = new MotivationTypeBiz(objDr);
        }
        public MotivationStatementBiz(int intMotivationStatementID)
        {
            _MotivationStatementDb = new MotivationStatementDb(intMotivationStatementID);

            if (_MotivationStatementDb.ParentID != 0)
                _ParentBiz = new MotivationStatementBiz(_MotivationStatementDb.ParentID);
            //else
            //    _ParentBiz = new MotivationStatementBiz();
            _MotivationTypeBiz = new MotivationTypeBiz(_MotivationStatementDb.MotivationType);
        }
        #endregion
        #region Public Properties
        public int ID { set { _MotivationStatementDb.ID = value; } get { return _MotivationStatementDb.ID; } }
        public string Desc { set { _MotivationStatementDb.Desc = value; } get { return _MotivationStatementDb.Desc; } }
        public string MonthName 
        { 
            set { _MotivationStatementDb.MonthName = value; } 
            get {
                if (_MotivationStatementDb.MonthName == null|| _MotivationStatementDb.MonthName == "" )
                {
                    if (DateTo.Month == 1)
                    {
                        return " íäÇíÑ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 2)
                    {
                        return " ÝÈÑÇíÑ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 3)
                    {
                        return " ãÇÑÓ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 4)
                    {
                        return " ÇÈÑíá " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 5)
                    {
                        return " ãÇíæ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 6)
                    {
                        return " íæäíÉ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 7)
                    {
                        return " íæáÈæ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 8)
                    {
                        return " ÇÛÓØÓ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 9)
                    {
                        return " ÓÈÊãÈÑ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 10)
                    {
                        return " ÇßÊæÈÑ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 11)
                    {
                        return " äæÝãÈÑ " + DateTo.Year.ToString();
                    }
                    else if (DateTo.Month == 12)
                    {
                        return " ÏíÓãÈÑ " + DateTo.Year.ToString();
                    }
                }
                return _MotivationStatementDb.MonthName; 
            } 
        }
        public bool IsAddedBonus
        {
            set => _MotivationStatementDb.IsAddedBonus = value;
            get => _MotivationStatementDb.IsAddedBonus;
        }
        public DateTime DateFrom { set { _MotivationStatementDb.DateFrom = value; } get { return _MotivationStatementDb.DateFrom; } }
        public DateTime DateTo { set { _MotivationStatementDb.DateTo = value; } get { return _MotivationStatementDb.DateTo; } }
        public DateTime DateStartDateLimit { set { _MotivationStatementDb.DateStartDateLimit = value; } get { return _MotivationStatementDb.DateStartDateLimit; } }
        public int VacationDay { set { _MotivationStatementDb.VacationDay = value; } get { return _MotivationStatementDb.VacationDay; } }
        public MotivationStatementBiz ParentBiz { set { _ParentBiz = value; } get { return _ParentBiz; } }
        public MotivationTypeBiz MotivationTypeBiz { set { _MotivationTypeBiz = value; } get { return _MotivationTypeBiz; } }
        public MotivationStatementEstimationStatementCol EstimationStatementCol
        {
            set
            {
                _EstimationStatementCol = value;
            }
            get
            {
                if(_EstimationStatementCol==null)
                {
                    _EstimationStatementCol = new MotivationStatementEstimationStatementCol(this);
                }
                return _EstimationStatementCol;
            }
        }
        public MotivationStatementGlobalStatementCol GlobalStatementCol
        {
            set
            {
                _GlobalStatementCol = value;
            }
            get
            {
                if (_GlobalStatementCol == null)
                {
                    _GlobalStatementCol = new MotivationStatementGlobalStatementCol(this);
                }
                return _GlobalStatementCol;
            }
        }
        public MotivationStatementRelatedStatementCol RelatedStatementCol
        {
            set
            {
                _RelatedStatementCol = value;
            }
            get
            {
                if (_RelatedStatementCol == null)
                {
                    _RelatedStatementCol = new MotivationStatementRelatedStatementCol(this);
                }
                return _RelatedStatementCol;
            }
        }
        public MotivationStatementCostCenterCol CostCenterCol
        {
            set
            {
                _CostCenterCol = value;
            }
            get
            {
                if (_CostCenterCol == null)
                {
                    _CostCenterCol = new MotivationStatementCostCenterCol(this,_CostCenterTypeBiz);
                }
                return _CostCenterCol;
            }
        }
        public static CostCenterTypeBiz CostCenterTypeBiz
        {
            set
            {
                _CostCenterTypeBiz = value;
            }
            get
            {
                return _CostCenterTypeBiz;
            }
        }
        
        CostCenterTypeBiz _CostCenterTypeBizForRange;
        public static CostCenterTypeBiz CostCenterTypeBizForRange
        {
            set
            {
                _CostCenterTypeBiz = value;
            }
            get
            {
                return _CostCenterTypeBiz;
            }
        }
        public ApplicantWorkerMotivationStatementCol ApplicantWorkerMotivationStatementCol
        {
            set
            {
                _ApplicantWorkerMotivationStatementCol = value;
            }
            get
            {
                if (_ApplicantWorkerMotivationStatementCol == null)
                {
                    _ApplicantWorkerMotivationStatementCol = new ApplicantWorkerMotivationStatementCol(this);
                }
                return _ApplicantWorkerMotivationStatementCol;
            }
        }
        public EstimationStatementBiz MainEstimationStatementBiz
        {
            get
            {
                return _MainEstimationStatementBiz;
            }
        }
        public EstimationStatementBiz EstimationStatement1Biz
        {
            get
            {
                return _EstimationStatement1Biz;
            }
        }
        public EstimationStatementBiz EstimationStatement2Biz
        {
            get
            {
                return _EstimationStatement2Biz;
            }
        }
        public EstimationStatementBiz EstimationStatement3Biz
        {
            get
            {
                return _EstimationStatement3Biz;
            }
        }
        public MotivationStatementBiz RelatedStatement1Biz
        {
            get
            {
                return _RelatedStatement1Biz;
            }
        }
        public MotivationStatementBiz RelatedStatement2Biz
        {
            get
            {
                return _RelatedStatement2Biz;
            }
        }
        public MotivationStatementBiz RelatedStatement3Biz
        {
            get
            {
                return _RelatedStatement3Biz;
            }
        }
        public MotivationStatementApplicantCol MotivationStatementApplicantCol
        {
            set
            {
                _MotivationStatementApplicantCol = value;
            }
            get
            {
                if (_MotivationStatementApplicantCol == null)
                {
                    _MotivationStatementApplicantCol = new MotivationStatementApplicantCol(this);
                }
                return _MotivationStatementApplicantCol;
            }
        }
        public MotivationStatementCostcenterTreeCol CostcenterTreeCol
        {
            get
            {
                _CostcenterTreeCol = new MotivationStatementCostcenterTreeCol(this);
                return _CostcenterTreeCol;
            }
        }
        public MotivationStatementRangesCol RangesCol
        {
            set
            {
                _RangesCol = value;
            }
            get
            {
                if (_RangesCol == null)
                {
                    _RangesCol = new MotivationStatementRangesCol(true);
                    if (ID != 0)
                    {
                        MotivationStatementRangesDb objDb = new MotivationStatementRangesDb();
                        objDb.MotivationStatement = ID;
                        if (CostCenterTypeBizForRange != null)
                        {
                            objDb.CostCenterType = CostCenterTypeBizForRange.ID;
                            if (CostCenterTypeBizForRange.ID == 0)
                                objDb.CostCenterType = -1;
                        }
                        DataTable dtTemp = objDb.Search();

                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _RangesCol.Add(new MotivationStatementRangesBiz(objDr));
                        }
                    }
                }
                return _RangesCol;
            }
        }
        public Hashtable StatementHash
        {
            set
            {
                _StatementHash = value;
            }
            get
            {
                if (_StatementHash == null)
                {
                    _StatementHash = new Hashtable();
                    if (ID != 0)
                    {
                        MotivationStatementApplicantDb objDb = new MotivationStatementApplicantDb();
                        objDb.MotivationStatementSearch = ID;
                        objDb.ShortApplicantOnly = true;

                        DataTable dtTemp = objDb.Search();
                        MotivationStatementApplicantBiz objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new MotivationStatementApplicantBiz(objDr);
                            if (_StatementHash[objBiz.ApplicantWorkerBiz.ID.ToString()] == null)
                            {
                                _StatementHash.Add(objBiz.ApplicantWorkerBiz.ID.ToString(), objBiz);

                            }
 
                        }
                    }

                }
                return _StatementHash;
            }
        }
        #endregion
        #region Private Methods
       
        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementDb.MotivationType = _MotivationTypeBiz.ID;
            _MotivationStatementDb.EstimationStatementTable = EstimationStatementCol.GetTable();
            _MotivationStatementDb.GlobalStatementTable = GlobalStatementCol.GetTable();
            _MotivationStatementDb.RelatedStatementTable = RelatedStatementCol.GetTable();
            _MotivationStatementDb.MonthName = MonthName;
           // _MotivationStatementDb.RangesTable = RangesCol.GetTable();
            _MotivationStatementDb.Add();
        }
        public void Edit()
        {
            _MotivationStatementDb.MotivationType = _MotivationTypeBiz.ID;
            _MotivationStatementDb.EstimationStatementTable = EstimationStatementCol.GetTable();
            _MotivationStatementDb.GlobalStatementTable = GlobalStatementCol.GetTable();
            _MotivationStatementDb.RelatedStatementTable = RelatedStatementCol.GetTable();
            _MotivationStatementDb.MonthName = MonthName;
            //_MotivationStatementDb.RangesTable = RangesCol.GetTable();
            _MotivationStatementDb.Edit();
        }
        public void Delete()
        {
            _MotivationStatementDb.EstimationStatementTable = new DataTable();
            _MotivationStatementDb.GlobalStatementTable = new DataTable();
            _MotivationStatementDb.RelatedStatementTable = new DataTable();
            _MotivationStatementDb.RangesTable = new DataTable() ;
            _MotivationStatementDb.Delete();
        }
        public void GetEstimationStatements()
        {
            _MainEstimationStatementBiz = new EstimationStatementBiz();
            _EstimationStatement1Biz = new EstimationStatementBiz();
            _EstimationStatement2Biz = new EstimationStatementBiz();
            _EstimationStatement3Biz = new EstimationStatementBiz();

            if (EstimationStatementCol.Count != 0)
            {
                
                    if (EstimationStatementCol.Count == 1)
                    {
                        _MainEstimationStatementBiz = EstimationStatementCol[0].EstimationStatementBiz;
                        _EstimationStatement1Biz = new EstimationStatementBiz();
                        _EstimationStatement2Biz = new EstimationStatementBiz();
                        _EstimationStatement3Biz = new EstimationStatementBiz();
                    }
                    else if (EstimationStatementCol.Count == 2)
                    {
                        _MainEstimationStatementBiz = EstimationStatementCol[0].EstimationStatementBiz;
                        _EstimationStatement1Biz = EstimationStatementCol[1].EstimationStatementBiz;                        
                        _EstimationStatement2Biz = new EstimationStatementBiz();
                        _EstimationStatement3Biz = new EstimationStatementBiz();
                    }
                    else if (EstimationStatementCol.Count == 3)
                    {
                        _MainEstimationStatementBiz = EstimationStatementCol[0].EstimationStatementBiz;
                        _EstimationStatement1Biz = EstimationStatementCol[1].EstimationStatementBiz;
                        _EstimationStatement2Biz = EstimationStatementCol[2].EstimationStatementBiz;
                        _EstimationStatement3Biz = new EstimationStatementBiz();
                    }
                    else if (EstimationStatementCol.Count == 4)
                    {
                        _MainEstimationStatementBiz = EstimationStatementCol[0].EstimationStatementBiz;
                        _EstimationStatement1Biz = EstimationStatementCol[1].EstimationStatementBiz;
                        _EstimationStatement2Biz = EstimationStatementCol[2].EstimationStatementBiz;
                        _EstimationStatement3Biz = EstimationStatementCol[3].EstimationStatementBiz;
                    }
                
            }
        }
        public void GetRelatedStatements()
        {
            _RelatedStatement1Biz = new MotivationStatementBiz();
            _RelatedStatement2Biz = new MotivationStatementBiz();
            _RelatedStatement3Biz = new MotivationStatementBiz();

            if (RelatedStatementCol.Count != 0)
            {

                if (RelatedStatementCol.Count == 1)
                {
                    _RelatedStatement1Biz = RelatedStatementCol[0].RelatedStatementBiz;
                }
                else if (RelatedStatementCol.Count == 2)
                {
                    _RelatedStatement1Biz = RelatedStatementCol[0].RelatedStatementBiz;
                    _RelatedStatement2Biz = RelatedStatementCol[1].RelatedStatementBiz;
                }
                else if (RelatedStatementCol.Count == 3)
                {
                    _RelatedStatement1Biz = RelatedStatementCol[0].RelatedStatementBiz;
                    _RelatedStatement2Biz = RelatedStatementCol[1].RelatedStatementBiz;
                    _RelatedStatement3Biz = RelatedStatementCol[2].RelatedStatementBiz;
                }
               

            }
        }
        public string GetMotivationAndRelatedIDs()
        {
            string Returned = this.ID.ToString();
            if (this.ParentBiz != null)
            {
                Returned += "," + this.ParentBiz.ID;
                if (this.ParentBiz.MotivationStatementChildCol.IDsStr != "")
                    Returned += "," + this.ParentBiz.MotivationStatementChildCol.IDsStr;
            }

            if (RelatedStatementCol.RelatedStatementIDs != "")
                Returned += "," + RelatedStatementCol.RelatedStatementIDs;
            return Returned;
        }
        public GlobalStatementCol GetGlobalStatementCol
        {
            get
            {
                GlobalStatementCol objCol = new GlobalStatementCol(false);
                foreach (MotivationStatementGlobalStatementBiz objBiz in GlobalStatementCol)
                {
                    objCol.Add(objBiz.GlobalStatementBiz);
                }
                return objCol;
            }
        }
        static MotivationStatementBiz _MotivationStatement;
        public static MotivationStatementBiz MotivationStatement { set => _MotivationStatement = value; get => _MotivationStatement; }
        public CostCenterHRCol GetCostCenterHRCol
        {
            get
            {
                CostCenterHRCol objCol = new CostCenterHRCol(true);
                foreach (MotivationStatementCostCenterBiz objBiz in CostCenterCol)
                {
                    objCol.Add(objBiz.CostCenterHRBiz);
                }
                return objCol;
            }
        }
        public void CopyCostCenterTree(MotivationStatementBiz objSourceBiz)
        {
            if (objSourceBiz == null || objSourceBiz.ID == 0 || ID == 0)
                return;
            DeleteCostCenterTree();

            //foreach (MotivationStatementCostcenterTreeBiz objBiz in objSourceBiz.CostcenterTreeCol)
            //{
            //    objBiz.MotivationStatementBiz = this;
            //    objBiz.Add();
            //}
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.SrcStatement = objSourceBiz.ID;
            objDb.DestStatement = ID;
            objDb.CopyCostCenterTree();


        }
        public void DeleteCostCenterTree()
        {
            MotivationStatementCostcenterTreeDb objDb = new MotivationStatementCostcenterTreeDb();
            objDb.DeleteCostCenterTree(ID);
        }
        public void SaveRanges()
        {
            MotivationStatementRangesDb objDb = new MotivationStatementRangesDb();

            objDb.DeleteRange(this.ID,CostCenterTypeBizForRange.ID);

            foreach (MotivationStatementRangesBiz objBiz in this.RangesCol)
            {
                objBiz.Add();
            }
        }
        MotivationStatementCol _MotivationStatementChildCol;
        public MotivationStatementCol MotivationStatementChildCol
        {
            set
            {
                _MotivationStatementChildCol = value;
            }
            get
            {
                if (_MotivationStatementChildCol == null)
                {
                    _MotivationStatementChildCol = new MotivationStatementCol(true);
                    if (ID != 0)
                    {
                        MotivationStatementDb objDb = new MotivationStatementDb();
                        objDb.ParentIDSearch = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _MotivationStatementChildCol.Add(new MotivationStatementBiz(objDr));
                        }
                    }
                }
                return _MotivationStatementChildCol;
            }
        }
        string _MotivationStatementIDAndChildIDs;
        public string MotivationStatementIDAndChildIDs
        {
            get
            {
                _MotivationStatementIDAndChildIDs = ID.ToString();
                if (this.MotivationStatementChildCol.IDsStr != "")
                    _MotivationStatementIDAndChildIDs += "," + this.MotivationStatementChildCol.IDsStr;
                return _MotivationStatementIDAndChildIDs;
            }
        }

        public static int MotivationStatementID { get; internal set; }

        public ApplicantWorkerCol GetApplicantCol(CostCenterHRBiz objCostCenterBiz, int intCostCenterType,int intStatementStatus)
        {
            ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
            MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
            objDb.MotivationStatement = ID;
            objDb.CostCenter = objCostCenterBiz.ID;
            objDb.StatementStatus = intStatementStatus;

            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "OrderJobCategoryOrder,OrderJobNatureNameA,ApplicantFirstName");
            ApplicantWorkerBiz objBiz;
            ApplicantWorkerMotivationCostCenterBiz objMotivationCostCenterBiz;
            foreach (DataRow objDr in arrDr)
            {
                objBiz = new ApplicantWorkerBiz(objDr);
                objMotivationCostCenterBiz = new ApplicantWorkerMotivationCostCenterBiz();
                objMotivationCostCenterBiz.ApplicantWorkerBiz = objBiz;
                objMotivationCostCenterBiz.CostCenterHRBiz = objCostCenterBiz;
                objBiz.MotivationCostCenterBiz = objMotivationCostCenterBiz;
                objBiz.VirualCostCenterBiz = objMotivationCostCenterBiz.CostCenterHRBiz;
                objBiz.VirualJobNatureTypeBiz = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz;
                Returned.Add(objBiz);
            }
            return Returned;
        }
        public void UploadData(bool blIsReviewed,DataTable dtTemp)
        {
            if (dtTemp.Rows.Count == 0)
                return;
            MotivationStatementDb objDb = new MotivationStatementDb();
            objDb.ID = ID;
            objDb.Reviewed = blIsReviewed;
            objDb.UploadDataTable = dtTemp;
            objDb.User = int.Parse(dtTemp.Rows[0]["CurrentUser"].ToString());
            objDb.Reviewed = blIsReviewed;
            objDb.UploadDataUser();
        }
        public void SetCacheWorker(string strCostCenter)
        {
            
        }
        #endregion
    }
}
