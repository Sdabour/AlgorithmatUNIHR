using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerPayBackBiz
    {
        #region Private Data
        ApplicantWorkerPayBackDb _PayBackDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        GlobalStatementBiz _StatementBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerPayBackBiz()
        {
            _PayBackDb = new ApplicantWorkerPayBackDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _StatementBiz = new GlobalStatementBiz();
        }
        public ApplicantWorkerPayBackBiz(DataRow objDr)
        {
            _PayBackDb = new ApplicantWorkerPayBackDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
            _StatementBiz = new GlobalStatementBiz(objDr);
        }
        public ApplicantWorkerPayBackBiz(ApplicantWorkerBiz objApplicantWorkerBiz, GlobalStatementBiz objGlobalStatementBiz)
        {
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
            _StatementBiz = objGlobalStatementBiz;
            _PayBackDb = new ApplicantWorkerPayBackDb(objApplicantWorkerBiz.ID, objGlobalStatementBiz.ID);
        }
        #endregion
        #region Public Properties
        public int PayBackID
        {
            set
            {
                _PayBackDb.PayBackID = value;
            }
            get
            {
                return _PayBackDb.PayBackID;
            }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set
            {
                _ApplicantWorkerBiz = value;
            }
            get
            {
                return _ApplicantWorkerBiz;
            }
        }
        public float Value
        {
            set
            {
                _PayBackDb.Value = value;
            }
            get
            {
                return _PayBackDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _PayBackDb.Date = value;
            }
            get
            {
                return _PayBackDb.Date;
            }
        }
        public string Desc
        {
            set
            {
                _PayBackDb.Desc = value;
            }
            get
            {
                return _PayBackDb.Desc;
            }
        }
        public GlobalStatementBiz StatementBiz
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
            _PayBackDb.Applicant = _ApplicantWorkerBiz.ID;
            _PayBackDb.Statement = _StatementBiz.ID;
            _PayBackDb.Add();
        }
        public void Edit()
        {
            _PayBackDb.Applicant = _ApplicantWorkerBiz.ID;
            //if (_StatementBiz != null)
            _PayBackDb.Statement = _StatementBiz.ID;
            _PayBackDb.Edit();
        }
        public void Delete()
        {           
            _PayBackDb.Delete();
        }
        #endregion
    }
}
