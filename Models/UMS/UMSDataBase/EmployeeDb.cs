using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.UMS.UMSDataBase
{
    public class EmployeeDb
    {
        #region Private Data
        protected int _ID;
        protected string _Code;
        protected string _Name;
        protected int _UserID;
        protected string _FamousName;
        protected string _ShortName;

        protected int _Status;
        protected int _BranchID;
        protected string _BranchName;
        protected int _CofferID;
        protected string _CofferName;
        protected string _CofferCode;
        protected DateTime _EndDate;
        protected bool _IsEnded;
        protected int _WorkingStatus;
        protected string _DepartmentIDs;
        protected string _IDs;
        string _CodeLike;
        int _DepartmentID;
        int _WorkGroupID;
        #endregion
        #region Constructors
        public EmployeeDb()
        { 

        }
        public EmployeeDb(DataRow objDr)
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
        public string Name
        {
            set
            {
                _Name = value;
            }
            get
            {
                return _Name;
            }
        }
        public int UserID
        {
            set
            {
                _UserID = value;
            }
            get
            {
                return _UserID;
            }
        }
        public string FamousName
        {
            set
            {
                _FamousName = value;
            }
            get
            {
                if (_FamousName == null)
                    _FamousName = "";
                return _FamousName;
            }
        }
        public string ShortName
        {
            set
            {
                _ShortName = value;
            }
            get
            {
                if (_ShortName == null)
                    _ShortName = "";
                return _ShortName;
            }
        }
        public int Status
        {
            set
            {
                _Status = value;
            }
            get
            {
                return _Status;
            }
        }
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
        public int BranchID
        {
            set
            {
                _BranchID = value;
            }
            get
            {
                return _BranchID;
            }
        }
        public string BranchName
        {
            set
            {
                _BranchName = value;
            }
            get
            {
                return _BranchName;
            }
        }
        string _SectorName;
        public string SectorName
        {
            set { _SectorName = value; }
            get { return _SectorName; }
        }
        string _SectorName1;
        public string SectorName1
        {
            set { _SectorName1 = value; }
            get { return _SectorName1; }
        }
        string _SectorName2;
        public string SectorName2
        {
            set { _SectorName2 = value; }
            get { return _SectorName2; }
        }
        string _JobNature;
        public string JobNature
        {
            set { _JobNature = value; }
            get { return _JobNature; }
        }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; get => _StartDate; }
        public int DepartmentID
        {
            set
            {
                _DepartmentID = value;
            }
            get
            {
                return _DepartmentID;
            }
        }
        public int WorkGroupID
        {
            set
            {
                _WorkGroupID = value;
            }
            get
            {
                return _WorkGroupID;
            }
        }
        public int CofferID
        {
            set
            {
                _CofferID = value;
            }
            get
            {
                return _CofferID;
            }
        }
        public string CofferName
        {
            set
            {
                _CofferName = value;
            }
            get
            {
                return _CofferName;
            }
        }
        public string CofferCode
        {
            set
            {
                _CofferCode = value;
            }
            get
            {
                return _CofferCode;
            }
        }
        public string DepartmentIDs
        {
            set
            {
                _DepartmentIDs = value;
            }

        }
        public string IDs
        {
            set
            {
                _IDs = value;
            }
        }
        public int WorkingStatus
        {
            set
            {
                _WorkingStatus = value;
            }
        }
        public string CodeLike
        {
            set
            {
                _CodeLike = value;
            }
        }
        public bool IsEnded
        {
            get
            {
                return _IsEnded;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = "";

                return Returned;
            }

        }
        int _SectorID;
        public int SectorID { set => _SectorID = value; }
        public string SectorSearchStr
        {
            get
            {
                string Returned = @"WITH SectorTable(SectorID, SectorNameA, SectorParentID, SLevel) AS (SELECT        SectorID, SectorNameA, SectorParentID, 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector
                                                                                                                                                           WHERE        (SectorID IN (" + _SectorID + @"))
                                                                                                                                                           UNION ALL
                                                                                                                                                           SELECT        HRSector_1.SectorID, HRSector_1.SectorNameA, HRSector_1.SectorParentID, SectorTable_2.SLevel + 1 AS SLevel
                                                                                                                                                           FROM            dbo.HRSector AS HRSector_1 INNER JOIN
                                                                                                                                                                                    SectorTable AS SectorTable_2 ON HRSector_1.SectorParentID = SectorTable_2.SectorID)  select SectorTable.* from SectorTable ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strSales = "SELECT   dbo.CRMSalesMan.ApplicantID AS SalesManID, dbo.HRBranch.BranchID AS SalesBranchID, dbo.HRBranch.BranchNameA AS SalesBranchName " +
                    " FROM   dbo.CRMSalesMan INNER JOIN " +
                    " dbo.HRBranch ON dbo.CRMSalesMan.BranchID = dbo.HRBranch.BranchID ";
                //strSales = "";
                string strMaxSubSector = @"SELECT     ApplicantID, MAX(SubSectorID) AS ApplicantSubSector " +
                      " FROM         dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1 " +
                      "  GROUP BY ApplicantID";
                string strApplicantSubSector = @"SELECT dbo.HRApplicantWorkerCurrentSubSector.ApplicantID AS SubSectorEmployee, dbo.HRApplicantWorkerCurrentSubSector.SubSectorID, dbo.HRApplicantWorkerCurrentSubSector.Description AS EmployeeJobDesc, 
                  dbo.HRJobNatureType.JobNatureNameA AS EmployeeJObNatureName, dbo.HRSector.SectorNameA AS EmployeeSectorName
FROM     dbo.HRApplicantWorkerCurrentSubSector INNER JOIN
                  dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                  dbo.HRSector ON dbo.HRSubSector.SectorID = dbo.HRSector.SectorID LEFT OUTER JOIN
                  dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID";
                string strCurrentBranch = "SELECT     CurrentTAble.ApplicantID CurrentApplicant, dbo.HRBranch.BranchID AS ApplicantBranchID" +
                    ", dbo.HRBranch.BranchNameA AS ApplicantBranchName,dbo.HRSubSector.SectorID as DepartmentID " +
                   " FROM         (" + strMaxSubSector + @") AS CurrentTAble " +
                      " INNER JOIN  dbo.HRSubSector " +
                      " ON CurrentTAble.ApplicantSubSector = dbo.HRSubSector.SubSectorID " +
                      " INNER JOIN  dbo.HRSubSectorBranch  ON dbo.HRSubSector.SubSectorID = dbo.HRSubSectorBranch.SubSectorID INNER JOIN " +
                      @" dbo.HRBranch ON dbo.HRSubSectorBranch.BranchID = dbo.HRBranch.BranchID  ";
                //inner join ("+ strApplicantSubSector +@") as AppliantSubSectorTable 
                //   on CurrentTAble.ApplicantID = AppliantSubSectorTable.SubSectorEmployee and   dbo.HRSubSector.SubSectorID= AppliantSubSectorTable.SubSectorID ";

                strCurrentBranch = @"SELECT        CurrentTAble.ApplicantID AS CurrentApplicant, dbo.HRBranch.BranchID AS ApplicantBranchID, dbo.HRBranch.BranchNameA AS ApplicantBranchName, dbo.HRSubSector.SectorID AS DepartmentID, 
                         dbo.HRSector.SectorNameA AS SectorName, HRSector_1.SectorNameA AS SectorName1, HRSector_2.SectorNameA AS SectorName2, ISNULL(dbo.HRJobNatureType.JobNatureNameA, '') AS JobNature
FROM            dbo.HRApplicantWorkerCurrentSubSector INNER JOIN
                             (SELECT        ApplicantID, MAX(SubSectorID) AS ApplicantSubSector, MAX(ApplicantSubSectorID) AS MaxApplicantSubSectorID
                                FROM            dbo.HRApplicantWorkerCurrentSubSector AS HRApplicantWorkerCurrentSubSector_1
                                GROUP BY ApplicantID) AS CurrentTAble ON dbo.HRApplicantWorkerCurrentSubSector.ApplicantID = CurrentTAble.ApplicantID AND 
                         dbo.HRApplicantWorkerCurrentSubSector.ApplicantSubSectorID = CurrentTAble.MaxApplicantSubSectorID INNER JOIN
                         dbo.HRSubSectorBranch INNER JOIN
                         dbo.HRSubSector ON dbo.HRSubSectorBranch.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                         dbo.HRBranch ON dbo.HRSubSectorBranch.BranchID = dbo.HRBranch.BranchID ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                         dbo.HRSector ON dbo.HRSubSector.SectorID = dbo.HRSector.SectorID INNER JOIN
                         dbo.HRSector AS HRSector_1 ON dbo.HRSector.SectorParentID = HRSector_1.SectorID INNER JOIN
                         dbo.HRSector AS HRSector_2 ON HRSector_1.SectorParentID = HRSector_2.SectorID LEFT OUTER JOIN
                         dbo.HRJobNatureType ON dbo.HRApplicantWorkerCurrentSubSector.JobNatureID = dbo.HRJobNatureType.JobNatureID";
                string strWorkGroup = "SELECT derivedtbl_1.WorkGroupApplicant, dbo.HRWorkGroupApplicant.WorkGroupID " +
                        " FROM   dbo.HRWorkGroupApplicant INNER JOIN " +
                        " (SELECT     WorkGroupApplicant, MAX(WorkGroupApplicantID) AS MaxWorkGroupApplicant " +
                         " FROM         dbo.HRWorkGroupApplicant AS HRWorkGroupApplicant_1 " +
                         " GROUP BY WorkGroupApplicant) AS derivedtbl_1 ON dbo.HRWorkGroupApplicant.WorkGroupApplicantID = derivedtbl_1.MaxWorkGroupApplicant AND  " +
                         " dbo.HRWorkGroupApplicant.WorkGroupApplicant = derivedtbl_1.WorkGroupApplicant ";

                string Returned = "SELECT  dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode" +
                    ", dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicant.ApplicantFamousName,dbo.HRApplicant.ApplicantShortName " +
                      ",dbo.HRApplicantWorker.ApplicantStartDate, dbo.HRApplicant.ApplicantNameComp, dbo.HRApplicantWorker.ApplicantUser, dbo.HRApplicantWorker.ApplicantStatusID " +
                      ",dbo.HRApplicantWorker.ApplicantEndDate,SalesManTable.*" +
                      ",CurrentBranchTable.*,WorkGroupTable.WorkGroupID  " +
                      " FROM   dbo.HRApplicant INNER JOIN " +
                      " dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID" +
                      " left outer join (" + strSales + ") as SalesManTable on  dbo.HRApplicant.ApplicantID = SalesManTable.SalesManID " +
                      " left outer join (" + strCurrentBranch + ") as CurrentBranchTable " +
                      " on dbo.HRApplicant.ApplicantID = CurrentBranchTable.CurrentApplicant  " +
                      " left outer join (" + strWorkGroup + ") as WorkGroupTable " +
                      " on  dbo.HRApplicant.ApplicantID = WorkGroupTable.WorkGroupApplicant ";

                return Returned;
            }
        }
        #endregion
        #region Private Methods

        protected void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["ApplicantID"].ToString()); 
            _Code = objDr["ApplicantCode"].ToString();
            _Name = objDr["ApplicantFirstName"].ToString();
            _FamousName = objDr["ApplicantFamousName"].ToString();
            _ShortName = objDr["ApplicantShortName"].ToString();
            if(objDr["ApplicantUser"].ToString()!= "")
            _UserID = int.Parse( objDr["ApplicantUser"].ToString());
            _Status = int.Parse(objDr["ApplicantStatusID"].ToString());
            if (objDr["SalesBranchID"].ToString() != "")
            {
                _BranchID = int.Parse(objDr["SalesBranchID"].ToString());
                _BranchName = objDr["SalesBranchName"].ToString();
            }
            else if (objDr["CurrentApplicant"].ToString() != "")
            {
                _BranchID = int.Parse(objDr["ApplicantBranchID"].ToString());
                _BranchName = objDr["ApplicantBranchName"].ToString();
            }
            _IsEnded = false;
            if (objDr["ApplicantEndDate"].ToString() != "")
            {
               _EndDate = DateTime.Parse(objDr["ApplicantEndDate"].ToString());
               _IsEnded = true;

            }
            if (objDr.Table.Columns["DepartmentID"] != null && objDr["DepartmentID"].ToString() != "")
                _DepartmentID = int.Parse(objDr["DepartmentID"].ToString());
            if (objDr.Table.Columns["WorkGroupID"] != null && objDr["WorkGroupID"].ToString() != "")
                _WorkGroupID = int.Parse(objDr["WorkGroupID"].ToString());


            if (objDr.Table.Columns["SectorName"] != null)
                _SectorName = objDr["SectorName"].ToString();

            if (objDr.Table.Columns["SectorName1"] != null)
                _SectorName1 = objDr["SectorName1"].ToString();

            if (objDr.Table.Columns["SectorName2"] != null)
                _SectorName2 = objDr["SectorName2"].ToString();

            if (objDr.Table.Columns["JobNature"] != null)
                _JobNature = objDr["JobNature"].ToString();


            if (objDr.Table.Columns["ApplicantStartDate"] != null)
                DateTime.TryParse(objDr["ApplicantStartDate"].ToString(), out _StartDate);
        }
        #endregion
        #region Public Methods
        public virtual void Add()
        {
            string strSql = "";
            ID = BaseDb.UMSBaseDb.InsertIdentityTable(strSql);

        }
        public virtual void Edit()
        {
 
        }
        public virtual void Delete()
        { 
        }
       
        public void EditUserID()
        {
            if (_ID == 0)
                return;
            string strSql = "update HRApplicantWorker set ApplicantUser =" + _UserID +
                   " WHERE     (ApplicantID = " + _ID + ")";
            strSql += " update HRApplicantWorker set ApplicantUser =0 "  +
                   " WHERE     (ApplicantID <> " + _ID + ") and ApplicantUser ="+ _UserID +" ";
            BaseDb.UMSBaseDb.ExecuteNonQuery(strSql);

        }

        public virtual DataTable Search()
        {
            string strSql = SearchStr + " where (1=1)  ";
            if (_ID != 0)
                strSql += " and HRApplicant.ApplicantID=" + _ID;
            if (_IDs != null && _IDs != "")
                strSql += " and HRApplicant.ApplicantID in(" + _IDs + ")";
            if (_Code != null && _Code != "") 
                strSql += " and HRApplicantWorker.ApplicantCode like '%" + _Code + "%' ";
            if (_Name != null && _Name != "")
                strSql += " and (dbo.ReplaceStringComp(HRApplicant.ApplicantFirstName) like '%" + BaseDb.ReplaceStringComp(_Name) +
                    "%' or dbo.ReplaceStringComp(ApplicantFamousName) like '%" + BaseDb.ReplaceStringComp(_Name) + "%' ) ";

            if (_SectorID != 0)
            {
                DataTable dtSector = BaseDb.UMSBaseDb.ReturnDatatable(SectorSearchStr);
                string strSectoRIDs = "";
                foreach (DataRow objDr in dtSector.Rows)
                {
                    if (strSectoRIDs != "")
                        strSectoRIDs += ",";
                    strSectoRIDs += objDr["SectorID"].ToString();
                }

                strSql += " and DepartmentID in (" + strSectoRIDs + ")";
            }
            if (_UserID != 0)
            {
                strSql += " and dbo.HRApplicantWorker.ApplicantUser = " + _UserID;
            }
            if (_WorkingStatus != 0)
            {
                if (_WorkingStatus == 1)
                    strSql += " and HRApplicantWorker.ApplicantStatusID=1 ";
                else
                    strSql += " and HRApplicantWorker.ApplicantStatusID<>1 ";
            }
            if (_DepartmentIDs != null && _DepartmentIDs != "")
            {
                string strDepartment = "SELECT   distinct  dbo.HRApplicantWorkerCurrentSubSector.ApplicantID "+
                    " FROM   dbo.HRApplicantWorkerCurrentSubSector INNER JOIN " +
                    " dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID ";
                strDepartment += " where dbo.HRSubSector.SectorID in (" + _DepartmentIDs  + ")";
                strSql = "select EmployeeTable.* from ("+ strSql +
                    ") as EmployeeTable inner join ("+ strDepartment +") as DepartmentTable on EmployeeTable.ApplicantID= DepartmentTable.ApplicantID ";
            }
        
              
            return BaseDb.UMSBaseDb.ReturnDatatable(strSql);
        }
        #endregion 
    }
}
