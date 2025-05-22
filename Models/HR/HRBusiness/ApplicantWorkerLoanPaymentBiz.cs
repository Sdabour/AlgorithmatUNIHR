using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerLoanPaymentBiz
    {
        #region Private Data
        ApplicantWorkerLoanPaymentDb _LoanPaymentDb;
        ApplicantWorkerLoanBiz _LoanBiz;
        ApplicantWorkerStatementBiz _StatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerLoanPaymentBiz()
        {
            _LoanPaymentDb = new ApplicantWorkerLoanPaymentDb();
            _LoanBiz = new ApplicantWorkerLoanBiz();
            _StatementBiz = new ApplicantWorkerStatementBiz();
        }
        public ApplicantWorkerLoanPaymentBiz(DataRow objDr)
        {
            _LoanPaymentDb = new ApplicantWorkerLoanPaymentDb(objDr);
            _LoanBiz = new ApplicantWorkerLoanBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int LoanPaymentID
        {
            set
            {
                _LoanPaymentDb.LoanPaymentID = value;
            }
            get
            {
                return _LoanPaymentDb.LoanPaymentID;
            }
        }
        public ApplicantWorkerLoanBiz LoanBiz
        {
            set
            {
                _LoanBiz = value;
            }
            get
            {
                return _LoanBiz;
            }
        }
        public float PaymenetValue
        {
            set
            {
                _LoanPaymentDb.PaymenetValue = value;
            }
            get
            {
                return _LoanPaymentDb.PaymenetValue;
            }
        }
        public DateTime PaymenetDate
        {
            set
            {
                _LoanPaymentDb.PaymenetDate = value;
            }
            get
            {
                return _LoanPaymentDb.PaymenetDate;
            }
        }
        public ApplicantWorkerStatementBiz StatementBiz
        {
            set
            {
                _StatementBiz = value;
            }
            get
            {
                return _StatementBiz;
            }
        }
        public string Remarks
        {
            set
            {
                _LoanPaymentDb.Remarks = value;
            }
            get
            {
                return _LoanPaymentDb.Remarks;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _LoanPaymentDb.Loan = _LoanBiz.ID;
            if (_StatementBiz != null)
            _LoanPaymentDb.StatementID = _StatementBiz.ID;
            _LoanPaymentDb.Add();
        }
        public void Edit()
        {
            _LoanPaymentDb.Loan = _LoanBiz.ID;
            if(_StatementBiz!=null)
            _LoanPaymentDb.StatementID = _StatementBiz.ID;
            _LoanPaymentDb.Edit();
        }
        public void Delete()
        {           
            _LoanPaymentDb.Delete();
        }
        #endregion
    }
}
