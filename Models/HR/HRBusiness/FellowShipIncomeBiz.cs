using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class FellowShipIncomeBiz
    {
        #region Private Data
        FellowShipIncomeDb _FellowShipIncomeDb;
        ApplicantWorkerBiz _ApplicantBiz;        
        FellowShipIncomeMainTypeBiz _FellowShipIncomeMainTypeBiz;
        FellowShipStatementBiz _StatementBiz;
        #endregion
        #region Constructors
        public FellowShipIncomeBiz()
        {
            _FellowShipIncomeDb = new FellowShipIncomeDb();
            _ApplicantBiz = new ApplicantWorkerBiz();
            _FellowShipIncomeMainTypeBiz = new FellowShipIncomeMainTypeBiz();
            _StatementBiz = new FellowShipStatementBiz();
        }
        public FellowShipIncomeBiz(DataRow objDr)
        {
            _FellowShipIncomeDb = new FellowShipIncomeDb(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
            _FellowShipIncomeMainTypeBiz = new FellowShipIncomeMainTypeBiz(objDr);
            _StatementBiz = new FellowShipStatementBiz();
        }
        public FellowShipIncomeBiz(DataRow objDr, FellowShipStatementBiz objFellowShipStatementBiz)
        {
            _FellowShipIncomeDb = new FellowShipIncomeDb(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
            _FellowShipIncomeMainTypeBiz = new FellowShipIncomeMainTypeBiz(objDr);            
            _StatementBiz = objFellowShipStatementBiz;
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _FellowShipIncomeDb.ID = value;
            }
            get
            {
                return _FellowShipIncomeDb.ID;
            }
        }
        public ApplicantWorkerBiz ApplicantBiz
        {
            set
            {
                _ApplicantBiz = value;
            }
            get
            {
                return _ApplicantBiz;
            }
        }
        public double Value
        {
            set
            {
                _FellowShipIncomeDb.Value = value;
            }
            get
            {
                return _FellowShipIncomeDb.Value;
            }
        }
        public string Desc
        {
            set
            {
                _FellowShipIncomeDb.Desc = value;
            }
            get
            {
                return _FellowShipIncomeDb.Desc;
            }
        }
        public DateTime Date
        {
            set
            {
                _FellowShipIncomeDb.Date = value;
            }
            get
            {
                return _FellowShipIncomeDb.Date;
            }
        }        
        public FellowShipIncomeMainTypeBiz FellowShipIncomeMainTypeBiz
        {
            set
            {
                _FellowShipIncomeMainTypeBiz = value;
            }
            get
            {
                return _FellowShipIncomeMainTypeBiz;
            }
        }
        public int Statement
        {
            set
            {
                _FellowShipIncomeDb.Statement = value;
            }
            get
            {
                return _FellowShipIncomeDb.Statement;
            }
        }
        public FellowShipStatementBiz StatementBiz
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
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _FellowShipIncomeDb.Applicant = _ApplicantBiz.ID;
            _FellowShipIncomeDb.FellowShipIncomeMainType = _FellowShipIncomeMainTypeBiz.ID;            
            _FellowShipIncomeDb.Add();
        }
        public void Edit()
        {
            _FellowShipIncomeDb.Applicant = _ApplicantBiz.ID;
            _FellowShipIncomeDb.FellowShipIncomeMainType = _FellowShipIncomeMainTypeBiz.ID;            
            _FellowShipIncomeDb.Edit();
        }
        public void Delete()
        {            
            _FellowShipIncomeDb.Delete();
        }
        #endregion
    }
}
