using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class GlobalStatementPaymentDb
    {
        #region Private Data
        protected int _ID;
        protected int _GlobalStatement;
        protected string  _PaymentDesc;
        #endregion
        #region Constructors
        public GlobalStatementPaymentDb()
        {
        }
        public GlobalStatementPaymentDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID { set { _ID = value; } get { return _ID; } }
        public int GlobalStatement { set { _GlobalStatement = value; } get { return _GlobalStatement; } }
        public string PaymentDesc { set { _PaymentDesc = value; } get { return _PaymentDesc; } }

        public string AddStr
        {
            get
            {
                string strReturn=" INSERT INTO HRGlobalStatementPayment"+
                                 " (GlobalStatement, PaymentDesc, UsrIns, TimIns)"+
                                 " VALUES ("+ _GlobalStatement +",'"+ _PaymentDesc +"',"+ SysData.CurrentUser.ID +",GetDate())";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturn = " UPDATE    HRGlobalStatementPayment "+
                                   "  SET GlobalStatement =" + _GlobalStatement + "" +
                                   " ,PaymentDesc ='" + _PaymentDesc + "'" +
                                   " ,UsrUpd ="+ SysData.CurrentUser.ID +", TimUpd = GetDate()" +
                                   " WHERE     (GlobalStatementPaymentID = "+ _ID +")";

                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " UPDATE    HRGlobalStatementPayment SET Dis = WHERE (GlobalStatementPaymentID =" + _ID + ")";

                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = "SELECT     GlobalStatementPaymentID, GlobalStatement, PaymentDesc FROM         HRGlobalStatementPayment";

                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["GlobalStatementPaymentID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["GlobalStatementPaymentID"].ToString());
            _GlobalStatement = int.Parse(objDr["GlobalStatement"].ToString());
            _PaymentDesc = objDr["PaymentDesc"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
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
            string StrSql = SearchStr + " Where Dis is Null ";
            if (_GlobalStatement != 0)
                StrSql = StrSql + " And GlobalStatement = " + _GlobalStatement + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
