using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class GlobalStatementDetailsDb
    {
        #region Private Data
        protected int _StatementID;
        protected int _StatementDetailType;
        #endregion
        #region Constructors
        public GlobalStatementDetailsDb()
        {
        }
        public GlobalStatementDetailsDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int StatementID
        {
            set
            {
                _StatementID = value;
            }
            get
            {
                return _StatementID;
            }
        }
        public int StatementDetailType
        {
            set
            {
                _StatementDetailType = value;
            }
            get
            {
                return _StatementDetailType;
            }
        }

        public string AddStr
        {
            get
            {               
                string ReturnedStr = " INSERT INTO HRGlobalStatementDetails"+
                                     " (StatementID, StatementDetailType) VALUES (" + _StatementID + "," + _StatementDetailType + ")";
                return ReturnedStr;
            }
        }        
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRGlobalStatementDetails" +
                                     " WHERE     (StatementID = " + _StatementID + ")";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     HRGlobalStatementDetails.StatementID, HRGlobalStatementDetails.StatementDetailType ,DetailTypeTable.*" +
                                     " FROM  HRGlobalStatementDetails" +
                                     " Left Outer Join (" + DetailTypeDb.SearchStr + ") DetailTypeTable On DetailTypeTable.DetailTypeID = HRGlobalStatementDetails.StatementDetailType";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _StatementID = int.Parse(objDr["StatementID"].ToString());
            _StatementDetailType = int.Parse(objDr["StatementDetailType"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";            
            if (_StatementID != 0)
                StrSql = StrSql + " And StatementID = " + _StatementID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
