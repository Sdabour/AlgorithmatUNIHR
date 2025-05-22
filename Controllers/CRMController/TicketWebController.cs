using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.CRM.CRMBusiness;
using SharpVision.Base.BaseBusiness;
using SharpVision.UMS.UMSBusiness;
namespace AlgorithmatMVC.Controllers.CRMController
{
    [Serializable]
    public class SingleTicket
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
        public string TicketType;
        public int NewStatus;





        public bool Picked;
      
        public int ID;

    }

    public class TicketWebController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
           
        }

        
        [Route("api/TicketWebController/NewTicket")]
        [HttpPost]
        [ActionName("NewTicket")]
        public int NewTicket([FromBody]SingleTicket objTicket)
        {
            VisitWebController.InitializeCon();
            TicketBiz objBiz = new TicketBiz();
            objBiz.Status = TicketStatus.Created;
            int intTemp = 0;
            int.TryParse(objTicket.TicketType, out intTemp);
            objBiz.TypeBiz = new TicketTypeBiz { ID = intTemp };
            intTemp = 0;
            //int.TryParse(objTicket.Branch, out intTemp);
            //objBiz.BranchBiz = new UMSBranchBiz() { ID = intTemp };
            //objBiz.ContactCustomerPhone = objVisit.CustomerPhone;
            intTemp = 0;
            int.TryParse(objTicket.TicketType, out intTemp);
            objBiz.TypeBiz = new TicketTypeBiz() { ID = intTemp };
            objBiz.Date = DateTime.Now;
            objBiz.Add();
            return objBiz.ID;
        }
        [Route("api/TicketWebController/GetTicketType")]
        [HttpGet]
        [ActionName("GetTicketType")]
        public IEnumerable<SerializableBiz> GetTicketType()
        {
            VisitWebController.InitializeCon();
            TicketTypeCol objCol = new TicketTypeCol();
            IEnumerable<SerializableBiz> Returned = from objTicket in objCol.Cast<TicketTypeBiz>()
                                                    select new SerializableBiz() {ID=objTicket.ID,Name=objTicket.Name };
            return Returned;

        }

        [Route("api/TicketWebController/GetNewAndAssignedTickets")]
        [ActionName("GetNewAndAssignedTickets")]
        [AcceptVerbs("GET")]
        public IEnumerable<SingleTicket> GetNewAndAssignedTickets
     (
          string  strEmployee,string strGroup,string strMonitoringGroup
    )
        {





            int intEmployee = 0;
            int.TryParse(strEmployee, out intEmployee);
            int intGroup = 0;
            int.TryParse(strGroup, out intGroup);
            int intMonitoringGroup = 0;
            int.TryParse(strMonitoringGroup, out intMonitoringGroup);
            //string jsonString1 = Request.

            IEnumerable<SingleTicket> Returned;
            TicketCol objWaitingTicketCol;
            TicketCol objNewTicketCol ;
            EmployeeBiz objEmployeeBiz = new EmployeeBiz() { ID = intEmployee };
            WorkGroupBiz objMonitoringGroupBiz = new WorkGroupBiz() { ID = intMonitoringGroup };
            objWaitingTicketCol = TicketCol.GetTicketProcessingWaitingCurrentDate(objEmployeeBiz,objMonitoringGroupBiz);
            WorkGroupBiz objGroupBiz = new WorkGroupBiz() { ID=intGroup};
           objNewTicketCol = TicketCol.GetWaitingAssignmentTicketCol(objEmployeeBiz, objGroupBiz);


            IEnumerable<SingleTicket> objNewCol = from objBiz in objNewTicketCol.Cast<TicketBiz>()
                                               let strCustomerName =
                                                objBiz.CustomerBiz.Name
                                               select new SingleTicket()
                                               {

                                                   CustomerName = strCustomerName,
                                                   Time = objBiz.Date.ToString("MM-dd HHH:mm"),
                                                   TicketType=objBiz.TypeBiz.Name,
                                                   Unit = objBiz.ReservationBiz.DirectUnitCodeStr,
                                                   Group = objBiz.GroupBiz.Name,
                                                   Desc = objBiz.Desc,
                                                   Employee = objBiz.EmployeeBiz == null || objBiz.EmployeeBiz.Name == null ? "" : objBiz.EmployeeBiz.Name,

                                                   Status = objBiz.StatusStr,
                                                   StatusTime = objBiz.StatusBiz.Date.ToString("MM-dd HHH:mm")
                        ,
                                                   
                                                   Picked = false
                        ,NewStatus=1,

                                                   ID = objBiz.ID
                                               };

            Returned = from objBiz in objWaitingTicketCol.Cast<TicketBiz>()
                       let strCustomerName =
                        objBiz.CustomerBiz.Name
                       select new SingleTicket()
                       {

                           CustomerName = strCustomerName,
                           Time = objBiz.Date.ToString("HHH:mm"),
                           Unit = objBiz.ReservationBiz.DirectUnitCodeStr,
                           Group = objBiz.GroupBiz.Name,
                           Desc = objBiz.Desc,
                           Employee = objBiz.EmployeeBiz == null || objBiz.EmployeeBiz.Name == null ? "" : objBiz.EmployeeBiz.Name,
                           
                           Status = objBiz.StatusStr,
                           StatusTime = objBiz.StatusBiz.Date.ToString("HHH:mm")
,
                           TicketType = objBiz.TypeBiz.Name
,
                           Picked = true
,
                           NewStatus = 0,
                           ID = objBiz.ID
                       };
           
            Returned = Returned.Union(objNewCol);
            int intTemp = Returned.Count();

            return Returned;

        }

    }
}