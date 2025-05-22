using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerBillDb
    {
        #region Private Data
        protected int _ID;
        protected int _ApplicantParticipation;
        protected int _Applicant;
        protected DateTime _BillDate;
        protected float _BillValue;
        protected int _BillStatement;
        protected int _GlobalStatement;
        protected bool _BillDateSearch;
        protected DateTime _BillDateFromSearch;
        protected DateTime _BillDateToSearch;
        string _IDsStr;
        byte _StatementStatus;
        string _ApplicantIDs;

        int _ServiceTypeSearch;
        int _ServiceSearch;
        int _ServiceProviderSearch;
        bool _SetApplicantCache;
        #endregion
        #region Constructors
        public ApplicantWorkerBillDb()
        {
        }
        public ApplicantWorkerBillDb(DataRow objDr)
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
        public int ApplicantParticipation
        {
            set
            {
                _ApplicantParticipation = value;
            }
            get
            {
                return _ApplicantParticipation;
            }
        }
        public DateTime BillDate
        {
            set
            {
                _BillDate = value;
            }
            get
            {
                return _BillDate;
            }
        }
        public float BillValue
        {
            set
            {
                _BillValue = value;
            }
            get
            {
                return _BillValue;
            }
        }
        public int BillStatement
        {
            set
            {
                _BillStatement = value;
            }
            get
            {
                return _BillStatement;
            }
        }
        public bool BillDateSearch
        {
            set
            {
                _BillDateSearch = value;
            }
            get
            {
                return _BillDateSearch;
            }
        }
        public DateTime BillDateFromSearch
        {
            set
            {
                _BillDateFromSearch = value;
            }
            get
            {
                return _BillDateFromSearch;
            }
        }
        public DateTime BillDateToSearch
        {
            set
            {
                _BillDateToSearch = value;
            }
            get
            {
                return _BillDateToSearch;
            }
        }
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }           
        }
         public int GlobalStatement 
        {
            set
            {
                _GlobalStatement = value;
            }           
         }
        public int ServiceTypeSearch
        {
            set
            {
                _ServiceTypeSearch = value;
            }
        }
        public int ServiceSearch
        {
            set
            {
                _ServiceSearch = value;
            }
        }
        public int ServiceProviderSearch
        {
            set
            {
                _ServiceProviderSearch = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public byte StatementStatus
        {
            set
            {
                _StatementStatus = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }

        }
        public bool SetApplicantCache
        {
            set
            {
                _SetApplicantCache = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerBill.BillID, HRApplicantWorkerBill.ApplicantParticipation, "+
                                  " HRApplicantWorkerBill.BillDate, HRApplicantWorkerBill.BillValue,HRApplicantWorkerBill.BillStatement,ServiceParticipationTable.*" +
                                  " FROM HRApplicantWorkerBill"+
                                  " Inner Join (" + ApplicantWorkerServiceParticipationDb.SearchStr + ") as ServiceParticipationTable "+
                                  " On HRApplicantWorkerBill.ApplicantParticipation = ServiceParticipationTable.ParticipationID";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dlBillDate = _BillDate.ToOADate() - 2;
                string strReturn = " INSERT INTO HRApplicantWorkerBill"+
                                   " (ApplicantParticipation, BillDate, BillValue, BillStatement, UsrIns, TimIns)"+
                                   " VALUES "+
                                   " (" + _ApplicantParticipation + "," + dlBillDate + "," + BillValue + "," +
                                   " "+ _BillStatement +","+ SysData.CurrentUser.ID +",GetDate())";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                double dlBillDate = _BillDate.ToOADate() - 2;
                string strReturn = " UPDATE    HRApplicantWorkerBill" +
                                   "  SET " +
                                   "  ApplicantParticipation =" + _ApplicantParticipation + "" +
                                   ", BillDate =" + dlBillDate + "" +
                                   ", BillValue = "+ BillValue + "" +
                                   ", BillStatement =" + _BillStatement + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " Where BillID = "+ _ID +"";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " Delete From    HRApplicantWorkerBill" +                                  
                                   " Where BillID = " + _ID + "";
                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["BillID"].ToString());
            _ApplicantParticipation = int.Parse(objDr["ApplicantParticipation"].ToString());
            _BillDate  = DateTime.Parse(objDr["BillDate"].ToString());
            _BillValue = float.Parse(objDr["BillValue"].ToString());
            _BillStatement = int.Parse(objDr["BillStatement"].ToString());
            _Applicant = int.Parse(objDr["ParticipationApplicant"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerBill" +
                                  "  SET " +
                                  " BillStatement =" + _BillStatement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where BillID in (" + _IDsStr + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_ApplicantParticipation != 0)
                strSql = strSql + " And ApplicantParticipation = " + _ApplicantParticipation + "";
            if (_Applicant != 0)
                strSql = strSql + " And ServiceParticipationTable.ParticipationApplicant= " + _Applicant + "";
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql = strSql + " And (ServiceParticipationTable.ParticipationApplicant In ( " + _ApplicantIDs + "))";
            if (_BillDateSearch == true && _GlobalStatement==0)
            {
                int intBillFrom;
                double d = _BillDateFromSearch.ToOADate() - 2;
                intBillFrom = (int)d;
                intBillFrom = intBillFrom > d ? intBillFrom-1 : intBillFrom;
                int intBillTo;
                double dd = _BillDateToSearch.ToOADate() - 2;
                intBillTo = (int)dd;
                intBillTo = intBillTo < dd ? intBillTo + 1 : intBillTo;
                

                strSql = strSql + " And BillDate >=  " + intBillFrom + " and BillDate < " + intBillTo + "";
            }
            if (_ServiceTypeSearch != 0)
                strSql = strSql + " And ServiceParticipationTable.ServiceType= " + _ServiceTypeSearch + "";
            if (_ServiceSearch != 0)
                strSql = strSql + " And ServiceParticipationTable.ServiceID= " + _ServiceSearch + "";
            if (_ServiceProviderSearch != 0)
                strSql = strSql + " And ServiceParticipationTable.ServiceProvider= " + _ServiceProviderSearch + "";
            if (_StatementStatus != 0)
            {
                if (_StatementStatus == 1)
                    strSql += " and HRApplicantWorkerBill.BillStatement =0 ";
                if(_StatementStatus == 2)
                    strSql += " and HRApplicantWorkerBill.BillStatement <>0 ";
            }
            
            if(_BillStatement != 0)
                strSql += " and HRApplicantWorkerBill.BillStatement =" + _BillStatement;
            if (_GlobalStatement != 0)
            {
                //strSql += " and ServiceParticipationTable.ParticipationApplicant In (SELECT     Applicant FROM         HRApplicantWorkerStatement WHERE     (GlobalStatment = " + _GlobalStatement + "))";
                string ss = "";
                if (_BillDateSearch == true)
                {
                    int intBillFrom;
                    double d = _BillDateFromSearch.ToOADate() - 2;
                    intBillFrom = (int)d;
                    intBillFrom = intBillFrom > d ? intBillFrom - 1 : intBillFrom;
                    int intBillTo;
                    double dd = _BillDateToSearch.ToOADate() - 2;
                    intBillTo = (int)dd;
                    intBillTo = intBillTo < dd ? intBillTo + 1 : intBillTo;

                    
                     ss = " OR (BillDate >=  " + intBillFrom + " and BillDate < " + intBillTo + ")";
                }

                strSql += " and ((HRApplicantWorkerBill.BillStatement  In (SELECT OriginStatementID FROM HRApplicantWorkerStatement WHERE (GlobalStatment = " + _GlobalStatement + "))) "+ ss +" )";

                

            }
            if (_SetApplicantCache == true)
            {
                ApplicantWorkerDb.SetCashTable();
                ApplicantWorkerDb.ApplicantIDs = " select ApplicantID from (" + strSql + ") as NativeTable ";
            }
           
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
