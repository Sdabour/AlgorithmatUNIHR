using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementLoanDiscountBiz
    {
        #region Private Data
        ApplicantWorkerStatementLoanDiscountDb _LoanDiscountDb;
        ApplicantWorkerLoanBiz _LoanBiz;
        ApplicantWorkerStatementBiz _StatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementLoanDiscountBiz()
        {
            _LoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb();
            _LoanBiz = new ApplicantWorkerLoanBiz();
            _StatementBiz = new ApplicantWorkerStatementBiz();
        }
        public ApplicantWorkerStatementLoanDiscountBiz(DataRow objDr)
        {
            _LoanDiscountDb = new ApplicantWorkerStatementLoanDiscountDb(objDr);
            _LoanBiz = new ApplicantWorkerLoanBiz(objDr);
            _StatementBiz = new ApplicantWorkerStatementBiz();
            _StatementBiz.ApplicantBiz = _LoanBiz.ApplicantWorkerBiz;
            _StatementBiz.ID = _LoanDiscountDb.Statement;
            _StatementBiz.GlobalStatementBiz.ID = _LoanDiscountDb.GlobalStatement;
            _StatementBiz.GlobalStatementBiz.StatementDesc = _LoanDiscountDb.GlobalStatementDesc;
            _StatementBiz.GlobalStatementBiz.StatementDate = _LoanDiscountDb.GlobalStatementDate;
        }
        
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _LoanDiscountDb.ID = value;
            }
            get
            {
                return _LoanDiscountDb.ID;
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
        public double Value
        {
            set
            {
                _LoanDiscountDb.Value = value;
            }
            get
            {
                return _LoanDiscountDb.Value;
            }
        }
        #endregion
        #region Private Methods
        public void Add()
        {
            _LoanDiscountDb.Loan = _LoanBiz.ID;
            _LoanDiscountDb.Statement = _StatementBiz.ID;
            _LoanDiscountDb.Add();
        }
        public void Edit()
        {
            _LoanDiscountDb.Loan = _LoanBiz.ID;
            _LoanDiscountDb.Statement = _StatementBiz.ID;
            _LoanDiscountDb.Edit();
        }
        public void Delete()
        {
            _LoanDiscountDb.Loan = _LoanBiz.ID;
            _LoanDiscountDb.Statement = _StatementBiz.ID;
            _LoanDiscountDb.Delete();
        }
        #endregion
        #region Public Methods

        #endregion
    }
}
