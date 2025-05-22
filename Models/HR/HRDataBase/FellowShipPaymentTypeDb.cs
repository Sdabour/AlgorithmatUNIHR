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
    public class FellowShipPaymentTypeDb : BaseSingleDb
    {
        #region Private Data      
        protected int _FellowShipPaymentMainType;
        #endregion
        #region Constructors
        public FellowShipPaymentTypeDb()
        {

        }
        public FellowShipPaymentTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        public FellowShipPaymentTypeDb(DataRow objDR)
        {            
            SetData(objDR);
        }
        public FellowShipPaymentTypeDb(int intID, string strName)
        {
            _ID = intID;
            _NameA = strName;           
        }
        #endregion
        #region Public Properties  
        public int FellowShipPaymentMainType
        {
            set { _FellowShipPaymentMainType = value; }
            get { return _FellowShipPaymentMainType; }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = @" SELECT HRFellowShipPaymentType.FellowShipPaymentTypeID, HRFellowShipPaymentType.FellowShipPaymentTypeNameA," +
                                   " HRFellowShipPaymentType.FellowShipPaymentTypeNameE"+//,HRFellowShipPaymentType.FellowShipPaymentMainType";//,FellowShipPaymentMainTypeTable.* " +
                                   " FROM HRFellowShipPaymentType ";//Inner Join (" + FellowShipPaymentMainTypeDb.SearchStr + ") as FellowShipPaymentMainTypeTable" +
                                   //" On FellowShipPaymentMainTypeTable.FellowShipPaymentMainTypeID = HRFellowShipPaymentType.FellowShipPaymentMainType";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["FellowShipPaymentTypeID"].ToString() != "")
                _ID = int.Parse(objDR["FellowShipPaymentTypeID"].ToString());
            _NameA = objDR["FellowShipPaymentTypeNameA"].ToString();
            _NameE = objDR["FellowShipPaymentTypeNameE"].ToString();
            _FellowShipPaymentMainType = 0;// int.Parse(objDR["FellowShipPaymentMainType"].ToString());                    
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            string strSql = "insert into HRFellowShipPaymentType (FellowShipPaymentTypeNameA,FellowShipPaymentTypeNameE,FellowShipPaymentMainType,UsrIns,TimIns) " +
            "values('" + _NameA + "','" + _NameE + "'," + _FellowShipPaymentMainType + "," + SysData.CurrentUser.ID + ",Getdate())";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);            
        }
        public override void Edit()
        {            
            string strSql = "update  HRFellowShipPaymentType ";
            strSql = strSql + " set FellowShipPaymentTypeNameA ='" + _NameA + "'";
            strSql = strSql + " , FellowShipPaymentTypeNameE ='" + NameE + "'";
            strSql = strSql + " , FellowShipPaymentMainType =" + _FellowShipPaymentMainType + "";
            strSql = strSql + ",UsrUpd = " + SysData.CurrentUser.ID;
            strSql = strSql + ",TimUpd =Getdate() ";
            strSql = strSql + " where FellowShipPaymentTypeID = " + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public override void Delete()
        {
            string strSql = "update HRFellowShipPaymentType set Dis = GetDate() where FellowShipPaymentTypeID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public override DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (HRFellowShipPaymentType.Dis IS NULL)";
            if (_ID != 0)
                strSql = strSql + " and FellowShipPaymentTypeID = " + _ID.ToString();
            if (_FellowShipPaymentMainType != 0)
                strSql = strSql + " and FellowShipPaymentMainType = " + _FellowShipPaymentMainType.ToString();
                       
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
