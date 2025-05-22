using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class PaymentStrategyConditionDb
    {

        #region Constructor
        public PaymentStrategyConditionDb()
        {
        }
        public PaymentStrategyConditionDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _Strategy;
        public int Strategy
        {
            set
            {
                _Strategy = value;
            }
            get
            {
                return _Strategy;
            }
        }
        string _StrategyIDs;
        public string StrategyIDs { set => _StrategyIDs = value; }
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
        double _Perc;
        public double Perc
        {
            set
            {
                _Perc = value;
            }
            get
            {
                return _Perc;
            }
        }
        int _No;
        public int No
        {
            set
            {
                _No = value;
            }
            get
            {
                return _No;
            }
        }
        int _MonthNo;
        public int MonthNo
        {
            set
            {
                _MonthNo = value;
            }
            get
            {
                return _MonthNo;
            }
        }

        int _Allowance;
        public int Allowance
        { set => _Allowance = value; get => _Allowance; }
        double _DiscountPerc;
        public double DiscountPerc
        { set => _DiscountPerc = value; get => _DiscountPerc; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNPaymentStrategyCondition (ConditionStrategy,ConditionDesc,ConditionPerc,ConditionNo,ConditionMonthNo,ConditionAllowance,ConditionDiscountPerc) values (" + Strategy + ",'" + Desc + "'," + Perc + "," + No + "," + MonthNo+","+_Allowance+","+_DiscountPerc + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNPaymentStrategyCondition set " + "ConditionStrategy=" + Strategy + "" +
           ",ConditionDesc='" + Desc + "'" +
           ",ConditionPerc=" + Perc + "" +
           ",ConditionNo=" + No + "" +
           ",ConditionMonthNo=" + MonthNo + "" 
           + ",ConditionAllowance="+_Allowance
           + ",ConditionDiscountPerc="+_DiscountPerc
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNPaymentStrategyCondition set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select ConditionStrategy,ConditionDesc,ConditionPerc,ConditionNo,ConditionMonthNo,ConditionAllowance,ConditionDiscountPerc from MNPaymentStrategyCondition  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ConditionStrategy"] != null)
                int.TryParse(objDr["ConditionStrategy"].ToString(), out _Strategy);

            if (objDr.Table.Columns["ConditionDesc"] != null)
                _Desc = objDr["ConditionDesc"].ToString();

            if (objDr.Table.Columns["ConditionPerc"] != null)
                double.TryParse(objDr["ConditionPerc"].ToString(), out _Perc);

            if (objDr.Table.Columns["ConditionNo"] != null)
                int.TryParse(objDr["ConditionNo"].ToString(), out _No);

            if (objDr.Table.Columns["ConditionMonthNo"] != null)
                int.TryParse(objDr["ConditionMonthNo"].ToString(), out _MonthNo);
            if (objDr.Table.Columns["ConditionAllowance"] != null)
                int.TryParse(objDr["ConditionAllowance"].ToString(), out _Allowance);
            if (objDr.Table.Columns["ConditionDiscountPerc"] != null)
                double.TryParse(objDr["ConditionDiscountPerc"].ToString(), out _DiscountPerc);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";

            if (_Strategy != 0)
                strSql += " and ConditionStrategy = "+_Strategy;
            if (_StrategyIDs != null && _StrategyIDs!= "")
                strSql += " and ConditionStrategy in (" + _StrategyIDs +")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
