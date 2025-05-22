using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationGroupBiz
    {

        #region Constructor
        public RegisterationGroupBiz()
        {
            _GroupDb = new RegisterationGroupDb();
        }
        public RegisterationGroupBiz(DataRow objDr)
        {
            _GroupDb = new RegisterationGroupDb(objDr);
        }

        #endregion
        #region Private Data
        RegisterationGroupDb _GroupDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _GroupDb.ID = value;
            get => _GroupDb.ID;
        }
        //public int Faculty
        //{
        //    set => _GroupDb.Faculty = value;
        //    get => _GroupDb.Faculty;
        //}
        public string Code
        {
            set => _GroupDb.Code = value;
            get => _GroupDb.Code;
        }
        public string NameA
        {
            set => _GroupDb.NameA = value;
            get => _GroupDb.NameA;
        }
        public string NameE
        {
            set => _GroupDb.NameE = value;
            get => _GroupDb.NameE;
        }
        public int Semester
        {
            set => _GroupDb.Semester = value;
            get => _GroupDb.Semester;
        }
        public int Course
        {
            set => _GroupDb.Course = value;
            get => _GroupDb.Course;
        }
        public int LectureType
        {
            set => _GroupDb.LectureType = value;
            get => _GroupDb.LectureType;
        }
        public ExamType ExamType
        {
            set => _GroupDb.ExamType = (int)value;
            get => (ExamType)_GroupDb.ExamType;
        }
        HallBiz _HallBiz;
        public HallBiz HallBiz
        {
            set => _HallBiz = value;
            get
            {
                if (_HallBiz == null)
                    _HallBiz = new HallBiz() { ID = _GroupDb.HallID, Name = _GroupDb.HallName };
                return _HallBiz;
            }
        }
        //public int FacultyID
        //{
        //    set => _GroupDb.FacultyID = value;
        //    get => _GroupDb.FacultyID;
        //}
        //public string FacultyNameA
        //{
        //    set => _GroupDb.FacultyNameA = value;
        //    get => _GroupDb.FacultyNameA;
        //}
        //public string FacultyNameE
        //{
        //    set => _GroupDb.FacultyNameE = value;
        //    get => _GroupDb.FacultyNameE;
        //}
        RegisterationCol _RegisterationCol;
        public RegisterationCol RegisterationCol
        {
            set => _RegisterationCol = value;
            get
            {
                if(_RegisterationCol == null)
                {
                    _RegisterationCol = new RegisterationCol(true,0);
                    if(ID!= 0)
                    {
                        _GroupDb.Faculty = FacultyBiz.ID;
                         DataTable dtTemp = _GroupDb.GetGroupRegisteration();
                        foreach(DataRow objDr in dtTemp.Rows)
                        {
                            _RegisterationCol.Add(new RegisterationBiz(objDr));

                        }
                    }
                }
                return _RegisterationCol;
            }
        }
        public RegisterationCol RecommendedRegisterationCol
        {
            get
            {
                RegisterationCol Returned = new RegisterationCol(true, 0);
                _GroupDb.Faculty = FacultyBiz.ID;
                DataTable dtTemp = _GroupDb.GetGroupRecommededRegisteration();
                foreach(DataRow objDr in dtTemp.Rows)
                {
                    Returned.Add(new RegisterationBiz(objDr));

                }
                return Returned;
            }
        }

        FacultyBiz _FacultyBiz;
        public FacultyBiz FacultyBiz
        {
            set => _FacultyBiz = value;
            get
            {
                if(_FacultyBiz == null)
                {
                    _FacultyBiz = new FacultyBiz() { ID = _GroupDb.FacultyID, NameA = _GroupDb.FacultyNameA, NameE = _GroupDb.FacultyNameE };
                   
                }
                return _FacultyBiz;
            }
        }
        //public int CourseID
        //{
        //    set => _GroupDb.CourseID = value;
        //    get => _GroupDb.CourseID;
        //}
        //public string CourseCode
        //{
        //    set => _GroupDb.CourseCode = value;
        //    get => _GroupDb.CourseCode;
        //}
        //public string CourseNameA
        //{
        //    set => _GroupDb.CourseNameA = value;
        //    get => _GroupDb.CourseNameA;
        //}
        //public string CourseNameE
        //{
        //    set => _GroupDb.CourseNameE = value;
        //    get => _GroupDb.CourseNameE;
        //}
        CourseBiz _CourseBiz;
        public CourseBiz CourseBiz { set => _CourseBiz = value;get {
                if(_CourseBiz== null)
                {
                    _CourseBiz = new CourseBiz() { ID = _GroupDb.CourseID, Code = _GroupDb.CourseCode, NameA = _GroupDb.CourseNameA, NameE = _GroupDb.CourseNameE,RecommendedGrade=_GroupDb.CourseLevel };
                }
                return _CourseBiz;
            } }
        //public int SemesterID
        //{
        //    set => _GroupDb.SemesterID = value;
        //    get => _GroupDb.SemesterID;
        //}
        //public string SemesterDesc
        //{
        //    set => _GroupDb.SemesterDesc = value;
        //    get => _GroupDb.SemesterDesc;
        //}
        SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz { set => _SemesterBiz = value;
            get {
                if(_SemesterBiz==null)
                {
                    _SemesterBiz = new SemesterBiz() { ID = _GroupDb.SemesterID, Desc = _GroupDb.SemesterDesc };
                }
                return _SemesterBiz; }
        }
        //public int LectureTypeID
        //{
        //    set => _GroupDb.LectureTypeID = value;
        //    get => _GroupDb.LectureTypeID;
        //}
        //public string LectureTypeCode
        //{
        //    set => _GroupDb.LectureTypeCode = value;
        //    get => _GroupDb.LectureTypeCode;
        //}
        //public string LectureTypeNameA
        //{
        //    set => _GroupDb.LectureTypeNameA = value;
        //    get => _GroupDb.LectureTypeNameA;
        //}
        //public string LectureTypeNameE
        //{
        //    set => _GroupDb.LectureTypeNameE = value;
        //    get => _GroupDb.LectureTypeNameE;
        //}
        LectureTypeBiz _LecturTypeBiz;
        public LectureTypeBiz LectureTypeBiz
        {
            set => _LecturTypeBiz = value;
            get
            {
                if(_LecturTypeBiz==null)
                {
                    _LecturTypeBiz = new LectureTypeBiz() { ID = _GroupDb.LectureTypeID, Code = _GroupDb.LectureTypeCode, NameA = _GroupDb.LectureTypeNameA, NameE = _GroupDb.LectureTypeNameE };
                }
                return _LecturTypeBiz;
            }
        }
        int _RegisterationNo;
        public int RegisterationNo
        {
            set => _RegisterationNo = value;
            get => _RegisterationNo;
        }
        string _MinSeatNo;
        public string MinSeatNo { set => _MinSeatNo = value; get => _MinSeatNo; }
        string _MaxSeatNo;
        public string MaxSeatNo { set => _MaxSeatNo = value; get => _MaxSeatNo; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _GroupDb.Add();
        }
        public void Edit()
        {
            _GroupDb.Edit();
        }
        public void Delete()
        {
            _GroupDb.Delete();
        }
        public void AddUnique(int intUser)
        {
            _GroupDb.User = intUser;
            _GroupDb.Faculty = FacultyBiz.ID;
            _GroupDb.Semester = SemesterBiz.ID;
            _GroupDb.LectureType = LectureTypeBiz.ID;
            _GroupDb.Course = CourseBiz.ID;
            _GroupDb.AddUnique();
        }
        public void JoinRegisterationLst(List<int> lstRegisterationIDs)
        {
            if (lstRegisterationIDs.Count == 0 || ID == 0)
                return;
            string strIDs = "";
            foreach(int intID in lstRegisterationIDs)
            {
                if (strIDs != "")
                    strIDs += ",";
                strIDs += intID.ToString();
            }
            _GroupDb.RegisterationIDs = strIDs;
            _GroupDb.JoinRegisteration();
        }
        public void DeleteStudent()
        {
            _GroupDb.DeleteStudent();
        }
        #endregion
    }
}