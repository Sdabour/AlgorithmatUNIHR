using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class TempSchedulingDb
    {

        #region Constructor
        public TempSchedulingDb()
        {
        }
        public TempSchedulingDb(DataRow objDr)
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
        int _RO;
        public int RO
        {
            set
            {
                _RO = value;
            }
            get
            {
                return _RO;
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
        double _AdvancedValue;
        public double AdvancedValue
        {
            set
            {
                _AdvancedValue = value;
            }
            get
            {
                return _AdvancedValue;
            }
        }
        string _PaymentDesc;
        public string PaymentDesc
        { set => _PaymentDesc = value; }
        string _TempPaymentRef;
        public string TempPaymentRef { get => _TempPaymentRef; }

         DateTime _StartDate;
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCreditTempScheduling (SchedulingRO,SchedulingStrategy,SchedulingCredit,SchedulingAdvancedValue,SchedulingStartDate,UsrIns,TimIns) values (" + RO + "," + Strategy + "," + Credit + "," + AdvancedValue + "," + (StartDate.ToOADate() - 2).ToString() + "," + SysData.CurrentUser.ID + ",GetDate() ) " +
                    @" declare @SchedulingID numeric(18,0);
    set @SchedulingID = (select @@IDENTITY) ;
    ";
                TempMaintainancePaymentDb objPayment = new TempMaintainancePaymentDb() { Date = DateTime.Now, Value = AdvancedValue, Desc = _PaymentDesc, IdentityScheduling = true, System = SysData.SysID, InternalRef = RO };
                Returned += objPayment.AddStr;
                Returned += @" select dbo.MNROCreditTempPayment.PaymentID,MNROCreditTempScheduling.SchedulingID
    , { fn MINUTE(PaymentDate) } AS PaymentMinute, { fn SECOND(PaymentDate) } AS PaymentSecond
  from dbo.MNROCreditTempPayment
  cross join MNROCreditTempScheduling
  WHERE  (dbo.MNROCreditTempPayment.PaymentID = @TempPaymentID)  and  (MNROCreditTempScheduling.SchedulingID = @SchedulingID) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCreditTempScheduling set   SchedulingRO=" + RO + "" +
           ",SchedulingStrategy=" + Strategy + "" +
           ",SchedulingCredit=" + Credit + "" +
           ",SchedulingAdvancedValue=" + AdvancedValue + "" +
           ",SchedulingStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where SchedulingID = "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNROCreditTempScheduling set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select SchedulingID,SchedulingRO,SchedulingStrategy,SchedulingCredit,SchedulingAdvancedValue,SchedulingStartDate from MNROCreditTempScheduling  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["SchedulingID"] != null)
                int.TryParse(objDr["SchedulingID"].ToString(), out _ID);

            if (objDr.Table.Columns["SchedulingRO"] != null)
                int.TryParse(objDr["SchedulingRO"].ToString(), out _RO);

            if (objDr.Table.Columns["SchedulingStrategy"] != null)
                int.TryParse(objDr["SchedulingStrategy"].ToString(), out _Strategy);

            if (objDr.Table.Columns["SchedulingCredit"] != null)
                int.TryParse(objDr["SchedulingCredit"].ToString(), out _Credit);

            if (objDr.Table.Columns["SchedulingAdvancedValue"] != null)
                double.TryParse(objDr["SchedulingAdvancedValue"].ToString(), out _AdvancedValue);

            if (objDr.Table.Columns["SchedulingStartDate"] != null)
                DateTime.TryParse(objDr["SchedulingStartDate"].ToString(), out _StartDate);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            int intTempPayment = 0;
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            if (dtTemp != null && dtTemp.Rows.Count > 0)
            {
                int.TryParse(dtTemp.Rows[0]["PaymentID"].ToString(), out intTempPayment );
                int.TryParse(dtTemp.Rows[0]["SchedulingID"].ToString(), out _ID);
                string strSecond = dtTemp.Rows[0]["PaymentSecond"].ToString().PadLeft(2, '0');
                string strMinute = dtTemp.Rows[0]["PaymentMinute"].ToString().PadLeft(2, '0');
                _TempPaymentRef = strMinute + strSecond + intTempPayment.ToString();
            }
            
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

            if (ID != 0)
                strSql += " and MNROCreditTempScheduling.SchedulingID = "+_ID;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}