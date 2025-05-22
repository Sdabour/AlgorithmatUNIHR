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
    public class MotivationStatementRelatedStatementDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _RelatedStatement;
        protected int _OrderVal;
        protected string _RelatedStatementIDs;

        #endregion
        #region Constructors
        public MotivationStatementRelatedStatementDb()
        {
        }
        public MotivationStatementRelatedStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int RelatedStatement { set { _RelatedStatement = value; } get { return _RelatedStatement; } }
        public int OrderVal { set { _OrderVal = value; } get { return _OrderVal; } }
        public string RelatedStatementIDs { set { _RelatedStatementIDs = value; } }       

        public string AddStr
        {
            get
            {


                string ReturnedStr = " INSERT INTO HRMotivationStatementRelatedStatement " +
                                     " (MotivationStatement, RelatedStatement,OrderVal)" +
                                     " VALUES (" + _MotivationStatement + "," + _RelatedStatement + ","+ _OrderVal +")";
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
                string ReturnedStr = " Delete From HRMotivationStatementRelatedStatement "+
                                     " Where  MotivationStatement = "+ _MotivationStatement +""+
                                     " And RelatedStatement = "+ _RelatedStatement +"";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT  MotivationStatement, RelatedStatement ,OrderVal,StatementTable.* " +
                                     " FROM         HRMotivationStatementRelatedStatement "+
                                     " inner join ("+ MotivationStatementDb.SearchStr +") as StatementTable "+
                                     " on  HRMotivationStatementRelatedStatement.RelatedStatement = StatementTable.MotivationStatementID ";
                                    
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _RelatedStatement = int.Parse(objDr["RelatedStatement"].ToString());
            _OrderVal = int.Parse(objDr["OrderVal"].ToString());            
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
            if (_RelatedStatement != 0)
                StrSql = StrSql + " And RelatedStatement = " + _RelatedStatement + "";
            if (_RelatedStatementIDs != null && _RelatedStatementIDs!="")
                StrSql = StrSql + " And RelatedStatement in ( " + _RelatedStatementIDs + ")";

            StrSql += " Order by OrderVal";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }        
        #endregion
    }
}
