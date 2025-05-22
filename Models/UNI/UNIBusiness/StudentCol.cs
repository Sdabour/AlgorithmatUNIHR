using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatMVC.UNI.UniDataBase;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentCol:CollectionBase
    {

        #region Constructor
        public StudentCol()
        {

        }
        public StudentCol(bool blIsEmbty,int intFaculty)
        {
            if (blIsEmbty)
                return;
            StudentBiz objBiz = new StudentBiz();
            

            StudentDb objDb = new StudentDb();
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "StudentNameA");

            foreach (DataRow objDR in arrDr)
            {
                objBiz = new StudentBiz(objDR);
                Add(objBiz);
            }
        }
        public StudentCol( int intFaculty,string strCode)
        {

            StudentBiz objBiz = new StudentBiz();


            StudentDb objDb = new StudentDb();
            objDb.Code = strCode;
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "StudentNameA");

            foreach (DataRow objDR in arrDr)
            {
                objBiz = new StudentBiz(objDR);
                Add(objBiz);
            }
        }
        public StudentCol(int intFaculty,string strCode,int intLevel,int intStatus,bool blIsDateRange,DateTime dtStartDate,DateTime dtEndDate)
        {

            StudentBiz objBiz = new StudentBiz();


            StudentDb objDb = new StudentDb();
            objDb.Faculty = intFaculty;
            objDb.Code = strCode;
            objDb.AllStudent = true;
            objDb.LastGrade = intLevel;
            objDb.IsDateRange = blIsDateRange;
            objDb.StartDate = dtStartDate;
            objDb.EndDate = dtEndDate;
            objDb.Status = intStatus;

            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "StudentNameA");

            foreach (DataRow objDR in arrDr)
            {
                objBiz = new StudentBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public StudentBiz this[int intIndex]
        {
            get
            {
                return (StudentBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach(StudentBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }

        public string ResultIDsStr
        {
            get
            {
                string Returned = "";
                foreach (StudentBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ResultBiz.ID.ToString();
                }
                return Returned;
            }
        }
        CourseCol _CourseCol;
        public CourseCol CourseCol
        {
            set
            {
                _CourseCol = value;
            }
            get
            {
                if (_CourseCol == null)
                    _CourseCol = new CourseCol(true,0);
                return _CourseCol;
            }
        }
        public RegisterationCol RegisterationCol
        {
            get
            {
                RegisterationCol Returned = new RegisterationCol(true,0);
                foreach (StudentBiz objStudent in this)
                {
                    foreach (RegisterationBiz objReg in objStudent.RegisterationCol)
                        Returned.Add(objReg);
                }
                return Returned;
            }
        }
        public List<LevelBiz> LevelLst
        {
            get
            {
               
                List<LevelBiz> Returned = new List<LevelBiz>();
                var vrGrdLst = from objStudent in this.Cast<StudentBiz>()
                            group objStudent by objStudent.LastGrade
                            into GradeID
                            select GradeID;
                LevelBiz objGrade;
                foreach(var vrGrd in vrGrdLst)
                {
                    objGrade = new LevelBiz() { Level = vrGrd.Key };
                   // objGrade.StudentCol = new StudentCol(true);
                    foreach(StudentBiz objStudent in vrGrd.ToList())
                    {
                        objGrade.StudentCol.Add(objStudent);
                    }
                    objGrade.StudentCol.SetRegisterationCol(0);
                    objGrade.CourseCol = objGrade.StudentCol.CourseCol;
                    Returned.Add(objGrade);
                }
                return Returned;
            }
        }
        public List<LevelBiz> PostedLevelLst
        {
            get
            {

                List<LevelBiz> Returned = new List<LevelBiz>();
                var vrGrdLst = from objStudent in this.Cast<StudentBiz>()
                               group objStudent by objStudent.LastGrade
                            into GradeID
                               select GradeID;
                LevelBiz objGrade;
                foreach (var vrGrd in vrGrdLst)
                {
                    objGrade = new LevelBiz() { Level = vrGrd.Key };
                    // objGrade.StudentCol = new StudentCol(true);
                    foreach (StudentBiz objStudent in vrGrd.ToList())
                    {
                        objGrade.StudentCol.Add(objStudent);
                    }
                    objGrade.StudentCol.SetRegisterationCol(1);
                    objGrade.CourseCol = objGrade.StudentCol.CourseCol;
                    Returned.Add(objGrade);
                }
                return Returned;
            }
        }

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(StudentBiz objBiz)
        {
            List.Add(objBiz);
        }
        public StudentCol GetCol(string strTemp,int intLevel)
        {
            StudentCol Returned = new StudentCol(true,0);
            foreach (StudentBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp)&&(intLevel == 0 || objBiz.LastGrade == intLevel))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StudentID"), new DataColumn("StudentCode"), new DataColumn("StudentNameA"), new DataColumn("StudentNameE"), new DataColumn("StudentBirthDate", System.Type.GetType("System.DateTime")), new DataColumn("StudentMobile1"), new DataColumn("StudentMobile2"), new DataColumn("StudentPhone1"), new DataColumn("StudentPhone2"), new DataColumn("StudentAddress"), new DataColumn("StudentEmail"), new DataColumn("StudentHomeCity"), new DataColumn("StudentHomeCountry") });
            DataRow objDr;
            foreach (StudentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["StudentID"] = objBiz.ID;
                objDr["StudentCode"] = objBiz.Code;
                objDr["StudentNameA"] = objBiz.NameA;
                objDr["StudentNameE"] = objBiz.NameE;
                objDr["StudentBirthDate"] = objBiz.BirthDate;
                objDr["StudentMobile1"] = objBiz.Mobile1;
                objDr["StudentMobile2"] = objBiz.Mobile2;
                objDr["StudentPhone1"] = objBiz.Phone1;
                objDr["StudentPhone2"] = objBiz.Phone2;
                objDr["StudentAddress"] = objBiz.Address;
                objDr["StudentEmail"] = objBiz.Email;
                objDr["StudentHomeCity"] = objBiz.HomeCity;
                objDr["StudentHomeCountry"] = objBiz.HomeCountry;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetRegisterationCol(int intPostStatus)
        {
            // objCourseCol = new CourseCol(true);
            _CourseCol = new CourseCol(true,0);
            Hashtable hsCourse = new Hashtable();
            int intFaculty = 0;
            if (Count > 0)
                intFaculty = this[0].Faculty;
            RegisterationDb objDb = new RegisterationDb() { Faculty=intFaculty,StudentIDs = IDsStr ,PostStatus =intPostStatus};
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach(StudentBiz objBiz in this)
            {
                arrDr = dtTemp.Select("RegisterationStudent=" + objBiz.ID, "CourseCode");
                objBiz.RegisterationCol = new RegisterationCol(true,0);

                RegisterationBiz objRegisteration;
                CourseBiz objCourse;
                foreach (DataRow objDr in arrDr)
                {
                    objRegisteration = new RegisterationBiz(objDr);
                    objRegisteration.StudentBiz = objBiz;
                    objCourse = new CourseBiz();
                    if (hsCourse[objRegisteration.Course.ToString()] != null)
                    {
                        objCourse = (CourseBiz)hsCourse[objRegisteration.Course.ToString()];
                        objCourse.RegisterationCol.Add(objRegisteration);
                        //objRegisteration.CourseBiz = objCourse;

                    }
                   
                    if(objCourse.ID==0)
                    {
                        hsCourse.Add(objRegisteration.Course.ToString(), objRegisteration.CourseBiz);
                      //  objCourseCol.Add(objRegisteration.CourseBiz);
                        _CourseCol.Add(objRegisteration.CourseBiz);
                    }
                    objBiz.RegisterationCol.Add(objRegisteration);
                }
            }
            //_CourseCol = objCourseCol;
        }
        public void SetResultRegisterationCol()
        {
            // objCourseCol = new CourseCol(true);
            _CourseCol = new CourseCol(true,0);
            Hashtable hsCourse = new Hashtable();
            RegisterationResultDb objDb = new RegisterationResultDb() { ResultIDs = ResultIDsStr};
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach (StudentBiz objBiz in this)
            {
                arrDr = dtTemp.Select("RegisterationStudent=" + objBiz.ID, "CourseCode");
                objBiz.RegisterationCol = new RegisterationCol(true,0);

                RegisterationResultBiz objRegisteration;
                CourseBiz objCourse;
                foreach (DataRow objDr in arrDr)
                {
                    objRegisteration = new RegisterationResultBiz(objDr);
                    objRegisteration.StudentBiz = objBiz;
                    objRegisteration.Faculty = objBiz.Faculty;
                    objCourse = new CourseBiz();
                    if (hsCourse[objRegisteration.Course.ToString()] != null)
                    {
                        objCourse = (CourseBiz)hsCourse[objRegisteration.Course.ToString()];
                        objCourse.RegisterationCol.Add(objRegisteration);
                        //objRegisteration.CourseBiz = objCourse;

                    }

                    if (objCourse.ID == 0)
                    {
                        hsCourse.Add(objRegisteration.Course.ToString(), objRegisteration.CourseBiz);
                        //  objCourseCol.Add(objRegisteration.CourseBiz);
                        _CourseCol.Add(objRegisteration.CourseBiz);
                    }
                    objBiz.RegisterationCol.Add(objRegisteration);
                }
            }
            //_CourseCol = objCourseCol;
        }
        public DataTable GetPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Code"), new DataColumn("Name"),new DataColumn("CGPA") });
            CourseCol objCourseCol = new CourseCol(true,0);
           // SetRegisterationCol();
            objCourseCol = _CourseCol;
            List<CourseBiz> lstCourse = objCourseCol.Cast<CourseBiz>().OrderBy(x => x.Code).ToList();
            string strCourse = "";

            foreach(CourseBiz objCourse in lstCourse)
            {
                Returned.Columns.Add(new DataColumn(objCourse.NameA));
            }
            DataRow objDr;

            foreach(StudentBiz objStudent in this)
            {
                objDr = Returned.NewRow();
                objDr["Code"] = objStudent.Code;
                objDr["Name"] = objStudent.NameA;
                objDr["CGPA"] = objStudent.RegisterationCol.COMMONGrade.GetPoints(0)+"("+ objStudent.RegisterationCol.COMMONGrade.Verbal+ ")";
                foreach(RegisterationBiz objReg in objStudent.RegisterationCol)
                {
                    objDr[objReg.CourseBiz.NameA] = objReg.COMMONGradeBiz.GetPoints(0)+"("+ objReg.COMMONGradeBiz.Verbal +")";
                }
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        public DataTable GetLastSemesterPivotTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Code"), new DataColumn("Name"), new DataColumn("CGPA") });
            //var vrCourse = this.Cast<StudentBiz>().GroupBy
            CourseCol objCourseCol = new CourseCol(true,0);
            // SetRegisterationCol();
            objCourseCol = RegisterationCol.GetCourseCol(4);

            List<CourseBiz> lstCourse = objCourseCol.Cast<CourseBiz>().ToList();


            string strCourse = "";

            foreach (CourseBiz objCourse in lstCourse)
            {
                Returned.Columns.Add(new DataColumn(objCourse.NameA));
            }
            DataRow objDr;
            List<RegisterationBiz> lstSemRegisteration;
            foreach (StudentBiz objStudent in this)
            {
                objDr = Returned.NewRow();
                objDr["Code"] = objStudent.Code;
                objDr["Name"] = objStudent.NameA;
                objDr["CGPA"] = objStudent.RegisterationCol.COMMONGrade.GetPoints(0);
                lstSemRegisteration = objStudent.RegisterationCol.Cast<RegisterationBiz>().Where(objReg => objReg.Semester == 4).ToList();
                foreach (RegisterationBiz objReg in lstSemRegisteration)
                {
                    objDr[objReg.CourseBiz.NameA] = objReg.COMMONGradeBiz.Verbal;
                }
                Returned.Rows.Add(objDr);

            }
            return Returned;
        }
        public CourseCol GetCourseCol()
        {
            CourseCol Returned = new CourseCol(true,0);
            Hashtable hsCourse = new Hashtable();
           // foreach(StudentBiz objBiz in )
            return Returned;
        }
        public static void UploadStudent(DataTable dtTemp)
        {
            StudentDb objDb = new StudentDb();
            //objDb.AllStudent
        }
        public void EditStatus(int intStatus)
        {
            if (Count == 0)
                return;
            StudentDb objDb = new StudentDb() { IDs = IDsStr, Status = intStatus };
            objDb.EditStatus();
        }
        public void SetLastResultCol()
        {
            if (Count == 0)
                return;
            StudentResultDb objDb = new StudentResultDb() { StudentIDs = IDsStr, LastStatementStatus = 1 ,Faculty=this[0].Faculty};
            DataTable dtTemp = objDb.Search();
            StudentResultBiz objResultBiz;
            DataRow[] arrDr;
            Hashtable hsTemp = new Hashtable();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                objResultBiz = new StudentResultBiz(objDr);
                if(hsTemp[objResultBiz.StudentBiz.ID.ToString()]==null)
                {
                    hsTemp.Add(objResultBiz.StudentBiz.ID.ToString(), objResultBiz) ;
                }
            }
            foreach(StudentBiz objBiz in this)
            {
                if (hsTemp[objBiz.ID.ToString()] != null)
                    objBiz.ResultBiz = (StudentResultBiz)hsTemp[objBiz.ID.ToString()];
            }
        }
        public static StudentCol GetSelectStudentView(int intFaculty)
        {
            StudentCol Returned = new StudentCol(true,0);
            StudentDb objDb = new StudentDb() { Selected=true,Faculty=intFaculty};
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new StudentBiz(objDr));
            }
            return Returned;
        }
        #endregion
    }
}