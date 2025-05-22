using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationManyStatementCol : CollectionBase
    {
        #region Private Data
        double _MotivationValue=-1;
        double _MotivationValueBankValue = -1;
        double _MotivationValueCofferValue = -1;
        double _BaseSalary = -1;
        double _TotalSalaryValue = -1;
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationManyStatementCol(bool blEmpty)
        {
        }
        #endregion
        #region Public Properties        
        public double MotivationValue
        {
            get
            {
                if (_MotivationValue == -1)
                {
                    _MotivationValue = 0;
                    foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
                    {
                        foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                        {                          
                                _MotivationValue += objBiz.MotivationValue;
                        }
                    }
                }
                return _MotivationValueBankValue;
            }
        }
        public double MotivationValueBankValue
        {
            get
            {
                if (_MotivationValueBankValue == -1)
                {
                    _MotivationValueBankValue = 0;
                    foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
                    {
                        foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                        {
                            if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                                _MotivationValueBankValue += objBiz.MotivationValue;
                        }
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
                    foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
                    {
                        foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                        {
                            if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                                _MotivationValueCofferValue += objBiz.MotivationValue;
                        }
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
                    foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
                    {
                        foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                        {
                            _BaseSalary += objBiz.BaseSalaryValue;
                        }
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
                    foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
                    {
                        foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                        {
                            _TotalSalaryValue += objBiz.TotalSalaryValue;
                        }
                    }
                }
                return _TotalSalaryValue;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerMotivationManyStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationManyStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerMotivationManyStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Public Methods
        public void GetValues()
        {
            _MotivationValue = 0;
            _MotivationValueBankValue = 0;
            _MotivationValueCofferValue = 0;
            _BaseSalary = 0;
            _TotalSalaryValue = 0;
            foreach (ApplicantWorkerMotivationManyStatementBiz objManyStatementBiz in this)
            {
                foreach (ApplicantWorkerMotivationStatementBiz objBiz in objManyStatementBiz.MotivationStatementCol)
                {

                    _MotivationValue += objBiz.MotivationValue;
                    
                    if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                        _MotivationValueBankValue += objBiz.MotivationValue;
                    else
                        _MotivationValueCofferValue += objBiz.MotivationValue;
                    _BaseSalary += objBiz.BaseSalaryValue;
                    _TotalSalaryValue += objBiz.TotalSalaryValue;
                }
            }
        }
        #endregion
    }
}
