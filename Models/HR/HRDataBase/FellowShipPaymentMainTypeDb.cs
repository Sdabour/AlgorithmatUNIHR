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
    public class FellowShipPaymentMainTypeDb : BaseSingleDb
    {
        #region Private Data                
        #endregion
        #region Constructors
        public FellowShipPaymentMainTypeDb()
        {

        }
        public FellowShipPaymentMainTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        public FellowShipPaymentMainTypeDb(DataRow objDR)
        {            
            SetData(objDR);
        }
        public FellowShipPaymentMainTypeDb(int intID, string strName)
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
                string Returned = @" SELECT HRFellowShipPaymentMainType.FellowShipPaymentMainTypeID, HRFellowShipPaymentMainType.FellowShipPaymentMainTypeNameA,HRFellowShipPaymentMainType.FellowShipPaymentMainTypeNameE
                                     FROM HRFellowShipPaymentMainType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FellowShipPaymentMainTypeID"].ToString() != "")
                _ID = int.Parse(objDR["FellowShipPaymentMainTypeID"].ToString());
            _NameA = objDR["FellowShipPaymentMainTypeNameA"].ToString();
            _NameE = objDR["FellowShipPaymentMainTypeNameE"].ToString();                                  
        }
        #endregion
        #region Public Methods
        public override void Add()
        {            
            string strSql = "insert into HRFellowShipPaymentMainType (FellowShipPaymentMainTypeNameA,FellowShipPaymentMainTypeNameE,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);            
        }
        public override void Edit()
        {            
            string strSql = "update  HRFellowShipPaymentMainType ";
            strSql = strSql + " set FellowShipPaymentMainTypeNameA ='" + _NameA + "'";
            strSql = strSql + " , FellowShipPaymentMainTypeNameE ='" + NameE + "'";            
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FellowShipPaymentMainTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRFellowShipPaymentMainType set Dis = GetDate() where FellowShipPaymentMainTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRFellowShipPaymentMainType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FellowShipPaymentMainTypeID = " + _ID.ToString();
                       
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
