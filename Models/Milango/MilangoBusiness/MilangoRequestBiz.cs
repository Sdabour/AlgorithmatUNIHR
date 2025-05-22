using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.Milango.MilangoDb;
using System.Data;

namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class MilangoRequestBiz
    {

        #region Constructor
        public MilangoRequestBiz()
        {
            _MilangoRequestDb = new MilangoRequestDb();
        }
        public MilangoRequestBiz(DataRow objDr)
        {
            _MilangoRequestDb = new MilangoRequestDb(objDr);
        }

        #endregion
        #region Private Data
        MilangoRequestDb _MilangoRequestDb;
        #endregion
        #region Properties
        public string ProjectCode
        {
            set => _MilangoRequestDb.ProjectCode = value;
            get => _MilangoRequestDb.ProjectCode;
        }
        public string UnitCode
        {
            set => _MilangoRequestDb.UnitCode = value;
            get => _MilangoRequestDb.UnitCode;
        }
        public string SAPPartner
        {
            set => _MilangoRequestDb.SAPPartner = value;
            get => _MilangoRequestDb.SAPPartner;
        }
        public int CategoryID
        {
            set => _MilangoRequestDb.CategoryID = value;
            get => _MilangoRequestDb.CategoryID;
        }
        public string CategoryNameA
        {
            set => _MilangoRequestDb.CategoryNameA = value;
            get => _MilangoRequestDb.CategoryNameA;
        }
        public string CategoryNameE
        {
            set => _MilangoRequestDb.CategoryNameE = value;
            get => _MilangoRequestDb.CategoryNameE;
        }
        public int ServiceID
        {
            set => _MilangoRequestDb.ServiceID = value;
            get => _MilangoRequestDb.ServiceID;
        }
        public string ServiceNameA
        {
            set => _MilangoRequestDb.ServiceNameA = value;
            get => _MilangoRequestDb.ServiceNameA;
        }
        public string ServiceNameE
        {
            set => _MilangoRequestDb.ServiceNameE = value;
            get => _MilangoRequestDb.ServiceNameE;
        }
        public DateTime SubmitDate
        {
            set => _MilangoRequestDb.SubmitDate = value;
            get => _MilangoRequestDb.SubmitDate;
        }
        public string Summary
        {
            set => _MilangoRequestDb.Summary = value;
            get => _MilangoRequestDb.Summary;
        }
        public string Description
        {
            set => _MilangoRequestDb.Description = value;
            get => _MilangoRequestDb.Description;
        }
        public string StatusCode
        {
            set => _MilangoRequestDb.StatusCode = value;
            get => _MilangoRequestDb.StatusCode;
        }
        public string StatusNameA
        {
            set => _MilangoRequestDb.StatusNameA = value;
            get => _MilangoRequestDb.StatusNameA;
        }
        public string StatusNameE
        {
            set => _MilangoRequestDb.StatusNameE = value;
            get => _MilangoRequestDb.StatusNameE;
        }
        public string StatusNote
        {
            set => _MilangoRequestDb.StatusNote = value;
            get => _MilangoRequestDb.StatusNote;
        }
        public DateTime StatusDT
        {
            set => _MilangoRequestDb.StatusDT = value;
            get => _MilangoRequestDb.StatusDT;
        }
        public bool Done
        {
            set => _MilangoRequestDb.Done = value;
            get => _MilangoRequestDb.Done;
        }
        public MilangoRequestSimple GetSimple() {
            MilangoRequestSimple Returned = new MilangoRequestSimple() { Category = new CategorySimple() { CategoryID = CategoryID, CategoryNameA = CategoryNameA, CategoryNameE = CategoryNameE }, Description = Description, ProjectCode = ProjectCode, SAPPartner = SAPPartner, Service = new ServiceSimple() { ServiceID = ServiceID, ServiceNameA = ServiceNameA, ServiceNameE = ServiceNameE }, Status = new RequestStatusSimple() { Done = Done, StatusCode = StatusCode, StatusDT = StatusDT, StatusNameA = StatusNameA, StatusNameE = StatusNameE, StatusNote = StatusNote }, SubmitDate = SubmitDate, Summary = Summary, UnitCode = UnitCode };
            return Returned;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MilangoRequestDb.Add();
        }
        public void Edit()
        {
            _MilangoRequestDb.Edit();
        }
        public void Delete()
        {
            _MilangoRequestDb.Delete();
        }
        #endregion
    }
}