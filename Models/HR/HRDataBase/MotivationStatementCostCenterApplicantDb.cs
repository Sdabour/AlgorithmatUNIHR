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
    public class MotivationStatementCostCenterApplicantDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _CostCenter;
        protected int _Applicant;
        protected string _ApplicantIDs;
        protected bool _IsSpecialCase;
        byte _IsSpecialCaseSearch;
        int _StatementStatus;

        public int StatementStatus
        {
            get { return _StatementStatus; }
            set { _StatementStatus = value; }
        }
        #endregion
        #region Constructors
        public MotivationStatementCostCenterApplicantDb()
        {
        }
        public MotivationStatementCostCenterApplicantDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int CostCenter { set { _CostCenter = value; } get { return _CostCenter; } }
        string _CostCeneterIDs;
        public string CostCenterIDs { set => _CostCeneterIDs = value; }
        public int Applicant { set { _Applicant = value; } get { return _Applicant; } }
        public bool IsSpecialCase { set { _IsSpecialCase = value; } get { return _IsSpecialCase; } }
        public string ApplicantIDs { set { _ApplicantIDs = value; } }
        public byte IsSpecialCaseSearch { set { _IsSpecialCaseSearch = value; } }       

        public string AddStr
        {
            get
            {
                int intIsSpecialCase = _IsSpecialCase ? 1 : 0;
                string ReturnedStr = " INSERT INTO HRMotivationStatementCostCenterApplicant " +
                                     " (MotivationStatement, CostCenter,Applicant,IsSpecialCase)" +
                                     " VALUES (" + _MotivationStatement + "," + _CostCenter + "," + _Applicant + "," + intIsSpecialCase + ")";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                
               
                string ReturnedStr = " ";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " Delete From HRMotivationStatementCostCenterApplicant " +
                                     " Where  MotivationStatement = " + _MotivationStatement + "" +
                                     " And CostCenter = " + _CostCenter + "";
                if (_Applicant != 0)
                    ReturnedStr += " And Applicant = " + _Applicant + "";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strStatementJobNatureCategory = "SELECT  dbo.HRApplicantWorkerStatement.OriginStatementID, dbo.HRJobNatureType.JobNatureNameA AS StatementJobNatureNameA, dbo.HRJobCategory.OrderValue AS StatementJobCategoryOrder "+
                     " FROM            dbo.HRJobCategory RIGHT OUTER JOIN "+
                     " dbo.HRJobNatureType ON dbo.HRJobCategory.JobCategoryID = dbo.HRJobNatureType.JobCategory RIGHT OUTER JOIN "+
                      " dbo.HRApplicantWorkerStatement ON dbo.HRJobNatureType.JobNatureID = dbo.HRApplicantWorkerStatement.JobNature";
                string strMinStatement = "SELECT   derivedtbl_1.MotivationStatement AS MSMotivationStatement, derivedtbl_1.Applicant AS MSApplicant, dbo.HRApplicantWorkerStatement.OriginStatementID AS MSID, "+
                         " dbo.HRJobNatureType.JobNatureNameA AS MSJN, dbo.HRJobCategory.OrderValue AS MSJCOrder "+
                         " FROM            dbo.HRApplicantWorkerStatement INNER JOIN "+
                         " (SELECT        dbo.HRMotivationStatementGlobalStatement.MotivationStatement, MIN(HRApplicantWorkerStatement_1.OriginStatementID) AS MinOriginStatement, HRApplicantWorkerStatement_1.Applicant "+
                         " FROM            dbo.HRMotivationStatementGlobalStatement INNER JOIN "+
                         " dbo.HRApplicantWorkerStatement AS HRApplicantWorkerStatement_1 ON dbo.HRMotivationStatementGlobalStatement.GlobalStatement = HRApplicantWorkerStatement_1.GlobalStatment "+
                         " GROUP BY dbo.HRMotivationStatementGlobalStatement.MotivationStatement, HRApplicantWorkerStatement_1.Applicant) AS derivedtbl_1 ON  "+
                         " dbo.HRApplicantWorkerStatement.OriginStatementID = derivedtbl_1.MinOriginStatement LEFT OUTER JOIN "+
                         " dbo.HRJobNatureType ON dbo.HRApplicantWorkerStatement.JobNature = dbo.HRJobNatureType.JobNatureID LEFT OUTER JOIN "+
                         " dbo.HRJobCategory ON dbo.HRJobNatureType.JobCategory = dbo.HRJobCategory.JobCategoryID ";

                string strMotivationStatement = "SELECT        dbo.HRApplicantWorkerMotivationStatement.Applicant, MAX(dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID) AS LastMotivationStatementID "+
                               " FROM            dbo.HRApplicantWorkerMotivationStatement INNER JOIN "+
                                " dbo.HRMotivationStatement ON dbo.HRApplicantWorkerMotivationStatement.MotivationStatement = dbo.HRMotivationStatement.MotivationStatementID "+
                                " GROUP BY dbo.HRApplicantWorkerMotivationStatement.Applicant";
                string ReturnedStr = " SELECT distinct HRMotivationStatementCostCenterApplicant.MotivationStatement, "+
                                     " HRMotivationStatementCostCenterApplicant.CostCenter,"+
                                     " HRMotivationStatementCostCenterApplicant.IsSpecialCase," +
                                     " HRMotivationStatementCostCenterApplicant.Applicant,ApplicantWorkerTable.* " +
                                     ",  dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID AS LastMotivationStatementID "+
                                    //",isnull(StatementJobNatureNameA,SectorJobNatureNameA) as OrderJobNatureNameA" +
                                    //",isnull(StatementJobCategoryOrder ,SectorJobCategoryOrder) as OrderJobCategoryOrder  " +
                                      ",case when OriginStatementID is not null then StatementJobNatureNameA when MSID is not null then MSJN else SectorJobNatureNameA end as OrderJobNatureNameA" +
                                    ",case when OriginStatementID is not null then  StatementJobCategoryOrder when MSID is not null  then MSJCOrder  else SectorJobCategoryOrder end as OrderJobCategoryOrder  " +
                                     ",StatementJobNatureNameA as OrderJobNatureNameA1" +
                                    ",StatementJobCategoryOrder as OrderJobCategoryOrder1  " +
                                    ",LastMotivationTable.LastMotivationStatementID "+
                                     " FROM         HRMotivationStatementCostCenterApplicant "+
                                     " Inner Join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable "+
                                     " On ApplicantWorkerTable.ApplicantID = HRMotivationStatementCostCenterApplicant.Applicant"+
                                     " left outer join        dbo.HRApplicantWorkerMotivationStatement "+
                                     " ON     dbo.HRMotivationStatementCostCenterApplicant.Applicant = dbo.HRApplicantWorkerMotivationStatement.Applicant AND "+
                                    " dbo.HRMotivationStatementCostCenterApplicant.MotivationStatement = dbo.HRApplicantWorkerMotivationStatement.MotivationStatement "+
                                    " LEFT OUTER JOIN   dbo.HRMotivationStatementCostCenterTree "+
                                    " ON  dbo.HRMotivationStatementCostCenterApplicant.MotivationStatement = dbo.HRMotivationStatementCostCenterTree.MotivationStatement "+
                                    " AND dbo.HRMotivationStatementCostCenterApplicant.CostCenter = dbo.HRMotivationStatementCostCenterTree.CostCenter "+
                                    " left outer join ("+strStatementJobNatureCategory+") as StatementCategoryTable "+
                                    " on dbo.HRApplicantWorkerMotivationStatement.MotivationStatementOriginStatement = StatementCategoryTable.OriginStatementID "+
                                    " left outer join (" + strMinStatement  + ") as MSTable "+
                                    " on ApplicantWorkerTable.ApplicantID = MSTable.MSApplicant "+
                                    " and  HRMotivationStatementCostCenterApplicant.MotivationStatement = MSTable.MSMotivationStatement  "+
                                    " left outer join ("+ strMotivationStatement +") as LastMotivationTable "+
                                    " on  ApplicantWorkerTable.ApplicantID = LastMotivationTable.Applicant ";
                                     
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _CostCenter = int.Parse(objDr["CostCenter"].ToString());
            _Applicant = int.Parse(objDr["Applicant"].ToString());
            if (objDr["IsSpecialCase"].ToString() != "")
                _IsSpecialCase = bool.Parse(objDr["IsSpecialCase"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);           
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
            if (_MotivationStatement != 0)
                StrSql = StrSql + " And HRMotivationStatementCostCenterApplicant.MotivationStatement = " + _MotivationStatement + "";
            if (_CostCenter != 0)
                StrSql = StrSql + " And (HRMotivationStatementCostCenterApplicant.CostCenter = " + _CostCenter +
                    " or  dbo.HRMotivationStatementCostCenterTree.CostCenterParent ="+ _CostCenter +" )";
            if (_CostCenter != null&&_CostCeneterIDs!="")
                StrSql = StrSql + " And (HRMotivationStatementCostCenterApplicant.CostCenter in (" + _CostCeneterIDs +
                    ") or  dbo.HRMotivationStatementCostCenterTree.CostCenterParent in(" + _CostCeneterIDs + ") )";
            if (_Applicant != 0)
                StrSql = StrSql + " And Applicant = " + _Applicant + "";
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                StrSql = StrSql + " And Applicant in ( " + _ApplicantIDs + ")";
            if (_IsSpecialCaseSearch != 0)
            {
                if (_IsSpecialCaseSearch == 1)
                    StrSql += " and (IsSpecialCase = 0)";
                else if (_IsSpecialCaseSearch == 2)
                    StrSql += " and (IsSpecialCase = 1)";
            }
            if (_StatementStatus == 1)
            {
                StrSql += " and dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID is not null ";
            }
            if (_StatementStatus == 2)
            {
                StrSql += " and dbo.HRApplicantWorkerMotivationStatement.ApplicantMotivationStatementID is   null ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }        
        #endregion
    }
}
