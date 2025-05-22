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
    public class ApplicantWorkerStatementDiscountBiz
    {
        #region Private Data
        ApplicantWorkerStatementDiscountDb _OriginStatementDiscountDb;
        SalaryDiscountTypeBiz _DiscountTypeBiz;
        #endregion

        #region Constractors
        public ApplicantWorkerStatementDiscountBiz()
        {
            _OriginStatementDiscountDb = new ApplicantWorkerStatementDiscountDb();
            _DiscountTypeBiz = new SalaryDiscountTypeBiz();
        }
        public ApplicantWorkerStatementDiscountBiz(int intID)
        {
            _OriginStatementDiscountDb = new ApplicantWorkerStatementDiscountDb(intID);
            _DiscountTypeBiz = new SalaryDiscountTypeBiz(_OriginStatementDiscountDb.DiscountType);
        }
        public ApplicantWorkerStatementDiscountBiz(DataRow objDR)
        {
            _OriginStatementDiscountDb = new ApplicantWorkerStatementDiscountDb(objDR);
            _DiscountTypeBiz = new SalaryDiscountTypeBiz(objDR);
        }
        #endregion

        #region Public Accessorice
        public SalaryDiscountTypeBiz DiscountTypeBiz
        {
            set
            {
                _DiscountTypeBiz = value;
            }
            get
            {
                return _DiscountTypeBiz;
            }
        }
        public int OriginStatement
        {
            set
            {
                _OriginStatementDiscountDb.OriginStatement = value;
            }
            get
            {
                return _OriginStatementDiscountDb.OriginStatement;
            }
        }
        public string Desc
        {
            set
            {
                _OriginStatementDiscountDb.Desc = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Desc;
            }
        }
        public double Value
        {
            set
            {
                _OriginStatementDiscountDb.Value = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _OriginStatementDiscountDb.Date = value;
            }
            get
            {
                return _OriginStatementDiscountDb.Date;
            }
        }
        public int DiscountID
        {
            set
            {
                _OriginStatementDiscountDb.DiscountID = value;
            }
            get
            {
                return _OriginStatementDiscountDb.DiscountID;
            }
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void Add()
        {
            _OriginStatementDiscountDb.DiscountType = _DiscountTypeBiz.ID;
            _OriginStatementDiscountDb.Add();
        }
        public void Edit()
        {
            _OriginStatementDiscountDb.DiscountType = _DiscountTypeBiz.ID;
            _OriginStatementDiscountDb.Edit();
        }
        public void Delete()
        {
            _OriginStatementDiscountDb.Delete();
        }

        #endregion
    }
}
