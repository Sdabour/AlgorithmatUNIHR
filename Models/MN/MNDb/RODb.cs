using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class RODb
    {


        #region Constructor
        public RODb()
        {
        }
        public RODb(DataRow objDr)
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
        string _Code;
        public string Code
        {
            set
            {
                _Code = value;
            }
            get
            {
                return _Code;
            }
        }
        string _ProjectCode;
        public string ProjectCode
        {
            set
            {
                _ProjectCode = value;
            }
            get
            {
                return _ProjectCode;
            }
        }
        string _NativeProjectCode;
        public string NativeProjectCode
        {
            set
            {
                _NativeProjectCode = value;
            }
            get
            {
                return _NativeProjectCode;
            }
        }
        bool _Occupied;
        public bool Occupied { set => _Occupied = value; get => _Occupied; }

        bool _LocalOwned;
        public bool LocalOwned { set => _LocalOwned = value; get => _LocalOwned; }
        string _ExactCode;
        public string ExactCode
        {
            set => _ExactCode = value;
        }
        string _ProjectCodeS;
        public string ProjectCodeS
        {
            set
            {
                _ProjectCodeS = value;
            }

        }
        string _TowerCode;
        public string TowerCode { set => _TowerCode = value; get => _TowerCode; }
        double _Area;
        public double Area { set => _Area = value; get => _Area; }
        int _Type;
        public int Type
        {
            set
            {
                _Type = value;
            }
            get
            {
                return _Type;
            }
        }
        int _TenancyStatus;
        public int TenancyStatus { set => _TenancyStatus = value; }
        int _CancelationStatus;
        public int CancelationStatus { set => _CancelationStatus = value; }
        int _OccupencyStatus;
        public int OccupencyStatus { set => _OccupencyStatus = value; }
        int _LocalOwnedStatus;
        public int LocalOwnedStatus { set => _LocalOwnedStatus = value; }
        int _DebitStatus;
        public int DebitStatus { set => _DebitStatus = value; }
        int _CreditedStatus;
        public int CreditedStatus { set => _CreditedStatus = value; }

        int _ReservationID;
        public int ReservationID { set => _ReservationID = value; get => _ReservationID; }
        string _ReservationIDs;
        public string ReservationIDs { set => _ReservationIDs = value; }
        string _CustomerIDs;
        public string CustomerIDs { set => _CustomerIDs = value; }
        string _SapContract;
        public string SapContract { set => _SapContract = value; get => _SapContract; }
        string _SapCustomerNo;
        public string SapCustomerNo { set => _SapCustomerNo = value; get => _SapCustomerNo; }
        string _Customer;
        public string Customer
        {
            set
            {
                _Customer = value;
            }
            get
            {
                return _Customer;
            }
        }
        string _IDs;
        public string IDs
        { set => _IDs = value; }
        bool _IsDelivered;
        public bool IsDelivered { set => _IsDelivered = value; get => _IsDelivered; }
        int _IsDeliveredStatus;
        public int IsDeliveredStatus { set => _IsDeliveredStatus = value; }
        DateTime _DeliveryDate;
        public DateTime DeliveryDate
        {
            set
            {
                _DeliveryDate = value;
            }
            get
            {
                return _DeliveryDate;
            }
        }
        bool _DeliveryDateRange;
        public bool DeliveryDateRange
        { set => _DeliveryDateRange = value; }
        DateTime _DeliveryStartDate;
        public DateTime DeliveryStartDate
        { set => _DeliveryStartDate = value; }
        DateTime _DeliveryEndDate;
        public DateTime DeliveryEndDate
        { set => _DeliveryEndDate = value; }
        bool _IsEnded;
        public bool IsEnded
        { set => _IsEnded = value; get => _IsEnded; }
        DateTime _EndDate;
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        double _InitialMaintainanceValue;
        public double InitialMaintainanceValue
        {
            set
            {
                _InitialMaintainanceValue = value;
            }
            get
            {
                return _InitialMaintainanceValue;
            }
        }
        double _MaintainanceBonusPercPerYear;
        public double MaintainanceBonusPercPerYear
        {
            set
            {
                _MaintainanceBonusPercPerYear = value;
            }
            get
            {
                return _MaintainanceBonusPercPerYear;
            }
        }
        DateTime _ContractingDate;
        public DateTime ContractingDate
        {
            get => _ContractingDate;
        }
        bool _IsCanceled;
        public bool IsCanceled { get => _IsCanceled; }
        DateTime _CancelDate;
        public DateTime CancelDate { get => _CancelDate; }
        double _Value;
        public double Value { get => _Value; }
        string _Note;
        public string Note
        { set => _Note = value; get => _Note; }
        bool _CollectTotalRequired;
        public bool CollectTotalRequired
        {
            set => _CollectTotalRequired = value;
            get => _CollectTotalRequired;
        }
        #region MaxCredit
        int _MaxCreditRO;
        public int MaxCreditRO
        {
            set
            {
                _MaxCreditRO = value;
            }
            get
            {
                return _MaxCreditRO;
            }
        }
        int _MaxCreditID;
        public int MaxCreditID
        {
            set
            {
                _MaxCreditID = value;
            }
            get
            {
                return _MaxCreditID;
            }
        }
        DateTime _MaxCreditStartDate;
        public DateTime MaxCreditStartDate
        {
            set
            {
                _MaxCreditStartDate = value;
            }
            get
            {
                return _MaxCreditStartDate;
            }
        }
        DateTime _MaxCreditEndDate;
        public DateTime MaxCreditEndDate
        {
            set
            {
                _MaxCreditEndDate = value;
            }
            get
            {
                return _MaxCreditEndDate;
            }
        }
        double _MaxCreditInitialValue;
        public double MaxCreditInitialValue
        {
            set
            {
                _MaxCreditInitialValue = value;
            }
            get
            {
                return _MaxCreditInitialValue;
            }
        }
        double _MaxCreditBonusValue;
        public double MaxCreditBonusValue
        {
            set
            {
                _MaxCreditBonusValue = value;
            }
            get
            {
                return _MaxCreditBonusValue;
            }
        }
        double _MaxCreditPaymentValue;
        public double MaxCreditPaymentValue
        {
            set
            {
                _MaxCreditPaymentValue = value;
            }
            get
            {
                return _MaxCreditPaymentValue;
            }
        }
        double _NonCreditedPayment;
        public double NonCreditedPayment
        { get => _NonCreditedPayment; }
        double _NonCreditedDiscount;
        public double NonCreditedDiscount
        { get => _NonCreditedDiscount; }
        double _NonCreditedCost;
        public double NonCreditedCost
        { get => _NonCreditedCost; }

        double _MaxCreditDiscountValue;
        public double MaxCreditDiscountValue
        {
            set
            {
                _MaxCreditDiscountValue = value;
            }
            get
            {
                return _MaxCreditDiscountValue;
            }
        }
        double _MaxCreditCost;
        public double MaxCreditCost
        {
            set
            {
                _MaxCreditCost = value;
            }
            get
            {
                return _MaxCreditCost;
            }
        }
        int _MaxCreditYearID;
        public int MaxCreditYearID
        {
            set
            {
                _MaxCreditYearID = value;
            }
            get
            {
                return _MaxCreditYearID;
            }
        }
        string _MaxCreditYearDesc;
        public string MaxCreditYearDesc
        {
            set
            {
                _MaxCreditYearDesc = value;
            }
            get
            {
                return _MaxCreditYearDesc;
            }
        }
        #region Estimated Properties
        int _Estimated;
        public int Estimated
        {
            set => _Estimated = value;
            get => _Estimated;
        }
        double _EsitimatedValue;
        public double EsitimatedValue
        {
            set => _EsitimatedValue = value;
            get => _EsitimatedValue;
        }
        DateTime _EstimatedDate;
        public DateTime EstimatedDate
        {
            set => _EstimatedDate = value;
            get => _EstimatedDate;
        }
        DateTime _EstimatedEndDate;
        public DateTime EstimatedEndDate
        {
            set => _EstimatedEndDate = value;
            get => _EstimatedEndDate;
        }
        bool _EstimatedApplied;
        public bool EstimatedApplied
        {
            get => _EstimatedApplied;
        }
        DateTime _EstimatedApplyDate;
        public DateTime EstimatedApplyDate
        {
            set => _EstimatedApplyDate = value;
            get => _EstimatedApplyDate;
        }
        public string EstimatedAddStr
        {
            get
            {
                string Returned = " insert into MNROEstimatedValue (ROID,ROEsitimatedValue,ROEstimatedDate,ROEstimatedEndDate,ROEstimatedApplyDate) values (" + ID + "," + EsitimatedValue + "," + (EstimatedDate.ToOADate() - 2).ToString() + "," + (EstimatedEndDate.ToOADate() - 2).ToString() + "," + (EstimatedApplyDate.ToOADate() - 2).ToString() + ") ";
                return Returned;
            }
        }
        public string EstimatedEditStr
        {
            get
            {
                string Returned = " update MNROEstimatedValue set " + "EstimatedRO=" + Estimated + "" +
           ",ROEsitimatedValue=" + EsitimatedValue + "" +
           ",ROEstimatedDate=" + (EstimatedDate.ToOADate() - 2).ToString() + "" +
           ",ROEstimatedEndDate=" + (EstimatedEndDate.ToOADate() - 2).ToString() + "" +
           ",ROEstimatedApplyDate=" + (EstimatedApplyDate.ToOADate() - 2).ToString() + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string EstimatedDeleteStr
        {
            get
            {
                string Returned = " update MNROEstimatedValue set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string EstimatedSearchStr
        {
            get
            {
                string Returned = " select EstimatedRO,ROEsitimatedValue,ROEstimatedDate,ROEstimatedEndDate,ROEstimatedApplyDate from MNROEstimatedValue  ";
                return Returned;
            }
        }
        #endregion
        #region TenancyProperties
        bool _IsTenancy;
        public bool IsTenancy
        { set => _IsTenancy = value; get => _IsTenancy; }
        int _TenancyID;
        public int TenancyID
        {
            set => _TenancyID = value;
            get => _TenancyID;
        }
        int _TenancyType;
        public int TenancyType
        {
            set => _TenancyType = value;
            get => _TenancyType;
        }
        double _TenancyValue;
        public double TenancyValue
        {
            set => _TenancyValue = value;
            get => _TenancyValue;
        }
        public string TenancyAddStr
        {
            get
            {

                string Returned = "delete from MNROTenancy where ROID = " + ID + @"  insert into MNROTenancy (ROID,ROTenancyType,ROTenancyValue) values (" + TenancyID + "," + TenancyType + "," + TenancyValue + ") ";
                return Returned;
            }
        }

        #endregion
        #endregion
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNRO (ROCode,ROArea,ROReservationID,ROProjectCode,ROTowerCode,ROType,ROSapContract,ROSapCustomerNo,ROCustomer,ROIsDelivered,RODeliveryDate,ROInitialMaintainanceValue,ROMaintainanceBonusPercPerYear,RONote,UsrIns,TimIns) values ('" + Code + "'," + _Area + "," + _ReservationID + ",'" + ProjectCode + "','" + _TowerCode + "'," + Type + ",'" + _SapContract + "','" + _SapCustomerNo + "','" + Customer + "'," + (_IsDelivered ? "1" : "0") + "," + (DeliveryDate.ToOADate() - 2).ToString() + "," + InitialMaintainanceValue + "," + MaintainanceBonusPercPerYear + ",'" + _Note + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNRO set  ROCode='" + Code + "'" +
           ",ROProjectCode='" + ProjectCode + "'" +
           ",ROTowerCode='" + _TowerCode + "'" +
           ",ROArea=" + _Area +
           ",ROType=" + Type + "" +
           ",ROSapContract='" + _SapContract + "'" +
           ",ROSapCustomerNo='" + _SapCustomerNo + "'" +
           ",ROCustomer='" + Customer + "'" +
           ",RODeliveryDate=" + (DeliveryDate.ToOADate() - 2).ToString() + "" +
           ",ROInitialMaintainanceValue=" + InitialMaintainanceValue + "" +
           ",ROMaintainanceBonusPercPerYear=" + MaintainanceBonusPercPerYear + ""
           + ",RONote='" + _Note + "'"
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ROID=" + _ID;
                return Returned;
            }
        }

        public string EditValueDeliveryDateStr
        {
            get
            {
                string strCreditRO = @"SELECT CreditRO, COUNT(CreditID) AS CreditCount
FROM     dbo.MNROCredit
GROUP BY CreditRO ";
                string Returned = " update MNRO set ROSapContract='" + _SapContract + "'" +
           ",ROSapCustomerNo='" + _SapCustomerNo + "'" +
           ",ROCustomer='" + Customer + "'" +
           ",ROIsDelivered=" + (_IsDelivered ? "1" : "0") +
           ",RODeliveryDate=" + (DeliveryDate.ToOADate() - 2).ToString() + "" +
           ",ROInitialMaintainanceValue=" + InitialMaintainanceValue + "" +
           ",ROMaintainanceBonusPercPerYear=" + MaintainanceBonusPercPerYear + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate() 
 from MNRO left outer join (" + strCreditRO + @") as CreditTable 
 on MNRO.ROID = CreditTable.CreditRO 
   where ROCode = '" + _Code + "' and ROProjectCode = '" + _ProjectCode + "' and ROID=" + _ID + " and CreditTable.CreditRO is null ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNRO set Dis = GetDate() where  ";
                return Returned;
            }
        }
        #region Iteration
        double _IterationValue;
        public double IterationValue
        { set => _IterationValue = value; get => _IterationValue; }
        int _IterationPeriod;
        public int IterationPeriod
        { set => _IterationPeriod = value; get => _IterationPeriod; }
        int _IterationPeriodAmount;
        public int IterationPeriodAmount
        { set => _IterationPeriodAmount = value; get => _IterationPeriodAmount; }
        public string IterationSearchStr
        {
            get
            {
                string Returned = @"SELECT ROID AS IterationROID, ROIterationValue, ROIterationPeriod, ROIterationPeriodAmount
FROM     dbo.MNROIteration ";

                return Returned;
            }
        }
        public string IterationAddStr
        {
            get
            {
                string Returned = @"insert into MNROIteration (ROID, ROIterationValue, ROIterationPeriod, ROIterationPeriodAmount
) 
  SELECT dbo.MNRO.ROID, 0 AS IterationValue, 0 AS IterationPeriod, 0 AS IterationAmount
FROM     dbo.MNROIteration RIGHT OUTER JOIN
                  dbo.MNRO ON dbo.MNROIteration.ROID = dbo.MNRO.ROID
WHERE  (dbo.MNROIteration.ROID IS NULL) and dbo.MNRO.ROID = " + _ID;
                return Returned;
            }
        }
        #endregion
        public string SearchStr
        {
            get
            {
                string strTenancy = @"SELECT ROID AS ROTenancyID, ROTenancyType, ROTenancyValue
   FROM     dbo.MNROTenancy";
                string strNonCreditedCost = @"SELECT dbo.MNRoCost.CostRO, SUM(dbo.MNRoCost.CostValue) AS TotalNonCreditedCost
FROM     dbo.MNRO INNER JOIN
                  dbo.MNRoCost ON dbo.MNRO.ROID = dbo.MNRoCost.CostRO
WHERE  (dbo.MNRoCost.CostCredit = 0)
GROUP BY dbo.MNRoCost.CostRO";
                string strNonCreditedPayment = @"SELECT dbo.MNRO.ROID, SUM(dbo.GLPayment.PaymentValue) AS TotalNonCreditedPayment
FROM     dbo.GLPayment INNER JOIN
                  dbo.MNROCreditPayment ON dbo.GLPayment.PaymentID = dbo.MNROCreditPayment.PaymentID INNER JOIN
                  dbo.MNRO ON dbo.MNROCreditPayment.CreditROID = dbo.MNRO.ROID
WHERE  (dbo.MNROCreditPayment.CreditID = 0)
GROUP BY dbo.MNRO.ROID, dbo.MNRO.ROCode ";
                string strNonCreditedDiscount = @"SELECT dbo.MNRO.ROID, SUM(dbo.MNROCreditDiscount.CreditDiscountValue) AS TotalNonCreditedDiscount
FROM     dbo.MNRO INNER JOIN
                  dbo.MNROCreditDiscount ON dbo.MNRO.ROID = dbo.MNROCreditDiscount.CreditROID
WHERE  (ISNULL(dbo.MNROCreditDiscount.CreditID, 0) = 0)
GROUP BY dbo.MNRO.ROID";
                string strEstimatedCost = @"";
                string strReservationValue = @"SELECT ReservationValueTable.ReservationID, ReservationValueTable.TotalValue, ISNULL(derivedtbl_1.TotalBonus, 0) AS TotalBonus, ISNULL(DiscountTable.TotalDiscount, 0) AS TotalDiscount
FROM     (SELECT ReservationID, SUM(Value) AS TotalValue
                  FROM      (SELECT ReservationID, InstallmentDueDate, InstallmentValue AS Value, 'z' AS ConditionType
                                     FROM      dbo.CRMReservationInstallment
                                     UNION ALL
                                     SELECT dbo.CRMTempReservationPayment.ReservationID, dbo.GLPayment.PaymentDate, dbo.GLPayment.PaymentValue AS Value, 'z401' AS ConditionType
                                     FROM     dbo.CRMTempReservationPayment INNER JOIN
                                                       dbo.GLPayment ON dbo.CRMTempReservationPayment.PaymentID = dbo.GLPayment.PaymentID) AS ValueTbale
                  GROUP BY ReservationID) AS ReservationValueTable LEFT OUTER JOIN
                      (SELECT ReservationID, SUM(DiscountValue) AS TotalDiscount
                       FROM      dbo.CRMReservationDiscount
                       GROUP BY ReservationID) AS DiscountTable ON ReservationValueTable.ReservationID = DiscountTable.ReservationID LEFT OUTER JOIN
                      (SELECT ReservationID, SUM(BonusValue) AS TotalBonus
                       FROM      dbo.CRMReservationBonus
                       GROUP BY ReservationID) AS derivedtbl_1 ON ReservationValueTable.ReservationID = derivedtbl_1.ReservationID ";
                string strMaxCreditTable = @"SELECT ROMaxCreditTable.CreditRO AS MaxCreditRO, ROMaxCreditTable.MaxCreditID, MNROCredit_1.CreditStartDate AS MaxCreditStartDate, MNROCredit_1.CreditEndDate AS MaxCreditEndDate, 
                  MNROCredit_1.CrditInitialValue AS MaxCreditInitialValue, MNROCredit_1.CreditBonusValue AS MaxCreditBonusValue, MNROCredit_1.CreditPaymentValue AS MaxCreditPaymentValue, 
                  MNROCredit_1.CreditDiscountValue AS MaxCreditDiscountValue, MNROCredit_1.CreditCost AS MaxCreditCost, dbo.MNYear.YearID AS MaxCreditYearID, dbo.MNYear.YearDesc AS MaxCreditYearDesc
FROM     (SELECT CreditRO, MAX(CreditID) AS MaxCreditID
                  FROM      dbo.MNROCredit ";
                if (_MaxCreditYearID > 0)
                {
                    strMaxCreditTable += " where CreditYear = " + _MaxCreditYearID;
                }
                strMaxCreditTable += @" GROUP BY CreditRO) 
  AS ROMaxCreditTable INNER JOIN
                  dbo.MNROCredit AS MNROCredit_1 ON ROMaxCreditTable.MaxCreditID = MNROCredit_1.CreditID INNER JOIN
                  dbo.MNYear ON MNROCredit_1.CreditYear = dbo.MNYear.YearID ";

                string strReservation = @" SELECT dbo.CRMReservation.ReservationID as MainReservationID, dbo.CRMReservation.ReservationContractingDate
,ReservationValueTable.TotalValue-ReservationValueTable.TotalBonus as ReservationValue1, dbo.CRMReservationCancelation.ReservationID AS CanceledReservationID, 
                  dbo.CRMReservationCancelation.CancelationDate,dbo.CRMReservationTenancy.ReservationID AS TenancyID 
  FROM     dbo.CRMReservation LEFT OUTER JOIN
                  dbo.CRMReservationCancelation ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCancelation.ReservationID  inner join (" + strReservationValue + @") as ReservationValueTable  on dbo.CRMReservation.ReservationID = ReservationValueTable.ReservationID 
   LEFT OUTER JOIN
                  dbo.CRMReservationTenancy ON dbo.CRMReservation.ReservationID = dbo.CRMReservationTenancy.ReservationID ";


                string Returned = @" select MNRO.ROID,ROCode,ROArea,ROReservationID,ROProjectCode,ROTowerCode,ROType,ROSapContract,ROSapCustomerNo,ROCustomer,ROIsDelivered,RODeliveryDate,ROIsEnded,ROEndDate,ROInitialMaintainanceValue,ROMaintainanceBonusPercPerYear,RONativeProjectCode,ROOccupied,ROLocalOwned,MNRO.RONote,ROCollectTotalRequired,ReservationTable.*,MaxCreditTable.* ,isnull(NonCreditedPaymentTable.TotalNonCreditedPayment,0) as NonCreditedPayment,isnull(NonCreditedDiscountTable.TotalNonCreditedDiscount,0) as NonCreditedDiscount 
,isnull(NonCreditedCostTable.TotalNonCreditedCost,0) as NonCreditedCost ,TenancyTable.* 
    from MNRO  
 left outer join (" + strReservation + @") as ReservationTable 
 on MNRO.ROReservationID = ReservationTable.MainReservationID ";
                if (_MaxCreditYearID > 0)
                    Returned += " inner join ";
                else
                    Returned += " left outer join ";
                Returned += @" (" + strMaxCreditTable + @")  as MaxCreditTable 
  on MNRO.ROID = MaxCreditTable.MaxCreditRO 
   left outer join (" + strNonCreditedPayment + @") NonCreditedPaymentTable 
    on MNRO.ROID = NonCreditedPaymentTable.ROID 
   left outer join (" + strNonCreditedDiscount + @") as NonCreditedDiscountTable 
   on MNRO.ROID = NonCreditedDiscountTable.ROID 
  left outer join (" + strNonCreditedCost + @") as NonCreditedCostTable  
  on MNRO.ROID =  NonCreditedCostTable.CostRO  
   left outer join (" + strTenancy + @") as TenancyTable 
    on MNRo.ROID = TenancyTable.ROTenancyID  ";

                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ROID"] != null)
                int.TryParse(objDr["ROID"].ToString(), out _ID);

            if (objDr.Table.Columns["ROCode"] != null)
                _Code = objDr["ROCode"].ToString();

            if (objDr.Table.Columns["ROProjectCode"] != null)
                _ProjectCode = objDr["ROProjectCode"].ToString();
            if (objDr.Table.Columns["RONativeProjectCode"] != null)
                _NativeProjectCode = objDr["RONativeProjectCode"].ToString();

            if (objDr.Table.Columns["ROTowerCode"] != null)
                _TowerCode = objDr["ROTowerCode"].ToString();

            if (objDr.Table.Columns["ROType"] != null)
                int.TryParse(objDr["ROType"].ToString(), out _Type);

            if (objDr.Table.Columns["ROCustomer"] != null)
                _Customer = objDr["ROCustomer"].ToString();

            if (objDr.Table.Columns["ROSapContract"] != null)
                _SapContract = objDr["ROSapContract"].ToString();

            if (objDr.Table.Columns["ROSapCustomerNo"] != null)
                _SapCustomerNo = objDr["ROSapCustomerNo"].ToString();

            if (objDr.Table.Columns["RODeliveryDate"] != null)
                DateTime.TryParse(objDr["RODeliveryDate"].ToString(), out _DeliveryDate);

            if (objDr.Table.Columns["ROInitialMaintainanceValue"] != null)
                double.TryParse(objDr["ROInitialMaintainanceValue"].ToString(), out _InitialMaintainanceValue);

            if (objDr.Table.Columns["ROMaintainanceBonusPercPerYear"] != null)
                double.TryParse(objDr["ROMaintainanceBonusPercPerYear"].ToString(), out _MaintainanceBonusPercPerYear);
            if (objDr.Table.Columns["ROArea"] != null)
                double.TryParse(objDr["ROArea"].ToString(), out _Area);
            if (objDr.Table.Columns["ROReservationID"] != null)
                int.TryParse(objDr["ROReservationID"].ToString(), out _ReservationID);

            if (objDr.Table.Columns["ROIsEnded"] != null)
                bool.TryParse(objDr["ROIsEnded"].ToString(), out _IsEnded);
            if (objDr.Table.Columns["ROCollectTotalRequired"] != null)
                bool.TryParse(objDr["ROCollectTotalRequired"].ToString(), out _CollectTotalRequired);

            if (objDr.Table.Columns["ROEndDate"] != null)
                DateTime.TryParse(objDr["ROEndDate"].ToString(), out _EndDate);
            if (objDr.Table.Columns["ROIsDelivered"] != null)
                bool.TryParse(objDr["ROIsDelivered"].ToString(), out _IsDelivered);
            if (objDr.Table.Columns["ReservationContractingDate"] == null ||
                !DateTime.TryParse(objDr["ReservationContractingDate"].ToString(), out _ContractingDate))
                _ContractingDate = _DeliveryDate;
            if (objDr.Table.Columns["ReservationValue1"] != null)
                double.TryParse(objDr["ReservationValue1"].ToString(), out _Value);
            if (objDr.Table.Columns["CanceledReservationID"] != null && objDr["CanceledReservationID"].ToString() != "")
            {
                _IsCanceled = true;
                DateTime.TryParse(objDr["CancelationDate"].ToString(), out _CancelDate);

            }
            if (objDr.Table.Columns["ROOccupied"] != null)
                bool.TryParse(objDr["ROOccupied"].ToString(), out _Occupied);

            if (objDr.Table.Columns["ROLocalOwned"] != null)
                bool.TryParse(objDr["ROLocalOwned"].ToString(), out _LocalOwned);
            if (objDr.Table.Columns["RONote"] != null)
                _Note = objDr["RONote"].ToString();
            #region 

            if (objDr.Table.Columns["MaxCreditRO"] != null)
                int.TryParse(objDr["MaxCreditRO"].ToString(), out _MaxCreditRO);

            if (objDr.Table.Columns["MaxCreditID"] != null)
                int.TryParse(objDr["MaxCreditID"].ToString(), out _MaxCreditID);

            if (objDr.Table.Columns["MaxCreditStartDate"] != null)
                DateTime.TryParse(objDr["MaxCreditStartDate"].ToString(), out _MaxCreditStartDate);

            if (objDr.Table.Columns["MaxCreditEndDate"] != null)
                DateTime.TryParse(objDr["MaxCreditEndDate"].ToString(), out _MaxCreditEndDate);

            if (objDr.Table.Columns["MaxCreditInitialValue"] != null)
                double.TryParse(objDr["MaxCreditInitialValue"].ToString(), out _MaxCreditInitialValue);

            if (objDr.Table.Columns["MaxCreditBonusValue"] != null)
                double.TryParse(objDr["MaxCreditBonusValue"].ToString(), out _MaxCreditBonusValue);

            if (objDr.Table.Columns["MaxCreditPaymentValue"] != null)
                double.TryParse(objDr["MaxCreditPaymentValue"].ToString(), out _MaxCreditPaymentValue);

            if (objDr.Table.Columns["MaxCreditDiscountValue"] != null)
                double.TryParse(objDr["MaxCreditDiscountValue"].ToString(), out _MaxCreditDiscountValue);

            if (objDr.Table.Columns["MaxCreditCost"] != null)
                double.TryParse(objDr["MaxCreditCost"].ToString(), out _MaxCreditCost);

            if (objDr.Table.Columns["MaxCreditYearID"] != null)
                int.TryParse(objDr["MaxCreditYearID"].ToString(), out _MaxCreditYearID);

            if (objDr.Table.Columns["MaxCreditYearDesc"] != null)
                _MaxCreditYearDesc = objDr["MaxCreditYearDesc"].ToString();
            if (objDr.Table.Columns["NonCreditedPayment"] != null)
                double.TryParse(objDr["NonCreditedPayment"].ToString(), out _NonCreditedPayment);
            if (objDr.Table.Columns["NonCreditedDiscount"] != null)
                double.TryParse(objDr["NonCreditedDiscount"].ToString(), out _NonCreditedDiscount);
            if (objDr.Table.Columns["NonCreditedCost"] != null)
                double.TryParse(objDr["NonCreditedCost"].ToString(), out _NonCreditedCost);
            #endregion
            SetTenancyData(objDr);
            SetEstimatedData(objDr);
        }
        void SetEstimatedData(DataRow objDr)
        {

            if (objDr.Table.Columns["EstimatedRO"] != null)
                int.TryParse(objDr["EstimatedRO"].ToString(), out _Estimated);

            if (objDr.Table.Columns["ROEsitimatedValue"] != null)
                double.TryParse(objDr["ROEsitimatedValue"].ToString(), out _EsitimatedValue);

            if (objDr.Table.Columns["ROEstimatedDate"] != null)
                DateTime.TryParse(objDr["ROEstimatedDate"].ToString(), out _EstimatedDate);

            if (objDr.Table.Columns["ROEstimatedEndDate"] != null)
                DateTime.TryParse(objDr["ROEstimatedEndDate"].ToString(), out _EstimatedEndDate);

            if (objDr.Table.Columns["ROEstimatedApplyDate"] != null)
                _EstimatedApplied = DateTime.TryParse(objDr["ROEstimatedApplyDate"].ToString(), out _EstimatedApplyDate);
        }
        void SetTenancyData(DataRow objDr)
        {
            if (objDr.Table.Columns["ROTenancyID"] != null)
                int.TryParse(objDr["ROTenancyID"].ToString(), out _TenancyID);
            if (_TenancyID != 0)
                _IsTenancy = true;
            int intReservationTenanceyID = 0;
            if (objDr.Table.Columns["TenancyID"] != null)
                int.TryParse(objDr["TenancyID"].ToString(), out intReservationTenanceyID);
            if (intReservationTenanceyID != 0)
                _IsTenancy = true;
            if (objDr.Table.Columns["ROTenancyType"] != null)
                int.TryParse(objDr["ROTenancyType"].ToString(), out _TenancyType);

            if (objDr.Table.Columns["ROTenancyValue"] != null)
                double.TryParse(objDr["ROTenancyValue"].ToString(), out _TenancyValue);
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
        public void EditCollectTotalRequired()
        {
            string strSql = @"update MNRO set ROCollectTotalRequired =" + (_CollectTotalRequired ? "1" : "0") +
                @" where ROID=" + _ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditMaintainanceValue()
        {
            string strSql = EditValueDeliveryDateStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditProfitPerc()
        {
            if (_ID == 0 && (_IDs == null || _IDs == ""))
                return;
            string strIDs = _ID == 0 ? _IDs : _ID.ToString();
            string strSql = @"update MNRO set ROMaintainanceBonusPercPerYear = " + MaintainanceBonusPercPerYear + @" where ROID in (" + strIDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public void EndMaintainance()
        {
            if (_ID == 0 && (_IDs == null || _IDs == ""))
                return;
            string strIDs = _ID == 0 ? _IDs : _ID.ToString();

            string strSql = @"update MNRO set ROIsEnded=1,ROEndDate = " + (EndDate.Date.ToOADate() - 2) + @" where ROID in (" + strIDs + ") and ROEndDate is null ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void ReverseEndMaintainance()
        {
            if (_ID == 0 && (_IDs == null || _IDs == ""))
                return;
            string strIDs = _ID == 0 ? _IDs : _ID.ToString();

            string strSql = @"update MNRO set ROIsEnded=0,ROEndDate = NULL  where ROID in (" + strIDs + ") and ROEndDate is null ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void ChangeTenancyType()
        {
            string strSql = @"insert into MNROTenancy (ROID,ROTenancyType, ROTenancyValue)
    select  ROID," + _TenancyType + @" as TenancyType,0 as TenancyValue 
   from dbo.MNRO where ROID  in (" + _IDs + @") AND (NOT EXISTS
                      (SELECT ROID
                       FROM      dbo.MNROTenancy
                       WHERE   (ROID in (" + _IDs + "))))";

            strSql += " update MNROTenancy set ROTenancyType =" + _TenancyType + "  where ROID in (" + _IDs + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";

            if (_Code != null && _Code != "")
                strSql += " and ROCode like '%" + _Code + "%' ";
            if (_ExactCode != null && _ExactCode != "")
                strSql += " and ROCode ='" + _ExactCode + "' ";
            if (_ProjectCode != null && _ProjectCode != "")
                strSql += " and ROProjectCode='" + _ProjectCode + "' ";
            if (_ProjectCodeS != null && _ProjectCodeS != "")
                strSql += " and ROProjectCode in (" + _ProjectCodeS + ") ";
            if (_ID != 0)
                strSql += " and MNRO.ROID = " + _ID;
            //_IDs = "2060";
            if (_IDs != null && _IDs != "")
                strSql += " and ROID in (" + _IDs + ")";
            if (_IsDeliveredStatus == 1)
                strSql += " and ROIsDelivered=1 ";
            if (_Type != 0)
                strSql += " and MNRO.ROType = " + _Type;
            if (_OccupencyStatus == 1)
                strSql += " and MNRO.ROOccupied = 1 ";
            if (_OccupencyStatus == 2)
                strSql += " and MNRO.ROOccupied = 0 ";

            if (_LocalOwnedStatus == 1)
                strSql += " and MNRO.ROLocalOwned = 1 ";
            if (_LocalOwnedStatus == 2)
                strSql += " and MNRO.ROLocalOwned = 0 ";

            if (_Customer != null && _Customer != "")
                strSql += " and MNRO.ROCustomer like '%" + _Customer.Trim() + "%'";
            if (_TenancyStatus != 0)
            {
                if (_TenancyStatus == 1)
                    strSql += " and (ReservationTable.TenancyID is not null) ";
                else if (_TenancyStatus == 2)
                    strSql += " and (ReservationTable.TenancyID is  null) ";
                if (_TenancyType != 0)
                {
                    strSql += " and ROTenancyType = " + _TenancyType;
                }
            }
            if (_DeliveryDateRange)
            {
                strSql += " and RODeliveryDate between " + (_DeliveryStartDate.Date.ToOADate() - 2) + " and " + (_DeliveryEndDate.Date.ToOADate() - 1);
            }
            if (_DebitStatus == 1)
            {

            }
            if (_CancelationStatus == 1)
            {
                strSql += " and MNRO.ROIsEnded=1 ";
            }
            else if (_CancelationStatus == 2)
            {
                strSql += " and MNRO.ROIsEnded=0 ";
            }
            if (_ReservationIDs != null && _ReservationIDs != "")
            {
                strSql += " and ROReservationID in (" + _ReservationIDs + ") ";
            }
            if (_CustomerIDs != null && _CustomerIDs != "")
            {
                string strReservationIDs = @"SELECT dbo.CRMReservation.ReservationID
FROM     dbo.CRMReservation INNER JOIN
                  dbo.CRMReservationCustomer ON dbo.CRMReservation.ReservationID = dbo.CRMReservationCustomer.ReservationID INNER JOIN
                  dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID
WHERE  (dbo.CRMCustomer.CustomerID IN (" + _CustomerIDs + "))";
                strSql += " and ROReservationID in (" + _ReservationIDs + ") ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void DeleteAllCredit()
        {
            if (_ID == 0)
                return;
            string strSql = @"delete 
 FROM     dbo.MNROCreditCondition
WHERE  (ConditionCredit IN
                      (SELECT CreditID
                       FROM      dbo.MNROCredit
                       WHERE   (CreditRO = " + _ID + ")))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void SwapNew()
        {
            if (_ID == 0)
                return;

            string strEndOld = @"update MNRO set ROIsEnded= 1, ROEndDate=" + (_EndDate.Date.ToOADate() - 2) + @" 
   WHERE  (ROID = " + _ID + ") ";
            string strNew = @"insert into MNRO
( ROCode, ROArea, ROReservationID, ROProjectCode, ROTowerCode, ROType, ROSapContract, ROSapCustomerNo, ROCustomer, ROIsDelivered, RODeliveryDate, ROIsEnded, ROInitialMaintainanceValue, 
                  ROMaintainanceBonusPercPerYear, RONativeProjectCode, ROOccupied, ROLocalOwned, ROSource,UsrIns,TimIns
)
SELECT dbo.MNRO.ROCode, dbo.CRMUnit.UnitSurvey, CustomerTable.ReservationID, dbo.MNRO.ROProjectCode, dbo.MNRO.ROTowerCode, dbo.MNRO.ROType, '' AS SapContract, '' AS CustomerNo, CustomerTable.CustomerFullName, 
                  1 AS IsDelivered, dbo.MNRO.ROEndDate AS InitialDeliveryDate, 0 AS ROIsEnded, dbo.MNRO.ROInitialMaintainanceValue, dbo.MNRO.ROMaintainanceBonusPercPerYear, dbo.MNRO.RONativeProjectCode, 0 AS Occupied, 
                  0 AS LocalOwned, dbo.MNRO.ROID AS ROSource, " + SysData.CurrentUser.ID + @" AS UsrIns, GETDATE() AS TimIns
FROM     dbo.MNRO INNER JOIN
                  dbo.CRMReservationUnit ON dbo.MNRO.ROReservationID = dbo.CRMReservationUnit.ReservationID INNER JOIN
                  dbo.CRMUnit ON dbo.CRMReservationUnit.UnitID = dbo.CRMUnit.UnitID INNER JOIN
                      (SELECT MaxCustomer.ReservationID, dbo.CRMCustomer.CustomerFullName
                       FROM      (SELECT ReservationID, MAX(CustomerID) AS MaxCustomer
                                          FROM      dbo.CRMReservationCustomer
                                          GROUP BY ReservationID) AS MaxCustomer INNER JOIN
                                         dbo.CRMCustomer ON MaxCustomer.MaxCustomer = dbo.CRMCustomer.CustomerID) AS CustomerTable ON dbo.CRMUnit.CurrentReservation = CustomerTable.ReservationID LEFT OUTER JOIN
                      (SELECT ROReservationID
                       FROM      dbo.MNRO AS MNRO_1) AS derivedtbl_1 ON CustomerTable.ReservationID = derivedtbl_1.ROReservationID
WHERE  (derivedtbl_1.ROReservationID IS NULL) AND (dbo.MNRO.ROID = " + _ID + ")";

        }
        public DataTable GetCollectedInstallment()
        {
            DataTable Returned = new DataTable();
            return Returned;

        }
        public DataTable GetCustomer()
        {
            if (_IDs == null || _IDs == "")
                return new DataTable();
            string strSql = @"SELECT dbo.MNRO.ROID, dbo.CRMCustomer.CustomerFullName AS CustomerName, dbo.CRMCustomer.CustomerMobile_T AS CustomerMobile
FROM     dbo.CRMReservationCustomer INNER JOIN
                  dbo.CRMReservation ON dbo.CRMReservationCustomer.ReservationID = dbo.CRMReservation.ReservationID INNER JOIN
                  dbo.CRMCustomer ON dbo.CRMReservationCustomer.CustomerID = dbo.CRMCustomer.CustomerID INNER JOIN
                  dbo.MNRO ON dbo.CRMReservation.ReservationID = dbo.MNRO.ROReservationID
WHERE  (dbo.MNRO.ROID IN (" + _IDs + "))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
