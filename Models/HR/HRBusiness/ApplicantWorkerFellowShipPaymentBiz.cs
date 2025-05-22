using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerFellowShipPaymentBiz
    {
        #region Private Data
        ApplicantWorkerFellowShipPaymentDb _FellowShipPaymentDb;
        ApplicantWorkerBiz _ApplicantBiz;
        FellowShipPaymentTypeBiz _FellowShipPaymentTypeBiz;
        FellowShipPaymentMainTypeBiz _FellowShipPaymentMainTypeBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerFellowShipPaymentBiz()
        {
            _FellowShipPaymentDb = new ApplicantWorkerFellowShipPaymentDb();
            _ApplicantBiz = new ApplicantWorkerBiz();
            _FellowShipPaymentMainTypeBiz = new FellowShipPaymentMainTypeBiz();
            _FellowShipPaymentTypeBiz = new FellowShipPaymentTypeBiz();
        }
        public ApplicantWorkerFellowShipPaymentBiz(DataRow objDr)
        {
            _FellowShipPaymentDb = new ApplicantWorkerFellowShipPaymentDb(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
            _FellowShipPaymentMainTypeBiz = new FellowShipPaymentMainTypeBiz(objDr);
            _FellowShipPaymentTypeBiz = new FellowShipPaymentTypeBiz(objDr);
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
        #endregion
    }
}
