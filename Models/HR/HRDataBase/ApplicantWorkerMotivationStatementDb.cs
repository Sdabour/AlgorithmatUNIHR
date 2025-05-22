using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerMotivationStatementDb
    {
        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected int _MotivationStatement;        
        protected double _MotivationValue;
        protected double _DiscountValue;

        double _LoanDiscountValue;
        int _intDiscountType = 0;
        double _MemoDiscountValue;
        double _DelayDiscountValue;
        public int IntDiscountType
        {
            get { return _intDiscountType; }
            set { _intDiscountType = value; }
        }
        public double LoanDiscountValue
        {
            get { return _LoanDiscountValue; }
            set { _LoanDiscountValue = value; }
        }
        public double MemoDiscountValue
        {
            get { return _MemoDiscountValue; }
            set { _MemoDiscountValue = value; }
        }
        public double DelayDiscountValue
        {
            get { return _DelayDiscountValue; }
            set { _DelayDiscountValue = value; }
        }

        int _StatementCount;

     
        double _SumBaseSalaryVal;

      
        double _SumTransferVal;

      
        double _SumTelephoneVal;

      
        double _SumFeedingVal;

       
        double _SumIncreaseVal;

      
        double _SumPenaltyDiscount;

      
        double _SumAbsenceCount;

        double _SumDelayCount;

  

        protected double _BonusValue;
        protected double _MotivationValueBeforeEffect;
        protected bool _IsStop;
        protected string _Remarks;
        protected int _CostCenter;
        protected int _JobNatureTypeID;


        int _JobNatureID;

     
        string _JobNatureNameA;

      
        string _JobNatureNameE;

       
        bool _JobNatureVIP;

      
        int _JobCategoryID;

       
        string _JobCategoryNameA;

      
        string _JobCategoryNameE;

      
        int _JobCatregotryOrderValue;

      
       
        string _ApplicantIDs;
        string _CostCenterIDs;
        string _MotivationStatementIDs;
        int _ApplicantSearch;
        int _MotivationStatementSearch;
        public int MotivationStatementSearch
        { set => _MotivationStatementSearch = value; }
        string _AccountBankNo;
        int _AccountBankID;
        string _AccountBankName;
        double _BankNo;

        int _CostCenterSearch;
        byte _AccountBankNoSearch;
        protected int _IsStopSearch;
        byte _OrderStatus;
        bool _LastMotivation;
        int _AddedBonusStatus;
        public int AddedBonusStatus
        {
            set => _AddedBonusStatus = value;
        }

        bool _SimpleSearch;

        public bool SimpleSearch
        {
            get { return _SimpleSearch; }
            set { _SimpleSearch = value; }
        }
        bool _IncludePreviousSalary;

        public bool IncludePreviousSalary
        {
            get { return _IncludePreviousSalary; }
            set { _IncludePreviousSalary = value; }
        }
        double _CostCenterAddValue;

        public double CostCenterAddValue
        {
            get { return _CostCenterAddValue; }
            set { _CostCenterAddValue = value; }
        }
        double _CostCenterBonusOnDeserved;

        public double CostCenterBonusOnDeserved
        {
            get { return _CostCenterBonusOnDeserved; }
            set { _CostCenterBonusOnDeserved = value; }
        }
   
        string _CostCenterRemarks;

        public string CostCenterRemarks
        {
            get { return _CostCenterRemarks; }
            set { _CostCenterRemarks = value; }
        }
        double _CostCenterMotivationRatio;

        public double CostCenterMotivationRatio
        {
            get { return _CostCenterMotivationRatio; }
            set { _CostCenterMotivationRatio = value; }
        }
        bool _IsFellowShip;

        public bool IsFellowShip
        {
            get { return _IsFellowShip; }
            set { _IsFellowShip = value; }
        }
        double _FellowshipFund;

        public double FellowshipFund
        {
            get { return _FellowshipFund; }
            set { _FellowshipFund = value; }
        }
        double _FellowshipFundBonus;

        public double FellowshipFundBonus
        {
            get { return _FellowshipFundBonus; }
            set { _FellowshipFundBonus = value; }
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

        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementDb()
        {
        }
        public ApplicantWorkerMotivationStatementDb(DataRow ObjDr)
        {
            SetData(ObjDr);
        }
        public ApplicantWorkerMotivationStatementDb(int intMotivationStatementID, int intApplicantWorkerID)
        {
            _ApplicantSearch = intApplicantWorkerID;
            _MotivationStatementSearch = intMotivationStatementID;
            if (_ApplicantSearch == 0 || _MotivationStatementSearch == 0)
                return;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        public ApplicantWorkerMotivationStatementDb(int intMotivationStatementID, int intApplicantWorkerID, int intCostcenterID)
        {
            _ApplicantSearch = intApplicantWorkerID;
            _MotivationStatementSearch = intMotivationStatementID;
            _CostCenterSearch = intCostcenterID;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public int Applicant
        {
            set { _Applicant = value; }
            get { return _Applicant; }
        }
        public int MotivationStatement
        {
            set { _MotivationStatement = value; }
            get { return _MotivationStatement; }
        }
        public int CostCenter
        {
            set { _CostCenter = value; }
            get { return _CostCenter; }
        }
        public int JobNatureTypeID
        {
            set { _JobNatureTypeID = value; }
            get { return _JobNatureTypeID; }
        }
        public int JobNatureID
        {
            get { return _JobNatureID; }
            set { _JobNatureID = value; }
        }
        public string JobNatureNameA
        {
            get { return _JobNatureNameA; }
            set { _JobNatureNameA = value; }
        }
        public string JobNatureNameE
        {
            get { return _JobNatureNameE; }
            set { _JobNatureNameE = value; }
        }
        public bool JobNatureVIP
        {
            get { return _JobNatureVIP; }
            set { _JobNatureVIP = value; }
        }
        public int JobCategoryID
        {
            get { return _JobCategoryID; }
            set { _JobCategoryID = value; }
        }
        public string JobCategoryNameA
        {
            get { return _JobCategoryNameA; }
            set { _JobCategoryNameA = value; }
        }
        public string JobCategoryNameE
        {
            get { return _JobCategoryNameE; }
            set { _JobCategoryNameE = value; }
        }

        public int JobCatregotryOrderValue
        {
            get { return _JobCatregotryOrderValue; }
            set { _JobCatregotryOrderValue = value; }
        }
        public double MotivationValue
        {
            set { _MotivationValue = value; }
            get { return _MotivationValue; }
        }
        public double DiscountValue
        {
            set { _DiscountValue = value; }
            get { return _DiscountValue; }
        }
        public double BonusValue
        {
            set { _BonusValue = value; }
            get { return _BonusValue; }
        }
        public double MotivationValueBeforeEffect
        {
            set { _MotivationValueBeforeEffect = value; }
            get { return _MotivationValueBeforeEffect; }
        }
        public bool IsStop
        {
            set { _IsStop = value; }
            get { return _IsStop; }
        }
        public string Remarks
        {
            set { _Remarks = value; }
            get { return _Remarks; }
        }
        public string AccountBankNo
        {
            set { _AccountBankNo = value; }
            get { return _AccountBankNo; }
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
        public byte AccountBankNoSearch
        {
            set { _AccountBankNoSearch = value; }            
        }
        public double BankNo
        {
            set { _BankNo = value; }
            get { return _BankNo; }
        }

        public int StatementCount
        {
            get { return _StatementCount; }
            set { _StatementCount = value; }
        }
        public double SumBaseSalaryVal
        {
            get { return _SumBaseSalaryVal; }
            set { _SumBaseSalaryVal = value; }
        }
        public double SumTransferVal
        {
            get { return _SumTransferVal; }
            set { _SumTransferVal = value; }
        }
        public double SumTelephoneVal
        {
            get { return _SumTelephoneVal; }
            set { _SumTelephoneVal = value; }
        }
        public double SumFeedingVal
        {
            get { return _SumFeedingVal; }
            set { _SumFeedingVal = value; }
        }
        public double SumIncreaseVal
        {
            get { return _SumIncreaseVal; }
            set { _SumIncreaseVal = value; }
        }
        public double SumPenaltyDiscount
        {
            get { return _SumPenaltyDiscount; }
            set { _SumPenaltyDiscount = value; }
        }

        public double SumAbsenceCount
        {
            get { return _SumAbsenceCount; }
            set { _SumAbsenceCount = value; }
        }
        public double SumDelayCount
        {
            get { return _SumDelayCount; }
            set { _SumDelayCount = value; }
        }



        public string ApplicantIDs
        {
            set
            { _ApplicantIDs = value; }
        }
        public string CostCenterIDs
        {
            set
            { _CostCenterIDs = value; }
        }
        public byte OrderStatue
        {
            set { _OrderStatus = value; }
        }
        public string MotivationStatementIDs
        {
            set
            { _MotivationStatementIDs = value; }
        }
        public int IsStopSearch
        {
            set { _IsStopSearch = value; }           
        }
        public bool LastMotivation
        {
            set { _LastMotivation = value; }
        }
        bool _IsReviewed;
        public bool IsReviewed
        {
            set => _IsReviewed = value;
            get => _IsReviewed;
        }
        //public static string SearchStr
        //{
        //    get
        //    {
        //        string strBank = "SELECT  BankID AS MotivationStatementBankID, BankNameA AS MotivationStatementBankName "+
        //              " FROM    dbo.GLBank ";
        //        string strDiscount = "SELECT  ApplicantWorkerMotivationStatement, SUM(CASE WHEN MotivationDiscountType = 5 THEN 0 ELSE DiscountValue END) AS MainDiscountValue, "+
        //                 " SUM(CASE WHEN MotivationDiscountType = 5 THEN DiscountValue ELSE 0 END) AS LoanDiscountValue "+
        //                 " FROM            dbo.HRApplicantWorkerMotivationStatementDiscount "+
        //                 " GROUP BY ApplicantWorkerMotivationStatement ";

        //        string Returned = " SELECT     HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID, " +
        //                          " HRApplicantWorkerMotivationStatement.Applicant, HRApplicantWorkerMotivationStatement.MotivationStatement," +
        //                          " HRApplicantWorkerMotivationStatement.MotivationValue,HRApplicantWorkerMotivationStatement.CostCenter,"+
        //                          " HRApplicantWorkerMotivationStatement.DiscountValue,HRApplicantWorkerMotivationStatement.BonusValue,"+
        //                          " HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect," +
        //                          " HRApplicantWorkerMotivationStatement.JobNatureTypeID," +
        //                          " HRApplicantWorkerMotivationStatement.IsStop,HRApplicantWorkerMotivationStatement.Remarks,"+
        //                         "0 as ApplicantloanValue " +
        //                          ", HRApplicantWorkerMotivationStatement.AccountBankNo,BankTable.*,CONVERT(float, REPLACE(HRApplicantWorkerMotivationStatement.AccountBankNo, '/', '')) AS BankNo ," +
        //                          " ApplicantWorkerTable.*,MotivationStatementTable.*"+//,CostCenterHRTable.*" +
        //                         ", case when DiscountTable.MainDiscountValue is null then 0 else DiscountTable.MainDiscountValue end as  MainDiscountValue " +
        //                         ", case when DiscountTable.LoanDiscountValue is null then 0 else DiscountTable.LoanDiscountValue end as  LoanDiscountValue " +
        //                          " FROM         HRApplicantWorkerMotivationStatement " +
        //                          " inner join (" + new ApplicantWorkerDb().SearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerMotivationStatement.Applicant" +
        //                          " inner join (" + MotivationStatementDb.SearchStr + ") as MotivationStatementTable On MotivationStatementTable.MotivationStatementID = HRApplicantWorkerMotivationStatement.MotivationStatement"+
        //                          " left outer join (" + strBank + ") as BankTable "+
        //                          " on  HRApplicantWorkerMotivationStatement.AccountBankID = BankTable.MotivationStatementBankID  "+
        //                          " left outer join (" + strDiscount + ") as DiscountTable "+
        //                          " on  HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID = DiscountTable.ApplicantWorkerMotivationStatement  ";
        //                          //" inner join (" + CostCenterHRDb.SearchStr + ") as CostCenterHRTable On CostCenterHRTable.CostCenterID = HRApplicantWorkerMotivationStatement.CostCenter";


        //        return Returned;
        //    }
        //}

        public  string StatementSearchStr
        {
            get
            {
                string Returned = "SELECT  COUNT(dbo.HRApplicantWorkerStatement.OriginStatementID) AS StatementCount, dbo.HRApplicantWorkerStatement.Applicant, " +
                         " MAX(dbo.HRApplicantWorkerStatement.JobNature) AS JobNature, MAX(dbo.HRApplicantWorkerStatement.MotivationCostCenter) AS MotivationCostCenter, " +
                         " SUM(CASE WHEN NotCalcBaseSalary = 0 THEN BaseSalary ELSE 0 END) AS SumBaseSalaryVal, SUM(DetailTable.TransferVal) AS SumTransferVal,  " +
                         " SUM(DetailTable.TelephoneVal) AS SumTelephoneVal, SUM(DetailTable.FeedingVal) AS SumFeedingVal, SUM(dbo.HRApplicantWorkerStatement.IncreaseValue)  " +
                         " AS SumIncreaseVal, SUM(dbo.HRApplicantWorkerStatement.PenaltyDiscount) AS SumPenaltyDiscount, SUM(dbo.HRApplicantWorkerStatement.AbsenceCount)  " +
                         " AS SumAbsenceCount, SUM(dbo.HRApplicantWorkerStatement.DelayValue) AS SumDelayCount, " +
                         " dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID " +
                         " FROM            dbo.HRApplicantWorkerStatement INNER JOIN " +
                         " dbo.HRMotivationStatementGlobalStatement ON  " +
                         " dbo.HRApplicantWorkerStatement.GlobalStatment = dbo.HRMotivationStatementGlobalStatement.GlobalStatement INNER JOIN " +
                         " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorkerStatement.Applicant = dbo.HRApplicantWorkerMotivationStatement.Applicant AND  " +
                         " dbo.HRMotivationStatementGlobalStatement.MotivationStatement = dbo.HRApplicantWorkerMotivationStatement.MotivationStatement LEFT OUTER JOIN " +
                         " ( " +
                         "SELECT        SUM(CASE WHEN DetailType = 2 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) ELSE 0 END)  " +
                         " AS TransferVal, SUM(CASE WHEN DetailType = 3 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) " +
                          " ELSE 0 END) AS TelephoneVal, " +
                                                         " SUM(CASE WHEN DetailType = 5 THEN (CASE WHEN Statement.NotCalcBaseSalaryDetails = 0 THEN DetailValue ELSE 0 END) ELSE 0 END)  " +
                                                         " AS FeedingVal, dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement " +
                                " FROM            dbo.HRApplicantWorkerStatementSalaryDetails INNER JOIN " +
                                " dbo.HRApplicantWorkerStatement AS Statement ON  " +
                                " dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement = Statement.OriginStatementID " +
                                " GROUP BY dbo.HRApplicantWorkerStatementSalaryDetails.OrginStatement " +
                                ")  AS DetailTable " +
                                " ON  " +
                                " dbo.HRApplicantWorkerStatement.OriginStatementID = DetailTable.OrginStatement ";
                if (_MotivationStatement != 0)
                    Returned += " where HRMotivationStatementGlobalStatement.MotivationStatement = "+ _MotivationStatement;
                                Returned+= " GROUP BY dbo.HRApplicantWorkerStatement.Applicant, dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID ";
                if (_MotivationStatement != 0)
                    Returned += "";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strBank = "SELECT  BankID AS MotivationStatementBankID, BankNameA AS MotivationStatementBankName " +
                      " FROM    dbo.GLBank ";
                string strDiscount = "SELECT  ApplicantWorkerMotivationStatement, SUM(CASE WHEN MotivationDiscountType = 5 THEN 0 ELSE DiscountValue END) AS MainDiscountValue, " +
                         " SUM(CASE WHEN MotivationDiscountType = 5 THEN DiscountValue ELSE 0 END) AS LoanDiscountValue ," + // ”·›…
                         " SUM(CASE WHEN MotivationDiscountType = 3 THEN DiscountValue ELSE 0 END) AS DelayDiscountValue," + // √ŒÌ—
                         " SUM(CASE WHEN MotivationDiscountType = 1 THEN DiscountValue ELSE 0 END) AS MemoDiscountValue " + // „–ﬂ—…
                         " FROM            dbo.HRApplicantWorkerMotivationStatementDiscount " +
                         " GROUP BY ApplicantWorkerMotivationStatement ";
                string strJobNature = " SELECT        dbo.HRJobNatureType.JobNatureID AS MotivationJobNatureID, dbo.HRJobNatureType.JobNatureNameA AS MotivationJobNatureNameA, " +
                         " dbo.HRJobNatureType.JobNatureNameE AS MotivationJobNatureNameE, dbo.HRJobNatureType.VIP AS MotivationJobNatureVIP, " +
                         " dbo.HRJobCategory.JobCategoryID AS MotivationJobCategoryID, dbo.HRJobCategory.JobCategoryNameA AS MotivationJobCategoryNameA, " +
                         " dbo.HRJobCategory.JobCategoryNameE AS MotivationJobCategoryNameE, dbo.HRJobCategory.OrderValue AS MotivationJobCatregotryOrderValue " +
                         " FROM            dbo.HRJobCategory RIGHT OUTER JOIN " +
                         " dbo.HRJobNatureType ON dbo.HRJobCategory.JobCategoryID = dbo.HRJobNatureType.JobCategory ";
                ApplicantWorkerDb objApplicantWorkerDb = new ApplicantWorkerDb();
                //  objApplicantWorkerDb.IncludePreviousSalalry = _IncludePreviousSalary;
                string strMotivationStatementCostCenter = "SELECT    MotivationStatement, CostCenter, MAX(MotivationStatementCostCenterID) AS MaxStatementID " +
                        " FROM            dbo.HRMotivationStatementCostCenter " +
                        " where (1=1)  ";
                if (_MotivationStatement != 0)
                    strMotivationStatementCostCenter += " and MotivationStatement = " + _MotivationStatement;
                if (_CostCenterIDs != null && _CostCenterIDs != "")
                    strMotivationStatementCostCenter += " and CostCenter in (" + _CostCenterIDs + ") ";


                strMotivationStatementCostCenter += " GROUP BY MotivationStatement, CostCenter ";
                strMotivationStatementCostCenter = "SELECT   dbo.HRMotivationStatementCostCenter.MotivationStatement, dbo.HRMotivationStatementCostCenter.CostCenter" +
                    ", dbo.HRMotivationStatementCostCenter.MotivationStatementAddValue AS CostCenterAddValue" +
                    ", dbo.HRMotivationStatementCostCenter.BounsOnDeserved AS CostCenterBonusOnDeserved, " +
                         " dbo.HRMotivationStatementCostCenter.Remarks AS CostCenterRemarks" +
                         ", dbo.HRMotivationStatementCostCenter.MotivationRatio AS CostCenterMotivationRatio " +
                         " FROM            dbo.HRMotivationStatementCostCenter " +
                         " inner join (" + strMotivationStatementCostCenter + ") as MaxTable " +
                         " on dbo.HRMotivationStatementCostCenter.CostCenter = MaxTable.CostCenter " +
                         " and dbo.HRMotivationStatementCostCenter.MotivationStatement = MaxTable.MotivationStatement " +
                         " and dbo.HRMotivationStatementCostCenter.MotivationStatementCostCenterID  = MaxTable.MaxStatementID ";

                //if (_CostCenterIDs != "" && _CostCenterIDs != "0")
                //{
                //    strMotivationStatementCostCenter += "    where (MaxTable.CostCenter in ("+ _CostCenterIDs +") ) ";
                //}
                if (_CostCenterIDs == null)
                    _CostCenterIDs = "";
                string strCostCenter = " SELECT CostCenter FROM HRCostCenter WHERE  (CostCenter  in (" + _CostCenterIDs + ") ) or (ParentID IN (" + _CostCenterIDs + "))";
                // StrSql += " And (HRApplicantWorkerMotivationStatement.CostCenter in ( " + strCostCenter + "))";

                string Returned = " SELECT     HRApplicantWorkerMotivationStatement.Applicant as MotivationApplicant, HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID, " +
                                  " HRApplicantWorkerMotivationStatement.Applicant, HRApplicantWorkerMotivationStatement.MotivationStatement," +
                                  " HRApplicantWorkerMotivationStatement.MotivationValue,HRApplicantWorkerMotivationStatement.CostCenter," +
                                  " HRApplicantWorkerMotivationStatement.DiscountValue,HRApplicantWorkerMotivationStatement.BonusValue," +
                                  " HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect," +
                                  " HRApplicantWorkerMotivationStatement.JobNatureTypeID," +
                                  " HRApplicantWorkerMotivationStatement.IsStop,HRApplicantWorkerMotivationStatement.Remarks," +
                                 "0 as ApplicantloanValue " +
                                  ", HRApplicantWorkerMotivationStatement.AccountBankNo,HRApplicantWorkerMotivationStatement.MotivationStatementReview,BankTable.*,CONVERT(float, REPLACE(HRApplicantWorkerMotivationStatement.AccountBankNo, '/', '')) AS BankNo " +
                                  ", dbo.HRApplicantWorkerMotivationStatement.IsFellowship as MotivationIsFellowship" +
                                  ", dbo.HRApplicantWorkerMotivationStatement.FellowshipFund as MotivationFellowshipFund" +
                                  ", dbo.HRApplicantWorkerMotivationStatement.FellowshipFundBonus  as MotivationFellowshipFundBonus ";
                if (!_SimpleSearch)
                    Returned += " ,ApplicantWorkerTable.*";

                Returned += ",MotivationStatementTable.*" +//,CostCenterHRTable.*" +
               ",case when DiscountTable.MainDiscountValue is null then 0 else DiscountTable.MainDiscountValue end as  MainDiscountValue " +
               ",case when DiscountTable.LoanDiscountValue is null then 0 else DiscountTable.LoanDiscountValue end as  LoanDiscountValue " +
               ",case when DiscountTable.MemoDiscountValue is null then 0 else DiscountTable.MemoDiscountValue end as  MemoDiscountValue " +
                  " ,case when DiscountTable.DelayDiscountValue is null then 0 else DiscountTable.DelayDiscountValue end as  DelayDiscountValue " +
                  " ,BankTable.MotivationStatementBankID,CostCenterTable.* ,JobNatureTypeTable.* " +
                  ",StatementTable.StatementCount,StatementTable.SumBaseSalaryVal,StatementTable.SumTransferVal " +
                  ",StatementTable.SumTelephoneVal,StatementTable.SumFeedingVal,StatementTable.SumIncreaseVal " +
                  ",StatementTable.SumPenaltyDiscount,StatementTable.SumAbsenceCount,StatementTable.SumDelayCount " +
                 ",    MotivationCostCenterTable.CostCenterAddValue, MotivationCostCenterTable.CostCenterBonusOnDeserved, MotivationCostCenterTable.CostCenterRemarks, " +
                 " MotivationCostCenterTable.CostCenterMotivationRatio " +
                 ", dbo.HRApplicantWorkerMotivationStatement.BankBranchCode AS MotivationBankBranchCode, dbo.HRApplicantWorkerMotivationStatement.AccountTypeCode AS MotivationAccountTypeCode  " +

                " FROM         HRApplicantWorkerMotivationStatement ";
                if (!_SimpleSearch)
                       Returned += " inner join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerMotivationStatement.Applicant ";
                else
                Returned += " inner join (" + objApplicantWorkerDb.ShortSearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerMotivationStatement.Applicant ";
                if (_MotivationStatement != 0)
                    Returned += " and HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatement;

                Returned += " inner join (" + MotivationStatementDb.SearchStr + ") as MotivationStatementTable On MotivationStatementTable.MotivationStatementID = HRApplicantWorkerMotivationStatement.MotivationStatement" +
                                  " left outer join (" + strBank + ") as BankTable " +
                                  " on  HRApplicantWorkerMotivationStatement.AccountBankID = BankTable.MotivationStatementBankID  " +
                                  " left outer join (" + strDiscount + ") as DiscountTable " +
                                  " on  HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID = DiscountTable.ApplicantWorkerMotivationStatement  " +
                                  " Left Outer join (" + CostCenterHRDb.SearchStr + ") as CostCenterTable " +
                                  " On CostCenterTable.CostCenterID = HRApplicantWorkerMotivationStatement.CostCenter  " +
                                  " left outer join (" + strJobNature + ") as JobNatureTypeTable " +
                                  "  on HRApplicantWorkerMotivationStatement.JobNatureTypeID = JobNatureTypeTable.MotivationJobNatureID  " +
                                  " left outer join (" + StatementSearchStr + ") as StatementTable " +
                                  " on HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID = StatementTable.ApplicantMotivationStatementID " +
                                  " left outer join (" + strMotivationStatementCostCenter + ") as MotivationCostCenterTable " +
                                  " on  HRApplicantWorkerMotivationStatement.MotivationStatement = MotivationCostCenterTable.MotivationStatement " +
                                  " and CostCenterTable.CostCenterID = MotivationCostCenterTable.CostCenter ";
                //" inner join (" + CostCenterHRDb.SearchStr + ") as CostCenterHRTable On CostCenterHRTable.CostCenterID = HRApplicantWorkerMotivationStatement.CostCenter";
                if (_CostCenterIDs != "" && _CostCenterIDs != "0")
                    Returned += " inner join (" + strCostCenter + ") SelectedCostCenterTable " +
                        " on    MotivationCostCenterTable.CostCenter = SelectedCostCenterTable.CostCenter ";



                return Returned;
            }
        }
      


        public string AddStr
        {
            get
            {
                int intIsStop = _IsStop ? 1 : 0;
                int intIsFellowship = _IsFellowShip ? 1 : 0;
                _FellowshipFund = _IsFellowShip ? _FellowshipFund : 0;
                _FellowshipFundBonus = _IsFellowShip ? _FellowshipFundBonus : 0;
                string Returned = " INSERT INTO HRApplicantWorkerMotivationStatement "+
                                  " (Applicant, MotivationStatement, CostCenter, MotivationValue,"+
                                  " DiscountValue,BonusValue,MotivationValueBeforeEffect" +
                                  ",  IsFellowship, FellowshipFund, FellowshipFundBonus "+
                                  " ,JobNatureTypeID,IsStop,Remarks,AccountBankNo,AccountBankID"+
                                  ",BankBranchCode, AccountTypeCode, UsrIns, TimIns)" +
                                  " VALUES "+
                                  " (" + _Applicant + "," + _MotivationStatement + "," + _CostCenter + "," +
                                  " " + _MotivationValue + ","+
                                  " " + _DiscountValue + "," + _BonusValue + "," + _MotivationValueBeforeEffect + "" +
                                  ","+intIsFellowship + "," + _FellowshipFund + "," +_FellowshipFundBonus +
                                  ", " + _JobNatureTypeID + "," + intIsStop + 
                                  ",'" + _Remarks + "','" + _AccountBankNo + "'," + _AccountBankID + 
                                  ",'" + _BankBranchCode + "','"+_AccountTypeCode + "',"+
                                  SysData.CurrentUser.ID + ",GetDate())";

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                int intIsStop = _IsStop ? 1 : 0;
                int intIsFellowship = _IsFellowShip ? 1 : 0;
                _FellowshipFund = _IsFellowShip ? _FellowshipFund : 0;
                _FellowshipFundBonus = _IsFellowShip ? _FellowshipFundBonus : 0;
                string Returned = " UPDATE    HRApplicantWorkerMotivationStatement "+
                                  "   SET    Applicant =" + _Applicant + "" +
                                  " , MotivationStatement =" + _MotivationStatement + "" +
                                  " , CostCenter =" + _CostCenter + "" +
                                  " , MotivationValue =" + _MotivationValue + "" +
                                  " , DiscountValue =" + _DiscountValue + "" +
                                  " , BonusValue =" + _BonusValue + "" +
                                  " , MotivationValueBeforeEffect =" + _MotivationValueBeforeEffect + "" +
                                  ",  IsFellowship="+ intIsFellowship +
                                  ", FellowshipFund="+ _FellowshipFund +
                                  ", FellowshipFundBonus = "+_FellowshipFundBonus +
                                  " , JobNatureTypeID = " + _JobNatureTypeID + "" +
                                  " , IsStop=" + intIsStop + "" +
                                  " , Remarks='" + _Remarks + "'" +
                                  " , AccountBankNo='" + _AccountBankNo + "'" +
                                  " , AccountBankID=" + _AccountBankID  +
                                  ",BankBranchCode = '"+ _BankBranchCode +"'"+
                                  ", AccountTypeCode ='" +_AccountTypeCode  + "'"+
                                  " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (ApplicantMotivationStatementID = "+ _ID +")";

                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM HRApplicantWorkerMotivationStatement "+
                                  " WHERE     (ApplicantMotivationStatementID = " + _ID + ")";
                Returned += " delete "+
                   " FROM            dbo.HRApplicantWorkerMotivationStatementDiscount "+
                    " WHERE        (ApplicantWorkerMotivationStatement = "+ _ID +")";
                Returned += " delete "+
                  " FROM            dbo.HRApplicantWorkerMotivationStatementBonus "+
                  " WHERE        (ApplicantWorkerMotivationStatement = " + _ID  + ") "; 

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["ApplicantMotivationStatementID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["ApplicantMotivationStatementID"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _CostCenter = int.Parse(objDr["CostCenter"].ToString());
            double.TryParse(objDr["MotivationValue"].ToString(),out _MotivationValue);
            if (objDr["JobNatureTypeID"].ToString() != "")
                _JobNatureTypeID = int.Parse(objDr["JobNatureTypeID"].ToString());


            if (objDr.Table.Columns["MotivationJobNatureID"] != null && objDr["MotivationJobNatureID"].ToString() != "")
                _JobNatureID = int.Parse(objDr["MotivationJobNatureID"].ToString());
            if (objDr.Table.Columns["MotivationJobNatureNameA"] != null )
                _JobNatureNameA = objDr["MotivationJobNatureNameA"].ToString();
            if (objDr.Table.Columns["MotivationJobNatureNameE"] != null)
                _JobNatureNameE = objDr["MotivationJobNatureNameE"].ToString();
            if (objDr.Table.Columns["MotivationJobNatureVIP"] != null && objDr["MotivationJobNatureVIP"].ToString() != "")
                _JobNatureVIP = bool.Parse(objDr["MotivationJobNatureVIP"].ToString());

            if (objDr.Table.Columns["MotivationJobCategoryID"] != null && objDr["MotivationJobCategoryID"].ToString() != "")
                _JobCategoryID = int.Parse(objDr["MotivationJobCategoryID"].ToString());
            if (objDr.Table.Columns["MotivationJobCategoryNameA"] != null)
                _JobCategoryNameA = objDr["MotivationJobCategoryNameA"].ToString();
            if (objDr.Table.Columns["MotivationJobCategoryNameE"] != null)
                _JobCategoryNameE = objDr["MotivationJobCategoryNameE"].ToString();
            if (objDr.Table.Columns["MotivationJobCatregotryOrderValue"] != null && objDr["MotivationJobCatregotryOrderValue"].ToString() != "")
                _JobCatregotryOrderValue = int.Parse(objDr["MotivationJobCatregotryOrderValue"].ToString());

            _Remarks = objDr["Remarks"].ToString();
            _AccountBankNo = objDr["AccountBankNo"].ToString();
            if (objDr["BankNo"].ToString() != "")
                _BankNo = double.Parse(objDr["BankNo"].ToString());
            _BankBranchCode = objDr["MotivationBankBranchCode"].ToString();
            _AccountTypeCode = objDr["MotivationAccountTypeCode"].ToString();
            // double dl = double.Parse(objDr["BankNo"].ToString());
            // if (objDr["IsStop"].ToString() == "1")
            _IsStop = bool.Parse(objDr["IsStop"].ToString());

            _DiscountValue = double.Parse(objDr["DiscountValue"].ToString());
            _LoanDiscountValue = double.Parse(objDr["LoanDiscountValue"].ToString());
            _MemoDiscountValue = double.Parse(objDr["MemoDiscountValue"].ToString());
            _DelayDiscountValue = double.Parse(objDr["DelayDiscountValue"].ToString());
            _BonusValue = double.Parse(objDr["BonusValue"].ToString());
            double.TryParse(objDr["MotivationValueBeforeEffect"].ToString(),out _MotivationValueBeforeEffect);
            if (objDr["MotivationStatementBankID"].ToString() != "")
                _AccountBankID = int.Parse(objDr["MotivationStatementBankID"].ToString());
            _AccountBankName = objDr["MotivationStatementBankName"].ToString();
            if (objDr.Table.Columns["StatementCount"] != null && objDr["StatementCount"].ToString() != "")
                _StatementCount = int.Parse(objDr["StatementCount"].ToString());
            if (objDr.Table.Columns["SumBaseSalaryVal"] != null && objDr["SumBaseSalaryVal"].ToString() != "")
                _SumBaseSalaryVal = double.Parse(objDr["SumBaseSalaryVal"].ToString());
            if (objDr.Table.Columns["SumTransferVal"] != null && objDr["SumTransferVal"].ToString() != "")
                _SumTransferVal = double.Parse(objDr["SumTransferVal"].ToString());
            if (objDr.Table.Columns["SumTelephoneVal"] != null && objDr["SumTelephoneVal"].ToString() != "")
                _SumTelephoneVal = double.Parse(objDr["SumTelephoneVal"].ToString());
            if (objDr.Table.Columns["SumFeedingVal"] != null && objDr["SumFeedingVal"].ToString() != "")
                _SumFeedingVal = double.Parse(objDr["SumFeedingVal"].ToString());
            if (objDr.Table.Columns["SumIncreaseVal"] != null && objDr["SumIncreaseVal"].ToString() != "")
                _SumIncreaseVal = double.Parse(objDr["SumIncreaseVal"].ToString());
            if (objDr.Table.Columns["SumPenaltyDiscount"] != null && objDr["SumPenaltyDiscount"].ToString() != "")
                _SumPenaltyDiscount = double.Parse(objDr["SumPenaltyDiscount"].ToString());

            if (objDr.Table.Columns["SumAbsenceCount"] != null && objDr["SumAbsenceCount"].ToString() != "")
                _SumAbsenceCount = double.Parse(objDr["SumAbsenceCount"].ToString());
            if (objDr.Table.Columns["SumDelayCount"] != null && objDr["SumDelayCount"].ToString() != "")
                _SumDelayCount = double.Parse(objDr["SumDelayCount"].ToString());


            if(objDr.Table.Columns["CostCenterAddValue"]!= null &&objDr["CostCenterAddValue"].ToString()!= "")
                _CostCenterAddValue = double.Parse(objDr["CostCenterAddValue"].ToString());
            if (objDr.Table.Columns["CostCenterBonusOnDeserved"] != null && objDr["CostCenterBonusOnDeserved"].ToString() != "")
                _CostCenterBonusOnDeserved = double.Parse(objDr["CostCenterBonusOnDeserved"].ToString());
            if (objDr.Table.Columns["CostCenterRemarks"] != null )
                _CostCenterRemarks =  objDr["CostCenterRemarks"].ToString() ;
            if (objDr.Table.Columns["CostCenterMotivationRatio"] != null && objDr["CostCenterMotivationRatio"].ToString() != "")
                _CostCenterMotivationRatio = double.Parse(objDr["CostCenterMotivationRatio"].ToString());
            bool.TryParse(objDr["MotivationIsFellowship"].ToString(), out _IsFellowShip);
            double.TryParse(objDr["MotivationFellowshipFund"].ToString(), out _FellowshipFund);
            double.TryParse(objDr["MotivationFellowshipFundBonus"].ToString(), out _FellowshipFundBonus);
            bool.TryParse(objDr["MotivationStatementReview"].ToString(), out _IsReviewed);
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
            {
                StrSql += " and (dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID="+ _ID +") ";
             
            }
            if (_Applicant != 0)
                StrSql += " And (dbo.HRApplicantWorkerMotivationStatement.Applicant = " + _Applicant + ")";
            //if (_MotivationStatement != 0)
            //    StrSql += " And (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatement + ")";
            if (_CostCenter != 0)
                StrSql += " And (CostCenter = " + _CostCenter + ")";
            if (_ApplicantSearch != 0)
                StrSql += " And (dbo.HRApplicantWorkerMotivationStatement.Applicant = " + _ApplicantSearch + ")";
            if (_MotivationStatementSearch != 0)
                StrSql += " And (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + _MotivationStatementSearch + ")";
            if (_CostCenterSearch != 0)
                StrSql += " And (HRApplicantWorkerMotivationStatement.CostCenter = " + _CostCenterSearch + ")";
            if (_ApplicantIDs != null && _ApplicantIDs!="")
                StrSql += " And (dbo.HRApplicantWorkerMotivationStatement.Applicant in ( " + _ApplicantIDs + "))";
            if (_MotivationStatementIDs != null && _MotivationStatementIDs != "")
                StrSql += " And (HRApplicantWorkerMotivationStatement.MotivationStatement in ( " + _MotivationStatementIDs + "))";
            if (_CostCenterIDs != null && _CostCenterIDs != "")
            {
                if (_CostCenterIDs != "0")
                {
                    string strCostCenter = " SELECT CostCenter FROM HRCostCenter WHERE  (CostCenter  in ("+ _CostCenterIDs +") ) or (ParentID IN (" + _CostCenterIDs + "))";
                   // StrSql += " And (HRApplicantWorkerMotivationStatement.CostCenter in ( " + strCostCenter + "))";
                }
                else
                {
                    StrSql += " And (HRApplicantWorkerMotivationStatement.CostCenter in ( " + _CostCenterIDs + "))";
                }

            }
            if (_IsStopSearch != 0)
            {
                if (_IsStopSearch == 1)
                {
                    StrSql += " And (IsStop=0)";
                }
                else if (_IsStopSearch == 2)
                {
                    StrSql += " And (IsStop=1)";
                }
            }
            if (_AccountBankNoSearch != 0)
            {
                if (_AccountBankNoSearch == 1) // has accountNo
                {
                    StrSql += " And  (AccountBankNo IS NOT NULL) AND (AccountBankNo <> '')";
                }
                else if (_AccountBankNoSearch == 2) // not has accountNo
                {
                    StrSql += " And  ((AccountBankNo IS NULL) OR (AccountBankNo = ''))";
                }
            }


            if (_IntBankID == 1)
                StrSql += " And MotivationStatementBankID =  81 ";
            if (_IntBankID == 2)
                StrSql += " And MotivationStatementBankID =  3 ";

            if (_intDiscountType == 1)
                StrSql += " And MemoDiscountValue > 0 ";
            else if (_intDiscountType == 3)
                StrSql += " And DelayDiscountValue > 0 ";
            else if (_intDiscountType == 5)
                StrSql += " And LoanDiscountValue > 0 ";


            if (_LastMotivation)
            {
                string strTemp = " where (1=1) ";
               
                if (_ApplicantIDs != null && _ApplicantIDs != "")
                    strTemp += " and (HRApplicantWorkerMotivationStatement.Applicant in ( " + _ApplicantIDs + "))";
                if (_AddedBonusStatus == 2)
                    strTemp += " and   dbo.HRMotivationStatement.MotivationIsAddedBonus =0 ";
                if (_AddedBonusStatus == 1)
                    strTemp += " and   dbo.HRMotivationStatement.MotivationIsAddedBonus =1 ";
                StrSql += @" And HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID in (
SELECT  MAX(ApplicantMotivationStatementID)  FROM    HRApplicantWorkerMotivationStatement 
 inner join dbo.HRMotivationStatement 
 ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID " + strTemp + @"  GROUP BY Applicant" +
")";
            }
            //if (_OrderStatus == 0)
            //{
            //    StrSql += "order by HRApplicantWorkerMotivationStatement.CostCenter,dbo.HRApplicantWorkerMotivationStatement.Applicant";
            //}
            //else if (_OrderStatus == 1)
            //{
            //    StrSql += "order by HRApplicantWorkerMotivationStatement.Applicant,HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID";
            //}
            //else if (_OrderStatus == 2)
            //{
            //    StrSql += "order by HRApplicantWorkerMotivationStatement.Applicant,HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID Desc";
            //}
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetLastMotivationValue()
        {
            
            DataTable Returned = new DataTable();
            string strSql = @"SELECT  HRApplicantWorkerMotivationStatement_1.Applicant, HRApplicantWorkerMotivationStatement_1.MotivationValueBeforeEffect
,dbo.HRMotivationStatement.DateFrom AS MotivationDate
FROM(SELECT        Applicant, MAX(ApplicantMotivationStatementID) AS LastMotivationStatement
                           FROM            dbo.HRApplicantWorkerMotivationStatement
  INNER JOIN dbo.HRMotivationStatement 
   ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID 
   WHERE(dbo.HRMotivationStatement.MotivationIsAddedBonus = 0) 
                           GROUP BY Applicant) AS derivedtbl_1 INNER JOIN
                         dbo.HRApplicantWorkerMotivationStatement AS HRApplicantWorkerMotivationStatement_1 ON derivedtbl_1.LastMotivationStatement = HRApplicantWorkerMotivationStatement_1.ApplicantMotivationStatementID
 INNER JOIN dbo.HRMotivationStatement ON HRApplicantWorkerMotivationStatement_1.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID  where  dbo.HRMotivationStatement.MotivationIsAddedBonus = 0 ";
            if(_ApplicantIDs != null && _ApplicantIDs!= "")
            strSql += " and (HRApplicantWorkerMotivationStatement_1.Applicant IN("+ _ApplicantIDs +@"))";
            Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;

        }
        public DataTable GetMotivationValue()
        {
            string strSql = @"SELECT Applicant, MotivationValue,MotivationStatementReview
  FROM     dbo.HRApplicantWorkerMotivationStatement
WHERE  (MotivationStatement = " + _MotivationStatement+") AND (Applicant IN ("+_ApplicantIDs+"))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetLastAddedBonusValue()
        {

            DataTable Returned = new DataTable();
            string strSql = @"SELECT  HRApplicantWorkerMotivationStatement_1.Applicant, HRApplicantWorkerMotivationStatement_1.MotivationValueBeforeEffect
,dbo.HRMotivationStatement.DateFrom AS MotivationDate
FROM(SELECT        Applicant, MAX(ApplicantMotivationStatementID) AS LastMotivationStatement
                           FROM            dbo.HRApplicantWorkerMotivationStatement
  INNER JOIN dbo.HRMotivationStatement 
   ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID 
   WHERE(dbo.HRMotivationStatement.MotivationIsAddedBonus = 1) 
                           GROUP BY Applicant) AS derivedtbl_1 INNER JOIN
                         dbo.HRApplicantWorkerMotivationStatement AS HRApplicantWorkerMotivationStatement_1 ON derivedtbl_1.LastMotivationStatement = HRApplicantWorkerMotivationStatement_1.ApplicantMotivationStatementID
 INNER JOIN dbo.HRMotivationStatement ON HRApplicantWorkerMotivationStatement_1.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID  where  dbo.HRMotivationStatement.MotivationIsAddedBonus = 0 ";
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql += " and (HRApplicantWorkerMotivationStatement_1.Applicant IN(" + _ApplicantIDs + @"))";
            Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;

        }
        #endregion

        int _IntBankID;

        public int IntBankID
        {
            get { return _IntBankID; }
            set { _IntBankID = value; }
        }
    }
}
