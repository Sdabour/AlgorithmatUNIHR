using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditBiz
    {

        #region Constructor
        public CreditBiz()
        {
            _CreditDb = new CreditDb();
        }
        public CreditBiz(DataRow objDr)
        {
            _CreditDb = new CreditDb(objDr);
            _ROBiz = new ROBiz(objDr);
            _StartegyBiz = new PaymentStrategyBiz(objDr);
        }
        public CreditBiz(int intCredit)
        {
           
            _CreditDb = new CreditDb();
            DataTable dtTemp = new CreditDb() { ID = intCredit }.Search();
            if (dtTemp.Rows.Count > 0)
            {
                _CreditDb = new CreditDb(dtTemp.Rows[0]);
                _ROBiz = new ROBiz(dtTemp.Rows[0]);
                _StartegyBiz = new PaymentStrategyBiz(dtTemp.Rows[0]);
            }

        }
        #endregion
        #region Private Data
        CreditDb _CreditDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _CreditDb.ID = value;
            }
            get
            {
                return _CreditDb.ID;
            }
        }
        public int RO
        {
            set
            {
                _CreditDb.RO = value;
            }
            get
            {
                return _CreditDb.RO;
            }
        }
        public int Year
        {
            set
            {
                _CreditDb.Year = value;
            }
            get
            {
                return _CreditDb.Year;
            }
        }
        ProjectYearBiz _YearBiz;
        public ProjectYearBiz YearBiz
        { set => _YearBiz = value;
            get 
            {
                if (_YearBiz == null) { _YearBiz = new ProjectYearBiz() { Year = Year, ProjectCode = ROBiz.ProjectCode }; }
                return _YearBiz;
            }
        }
        public string Key { get => RO.ToString() + "-" + Year.ToString(); }
        public DateTime StartDate
        {
            set
            {
                _CreditDb.StartDate = value;
            }
            get
            {
                return _CreditDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _CreditDb.EndDate = value;
            }
            get
            {
                return _CreditDb.EndDate;
            }
        }
        public double CrditInitialValue
        {
            set
            {
                _CreditDb.CrditInitialValue = value;
            }
            get
            {
                return _CreditDb.CrditInitialValue;
            }
        }
        public double BonusValue
        {
            set
            {
                _CreditDb.BonusValue = value;
            }
            get
            {
                int intDays =YearBiz.Year >0? (new DateTime(YearBiz.Year, 12, 31).Subtract(new DateTime(YearBiz.Year, 1, 1)).Days+1):0;
                return ID != 0 ? _CreditDb.BonusValue : (
                    (CrditInitialValue - Cost) <= 0 ? 0 :
                    ((CrditInitialValue - Cost) * Days / intDays) * (ROBiz.MaintainanceBonusPercPerYear / 100));
            }
        }
        public double PaymentValue
        {
            set
            {
                _CreditDb.PaymentValue = value;
            }
            get
            {

                return ID != 0 ? _CreditDb.PaymentValue : PaymentCol.TotalValue;
            }
        }
        public double DiscountValue
        {
            set
            {
                _CreditDb.DiscountValue = value;
            }
            get
            {
                return ID != 0 ? _CreditDb.DiscountValue : DiscountCol.TotalValue;
            }
        }

        public double Cost
        {
            set
            {
                _CreditDb.Cost = value;
            }
            get
            {
                //if(ID!= 0)

                return _CreditDb.Cost;
            }
        }
        public double Closing { get => ROBiz.Occupied ? 0 : CrditInitialValue + PaymentValue+DiscountValue + BonusValue - Cost; }
       
        public double CostDiff { get => Cost - BonusValue > 0 ? Cost - BonusValue : 0; }
        ROBiz _ROBiz;
        public ROBiz ROBiz
        { set => _ROBiz = value;
            get
            { if (_ROBiz == null)
                    _ROBiz = new ROBiz();
                return _ROBiz;
            } }
        public double Days
        {
            get
            {
                return EndDate.Subtract(StartDate).Days + 1;
            }
        }
        public double CostPart
        {
            get
            {
                return ROBiz.TypeWeight * Days * (double)ROBiz.Area;
            }
        }
        public double LastDueValue
        {
            get
            {
                double dblCLosing = ((CrditInitialValue > ROBiz.InitialMaintainanceValue ? CrditInitialValue : 0) - Cost + BonusValue);
                double Returned = dblCLosing > 0 ? 0 : -1 * dblCLosing;
                if (ROBiz.Occupied)
                    Returned = 0;
                return Returned;

            }
        }
        MaintainanceDiscountCol _DiscountCol;
        public MaintainanceDiscountCol DiscountCol
        {
            set => _DiscountCol = value;
            get
            {
                if (_DiscountCol == null)
                    _DiscountCol = new MaintainanceDiscountCol(true);
                return _DiscountCol;
            }
        }
        MaintainancePaymentCol _PaymentCol;
        public MaintainancePaymentCol PaymentCol
        { set => _PaymentCol = value;
            get
            {
                if (_PaymentCol == null)
                    _PaymentCol = new MaintainancePaymentCol(true);
                return _PaymentCol;
            }
        }
        ROCostCol _CostCol;
        public ROCostCol ROCostCol
        {
            set => _CostCol = value;
            get {
                if (_CostCol == null)
                {
                    _CostCol = new ROCostCol(true);
                }
                return _CostCol;
            }
        }
        CreditConditionCol _ConditionCol;
        public CreditConditionCol ConditionCol
        { set => _ConditionCol = value;
            get
            {
                if (_ConditionCol == null)
                    _ConditionCol = new CreditConditionCol(true);
                return _ConditionCol;
            }
        }
        public DateTime StrategyStartDate
        { set => _CreditDb.StrategyStartDate = value;
            get => _CreditDb.StrategyStartDate;
        }
        public double StrategyDiscountValue
        {
            set => _CreditDb.StrategyDiscountValue = value;
            get => _CreditDb.StrategyDiscountValue;
        }
        PaymentStrategyBiz _StartegyBiz;
        public PaymentStrategyBiz StrategyBiz
        { set => _StartegyBiz = value;
            get
            {
                if (_StartegyBiz == null)
                    _StartegyBiz = new PaymentStrategyBiz();
                return _StartegyBiz;
            }
        }
        
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _CreditDb.BonusValue = BonusValue;
            _CreditDb.Add();
        }
        public void Edit()
        {
            _CreditDb.Edit();
        }
        public void Delete()
        {
            _CreditDb.Delete();
        }
        public CreditConditionCol GetConditionCol(double dblDownPayment, DateTime dtStart, PaymentStrategyBiz objStrategyBiz, bool blIgnoreStrategyAdvanced)
        {
            CreditConditionCol Returned = new CreditConditionCol(true);
            if (ID == 0 || objStrategyBiz == null || objStrategyBiz.ID == 0)
                return Returned;
            double dblValue = 0;
            double dblRemaining = 0;
            double dblNewAdvancedPerc = 0;
            double dblPerc = 0;
            double dblPercDiff = 0;
            foreach (PaymentStrategyConditionBiz objCondition in objStrategyBiz.ConditionCol)
            {
                //dblRemaining = (-1 * Closing) - ((objStrategyBiz.Discount*(-1*Closing))/100) - Returned.TotalValue;
                dblRemaining = ROBiz.ValueToBeDevided - Returned.TotalValue;
                if (Closing > 0 ||
                    dblRemaining <= 0)
                    break;
                //dblValue = (-1 * Closing * objCondition.Perc) / 100;

                dblValue = (ROBiz.ValueToBeDevided * objCondition.Perc) / 100;
                //Here adjust the condition to fit the downpayment
                dblPerc = objCondition.Perc;
                if (objCondition.MonthNo == 0 && ((dblDownPayment > (dblValue * (100 - objCondition.DiscountPerc) / 100) + 1) || blIgnoreStrategyAdvanced))
                {
                    dblValue = dblDownPayment * 100 / (100 - objCondition.DiscountPerc);
                    dblNewAdvancedPerc = (dblValue / ROBiz.ValueToBeDevided) * 100;
                    dblPerc = dblNewAdvancedPerc;
                    dblPercDiff = dblNewAdvancedPerc - objCondition.Perc;
                }


                if (objCondition.MonthNo > 0 && dblPercDiff > 0)
                {
                    dblPerc = objCondition.Perc - dblPercDiff * (objCondition.Perc / 100);
                    dblValue = (ROBiz.ValueToBeDevided * dblPerc) / 100;
                }
                dblValue = dblValue > dblRemaining ? dblRemaining : dblValue;
                dtStart = dtStart.AddMonths(objCondition.MonthNo);
                Returned.Add(new CreditConditionBiz() { CreditBiz = this, Credit = ID, Desc = objCondition.Desc, DueDate = dtStart, No = objCondition.No, Perc = dblPerc, Strategy = objStrategyBiz.ID, Value = double.Parse(dblValue.ToString("0")), Allowance = objCondition.Allowance, DiscountPerc = objCondition.DiscountPerc });
            }
            if (Returned.Count > 0)
            {
                Returned[Returned.Count - 1].Value += _ROBiz.ValueToBeDevided - Returned.TotalValue;
                Returned[Returned.Count - 1].Value = double.Parse(Returned[Returned.Count - 1].Value.ToString("0"));

            }
            return Returned;
        }
        public void SaveStrategy()
        {
            _CreditDb.StrategyID = StrategyBiz.ID;
            _CreditDb.ConditionTable = ConditionCol.GetTable();
            _CreditDb.AddStrategy();
           
        }
        public void SetConditionCol()
        {
            CreditConditionDb objDb = new CreditConditionDb() { Credit = ID };
            DataTable dtTemp = objDb.Search();
            _ConditionCol = new CreditConditionCol(true);
            foreach(DataRow objDr in dtTemp.Rows)
            {
                _ConditionCol.Add(new CreditConditionBiz(objDr));
            }
        }

        #endregion
    }
}
