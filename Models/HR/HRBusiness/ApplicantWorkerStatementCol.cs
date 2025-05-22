using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.GL.GLBusiness;
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementCol : CollectionBase
    {
        #region Private Data
        double _TotalDeserved = -1.0;
        //double _TotalFollowShip = -1.0;
        double _TotalBill = -1.0;
        double _TotalBill1 = -1.0;
        double _TotalBill2 = -1.0;
        double _TotalIncreaseValue = -1.0;

        double _TotalLoan = -1.0;
        double _TotalDeservedFromBank = -1.0; // الموظفين لهم رقم حساب
        double _TotalDeservedFromCoffer = -1.0;// موظفين ليس لهم حساب

        double _TotalBillFromBank = -1.0; // الموظفين لهم رقم حساب
        double _TotalBillFromCoffer = -1.0;// موظفين ليس لهم حساب

        double _TotalFellowShip = -1.0;
        double _TotalFellowShipFromBank = -1.0; // الموظفين لهم رقم حساب
        double _TotalFellowShipFromCoffer = -1.0;// موظفين ليس لهم حساب

        int _CountBankNo = 0;

        double _TotalDelayHours = -1.0;
        double _TotalDelayHoursValue = -1.0;
        double _TotalDelayHoursRecommended = -1.0;
        double _TotalDelayHoursRecommendedValue = -1.0;

        double _TotalAbsentDay = -1.0;
        double _TotalAbsentDayValue = -1.0;
        double _TotalAbsentDayRecommended = -1.0;
        double _TotalAbsentDayRecommendedValue = -1.0;

        double _TotalBaseSalary;
        //double _TotalIncreaseValue;
        double _TotalFeedingSalaryDetail;
        double _TotalTelSalaryDetail;
        double _TotalTransferSalaryDetail;
        double _TotalVarioustSalaryDetail;

        ApplicantWorkerCol _ApplicantWorkerCol;
        bool _CheckFromBaseStatement;
        bool _AttendancePenalitySet = false;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementCol(bool blIsEmpty)
        {
 
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {                
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte byAccountBankStatus)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.HasAccountBankNo = (int)byAccountBankStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }

        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork,CostCenterHRCol objCostCenterCol,
            int intSearchStatus,byte byStatusOperation, double dlValueFrom, double dlValueTo,double dlTotalDeservedRatioSearch
            , byte byMotivationStatus, bool blDependOnStartDate, DateTime dtStartDate, int intGlobalStatementPayment,string strApplicantIDs
            , byte byIsStopStatus, JobNatureTypeCol objJobNatureCol, byte byAccountBankStatus, 
            int intSalaryDiscountOrBonusType,int intNonCountedStatus)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.WorkStatus = btOnlyWork;
            objDb.IsStopStatus = byIsStopStatus;
            objDb.JobNatureIDs = objJobNatureCol.IDsStr;
            objDb.DetailEffectSearch = (byte)intSearchStatus;
            objDb.OperationDetailEffectSearch = byStatusOperation;
            if (intSearchStatus == 1)
            {
                objDb.PenaltyCountFormSearch = dlValueFrom;
                objDb.PenaltyCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 2)
            {
                objDb.OverDayCountFromSearch = dlValueFrom;
                objDb.OverDayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 3)
            {
                objDb.AbsenceCountFromSearch = dlValueFrom;
                objDb.AbsenceCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 4)
            {
                objDb.DelayCountFromSearch = dlValueFrom;
                objDb.DelayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 5) // baseSalary
            {
                objDb.BaseSalaryFromSearch = dlValueFrom;
                objDb.BaseSalaryToSearch = dlValueTo;
            }
            else if (intSearchStatus == 6)// Deserved
            {
                objDb.DeservedFromSearch = dlValueFrom;
                objDb.DeservedToSearch = dlValueTo;
            }
            else if (intSearchStatus == 7)// Bouns
            {
                objDb.BonusFromSearch = dlValueFrom;
                objDb.BonusToSearch = dlValueTo;
                objDb.SalaryBonusTypeSearch = intSalaryDiscountOrBonusType;
                
            }
            else if (intSearchStatus == 8)// Discount
            {
                objDb.DiscountFromSearch = dlValueFrom;
                objDb.DiscountToSearch = dlValueTo;
                objDb.SalaryDiscountTypeSearch = intSalaryDiscountOrBonusType;
            }
            else if (intSearchStatus == 9)// Increase
            {
                objDb.IncreaseFromSearch = dlValueFrom;
                objDb.IncreaseToSearch = dlValueTo;
            }
            
            objDb.HasMotivationSearch = byMotivationStatus;
            objDb.IsDependOnStartDateInMotivation = blDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;
            objDb.NonCountedDayStatus = intNonCountedStatus;
            objDb.HasAccountBankNo = (int)byAccountBankStatus;
            if (intGlobalStatementPayment == 0)
            {
                objDb.PaymentStatus = 0;
                objDb.GlobalStatementPayment = 0;
            }
            else if (intGlobalStatementPayment == -1)
            {
                objDb.PaymentStatus = 2;
                objDb.GlobalStatementPayment = 0;
            }
            else
            {
                objDb.PaymentStatus = 1;
                objDb.GlobalStatementPayment = intGlobalStatementPayment;
            }
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerStatementDb.DeservedRatioSearch = dlTotalDeservedRatioSearch;
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
            ApplicantWorkerStatementDb.DeservedRatioSearch = 0;
        }

        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol,
            int intSearchStatus, byte byStatusOperation, double dlValueFrom, double dlValueTo, double dlTotalDeservedRatioSearch
            , byte byMotivationStatus, bool blDependOnStartDate, DateTime dtStartDate, int intGlobalStatementPayment, string strApplicantIDs
            , byte byIsStopStatus, JobNatureTypeCol objJobNatureCol, byte byAccountBankStatus, int intSalaryDiscountOrBonusType,byte byApplicantStatusWork)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            if (objGlobalStatementCol == null)
                objGlobalStatementCol = new GlobalStatementCol(true);

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.WorkStatus = btOnlyWork;
            objDb.IsStopStatus = byIsStopStatus;
            objDb.JobNatureIDs = objJobNatureCol.IDsStr;
            objDb.DetailEffectSearch = (byte)intSearchStatus;
            objDb.OperationDetailEffectSearch = byStatusOperation;
            objDb.ApplicantStatusWorker = byApplicantStatusWork;
            if (intSearchStatus == 1)
            {
                objDb.PenaltyCountFormSearch = dlValueFrom;
                objDb.PenaltyCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 2)
            {
                objDb.OverDayCountFromSearch = dlValueFrom;
                objDb.OverDayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 3)
            {
                objDb.AbsenceCountFromSearch = dlValueFrom;
                objDb.AbsenceCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 4)
            {
                objDb.DelayCountFromSearch = dlValueFrom;
                objDb.DelayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 5) // baseSalary
            {
                objDb.BaseSalaryFromSearch = dlValueFrom;
                objDb.BaseSalaryToSearch = dlValueTo;
            }
            else if (intSearchStatus == 6)// Deserved
            {
                objDb.DeservedFromSearch = dlValueFrom;
                objDb.DeservedToSearch = dlValueTo;
            }
            else if (intSearchStatus == 7)// Bouns
            {
                objDb.BonusFromSearch = dlValueFrom;
                objDb.BonusToSearch = dlValueTo;
                objDb.SalaryBonusTypeSearch = intSalaryDiscountOrBonusType;

            }
            else if (intSearchStatus == 8)// Discount
            {
                objDb.DiscountFromSearch = dlValueFrom;
                objDb.DiscountToSearch = dlValueTo;
                objDb.SalaryDiscountTypeSearch = intSalaryDiscountOrBonusType;
            }
            else if (intSearchStatus == 9)// Increase
            {
                objDb.IncreaseFromSearch = dlValueFrom;
                objDb.IncreaseToSearch = dlValueTo;
            }

            objDb.HasMotivationSearch = byMotivationStatus;
            objDb.IsDependOnStartDateInMotivation = blDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;

            objDb.HasAccountBankNo = (int)byAccountBankStatus;
            if (intGlobalStatementPayment == 0)
            {
                objDb.PaymentStatus = 0;
                objDb.GlobalStatementPayment = 0;
            }
            else if (intGlobalStatementPayment == -1)
            {
                objDb.PaymentStatus = 2;
                objDb.GlobalStatementPayment = 0;
            }
            else
            {
                objDb.PaymentStatus = 1;
                objDb.GlobalStatementPayment = intGlobalStatementPayment;
            }
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerStatementDb.DeservedRatioSearch = dlTotalDeservedRatioSearch;
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
            ApplicantWorkerStatementDb.DeservedRatioSearch = 0;
        }

        public ApplicantWorkerStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, string strApplicantIDs)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, string strApplicantIDs)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementBiz, string strApplicantIDs, byte byRecommenedValueStatus)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementBiz.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.RecommenedValueStatus = byRecommenedValueStatus;
            DataTable dtTemp = objDb.Search();

            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, string strApplicantIDs,string strApplicantExceptionIDs)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.ApplicantExceptionIDs = strApplicantExceptionIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, SectorBiz objSectorBiz, byte btOnlyWork, bool blWithGlobalStatement)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            if (blWithGlobalStatement == true)
                objDb.FinancialStatementStatusSearch = 1;
            else
                objDb.FinancialStatementStatusSearch = 2;
            // objDb
            if (objSectorBiz.ID != 0 && objSectorBiz.FamilyID == objSectorBiz.ID)
                objDb.SectorFamilyID = objSectorBiz.FamilyID;
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;
            objDb.WorkStatus = btOnlyWork;

            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, SectorBiz objSectorBiz, string strApplicantExceptionIDs, byte intWorkStatus)
        {
            if (objSectorBiz == null)
                objSectorBiz = new SectorBiz();
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            if (objSectorBiz.ID != 0 && objSectorBiz.FamilyID == objSectorBiz.ID)
                objDb.SectorFamilyID = objSectorBiz.FamilyID;
            else if (objSectorBiz.ID != 0)
                objDb.SectorIDs = objSectorBiz.IDsStr;

            objDb.ApplicantExceptionIDs = strApplicantExceptionIDs;
            objDb.WorkStatus = intWorkStatus;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork, CostCenterHRCol objCostCenterCol,
            byte byMotivationStatus, bool blDependOnStartDate, DateTime dtStartDate, int intGlobalStatementPayment,
            byte byIsStopStatus, JobNatureTypeCol objJobNatureCol, byte byAccountBankStatus,int intNonCountedStatus)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);            
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;          
            objDb.WorkStatus = btOnlyWork;
            objDb.JobNatureIDs = objJobNatureCol.IDsStr;
            objDb.IsStopStatus = byIsStopStatus;
            objDb.HasMotivationSearch = byMotivationStatus;
            objDb.IsDependOnStartDateInMotivation = blDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;
            //objDb.Applicant = 5545;
            objDb.NonCountedDayStatus = intNonCountedStatus;
            if (intGlobalStatementPayment == 0)
            {
                objDb.PaymentStatus = 0;
                objDb.GlobalStatementPayment = 0;
            }
            else if (intGlobalStatementPayment  == -1)
            {
                objDb.PaymentStatus = 2;
                objDb.GlobalStatementPayment = 0;
            }
            else
            {
                objDb.PaymentStatus = 1;
                objDb.GlobalStatementPayment = intGlobalStatementPayment;
            }
            objDb.HasAccountBankNo = (int)byAccountBankStatus;
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerStatementBiz objTemp;

            foreach (DataRow DR in dtTemp.Rows)
            {
                objTemp = new ApplicantWorkerStatementBiz(DR);
                if (objTemp.ApplicantBiz.ID == 4027)
                { 
                }
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz,byte btOnlyWork,CostCenterHRBiz objCostCenterBiz)
        {
            if (objCostCenterBiz == null)
                objCostCenterBiz = new CostCenterHRBiz();           
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterBiz.ID.ToString();           
            objDb.WorkStatus = btOnlyWork;            
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork, CostCenterHRCol objCostCenterCol)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol,byte byApplicantStatusWorker)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);


            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            objDb.ApplicantStatusWorker = byApplicantStatusWorker;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol, MotivationStatementBiz objMotivationStatementBiz)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);


            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.MotivationStatementIDSearch = objMotivationStatementBiz.ID;
            objDb.WorkStatus = btOnlyWork;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRBiz objCostCenterBiz, MotivationStatementBiz objMotivationStatementBiz)
        {
            if (objCostCenterBiz == null)
                objCostCenterBiz = new CostCenterHRBiz();


            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterBiz.ID.ToString();
            objDb.MotivationStatementIDSearch = objMotivationStatementBiz.ID;
            objDb.MotivationTypeSearch = objMotivationStatementBiz.MotivationTypeBiz.ID;
            objDb.WorkStatus = btOnlyWork;

            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRBiz objCostCenterBiz)
        {
            if (objCostCenterBiz == null)
                objCostCenterBiz = new CostCenterHRBiz();


            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterBiz.ID.ToString();
            objDb.WorkStatus = btOnlyWork;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol,string strApplicantIDs)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);


            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork, CostCenterHRCol objCostCenterCol
            , byte byPaymentStatus, int intGlobalStatementPayment)
        {
            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            objDb.PaymentStatus = byPaymentStatus;
            objDb.GlobalStatementPayment = intGlobalStatementPayment;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork, CostCenterHRBiz objCostCenterBiz
            , byte byPaymentStatus, int intGlobalStatementPayment)
        {
            if (objCostCenterBiz == null)
                objCostCenterBiz = new CostCenterHRBiz();
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.CostCenterIDs = objCostCenterBiz.ID.ToString();
            objDb.WorkStatus = btOnlyWork;
            objDb.PaymentStatus = byPaymentStatus;
            objDb.GlobalStatementPayment = intGlobalStatementPayment;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte btOnlyWork, string strStatementIDs
            , byte byPaymentStatus, int intGlobalStatementPayment)
        {           
            if (objGlobalStatementBiz == null)
                objGlobalStatementBiz = new GlobalStatementBiz();

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.StatementSearchIDs = strStatementIDs;
            objDb.WorkStatus = btOnlyWork;
            objDb.PaymentStatus = byPaymentStatus;
            objDb.GlobalStatementPayment = intGlobalStatementPayment;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, string strApplicantIDs,bool blOrderByBankNo)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.ApplicantIDs = strApplicantIDs;
            DataTable dtTemp = objDb.Search();
            if (blOrderByBankNo == false)
            {
                foreach (DataRow DR in dtTemp.Rows)
                {
                    this.Add(new ApplicantWorkerStatementBiz(DR));
                }
            }
            else
            {
                DataRow[] ArrDR = dtTemp.Select("","BankIntNo");
                foreach (DataRow objDr in ArrDR)
                {
                    this.Add(new ApplicantWorkerStatementBiz(objDr));
                }
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz,byte byAccountBankNo, bool blOrderByBankNo)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.HasAccountBankNo = byAccountBankNo;
            DataTable dtTemp = objDb.Search();
            if (blOrderByBankNo == false)
            {
                foreach (DataRow DR in dtTemp.Rows)
                {
                    this.Add(new ApplicantWorkerStatementBiz(DR));
                }
            }
            else
            {
                DataRow[] ArrDR = dtTemp.Select("", "StatementBankIntNo");
                foreach (DataRow objDr in ArrDR)
                {
                    this.Add(new ApplicantWorkerStatementBiz(objDr));
                }
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte byAccountBankNo, bool blOrderByBankNo, CostCenterHRCol objCostCenterCol)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.HasAccountBankNo = byAccountBankNo;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            DataTable dtTemp = objDb.Search();
            if (blOrderByBankNo == false)
            {
                foreach (DataRow DR in dtTemp.Rows)
                {
                    this.Add(new ApplicantWorkerStatementBiz(DR));
                }
            }
            else
            {
                DataRow[] ArrDR = dtTemp.Select("", "StatementBankIntNo");
                foreach (DataRow objDr in ArrDR)
                {
                    this.Add(new ApplicantWorkerStatementBiz(objDr));
                }
            }
        }
        public ApplicantWorkerStatementCol(GlobalStatementBiz objGlobalStatementBiz, byte byAccountBankNo, bool blOrderByBankNo, CostCenterHRCol objCostCenterCol
            , int intSearchStatus,byte byStatusOperation, double dlValueFrom, double dlValueTo)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatment = objGlobalStatementBiz.ID;
            objDb.HasAccountBankNo = byAccountBankNo;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.DetailEffectSearch = (byte)intSearchStatus;
            objDb.OperationDetailEffectSearch = byStatusOperation;
            if (intSearchStatus == 1)
            {
                objDb.PenaltyCountFormSearch = dlValueFrom;
                objDb.PenaltyCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 2)
            {
                objDb.OverDayCountFromSearch = dlValueFrom;
                objDb.OverDayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 3)
            {
                objDb.AbsenceCountFromSearch = dlValueFrom;
                objDb.AbsenceCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 4)
            {
                objDb.DelayCountFromSearch = dlValueFrom;
                objDb.DelayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 5) // baseSalary
            {
                objDb.BaseSalaryFromSearch = dlValueFrom;
                objDb.BaseSalaryToSearch = dlValueTo;
            }
            else if (intSearchStatus == 6)// Deserved
            {
                objDb.DeservedFromSearch = dlValueFrom;
                objDb.DeservedToSearch = dlValueTo;
            }
            DataTable dtTemp = objDb.Search();
            if (blOrderByBankNo == false)
            {
                foreach (DataRow DR in dtTemp.Rows)
                {
                    this.Add(new ApplicantWorkerStatementBiz(DR));
                }
            }
            else
            {
                DataRow[] ArrDR = dtTemp.Select("", "StatementBankIntNo");
                foreach (DataRow objDr in ArrDR)
                {
                    this.Add(new ApplicantWorkerStatementBiz(objDr));
                }
            }
        }
        public ApplicantWorkerStatementCol(UserBiz objUserBiz, bool blStatusSearch, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.UserIDSearch = objUserBiz.ID;
            objDb.InsDateStatusSearch = blStatusSearch;
            objDb.InsDateFromSearch = dtFrom;
            objDb.InsDateToSearch = dtTo;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow DR in dtTemp.Rows)
            {
                this.Add(new ApplicantWorkerStatementBiz(DR));
            }
        }
        #endregion
        #region Public Properties
        public double TotalDeserved
        {
            set
            {
                _TotalDeserved = value;
            }
            get
            {
               
                    _TotalDeserved = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        //_TotalDeserved += objBiz.DeducedNetValue;
                        _TotalDeserved += objBiz.TotalDeserved; 
                    }
               
                return _TotalDeserved;
            }
        }
        public double TotalLoan
        {
            set
            {
                _TotalLoan = value;
            }
            get
            {

                _TotalLoan = 0;
                foreach (ApplicantWorkerStatementBiz objBiz in this)
                {
                    _TotalLoan += objBiz.LoanDiscount;
                }

                return _TotalLoan;
            }
        }
        public int CountBankNo
        {
            set
            {
                _CountBankNo = value;
            }
            get
            {
                if (_CountBankNo == -1.0)
                {
                    _CountBankNo = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                            _CountBankNo ++;
                    }
                }
                return _CountBankNo;
            }
        }
        public double TotalDeservedFromBank
        {
            set
            {
                _TotalDeservedFromBank = value;
            }
            get
            {
                if (_TotalDeservedFromBank == -1.0)
                {
                    _TotalDeservedFromBank = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                        {
                            //_TotalDeservedFromBank += objBiz.DeducedNetValue;
                            _TotalDeservedFromBank += objBiz.TotalDeserved;
                        }
                    }
                }
                return _TotalDeservedFromBank;
            }
        }
        public double TotalDeservedFromCoffer
        {
            set
            {
                _TotalDeservedFromCoffer = value;
            }
            get
            {
                if (_TotalDeservedFromCoffer == -1.0)
                {
                    _TotalDeservedFromCoffer = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.ID == 188914 || objBiz.ID == 188913)
                            objBiz.ID = objBiz.ID;
                        if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                        {
                            //_TotalDeservedFromCoffer += objBiz.DeducedNetValue;
                            _TotalDeservedFromCoffer += objBiz.TotalDeserved;
                        }
                    }
                }
                return _TotalDeservedFromCoffer;
            }
        }
        //public double TotalFollowShip
        //{
        //    set
        //    {
        //        _TotalFollowShip = value;
        //    }
        //    get
        //    {
        //        if (_TotalFollowShip == -1.0)
        //        {
        //            _TotalFollowShip = 0;
        //            foreach (ApplicantWorkerStatementBiz objBiz in this)
        //            {
        //                _TotalFollowShip += objBiz.FellowshipFundFromDb;
        //            }
        //        }
        //        return _TotalFollowShip;
        //    }
        //}
        
        public double TotalBill
        {
            set
            {
                _TotalBill = value;
            }
            get
            {
                if (_TotalBill == -1.0)
                {
                    _TotalBill = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        
                        _TotalBill += objBiz.UtilityValue;
                    }
                }
                return SysUtility.Approximate(_TotalBill, 1, ApproximateType.Default);
            }
        }
        public double TotalBill1
        {
            set
            {
                _TotalBill1 = value;
            }
            get
            {
                if (_TotalBill1 == -1.0)
                {
                    _TotalBill1 = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        foreach (ApplicantWorkerBillBiz objBillBiz in objBiz.BillCol)
                        {
                           
                                _TotalBill1 += objBillBiz.BillValue;
                        }                     
                    }
                }
                return SysUtility.Approximate(_TotalBill1, 1, ApproximateType.Default);
            }
        }
        public double TotalBill2
        {
            set
            {
                _TotalBill2 = value;
            }
            get
            {
                if (_TotalBill2 == -1.0)
                {
                    _TotalBill2 = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        foreach (ApplicantWorkerBillBiz objBillBiz in objBiz.BillCol)
                        {
                            
                                _TotalBill2 += 0;
                        }

                    }
                }
                return SysUtility.Approximate(_TotalBill2, 1,ApproximateType.Default);
            }
        }
        
        public double TotalIncreaseValue
        {
            set
            {
                _TotalIncreaseValue = value;
            }
            get
            {
                if (_TotalIncreaseValue == -1.0)
                {
                    _TotalIncreaseValue = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalIncreaseValue += objBiz.IncreaseValue;
                    }
                }
                return _TotalIncreaseValue;
            }
        }
        public string ApplicantIDs
        {
            get
            {
                string strApplicantIDs = "";
                foreach (ApplicantWorkerStatementBiz objBiz in this)
                {
                    if (strApplicantIDs != "")
                        strApplicantIDs = strApplicantIDs + ",";
                    strApplicantIDs = strApplicantIDs + objBiz.ApplicantBiz.ID.ToString();
                }
                return strApplicantIDs;
            }
        }
        public string IDs
        {
            get
            {
                string strIDs = "";
                foreach (ApplicantWorkerStatementBiz objBiz in this)
                {
                    if (strIDs != "")
                        strIDs = strIDs + ",";
                    strIDs = strIDs + objBiz.ID.ToString();
                }
                return strIDs;
            }
        }
        public double TotalFellowShip
        {
            set
            {
                _TotalFellowShip = value;
            }
            get
            {
                if (_TotalFellowShip == -1.0)
                {
                    _TotalFellowShip = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {                        
                            _TotalFellowShip += objBiz.FellowshipFundFromDb;
                    }
                }
                return _TotalFellowShip;
            }
        }
        public double TotalFellowShipFromBank
        {
            set
            {
                _TotalFellowShipFromBank = value;
            }
            get
            {
                if (_TotalFellowShipFromBank == -1.0)
                {
                    _TotalFellowShipFromBank = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                        _TotalFellowShipFromBank += objBiz.FellowshipFund;
                    }
                }
                return _TotalFellowShipFromBank;
            }
        }
        public double TotalFellowShipFromCoffer
        {
            set
            {
                _TotalFellowShipFromCoffer = value;
            }
            get
            {
                if (_TotalFellowShipFromCoffer == -1.0)
                {
                    _TotalFellowShipFromCoffer = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                        _TotalFellowShipFromCoffer += objBiz.FellowshipFund;
                    }
                }
                return _TotalFellowShipFromCoffer;
            }
        }
        public double TotalBillFromBank
        {
            set
            {
                _TotalBillFromBank = value;
            }
            get
            {
                if (_TotalBillFromBank == -1.0)
                {
                    _TotalBillFromBank = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                            _TotalBillFromBank += objBiz.UtilityValue;
                    }
                }
                return _TotalBillFromBank;
            }
        }
        public double TotalBillFromCoffer
        {
            set
            {
                _TotalBillFromCoffer = value;
            }
            get
            {
                if (_TotalBillFromCoffer == -1.0)
                {
                    _TotalBillFromCoffer = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        if (objBiz.AccountBankNo == null || objBiz.AccountBankNo == "")
                            _TotalBillFromCoffer += objBiz.UtilityValue;
                    }
                }
                return _TotalBillFromCoffer;
            }
        }
        public double TotalDelayHours
        {
            set
            {
                _TotalDelayHours = value;
            }
            get
            {
                if (_TotalDelayHours == -1.0)
                {
                    _TotalDelayHours = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalDelayHours += objBiz.AttendanceStatementCol.DelayCount;
                    }
                }
                return _TotalDelayHours;
            }
        }
        public double TotalDelayHoursValue
        {
            set
            {
                _TotalDelayHoursValue = value;
            }
            get
            {
                if (_TotalDelayHoursValue == -1.0)
                {
                    _TotalDelayHoursValue = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalDelayHoursValue += objBiz.GetDiscountValue((objBiz.AttendanceStatementCol.DelayCount / (60 * 24)));
                    }
                }
                return _TotalDelayHoursValue;
            }
        }
        public double TotalDelayHoursRecommended
        {
            set
            {
                _TotalDelayHoursRecommended = value;
            }
            get
            {
                if (_TotalDelayHoursRecommended == -1.0)
                {
                    _TotalDelayHoursRecommended = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalDelayHoursRecommended += objBiz.DelayValue;
                    }
                }
                return _TotalDelayHoursRecommended;
            }
        }
        public double TotalDelayHoursRecommendedValue
        {
            set
            {
                _TotalDelayHoursRecommendedValue = value;
            }
            get
            {
                if (_TotalDelayHoursRecommendedValue == -1.0)
                {
                    _TotalDelayHoursRecommendedValue = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalDelayHoursRecommendedValue += objBiz.DelayDiscount;
                    }
                }
                return _TotalDelayHoursRecommendedValue;
            }
        }
        public double TotalAbsentDay
        {
            set
            {
                _TotalAbsentDay = value;
            }
            get
            {
                if (_TotalAbsentDay == -1.0)
                {
                    _TotalAbsentDay = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalAbsentDay += objBiz.AttendanceStatementCol.AbsenceDayCount;
                    }
                }
                return _TotalAbsentDay;
            }
        }
        public double TotalAbsentDayValue
        {
            set
            {
                _TotalAbsentDayValue = value;
            }
            get
            {
                if (_TotalAbsentDayValue == -1.0)
                {
                    _TotalAbsentDayValue = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalAbsentDayValue += objBiz.GetDiscountValue(objBiz.AttendanceStatementCol.AbsenceDayCount);
                    }
                }
                return _TotalAbsentDayValue;
            }
        }
        public double TotalAbsentDayRecommended
        {
            set
            {
                _TotalAbsentDayRecommended = value;
            }
            get
            {
                if (_TotalAbsentDayRecommended == -1.0)
                {
                    _TotalAbsentDayRecommended = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalAbsentDayRecommended += objBiz.AbsenceCount;
                    }
                }
                return _TotalAbsentDayRecommended;
            }
        }
        public double TotalAbsentDayRecommendedValue
        {
            set
            {
                _TotalAbsentDayRecommendedValue = value;
            }
            get
            {
                if (_TotalAbsentDayRecommendedValue == -1.0)
                {
                    _TotalAbsentDayRecommendedValue = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalAbsentDayRecommendedValue += objBiz.AbsenceDiscount;
                    }
                }
                return _TotalAbsentDayRecommendedValue;
            }
        }
        public double TotalBaseSalary
        {
            set
            {
                _TotalBaseSalary = value;
            }
            get
            {
                if (_TotalBaseSalary == -1.0)
                {
                    _TotalBaseSalary = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalBaseSalary += objBiz.BaseSalarySaved;
                    }
                }
                return _TotalBaseSalary;
            }
        }
        public double TotalFeedingSalaryDetail
        {
            set
            {
                _TotalFeedingSalaryDetail = value;
            }
            get
            {
                if (_TotalFeedingSalaryDetail == -1.0)
                {
                    _TotalFeedingSalaryDetail = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalFeedingSalaryDetail += objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5);
                    }
                }
                return _TotalFeedingSalaryDetail;
            }
        }
        public double TotalTelSalaryDetail
        {
            set
            {
                _TotalTelSalaryDetail = value;
            }
            get
            {
                if (_TotalTelSalaryDetail == -1.0)
                {
                    _TotalTelSalaryDetail = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalTelSalaryDetail += objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3);
                    }
                }
                return _TotalTelSalaryDetail;
            }
        }
        public double TotalTransferSalaryDetail
        {
            set
            {
                _TotalTransferSalaryDetail = value;
            }
            get
            {
                if (_TotalTransferSalaryDetail == -1.0)
                {
                    _TotalTransferSalaryDetail = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _TotalTransferSalaryDetail += objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2);
                    }
                }
                return _TotalTransferSalaryDetail;
            }
        }
        public double TotalVarioustSalaryDetail
        {
            set
            {
                _TotalVarioustSalaryDetail = value;
            }
            get
            {
                if (_TotalVarioustSalaryDetail == -1.0)
                {
                    _TotalVarioustSalaryDetail = 0;
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        double dlSum = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5)+
                            objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3)+
                            objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2);
                        _TotalVarioustSalaryDetail += objBiz.SalaryDetailsCol.TotalRecommendedValue - dlSum;
                    }
                }
                return _TotalVarioustSalaryDetail;
            }
        }
        public ApplicantWorkerCol ApplicantWorkerCol
        {
            get
            {
                if (_ApplicantWorkerCol == null)
                {
                    _ApplicantWorkerCol = new ApplicantWorkerCol();
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _ApplicantWorkerCol.Add(objBiz.ApplicantBiz);
                    }
                }
                return _ApplicantWorkerCol;
            }
        }
        public bool CheckFromBaseStatement
        {
            set
            {
                _CheckFromBaseStatement = value;
            }
            get
            {
                return _CheckFromBaseStatement;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerStatementBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerStatementBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ApplicantWorkerStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public ApplicantWorkerStatementCol GetStatementByName(string strApplicantName)
        {
            ApplicantWorkerStatementCol Returned = new ApplicantWorkerStatementCol(true);
            bool blIsFound = false;

            string[] arrStr = strApplicantName.Split("%".ToCharArray());
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
              
                if (objBiz.ApplicantBiz == null )
                    continue;
                blIsFound = true;
                foreach (string strTemp in arrStr)
                {

                    if (SysUtility.ReplaceStringComp(objBiz.ApplicantBiz.Name).
                        IndexOf(strTemp) == -1 && objBiz.ApplicantBiz.Code.
                        IndexOf(strTemp) == -1)
                    {
                        blIsFound = false;
                        break;
                    }
                }
                if(blIsFound)
                Returned.Add(objBiz);
            }
            return Returned;

        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        #endregion
        #region Public Methods
        public void InitTotal()
        {
            _TotalDeserved = -1.0;
            //_TotalFollowShip = -1.0;
            _TotalBill = -1.0;
            _TotalBill1 = -1.0;
            _TotalBill2 = -1.0;
            _TotalIncreaseValue = -1.0;
            _TotalLoan = -1.0;

            _TotalDeservedFromBank = -1.0;
            _TotalDeservedFromCoffer = -1.0;
            _TotalBillFromBank = -1.0;
            _TotalBillFromCoffer = -1.0;
            _TotalFellowShip = -1.0;
            _TotalFellowShipFromBank = -1.0;
            _TotalFellowShipFromCoffer = -1.0;

            _TotalDelayHours = -1.0;
            _TotalDelayHoursValue = -1.0;
            _TotalDelayHoursRecommended = -1.0;
            _TotalDelayHoursRecommendedValue = -1.0;

            _TotalAbsentDay = -1.0;
            _TotalAbsentDayValue = -1.0;
            _TotalAbsentDayRecommended = -1.0;
            _TotalAbsentDayRecommendedValue = -1.0;

            _TotalBaseSalary = -1.0;
            _TotalIncreaseValue = -1.0;
            _TotalFeedingSalaryDetail = -1.0;
            _TotalTelSalaryDetail = -1.0;
            _TotalTransferSalaryDetail = -1.0;
            _TotalVarioustSalaryDetail = -1.0;

        }
        public void GetTotal()
        {
            _TotalDeserved = 0.0;
            //_TotalFollowShip = 0.0;
            _TotalBill = 0.0;
            //_TotalBill1 = 0.0;
            //_TotalBill2 = 0.0;
            _TotalIncreaseValue = 0.0;
            _TotalDeservedFromBank = 0.0;
            _TotalDeservedFromCoffer = 0.0;
            _TotalBillFromBank = 0.0;
            _TotalBillFromCoffer = 0.0;
            _TotalFellowShip = 0;
            _TotalFellowShipFromBank = 0.0;
            _TotalFellowShipFromCoffer = 0.0;
            _TotalLoan = 0.0;
            _CountBankNo = 0;

            _TotalDelayHours = 0.0;
            _TotalDelayHoursValue = 0.0;
            _TotalDelayHoursRecommended = 0.0;
            _TotalDelayHoursRecommendedValue = 0.0;

            _TotalAbsentDay = 0.0;
            _TotalAbsentDayValue = 0.0;
            _TotalAbsentDayRecommended = 0.0;
            _TotalAbsentDayRecommendedValue = 0.0;

            _TotalBaseSalary = 0.0;
            _TotalIncreaseValue = 0.0;
            _TotalFeedingSalaryDetail = 0.0;
            _TotalTelSalaryDetail = 0.0;
            _TotalTransferSalaryDetail = 0.0;
            _TotalVarioustSalaryDetail = 0.0;

            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                //_TotalDeserved += objBiz.DeducedNetValue;
                _TotalDeserved += objBiz.TotalDeserved;
                _TotalLoan += objBiz.LoanDiscount;
                _TotalFellowShip += objBiz.FellowshipFundFromDb;
                _TotalBill += objBiz.UtilityValue;
               // _TotalIncreaseValue += objBiz.IncreaseValue;


                if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                {
                    //_TotalDeservedFromBank += objBiz.DeducedNetValue;
                    _TotalDeservedFromBank += objBiz.TotalDeserved;
                    _CountBankNo++;
                }
                else
                {
                    //_TotalDeservedFromCoffer += objBiz.DeducedNetValue;
                    _TotalDeservedFromCoffer += objBiz.TotalDeserved;
                }

                string strName = objBiz.ApplicantBiz.Name;
                if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                    _TotalBillFromBank += objBiz.UtilityValue;
                else
                    _TotalBillFromCoffer += objBiz.UtilityValue;

                //_TotalFellowShip += objBiz.FellowshipFundFromDb;
                if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                    _TotalFellowShipFromBank += objBiz.FellowshipFundFromDb;
                else
                    _TotalFellowShipFromCoffer += objBiz.FellowshipFundFromDb;


                //_TotalDelayHours += objBiz.AttendanceStatementCol.DelayCount;
                //_TotalDelayHoursValue += objBiz.GetDiscountValue((objBiz.AttendanceStatementCol.DelayCount / (60 * 24)));
                _TotalDelayHoursRecommended += objBiz.DelayValue;
                _TotalDelayHoursRecommendedValue += objBiz.DelayDiscount;

                //_TotalAbsentDay += objBiz.AttendanceStatementCol.AbsenceDayCount;
                //_TotalAbsentDayValue += objBiz.GetDiscountValue(objBiz.AttendanceStatementCol.AbsenceDayCount);
                _TotalAbsentDayRecommended += objBiz.AbsenceCount;
                _TotalAbsentDayRecommendedValue += objBiz.AbsenceDiscount;


                if (!_CheckFromBaseStatement)
                {
                    _TotalBaseSalary += objBiz.BaseSalarySaved;
                    _TotalIncreaseValue += objBiz.IncreaseValue;
                    double dlSum = 0;
                    double dlValue = 0;
                    dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5);
                    _TotalFeedingSalaryDetail += dlValue;
                    dlSum += dlValue;
                    dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3);
                    _TotalTelSalaryDetail += dlValue;
                    dlSum += dlValue;
                    dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2);
                    _TotalTransferSalaryDetail += dlValue;
                    dlSum += dlValue;

                    _TotalVarioustSalaryDetail += objBiz.SalaryDetailsCol.TotalRecommendedValue - dlSum;
                }
                else
                {
                    if (objBiz.BaseStatementBiz.ID == 0)
                    {
                        _TotalBaseSalary += objBiz.BaseSalarySaved;

                        _TotalIncreaseValue += objBiz.IncreaseValue;
                        double dlSum = 0;
                        double dlValue = 0;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5);
                        _TotalFeedingSalaryDetail += dlValue;
                        dlSum += dlValue;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3);
                        _TotalTelSalaryDetail += dlValue;
                        dlSum += dlValue;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2);
                        _TotalTransferSalaryDetail += dlValue;
                        dlSum += dlValue;

                        _TotalVarioustSalaryDetail += objBiz.SalaryDetailsCol.TotalRecommendedValue - dlSum;
                    }
                    else
                    {
                        if (objBiz.BaseStatementBiz.BaseSalarySaved + objBiz.BaseStatementBiz.IncreaseValue != objBiz.BaseSalarySaved + objBiz.IncreaseValue)
                        {
                            if (objBiz.BaseStatementBiz.BaseSalarySaved != objBiz.BaseSalarySaved )
                            {
                                _TotalBaseSalary += objBiz.BaseSalarySaved;
                            }
                            if (objBiz.BaseStatementBiz.IncreaseValue != objBiz.IncreaseValue)
                            {
                                _TotalIncreaseValue += objBiz.IncreaseValue;
                            }
                        }
                       
                        double dlSum = 0;
                        double dlValue = 0;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5);
                        if (objBiz.BaseStatementBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(5) != dlValue)
                        {
                            _TotalFeedingSalaryDetail += dlValue;                           
                        }
                        dlSum += dlValue;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3);
                        if (objBiz.BaseStatementBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(3) != dlValue)
                        {
                            _TotalTelSalaryDetail += dlValue;                            
                        }
                        dlSum += dlValue;
                        dlValue = objBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2);
                        if (objBiz.BaseStatementBiz.SalaryDetailsCol.GetSalaryDetailsRecommendedValue(2) != dlValue)
                        {
                            _TotalTransferSalaryDetail += dlValue;                            
                        }
                        dlSum += dlValue;

                        double dlReminder = objBiz.SalaryDetailsCol.TotalRecommendedValue - dlSum;
                        if (objBiz.BaseStatementBiz.SalaryDetailsCol.TotalRecommendedValue != dlReminder)
                        {
                            _TotalVarioustSalaryDetail += dlReminder;
                        }

                    }
                }

            }


        }
        public CostCenterHRCol GetCostCenterCol()
        {
            CostCenterHRCol Returned = new CostCenterHRCol(true);
            CostCenterHRBiz objEndBiz = new CostCenterHRBiz();
            objEndBiz.NameA = "انهاء خدمة";
            objEndBiz.ID = -1;
            objEndBiz.OrderVal = 1000;
            ApplicantWorkerDb objDb = new ApplicantWorkerDb();
            objDb.IDs = ApplicantIDs;
            DataTable dtTemp = objDb.GetCostCenter();
            DataRow[] arrDr;
            Hashtable hsTemp = new Hashtable();
            CostCenterHRBiz objBiz;

            foreach (ApplicantWorkerStatementBiz objStatementBiz in this)
            {
                if (objStatementBiz.IsEndStatement)
                {
                    objEndBiz.StatementCol.Add(objStatementBiz);
                    continue;
                }
                if (objStatementBiz.CostCenterBiz.ID == 0)
                {
                    arrDr = dtTemp.Select("Applicant=" + objStatementBiz.ApplicantBiz.ID);
                    foreach (DataRow objDr in arrDr)
                    {
                        objBiz = new CostCenterHRBiz(objDr);

                        if (hsTemp[objBiz.ID.ToString()] == null)
                        {
                            hsTemp.Add(objBiz.ID.ToString(), objBiz);
                            Returned.Add(objBiz);
                        }
                        else
                        {
                            objBiz = (CostCenterHRBiz)hsTemp[objBiz.ID.ToString()];

                        }
                        objBiz.StatementCol.Add(objStatementBiz);
                    }
                }
                else
                {
                    objBiz = (CostCenterHRBiz)objStatementBiz.CostCenterBiz;

                    if (hsTemp[objBiz.ID.ToString()] == null)
                    {
                        hsTemp.Add(objBiz.ID.ToString(), objBiz);
                        Returned.Add(objBiz);
                    }
                    else
                    {
                        objBiz = (CostCenterHRBiz)hsTemp[objBiz.ID.ToString()];

                    }
                    objBiz.StatementCol.Add(objStatementBiz);
                }


            }
            Returned.Add(objEndBiz);
            return Returned;
        }
        public ApplicantWorkerStatementCol GetApplicantWorkerStatementOrderByJob()
        {
            ApplicantWorkerStatementCol objCol = new ApplicantWorkerStatementCol(true);
            DataTable dtTemp = new DataTable("");
            dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("StatementID"),new DataColumn("ApplicantID"), new DataColumn("ApplicantName")
            ,new DataColumn("JobNature"),new DataColumn("OrderVal",typeof(int))});
            DataRow drTemp;
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                drTemp = dtTemp.NewRow();
                drTemp["StatementID"] = objBiz.ID;
                drTemp["ApplicantID"] = objBiz.ApplicantBiz.ID;
                drTemp["ApplicantName"] = objBiz.ApplicantBiz.Name;
                drTemp["JobNature"] = objBiz.ApplicantBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
                drTemp["OrderVal"] = objBiz.ApplicantBiz.CurrentSubSectorBiz.JobNatureTypeBiz.JobCategory.OrderValue;

                dtTemp.Rows.Add(drTemp);
            }

            DataRow[] arrRows = dtTemp.Select("", "OrderVal,JobNature,ApplicantName");

            foreach (DataRow objDr in arrRows)
            {
                objCol.Add(this[this.GetIndex(int.Parse(objDr["StatementID"].ToString()))]);
            }
            return objCol;
        }
        public CostCenterHRBiz GetCostCenterHRBiz(int intApplicantID)
        {
            CostCenterHRBiz Returned = new CostCenterHRBiz();
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantBiz.ID == intApplicantID)
                {
                    Returned = objBiz.CostCenterBiz;
                    break;
                }
            }
            return Returned;
        }
        public ApplicantWorkerCol GetApplicantWorkerColWithCondation(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol,
            int intSearchStatus, byte byStatusOperation, double dlValueFrom, double dlValueTo, double dlTotalDeservedRatioSearch
            , byte byMotivationStatus, bool blDependOnStartDate, DateTime dtStartDate, int intGlobalStatementPayment, string strApplicantIDs
            , byte byIsStopStatus, JobNatureTypeCol objJobNatureCol, byte byAccountBankStatus, int intSalaryDiscountOrBonusType)
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();

            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            if (objGlobalStatementCol == null)
                objGlobalStatementCol = new GlobalStatementCol(true);

            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.ApplicantIDs = strApplicantIDs;
            objDb.WorkStatus = btOnlyWork;
            objDb.IsStopStatus = byIsStopStatus;
            objDb.JobNatureIDs = objJobNatureCol.IDsStr;
            objDb.DetailEffectSearch = (byte)intSearchStatus;
            objDb.OperationDetailEffectSearch = byStatusOperation;
            if (intSearchStatus == 1)
            {
                objDb.PenaltyCountFormSearch = dlValueFrom;
                objDb.PenaltyCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 2)
            {
                objDb.OverDayCountFromSearch = dlValueFrom;
                objDb.OverDayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 3)
            {
                objDb.AbsenceCountFromSearch = dlValueFrom;
                objDb.AbsenceCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 4)
            {
                objDb.DelayCountFromSearch = dlValueFrom;
                objDb.DelayCountToSearch = dlValueTo;
            }
            else if (intSearchStatus == 5) // baseSalary
            {
                objDb.BaseSalaryFromSearch = dlValueFrom;
                objDb.BaseSalaryToSearch = dlValueTo;
            }
            else if (intSearchStatus == 6)// Deserved
            {
                objDb.DeservedFromSearch = dlValueFrom;
                objDb.DeservedToSearch = dlValueTo;
            }
            else if (intSearchStatus == 7)// Bouns
            {
                objDb.BonusFromSearch = dlValueFrom;
                objDb.BonusToSearch = dlValueTo;
                objDb.SalaryBonusTypeSearch = intSalaryDiscountOrBonusType;

            }
            else if (intSearchStatus == 8)// Discount
            {
                objDb.DiscountFromSearch = dlValueFrom;
                objDb.DiscountToSearch = dlValueTo;
                objDb.SalaryDiscountTypeSearch = intSalaryDiscountOrBonusType;
            }
            else if (intSearchStatus == 9)// Increase
            {
                objDb.IncreaseFromSearch = dlValueFrom;
                objDb.IncreaseToSearch = dlValueTo;
            }

            objDb.HasMotivationSearch = byMotivationStatus;
            objDb.IsDependOnStartDateInMotivation = blDependOnStartDate;
            objDb.StartDateInMotivation = dtStartDate;

            objDb.HasAccountBankNo = (int)byAccountBankStatus;
            if (intGlobalStatementPayment == 0)
            {
                objDb.PaymentStatus = 0;
                objDb.GlobalStatementPayment = 0;
            }
            else if (intGlobalStatementPayment == -1)
            {
                objDb.PaymentStatus = 2;
                objDb.GlobalStatementPayment = 0;
            }
            else
            {
                objDb.PaymentStatus = 1;
                objDb.GlobalStatementPayment = intGlobalStatementPayment;
            }
            DataTable dtTemp = objDb.GetApplicantWithEffects();
            string strTempIds = "";
            foreach (DataRow  objDr in dtTemp.Rows)
            {
                if (strTempIds == "")
                    strTempIds = objDr["Applicant"].ToString();
                else
                    strTempIds +=","+ objDr["Applicant"].ToString();
            }
            if(strTempIds!="")
            objCol = new ApplicantWorkerCol("", strTempIds);
            return objCol;
        }

        public ApplicantWorkerStatementCol GetApplicantWorkerStatementColBetweenTwoStatement(GlobalStatementBiz objGlobalStatementBiz1, GlobalStatementBiz objGlobalStatementBiz2)
        {
            ApplicantWorkerStatementCol objCol = new ApplicantWorkerStatementCol(true);
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            DataTable dtTemp = objDb.GetApplicantWorkerStatementBeteenTwoStatement(objGlobalStatementBiz1.ID, objGlobalStatementBiz2.ID);
            foreach (DataRow DR in dtTemp.Rows)
            {
                objCol.Add(new ApplicantWorkerStatementBiz(DR));
            }
            return objCol;
        }

        public static DataTable GetApplicantWorkerStatementFellowSipDiscount(GlobalStatementCol objGlobalStatementCol, byte btOnlyWork, CostCenterHRCol objCostCenterCol, string strApplicantIDs)
        {

            if (objCostCenterCol == null)
                objCostCenterCol = new CostCenterHRCol(true);
            DataTable dtTemp;
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.GlobalStatementIDs = objGlobalStatementCol.IDsStr;
            objDb.CostCenterIDs = objCostCenterCol.IDsStr;
            objDb.WorkStatus = btOnlyWork;
            objDb.ApplicantIDs = strApplicantIDs;
            return dtTemp = objDb.GetApplicantWorkerStatementFellowShipDiscount();
        }
        #endregion

        ApplicantWorkerCol _ApplicantWorkerOrderByJobCol;
        public ApplicantWorkerCol ApplicantWorkerOrderByJobCol
        {
            get
            {
                if (_ApplicantWorkerOrderByJobCol == null)
                {
                    _ApplicantWorkerOrderByJobCol = new ApplicantWorkerCol(true);
                    foreach (ApplicantWorkerStatementBiz objBiz in this)
                    {
                        _ApplicantWorkerOrderByJobCol.Add(objBiz.ApplicantBiz);
                    }
                    _ApplicantWorkerOrderByJobCol = _ApplicantWorkerOrderByJobCol.GetApplicantWorkerOrderByJob();
                }
                return _ApplicantWorkerOrderByJobCol;
            }
        }
        public BankHRCol BankCol
        {
            get
            {
                BankHRCol Returned = new BankHRCol();
                BankHRBiz objBankBiz;
                Hashtable hsTemp = new Hashtable();
                foreach (ApplicantWorkerStatementBiz objBiz in this)
                {
                    if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                    {
                        if (hsTemp[objBiz.BankBiz.ID.ToString()] != null)
                        {
                            objBankBiz = (BankHRBiz)hsTemp[objBiz.BankBiz.ID.ToString()];


                        }
                        else
                        {
                            objBankBiz = new BankHRBiz();
                            objBankBiz.BankBiz = objBiz.BankBiz;
                            Returned.Add(objBankBiz);
                            hsTemp.Add(objBankBiz.BankBiz.ID.ToString(), objBankBiz);

                        }
                        objBankBiz.StatementCol.Add(objBiz);

                    }
                }
                return Returned;
            }
        }

        public ApplicantWorkerStatementCol GetOrderApplicantWorkerStatementCol()
        {
            ApplicantWorkerStatementCol objCol = new ApplicantWorkerStatementCol(true);
            foreach (ApplicantWorkerBiz objApplicantBiz in ApplicantWorkerOrderByJobCol)
            {
                foreach (ApplicantWorkerStatementBiz objStatementBiz in this)
                {
                    if (objApplicantBiz.ID == objStatementBiz.ApplicantBiz.ID)
                    {
                        if (objStatementBiz.ApplicantBiz.VirualIndex == 0)
                            objStatementBiz.ApplicantBiz.VirualIndex = objApplicantBiz.VirualIndex;
                        objCol.Add(objStatementBiz);
                    }
                }
            }
            return objCol;
        }
        public ApplicantWorkerStatementBiz GetStatementBiz(ApplicantWorkerBiz objApplicantbiz)
        {
            ApplicantWorkerStatementBiz ObjStatementBiz = new ApplicantWorkerStatementBiz();
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                if (objBiz.ApplicantBiz.ID == objApplicantbiz.ID)
                {
                    ObjStatementBiz = objBiz;
                    break;
                }
            }
            return ObjStatementBiz;
        }
        public DataTable GetBankTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {
                new DataColumn("Serial"),
                new DataColumn("اسم"), 
                new DataColumn("حساب", Type.GetType("System.String")),
                new DataColumn("قيمة"),new DataColumn("ID"),new DataColumn("Job")});
            string strTemp = "";
            int intIndex = 0;
            DataRow objDr;
            foreach (ApplicantWorkerStatementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                intIndex++;
               
                strTemp = objBiz.AccountBankNo.ToString();
                if (objBiz.BankBranchCode != "")
                    strTemp = objBiz.BankBranchCode + "-" + strTemp;
                if (objBiz.AccountTypeCode != "")
                    strTemp = strTemp + "-" + objBiz.AccountTypeCode;
                objDr[0] = intIndex.ToString();
                objDr[1] = objBiz.ApplicantBiz.Name;
                objDr[2] = strTemp;

                strTemp = "[" + objBiz.ApplicantBiz.IDTypeInstantBiz.IDValue + "]";

                objDr[3] = objBiz.TotalDeserved;
                objDr[4] = strTemp;
                objDr["Job"] = objBiz.ApplicantBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetAttendancePenality()
        {
            if (_AttendancePenalitySet)
                return;
            string strIDs = IDs;
            ApplicantWorkerPenaltyDiscountDb objDb = new ApplicantWorkerPenaltyDiscountDb();
            objDb.StatementIDs = strIDs;
            DataTable dtTemp = objDb.Search();

            ApplicantWorkerStatementDiscountDb objDiscountDb = new ApplicantWorkerStatementDiscountDb();
            objDiscountDb.StatementIDs = strIDs;
            DataTable dtDiscount = objDiscountDb.Search();
            
            ApplicantWorkerAttendanceStatementDb objAttendanceDb = new ApplicantWorkerAttendanceStatementDb();
            objAttendanceDb.FinancialStatementIDs = strIDs;
            DataTable dtAttendance = objAttendanceDb.Search();
            DataRow[] arrDr;
            foreach (ApplicantWorkerStatementBiz objStatementBiz in this)
            {
                arrDr = dtTemp.Select("DiscountStatement=" + objStatementBiz.ID);
                objStatementBiz.PenaltyDiscountCol = new ApplicantWorkerPenaltyDiscountCol(true);
                foreach (DataRow objDr in arrDr)
                    objStatementBiz.PenaltyDiscountCol.Add(new ApplicantWorkerPenaltyDiscountBiz(objDr));
                arrDr = dtAttendance.Select("FinancialStatement=" + objStatementBiz.ID);
                objStatementBiz.AttendanceStatementCol = new ApplicantWorkerAttendanceStatementCol(true);
                foreach (DataRow objDr1 in arrDr)
                    objStatementBiz.AttendanceStatementCol.Add(new ApplicantWorkerAttendanceStatementBiz(objDr1));
                objStatementBiz.DiscountCol = new ApplicantWorkerStatementDiscountCol(true);
                arrDr = dtDiscount.Select("OriginStatement=" + objStatementBiz.ID);
                foreach (DataRow objDr2 in arrDr)
                    objStatementBiz.DiscountCol.Add(new ApplicantWorkerStatementDiscountBiz(objDr2));
            }
            _AttendancePenalitySet = true;

        }
        public void EditMotivationCostCenter(CostCenterHRBiz objBiz)
        {
            if (objBiz == null || objBiz.ID == 0)
                return;
            ApplicantWorkerStatementDb objDb = new ApplicantWorkerStatementDb();
            objDb.MotivationCostCenter = objBiz.ID;
            objDb.IDs = IDs;
            objDb.EditMotivationCostCenter();


        }

    }
}
