using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.CRM.CRMBusiness;
using System.Web.Helpers;
namespace AlgorithmatMVC.Controllers.CRMController
{
    [Serializable]
    public class SingleCustomer
    {
        public int _ID;

        public string _Name;
        public string _UnitCode;
        public string _Project;
        public string _IDNo;
        public SingleCustomer()
        {
            _Name = "";
            _UnitCode = "";
            _Project = "";
            _IDNo = "";

        }
    }
    public class CustomerWebController : ApiController
    {
       
        [Route("api/CustomerWebController/GetCustomer")]
        [ActionName("GetCustomer")]
        [AcceptVerbs("GET","POST")]

        public IEnumerable<SingleCustomer> GetCustomer
            (string id,string strName,
            string strPhone,string strUnitCode
            ,string strIDNo,
            string strProjectIDs)
        {
            //string jsonString1 = Request.
          
            ProjectCol objProjectCol = new ProjectCol(true);
            int[] arrIndex = new int[0];
            if(strProjectIDs!= null && strProjectIDs!= "")
            arrIndex = System.Web.Helpers.Json.Decode<int[]>(strProjectIDs);
            foreach (int intProjectID in arrIndex)
                objProjectCol.Add(new ProjectBiz() { ID = intProjectID });

            CustomerCol objCustomerCol = 
                new CustomerCol(strName, strPhone, strIDNo, strUnitCode, objProjectCol);



            IEnumerable<SingleCustomer> Returned = from objCustomer in objCustomerCol.Cast<CustomerBiz>()
                       select new SingleCustomer() { _ID = objCustomer.ID,_Name = objCustomer.Name ,_UnitCode=objCustomer.UnitFullName,_Project=objCustomer.ProjectName};



            return Returned;
        }

    }
}
