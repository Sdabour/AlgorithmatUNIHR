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
    public class MotivationStatementCostcenterTreeDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _CostCenter;
        protected int _CostCenterParent;
        protected string _CostCenterParentCode;
        protected string _CostCenterParentName;
        int _CostCenterTypeSearch;
        int _SrcStatement;

        public int SrcStatement
        {
            
            set { _SrcStatement = value; }
        }
        int _DestStatement;

        public int DestStatement
        {
          
            set { _DestStatement = value; }
        }
        #endregion
        #region Constructors
        public MotivationStatementCostcenterTreeDb()
        {

        }
        public MotivationStatementCostcenterTreeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int CostCenter { set { _CostCenter = value; } get { return _CostCenter; } }
        public int CostCenterParent { set { _CostCenterParent = value; } get { return _CostCenterParent; } }
        public int CostCenterTypeSearch { set { _CostCenterTypeSearch = value; } }
        public string CostCenterParentCode
        {
            get
            {
                return _CostCenterParentCode;
            }
        }
        public string CostCenterParentName
        {
            get
            {
                return _CostCenterParentName;
            }
        }
        public string AddStr
        {
            get
            {
                string strReturn = " INSERT INTO HRMotivationStatementCostCenterTree "+
                                   " (MotivationStatement, CostCenter, CostCenterParent)"+
                                   " VALUES ("+ _MotivationStatement +","+ _CostCenter +","+ _CostCenterParent +")";

                return strReturn ;
            }
        }        
        public string DeleteStr
        {
            get
            {
                string strReturn = " DELETE FROM HRMotivationStatementCostCenterTree "+
                                   " WHERE (MotivationStatement = " + _MotivationStatement + ") " +
                                   " AND (CostCenter = " + _CostCenter + ") " +
                                   " AND (CostCenterParent = " + _CostCenterParent + ")";

                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strCostCenterParent = "SELECT  CostCenterID AS CostCenterParentID, CostCenterCode AS CostCenterParentCode, CostCenterNameA AS CostCenterParentName "+
                        " FROM         dbo.GLCostCenter ";
                string strReturn = "SELECT     MotivationStatement, CostCenter, CostCenterParent  "+
                    ",CostCenterTable.*,MotivationStatementTable.*,CostCenterParentTable.*   " +
                    " FROM         HRMotivationStatementCostCenterTree "+
                    " left outer join (" + MotivationStatementDb.SearchStr + ") as MotivationStatementTable "+
                    " on HRMotivationStatementCostCenterTree.MotivationStatement = MotivationStatementTable.MotivationStatementID "+
                    " left outer join ("+ CostCenterHRDb.SearchStr +" ) as CostCenterTable "+
                    " on HRMotivationStatementCostCenterTree.CostCenter = CostCenterTable.CostCenterID "+
                    " left outer join ("+ strCostCenterParent +") as CostCenterParentTable "+
                    " on  HRMotivationStatementCostCenterTree.CostCenterParent = CostCenterParentTable.CostCenterParentID ";

                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _CostCenter = int.Parse(objDr["CostCenter"].ToString());
            _CostCenterParent = int.Parse(objDr["CostCenterParent"].ToString());
            _CostCenterParentCode = objDr["CostCenterParentCode"].ToString();
            _CostCenterParentName = objDr["CostCenterParentName"].ToString();
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
            if (_MotivationStatement != 0)
            {
                StrSql += " And ( MotivationStatement = "+ _MotivationStatement +")";
            }
            if (_CostCenterParent != 0)
            {
                StrSql += " And ( CostCenterParent = " + _CostCenterParent + ")";
            }
            if (_CostCenter != 0)
            {
                StrSql += " And ( CostCenter = " + _CostCenter + ")";
            }
            if (_CostCenterTypeSearch != 0)
            {
                StrSql += " And ( CostCenter in (SELECT CostCenter FROM         HRCostCenter WHERE (CostCenterType = " + _CostCenterTypeSearch + ")))";
            }
            StrSql += " Order by MotivationStatement,CostCenterParent,CostCenter";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public void DeleteCostCenterTree(int intMotivationStatementID)
        {
            string strSql = " DELETE FROM HRMotivationStatementCostCenterTree " +
                                  " WHERE (MotivationStatement = " + intMotivationStatementID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
                                  
        }
        public void CopyCostCenterTree()
        {
            if (_SrcStatement == 0 || _DestStatement == 0)
                return;
            string strSql = "SELECT DISTINCT "+ _DestStatement +" AS MotivationStatement1, dbo.HRMotivationStatementCostCenterTree.CostCenter, dbo.HRMotivationStatementCostCenterTree.CostCenterParent "+
                             " FROM            dbo.HRMotivationStatementCostCenterTree LEFT OUTER JOIN "+
                             " (SELECT DISTINCT CostCenter, MotivationStatement "+
                             " FROM            dbo.HRMotivationStatementCostCenterTree AS HRMotivationStatementCostCenterTree_1 "+
                             " WHERE        (MotivationStatement = 2)) AS derivedtbl_1 ON  "+
                             " dbo.HRMotivationStatementCostCenterTree.MotivationStatement = derivedtbl_1.MotivationStatement AND  "+
                             " dbo.HRMotivationStatementCostCenterTree.CostCenter = derivedtbl_1.CostCenter "+
                             " WHERE        (dbo.HRMotivationStatementCostCenterTree.MotivationStatement = "+ _SrcStatement +") AND (derivedtbl_1.CostCenter IS NULL)";
            strSql = " insert into dbo.HRMotivationStatementCostCenterTree (MotivationStatement, CostCenter, CostCenterParent)   " + strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
