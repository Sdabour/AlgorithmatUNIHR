using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementDb : OriginStatementDb
    {
        #region Private Data
        protected string _AccountBankNo;
        protected int _GlobalStatment;
        protected DateTime _StatementDate;
        protected int _Applicant;
        protected int _FinancialStatementType;
        protected double _LoanDiscount;
        protected int _PartTimeTotalMinutes;
        protected byte _PartTimeUnit;
        protected double _PartTimeValue;
        protected double _BaseSalary;
        protected double _BaseSalarySaved;
        protected double _DetailsValue;
        protected double _BonusValue;
        //protected double _DiscountValue;
        protected double _RewardValue;
        protected double _AttendanceDiscount;
        protected double _PenaltyDiscount;

        protected double _DelayValue;
        protected double _DelayDiscount;//
        protected double _OverDaysBonus;
        protected double _OverDays;//
        protected double _OverTimeBonus;//
        protected double _OverTimeValue;//

        protected double _AbsenceCount;
        protected double _AbsenceDiscount;//
        protected double _FurloughValue;
        protected double _FurloughDiscount;//
        protected double _VacationValue;
        protected double _VacationDiscount;//
        protected double _NonCountedDays;
        protected double _NonCountedDaysDiscount;//
        protected double _UtilityValue;//
        protected double _FellowShipFund;
        protected double _FellowShipFundBonus;
        protected double _IncreaseValue;
        protected double _PayBackValue;
        protected double _FellowShipPaymentValue;
        protected int _CostCenter;
        protected int _MotivationCostCenter;
        protected int _JobNature;
        protected string _JobNatureIDs;
        protected bool _IsEndStatement;
        protected bool _IsStop;
        protected bool _IsNotHasAttendanceStatement;
        protected bool _NotCalcBaseSalary;
        protected bool _NotCalcBaseSalaryDetails;
        protected bool _NotShowBaseSalary;
        protected bool _NotShowBaseSalaryDetails;
        protected bool _NotCalcBaseSalaryFellowShip;
        protected string _Remark;
        double _OldIncreaseValue;
        string _SectorIDs;
        int _SectorFamilyID;
        int _BranchID;
        int _JobNatureTypeID;
        string _ApplicantIDs;
        int _HasAccountBankNo;
        int _AccountBankID;
        string _AccountBankName;
        string _ApplicantExceptionIDs;

        protected bool _InsDateStatusSearch;
        protected DateTime _InsDateFromSearch;
        protected DateTime _InsDateToSearch;
        int _UserIDSearch;

        protected double _OldDeserved;
        protected double _TotalDeserved;
        byte _WorkStatus;
        byte _IsStopStatus;
        byte _PaymentStatus;
        int _GlobalStatementPayment;
        byte _RecommenedValueStatus;
        protected bool _SentToMail;
        string _CostCenterIDs;
        string _MotivationCostCenterIDs;
        int _CostCenterChildID;
        int _MotivationCostCenterChildID;
        string _GlobalStatementIDs;
        string _StatementSearchIDs;
        DataTable _SalaryDetailsTable;
        DataTable _SubSectorTable;
        DataTable _LoanDiscountTable;
        DataTable _DeletedLoanDiscountTable;
        static DataTable _ChacheSalaryDetailsTable;
        static DataTable _ChacheSubSectorTable;
        static DataTable _CacheLoanDiscountTable;
        static DataTable _CachApplicantTable;
        static DataTable _CachCostCenterTable;
        static DataTable _CachJobNatureTypeTable;
         DataTable _DiscountTable;
        DataTable _BonusTable;
        static string _StatementIDs;
        int _FinancialStatementStatusSearch;
        int _SubSectorID;
        double _FeedingValue;
        double _PhoneValue;
        double _TransportValue;
        double _OtherValue;
        double _ExchangeValue;

       
        
     
    

       

        byte _DetailEffectSearch;
        byte _OperationDetailEffectSearch;
        double _BaseSalaryFromSearch = -1;
        double _BaseSalaryToSearch = -1;

        double _PenaltyCountFromSearch = -1;
        double _PenaltyCountToSearch = -1;
        double _OverDayCountFromSearch = -1;
        double _OverDayCountToSearch = -1;
        double _AbsenceCountFromSearch = -1;
        double _AbsenceCountToSearch = -1;
        double _DelayCountFromSearch = -1;
        double _DelayCountToSearch = -1;

        
        double _IncreaseFromSearch = -1;
        double _IncreaseToSearch = -1;
        double _TotalSalaryFromSearch = -1;
        double _TotalSalaryToSearch = -1;
        double _DeservedFromSearch = -1;
        double _DeservedToSearch = -1;

        double _BonusFromSearch = -1;
        double _BonusToSearch = -1;
        int _SalaryBonusTypeSearch = 0;

        double _DiscountFromSearch = -1;
        double _DiscountToSearch = -1;
        int _SalaryDiscountTypeSearch = 0;

        static double _DeservedRatioSearch = 0;
        byte _HasMotivationSearch;
        int _MotivationTypeSearch;
        byte _MotivationStatusSearch;
        int _MotivationStatementSearch;
        int _MotivationStatementCostCenterIDSearch;
        bool _IsDependOnStartDateInMotivation;
        DateTime _StartDateInMotivation;
        float _flAccountBankNo;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementDb()
        {
        }
        public ApplicantWorkerStatementDb(DataRow objDr):base(objDr)
        {
            SetData(objDr);
        }
        public ApplicantWorkerStatementDb(int intID)
        {
            if (intID == 0)
                return;
            _ID = intID;
            DataTable dtTemp = Search();
            if(dtTemp.Rows.Count!=0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int GlobalStatment
        {
            set
            {
                _GlobalStatment = value;
            }
            get
            {
                return _GlobalStatment;
            }
        }
       // public  string GlobalStatementIDs { get; set; }
        public string AccountBankNo
        {
            set
            {
                _AccountBankNo = value;
            }
            get
            {
                return _AccountBankNo;
            }
        }
        public float flAccountBankNo
        {
            set
            {
                _flAccountBankNo = value;
            }
            get
            {
                return _flAccountBankNo;
            }
        }

        string _BankBranchCode;

        public string BankBranchCode
        {
            get { return _BankBranchCode; }
            set { _BankBranchCode = value; }
        }
        string _AccountTypeCode;

        public string AccountTypeCode
        {
            get { return _AccountTypeCode; }
            set { _AccountTypeCode = value; }
        }
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
            }
        }
        public int FinancialStatementType
        {
            set
            {
                _FinancialStatementType = value;
            }
            get
            {
                return _FinancialStatementType;
            }
        }
        public int SubSectorID
        {
            get
            {
                return _SubSectorID; 
            }

        }
        public DateTime StatementDate
        {
            set
            {
                _StatementDate = value;
            }
            get
            {
                return _StatementDate;
            }
        }
        public double LoanDiscount
        {
            set
            {
                _LoanDiscount = value;
            }
            get
            {
                return _LoanDiscount;
            }
        }
        public double BaseSalary
        {
            set
            {
                _BaseSalary = value;
            }
            get
            {
                return _BaseSalary;
            }
        }
        public double BaseSalarySaved
        {
            set
            {
                _BaseSalarySaved = value;
            }
            get
            {
                return _BaseSalarySaved;
            }
        }
        
        public int PartTimeTotalMinutes
        {
            set
            {
                _PartTimeTotalMinutes = value;
            }
            get
            {
                return _PartTimeTotalMinutes;
            }
        }
        public byte PartTimeUnit
        {
            set
            {
                _PartTimeUnit = value;
            }
            get
            {
                return _PartTimeUnit;
            }
        }
        public double PartTimeValue
        {
            set
            {
                _PartTimeValue = value;
            }
            get
            {
                return _PartTimeValue;
            }
        }
        public double DetailsValue
        {
            set
            {
                _DetailsValue = value;
            }
            get
            {
                return _DetailsValue;
            }
        }
        public double BonusValue
        {
            set
            {
                _BonusValue = value;
            }
            get
            {
                return _BonusValue;
            }
        }
        public double DiscountValue
        {
            set
            {
                _DiscountValue = value;
            }
            get
            {
                return _DiscountValue;
            }
        }
        public double RewardValue
        {
            set
            {
                _RewardValue = value;
            }
            get
            {
                return _RewardValue;
            }
        }
        public double AttendanceDiscount
        {
            set
            {
                _AttendanceDiscount = value;
            }
            get
            {
                return _AttendanceDiscount;
            }
        }
        public double PenaltyDiscount
        {
            set
            {
                _PenaltyDiscount = value;
            }
            get
            {
                return _PenaltyDiscount;
            }
        }
        public double DelayValue
        {
            set
            {
                _DelayValue = value;
            }
            get
            {
                return _DelayValue;
            }
        }
        public double DelayDiscount
        {
            set
            {
                _DelayDiscount = value;
            }
            get
            {
                return _DelayDiscount;
            }

        }
        public double OverDays
        {
            set
            {
                _OverDays = value;
            }
            get
            {
                return _OverDays;
            }

        }
        public double OverTimeValue
        {
            set
            {
                _OverTimeValue = value;
            }
            get
            {
                return _OverTimeValue;
            }

        }
        public double AbsenceDiscount
        {
            set
            {
                _AbsenceDiscount = value;
            }
            get
            {
                return _AbsenceDiscount;
            }

        }
        public double FurloughDiscount
        {
            set
            {
                _FurloughDiscount = value;
            }
            get
            {
                return _FurloughDiscount;
            }
        }
        public double FurloughValue
        {
            set
            {
                _FurloughValue = value;
            }
            get
            {
                return _FurloughValue;
            }

        }
        public double VacationDiscount
        {
            set
            {
                _VacationDiscount = value;
            }
            get
            {
                return _VacationDiscount;
            }
        }
        public double VacationValue
        {
            set
            {
                _VacationValue = value;
            }
            get
            {
                return _VacationValue;
            }

        }
        public double NonCountedDaysDiscount
        {
            set
            {
                _NonCountedDaysDiscount = value;
            }
            get
            {
                return _NonCountedDaysDiscount;
            }

        }
        public double UtilityValue
        {
            set
            {
                _UtilityValue = value;
            }
            get
            {
                return _UtilityValue;
            }

        }
        public double OverDaysBonus
        {
            set { _OverDaysBonus = value; }
            get { return _OverDaysBonus; }

        }
        public double OverTimeBonus
        {
            set
            {
                _OverTimeBonus = value;
            }
            get
            {
                return _OverTimeBonus;
            }
        }
        public double AbsenceCount
        {
            set { _AbsenceCount = value; }
            get { return _AbsenceCount; }

        }
        public double NonCountedDays
        {
            set { _NonCountedDays = value; }
            get { return _NonCountedDays; }

        }
        public double OldDeserved
        {
            set
            {
                _OldDeserved = value;
            }
            get
            {
                return _OldDeserved;
            }
        }
        public double TotalDeserved
        {
            set
            {
                _TotalDeserved = value;
            }
            get
            {
                return _TotalDeserved;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
            }
        }
        public int MotivationCostCenter
        {
            set
            {
                _MotivationCostCenter = value;
            }
            get
            {
                return _MotivationCostCenter;
            }
        }
        string _MotivationCostcenterName;

        public string MotivationCostcenterName
        {
            get { return _MotivationCostcenterName; }
            set { _MotivationCostcenterName = value; }
        }
        public int JobNature
        {
            set
            {
                _JobNature = value;
            }
            get
            {
                return _JobNature;
            }
        }
        public bool IsEndStatement
        {
            set
            {
                _IsEndStatement = value;
            }
            get
            {
                return _IsEndStatement;
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
        public bool IsNotHasAttendanceStatement
        {
            set
            {
                _IsNotHasAttendanceStatement = value;
            }
            get
            {
                return _IsNotHasAttendanceStatement;
            }
        }
        public bool NotCalcBaseSalary
        {
            set
            {
                _NotCalcBaseSalary = value;
            }
            get
            {
                return _NotCalcBaseSalary;
            }
        }
        public bool NotCalcBaseSalaryDetails
        {
            set
            {
                _NotCalcBaseSalaryDetails = value;
            }
            get
            {
                return _NotCalcBaseSalaryDetails;
            }
        }
        public bool NotShowBaseSalary
        {
            set
            {
                _NotShowBaseSalary = value;
            }
            get
            {
                return _NotShowBaseSalary;
            }
        }
        public bool NotShowBaseSalaryDetails
        {
            set
            {
                _NotShowBaseSalaryDetails = value;
            }
            get
            {
                return _NotShowBaseSalaryDetails;
            }
        }
        public bool NotCalcBaseSalaryFellowShip
        {
            set
            {
                _NotCalcBaseSalaryFellowShip = value;
            }
            get
            {
                return _NotCalcBaseSalaryFellowShip;
            }
        }
        public string Remark
        {
            set
            {
                _Remark = value;
            }
            get
            {
                return _Remark;
            }
        }
        public bool SentToMail
        {
            set
            {
                _SentToMail = value;
            }
            get
            {
                return _SentToMail;
            }
        }
        public double IncreaseValue
        {
            set
            {
                _IncreaseValue = value;
            }
            get
            {
                return _IncreaseValue;
            }
        }
        public static string StatementIDs
        {
            set
            {
                _StatementIDs = value;
            }
            get
            {
                return _StatementIDs;
            }
        }
        string _IDs;

        public string IDs
        {
          
            set { _IDs = value; }
        }
       
        public double FellowShipFund
        {
            set
            {
                _FellowShipFund = value;
            }
            get
            {
                //int intTemp = (int)_FellowShipFund;
                //intTemp = intTemp <= _FellowShipFund ? intTemp : intTemp - 1;
                //_FellowShipFund = (double)intTemp;
                return _FellowShipFund;
            }
        }
        public double FellowShipFundBonus
        {
            set
            {
                _FellowShipFundBonus = value;
            }
            get
            {
                //int intTemp = (int)_FellowShipFundBonus;
                //intTemp = intTemp <= _FellowShipFundBonus ? intTemp : intTemp - 1;
                //_FellowShipFundBonus = (double)intTemp;
                return _FellowShipFundBonus;
            }
        }
        public double PayBackValue
        {
            set
            {
                _PayBackValue = value;
            }
            get
            {
                return _PayBackValue;
            }
        }
        public double FellowShipPaymentValue
        {
            set
            {
                _FellowShipPaymentValue = value;
            }
            get
            {
                return _FellowShipPaymentValue;
            }
        }
        int _MotivationStatementIDSearch;
        public string CostCenterIDs
        {
            set
            {
                _CostCenterIDs = value;
            }
        }
        public string MotivationCostCenterIDs
        {
            set
            {
                _MotivationCostCenterIDs = value;
            }
        }
        public int MotivationStatementIDSearch
        {
            set
            {
                _MotivationStatementIDSearch = value;
            }
        }
        public int CostCenterChildID
        {
            set
            {
                _CostCenterChildID = value;
            }
        }
        public int MotivationCostCenterChildID
        {
            set
            {
                _MotivationCostCenterChildID = value;
            }
        }
        public string GlobalStatementIDs
        {
            set
            {
                _GlobalStatementIDs = value;
            }
        }
        public string StatementSearchIDs
        {
            set
            {
                _StatementSearchIDs = value;
            }
        }
        public int HasAccountBankNo
        {
            set
            {
                _HasAccountBankNo = value;
            }
        }
        public string JobNatureIDs
        {
            set
            {
                _JobNatureIDs = value;
            }
        }
        public int AccountBankID
        {
            set
            {
                _AccountBankID = value;
            }
            get
            {
                return _AccountBankID;
            }
        }
        public string AccountBankName
        {
            get
            {
                return _AccountBankName;
            }
        }
        public static DataTable ChacheSalaryDetailsTable
        {
            get
            {
                if (_ChacheSalaryDetailsTable == null && StatementIDs != null && StatementIDs != "")
                {
                    string strSql = "";
                    strSql = ApplicantWorkerStatementSalaryDetailsDb.SearchStr;
                    strSql += " where HRApplicantWorkerStatementSalaryDetails.OrginStatement in(" + _StatementIDs + ")";
                    _ChacheSalaryDetailsTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
                }
                return _ChacheSalaryDetailsTable;

            }
        }
        public static DataTable ChacheSubSectorTable
        {
            get
            {
                if (_ChacheSubSectorTable == null && StatementIDs != null && StatementIDs != "")
                {
                    string strSql = "";
                    strSql = ApplicantWorkerStatementSubSectorDb.SearchStr;
                    strSql += " where HRApplicantWorkerStatementSubSector.OrginStatement in(" + _StatementIDs + ")";
                    _ChacheSubSectorTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
                }
                return _ChacheSubSectorTable;

            }
        }
        public static DataTable ChacheLoanDiscountTable
        {
            get
            {
                if (_CacheLoanDiscountTable == null && StatementIDs != null && StatementIDs != "")
                {
                    string strSql = "";
                    strSql = ApplicantWorkerStatementLoanDiscountDb.SearchStr;
                    strSql += " where HRApplicantWorkerStatementLoanDiscount.DiscountStatement in(" + _StatementIDs + ")";
                    _CacheLoanDiscountTable = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
                }
                return _ChacheSalaryDetailsTable;

            }
        }
        public byte WorkStatus
        {
            set
            {
                _WorkStatus = value;
            }
        }
        public byte IsStopStatus
        {
            set
            {
                _IsStopStatus = value;
            }
        }
        public byte PaymentStatus
        {
            set
            {
                _PaymentStatus = value;
            }
        }
        public int GlobalStatementPayment
        {
            set
            {
                _GlobalStatementPayment = value;
            }
        }
        
        public byte RecommenedValueStatus
        {
            set
            {
                _RecommenedValueStatus = value;
            }
        }
        public DataTable SalaryDetailsTable
        {
            set
            {
                _SalaryDetailsTable = value;
            }
        }
        public DataTable SubSectorTable
        {
            set
            {
                _SubSectorTable = value;
            }
        }
        public DataTable LoanDiscountTable
        {
            set
            {
                _LoanDiscountTable = value;
            }

        }
        public DataTable DeletedLoanDiscountTable
        {
            set
            {
                _DeletedLoanDiscountTable = value;
            }

        }
        public string SectorIDs
        {
            set
            {
                _SectorIDs = value;
            }

        }
        public bool InsDateStatusSearch
        {
            set
            {
                _InsDateStatusSearch = value;
            }
            get
            {
                return _InsDateStatusSearch;
            }

        }
        public DateTime InsDateFromSearch
        {
            set
            {
                _InsDateFromSearch = value;
            }
            get
            {
                return _InsDateFromSearch;
            }

        }
        public double TransportValue
        {
            get { return _TransportValue; }
            set { _TransportValue = value; }
        }

        public double PhoneValue
        {
            get { return _PhoneValue; }
            set { _PhoneValue = value; }
        }
        public double FeedingValue
        {
            get { return _FeedingValue; }
            set { _FeedingValue = value; }
        }
        public double OtherValue
        {
            get { return _OtherValue; }
            set { _OtherValue = value; }
        }
        public double ExchangeValue
        {
            get { return _ExchangeValue; }
            set { _ExchangeValue = value; }
        }
        public DateTime InsDateToSearch
        {
            set
            {
                _InsDateToSearch = value;
            }
            get
            {
                return _InsDateToSearch;
            }

        }
        public int UserIDSearch
        {
            set
            {
                _UserIDSearch = value;
            }
        }
        public int FinancialStatementStatusSearch
        {
            set
            {
                _FinancialStatementStatusSearch = value;
            }
        }
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }

        }
        public int SectorFamilyID
        {
            set
            {
                _SectorFamilyID = value;
            }

        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
            get
            {
                return _ApplicantIDs;
            }
        }
        public string ApplicantExceptionIDs
        {
            set
            {
                _ApplicantExceptionIDs = value;
            }
        }
        public byte DetailEffectSearch
        {
            set
            {
                _DetailEffectSearch = value;
            }
        }
      
        public byte OperationDetailEffectSearch
        {
            set
            {
                _OperationDetailEffectSearch = value;
            }
        }
        public double PenaltyCountFormSearch
        {
            set
            {
                _PenaltyCountFromSearch = value;
            }
        }
        public double PenaltyCountToSearch
        {
            set
            {
                _PenaltyCountToSearch = value;
            }
        }
        public double OverDayCountFromSearch
        {
            set
            {
                _OverDayCountFromSearch = value;
            }
        }
        public double OverDayCountToSearch
        {
            set
            {
                _OverDayCountToSearch = value;
            }
        }
        public double AbsenceCountFromSearch
        {
            set
            {
                _AbsenceCountFromSearch = value;
            }
        }
        public double AbsenceCountToSearch
        {
            set
            {
                _AbsenceCountToSearch = value;
            }
        }
        public double DelayCountFromSearch
        {
            set
            {
                _DelayCountFromSearch = value;
            }
        }
        public double DelayCountToSearch
        {
            set
            {
                _DelayCountToSearch = value;
            }
        }
        public double BaseSalaryFromSearch
        {
            set
            {
                _BaseSalaryFromSearch = value;
            }
        }
        public double BaseSalaryToSearch
        {
            set
            {
                _BaseSalaryToSearch = value;
            }
        }
        public double IncreaseFromSearch
        {
            set
            {
                _IncreaseFromSearch = value;
            }
        }
        public double IncreaseToSearch
        {
            set
            {
                _IncreaseToSearch = value;
            }
        }
        public double TotalSalaryFromSearch
        {
            set
            {
                _TotalSalaryFromSearch = value;
            }
        }
        public double TotalSalaryToSearch
        {
            set
            {
                _TotalSalaryToSearch = value;
            }
        }
        public double DeservedFromSearch
        {
            set
            {
                _DeservedFromSearch = value;
            }
        }
        public double DeservedToSearch
        {
            set
            {
                _DeservedToSearch = value;
            }
        }
        public double BonusFromSearch
        {
            set
            {
                _BonusFromSearch = value;
            }
        }
        public int SalaryBonusTypeSearch
        {
            set
            {
                _SalaryBonusTypeSearch = value;
            }
        }
        public double BonusToSearch
        {
            set
            {
                _BonusToSearch = value;
            }
        }
        public double DiscountFromSearch
        {
            set
            {
                _DiscountFromSearch = value;
            }
        }
        public double DiscountToSearch
        {
            set
            {
                _DiscountToSearch = value;
            }
        }
        public int SalaryDiscountTypeSearch
        {
            set
            {
                _SalaryDiscountTypeSearch = value;
            }
        }
        public static double DeservedRatioSearch
        {
            set
            {
                _DeservedRatioSearch = value;
            }
        }
        public byte HasMotivationSearch
        {
            set
            {
                _HasMotivationSearch = value;
            }
        }
        public int MotivationTypeSearch
        {
            set
            {
                _MotivationTypeSearch = value;
            }
        }
        public int MotivationStatementSearch
        {
            set
            {
                _MotivationStatementSearch = value;
            }
        }
        public int MotivationStatementCostCenterIDSearch
        {
            set
            {
                _MotivationStatementCostCenterIDSearch = value;
            }
        }
        string _MotivationStatementCostCenterIDsSearch;
        public string MotivationStatementCostCenterIDsSearch
        {
            set
            {
                _MotivationStatementCostCenterIDsSearch = value;
            }
        }
        public byte MotivationStatusSearch
        {
            set
            {
                _MotivationStatusSearch = value;
            }
        }
        public bool IsDependOnStartDateInMotivation
        {
            set
            {
                _IsDependOnStartDateInMotivation = value;
            }
        }
        public DateTime StartDateInMotivation
        {
            set
            {
                _StartDateInMotivation = value;
            }
        }
        int _NonCountedDayStatus;

        public int NonCountedDayStatus
        {
            get { return _NonCountedDayStatus; }
            set { _NonCountedDayStatus = value; }
        }
        public static DataTable CachApplicantTable
        {
            set
            {
                _CachApplicantTable = value;
            }
            get
            {
                if (_CachApplicantTable == null)
                {
                    _CachApplicantTable = new DataTable();
                    _CachApplicantTable.Columns.Add("ApplicantID");
                }
                return _CachApplicantTable;
            }
        }
        public static DataTable CachCostCenterTable
        {
            set
            {
                _CachCostCenterTable = value;
            }
            get
            {
                if (_CachCostCenterTable == null)
                {
                    _CachCostCenterTable = new DataTable();
                    _CachCostCenterTable.Columns.Add("CostCenter");
                }
                return _CachCostCenterTable;
            }
        }
        public static DataTable CachJobNatureTypeTable
        {
            set
            {
                _CachJobNatureTypeTable = value;
            }
            get
            {
                if (_CachJobNatureTypeTable == null)
                {
                    _CachJobNatureTypeTable = new DataTable();
                    _CachJobNatureTypeTable.Columns.Add("JobNature");
                }
                return _CachJobNatureTypeTable;
            }
        }
        public DataTable BonusTable
        {
            set
            {
                _BonusTable = value;
            }
        }
        public DataTable DiscountTable
        {
            set
            {
                _DiscountTable = value;
            }
        }


        public string SetIncreaseValueStr
        {
            get
            {
                string strID = _ID == 0 ? "@@IDENTITY" : _ID.ToString();
                string Returned = "update HRApplicantWorker " +
             " set ApplicantCurrentSalary =ApplicantCurrentSalary+HRApplicantWorkerStatement.IncreaseValue " +
             "FROM    dbo.HRApplicantWorker INNER JOIN " +
             " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant " +
             " WHERE    (dbo.HRApplicantWorkerStatement.OriginStatementID = " + strID + ")";
                return Returned;
            }
        }
        public string ReSetIncreaseValueStr
        {
            get
            {
                string Returned = "update HRApplicantWorker " +
             "set ApplicantCurrentSalary =ApplicantCurrentSalary-HRApplicantWorkerStatement.IncreaseValue " +
             "FROM    dbo.HRApplicantWorker INNER JOIN " +
             " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant " +
             " WHERE    (dbo.HRApplicantWorkerStatement.OriginStatementID = " + _ID + ")";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                int IsSentToMail = _SentToMail ? 1 : 0;
                int intIsEndStatement = _IsEndStatement ? 1 : 0;
                int intIsStop = _IsStop ? 1 : 0;
                int intNotCalcBaseSalary = _NotCalcBaseSalary ? 1 : 0;
                int intNotCalcBaseSalaryDetails = _NotCalcBaseSalaryDetails ? 1 : 0;

                int intNotShowBaseSalary = _NotShowBaseSalary ? 1 : 0;
                int intNotShowBaseSalaryDetails = _NotShowBaseSalaryDetails ? 1 : 0;

                int intNotCalcBaseSalaryFellowShip = _NotCalcBaseSalaryFellowShip ? 1 : 0;
                int intIsNotHasAttendanceStatement = _IsNotHasAttendanceStatement ? 1 : 0;
                double dlStatementDate = _StatementDate.ToOADate() - 2;
                string ReturnedStr = "INSERT INTO HRApplicantWorkerStatement " +
                                     " (OriginStatementID, GlobalStatment, Applicant,AccountBankNo,AccountBankID" +
                                     ", BankBranchCode, AccountTypeCode "+
                                     ",FinancialStatementDate,FinancialStatementType," +
                                     " LoanDiscount,PartTimeTotalMinutes,PartTimeUnit,PartTimeValue, BaseSalary,DetailsValue,RewardValue, IncreaseValue,AttendanceDiscount,PenaltyDiscount," +
                                     " DelayDiscount,OverDays,OverTimeValue,AbsenceDiscount,NonCountedDaysDiscount,UtilityValue,FellowShipFund,FellowShipFundBonus," +
                                     " SentToMail,DiscountValue,BonusValue,OldDeserved,TotalDeserved,DelayValue,OverDaysBonus,AbsenceCount,NonCountedDays,CostCenter,MotivationCostCenter,JobNature,IsEndStatement,IsStop,Remark" +
                                     " ,PayBackValue,FellowShipPaymentValue,FurloughValue,FurloughDiscount,VacationValue,VacationDiscount,"+
                                     " NotCalcBaseSalary,NotCalcBaseSalaryDetails,NotCalcBaseSalaryFellowShip,IsNotHasAttendanceStatement"+
                                     " ,NotShowBaseSalary,NotShowBaseSalaryDetails)" +
                                     " VALUES  (" + _ID + "," + _GlobalStatment + "," + _Applicant + ",'" + _AccountBankNo + "',"+
                                     _AccountBankID+",'" + _BankBranchCode +"','"+ _AccountTypeCode + "'," +
                                     dlStatementDate + "," + _FinancialStatementType + "," +
                                     " " + _LoanDiscount + "," + _PartTimeTotalMinutes + "," + _PartTimeUnit + "," + _PartTimeValue + "," + _BaseSalary + "," + _DetailsValue + "," +
                                     " " + _RewardValue + "," + _IncreaseValue + "," + _AttendanceDiscount + "," + _PenaltyDiscount + "," +
                                     " " + _DelayDiscount + "," + _OverDays + "," + _OverTimeValue + "," +
                                     " " + _AbsenceDiscount + "," + _NonCountedDaysDiscount + "," + _UtilityValue + "," + _FellowShipFund + "," + _FellowShipFundBonus + "," +
                                     " " + IsSentToMail + "," + _DiscountValue + "," + _BonusValue + "," + _OldDeserved + "," +
                                     " " + _TotalDeserved + "," + _DelayValue + "," + _OverDaysBonus + "," + _AbsenceCount + "," + _NonCountedDays + "," + _CostCenter + "," + _MotivationCostCenter + "," + _JobNature + "," + intIsEndStatement + "," + intIsStop + ",'" + _Remark + "'" +
                                     " ," + _PayBackValue + "," + _FellowShipPaymentValue + "," + _FurloughValue + "," + _FurloughDiscount + "," + _VacationValue + "," + _VacationDiscount + ""+
                                     " ," + intNotCalcBaseSalary + "," + intNotCalcBaseSalaryDetails + "," + intNotCalcBaseSalaryFellowShip + "," + intIsNotHasAttendanceStatement + ""+
                                     " ," + intNotShowBaseSalary + "," + intNotShowBaseSalaryDetails + ")";
                ReturnedStr += " " + SetIncreaseValueStr;
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                int IsSentToMail = _SentToMail ? 1 : 0;
                int intIsStop = _IsStop ? 1 : 0;
                int intNotCalcBaseSalary = _NotCalcBaseSalary ? 1 : 0;
                int intNotCalcBaseSalaryDetails = _NotCalcBaseSalaryDetails ? 1 : 0;
                int intNotCalcBaseSalaryFellowShip = _NotCalcBaseSalaryFellowShip ? 1 : 0;
                int intNotShowBaseSalary = _NotShowBaseSalary ? 1 : 0;
                int intNotShowBaseSalaryDetails = _NotShowBaseSalaryDetails ? 1 : 0;
                int intIsEndStatement = _IsEndStatement ? 1 : 0;
                double dlStatementDate = _StatementDate.ToOADate() - 2;
                int intIsNotHasAttendanceStatement = _IsNotHasAttendanceStatement ? 1 : 0;
                
                string ReturnedStr =  ReSetIncreaseValueStr +"  UPDATE    HRApplicantWorkerStatement" +
                                     "   SET BaseSalary =" + _BaseSalary + "" +
                                     " , FinancialStatementDate =" + dlStatementDate + " " +
                                     " , PartTimeTotalMinutes =" + _PartTimeTotalMinutes + "" +
                                     " , FinancialStatementType =" + _FinancialStatementType + "" +
                                     " , PartTimeUnit =" + _PartTimeUnit + "" +
                                     " , PartTimeValue =" + _PartTimeValue + "" +
                                     " , DetailsValue =" + _DetailsValue + "" +
                                     " , DiscountValue =" + _DiscountValue + "" +
                                     " , BonusValue =" + _BonusValue + "" +
                                     " , LoanDiscount =" + _LoanDiscount + "" +
                                     " , RewardValue =" + _RewardValue + "" +
                                     " , IncreaseValue =" + _IncreaseValue + "" +
                                     " , AttendanceDiscount =" + _AttendanceDiscount + "" +
                                     " , PenaltyDiscount =" + _PenaltyDiscount + "" +
                                     " , DelayDiscount =" + _DelayDiscount + "" +
                                     " , OverDays = " + _OverDays + "" +
                                     " , OverTimeValue =" + _OverTimeValue + "" +
                                     " , AbsenceDiscount =" + _AbsenceDiscount + "" +
                                     " , NonCountedDaysDiscount =" + _NonCountedDaysDiscount + "" +
                                     " , UtilityValue = " + _UtilityValue + "" +
                                     " , FellowShipFund = " + _FellowShipFund + "" +
                                     " , FellowShipFundBonus = " + _FellowShipFundBonus + "" +
                                     " , OldDeserved =" + _OldDeserved + "" +
                                     " , TotalDeserved =" + _TotalDeserved + "" +
                                     " , SentToMail =" + IsSentToMail + "" +
                                     " , DelayValue =" + _DelayValue + "" +
                                     " , OverDaysBonus =" + _OverDaysBonus + "" +
                                     " , AbsenceCount =" + _AbsenceCount + "" +
                                     " , NonCountedDays =" + _NonCountedDays + "" +
                                     " , CostCenter =" + _CostCenter + "" +
                                     " , MotivationCostCenter = " + _MotivationCostCenter + "" +
                                     " , JobNature =" + _JobNature + "" +
                                     " , AccountBankNo ='" + _AccountBankNo + "'" +
                                     ",AccountBankID="+_AccountBankID+
                                     ", BankBranchCode='"+ _BankBranchCode + "'"+
                                     ", AccountTypeCode = '"+ _AccountTypeCode +"'"+
                                     " , IsEndStatement =" + intIsEndStatement + "" +
                                     " , IsStop =" + intIsStop + "" +
                                     " , IsNotHasAttendanceStatement =" + intIsNotHasAttendanceStatement + "" +
                                     " , Remark = '" + _Remark + "'" +
                                     " , PayBackValue =" + _PayBackValue + "" +
                                     " , FellowShipPaymentValue =" + _FellowShipPaymentValue + "" +
                                     " , FurloughValue =" + _FurloughValue + "" +
                                     " , FurloughDiscount =" + _FurloughDiscount + "" +
                                     " , VacationValue =" + _VacationValue + "" +
                                     " , VacationDiscount =" + _VacationDiscount + "" +
                                     " , NotCalcBaseSalary = " + intNotCalcBaseSalary + "" +
                                     " , NotCalcBaseSalaryDetails = " + intNotCalcBaseSalaryDetails + "" +
                                     " , NotCalcBaseSalaryFellowShip = " + intNotCalcBaseSalaryFellowShip + "" +
                                     " , NotShowBaseSalary = " + intNotShowBaseSalary + "" +
                                     " , NotShowBaseSalaryDetails = " + intNotShowBaseSalaryDetails + "" +
                                     " WHERE     (OriginStatementID = " + _ID + ")";
                //DelayValue,OverDaysBonus,AbsenceCount,NonCountedDays
                ReturnedStr += " " + SetIncreaseValueStr;
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = ReSetIncreaseValueStr + " DELETE FROM HRApplicantWorkerStatement WHERE     (OriginStatementID = " + _ID + ") ";
                return ReturnedStr;
            }
        }
        public static string SubSectorSearchStr
        {
            get
            {
                string Returned = "SELECT   OrginStatement, MAX(StatementSubsectorID) AS MaxSubSector "+
                       " FROM         dbo.HRApplicantWorkerStatementSubSector "+
                       " GROUP BY OrginStatement ";
                Returned = "select SubSectorTable.* "+
                    " from ("+ ApplicantWorkerStatementSubSectorDb.SearchStr +") as SubSectorTable "+
                    " inner join ("+ Returned +") as MaxSubSectorTable  "+
                    " on SubSectorTable.OrginStatement = MaxSubSectorTable.OrginStatement " +
                    " and  SubSectorTable.StatementSubsectorID = MaxSubSectorTable.MaxSubSector   ";
                return Returned;
            }
        }
        public static string ExchangeSearchStr
        {
            get
            {
                string Retuned = "SELECT     OriginStatement, SUM(ExchangeValue) AS TotalExchangeValue "+
                  " FROM         dbo.HRApplicantWorkerStatementExchange "+
                  " GROUP BY OriginStatement ";
                return Retuned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strBank = "SELECT  BankID AS StatementBankID, BankNameA AS StatementBankName " +
                    " FROM    dbo.GLBank ";
                string strSalaryDetails = "SELECT  OrginStatement as DetailsOriginStatement, SUM(DetailRecomendedValue) AS TotalDetalsValue, SUM(CASE WHEN DetailType = 3 THEN DetailRecomendedValue ELSE 0 END) AS PhoneDetalsValue, " +
                      " SUM(CASE WHEN DetailType = 2 THEN DetailRecomendedValue ELSE 0 END) AS TransportDetalsValue, SUM(CASE WHEN DetailType = 5 THEN DetailRecomendedValue ELSE 0 END)  " +
                       " AS FeedingDetalsValue, SUM(CASE WHEN DetailType NOT IN (2, 3, 5) THEN DetailRecomendedValue ELSE 0 END) AS OtherDetalsValue " +
                       " FROM         dbo.HRApplicantWorkerStatementSalaryDetails "+
                       " GROUP BY OrginStatement ";

                string strMotivationCostCenter = "SELECT CostCenterID AS StatementMotivationCostCenterID, CostCenterNameA AS StatementMotivationCostCenterName "+
                        " FROM            dbo.GLCostCenter ";
                string ReturnedStr = " SELECT     OriginTable.*,dbo.HRApplicantWorkerStatement.GlobalStatment, dbo.HRApplicantWorkerStatement.Applicant"+
                    ",HRApplicantWorkerStatement.AccountBankNo,CONVERT(bigint, REPLACE(HRApplicantWorkerStatement.AccountBankNo, '/', '')) as StatementBankIntNo" +
                    ",dbo.HRApplicantWorkerStatement.BankBranchCode AS StatementBankBranchCode, dbo.HRApplicantWorkerStatement.AccountTypeCode AS StatementAccountTypeCode "+
                    ", dbo.HRApplicantWorkerStatement.PartTimeTotalMinutes,dbo.HRApplicantWorkerStatement.PartTimeUnit as StatementPartTimeUnit,dbo.HRApplicantWorkerStatement.PartTimeValue" +
                    ", dbo.HRApplicantWorkerStatement.BaseSalary,HRApplicantWorkerStatement.FinancialStatementDate,HRApplicantWorkerStatement.FinancialStatementType, " +
                                     " dbo.HRApplicantWorkerStatement.DetailsValue, dbo.HRApplicantWorkerStatement.DiscountValue, dbo.HRApplicantWorkerStatement.BonusValue,HRApplicantWorkerStatement.PayBackValue,HRApplicantWorkerStatement.FellowShipPaymentValue, " +
                                     " dbo.HRApplicantWorkerStatement.LoanDiscount, dbo.HRApplicantWorkerStatement.RewardValue,dbo.HRApplicantWorkerStatement.IncreaseValue, " +
                                     " dbo.HRApplicantWorkerStatement.AttendanceDiscount, dbo.HRApplicantWorkerStatement.PenaltyDiscount,dbo.HRApplicantWorkerStatement.DelayDiscount,dbo.HRApplicantWorkerStatement.OverDays," +
                                     " dbo.HRApplicantWorkerStatement.OverTimeValue,dbo.HRApplicantWorkerStatement.AbsenceDiscount,dbo.HRApplicantWorkerStatement.NonCountedDaysDiscount,dbo.HRApplicantWorkerStatement.UtilityValue,FellowShipFund,FellowShipFundBonus," +
                                     " dbo.HRApplicantWorkerStatement.DelayValue,dbo.HRApplicantWorkerStatement.OverDaysBonus,dbo.HRApplicantWorkerStatement.AbsenceCount,dbo.HRApplicantWorkerStatement.NonCountedDays," +
                                     " HRApplicantWorkerStatement.FurloughValue,HRApplicantWorkerStatement.FurloughDiscount,HRApplicantWorkerStatement.VacationValue,HRApplicantWorkerStatement.VacationDiscount," +
                                     " HRApplicantWorkerStatement.NotCalcBaseSalary, HRApplicantWorkerStatement.NotCalcBaseSalaryDetails,HRApplicantWorkerStatement.NotCalcBaseSalaryFellowShip,HRApplicantWorkerStatement.IsNotHasAttendanceStatement," +
                                     " HRApplicantWorkerStatement.NotShowBaseSalary,HRApplicantWorkerStatement.NotShowBaseSalaryDetails," +
                                     " dbo.HRApplicantWorkerStatement.OldDeserved, dbo.HRApplicantWorkerStatement.TotalDeserved, dbo.HRApplicantWorkerStatement.SentToMail ,GlobalStatementTable.*,ApplicantWorkerTable.* " +
                                     " ,dbo.HRApplicantWorkerStatement.CostCenter,HRApplicantWorkerStatement.JobNature," +
                                     " dbo.HRApplicantWorkerStatement.IsEndStatement,dbo.HRApplicantWorkerStatement.IsStop," +
                                     " HRApplicantWorkerStatement.Remark,HRApplicantWorkerStatement.MotivationCostCenter," +
                                     " CostCenterTable.*,FinancialStatementTypeTable.*,JobNatureTypeTable.*" +// ,MotivationCostCenterTable.* " +
                                     ",BankTable.* " +
                                     ",SubSectorTable.*,DetailsTable.*,ExchangeTable.TotalExchangeValue  " +
                                     ",MotivationCostCenterTable.* " +
                                     " FROM         HRApplicantWorkerStatement" +
                                     " Left Outer join (" + GlobalStatementDb.SearchStr + ") GlobalStatementTable On GlobalStatementTable.StatementID = HRApplicantWorkerStatement.GlobalStatment " +
                                     " inner join (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerStatement.Applicant " +
                                     " inner join (" + OriginStatementDb.SearchStr + ") as OriginTable on HRApplicantWorkerStatement.OriginStatementID = OriginTable.OriginStatementID   " +
                                     " Left Outer join (" + CostCenterHRDb.SearchStr + ") as CostCenterTable On CostCenterTable.CostCenterID = HRApplicantWorkerStatement.CostCenter " +
                                     " Left Outer join (" + FinancialStatementTypeDb.SearchStr + ") as FinancialStatementTypeTable On FinancialStatementTypeTable.FinancialStatementTypeID = HRApplicantWorkerStatement.FinancialStatementType " +
                                     " Left Outer join (" + JobNatureTypeDb.SearchStr + ") as JobNatureTypeTable On JobNatureTypeTable.JobNatureID = HRApplicantWorkerStatement.JobNature " +
                                      " left outer join (" + strBank + ") as BankTable " +
                                      " on  HRApplicantWorkerStatement.AccountBankID = BankTable.StatementBankID  " +
                                      " left outer join (" + SubSectorSearchStr + ") as SubSectorTable " +
                                      "  on HRApplicantWorkerStatement.OriginStatementID = SubSectorTable.OrginStatement " +
                                      " left outer join (" + strSalaryDetails + ") as DetailsTable " +
                                      " on HRApplicantWorkerStatement.OriginStatementID = DetailsTable.DetailsOriginStatement  " +
                                      " left outer join (" + ExchangeSearchStr + ") as ExchangeTable " +
                                      " on   HRApplicantWorkerStatement.OriginStatementID = ExchangeTable.OriginStatement " +
                                      " left outer join (" + strMotivationCostCenter + ") as MotivationCostCenterTable  " +
                                      " on dbo.HRApplicantWorkerStatement.MotivationCostCenter = MotivationCostCenterTable.StatementMotivationCostCenterID ";
                string strTemp = @"SELECT       distinct dbo.HRApplicantWorkerStatement.Applicant as DApplicant
FROM            dbo.HRApplicantWorkerStatement INNER JOIN
                         dbo.HRApplicantWorkerStatementBonus ON dbo.HRApplicantWorkerStatement.OriginStatementID = dbo.HRApplicantWorkerStatementBonus.OriginStatement
WHERE        (dbo.HRApplicantWorkerStatement.GlobalStatment = 355) AND (dbo.HRApplicantWorkerStatementBonus.BonusType IN (6, 28))";
 //               ReturnedStr += " inner join ("+strTemp+ @") TempDTable 
 //on dbo.HRApplicantWorkerStatement.Applicant= TempDTable.DApplicant ";
                                    //  " inner join VTEMPLoanDiscount on HRApplicantWorkerStatement.OriginStatementID =  VTEMPLoanDiscount.DiscountStatement "; 


                return ReturnedStr;
            }
        }
        public string StrSearch
        {
            get
            {
                string StrSql = SearchStr + " where 1=1 ";
                if (_ID != 0)
                    StrSql = StrSql + " And HRApplicantWorkerStatement.OriginStatementID = " + _ID + "";
                if (_FinancialStatementStatusSearch != 0)
                {
                    if (_FinancialStatementStatusSearch == 1)
                    {
                        StrSql = StrSql + " And GlobalStatment <> 0";
                    }
                    else if (_FinancialStatementStatusSearch == 2)
                    {
                        StrSql = StrSql + " And GlobalStatment = 0";
                    }
                }

                if (_GlobalStatment != 0)
                    StrSql = StrSql + " And GlobalStatment = " + _GlobalStatment + "";
                if (_Applicant != 0)
                    StrSql = StrSql + " And Applicant = " + _Applicant + "";

                if (_BranchID != 0)
                {
                    if (_BranchID != 0 || _SectorFamilyID != 0 || (_SectorIDs != null && _SectorIDs != ""))
                    {
                        string strSector = "SELECT HRApplicantWorkerCurrentSubSector.ApplicantID " +
                              " FROM         HRApplicantWorkerCurrentSubSector INNER JOIN " +
                              " HRSubSector ON HRApplicantWorkerCurrentSubSector.SubSectorID = HRSubSector.SubSectorID INNER JOIN " +
                             " HRSector ON HRSubSector.SectorID = HRSector.SectorID " +
                             " Inner join  HRSubSectorBranch On HRSubSectorBranch.SubSectorID = HRSubSector.SubSectorID ";
                        if (_SectorFamilyID != 0)
                            strSector += " where HRSector.SectorFamilyID = " + _SectorFamilyID;
                        else
                            strSector += " where HRSector.SectorID in (" + _SectorIDs + ")";
                        if (_JobNature != 0)
                            strSector += " and  HRApplicantWorkerCurrentSubSector.JobNatureID =" + _JobNature;
                        strSector += " And  HRSubSectorBranch.BranchID = " + _BranchID + "";
                        StrSql += " and Applicant in (" + strSector + ")";

                    }
                }
                else if (_SectorFamilyID != 0 || (_SectorIDs != null && _SectorIDs != "") || _JobNature != 0)
                {
                    string strSector = "SELECT HRApplicantWorkerCurrentSubSector.ApplicantID " +
                          " FROM         HRApplicantWorkerCurrentSubSector INNER JOIN " +
                          " HRSubSector ON HRApplicantWorkerCurrentSubSector.SubSectorID = HRSubSector.SubSectorID INNER JOIN " +
                         " HRSector ON HRSubSector.SectorID = HRSector.SectorID where (1=1) ";
                    if (_SectorFamilyID != 0)
                        strSector += " and HRSector.SectorFamilyID = " + _SectorFamilyID;
                    if (_SectorIDs != null && _SectorIDs != "")
                        strSector += " and  HRSector.SectorID in (" + _SectorIDs + ")";
                    if (_JobNature != 0)
                        strSector += " and  HRApplicantWorkerCurrentSubSector.JobNatureID =" + _JobNature;
                    //if (_JobNatureIDs != null && _JobNatureIDs != "")
                    //{
                    //    strSector += " and  HRApplicantWorkerCurrentSubSector.JobNatureID in (" + _JobNatureIDs + ") ";
                    //}
                    StrSql += " and Applicant in (" + strSector + ")";

                }
                if (_ApplicantIDs != null && _ApplicantIDs != "")
                {
                    StrSql = StrSql + " And Applicant In ( " + _ApplicantIDs + ")";
                }
                if (_ApplicantExceptionIDs != null && _ApplicantExceptionIDs != "")
                {
                    StrSql = StrSql + " And Applicant Not In ( " + _ApplicantExceptionIDs + ")";
                }
                if (_WorkStatus != 0)
                {
                    if (_WorkStatus == 1) // not Work
                        StrSql += " and IsEndStatement = 1 ";
                    else
                        StrSql += " and IsEndStatement = 0 ";
                }
                if (_ApplicantStatusWorker != 0)
                {
                    if (_ApplicantStatusWorker == 1)
                    {
                        StrSql += " And (Applicant in (Select ApplicantID From HRApplicantWorker Where ApplicantStatusID =1))";
                    }
                    else if (_ApplicantStatusWorker == 2)
                    {
                        StrSql += " And (Applicant in (Select ApplicantID From HRApplicantWorker Where ApplicantStatusID <> 1))";
                    }
                }
                if (_IsStopStatus != 0)
                {
                    if (_IsStopStatus == 1) // not stop
                        StrSql += " and IsStop = 0 ";
                    else
                        StrSql += " and IsStop = 1 ";
                }
                if (_HasMotivationSearch != 0)
                {
                    if (_HasMotivationSearch == 1)
                    {
                        StrSql += " And (Applicant in (SELECT ApplicantID FROM HRApplicantWorker WHERE     (HasMotivation = 1) ))";
                    }
                    else if (_HasMotivationSearch == 2)
                    {
                        StrSql += " And (Applicant in (SELECT ApplicantID FROM HRApplicantWorker WHERE  (HasMotivation = 1) ))";
                    }
                }
                if (_MotivationTypeSearch != 0)
                {
                    StrSql += " And (Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE    (MotivationType = " + _MotivationTypeSearch + ") ))";
                }
                if (_NonCountedDayStatus == 1)
                {
                    StrSql += " and dbo.HRApplicantWorkerStatement.NonCountedDays > 0 ";


                }
                if (_RecommenedValueStatus != 0)
                {
                    if (_RecommenedValueStatus == 1)
                    {
                        StrSql += " and HRApplicantWorkerStatement.OriginStatementID  in (SELECT     StatementTable.OriginStatementID " +
                                  " FROM         HRApplicantWorkerAttendanceStatement AWASTable INNER JOIN" +
                                  " (SELECT     OriginStatementID" +
                                  " FROM         HRApplicantWorkerStatement" +
                                  " WHERE     (GlobalStatment = " + _GlobalStatment + ")) StatementTable ON AWASTable.FinancialStatement = StatementTable.OriginStatementID" +
                                  " WHERE     (AWASTable.DelayCountValue <> AWASTable.DelayCountRecommendedValue) OR " +
                                  " (AWASTable.AbsenceDayCountValue <> AWASTable.AbsenceDayCountRecommendedValue)) ";
                    }

                }
                if (_CostCenterIDs != null && _CostCenterIDs != "")
                {
                    //StrSql += " and Applicant in (SELECT     Applicant "+
                    // " FROM  dbo.HRApplicantWorkerCostCenter where CostCenter in(" +
                    // _CostCenterIDs + ") ) ";
                    if (_MotivationStatementIDSearch == 0)
                        StrSql += " and HRApplicantWorkerStatement.CostCenter in (" + _CostCenterIDs + ")  ";
                    else
                    {
                        string strCostCenter = " SELECT     CostCenter FROM         HRMotivationStatementCostCenterTree WHERE     (MotivationStatement = " + _MotivationStatementIDSearch + ") AND (CostCenterParent in( " + _CostCenterIDs + "))";
                        StrSql += " and HRApplicantWorkerStatement.MotivationCostCenter in (" + strCostCenter + ")  ";
                    }
                }
                if (_MotivationCostCenterIDs != null && _MotivationCostCenterIDs != "")
                {
                    //StrSql += " and Applicant in (SELECT     Applicant "+
                    // " FROM  dbo.HRApplicantWorkerCostCenter where CostCenter in(" +
                    // _CostCenterIDs + ") ) ";
                    if (_MotivationStatementIDSearch == 0)
                        StrSql += " and HRApplicantWorkerStatement.MotivationCostCenter in (" + _MotivationCostCenterIDs + ")  ";
                    else
                    {
                        string strCostCenter = " SELECT     CostCenter FROM         HRMotivationStatementCostCenterTree " +
                                               " WHERE     (MotivationStatement = " + _MotivationStatementIDSearch + ")" +
                                               " AND (CostCenterParent in( " + _MotivationCostCenterIDs + "))";
                        StrSql += " and HRApplicantWorkerStatement.MotivationCostCenter in (" + strCostCenter + ")  ";
                    }
                }
                if (_JobNatureIDs != null && _JobNatureIDs != "")
                    StrSql += " and HRApplicantWorkerStatement. JobNature in (" + _JobNatureIDs + ")  ";

                if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
                {
                    StrSql += " and HRApplicantWorkerStatement.GlobalStatment in (" + _GlobalStatementIDs + ")  ";
                }
                if (_StatementSearchIDs != null && _StatementSearchIDs != "")
                {
                    StrSql += " and HRApplicantWorkerStatement.OriginStatementID in (" + _StatementSearchIDs + ")  ";
                }
                if (_InsDateStatusSearch == true)
                {
                    double dblFrom = SysUtility.Approximate(_InsDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                    double dblTo = SysUtility.Approximate(_InsDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                    StrSql = StrSql + " And  OriginTable.TimIns Between " + dblFrom + " And " + dblTo + " ";
                }
                if (_UserIDSearch != 0)
                {
                    StrSql += " And OriginTable.UsrIns = " + _UserIDSearch + "";
                }
                if (_HasAccountBankNo == 1)
                {
                    StrSql += " And HRApplicantWorkerStatement.AccountBankNo Is Not Null And HRApplicantWorkerStatement.AccountBankNo <> ''";
                }
                else if (_HasAccountBankNo == 2)
                {
                    StrSql += " And ( HRApplicantWorkerStatement.AccountBankNo Is Null Or HRApplicantWorkerStatement.AccountBankNo = '')";
                }

                #region MyRegion


                if (_DetailEffectSearch != 0)
                {
                    if (_DetailEffectSearch == 1) // Penalty
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.PenaltyDiscount <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.PenaltyDiscount Between " + _PenaltyCountFromSearch + " And " + _PenaltyCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.PenaltyDiscount <= " + _PenaltyCountFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.PenaltyDiscount >= " + _PenaltyCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.PenaltyDiscount = " + _PenaltyCountFromSearch + " )";
                        }

                    }
                    else if (_DetailEffectSearch == 2) // OverDays
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.OverDays <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.OverDays Between " + _OverDayCountFromSearch + " And " + _OverDayCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.OverDays <= " + _OverDayCountFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.OverDays >= " + _OverDayCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.OverDays = " + _OverDayCountFromSearch + " )";
                        }
                    }
                    else if (_DetailEffectSearch == 3) // Absence
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.AbsenceCount <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.AbsenceCount Between " + _AbsenceCountFromSearch + " And " + _AbsenceCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.AbsenceCount <= " + _AbsenceCountFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.AbsenceCount >= " + _AbsenceCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.AbsenceCount = " + _AbsenceCountFromSearch + " )";
                        }
                    }
                    else if (_DetailEffectSearch == 4) // Delay
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DelayValue <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DelayValue Between " + _DelayCountFromSearch + " And " + _DelayCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DelayValue <= " + _DelayCountFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DelayValue >= " + _DelayCountToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DelayValue = " + _DelayCountFromSearch + " )";
                        }
                    }
                    else if (_DetailEffectSearch == 5) // BaseSalry
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) Between " + _BaseSalaryFromSearch + " And " + _BaseSalaryToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) <= " + _BaseSalaryFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) >= " + _BaseSalaryToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) = " + _BaseSalaryFromSearch + " )";
                        }
                    }
                    else if (_DetailEffectSearch == 6) // BaseSalry
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved Between " + _DeservedFromSearch + " And " + _DeservedToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved <= " + _DeservedFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved >= " + _DeservedToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved = " + _DeservedFromSearch + " )";
                        }
                    }
                    else if (_DetailEffectSearch == 7) // Bonus
                    {
                        string strBonusType = "";
                        if (_SalaryBonusTypeSearch != 0)
                        {
                            if (_GlobalStatment != 0)
                                strBonusType = " And (OriginTable.OriginStatementID in ( SELECT HRApplicantWorkerStatementBonus.OriginStatement FROM  HRApplicantWorkerStatementBonus  WHERE (HRApplicantWorkerStatementBonus.BonusType = " + _SalaryBonusTypeSearch + ") " +
                                                " AND (HRApplicantWorkerStatementBonus.OriginStatement IN " +
                                                " (SELECT AWS.OriginStatementID as OSID" +
                                                " FROM HRApplicantWorkerStatement AS AWS" +
                                                " WHERE (AWS.GlobalStatment = " + _GlobalStatment + ")))))";
                            else if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
                                strBonusType = " And (OriginTable.OriginStatementID in ( SELECT HRApplicantWorkerStatementBonus.OriginStatement FROM  HRApplicantWorkerStatementBonus  WHERE (HRApplicantWorkerStatementBonus.BonusType = " + _SalaryBonusTypeSearch + ") " +
                                            " AND (HRApplicantWorkerStatementBonus.OriginStatement IN " +
                                            " (SELECT AWS.OriginStatementID as OSID" +
                                            " FROM HRApplicantWorkerStatement AS AWS" +
                                            " WHERE (AWS.GlobalStatment in (" + _GlobalStatementIDs + "))))))";
                        }
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.BonusValue <> 0 )  " + strBonusType + "";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.BonusValue Between " + _BonusFromSearch + " And " + _BonusToSearch + " ) " + strBonusType + "";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.BonusValue <= " + _BonusFromSearch + " ) " + strBonusType + "";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.BonusValue >= " + _BonusToSearch + " ) " + strBonusType + "";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.BonusValue = " + _BonusFromSearch + " ) " + strBonusType + "";
                        }
                    }
                    else if (_DetailEffectSearch == 8) // Discount
                    {
                        string strDiscountType = "";
                        if (_SalaryDiscountTypeSearch != 0)
                        {
                            if (_GlobalStatment != 0)
                                strDiscountType = " And (OriginTable.OriginStatementID in ( SELECT     HRApplicantWorkerStatementDiscount.OriginStatement FROM         HRApplicantWorkerStatementDiscount WHERE     (HRApplicantWorkerStatementDiscount.DiscountType = " + _SalaryDiscountTypeSearch + ") " +
                                                " AND (HRApplicantWorkerStatementDiscount.OriginStatement IN " +
                                                " (SELECT     AWS.OriginStatementID as OSID " +
                                                " FROM         HRApplicantWorkerStatement AS AWS" +
                                                " WHERE     (AWS.GlobalStatment = " + _GlobalStatment + ")))))";
                            else if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
                                strDiscountType = " And (OriginTable.OriginStatementID in ( SELECT     HRApplicantWorkerStatementDiscount.OriginStatement FROM         HRApplicantWorkerStatementDiscount WHERE     (HRApplicantWorkerStatementDiscount.DiscountType = " + _SalaryDiscountTypeSearch + ") " +
                                            " AND (HRApplicantWorkerStatementDiscount.OriginStatement IN " +
                                            " (SELECT     AWS.OriginStatementID as OSID " +
                                            " FROM         HRApplicantWorkerStatement AS AWS" +
                                            " WHERE     (AWS.GlobalStatment in ( " + _GlobalStatementIDs + "))))))";

                        }
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DiscountValue <> 0 ) " + strDiscountType + "";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DiscountValue Between " + _DiscountFromSearch + " And " + _DiscountToSearch + " )" + strDiscountType + "";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DiscountValue <= " + _DiscountFromSearch + " ) " + strDiscountType + "";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DiscountValue >= " + _DiscountToSearch + " ) " + strDiscountType + "";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.DiscountValue = " + _DiscountFromSearch + " ) " + strDiscountType + "";
                        }
                    }
                    else if (_DetailEffectSearch == 9) // Discount
                    {
                        if (_OperationDetailEffectSearch == 0)
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.IncreaseValue <> 0 )";
                        }
                        else if (_OperationDetailEffectSearch == 1) //BW
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.IncreaseValue Between " + _IncreaseFromSearch + " And " + _IncreaseToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 2) //LessThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.IncreaseValue <= " + _IncreaseFromSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 3) //LargeThan
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.IncreaseValue >= " + _IncreaseToSearch + " )";
                        }
                        else if (_OperationDetailEffectSearch == 4) //Equal
                        {
                            StrSql += " And ( HRApplicantWorkerStatement.IncreaseValue = " + _IncreaseFromSearch + " )";
                        }
                        
                    }


                }
                #endregion
                if (_HasMotivationSearch != 0)
                {
                    if (_HasMotivationSearch == 1)
                    {
                        StrSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE     (HasMotivation = 1)";
                        if (_IsDependOnStartDateInMotivation == true)
                        {
                            double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                            StrSql += "And (ApplicantStartDate < = " + dlStartDate + ")";
                        }

                        StrSql += " ))";
                    }
                    else if (_HasMotivationSearch == 2)
                    {
                        StrSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE     (HasMotivation = 0)";
                        if (_IsDependOnStartDateInMotivation == true)
                        {
                            double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                            StrSql += "And (ApplicantStartDate < = " + dlStartDate + ")";
                        }

                        StrSql += " ))";
                    }
                }
                else
                {
                    if (_IsDependOnStartDateInMotivation == true)
                    {
                        double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                        StrSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker Where (ApplicantStartDate < = " + dlStartDate + ")))";
                    }
                }
                if (_PaymentStatus != 0)
                {
                    if (_PaymentStatus == 1)
                    {
                        StrSql += " And (HRApplicantWorkerStatement.OriginStatementID in ( SELECT OriginStatement " +
                                  " FROM HRApplicantWorkerStatementExchange ";
                        if (_GlobalStatementPayment != 0)
                            StrSql += " WHERE (GlobalStatementPayment = " + _GlobalStatementPayment + ")";
                        StrSql += "))";
                    }
                    else if (_PaymentStatus == 2)
                    {
                        StrSql += " And (HRApplicantWorkerStatement.OriginStatementID not in ( SELECT OriginStatement " +
                                  " FROM HRApplicantWorkerStatementExchange ";
                        if (_GlobalStatementPayment != 0)
                            StrSql += " WHERE (GlobalStatementPayment = " + _GlobalStatementPayment + ")";

                        StrSql += "))";
                    }
                }
                return StrSql;
            }
        }
        public  string SearchSumStr
        {
            get
            {
                string Returned = "";
                string strSelect = "1 as IsSummary" +
                    ",count(ApplicantAddedBonusStatementID) as TotalCount" +
                    ",sum(AddedBonusValue) as TotalValue" +
                    ",sum(case when AccountBankNo is null  or AccountBankNo ='' then 0 else AddedBonusBaseValue end) as BankTotalValue " +
                    ",sum(case when AccountBankNo is not null  and AccountBankNo <>'' then 0 else AddedBonusBaseValue end) as CofferTotalValue " +
                    ",sum(case when AccountBankNo is null  or AccountBankNo ='' or AddedBonusStatementBankID = 3 then 0  else AddedBonusBaseValue end) as TotalAlexValue " +
                    ",sum(case when AccountBankNo is null  or AccountBankNo ='' or AddedBonusStatementBankID <> 3 then 0  else AddedBonusBaseValue end) as TotalAhlyValue " +
                       ",sum(case when AccountBankNo is null  or AccountBankNo ='' then 0 else 1 end) as BankTotalCount " +
                    ",sum(case when AccountBankNo is not null  and AccountBankNo <>'' then 0 else 1 end) as CofferTotalCount " +
                    ",sum(case when AccountBankNo is null  or AccountBankNo ='' or AddedBonusStatementBankID = 3 then 0  else 1 end) as TotalAlexCount " +
                    ",sum(case when AccountBankNo is null  or AccountBankNo ='' or AddedBonusStatementBankID <> 3 then 0  else 1 end) as TotalAhlyCount ";


                string strGroup = "";
                string strOrder = "";
                string strTemp = "";
                //if (_IsStatementGrouping)
                //{
                //    strTemp = " StatementID, StatementDesc, StatementDate,StatementPerc,StatementMinValue";
                //    strSelect += "," + strTemp;
                //    if (strOrder != "")
                //        strOrder += ",";
                //    strOrder += " StatementDate Desc ";

                //    if (strGroup != "")
                //        strGroup += ",";

                //    strGroup += strTemp;
                //}
              
                Returned = "select " + strSelect + " from (" + StrSearch + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;
                return Returned;
            }
        }

        #region Groupping

        bool _IsApplicantGroupping;
        double _DiscountSum;
        

#endregion
        #endregion
        #region Private Methods
        void SetData(DataRow objDr) 
        {
            _ID = int.Parse(objDr["OriginStatementID"].ToString());
            _AccountBankNo = objDr["AccountBankNo"].ToString();
            if (objDr["StatementBankIntNo"].ToString()!="")
            _flAccountBankNo = float.Parse(objDr["StatementBankIntNo"].ToString());

            _GlobalStatment = int.Parse(objDr["GlobalStatment"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());
            if (objDr["FinancialStatementDate"].ToString() != "")
                _StatementDate = DateTime.Parse(objDr["FinancialStatementDate"].ToString());

            _LoanDiscount = double.Parse(objDr["LoanDiscount"].ToString());
            _PartTimeTotalMinutes = int.Parse(objDr["PartTimeTotalMinutes"].ToString());
            _PartTimeValue = double.Parse(objDr["PartTimeValue"].ToString());
            _PartTimeUnit = byte.Parse(objDr["StatementPartTimeUnit"].ToString());
            _BaseSalary = double.Parse(objDr["BaseSalary"].ToString());
            _BaseSalarySaved = _BaseSalary;
            _DetailsValue = double.Parse(objDr["DetailsValue"].ToString());
            _RewardValue = double.Parse(objDr["RewardValue"].ToString());
            _IncreaseValue = double.Parse(objDr["IncreaseValue"].ToString());
            _OldIncreaseValue = _IncreaseValue;
            _AttendanceDiscount = double.Parse(objDr["AttendanceDiscount"].ToString());
            _PenaltyDiscount = double.Parse(objDr["PenaltyDiscount"].ToString());
            _SentToMail = bool.Parse(objDr["SentToMail"].ToString());
            //_DelayValue = double.Parse(objDr["DelayValue"].ToString());
            _DelayDiscount = double.Parse(objDr["DelayDiscount"].ToString());
            _OverDays = double.Parse(objDr["OverDays"].ToString());
            _OverTimeValue = double.Parse(objDr["OverTimeValue"].ToString());
            _AbsenceDiscount = double.Parse(objDr["AbsenceDiscount"].ToString());
            if (objDr["FurloughValue"].ToString() != "")
                _FurloughValue = double.Parse(objDr["FurloughValue"].ToString());
            if (objDr["FurloughDiscount"].ToString() != "")
                _FurloughDiscount = double.Parse(objDr["FurloughDiscount"].ToString());

            if (objDr["VacationValue"].ToString() != "")
                _VacationValue = double.Parse(objDr["VacationValue"].ToString());
            if (objDr["VacationDiscount"].ToString() != "")
                _VacationDiscount = double.Parse(objDr["VacationDiscount"].ToString());


            _NonCountedDaysDiscount = double.Parse(objDr["NonCountedDaysDiscount"].ToString());
            _UtilityValue = double.Parse(objDr["UtilityValue"].ToString());
            _DelayValue = double.Parse(objDr["DelayValue"].ToString());
            _OverDaysBonus = double.Parse(objDr["OverDaysBonus"].ToString());
            _AbsenceCount = double.Parse(objDr["AbsenceCount"].ToString());
            _NonCountedDays = double.Parse(objDr["NonCountedDays"].ToString());
            _DiscountValue = double.Parse(objDr["DiscountValue"].ToString());
            _BonusValue = double.Parse(objDr["BonusValue"].ToString());
            _FellowShipFund = double.Parse(objDr["FellowShipFund"].ToString());
            _FellowShipFundBonus = double.Parse(objDr["FellowShipFundBonus"].ToString());

            _PayBackValue = double.Parse(objDr["PayBackValue"].ToString());
            _FellowShipPaymentValue = double.Parse(objDr["FellowShipPaymentValue"].ToString());


            _TotalDeserved = double.Parse(objDr["TotalDeserved"].ToString());
            if (_DeservedRatioSearch != 0)
                _TotalDeserved = (_TotalDeserved * _DeservedRatioSearch) / 100;


            if (objDr["CostCenter"].ToString() != "")
                _CostCenter = int.Parse(objDr["CostCenter"].ToString());
            if (objDr["MotivationCostCenter"].ToString() != "")
                _MotivationCostCenter = int.Parse(objDr["MotivationCostCenter"].ToString());
            if(objDr.Table.Columns["StatementMotivationCostCenterName"]!= null)
            _MotivationCostcenterName = objDr["StatementMotivationCostCenterName"].ToString();
            if (objDr["IsEndStatement"].ToString() != "")
                _IsEndStatement = bool.Parse(objDr["IsEndStatement"].ToString());
            if (objDr["IsStop"].ToString() != "")
                _IsStop = bool.Parse(objDr["IsStop"].ToString());
            if (objDr["IsNotHasAttendanceStatement"].ToString() != "")
                _IsNotHasAttendanceStatement = bool.Parse(objDr["IsNotHasAttendanceStatement"].ToString());

            if (objDr["FinancialStatementType"].ToString() != "")
                _FinancialStatementType = int.Parse(objDr["FinancialStatementType"].ToString());

            _Remark = objDr["Remark"].ToString();

            if (objDr["NotCalcBaseSalary"].ToString() != "")
                _NotCalcBaseSalary = bool.Parse(objDr["NotCalcBaseSalary"].ToString());
            if (objDr["NotCalcBaseSalaryDetails"].ToString() != "")
                _NotCalcBaseSalaryDetails = bool.Parse(objDr["NotCalcBaseSalaryDetails"].ToString());
            if (objDr["NotCalcBaseSalaryFellowShip"].ToString() != "")
                _NotCalcBaseSalaryFellowShip = bool.Parse(objDr["NotCalcBaseSalaryFellowShip"].ToString());

            if (objDr["JobNature"].ToString() != "")
                _JobNature = int.Parse(objDr["JobNature"].ToString());


            if (objDr["NotShowBaseSalary"].ToString() != "")
                _NotShowBaseSalary = bool.Parse(objDr["NotShowBaseSalary"].ToString());
            if (objDr["NotShowBaseSalaryDetails"].ToString() != "")
                _NotShowBaseSalaryDetails = bool.Parse(objDr["NotShowBaseSalaryDetails"].ToString());
            if (objDr["StatementBankID"].ToString() != "")
                _AccountBankID = int.Parse(objDr["StatementBankID"].ToString());
            _AccountBankName = objDr["StatementBankName"].ToString();
            if( objDr.Table.Columns["SubSector"]!= null && objDr["SubSector"].ToString()!= "")
            _SubSectorID = int.Parse(objDr["SubSector"].ToString());
            if (objDr.Table.Columns["OtherDetalsValue"] != null && objDr["OtherDetalsValue"].ToString() != "")
            {
                _OtherValue = double.Parse(objDr["OtherDetalsValue"].ToString());
            }
            if (objDr.Table.Columns["FeedingDetalsValue"] != null && objDr["FeedingDetalsValue"].ToString() != "")
            {
                _FeedingValue = double.Parse(objDr["FeedingDetalsValue"].ToString());

            }
            if (objDr.Table.Columns["TransportDetalsValue"] != null && objDr["TransportDetalsValue"].ToString() != "")
            {
                _TransportValue = double.Parse(objDr["TransportDetalsValue"].ToString());
            }
            if (objDr.Table.Columns["PhoneDetalsValue"] != null && objDr["PhoneDetalsValue"].ToString() != "")
            {
                _PhoneValue = double.Parse(objDr["PhoneDetalsValue"].ToString());

            }
            if (objDr.Table.Columns["TotalExchangeValue"] != null && objDr["TotalExchangeValue"].ToString() != "")
                _ExchangeValue = double.Parse(objDr["TotalExchangeValue"].ToString());
            _StatementReviewed = bool.Parse(objDr["OriginStatementReviewed"].ToString());
            _BankBranchCode = objDr["StatementBankBranchCode"].ToString();
            _AccountTypeCode = objDr["StatementAccountTypeCode"].ToString();
        }
        void JoinSalaryDetails()
        {
            if (_SalaryDetailsTable == null || _SalaryDetailsTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_SalaryDetailsTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerStatementSalaryDetails where " +
                " OrginStatement=" + _ID;
            ApplicantWorkerStatementSalaryDetailsDb objDb;
            int intIndex = 1;
            foreach (DataRow objDr in _SalaryDetailsTable.Rows)
            {
                objDb = new ApplicantWorkerStatementSalaryDetailsDb(objDr);
                objDb.OrginStatement = _ID;
                arrStr[intIndex] = objDb.AddStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void ResetLoanIsFinished()
        {
            string strSql = "SELECT     DiscountStatement, DiscountLoan " +
                   " FROM   HRApplicantWorkerStatementLoanDiscount INNER JOIN " +
                   " HRApplicantWorkerLoan ON HRApplicantWorkerStatementLoanDiscount.DiscountLoan = " +
                   "HRApplicantWorkerLoan.LoanID where  HRApplicantWorkerLoan.IsFinished = 1 and DiscountStatement=" + ID;
            DataTable dtTemp = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            String strFinishedLoans = "";
            foreach (DataRow objDr in dtTemp.Rows)
            {
                if (strFinishedLoans != "")
                    strFinishedLoans += ",";
                strFinishedLoans += objDr["DiscountLoan"].ToString();
            }
            if (strFinishedLoans != "")
            {
                strSql = "update HRApplicantWorkerLoan set IsFinished = 0 where LoanID in (" + strFinishedLoans + ")";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            }
        }
        void JoinSubSector()
        {
            if (_SubSectorTable == null || _SubSectorTable.Rows.Count == 0)
                return;
            string[] arrStr = new string[_SubSectorTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerStatementSubSector where " +
                " OrginStatement=" + _ID;
            ApplicantWorkerStatementSubSectorDb objDb;
            int intIndex = 1;
            foreach (DataRow objDr in _SubSectorTable.Rows)
            {
                objDb = new ApplicantWorkerStatementSubSectorDb(objDr);
                objDb.OrginStatement = _ID;
                arrStr[intIndex] = objDb.AddStr;
                intIndex++;
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinLoanDiscount()
        {
            int intlen = 0;
            if ((_LoanDiscountTable == null || _LoanDiscountTable.Rows.Count == 0) &&
                (_DeletedLoanDiscountTable == null || _DeletedLoanDiscountTable.Rows.Count == 0))
                return;
            if (_DeletedLoanDiscountTable != null)
                intlen += _DeletedLoanDiscountTable.Rows.Count;
            intlen += _LoanDiscountTable.Rows.Count;
            string[] arrStr = new string[intlen];

            ApplicantWorkerStatementLoanDiscountDb objDb;
            int intIndex = 0;
            string strTemp = "";

            foreach (DataRow objDr in _LoanDiscountTable.Rows)
            {
                objDb = new ApplicantWorkerStatementLoanDiscountDb(objDr);
                objDb.Statement = _ID;
                if (objDb.ID == 0)
                    strTemp = objDb.AddStr;
                else
                    strTemp = objDb.EditStr;

                arrStr[intIndex] = strTemp;
                intIndex++;
            }
            if (_DeletedLoanDiscountTable != null && _DeletedLoanDiscountTable.Rows.Count != 0)
            {
                foreach (DataRow objDr in _DeletedLoanDiscountTable.Rows)
                {
                    objDb = new ApplicantWorkerStatementLoanDiscountDb(objDr);
                    objDb.Statement = _ID;
                    strTemp = objDb.DeleteStr;

                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            #region Set IsFinished
            string strLoanIDs = "";
            foreach (DataRow objDr in _LoanDiscountTable.Rows)
            {
                objDb = new ApplicantWorkerStatementLoanDiscountDb(objDr);
                if (strLoanIDs != "")
                    strLoanIDs += ",";
                strLoanIDs += objDb.Loan.ToString();

            }
            foreach (DataRow objDr in _DeletedLoanDiscountTable.Rows)
            {
                objDb = new ApplicantWorkerStatementLoanDiscountDb(objDr);
                if (strLoanIDs != "")
                    strLoanIDs += ",";
                strLoanIDs += objDb.Loan.ToString();

            }
            if (strLoanIDs == "")
                return;
            string strSql = "SELECT dbo.HRApplicantWorkerLoan.LoanID, dbo.HRApplicantWorkerLoan.LoanValue, " +
                      " dbo.HRApplicantWorkerLoan.LoanPrepaidValue + SUM(dbo.HRApplicantWorkerStatementLoanDiscount.DiscountValue) " +
                      " + SUM(HRApplicantWorkerLoanPayment.PaymenetValue) AS TotalPaid, " +
                      "dbo.HRApplicantWorkerLoan.LoanPrepaidValue " +
                      " FROM         dbo.HRApplicantWorkerLoan Left Outer JOIN " +
                      " dbo.HRApplicantWorkerStatementLoanDiscount ON " +
                      " dbo.HRApplicantWorkerLoan.LoanID = dbo.HRApplicantWorkerStatementLoanDiscount.DiscountLoan Left Outer JOIN " +
                      " HRApplicantWorkerLoanPayment ON HRApplicantWorkerLoan.LoanID = HRApplicantWorkerLoanPayment.Loan " +
                      " WHERE     (dbo.HRApplicantWorkerLoan.LoanID IN (" + strLoanIDs + ")) " +
                      " GROUP BY dbo.HRApplicantWorkerLoan.LoanValue, dbo.HRApplicantWorkerLoan.LoanPrepaidValue, dbo.HRApplicantWorkerLoan.LoanID";
            string strSql1 = " SELECT     HRApplicantWorkerLoan.LoanID, HRApplicantWorkerLoan.LoanValue, " +
                             " HRApplicantWorkerLoan.LoanPrepaidValue + CASE WHEN DiscountTable.SumDiscountValue IS NULL " +
                             " THEN 0 ELSE DiscountTable.SumDiscountValue END + CASE WHEN PaymentTable.SumPaymentValue IS NULL " +
                             " THEN 0 ELSE PaymentTable.SumPaymentValue END AS TotalPaid, HRApplicantWorkerLoan.LoanPrepaidValue, DiscountTable.SumDiscountValue, " +
                             " PaymentTable.SumPaymentValue" +
                             " FROM         HRApplicantWorkerLoan LEFT OUTER JOIN" +
                             " (SELECT     DiscountLoan, SUM(DiscountValue) AS SumDiscountValue" +
                             " FROM         HRApplicantWorkerStatementLoanDiscount" +
                             "  GROUP BY DiscountLoan) AS DiscountTable ON HRApplicantWorkerLoan.LoanID = DiscountTable.DiscountLoan LEFT OUTER JOIN" +
                             " (SELECT     Loan, SUM(PaymenetValue) AS SumPaymentValue" +
                             " FROM         HRApplicantWorkerLoanPayment" +
                             " GROUP BY Loan) AS PaymentTable ON HRApplicantWorkerLoan.LoanID = PaymentTable.Loan" +
                             " WHERE     (HRApplicantWorkerLoan.LoanID IN (175))";

            strSql = "update HRApplicantWorkerLoan set IsFinished= case when NativeTable.TotalPaid = " +
                " HRApplicantWorkerLoan.LoanValue then 1 else 0 end " +
                " from HRApplicantWorkerLoan inner join (" + strSql1 + ") as NativeTable on HRApplicantWorkerLoan.LoanID = NativeTable.LoanID " +
                " where HRApplicantWorkerLoan.LoanID in(" + strLoanIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            #endregion

        }
        void ResetIncreaseValue()
        {
            if (_OldIncreaseValue == 0 || _OldIncreaseValue != _IncreaseValue)
                return;
            string strSql = "update HRApplicantWorker " +
                "set ApplicantCurrentSalary =ApplicantCurrentSalary-HRApplicantWorkerStatement.IncreaseValue " +
                "FROM    dbo.HRApplicantWorker INNER JOIN " +
                " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant " +
                " WHERE    HRApplicantWorker.ApplicantID=" + _Applicant +
                " and  (dbo.HRApplicantWorkerStatement.OriginStatementID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        void SetIncreaseValue()
        {
            if (_OldIncreaseValue == 0 || _OldIncreaseValue != _IncreaseValue)
                return;
            string strSql = "update HRApplicantWorker " +
                "set ApplicantCurrentSalary =ApplicantCurrentSalary+HRApplicantWorkerStatement.IncreaseValue " +
                "FROM    dbo.HRApplicantWorker INNER JOIN " +
                " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant " +
                " WHERE    (dbo.HRApplicantWorkerStatement.OriginStatementID = " + _ID + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void JoinDiscount()
        {
            if (_DiscountTable == null)
                return;
            string[] arrStr = new string[_DiscountTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerStatementDiscount where OriginStatement=" + _ID;
            int intIndex = 1;
            double dblDate;
            foreach (DataRow objDr in _DiscountTable.Rows)
            {
                dblDate = DateTime.Parse(objDr["DiscountDate"].ToString()).ToOADate() - 2;
                arrStr[intIndex] = "insert into HRApplicantWorkerStatementDiscount ( OriginStatement, DiscountDesc, DiscountValue, DiscountDate,DiscountType,DiscountID) " +
                    " values (" + _ID + ",'" + objDr["DiscountDesc"].ToString() + "'," +
                    objDr["DiscountValue"].ToString() + "," + dblDate + "," + objDr["DiscountType"].ToString() + "," + objDr["DiscountID"].ToString() + ")";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
            foreach (DataRow objDr in _DiscountTable.Rows)
            {
                if (objDr["DiscountID"].ToString() != "0")
                {
                    string str = " Insert into HRApplicantWorkerDiscountGlobalStatement (OriginStatement,Discount,UsrIns,TimIns)" +
                                   " Values (" + _ID + "," + objDr["DiscountID"].ToString() + "," + SysData.CurrentUser.ID + ",GetDate())";
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
                }
            }
        }
        public void JoinBonus()
        {
            if (_BonusTable == null)
                return;
            string[] arrStr = new string[_BonusTable.Rows.Count + 1];
            arrStr[0] = "delete from HRApplicantWorkerStatementBonus where OriginStatement=" + _ID;
            int intIndex = 1;
            double dblDate;
            foreach (DataRow objDr in _BonusTable.Rows)
            {
                dblDate = DateTime.Parse(objDr["BonusDate"].ToString()).ToOADate() - 2;
                arrStr[intIndex] = "insert into HRApplicantWorkerStatementBonus ( OriginStatement, BonusDesc, BonusValue"+
                    ",BonusDayCount, BonusDayReferenceCount, BonusHourCount, BonusHourRefrenceCount"+
                    ", BonusDate,BonusType,BonusID) " +
                    " values (" + _ID + ",'" + objDr["BonusDesc"].ToString() + "'," +
                    objDr["BonusValue"].ToString() +
                    "," + objDr["BonusDayCount"].ToString() + "," + objDr["BonusDayReferenceCount"].ToString() + "," + objDr["BonusHourCount"].ToString() + "," + objDr["BonusHourRefrenceCount"].ToString() +
                    "," + dblDate + "," + objDr["BonusType"].ToString() + "," + objDr["BonusID"].ToString() + ")";
                intIndex++;

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);

            foreach (DataRow objDr in _BonusTable.Rows)
            {
                if (objDr["BonusID"].ToString() != "0")
                {
                    string str = " Insert into HRApplicantWorkerBonusGlobalStatement (OriginStatement,Bonus,UsrIns,TimIns)" +
                                   " Values (" + _ID + "," + objDr["BonusID"].ToString() + "," + SysData.CurrentUser.ID + ",GetDate())";
                    SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
                }
            }
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            base.Add();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
            //SetIncreaseValue();
            JoinSalaryDetails();
            JoinSubSector();
            JoinDiscount();
            JoinBonus();
            JoinLoanDiscount();

        }
        public override void Edit()
        {
            //ResetIncreaseValue();
            base.Edit();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
           // SetIncreaseValue();
            JoinSalaryDetails();
            JoinSubSector();
            JoinDiscount();
            JoinBonus();
            JoinLoanDiscount();

        }
        public void Delete()
        {

            ResetLoanIsFinished();
            base.Delete();
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
            //ResetIncreaseValue();
            JoinSubSector();
            JoinDiscount();
            JoinBonus();
            //JoinLoanDiscount();
        }
        byte _ApplicantStatusWorker;
        public byte ApplicantStatusWorker
        {
            set
            {
                _ApplicantStatusWorker = value;
            }
        }
        public DataTable GetApplicantWorkerStatementFellowShipDiscount()
        {
            string StrSql = "";
            string strAppliantPayment = "";
            string strAppliantFellowship = "";
            string strostCenterIDs = "";
            string strGlobalStatementIDs = "";
            
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                strAppliantPayment = " And HRFellowShipPayment.PaymentApplicant In ( " + _ApplicantIDs + ")";
                strAppliantFellowship = " HAVING       HRApplicantWorkerStatement.Applicant In ( " + _ApplicantIDs + ")";
            }

            if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
            {
                strGlobalStatementIDs = " and HRApplicantWorkerStatement.GlobalStatment in (" + _GlobalStatementIDs + ")  ";
            }
            if (_CostCenterIDs != null && _CostCenterIDs != "")
            {
                strostCenterIDs = " and HRApplicantWorkerStatement.CostCenter in (" + _CostCenterIDs + ")  ";
            }

            StrSql = "SELECT     HRApplicantWorkerStatement.Applicant, SUM(HRApplicantWorkerStatement.FellowShipFund + HRApplicantWorkerStatement.FellowShipFundBonus) " +
                      " AS FellowShipDiscount, dt_Payment.SUMPaymentValue AS PaymentValue" +
                    " FROM         HRApplicantWorkerStatement LEFT OUTER JOIN" +
                          " (SELECT     PaymentApplicant, SUM(PaymentValue) AS SUMPaymentValue" +
                             " FROM         HRFellowShipPayment" +
                             " WHERE    1=1 " + strAppliantPayment + "" +
                             " GROUP BY PaymentApplicant) AS dt_Payment ON HRApplicantWorkerStatement.Applicant = dt_Payment.PaymentApplicant " +
                    " WHERE     (1 = 1) " + strostCenterIDs + " " + strGlobalStatementIDs + "" +
                    " GROUP BY HRApplicantWorkerStatement.Applicant, dt_Payment.SUMPaymentValue" +
                    " " + strAppliantFellowship + "";




            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable Search()
        {
            string StrSql = StrSearch;
           
           // StrSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     Applicant as ApplicantTemp FROM         HRApplicantWorkerStatement as TempTable WHERE     (GlobalStatment >= 43) GROUP BY Applicant HAVING      (SUM(IncreaseValue) > 0)))";
            ApplicantWorkerDb.SetCashTable();
            ApplicantWorkerDb.ApplicantIDs = "select Applicant from (" + StrSql + ") as NativeTable ";

            _StatementIDs = "select OriginStatementID from (" + StrSql + ") as NativeTable ";
            ResetChacheData();
           ////// StrSql += " order by OriginStatementID,BaseSalary desc";
            //StrSql += " order by HRApplicantWorkerStatement.GlobalStatment,HRApplicantWorkerStatement.Applicant";
            StrSql += " order by GlobalStatementTable.StatementDate,StatementBankIntNo";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
            List<string> arrStr = SysUtility.GetStringArr(Returned, "OriginStatementID", 5000);
            if (arrStr.Count == 1)
                _StatementIDs = arrStr[0];
        
            return Returned;
           
        }
        public static void ResetChacheData()
        {
            _ChacheSalaryDetailsTable = null;
            _CacheLoanDiscountTable = null;
        }
        public DataTable GetApplicantMainData()
        {
            string strApplicantHasMotivation = @"SELECT        ApplicantID, HasMotivation
FROM            dbo.HRApplicantWorker
WHERE        (HasMotivation = 1) ";
            string strMotivationStopped = "0 as MotivationStopped";
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strMotivationStopped = " case when HRApplicantWorkerStatement.Applicant in ("+_ApplicantIDs+ @") then 0 else 1 end as  MotivationStopped ";
            string strApplicantMotivationCostCenter = "SELECT  Applicant, MAX(CostCenter) AS ApplicantMotivationCostCenter "+
                   " FROM            dbo.HRApplicantWorkerMotivationCostCenter "+
                   " GROUP BY Applicant ";
            string strSql = " SELECT     COUNT(*) AS StatementCount, dbo.HRApplicantWorkerStatement.Applicant  ,dbo.HRApplicantWorkerStatement.JobNature,HRApplicantWorkerStatement.MotivationCostCenter, SUM(CASE WHEN NotCalcBaseSalary = 0 THEN BaseSalary ELSE 0 END) AS SumBaseSalaryVal" +
                            " ,SUM(DetailTable.TransferVal) AS SumTransferVal, SUM(DetailTable.TelephoneVal) AS SumTelephoneVal," +
                            " SUM(DetailTable.FeedingVal) AS SumFeedingVal, SUM(dbo.HRApplicantWorkerStatement.IncreaseValue) AS SumIncreaseVal," +
                            " SUM(HRApplicantWorkerStatement.PenaltyDiscount) AS SumPenaltyDiscount, SUM(HRApplicantWorkerStatement.AbsenceCount) AS SumAbsenceCount "+
                            " , SUM(HRApplicantWorkerStatement.DelayValue) AS SumDelayCount" +
                            ",0 as FellowshipValue ,"+strMotivationStopped +
                            " FROM         dbo.HRApplicantWorkerStatement LEFT OUTER JOIN " +
                            " (" +
                            " SELECT     SUM(CASE WHEN DetailType = 2 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) ELSE 0 END) AS TransferVal" +
                            " , SUM(CASE WHEN DetailType = 3 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) ELSE 0 END) AS TelephoneVal " +
                            " , SUM(CASE WHEN DetailType = 5 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) ELSE 0 END) AS FeedingVal" +
                            " , dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement " +
                            " FROM         dbo.HRApplicantWorkerStatementSalaryDetails INNER JOIN dbo.HRApplicantWorkerStatement AS Statement ON " +
                            " dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement = Statement.OriginStatementID  ";
            if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
            {
                strSql += " WHERE     (Statement.GlobalStatment IN (" + _GlobalStatementIDs + ")) ";
            }

            strSql += " GROUP BY dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement" +
          
                            " ) AS DetailTable ON dbo.HRApplicantWorkerStatement.OriginStatementID = DetailTable.OrginStatement ";

            strSql += " left outer join ("+ strApplicantMotivationCostCenter +") as MotivationCostCenterTable "+
                @" on  dbo.HRApplicantWorkerStatement.Applicant = MotivationCostCenterTable.Applicant 
   inner join ("+ strApplicantHasMotivation + @") as ApplicantHasMotivationTable 
    on dbo.HRApplicantWorkerStatement.Applicant  = ApplicantHasMotivationTable.ApplicantID ";
            strSql += " WHERE (1=1)";
            if (_GlobalStatment != 0)
            {
                strSql += "And  (dbo.HRApplicantWorkerStatement.GlobalStatment =" + _GlobalStatment + ")";
            }
            if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
            {
                strSql += "And  (dbo.HRApplicantWorkerStatement.GlobalStatment IN (" + _GlobalStatementIDs + "))";
            }
            if (_CostCenterIDs != null && _CostCenterIDs != "")
            {
                if (_CostCenterIDs == "0")
                {
                    int s = 0;
                }
                //string strCostCenter = " SELECT CostCenter FROM HRCostCenter WHERE  (ParentID IN (" + _CostCenterIDs + "))";
                string strCostCenter = " SELECT     CostCenter FROM         HRMotivationStatementCostCenterTree WHERE     (MotivationStatement = " + _MotivationStatementSearch + ") AND (CostCenterParent in( " + _CostCenterIDs + "))";
                strSql += " and HRApplicantWorkerStatement.CostCenter in (" + strCostCenter + ")  ";
                if (_CostCenterChildID != 0)
                    strSql += " and HRApplicantWorkerStatement.CostCenter = " + _CostCenterChildID + " ";

            }
            if (_MotivationCostCenterIDs != null && _MotivationCostCenterIDs != "")
            {
                if (_MotivationCostCenterIDs == "0")
                {
                    int s = 0;
                }
                //string strCostCenter = " SELECT CostCenter FROM HRCostCenter WHERE  (ParentID IN (" + _CostCenterIDs + "))";
                string strCostCenter = " SELECT     CostCenter FROM         HRMotivationStatementCostCenterTree "+
                                       " WHERE     (MotivationStatement = " + _MotivationStatementSearch + ") "+
                                       " AND (CostCenterParent in( " + _MotivationCostCenterIDs + "))";
                strSql += " and HRApplicantWorkerStatement.MotivationCostCenter in (" + strCostCenter + ")  ";
               // strSql += " and MotivationCostCenterTable.ApplicantMotivationCostCenter in (" + strCostCenter + ")  ";
                if (_MotivationCostCenterChildID != 0)
                    //strSql += " and MotivationCostCenterTable.ApplicantMotivationCostCenter = " + _MotivationCostCenterChildID + " ";
                    strSql += " and HRApplicantWorkerStatement.MotivationCostCenter = " + _MotivationCostCenterChildID + " ";

            }
            if (_WorkStatus != 0)
            {
                if (_WorkStatus == 1) // not Work
                    strSql += " and HRApplicantWorkerStatement.IsEndStatement = 0 ";
                else
                    strSql += " and HRApplicantWorkerStatement.IsEndStatement = 1 ";
            }
            
            //if (_ApplicantIDs != null && _ApplicantIDs != "")
            //{
            //    strSql += " and HRApplicantWorkerStatement.Applicant in (" + _ApplicantIDs + ")  ";
            //}
            else if (_HasMotivationSearch != 0)
            {
                if (_HasMotivationSearch == 1)
                {
                    string strMotivationType = "";
                    if (_MotivationTypeSearch != 0)
                        strMotivationType = " and (MotivationType = " + _MotivationTypeSearch + ")";
                    strSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE     (HasMotivation = 1) " + strMotivationType + "";
                    if (_IsDependOnStartDateInMotivation == true)
                    {
                        double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                        if(dlStartDate> 0)
                        strSql += "And (ApplicantStartDate < = " + dlStartDate + ")";
                    }

                    strSql += " ))";
                }
                else if (_HasMotivationSearch == 2)
                {
                    string strMotivationType = "";
                    if (_MotivationTypeSearch != 0)
                        strMotivationType = " and (MotivationType = " + _MotivationTypeSearch + ")";
                    strSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE     (HasMotivation = 0) " + strMotivationType + "";
                    if (_IsDependOnStartDateInMotivation == true)
                    {
                        double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                        strSql += "And (ApplicantStartDate < = " + dlStartDate + ")";
                    }

                    strSql += " ))";
                }
            }
            else if (_MotivationTypeSearch != 0)
            {
                strSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker WHERE  MotivationType = "+ _MotivationTypeSearch +" ))";
            }
            else
            {
                if (_IsDependOnStartDateInMotivation == true)
                {
                    double dlStartDate = _StartDateInMotivation.ToOADate() - 2;
                    strSql += " And (HRApplicantWorkerStatement.Applicant in (SELECT     ApplicantID FROM         HRApplicantWorker Where (ApplicantStartDate < = " + dlStartDate + ")))";
                }
            }
            if (_MotivationStatusSearch != 0)
            {
                string strCostCenter="";
                if(_MotivationStatementCostCenterIDSearch!=0)
                    strCostCenter = " And (MotivationCostCenter in (SELECT CostCenter FROM HRCostCenter WHERE  (ParentID IN (" + _MotivationStatementCostCenterIDSearch + "))))";

                if (_MotivationStatementCostCenterIDsSearch != null&& _MotivationStatementCostCenterIDsSearch!= "")
                    strCostCenter = " And (MotivationCostCenter in (SELECT CostCenter FROM HRCostCenter WHERE  (ParentID IN (" + _MotivationStatementCostCenterIDsSearch + "))))";

                if (_MotivationStatusSearch == 1)
                {
                    strSql += " And (HRApplicantWorkerStatement.Applicant in (Select Applicant From HRApplicantWorkerMotivationStatement "+
                              " Where MotivationStatement = " + _MotivationStatementSearch + " " + strCostCenter + "))";
                }
                else if (_MotivationStatusSearch == 2)
                {
                    strSql += " And (HRApplicantWorkerStatement.Applicant not in (Select Applicant From HRApplicantWorkerMotivationStatement " +
                             " Where MotivationStatement = " + _MotivationStatementSearch + " " + strCostCenter + "))";
                }
            }

            strSql += " GROUP BY dbo.HRApplicantWorkerStatement.Applicant, HRApplicantWorkerStatement.MotivationCostCenter,dbo.HRApplicantWorkerStatement.JobNature";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetApplicantWithEffects()
        {
            string StrSql = " SELECT     Applicant, SUM(PenaltyDiscount), SUM(OverDays), SUM(AbsenceCount), SUM(DelayValue), SUM(BonusValue), SUM(DiscountValue)," + 
                            " SUM(IncreaseValue) FROM         HRApplicantWorkerStatement"+
                            " WHERE  1=1 ";   

            if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
            {
                StrSql += " and HRApplicantWorkerStatement.GlobalStatment in (" + _GlobalStatementIDs + ")  ";
            }
            if (_ApplicantIDs != null && _ApplicantIDs != "")
            {
                StrSql = StrSql + " And HRApplicantWorkerStatement.Applicant In ( " + _ApplicantIDs + ")";
            }
            if (_CostCenterIDs != null && _CostCenterIDs != "")
            {
                StrSql = StrSql + " And HRApplicantWorkerStatement.CostCenter In ( " + _CostCenterIDs + ")";
            }
            StrSql += "GROUP BY HRApplicantWorkerStatement.Applicant";
            StrSql += " Having (1=1)";
            #region MyRegion


            if (_DetailEffectSearch != 0)
            {
                if (_DetailEffectSearch == 1) // Penalty
                {
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( SUM(HRApplicantWorkerStatement.PenaltyDiscount) <> 0 )";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( SUM(HRApplicantWorkerStatement.PenaltyDiscount) Between " + _PenaltyCountFromSearch + " And " + _PenaltyCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( SUM(HRApplicantWorkerStatement.PenaltyDiscount) <= " + _PenaltyCountFromSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And ( SUM(HRApplicantWorkerStatement.PenaltyDiscount) >= " + _PenaltyCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( SUM(HRApplicantWorkerStatement.PenaltyDiscount) = " + _PenaltyCountFromSearch + " )";
                    }

                }
                else if (_DetailEffectSearch == 2) // OverDays
                {
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.OverDays) <> 0 )";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.OverDays) Between " + _OverDayCountFromSearch + " And " + _OverDayCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.OverDays) <= " + _OverDayCountFromSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.OverDays) >= " + _OverDayCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.OverDays) = " + _OverDayCountFromSearch + " )";
                    }
                }
                else if (_DetailEffectSearch == 3) // Absence
                {
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.AbsenceCount) <> 0 )";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.AbsenceCount) Between " + _AbsenceCountFromSearch + " And " + _AbsenceCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.AbsenceCount) <= " + _AbsenceCountFromSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.AbsenceCount) >= " + _AbsenceCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.AbsenceCount) = " + _AbsenceCountFromSearch + " )";
                    }
                }
                else if (_DetailEffectSearch == 4) // Delay
                {
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DelayValue) <> 0 )";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DelayValue) Between " + _DelayCountFromSearch + " And " + _DelayCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DelayValue) <= " + _DelayCountFromSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DelayValue) >= " + _DelayCountToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DelayValue) = " + _DelayCountFromSearch + " )";
                    }
                }
                else if (_DetailEffectSearch == 5) // BaseSalry
                {
                    //if (_OperationDetailEffectSearch == 0)
                    //{
                    //    StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) <> 0 )";
                    //}
                    //else if (_OperationDetailEffectSearch == 1) //BW
                    //{
                    //    StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) Between " + _BaseSalaryFromSearch + " And " + _BaseSalaryToSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 2) //LessThan
                    //{
                    //    StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) <= " + _BaseSalaryFromSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 3) //LargeThan
                    //{
                    //    StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) >= " + _BaseSalaryToSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 4) //Equal
                    //{
                    //    StrSql += " And ( (HRApplicantWorkerStatement.BaseSalary + HRApplicantWorkerStatement.DetailsValue) = " + _BaseSalaryFromSearch + " )";
                    //}
                }
                else if (_DetailEffectSearch == 6) // BaseSalry
                {
                    //if (_OperationDetailEffectSearch == 0)
                    //{
                    //    StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved <> 0 )";
                    //}
                    //else if (_OperationDetailEffectSearch == 1) //BW
                    //{
                    //    StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved Between " + _DeservedFromSearch + " And " + _DeservedToSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 2) //LessThan
                    //{
                    //    StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved <= " + _DeservedFromSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 3) //LargeThan
                    //{
                    //    StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved >= " + _DeservedToSearch + " )";
                    //}
                    //else if (_OperationDetailEffectSearch == 4) //Equal
                    //{
                    //    StrSql += " And ( HRApplicantWorkerStatement.TotalDeserved = " + _DeservedFromSearch + " )";
                    //}
                }
                else if (_DetailEffectSearch == 7) // Bonus
                {
                    string strBonusType = "";
                    if (_SalaryBonusTypeSearch != 0)
                    {
                        if (_GlobalStatment != 0)
                            strBonusType = " And (OriginTable.OriginStatementID in ( SELECT HRApplicantWorkerStatementBonus.OriginStatement FROM  HRApplicantWorkerStatementBonus  WHERE (HRApplicantWorkerStatementBonus.BonusType = " + _SalaryBonusTypeSearch + ") " +
                                            " AND (HRApplicantWorkerStatementBonus.OriginStatement IN " +
                                            " (SELECT AWS.OriginStatementID as OSID" +
                                            " FROM HRApplicantWorkerStatement AS AWS" +
                                            " WHERE (AWS.GlobalStatment = " + _GlobalStatment + ")))))";
                        else if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
                            strBonusType = " And (OriginTable.OriginStatementID in ( SELECT HRApplicantWorkerStatementBonus.OriginStatement FROM  HRApplicantWorkerStatementBonus  WHERE (HRApplicantWorkerStatementBonus.BonusType = " + _SalaryBonusTypeSearch + ") " +
                                        " AND (HRApplicantWorkerStatementBonus.OriginStatement IN " +
                                        " (SELECT AWS.OriginStatementID as OSID" +
                                        " FROM HRApplicantWorkerStatement AS AWS" +
                                        " WHERE (AWS.GlobalStatment in (" + _GlobalStatementIDs + "))))))";
                    }
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.BonusValue) <> 0 )  " + strBonusType + "";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.BonusValue) Between " + _BonusFromSearch + " And " + _BonusToSearch + " ) " + strBonusType + "";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.BonusValue) <= " + _BonusFromSearch + " ) " + strBonusType + "";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And (Sum(HRApplicantWorkerStatement.BonusValue) >= " + _BonusToSearch + " ) " + strBonusType + "";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.BonusValue) = " + _BonusFromSearch + " ) " + strBonusType + "";
                    }
                }
                else if (_DetailEffectSearch == 8) // Discount
                {
                    string strDiscountType = "";
                    if (_SalaryDiscountTypeSearch != 0)
                    {
                        if (_GlobalStatment != 0)
                            strDiscountType = " And (OriginTable.OriginStatementID in ( SELECT     HRApplicantWorkerStatementDiscount.OriginStatement FROM         HRApplicantWorkerStatementDiscount WHERE     (HRApplicantWorkerStatementDiscount.DiscountType = " + _SalaryDiscountTypeSearch + ") " +
                                            " AND (HRApplicantWorkerStatementDiscount.OriginStatement IN " +
                                            " (SELECT     AWS.OriginStatementID as OSID " +
                                            " FROM         HRApplicantWorkerStatement AS AWS" +
                                            " WHERE     (AWS.GlobalStatment = " + _GlobalStatment + ")))))";
                        else if (_GlobalStatementIDs != null && _GlobalStatementIDs != "")
                            strDiscountType = " And (OriginTable.OriginStatementID in ( SELECT     HRApplicantWorkerStatementDiscount.OriginStatement FROM         HRApplicantWorkerStatementDiscount WHERE     (HRApplicantWorkerStatementDiscount.DiscountType = " + _SalaryDiscountTypeSearch + ") " +
                                        " AND (HRApplicantWorkerStatementDiscount.OriginStatement IN " +
                                        " (SELECT     AWS.OriginStatementID as OSID " +
                                        " FROM         HRApplicantWorkerStatement AS AWS" +
                                        " WHERE     (AWS.GlobalStatment in ( " + _GlobalStatementIDs + "))))))";

                    }
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DiscountValue) <> 0 ) " + strDiscountType + "";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DiscountValue) Between " + _DiscountFromSearch + " And " + _DiscountToSearch + " )" + strDiscountType + "";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DiscountValue) <= " + _DiscountFromSearch + " ) " + strDiscountType + "";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DiscountValue) >= " + _DiscountToSearch + " ) " + strDiscountType + "";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.DiscountValue) = " + _DiscountFromSearch + " ) " + strDiscountType + "";
                    }
                }
                else if (_DetailEffectSearch == 9) // Discount
                {
                    if (_OperationDetailEffectSearch == 0)
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.IncreaseValue) <> 0 )";
                    }
                    else if (_OperationDetailEffectSearch == 1) //BW
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.IncreaseValue) Between " + _IncreaseFromSearch + " And " + _IncreaseToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 2) //LessThan
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.IncreaseValue) <= " + _IncreaseFromSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 3) //LargeThan
                    {
                        StrSql += " And (Sum(HRApplicantWorkerStatement.IncreaseValue) >= " + _IncreaseToSearch + " )";
                    }
                    else if (_OperationDetailEffectSearch == 4) //Equal
                    {
                        StrSql += " And ( Sum(HRApplicantWorkerStatement.IncreaseValue) = " + _IncreaseFromSearch + " )";
                    }
                }


            }
            #endregion
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetApplicantWorkerStatementBeteenTwoStatement(int intID1, int intID2)
        {
            string strSql = SearchStr + " Where 1=1";
            if (intID1 != 0 && intID2 != 0)
            {
                string strStatement1 = " SELECT     Applicant, BaseSalary, IncreaseValue, DetailsValue" +
                                       " FROM         dbo.HRApplicantWorkerStatement "+
                                       " WHERE     (GlobalStatment = "+ intID1 +")";
                string strStatement2 = " SELECT     Applicant, BaseSalary, IncreaseValue, DetailsValue" +
                                       " FROM         dbo.HRApplicantWorkerStatement " +
                                       " WHERE     (GlobalStatment = " + intID2 + ")";

                string str = " Select StatementTable1.Applicant from (" + strStatement1 + ") as StatementTable1 Inner Join (" + strStatement2 + ") as StatementTable2" +
                             " On StatementTable1.Applicant = StatementTable2.Applicant "+
                             " And (StatementTable1.BaseSalary + StatementTable1.IncreaseValue + StatementTable1.DetailsValue)"+
                             " <> (StatementTable2.BaseSalary + StatementTable2.IncreaseValue + StatementTable2.DetailsValue)";

                //string str1 = " Select StatementTable1.Applicant from " + (strStatement1) + " as StatementTable1 Inner Join " + (strStatement2) + " as StatementTable2" +
                //             " On StatementTable1.Applicant = StatementTable2.Applicant " +
                //             " And (StatementTable1.BaseSalary + StatementTable1.IncreaseValue + StatementTable1.DetailsValue)" +
                //             " <> (StatementTable2.BaseSalary + StatementTable2.IncreaseValue + StatementTable2.DetailsValue)";

                strSql += " and (HRApplicantWorkerStatement.GlobalStatment in (" + intID1.ToString() + " , " + intID2.ToString() + ") ) ";
                strSql += " And (HRApplicantWorkerStatement.Applicant in ("+ str +"))";

                return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);

            }
            else
            {
                return null;
            }
        }
        public void EditMotivationCostCenter()
        {
            if (_IDs == null || _IDs == "" || _MotivationCostCenter == 0)
                return;
            string strSql = " insert into HRApplicantWorkerMotivationCostCenter (Applicant, CostCenter)  "+
                "SELECT   "+ _MotivationCostCenter +" AS CostCenter, dbo.HRApplicantWorkerStatement.Applicant "+
               " FROM       dbo.HRApplicantWorkerMotivationCostCenter RIGHT OUTER JOIN "+
               " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorkerMotivationCostCenter.Applicant = dbo.HRApplicantWorkerStatement.Applicant "+
               " WHERE        (dbo.HRApplicantWorkerMotivationCostCenter.Applicant IS NULL)  " +
               " AND (dbo.HRApplicantWorkerStatement.OriginStatementID IN ("+ _IDs +"))";
            strSql += " update HRApplicantWorkerMotivationCostCenter set CostCenter ="+ _MotivationCostCenter +
                      " FROM            dbo.HRApplicantWorkerMotivationCostCenter INNER JOIN "+
                       " dbo.HRApplicantWorkerStatement ON dbo.HRApplicantWorkerMotivationCostCenter.Applicant = dbo.HRApplicantWorkerStatement.Applicant "+
                       " WHERE        (dbo.HRApplicantWorkerStatement.OriginStatementID IN ("+_IDs+")) ";
            strSql += "update   dbo.HRApplicantWorkerStatement set MotivationCostCenter = "+_MotivationCostCenter +" "+
                   " WHERE        (OriginStatementID IN ("+ _IDs +"))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        #endregion

    }
}
