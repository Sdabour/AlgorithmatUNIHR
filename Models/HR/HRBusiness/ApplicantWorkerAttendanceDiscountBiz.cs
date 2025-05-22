using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class  ApplicantWorkerAttendanceDiscountBiz
    {
        #region Private Data
        protected ApplicantWorkerBiz _ApplicantWorkerBiz;
        protected ApplicantWorkerAttendanceStatementBiz _ApplicantAttendanceStatementBiz;
        protected ApplicantWorkerAttendanceDiscountDb _AttendanceDiscount;
        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceDiscountBiz()
        {
            _AttendanceDiscount = new ApplicantWorkerAttendanceDiscountDb();
        }
        public ApplicantWorkerAttendanceDiscountBiz(DataRow objDr)
        {
            _AttendanceDiscount = new ApplicantWorkerAttendanceDiscountDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _AttendanceDiscount.ID = value;
            }
            get
            {
                return _AttendanceDiscount.ID;
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
        public ApplicantWorkerAttendanceStatementBiz ApplicantAttendanceStatementBiz
        {
            set
            {
                _ApplicantAttendanceStatementBiz = value;
            }
            get
            {
                return _ApplicantAttendanceStatementBiz;
            }
        }
        public string Desc
        {
            set
            {
                _AttendanceDiscount.Desc = value;
            }
            get
            {
                return _AttendanceDiscount.Desc;
            }
        }
        public double Value
        {
            set
            {
                _AttendanceDiscount.Value = value;
            }
            get
            {
                return _AttendanceDiscount.Value;
            }
        }
        public double DayCount
        {
            set
            {
                _AttendanceDiscount.DayCount = value;
            }
            get
            {
                return _AttendanceDiscount.DayCount;
            }
        }
        public double AppliedValue
        {
            set
            {
                _AttendanceDiscount.AppliedValue = value;
            }
            get
            {
                return _AttendanceDiscount.AppliedValue;
            }
        }
        public int AppliedValueUsr
        {
            set
            {
                _AttendanceDiscount.AppliedValueUsr = value;
            }
            get
            {
                return _AttendanceDiscount.AppliedValueUsr;
            }
        }
        public int FinancialStatement
        {
            set
            {
                _AttendanceDiscount.FinancialStatement = value;
            }
            get
            {
                return _AttendanceDiscount.FinancialStatement;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _AttendanceDiscount.Applicant = _ApplicantWorkerBiz.ID;
            _AttendanceDiscount.AttendanceStatement = _ApplicantAttendanceStatementBiz.ID;
            _AttendanceDiscount.Add();
        }
        public void Edit()
        {
            _AttendanceDiscount.Applicant = _ApplicantWorkerBiz.ID;
            _AttendanceDiscount.AttendanceStatement = _ApplicantAttendanceStatementBiz.ID;
            _AttendanceDiscount.Add();
        }
        public void Delete()
        {
            _AttendanceDiscount.Applicant = _ApplicantWorkerBiz.ID;
            _AttendanceDiscount.AttendanceStatement = _ApplicantAttendanceStatementBiz.ID;
            _AttendanceDiscount.Add();
        }
        #endregion
    }
}
