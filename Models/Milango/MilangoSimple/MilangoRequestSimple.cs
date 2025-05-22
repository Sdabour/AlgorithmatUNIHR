using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class CategorySimple
    {
        public int CategoryID;
        public string CategoryNameA;
        public string CategoryNameE;
    }
    public class ServiceSimple
    {
        public int ServiceID;
        public string ServiceNameA;
        public string ServiceNameE;
    }
    public class RequestStatusSimple
        {
        public string StatusCode;
        public string StatusNameA;
        public string StatusNameE;
        public string StatusNote;
        public DateTime StatusDT;
        public bool Done;

    }
    public class MilangoRequestSimple
    {

        #region Properties
        public string ProjectCode;
        public string UnitCode;
        public string SAPPartner;

        public CategorySimple Category = new CategorySimple();
        public ServiceSimple Service = new ServiceSimple();
        public DateTime SubmitDate;
        public string Summary;
        public string Description;
        public RequestStatusSimple Status = new RequestStatusSimple();
        #endregion
    }
}