using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementSalaryDetailsBiz
    {
        #region Private Data
        ApplicantWorkerStatementSalaryDetailsDb _StatementSalaryDetailsDb;
        ApplicantWorkerStatementBiz _ApplicantWorkerStatementBiz;
        DetailTypeBiz _DetailTypeBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementSalaryDetailsBiz()
        {
            _StatementSalaryDetailsDb = new ApplicantWorkerStatementSalaryDetailsDb();
            _ApplicantWorkerStatementBiz = new ApplicantWorkerStatementBiz();
            _DetailTypeBiz = new DetailTypeBiz();
        }
        public ApplicantWorkerStatementSalaryDetailsBiz(DataRow objDr)
        {
            _StatementSalaryDetailsDb = new ApplicantWorkerStatementSalaryDetailsDb(objDr);
            //_ApplicantWorkerStatementBiz = new ApplicantWorkerStatementBiz(objDr);
            _DetailTypeBiz = new DetailTypeBiz(objDr);
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerStatementBiz ApplicantWorkerStatementBiz
        {
            set
            {
                _ApplicantWorkerStatementBiz = value;
            }
            get
            {
                return _ApplicantWorkerStatementBiz;
            }
        }
        public DetailTypeBiz DetailTypeBiz
        {
            set
            {
                _DetailTypeBiz = value;
            }
            get
            {
                if (_DetailTypeBiz == null)
                    _DetailTypeBiz = new DetailTypeBiz();
                return _DetailTypeBiz;
            }
        }
        public double DetailValue
        {
            set
            {
                _StatementSalaryDetailsDb.DetailValue = value;
            }
            get
            {
                return _StatementSalaryDetailsDb.DetailValue;
            }
        }
        public double DetailRecomendedValue
        {
            set
            {
                _StatementSalaryDetailsDb.DetailRecomendedValue = value;
            }
            get
            {
                return _StatementSalaryDetailsDb.DetailRecomendedValue;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _StatementSalaryDetailsDb.OrginStatement = _ApplicantWorkerStatementBiz.ID;
            _StatementSalaryDetailsDb.DetailType = _DetailTypeBiz.ID;
            _StatementSalaryDetailsDb.Add();
        }        
        public void Delete()
        {
            _StatementSalaryDetailsDb.OrginStatement = _ApplicantWorkerStatementBiz.ID;            
            _StatementSalaryDetailsDb.Add();
        }
        #endregion
    }
}
