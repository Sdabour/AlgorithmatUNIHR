using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementDiscountBiz
    {
        #region Private Data
        ApplicantWorkerMotivationStatementDiscountDb _ApplicantWorkerMotivationStatementDiscountDb;
        MotivationDiscountTypeBiz _MotivationDiscountTypeBiz;
        ApplicantWorkerMotivationStatementBiz _StatementBiz;

     
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementDiscountBiz()
        {
            _ApplicantWorkerMotivationStatementDiscountDb = new ApplicantWorkerMotivationStatementDiscountDb();
            _MotivationDiscountTypeBiz = new MotivationDiscountTypeBiz();
        }
        public ApplicantWorkerMotivationStatementDiscountBiz(DataRow objDr)
        {
            _ApplicantWorkerMotivationStatementDiscountDb = new ApplicantWorkerMotivationStatementDiscountDb(objDr);
            _MotivationDiscountTypeBiz = new MotivationDiscountTypeBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerMotivationStatementDiscountDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementDiscountDb.ID;
            }
        }
        public int ApplicantWorkerMotivationStatement
        {
            set
            {
                _ApplicantWorkerMotivationStatementDiscountDb.ApplicantWorkerMotivationStatement = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementDiscountDb.ApplicantWorkerMotivationStatement;
            }
        }
        public string Desc
        {
            set
            {
                _ApplicantWorkerMotivationStatementDiscountDb.Desc = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementDiscountDb.Desc;
            }
        }
        public double DiscountValue
        {
            set
            {
                _ApplicantWorkerMotivationStatementDiscountDb.DiscountValue = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementDiscountDb.DiscountValue;
            }
        }
        public MotivationDiscountTypeBiz MotivationDiscountTypeBiz
        {
            set
            {
                _MotivationDiscountTypeBiz = value;
            }
            get
            {
                return _MotivationDiscountTypeBiz;
            }
        }
        public ApplicantWorkerMotivationStatementBiz StatementBiz
        {
            get {
                if (_StatementBiz == null)
                    _StatementBiz = new ApplicantWorkerMotivationStatementBiz();
                return _StatementBiz; }
            set { _StatementBiz = value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerMotivationStatementDiscountDb.MotivationDiscountType = _MotivationDiscountTypeBiz.ID;
            _ApplicantWorkerMotivationStatementDiscountDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerMotivationStatementDiscountDb.MotivationDiscountType = _MotivationDiscountTypeBiz.ID;
            _ApplicantWorkerMotivationStatementDiscountDb.Edit();
        }
        public void Delete()
        {            
            _ApplicantWorkerMotivationStatementDiscountDb.Delete();
        }
        #endregion
    }
}
