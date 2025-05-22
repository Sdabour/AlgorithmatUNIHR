using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.UMS.UMSBusiness;

namespace SharpVision.UMS.UMSBusiness
{
    public static class UMSExtendedMethod
    {
        public static UserSimple GetSimple(this UserBiz objBiz)
        {
            UserSimple Returned = new UserSimple() { Branch = objBiz.EmployeeBiz.BranchID, EmpCode = objBiz.EmployeeBiz.EmployeeSimple.Code, EmpID = objBiz.EmployeeBiz.ID, EmpName = objBiz.EmployeeBiz.Name, FullName = objBiz.FullName, Group = objBiz.GroupID, GroupName = objBiz.GroupName, ID = objBiz.ID, IsSystemAdmin = objBiz.IsAdmin, Name = objBiz.Name, Sector = objBiz.EmployeeBiz.SectorName };
            return Returned;
        }
        public static FunctionSimple GetFunctionSimple(this FunctionBiz objBiz)
        {
            FunctionSimple Returned = new FunctionSimple() { Desc=objBiz.Description, FamilyID=objBiz.FamilyID,FamilyName="",ID=objBiz.ID,Name=objBiz.Name,Parent=objBiz.ParentID,ParentID=objBiz.ParentID,ParentName=objBiz.ParentBiz.Name,Stoped=objBiz.IsStoped,SysID=objBiz.SysID};
            return Returned;
        }
        //public static FunctionInstantSimple GetFunctionInstant(this UserFunctionInstantBiz objBiz)
        //{
        //    FunctionInstantSimple Returned = new FunctionInstantSimple() {EndDate=objBiz.IsPermanent ?DateTime.Now: objBiz.EndDate,FunctionSimple=new FunctionSimple() { Desc=objBiz.Description,FamilyID=objBiz.FamilyID,FamilyName="",ID=objBiz.ID,Name=objBiz.Name,Parent=objBiz.ParentID,ParentID=objBiz.ParentID,ParentName="",Stoped=false,SysID=objBiz.SysID} ,IsAdmin=objBiz.IsAdmin,IsPermanent=objBiz.IsPermanent,StartDate= objBiz.IsPermanent ? DateTime.Now : objBiz.StartDate};
        //    return Returned;
        //}
        public static FunctionInstantSimple GetFunctionInstant(this UserFunctionInstantBiz objBiz)
        {
            FunctionInstantSimple Returned = new FunctionInstantSimple() { EndDate = objBiz.IsPermanent ? "": objBiz.EndDate.ToString("yyyy-MM-dd"), FunctionSimple = new FunctionSimple() { Desc = objBiz.Description, FamilyID = objBiz.FamilyID, FamilyName = "", ID = objBiz.ID, Name = objBiz.Name, Parent = objBiz.ParentID, ParentID = objBiz.ParentID, ParentName = "", Stoped = false, SysID = objBiz.SysID }, IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent, StartDate = objBiz.IsPermanent ?"" : objBiz.StartDate.ToString("yyyy-MM-dd") };
            return Returned;
        }
        //public static GroupFunctionInstantBiz GetGroupFunctionInstant(this FunctionInstantSimple objBiz)
        //{
        //    GroupFunctionInstantBiz Returned = new GroupFunctionInstantBiz() { EndDate = objBiz.EndDate, ID=objBiz.FunctionSimple.ID,IsAdmin =objBiz.IsAdmin,IsPermanent=objBiz.IsPermanent,StartDate = objBiz.StartDate};
        //    return Returned;
        //}
        public static GroupFunctionInstantBiz GetGroupFunctionInstant(this FunctionInstantSimple objBiz)
        {
            GroupFunctionInstantBiz Returned = new GroupFunctionInstantBiz() {  ID = objBiz.FunctionSimple.ID, IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent };
            DateTime dtTemp = DateTime.Now;
            if(DateTime.TryParse(objBiz.StartDate,out dtTemp))
            {
                Returned.StartDate = dtTemp;
            }
            if (DateTime.TryParse(objBiz.EndDate, out dtTemp))
                Returned.EndDate = dtTemp;
            return Returned;
        }
        public static UserFunctionInstantBiz GetUserFunctionInstant(this FunctionInstantSimple objBiz)
        {
            UserFunctionInstantBiz Returned = new UserFunctionInstantBiz() {  ID = objBiz.FunctionSimple.ID, IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent,SysID=objBiz.FunctionSimple.SysID };
            DateTime dtTemp = DateTime.Now;
            if (DateTime.TryParse(objBiz.StartDate, out dtTemp))
            {
                Returned.StartDate = dtTemp;
            }
            if (DateTime.TryParse(objBiz.EndDate, out dtTemp))
                Returned.EndDate = dtTemp;
            return Returned;
        }
        public static FunctionInstantSimple GetFunctionInstant(this GroupFunctionInstantBiz objBiz)
        {
            FunctionInstantSimple Returned = new FunctionInstantSimple() { EndDate = objBiz.IsPermanent?"" : objBiz.EndDate.ToString("yyyy-MM-dd"), FunctionSimple =new FunctionSimple() { ID = objBiz.ID, Name=objBiz.Name,SysID=objBiz.SysID},IsAdmin = objBiz.IsAdmin, IsPermanent = objBiz.IsPermanent, StartDate = objBiz.IsPermanent ?"": objBiz.StartDate.ToString("yyyy-MM-dd") };
            return Returned;
        }
        public static EmployeeSimple GetSimple(this EmployeeBiz objBiz)
        {
          EmployeeSimple Returned =  new EmployeeSimple() { ID = objBiz.ID, Code = objBiz.Code, Name = objBiz.Name, Department = objBiz.DepartmentStr, BranchName = objBiz.BranchName, FamousName = objBiz.FamousName, User = objBiz.UserID, UserName = "" };
            return Returned;
        }
        public static AssignmentObjectSimple GetSimple(this AssignmentObjectBiz objBiz)
        {
            AssignmentObjectSimple Returned = new AssignmentObjectSimple() { Code = objBiz.Code, Desc = objBiz.Desc, ID = objBiz.ID };
            return Returned;
        }
    }
}