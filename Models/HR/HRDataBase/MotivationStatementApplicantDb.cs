using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class MotivationStatementApplicantDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _Applicant;

        protected int _MotivationStatementSearch;
        protected int _ApplicantSearch;
        protected string _ApplicantIDs;
        byte _MotivationStatusSearch;
        bool _ShortApplicantOnly;

        public bool ShortApplicantOnly
        {
            get { return _ShortApplicantOnly; }
            set { _ShortApplicantOnly = value; }
        }
        #endregion
        #region Constructors
        public MotivationStatementApplicantDb()
        {
        }
        public MotivationStatementApplicantDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int Applicant { set { _Applicant = value; } get { return _Applicant; } }
        public int MotivationStatementSearch { set { _MotivationStatementSearch = value; }  }
        public int ApplicantSearch { set { _ApplicantSearch = value; } }
        public string ApplicantIDs { set { _ApplicantIDs = value; } }
        public byte MotivationStatusSearch { set { _MotivationStatusSearch = value; } }
        public string AddStr
        {
            get
            {
                string strReturned = " INSERT INTO HRMotivationStatementApplicant"+
                                     " (MotivationStatement, Applicant)"+
                                     " VALUES     (" + _MotivationStatement + ","+ _Applicant +")";
                return strReturned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturned = " DELETE FROM HRMotivationStatementApplicant"+
                                     " WHERE     (MotivationStatement = " + _MotivationStatement + ") AND (Applicant = " + _Applicant + ")";
                return strReturned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturned = " SELECT     MotivationStatement, Applicant,ApplicantWorkerTable.* " +
                                     " FROM         HRMotivationStatementApplicant "+
                                     " Inner Join ("+ new ApplicantWorkerDb().SearchStr +") As ApplicantWorkerTable "+
                                     " On ApplicantWorkerTable.ApplicantID = HRMotivationStatementApplicant.Applicant";
                return strReturned;
            }
        }
        public static string SeachShortStr
        {
            get
            {
                string strReturned = " SELECT     MotivationStatement, Applicant,ApplicantWorkerTable.* " +
                                     " FROM         HRMotivationStatementApplicant " +
                                     " Inner Join (" + new ApplicantWorkerDb().ShortSearchStr +  ") As ApplicantWorkerTable " +
                                     " On ApplicantWorkerTable.ApplicantID = HRMotivationStatementApplicant.Applicant";
                return strReturned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["MotivationStatement"].ToString() == "")
                return;
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());

        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = (_ShortApplicantOnly ? SeachShortStr : SearchStr) + " Where 1=1 ";
            if (_MotivationStatement != 0)
                StrSql = StrSql + " And MotivationStatement = " + _MotivationStatement + "";

            if (_Applicant != 0)
                StrSql = StrSql + " And Applicant = " + _Applicant + "";
            if (_MotivationStatementSearch != 0)
                StrSql = StrSql + " And MotivationStatement = " + _MotivationStatementSearch + "";


            if (_MotivationStatusSearch != 0)
            {               
                if (_MotivationStatusSearch == 1)
                {
                    StrSql += " And (HRMotivationStatementApplicant.Applicant in (Select Applicant From HRApplicantWorkerMotivationStatement " +
                              " Where MotivationStatement = " + _MotivationStatementSearch + " And CostCenter =0))";
                }
                else if (_MotivationStatusSearch == 2)
                {
                    StrSql += " And (HRMotivationStatementApplicant.Applicant not in (Select Applicant From HRApplicantWorkerMotivationStatement " +
                             " Where MotivationStatement = " + _MotivationStatementSearch + " And CostCenter =0))";
                }
            }



            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
