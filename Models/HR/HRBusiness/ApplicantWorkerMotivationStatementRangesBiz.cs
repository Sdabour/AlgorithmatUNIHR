using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementRangesBiz
    {
        #region Private Data
        ApplicantWorkerManyStatementBiz _ManyStatementBiz;
        ApplicantWorkerMotivationStatementBiz _StatementBiz;
        MotivationStatementRangesBiz _RangesBiz; 
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementRangesBiz()
        {
            _ManyStatementBiz = new ApplicantWorkerManyStatementBiz();
            _RangesBiz = new MotivationStatementRangesBiz();
        }
        public ApplicantWorkerMotivationStatementRangesBiz(ApplicantWorkerManyStatementBiz objManyStatementBiz,
            MotivationStatementRangesBiz objRangesBiz)
        {
            _ManyStatementBiz = objManyStatementBiz;
            _RangesBiz = objRangesBiz;
        }
        public ApplicantWorkerMotivationStatementRangesBiz(ApplicantWorkerMotivationStatementBiz objStatementBiz,
            MotivationStatementRangesBiz objRangesBiz)
        {
            _StatementBiz = objStatementBiz;
            _RangesBiz = objRangesBiz;
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerManyStatementBiz ManyStatementBiz
        {
            set
            {
                _ManyStatementBiz = value;
            }
            get
            {
                return _ManyStatementBiz;
            }
        }
        public ApplicantWorkerMotivationStatementBiz StatementBiz
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
        public MotivationStatementRangesBiz RangesBiz
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
