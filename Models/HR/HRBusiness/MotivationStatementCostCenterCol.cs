using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementCostCenterCol : CollectionBase
    {
        #region Private Data
        DataTable _RelatedMotivationTable;


        DataTable _EstimationTable;

      
        #endregion
        #region Constructors
        public MotivationStatementCostCenterCol(bool IsEmpty)
        {
        }
        public MotivationStatementCostCenterCol()
        {
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterBiz(objDr));
            }
        }
        public MotivationStatementCostCenterCol(MotivationStatementBiz objMotivationStatementBiz,string strCostCenterIDs)
        {
            if (strCostCenterIDs == null || strCostCenterIDs == "")
                return;
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = strCostCenterIDs;
            DataTable dtTemp = objDb.Search();
            MotivationStatementCostCenterBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new MotivationStatementCostCenterBiz(objDr);
                objBiz.MotivationStatementBiz = objMotivationStatementBiz;
                this.Add(objBiz);
            }
        }
        public MotivationStatementCostCenterCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterTypeBiz objCostCenterTypeBiz)
        {
            if (objMotivationStatementBiz == null)
                objMotivationStatementBiz = new MotivationStatementBiz();
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if(objCostCenterTypeBiz!=null)
            objDb.CostCenterType = objCostCenterTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            MotivationStatementCostCenterBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new MotivationStatementCostCenterBiz(objDr);
                if(objMotivationStatementBiz.ID!= 0)
                 objBiz.MotivationStatementBiz = objMotivationStatementBiz;
                this.Add(objBiz);
            }
        }
        public MotivationStatementCostCenterCol(MotivationStatementCol objMotivationStatementCol, CostCenterTypeBiz objCostCenterTypeBiz)
        {
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.MotivationStatementIDs = objMotivationStatementCol.IDsStr;
            if (objCostCenterTypeBiz != null)
                objDb.CostCenterType = objCostCenterTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterBiz(objDr));
            }
        }
        public MotivationStatementCostCenterCol(CostCenterHRBiz objCostCenterHRBiz)
        {
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.CostCenter = objCostCenterHRBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterBiz(objDr));
            }
        }
        public MotivationStatementCostCenterCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRBiz objCostCenterHRBiz)
        {
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenter = objCostCenterHRBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterBiz(objDr));
            }
        }
        public MotivationStatementCostCenterCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRCol objCostCenterHRCol)
        {
            MotivationStatementCostCenterDb objDb = new MotivationStatementCostCenterDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterHRCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementCostCenterBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementCostCenterBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementCostCenterBiz objBiz)
        {
            if (GetIndex(objBiz.CostCenterHRBiz.ID) == -1)
                this.List.Add(objBiz);
        }
        public virtual void Add(MotivationStatementCostCenterBiz objBiz,bool blNoCheck)
        {
            if (blNoCheck)
            {
                if (GetIndex(objBiz.CostCenterHRBiz.ID) == -1)
                    this.List.Add(objBiz);
            }
            else
            {
                this.List.Add(objBiz);
            }
        }
        public int GetIndex(int intID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].CostCenterHRBiz.ID == intID)
                    return intIndex;
            }
            return -1;
        }
        public string CostCenterIDs
        {
            get
            {
                string Returned = "";
                foreach (MotivationStatementCostCenterBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.CostCenterHRBiz.ID.ToString();
                }
                return Returned;
            }
        }
        CostCenterHRCol _CostCenterHRCol;
        public CostCenterHRCol CostCenterHRCol
        {
            set
            {
                _CostCenterHRCol = value;
            }
            get
            {
                if (_CostCenterHRCol == null)
                {
                    _CostCenterHRCol = new CostCenterHRCol(true);
                    foreach (MotivationStatementCostCenterBiz objBiz in this)
                    {
                        _CostCenterHRCol.Add(objBiz.CostCenterHRBiz);
                    }
                }
                return _CostCenterHRCol;
            }
        }
        public ApplicantWorkerCol ApplicantWorkerCol
        {
            get
            {
                ApplicantWorkerCol Returned = new ApplicantWorkerCol(true);
                foreach (MotivationStatementCostCenterBiz objBiz in this)
                {
                    foreach (ApplicantWorkerManyStatementBiz objStatementBiz in objBiz.ManyStatementCol)
                    {
                        Returned.Add(objStatementBiz.ApplicantWorkerBiz);
                    }
                }
                return Returned;
            }
        }
        public MotivationStatementBiz MotivationStatementBiz
        {
            get
            {
                MotivationStatementBiz Returned = new MotivationStatementBiz();
                if (Count > 0)
                    Returned = this[0].MotivationStatementBiz;
                return Returned;
            }
        }
        public ApplicantWorkerManyStatementCol ManyStatementCol
        {
           
            get
            {
                ApplicantWorkerManyStatementCol Returned = new ApplicantWorkerManyStatementCol(true);

                foreach(MotivationStatementCostCenterBiz objCostBiz in this)
                {
                    foreach (ApplicantWorkerManyStatementBiz objStatement in objCostBiz.ManyStatementCol)
                        Returned.Add(objStatement);
                }

                return Returned;
            }
        }
        public DataTable RelatedMotivationTable
        {
            get
            {
                if (_RelatedMotivationTable == null)
                {
                    ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
                    objDb.ApplicantIDs = ApplicantWorkerCol.IDs; 
                    objDb.MotivationStatementIDs = Count>0 ? this[0].MotivationStatementBiz.GetMotivationAndRelatedIDs():"";
                    objDb.SimpleSearch = true;
                    _RelatedMotivationTable = objDb.Search();

                }
                return _RelatedMotivationTable;
            }
            set { _RelatedMotivationTable = value; }
        }
        public DataTable EstimationTable
        {
            get 
            {
                if (_EstimationTable == null)
                {
                    ApplicantWorkerEstimationStatementDb objDb = new ApplicantWorkerEstimationStatementDb();
                    objDb.EstimationStatementIDs = Count >0 ?this[0].MotivationStatementBiz.EstimationStatementCol.EstimationStatementIDs:"";
                    objDb.ApplicantIDs = ApplicantWorkerCol.IDs;
                    _EstimationTable = objDb.Search();
                }
                return _EstimationTable;
            }
            set { _EstimationTable = value; }
        }
        MotivationStatementCostCenterApplicantCol _ApplicantCol;
        public MotivationStatementCostCenterApplicantCol ApplicantCol
        {
            set
            {
                _ApplicantCol = value;
            }
            get
            {
               
                if (_ApplicantCol == null)
                {
                    MotivationStatementCostCenterApplicantCol.SetMotivationApplicantCostCenterTableNull();
                    _ApplicantCol = new MotivationStatementCostCenterApplicantCol(MotivationStatementBiz.ID, 0,CostCenterIDs);
                }

                return _ApplicantCol;
            }
        }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public MotivationStatementCostCenterCol GetMotivationStatementCostCenterColDependOnCostCenterHRBiz(CostCenterHRBiz objCostCenterHRBiz)
        {
            MotivationStatementCostCenterCol objCol = new MotivationStatementCostCenterCol(true);
            foreach (MotivationStatementCostCenterBiz objBiz in this)
            {
                if (objBiz.CostCenterHRBiz.ID == objCostCenterHRBiz.ID)
                    objCol.Add(objBiz,false);
            }
            return objCol;
        }
        //public ApplicantWorkerManyStatementCol GetApplicantWorkerManyStatementCol()
        //{
        //    ApplicantWorkerManyStatementCol _ApplicantWorkerManyStatementCol;
        //    ApplicantWorkerManyStatementCol objManyStatementCol;
        //    foreach (MotivationStatementCostCenterBiz objBiz in this)
        //    {
                
        //    }   
        //    return _ApplicantWorkerManyStatementCol;
        //}       

        public void SetManyCol()
        {
            if (Count == 0)
                return;
            MotivationStatementBiz _MotivationStatementBiz = this[0].MotivationStatementBiz;
            bool blIsDependonStartDate = false;
            if (_MotivationStatementBiz.DateStartDateLimit.Year != 1900)
                blIsDependonStartDate = true;

            ApplicantWorkerManyStatementCol _ManyStatementCol = new ApplicantWorkerManyStatementCol(_MotivationStatementBiz, _MotivationStatementBiz.GetGlobalStatementCol,
            new CostCenterHRBiz(), (byte)this[0].ApplicantStatus, 1, blIsDependonStartDate, _MotivationStatementBiz.DateStartDateLimit
            , this[0].IsIncludeAllApplicant, ApplicantCol.IDs, 0, new CostCenterHRBiz(),strCostCenterIDs: CostCenterIDs);
            

            //_ManyStatementCol.SetSumVariable();
           
            //_ManyStatementCol.GetSumVariable();
            List<ApplicantWorkerManyStatementBiz> lstMany = new List<ApplicantWorkerManyStatementBiz>();
            double dlTotalSalary = _ManyStatementCol.SumTotalSalary;
            foreach(MotivationStatementCostCenterBiz objBiz in this)
            {
                if(objBiz.CostCenterHRBiz.ID== 46868)
                {

                }
                objBiz.ManyStatementCol = new ApplicantWorkerManyStatementCol(true);
                lstMany = _ManyStatementCol.Cast<ApplicantWorkerManyStatementBiz>().Where(x => x.CostCenterHRBiz.ID == objBiz.CostCenterHRBiz.ID).ToList();
                foreach (ApplicantWorkerManyStatementBiz objStatement in lstMany)
                    objBiz.ManyStatementCol.Add(objStatement);
                objBiz.ManyStatementCol.SetSumVariable();
                objBiz.ManyStatementCol.GetSumVariable();
            }

        }
        #endregion
    }
}
