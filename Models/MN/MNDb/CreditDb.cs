using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class CreditDb
    {

        #region Constructor
        public CreditDb()
        {
        }
        public CreditDb(DataRow objDr)
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
        string _ROCode;
        public string ROCode
        { set => _ROCode = value; }
        int _Year;
        public int Year
        {
            set
            {
                _Year = value;
            }
            get
            {
                return _Year;
            }
        }
        string _YearsStr;
        public string YearsStr { set => _YearsStr = value; }
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
        double _CrditInitialValue;
        public double CrditInitialValue
        {
            set
            {
                _CrditInitialValue = value;
            }
            get
            {
                return _CrditInitialValue;
            }
        }
        double _BonusValue;
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
        double _PaymentValue;
        public double PaymentValue
        {
            set
            {
                _PaymentValue = value;
            }
            get
            {
                return _PaymentValue;
            }
        }
        double _DiscountValue;
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
        double _Cost;
        public double Cost
        {
            set
            {
                _Cost = value;
            }
            get
            {
                return _Cost;
            }
        }
        int _AncesstorID;
        public int AncesstorID { set => _AncesstorID = value; get => _AncesstorID; }
        double _MeterCost;
        public double MeterCost { get => _MeterCost; }
        double _DaysNo;
        public double DaysNo { get => _DaysNo; }
        bool _IsLast;
        public bool IsLast { set => _IsLast = value; get => _IsLast; }
        int _StrategyID;
        public int StrategyID { set => _StrategyID = value; get => _StrategyID; }
        DateTime _StrategyStartDate;
        public DateTime StrategyStartDate { set => _StrategyStartDate = value; get => _StrategyStartDate; }
        double _StrategyDiscountValue;
        public double StrategyDiscountValue { set => _StrategyDiscountValue = value; get => _StrategyDiscountValue; }
        double _PeriodInitialValue;
        public double PeriodInitialValue { set => _PeriodInitialValue = value; get => _PeriodInitialValue; }
        double _PeriodNewValue;
        public double PeriodNewValue { set => _PeriodNewValue = value; get => _PeriodNewValue; }
        string _IDs;
        public string IDs
        { set => _IDs = value; }
        string _ROIDs;
        public string ROIDs
        { set => _ROIDs = value; }
        DataTable _ROIDTable;
        public DataTable ROIDTable { set => _ROIDTable = value; }
        string _ProjectCode;
        public string ProjectCode { set => _ProjectCode = value; }
        bool _DeleteOnlyLast;
        public bool DeleteOnlyLast { set => _DeleteOnlyLast = value; }
        DataTable _CreditTable;
        public DataTable CreditTable
        {
            set => _CreditTable = value;
        }
        DataTable _DiscountTable;
        public DataTable DiscountTable
        { set => _DiscountTable = value; }
        DataTable _PaymentTable;
        public DataTable PaymentTable
        { set => _PaymentTable = value; }
        DataTable _CostTable;
        public DataTable CostTable
        { set => _CostTable = value; }
        DataTable _ConditionTable;
        public DataTable ConditionTable
        {
            set => _ConditionTable = value;
        }
        #region Group
        bool _IsYearGroup;
        public bool IsYearGroup { set => _IsYearGroup = value; }
        bool _IsProjectGroup;
        public bool IsProjectGroup { set => _IsProjectGroup = value; }
        bool _IsTowerGroup;
        public bool IsTowerGroup { set => _IsTowerGroup = value; }

        string _ROProjectCode;
        public string ROProjectCode
        {
            set => _ROProjectCode = value;
            get => _ROProjectCode;
        }
        string _ROTowerCode;
        public string ROTowerCode
        {
            set => _ROTowerCode = value;
            get => _ROTowerCode;
        }
        string _YearDesc;
        public string YearDesc
        {
            set => _YearDesc = value;
            get => _YearDesc;
        }
        double _TotalBonusValue;
        public double TotalBonusValue
        {
            set => _TotalBonusValue = value;
            get => _TotalBonusValue;
        }
        double _TotalPaymentValue;
        public double TotalPaymentValue { set => _TotalPaymentValue = value; get => _TotalPaymentValue; }
        double _TotalDiscountValue;
        public double TotalDiscountValue { set => _TotalDiscountValue = value; get => _TotalDiscountValue; }

        double _EndedClosingValue;
        public double EndedClosingValue { set => _EndedClosingValue = value; get => _EndedClosingValue; }

        double _EndedInitialValue;
        public double EndedInitialValue { set => _EndedInitialValue = value; get => _EndedInitialValue; }
        double _TotalCreditCost;
        public double TotalCreditCost
        {
            set => _TotalCreditCost = value;
            get => _TotalCreditCost;
        }
        double _TotalArea;
        public double TotalArea
        {
            set => _TotalArea = value;
            get => _TotalArea;
        }
        double _TotalResedintialArea;
        public double TotalResedintialArea
        {
            set => _TotalResedintialArea = value;
            get => _TotalResedintialArea;
        }
        double _TotalNonResedinitialArea;
        public double TotalNonResedinitialArea
        {
            set => _TotalNonResedinitialArea = value;
            get => _TotalNonResedinitialArea;
        }
        double _TotalPeriodInitialValue;
        public double TotalPeriodInitialValue
        {
            set => _TotalPeriodInitialValue = value;
            get => _TotalPeriodInitialValue;
        }
        double _MinMeterCost;
        public double MinMeterCost
        {
            set => _MinMeterCost = value;
            get => _MinMeterCost;
        }
        double _MaxMeterCost;
        public double MaxMeterCost
        {
            set => _MaxMeterCost = value;
            get => _MaxMeterCost;
        }
        double _TotalPeriodNewValue;
        public double TotalPeriodNewValue
        {
            set => _TotalPeriodNewValue = value;
            get => _TotalPeriodNewValue;
        }
        double _NetPeriodValue;
        public double NetPeriodValue
        {
            set => _NetPeriodValue = value;
            get => _NetPeriodValue;
        }
        //bool _Is
        int _IsCountedStatus;
        public int IsCountedStatus { set => _IsCountedStatus = value; }
        int _IsEndedStatus;
        public int IsEndedStatus { set => _IsEndedStatus = value; }
        DataTable _ROTable;
        public DataTable ROTable { set => _ROTable = value; }
        #endregion
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNROCredit (CreditRO,CreditYear,CreditStartDate,CreditEndDate,CrditInitialValue,CreditBonusValue,CreditPaymentValue,CreditDiscountValue,CreditCost,UsrIns,TimIns) values (" + RO + "," + Year + "," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString() + "," + CrditInitialValue + "," + BonusValue + "," + PaymentValue + "," + DiscountValue + "," + Cost + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string AddStrategyStr
        {
            get
            {
                string Returned = @" insert into MNROCreditStrategy ( CreditID, StrategyID, StartDate, DiscountValue
)
 SELECT dbo.MNROCredit.CreditID, " + _StrategyID + @" AS StrategyID, " + (_StrategyStartDate.Date.ToOADate() - 2) + @" AS StartDate, " + _StrategyDiscountValue + @" AS DiscountValue
FROM     dbo.MNROCredit LEFT OUTER JOIN
                  dbo.MNROCreditStrategy ON dbo.MNROCredit.CreditID = dbo.MNROCreditStrategy.CreditID
WHERE  (dbo.MNROCredit.CreditID = " + _ID + @") AND (dbo.MNROCreditStrategy.CreditID IS NULL) ";
                Returned += @" update MNROCreditStrategy set StrategyID =" + _StrategyID + @", StartDate=" + (_StrategyStartDate.Date.ToOADate() - 2) + @", DiscountValue=" + _StrategyDiscountValue + @"
 where CreditID =" + _ID;
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNROCredit set CreditRO=" + RO + "" +
           ",CreditYear=" + Year + "" +
           ",CreditStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",CreditEndDate=" + (EndDate.ToOADate() - 2).ToString() + "" +
           ",CrditInitialValue=" + CrditInitialValue + "" +
           ",CreditBonusValue=" + BonusValue + "" +
           ",CreditPaymentValue=" + PaymentValue +
           ",CreditDiscountValue=" + DiscountValue +
           ",CreditCost=" + Cost + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strCredit = @"delete 
    FROM dbo.MNROCreditTemp
WHERE(CreditUser = " + SysData.CurrentUser.ID + ")";
                strCredit = "truncate table MNROCreditTemp";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strCredit);
                strCredit = @" insert into MNROCreditTemp (CreditID, CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditUser
)
SELECT CreditID, MNROCredit.CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, " + SysData.CurrentUser.ID.ToString() + @"
FROM     dbo.MNROCredit ";

                if (_IDs != null && _IDs != "")
                {
                    strCredit += @" inner join (
SELECT CreditRO, MAX(CreditID) AS MaxCreditID
 FROM     dbo.MNROCredit
 GROUP BY CreditRO
  HAVING (MAX(CreditID) in (" + _IDs + @"))
) as MaxCreditTable on MNROCredit.CreditID = MaxCreditTable.MaxCreditID ";
                    strCredit += " where CreditID in (" + _IDs + ")";
                }
                else if (_DeleteOnlyLast)
                {
                    strCredit += @" inner join (
SELECT CreditRO, MAX(CreditID) AS MaxCreditID
 FROM     dbo.MNROCredit
 where (CreditRO in (" + _ROIDs + @")) 
 GROUP BY CreditRO
  
) as MaxCreditTable on MNROCredit.CreditID = MaxCreditTable.MaxCreditID ";
                    //strCredit += " where CreditID in (" + _IDs + ")";
                }
                else if (_ROIDs != null && _ROIDs != "")
                    strCredit += " where CreditRO in (" + _ROIDs + ") ";
                else if (_ROIDTable != null && _ROIDTable.Rows.Count > 0)
                {
                    SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table MNTempID");
                    System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
                    objCopy.DestinationTableName = "MNTempID";
                    objCopy.WriteToServer(_ROIDTable);

                    strCredit += @" where CreditID in (SELECT dbo.MNROCredit.CreditID
FROM dbo.MNROCredit INNER JOIN
                  dbo.MNTempID ON dbo.MNROCredit.CreditRO = dbo.MNTempID.ID)";
                }
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strCredit);

                string strIDs = _IDs == null || _IDs == "" ? ID.ToString() : _IDs;
                string Returned = @" begin transaction Trans1; ";
                Returned += " begin try ";
                Returned += @"delete from MNROCredit where CreditID in (SELECT CreditID
FROM     dbo.MNROCreditTemp
WHERE  (CreditUser = " + SysData.CurrentUser.ID + ")) ";
                Returned += @" update dbo.MNRoCost set CostCredit =0 
FROM dbo.MNRoCost INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNRoCost.CostCredit = dbo.MNROCreditTemp.CreditID
WHERE(dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + ") AND(dbo.MNROCreditTemp.CreditID > 0)";

                Returned += @" update dbo.MNROCreditPayment set CreditID = 0
FROM     dbo.MNROCreditPayment INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCreditPayment.CreditID = dbo.MNROCreditTemp.CreditID
WHERE  (dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + @") AND (dbo.MNROCreditTemp.CreditID > 0)";

                Returned += @" update dbo.MNROCreditDiscount set CreditID = 0 
 FROM     dbo.MNROCreditDiscount INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCreditDiscount.CreditID = dbo.MNROCreditTemp.CreditID
WHERE  (dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + @") AND (dbo.MNROCreditTemp.CreditID > 0) ";
                Returned += @" ";
                Returned += @" commitline: commit transaction Trans1;Return; ";
                Returned += @"
     END TRY ";


                Returned += @" BEGIN CATCH 
   rolLine: RollBack TRAN Trans1 ; 
   END CATCH; ";
                return Returned;
            }
        }
        
        public string SearchStr
        {
            get
            {
                // PeriodInitialValue,PeriodNewValue,PeriodOutValue
                string strIsCounted = " case when ROTable.ROOccupied=1 or (ROTenancyID is not null and ROTenancyType in (1,2)) then 0 else 1 end =1  ";
                string strROIsEnded = @" case when ROTable.ROIsEnded =0 or ROTable.ROEndDate > YearTable.YearEndDate then 0 when  (ROTable.ROIsEnded =1 and ROTable.ROEndDate >= YearTable.YearStartDate and ROTable.ROEndDate <=YearTable.YearEndDate) then 1 else 2 end ";
                string strPeriodInitialValue = " CASE WHEN  " + strIsCounted + " and dbo.MNROCredit.CreditAncesstorID > 0 THEN dbo.MNROCredit.CrditInitialValue ELSE 0 END AS PeriodInitialValue";
                string strPeriodNewValue = " CASE WHEN  " + strIsCounted + " and  dbo.MNROCredit.CreditAncesstorID = 0 THEN dbo.MNROCredit.CrditInitialValue ELSE 0 END AS PeriodNewValue";
                string strClosing = @"case when  " + strIsCounted + @" then dbo.MNROCredit.CrditInitialValue +dbo.MNROCredit.CreditPaymentValue+dbo.MNROCredit.CreditBonusValue+ dbo.MNROCredit.CreditDiscountValue- dbo.MNROCredit.CreditCost
 else 0 end as ClosingValue ";



                string Returned = @" select dbo.MNROCredit.CreditID,dbo.MNROCredit.CreditRO,dbo.MNROCredit.CreditYear,dbo.MNROCredit.CreditStartDate,dbo.MNROCredit.CreditEndDate,CrditInitialValue,CreditBonusValue,CreditPaymentValue, CreditDiscountValue
,CreditCost,ROTable.*,dbo.MNROCreditStrategy.CreditID AS StrategyCreditID, dbo.MNROCreditStrategy.StartDate AS CreditStrategyStartDate, dbo.MNROCreditStrategy.DiscountValue AS StrategyDiscountValue, 
                  dbo.MNROCreditStrategy.StrategyID AS StrategyID1,StrategyTable.*,YearTable.*
  ,dbo.MNROCredit.CreditCost *
				  (convert(float, (DATEDIFF(day, YearTable.YearStartDate, 
                  YearTable.YearEndDate) + 1))
				  /convert(float, (DATEDIFF(day, dbo.MNROCredit.CreditStartDate, dbo.MNROCredit.CreditEndDate) + 1)) ) / ROTable.ROArea AS CreditMeterCost
,DATEDIFF(day, dbo.MNROCredit.CreditStartDate, dbo.MNROCredit.CreditEndDate) + 1 as CreditDayNo," + strPeriodInitialValue + "," + strPeriodNewValue + "," + strClosing + "," + strROIsEnded + " as CreditROIsEnded " + @"

    from MNROCredit 
    inner join (" + new RODb().SearchStr + @") as ROTable 
   on MNROCredit.CreditRO  = ROTable.ROID 
  inner join (" + new YearDb().SearchStr + @") as YearTable
  on MNROCredit.CreditYear = YearTable.YearID 
  LEFT OUTER JOIN
                  dbo.MNROCreditStrategy ON dbo.MNROCredit.CreditID = dbo.MNROCreditStrategy.CreditID
 left outer join (" + new PaymentStrategyDb().SearchStr + @") as StrategyTable
  on  dbo.MNROCreditStrategy.StrategyID = StrategyTable.StrategyID ";
                if (_ROIDTable != null && _ROIDTable.Rows.Count > 0)
                {
                    SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table MNTempID");
                    System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
                    objCopy.DestinationTableName = "MNTempID";
                    objCopy.WriteToServer(_ROIDTable);
                    Returned += " inner join MNTempID on ROTable.ROID  =  MNTempID.ID  ";
                }
                if (_ROTable != null && _ROTable.Rows.Count > 0)
                {
                    SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table CRMTempBEUnitCode");
                    System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
                    objCopy.DestinationTableName = "CRMTempBEUnitCode";
                    objCopy.WriteToServer(_ROTable);
                    string strRO = @"SELECT DISTINCT ROUnitTable.UnitID, ROUnitTable.UnitCode, ROUnitTable.UnitFullName, ROUnitTable.CurrentReservation, ROUnitTable.ProjectCode
                       FROM      dbo.CRMTempBEUnitCode INNER JOIN
                                             (SELECT dbo.CRMUnit.UnitID, dbo.CRMUnit.UnitCode, dbo.CRMUnit.UnitFullName, dbo.CRMUnit.CurrentReservation, dbo.CRMProject.ProjectCode
                                              FROM      dbo.CRMProject INNER JOIN
                                                                dbo.CRMTower ON dbo.CRMProject.ProjectID = dbo.CRMTower.TowerProject INNER JOIN
                                                                dbo.CRMUnit ON dbo.CRMTower.TowerID = dbo.CRMUnit.UnitTower
                                              WHERE   (dbo.CRMUnit.CurrentReservation > 0)) AS ROUnitTable ON dbo.CRMTempBEUnitCode.BE = ROUnitTable.ProjectCode AND (dbo.CRMTempBEUnitCode.UnitCode = ROUnitTable.UnitCode OR
                                         dbo.CRMTempBEUnitCode.UnitCode = ROUnitTable.UnitFullName)";
                    Returned += " inner join (" + strRO + @")  as ROUnitTempTable ON ROTable.ROReservationID = ROUnitTempTable.CurrentReservation ";
                }
                return Returned;
            }
        }
        public string StrSearch
        {
            get
            {
                string Returned = SearchStr + " where (1=1) ";
                //_ROIDs = "1425";
                if (_ROIDs != null && _ROIDs != "")
                    Returned += " and ROTable.ROID in (" + _ROIDs + ") ";
                if (_ProjectCode != null && _ProjectCode != "")
                    Returned += " and ROProjectCode='" + _ProjectCode + "' ";
                if (_ROCode != null && _ROCode != "")
                    Returned += " and ROCode like '%" + _ROCode + "%' ";
                if (_YearsStr != null && _YearsStr != "" && _YearsStr != "0")
                {
                    Returned += " and CreditYear in (" + _YearsStr + ") ";
                }
                if (_YearsStr == null || _YearsStr == "" || _YearsStr == "0")
                {
                    if (_IsEndedStatus == 1)
                    {
                        Returned += " and ROTable.ROIsEnded =1 ";
                    }
                    else if (_IsEndedStatus == 2)
                    {
                        Returned += " and ROTable.ROIsEnded =0 ";
                    }
                }
                else
                {
                    if (_IsEndedStatus == 1)
                    {
                        Returned += " and case when ROTable.ROIsEnded =0 or ROTable.ROEndDate > YearTable.YearEndDate then 0 when  (ROTable.ROIsEnded =1 and ROTable.ROEndDate >= YearTable.YearStartDate and ROTable.ROEndDate <=YearTable.YearEndDate) then 1 else 2 end  =1 ";
                    }
                    else if (_IsEndedStatus == 2)
                    {
                        Returned += " and case when ROTable.ROIsEnded =0 or ROTable.ROEndDate > YearTable.YearEndDate then 0 when  (ROTable.ROIsEnded =1 and ROTable.ROEndDate >= YearTable.YearStartDate and ROTable.ROEndDate <=YearTable.YearEndDate) then 1 else 2 end  =0 ";
                    }
                }
                string strIsCounted = " case when ROTable.ROOccupied=1 or (ROTenancyID is not null and ROTenancyType in (1,2)) then 0 else 1 end ";
                if (_IsCountedStatus == 1)
                {
                    strIsCounted += " =1 ";

                    Returned += " and " + strIsCounted;
                }
                else if (_IsCountedStatus == 2)
                {
                    strIsCounted += " =0 ";

                    Returned += " and " + strIsCounted;
                }
                return Returned;
            }
        }

        public string SearchSUMStr
        {
            get
            {
                SysData.SharpVisionBaseDb.ExecuteNonQuery("delete from dbo.MNROTempID where UsrIns=" + SysData.CurrentUser.ID);
                string strTempSearch = @"insert into MNROTempID 
   select CreditID," + SysData.CurrentUser.ID + @" as UsrIns,GetDate() as TimIns 
 from (" + StrSearch + ") as CreditDetailsTable";
                SysData.SharpVisionBaseDb.ExecuteNonQuery(strTempSearch);

                string Returned = SearchStr + @" inner join dbo.MNROTempID on MNROCredit.CreditID = dbo.MNROTempID.ID and dbo.MNROTempID.UsrIns= " + SysData.CurrentUser.ID;
                string strClosing = "ClosingValue";
                string strEndedClosingValue = " case when CreditROIsEnded = 1 then " + strClosing + " else 0 end";

                string strEndedInitalValue = " case when CreditROIsEnded = 1 then isnull(ROInitialMaintainanceValue,0) else 0 end";

                string strPeriodInitial = "PeriodNewValue";
                string strSelect = @"SUM(CreditBonusValue) AS TotalBonusValue, SUM(CreditCost) AS TotalCreditCost, SUM(ROArea) AS TotalArea, SUM(CASE WHEN ROType = 1 THEN ROArea ELSE 0 END) 
                  AS TotalResedintialArea
, SUM(CASE WHEN ROType <> 1 THEN ROArea ELSE 0 END) AS TotalNonResedinitialArea
, SUM(PeriodInitialValue) AS TotalPeriodInitialValue
, SUM(CreditPaymentValue) AS TotalPaymentValue
, SUM(CreditDiscountValue) AS TotalDiscountValue
, MIN(CreditMeterCost) AS MinMeterCost, MAX(CreditMeterCost) 
                  AS MaxMeterCost, SUM(" + strPeriodInitial + @") AS TotalPeriodNewValue,sum(" + strClosing + @") as NetPeriodValue
 ,sum(" + strEndedClosingValue + @") as EndedClosingValue,sum(" + strEndedInitalValue + @") as EndedInitialValue ";
                string strGroup = "";
                string strOrder = "";
                if (_IsProjectGroup && !_IsTowerGroup)
                {
                    strSelect += ",ROProjectCode";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ROProjectCode";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ROProjectCode";
                }
                if (_IsTowerGroup)
                {
                    strSelect += ",ROProjectCode,ROTowerCode";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "ROProjectCode,ROTowerCode";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "ROProjectCode,ROTowerCode";
                }
                if (_IsYearGroup)
                {
                    strSelect += ",CreditYear,YearDesc";
                    if (strGroup != "")
                        strGroup += ",";
                    strGroup += "CreditYear,YearDesc";
                    if (strOrder != "")
                        strOrder += ",";
                    strOrder += "CreditYear,YearDesc";
                }
                Returned = "select " + strSelect + " from (" + Returned + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;

                return Returned;
            }
        }
        public string SearchSUMStr1
        {
            get
            {
                string strProjectYearFirstDate = @"SELECT dbo.MNRO.ROProjectCode, dbo.MNROCredit.CreditYear, MIN(dbo.MNROCredit.CreditStartDate) AS ProjectYearFirstDate
                       FROM      dbo.MNROCredit INNER JOIN
                                         dbo.MNRO ON dbo.MNROCredit.CreditRO = dbo.MNRO.ROID
                       GROUP BY dbo.MNRO.ROProjectCode, dbo.MNROCredit.CreditYear ";
                string strProjectFirstDate = @"SELECT MNRO_1.ROProjectCode, MIN(MNROCredit_1.CreditStartDate) AS MinProjectStartDate
                       FROM      dbo.MNRO AS MNRO_1 INNER JOIN
                                         dbo.MNROCredit AS MNROCredit_1 ON MNRO_1.ROID = MNROCredit_1.CreditRO
                       WHERE   (MNRO_1.RODeliveryDate IS NOT NULL)
                       GROUP BY MNRO_1.ROProjectCode";
                string strPeriodCondition = @" CreditTable.RODeliveryDate < ProjectYearMinDateTable.ProjectYearFirstDate OR
                  ProjectYearMinDateTable.ProjectYearFirstDate = ProjectMinDate.MinProjectStartDate ";
                string Returned = @"SELECT DATEDIFF(day, CreditTable.CreditStartDate, CreditTable.CreditEndDate) + 1 AS TotalCreditDaysNo, 
                  CASE WHEN " + strPeriodCondition + @" THEN CreditTable.CrditInitialValue ELSE 0 END AS PeriodInitialValue,CreditTable.* 
FROM    (" + StrSearch + @") AS CreditTable INNER JOIN
                      (" + strProjectYearFirstDate + @") AS ProjectYearMinDateTable ON CreditTable.ROProjectCode = ProjectYearMinDateTable.ROProjectCode AND 
                  CreditTable.CreditYear = ProjectYearMinDateTable.CreditYear INNER JOIN
                      (" + strProjectFirstDate + @") AS ProjectMinDate ON CreditTable.ROProjectCode = ProjectMinDate.ROProjectCode";

                string strSelect = "";
                string strGroup = "";
                string strOrder = "";

                Returned = "select " + strSelect + " from (" + Returned + ") as NativeTable ";

                if (strGroup != "")
                    Returned += " group by " + strGroup;
                if (strOrder != "")
                    Returned += " order by  " + strOrder;

                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {
            if (objDr.Table.Columns["TotalPeriodInitialValue"] != null)
            {
                SetSUMData(objDr);
                return;
            }
            if (objDr.Table.Columns["CreditID"] != null)
                int.TryParse(objDr["CreditID"].ToString(), out _ID);

            if (objDr.Table.Columns["CreditRO"] != null)
                int.TryParse(objDr["CreditRO"].ToString(), out _RO);

            if (objDr.Table.Columns["CreditYear"] != null)
                int.TryParse(objDr["CreditYear"].ToString(), out _Year);

            if (objDr.Table.Columns["CreditStartDate"] != null)
                DateTime.TryParse(objDr["CreditStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["CreditEndDate"] != null)
                DateTime.TryParse(objDr["CreditEndDate"].ToString(), out _EndDate);

            if (objDr.Table.Columns["CrditInitialValue"] != null)
                double.TryParse(objDr["CrditInitialValue"].ToString(), out _CrditInitialValue);

            if (objDr.Table.Columns["CreditBonusValue"] != null)
                double.TryParse(objDr["CreditBonusValue"].ToString(), out _BonusValue);

            if (objDr.Table.Columns["CreditCost"] != null)
                double.TryParse(objDr["CreditCost"].ToString(), out _Cost);
            if (objDr.Table.Columns["CreditPaymentValue"] != null)
                double.TryParse(objDr["CreditPaymentValue"].ToString(), out _PaymentValue);
            if (objDr.Table.Columns["CreditDiscountValue"] != null)
                double.TryParse(objDr["CreditDiscountValue"].ToString(), out _DiscountValue);


            if (objDr.Table.Columns["StrategyStartDate"] != null)
                DateTime.TryParse(objDr["StrategyStartDate"].ToString(), out _StrategyStartDate);
            if (objDr.Table.Columns["CreditStrategyStartDate"] != null)
                DateTime.TryParse(objDr["CreditStrategyStartDate"].ToString(), out _StrategyStartDate);
            if (objDr.Table.Columns["StrategyDiscountValue"] != null)
                double.TryParse(objDr["StrategyDiscountValue"].ToString(), out _StrategyDiscountValue);
            if (_PaymentValue > 0)
            {

            }
            if (objDr.Table.Columns["CreditMeterCost"] != null)
                double.TryParse(objDr["CreditMeterCost"].ToString(), out _MeterCost);
            if (objDr.Table.Columns["CreditDayNo"] != null)
                double.TryParse(objDr["CreditDayNo"].ToString(), out _DaysNo);
            if (objDr.Table.Columns["PeriodInitialValue"] != null)
                double.TryParse(objDr["PeriodInitialValue"].ToString(), out _PeriodInitialValue);
            //DataRow[] arrDr = objDr.Table.Select("CreditPaymentValue>0");
        }
        void SetSUMData(DataRow objDr)
        {

            if (objDr.Table.Columns["ROProjectCode"] != null)
                _ROProjectCode = objDr["ROProjectCode"].ToString();

            if (objDr.Table.Columns["ROTowerCode"] != null)
                _ROTowerCode = objDr["ROTowerCode"].ToString();

            if (objDr.Table.Columns["YearDesc"] != null)
                _YearDesc = objDr["YearDesc"].ToString();
            if (objDr.Table.Columns["CreditYear"] != null)
                int.TryParse(objDr["CreditYear"].ToString(), out _Year);
            if (objDr.Table.Columns["TotalBonusValue"] != null)
                double.TryParse(objDr["TotalBonusValue"].ToString(), out _TotalBonusValue);

            if (objDr.Table.Columns["TotalCreditCost"] != null)
                double.TryParse(objDr["TotalCreditCost"].ToString(), out _TotalCreditCost);

            if (objDr.Table.Columns["TotalArea"] != null)
                double.TryParse(objDr["TotalArea"].ToString(), out _TotalArea);

            if (objDr.Table.Columns["TotalResedintialArea"] != null)
                double.TryParse(objDr["TotalResedintialArea"].ToString(), out _TotalResedintialArea);

            if (objDr.Table.Columns["TotalNonResedinitialArea"] != null)
                double.TryParse(objDr["TotalNonResedinitialArea"].ToString(), out _TotalNonResedinitialArea);

            if (objDr.Table.Columns["TotalPeriodInitialValue"] != null)
                double.TryParse(objDr["TotalPeriodInitialValue"].ToString(), out _TotalPeriodInitialValue);

            if (objDr.Table.Columns["MinMeterCost"] != null)
                double.TryParse(objDr["MinMeterCost"].ToString(), out _MinMeterCost);

            if (objDr.Table.Columns["MaxMeterCost"] != null)
                double.TryParse(objDr["MaxMeterCost"].ToString(), out _MaxMeterCost);

            if (objDr.Table.Columns["TotalPeriodNewValue"] != null)
                double.TryParse(objDr["TotalPeriodNewValue"].ToString(), out _TotalPeriodNewValue);
            if (objDr.Table.Columns["NetPeriodValue"] != null)
                double.TryParse(objDr["NetPeriodValue"].ToString(), out _NetPeriodValue);
            if (objDr.Table.Columns["TotalPaymentValue"] != null)
                double.TryParse(objDr["TotalPaymentValue"].ToString(), out _TotalPaymentValue);

            if (objDr.Table.Columns["TotalDiscountValue"] != null)
                double.TryParse(objDr["TotalDiscountValue"].ToString(), out _TotalDiscountValue);

            if (objDr.Table.Columns["EndedClosingValue"] != null)
                double.TryParse(objDr["EndedClosingValue"].ToString(), out _EndedClosingValue);

            if (objDr.Table.Columns["EndedInitialValue"] != null)
                double.TryParse(objDr["EndedInitialValue"].ToString(), out _EndedInitialValue);
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
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = StrSearch;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable SearchSUM()
        {
            string strSql = SearchSUMStr;

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddMultiple()
        {
            if (_CreditTable == null || _CreditTable.Rows.Count == 0)
                return;
            System.Data.SqlClient.SqlBulkCopy objCopy = new System.Data.SqlClient.SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table MNROCreditTemp ");
            //COMMONTempForign
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table COMMONTempForign ");
            objCopy.DestinationTableName = "MNROCreditTemp";
            DataRow[] arrDr = _CreditTable.Select("CreditID=0");
            objCopy.WriteToServer(_CreditTable);
            SysUtility.SaveTempForignTable("MNROCreditDiscount", _DiscountTable);
            SysUtility.SaveTempForignTable("MNROCreditPayment", _PaymentTable);

            SysUtility.SaveTempForignTable("MNROCost", _CostTable);
            List<string> lstSql = new List<string>();
            double dblTimIns = DateTime.Now.ToOADate() - 2;
            string strSql = @" insert into  MNROCredit 
 (CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditOrder, UsrIns, TimIns
)
SELECT CreditRO, CreditYear, CreditStartDate, CreditEndDate, CrditInitialValue, CreditBonusValue, CreditPaymentValue, CreditDiscountValue, CreditCost, CreditOrder, " + SysData.CurrentUser.ID + @" AS UsrIns, " + dblTimIns + @" AS TimIns
FROM     dbo.MNROCreditTemp
WHERE  (CreditUser = " + SysData.CurrentUser.ID + @") ";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.MNRoCost set CostCredit=dbo.MNROCredit.CreditID
 FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO   and dbo.MNROCredit.CreditOrder = dbo.MNROCreditTemp.CreditOrder INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNRoCost ON dbo.COMMONTempForign.PrimaryID = dbo.MNRoCost.CostID
  AND dbo.MNROCredit.CreditRO = dbo.MNRoCost.CostRO
WHERE  (dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + @") AND (dbo.COMMONTempForign.TypeDesc = 'MNRoCost') and (dbo.MNROCredit.TimIns>=" + dblTimIns + @") ";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = @" update dbo.MNROCreditPayment set CreditID =  dbo.MNROCredit.CreditID
 FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO   and dbo.MNROCredit.CreditOrder = dbo.MNROCreditTemp.CreditOrder INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNROCreditPayment ON dbo.COMMONTempForign.PrimaryID = dbo.MNROCreditPayment.PaymentID
 and dbo.MNROCredit.CreditRO = dbo.MNROCreditPayment.CreditROID
WHERE  (dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + @") AND (dbo.COMMONTempForign.TypeDesc = 'MNROCreditPayment') AND (dbo.MNROCredit.TimIns >= " + dblTimIns + ")";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.MNROCreditDiscount set CreditID = dbo.MNROCredit.CreditID
FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO 
 and  dbo.MNROCredit.CreditOrder = dbo.MNROCreditTemp.CreditOrder
INNER JOIN
                  dbo.COMMONTempForign ON dbo.MNROCreditTemp.CreditOrder = dbo.COMMONTempForign.ForignID INNER JOIN
                  dbo.MNROCreditDiscount ON dbo.COMMONTempForign.PrimaryID = dbo.MNROCreditDiscount.CreditDiscountID
 and dbo.MNROCredit.CreditRO = dbo.MNROCreditDiscount.CreditROID 
 WHERE  (dbo.MNROCreditTemp.CreditUser = " + SysData.CurrentUser.ID + @") AND (dbo.COMMONTempForign.TypeDesc = 'MNROCreditDiscount') AND (dbo.MNROCredit.TimIns >= " + dblTimIns + ")";
            lstSql.Add(strSql);
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"update dbo.MNROCredit set CreditAncesstorID= derivedtbl_1.MaxAncesstorCredit
FROM     dbo.MNROCredit INNER JOIN
                      (SELECT TOP (100) PERCENT dbo.MNROCredit.CreditID, MAX(MNROCredit_1.CreditID) AS MaxAncesstorCredit
FROM     dbo.MNROCredit INNER JOIN
                  dbo.MNROCredit AS MNROCredit_1 ON dbo.MNROCredit.CreditRO = MNROCredit_1.CreditRO AND dbo.MNROCredit.CreditID > MNROCredit_1.CreditID INNER JOIN
                  dbo.MNROCreditTemp ON dbo.MNROCredit.CreditRO = dbo.MNROCreditTemp.CreditRO
GROUP BY dbo.MNROCredit.CreditID) AS derivedtbl_1 ON dbo.MNROCredit.CreditID = derivedtbl_1.CreditID ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void AddStrategy()
        {
            string strSql = AddStrategyStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinCondition();
        }
        public void JoinCondition()
        {
            if (_ConditionTable == null || _ConditionTable.Rows.Count == 0)
                return;

            CreditConditionDb objCondition;
            List<string> arrStr = new List<string>();
            arrStr.Add(@"delete from   dbo.MNROCreditCondition
WHERE(ConditionCredit = " + _ID + ")");
            foreach (DataRow objDr in _ConditionTable.Rows)
            {
                objCondition = new CreditConditionDb(objDr);
                objCondition.Credit = ID;
                if (objCondition.Perc > 0)
                    arrStr.Add(objCondition.AddStr);

            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }


        #endregion
    }
}
