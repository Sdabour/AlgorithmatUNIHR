using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;

namespace AlgorithmatMN.MN.MNBiz
{
    public class PaymentStrategyConditionBiz
    {

        #region Constructor
        public PaymentStrategyConditionBiz()
        {
            _PaymentStrategyConditionDb = new PaymentStrategyConditionDb();
        }
        public PaymentStrategyConditionBiz(DataRow objDr)
        {
            _PaymentStrategyConditionDb = new PaymentStrategyConditionDb(objDr);
        }

        #endregion
        #region Private Data
        PaymentStrategyConditionDb _PaymentStrategyConditionDb;
        #endregion
        #region Properties
        public int Strategy
        {
            set
            {
                _PaymentStrategyConditionDb.Strategy = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.Strategy;
            }
        }
        public string Desc
        {
            set
            {
                _PaymentStrategyConditionDb.Desc = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.Desc;
            }
        }
        public double Perc
        {
            set
            {
                _PaymentStrategyConditionDb.Perc = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.Perc;
            }
        }
        public double DiscountPerc
        {
            set
            {
                _PaymentStrategyConditionDb.DiscountPerc = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.DiscountPerc;
            }
        }
        public int No
        {
            set
            {
                _PaymentStrategyConditionDb.No = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.No;
            }
        }
        public int MonthNo
        {
            set
            {
                _PaymentStrategyConditionDb.MonthNo = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.MonthNo;
            }
        }
        public int Allowance
        {
            set
            {
                _PaymentStrategyConditionDb.Allowance = value;
            }
            get
            {
                return _PaymentStrategyConditionDb.Allowance;
            }
        }
        PaymentStrategyBiz _StrategyBiz;
        public PaymentStrategyBiz StrategyBiz { set => _StrategyBiz = value;
            get { if (_StrategyBiz == null)
                    _StrategyBiz = new PaymentStrategyBiz();
                return _StrategyBiz;
            }
        }
        public CreditConditionBiz CreditConditionBiz
        { get
            {
                return new CreditConditionBiz() { };
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _PaymentStrategyConditionDb.Add();
        }
        public void Edit()
        {
            _PaymentStrategyConditionDb.Edit();
        }
        public void Delete()
        {
            _PaymentStrategyConditionDb.Delete();
        }
        #endregion
    }
}
