using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.GL.GLBusiness;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.COMMON.COMMONBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementBiz : OriginStatementBiz
    {
        #region Private Data
        //ApplicantWorkerStatementDb ((ApplicantWorkerStatementDb)_OriginStatementDb);
        protected bool _GetTotalFromDB;
        GlobalStatementBiz _GlobalStatementBiz;
        //FinancialStatementTypeBiz _FinancialStatementTypeBiz;
        ApplicantWorkerBiz _ApplicantBiz;
        JobNatureTypeBiz _JobNatureTypeBiz;
        ApplicantWorkerBonusCol _RewardCol;
        //ApplicantWorkerBonusCol _DeleteRewardCol;
        ApplicantWorkerStatementLoanDiscountCol _LoanDiscountCol;
        ApplicantWorkerLoanPaymentCol _LoanPaymentCol;
        ApplicantWorkerPayBackCol _PayBackCol;
        //ApplicantWorkerPayBackCol _DeletedPayBackCol;
        //ApplicantWorkerLoanPaymentCol _DeletedLoanPaymentCol;
        ApplicantWorkerStatementLoanDiscountCol _DeleteLoanDiscountCol;
        ApplicantWorkerStatementSalaryDetailsCol _SalaryDetailsCol;
        ApplicantWorkerStatementSubSectorCol _SubSectorCol;
        ApplicantWorkerStatementSubSectorCol _CurrentSubSectorCol;
        ApplicantWorkerPenaltyDiscountCol _PenaltyDiscountCol;
        //ApplicantWorkerPenaltyDiscountCol _DeletedPenaltyDiscountCol;
        ApplicantWorkerAttendanceDiscountCol _AttendanceDiscountCol;
        //ApplicantWorkerAttendanceDiscountCol _DeletedAttendanceDiscountCol;
        ApplicantWorkerAttendanceStatementCol _AttendanceStatementCol;
        ApplicantWorkerAttendanceStatementCol _DeletedAttendanceStatementCol;
        ApplicantWorkerBillCol _BillCol;
        //ApplicantWorkerBillCol _DeletedBillCol;
        CostCenterHRBiz _CostCenterBiz;
        CostCenterHRBiz _MotivationCostCenterBiz;
        ApplicantWorkerFellowShipPaymentCol _FellowShipPaymentCol;
        //ApplicantWorkerFellowShipPaymentCol _DeletedFellowShipPaymentCol;
        ApplicantWorkerStatementExchangeCol _ExchangeCol;
        ApplicantWorkerStatementBiz _BaseStatementBiz;

        ApplicantWorkerStatementBonusCol _BonusCol;
        ApplicantWorkerStatementBonusCol _DeleteBonusCol;
        ApplicantWorkerStatementDiscountCol _DiscountCol;
        ApplicantWorkerStatementDiscountCol _DeleteDiscountCol;

        BankBiz _BankBiz;
       
        #endregion
        #region Constructors
        public ApplicantWorkerStatementBiz()
        {
            _OriginStatementDb = new ApplicantWorkerStatementDb();
            _GlobalStatementBiz = new GlobalStatementBiz();
            _ApplicantBiz = new ApplicantWorkerBiz();
            
            _CostCenterBiz = new CostCenterHRBiz();
            _JobNatureTypeBiz = new JobNatureTypeBiz();
            _MotivationCostCenterBiz = new CostCenterHRBiz();
        }
        public ApplicantWorkerStatementBiz(DataRow objDr)
        {
            _OriginStatementDb = new ApplicantWorkerStatementDb(objDr);
            _GlobalStatementBiz = new GlobalStatementBiz(objDr);
            _ApplicantBiz = new ApplicantWorkerBiz(objDr);
             


            _ApplicantBiz.CurrentSalary = _ApplicantBiz.NativeCurrentSalary;
            if (_GlobalStatementBiz.BaseSalary && BaseSalary != _ApplicantBiz.CurrentSalary)
            {
                _ApplicantBiz.CurrentSalary = _ApplicantBiz.CurrentSalary - IncreaseValue;
            }


            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter != 0)
            {
                _CostCenterBiz = new CostCenterHRBiz(objDr);
            }
            else
            {
                _CostCenterBiz = new CostCenterHRBiz();
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter == ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter)
                _MotivationCostCenterBiz = _CostCenterBiz;
            else
            {
               // _MotivationCostCenterBiz = new CostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
                _MotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
            }
            

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).JobNature != 0)
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz(objDr);
            }
            else
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz();
            }
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).FinancialStatementType != 0)
            {
                
            }
            else
            {
                 
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankID != 0)
            {
                _BankBiz = new BankBiz();
                _BankBiz.ID = ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankID;
                if (_BankBiz.ID == 152)
                { 
                }
                _BankBiz.NameA = ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankName;
            }
            SubSectorCol = new ApplicantWorkerStatementSubSectorCol(true);
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).SubSectorID != 0)
            {
                _SubSectorCol = new ApplicantWorkerStatementSubSectorCol(true);
                _CurrentSubSectorCol = new ApplicantWorkerStatementSubSectorCol(true);
                SubSectorCol.Add(new ApplicantWorkerStatementSubSectorBiz(objDr));
                CurrentSubSectorCol.Add(new ApplicantWorkerStatementSubSectorBiz(objDr));
            }
            _SalaryDetailsCol = new ApplicantWorkerStatementSalaryDetailsCol(true);
            ApplicantWorkerStatementSalaryDetailsBiz objDetails = new ApplicantWorkerStatementSalaryDetailsBiz();
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).FeedingValue > 0)
            {
                objDetails = new ApplicantWorkerStatementSalaryDetailsBiz();
                objDetails.DetailTypeBiz.ID = 5;
                objDetails.DetailTypeBiz.NameA = "بدل تغذية";
                objDetails.DetailValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).FeedingValue;
                objDetails.DetailRecomendedValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).FeedingValue;
                _SalaryDetailsCol.Add(objDetails);
            }
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).PhoneValue > 0)
            {
                objDetails = new ApplicantWorkerStatementSalaryDetailsBiz();
                objDetails.DetailTypeBiz.ID = 3;
                objDetails.DetailTypeBiz.NameA = "بدل تليفون";
                objDetails.DetailValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).PhoneValue;
                objDetails.DetailRecomendedValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).PhoneValue;
                _SalaryDetailsCol.Add(objDetails);
            }
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).TransportValue > 0)
            {
                objDetails = new ApplicantWorkerStatementSalaryDetailsBiz();
                objDetails.DetailTypeBiz.ID = 2;
                objDetails.DetailTypeBiz.NameA = "بدل انتقال";
                objDetails.DetailValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).TransportValue;
                objDetails.DetailRecomendedValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).TransportValue;
                _SalaryDetailsCol.Add(objDetails);
            }
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).OtherValue > 0)
            {
                objDetails = new ApplicantWorkerStatementSalaryDetailsBiz();
                objDetails.DetailTypeBiz.ID = 4;
                objDetails.DetailTypeBiz.NameA = "بدل متنوع";
                objDetails.DetailValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).OtherValue;
                objDetails.DetailRecomendedValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).OtherValue;
                _SalaryDetailsCol.Add(objDetails);
            }
            _PayBackCol = new ApplicantWorkerPayBackCol(true);
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).PayBackValue > 0)
            {
                ApplicantWorkerPayBackBiz objPayBackBiz = new ApplicantWorkerPayBackBiz();
                objPayBackBiz.Value = (float)((ApplicantWorkerStatementDb)_OriginStatementDb).PayBackValue;
                _PayBackCol.Add(objPayBackBiz);
            }
            _FellowShipPaymentCol = new ApplicantWorkerFellowShipPaymentCol(true);
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipPaymentValue > 0)
            {
                ApplicantWorkerFellowShipPaymentBiz objBiz = new ApplicantWorkerFellowShipPaymentBiz();
                objBiz.Value = ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipPaymentValue;
                _FellowShipPaymentCol.Add(objBiz);
            }
            _DiscountCol = new ApplicantWorkerStatementDiscountCol(true);
            ApplicantWorkerStatementDiscountBiz objDiscountBiz = new ApplicantWorkerStatementDiscountBiz();
            objDiscountBiz.Value = ((ApplicantWorkerStatementDb)_OriginStatementDb).DiscountValue;
            if (objDiscountBiz.Value > 0)
                _DiscountCol.Add(objDiscountBiz);
            _ExchangeCol = new ApplicantWorkerStatementExchangeCol(true);
            ApplicantWorkerStatementExchangeBiz objExchange = new ApplicantWorkerStatementExchangeBiz();
            objExchange.ExchangeValue = ((ApplicantWorkerStatementDb)_OriginStatementDb).ExchangeValue;
            if (Math.Abs(objExchange.ExchangeValue) > 0)
                _ExchangeCol.Add(objExchange);
            _PenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
            ApplicantWorkerPenaltyDiscountBiz objPenality = new ApplicantWorkerPenaltyDiscountBiz();
            objPenality.DiscountValue = (float)((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount;


            if (objPenality.DiscountValue > 0)
                _PenaltyDiscountCol.Add(objPenality);



        }
        public ApplicantWorkerStatementBiz(int intID)
        {
            _OriginStatementDb = new ApplicantWorkerStatementDb(intID);
            _GlobalStatementBiz = new GlobalStatementBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).GlobalStatment);
            _ApplicantBiz = new ApplicantWorkerBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).Applicant);
            //_FinancialStatementTypeBiz = FinancialStatementTypeCol.GetFinancialStatementTypeBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).FinancialStatementType);


            _ApplicantBiz.CurrentSalary = _ApplicantBiz.NativeCurrentSalary;
            if (_GlobalStatementBiz.BaseSalary && BaseSalary != _ApplicantBiz.CurrentSalary)
                _ApplicantBiz.CurrentSalary = _ApplicantBiz.CurrentSalary - IncreaseValue;



            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter != 0)
            {
                //_CostCenterBiz = new CostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter);
                _CostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter);
            }
            else
            {
                _CostCenterBiz = new CostCenterHRBiz();
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter == ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter)
                _MotivationCostCenterBiz = _CostCenterBiz;
            else
            {
                // _MotivationCostCenterBiz = new CostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
                _MotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
            }            
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).JobNature != 0)
            {
                _JobNatureTypeBiz = JobNatureTypeCol.GetJobNatureTypeBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).JobNature);
            }
            else
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz();
            }
            
        }
        public ApplicantWorkerStatementBiz(ApplicantWorkerBiz objApplicantBiz, GlobalStatementBiz objGlobalStatement)
        {
            if (objGlobalStatement == null)
                objGlobalStatement = new GlobalStatementBiz();
            _OriginStatementDb = new ApplicantWorkerStatementDb();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).Applicant = objApplicantBiz.ID;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).GlobalStatment = objGlobalStatement.ID;
            DataTable dtTemp = ((ApplicantWorkerStatementDb)_OriginStatementDb).Search();
            if (dtTemp.Rows.Count > 0)
                _OriginStatementDb = new ApplicantWorkerStatementDb(dtTemp.Rows[0]);
            else
                _OriginStatementDb = new ApplicantWorkerStatementDb();
            _ApplicantBiz = objApplicantBiz;
            _GlobalStatementBiz = objGlobalStatement;


            _ApplicantBiz.CurrentSalary = _ApplicantBiz.NativeCurrentSalary;
            if (_GlobalStatementBiz.BaseSalary && BaseSalary != _ApplicantBiz.CurrentSalary)
                _ApplicantBiz.CurrentSalary = _ApplicantBiz.CurrentSalary - IncreaseValue;

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter != 0)
            {
                _CostCenterBiz = new CostCenterHRBiz(dtTemp.Rows[0]);
            }  
            else
            {
                _CostCenterBiz = new CostCenterHRBiz();
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter == 
                ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter)
                _MotivationCostCenterBiz = _CostCenterBiz;
            else
            {
                // _MotivationCostCenterBiz = new CostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
                _MotivationCostCenterBiz = CostCenterHRCol.GetCostCenterHRBiz(((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter);
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).JobNature != 0)
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz(dtTemp.Rows[0]);
            }
            else
            {
                _JobNatureTypeBiz = new JobNatureTypeBiz();
            }

            if (((ApplicantWorkerStatementDb)_OriginStatementDb).FinancialStatementType != 0)
            {
                //_FinancialStatementTypeBiz = new FinancialStatementTypeBiz(dtTemp.Rows[0]);
            }
            else
            {
                //_FinancialStatementTypeBiz = new FinancialStatementTypeBiz();
            }
           


        }
        #endregion
        #region Public Properties
        public GlobalStatementBiz GlobalStatementBiz
        {
            set
            {
                _GlobalStatementBiz = value;
            }
            get
            {
                if (_GlobalStatementBiz == null)
                    _GlobalStatementBiz = new GlobalStatementBiz();
                return _GlobalStatementBiz;
            }
        }
       
        public ApplicantWorkerBiz ApplicantBiz
        {
            set
            {
                _ApplicantBiz = value;
            }
            get
            {
                return _ApplicantBiz;
            }
        }
        public DateTime StatementDate
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).StatementDate = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).StatementDate;
            }
        }
        public string AccountBankNo
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo = value;
            }
            get
            {
                if (_GlobalStatementBiz == null || _GlobalStatementBiz.ID == 0)
                    return "";
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo;
            }
        }
        public string BankBranchCode
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BankBranchCode = value;
            }
            get
            {
                if (_GlobalStatementBiz == null || _GlobalStatementBiz.ID == 0)
                    return "";
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).BankBranchCode;
            }
        }
        public string AccountTypeCode
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountTypeCode = value;
            }
            get
            {
                if (_GlobalStatementBiz == null || _GlobalStatementBiz.ID == 0)
                    return "";
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountTypeCode;
            }
        }
        public float flAccountBankNo
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).flAccountBankNo = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).flAccountBankNo;
            }
        }
        public double LoanDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).LoanDiscount = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).LoanDiscount.ToString("0"));
            }
        }
        bool _RefreshBaseSalary;
        public bool RefreshBaseSalary
        {
            set { _RefreshBaseSalary = value; }
            get { return _RefreshBaseSalary; }
        }
        public double BaseSalary
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary = value;
            }
            get
            {

                if (_RefreshBaseSalary)
                {
                    //if (((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary == 0)
                        ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary = _ApplicantBiz.CurrentSalary;
                }
                if (_GlobalStatementBiz == null || _GlobalStatementBiz.ID == 0)
                    ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary = 0;
                if (NotCalcBaseSalary == true)
                    return 0;
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary;
            }
        }
        
        public int PartTimeTotalMinutes
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeTotalMinutes = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeTotalMinutes;

            }
        }
        public Period PartTimeunit
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeUnit = (byte)value;
            }
            get
            {
                return (Period)((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeUnit;

            }
        }
        public double PartTimeValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeValue;
            }
        }
        public double PartTimeRecommendedValue
        {
            get
            {
                double Returned = 0;
                if (_ApplicantBiz.IsPartTime)
                {
                    //double dblRecommendedTime = 0;
                    double dblPeriod = AttendanceStatementCol.RecommendedPartTotalMinutes;
                    PeriodBiz objTemp = new PeriodBiz(Period.Minute, dblPeriod, _GlobalStatementBiz.WeekDayNo,
                        _GlobalStatementBiz.DayHourNo);
                    if (_ApplicantBiz.PartTimeUnit == Period.Hour)
                    {
                        Returned = objTemp.HourNo * _ApplicantBiz.PartTimeUnitValue;

                    }
                    else if (_ApplicantBiz.PartTimeUnit == Period.Day)
                    {
                        Returned = objTemp.DayNo * _ApplicantBiz.PartTimeUnitValue;

                    }
                    else if (_ApplicantBiz.PartTimeUnit == Period.Week)
                    {
                        Returned = objTemp.WeekNo * _ApplicantBiz.PartTimeUnitValue;
                    }
                }
                return Returned;
            }
        }
        public double DetailsValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).DetailsValue = value;
            }
            get
            {
                if (NotCalcBaseSalaryDetails == true)
                    return 0;
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).DetailsValue.ToString("0"));
            }
        }
        public double BonusValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BonusValue = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).BonusValue.ToString());
            }
        }
        public double RewardValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).RewardValue = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).RewardValue.ToString("0"));
            }
        }
        public double AttendanceDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AttendanceDiscount = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).AttendanceDiscount;
            }
        }
        public double PenaltyDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount.ToString("0.00"));
            }
        }
        public double DelayValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).DelayValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).DelayValue;
            }
        }
        public double IncreaseValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IncreaseValue = value;
                CurrentFellowshipFund = 0;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).IncreaseValue.ToString("0"));
            }
        }
        public double BaseSalarySaved
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalarySaved = value;
            }
            get
            {
                //if (NotCalcBaseSalary == true)
                //    return 0;
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalarySaved;
            }
        }
        public double OverDaysBonus
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDaysBonus = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).OverDaysBonus.ToString("0"));
            }

        }
        public double OverDaysCount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDays = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDays;
            }

        }
        public double OverTimeBonus
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeBonus = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeBonus.ToString("0"));
            }
        }
        public double AbsenceCount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceCount = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceCount;
            }

        }
        public double NonCountedDays
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDays = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDays;
            }

        }
        public double DelayDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).DelayDiscount = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).DelayDiscount.ToString("0"));
            }

        }
        public double OverTimeDays
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDays = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDays;
            }

        }
        public double OverTimeValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeValue;
            }

        }
        public double AbsenceDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceDiscount = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceDiscount.ToString("0"));
            }

        }
        public double FurloughDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughDiscount = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughDiscount;
            }

        }
        public double FurloughValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughValue;
            }

        }
        public double VacationDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationDiscount = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationDiscount;
            }

        }
        public double VacationValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationValue;
            }

        }
        public double AbsenceFurloughVacationDiscount
        {            
            get
            {
                return  FurloughDiscount + AbsenceDiscount + VacationDiscount;
            }
        }
        public double AbsenceFurloughVacationCount
        {            
            get
            {
                return FurloughValue + AbsenceCount + VacationValue;
            }
        }
        public double NonCountedDaysDiscount
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDaysDiscount = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDaysDiscount.ToString("0"));
            }

        }
        public double UtilityValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).UtilityValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).UtilityValue;
            }

        }
        public double OldDeserved
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OldDeserved = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).OldDeserved;
            }
        }
        public double TotalDeserved
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).TotalDeserved = value;
            }
            get
            {
                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).TotalDeserved.ToString("0"));
            }
        }
        public bool SentToMail
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).SentToMail = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).SentToMail;
            }
        }
        public CostCenterHRBiz CostCenterBiz
        {
            set
            {
                _CostCenterBiz = value;
            }
            get
            {
                return _CostCenterBiz;
            }
        }
        public double PayBackValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PayBackValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).PayBackValue;
            }
        }
        public double FellowShipPaymentValue
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipPaymentValue = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipPaymentValue;
            }
        }
        public bool IsEndStatement
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement;
            }
        }
        public CostCenterHRBiz MotivationCostCenterBiz
        {
            set
            {
                _MotivationCostCenterBiz = value;
            }
            get
            {
                return _MotivationCostCenterBiz;
            }
        }
        public int MotivationCostCenter
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter;
            }
        }
        public bool IsStop
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IsStop = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).IsStop;
            }
        }
        public bool IsNotHasAttendanceStatement
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IsNotHasAttendanceStatement = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).IsNotHasAttendanceStatement;
            }
        }
        public bool NotCalcBaseSalary
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalary = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalary;
            }
        }
        public bool NotCalcBaseSalaryDetails
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalaryDetails = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalaryDetails;
            }
        }
        public bool NotShowBaseSalary
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NotShowBaseSalary = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NotShowBaseSalary;
            }
        }
        public bool NotShowBaseSalaryDetails
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NotShowBaseSalaryDetails = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NotShowBaseSalaryDetails;
            }
        }
        public bool NotCalcBaseSalaryFellowShip
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalaryFellowShip = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).NotCalcBaseSalaryFellowShip;
            }
        }
        public string Remark
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).Remark = value;
            }
            get
            {
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).Remark;
            }
        }
        public JobNatureTypeBiz JobNatureTypeBiz
        {
            set
            {
                _JobNatureTypeBiz = value;
            }
            get
            {
                return _JobNatureTypeBiz;
            }
        }
        //public override double DiscountValue
        //{
        //    get
        //    {
        //        return ()base.DiscountValue;
        //    }
        //    set
        //    {
        //        base.DiscountValue = value;
        //    }
        //}
     
        public ApplicantWorkerStatementLoanDiscountCol LoanDiscountCol
        {
            set
            {
                _LoanDiscountCol = value;
            }
            get
            {
                if (_LoanDiscountCol == null)
                {
                    _LoanDiscountCol = new ApplicantWorkerStatementLoanDiscountCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerStatementLoanDiscountDb objDb = new ApplicantWorkerStatementLoanDiscountDb();
                        objDb.Statement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {

                            _LoanDiscountCol.Add(new ApplicantWorkerStatementLoanDiscountBiz(objDr));
                        }

                    }
                }
                return _LoanDiscountCol;
            }
        }
        public ApplicantWorkerStatementLoanDiscountCol DeleteLoanDiscountCol
        {
            set
            {
                _DeleteLoanDiscountCol = value;
            }
            get
            {
                if (_DeleteLoanDiscountCol == null)
                {
                    _DeleteLoanDiscountCol = new ApplicantWorkerStatementLoanDiscountCol(true);
                }
                return _DeleteLoanDiscountCol;
            }
        }
       
   
       
        public ApplicantWorkerStatementSalaryDetailsCol SalaryDetailsCol
        {
            set
            {
                _SalaryDetailsCol = value;
            }
            get
            {
                if (_SalaryDetailsCol == null)
                {
                    _SalaryDetailsCol = new ApplicantWorkerStatementSalaryDetailsCol(true);
                    if (ID != 0)
                    {
                       // DataRow[] arrDr = ApplicantWorkerStatementDb.ChacheSalaryDetailsTable.Select("OrginStatement=" + ID);
                        ApplicantWorkerStatementSalaryDetailsDb objDb = new ApplicantWorkerStatementSalaryDetailsDb();
                        objDb.OrginStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerStatementSalaryDetailsBiz objTemp;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new ApplicantWorkerStatementSalaryDetailsBiz(objDr);
                            objTemp.ApplicantWorkerStatementBiz = this;
                            _SalaryDetailsCol.Add(objTemp);
                        }

                        
                        //foreach (DataRow objDr in arrDr)
                        //{
                        //    objTemp = new ApplicantWorkerStatementSalaryDetailsBiz(objDr);
                        //    objTemp.ApplicantWorkerStatementBiz = this;
                        //    _SalaryDetailsCol.Add(objTemp);
                        //}
                    }
                }
                return _SalaryDetailsCol;
            }
        }
        public ApplicantWorkerStatementSubSectorCol SubSectorCol
        {
            set
            {
                _SubSectorCol = value;
            }
            get
            {
                if (_SubSectorCol == null)
                {
                    _SubSectorCol = new ApplicantWorkerStatementSubSectorCol(true);

                    ApplicantWorkerStatementSubSectorBiz objTemp;
                    foreach (ApplicantWorkerCurrentSubSectorBiz objbiz in _ApplicantBiz.CurrentSubSectorCol)
                    {
                        objTemp = new ApplicantWorkerStatementSubSectorBiz(this, objbiz.SubSectorBiz);
                        _SubSectorCol.Add(objTemp);
                    }

                }
                return _SubSectorCol;
            }
        }
        public ApplicantWorkerStatementSubSectorCol CurrentSubSectorCol
        {
            set
            {
                _CurrentSubSectorCol = value;
            }
            get
            {
                if (_CurrentSubSectorCol == null)
                {
                    _CurrentSubSectorCol = new ApplicantWorkerStatementSubSectorCol(ID);                   
                }
                return _CurrentSubSectorCol;
            }
        }
        public ApplicantWorkerAttendanceStatementCol AttendanceStatementCol
        {
            set
            {
                _AttendanceStatementCol = value;
            }
            get
            {
                if (_AttendanceStatementCol == null)
                {
                    _AttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerAttendanceStatementDb objDb =
                            new ApplicantWorkerAttendanceStatementDb();
                        objDb.FinancialStatement = ID;
                        objDb.Applicant = ApplicantBiz.ID;
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerAttendanceStatementBiz objTemp;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new ApplicantWorkerAttendanceStatementBiz(objDr);
                            _AttendanceStatementCol.Add(objTemp);
                        }
                    }
                }
                return _AttendanceStatementCol;
            }
        }
        public ApplicantWorkerAttendanceStatementCol DeletedAttendanceStatementCol
        {
            set
            {
                _DeletedAttendanceStatementCol = value;
            }
            get
            {
                if (_DeletedAttendanceStatementCol == null)
                    _DeletedAttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
                return _DeletedAttendanceStatementCol;

            }

        }
       
        public ApplicantWorkerStatementExchangeCol ExchangeCol
        {
            get
            {
                if (_ExchangeCol == null)
                {
                    _ExchangeCol = new ApplicantWorkerStatementExchangeCol(this);
                }
                return _ExchangeCol;
            }
        }
        
        public ApplicantWorkerStatementBonusCol BonusCol
        {
            set
            {
                _BonusCol = value;
            }
            get
            {
                if (_BonusCol == null)
                {
                    _BonusCol = new ApplicantWorkerStatementBonusCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerStatementBonusDb objDb = new ApplicantWorkerStatementBonusDb();
                        objDb.OriginStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _BonusCol.Add(new ApplicantWorkerStatementBonusBiz(objDr));
                        }
                    }
                }
                return _BonusCol;
            }
        }
      
      
        public ApplicantWorkerStatementBonusCol DeleteBonusCol
        {
            set
            {
                _DeleteBonusCol = value;
            }
            get
            {
                if (_DeleteBonusCol == null)
                {
                    _DeleteBonusCol = new ApplicantWorkerStatementBonusCol(true);
                }
                return _DeleteBonusCol;
            }
        }
        public ApplicantWorkerStatementDiscountCol DiscountCol
        {
            set
            {
                _DiscountCol = value;
            }
            get
            {

                if (_DiscountCol == null)
                {
                    _DiscountCol = new ApplicantWorkerStatementDiscountCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerStatementDiscountDb objDb = new ApplicantWorkerStatementDiscountDb();
                        objDb.OriginStatement = ID;                        
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerStatementDiscountBiz objTemp;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objTemp = new ApplicantWorkerStatementDiscountBiz(objDr);
                            //objTemp.
                            _DiscountCol.Add(objTemp);
                        }
                    }
                }

                return _DiscountCol;
            }
        }
        public ApplicantWorkerStatementDiscountCol DeleteDiscountCol
        {
            set
            {
                _DeleteDiscountCol = value;
            }
            get
            {

                if (_DeleteDiscountCol == null)
                {
                    _DeleteDiscountCol = new ApplicantWorkerStatementDiscountCol(true);
                }

                return _DeleteDiscountCol;
            }
        }

        public ApplicantWorkerPenaltyDiscountCol PenaltyDiscountCol
        {
            set
            {
                _PenaltyDiscountCol = value;
            }

            get
            {
                if (_PenaltyDiscountCol == null)
                {
                    _PenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerPenaltyDiscountDb objDb = new ApplicantWorkerPenaltyDiscountDb();
                        objDb.ApplicantStatusSearch = true;
                        objDb.StatementStatusSearch = 2;
                        objDb.DiscountStatement = ID;
                        objDb.ApplicantIDSearch = ApplicantBiz.ID;
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerPenaltyDiscountBiz objDiscountBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {

                            _PenaltyDiscountCol.Add(new ApplicantWorkerPenaltyDiscountBiz(objDr));
                        }

                    }
                }
                return _PenaltyDiscountCol;
            }
        }
        public ApplicantWorkerBillCol BillCol
        {
            set
            {
                _BillCol = value;
            }

            get
            {
                if (_BillCol == null)
                {
                    _BillCol = new ApplicantWorkerBillCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerBillDb objDb = new ApplicantWorkerBillDb();
                        objDb.BillStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _BillCol.Add(new ApplicantWorkerBillBiz(objDr));
                        }

                    }
                }
                return _BillCol;
            }
        }
        public ApplicantWorkerBonusCol RewardCol
        {
            set
            {
                _RewardCol = value;
            }
            get
            {
                if (_RewardCol == null)
                {
                    _RewardCol = new ApplicantWorkerBonusCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerBonusDb objDb = new ApplicantWorkerBonusDb();
                        objDb.BonusStatement = ID;
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerBonusBiz objBnusBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBnusBiz = new ApplicantWorkerBonusBiz(objDr);
                            objBnusBiz.BonusApplicant = ApplicantBiz;
                            _RewardCol.Add(objBnusBiz);
                        }
                    }
                }
                return _RewardCol;
            }
        }
        public ApplicantWorkerAttendanceDiscountCol AttendanceDiscountCol
        {
            set
            {
                _AttendanceDiscountCol = value;
            }

            get
            {
                if (_AttendanceDiscountCol == null)
                {
                    _AttendanceDiscountCol = new ApplicantWorkerAttendanceDiscountCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerAttendanceDiscountDb objDb = new ApplicantWorkerAttendanceDiscountDb();
                        objDb.Applicant = ID;
                        objDb.FinancialStatementSearch = true;
                        DataTable dtTemp = objDb.Search();
                        ApplicantWorkerAttendanceDiscountBiz objDiscountBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objDiscountBiz = new ApplicantWorkerAttendanceDiscountBiz(objDr);
                            objDiscountBiz.ApplicantWorkerBiz = ApplicantBiz;
                            _AttendanceDiscountCol.Add(new ApplicantWorkerAttendanceDiscountBiz(objDr));
                        }

                    }
                }
                return _AttendanceDiscountCol;
            }
        }
        public ApplicantWorkerPayBackCol PayBackCol
        {
            set
            {
                _PayBackCol = value;
            }
            get
            {
                if (_PayBackCol == null)
                {
                    _PayBackCol = new ApplicantWorkerPayBackCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerPayBackDb objDb = new ApplicantWorkerPayBackDb();
                        objDb.Statement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _PayBackCol.Add(new ApplicantWorkerPayBackBiz(objDr));
                        }
                    }
                }
                return _PayBackCol;
            }
        }
        public ApplicantWorkerFellowShipPaymentCol FellowShipPaymentCol
        {
            set
            {
                _FellowShipPaymentCol = value;
            }
            get
            {
                if (_FellowShipPaymentCol == null)
                {
                    _FellowShipPaymentCol = new ApplicantWorkerFellowShipPaymentCol(true);
                    if (ID != 0)
                    {
                        ApplicantWorkerFellowShipPaymentDb objDb = new ApplicantWorkerFellowShipPaymentDb();
                        objDb.Statement = ID;
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            _FellowShipPaymentCol.Add(new ApplicantWorkerFellowShipPaymentBiz(objDr));
                        }
                    }
                }
                return _FellowShipPaymentCol;
            }
        }
        public double NetDeservedValue
        {
            get
            {
                double Returned = 0;
                double dblBaseSalary = 0;
                double dblDiscount = 0;
                if (GlobalStatementBiz.BaseSalary)
                {
                    dblBaseSalary = BaseSalary;
                    if (NotCalcBaseSalary)
                        dblBaseSalary = 0;
                    //if (BaseSalary == 0)
                    //    BaseSalary = dblBaseSalary;
                }
                //++ GetBonustValue(AttendanceStatementCol.OverTimeCountValue)
                if (IsNotHasAttendanceStatement == false)
                {
                    dblDiscount += GetDiscountValue(PenaltyDiscountCol.TotalValue) +
                   GetDiscountValue(AttendanceStatementCol.NonCountedDaysDiscount) +
                   GetDiscountValue(AttendanceStatementCol.DelayDiscount) +
                   GetDiscountValue(AttendanceStatementCol.AbsenceDayDiscount) +
                   GetDiscountValue(AttendanceStatementCol.FurloughDiscountRecommondedValue) +
                   GetDiscountValue(AttendanceStatementCol.VacationDiscountRecommondedValue) +
                   FellowshipFund + BillCol.TotalValue + LoanDiscountCol.TotalValue;

                    Returned += PartTimeRecommendedValue + dblBaseSalary + BonusCol.TotalValue + IncreaseValue +
                   RewardCol.TotalValue  -
                   DiscountCol.TotalValue - AttendanceDiscountCol.TotalAppliedValue -

                   SystemBase.SysUtility.Approximate(dblDiscount, 1, SystemBase.ApproximateType.Default)


                   + SystemBase.SysUtility.Approximate(GetBonustValue(AttendanceStatementCol.OverDayCountValue), 1, SystemBase.ApproximateType.Default)
                   + PayBackCol.TotalValue + FellowShipPaymentCol.TotalValue;

                    if (NotCalcBaseSalaryDetails == false)
                    {
                        Returned += SalaryDetailsCol.TotalRecommendedValue;
                    }
                }
                else
                {
                    dblDiscount += 
                                       GetDiscountValue(NonCountedDays) +
                                       GetDiscountValue(DelayValue) +
                                       GetDiscountValue(AbsenceCount) +
                                       GetDiscountValue(FurloughValue) +
                                       GetDiscountValue(VacationValue) +
                                       FellowshipFund + BillCol.TotalValue + LoanDiscountCol.TotalValue;
                    if (PenaltyDiscount != 0)
                        dblDiscount += GetDiscountValue(PenaltyDiscount);
                    else if (PenaltyDiscountCol.TotalValue != 0)
                        dblDiscount += GetDiscountValue(PenaltyDiscountCol.TotalValue);

                    Returned += PartTimeRecommendedValue + dblBaseSalary + BonusCol.TotalValue + IncreaseValue +
                   RewardCol.TotalValue -
                   DiscountCol.TotalValue - AttendanceDiscountCol.TotalAppliedValue -

                  
                   SystemBase.SysUtility.Approximate(dblDiscount, 1, SystemBase.ApproximateType.Default)


                   + SystemBase.SysUtility.Approximate(OverDaysBonus, 1, SystemBase.ApproximateType.Default)
                   + PayBackCol.TotalValue + FellowShipPaymentCol.TotalValue;


                    if (NotCalcBaseSalaryDetails == false)
                    {
                        Returned += SalaryDetailsCol.TotalRecommendedValue;
                    }

                }
               

               



                return double.Parse(Returned.ToString("0"));

            }
        }
        public double DeducedNetValue 
        {
            get
            {
                double Returned = 0;
                double dblBaseSalary = 0;
                double dblDiscount = 0;
                if (GlobalStatementBiz.BaseSalary)
                    dblBaseSalary = BaseSalary;
                if (NotCalcBaseSalary)
                    dblBaseSalary = 0;
                double dblPartTime = PartTimeRecommendedValue;

                dblDiscount += FellowshipFund + UtilityValue + NonCountedDaysDiscount + DelayDiscount + AbsenceDiscount + FurloughDiscount + VacationDiscount + LoanDiscount + GetDiscountValue(PenaltyDiscount);
                //dblDiscount += FellowshipFund + UtilityValue + GetDiscountValue(AttendanceStatementCol.NonCountedDaysDiscount) + 
                //    GetDiscountValue(AttendanceStatementCol.DelayDiscount) +
                //    GetDiscountValue(AttendanceStatementCol.AbsenceDayDiscount)
                //    + LoanDiscount + GetDiscountValue(PenaltyDiscount);


                Returned += dblPartTime + dblBaseSalary + BonusValue + IncreaseValue +
                    RewardValue -
                    DiscountValue +
                    SystemBase.SysUtility.Approximate(OverTimeBonus, 1, SystemBase.ApproximateType.Default)
                     + OverDaysBonus - SystemBase.SysUtility.Approximate(dblDiscount, 1, SystemBase.ApproximateType.Default)
                      + PayBackCol.TotalValue + FellowShipPaymentCol.TotalValue;

                if (NotCalcBaseSalaryDetails == false)
                {
                    Returned += SalaryDetailsCol.TotalRecommendedValue;
                }
                return double.Parse(Returned.ToString("0"));

            }
        }
        public double RecommendedNet
        {
            get
            {
                double Returned = DeducedNetValue;
                if (Returned >= 2000)
                {
                    Returned = 0.3;
                }
                else
                {
                    Returned = 0.5;
                }
                if (Returned < 700)
                {
                    Returned = 700;
                }
                if (Returned > 3000)
                {
                    Returned = 3000;
                }
                return Returned;
            }
        }
        public double TotalDeducedValue
        {
            get
            {
                double Returned = 0;
                double dblBaseSalary = 0;
                //if (GlobalStatementBiz.BaseSalary)
                //{
                //    //if (BaseSalarySaved != 0)
                //    //    dblBaseSalary = BaseSalarySaved;
                //    //else
                        dblBaseSalary = BaseSalarySaved;
                //}
                if (NotCalcBaseSalary)
                    dblBaseSalary = 0;

                Returned += dblBaseSalary +  IncreaseValue + BonusValue +
                    RewardValue 
                  + SystemBase.SysUtility.Approximate(OverTimeBonus, 1, SystemBase.ApproximateType.Default) + OverDaysBonus
                   + PayBackCol.TotalValue + FellowShipPaymentCol.TotalValue;

                if (NotCalcBaseSalaryDetails == false)
                {
                    Returned += SalaryDetailsCol.TotalRecommendedValue;
                }

                return double.Parse(Returned.ToString("0"));


            }
        }
        public double FellowshipFundFromDb
        {
            get
            {
                double Returned = 0;
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                    return 0;              
                return ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund + ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFundBonus;
            }
        }
        public double FellowshipFund
        {
            get
            {
                double Returned = 0;
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                    return 0;
                if (_ApplicantBiz.IsFellowShip)
                {
                    //if (FellowShipFundBonus != 0.0)
                    //{
                    //}
                    Returned = ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund + FellowShipFundBonus;
                    //Returned = BaseSalary;//+ SalaryDetailsCol.TotalRecommendedValue;
                    //Returned += IncreaseValue;
                    //Returned = Returned * 1.25 / 100;
                    ////int intTemp = (int)Returned;
                    ////intTemp = intTemp <= Returned ? intTemp : intTemp - 1;
                    ////Returned = (double)intTemp;
                    ////Returned = Math.Round(Returned,
                    //((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = SystemBase.SysUtility.Approximate(Returned, 1, SystemBase.ApproximateType.Default);
                }



                return Returned;
            }
        }
        public double FellowShipFundBonus
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFundBonus = value;
            }
            get
            {
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                    return 0;

                //if (((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFundBonus == 0)
                //{

                //    if (_ApplicantBiz.IsFellowShip)
                //    {
                //        double Returned = 0;

                //        Returned = BaseSalary;//+ SalaryDetailsCol.TotalRecommendedValue;
                //        Returned += IncreaseValue;
                //        Returned = Returned * 1.25 / 100;
                //        //int intTemp = (int)Returned;
                //        //intTemp = intTemp <= Returned ? intTemp : intTemp - 1;
                //        //Returned = (double)intTemp;
                //        //Returned = Math.Round(Returned,
                //        ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = SystemBase.SysUtility.Approximate(Returned, 1, SystemBase.ApproximateType.Default);
                //    }
                //}


                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFundBonus.ToString("0"));
            }
        }
        public double CurrentFellowshipFund1
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = value;
            }
            get
            {
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                    return 0;
                if (NotCalcBaseSalaryFellowShip == true)
                    return 0;
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund == 0)
                {

                    if (_ApplicantBiz.IsFellowShip)
                    {
                        double Returned = 0;

                        if (_GlobalStatementBiz.BaseSalary == false)
                            return 0;

                        if (BaseSalary == 0)
                        {
                            return _ApplicantBiz.FellowShipCredit;
                        }
                        Returned = BaseSalary;//+ SalaryDetailsCol.TotalRecommendedValue;
                        Returned += IncreaseValue;
                        Returned = Returned * 1.25 / 100;
                        //int intTemp = (int)Returned;
                        //intTemp = intTemp <= Returned ? intTemp : intTemp - 1;
                        //Returned = (double)intTemp;
                        //Returned = Math.Round(Returned,
                        ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = SystemBase.SysUtility.Approximate(Returned, 1, SystemBase.ApproximateType.Default);
                    }
                }


                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund.ToString("0"));
            }
        }

        public double CurrentFellowshipFund
        {
            set
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = value;
            }
            get
            {
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                    return 0;
                if (NotCalcBaseSalaryFellowShip == true)
                    return 0;
                if (((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund == 0)
                {

                    if (_ApplicantBiz.IsFellowShip)
                    {
                        double Returned = 0;

                        if (_GlobalStatementBiz.BaseSalary == false)
                            return 0;
                        double dblSalary = BaseSalary == 0 ? 0 : (BaseSalary + IncreaseValue);
                      //  double dblSalary = ApplicantBiz.NativeCurrentSalary == 0 ? 0 : (ApplicantBiz.NativeCurrentSalary + IncreaseValue);
                        Returned = FellowshipRoleCol.GetRecommendedFellowship(FellowshipRoleMotivationOrSalary.Salary, dblSalary
                            , _ApplicantBiz);
                        ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = SystemBase.SysUtility.Approximate(Returned, 1, SystemBase.ApproximateType.Default);
                    }
                }


                return double.Parse(((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund.ToString("0"));
            }
        }
        public double TotalExchangeValue
        {
            get
            {
                double dlValue = 0;
                foreach (ApplicantWorkerStatementExchangeBiz objBiz in ExchangeCol)
                {
                    dlValue += objBiz.ExchangeValue; 
                }
                return dlValue;
            }
        }
        public double RemainingValue
        {
            get
            {
                double dlValue = TotalDeserved - TotalExchangeValue;
                
                return dlValue;
            }
        }
        public ApplicantWorkerStatementBiz BaseStatementBiz
        {
            get
            {
                if (_BaseStatementBiz == null)
                {
                    _BaseStatementBiz = new ApplicantWorkerStatementBiz();
                    if (_GlobalStatementBiz.BaseGlobalStatementBiz.ID != 0)
                    {
                        ApplicantWorkerStatementSalaryDetailsCol objCol = SalaryDetailsCol;
                        _BaseStatementBiz = new ApplicantWorkerStatementBiz(ApplicantBiz, GlobalStatementBiz.BaseGlobalStatementBiz);
                        objCol = _BaseStatementBiz.SalaryDetailsCol;
                    }
                }
                return _BaseStatementBiz;
            }
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
                    _BankBiz = _ApplicantBiz.BankBiz;
                return _BankBiz;
            }
        }
      
        #endregion
        #region Private Methods
        void SaveData()
        {
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).ID == 0)
                ((ApplicantWorkerStatementDb)_OriginStatementDb).Add();
            else
                ((ApplicantWorkerStatementDb)_OriginStatementDb).Edit();
            SaveReward();
            SavePenalityDiscount();
            SaveAttendanceStatement();
            SaveBill();
            SavePayBack();
            SaveFellowShipPayment();
            if (_OriginStatementDb.StatementReviewed)
            if (_ApplicantBiz.StatusID > 1)
                _ApplicantBiz.EditLastFinancialStatement(ID);


        }
        void SaveReward()
        {
            if (_RewardCol == null)
                _RewardCol = new ApplicantWorkerBonusCol(true);
             
            _RewardCol.EditStatement(ApplicantBiz.ID, ID);
            

        }
        void SavePenalityDiscount()
        {
            if (_PenaltyDiscountCol == null)
                _PenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
             
            _PenaltyDiscountCol.EditStatement(ID);
             

        }
        void SaveAttendanceStatement()
        {
            if (_AttendanceStatementCol == null)
                _AttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
            if (_DeletedAttendanceStatementCol == null)
                _DeletedAttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
            

           

        }
        void SaveBill()
        {
            if (_BillCol == null)
                _BillCol = new ApplicantWorkerBillCol(true);
             
            _BillCol.EditStatement(ID);
            
        }
        void SavePayBack()
        {
            if (_PayBackCol == null)
                _PayBackCol = new ApplicantWorkerPayBackCol(true);
            
            _PayBackCol.EditStatement(ID);
             
        }
        void SaveFellowShipPayment()
        {
            if (_FellowShipPaymentCol == null)
                _FellowShipPaymentCol = new ApplicantWorkerFellowShipPaymentCol(true);
          
            _FellowShipPaymentCol.EditStatement(ID);
            
        }
        void GetData()
        {
            ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = 0;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = double.Parse(CurrentFellowshipFund.ToString("0.0"));
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement ==true)
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFund = 0;
            
            ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipFundBonus = FellowShipFundBonus;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).Applicant = _ApplicantBiz.ID;
            
            //((ApplicantWorkerStatementDb)_OriginStatementDb).IncreaseValue = BonusCol.IncreaseValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).GlobalStatment = _GlobalStatementBiz.ID;

            ((ApplicantWorkerStatementDb)_OriginStatementDb).DetailsValue = SalaryDetailsCol.TotalRecommendedValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).AttendanceDiscount = AttendanceDiscountCol.TotalAppliedValue;
            if (_GlobalStatementBiz == null || _GlobalStatementBiz.ID == 0)
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary = 0;
            else
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BaseSalary = _ApplicantBiz.CurrentSalary;

            PartTimeTotalMinutes = int.Parse(AttendanceStatementCol.RecommendedPartTotalMinutes.ToString());
            PartTimeunit = _ApplicantBiz.PartTimeUnit;

            ((ApplicantWorkerStatementDb)_OriginStatementDb).PartTimeValue = PartTimeRecommendedValue;

            ((ApplicantWorkerStatementDb)_OriginStatementDb).BonusValue = BonusCol.TotalValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).DiscountValue = DiscountCol.TotalValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).LoanDiscount = LoanDiscountCol.TotalValue;
            
            // if (PenaltyDiscountCol.TotalValue != 0)
                ((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount = PenaltyDiscountCol.TotalValue;
            //else if (PenaltyDiscount != 0)
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount = PenaltyDiscount;
            //else
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).PenaltyDiscount = 0;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).RewardValue = RewardCol.TotalValue;

            if (IsNotHasAttendanceStatement == false)
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceCount = AttendanceStatementCol.AbsenceDayDiscount;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AbsenceDiscount = GetDiscountValue(AttendanceStatementCol.AbsenceDayDiscount);
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughValue = AttendanceStatementCol.FurloughDiscountRecommondedValue;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).FurloughDiscount = GetDiscountValue(AttendanceStatementCol.FurloughDiscountRecommondedValue);
                
                ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationValue = AttendanceStatementCol.VacationDiscountRecommondedValue;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).VacationDiscount = GetDiscountValue(AttendanceStatementCol.VacationDiscountRecommondedValue);

                ((ApplicantWorkerStatementDb)_OriginStatementDb).DelayValue = AttendanceStatementCol.DelayDiscount;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).DelayDiscount = GetDiscountValue(AttendanceStatementCol.DelayDiscount);
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDays = AttendanceStatementCol.NonCountedDays;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).NonCountedDaysDiscount = GetDiscountValue(AttendanceStatementCol.NonCountedDays);
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeValue = 0;//AttendanceStatementCol.OverTimeCountValue;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverTimeBonus = 0;//AttendanceStatementCol.OverTimeBonus;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDays = AttendanceStatementCol.OverDayCountValue;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).OverDaysBonus = SystemBase.SysUtility.Approximate(GetBonustValue(AttendanceStatementCol.OverDayCountValue), 1, SystemBase.ApproximateType.Default);
            }
            
            
            
            ((ApplicantWorkerStatementDb)_OriginStatementDb).UtilityValue = BillCol.TotalValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).TotalDeserved = double.Parse(NetDeservedValue.ToString("0.0"));
            ((ApplicantWorkerStatementDb)_OriginStatementDb).PayBackValue = PayBackCol.TotalValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).FellowShipPaymentValue = FellowShipPaymentCol.TotalValue;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).SentToMail = false;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).BonusTable = BonusCol.GetTable();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).DiscountTable = DiscountCol.GetTable();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).SalaryDetailsTable = SalaryDetailsCol.GetTable();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).SubSectorTable = SubSectorCol.GetTable();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).LoanDiscountTable = LoanDiscountCol.GetTable();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).DeletedLoanDiscountTable = DeleteLoanDiscountCol.GetTable();
            if (((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo != "")
            {
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankID = BankBiz.ID;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountTypeCode = _ApplicantBiz.AccountTypeCode;
                ((ApplicantWorkerStatementDb)_OriginStatementDb).BankBranchCode = _ApplicantBiz.AccountBankBranchCode;

            }

            //if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement == true)
                //((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo = "";

            //((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo = _ApplicantBiz.AccountBankNo;

            //_StatementDb.
            //_StatementDb.

            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.IDs = _ApplicantBiz.ID.ToString();
            #region 20160506 replace getting costcenter
            //DataTable dtTemp = objDb.GetCostCenter();
            //if (dtTemp.Rows.Count != 0)
            //{
            //    CostCenterBiz objTemp = new CostCenterBiz(dtTemp.Rows[0]);
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter = objTemp.ID;                
            //}
            //else
            //{
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).CostCenter = 0;                
            //}

            //DataTable dtTemp1 = objDb.GetMotivationCostCenter();
            //if (dtTemp1.Rows.Count != 0)
            //{
            //    CostCenterBiz objTemp = new CostCenterBiz(dtTemp1.Rows[0]);                
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter = objTemp.ID;
            //}
            //else
            //{                
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter = 0;
            //}
            #endregion

             
            ((ApplicantWorkerStatementDb)_OriginStatementDb).MotivationCostCenter = _ApplicantBiz.MotivationCostCenterBiz.CostCenterHRBiz.ID;

            ((ApplicantWorkerStatementDb)_OriginStatementDb).JobNature = _ApplicantBiz.CurrentSubSectorBiz.JobNatureTypeBiz.ID;
            
            if (_ApplicantBiz.StatusID > 1)
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement = true;
            else
                ((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement = false;

          //  if (((ApplicantWorkerStatementDb)_OriginStatementDb).IsEndStatement)
            //    ((ApplicantWorkerStatementDb)_OriginStatementDb).AccountBankNo = "";
        }
        double GetPartTimeValue()
        {
            double Returned = 0;
            if (ApplicantBiz.CurrentSalary == 0)
            {
                double dblTotalWorkPeriod = 0;
                PeriodBiz objPeriod = new PeriodBiz(Period.Minute, PartTimeTotalMinutes);
                if (ApplicantBiz.PartTimeUnit == Period.Hour)
                    dblTotalWorkPeriod = objPeriod.HourNo;
                else if (ApplicantBiz.PartTimeUnit == Period.Day)
                    dblTotalWorkPeriod = objPeriod.DayNo;
                else if (ApplicantBiz.PartTimeUnit == Period.Week)
                    dblTotalWorkPeriod = objPeriod.WeekNo;
                Returned = dblTotalWorkPeriod * ApplicantBiz.PartTimeUnitValue;

            }
            return Returned;
        }
        #endregion
        #region Public Methods
        public void Add(bool blPost)
        {
            GetData();
            _OriginStatementDb.StatementReviewed = blPost;
            SaveData();
        }
        public void Edit(bool blPost)
        {
            GetData();
            _OriginStatementDb.StatementReviewed = blPost;
            SaveData();

        }
        public override void Delete()
        {
             ((ApplicantWorkerStatementDb)_OriginStatementDb).GlobalStatment = _GlobalStatementBiz.ID;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).Applicant = _ApplicantBiz.ID;
            ((ApplicantWorkerStatementDb)_OriginStatementDb).Delete();
            ((ApplicantWorkerStatementDb)_OriginStatementDb).ID = 0;
            _ApplicantBiz.EditLastFinancialStatement(0);
            SaveAttendanceStatement();
            SaveReward();
            SavePenalityDiscount();
            SaveBill();
            SavePayBack();
            SaveFellowShipPayment();
           

        }
        public double GetDiscountValue(double dblDaysCount)
        {
            double dblTotalValue = BaseSalary + SalaryDetailsCol.TotalRecommendedValue;
            dblTotalValue += IncreaseValue;
            double Returned = dblDaysCount * dblTotalValue / 30;
            if (Returned == 0 && _GlobalStatementBiz.IsAppendix == true)
            {
                dblTotalValue = _ApplicantBiz.CurrentSalary + 0; //_ApplicantBiz.SalaryDetailsCol.TotalValue;
                dblTotalValue += IncreaseValue;
                Returned = dblDaysCount * dblTotalValue / 30;
            }

            return Returned;
        }
        public double GetBonustValue(double dblDaysCount)
        {
            double dblBaseSalary = NotCalcBaseSalary ? ApplicantBiz.CurrentSalary : BaseSalary;
            double dblTotalValue = dblBaseSalary + SalaryDetailsCol.TotalRecommendedValue;
            dblTotalValue += IncreaseValue;
            double Returned = dblDaysCount * dblTotalValue / 30;

            if (Returned ==0 &&  _GlobalStatementBiz.IsAppendix == true)
            {
                dblTotalValue = _ApplicantBiz.CurrentSalary + 0;//_ApplicantBiz.SalaryDetailsCol.TotalValue;
                dblTotalValue += IncreaseValue;
                 Returned = dblDaysCount * dblTotalValue / 30;
            }
            return Returned;
        }
        public double GetBonusHourValue(double dblHourCount,double dblHourReferenceCount,double dblDayRefrenceCount)
        {

            double dblTotalValue = BaseSalary + SalaryDetailsCol.TotalRecommendedValue;
            dblTotalValue += IncreaseValue;
            double dblDaysCount = 0;
            dblDaysCount = dblHourCount / dblHourReferenceCount;
            double Returned = dblDaysCount * dblTotalValue / dblDayRefrenceCount;

            if (Returned == 0 && _GlobalStatementBiz.IsAppendix == true)
            {
                dblTotalValue = _ApplicantBiz.CurrentSalary + 0;//_ApplicantBiz.SalaryDetailsCol.TotalValue;
                dblTotalValue += IncreaseValue;
                Returned = dblDaysCount * dblTotalValue / dblDayRefrenceCount;
            }
            return Returned;
        }
        public ApplicantWorkerAttendanceStatementCol GetAttendanceStatementCol(byte byRecommenedValueStatus)
        {
            ApplicantWorkerAttendanceStatementCol objCol = new ApplicantWorkerAttendanceStatementCol(true);

            ApplicantWorkerAttendanceStatementDb objDb =
                           new ApplicantWorkerAttendanceStatementDb();
            objDb.FinancialStatement = ID;
            objDb.Applicant = ApplicantBiz.ID;
            objDb.RecommenedValueStatus = byRecommenedValueStatus;
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerAttendanceStatementBiz objTemp;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objTemp = new ApplicantWorkerAttendanceStatementBiz(objDr);
                objCol.Add(objTemp);
            }

            return objCol;
        }
        public double GetIncreaseValue()
        {
            //GlobalStatementApplicantIncreaseValueBiz objBiz = new GlobalStatementApplicantIncreaseValueBiz(_GlobalStatementBiz,_ApplicantBiz);
            return 0;// objBiz.IncreaseValue;
        }
        #endregion
    }
}
