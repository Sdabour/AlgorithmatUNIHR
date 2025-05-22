using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class MotivationStatementDb
    {
        #region Private Data
        protected int _ID;
        protected string _Desc;
        protected string _MonthName;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;
        protected DateTime _DateStartDateLimit;
        protected int _VacationDay;
        protected int _ParentID;
        protected int _MotivationType;
        protected DataTable _EstimationStatementTable;
        protected DataTable _GlobalStatementTable;
        protected DataTable _RelatedStatementTable;
        protected DataTable _RangesTable;
        protected byte _IDIncludeStatus;
        protected int _IDIncludeSearch;
        protected int _ParentIDSearch;

        int _ParentStatementID;

     
        string _ParentStatementDesc;

       
        DateTime _ParentStatementDateFrom;

       
        DateTime _ParentStatementDateTo;

    
        int _ParentStatementApplicantStatus;

       
        string _ParentStatementMonthName;

      
        int _ParentStatementVacationDay;

       
        int _ParentStatementType;

      
        string _ParentStatmentTypeNameA;

       
        string _ParentStatementTypeNameE;

       
        #endregion
        #region Constructors
        public MotivationStatementDb()
        {
        }
        public MotivationStatementDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public MotivationStatementDb(int intMotivationStatementID)
        {
            if (intMotivationStatementID == 0)
                return;
            _ID = intMotivationStatementID;
            DataTable dtTemp = Search();
            if(dtTemp.Rows.Count!=0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int ID { set { _ID = value; } get { return _ID; } }
        public string Desc { set { _Desc = value; } get { return _Desc; } }
        public string MonthName { set { _MonthName = value; } get { return _MonthName; } }
        public DateTime DateFrom { set { _DateFrom = value; } get { return _DateFrom; } }
        public DateTime DateTo { set { _DateTo = value; } get { return _DateTo; } }
        public DateTime DateStartDateLimit { set { _DateStartDateLimit = value; } get { return _DateStartDateLimit; } }
        public int VacationDay { set { _VacationDay = value; } get { return _VacationDay; } }
        public int ParentID { set { _ParentID = value; } get { return _ParentID; } }
        public int MotivationType { set { _MotivationType = value; } get { return _MotivationType; } }
        bool _IsAddedBonus;
        public bool IsAddedBonus
        {
            set => _IsAddedBonus = value;
            get => _IsAddedBonus;
        }
        public DataTable EstimationStatementTable { set { _EstimationStatementTable = value; } }
        public DataTable GlobalStatementTable { set { _GlobalStatementTable = value; } }
        public DataTable RelatedStatementTable { set { _RelatedStatementTable = value; } }
        public DataTable RangesTable
        {
            set
            {
                _RangesTable = value;
            }
        }
        public byte IDIncludeStatus { set { _IDIncludeStatus = value; } }
        public int IDIncludeSearch { set { _IDIncludeSearch = value; } }
        public int ParentIDSearch { set { _ParentIDSearch = value; } }
        public int ParentStatementID
        {
            get { return _ParentStatementID; }
            set { _ParentStatementID = value; }
        }
        public string ParentStatementDesc
        {
            get { return _ParentStatementDesc; }
            set { _ParentStatementDesc = value; }
        }
        public DateTime ParentStatementDateFrom
        {
            get { return _ParentStatementDateFrom; }
            set { _ParentStatementDateFrom = value; }
        }
        public DateTime ParentStatementDateTo
        {
            get { return _ParentStatementDateTo; }
            set { _ParentStatementDateTo = value; }
        }
        public int ParentStatementApplicantStatus
        {
            get { return _ParentStatementApplicantStatus; }
            set { _ParentStatementApplicantStatus = value; }
        }
        public string ParentStatementMonthName
        {
            get { return _ParentStatementMonthName; }
            set { _ParentStatementMonthName = value; }
        }
        public int ParentStatementVacationDay
        {
            get { return _ParentStatementVacationDay; }
            set { _ParentStatementVacationDay = value; }
        }
        public int ParentStatementType
        {
            get { return _ParentStatementType; }
            set { _ParentStatementType = value; }
        }
        public string ParentStatmentTypeNameA
        {
            get { return _ParentStatmentTypeNameA; }
            set { _ParentStatmentTypeNameA = value; }
        }
        public string ParentStatementTypeNameE
        {
            get { return _ParentStatementTypeNameE; }
            set { _ParentStatementTypeNameE = value; }
        }
        bool _Reviewed;
        public bool Reviewed { set => _Reviewed = value; }
        DataTable _UploadDataTable;

        public DataTable UploadDataTable
        {
            get { 
                return _UploadDataTable; }
            set { _UploadDataTable = value; }
        }
        int _User;
        public int User { set => _User=value; }
        public string AddStr
        {
            get
            {
                double dblDateFrom = _DateFrom.ToOADate() - 2;
                double dblDateTo = _DateTo.ToOADate() - 2;

                double dblDateStartDateLimit = _DateStartDateLimit.ToOADate() - 2;
                
                 
                string ReturnedStr = " INSERT INTO HRMotivationStatement "+
                                     " (MotivationStatementDesc, DateFrom, DateTo,DateStartDateLimit,"+
                                     " MonthName ,VacationDay,ParentID,MotivationType,MotivationIsAddedBonus, UsrIns, TimIns)" +
                                     " VALUES ('"+ _Desc +"',"+ dblDateFrom +","+ dblDateTo +","+
                                     " " + dblDateStartDateLimit + ",'" + _MonthName + "' ," + _VacationDay + "," + _ParentID + "," +
                                     " " + _MotivationType + "," + (_IsAddedBonus?1:0)+ "," + SysData.CurrentUser.ID + ", GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                double dblDateFrom = _DateFrom.ToOADate() - 2;
                double dblDateTo = _DateTo.ToOADate() - 2;
                double dblDateStartDateLimit = _DateStartDateLimit.ToOADate() - 2;
                string ReturnedStr = " UPDATE    HRMotivationStatement "+
                                     "  SET MotivationStatementDesc ='" + _Desc + "'" +
                                     " , DateFrom =" + dblDateFrom + "" +
                                     " , DateTo =" + dblDateTo + "" +
                                     " , DateStartDateLimit = " + dblDateStartDateLimit + "" +                                                                          
                                     " , MonthName ='" + _MonthName + "'" +
                                     " , VacationDay=" + _VacationDay + "" +
                                     " , ParentID = " + _ParentID + "" +
                                     " , MotivationType =" + _MotivationType + "" +
                                     ",MotivationIsAddedBonus="+ (_IsAddedBonus?1:0)+
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                     " WHERE     (MotivationStatementID = "+ _ID +")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " UPDATE    HRMotivationStatement SET Dis = GETDATE()"+
                                     " WHERE     (MotivationStatementID = "+ _ID +") ";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strParent = "SELECT        dbo.HRMotivationStatement.MotivationStatementID AS ParentMotivationStatementID, "+
                          " dbo.HRMotivationStatement.MotivationStatementDesc AS ParentMotivationStatementDesc, "+
                         " dbo.HRMotivationStatement.DateFrom AS ParentMotivationStatementDateFrom, dbo.HRMotivationStatement.DateTo AS ParentMotivationStatementDateTo, "+
                         " dbo.HRMotivationStatement.ApplicantStatus AS ParentMotivationStatementApplicantStatus,  "+
                         " dbo.HRMotivationStatement.MonthName AS ParentMotivationStatementMonthName,  "+
                         " dbo.HRMotivationStatement.VacationDay AS ParentMotivationStatementVacationDay,  "+
                         " dbo.HRMotivationStatement.MotivationType AS ParentMotivationStatementType "+
                                                 ", dbo.HRMotivationType.MotivationTypeNameA AS ParentMotivationStatmentTypeNameA, "+
                         " dbo.HRMotivationType.MotivationTypeNameE AS ParentMotivationStatementTypeNameE "+
                         " FROM            dbo.HRMotivationStatement INNER JOIN "+
                         " dbo.HRMotivationType ON dbo.HRMotivationStatement.MotivationType = dbo.HRMotivationType.MotivationTypeID ";
                string ReturnedStr = " SELECT     HRMotivationStatement.MotivationStatementID, HRMotivationStatement.MotivationStatementDesc,"+
                                     " HRMotivationStatement.DateFrom, HRMotivationStatement.DateTo," +
                                     " HRMotivationStatement.MonthName As MotivationMonthName , HRMotivationStatement.MotivationType" +
                                     " ,HRMotivationStatement.DateStartDateLimit,HRMotivationStatement.VacationDay"+
                                      ",dbo.HRMotivationStatement.MotivationIsAddedBonus " +
                                     ", HRMotivationStatement.ParentID,MotivationTypeTable.*,ParentTable.* " +
                                     " FROM         HRMotivationStatement"+
                                     " Left Outer join (" + MotivationTypeDb.SearchStr + ") as MotivationTypeTable"+
                                     " On MotivationTypeTable.MotivationTypeID = HRMotivationStatement.MotivationType "+
                                     " left outer join ("+ strParent +") as ParentTable "+
                                     " on HRMotivationStatement.ParentID = ParentTable.ParentMotivationStatementID  ";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["MotivationStatementID"].ToString());
            _Desc = objDr["MotivationStatementDesc"].ToString();
            _MonthName = objDr["MotivationMonthName"].ToString();
            _DateFrom = DateTime.Parse(objDr["DateFrom"].ToString());
            _DateTo = DateTime.Parse(objDr["DateTo"].ToString());
            _DateStartDateLimit = DateTime.Parse(objDr["DateStartDateLimit"].ToString());
            if (objDr["VacationDay"].ToString() != "")
                _VacationDay = int.Parse(objDr["VacationDay"].ToString());
            if (objDr["ParentID"].ToString() != "")
                _ParentID = int.Parse(objDr["ParentID"].ToString());
            if (objDr["MotivationType"].ToString() != "")
                _MotivationType = int.Parse(objDr["MotivationType"].ToString());

            if (objDr.Table.Columns["ParentMotivationStatementID"] != null && objDr["ParentMotivationStatementID"].ToString() != "")
                _ParentStatementID = int.Parse(objDr["ParentMotivationStatementID"].ToString());
            if (objDr.Table.Columns["ParentMotivationStatementDesc"] != null)
                _ParentStatementDesc  = objDr["ParentMotivationStatementDesc"].ToString();
            if (objDr.Table.Columns["ParentMotivationStatementDateFrom"] != null && objDr["ParentMotivationStatementDateFrom"].ToString() != "")
                _ParentStatementDateFrom = DateTime.Parse(objDr["ParentMotivationStatementDateFrom"].ToString());
            if (objDr.Table.Columns["ParentMotivationStatementDateTo"] != null && objDr["ParentMotivationStatementDateTo"].ToString() != "")
                _ParentStatementDateTo = DateTime.Parse(objDr["ParentMotivationStatementDateTo"].ToString());
            if (objDr.Table.Columns["ParentMotivationStatementApplicantStatus"] != null && objDr["ParentMotivationStatementApplicantStatus"].ToString() != "")
                _ParentStatementApplicantStatus = int.Parse(objDr["ParentMotivationStatementApplicantStatus"].ToString());
            if (objDr.Table.Columns["ParentMotivationStatementMonthName"] != null)
                _ParentStatementMonthName = objDr["ParentMotivationStatementMonthName"].ToString();
            if (objDr.Table.Columns["ParentMotivationStatementVacationDay"] != null && objDr["ParentMotivationStatementVacationDay"].ToString() != "")
                _ParentStatementVacationDay = int.Parse(objDr["ParentMotivationStatementVacationDay"].ToString());
            if (objDr.Table.Columns["ParentMotivationStatementType"] != null && objDr["ParentMotivationStatementType"].ToString() != "")
                _ParentStatementType = int.Parse(objDr["ParentMotivationStatementType"].ToString());

            if (objDr.Table.Columns["ParentMotivationStatmentTypeNameA"] != null)
                _ParentStatmentTypeNameA = objDr["ParentMotivationStatmentTypeNameA"].ToString();
            if (objDr.Table.Columns["ParentMotivationStatementTypeNameE"] != null)
                _ParentStatementTypeNameE = objDr["ParentMotivationStatementTypeNameE"].ToString();

            if(objDr.Table.Columns["MotivationIsAddedBonus"]!= null)
            bool.TryParse(objDr["MotivationIsAddedBonus"].ToString(), out _IsAddedBonus);


        }
        void JoinEstimationStatement()
        {

            string[] arrStr = new string[_EstimationStatementTable.Rows.Count + 1];
            arrStr[0] = "DELETE FROM HRMotivationStatementEstimationStatement where  (MotivationStatement = " + _ID + ")";

            if (_EstimationStatementTable == null || _EstimationStatementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                MotivationStatementEstimationStatementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _EstimationStatementTable.Rows)
                {
                    objDb = new MotivationStatementEstimationStatementDb(objDr);
                    objDb.MotivationStatement = _ID;
                    objDb.OrderVal = intIndex - 1;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinGlobalStatement()
        {
            string[] arrStr = new string[_GlobalStatementTable.Rows.Count + 1];
            arrStr[0] = "DELETE FROM HRMotivationStatementGlobalStatement where  (MotivationStatement = " + _ID + ")";

            if (_GlobalStatementTable == null || _GlobalStatementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                MotivationStatementGlobalStatementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _GlobalStatementTable.Rows)
                {
                    objDb = new MotivationStatementGlobalStatementDb(objDr);
                    objDb.MotivationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinRelatedStatement()
        {
            string[] arrStr = new string[_RelatedStatementTable.Rows.Count + 1];
            arrStr[0] = "DELETE FROM HRMotivationStatementRelatedStatement where  (MotivationStatement = " + _ID + ")";

            if (_RelatedStatementTable == null || _RelatedStatementTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                MotivationStatementRelatedStatementDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _RelatedStatementTable.Rows)
                {
                    objDb = new MotivationStatementRelatedStatementDb(objDr);
                    objDb.MotivationStatement = _ID;
                    objDb.OrderVal = intIndex - 1;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        void JoinRanges()
        {
            string[] arrStr = new string[_RangesTable.Rows.Count + 1];
            arrStr[0] = "DELETE FROM HRMotivationStatementRanges where  (MotivationStatement = " + _ID + ")";

            if (_RangesTable == null || _RangesTable.Rows.Count == 0)
            {
                //return;
            }
            else
            {
                MotivationStatementRangesDb objDb;
                int intIndex = 1;
                string strTemp = "";
                foreach (DataRow objDr in _RangesTable.Rows)
                {
                    objDb = new MotivationStatementRangesDb(objDr);
                    objDb.MotivationStatement = _ID;
                    strTemp = objDb.AddStr;
                    arrStr[intIndex] = strTemp;
                    intIndex++;
                }
            }
            SysData.SharpVisionBaseDb.ExecuteNonQuery(arrStr);
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
            JoinEstimationStatement();
            JoinGlobalStatement();
            JoinRelatedStatement();
            //JoinRanges();
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
            JoinEstimationStatement();
            JoinGlobalStatement();
            JoinRelatedStatement();
           // JoinRanges();
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
            JoinEstimationStatement();
            JoinGlobalStatement();
            JoinRelatedStatement();
            JoinRanges();
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where Dis is Null";
            if (_ID != 0)
                StrSql = StrSql + " And MotivationStatementID = " + _ID + "";

            if (_MotivationType != 0)
                StrSql = StrSql + " And MotivationType = " + _MotivationType + "";

            if (_IDIncludeStatus != 0)
            {
                StrSql = StrSql + " And MotivationStatementID <> " + _IDIncludeSearch + "";
            }
            if (_ParentIDSearch != 0)
                StrSql = StrSql + " And ParentID = " + _ParentIDSearch + "";
            StrSql += " Order By MotivationStatementID desc";//DateFrom desc";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public DataTable GetLatestMotivationStatement()
        {
            string strSql = SearchStr + " where MotivationStatementID = (select max(MotivationStatementID)  from  HRMotivationStatement where Dis is null )";
            DataTable Returned = SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
            return Returned;
        }
        public void UploadData()
        {
            if (_UploadDataTable == null || _UploadDataTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table HRTempApplicantWorkerValue ");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "HRTempApplicantWorkerValue";
            objCopy.WriteToServer(_UploadDataTable);
            string strSavedApplicant = " SELECT        Applicant, MotivationStatement "+
                         " FROM            dbo.HRApplicantWorkerMotivationStatement "+
                        " WHERE        (MotivationStatement = "+ _ID +")";
            string strNewMotivationStatement = "SELECT   derivedtbl_1.Applicant, dbo.HRMotivationStatement.MotivationStatementID, dbo.HRApplicantWorkerStatement.MotivationCostCenter, dbo.HRTempApplicantWorkerValue.Value AS MotivationValue, 0 AS IsStop,  "+
                         " '' AS Remarks, dbo.HRApplicantWorkerCurrentSubSector.JobNatureID, dbo.HRApplicantWorker.ApplicantAccountBankNo, dbo.HRApplicantWorker.ApplicantAccountBankID"+
                         ",dbo.HRApplicantWorker.ApplicantAccountBankBranchCode, dbo.HRApplicantWorker.ApplicantAccountBankAccountTypeCode"+
                         ", 0 AS DiscountValue, 0 AS BonusValue,  " +
                         " dbo.HRTempApplicantWorkerValue.Value AS MotivationValueBeforeEffect"+
                         ", dbo.HRApplicantWorkerStatement.OriginStatementID ,"+ SysData.CurrentUser.ID + " as UsrIns1,GetDate() as TimIns1 "+
                        "  FROM            ("+
                        " SELECT        dbo.HRMotivationStatementGlobalStatement.MotivationStatement, HRApplicantWorkerStatement_1.Applicant, MAX(HRApplicantWorkerStatement_1.OriginStatementID) AS MaxOriginStatement "+
                         " FROM            dbo.HRApplicantWorkerStatement AS HRApplicantWorkerStatement_1 INNER JOIN "+
                         " dbo.HRMotivationStatementGlobalStatement ON HRApplicantWorkerStatement_1.GlobalStatment = dbo.HRMotivationStatementGlobalStatement.GlobalStatement "+
                         " GROUP BY dbo.HRMotivationStatementGlobalStatement.MotivationStatement, HRApplicantWorkerStatement_1.Applicant"+
                         ") AS derivedtbl_1  "+
                         " INNER JOIN dbo.HRMotivationStatement "+
                         " ON derivedtbl_1.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID "+
                         " INNER JOIN  dbo.HRApplicantWorker "+
                         " INNER JOIN     dbo.HRApplicantWorkerStatement "+
                         " ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant "+
                         " ON derivedtbl_1.MaxOriginStatement = dbo.HRApplicantWorkerStatement.OriginStatementID "+
                         " INNER JOIN ("+
                             " SELECT        ApplicantID, MAX(ApplicantSubSectorID) AS MaxApplicantSubsSector "+
                                " FROM            dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 "+
                                " GROUP BY ApplicantID) AS derivedtbl_2 ON dbo.HRApplicantWorker.ApplicantID = derivedtbl_2.ApplicantID INNER JOIN "+
                         " dbo.HRApplicantWorkerCurrentSubSector ON derivedtbl_2.MaxApplicantSubsSector = dbo.HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID AND "+
                         " derivedtbl_2.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN "+
                         " dbo.HRTempApplicantWorkerValue ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValue.ApplicantCode "+
                       " left outer join ("+ strSavedApplicant + ") as MotivationTable "+
                       " on dbo.HRApplicantWorker.ApplicantID = MotivationTable.Applicant  "+
                         " WHERE       MotivationTable.Applicant is null and  (dbo.HRMotivationStatement.MotivationStatementID = "+ _ID +")";
            string strSql = "insert into HRApplicantWorkerMotivationStatement (Applicant, MotivationStatement, CostCenter, MotivationValue, IsStop, Remarks, JobNatureTypeID, AccountBankNo, AccountBankID,BankBranchCode, AccountTypeCode, DiscountValue, BonusValue, MotivationValueBeforeEffect,  " +
                         " MotivationStatementOriginStatement, UsrIns, TimIns) "+
                         strNewMotivationStatement ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update        HRApplicantWorkerMotivationStatement "+
                " set MotivationValue = dbo.HRTempApplicantWorkerValue.Value"+
                ", dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect = dbo.HRTempApplicantWorkerValue.Value "+
                " FROM            dbo.HRTempApplicantWorkerValue INNER JOIN "+
                " dbo.HRApplicantWorker ON dbo.HRTempApplicantWorkerValue.ApplicantCode = dbo.HRApplicantWorker.ApplicantCode INNER JOIN "+
               " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant "+
               " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = "+ ID +") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.HRApplicantWorkerMotivationStatement set IsFellowship =1 "+
                ",FellowshipFund = CASE WHEN isnull(FellowshipRoleTable.RoleFellowshipValue, 0) "+
                         " = 0 THEN isnull(FellowshipRoleTable.RoleFellowshipPerc, 0) * dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect / 100 ELSE isnull(FellowshipRoleTable.RoleFellowshipValue, 0)  "+
                         " END ,FellowshipFundBonus = 0 "+ 
                    " FROM            dbo.HRApplicantWorker INNER JOIN "+
                         " dbo.HRTempApplicantWorkerValue ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValue.ApplicantCode INNER JOIN "+
                         " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN "+
                         " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN"+
                         " dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID INNER JOIN "+
                             " ("+
                             "SELECT  RoleJobNature, RoleDesc, RoleStartSalary, RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue "+
                                " FROM    dbo.HRFellowshipRole "+
                                " WHERE  (RoleSalaryOrMotivation = 1) AND (isnull(RoleJobNature,0) =0)"+
                                ") AS FellowshipRoleTable "+
                                " ON  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect >= FellowshipRoleTable.RoleStartSalary "+
                                " AND  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect <= FellowshipRoleTable.RoleEndSalary "+
                                //" AND dbo.HRJobNatureType.JobNatureID = FellowshipRoleTable.RoleJobNature " +
                        " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = "+ _ID +") and  (dbo.HRApplicantWorker.IsFellowShip=1) "+
                        " and ( dbo.HRApplicantWorker.ApplicantCurrentSalary = 0 or ( dbo.HRApplicantWorker.FellowShipSalaryOrMotivation =1)) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.HRApplicantWorkerMotivationStatement set IsFellowship =1 " +
               ",FellowshipFund = CASE WHEN isnull(FellowshipRoleTable.RoleFellowshipValue, 0) " +
                        " = 0 THEN isnull(FellowshipRoleTable.RoleFellowshipPerc, 0) * dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect / 100 ELSE isnull(FellowshipRoleTable.RoleFellowshipValue, 0)  " +
                        " END ,FellowshipFundBonus = 0 " +
                   " FROM            dbo.HRApplicantWorker INNER JOIN " +
                        " dbo.HRTempApplicantWorkerValue ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValue.ApplicantCode INNER JOIN " +
                        " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN " +
                        " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN" +
                        " dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID INNER JOIN " +
                            " (" +
                            "SELECT  RoleJobNature, RoleDesc, RoleStartSalary, RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue " +
                               " FROM    dbo.HRFellowshipRole " +
                               " WHERE  (RoleSalaryOrMotivation = 1) AND (isnull(RoleJobNature,0)>0)" +
                               ") AS FellowshipRoleTable " +
                               " ON  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect >= FellowshipRoleTable.RoleStartSalary " +
                               " AND  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect <= FellowshipRoleTable.RoleEndSalary " +
                 " AND dbo.HRJobNatureType.JobNatureID = FellowshipRoleTable.RoleJobNature " +
                       " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + _ID + ") and  (dbo.HRApplicantWorker.IsFellowShip=1) " +
                       " and ( dbo.HRApplicantWorker.ApplicantCurrentSalary = 0 or ( dbo.HRApplicantWorker.FellowShipSalaryOrMotivation =1)) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update dbo.HRApplicantWorkerMotivationStatement set MotivationValue = MotivationValueBeforeEffect + "+
                         " BonusValue - (DiscountValue+FellowshipFund+FellowshipFundBonus) " +
                         " FROM            dbo.HRApplicantWorker INNER JOIN "+
                         " dbo.HRTempApplicantWorkerValue ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValue.ApplicantCode INNER JOIN "+
                         " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN "+
                            " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID "+
                        " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement ="+ _ID +")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }

        public void UploadDataUser()
        {
            if (_UploadDataTable == null || _UploadDataTable.Rows.Count == 0)
                return;
            int intReviewed = _Reviewed ? 1 : 0;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("delete from HRTempApplicantWorkerValueUser where CurrentUser ="+_User);
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "HRTempApplicantWorkerValueUser";
            objCopy.WriteToServer(_UploadDataTable);
            string strSavedApplicant = " SELECT        Applicant, MotivationStatement " +
                         " FROM            dbo.HRApplicantWorkerMotivationStatement " +
                        " WHERE        (MotivationStatement = " + _ID + ")";

            string strNewMotivationStatement = "SELECT   derivedtbl_1.Applicant, dbo.HRMotivationStatement.MotivationStatementID, dbo.HRApplicantWorkerStatement.MotivationCostCenter, dbo.HRTempApplicantWorkerValueUser.Value AS MotivationValue, 0 AS IsStop,  " +
                         " '' AS Remarks, dbo.HRApplicantWorkerCurrentSubSector.JobNatureID, dbo.HRApplicantWorker.ApplicantAccountBankNo, dbo.HRApplicantWorker.ApplicantAccountBankID" +
                         ",dbo.HRApplicantWorker.ApplicantAccountBankBranchCode, dbo.HRApplicantWorker.ApplicantAccountBankAccountTypeCode" +
                         ", 0 AS DiscountValue, 0 AS BonusValue,  " +
                         " dbo.HRTempApplicantWorkerValueUser.Value AS MotivationValueBeforeEffect" +
                         ", dbo.HRApplicantWorkerStatement.OriginStatementID,"+intReviewed+@" ," + SysData.CurrentUser.ID + " as UsrIns1,GetDate() as TimIns1 " +
                        "  FROM            (" +
                        " SELECT        dbo.HRMotivationStatementGlobalStatement.MotivationStatement, HRApplicantWorkerStatement_1.Applicant, MAX(HRApplicantWorkerStatement_1.OriginStatementID) AS MaxOriginStatement " +
                         " FROM            dbo.HRApplicantWorkerStatement AS HRApplicantWorkerStatement_1 INNER JOIN " +
                         " dbo.HRMotivationStatementGlobalStatement ON HRApplicantWorkerStatement_1.GlobalStatment = dbo.HRMotivationStatementGlobalStatement.GlobalStatement " +
                         " GROUP BY dbo.HRMotivationStatementGlobalStatement.MotivationStatement, HRApplicantWorkerStatement_1.Applicant" +
                         ") AS derivedtbl_1  " +
                         " INNER JOIN dbo.HRMotivationStatement " +
                         " ON derivedtbl_1.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID " +
                         " INNER JOIN  dbo.HRApplicantWorker " +
                         " INNER JOIN     dbo.HRApplicantWorkerStatement " +
                         " ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerStatement.Applicant " +
                         " ON derivedtbl_1.MaxOriginStatement = dbo.HRApplicantWorkerStatement.OriginStatementID " +
                         " INNER JOIN (" +
                             " SELECT        ApplicantID, MAX(ApplicantSubSectorID) AS MaxApplicantSubsSector " +
                                " FROM            dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 " +
                                " GROUP BY ApplicantID) AS derivedtbl_2 ON dbo.HRApplicantWorker.ApplicantID = derivedtbl_2.ApplicantID INNER JOIN " +
                         " dbo.HRApplicantWorkerCurrentSubSector ON derivedtbl_2.MaxApplicantSubsSector = dbo.HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID AND " +
                         " derivedtbl_2.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN " +
                         " dbo.HRTempApplicantWorkerValueUser ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueUser.ApplicantCode " +
                       " left outer join (" + strSavedApplicant + ") as MotivationTable " +
                       " on dbo.HRApplicantWorker.ApplicantID = MotivationTable.Applicant  " +
                         " WHERE       MotivationTable.Applicant is null and  (dbo.HRMotivationStatement.MotivationStatementID = " + _ID + ") and (dbo.HRTempApplicantWorkerValueUser.CurrentUser="+_User+")";
            string strSql = "insert into HRApplicantWorkerMotivationStatement (Applicant, MotivationStatement, CostCenter, MotivationValue, IsStop, Remarks, JobNatureTypeID, AccountBankNo, AccountBankID,BankBranchCode, AccountTypeCode, DiscountValue, BonusValue, MotivationValueBeforeEffect,  " +
                         " MotivationStatementOriginStatement,MotivationStatementReview, UsrIns, TimIns) " +
                         strNewMotivationStatement;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update        HRApplicantWorkerMotivationStatement " +
                " set MotivationValue = dbo.HRTempApplicantWorkerValueUser.Value" +
                ", dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect = dbo.HRTempApplicantWorkerValueUser.Value,MotivationStatementReview ="+intReviewed +
                " FROM            dbo.HRTempApplicantWorkerValueUser INNER JOIN " +
                " dbo.HRApplicantWorker ON dbo.HRTempApplicantWorkerValueUser.ApplicantCode = dbo.HRApplicantWorker.ApplicantCode INNER JOIN " +
               " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant " +
               " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + ID + ") and (dbo.HRTempApplicantWorkerValueUser.CurrentUser="+_User+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.HRApplicantWorkerMotivationStatement set IsFellowship =1 " +
                ",FellowshipFund = CASE WHEN isnull(FellowshipRoleTable.RoleFellowshipValue, 0) " +
                         " = 0 THEN isnull(FellowshipRoleTable.RoleFellowshipPerc, 0) * dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect / 100 ELSE isnull(FellowshipRoleTable.RoleFellowshipValue, 0)  " +
                         " END ,FellowshipFundBonus = 0 " +
                         ",MotivationStatementReview=" +intReviewed+
                    " FROM            dbo.HRApplicantWorker INNER JOIN " +
                         " dbo.HRTempApplicantWorkerValueUser ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueUser.ApplicantCode INNER JOIN " +
                         " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN " +
                         " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN" +
                         " dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID INNER JOIN " +
                             " (" +
                             "SELECT  RoleJobNature, RoleDesc, RoleStartSalary, RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue " +
                                " FROM    dbo.HRFellowshipRole " +
                                " WHERE  (RoleSalaryOrMotivation = 1) AND (isnull(RoleJobNature,0) =0)" +
                                ") AS FellowshipRoleTable " +
                                " ON  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect >= FellowshipRoleTable.RoleStartSalary " +
                                " AND  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect <= FellowshipRoleTable.RoleEndSalary " +
                        //" AND dbo.HRJobNatureType.JobNatureID = FellowshipRoleTable.RoleJobNature " +
                        " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + _ID + ") and (dbo.HRApplicantWorkerMotivationStatement.MotivationStatementReview = 0) and  (dbo.HRApplicantWorker.IsFellowShip=1) " +
                        " and ( dbo.HRApplicantWorker.ApplicantCurrentSalary = 0 or ( dbo.HRApplicantWorker.FellowShipSalaryOrMotivation =1)) and dbo.HRTempApplicantWorkerValueUser.CurrentUser= "+_User;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update   dbo.HRApplicantWorkerMotivationStatement set IsFellowship =1 " +
               ",FellowshipFund = CASE WHEN isnull(FellowshipRoleTable.RoleFellowshipValue, 0) " +
                        " = 0 THEN isnull(FellowshipRoleTable.RoleFellowshipPerc, 0) * dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect / 100 ELSE isnull(FellowshipRoleTable.RoleFellowshipValue, 0)  " +
                        " END ,FellowshipFundBonus = 0 " +
                   " FROM            dbo.HRApplicantWorker INNER JOIN " +
                        " dbo.HRTempApplicantWorkerValueUser ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueUser.ApplicantCode INNER JOIN " +
                        " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN " +
                        " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID INNER JOIN" +
                        " dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID INNER JOIN " +
                            " (" +
                            "SELECT  RoleJobNature, RoleDesc, RoleStartSalary, RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue " +
                               " FROM    dbo.HRFellowshipRole " +
                               " WHERE  (RoleSalaryOrMotivation = 1) AND (isnull(RoleJobNature,0)>0)" +
                               ") AS FellowshipRoleTable " +
                               " ON  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect >= FellowshipRoleTable.RoleStartSalary " +
                               " AND  dbo.HRApplicantWorkerMotivationStatement.MotivationValueBeforeEffect <= FellowshipRoleTable.RoleEndSalary " +
                 " AND dbo.HRJobNatureType.JobNatureID = FellowshipRoleTable.RoleJobNature " +
                       " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = " + _ID + ") and  (dbo.HRApplicantWorker.IsFellowShip=1) " +
                       " and ( dbo.HRApplicantWorker.ApplicantCurrentSalary = 0 or ( dbo.HRApplicantWorker.FellowShipSalaryOrMotivation =1)) and (dbo.HRTempApplicantWorkerValueUser.CurrentUser="+_User+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = " update dbo.HRApplicantWorkerMotivationStatement set MotivationValue = MotivationValueBeforeEffect + " +
                         " BonusValue - (DiscountValue+FellowshipFund+FellowshipFundBonus) " +
                         " FROM            dbo.HRApplicantWorker INNER JOIN " +
                         " dbo.HRTempApplicantWorkerValueUser ON dbo.HRApplicantWorker.ApplicantCode = dbo.HRTempApplicantWorkerValueUser.ApplicantCode INNER JOIN " +
                         " dbo.HRApplicantWorkerMotivationStatement ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerMotivationStatement.Applicant INNER JOIN " +
                            " dbo.HRApplicantWorkerCurrentSubSector ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicantWorkerCurrentSubSector.ApplicantID " +
                        " WHERE        (dbo.HRApplicantWorkerMotivationStatement.MotivationStatement =" + _ID + ")  and (dbo.HRTempApplicantWorkerValueUser.CurrentUser=" + _User + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);



        }
        #endregion
    }
}
