using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerManyStatementBiz
    {
        #region Private Data
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        JobNatureTypeBiz _JobNatureTypeBiz;
        double _BaseSalary;
        double _IncreaseValue;
        double _TelSalaryDetail;
        double _TransferSalaryDetail;
        double _FeedingSalaryDetail;
        double _VarioustSalaryDetail;
        int _StatmentCount;
        double _AbsenceValue;
        double _DelayValue;
        double _PenaltyValue;
        double _FellowshipValue;

        public double FellowshipValue
        {
            get { return _FellowshipValue; }
            set { _FellowshipValue = value; }
        }
        bool _MotivationStopped;
        public bool MotivationStopped
        {
            set => _MotivationStopped = value;
            get => _MotivationStopped;
        }
        MotivationStatementBiz _VirtualMotivationStatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerManyStatementBiz()
        {
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _CostCenterHRBiz = new CostCenterHRBiz();
            _VirtualMotivationStatementBiz = new MotivationStatementBiz();
        }
        public ApplicantWorkerManyStatementBiz(DataRow objDr, MotivationStatementBiz objMotivationStatementBiz)
        {
            //if (objDr["Applicant"].ToString() != "")
            //    _ApplicantWorkerBiz = new ApplicantWorkerBiz(int.Parse(objDr["Applicant"].ToString()));
            _MotivationStopped = false;
            if (objDr.Table.Columns["MotivationStopped"] != null && objDr["MotivationStopped"].ToString() != "")
                _MotivationStopped = objDr["MotivationStopped"].ToString() == "1";

            if (objDr["StatementCount"].ToString() != "")
                _StatmentCount = int.Parse(objDr["StatementCount"].ToString());

            if (objDr["SumBaseSalaryVal"].ToString() != "")
                _BaseSalary = double.Parse(objDr["SumBaseSalaryVal"].ToString());
            if (objDr["SumTransferVal"].ToString() != "")
                _TransferSalaryDetail = double.Parse(objDr["SumTransferVal"].ToString());
            if (objDr["SumTelephoneVal"].ToString() != "")
                _TelSalaryDetail = double.Parse(objDr["SumTelephoneVal"].ToString());
            if (objDr["SumFeedingVal"].ToString() != "")
                _FeedingSalaryDetail = double.Parse(objDr["SumFeedingVal"].ToString());
            if (objDr["SumIncreaseVal"].ToString() != "")
                _IncreaseValue = double.Parse(objDr["SumIncreaseVal"].ToString());

            if (objDr["SumAbsenceCount"].ToString() != "")
                _AbsenceValue = double.Parse(objDr["SumAbsenceCount"].ToString());

            if (objDr["SumDelayCount"].ToString() != "")
                _DelayValue = double.Parse(objDr["SumDelayCount"].ToString());

            if (objDr["SumPenaltyDiscount"].ToString() != "")
                _PenaltyValue = double.Parse(objDr["SumPenaltyDiscount"].ToString());

            if (objDr["Applicant"].ToString() != "")
            {
                DataRow[] ArrDr = ApplicantWorkerStatementDb.CachApplicantTable.Select("ApplicantID=" + objDr["Applicant"]);
                if (ArrDr.Length != 0)
                    _ApplicantWorkerBiz = new ApplicantWorkerBiz(ArrDr[0]);
                else
                    _ApplicantWorkerBiz = new ApplicantWorkerBiz();                
            }
            else
                _ApplicantWorkerBiz = new ApplicantWorkerBiz();

            if (objDr["MotivationCostCenter"].ToString() != "")
            {
                DataRow[] ArrDr = ApplicantWorkerStatementDb.CachCostCenterTable.Select("CostCenterID=" + objDr["MotivationCostCenter"]);
                if (ArrDr.Length != 0)
                    _CostCenterHRBiz = new CostCenterHRBiz(ArrDr[0], objMotivationStatementBiz);
                else
                    _CostCenterHRBiz = new CostCenterHRBiz();
            }
            else
                _CostCenterHRBiz = new CostCenterHRBiz();

            if (objDr["JobNature"].ToString() != "")
            {
                DataRow[] ArrDr = ApplicantWorkerStatementDb.CachJobNatureTypeTable.Select("JobNatureID=" + objDr["JobNature"]);
                if (ArrDr.Length != 0)
                    _JobNatureTypeBiz = new JobNatureTypeBiz(ArrDr[0]);
                else
                    _JobNatureTypeBiz = new JobNatureTypeBiz();
            }
            else
                _JobNatureTypeBiz = new JobNatureTypeBiz();
            if (objDr["FellowshipValue"].ToString() != "")
                double.TryParse(objDr["FellowshipValue"].ToString(), out _FellowshipValue);

            _VirtualMotivationStatementBiz = new MotivationStatementBiz();

        }

        public ApplicantWorkerManyStatementBiz(ApplicantWorkerMotivationStatementBiz objBiz)
        {
            //if (objDr["Applicant"].ToString() != "")
            //    _ApplicantWorkerBiz = new ApplicantWorkerBiz(int.Parse(objDr["Applicant"].ToString()));
          
                _StatmentCount =objBiz.StatementCount;

           
                _BaseSalary = objBiz.SumBaseSalaryVal;
           
                _TransferSalaryDetail = objBiz.SumTransferVal ;

                _TelSalaryDetail = objBiz.SumTelephoneVal;
             
                _FeedingSalaryDetail = objBiz.SumFeedingVal;
          
                _IncreaseValue =objBiz.SumIncreaseVal;

            
                _AbsenceValue = objBiz.SumAbsenceCount;

            
                _DelayValue = objBiz.SumDelayCount;

          
                _PenaltyValue =objBiz.SumPenaltyDiscount;
                _ApplicantWorkerBiz = objBiz.ApplicantWorkerBiz;
            

           _CostCenterHRBiz = objBiz.CostCenterHRBiz;


           _JobNatureTypeBiz = objBiz.JobNatureTypeBiz;
           _FellowshipValue = objBiz.FellowshipFund + objBiz.FellowshipFundBonus;
            _VirtualMotivationStatementBiz = new MotivationStatementBiz();

        } 
        #endregion
        #region Public Properties
        public MotivationStatementBiz VirtualMotivationStatementBiz
        {
            set
            {
                _VirtualMotivationStatementBiz = value;
            }
            get
            {
                return _VirtualMotivationStatementBiz;
            }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set { _ApplicantWorkerBiz = value; }
            get { return _ApplicantWorkerBiz; }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set { _CostCenterHRBiz = value; }
            get { return _CostCenterHRBiz; }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set { _JobNatureTypeBiz = value; }
            get { return _JobNatureTypeBiz; }
        }
        public double BaseSalary
        {
            set { _BaseSalary = value; }
            get { return _BaseSalary; }
        }
        public double IncreaseValue
        {
            set { _IncreaseValue = value; }
            get { return _IncreaseValue; }
        }
        public double TelSalaryDetail
        {
            set { _TelSalaryDetail = value; }
            get { return _TelSalaryDetail; }
        }
        public double TransferSalaryDetail
        {
            set { _TransferSalaryDetail = value; }
            get { return _TransferSalaryDetail; }
        }
        public double FeedingSalaryDetail
        {
            set { _FeedingSalaryDetail = value; }
            get { return _FeedingSalaryDetail; }
        }
        public double VarioustSalaryDetail
        {
            set { _VarioustSalaryDetail = value; }
            get { return _VarioustSalaryDetail; }
        }
        public int StatmentCount
        {
            set { _StatmentCount = value; }
            get { return _StatmentCount; }
        }
        public double AbsenceValue
        {
            set { _AbsenceValue = value; }
            get { return _AbsenceValue; }
        }
        public double DelayValue
        {
            set { _DelayValue = value; }
            get { return _DelayValue; }
        }
        public double PenaltyValue
        {
            set { _PenaltyValue = value; }
            get { return _PenaltyValue; }
        }
        public double TotalSalary
        {
            get { return BaseSalary + IncreaseValue + TelSalaryDetail + TransferSalaryDetail + FeedingSalaryDetail; }
        }
        public bool Stopped { set; get; }
        ApplicantWorkerEstimationStatementCol _EstimationStatementCol;
        public ApplicantWorkerEstimationStatementCol EstimationStatementCol
        {
            set => _EstimationStatementCol = value;
            get
            {
                if(_EstimationStatementCol==null)
                {
                    _EstimationStatementCol = new ApplicantWorkerEstimationStatementCol(true);

                }
                return _EstimationStatementCol;
            }
        }
        ApplicantWorkerMotivationStatementCol _RelatedStatementCol;
        public ApplicantWorkerMotivationStatementCol RelatedStatementCol
        {
            set => _RelatedStatementCol = value;
            get
            {
                if (_RelatedStatementCol == null)
                    _RelatedStatementCol = new ApplicantWorkerMotivationStatementCol(true);
                return _RelatedStatementCol;
            }
        }
        ApplicantWorkerMotivationStatementBiz _StatementBiz;
        public ApplicantWorkerMotivationStatementBiz StatementBiz
        { set => _StatementBiz = value;
            get
            {
                if (_StatementBiz == null)
                    _StatementBiz = new ApplicantWorkerMotivationStatementBiz();
                return _StatementBiz;
            }
        }
        public double SavedValue { set; get; }
        public bool Reviewed { set; get; }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
