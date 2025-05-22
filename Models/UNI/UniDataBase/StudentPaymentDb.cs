using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class StudentPaymentDb : PaymentDb
    {

        #region Constructor
        public StudentPaymentDb()
        {
        }
        public StudentPaymentDb(DataRow objDr) : base(objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties

        int _StudentID;
        public int StudentID
        {
            set
            {
                _StudentID = value;
            }
            get
            {
                return _StudentID;
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
        {
            set => _CreditConditionID = value;
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
        DataTable _ROIDTable;
        public DataTable ROIDTable { set => _ROIDTable = value; }
        public string AddDiscountStr
        {
            get
            {
                string Returned = @" insert into UNIStudentDiscount (StudentID, CreditDiscountType, CreditDiscountDate, CreditDiscountDesc, CreditDiscountValue, CreditPayment, UsrIns, TimIns
) ";

                Returned += @" SELECT dbo.UNIStudent.Student, 0 AS DiscountType, derivedtbl_1.MaxPaymentDate AS DiscountDate, 'خصم  تعجيل سداد' AS DiscountDesc, 
                  dbo.UNIStudentCondition.ConditionDiscountPerc * dbo.UNIStudentCondition.ConditionValue / 100 AS DiscountValue, derivedtbl_1.MaxPaymentID, 2 AS UsrIns, GETDATE() AS TimIns
FROM     dbo.UNIStudentCondition INNER JOIN
                      (SELECT dbo.UNIStudentConditionPayment.ConditionID, SUM(dbo.GLPayment.PaymentValue) AS TotalPaidValue, MAX(dbo.GLPayment.PaymentDate) AS MaxPaymentDate, MAX(dbo.UNIStudentConditionPayment.PaymentID) 
                                         AS MaxPaymentID
                       FROM      dbo.UNIStudentConditionPayment INNER JOIN
                                         dbo.UNIStudentPayment ON dbo.UNIStudentConditionPayment.PaymentID = dbo.UNIStudentPayment.PaymentID INNER JOIN
                                         dbo.GLPayment ON dbo.UNIStudentPayment.PaymentID = dbo.GLPayment.PaymentID
                       GROUP BY dbo.UNIStudentConditionPayment.ConditionID) AS derivedtbl_1 ON dbo.UNIStudentCondition.ConditionID = derivedtbl_1.ConditionID AND
 (derivedtbl_1.TotalPaidValue -
(
(100 - dbo.UNIStudentCondition.ConditionDiscountPerc) 
                  * dbo.UNIStudentCondition.ConditionValue/100
) ) >= -2  AND dbo.UNIStudentCondition.ConditionAllowance >= DATEDIFF(day, dbo.UNIStudentCondition.ConditionDueDate, derivedtbl_1.MaxPaymentDate) INNER JOIN
                  dbo.UNIStudent ON dbo.UNIStudentCondition.ConditionCredit = dbo.UNIStudent.CreditID LEFT OUTER JOIN
                      (SELECT dbo.UNIStudentConditionDiscount.ConditionID, SUM(dbo.UNIStudentDiscount.CreditDiscountValue) AS TotalDiscount
                       FROM      dbo.UNIStudentConditionDiscount INNER JOIN
                                         dbo.UNIStudentDiscount ON dbo.UNIStudentConditionDiscount.DiscountID = dbo.UNIStudentDiscount.CreditDiscountID
                       GROUP BY dbo.UNIStudentConditionDiscount.ConditionID) AS derivedtbl_2 ON dbo.UNIStudentCondition.ConditionID = derivedtbl_2.ConditionID
WHERE  (dbo.UNIStudentCondition.ConditionID = " + _CreditConditionID + @")";
                Returned += @"declare @DiscountID numeric(18,0);
   set @DiscountID = (select @@IDENTITY as NewDiscountID)
   insert into UNIStudentConditionDiscount (ConditionID,DiscountID)
     SELECT  dbo.UNIStudentPayment.CreditConditionID,dbo.UNIStudentDiscount.CreditDiscountID
 FROM     dbo.UNIStudentDiscount INNER JOIN
                  dbo.UNIStudentPayment ON dbo.UNIStudentDiscount.CreditPayment = dbo.UNIStudentPayment.PaymentID
WHERE  (dbo.UNIStudentDiscount.CreditDiscountID = @DiscountID)  AND (dbo.UNIStudentPayment.CreditConditionID = " + _CreditConditionID + @")";
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
                Returned += @" insert into UNIStudentPayment (PaymentID,StudentID,CreditID,CreditConditionID)
     values (@PaymentID," + StudentID + "," + CreditID + "," + _CreditConditionID + ") ";

                if (_CreditConditionID != 0)
                {
                    Returned += " insert into UNIStudentConditionPayment (ConditionID, PaymentID) values (" + _CreditConditionID + ",@PaymentID)";
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
      set @PaymentCount = (select count(PaymentID) as PaymentCount from UNIStudentPayment where  PaymentID=" + ID + @" and CreditID =0 );";
                Returned += @"  if @PaymentCount >0  goto rolLine ;";
                //     Returned += " update UNIStudentPayment set StudentID=" + StudentID + "" +
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
                string strPaymentDiscount = @"SELECT dbo.UNIStudentDiscount.CreditDiscountID
FROM     dbo.UNIStudentDiscount INNER JOIN
                  dbo.UNIStudentConditionDiscount ON dbo.UNIStudentDiscount.CreditDiscountID = dbo.UNIStudentConditionDiscount.DiscountID INNER JOIN
                  dbo.UNIStudentPayment ON dbo.UNIStudentConditionDiscount.ConditionID = dbo.UNIStudentPayment.CreditConditionID
 WHERE  (dbo.UNIStudentPayment.PaymentID =" + _ID + ")";
                string Returned = @"delete FROM     dbo.UNIStudentDiscount
WHERE  (CreditPayment > 0) AND (CreditDiscountID IN (" + strPaymentDiscount + @")) AND (isnull(CreditID,0) = 0)";

                Returned += @" delete FROM     dbo.UNIStudentPayment
WHERE(CreditID = 0) AND(PaymentID = " + _ID + @")";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT        dbo.UNIStudentPayment.StudentID as PaymentSTudentID, dbo.UNIStudentPayment.CreditID,StudentTable.* ,PaymentTable.*  
                           FROM          dbo.UNIStudentPayment INNER JOIN
          (" + base.SearchStr + @") as PaymentTable 
 on UNIStudentPayment.PaymentID = PaymentTable.PaymentID
   inner join (" + new StudentDb().SearchStr + @") as StudentTable 
    on UNIStudentPayment.StudentID = StudentTable.StudentID ";

              
                return Returned;
            }
        }
       
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PaymentID"] != null)
                int.TryParse(objDr["PaymentID"].ToString(), out _ID);

            if (objDr.Table.Columns["StudentID"] != null)
                int.TryParse(objDr["StudentID"].ToString(), out _StudentID);

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
            if (_CreditedStatus != 0)
            {
                if (_CreditedStatus == 1)
                    strSql += " and dbo.UNIStudentPayment.CreditID >0 ";
                else if (_CreditedStatus == 2)
                    strSql += " and dbo.UNIStudentPayment.CreditID =0 ";
            }
            if (_IsDateRange)
                strSql += " and PaymentTable.PaymentDate between " + (_StartDate.Date.ToOADate() - 2) + "  and " + (_EndDate.Date.ToOADate() - 1);
            if (_StudentID != 0)
                strSql += " and dbo.UNIStudentPayment.StudentID =" + _StudentID;
            if (_ROIDs != null && _ROIDs != "")
                strSql += " and dbo.UNIStudentPayment.StudentID in (" + _ROIDs + ") ";
            if (_CreditedStatus == 1)
                strSql += " and dbo.UNIStudentPayment.CreditID >0 ";
            if (_CreditedStatus == 2)
                strSql += " and dbo.UNIStudentPayment.CreditID =0 ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and StudentTable.ROProjectCode ='" + _ProjectCode + "' ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion

    }
}
