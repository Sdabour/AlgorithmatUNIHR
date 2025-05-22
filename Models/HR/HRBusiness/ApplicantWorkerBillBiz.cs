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
    public class ApplicantWorkerBillBiz
    {
        #region Private Data
        ApplicantWorkerBillDb _ApplicantWorkerBillDb;
        ApplicantWorkerServiceParticipationBiz _ServiceParticipationBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerBillBiz()
        {
            _ApplicantWorkerBillDb = new ApplicantWorkerBillDb();
            _ServiceParticipationBiz = new ApplicantWorkerServiceParticipationBiz();
        }
        public ApplicantWorkerBillBiz(DataRow objDr)
        {
            _ApplicantWorkerBillDb = new ApplicantWorkerBillDb(objDr);
            _ServiceParticipationBiz = new ApplicantWorkerServiceParticipationBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerBillDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerBillDb.ID;
            }
        }
        public ApplicantWorkerServiceParticipationBiz ServiceParticipationBiz
        {
            set
            {
                _ServiceParticipationBiz = value;
            }
            get
            {
                return _ServiceParticipationBiz;
            }
        }
        public DateTime BillDate
        {
            set
            {
                _ApplicantWorkerBillDb.BillDate = value;
            }
            get
            {
                return _ApplicantWorkerBillDb.BillDate;
            }
        }
        public float BillValue
        {
            set
            {
                _ApplicantWorkerBillDb.BillValue = value;
            }
            get
            {
                return _ApplicantWorkerBillDb.BillValue;
            }
        }
        public int BillStatement
        {
            set
            {
                _ApplicantWorkerBillDb.BillStatement = value;
            }
            get
            {
                return _ApplicantWorkerBillDb.BillStatement;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerBillDb.ApplicantParticipation = ServiceParticipationBiz.ID;
            _ApplicantWorkerBillDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerBillDb.ApplicantParticipation = ServiceParticipationBiz.ID;
            _ApplicantWorkerBillDb.Edit();
        }
        public void Delete()
        {
            _ApplicantWorkerBillDb.Delete();
        }
        #endregion
    }
}
