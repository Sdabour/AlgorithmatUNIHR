using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LectureBiz
    {

        #region Constructor
        public LectureBiz()
        {
            _LectureDb = new LectureDb();
        }
        public LectureBiz(DataRow objDr)
        {
            _LectureDb = new LectureDb(objDr);
        }
        public LectureBiz(int intID)
        {
            _LectureDb = new LectureDb();
            if (intID == 0)
                return;
            LectureDb objDb = new LectureDb() { ID = intID };
            DataTable dtTemp = objDb.Search();
            if (dtTemp.Rows.Count > 0)
                _LectureDb = new LectureDb(dtTemp.Rows[0]);

        }
        #endregion
        #region Private Data
        LectureDb _LectureDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _LectureDb.ID = value;
            get => _LectureDb.ID;
        }
        public int Type
        {
            set => _LectureDb.Type = value;
            get => _LectureDb.Type;
        }
        public int Course
        {
            set => _LectureDb.Course = value;
            get => _LectureDb.Course;
        }
        public int Semester
        {
            set => _LectureDb.Semester = value;
            get => _LectureDb.Semester;
        }
        
        public int Teacher
        {
            set => _LectureDb.Teacher = value;
            get => _LectureDb.Teacher;
        }
        public DateTime Date
        {
            set => _LectureDb.Date = value;
            get => _LectureDb.Date;
        }
        public DateTime StartTime
        {
            set => _LectureDb.StartTime = value;
            get => _LectureDb.StartTime;
        }
        public DateTime EndTime
        {
            set => _LectureDb.EndTime = value;
            get => _LectureDb.EndTime;
        }
        public double BreakDurationInMinutes
        {
            set => _LectureDb.BreakDurationInMinutes = value;
            get => _LectureDb.BreakDurationInMinutes;
        }
        public bool Scheduled
        {
            set => _LectureDb.Scheduled = value;
            get => _LectureDb.Scheduled;
        }
        public bool AttendanceMandatory
        {
            set => _LectureDb.AttendanceMandatory = value;
            get => _LectureDb.AttendanceMandatory;
        }
        public string Note
        {
            set => _LectureDb.Note = value;
            get => _LectureDb.Note;
        }
        public int Hall
        {
            set => _LectureDb.Hall = value;
            get => _LectureDb.Hall;
        }
        public string GUUID
        {
            set => _LectureDb.GUUID = value;
            get => _LectureDb.GUUID;
        }
        CourseBiz _CourseBiz;
        public CourseBiz CourseBiz
        {
            set => _CourseBiz = value;
            get
            {
                if(_CourseBiz == null)
                {
                    _CourseBiz = new CourseBiz() { ID = _LectureDb.CourseID, Code = _LectureDb.CourseCode, NameA = _LectureDb.CourseNameA, NameE = _LectureDb.CourseNameE, Faculty = _LectureDb.CourseFaculty, CreditHour = _LectureDb.CourseCreditHour, SemesterWorkDegree = _LectureDb.CourseSemesterWorkDegree };
                }
                return _CourseBiz;
            }
        }
        SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz
        {
            set => _SemesterBiz = value;
            get
            {
                if(_SemesterBiz == null)
                {
                    _SemesterBiz = new SemesterBiz() { ID = _LectureDb.SemesterID, Desc = _LectureDb.SemesterDesc, Type = (UNIBusiness.SemesterType)_LectureDb.SemesterType };
                }
                return _SemesterBiz;
            }
        }

        LectureTypeBiz _TypeBiz;
        public LectureTypeBiz TypeBiz
        {
            set =>_TypeBiz= value;
            get
            {
                if(_TypeBiz== null)
                {
                    _TypeBiz = new LectureTypeBiz() { ID = _LectureDb.TypeID, Code = _LectureDb.TypeCode, NameA = _LectureDb.TypeNameE, NameE = _LectureDb.TypeNameE };
                }
                    return _TypeBiz;
            }

        }
        TeacherBiz _TeacherBiz;
        public TeacherBiz TeacherBiz
        {
            set => _TeacherBiz = value;
            get
            {
                if(_TeacherBiz == null)
                {
                    _TeacherBiz = new TeacherBiz() { Code = _LectureDb.TeacherCode, Name = _LectureDb.TeacherName, ID = _LectureDb.TeacherID };
                }
                return _TeacherBiz;
            }

        }
        //public int TeacherID
        //{
        //    set => _LectureDb.TeacherID = value;
        //    get => _LectureDb.TeacherID;
        //}
        //public string TeacherCode
        //{
        //    set => _LectureDb.TeacherCode = value;
        //    get => _LectureDb.TeacherCode;
        //}
        //public string TeacherName
        //{
        //    set => _LectureDb.TeacherName = value;
        //    get => _LectureDb.TeacherName;
        //}
        //public int LeactureTeacherStatus
        //{
        //    set => _LectureDb.LeactureTeacherStatus = value;
        //    get => _LectureDb.LeactureTeacherStatus;
        //}
        RegisterationCol _RegisterationCol;
        public RegisterationCol RegisterationCol
        {
            get
            {
                if(_RegisterationCol == null)
                {
                    DataTable dtTemp = _LectureDb.GetRegisteration();
                    _RegisterationCol = new RegisterationCol(true,0);
                    foreach(DataRow objDr in dtTemp.Rows)
                    {
                        _RegisterationCol.Add(new RegisterationBiz(objDr));

                    }
                }
                return _RegisterationCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _LectureDb.Course = CourseBiz.ID;
            _LectureDb.Semester = SemesterBiz.ID;
            _LectureDb.Type = TypeBiz.ID;
            //_LectureDb.Teacher = Teacher
            _LectureDb.Add();
        }
        public void AddUnique(int intUser)
        {
            _LectureDb.Course = CourseBiz.ID;
            _LectureDb.Semester = SemesterBiz.ID;
            _LectureDb.Type = TypeBiz.ID;
            _LectureDb.Teacher = TeacherBiz.ID;
            _LectureDb.Add();
        }
        public void Edit()
        {
            _LectureDb.Edit();
        }
        public void Delete()
        {
            _LectureDb.Delete();
        }
        #endregion

    }
}