using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class TempSchedulingBiz
    {

        #region Constructor
        public TempSchedulingBiz()
        {
            _TempSchedulingDb = new TempSchedulingDb();
        }
        public TempSchedulingBiz(DataRow objDr)
        {
            _TempSchedulingDb = new TempSchedulingDb(objDr);
        }
        public TempSchedulingBiz(int intID)
        {
            _TempSchedulingDb = new TempSchedulingDb();
            if(intID>0)
            {
                TempSchedulingDb objDb = new TempSchedulingDb() { ID = intID };
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count > 0)
                    _TempSchedulingDb = new TempSchedulingDb(dtTemp.Rows[0]);
            }
        }
        #endregion
        #region Private Data
        TempSchedulingDb _TempSchedulingDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _TempSchedulingDb.ID = value;
            }
            get
            {
                return _TempSchedulingDb.ID;
            }
        }
        public int RO
        {
            set
            {
                _TempSchedulingDb.RO = value;
            }
            get
            {
                return _TempSchedulingDb.RO;
            }
        }
        public int Strategy
        {
            set
            {
                _TempSchedulingDb.Strategy = value;
            }
            get
            {
                return _TempSchedulingDb.Strategy;
            }
        }
        public int Credit
        {
            set
            {
                _TempSchedulingDb.Credit = value;
            }
            get
            {
                return _TempSchedulingDb.Credit;
            }
        }
        public double AdvancedValue
        {
            set
            {
                _TempSchedulingDb.AdvancedValue = value;
            }
            get
            {
                return _TempSchedulingDb.AdvancedValue;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _TempSchedulingDb.StartDate = value;
            }
            get
            {
                return _TempSchedulingDb.StartDate;
            }
        }
        public string TempPaymentRef
        {  get => _TempSchedulingDb.TempPaymentRef; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _TempSchedulingDb.Add();
        }
        public void Edit()
        {
            _TempSchedulingDb.Edit();
        }
        public void Delete()
        {
            _TempSchedulingDb.Delete();
        }
        #endregion
    }
}