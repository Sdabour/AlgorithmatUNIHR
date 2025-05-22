using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementExchangeDb
    {
        #region Private Data
        protected int _OriginStatement;
        protected int _GlobalStatementPayment;
        protected double _ExchangeValue;

         string _OriginStatementIDs;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementExchangeDb()
        {
        }
        public ApplicantWorkerStatementExchangeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ApplicantWorkerStatementExchangeDb(int intOriginStatement, int intGlobalStatementPayment)
        {
            _OriginStatement = intOriginStatement;
            _GlobalStatementPayment = intGlobalStatementPayment;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int OriginStatement { set { _OriginStatement = value; } get { return _OriginStatement; } }
        public int GlobalStatementPayment { set { _GlobalStatementPayment = value; } get { return _GlobalStatementPayment; } }
        public double ExchangeValue { set { _ExchangeValue = value; } get { return _ExchangeValue; } }

        public string OriginStatementIDs { set { _OriginStatementIDs = value; } }

        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HRApplicantWorkerStatementExchange "+
                                   " (OriginStatement, GlobalStatementPayment, ExchangeValue, UsrIns, TimIns)"+
                                   " VALUES (" + _OriginStatement + "," + _GlobalStatementPayment + "," + _ExchangeValue + "," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturn = " UPDATE    HRApplicantWorkerStatementExchange " +
                                   "  SET ExchangeValue =" + _ExchangeValue + "" +                                   
                                   " ,UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd = GetDate()" +
                                   " WHERE     (OriginStatement = " + _OriginStatement + ") And (GlobalStatementPayment = " + _GlobalStatementPayment + ")";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " Delete From    HRApplicantWorkerStatementExchange " +                                    
                                   " WHERE     (OriginStatement = " + _OriginStatement + ") And (GlobalStatementPayment = " + _GlobalStatementPayment + ")";
                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = "SELECT     OriginStatement, GlobalStatementPayment, ExchangeValue FROM         HRApplicantWorkerStatementExchange";

                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["OriginStatement"].ToString()=="")
                return;
            _OriginStatement = int.Parse(objDr["OriginStatement"].ToString());
            _GlobalStatementPayment = int.Parse(objDr["GlobalStatementPayment"].ToString());
            _ExchangeValue = int.Parse(objDr["ExchangeValue"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_OriginStatement != 0)
                StrSql = StrSql + " And OriginStatement = " + _OriginStatement + "";

            if (_OriginStatementIDs != null && _OriginStatementIDs!="")
                StrSql = StrSql + " And OriginStatement in (" + _OriginStatementIDs + ")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
