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
    public class FellowShipStatementBiz
    {
        #region Private Data
        FellowShipStatementDb _FellowShipStatementDb;
        FellowShipIncomeCol _IncomeCol;
        FellowShipPaymentCol _PaymentCol;
        #endregion
        #region Constructors
        public FellowShipStatementBiz()
        {
            _FellowShipStatementDb = new FellowShipStatementDb();
        }
        public FellowShipStatementBiz(DataRow objDr)
        {
            _FellowShipStatementDb = new FellowShipStatementDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID { set { _FellowShipStatementDb.ID = value; } get { return _FellowShipStatementDb.ID; } }
        public string StatementDesc { set { _FellowShipStatementDb.StatementDesc = value; } get { return _FellowShipStatementDb.StatementDesc; } }
        public DateTime DateFrom { set { _FellowShipStatementDb.DateFrom = value; } get { return _FellowShipStatementDb.DateFrom; } }
        public DateTime DateTo { set { _FellowShipStatementDb.DateTo = value; } get { return _FellowShipStatementDb.DateTo; } }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _FellowShipStatementDb.Add();
        }
        public void Edit()
        {
            _FellowShipStatementDb.Edit();
        }
        public void Delete()
        {
            _FellowShipStatementDb.Delete();
        }

        public FellowShipIncomeCol IncomeCol
        {
            get
            {
                if (_IncomeCol == null)
                {
                    _IncomeCol = new FellowShipIncomeCol(this);
                }
                return _IncomeCol;
            }
        }
        public FellowShipPaymentCol PaymentCol
        {
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new FellowShipPaymentCol(this);
                }
                return _PaymentCol;
            }
        }
        #endregion
    }
}
