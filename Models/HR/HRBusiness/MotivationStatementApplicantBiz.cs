using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementApplicantBiz
    {
        #region Private Data
        MotivationStatementApplicantDb _MotivationStatementApplicantDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        #endregion
        #region Constructors
        public MotivationStatementApplicantBiz()
        {
            _MotivationStatementApplicantDb = new MotivationStatementApplicantDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
        }
        public MotivationStatementApplicantBiz(DataRow objDr)
        {
            _MotivationStatementApplicantDb = new MotivationStatementApplicantDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatementApplicantDb.MotivationStatement = value; } get { return _MotivationStatementApplicantDb.MotivationStatement; } }
        public ApplicantWorkerBiz ApplicantWorkerBiz { set { _ApplicantWorkerBiz = value; } get { return _ApplicantWorkerBiz; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementApplicantDb.Applicant = _ApplicantWorkerBiz.ID;
            _MotivationStatementApplicantDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementApplicantDb.Applicant = _ApplicantWorkerBiz.ID;
            _MotivationStatementApplicantDb.Delete();
        }
        #endregion
    }
}
