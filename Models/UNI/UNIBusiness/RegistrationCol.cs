using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationCol:CollectionBase
    {

        #region Constructor
        public RegisterationCol()
        {

        }
        public RegisterationCol(bool blIsEmbty,int intFaculty)
        {
            if (blIsEmbty)
                return;
            RegisterationBiz objBiz = new RegisterationBiz();
            

            RegisterationDb objDb = new RegisterationDb() {Faculty=intFaculty };
             
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationBiz(objDR);
                Add(objBiz);
            }
        }
        public RegisterationCol(int intFaculty,SemesterBiz objSemester,string strStudentCode,string strCourseCode)
        {
            if (objSemester == null)
                objSemester = new SemesterBiz();
            if (objSemester.ID == 0)
                return;
            RegisterationDb objDb = new RegisterationDb();
            objDb.Semester = objSemester.ID;
            objDb.StudentCode = strStudentCode;
            objDb.CourseCode = strCourseCode;
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();
            RegisterationBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationBiz(objDR);
                Add(objBiz);
            }
        }
        public RegisterationCol(int intFaculty,SemesterBiz objSemester, string strStudentCode, CourseBiz objCourseBiz)
        {
            if (objSemester == null)
                objSemester = new SemesterBiz();
            if (objSemester.ID == 0)
                return;
            if (objCourseBiz == null || objCourseBiz.ID == 0)
                return;
            RegisterationDb objDb = new RegisterationDb();
            objDb.Semester = objSemester.ID;
            objDb.StudentCode = strStudentCode;
            objDb.Course = objCourseBiz.ID;
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();
            RegisterationBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationBiz(objDR);
                Add(objBiz);
            }
        }

        public RegisterationCol(int intFaculty,SemesterBiz objSemester, CourseBiz objCourseBiz,StudentBiz objStudent, int intLevel,int intStatus,int intPostStatus,int intStatementStatus,bool blSelected,int?intCourseLevel=0,bool? blPreInc=false)
        {
            if (objSemester == null)
                objSemester = new SemesterBiz();
            if (objStudent == null)
                objStudent = new StudentBiz();
            
            RegisterationDb objDb = new RegisterationDb();
            objDb.Semester = objSemester.ID;
            objDb.CourseLevel = intCourseLevel.GetValueOrDefault();
            objDb.OnlyNonCompleted = blPreInc.GetValueOrDefault();
            objDb.Faculty = intFaculty;
            objDb.Course = objCourseBiz.ID;
            objDb.Student = objStudent.ID;
            objDb.PostStatus = intPostStatus;
            objDb.ResultStatus = intStatementStatus;
            objDb.OnlySelected = blSelected;
            objDb.Status = intStatus;
            objDb.Level = intLevel;
            DataTable dtTemp = objDb.Search();
            RegisterationBiz objBiz;
            
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationBiz(objDR);
               
                    Add(objBiz);
               
            }
        }

        public RegisterationCol(int intFaculty, SemesterBiz objSemester, CourseBiz objCourseBiz, StudentCol objStudentCol, int intPostStatus, int intStatementStatus)
        {
            if (objSemester == null)
                objSemester = new SemesterBiz();
            if (objStudentCol == null)
                objStudentCol = new StudentCol(true,0);

            RegisterationDb objDb = new RegisterationDb();
            objDb.Semester = objSemester.ID;
            objDb.Faculty = intFaculty;
            objDb.Course = objCourseBiz.ID;
            objDb.StudentIDs = objStudentCol.IDsStr;
            objDb.PostStatus = intPostStatus;
            objDb.ResultStatus = intStatementStatus;
            
            DataTable dtTemp = objDb.Search();
            RegisterationBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationBiz(objDR);

                Add(objBiz);

            }
        }
       
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public RegisterationBiz this[int intIndex]
        {
            get
            {
                return (RegisterationBiz)this.List[intIndex];
            }
        }
        public int TotalCreditHours
        {
            get
            {
                int Returned = 0;
                Hashtable hsTemp = new Hashtable();
                CourseCol objCourseCol = new CourseCol(true,0);
                var vrCourse = this.Cast<RegisterationBiz>().Where(y => y.Status != RegisterationStatus.IC && y.Status != RegisterationStatus.W &&y.Posted).GroupBy(x => new{ ID = x.CourseBiz.ID, NameA = x.CourseBiz.NameA, CreditHour = x.CourseBiz.CreditHour }).Select(y=>new CourseBiz() { ID=y.Key.ID,NameA=y.Key.NameA,CreditHour=y.Key.CreditHour});
                Returned = vrCourse.Sum(z => z.CreditHour);
                    
                return Returned;
            }
        }
        public int TotalComputedCreditHours
        {
            get
            {
                int Returned = 0;
                Hashtable hsTemp = new Hashtable();
                CourseCol objCourseCol = new CourseCol(true, 0);
                var vrCourse = this.Cast<RegisterationBiz>().Where(y => y.Status != RegisterationStatus.IC && y.Status != RegisterationStatus.W && y.Status != RegisterationStatus.P && y.Posted).GroupBy(x => new { ID = x.CourseBiz.ID, NameA = x.CourseBiz.NameA, CreditHour = x.CourseBiz.CreditHour }).Select(y => new CourseBiz() { ID = y.Key.ID, NameA = y.Key.NameA, CreditHour = y.Key.CreditHour });
                Returned = vrCourse.Sum(z => z.CreditHour);

                return Returned;
            }
        }
        public int EarnedCreditHours
        {
            get
            {
                int Returned = 0;
                Hashtable hsTemp = new Hashtable();
                CourseCol objCourseCol = new CourseCol(true,0);
                var vrCourse = this.Cast<RegisterationBiz>().Where(y => y.Status != RegisterationStatus.IC && y.Status != RegisterationStatus.W && y.Status != RegisterationStatus.DS&& y.Status != RegisterationStatus.DN && y.Status != RegisterationStatus.WF && y.COMMONGradeBiz.Verbal!="F"&&y.Posted).GroupBy(x => new{ ID = x.CourseBiz.ID, NameA = x.CourseBiz.NameA, CreditHour = x.CourseBiz.CreditHour }).Select(y => new CourseBiz() { ID = y.Key.ID, NameA = y.Key.NameA, CreditHour = y.Key.CreditHour });
                Returned = vrCourse.Sum(z => z.CreditHour);

                return Returned;
            }
        }
        public COMMONGradeBiz COMMONGrade
        {
            get
            {
                
              
                Hashtable hsTemp = new Hashtable();
                
                CourseCol objCourseCol = new CourseCol(true,0);
                var vrCourse = this.Cast<RegisterationBiz>().Where(y => (y.Status != RegisterationStatus.IC && y.Status != RegisterationStatus.W && y.Status != RegisterationStatus.P) && y.Posted).Select(x => x.CourseBiz).Distinct();

                int dblCrdHour = 0;
                int intCreditHour = 0;
                if (vrCourse != null && vrCourse.Count() > 0)
                {
                    dblCrdHour = vrCourse.Select(x => x.CreditHour).Sum();

                    //DataTable dtTemp = new DataTable();
                    //dtTemp.Columns.AddRange(new DataColumn[] { new DataColumn("ID"), new DataColumn("Name") });
                    //DataRow objDr;
                    foreach (var item in vrCourse)
                    {
                        if (hsTemp[item.ID.ToString()] == null)
                        {
                            hsTemp.Add(item.ID.ToString(), item);
                            objCourseCol.Add(item);
                        }
                    }
                    dblCrdHour = objCourseCol.Cast<CourseBiz>().Sum(x => x.CreditHour);
                   
                    intCreditHour = TotalComputedCreditHours;
                    dblCrdHour = intCreditHour;

                }
                RegisterationBiz objRegBiz = Count==0? new RegisterationBiz(): this[0];
                    double dblTotal = AppliedRegisterationCol.Cast<RegisterationBiz>().Select(x => x.COMMONGradeBiz.GetPoints(x.Perc)*x.CourseBiz.CreditHour).Sum();
                dblTotal = dblCrdHour >0? dblTotal/dblCrdHour:0;
                dblTotal = double.Parse(dblTotal.ToString("0.00"));
                COMMONGradeBiz Returned = COMMONGradeCol.CacheCOMMONGradeCol.GetCOMMONGradeByPoints(dblTotal,objRegBiz.Faculty).Copy();
                if (Returned.Points != Returned.MaxPoints)
                {
                    Returned.Points = dblTotal;
                    Returned.MaxPoints = dblTotal;
                }
                return Returned;

            }
        }
        public RegisterationCol AppliedRegisterationCol
        {
        get
            {
                RegisterationCol Returned = new RegisterationCol(true,0);
                Hashtable hsTemp = new Hashtable();
                var vrRegisteration = this.Cast<RegisterationBiz>().Where(y => y.Status != RegisterationStatus.IC && y.Status != RegisterationStatus.W && y.Status != RegisterationStatus.Canceled && y.Status != RegisterationStatus.DN && y.Status != RegisterationStatus.DS && y.Posted&&y.COMMONGradeBiz.Verbal!="F").OrderByDescending(objReg =>objReg.Perc).GroupBy(y => new {y.Course,y.Student });
                foreach(var vrRegGroup in  vrRegisteration)
                {
                    if (vrRegGroup.Count() > 0)
                    {
                        Returned.Add(vrRegGroup.ToList()[0]);
                    }
                    }
                return Returned;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach(RegisterationBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }

        public SemesterCol SemesterCol
        {
            get
            {
                SemesterCol Returned = new SemesterCol(true);
                var vrSemesterLst = from objReg in this.Cast<RegisterationBiz>()
                                    orderby (objReg.SemesterBiz.Type== SemesterType.EQ?1 :0),objReg.SemesterBiz.ID descending,objReg.CourseBiz.Code ascending

                                 group objReg by new { ID = objReg.SemesterBiz.ID, Desc = objReg.SemesterBiz.Desc, Type = objReg.SemesterBiz.Type }
                                 into objSem
                                 select objSem;
                SemesterBiz objSemester;
                foreach(var vrSem in vrSemesterLst)
                {
                    objSemester = new SemesterBiz() { ID = vrSem.Key.ID, Desc = vrSem.Key.Desc, Type = vrSem.Key.Type };
                    objSemester.REgisterationCol = new RegisterationCol(true,0);
                    foreach (RegisterationBiz objReg in vrSem.ToList())
                    {
                        objSemester.REgisterationCol.Add(objReg);
                    }
                    Returned.Add(objSemester);
                }

                return Returned;

            }
        }
        public SemesterCol SemesterCol1
        {
            get
            {
                SemesterCol Returned = new SemesterCol(true);
                Hashtable hsTemp = new Hashtable();
                SemesterSimple objSemester;
                foreach(RegisterationBiz objBiz in this)
                {
                    if (hsTemp[objBiz.SemesterBiz.ID.ToString()] == null)
                        hsTemp.Add(objBiz.SemesterBiz.ID.ToString(),objBiz.SemesterBiz.GetSimple());

                    objSemester  = (SemesterSimple)hsTemp[objBiz.SemesterBiz.ID.ToString()];
                  
                }

                return Returned;

            }
        }
        public string StudentIDs
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                var vrStudent = from objReg in this.Cast<RegisterationBiz>() group objReg by objReg.Student into StudentID select StudentID;
                foreach(var vrID in vrStudent)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += vrID.Key.ToString();
                }
                return Returned;
            }
        }
        public CourseCol CourseCol
        {
            get
            {
                CourseCol Returned = new CourseCol(true,0);
                var vrCourse = this.Cast<RegisterationBiz>().GroupBy(x => new{ x.CourseBiz.ID,x.CourseBiz.Code,x.CourseBiz.NameA});
                CourseBiz objBiz = new CourseBiz();
                foreach(var vrCourseBiz in vrCourse)
                {
                    objBiz = new CourseBiz() {ID = vrCourseBiz.Key.ID,Code=vrCourseBiz.Key.Code,NameA=vrCourseBiz.Key.NameA};
                    foreach (var vrReg in vrCourseBiz)
                    {
                        objBiz.RegisterationCol.Add(vrReg);
                    }
                    Returned.Add(objBiz);
                }
                
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(RegisterationBiz objBiz)
        {
            List.Add(objBiz);
        }
        public void Add(List<RegisterationBiz> objCol)
        {
            foreach(RegisterationBiz objBiz in objCol)
             Add(objBiz);

        }
        public RegisterationCol GetCol(string strTemp)
        {
            RegisterationCol Returned = new RegisterationCol(true,0);
            foreach (RegisterationBiz objBiz in this)
            {
                //if (objBiz..CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("RegisterationID"), new DataColumn("RegisterationStudent"), new DataColumn("RegisterationDate", System.Type.GetType("System.DateTime")), new DataColumn("RegisterationSemester"), new DataColumn("RegisterationCourse"), new DataColumn("RegisterationGrade"), new DataColumn("RegisterationIteration"), new DataColumn("MidtermDegree"), new DataColumn("SemesterWorkDegree"), new DataColumn("PracticalDegree"), new DataColumn("OralDegree"), new DataColumn("FinalDegree"), new DataColumn("Bonus") });
            DataRow objDr;
            foreach (RegisterationBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["RegisterationID"] = objBiz.ID;
                objDr["RegisterationStudent"] = objBiz.Student;
                objDr["RegisterationDate"] = objBiz.Date;
                objDr["RegisterationSemester"] = objBiz.Semester;
                objDr["RegisterationCourse"] = objBiz.Course;
                objDr["RegisterationGrade"] = objBiz.Level;
                objDr["RegisterationIteration"] = objBiz.Iteration;
                objDr["MidtermDegree"] = objBiz.MidtermDegree;
                objDr["SemesterWorkDegree"] = objBiz.SemesterWorkDegree;
                objDr["PracticalDegree"] = objBiz.PracticalDegree;
                objDr["OralDegree"] = objBiz.OralDegree;
                objDr["FinalDegree"] = objBiz.FinalDegree;
                objDr["Bonus"] = objBiz.Bonus;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CourseCol GetCourseCol(int intSemesterID)
        {
            CourseCol Returned = new CourseCol(true,0);
            var vrCourse = this.Cast<RegisterationBiz>().Where(x => x.Semester == intSemesterID).GroupBy(y => new { id = y.CourseBiz.ID, code = y.CourseBiz.Code, name = y.CourseBiz.NameA });
            foreach (var vrTemp in vrCourse)
                Returned.Add(new CourseBiz() { ID = vrTemp.Key.id, Code = vrTemp.Key.code, NameA = vrTemp.Key.name });
            return Returned;
        }
        public void Post(bool blPost)
        {
            RegisterationDb objDb = new RegisterationDb() { Posted = blPost ,IDs=IDsStr};
            objDb.EditPosted();
        }
        public StudentCol GetStudentCol(int intSemester)
{
            StudentCol Returned = new StudentCol(true,0);
            string strIDs = "";
            Hashtable hsTemp = new Hashtable();

            foreach(RegisterationBiz objBiz in this)
            {
                if(hsTemp[objBiz.Student.ToString()]== null)
                {
                    hsTemp.Add(objBiz.StudentBiz.ID.ToString(),objBiz.StudentName);
                    if (strIDs != "")
                        strIDs += ",";
                    strIDs += objBiz.StudentBiz.ID.ToString();
                }
            }
            if (strIDs != null && strIDs != "")
            {
                StudentDb objDb = new StudentDb() { IDs = strIDs ,Faculty = this[0].CourseBiz.Faculty,CurrentSemester=intSemester};

                DataTable dtTemp = objDb.Search();
                DataTable dtNonPosted = objDb.GetUnpostedCount();
                StudentBiz objStudentBiz;
                DataRow[] arrDr;
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    objStudentBiz = new StudentBiz(objDr);
                    arrDr = dtNonPosted.Select("StudentID=" + objStudentBiz.ID);
                    if (arrDr.Length > 0)
                    {
                        int intUnPosted = 0;
                        int.TryParse(arrDr[0]["UnPostedCount"].ToString(), out intUnPosted);
                        objStudentBiz.UnPostedCount = intUnPosted;
                    }
                    if(objStudentBiz.UnPostedCount ==0)
                    Returned.Add(objStudentBiz); 
                }
            }
            return Returned;
        }
        public void SetStudentCol(int intFaculty)
        {
            StudentDb objDb = new StudentDb() { Faculty=intFaculty,IDs = StudentIDs };
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            StudentBiz objStudent;
            Hashtable hsTemp = new Hashtable();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                objStudent = new StudentBiz(objDr);
                if (hsTemp[objStudent.ID.ToString()] == null)
                    hsTemp.Add(objStudent.ID.ToString(), objStudent);
            }
           foreach(RegisterationBiz objBiz in this)
            {
                if(hsTemp[objBiz.StudentBiz.ID.ToString()]!=null)
                {
                    objBiz.StudentBiz = (StudentBiz)hsTemp[objBiz.StudentBiz.ID.ToString()];
                }
            }
        }
        public void EditStatus(RegisterationStatus objStatus)
        {
            RegisterationDb objDb = new RegisterationDb() { IDs = IDsStr, Status = (int)objStatus };
            objDb.EditStatus();
        }
        public DataTable GetDegreeTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StudentCode"), new DataColumn("StudentName"), new DataColumn("SW"), new DataColumn("MT"), new DataColumn("Oral"), new DataColumn("Practical"), new DataColumn("Final"), new DataColumn("Bonus") });
            DataRow objDr;
            foreach (RegisterationBiz objBiz in this)
            {
                objDr =
    Returned.NewRow();
                objDr["StudentCode"] = objBiz.StudentBiz.Code;
                objDr["StudentName"] = objBiz.StudentBiz.NameA;
                objDr["SW"] = objBiz.SemesterWorkDegree;
                objDr["MT"] = objBiz.MidtermDegree;
                objDr["Oral"] = objBiz.OralDegree;
                objDr["Practical"] = objBiz.PracticalDegree;
                objDr["Final"] = objBiz.FinalDegree;
                objDr["Bonus"] = objBiz.Bonus;
                Returned.Rows.Add(objDr);
            }

            return Returned;
        }
        public void SetPrequisitCol()
        {
            if (Count == 0)
                return;
            RegisterationDb objDb = new RegisterationDb() { IDs=IDsStr,Faculty=this[0].Faculty,OnlyMaxRegisteration=false};
            DataTable dtTemp = objDb.GetPrequisit();
            DataRow[] arrDr;
            foreach(RegisterationBiz objBiz in this)
            {
                objBiz.PrequisitCol = new RegisterationCol(true, 0);
                arrDr = dtTemp.Select("MainRegisterationID=" + objBiz.ID, "CourseCode,SemesterID Desc");
                foreach(DataRow objDr in arrDr)
                {
                    objBiz.PrequisitCol.Add(new RegisterationBiz(objDr));
                }
            }

        }
        #endregion
    }
}