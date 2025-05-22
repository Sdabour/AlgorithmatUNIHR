using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.GL.GLDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationCostCenterBiz
    {
        #region Private Data
        ApplicantWorkerMotivationCostCenterDb _ApplicantCostCenterDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        CostCenterHRBiz _CostCenterHRBiz; 
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationCostCenterBiz()
        {
            _ApplicantCostCenterDb = new ApplicantWorkerMotivationCostCenterDb();
            _CostCenterHRBiz = new CostCenterHRBiz();
            //_ApplicantWorkerBiz = new ApplicantWorkerBiz();
        }
        public ApplicantWorkerMotivationCostCenterBiz(DataRow objDr)
        {
            _ApplicantCostCenterDb = new ApplicantWorkerMotivationCostCenterDb(objDr);
            _CostCenterHRBiz = new CostCenterHRBiz(objDr,true);
           // _ApplicantWorkerBiz = new ApplicantWorkerBiz();
        }
        public ApplicantWorkerMotivationCostCenterBiz(DataRow objDr, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            _ApplicantCostCenterDb = new ApplicantWorkerMotivationCostCenterDb(objDr);
            _CostCenterHRBiz = new CostCenterHRBiz(objDr, true);
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
        }
        public ApplicantWorkerMotivationCostCenterBiz(CostCenterHRBiz objCostCenterHRBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            _ApplicantCostCenterDb = new ApplicantWorkerMotivationCostCenterDb();
            _CostCenterHRBiz =  objCostCenterHRBiz;
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set
            {
                _ApplicantWorkerBiz = value;
            }
            get
            {
                if (_ApplicantWorkerBiz == null)
                    _ApplicantWorkerBiz = new ApplicantWorkerBiz();
                return _ApplicantWorkerBiz;
            }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set
            {
                _CostCenterHRBiz = value;
            }
            get
            {
                return _CostCenterHRBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
