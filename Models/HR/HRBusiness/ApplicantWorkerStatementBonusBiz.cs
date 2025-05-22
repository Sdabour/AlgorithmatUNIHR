using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONBusiness;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementBonusBiz
    {
        #region Private Data

        ApplicantWorkerStatementBonusDb _OriginStatementBonusDb;
        SalaryBonusTypeBiz _BonusTypeBiz;
        #endregion

        #region Constractors
        public ApplicantWorkerStatementBonusBiz()
        {
            _OriginStatementBonusDb = new ApplicantWorkerStatementBonusDb();
            _BonusTypeBiz = new SalaryBonusTypeBiz();
        }
        public ApplicantWorkerStatementBonusBiz(int intID)
        {
            _OriginStatementBonusDb = new ApplicantWorkerStatementBonusDb(intID);
            _BonusTypeBiz = new SalaryBonusTypeBiz(_OriginStatementBonusDb.BonusType);
        }
        public ApplicantWorkerStatementBonusBiz(DataRow objDR)
        {
            _OriginStatementBonusDb = new ApplicantWorkerStatementBonusDb(objDR);
            _BonusTypeBiz = new SalaryBonusTypeBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public int ID
        {
            get { return _OriginStatementBonusDb.ID; }
            set { _OriginStatementBonusDb.ID = value; }
        }
        public int OriginStatement
        {
            set
            {
                _OriginStatementBonusDb.OriginStatement = value;
            }
            get
            {
                return _OriginStatementBonusDb.OriginStatement;
            }
        }
        public string Desc
        {
            set
            {
                _OriginStatementBonusDb.Desc = value;
            }
            get
            {
                return _OriginStatementBonusDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _OriginStatementBonusDb.Value = value;
            }
            get
            {
                return _OriginStatementBonusDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _OriginStatementBonusDb.Date = value;
            }
            get
            {
                return _OriginStatementBonusDb.Date;
            }
        }


        public SalaryBonusTypeBiz BonusTypeBiz
        {
            set
            {
                _BonusTypeBiz = value;
            }
            get
            {
                return _BonusTypeBiz;
            }
        }
        public int BonusID
        {
            set
            {
                _OriginStatementBonusDb.BonusID = value;
            }
            get
            {
                return _OriginStatementBonusDb.BonusID;
            }
        }
        public double DayCount
        {
            get { return _OriginStatementBonusDb.DayCount; }
            set { _OriginStatementBonusDb.DayCount = value; }
        }



        public double DayReferenceCount
        {
            get { return _OriginStatementBonusDb.DayReferenceCount; }
            set { _OriginStatementBonusDb.DayReferenceCount = value; }
        }


        public double HourCount
        {
            get { return _OriginStatementBonusDb.HourCount; }
            set { _OriginStatementBonusDb.HourCount = value; }
        }


        public double HourRefrenceCount
        {
            get { return _OriginStatementBonusDb.HourRefrenceCount; }
            set { _OriginStatementBonusDb.HourRefrenceCount = value; }
        }

        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _OriginStatementBonusDb.BonusType = _BonusTypeBiz.ID;
            _OriginStatementBonusDb.Add();
        }
        public void Edit()
        {
            _OriginStatementBonusDb.BonusType = _BonusTypeBiz.ID;
            _OriginStatementBonusDb.Edit();
        }
        public void Delete()
        {
            _OriginStatementBonusDb.Delete();
        }

        #endregion
    }
}
