using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;


namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementEstimationStatementBiz
    {
        #region Private Data
        MotivationStatementEstimationStatementDb _MotivationStatementEstimationStatementDb;
        EstimationStatementBiz _EstimationStatementBiz;
        #endregion
        #region Constructors
        public MotivationStatementEstimationStatementBiz()
        {
            _MotivationStatementEstimationStatementDb = new MotivationStatementEstimationStatementDb();
            _EstimationStatementBiz = new EstimationStatementBiz();
        }
        public MotivationStatementEstimationStatementBiz(DataRow objDr)
        {
            _MotivationStatementEstimationStatementDb = new MotivationStatementEstimationStatementDb(objDr);
            _EstimationStatementBiz = new EstimationStatementBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatementEstimationStatementDb.MotivationStatement = value; } get { return _MotivationStatementEstimationStatementDb.MotivationStatement; } }
        public EstimationStatementBiz EstimationStatementBiz { set { _EstimationStatementBiz = value; } get { return _EstimationStatementBiz; } }
        public int OrderVal { set { _MotivationStatementEstimationStatementDb.OrderVal = value; } get { return _MotivationStatementEstimationStatementDb.OrderVal; } }
        public bool MainEstimation { set { _MotivationStatementEstimationStatementDb.MainEstimation = value; } get { return _MotivationStatementEstimationStatementDb.MainEstimation; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementEstimationStatementDb.EstimationStatement = EstimationStatementBiz.ID;
            _MotivationStatementEstimationStatementDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementEstimationStatementDb.EstimationStatement = EstimationStatementBiz.ID;
            _MotivationStatementEstimationStatementDb.Add();
        }
        #endregion
    }
}
