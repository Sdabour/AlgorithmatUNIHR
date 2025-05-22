using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerServiceParticipationBiz
    {
        #region Private Data
        ApplicantWorkerServiceParticipationDb _ServiceParticipationDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        //ServiceBiz _ServiceBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerServiceParticipationBiz()
        {
            _ServiceParticipationDb = new ApplicantWorkerServiceParticipationDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            //_ServiceBiz = new ServiceBiz();
        }

        public ApplicantWorkerServiceParticipationBiz(DataRow objDr)
        {
            _ServiceParticipationDb = new ApplicantWorkerServiceParticipationDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
           // _ServiceBiz = new ServiceBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ServiceParticipationDb.ID = value;
            }
            get
            {
                return _ServiceParticipationDb.ID;
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
        //public ServiceBiz ServiceBiz
        //{
        //    set
        //    {
        //        _ServiceBiz = value;
        //    }
        //    get
        //    {
        //        return _ServiceBiz;
        //    }
        //}
        public DateTime StartDate
        {
            set
            {
                _ServiceParticipationDb.StartDate = value;
            }
            get
            {
                return _ServiceParticipationDb.StartDate;
            }
        }
        public int PayPeriod
        {
            set
            {
                _ServiceParticipationDb.PayPeriod = value;
            }
            get
            {
                return _ServiceParticipationDb.PayPeriod;
            }
        }
        public float Value
        {
            set
            {
                _ServiceParticipationDb.Value = value;
            }
            get
            {
                return _ServiceParticipationDb.Value;
            }
        }
        public string Desc
        {
            set
            {
                _ServiceParticipationDb.Desc = value;
            }
            get
            {
                return _ServiceParticipationDb.Desc;
            }
        }
        public string Number
        {
            set
            {
                _ServiceParticipationDb.Number = value;
            }
            get
            {
                return _ServiceParticipationDb.Number;
            }
        }
        public bool IsStop
        {
            set
            {
                _ServiceParticipationDb.IsStop = value;
            }
            get
            {
                return _ServiceParticipationDb.IsStop;
            }
        }
        public string PayPeriodStr
        {
            get
            {
                string Returned = "";
                if (PayPeriod == 0)
                    Returned = "سنوى";
                else if (PayPeriod == 1)
                    Returned = "شهرى";
                else if (PayPeriod == 2)
                    Returned = "اسبوعى";

                return Returned;
            }
        }
        public string IsStopStr
        {
            get
            {
                string Returned = "";
                if (IsStop == false)
                    Returned = "يعمل";
                else if (IsStop == true)
                    Returned = "موقوف";                
                return Returned;
            }
        }
        #endregion  
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ServiceParticipationDb.Applicant = _ApplicantWorkerBiz.ID;
           // _ServiceParticipationDb.Service = _ServiceBiz.ID;
            _ServiceParticipationDb.Add();
        }
        public void Edit()
        {
            _ServiceParticipationDb.Applicant = _ApplicantWorkerBiz.ID;
            //_ServiceParticipationDb.Service = _ServiceBiz.ID;
            _ServiceParticipationDb.Edit();
        }
        public void Delete()
        {            
            _ServiceParticipationDb.Delete();
        }
        #endregion
    }
}
