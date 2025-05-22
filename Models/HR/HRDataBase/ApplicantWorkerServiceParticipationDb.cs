using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerServiceParticipationDb
    {
        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected int _Service;
        protected DateTime _StartDate;
        protected int _PayPeriod;
        protected float _Value;
        protected string _Desc;
        protected string _Number;
        protected bool _IsStop;
        int _IsStopSearch;
         string _NumberSearch;
        #endregion
        #region Constructors
        public ApplicantWorkerServiceParticipationDb()
        {
        }
        public ApplicantWorkerServiceParticipationDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        public int Service
        {
            set
            {
                _Service = value;
            }
            get
            {
                return _Service;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public int PayPeriod
        {
            set
            {
                _PayPeriod = value;
            }
            get
            {
                return _PayPeriod;
            }
        }
        public float Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        public string Number
        {
            set
            {
                _Number = value;
            }
            get
            {
                return _Number;
            }
        }
        public bool IsStop
        {
            set
            {
                _IsStop = value;
            }
            get
            {
                return _IsStop;
            }
        }
        public int IsStopSearch
        {
            set
            {
                _IsStopSearch = value;
            }
        }
        public string NumberSearch
        {
            set
            {
                _NumberSearch = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerServiceParticipation.ParticipationID, HRApplicantWorkerServiceParticipation.ParticipationApplicant,HRApplicantWorkerServiceParticipation.IsStop, " +
                                  " HRApplicantWorkerServiceParticipation.ParticipationService, HRApplicantWorkerServiceParticipation.ParticipationStartDate, "+
                                  " HRApplicantWorkerServiceParticipation.ParticipationPayPeriod, HRApplicantWorkerServiceParticipation.ParticipationValue,HRApplicantWorkerServiceParticipation.ParticipationDesc,HRApplicantWorkerServiceParticipation.ParticipationNumber," +
                                  " ApplicantWorkerTable.*,ServiceTable.* " +
                                  " FROM         HRApplicantWorkerServiceParticipation "+
                                  " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable ON HRApplicantWorkerServiceParticipation.ParticipationApplicant=ApplicantWorkerTable.ApplicantID " +
                                  " Left Outer Join (" + ServiceDb.SearchStr + ") as ServiceTable ON HRApplicantWorkerServiceParticipation.ParticipationService=ServiceTable.ServiceID ";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                int intIsStop = _IsStop ? 1:0;
                double dlStartDate = _StartDate.ToOADate() - 2;
                string strReturn = " INSERT INTO HRApplicantWorkerServiceParticipation"+
                                   " (ParticipationApplicant, ParticipationService, ParticipationStartDate,"+
                                   " ParticipationPayPeriod, ParticipationValue,ParticipationDesc,IsStop,ParticipationNumber," +
                                   " UsrIns, TimIns)"+
                                   " VALUES     "+
                                   " (" + _Applicant + "," + _Service + "," + dlStartDate + "," +
                                   " " + _PayPeriod +"," + _Value +",'"+ _Desc +"',"+ intIsStop +",'"+ _Number +"'," +
                                   " " + SysData.CurrentUser.ID +",GetDate())";
                return strReturn;
            }

        }
        public string EditStr
        {
            get
            {
                double dlStartDate = _StartDate.ToOADate() - 2;
                int intIsStop = _IsStop ? 1 : 0;
                string strReturn = "  UPDATE    HRApplicantWorkerServiceParticipation"+
                                   "   SET ParticipationApplicant =" + _Applicant + "" +
                                   " , ParticipationService =" + _Service + "" +
                                   " , ParticipationStartDate =" + dlStartDate + "" +
                                   " , ParticipationPayPeriod =" + _PayPeriod + "" +
                                   " , ParticipationValue =" + _Value + "" +
                                   " , ParticipationDesc ='" + _Desc + "'" +
                                   " , ParticipationNumber ='" + _Number + "'" +
                                   " , IsStop =" + intIsStop + "" +
                                   " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " WHERE     (ParticipationID = "+ _ID +")";
                return strReturn;
            }

        }
        public string DeleteStr
        {
            get
            {

                string strReturn = "DELETE FROM HRApplicantWorkerServiceParticipation WHERE     (ParticipationID = " + _ID + ")";
                return strReturn;
            }

        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ParticipationID"].ToString());
            _Applicant = int.Parse(objDr["ParticipationApplicant"].ToString());
            _Service = int.Parse(objDr["ParticipationService"].ToString());
            _StartDate = DateTime.Parse(objDr["ParticipationStartDate"].ToString());
            _PayPeriod = int.Parse(objDr["ParticipationPayPeriod"].ToString());
            _Value = float.Parse(objDr["ParticipationValue"].ToString());
            _Desc = objDr["ParticipationDesc"].ToString();
            _Number = objDr["ParticipationNumber"].ToString();
            _IsStop = bool.Parse(objDr["IsStop"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }

        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_ID != 0)
                strSql = strSql + " and HRApplicantWorkerServiceParticipation.ParticipationID = " + _ID;
            if (_Applicant != 0)
                strSql = strSql + " and HRApplicantWorkerServiceParticipation.ParticipationApplicant = " + _Applicant;
            if (_Service != 0)
                strSql = strSql + " and HRApplicantWorkerServiceParticipation.ParticipationService = " + _Service;

            if (_IsStopSearch == 1) // not Stop
            {
                strSql = strSql + " And HRApplicantWorkerServiceParticipation.IsStop=0";
            }
            else if (_IsStopSearch == 2) // Stop
            {
                strSql = strSql + " And HRApplicantWorkerServiceParticipation.IsStop=1";
            }
            if (_NumberSearch != null && _NumberSearch != "")
            {
                strSql = strSql + " And HRApplicantWorkerServiceParticipation.ParticipationNumber like '%"+ _NumberSearch +"%'";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
