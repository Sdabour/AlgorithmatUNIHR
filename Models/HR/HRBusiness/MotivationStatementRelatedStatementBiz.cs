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
    public class MotivationStatementRelatedStatementBiz
    {
        #region Private Data
        MotivationStatementRelatedStatementDb _MotivationStatementRelatedStatementDb;
        MotivationStatementBiz _RelatedStatementBiz;
        #endregion
        #region Constructors
        public MotivationStatementRelatedStatementBiz()
        {
            _MotivationStatementRelatedStatementDb = new MotivationStatementRelatedStatementDb();
            _RelatedStatementBiz = new MotivationStatementBiz();
        }
        public MotivationStatementRelatedStatementBiz(DataRow objDr)
        {
            _MotivationStatementRelatedStatementDb = new MotivationStatementRelatedStatementDb(objDr);
            _RelatedStatementBiz = new MotivationStatementBiz(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatementRelatedStatementDb.MotivationStatement = value; } get { return _MotivationStatementRelatedStatementDb.MotivationStatement; } }
        public int OrderVal { set { _MotivationStatementRelatedStatementDb.OrderVal = value; } get { return _MotivationStatementRelatedStatementDb.OrderVal; } }
        public MotivationStatementBiz RelatedStatementBiz { set { _RelatedStatementBiz = value; } get { return _RelatedStatementBiz; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementRelatedStatementDb.RelatedStatement = RelatedStatementBiz.ID;
            _MotivationStatementRelatedStatementDb.Add();
        }
        public void Delete()
        {
            _MotivationStatementRelatedStatementDb.RelatedStatement = RelatedStatementBiz.ID;
            _MotivationStatementRelatedStatementDb.Delete();
        }
        #endregion
    }
}
