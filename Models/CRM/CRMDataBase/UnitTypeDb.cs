using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.CRM.CRMDataBase
{
    public class UnitTypeDb : BaseSingleDb
    {
        #region Private Data
        #endregion

        #region Constractors
        public UnitTypeDb()
        { 

        }
        public UnitTypeDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public UnitTypeDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion

        #region Public Accessorice
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     UnitTypeID, UnitTypeNameA, UnitTypeNameE"+
                                  " FROM         CRMUnitType ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods
        void SetData(DataRow objDR)
        {
            if(objDR["UnitTypeID"].ToString()!= "")
            _ID = int.Parse(objDR["UnitTypeID"].ToString());
            _NameA = objDR["UnitTypeNameA"].ToString();
            _NameE = objDR["UnitTypeNameE"].ToString();
        }
        #endregion

        #region Public Methods
        public override void Add()
        {
            string strSql = " INSERT INTO CRMUnitType"+
                            " ( UnitTypeNameA, UnitTypeNameE,UsrIns,TimIns)"+
                            " VALUES     ('"+_NameA+"','"+_NameE+"'," + SysData.CurrentUser.ID  +",GetDate()) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Edit()
        {
            string strSql = " UPDATE    CRMUnitType"+
                            " SET  UnitTypeNameA ='"+_NameA+"'"+
                            ", UnitTypeNameE = '"+_NameE+"'"+
                            ",UsrUpd="+SysData.CurrentUser.ID +
                            ",TimUpd=GetDate() "+
                            " Where UnitTypeID  = "+_ID+"";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = " UPDATE    CRMUnitType"+
                            " SET   Dis = GetData() "+
                            " Where UnitTypeID  = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis Is Null ";
            if (_ID != 0)
                strSql += " and  UnitTypeID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
