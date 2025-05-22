using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerPenaltyDiscountBiz
    {
        #region Private Data
        ApplicantWorkerPenaltyDiscountDb _ApplicantWorkerPenaltyDiscountDb;
        ApplicantWorkerPenaltyBiz _PenaltyBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyDiscountBiz()
        {
            _ApplicantWorkerPenaltyDiscountDb = new ApplicantWorkerPenaltyDiscountDb();
            _PenaltyBiz = new ApplicantWorkerPenaltyBiz();
        }
        public ApplicantWorkerPenaltyDiscountBiz(DataRow objDr)
        {
            _ApplicantWorkerPenaltyDiscountDb = new ApplicantWorkerPenaltyDiscountDb(objDr);
            _PenaltyBiz = new ApplicantWorkerPenaltyBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerPenaltyDiscountDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDiscountDb.ID;
            }
        }
        public ApplicantWorkerPenaltyBiz PenaltyBiz
        {
            set
            {
                _PenaltyBiz = value;
            }
            get
            {
                return _PenaltyBiz;
            }
        }
        public float DiscountValue
        {
            set
            {
                _ApplicantWorkerPenaltyDiscountDb.DiscountValue = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDiscountDb.DiscountValue;
            }
        }
        public string DiscountDesc
        {
            set
            {
                _ApplicantWorkerPenaltyDiscountDb.DiscountDesc = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDiscountDb.DiscountDesc;
            }
        }
        public int DiscountStatement
        {
            set
            {
                _ApplicantWorkerPenaltyDiscountDb.DiscountStatement = value;
            }
            get
            {
                return _ApplicantWorkerPenaltyDiscountDb.DiscountStatement;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerPenaltyDiscountDb.DiscountPenalty = _PenaltyBiz.PenaltyID;
            _ApplicantWorkerPenaltyDiscountDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerPenaltyDiscountDb.DiscountPenalty = _PenaltyBiz.PenaltyID;
            _ApplicantWorkerPenaltyDiscountDb.Edit();
        }
        public void Delete()
        {
            _ApplicantWorkerPenaltyDiscountDb.DiscountPenalty = _PenaltyBiz.PenaltyID;
            _ApplicantWorkerPenaltyDiscountDb.Delete();
        }
        #endregion
    }
}
