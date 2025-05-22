using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.Base.BaseBusiness;
using System.Data;
using System.Collections;
using SharpVision.UMS.UMSBusiness;

namespace SharpVision.UMS.UMSBusiness
{
    public class EmployeeBiz
    {
        #region Private Data
       protected EmployeeDb _EmployeeDb;
        EmployeeDepartmentCol _EmployeeDepartmentCol;
        UserBiz _UserBiz;
        DepartmentBiz _DepartmentBiz;
        WorkGroupBiz _WorkGroupBiz;
        static EmployeeBiz _CurrentEmployeeBiz;
        
        #endregion
        #region Constructors
        public EmployeeBiz()
        {
            _EmployeeDb = new EmployeeDb();
            
        }
        public EmployeeBiz(int intID)
        {
            _EmployeeDb = new EmployeeDb();
            if (intID != 0)
            {
                EmployeeDb objDb = new EmployeeDb() { ID = intID };
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count > 0)
                    _EmployeeDb = new EmployeeDb(dtTemp.Rows[0]);
            }

        }
        public EmployeeBiz(DataRow objDr)
        {
            _EmployeeDb = new EmployeeDb(objDr);
        }

        #endregion
        #region Public Properties
        public int ID
        {
            set
            {

                _EmployeeDb.ID = value;
            }
            get
            {
                return _EmployeeDb.ID;
            }
        }
        public string Code
        {
            set
            {
                _EmployeeDb.Code = value;
            }
            get
            {
                return _EmployeeDb.Code;
            }
        }
        public string Name
        {
            set
            {
                _EmployeeDb.Name = value;
            }
            get
            {
                return _EmployeeDb.Name;
            }
        }
        public int UserID
        {
            set
            {
                _EmployeeDb.UserID = value;
            }
            get
            {
                return _EmployeeDb.UserID;
            }
        }
        public string FamousName
        {
            set
            {
                _EmployeeDb.FamousName = value;
            }
            get
            {
                return _EmployeeDb.FamousName;
            }
        }
        public string ShortName
        {
            set
            {
                _EmployeeDb.ShortName = value;
            }
            get
            {

                return _EmployeeDb.ShortName;
            }
        }
        public string DisplayName
        {
            get
            {
                string Returned = "";
                Returned = ShortName != "" ?  ShortName :
                    (FamousName == "" ? Name : FamousName);
                return Returned;
            }
        }
        public int Status
        {
            set
            {
                _EmployeeDb.Status = value;
            }
            get
            {
                return _EmployeeDb.Status;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _EmployeeDb.EndDate = value;
            }
            get
            {
                return _EmployeeDb.EndDate;
            }
        }
        public int BranchID
        {
            set
            {
                _EmployeeDb.BranchID = value;
            }
            get
            {
                return _EmployeeDb.BranchID;
            }
        }
        public string BranchName
        {
            set
            {
                _EmployeeDb.BranchName = value;
            }
            get
            {
                return _EmployeeDb.BranchName;
            }
        }
         
        public string SectorName
        {
            set { _EmployeeDb.SectorName = value; }
            get { return _EmployeeDb.SectorName; }
        }
         
        public string SectorName1
        {
            set { _EmployeeDb.SectorName1 = value; }
            get { return _EmployeeDb.SectorName1; }
        }
        
        public string SectorName2
        {
            set { _EmployeeDb.SectorName2 = value; }
            get { return _EmployeeDb.SectorName2; }
        }
       
        public string JobNature
        {
            set { _EmployeeDb.JobNature = value; }
            get { return _EmployeeDb.JobNature; }
        }
        public EmployeeDepartmentCol EmployeeDepartmentCol
        {
            set
            {
                _EmployeeDepartmentCol = value;
            }
            get
            {
                if (_EmployeeDepartmentCol == null)
                    _EmployeeDepartmentCol = new EmployeeDepartmentCol(true);
                return _EmployeeDepartmentCol;
            }
        }
        public EmployeeDepartmentBiz EmployeeDepartmentBiz
        {
            get
            {
                EmployeeDepartmentBiz Returned = new EmployeeDepartmentBiz();
                if (EmployeeDepartmentCol.Count > 0)
                    Returned = EmployeeDepartmentCol[0];
                return Returned;
            }
        }
        public string DepartmentStr
        {
            get
            {
                string Returned = "";
                if (EmployeeDepartmentCol.Count > 0)
                {
                    Returned = EmployeeDepartmentCol[0].DepartmentBiz.Name;
                }
                return Returned;
            }
        }
        public string StatusStr
        {
            get
            {
                string Returned = "";
                if (Status == 1)
                    Returned = "íÚãá";
                else
                {
                    Returned = "áÇ íÚãá ";
                    if (_EmployeeDb.IsEnded)
                    {
                        Returned = " ÈÊÇÑíÎ : " + EndDate.ToString("yyyy-MM-dd");
                    }
                }
                return Returned;
            }
        }
      
        public UserBiz UserBiz
        {
            set 
            {
                _UserBiz = value;
            }
            get
            {
                if (_UserBiz == null)
                {
                    _UserBiz = new UserBiz();
                    
                }
                return _UserBiz;
            }
        }
        public DepartmentBiz DepartmentBiz
        {
            get
            {
                if (_DepartmentBiz == null)
                    _DepartmentBiz = DepartmentCol.CurrentDepartmentCol[_EmployeeDb.DepartmentID.ToString()];
                return _DepartmentBiz;
            }
        }
        public WorkGroupBiz WorkGroupBiz
        {
            get
            {
                if (_WorkGroupBiz == null)
                {
                    _WorkGroupBiz = WorkGroupCol.CurrentWorkGroupCol[_EmployeeDb.WorkGroupID.ToString()];
                    if(_WorkGroupBiz == null)
                    _WorkGroupBiz = new WorkGroupBiz();
                }
                return _WorkGroupBiz;
            }
        }
        public static EmployeeBiz CurrentEmployeeBiz
        {
            get
            {
                if (_CurrentEmployeeBiz == null)
                {
                    _CurrentEmployeeBiz = new EmployeeBiz();
                    //EmployeeDb objDb = new EmployeeDb();
                    //objDb.UserID = UserBiz.CurrentUser.ID;
                    //DataTable dtTemp = objDb.Search();
                    //if (dtTemp.Rows.Count > 0)
                    //{
                    //    _CurrentEmployeeBiz = new EmployeeBiz(dtTemp.Rows[0]);
                    //    EmployeeDepartmentDb objDepartmentDb = new EmployeeDepartmentDb();
                    //    objDepartmentDb.EmployeeIDs = _CurrentEmployeeBiz.ID.ToString();

                    //    DataTable dtDepartment = objDepartmentDb.Search();
                    //    if (dtDepartment.Rows.Count > 0)
                    //    {
                    //        foreach (DataRow objDr in dtDepartment.Rows)
                    //        {
                    //            _CurrentEmployeeBiz.EmployeeDepartmentCol.Add(new EmployeeDepartmentBiz(objDr));
                    //        }
                    //    }
                    //}
                    _CurrentEmployeeBiz = UserBiz.CurrentUser.EmployeeBiz;
                    

                }
                return _CurrentEmployeeBiz;
            }
        }
        public EmployeeSimple EmployeeSimple
        {
            get => new EmployeeSimple() { ID = ID, BranchName = BranchName, Code = Code, Department = DepartmentBiz.Name, FamousName = FamousName, Name = Name, User = UserID, UserName = UserBiz.Name };
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void EditUser()
        {
            _EmployeeDb.UserID = UserBiz.ID;
            _EmployeeDb.EditUserID();
        }
        public virtual void Add()
        { }
        public virtual void Edit()
        { }
        public virtual void Delete()
        { }
        public bool CheckDepartmentParentBiz(DepartmentBiz objBiz)
        {
       
           DepartmentBiz objTemp = DepartmentBiz;
           if (objBiz == null || objBiz.ID == 0)
               return true;
            if (objBiz.ID == DepartmentBiz.ID)
            {
                return true;
            }
            else
            {
                while (objTemp.ID != objTemp.ParentID)
                {
                    objTemp = objTemp.ParentBiz;
                    if (objTemp.ID == objBiz.ID)
                        return true;
                }
            }
            
            return false;
        }
        public bool CheckWorkGroupBiz(WorkGroupBiz objBiz)
        {
            if (objBiz == null || objBiz.ID == 0 ||  objBiz.ID == WorkGroupBiz.ID)
                return true;
            return false;
        }
        public bool CheckWorkGroupBiz(WorkGroupCol objCol)
        {
            if (objCol == null || objCol.Count == 0)
                return true;
            foreach(WorkGroupBiz objBiz in objCol)
            if (objBiz == null || objBiz.ID == 0 || objBiz.ID == WorkGroupBiz.ID)
                return true;
            return false;
        }
        public bool CheckWorkGroupBiz(Hashtable hsTemp )
        {
            if (hsTemp == null || hsTemp.Keys.Count == 0)
                return true;

            return hsTemp[WorkGroupBiz.ID.ToString()] != null;
           // return false;
        }

        #endregion
    }
}
