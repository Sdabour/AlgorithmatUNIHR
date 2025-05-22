using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class BankHRDb : BankDb
    {
        #region Private Data        
        protected int _Bank;  
        protected int _Status;        
        string _BankIDs;
        
        #endregion
        #region Constructors
        public BankHRDb()
        {
        }
        public BankHRDb(DataRow objDr)
            :base(objDr)
        {            
            SetData(objDr);
        }
        public BankHRDb(int intID)
            : base(intID)
        {
            if (intID == 0)
                return;
            _ID = intID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count == 0)
                return;
            DataRow objDR = dtTemp.Rows[0];          
            SetData(objDR);            
        }
        #endregion
        #region Public Properties        
        public int Bank
        {
            set
            {
                _Bank = value;
            }
            get
            {
                return _Bank;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
       
        public string BankIDs
        {
            set
            {
                _BankIDs = value;
            }
        }
       
        public string AddStr
        {
            get
            {
                string strReturned = " INSERT INTO HRBank(Bank, Status)" +
                                     " VALUES     (" + _ID + "," + _Status + ")";
                return strReturned;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturned = "";
                return strReturned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturned = "";
                return strReturned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturned = " SELECT  BankTable.*  FROM  GLBank " +
                                     
                                     " Left Outer Join (" + BankDb.SearchStr + ") as BankTable On BankTable.BankID = HRBank.Bank ";
                return strReturned;               
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["BankID"].ToString() != "")
                _Bank = int.Parse(objDr["BankID"].ToString());            
        }
        #endregion
        #region Public Methods
       
        public  DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_Bank != 0)
            {
                strSql += " And Bank =" + _Bank + "";
            }
          
            if (_ID != 0)
            {
                strSql += " And Bank =" + _ID + "";
            }
            if (_BankIDs != null && _BankIDs!="")
            {
                strSql += " And Bank in (" + _BankIDs + ")";
            }
                       
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

       
        #endregion
    }
}
