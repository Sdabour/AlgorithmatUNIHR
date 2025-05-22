using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;

using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerPenaltyBiz
    {
        #region Private Data
        ApplicantWorkerPenaltyDb _ApplicantWorkerPenaltyDb;
        ApplicantWorkerBiz _PenaltyApplicantBiz;
        //PenaltyReasonBiz _PenaltyReasonBiz;
        //PenaltyTypeBiz _PenaltyTypeBiz;
        ApplicantWorkerBiz _PenaltyPersonBiz;
        AttachmentFileBiz _AttachmentBiz;

        ApplicantWorkerPenaltyDiscountCol _PenaltyDiscountCol;
        ApplicantWorkerPenaltyDiscountCol _DeletePenaltyDiscountCol;
        string _Path;
        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyBiz()
        {
            _ApplicantWorkerPenaltyDb = new ApplicantWorkerPenaltyDb();
            _PenaltyApplicantBiz = new ApplicantWorkerBiz();
            //_PenaltyReasonBiz = new PenaltyReasonBiz();
            //_PenaltyTypeBiz = new PenaltyTypeBiz();

            _PenaltyPersonBiz = new ApplicantWorkerBiz();

        }
        public ApplicantWorkerPenaltyBiz(DataRow objDR)
        {
            _ApplicantWorkerPenaltyDb = new ApplicantWorkerPenaltyDb(objDR);
            _PenaltyApplicantBiz = new ApplicantWorkerBiz(objDR);


            if (objDR["PenaltyPerson"].ToString() != "")
            {
                DataRow[] ArrDr = ApplicantWorkerPenaltyDb.CachPenaltyPersonTable.Select("ApplicantID=" + objDR["PenaltyPerson"]);
                if (ArrDr.Length != 0)
                    _PenaltyPersonBiz = new ApplicantWorkerBiz(ArrDr[0]);
                else
                    _PenaltyPersonBiz = new ApplicantWorkerBiz();
                //_PenaltyPersonBiz = new ApplicantWorkerBiz(int.Parse(objDR["PenaltyPerson"].ToString()));
            }
            else
                _PenaltyPersonBiz = new ApplicantWorkerBiz();

            //if (objDR["AttachmentID"].ToString() != "")
            //    _AttachmentBiz = new ApplicantAttachmentBiz(int.Parse(objDR["AttachmentID"].ToString()));
            //else
            //    _AttachmentBiz = new ApplicantAttachmentBiz();

        }
        #endregion
        #region Public Properties
        public int PenaltyID
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyID = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyID;
            }

        }
        public ApplicantWorkerBiz PenaltyApplicantBiz
        {
            set
            {
                _PenaltyApplicantBiz = value;
            }
            get
            {
                return _PenaltyApplicantBiz;
            }

        }
       
        public ApplicantWorkerBiz PenaltyPersonBiz
        {
            set
            {
                _PenaltyPersonBiz = value;
            }
            get
            {
                return _PenaltyPersonBiz;
            }

        }
        public int PenaltyEstimationStatement
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyEstimationStatement = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyEstimationStatement;
            }

        }
        public int PenaltyStatus
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyStatus = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyStatus;
            }

        }        
        public string PenaltyDesc
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyDesc = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyDesc;
            }

        }
        public DateTime PenaltyDate
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyDate = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyDate;
            }

        }
        public string PenaltyReasonDesc
        {
            set
            {
                _ApplicantWorkerPenaltyDb.PenaltyReasonDesc = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDb.PenaltyReasonDesc;
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
                _AttachmentBiz = value;
            }
            get
            {
                if (_AttachmentBiz == null)
                {
                    if (_ApplicantWorkerPenaltyDb.AttachmentID != 0)
                    {
                        _AttachmentBiz = new AttachmentFileBiz(_ApplicantWorkerPenaltyDb.AttachmentID);
                    }
                    else
                        _AttachmentBiz = new AttachmentFileBiz();
                }
                return _AttachmentBiz;
            }
        }
        public string StrPenaltyApplicant
        {
            get
            {
                if (PenaltyApplicantBiz != null)
                    return PenaltyApplicantBiz.Name;
                else
                    return "";
            }
        }
        public string StrPenaltyPerson
        {
            get
            {
                if (PenaltyPersonBiz != null)
                    return PenaltyPersonBiz.Name;
                else
                    return "";
            }
        }
       
       
        public ApplicantWorkerPenaltyDiscountCol PenaltyDiscountCol
        {
            set
            {
                _PenaltyDiscountCol = value;
            }
            get
            {
                if (_PenaltyDiscountCol == null)
                {
                    _PenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
                    if (PenaltyID != 0)
                    {
                        ApplicantWorkerPenaltyDiscountDb objDb = new ApplicantWorkerPenaltyDiscountDb();
                        objDb.DiscountPenalty = PenaltyID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow  objDr in dtTemp.Rows)
                        {
                            _PenaltyDiscountCol.Add(new ApplicantWorkerPenaltyDiscountBiz(objDr));
                        }
                    }
                }
                return _PenaltyDiscountCol;
            }

        }
        public ApplicantWorkerPenaltyDiscountCol DeletePenaltyDiscountCol
        {
            set
            {
                _DeletePenaltyDiscountCol = value;
            }

            get
            {
                if (_DeletePenaltyDiscountCol == null)
                {
                    _DeletePenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
                }
                return _DeletePenaltyDiscountCol;
            }
        }
        public double TotalDiscount
        {
            get
            {
                double dbReturned = 0;
                foreach (ApplicantWorkerPenaltyDiscountBiz objBiz in PenaltyDiscountCol)
                {
                    dbReturned += (double)objBiz.DiscountValue;
                }
                return dbReturned;
            }
        }
        public string DiscountDesc
        {
            get
            {
                string strReturned = "";
                foreach (ApplicantWorkerPenaltyDiscountBiz objBiz in PenaltyDiscountCol)
                {
                    if (strReturned == "")
                        strReturned += objBiz.DiscountDesc;
                    else
                        strReturned += " - " + objBiz.DiscountDesc;
                }
                return strReturned;
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

            _ApplicantWorkerPenaltyDb.PenaltyApplicantID = PenaltyApplicantBiz.ID;
            _ApplicantWorkerPenaltyDb.PenaltyPerson = PenaltyPersonBiz.ID;
            //_ApplicantWorkerPenaltyDb.PenaltyReason = PenaltyReasonBiz.ID;
            //_ApplicantWorkerPenaltyDb.PenaltyType = PenaltyTypeBiz.ID;
           _ApplicantWorkerPenaltyDb.AttachmentID = AttachmentBiz.ID;
            _ApplicantWorkerPenaltyDb.Add();
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

            _ApplicantWorkerPenaltyDb.PenaltyApplicantID = PenaltyApplicantBiz.ID;
            _ApplicantWorkerPenaltyDb.PenaltyPerson = PenaltyPersonBiz.ID;
            //_ApplicantWorkerPenaltyDb.PenaltyReason = PenaltyReasonBiz.ID;
            //_ApplicantWorkerPenaltyDb.PenaltyType = PenaltyTypeBiz.ID;
            _ApplicantWorkerPenaltyDb.AttachmentID = AttachmentBiz.ID;
            _ApplicantWorkerPenaltyDb.Edit();
        }
        public void Delete()
        {
            if (AttachmentBiz != null)
                AttachmentBiz.Delete(AttachmentBiz.ID);

            _ApplicantWorkerPenaltyDb.PenaltyApplicantID = _PenaltyApplicantBiz.ID;
            _ApplicantWorkerPenaltyDb.Delete();
        }
        
        #endregion
    }
}
