using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerLoanBiz
    {
        #region Private Data
        ApplicantWorkerLoanDb _ApplicantWorkerLaonDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        ApplicantWorkerStatementLoanDiscountCol _LoanDiscountCol;
        ApplicantWorkerStatementLoanDiscountCol _LoanDiscountColWithStatement;
        ApplicantWorkerLoanPaymentCol _LoanPaymentCol;
        AttachmentFileBiz _Attachment;
        
         string _Path;
        #endregion
        #region Constructors
        public ApplicantWorkerLoanBiz()
        {
            _ApplicantWorkerLaonDb = new ApplicantWorkerLoanDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
        }
        public ApplicantWorkerLoanBiz(DataRow objDr)
        {
            _ApplicantWorkerLaonDb = new ApplicantWorkerLoanDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
            _LoanDiscountCol = new ApplicantWorkerStatementLoanDiscountCol(true);
            ApplicantWorkerStatementLoanDiscountBiz objDiscount = new ApplicantWorkerStatementLoanDiscountBiz();
            objDiscount.Value = _ApplicantWorkerLaonDb.TotalDiscount;
            if (objDiscount.Value > 0)
                _LoanDiscountCol.Add(objDiscount);
            _LoanPaymentCol = new ApplicantWorkerLoanPaymentCol(true);
            ApplicantWorkerLoanPaymentBiz objPayment = new ApplicantWorkerLoanPaymentBiz();
            objPayment.PaymenetValue = (float)_ApplicantWorkerLaonDb.TotalPayment;
            if (objPayment.PaymenetValue > 0)
                _LoanPaymentCol.Add(objPayment);

        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerLaonDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.ID;
            }
        }
        public bool IsStop
        {
            set
            {
                _ApplicantWorkerLaonDb.IsStop = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.IsStop;
            }
        }
        public float LoanPrepaidValue
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanPrepaidValue = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanPrepaidValue;
            }
        }
        public float InstallmentValue
        {
            set
            {
                _ApplicantWorkerLaonDb.InstallmentValue = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.InstallmentValue;
            }
        }
        public DateTime InstallmentDate
        {
            set
            {
                _ApplicantWorkerLaonDb.InstallmentDate = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.InstallmentDate;
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
        public float LoanValue
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanValue = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanValue;
            }
        }
        public string LoanDesc
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanDesc = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanDesc;
            }
        }
        public DateTime LoanRequestDate
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanRequestDate = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanRequestDate;
            }
        }
        public DateTime LoanGrantDate
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanGrantDate = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanGrantDate;
            }
        }
        public int LoanImage
        {
            set
            {
                _ApplicantWorkerLaonDb.LoanImage = value;
            }
            get
            {
                return _ApplicantWorkerLaonDb.LoanImage;
            }
        }
        public ApplicantWorkerStatementLoanDiscountCol LoanDiscountCol
        {
            set
            {
                _LoanDiscountCol = value;
            }
            get
            {
                if (_LoanDiscountCol == null)
                {
                    _LoanDiscountCol = new ApplicantWorkerStatementLoanDiscountCol(this);
                }
                return _LoanDiscountCol;
            }
        }

        public ApplicantWorkerStatementLoanDiscountCol GetLoanDiscountColWithStatement(int intNotGreaterThanID)
        {
            ApplicantWorkerStatementLoanDiscountCol objCol = new ApplicantWorkerStatementLoanDiscountCol(this, intNotGreaterThanID);

            return objCol;

        }
        public ApplicantWorkerLoanPaymentCol LoanPaymentCol
        {
            set
            {
                _LoanPaymentCol = value;
            }
            get
            {
                if (_LoanPaymentCol == null)
                {
                    _LoanPaymentCol = new ApplicantWorkerLoanPaymentCol(this);
                }
                return _LoanPaymentCol;
            }
        }
        public double ReminderValue
        {
            get
            {
                double flReminderValue = 0;
                flReminderValue = LoanValue - LoanPrepaidValue - LoanDiscountCol.TotalValue - LoanPaymentCol.TotalValue;
                return flReminderValue;
            }
        }
        public string Path
        {
            set
            {
                _Path = value;
            }
            get
            {
                if (_Path == null || _Path == "")
                {
                    if (AttachmentBiz != null && AttachmentBiz.ID != 0)
                    {
                        _Path = AttachmentBiz.Path;
                    }
                    else
                        _Path = "";

                }

                return _Path;
            }
        }
        public AttachmentFileBiz AttachmentBiz
        {
            set
            {
                _Attachment = value;
            }
            get
            {
                if (_Attachment == null)
                {
                    if (_ApplicantWorkerLaonDb.LoanImage != 0)
                    {
                        _Attachment = new AttachmentFileBiz(_ApplicantWorkerLaonDb.LoanImage);
                    }
                    else
                        _Attachment = new AttachmentFileBiz();
                }
                return _Attachment;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            if (Path != "")
            {
                AttachmentBiz.FilePath = Path;
                AttachmentBiz.Add();
            }
            _ApplicantWorkerLaonDb.LoanImage = AttachmentBiz.ID;

            _ApplicantWorkerLaonDb.LoanApplicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerLaonDb.Add();
        }
        public void Edit()
        {
            if (AttachmentBiz.Path == "")
            {
                if (Path != "")
                {
                    AttachmentBiz.FilePath = Path;
                    AttachmentBiz.Add();
                }
            }
            else if (AttachmentBiz.Path != Path)
            {
                AttachmentBiz.Bytes = null;
                AttachmentBiz.FilePath = Path;
                AttachmentBiz.Edit();
            }
            _ApplicantWorkerLaonDb.LoanImage = AttachmentBiz.ID;

            _ApplicantWorkerLaonDb.LoanApplicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerLaonDb.Edit();
        }
        public void Delete()
        {
            if (AttachmentBiz != null)
                AttachmentBiz.Delete(AttachmentBiz.ID);

            _ApplicantWorkerLaonDb.LoanApplicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerLaonDb.Delete();
        }
        #endregion
    }
}
