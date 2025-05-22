using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerBonusBiz
    {
        #region Private Data
        protected ApplicantWorkerBonusDb _ApplicantWorkerBonusDb;
        protected ApplicantWorkerBiz _BonusApplicant;
        protected AttachmentFileBiz _Attachment;        
        string _Path;
        #endregion
        #region Constructors
        public ApplicantWorkerBonusBiz()
        {
            _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb();
            _BonusApplicant = new ApplicantWorkerBiz();
        }
        public ApplicantWorkerBonusBiz(DataRow objDr)
        {
            _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb(objDr);
            _BonusApplicant = new ApplicantWorkerBiz(objDr);
        }
        public ApplicantWorkerBonusBiz(int intApplicant)
        {
            _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb(intApplicant);
            _BonusApplicant = new ApplicantWorkerBiz(intApplicant);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerBonusDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.ID;
            }
        }
        public ApplicantWorkerBiz BonusApplicant
        {
            set
            {
                _BonusApplicant = value;
            }
            get
            {
                return _BonusApplicant;
            }
        }
        public float BonusValue
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusValue = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusValue;
            }
        }
        public float BonusDay
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusDay = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusDay;
            }
        }
        public string BonusReason
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusReason = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusReason;
            }
        }
        public DateTime BonusDate
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusDate = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusDate;
            }
        }
        public int BonusImage
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusImage = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusImage;
            }
        }
        public int BonusStatement
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusStatement = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusStatement;
            }
        }
        public bool BonusDateSearch
        {
            set
            {
                _ApplicantWorkerBonusDb.BonusDateSearch = value;
            }
            get
            {
                return _ApplicantWorkerBonusDb.BonusDateSearch;
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
                    if (_ApplicantWorkerBonusDb.BonusImage != 0)
                    {
                        _Attachment = new AttachmentFileBiz(_ApplicantWorkerBonusDb.BonusImage);
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
            _ApplicantWorkerBonusDb.BonusImage = AttachmentBiz.ID;
 
            _ApplicantWorkerBonusDb.BonusApplicant = _BonusApplicant.ID;
            _ApplicantWorkerBonusDb.Add();
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
            _ApplicantWorkerBonusDb.BonusImage = AttachmentBiz.ID;
            _ApplicantWorkerBonusDb.BonusApplicant = _BonusApplicant.ID;
            _ApplicantWorkerBonusDb.Edit();
        }
        public void Delete()
        {
            if (AttachmentBiz != null)
                AttachmentBiz.Delete(AttachmentBiz.ID);

            _ApplicantWorkerBonusDb.BonusApplicant = _BonusApplicant.ID;
            _ApplicantWorkerBonusDb.Delete();
        }
        #endregion
    }
}
