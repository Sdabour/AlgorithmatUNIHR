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
    public class MotivationStatementEstimationStatementDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _EstimationStatement;
        protected int _OrderVal;
        protected bool _MainEstimation;
        protected string _EstimationStatementIDs;
        #endregion
        #region Constructors
        public MotivationStatementEstimationStatementDb()
        {
        }
        public MotivationStatementEstimationStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int EstimationStatement { set { _EstimationStatement = value; } get { return _EstimationStatement; } }
        public int OrderVal { set { _OrderVal = value; } get { return _OrderVal; } }
        public bool MainEstimation { set { _MainEstimation = value; } get { return _MainEstimation; } }
        public string EstimationStatementIDs { set { _EstimationStatementIDs = value; } }       

        public string AddStr
        {
            get
            {

                int intMainStatement = _MainEstimation ? 1 : 0;
                string ReturnedStr = " INSERT INTO HRMotivationStatementEstimationStatement " +
                                     " (MotivationStatement, EstimationStatement,OrderVal,MainEstimation)" +
                                     " VALUES (" + _MotivationStatement + "," + _EstimationStatement + "," + _OrderVal + "," + intMainStatement + ")";
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
                string ReturnedStr = " Delete From HRMotivationStatementEstimationStatement "+
                                     " Where  MotivationStatement = "+ _MotivationStatement +""+
                                     " And EstimationStatement = "+ _EstimationStatement +"";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT  MotivationStatement, EstimationStatement,OrderVal,MainEstimation ,EstimationStatementTable.* " +
                                     " FROM         HRMotivationStatementEstimationStatement "+
                                     " Inner join (" + EstimationStatementDb.SearchStr + ") as EstimationStatementTable "+
                                     " ON EstimationStatementTable.EstimationStatementID = HRMotivationStatementEstimationStatement.EstimationStatement";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _EstimationStatement = int.Parse(objDr["EstimationStatement"].ToString());
if(objDr["OrderVal"].ToString()!="")
            _OrderVal = int.Parse(objDr["OrderVal"].ToString());
        if (objDr["MainEstimation"].ToString() != "")
            _MainEstimation = bool.Parse(objDr["MainEstimation"].ToString());            
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
            if (_EstimationStatement != 0)
                StrSql = StrSql + " And EstimationStatement = " + _EstimationStatement + "";
            if (_EstimationStatementIDs != null && _EstimationStatementIDs != "")
                StrSql = StrSql + " And EstimationStatement in (" + _EstimationStatementIDs + ")";

            StrSql += " Order by OrderVal,MainEstimation";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }        
        #endregion
    }
}
