using System;
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
    public class ApplicantWorkerServiceParticipationCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerServiceParticipationCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerServiceParticipationCol()
        {
            ApplicantWorkerServiceParticipationDb _ServiceParticipationDb = new ApplicantWorkerServiceParticipationDb();
            DataTable dtTemp = _ServiceParticipationDb.Search();
            ApplicantWorkerServiceParticipationBiz objBiz;

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerServiceParticipationBiz(DR);
                this.Add(objBiz);
            }

        }
      
        public ApplicantWorkerServiceParticipationCol(string strNumber, byte byIsStop)
        {
            ApplicantWorkerServiceParticipationDb _ServiceParticipationDb = new ApplicantWorkerServiceParticipationDb();
            _ServiceParticipationDb.NumberSearch = strNumber;
            _ServiceParticipationDb.IsStopSearch = (int)byIsStop;
            DataTable dtTemp = _ServiceParticipationDb.Search();
            ApplicantWorkerServiceParticipationBiz objBiz;

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerServiceParticipationBiz(DR);
                this.Add(objBiz);
            }

        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerServiceParticipationBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerServiceParticipationBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Methods
        

        public virtual void Add(ApplicantWorkerServiceParticipationBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerServiceParticipation");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("ParticipationID"), new DataColumn("ParticipationApplicant"), 
                new DataColumn("ParticipationService"),new DataColumn("ParticipationStartDate"),new DataColumn("ParticipationPayPeriod"),
                new DataColumn("ParticipationValue"),new DataColumn("ParticipationDesc"),new DataColumn("IsStop"),new DataColumn("ParticipationNumber")});
            DataRow objDr;
            foreach (ApplicantWorkerServiceParticipationBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["ParticipationID"] = objBiz.ID;
                objDr["ParticipationApplicant"] = objBiz.ApplicantWorkerBiz.ID;
                //objDr["ParticipationService"] = objBiz.ServiceBiz.ID;
                objDr["ParticipationStartDate"] = objBiz.StartDate;
                objDr["ParticipationPayPeriod"] = objBiz.PayPeriod;
                objDr["ParticipationValue"] = objBiz.Value;
                objDr["ParticipationDesc"] = objBiz.Desc;
                objDr["ParticipationNumber"] = objBiz.Number;
                objDr["IsStop"] = objBiz.IsStop;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        
        #endregion
    }
}
