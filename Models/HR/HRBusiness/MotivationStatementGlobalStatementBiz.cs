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
    public class MotivationStatementGlobalStatementBiz
    {
        #region Private Data
        MotivationStatementGlobalStatementDb _MotivationStatementGlobalStatementDb;
        GlobalStatementBiz _GlobalStatementBiz;
        #endregion
        #region Constructors
        public MotivationStatementGlobalStatementBiz()
        {
            _MotivationStatementGlobalStatementDb = new MotivationStatementGlobalStatementDb();
            _GlobalStatementBiz = new GlobalStatementBiz();
        }
        public MotivationStatementGlobalStatementBiz(DataRow objDr)
        {
            _MotivationStatementGlobalStatementDb = new MotivationStatementGlobalStatementDb(objDr);
            _GlobalStatementBiz = new GlobalStatementBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatementGlobalStatementDb.MotivationStatement = value; } get { return _MotivationStatementGlobalStatementDb.MotivationStatement; } }
        public GlobalStatementBiz GlobalStatementBiz { set { _GlobalStatementBiz = value; } get { return _GlobalStatementBiz; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementGlobalStatementDb.GlobalStatement = GlobalStatementBiz.ID;
            _MotivationStatementGlobalStatementDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementGlobalStatementDb.GlobalStatement = GlobalStatementBiz.ID;
            _MotivationStatementGlobalStatementDb.Add();
        }
        #endregion
    }
}
