using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;
using SharpVision.CRM.CRMBusiness;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.Controllers.CRMController
{
    [Serializable]
    public class SingleVisit
    {
        public string CustomerName;
        public string Time;
        public string Unit;
        public string Branch;
        public string Group;
        public string Desc;
        public string CustomerPhone;
        public string Employee;
        public string AssignedEmployee;
        public string Status;
        public string StatusTime;
        public string VisitType;
      
      
        

        

        public bool Picked;
        public bool IsBroadCasted;
        public int VisitNo;
        public int WindowNo;
        public int ID;
       
    }
    [Serializable]
    public class SingleVisitType
    {
        public int ID;
        public string Name;
        public int WorkGroup;
    }
    public class VisitWebController : ApiController
    {
      public static  void InitializeCon()
        {
            #region IntializeConnection
            int intLanguage = 0;

            string strConnection = System.Configuration.ConfigurationManager.AppSettings["SVDBCon"];
            string strImage = System.Configuration.ConfigurationManager.AppSettings["ImageURL"];
            SysData.SharpVisionBaseDb = new SharpVision.Base.BaseDataBase.BaseDb(strConnection);
            UserBiz.SetUmsBaseConnection(strConnection, 6, 0, "");
            SysData.Language = intLanguage;
            #endregion
        }
        [Route("api/VisitWebController/GetVisit")]
        [ActionName("GetVisit")]
        [AcceptVerbs("GET")]
        public IEnumerable<SingleVisit> GetVisit
        (
             string strBranch
       )
        {
            

             


            int intBranch = 0;
            int.TryParse(strBranch, out intBranch);

            
            //string jsonString1 = Request.

            IEnumerable<SingleVisit> Returned;
            VisitCol objCol;
            UMSBranchBiz objBranchBiz = new UMSBranchBiz() { ID = intBranch };
           
                objCol = VisitCol.GetPickedVisitCol(new EmployeeBiz(), new WorkGroupBiz(), objBranchBiz,0);

           
              

            Returned = from objBiz in objCol.Cast<VisitBiz>()
                       let strCustomerName =
                       objBiz.ContactCustomerName == "" ?
                       (objBiz.CustomerBiz.ID == 0 ? "" : objBiz.CustomerBiz.Name) : objBiz.ContactCustomerName
                       select new SingleVisit()
                       {

                           CustomerName = strCustomerName,
                           Time = objBiz.Date.ToString("HHH:mm"),
                           Unit = objBiz.ReservationBiz.DirectUnitCodeStr,
                           Group = objBiz.GroupBiz.Name,
                           Desc = objBiz.Desc,
                           Employee = objBiz.EmployeeBiz == null || objBiz.EmployeeBiz.Name == null?"": objBiz.EmployeeBiz.Name,
                           AssignedEmployee=objBiz.AssignedEmployeeBiz.Name,
                           Status = objBiz.StatusStr,
                           StatusTime = objBiz.StatusBiz.Date.ToString("HHH:mm")
, VisitType = objBiz.TypeBiz.Name
, Picked = true
,
                           IsBroadCasted  = objBiz.IsBroadCasted,
                           VisitNo = objBiz.VisitNo,
                           WindowNo = objBiz.WindowNo,
                           ID = objBiz.ID
                       };
            objCol = VisitCol.GetWaitingAssignmentVisitCol(new EmployeeBiz(), new WorkGroupBiz(), objBranchBiz, new EmployeeBiz());
            IEnumerable<SingleVisit> objWaitingCol = from objBiz in objCol.Cast<VisitBiz>()
                                                     let strCustomerName =
                                                     objBiz.ContactCustomerName == "" ?
                                                     (objBiz.CustomerBiz.ID == 0 ? "" : objBiz.CustomerBiz.Name) : objBiz.ContactCustomerName
                                                     select new SingleVisit()
                                                     {

                                                         CustomerName = strCustomerName,
                                                         Time = objBiz.Date.ToString("HHH:mm"),
                                                         Unit = objBiz.ReservationBiz.DirectUnitCodeStr,
                                                         Group = objBiz.GroupBiz.Name,
                                                         Desc = objBiz.Desc,
                                                         Employee = objBiz.EmployeeBiz == null || objBiz.EmployeeBiz.Name == null ? "" : objBiz.EmployeeBiz.Name,
                                                         AssignedEmployee = objBiz.AssignedEmployeeBiz.Name,
                                                         Status = objBiz.StatusStr,
                                                         StatusTime = objBiz.StatusBiz.Date.ToString("HHH:mm")
                              ,
                                                         VisitType = objBiz.TypeBiz.Name
                              ,
                                                         Picked = false


                           ,IsBroadCasted = objBiz.IsBroadCasted,
                                                         VisitNo = objBiz.VisitNo,
                                                         WindowNo = objBiz.WindowNo,
                                                         ID = objBiz.ID
                                                     };

            Returned = Returned.Union(objWaitingCol);
            int intTemp = Returned.Count();
           
            return Returned;

        }

       [Route("api/VisitWebController/BroadCastVisit")]
       [HttpPost]
       [AcceptVerbs("GET")]
       [ActionName("BroadCastVisit")]
        public bool BroadCastVisit(string strVisitID)
        {
            InitializeCon();
            int intTemp = 0;
            if(int.TryParse(strVisitID, out intTemp))
            VisitBiz.BroadCastVisit(intTemp);
            return true;
        }
        [Route("api/VisitWebController/NewVisit")]
        [HttpPost]
        [ActionName("NewVisit")]
        public int NewVisit([FromBody]SingleVisit objVisit)
        {
            InitializeCon();
            VisitBiz objBiz = new VisitBiz();
            objBiz.Status = ContactStatus.Created;
            int intTemp =0;
            int.TryParse(objVisit.Group, out intTemp);
            objBiz.GroupBiz = new WorkGroupBiz() {ID=intTemp};
            intTemp = 0;
            int.TryParse(objVisit.Branch, out intTemp);
            objBiz.BranchBiz = new UMSBranchBiz() { ID = intTemp};
            objBiz.ContactCustomerPhone = objVisit.CustomerPhone;
             intTemp = 0;
            int.TryParse(objVisit.VisitType, out intTemp);
            objBiz.TypeBiz = new VisitTypeBiz() { ID = intTemp };
            objBiz.Date = DateTime.Now;
            objBiz.Add();
            return objBiz.VisitNo;
        }
    }
    
}
