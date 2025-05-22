using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditConditionBiz
    {

        #region Constructor
        public CreditConditionBiz()
        {
            _CreditConditionDb = new CreditConditionDb();
        }
        public CreditConditionBiz(DataRow objDr)
        {
            _CreditConditionDb = new CreditConditionDb(objDr);
            _CreditBiz = new CreditBiz(objDr);
        }
        public CreditConditionBiz(int intID)
        {
            _CreditConditionDb = new CreditConditionDb();
            if (intID != 0)
            {
                CreditConditionDb objDb = new CreditConditionDb() { ID = intID };
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count > 0)
                {
                    _CreditConditionDb = new CreditConditionDb(dtTemp.Rows[0]);
                    _CreditBiz = new CreditBiz(dtTemp.Rows[0]);

                }

            }
        }
        #endregion
        #region Private Data
        CreditConditionDb _CreditConditionDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _CreditConditionDb.ID = value;
            }
            get
            {
                return _CreditConditionDb.ID;
            }
        }
        public int Credit
        {
            set
            {
                _CreditConditionDb.Credit = value;
            }
            get
            {
                return _CreditConditionDb.Credit;
            }
        }
        
        public int Strategy
        {
            set
            {
                _CreditConditionDb.Strategy = value;
            }
            get
            {
                return _CreditConditionDb.Strategy;
            }
        }
        public string Desc
        {
            set
            {
                _CreditConditionDb.Desc = value;
            }
            get
            {
                return _CreditConditionDb.Desc;
            }
        }
        public double Perc
        {
            set
            {
                _CreditConditionDb.Perc = value;
            }
            get
            {
                return _CreditConditionDb.Perc;
            }
        }
        public int No
        {
            set
            {
                _CreditConditionDb.No = value;
            }
            get
            {
                return _CreditConditionDb.No;
            }
        }
        public DateTime DueDate
        {
            set
            {
                _CreditConditionDb.DueDate = value;
            }
            get
            {
                return _CreditConditionDb.DueDate;
            }
        }
        public double Value
        {
            set
            {
                _CreditConditionDb.Value = value;
            }
            get
            {
                return _CreditConditionDb.Value;
            }
        }
        public int Allowance
        {
            set
            {
                _CreditConditionDb.Allowance = value;
            }
            get
            {
                return _CreditConditionDb.Allowance;
            }
        }
        public double DiscountPerc
        {
            set
            {
                _CreditConditionDb.DiscountPerc = value;
            }
            get
            {
                return _CreditConditionDb.DiscountPerc;
            }
        }

        public double TotalPaidValue
        {
           
            get
            {
                return _CreditConditionDb.TotalPaidValue;
            }
        }
        public double TotalDiscountValue
        {
            
            get
            {
                return _CreditConditionDb.TotalDiscountValue;
            }
        }
        public double RemainingValue
        { get => Math.Abs(Value - TotalPaidValue - TotalDiscountValue); }
        public double RecommendedValue
        { get
            {
                double Returned = RemainingValue;
                double dblDiscount = 0;
                if(Returned>1 && DateTime.Now.Date.Subtract(DueDate.Date).Days<=Allowance)
                {
                    dblDiscount = DiscountPerc * Value / 100;
                }
                Returned -= dblDiscount;
                return Returned;
            } }
        CreditBiz _CreditBiz;
        public CreditBiz CreditBiz
        { set => _CreditBiz = value;
        get
            { if (_CreditBiz == null)
                    _CreditBiz = new CreditBiz();
                return _CreditBiz;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _CreditConditionDb.Add();
        }
        public void Edit()
        {
            _CreditConditionDb.Edit();
        }
        public void Delete()
        {
            _CreditConditionDb.Delete();
        }
        #endregion
    }
}
