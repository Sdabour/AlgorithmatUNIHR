using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class FacultyBiz
    {

        #region Constructor
        public FacultyBiz()
        {
            _FacultyDb = new FacultyDb();
        }
        public FacultyBiz(DataRow objDr)
        {
            _FacultyDb = new FacultyDb(objDr);
        }

        #endregion
        #region Private Data
        FacultyDb _FacultyDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _FacultyDb.ID = value;
            get => _FacultyDb.ID;
        }
        public string Code
        {
            set => _FacultyDb.Code = value;
            get => _FacultyDb.Code;
        }
        public string NameA
        {
            set => _FacultyDb.NameA = value;
            get => _FacultyDb.NameA;
        }
        public string NameE
        {
            set => _FacultyDb.NameE = value;
            get => _FacultyDb.NameE;
        }
        public string Dean
        {
            set => _FacultyDb.Dean = value;
            get => _FacultyDb.Dean;
        }
        public string ControlHead
        {
            set => _FacultyDb.ControlHead = value;
            get => _FacultyDb.ControlHead;
        }
        public string ControlViceHead
        {
            set => _FacultyDb.ControlViceHead = value;
            get => _FacultyDb.ControlViceHead;
        }
        public string CommitteeHead
        {
            set => _FacultyDb.CommitteeHead = value;
            get => _FacultyDb.CommitteeHead;
        }
        public static int UMSAllFaculties = 2447;
        public static string FacultyAssignObject = "FacultyAssign";
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _FacultyDb.Add();
        }
        public void Edit()
        {
            _FacultyDb.Edit();
        }
        public void Delete()
        {
            _FacultyDb.Delete();
        }
        #endregion
    }
}