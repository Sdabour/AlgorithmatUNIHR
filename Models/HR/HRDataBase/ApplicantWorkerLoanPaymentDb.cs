using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerLoanPaymentDb
    {
        #region Private Data
        int _LoanPaymentID;
         int _Loan;
         string _LoanIDs;

       
       
    float _PaymenetValue;
         DateTime _PaymenetDate;
        int _StatementID;
        string _Remarks;
        #endregion
        #region Constructors
        public ApplicantWorkerLoanPaymentDb()
        {
        }
        public ApplicantWorkerLoanPaymentDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int LoanPaymentID
        {
            set
            {
                _LoanPaymentID = value;
            }
            get
            {
                return _LoanPaymentID;
            }
        }
        public int Loan
        {
            set
            {
                _Loan = value;
            }
            get
            {
                return _Loan;
            }
        }
        public string LoanIDs
          {
             get { return _LoanIDs; }
             set { _LoanIDs = value; }
         }
        public float PaymenetValue
        {
            set
            {
                _PaymenetValue = value;
            }
            get
            {
                return _PaymenetValue;
            }
        }
        public DateTime PaymenetDate
        {
            set
            {
                _PaymenetDate = value;
            }
            get
            {
                return _PaymenetDate;
            }
        }
        public int StatementID
        {
            set
            {
                _StatementID = value;
            }
            get
            {
                return _StatementID;
            }
        }
        public string Remarks
        {
            set
            {
                _Remarks = value;
            }
            get
            {
                return _Remarks;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerLoanPayment.LoanPaymentID, HRApplicantWorkerLoanPayment.Loan,HRApplicantWorkerLoanPayment.StatementID," +
                                  " HRApplicantWorkerLoanPayment.PaymenetValue, HRApplicantWorkerLoanPayment.PaymenetDate,HRApplicantWorkerLoanPayment.Remarks, ApplicantWorkerLoanTable.* " +
                                  " FROM  HRApplicantWorkerLoanPayment "+
                                  " Left Outer Join (" + ApplicantWorkerLoanDb.SearchStr + ") as ApplicantWorkerLoanTable On ApplicantWorkerLoanTable.LoanID = HRApplicantWorkerLoanPayment.Loan";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dlPaymenetDate = _PaymenetDate.ToOADate() - 2;   
                string strReturn = " INSERT INTO HRApplicantWorkerLoanPayment"+
                                   " (Loan, PaymenetValue, PaymenetDate,StatementID,Remarks, UsrIns, TimIns)" +
                                   " VALUES (" + _Loan + "," + _PaymenetValue + "," + dlPaymenetDate + "," + _StatementID + ",'"+ _Remarks +"'," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                double dlPaymenetDate = _PaymenetDate.ToOADate() - 2;                
                string strReturn = " UPDATE    HRApplicantWorkerLoanPayment"+
                                   "  SET Loan =" + _Loan + "" +
                                   ", PaymenetValue =" + _PaymenetValue + "" +
                                   ", PaymenetDate =" + dlPaymenetDate + "" +
                                   ", StatementID =" + _StatementID + "" +
                                   ", Remarks = '" + _Remarks + "'" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()"+
                                   " Where LoanPaymentID = "+ _LoanPaymentID +"";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " DELETE FROM HRApplicantWorkerLoanPayment"+
                                   " WHERE     (LoanPaymentID = " + _LoanPaymentID + ")";
                return strReturn;
            }

        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["LoanPaymentID"].ToString() == "")
                return;
            _LoanPaymentID = int.Parse(objDr["LoanPaymentID"].ToString());
            _Loan = int.Parse(objDr["Loan"].ToString());
            _PaymenetValue = float.Parse(objDr["PaymenetValue"].ToString());
            _PaymenetDate = DateTime.Parse(objDr["PaymenetDate"].ToString());
            _StatementID = int.Parse(objDr["StatementID"].ToString());
            _Remarks = objDr["Remarks"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _LoanPaymentID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_Loan != 0)
            {
                strSql = strSql + " And Loan = "+ _Loan +"";
            }
            if (_LoanIDs != null && _LoanIDs != "")
            {
                strSql = strSql + " And Loan in  (" + _LoanIDs + ")";
            }
            if (_StatementID != 0)
            {
                strSql = strSql + " And StatementID = " + _StatementID + "";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
