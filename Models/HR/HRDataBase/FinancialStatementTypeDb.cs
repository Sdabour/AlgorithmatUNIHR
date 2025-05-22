using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class FinancialStatementTypeDb : BaseSingleDb
    {
         #region Private Data        
        #endregion
        #region Constructors
        public FinancialStatementTypeDb()
        {
        }
        public FinancialStatementTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public FinancialStatementTypeDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        #endregion
        #region Public Properties
        
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRFinancialStatementType.FinancialStatementTypeID, HRFinancialStatementType.FinancialStatementTypeNameA, HRFinancialStatementType.FinancialStatementTypeNameE FROM  HRFinancialStatementType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FinancialStatementTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDR["FinancialStatementTypeID"].ToString());
            _NameA = objDR["FinancialStatementTypeNameA"].ToString();
            _NameE = objDR["FinancialStatementTypeNameE"].ToString();
           
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = "insert into HRFinancialStatementType (FinancialStatementTypeNameA,FinancialStatementTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";            
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            

            string strSql = "update  HRFinancialStatementType ";
            strSql = strSql + " set FinancialStatementTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,FinancialStatementTypeNameE ='" + _NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID +"";            
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FinancialStatementTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRFinancialStatementType set Dis = GetDate() where FinancialStatementTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRFinancialStatementType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FinancialStatementTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
