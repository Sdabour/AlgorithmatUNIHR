using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class FellowShipIncomeCol : CollectionBase
    {
        #region Private Data
        FellowShipStatementCol _StatementCol;
        #endregion
        #region Constructors
        public FellowShipIncomeCol(bool IsEmpty)
        {
        }
        public FellowShipIncomeCol()
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(FellowShipStatementBiz objFellowShipStatementBiz)
        {
            if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
                return;
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(FellowShipStatementBiz objFellowShipStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
                return;
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            if (objApplicantWorkerBiz != null)
                objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(FellowShipStatementBiz objFellowShipStatementBiz,ApplicantWorkerBiz objApplicantWorkerBiz,
            bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(ApplicantWorkerBiz objApplicantWorkerBiz, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(ApplicantWorkerCol objApplicantWorkerCol)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        public FellowShipIncomeCol(ApplicantWorkerCol objApplicantWorkerCol, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["IncomeStatement"].ToString() != "" && DR["IncomeStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["IncomeStatement"].ToString()))];
                }


                this.Add(new FellowShipIncomeBiz(DR, objStatementBiz));
            }
        }
        #endregion
        #region Public Properties
        public virtual FellowShipIncomeBiz this[int intIndex]
        {
            get
            {
                return (FellowShipIncomeBiz)this.List[intIndex];
            }
        }
        public virtual void Add(FellowShipIncomeBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(FellowShipIncomeBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == objBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        public double TotalValue
        {
            get
            {
                double dlReturned = 0;
                foreach (FellowShipIncomeBiz objbiz in this)
                {
                    dlReturned += objbiz.Value;   
                }
                return dlReturned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (FellowShipIncomeBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void GetStatementCol(DataTable dtTemp)
        {
            string strStatementIDs = "";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (objDr["IncomeStatement"].ToString() != "" && objDr["IncomeStatement"].ToString() != "0")
                {
                    if (strStatementIDs != "")
                        strStatementIDs += "," + objDr["IncomeStatement"].ToString();
                    else
                        strStatementIDs = objDr["IncomeStatement"].ToString();
                }
            }
            if (strStatementIDs == "")
                _StatementCol = new FellowShipStatementCol();
            else
            {
                _StatementCol = new FellowShipStatementCol(strStatementIDs);
            }
        }
        #endregion
        #region Public Methods
        public void EditStatement(int intStatementID)
        {
            FellowShipIncomeDb objDb = new FellowShipIncomeDb();
            objDb.Statement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditStatement();
        }

        public FellowShipIncomeCol GetFellowShipIncomeColByApplicantName(string strName)
        {
            if (strName == "")
                return this;
            FellowShipIncomeCol objCol = new FellowShipIncomeCol(false);
            foreach (FellowShipIncomeBiz objBiz in this)
            {
                if (objBiz.ApplicantBiz.NameComp.IndexOf(strName) != -1)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        public FellowShipIncomeCol GetFellowShipIncomeColByDesc(string strDesc)
        {
            if (strDesc == "")
                return this;
            FellowShipIncomeCol objCol = new FellowShipIncomeCol(false);
            foreach (FellowShipIncomeBiz objBiz in this)
            {
                if (SystemBase.SysUtility.ReplaceStringComp(objBiz.Desc).IndexOf(strDesc) != -1)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        
        #endregion
    }
}
