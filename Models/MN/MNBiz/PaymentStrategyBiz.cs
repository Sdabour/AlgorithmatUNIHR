using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class PaymentStrategyBiz
    {

        #region Constructor
        public PaymentStrategyBiz()
        {
            _PaymentStrategyDb = new PaymentStrategyDb();
        }
        public PaymentStrategyBiz(int intID)
        {
            _PaymentStrategyDb = new PaymentStrategyDb();
            if (intID == 0)
            {
                return;
            }
            PaymentStrategyDb objDb = new PaymentStrategyDb() { ID = intID };
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                _PaymentStrategyDb = new PaymentStrategyDb(dtTemp.Rows[0]);
        }
        public PaymentStrategyBiz(DataRow objDr)
        {
            _PaymentStrategyDb = new PaymentStrategyDb(objDr);
        }

        #endregion
        #region Private Data
        PaymentStrategyDb _PaymentStrategyDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _PaymentStrategyDb.ID = value;
            }
            get
            {
                return _PaymentStrategyDb.ID;
            }
        }
        public string Desc
        {
            set
            {
                _PaymentStrategyDb.Desc = value;
            }
            get
            {
                return _PaymentStrategyDb.Desc;
            }
        }
        public int Year
        {
            set
            {
                _PaymentStrategyDb.Year = value;
            }
            get
            {
                return _PaymentStrategyDb.Year;
            }
        }
        public DateTime StartDate { set => _PaymentStrategyDb.StartDate = value; get => _PaymentStrategyDb.StartDate; }
        public DateTime EndDate { set => _PaymentStrategyDb.EndDate = value; get => _PaymentStrategyDb.EndDate; }
        public bool IsEnded { get => _PaymentStrategyDb.IsEnded; }
        public string Project
        {
            set
            {
                _PaymentStrategyDb.Project = value;
            }
            get
            {
                return _PaymentStrategyDb.Project == null ? "" : _PaymentStrategyDb.Project;
            }
        }
        public int MonthCount
        {
            set
            {
                _PaymentStrategyDb.MonthCount = value;
            }
            get
            {
                return _PaymentStrategyDb.MonthCount;
            }
        }
        public double Discount
        {
            set
            {
                _PaymentStrategyDb.Discount = value;
            }
            get
            {
                return _PaymentStrategyDb.Discount;
            }
        }
        public double MinValue
        {
            set
            {
                _PaymentStrategyDb.MinValue = value;
            }
            get
            {
                return _PaymentStrategyDb.MinValue;
            }
        }
        public double MaxValue
        {
            set
            {
                _PaymentStrategyDb.MaxValue = value;
            }
            get
            {
                return _PaymentStrategyDb.MaxValue;
            }
        }
        public double DownPaymentPerc
        {
            get => _PaymentStrategyDb.DownPayment;
        }
        public double TotalDiscountPerc
        {
            get => _PaymentStrategyDb.TotalDiscountPerc;
        }
        public double ConditionValue
        {
            get => _PaymentStrategyDb.ConditionValue;
        }
        public int ConditionCount
        {
            get => _PaymentStrategyDb.ConditionCount;
        }
        PaymentStrategyConditionCol _ConditionCol;
        public PaymentStrategyConditionCol ConditionCol
        {
            set => _ConditionCol = value;
            get
            {
                if (_ConditionCol == null)
                    _ConditionCol = new PaymentStrategyConditionCol(true);

                return _ConditionCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _PaymentStrategyDb.ConditionTable = ConditionCol.GetTable();
            _PaymentStrategyDb.Add();
        }
        public void Edit()
        {
            _PaymentStrategyDb.ConditionTable = ConditionCol.GetTable();
            _PaymentStrategyDb.Edit();
        }
        public void Delete()
        {
            _PaymentStrategyDb.Delete();
        }
        public double GetDiscount(ROBiz objRoBiz)
        {
            double Returned = objRoBiz.ValueToBeDevided * TotalDiscountPerc / 100;
            return Returned;
        }
        public double GetConditionValue(ROBiz objRoBiz)
        {
            double Returned = objRoBiz.ValueToBeDevided * ConditionValue / 100;
            return Returned;
        }
        public double GetDownPayment(ROBiz objRoBiz)
        {
            double Returned = objRoBiz.ValueToBeDevided * DownPaymentPerc / 100;
            return Returned;
        }
        #endregion
    }
}
