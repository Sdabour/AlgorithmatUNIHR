using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMN.MN.MNDb
{
    public class PaymentStrategyDb
    {

        #region Constructor
        public PaymentStrategyDb()
        {
        }
        public PaymentStrategyDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        string _Desc;
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        int _Year;
        public int Year
        {
            set
            {
                _Year = value;
            }
            get
            {
                return _Year;
            }
        }
        DateTime _StartDate;
        public DateTime StartDate
        { set => _StartDate = value; get => _StartDate; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; get => _EndDate; }
        bool _IsEnded;
        public bool IsEnded { get => _IsEnded; }
        string _Project;
        public string Project
        {
            set
            {
                _Project = value;
            }
            get
            {
                return _Project;
            }
        }
        int _MonthCount;
        public int MonthCount
        {
            set
            {
                _MonthCount = value;
            }
            get
            {
                return _MonthCount;
            }
        }
        double _Discount;
        public double Discount
        {
            set
            {
                _Discount = value;
            }
            get
            {
                return _Discount;
            }
        }
        double _DownPayment;
        public double DownPayment
        {
            set
            {
                _DownPayment = value;
            }
            get
            {
                return _DownPayment;
            }
        }
        double _TotalDiscountPerc;
        public double TotalDiscountPerc
        {
            set
            {
                _TotalDiscountPerc = value;
            }
            get
            {
                return _TotalDiscountPerc;
            }
        }
        int _ConditionCount;
        public int ConditionCount { get => _ConditionCount; }
        double _ConditionValue;
        public double ConditionValue { get => _ConditionValue; }
        double _MinValue;
        public double MinValue
        {
            set
            {
                _MinValue = value;
            }
            get
            {
                return _MinValue;
            }
        }
        double _MaxValue;
        public double MaxValue
        {
            set
            {
                _MaxValue = value;
            }
            get
            {
                return _MaxValue;
            }
        }
        public string AddStr
        {
            get
            {
                string strEndDate = "NULL";
                if (_EndDate != null && _EndDate > DateTime.Now)
                    strEndDate = (_EndDate.ToOADate() - 2).ToString();
                string Returned = " insert into MNPaymentStrategy (StrategyDesc,StrategyYear,StrategyStartDate, StrategyEndDate,StrategyProject,StrategyMonthCount,StrategyDiscount,StrategyMinValue,StrategyMaxValue,UsrIns,TimIns) values ('" + Desc + "'," + Year + ",GetDate()," + strEndDate + ",'" + Project + "'," + MonthCount + "," + Discount + "," + MinValue + "," + MaxValue + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNPaymentStrategy set StrategyDesc='" + Desc + "'" +
           ",StrategyYear=" + Year + "" +
           // ",StrategyStartDate="+_StartDate.Date.ToOADate()+
           ", StrategyEndDate=" + _EndDate.Date.ToOADate() +
           ",StrategyProject='" + Project + "'" +
           ",StrategyMonthCount=" + MonthCount + "" +
           ",StrategyDiscount=" + Discount + "" +
           ",StrategyMinValue=" + MinValue + "" +
           ",StrategyMaxValue=" + MaxValue + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where StrategyID=" + ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNPaymentStrategy set Dis = GetDate() where  StrategyID=" + ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strTotalDiscountPerc = @"SELECT ConditionStrategy, SUM((ConditionPerc / 100) * (ConditionDiscountPerc / 100) * 100) AS TotalDiscountPerc
FROM     dbo.MNPaymentStrategyCondition
GROUP BY ConditionStrategy ";
                string strDownPayment = @"SELECT ConditionStrategy, SUM((1 - ConditionDiscountPerc / 100) * ConditionPerc) AS DownPaymentPerc
FROM     dbo.MNPaymentStrategyCondition
GROUP BY ConditionStrategy, ConditionMonthNo
HAVING (ConditionMonthNo = 0)";
                string strCondition = @"SELECT ConditionStrategy, COUNT(*) AS ConditionCount, MIN((1 - ConditionDiscountPerc / 100) * ConditionPerc) AS ConditionValue
FROM     dbo.MNPaymentStrategyCondition
WHERE  (ConditionMonthNo > 0)
GROUP BY ConditionStrategy";
                string Returned = @" select StrategyID,StrategyDesc,StrategyYear,StrategyStartDate, StrategyEndDate,StrategyProject,StrategyMonthCount,StrategyDiscount,StrategyMinValue,StrategyMaxValue,DownPaymentTable.DownPaymentPerc,DiscountTable.TotalDiscountPerc,ConditionTable.ConditionCount,ConditionTable.ConditionValue  
  from MNPaymentStrategy 
 left outer join (" + strDownPayment + @") as DownPaymentTable
   on MNPaymentStrategy.StrategyID = DownPaymentTable.ConditionStrategy 
   left outer join (" + strTotalDiscountPerc + @") as DiscountTable
   on MNPaymentStrategy.StrategyID = DiscountTable.ConditionStrategy 
   left outer join (" + strCondition + @") as ConditionTable
   on MNPaymentStrategy.StrategyID = ConditionTable.ConditionStrategy";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["StrategyID"] != null)
                int.TryParse(objDr["StrategyID"].ToString(), out _ID);

            if (objDr.Table.Columns["StrategyDesc"] != null)
                _Desc = objDr["StrategyDesc"].ToString();

            if (objDr.Table.Columns["StrategyYear"] != null)
                int.TryParse(objDr["StrategyYear"].ToString(), out _Year);

            if (objDr.Table.Columns["StrategyStartDate"] != null)
                DateTime.TryParse(objDr["StrategyStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["StrategyEndDate"] != null)
                if (DateTime.TryParse(objDr["StrategyEndDate"].ToString(), out _EndDate) && _EndDate < DateTime.Now)
                    _IsEnded = true;

            if (objDr.Table.Columns["StrategyProject"] != null)
                _Project = objDr["StrategyProject"].ToString();

            if (objDr.Table.Columns["StrategyMonthCount"] != null)
                int.TryParse(objDr["StrategyMonthCount"].ToString(), out _MonthCount);

            if (objDr.Table.Columns["StrategyDiscount"] != null)
                double.TryParse(objDr["StrategyDiscount"].ToString(), out _Discount);

            if (objDr.Table.Columns["StrategyMinValue"] != null)
                double.TryParse(objDr["StrategyMinValue"].ToString(), out _MinValue);

            if (objDr.Table.Columns["StrategyMaxValue"] != null)
                double.TryParse(objDr["StrategyMaxValue"].ToString(), out _MaxValue);
            if (objDr.Table.Columns["DownPaymentPerc"] != null)
                double.TryParse(objDr["DownPaymentPerc"].ToString(), out _DownPayment);
            if (objDr.Table.Columns["TotalDiscountPerc"] != null)
                double.TryParse(objDr["TotalDiscountPerc"].ToString(), out _TotalDiscountPerc);
            if (objDr.Table.Columns["ConditionValue"] != null)
                double.TryParse(objDr["ConditionValue"].ToString(), out _ConditionValue);
            if (objDr.Table.Columns["ConditionCount"] != null)
                int.TryParse(objDr["ConditionCount"].ToString(), out _ConditionCount);
        }
        DataTable _ConditionTable;
        public DataTable ConditionTable
        {
            set => _ConditionTable = value;
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinCondition();
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinCondition();
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
            if (_ID != 0)
                strSql += " and StrategyID=" + _ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinCondition()
        {
            if (_ConditionTable == null || _ConditionTable.Rows.Count == 0)
                return;

            PaymentStrategyConditionDb objCondition;
            List<string> arrStr = new List<string>();
            arrStr.Add(@"delete from   dbo.MNPaymentStrategyCondition
WHERE(ConditionStrategy = " + _ID + ")");
            foreach (DataRow objDr in _ConditionTable.Rows)
            {
                objCondition = new PaymentStrategyConditionDb(objDr);
                objCondition.Strategy = ID;
                if (objCondition.Perc > 0)
                    arrStr.Add(objCondition.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
    }
}
