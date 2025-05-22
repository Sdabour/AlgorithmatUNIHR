using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.Base.BaseDataBase;



namespace SharpVision.HR.HRDataBase
{
    public class PenaltyReasonDb : BaseSingleDb
    {
         #region Private Data        
        #endregion
        #region Constructors
        public PenaltyReasonDb()
        {
        }
        public PenaltyReasonDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public PenaltyReasonDb(DataRow objDR)
        {
            SetData(objDR);           
        }
        #endregion
        #region Public Properties
        
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRPenaltyReason.PenaltyReasonID, HRPenaltyReason.PenaltyReasonNameA, HRPenaltyReason.PenaltyReasonNameE FROM  HRPenaltyReason ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _ID = int.Parse(objDR["PenaltyReasonID"].ToString());
            _NameA = objDR["PenaltyReasonNameA"].ToString();
            _NameE = objDR["PenaltyReasonNameE"].ToString();
           
        }
        #endregion
        #region Public Methods
        public override void Add()
        {

            string strSql = "insert into HRPenaltyReason (PenaltyReasonNameA,PenaltyReasonNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";            
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
        }
        public override void Edit()
        {
            

            string strSql = "update  HRPenaltyReason ";
            strSql = strSql + " set PenaltyReasonNameA ='" + _NameA + "'";
            strSql = strSql + " ,PenaltyReasonNameE ='" + _NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID +"";            
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where PenaltyReasonID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRPenaltyReason set Dis = GetDate() where PenaltyReasonID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRPenaltyReason.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and PenaltyReasonID = " + _ID.ToString();


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
