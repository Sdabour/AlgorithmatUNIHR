using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class FellowShipPaymentBiz
    {
        #region Private Data
        FellowShipPaymentDb _FellowShipPaymentDb;
        ApplicantWorkerBiz _ApplicantBiz;
        FellowShipPaymentTypeBiz _FellowShipPaymentTypeBiz;
        FellowShipPaymentMainTypeBiz _FellowShipPaymentMainTypeBiz;
        FellowShipStatementBiz _StatementBiz;
        #endregion
        #region Constructors
        public FellowShipPaymentBiz()
        {
            _FellowShipPaymentDb = new FellowShipPaymentDb();
            _ApplicantBiz = new ApplicantWorkerBiz();
            _FellowShipPaymentMainTypeBiz = new FellowShipPaymentMainTypeBiz();
            _FellowShipPaymentTypeBiz = new FellowShipPaymentTypeBiz();
            _StatementBiz = new FellowShipStatementBiz();
        }
        public FellowShipPaymentBiz(DataRow objDr)
        {
            _FellowShipPaymentDb = new FellowShipPaymentDb(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
            _FellowShipPaymentMainTypeBiz = new FellowShipPaymentMainTypeBiz(objDr);
            _FellowShipPaymentTypeBiz = new FellowShipPaymentTypeBiz(objDr);
            _StatementBiz = new FellowShipStatementBiz();
        }
        public FellowShipPaymentBiz(DataRow objDr, FellowShipStatementBiz objFellowShipStatementBiz)
        {
            _FellowShipPaymentDb = new FellowShipPaymentDb(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
            _FellowShipPaymentMainTypeBiz = new FellowShipPaymentMainTypeBiz(objDr);
            _FellowShipPaymentTypeBiz = new FellowShipPaymentTypeBiz(objDr);
            _StatementBiz = objFellowShipStatementBiz;
        }
      
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _FellowShipPaymentDb.ID = value;
            }
            get
            {
                return _FellowShipPaymentDb.ID;
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
                _FellowShipPaymentDb.Value = value;
            }
            get
            {
                return _FellowShipPaymentDb.Value;
            }
        }
        public string Desc
        {
            set
            {
                _FellowShipPaymentDb.Desc = value;
            }
            get
            {
                return _FellowShipPaymentDb.Desc;
            }
        }
        public DateTime Date
        {
            set
            {
                _FellowShipPaymentDb.Date = value;
            }
            get
            {
                return _FellowShipPaymentDb.Date;
            }
        }
        public DateTime RequestDate
        {
            set
            {
                _FellowShipPaymentDb.RequestDate = value;
            }
            get
            {
                return _FellowShipPaymentDb.RequestDate;
            }
        }
        public FellowShipPaymentTypeBiz FellowShipPaymentTypeBiz
        {
            set
            {
                _FellowShipPaymentTypeBiz = value;
            }
            get
            {
                return _FellowShipPaymentTypeBiz;
            }
        }
        public FellowShipPaymentMainTypeBiz FellowShipPaymentMainTypeBiz
        {
            set
            {
                _FellowShipPaymentMainTypeBiz = value;
            }
            get
            {
                return _FellowShipPaymentMainTypeBiz;
            }
        }
        public string IDBuffer
        {
            set
            {
                _FellowShipPaymentDb.IDBuffer = value;
            }
            get
            {
                return _FellowShipPaymentDb.IDBuffer;
            }
        }
        public string Remarks
        {
            set
            {
                _FellowShipPaymentDb.Remarks = value;
            }
            get
            {
                return _FellowShipPaymentDb.Remarks + " , "+"الرقم فى الكشف "+" : "+_FellowShipPaymentDb.IDBuffer;
            }
        }
        public int Statement
        {
            set
            {
                _FellowShipPaymentDb.Statement = value;
            }
            get
            {
                return _FellowShipPaymentDb.Statement;
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
            _FellowShipPaymentDb.Applicant = _ApplicantBiz.ID;
            _FellowShipPaymentDb.FellowShipPaymentMainType = _FellowShipPaymentMainTypeBiz.ID;
            _FellowShipPaymentDb.FellowShipPaymentType = _FellowShipPaymentTypeBiz.ID;
            _FellowShipPaymentDb.Add();
        }
        public void Edit()
        {
            _FellowShipPaymentDb.Applicant = _ApplicantBiz.ID;
            _FellowShipPaymentDb.FellowShipPaymentMainType = _FellowShipPaymentMainTypeBiz.ID;
            _FellowShipPaymentDb.FellowShipPaymentType = _FellowShipPaymentTypeBiz.ID;
            _FellowShipPaymentDb.Edit();
        }
        public void Delete()
        {            
            _FellowShipPaymentDb.Delete();
        }
        public void EditStatementAndDate()
        {
            _FellowShipPaymentDb.EditStatementAndDate(this.ID, this.Statement, this.Date);
        }
        #endregion
    }
}
