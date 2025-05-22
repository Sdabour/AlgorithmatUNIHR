using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class TeacherBiz
    {

        #region Constructor
        public TeacherBiz()
        {
            _TeacherDb = new TeacherDb();
        }
        public TeacherBiz(DataRow objDr)
        {
            _TeacherDb = new TeacherDb(objDr);
            _TypeBiz = new TeacherTypeBiz(objDr);
        }

        #endregion
        #region Private Data
        TeacherDb _TeacherDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _TeacherDb.ID = value;
            get => _TeacherDb.ID;
        }
        public string Code
        {
            set => _TeacherDb.Code = value;
            get => _TeacherDb.Code;
        }
        public string Name
        {
            set => _TeacherDb.Name = value;
            get => _TeacherDb.Name;
        }
        public string FamousName
        {
            set => _TeacherDb.FamousName = value;
            get => _TeacherDb.FamousName;
        }
        public string ShortName
        {
            set => _TeacherDb.ShortName = value;
            get => _TeacherDb.ShortName;
        }
        public int FunctionGroup
        {
            set => _TeacherDb.FunctionGroup = value;
            get => _TeacherDb.FunctionGroup;
        }
        FacultyBiz _FacultyBiz;
       public FacultyBiz FacultyBiz { set => _FacultyBiz = value;
            get {
                if (_FacultyBiz == null)
                    _FacultyBiz = new FacultyBiz() { ID = _TeacherDb.Faculty, Code = _TeacherDb.FacultyCode, NameA = _TeacherDb.FacultyNameA, NameE = _TeacherDb.FacultyNameE };
                return _FacultyBiz;
                        } }
        TeacherTypeBiz _TypeBiz;
        public TeacherTypeBiz TypeBiz
        {
            set => _TypeBiz = value;
            get
            {
                if (_TypeBiz == null)
                    _TypeBiz = new TeacherTypeBiz();
                return _TypeBiz;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _TeacherDb.Add();
        }
        public void Edit()
        {
            _TeacherDb.Edit();
        }
        public void Delete()
        {
            _TeacherDb.Delete();
        }
        #endregion
    }
}