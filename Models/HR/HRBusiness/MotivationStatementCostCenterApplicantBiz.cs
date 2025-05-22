using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;


namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementCostCenterApplicantBiz
    {
        #region Private Data
        MotivationStatementCostCenterApplicantDb _MotivationStatementCostCenterApplicantDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        #endregion
        #region Constructors
        public MotivationStatementCostCenterApplicantBiz()
        {
            _MotivationStatementCostCenterApplicantDb = new MotivationStatementCostCenterApplicantDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
        }
        public MotivationStatementCostCenterApplicantBiz(DataRow objDr)
        {
            _MotivationStatementCostCenterApplicantDb = new MotivationStatementCostCenterApplicantDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
            if (_ApplicantWorkerBiz.ID == 201)
            { 
            }
            _ApplicantWorkerBiz.VirualIsSpecialCaseChooseInMotivation = _MotivationStatementCostCenterApplicantDb.IsSpecialCase;
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatementCostCenterApplicantDb.MotivationStatement = value; } get { return _MotivationStatementCostCenterApplicantDb.MotivationStatement; } }
        public int CostCenter { set { _MotivationStatementCostCenterApplicantDb.CostCenter = value; } get { return _MotivationStatementCostCenterApplicantDb.CostCenter; } }
        public ApplicantWorkerBiz ApplicantWorkerBiz { set { _ApplicantWorkerBiz = value; } get { return _ApplicantWorkerBiz; } }
        public bool IsSpecialCase { set { _MotivationStatementCostCenterApplicantDb.IsSpecialCase = value; } get { return _MotivationStatementCostCenterApplicantDb.IsSpecialCase; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementCostCenterApplicantDb.Applicant = _ApplicantWorkerBiz.ID;
            _MotivationStatementCostCenterApplicantDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementCostCenterApplicantDb.Applicant = _ApplicantWorkerBiz.ID;
            _MotivationStatementCostCenterApplicantDb.Delete();
        }
        #endregion
    }
}
