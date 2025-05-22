using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace AlgorithmatMN.MN.MNDb
{
    public class MaintainancePaymentDb:PaymentDb
    {

        #region Constructor
        public MaintainancePaymentDb()
        {
        }
        public MaintainancePaymentDb(DataRow objDr):base(objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
       
        int _CreditROID;
        public int CreditROID
        {
            set
            {
                _CreditROID = value;
            }
            get
            {
                return _CreditROID;
            }
        }
      
        int _CreditID;
        public int CreditID
        {
            set
            {
                _CreditID = value;
            }
            get
            {
                return _CreditID;
            }
        }
        int _CreditConditionID;
        public int CreditConditionID
        { set => _CreditConditionID = value;
            get => _CreditConditionID;
        }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        int _CreditedStatus;
        public int CreditedStatus { set => _CreditedStatus = value; }
        string _ProjectCode;
        public string ProjectCode
        { set => _ProjectCode = value; }
        string _ROIDs;
        public string ROIDs { set => _ROIDs = value; }
        public string AddDiscountStr
        {
            get
            {
                string Returned = @" insert into MNROCreditDiscount (CreditROID, CreditDiscountType, CreditDiscountDate, CreditDiscountDesc, CreditDiscountValue, CreditPayment, UsrIns, TimIns
) ";
                
                Returned += @" SELECT dbo.MNROCredit.CreditRO, 0 AS DiscountType, derivedtbl_1.MaxPaymentDate AS DiscountDate, 'خصم  تعجيل سداد' AS DiscountDesc, 
                  dbo.MNROCreditCondition.ConditionDiscountPerc * dbo.MNROCreditCondition.ConditionValue / 100 AS DiscountValue, derivedtbl_1.MaxPaymentID, 2 AS UsrIns, GETDATE() AS TimIns
FROM     dbo.MNROCreditCondition INNER JOIN
                      (SELECT dbo.MNROCreditConditionPayment.ConditionID, SUM(dbo.GLPayment.PaymentValue) AS TotalPaidValue, MAX(dbo.GLPayment.PaymentDate) AS MaxPaymentDate, MAX(dbo.MNROCreditConditionPayment.PaymentID) 
                                         AS MaxPaymentID
                       FROM      dbo.MNROCreditConditionPayment INNER JOIN
                                         dbo.MNROCreditPayment ON dbo.MNROCreditConditionPayment.PaymentID = dbo.MNROCreditPayment.PaymentID INNER JOIN
                                         dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID
                       GROUP BY dbo.MNROCreditConditionPayment.ConditionID) AS derivedtbl_1 ON dbo.MNROCreditCondition.ConditionID = derivedtbl_1.ConditionID AND
 (derivedtbl_1.TotalPaidValue -
(
(100 - dbo.MNROCreditCondition.ConditionDiscountPerc) 
                  * dbo.MNROCreditCondition.ConditionValue/100
) ) >= -2  AND dbo.MNROCreditCondition.ConditionAllowance >= DATEDIFF(day, dbo.MNROCreditCondition.ConditionDueDate, derivedtbl_1.MaxPaymentDate) INNER JOIN
                  dbo.MNROCredit ON dbo.MNROCreditCondition.ConditionCredit = dbo.MNROCredit.CreditID LEFT OUTER JOIN
                      (SELECT dbo.MNROCreditConditionDiscount.ConditionID, SUM(dbo.MNROCreditDiscount.CreditDiscountValue) AS TotalDiscount
                       FROM      dbo.MNROCreditConditionDiscount INNER JOIN
                                         dbo.MNROCreditDiscount ON dbo.MNROCreditConditionDiscount.DiscountID = dbo.MNROCreditDiscount.CreditDiscountID
                       GROUP BY dbo.MNROCreditConditionDiscount.ConditionID) AS derivedtbl_2 ON dbo.MNROCreditCondition.ConditionID = derivedtbl_2.ConditionID
WHERE  (dbo.MNROCreditCondition.ConditionID = " + _CreditConditionID+@")";
                Returned += @"declare @DiscountID numeric(18,0);
   set @DiscountID = (select @@IDENTITY as NewDiscountID)
   insert into MNROCreditConditionDiscount (ConditionID,DiscountID)
     SELECT  dbo.MNROCreditPayment.CreditConditionID,dbo.MNROCreditDiscount.CreditDiscountID
 FROM     dbo.MNROCreditDiscount INNER JOIN
                  dbo.MNROCreditPayment ON dbo.MNROCreditDiscount.CreditPayment = dbo.MNROCreditPayment.PaymentID
WHERE  (dbo.MNROCreditDiscount.CreditDiscountID = @DiscountID)  AND (dbo.MNROCreditPayment.CreditConditionID = " + _CreditConditionID+@")";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "";
                Returned += @"begin transaction Trans1;
       ";
                Returned += base.BaseAddStr;
                Returned+= @" insert into MNROCreditPayment (PaymentID,CreditROID,CreditID,CreditConditionID)
     values (@PaymentID," + CreditROID + "," + CreditID +"," +_CreditConditionID+") ";

                if (_CreditConditionID != 0)
                {
                    Returned += " insert into MNROCreditConditionPayment (ConditionID, PaymentID) values ("+_CreditConditionID  +",@PaymentID)";
                    Returned += AddDiscountStr;
                }
                Returned += " goto commitline;";
                Returned += " commitline: commit transaction Trans1;select  @PaymentID as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
               string Returned = @"begin transaction Trans1;
       ";
                Returned += base.EditStr;
                Returned += @" declarae @PaymentCount int
      set @PaymentCount = (select count(PaymentID) as PaymentCount from MNROCreditPayment where  PaymentID="+ID+@" and CreditID =0 );";
                Returned += @"  if @PaymentCount >0  goto rolLine ;";
                //     Returned += " update MNROCreditPayment set CreditROID=" + CreditROID + "" +
                //",CreditID=" + CreditID + "" +
                // " where ";
                Returned += @" commitline: commit transaction Trans1;select  1 as exp1 ; return ; ";
                Returned += " rolLine: RollBack TRAN Trans1 ;select  -1 as exp1 ;";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strPaymentDiscount = @"SELECT dbo.MNROCreditDiscount.CreditDiscountID
FROM     dbo.MNROCreditDiscount INNER JOIN
                  dbo.MNROCreditConditionDiscount ON dbo.MNROCreditDiscount.CreditDiscountID = dbo.MNROCreditConditionDiscount.DiscountID INNER JOIN
                  dbo.MNROCreditPayment ON dbo.MNROCreditConditionDiscount.ConditionID = dbo.MNROCreditPayment.CreditConditionID
 WHERE  (dbo.MNROCreditPayment.PaymentID =" + _ID+")";
                string Returned = @"delete FROM     dbo.MNROCreditDiscount
WHERE  (CreditPayment > 0) AND (CreditDiscountID IN ("+ strPaymentDiscount +@")) AND (isnull(CreditID,0) = 0)";
                    
                    Returned +=@" delete FROM     dbo.MNROCreditPayment
WHERE(CreditID = 0) AND(PaymentID = "+_ID+@")";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT        dbo.MNROCreditPayment.CreditROID, dbo.MNROCreditPayment.CreditID,ROTable.* ,PaymentTable.*  
                           FROM          dbo.MNROCreditPayment INNER JOIN
          ("+base.SearchStr+ @") as PaymentTable 
 on MNROCreditPayment.PaymentID = PaymentTable.PaymentID
   inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditPayment.CreditROID = ROTable.ROID ";
                return Returned;
            }
        }
        public string Search1Str
        {
            get
            {
                string Returned = @"SELECT        dbo.MNROCreditPayment.PaymentID, dbo.MNROCreditPayment.CreditROID, dbo.MNROCreditPayment.CreditID, dbo.GLPayment.PaymentValue, dbo.GLPayment.PaymentDate, dbo.GLPayment.PaymentCurrency, 
                                                    dbo.GLPayment.PaymentCurrencyValue, dbo.GLPayment.PaymentType, dbo.GLPayment.PaymentDesc, dbo.GLPayment.PaymentDirection, dbo.GLPayment.PaymentEmployee, dbo.GLPayment.PaymentBranch, 
                                                    dbo.GLPayment.PaymentCoffer, dbo.GLPayment.PaymentHasReceipt, dbo.GLPayment.PaymentReceipt, dbo.GLPayment.PaymentSourceID, dbo.GLPayment.PaymentReverseID, 
                                                    dbo.GLPayment.PaymentCollectingID, dbo.GLCheckPayment.CheckID, dbo.GLCheckPayment.PaymentIsCollected, dbo.GLCheckPayment.PaymentCollectingDate, dbo.GLCheckPayment.PaymentCollectingUsr, 
                                                    dbo.GLCheckPayment.PaymentCollectingEmployee, dbo.GLCheckPayment.PaymentCollectingBranch, dbo.GLCheckPayment.PaymentCollectingCoffer, dbo.GLCheckPayment.PaymentCollectingRealDate, 
                                                    dbo.GLCheckPayment.PaymentCollectingID AS Expr1, dbo.GLCheck.CheckEditorName, dbo.GLCheck.CheckCode, dbo.GLCheck.CheckValue, dbo.GLCheck.CheckIssueDate, dbo.GLCheck.CheckDueDate, 
                                                    dbo.GLCheck.CheckPaymentDate, dbo.GLCheck.CheckCurrentStatus, dbo.GLCheck.CheckCurrentStatusDate,ROTable.*  
                           FROM            dbo.GLCheck RIGHT OUTER JOIN
                                                    dbo.GLCheckPayment ON dbo.GLCheck.CheckID = dbo.GLCheckPayment.CheckID RIGHT OUTER JOIN
                                                    dbo.MNROCreditPayment INNER JOIN
                                                    dbo.GLPayment ON dbo.MNROCreditPayment.PaymentID = dbo.GLPayment.PaymentID ON dbo.GLCheckPayment.PaymentID = dbo.GLPayment.PaymentID 
   inner join (" + new RODb().SearchStr + @") as ROTable 
    on MNROCreditPayment.CreditROID = ROTable.ROID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PaymentID"] != null)
                int.TryParse(objDr["PaymentID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditROID"] != null)
                int.TryParse(objDr["CreditROID"].ToString(), out _CreditROID);

            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _CreditID);

            if (objDr.Table.Columns["PaymentValue"] != null)
                double.TryParse(objDr["PaymentValue"].ToString(), out _Value);

            if (objDr.Table.Columns["PaymentDate"] != null)
                DateTime.TryParse(objDr["PaymentDate"].ToString(), out _Date);

            if (objDr.Table.Columns["PaymentCurrency"] != null)
                int.TryParse(objDr["PaymentCurrency"].ToString(), out _Currency);

            if (objDr.Table.Columns["PaymentCurrencyValue"] != null)
                double.TryParse(objDr["PaymentCurrencyValue"].ToString(), out _CurrencyValue);

            if (objDr.Table.Columns["PaymentType"] != null)
                int.TryParse(objDr["PaymentType"].ToString(), out _Type);

            if (objDr.Table.Columns["PaymentDesc"] != null)
                _Desc = objDr["PaymentDesc"].ToString();

            if (objDr.Table.Columns["PaymentDirection"] != null)
                bool.TryParse(objDr["PaymentDirection"].ToString(), out _Direction);

            if (objDr.Table.Columns["PaymentEmployee"] != null)
              

          

            if (objDr.Table.Columns["PaymentHasReceipt"] != null)
                bool.TryParse(objDr["PaymentHasReceipt"].ToString(), out _HasReceipt);

            if (objDr.Table.Columns["PaymentReceipt"] != null)
               

            if (objDr.Table.Columns["PaymentSourceID"] != null)
               

           

          

            if (objDr.Table.Columns["CheckID"] != null)
                int.TryParse(objDr["CheckID"].ToString(), out _CheckID);

            if (objDr.Table.Columns["PaymentIsCollected"] != null)
                bool.TryParse(objDr["PaymentIsCollected"].ToString(), out _IsCollected);

            if (objDr.Table.Columns["PaymentCollectingDate"] != null)
                DateTime.TryParse(objDr["PaymentCollectingDate"].ToString(), out _CollectingDate);

           

            

         

           

           

          

           
        }

        #endregion
        #region Public Method 
        public override void Add()
        {
            string strSql = AddStr;
            object objID = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            if (objID != null)
                int.TryParse(objID.ToString(), out _ID);
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
            if(_CreditedStatus != 0)
            {
                if(_CreditedStatus== 1)
                strSql += " and dbo.MNROCreditPayment.CreditID >0 ";
                else if (_CreditedStatus == 2)
                    strSql += " and dbo.MNROCreditPayment.CreditID =0 ";
            }
            if (_IsDateRange)
                strSql += " and PaymentTable.PaymentDate between "+ (_StartDate.Date.ToOADate()-2) + "  and "+(_EndDate.Date.ToOADate()-1);
            if (_CreditROID != 0)
                strSql += " and dbo.MNROCreditPayment.CreditROID ="+_CreditROID;
            if(_ROIDs!= null && _ROIDs!= "")
                strSql += " and dbo.MNROCreditPayment.CreditROID in (" + _ROIDs +") ";
            if (_CreditedStatus == 1)
                strSql += " and dbo.MNROCreditPayment.CreditID >0 ";
            if (_CreditedStatus == 2)
                strSql += " and dbo.MNROCreditPayment.CreditID =0 ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROTable.ROProjectCode ='"+ _ProjectCode +"' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
