using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerLoanDb
    {
        #region Private Data
        protected int _ID;
        protected int _LoanApplicant;
        protected float _LoanValue;
        protected float _LoanPrepaidValue;
        protected bool _IsStop;
        protected string _LoanDesc;
        protected DateTime _LoanRequestDate;
        protected DateTime _LoanGrantDate;
        protected float _InstallmentValue;
        protected DateTime _InstallmentDate;
        protected DateTime _InstallmentDateFromSearch;
        protected DateTime _InstallmentDateToSearch;
        protected bool _InstallmentDateSearch;
        protected int _LoanImage;
        byte _FinishStatus;
        string _ApplicantIDs;
        byte _BelongInStatement;
        int _GlobalStatementIDSearch;
        double _TotalPayment;
        double _TotalDiscount;

       

        #endregion
        #region Constructors
        public ApplicantWorkerLoanDb()
        {
        }
        public ApplicantWorkerLoanDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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
        public bool IsStop
        {
            set
            {
                _IsStop = value;
            }
            get
            {
                return _IsStop;
            }
        }
        public int LoanApplicant
        {
            set
            {
                _LoanApplicant = value;
            }
            get
            {
                return _LoanApplicant;
            }
        }
        public float LoanValue
        {
            set
            {
                _LoanValue = value;
            }
            get
            {
                return _LoanValue;
            }
        }
        public float LoanPrepaidValue
        {
            set
            {
                _LoanPrepaidValue = value;
            }
            get
            {
                return _LoanPrepaidValue;
            }
        }
        public string LoanDesc
        {
            set
            {
                _LoanDesc = value;
            }
            get
            {
                return _LoanDesc;
            }
        }
        public DateTime LoanRequestDate
        {
            set
            {
                _LoanRequestDate = value;
            }
            get
            {
                return _LoanRequestDate;
            }
        }
        public DateTime LoanGrantDate
        {
            set
            {
                _LoanGrantDate = value;
            }
            get
            {
                return _LoanGrantDate;
            }
        }        
        public byte FinishStatus
        {
            set
            {
                _FinishStatus = value;
            }

        }
        public float InstallmentValue
        {
            set
            {
                _InstallmentValue = value;
            }
            get
            {
                return _InstallmentValue;
            }
        }
        public DateTime InstallmentDate
        {
            set
            {
                _InstallmentDate = value;
            }
            get
            {
                return _InstallmentDate;
            }
        }
        public int LoanImage
        {
            set
            {
                _LoanImage = value;
            }
            get
            {
                return _LoanImage;
            }
        }
        public bool InstallmentDateSearch
        {
            set
            {
                _InstallmentDateSearch = value;
            }
            get
            {
                return _InstallmentDateSearch;
            }
        }
        public DateTime InstallmentDateFromSearch
        {
            set
            {
                _InstallmentDateFromSearch = value;
            }
            get
            {
                return _InstallmentDateFromSearch;
            }
        }
        public DateTime InstallmentDateToSearch
        {
            set
            {
                _InstallmentDateToSearch = value;
            }
            get
            {
                return _InstallmentDateToSearch;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }

        }
        public byte BelongInStatement
        {
            set
            {
                _BelongInStatement = value;
            }
        }
        public int GlobalStatementIDSearch
        {
            set
            {
                _GlobalStatementIDSearch = value;
            }
        }
        public double TotalDiscount
        {
            get { return _TotalDiscount; }
            set { _TotalDiscount = value; }
        }
        public double TotalPayment
        {
            get { return _TotalPayment; }
            set { _TotalPayment = value; }
        }
        public string AddStr
        {
            get
            {
                double dblLoanRequestDate = _LoanRequestDate.ToOADate() - 2;
                double dblLoanGrantDate = _LoanGrantDate.ToOADate() - 2;
                double dblInstallmentDate = _InstallmentDate.ToOADate() - 2;

                int intIsStop = _IsStop ? 1 : 0;
                
                string ReturnedStr = " INSERT INTO HRApplicantWorkerLoan "+
                                     " (LoanApplicant, LoanValue,LoanPrepaidValue,LoanInstallmentValue, LoanDesc, " +
                                     " LoanRequestDate, LoanGrantDate,LoanInstallmentDate,LoanImage,IsStop, UsrIns, TimIns)" +
                                     " VALUES "+
                                     " (" + _LoanApplicant + "," + _LoanValue + "," + _LoanPrepaidValue + "," + _InstallmentValue + ",'" + _LoanDesc + "'," +
                                     " " + dblLoanRequestDate + "," + dblLoanGrantDate + "," + dblInstallmentDate + "," + _LoanImage + ","+ intIsStop +"," +
                                     ""+ SysData.CurrentUser.ID +",GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblLoanRequestDate = _LoanRequestDate.ToOADate() - 2;
                double dblLoanGrantDate = _LoanGrantDate.ToOADate() - 2;
                double dblInstallmentDate = _InstallmentDate.ToOADate() - 2;
                int intIsStop = _IsStop ? 1 : 0;
                string ReturnedStr = " UPDATE    HRApplicantWorkerLoan "+
                                     " SET  LoanValue =" + _LoanValue + "" +
                                     " , LoanPrepaidValue =" + _LoanPrepaidValue + "" +
                                     " , LoanInstallmentValue =" + _InstallmentValue + "" +
                                     " , LoanDesc ='" + _LoanDesc + "'" +
                                     " , LoanRequestDate =" + dblLoanRequestDate + "" +
                                     " , LoanGrantDate =" + dblLoanGrantDate + "" +
                                     " , LoanInstallmentDate =" + dblInstallmentDate + "" +
                                     " , LoanImage =" + _LoanImage + "" +
                                     " , IsStop =" + intIsStop + "" + 
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                     " WHERE     (LoanID = " + _ID + ") AND (LoanApplicant = " + _LoanApplicant + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRApplicantWorkerLoan" +
                                     " WHERE     (LoanID = " + _ID + ") AND (LoanApplicant = " + _LoanApplicant + ")";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strPayment = "SELECT     Loan, SUM(PaymenetValue) AS TotalPaymentValue "+
                       " FROM         dbo.HRApplicantWorkerLoanPayment "+
                       " GROUP BY Loan ";
                string strMaxDiscount = "SELECT        DiscountStatement ,DiscountLoan, MAX(DiscountID) AS MaxDiscountID " +
                       " FROM            dbo.HRApplicantWorkerStatementLoanDiscount " +
                       " GROUP BY DiscountStatement,DiscountLoan ";
                string strDiscount = "SELECT dbo.HRApplicantWorkerStatementLoanDiscount.DiscountLoan, SUM(dbo.HRApplicantWorkerStatementLoanDiscount.DiscountValue) AS TotalDiscountValue "+
                     " FROM    dbo.HRApplicantWorkerStatement INNER JOIN "+
                     " dbo.GLOriginStatement ON dbo.HRApplicantWorkerStatement.OriginStatementID = dbo.GLOriginStatement.OriginStatementID INNER JOIN "+
                     " dbo.HRApplicantWorkerStatementLoanDiscount ON  "+
                     " dbo.HRApplicantWorkerStatement.OriginStatementID = dbo.HRApplicantWorkerStatementLoanDiscount.DiscountStatement "+
                    " inner join ("+ strMaxDiscount +") as MaxDiscountTable "+
                    " on dbo.HRApplicantWorkerStatementLoanDiscount.DiscountStatement = MaxDiscountTable.DiscountStatement " +
                    " and  dbo.HRApplicantWorkerStatementLoanDiscount.DiscountLoan = MaxDiscountTable.DiscountLoan " +
                    " and  dbo.HRApplicantWorkerStatementLoanDiscount.DiscountID =MaxDiscountTable.MaxDiscountID " +
                     " GROUP BY dbo.HRApplicantWorkerStatementLoanDiscount.DiscountLoan ";
                string ReturnedStr = " SELECT     HRApplicantWorkerLoan.LoanID, HRApplicantWorkerLoan.LoanApplicant,"+
                                     " HRApplicantWorkerLoan.LoanValue,HRApplicantWorkerLoan.LoanPrepaidValue, HRApplicantWorkerLoan.LoanDesc,HRApplicantWorkerLoan.LoanImage, " +
                                     " HRApplicantWorkerLoan.LoanRequestDate, HRApplicantWorkerLoan.LoanGrantDate,HRApplicantWorkerLoan.LoanInstallmentValue,HRApplicantWorkerLoan.LoanInstallmentDate,HRApplicantWorkerLoan.IsStop, " +
                                     " ApplicantWorkerTable.*,DiscountTable.TotalDiscountValue,PaymentTable.TotalPaymentValue  " +
                                     " FROM         HRApplicantWorkerLoan" +
                                     " Left Outer Join (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerLoan.LoanApplicant"+
                                     " left outer join ("+ strDiscount +") as DiscountTable "+
                                     " on HRApplicantWorkerLoan.LoanID = DiscountTable.DiscountLoan "+
                                     " left outer join ("+ strPayment +") as PaymentTable "+
                                     " on  HRApplicantWorkerLoan.LoanID = PaymentTable.Loan ";
                
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["LoanID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["LoanID"].ToString());
            _LoanApplicant = int.Parse(objDr["LoanApplicant"].ToString());
            _LoanValue = float.Parse(objDr["LoanValue"].ToString());
            _InstallmentValue = float.Parse(objDr["LoanInstallmentValue"].ToString());
            _InstallmentDate = DateTime.Parse(objDr["LoanInstallmentDate"].ToString());
            _LoanPrepaidValue = float.Parse(objDr["LoanPrepaidValue"].ToString());
            _LoanDesc = objDr["LoanDesc"].ToString();
            _LoanRequestDate = DateTime.Parse(objDr["LoanRequestDate"].ToString());
            _LoanGrantDate = DateTime.Parse(objDr["LoanGrantDate"].ToString());
            if (objDr["LoanImage"].ToString() != "")            
            _LoanImage = int.Parse(objDr["LoanImage"].ToString());

        if (objDr["IsStop"].ToString() != "")
            _IsStop = bool.Parse(objDr["IsStop"].ToString());
        if (objDr.Table.Columns["TotalPaymentValue"] != null && objDr["TotalPaymentValue"].ToString() != "")
            _TotalPayment = double.Parse(objDr["TotalPaymentValue"].ToString());
        if (objDr.Table.Columns["TotalDiscountValue"] != null && objDr["TotalDiscountValue"].ToString() != "")
            _TotalDiscount = double.Parse(objDr["TotalDiscountValue"].ToString());
        }
        #endregion
        #region Public Methods
        public  void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public  void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public  void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public  DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
                StrSql = StrSql + " And LoanID = " + _ID + "";
            if (_LoanApplicant != 0)
                StrSql = StrSql + " And LoanApplicant = " + _LoanApplicant + "";
            if (_FinishStatus == 1)
                StrSql += " and (HRApplicantWorkerLoan.IsFinished =0  "+
                    " and  HRApplicantWorkerLoan.LoanValue -  " +
                    "("+
                    " case when HRApplicantWorkerLoan.LoanPrepaidValue is null then 0 else HRApplicantWorkerLoan.LoanPrepaidValue end  " +
                   " + case when TotalDiscountValue is null then 0 else TotalDiscountValue end " +
                   "+ case when TotalPaymentValue is null then 0 else TotalPaymentValue end  " +                  
                    ") >0 "+
                    " ) ";
            else if(_FinishStatus == 2)
                StrSql += " and ( HRApplicantWorkerLoan.IsFinished = 1 " +
                      " or  HRApplicantWorkerLoan.LoanValue -  " +
                    "(" +
                    " case when HRApplicantWorkerLoan.LoanPrepaidValue is null then 0 else HRApplicantWorkerLoan.LoanPrepaidValue end  " +
                   " + case when TotalDiscountValue is null then 0 else TotalDiscountValue end " +
                   "+ case when TotalPaymentValue is null then 0 else TotalPaymentValue end  " +
                    ") <= 0 " +
                    ")";

            if (_ApplicantIDs != null && _ApplicantIDs!="")
                StrSql = StrSql + " And LoanApplicant In ( " + _ApplicantIDs + ")";
            if (_InstallmentDateSearch == true)
            {               
                int intFrom;
                double d = _InstallmentDateFromSearch.ToOADate() - 2;
                intFrom = (int)d;

                int intTo;
                double dd = _InstallmentDateToSearch.ToOADate() - 2;
                intTo = (int)dd + 1;

                StrSql += " and HRApplicantWorkerLoan.LoanInstallmentDate between " + intFrom + " And " + intTo + "";
            }
            StrSql += " And (HRApplicantWorkerLoan.IsStop=0 )";
            if (_BelongInStatement != 0)
            {
                if (_BelongInStatement == 1) // belong
                {
                    if (_GlobalStatementIDSearch != 0)
                    {
                        StrSql += " And (LoanID in ( SELECT     DiscountLoan FROM  HRApplicantWorkerStatementLoanDiscount " +
                                  " WHERE     (DiscountStatement IN " +
                                  " (SELECT     OriginStatementID " +
                                  " FROM         HRApplicantWorkerStatement " +
                                  " WHERE     (GlobalStatment = " + _GlobalStatementIDSearch + "))) ))";
                    }
                }
                else if (_BelongInStatement == 2) // not Belong
                {
                    if (_GlobalStatementIDSearch != 0)
                    {
                        StrSql += " And (LoanID not in ( SELECT     DiscountLoan FROM HRApplicantWorkerStatementLoanDiscount " +
                                  " WHERE     (DiscountStatement IN " +
                                  " (SELECT     OriginStatementID " +
                                  " FROM         HRApplicantWorkerStatement " +
                                  " WHERE     (GlobalStatment = " + _GlobalStatementIDSearch + "))) ))";
                        StrSql += " And (IsFinished=0)";
                    }
                }
            }
            ApplicantWorkerDb.SetCashTable();
            ApplicantWorkerDb.ApplicantIDs = "select ApplicantID from (" + StrSql + ") as NativeTable ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
