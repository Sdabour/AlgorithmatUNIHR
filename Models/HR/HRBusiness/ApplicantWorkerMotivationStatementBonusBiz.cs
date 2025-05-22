using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementBonusBiz
    {
        #region Private Data
        ApplicantWorkerMotivationStatementBonusDb _ApplicantWorkerMotivationStatementBonusDb;
        MotivationBonusTypeBiz _MotivationBonusTypeBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementBonusBiz()
        {
            _ApplicantWorkerMotivationStatementBonusDb = new ApplicantWorkerMotivationStatementBonusDb();
            _MotivationBonusTypeBiz = new MotivationBonusTypeBiz();
        }
        public ApplicantWorkerMotivationStatementBonusBiz(DataRow objDr)
        {
            _ApplicantWorkerMotivationStatementBonusDb = new ApplicantWorkerMotivationStatementBonusDb(objDr);
            _MotivationBonusTypeBiz = new MotivationBonusTypeBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ApplicantWorkerMotivationStatementBonusDb.ID = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementBonusDb.ID;
            }
        }
        public int ApplicantWorkerMotivationStatement
        {
            set
            {
                _ApplicantWorkerMotivationStatementBonusDb.ApplicantWorkerMotivationStatement = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementBonusDb.ApplicantWorkerMotivationStatement;
            }
        }
        public string Desc
        {
            set
            {
                _ApplicantWorkerMotivationStatementBonusDb.Desc = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementBonusDb.Desc;
            }
        }
        public double BonusValue
        {
            set
            {
                _ApplicantWorkerMotivationStatementBonusDb.BonusValue = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatementBonusDb.BonusValue;
            }
        }
        public MotivationBonusTypeBiz MotivationBonusTypeBiz
        {
            set
            {
                _MotivationBonusTypeBiz = value;
            }
            get
            {
                return _MotivationBonusTypeBiz;
            }
        }        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerMotivationStatementBonusDb.MotivationBonusType = _MotivationBonusTypeBiz.ID;
            _ApplicantWorkerMotivationStatementBonusDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerMotivationStatementBonusDb.MotivationBonusType = _MotivationBonusTypeBiz.ID;
            _ApplicantWorkerMotivationStatementBonusDb.Edit();
        }
        public void Delete()
        {            
            _ApplicantWorkerMotivationStatementBonusDb.Delete();
        }
        #endregion
    }
}
