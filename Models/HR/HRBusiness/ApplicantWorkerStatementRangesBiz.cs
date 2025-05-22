using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementRangesBiz
    {
        #region Private Data
         ApplicantWorkerStatementBiz _StatementBiz;
        GlobalStatementRangesBiz _RangesBiz; 
        #endregion
        #region Constructors
        public ApplicantWorkerStatementRangesBiz()
        {
            _StatementBiz = new ApplicantWorkerStatementBiz();
            _RangesBiz = new GlobalStatementRangesBiz();
        }
        public ApplicantWorkerStatementRangesBiz(ApplicantWorkerStatementBiz objStatementBiz,
            GlobalStatementRangesBiz objRangesBiz)
        {
            _StatementBiz = objStatementBiz;
            _RangesBiz = objRangesBiz;
        }
        #endregion
        #region Public Properties
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
        public GlobalStatementRangesBiz RangesBiz
        {
            set
            {
                _RangesBiz = value;
            }
            get
            {
                return _RangesBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
