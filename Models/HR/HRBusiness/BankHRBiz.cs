using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class BankHRBiz 
    {
        #region Private Data   
        BankBiz _BankBiz;
        ApplicantWorkerStatementCol _StatementCol;
        ApplicantWorkerMotivationStatementCol _MotivationStatementCol;
        #endregion
        #region Constructors
        public BankHRBiz() 
        {
           
        }
        
        #endregion
        #region Public Properties
        public BankBiz BankBiz
        {
            set
            {
                _BankBiz = value;
            }
            get
            {
                if (_BankBiz == null)
                    _BankBiz = new BankBiz();
                return _BankBiz;
            }
        }
        public ApplicantWorkerStatementCol StatementCol
        {
            set
            {
                _StatementCol = value;
            }
            get
            {
                if (_StatementCol == null)
                    _StatementCol = new ApplicantWorkerStatementCol(true);
                return _StatementCol;
            }
        }
        public ApplicantWorkerMotivationStatementCol MotivationStatementCol
        {
            set
            {
                _MotivationStatementCol = value;
            }
            get 
            {
                if (_MotivationStatementCol == null)
                    _MotivationStatementCol = new ApplicantWorkerMotivationStatementCol(true);
                return _MotivationStatementCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
      
        #endregion
    }
}
