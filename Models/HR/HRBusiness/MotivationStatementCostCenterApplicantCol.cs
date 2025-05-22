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
    public class MotivationStatementCostCenterApplicantCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationStatementCostCenterApplicantCol(bool IsEmpty)
        {
        }
        public MotivationStatementCostCenterApplicantCol()
        {
            MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterApplicantBiz(objDr));
            }
        }
        public MotivationStatementCostCenterApplicantCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objMotivationStatementBiz.ID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterApplicantBiz(objDr));
            }
        }
        public MotivationStatementCostCenterApplicantCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRBiz objCostCenterHRBiz)
        {
            MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            objDb.CostCenter = objCostCenterHRBiz.ID;
            if (objMotivationStatementBiz.ID == 0 || objCostCenterHRBiz.ID==0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterApplicantBiz(objDr));
            }
        }
        public MotivationStatementCostCenterApplicantCol(int intMotivationStatementID, int intCostCenterHRID,string strCostCenterIDs )
        {
            
            DataTable dtTemp = GetMotivationApplicantCostCenterTable(strCostCenterIDs ,intMotivationStatementID);
            DataRow[] arrDr = dtTemp.Select("CostCenter=" + intCostCenterHRID+" or 0="+intCostCenterHRID);
            foreach (DataRow objDr in arrDr)
            {
                this.Add(new MotivationStatementCostCenterApplicantBiz(objDr));
            }
        }
        public MotivationStatementCostCenterApplicantCol(int intMotivationStatementID, int objCostCenterHRID,byte byIsSpecialCaseSearch)
        {
            MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
            objDb.MotivationStatement = intMotivationStatementID;
            objDb.IsSpecialCaseSearch = byIsSpecialCaseSearch;
            objDb.CostCenter = objCostCenterHRID;
            if (intMotivationStatementID == 0 || objCostCenterHRID == 0)
                return;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementCostCenterApplicantBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementCostCenterApplicantBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementCostCenterApplicantBiz)this.List[intIndex];
            }
        }
       public string IDs { get {
                string Returned = "";
                foreach(MotivationStatementCostCenterApplicantBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ApplicantWorkerBiz.ID;
                }
                return Returned;
            } }
        static DataTable _MotivationApplicantCostCenterTable;
        public static void SetMotivationApplicantCostCenterTableNull()
        {
            _MotivationApplicantCostCenterTable = null;
        }
        public static DataTable GetMotivationApplicantCostCenterTable(string strCostCenterIDs,int intMotivationStatement)
        {
           
                if (_MotivationApplicantCostCenterTable == null && strCostCenterIDs != null && strCostCenterIDs != "")
                {
                    MotivationStatementCostCenterApplicantDb objDb = new MotivationStatementCostCenterApplicantDb();
                    objDb.MotivationStatement = intMotivationStatement;
                    objDb.CostCenterIDs = strCostCenterIDs;
                    _MotivationApplicantCostCenterTable = objDb.Search();
                }
                return _MotivationApplicantCostCenterTable;
            
        }
        public virtual void Add(MotivationStatementCostCenterApplicantBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRMotivationStatementCostCenterApplicant");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("MotivationStatement"), new DataColumn("CostCenter"), new DataColumn("Applicant") });
            DataRow objDr;
            foreach (MotivationStatementCostCenterApplicantBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["MotivationStatement"] = objBiz.MotivationStatement;
                objDr["CostCenter"] = objBiz.CostCenter;
                objDr["Applicant"] = objBiz.ApplicantWorkerBiz.ID;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
