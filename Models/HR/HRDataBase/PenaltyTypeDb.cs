using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class PenaltyTypeDb : BaseSingleDb
    {
         #region Private Data        
        #endregion
        #region Constructors
        public PenaltyTypeDb()
        {
        }
        public PenaltyTypeDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public PenaltyTypeDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        #endregion
        #region Public Properties
        
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRPenaltyType.PenaltyTypeID, HRPenaltyType.PenaltyTypeNameA, HRPenaltyType.PenaltyTypeNameE FROM  HRPenaltyType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["PenaltyTypeID"].ToString());
            _NameA = objDR["PenaltyTypeNameA"].ToString();
            _NameE = objDR["PenaltyTypeNameE"].ToString();
           
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = "insert into HRPenaltyType (PenaltyTypeNameA,PenaltyTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";            
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            

            string strSql = "update  HRPenaltyType ";
            strSql = strSql + " set PenaltyTypeNameA ='" + _NameA + "'";
            strSql = strSql + " ,PenaltyTypeNameE ='" + _NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID +"";            
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where PenaltyTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRPenaltyType set Dis = GetDate() where PenaltyTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRPenaltyType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and PenaltyTypeID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
