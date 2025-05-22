using System;
using System.Collections.Generic;
using System.Text;
//using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class FellowShipIncomeMainTypeDb : BaseSingleDb
    {
        #region Private Data                
        #endregion
        #region Constructors
        public FellowShipIncomeMainTypeDb()
        {

        }
        public FellowShipIncomeMainTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        public FellowShipIncomeMainTypeDb(DataRow objDR)
        {            
            SetData(objDR);
        }
        public FellowShipIncomeMainTypeDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;           
        }
        #endregion
        #region Public Properties               
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRFellowShipIncomeMainType.FellowShipIncomeMainTypeID, HRFellowShipIncomeMainType.FellowShipIncomeMainTypeNameA,HRFellowShipIncomeMainType.FellowShipIncomeMainTypeNameE
                                     FROM HRFellowShipIncomeMainType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FellowShipIncomeMainTypeID"].ToString() != "")
                _ID = int.Parse(objDR["FellowShipIncomeMainTypeID"].ToString());
            _NameA = objDR["FellowShipIncomeMainTypeNameA"].ToString();
            _NameE = objDR["FellowShipIncomeMainTypeNameE"].ToString();                                  
        }
        #endregion
        #region Public Methods
        public override void Add()
        {            
            string strSql = "insert into HRFellowShipIncomeMainType (FellowShipIncomeMainTypeNameA,FellowShipIncomeMainTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);            
        }
        public override void Edit()
        {            
            string strSql = "update  HRFellowShipIncomeMainType ";
            strSql = strSql + " set FellowShipIncomeMainTypeNameA ='" + _NameA + "'";
            strSql = strSql + " , FellowShipIncomeMainTypeNameE ='" + NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FellowShipIncomeMainTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRFellowShipIncomeMainType set Dis = GetDate() where FellowShipIncomeMainTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRFellowShipIncomeMainType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FellowShipIncomeMainTypeID = " + _ID.ToString();
                       
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
