using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public enum ExamType { Midterm=1,SemesterWork=2,Oral=3,Practical=4,Final=5,Clinical=6}
    public class ExamBiz
    {

        #region Constructor
        public ExamBiz()
        {
            _ExamDb = new ExamDb();
        }
        public ExamBiz(DataRow objDr)
        {
            _ExamDb = new ExamDb(objDr);
        }
        public ExamBiz(int intExam)
        {
            _ExamDb = new ExamDb();
            if (intExam != 0)
            {
                _ExamDb.ID = intExam;
                DataTable dtTemp = _ExamDb.Search();
                if (dtTemp.Rows.Count > 0)
                {
                    _ExamDb = new ExamDb(dtTemp.Rows[0]);

                }
                else
                    _ExamDb.ID = 0;
            }
            else
            {
                _ExamDb = new ExamDb();
            }
        }

        #endregion
        #region Private Data
        ExamDb _ExamDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _ExamDb.ID = value;
            get => _ExamDb.ID;
        }
        public string Desc
        {
            set => _ExamDb.Desc = value;
            get => _ExamDb.Desc;
        }
        public DateTime Date
        {
            set => _ExamDb.Date = value;
            get => _ExamDb.Date;
        }
        public DateTime StartTime
        {
            set => _ExamDb.StartTime = value;
            get => _ExamDb.StartTime;
        }
        public DateTime EndTime
        {
            set => _ExamDb.EndTime = value;
            get => _ExamDb.EndTime;
        }
        public int Semester
        {
            set => _ExamDb.Semester = value;
            get => _ExamDb.Semester;
        }
        public int Course
        {
            set => _ExamDb.Course = value;
            get => _ExamDb.Course;
        }
        public ExamType Type
        {
            set => _ExamDb.Type = (int)value;
            get => (ExamType)_ExamDb.Type;
        }

        public string TypeName
        {
            get
            {
                string Returned = "";
                switch (Type)
                {
                    case ExamType.Final: Returned = "Final"; break;
                    case ExamType.Midterm: Returned = "Midterm"; break;
                    case ExamType.Oral: Returned = "Oral"; break;
                    case ExamType.Practical: Returned = "Practical"; break;
                    case ExamType.SemesterWork: Returned = "SemesterWork"; break;
                    case ExamType.Clinical: Returned = "Clinical"; break;
                    default: Returned = ""; break;
                }
                return Returned;

            }
        }

        public int Grade
        {
            set => _ExamDb.Grade = value;
            get => _ExamDb.Grade;
        }
        //public int SemesterID
        //{
        //    set => _ExamDb.SemesterID = value;
        //    get => _ExamDb.SemesterID;
        //}
        //public string SemesterDesc
        //{
        //    set => _ExamDb.SemesterDesc = value;
        //    get => _ExamDb.SemesterDesc;
        //}
        SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz
        {
            set => _SemesterBiz = value;
            get
            {
                if (_SemesterBiz == null)
                    _SemesterBiz = new SemesterBiz() { ID = _ExamDb.SemesterID, Desc = _ExamDb.SemesterDesc };
                return _SemesterBiz;
            }
        }
        //public int CourseID
        //{
        //    set => _ExamDb.CourseID = value;
        //    get => _ExamDb.CourseID;
        //}
        //public string CourseCode
        //{
        //    set => _ExamDb.CourseCode = value;
        //    get => _ExamDb.CourseCode;
        //}
        //public string CourseNameA
        //{
        //    set => _ExamDb.CourseNameA = value;
        //    get => _ExamDb.CourseNameA;
        //}
        //public string CourseNameE
        //{
        //    set => _ExamDb.CourseNameE = value;
        //    get => _ExamDb.CourseNameE;
        //}
        CourseBiz _CourseBiz;
        public CourseBiz CourseBiz
        {
            set => _CourseBiz = value;
            get
            {
                if (_CourseBiz == null)
                    _CourseBiz = new CourseBiz() { Faculty = _ExamDb.CourseFaculty, ID = _ExamDb.CourseID, NameA = _ExamDb.CourseNameA, NameE = _ExamDb.CourseNameE, Code = _ExamDb.CourseCode };
                return _CourseBiz;
            }
        }
        HallBiz _HallBiz;
        public HallBiz HallBiz { set => _HallBiz = value;
            get
            {
                if (_HallBiz == null)
                    _HallBiz = new HallBiz() { ID = _ExamDb.HallID, Name = _ExamDb.HallName };
                return _HallBiz;
            }
        }
        int _Faculty;
        Hashtable _RegisterationHs;
        public Hashtable RegisterationHs
        {
            get
            {
                if (_RegisterationHs == null)
                {
                    _RegisterationHs = new Hashtable();
                    RegisterationExamDb objDb = new RegisterationExamDb() { Exam = ID, Faculty = _Faculty };
                    DataTable dtTemp = objDb.Search();
                    RegisterationExamBiz objBiz;
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objBiz = new RegisterationExamBiz(objDr);
                        if (_RegisterationHs[objBiz.Registeration.ToString()] == null)
                            _RegisterationHs.Add(objBiz.Registeration.ToString(), objBiz);

                    }
                }
                return _RegisterationHs;
            }
        }
        RegisterationExamCol _RegisterationCol;
        public RegisterationExamCol RegisterationCol
        {
            get
            {
                if (_RegisterationCol == null)
                {
                    _Faculty = CourseBiz.Faculty;
                    _RegisterationCol = new RegisterationExamCol(true);
                    RegisterationCol objCol = new RegisterationCol(CourseBiz.Faculty, SemesterBiz, "", CourseBiz);
                    //RegisterationExamCol objExamCol = new RegisterationExamCol(this, SemesterBiz, CourseBiz, new StudentBiz());

                    List<RegisterationExamBiz> lstReg = (from objReg in objCol.Cast<RegisterationBiz>()
                                                         orderby objReg.StudentBiz.NameA
                                                         let X = RegisterationHs[objReg.ID.ToString()]
                                                         select X == null ? new RegisterationExamBiz() { Date = DateTime.Now, ExamBiz = this, RegisterationBiz = objReg, Note = "" } : (RegisterationExamBiz)X).ToList();
                    foreach (RegisterationExamBiz objExam in lstReg)
                        _RegisterationCol.Add(objExam);
                }
                return _RegisterationCol;
            }
        }
        RegisterationGroupCol _GroupCol;
        public RegisterationGroupCol GroupCol
        {
            set => _GroupCol = value;
            get
            {
                if (_GroupCol == null)
                {
                    _GroupCol = new RegisterationGroupCol(true);

                }
                return _GroupCol;
            }
        }
        List<ExamGroupBiz> _LstGroup;
        public List<ExamGroupBiz> LstGroup {
            set => _LstGroup = value;
            get
            {
                if (_LstGroup == null)
                    _LstGroup = new List<ExamGroupBiz>();
                return _LstGroup;
            } }
        string _StartSeatNo;
        public string StartSeatNo{ set => _StartSeatNo = value; get => _StartSeatNo; }
        string _EndSeatNo;
        public string EndSeatNo { set => _EndSeatNo = value; get => _EndSeatNo; }
        int _RegisteredCount;
        public int RegisteredCount { set => _RegisteredCount = value; get => _RegisteredCount; }
        public static int UMSAllCourses = 2422;
        public static int UMSAllExamType = 2440;
        #endregion
        #region Private Method
        DataTable GetGroupTable(int intUser)
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ExamID"),new DataColumn("GroupID"),new DataColumn("HallID"),new DataColumn("UserID") });
            DataRow objDr;
            foreach(ExamGroupBiz objBiz in  LstGroup)
            {
                objDr = Returned.NewRow();
                 
                objDr["ExamID"] = ID;
                objDr["GroupID"] = objBiz.GroupBiz.ID;
                objDr["HallID"] = objBiz.HallBiz.ID;
                objDr["UserID"] = intUser;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            _ExamDb.Course = CourseBiz.ID;
            _ExamDb.Semester = SemesterBiz.ID;
            _ExamDb.Add();
        }
        public void AddUnique(int intUser)
        {
            _ExamDb.Course = CourseBiz.ID;
            _ExamDb.Semester = SemesterBiz.ID;
            _ExamDb.User = intUser;
            _ExamDb.AddUnique();
        }
        public void Edit(int intUser)
        {
            _ExamDb.Course = CourseBiz.ID;
            _ExamDb.Semester = SemesterBiz.ID;
            _ExamDb.User = intUser;
            _ExamDb.GroupTable = GetGroupTable(intUser);
            _ExamDb.Edit();
        }
        public void Delete()
        {
            _ExamDb.Delete();
        }
        public static void UploadEXamDegree(int intExam,DataTable dtTemp)
        {
            if (intExam == 0)
                return;
            ExamDb objDb = new ExamDb() { ID = intExam ,StudentDegreeTable=dtTemp};
            objDb.UploadExamRegisterationExcel();

        }

        public static void UploadEXam(int intSemester,ExamType objExamType, DataTable dtTemp)
        {
            if (intSemester == 0||dtTemp==null||dtTemp.Rows.Count==0)
                return;
            ExamDb objDb = new ExamDb() { Semester=intSemester,Type = (int)objExamType, StudentDegreeTable = dtTemp };
            objDb.UploadExamRegisterationExcel();

        }
        #endregion
    }
}