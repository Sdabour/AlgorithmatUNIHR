using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementExchangeBiz
    {
        #region Private Data
        ApplicantWorkerStatementExchangeDb _ApplicantWorkerStatementExchangeDb;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementExchangeBiz()
        {
            _ApplicantWorkerStatementExchangeDb = new ApplicantWorkerStatementExchangeDb();
        }
        public ApplicantWorkerStatementExchangeBiz(DataRow objDr)
        {
            _ApplicantWorkerStatementExchangeDb = new ApplicantWorkerStatementExchangeDb(objDr);
        }
     
        #endregion
        #region Public Properties
        public int OriginStatement { set { _ApplicantWorkerStatementExchangeDb.OriginStatement = value; } get { return _ApplicantWorkerStatementExchangeDb.OriginStatement; } }
        public int GlobalStatementPayment { set { _ApplicantWorkerStatementExchangeDb.GlobalStatementPayment = value; } get { return _ApplicantWorkerStatementExchangeDb.GlobalStatementPayment; } }
        public double ExchangeValue { set { _ApplicantWorkerStatementExchangeDb.ExchangeValue = value; } get { return _ApplicantWorkerStatementExchangeDb.ExchangeValue; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _ApplicantWorkerStatementExchangeDb.Add();
        }
        public void Edit()
        {
            _ApplicantWorkerStatementExchangeDb.Edit();
        }
        public void Delete()
        {
            _ApplicantWorkerStatementExchangeDb.Delete();
        }
        #endregion
    }
}
