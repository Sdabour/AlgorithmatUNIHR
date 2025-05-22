using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class CreditConditionDb
    {

        #region Constructor
        public CreditConditionDb()
        {
        }
        public CreditConditionDb(DataRow objDr)
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
        int _Credit;
        public int Credit
        {
            set
            {
                _Credit = value;
            }
            get
            {
                return _Credit;
            }
        }
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
        DateTime _DueDate;
        public DateTime DueDate
        {
            set
            {
                _DueDate = value;
            }
            get
            {
                return _DueDate;
            }
        }
        double _Value;
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        int _Allowance;
        public int Allowance
        { set => _Allowance = value; get => _Allowance; }
        double _DiscountPerc;
        public double DiscountPerc
        { set => _DiscountPerc = value; get => _DiscountPerc; }
        double _TotalPaidValue;
        public double TotalPaidValue
        { get => _TotalPaidValue; }
        double _TotalDiscountValue;
        public double TotalDiscountValue { get => _TotalDiscountValue; }
        string _ROIDs;
        public string ROIDs
        {
            set => _ROIDs = value;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCreditCondition (ConditionCredit,ConditionStrategy,ConditionDesc,ConditionPerc,ConditionNo,ConditionDueDate,ConditionValue,ConditionAllowance,ConditionDiscountPerc,UsrIns,TimIns) values (" + Credit + "," + Strategy + ",'" + Desc + "'," + Perc + "," + No + "," + (DueDate.ToOADate() - 2).ToString() + "," + Value +"," + _Allowance+"," +_DiscountPerc + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCreditCondition set " + "ConditionID=" + ID + "" +
           ",ConditionCredit=" + Credit + "" +
           ",ConditionStrategy=" + Strategy + "" +
           ",ConditionDesc='" + Desc + "'" +
           ",ConditionPerc=" + Perc + "" +
           ",ConditionNo=" + No + "" +
           ",ConditionDueDate=" + (DueDate.ToOADate() - 2).ToString() + "" +
           ",ConditionValue=" + Value + "" 
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
                string Returned = " update MNROCreditCondition set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strPayment = @"SELECT dbo.MNROCreditCondition.ConditionID, SUM(dbo.GLPayment.PaymentValue) AS ConditionPaidValue
FROM     dbo.MNROCreditCondition INNER JOIN
                  dbo.MNROCreditConditionPayment ON dbo.MNROCreditCondition.ConditionID = dbo.MNROCreditConditionPayment.ConditionID INNER JOIN
                  dbo.MNROCreditPayment ON dbo.MNROCreditConditionPayment.PaymentID = dbo.MNROCreditPayment.PaymentID INNER JOIN
                  dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID
GROUP BY dbo.MNROCreditCondition.ConditionID ";
                string strDiscount = @"SELECT dbo.MNROCreditCondition.ConditionID, SUM(dbo.MNROCreditDiscount.CreditDiscountValue) AS ConditionDiscountValue
FROM     dbo.MNROCreditCondition INNER JOIN
                  dbo.MNROCreditConditionDiscount ON dbo.MNROCreditCondition.ConditionID = dbo.MNROCreditConditionDiscount.ConditionID INNER JOIN
                  dbo.MNROCreditDiscount ON dbo.MNROCreditConditionDiscount.DiscountID = dbo.MNROCreditDiscount.CreditDiscountID
GROUP BY dbo.MNROCreditCondition.ConditionID";
                string Returned = @" select MNROCreditCondition.ConditionID,MNROCreditCondition.ConditionCredit,ConditionStrategy,MNROCreditCondition.ConditionDesc,MNROCreditCondition.ConditionPerc,MNROCreditCondition.ConditionNo,MNROCreditCondition.ConditionDueDate,MNROCreditCondition.ConditionValue,ConditionAllowance,ConditionDiscountPerc,isnull(PaymentTable.ConditionPaidValue,0) as ConditionPaidValue ,isnull(DiscountTable.ConditionDiscountValue,0) as ConditionDiscountValue,CreditTable.*    
  from MNROCreditCondition  
   INNER JOIN
                (" + new CreditDb().SearchStr +@") as CreditTable ON dbo.MNROCreditCondition.ConditionCredit = CreditTable.CreditID 
  left outer join (" + strPayment+ @") as PaymentTable 
  on MNROCreditCondition.ConditionID = PaymentTable.ConditionID
 left outer join ("+strDiscount+@") as DiscountTable 
   on MNROCreditCondition.ConditionID = DiscountTable.ConditionID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ConditionID"] != null)
                int.TryParse(objDr["ConditionID"].ToString(), out _ID);

            if (objDr.Table.Columns["ConditionCredit"] != null)
                int.TryParse(objDr["ConditionCredit"].ToString(), out _Credit);

            if (objDr.Table.Columns["ConditionStrategy"] != null)
                int.TryParse(objDr["ConditionStrategy"].ToString(), out _Strategy);

            if (objDr.Table.Columns["ConditionDesc"] != null)
                _Desc = objDr["ConditionDesc"].ToString();

            if (objDr.Table.Columns["ConditionPerc"] != null)
                double.TryParse(objDr["ConditionPerc"].ToString(), out _Perc);

            if (objDr.Table.Columns["ConditionNo"] != null)
                int.TryParse(objDr["ConditionNo"].ToString(), out _No);

            if (objDr.Table.Columns["ConditionDueDate"] != null)
                DateTime.TryParse(objDr["ConditionDueDate"].ToString(), out _DueDate);

            if (objDr.Table.Columns["ConditionValue"] != null)
                double.TryParse(objDr["ConditionValue"].ToString(), out _Value);
            if (objDr.Table.Columns["ConditionAllowance"] != null)
                int.TryParse(objDr["ConditionAllowance"].ToString(), out _Allowance);
            if (objDr.Table.Columns["ConditionDiscountPerc"] != null)
                double.TryParse(objDr["ConditionDiscountPerc"].ToString(), out _DiscountPerc);
            if (objDr.Table.Columns["ConditionPaidValue"] != null)
                double.TryParse(objDr["ConditionPaidValue"].ToString(), out _TotalPaidValue);
            if (_TotalPaidValue > 0)
            { 
            }
            if (objDr.Table.Columns["ConditionDiscountValue"] != null)
                double.TryParse(objDr["ConditionDiscountValue"].ToString(), out _TotalDiscountValue);
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
            string strSql = SearchStr + " where MNROCreditCondition.Dis is null ";
            if (ID != 0)
                strSql += " and dbo.MNROCreditCondition.ConditionID ="+ID ;
            if (_Credit != 0)
                strSql += " and ConditionCredit=" + _Credit;
            if (_ROIDs != null && _ROIDs != "")
                strSql += " and CreditTable.CreditRO in ("+_ROIDs+")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
