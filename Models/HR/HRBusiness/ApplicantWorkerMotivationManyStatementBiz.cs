using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationManyStatementBiz
    {
        #region Private Data
        ApplicantWorkerMotivationStatementCol _MotivationStatementCol;
        double _MotivationValue = -1;
        double _MotivationValueBankValue = -1;
        double _MotivationValueCofferValue = -1;
        double _BaseSalary = -1;
        double _TotalSalaryValue = -1;
        string _AccountBankNo="-1";
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationManyStatementBiz()
        {
        }
        #endregion
        #region Public Properties
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
        public double MotivationValue
        {
            get
            {
                if (_MotivationValue == -1)
                {
                    _MotivationValue = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        _MotivationValue += objBiz.MotivationValue;
                    }
                }
                return _MotivationValue;
            }
        }
        public string AccountBankNo
        {
            get
            {
                if (_AccountBankNo == "-1")
                {
                    _AccountBankNo = "";
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        _AccountBankNo = objBiz.AccountBankNo;
                    }
                }
                return _AccountBankNo;
            }
        }
        public double MotivationValueBankValue
        {
            get
            {
                if (_MotivationValueBankValue == -1)
                {
                    _MotivationValueBankValue = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                            _MotivationValueBankValue += objBiz.MotivationValue;
                    }
                }
                return _MotivationValueBankValue;
            }
        }
        public double MotivationValueCofferValue
        {
            get
            {
                if (_MotivationValueCofferValue == -1)
                {
                    _MotivationValueCofferValue = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                            _MotivationValueCofferValue += objBiz.MotivationValue;
                    }
                }
                return _MotivationValueCofferValue;
            }
        }
        public double BaseSalary
        {
            get
            {
                if (_BaseSalary == -1)
                {
                    _BaseSalary = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        _BaseSalary = objBiz.BaseSalaryValue;
                    }
                }
                return _BaseSalary;
            }
        }
        public double TotalSalaryValue
        {
            get
            {
                if (_TotalSalaryValue == -1)
                {
                    _TotalSalaryValue = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
                    {
                        _TotalSalaryValue = objBiz.TotalSalaryValue;
                    }
                }
                return _TotalSalaryValue;
            }
        }
        bool _MotivationStopped;
        public bool MotivationStopped
        {
            set => _MotivationStopped = value;
            get => _MotivationStopped;
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void GetValues()
        {
            _MotivationValue = 0;
            _MotivationValueBankValue = 0;
            _MotivationValueCofferValue = 0;
            _BaseSalary = 0;
            _TotalSalaryValue = 0;
            _AccountBankNo = "";
            foreach (ApplicantWorkerMotivationStatementBiz objBiz in MotivationStatementCol)
            {
                _MotivationValue += objBiz.MotivationValue;
                _AccountBankNo = objBiz.AccountBankNo;
                if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                    _MotivationValueBankValue += objBiz.MotivationValue;
                else
                    _MotivationValueCofferValue += objBiz.MotivationValue;
                _BaseSalary = objBiz.BaseSalaryValue;
                _TotalSalaryValue = objBiz.TotalSalaryValue;
            }
        }
        #endregion
    }
}
