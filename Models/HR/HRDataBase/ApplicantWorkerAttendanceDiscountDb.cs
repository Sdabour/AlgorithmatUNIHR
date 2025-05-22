using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerAttendanceDiscountDb
    {
        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected int _AttendanceStatement;
        protected string _Desc;
        protected double _Value;
        protected double _DayCount;
        protected double _AppliedValue = -1;
        protected int _AppliedValueUsr;
        protected int _FinancialStatement;
        protected bool _FinancialStatementSearch;
        string _IDsStr;
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceDiscountDb()
        {
        }
        public ApplicantWorkerAttendanceDiscountDb(DataRow objDr)
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
        public int AttendanceStatement
        {
            set
            {
                _AttendanceStatement = value;
            }
            get
            {
                return _AttendanceStatement;
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
        public double Value
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
        public double DayCount
        {
            set
            {
                _DayCount = value;
            }
            get
            {
                return _DayCount;
            }
        }
        public double AppliedValue
        {
            set
            {
                _AppliedValue = value;
            }
            get
            {
                return _AppliedValue;
            }
        }
        public int AppliedValueUsr
        {
            set
            {
                _AppliedValueUsr = value;
            }
            get
            {
                return _AppliedValueUsr;
            }
        }
        public int FinancialStatement
        {
            set
            {
                _FinancialStatement = value;
            }
            get
            {
                return _FinancialStatement;
            }
        }
        public bool FinancialStatementSearch
        {
            set
            {
                _FinancialStatementSearch = value;
            }
            get
            {
                return _FinancialStatementSearch;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HRApplicantWorkerAttendanceDiscount " +
                                  " (DiscountApplicant, DiscountAttendanceStatment," +
                                  " DiscountDesc, DiscountValue, " +
                                  " DiscountFinancialStatement,DiscountAttendanceDayCount,DiscountAppliedValue,DiscountAppliedValueUsr, UsrIns, TimIns)" +
                                  " VALUES     (" +
                                  " " + _Applicant + "," + _AttendanceStatement + "," +
                                  " '" + _Desc + "'," + _Value + "," +
                                  " " + _FinancialStatement + "," +
                                  " " + _DayCount + "," + _AppliedValue + "," + _AppliedValueUsr + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    HRApplicantWorkerAttendanceDiscount " +
                                  "  SET " +
                                  "  DiscountApplicant = " + _Applicant + "" +
                                  ", DiscountAttendanceStatment =" + _AttendanceStatement + "" +
                                  ", DiscountDesc ='" + _Desc + "'" +
                                  ", DiscountValue =" + _Value + "" +
                                  ", DiscountAttendanceDayCount =" + _DayCount + "" +
                                  ", DiscountAppliedValue =" + _AppliedValue + "" +
                                  ", DiscountAppliedValueUsr =" + _AppliedValueUsr + "" +
                                  ", DiscountFinancialStatement =" + _FinancialStatement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (DisocuntID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM HRApplicantWorkerAttendanceDiscount " +
                                  " WHERE     (DisocuntID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerAttendanceDiscount.DisocuntID, HRApplicantWorkerAttendanceDiscount.DiscountApplicant, " +
                                  " HRApplicantWorkerAttendanceDiscount.DiscountAttendanceStatment, HRApplicantWorkerAttendanceDiscount.DiscountDesc, " +
                                  " HRApplicantWorkerAttendanceDiscount.DiscountValue,HRApplicantWorkerAttendanceDiscount.DiscountAttendanceDayCount, HRApplicantWorkerAttendanceDiscount.DiscountFinancialStatement" +
                                  ",HRApplicantWorkerAttendanceDiscount.DiscountAppliedValue,HRApplicantWorkerAttendanceDiscount.DiscountAppliedValueUsr" +
                                  " FROM         HRApplicantWorkerAttendanceDiscount";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {

            _ID = int.Parse(objDr["DisocuntID"].ToString());
            _Applicant = int.Parse(objDr["DiscountApplicant"].ToString());
            _AttendanceStatement = int.Parse(objDr["DiscountAttendanceStatment"].ToString());
            _FinancialStatement = int.Parse(objDr["DiscountFinancialStatement"].ToString());
            if (objDr["DiscountValue"].ToString() != "")
                _Value = double.Parse(objDr["DiscountValue"].ToString());
            if (objDr["DiscountAttendanceDayCount"].ToString() != "")
                _DayCount = double.Parse(objDr["DiscountAttendanceDayCount"].ToString());
            _Desc = objDr["DiscountDesc"].ToString();
            if (objDr["DiscountAppliedValue"].ToString() != "")
                _AppliedValue = double.Parse(objDr["DiscountAppliedValue"].ToString());
            _AppliedValueUsr = int.Parse(objDr["DiscountAppliedValueUsr"].ToString());
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
        public void EditFinancialStatement()
        {
            string strSql = " UPDATE    HRApplicantWorkerAttendanceDiscount " +
                                  "  SET  DiscountFinancialStatement =" + _FinancialStatement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (DisocuntID in (" + _IDsStr + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_Applicant != 0)
                StrSql = StrSql + " And ( DiscountApplicant = " + _Applicant + ")";
            if (_AttendanceStatement != 0)
                StrSql = StrSql + " And ( DiscountAttendanceStatment = " + _AttendanceStatement + ")";
            
            if (_FinancialStatementSearch == true)
                StrSql = StrSql + " And ( DiscountFinancialStatement <> 0)";
            else
                StrSql = StrSql + " And ( DiscountFinancialStatement = 0)";

            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
