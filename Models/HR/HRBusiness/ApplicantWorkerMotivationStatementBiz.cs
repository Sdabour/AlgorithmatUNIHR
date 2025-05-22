using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class  ApplicantWorkerMotivationStatementBiz
    {
        #region Private Data
        ApplicantWorkerMotivationStatementDb _ApplicantWorkerMotivationStatementDb;
        ApplicantWorkerBiz _ApplicantWorkerBiz;
        MotivationStatementBiz _MotivationStatementBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        JobNatureTypeBiz _JobNatureTypeBiz;
        ApplicantWorkerManyStatementBiz _ManyStatementBiz;
        
        double _BaseSalaryValue;
        double _BaseSalaryDetailValue;
        double _TotalSalaryValue;
        BankBiz _BankBiz;
        ApplicantWorkerMotivationStatementDiscountCol _DiscountCol;
        ApplicantWorkerMotivationStatementDiscountCol _DeletedDiscountCol;
        ApplicantWorkerMotivationStatementBonusCol _BonusCol;
        ApplicantWorkerMotivationStatementBonusCol _DeletedBonusCol;
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementBiz()
        {
            _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb();
            _ApplicantWorkerBiz = new ApplicantWorkerBiz();
            _MotivationStatementBiz = new MotivationStatementBiz();
            _CostCenterHRBiz = new CostCenterHRBiz();
            _JobNatureTypeBiz = new JobNatureTypeBiz();
        }
        public ApplicantWorkerMotivationStatementBiz(DataRow objDr)
        {
            _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb(objDr);
            _ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);

            _MotivationStatementBiz = new MotivationStatementBiz(objDr);
           
            _CostCenterHRBiz = new CostCenterHRBiz(objDr);
         
            _JobNatureTypeBiz = new JobNatureTypeBiz();
            //_CostCenterHRBiz = new CostCenterHRBiz(objDr);
            if (_ApplicantWorkerMotivationStatementDb.JobNatureID != 0)
            {
                _JobNatureTypeBiz.ID = _ApplicantWorkerMotivationStatementDb.JobNatureID;
                _JobNatureTypeBiz.NameA = _ApplicantWorkerMotivationStatementDb.JobNatureNameA;
                _JobNatureTypeBiz.NameE = _ApplicantWorkerMotivationStatementDb.JobNatureNameE;
                _JobNatureTypeBiz.VIP = _ApplicantWorkerMotivationStatementDb.JobNatureVIP;
                _JobNatureTypeBiz.JobCategory = new JobCategoryBiz();
                _JobNatureTypeBiz.JobCategory.ID = _ApplicantWorkerMotivationStatementDb.JobCategoryID;
                _JobNatureTypeBiz.JobCategory.NameA = _ApplicantWorkerMotivationStatementDb.JobCategoryNameA;
                _JobNatureTypeBiz.JobCategory.NameE = _ApplicantWorkerMotivationStatementDb.JobCategoryNameE;
                _JobNatureTypeBiz.JobCategory.OrderValue = _ApplicantWorkerMotivationStatementDb.JobCatregotryOrderValue;
 
            }
            if (_ApplicantWorkerMotivationStatementDb.AccountBankID != 0)
            {
                _BankBiz = new BankBiz();
                _BankBiz.ID = _ApplicantWorkerMotivationStatementDb.AccountBankID;
                _BankBiz.NameA = _ApplicantWorkerMotivationStatementDb.AccountBankName;
            }
        }
        public ApplicantWorkerMotivationStatementBiz(MotivationStatementBiz objMotivationStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
            _ApplicantWorkerBiz.VirualCostCenterBiz = objApplicantWorkerBiz.MotivationCostCenterBiz.CostCenterHRBiz;
            _ApplicantWorkerBiz.VirualJobNatureTypeBiz = objApplicantWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz;
            _MotivationStatementBiz = objMotivationStatementBiz;
            ApplicantWorkerMotivationStatementDb objDb = new ApplicantWorkerMotivationStatementDb();
            if (objApplicantWorkerBiz.LastMotivationStatementID != 0)
            {
                objDb.ID = objApplicantWorkerBiz.LastMotivationStatementID;
            }
            else
            {
                _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb();
                return;
            }
            objDb.OrderStatue = 1;
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
            {
                DataRow objDr = dtTemp.Rows[0];
                _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb(objDr);
                //_ApplicantWorkerBiz = new ApplicantWorkerBiz(objDr);
                //_MotivationStatementBiz = new MotivationStatementBiz(objDr);
                _CostCenterHRBiz = new CostCenterHRBiz(objDr);
                _ApplicantWorkerBiz.VirualCostCenterBiz = CostCenterHRBiz;
                _JobNatureTypeBiz = new JobNatureTypeBiz();
                //_CostCenterHRBiz = new CostCenterHRBiz(objDr);
                if (_ApplicantWorkerMotivationStatementDb.JobNatureID != 0)
                {
                    _JobNatureTypeBiz.ID = _ApplicantWorkerMotivationStatementDb.JobNatureID;
                    _JobNatureTypeBiz.NameA = _ApplicantWorkerMotivationStatementDb.JobNatureNameA;
                    _JobNatureTypeBiz.NameE = _ApplicantWorkerMotivationStatementDb.JobNatureNameE;
                    _JobNatureTypeBiz.VIP = _ApplicantWorkerMotivationStatementDb.JobNatureVIP;
                    _JobNatureTypeBiz.JobCategory = new JobCategoryBiz();
                    _JobNatureTypeBiz.JobCategory.ID = _ApplicantWorkerMotivationStatementDb.JobCategoryID;
                    _JobNatureTypeBiz.JobCategory.NameA = _ApplicantWorkerMotivationStatementDb.JobCategoryNameA;
                    _JobNatureTypeBiz.JobCategory.NameE = _ApplicantWorkerMotivationStatementDb.JobCategoryNameE;
                    _JobNatureTypeBiz.JobCategory.OrderValue = _ApplicantWorkerMotivationStatementDb.JobCatregotryOrderValue;
                    //_ApplicantWorkerBiz.VirualCostCenterBiz =  //objApplicantWorkerBiz.MotivationCostCenterBiz.CostCenterHRBiz;
                    _ApplicantWorkerBiz.VirualJobNatureTypeBiz = JobNatureTypeBiz;// objApplicantWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz;
                }
                if (_ApplicantWorkerMotivationStatementDb.AccountBankID != 0)
                {
                    _BankBiz = new BankBiz();
                    _BankBiz.ID = _ApplicantWorkerMotivationStatementDb.AccountBankID;
                    _BankBiz.NameA = _ApplicantWorkerMotivationStatementDb.AccountBankName;
                }
            }
            else
            {
                _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb();

                
            }
           
            
            //if (_ApplicantWorkerMotivationStatementDb.CostCenter != 0)
            //    _CostCenterHRBiz = new CostCenterHRBiz(_ApplicantWorkerMotivationStatementDb.CostCenter);
            //else
            //    _CostCenterHRBiz = new CostCenterHRBiz();

            //if (_ApplicantWorkerMotivationStatementDb.JobNatureTypeID != 0)
            //    _JobNatureTypeBiz = new JobNatureTypeBiz(_ApplicantWorkerMotivationStatementDb.JobNatureTypeID);
            //else
            //    _JobNatureTypeBiz = new JobNatureTypeBiz();
        }
        public ApplicantWorkerMotivationStatementBiz(MotivationStatementBiz objMotivationStatementBiz, ApplicantWorkerBiz objApplicantWorkerBiz, CostCenterHRBiz objCostCenterHRBiz)
        {
            _ApplicantWorkerBiz = objApplicantWorkerBiz;
            _MotivationStatementBiz = objMotivationStatementBiz;
            _CostCenterHRBiz = objCostCenterHRBiz;  
            _ApplicantWorkerMotivationStatementDb = new ApplicantWorkerMotivationStatementDb(_MotivationStatementBiz.ID, _ApplicantWorkerBiz.ID, objCostCenterHRBiz.ID);
            if (_ApplicantWorkerMotivationStatementDb.JobNatureTypeID != 0)
                _JobNatureTypeBiz = new JobNatureTypeBiz(_ApplicantWorkerMotivationStatementDb.JobNatureTypeID);
            else
                _JobNatureTypeBiz = new JobNatureTypeBiz();
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _ApplicantWorkerMotivationStatementDb.ID = value; }
            get { return _ApplicantWorkerMotivationStatementDb.ID; }
        }
        public ApplicantWorkerBiz ApplicantWorkerBiz
        {
            set { _ApplicantWorkerBiz = value; }
            get { return _ApplicantWorkerBiz; }
        }
        public MotivationStatementBiz MotivationStatementBiz
        {
            set { _MotivationStatementBiz = value; }
            get { return _MotivationStatementBiz; }
        }
        public CostCenterHRBiz CostCenterHRBiz
        {
            set { _CostCenterHRBiz = value; }
            get { return _CostCenterHRBiz; }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set { _JobNatureTypeBiz = value; }
            get { return _JobNatureTypeBiz; }
        }
        public double MotivationValue
        {
            set { _ApplicantWorkerMotivationStatementDb.MotivationValue = value; }
            get {
                if (!true)//ApplicantWorkerBiz.UMSShowMotivationAuthorized)
                    return -1;
                return _ApplicantWorkerMotivationStatementDb.MotivationValue; }
        }
        public double DiscountValue
        {
            set { _ApplicantWorkerMotivationStatementDb.DiscountValue = value; }
            get { return _ApplicantWorkerMotivationStatementDb.DiscountValue; }
        }
        public double BonusValue
        {
            set { _ApplicantWorkerMotivationStatementDb.BonusValue = value; }
            get { return _ApplicantWorkerMotivationStatementDb.BonusValue; }
        }
        public double MotivationValueBeforeEffect
        {
            set { _ApplicantWorkerMotivationStatementDb.MotivationValueBeforeEffect = value; }
            get { return _ApplicantWorkerMotivationStatementDb.MotivationValueBeforeEffect; }
        }
        ApplicantWorkerManyStatementCol _ManyStatementCol;
        public ApplicantWorkerManyStatementBiz ManyStatementBiz
        {
            set { _ManyStatementBiz = value; }
            get { return _ManyStatementBiz; }
        }
        public ApplicantWorkerManyStatementCol ManyStatementCol
        {
            set { _ManyStatementCol = value; }
            get { return _ManyStatementCol; }
        }
        public bool IsStop
        {
            set { _ApplicantWorkerMotivationStatementDb.IsStop = value; }
            get { return _ApplicantWorkerMotivationStatementDb.IsStop; }
        }
        public string Remarks
        {
            set { _ApplicantWorkerMotivationStatementDb.Remarks = value; }
            get { return _ApplicantWorkerMotivationStatementDb.Remarks; }
        }
        public string AccountBankNo
        {
            set { _ApplicantWorkerMotivationStatementDb.AccountBankNo = value; }
            get {
                if (_ApplicantWorkerMotivationStatementDb.AccountBankNo == null)
                    _ApplicantWorkerMotivationStatementDb.AccountBankNo = "";
                return _ApplicantWorkerMotivationStatementDb.AccountBankNo; }
        }
        public double BankNo
        {
            set { _ApplicantWorkerMotivationStatementDb.BankNo = value; }
            get { return _ApplicantWorkerMotivationStatementDb.BankNo; }
        }
        public BankBiz BankBiz
        {
            set
            {
                _BankBiz = value;
            }
            get
            {
                if (_BankBiz == null || _BankBiz.ID == 0)
                    _BankBiz = _ApplicantWorkerBiz.BankBiz;
                return _BankBiz;
            }
        }

        public int IntDiscountType
        {
            get { return _ApplicantWorkerMotivationStatementDb.IntDiscountType; }
            set { _ApplicantWorkerMotivationStatementDb.IntDiscountType = value; }
        }
        public double LoanDiscountValue
        {
            get { return _ApplicantWorkerMotivationStatementDb.LoanDiscountValue; }
            set { _ApplicantWorkerMotivationStatementDb.LoanDiscountValue = value; }
        }
        public double MemoDiscountValue
        {
            get { return _ApplicantWorkerMotivationStatementDb.MemoDiscountValue; }
            set { _ApplicantWorkerMotivationStatementDb.MemoDiscountValue = value; }
        }
        public double DelayDiscountValue
        {
            get { return _ApplicantWorkerMotivationStatementDb.DelayDiscountValue; }
            set { _ApplicantWorkerMotivationStatementDb.DelayDiscountValue = value; }
        }


        public int IntBankID
        {
            get { return _ApplicantWorkerMotivationStatementDb.IntBankID; }
            set { _ApplicantWorkerMotivationStatementDb.IntBankID = value; }
        }
        public string BankBranchCode
        {
            get { return _ApplicantWorkerMotivationStatementDb.BankBranchCode; }
            set { _ApplicantWorkerMotivationStatementDb.BankBranchCode = value; }
        }
       

        public string AccountTypeCode
        {
            get { return _ApplicantWorkerMotivationStatementDb.AccountTypeCode; }
            set { _ApplicantWorkerMotivationStatementDb.AccountTypeCode = value; }
        }
        public double BaseSalaryValue { set { _BaseSalaryValue = value; } get { return _BaseSalaryValue; } }
        public double BaseSalaryDetailValue { set { _BaseSalaryDetailValue = value; } get { return _BaseSalaryDetailValue; } }
        public double TotalSalaryValue { set { _TotalSalaryValue = value; } get { return _TotalSalaryValue; } }

        public int StatementCount
        {
            get { return _ApplicantWorkerMotivationStatementDb.StatementCount; }
            set { _ApplicantWorkerMotivationStatementDb.StatementCount = value; }
        }
        public double SumBaseSalaryVal
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumBaseSalaryVal; }
            set { _ApplicantWorkerMotivationStatementDb.SumBaseSalaryVal = value; }
        }
        public double SumTransferVal
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumTransferVal; }
            set { _ApplicantWorkerMotivationStatementDb.SumTransferVal = value; }
        }
        public double SumTelephoneVal
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumTelephoneVal; }
            set { _ApplicantWorkerMotivationStatementDb.SumTelephoneVal = value; }
        }
        public double SumFeedingVal
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumFeedingVal; }
            set { _ApplicantWorkerMotivationStatementDb.SumFeedingVal = value; }
        }
        public double SumIncreaseVal
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumIncreaseVal; }
            set { _ApplicantWorkerMotivationStatementDb.SumIncreaseVal = value; }
        }
        public double SumPenaltyDiscount
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumPenaltyDiscount; }
            set { _ApplicantWorkerMotivationStatementDb.SumPenaltyDiscount = value; }
        }

        public double SumAbsenceCount
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumAbsenceCount; }
            set { _ApplicantWorkerMotivationStatementDb.SumAbsenceCount = value; }
        }
        public double SumDelayCount
        {
            get { return _ApplicantWorkerMotivationStatementDb.SumDelayCount; }
            set { _ApplicantWorkerMotivationStatementDb.SumDelayCount = value; }
        }
         

        public double CostCenterAddValue
        {
            get { return _ApplicantWorkerMotivationStatementDb.CostCenterAddValue; }
            set { _ApplicantWorkerMotivationStatementDb.CostCenterAddValue = value; }
        }

       public bool  IsFellowship
       {
              get { return _ApplicantWorkerMotivationStatementDb.IsFellowShip; }
            set { _ApplicantWorkerMotivationStatementDb.IsFellowShip = value; }
       }
public double FellowshipFund
{
       get {
           double Returned = _ApplicantWorkerMotivationStatementDb.FellowshipFund;
           if (Returned == 0 && IsFellowship &&
               (_ApplicantWorkerBiz.NativeCurrentSalary <=0 ||  _ApplicantWorkerBiz.FellowshipSalaryOrMotivation== 1))
           {

               Returned = FellowshipRoleCol.GetRecommendedFellowship(FellowshipRoleMotivationOrSalary.Motivation, 
                   MotivationValueBeforeEffect, ApplicantWorkerBiz);
           }

           return Returned;// _ApplicantWorkerMotivationStatementDb.FellowshipFund;
       }
            set { _ApplicantWorkerMotivationStatementDb.FellowshipFund = value; }
}
public double FellowshipFundBonus
{
    get { return _ApplicantWorkerMotivationStatementDb.FellowshipFundBonus; }
    set { _ApplicantWorkerMotivationStatementDb.FellowshipFundBonus = value; }
}

        public double CostCenterBonusOnDeserved
        {
            get { return _ApplicantWorkerMotivationStatementDb.CostCenterBonusOnDeserved; }
            set { _ApplicantWorkerMotivationStatementDb.CostCenterBonusOnDeserved = value; }
        }
       

        public string CostCenterRemarks
        {
            get { return _ApplicantWorkerMotivationStatementDb.CostCenterRemarks; }
            set { _ApplicantWorkerMotivationStatementDb.CostCenterRemarks = value; }
        }
       

        public double CostCenterMotivationRatio
        {
            get { return _ApplicantWorkerMotivationStatementDb.CostCenterMotivationRatio; }
            set { _ApplicantWorkerMotivationStatementDb.CostCenterMotivationRatio = value; }
        }

        public ApplicantWorkerMotivationStatementDiscountCol DiscountCol
        {
            set
            {
                _DiscountCol = value;
            }
            get
            {
                if (_DiscountCol == null)
                    _DiscountCol = new ApplicantWorkerMotivationStatementDiscountCol(this);
                return _DiscountCol;
            }
        }
        public ApplicantWorkerMotivationStatementDiscountCol DeletedDiscountCol
        {
            set
            {
                _DeletedDiscountCol = value;
            }
            get
            {
                if (_DeletedDiscountCol == null)
                    _DeletedDiscountCol = new ApplicantWorkerMotivationStatementDiscountCol(false);
                return _DeletedDiscountCol;
            }
        }
        public ApplicantWorkerMotivationStatementBonusCol BonusCol
        {
            set
            {
                _BonusCol = value;
            }
            get
            {
                if (_BonusCol == null)
                    _BonusCol = new ApplicantWorkerMotivationStatementBonusCol(this);
                return _BonusCol;
            }
        }
        public ApplicantWorkerMotivationStatementBonusCol DeletedBonusCol
        {
            set
            {
                _DeletedBonusCol = value;
            }
            get
            {
                if (_DeletedBonusCol == null)
                    _DeletedBonusCol = new ApplicantWorkerMotivationStatementBonusCol(false);
                return _DeletedBonusCol;
            }
        }
        #endregion
        #region Private Methods
        void SaveDiscount()
        {
            RemoveDiscount();
            foreach (ApplicantWorkerMotivationStatementDiscountBiz objBiz in DiscountCol)
            {
                if (objBiz.ID == 0)
                {
                    objBiz.ApplicantWorkerMotivationStatement = this.ID;
                    objBiz.Add();
                }
                else
                {
                    objBiz.Edit();
                }
            }
        }
        void RemoveDiscount()
        {
            foreach (ApplicantWorkerMotivationStatementDiscountBiz objBiz in DeletedDiscountCol)
            {
                if (objBiz.ID != 0)
                    objBiz.Delete();
            }
        }
        void SaveBonus()
        {
            RemoveBonus();
            foreach (ApplicantWorkerMotivationStatementBonusBiz objBiz in BonusCol)
            {
                if (objBiz.ID == 0)
                {
                    objBiz.ApplicantWorkerMotivationStatement = this.ID;
                    objBiz.Add();
                }
                else
                {
                    objBiz.Edit();
                }
            }
        }
        void RemoveBonus()
        {
            foreach (ApplicantWorkerMotivationStatementBonusBiz objBiz in DeletedBonusCol)
            {
                if (objBiz.ID != 0)
                    objBiz.Delete();
            }
        }
        #endregion
        #region Public Methods
        void GetData()
        {
            _ApplicantWorkerMotivationStatementDb.Applicant = _ApplicantWorkerBiz.ID;
            _ApplicantWorkerMotivationStatementDb.MotivationStatement = _MotivationStatementBiz.ID;

            _ApplicantWorkerMotivationStatementDb.CostCenter = _CostCenterHRBiz.ID;
            _ApplicantWorkerMotivationStatementDb.JobNatureTypeID = _JobNatureTypeBiz.ID;
            FellowshipFund = 0;
            _ApplicantWorkerMotivationStatementDb.FellowshipFund = FellowshipFund;
            this.BonusValue = BonusCol.TotalValue;
            if (AccountBankNo != "")
                _ApplicantWorkerMotivationStatementDb.AccountBankID = BankBiz.ID;
            if (_ApplicantWorkerMotivationStatementDb.AccountBankID == _ApplicantWorkerBiz.BankBiz.ID)
            {
                _ApplicantWorkerMotivationStatementDb.AccountTypeCode = _ApplicantWorkerBiz.AccountTypeCode;
                _ApplicantWorkerMotivationStatementDb.BankBranchCode = _ApplicantWorkerBiz.AccountBankBranchCode;
            }
            this.DiscountValue = DiscountCol.TotalValue;
            BonusValue = BonusCol.TotalValue;
            this.MotivationValue = this.MotivationValueBeforeEffect + this.BonusValue - this.DiscountValue -
                FellowshipFund - FellowshipFundBonus;
        }
        public double GetRecomendedValue()
        {
            this.DiscountValue = DiscountCol.TotalValue;
            BonusValue = BonusCol.TotalValue;
            FellowshipFund = 0;
            double Returned = this.MotivationValueBeforeEffect + this.BonusValue - this.DiscountValue -
              FellowshipFund - FellowshipFundBonus;

            return Returned;
        }
        public void Add()
        {
            GetData();
            _ApplicantWorkerMotivationStatementDb.AccountBankID = BankBiz.ID;
            _ApplicantWorkerMotivationStatementDb.Add();
            SaveDiscount();
            SaveBonus();
        }
        public void Edit()
        {
            GetData();
            _ApplicantWorkerMotivationStatementDb.AccountBankID = BankBiz.ID;
            _ApplicantWorkerMotivationStatementDb.Edit();
            SaveDiscount();
            SaveBonus();
            RemoveDiscount();
        }
        public void Delete()
        {            
            _ApplicantWorkerMotivationStatementDb.Delete();
            RemoveDiscount();
            RemoveBonus();
        }
        #endregion
    }
}
