using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class FellowShipStatementDb
    {
        #region Private Data
        protected int _ID;
        protected string _StatementDesc;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        string _IDsSearch;
        

        protected byte _IDIncludeStatus;
        protected int _IDIncludeSearch;
        #endregion
        #region Constructors
        public FellowShipStatementDb()
        {
        }
        public FellowShipStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID { set { _ID = value; } get { return _ID; } }
        public string StatementDesc { set { _StatementDesc = value; } get { return _StatementDesc; } }
        public DateTime DateFrom { set { _DateFrom = value; } get { return _DateFrom; } }
        public DateTime DateTo { set { _DateTo = value; } get { return _DateTo; } }

        public byte IDIncludeStatus { set { _IDIncludeStatus = value; } }
        public int IDIncludeSearch { set { _IDIncludeSearch = value; } }
        public string IDsSearch { set { _IDsSearch = value; } }
        public string AddStr
        {
            get
            {
                double dblDateFrom = _DateFrom.ToOADate() - 2;
                double dblDateTo = _DateTo.ToOADate() - 2;

                string ReturnedStr = " INSERT INTO HRFellowShipStatement " +
                                     " (StatementDesc, DateFrom, DateTo, UsrIns, TimIns)" +
                                     " VALUES ('" + _StatementDesc + "'," + dblDateFrom + "," + dblDateTo + "," +                                     
                                     " " + SysData.CurrentUser.ID + ", GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDateFrom = _DateFrom.ToOADate() - 2;
                double dblDateTo = _DateTo.ToOADate() - 2;

                string ReturnedStr = " UPDATE    HRFellowShipStatement " +
                                     "  SET StatementDesc ='" + _StatementDesc + "'" +
                                     " , DateFrom =" + dblDateFrom + "" +
                                     " , DateTo =" + dblDateTo + "" +                                     
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                     " WHERE     (StatementID = " + _ID + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " UPDATE    HRFellowShipStatement SET Dis = GETDATE()" +
                                     " WHERE     (StatementID = " + _ID + ") ";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     StatementID, StatementDesc, DateFrom, DateTo" +
                                     " FROM         HRFellowShipStatement";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["StatementID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["StatementID"].ToString());
            _StatementDesc = objDr["StatementDesc"].ToString();
            _DateFrom = DateTime.Parse(objDr["DateFrom"].ToString());
            _DateTo = DateTime.Parse(objDr["DateTo"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);           
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
            string StrSql = SearchStr + " Where Dis is Null";
            if (_ID != 0)
                StrSql = StrSql + " And StatementID = " + _ID + "";
            if (_IDsSearch != null && _IDsSearch!="" && _IDsSearch!="0")
                StrSql = StrSql + " And StatementID in ("+ _IDsSearch +")";

            if (_IDIncludeStatus != 0)
            {
                StrSql = StrSql + " And StatementID <> " + _IDIncludeSearch + "";
            }
          
            StrSql += " Order By StatementID desc";//DateFrom desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetLatestMotivationStatement()
        {
            string strSql = SearchStr + " where StatementID = (select max(StatementID)  from  HRFellowShipStatement )";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        #endregion
    }
}
