using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class FellowShipPaymentCol : CollectionBase
    {
        #region Private Data
        FellowShipStatementCol _StatementCol;
        #endregion
        #region Constructors
        public FellowShipPaymentCol(bool IsEmpty)
        {
        }
        public FellowShipPaymentCol()
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            DataTable dtTemp = objDb.Search();            
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }

               
                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz)
        {
            if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
                return;
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            //if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
            //    return;
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            if (objApplicantWorkerBiz != null)
                objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz,
            byte byIsApplicantSearch)
        {
            //if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
            //    return;
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            if (objApplicantWorkerBiz != null)
                objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            objDb.IsApplicantSearch = byIsApplicantSearch;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz,
            byte byIsApplicantSearch, byte byIsPaymentDateSearch,double dblStartValue,double dblEndValue)
        {
            //if (objFellowShipStatementBiz == null || objFellowShipStatementBiz.ID == 0)
            //    return;
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            if (objApplicantWorkerBiz != null)
                objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.SetApplicantCache = true;
            objDb.IsApplicantSearch = byIsApplicantSearch;
            objDb.IsPaymentDateSearch = byIsPaymentDateSearch;
            objDb.StartValue = dblStartValue;
            objDb.EndValue = dblEndValue;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz,ApplicantWorkerBiz objApplicantWorkerBiz,
            bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
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
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(FellowShipStatementBiz objFellowShipStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz,
            bool blSearch, DateTime dtFrom, DateTime dtTo,
            FellowShipPaymentMainTypeBiz objFellowShipPaymentMainTypeBiz,
            FellowShipPaymentTypeBiz objFellowShipPaymentTypeBiz, byte byIsDateSearch)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = objFellowShipStatementBiz.ID;
            if(objApplicantWorkerBiz!=null)
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            if (objFellowShipPaymentMainTypeBiz != null)
                objDb.FellowShipPaymentMainType = objFellowShipPaymentMainTypeBiz.ID;
            if (objFellowShipPaymentTypeBiz != null)
                objDb.FellowShipPaymentType = objFellowShipPaymentTypeBiz.ID;

            objDb.IsPaymentDateSearch = byIsDateSearch;
            

            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }

        public FellowShipPaymentCol(FellowShipStatementCol objFellowShipStatementCol, ApplicantWorkerBiz objApplicantWorkerBiz,
           bool blSearch, DateTime dtFrom, DateTime dtTo,
           FellowShipPaymentMainTypeBiz objFellowShipPaymentMainTypeBiz, FellowShipPaymentTypeBiz objFellowShipPaymentTypeBiz
            , byte byIsPaymentDateSearch, byte byIsApplicantSearch)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.StatementIDs = objFellowShipStatementCol.IDs;
            if (objApplicantWorkerBiz != null)
                objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.DateSearch = blSearch;
            objDb.DateFromSearch = dtFrom;
            objDb.DateToSearch = dtTo;
            if (objFellowShipPaymentMainTypeBiz != null )
                objDb.FellowShipPaymentMainType = objFellowShipPaymentMainTypeBiz.ID;
            if (objFellowShipPaymentTypeBiz != null)
                objDb.FellowShipPaymentType = objFellowShipPaymentTypeBiz.ID;

            objDb.IsPaymentDateSearch = byIsPaymentDateSearch;
            objDb.IsApplicantSearch = byIsApplicantSearch;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }

        public FellowShipPaymentCol(ApplicantWorkerBiz objApplicantWorkerBiz, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
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
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(ApplicantWorkerCol objApplicantWorkerCol)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.ApplicantIDs = objApplicantWorkerCol.IDs;
            objDb.SetApplicantCache = true;
            DataTable dtTemp = objDb.Search();
            GetStatementCol(dtTemp);
            foreach (DataRow DR in dtTemp.Rows)
            {
                FellowShipStatementBiz objStatementBiz = new FellowShipStatementBiz();
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        public FellowShipPaymentCol(ApplicantWorkerCol objApplicantWorkerCol, bool blSearch, DateTime dtFrom, DateTime dtTo)
        {
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
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
                if (_StatementCol != null && _StatementCol.Count != 0 && DR["PaymentStatement"].ToString() != "" && DR["PaymentStatement"].ToString() != "0")
                {
                    objStatementBiz = _StatementCol[_StatementCol.GetIndex(int.Parse(DR["PaymentStatement"].ToString()))];
                }


                this.Add(new FellowShipPaymentBiz(DR, objStatementBiz));
            }
        }
        #endregion
        #region Public Properties
        public virtual FellowShipPaymentBiz this[int intIndex]
        {
            get
            {
                return (FellowShipPaymentBiz)this.List[intIndex];
            }
        }
        public virtual void Add(FellowShipPaymentBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(FellowShipPaymentBiz objBiz)
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
                foreach (FellowShipPaymentBiz objbiz in this)
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
                foreach (FellowShipPaymentBiz objBiz in this)
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
                if (objDr["PaymentStatement"].ToString() != "" && objDr["PaymentStatement"].ToString() != "0")
                {
                    if (strStatementIDs != "")
                        strStatementIDs += "," + objDr["PaymentStatement"].ToString();
                    else
                        strStatementIDs = objDr["PaymentStatement"].ToString();
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
            FellowShipPaymentDb objDb = new FellowShipPaymentDb();
            objDb.Statement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditStatement();
        }

        public FellowShipPaymentCol GetFellowShipPaymentColByApplicantName(string strName)
        {
            if (strName == "")
                return this;
            FellowShipPaymentCol objCol = new FellowShipPaymentCol(false);
            foreach (FellowShipPaymentBiz objBiz in this)
            {
                if(objBiz.ApplicantBiz.Name!=null)
                if (objBiz.ApplicantBiz.Name.IndexOf(strName) != -1)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        public FellowShipPaymentCol GetFellowShipPaymentColByApplicantCode(string strCode)
        {
            if (strCode == "")
                return this;
            FellowShipPaymentCol objCol = new FellowShipPaymentCol(false);
            foreach (FellowShipPaymentBiz objBiz in this)
            {
                if (objBiz.ApplicantBiz.Name != null)
                    if (objBiz.ApplicantBiz.Code == strCode)
                        objCol.Add(objBiz);
            }
            return objCol;
        }
        public FellowShipPaymentCol GetFellowShipPaymentColByDesc(string strDesc)
        {
            if (strDesc == "")
                return this;
            FellowShipPaymentCol objCol = new FellowShipPaymentCol(false);
            foreach (FellowShipPaymentBiz objBiz in this)
            {
                if (SystemBase.SysUtility.ReplaceStringComp(objBiz.Desc).IndexOf(strDesc) != -1)
                    objCol.Add(objBiz);
            }
            return objCol;
        }
        public FellowShipPaymentCol GetFellowShipPaymentColByApplicantNameAndDesc(string strName)
        {
            if (strName == "")
                return this;
            FellowShipPaymentCol objCol = new FellowShipPaymentCol(false);
            foreach (FellowShipPaymentBiz objBiz in this)
            {
                if (objBiz.ApplicantBiz.ID != 0)
                {
                    if (objBiz.ApplicantBiz.Name != null)
                        if (objBiz.ApplicantBiz.Name.IndexOf(strName) != -1)
                            objCol.Add(objBiz);
                }
                else
                {
                    if (SystemBase.SysUtility.ReplaceStringComp(objBiz.Desc).IndexOf(strName) != -1)
                        objCol.Add(objBiz);
                }
            }
            return objCol;
        }
        #endregion
    }
}
