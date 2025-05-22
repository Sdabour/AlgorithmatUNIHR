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
    public class MotivationStatementGlobalStatementDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _GlobalStatement;
        protected string _GlobalStatementIDs;

        #endregion
        #region Constructors
        public MotivationStatementGlobalStatementDb()
        {
        }
        public MotivationStatementGlobalStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int GlobalStatement { set { _GlobalStatement = value; } get { return _GlobalStatement; } }
        public string GlobalStatementIDs { set { _GlobalStatementIDs = value; } }       

        public string AddStr
        {
            get
            {


                string ReturnedStr = " INSERT INTO HRMotivationStatementGlobalStatement " +
                                     " (MotivationStatement, GlobalStatement)" +
                                     " VALUES (" + _MotivationStatement + "," + _GlobalStatement + ")";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                
               
                string ReturnedStr = " ";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " Delete From HRMotivationStatementGlobalStatement "+
                                     " Where  MotivationStatement = "+ _MotivationStatement +""+
                                     " And GlobalStatement = "+ _GlobalStatement +"";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT  MotivationStatement, GlobalStatement ,GlobalStatementTable.* " +
                                     " FROM         HRMotivationStatementGlobalStatement "+
                                     " Inner join (" + GlobalStatementDb.SearchStr + ") as GlobalStatementTable "+
                                     " ON GlobalStatementTable.StatementID = HRMotivationStatementGlobalStatement.GlobalStatement";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _GlobalStatement = int.Parse(objDr["GlobalStatement"].ToString());            
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
            if (_MotivationStatement != 0)
                StrSql = StrSql + " And MotivationStatement = " + _MotivationStatement + "";
            if (_GlobalStatement != 0)
                StrSql = StrSql + " And GlobalStatement = " + _GlobalStatement + "";
            if (_GlobalStatementIDs != null && _GlobalStatementIDs!="")
                StrSql = StrSql + " And GlobalStatement in ( " + _GlobalStatementIDs + ")";           
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }        
        #endregion
    }
}
