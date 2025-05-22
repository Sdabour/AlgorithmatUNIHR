using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.UMS.UMSBusiness;
using AlgorithmatMVC.UNI.UNIBusiness;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMVC.Controllers.UNIController
{
   public  class SemesterCourseRegisteration
    {
        public int intCourse;
        
        public int intSemester;
        public int intUser;
        public int intStudent;
        public string strEQNameA;
        public string strEQNameE;
        public int intUni;
        public double dblEQFinalDegree;
        public List<StudentSimple> lstStudent;
        public List<CourseSimple> lstCourse;
        public int FacultyID;

    }
    public class LectureSearch
    {
        public int intUser;
        public int intFaculty; public int intSemester;public int intStudent;public int intType;public int intCourse;public int intProf;public int intSection;public bool blIsDateRange;public DateTime dtStart;public DateTime dtEnd;
    }
    public class ControlAPIController : ApiController
    {
        [Route("api/ControlAPI/EditRegisteration")]
        [ActionName("EditRegisteration")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool EditRegisteration(RegisterationSimple objSimple)
        {
            bool Returned = false;
            UserBiz objUser = new UserBiz(objSimple.UserID);
            if ((objSimple.UserID > 0 || (objSimple.UserName != "" && objSimple.Password != "")) && objUser.ID > 0)
            {
                if (objUser.UserFunctionInstantCol.GetIndex(RegisterationBiz.UMSEditRegistrationDegree) > -1)
                {
                    //MeasureAlertBiz.EditRegisteration(intAlert, objUser.ID);
                    //RegisterationBiz
                    RegisterationBiz.EditRegDegree(objUser.ID,objSimple.ID, objSimple.SemesterWorkDegree, objSimple.MidtermDegree, objSimple.OralDegree, objSimple.PracticalDegree, objSimple.FinalDegree,objSimple.ClinicalDegree, objSimple.Bonus, objSimple.Note);
                    Returned = true;
                }
            }

            return Returned;
        }
        [Route("api/ControlAPI/EditRegisterationStatus")]
        [ActionName("EditRegisterationStatus")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool EditRegisterationStatus(RegisterationSimple objSimple)
        {
            bool Returned = false;
            UserBiz objUser = new UserBiz(objSimple.UserID);
            if ((objSimple.UserID > 0 || (objSimple.UserName != "" && objSimple.Password != "")) && objUser.ID > 0)
            {
                if (objUser.UserFunctionInstantCol.GetIndex(RegisterationBiz.UMSEditRegistrationDegree) > -1)
                {
                    //MeasureAlertBiz.EditRegisteration(intAlert, objUser.ID);
                    //RegisterationBiz
                    RegisterationBiz.EditRegDegree(objUser.ID, objSimple.ID, objSimple.SemesterWorkDegree, objSimple.MidtermDegree, objSimple.OralDegree, objSimple.PracticalDegree, objSimple.FinalDegree, objSimple.Bonus,objSimple.ClinicalDegree, objSimple.Note);
                    Returned = true;
                }
            }

            return Returned;
        }

        [Route("api/ControlAPI/DeleteRegisteration")]
        [ActionName("DeleteRegisteration")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public bool DeleteRegisteration(int intRegisteration,int intFaculty)
        {
            bool Returned = false;
            RegisterationBiz objRegisteration = new RegisterationBiz(intRegisteration,intFaculty);
            if (objRegisteration.Posted || objRegisteration.ResultID > 0)
                Returned = false;
            else
            {
                objRegisteration.Delete();
                Returned = true;
            }
            return Returned;
        }

        [Route("api/ControlAPI/GetSemesterCourse")]
        [ActionName("GetSemesterCourse")]
        [HttpGet]
        public List<CourseSimple> GetSemesterCourse(int intFaculty,int intSemester,string strStudentCode,string strCourseCode)
        {
            if(intSemester == 0)
            {
                intSemester = SemesterBiz.MaxSemester;
            }
            List<CourseSimple> Returned = new List<CourseSimple>();
            RegisterationCol objRegisterationCol = new RegisterationCol(intFaculty,new SemesterBiz() { ID=intSemester},strStudentCode,strCourseCode);
            //var vrCourseGroup = objRegisterationCol.Cast<RegisterationBiz>().GroupBy(x => new { CourseCode = x.CourseBiz.Code, CourseName = x.CourseBiz.NameA });
            var vrCourseGroup = from objReg in objRegisterationCol.Cast<RegisterationBiz>() orderby objReg.CourseBiz.Code group objReg by new {ID=objReg.CourseBiz.ID, CourseCode = objReg.CourseBiz.Code, CourseName = objReg.CourseBiz.NameA } into objCourse select objCourse;

            CourseSimple objSimple = new CourseSimple();
            COMMONGradeSimple objSimpleGrade;
            foreach(var vrCourse in vrCourseGroup)
            {
                objSimple = new CourseSimple() {ID=vrCourse.Key.ID, Code = vrCourse.Key.CourseCode, NameA = vrCourse.Key.CourseName };
                var vrGradeGroup = vrCourse.ToList().OrderByDescending(z=>z.COMMONGradeBiz.MaxPerc).GroupBy(y => new { GPA = y.VerbalGPA }); 
                foreach(var vrGrade in vrGradeGroup)
                {
                    objSimpleGrade = new COMMONGradeSimple() { Verbal = vrGrade.Key.GPA };
                    foreach(RegisterationBiz objBiz in vrGrade.ToList())
                    {
                        objSimpleGrade.RegisterationLst.Add(objBiz.GetSimple());
                    }

                    objSimple.GradeLst.Add(objSimpleGrade);
                    
                }
                objSimple.RegisterationNo = objSimple.GradeLst.Sum(x => x.RegisterationLst.Count);
                Returned.Add(objSimple);
            }
            return Returned;
        }

        [Route("api/ControlAPI/GetCourse")]
        [ActionName("GetCourse")]
        [HttpGet]
        public List<CourseSimple> GetCourse(int intFaculty,int intSemester, string strCourseCode,int intLevel)
        {
           
           

            CourseCol objCourseCol = new CourseCol(intFaculty,strCourseCode, intSemester, intLevel);
            List<CourseSimple> Returned = objCourseCol.Cast<CourseBiz>().Select(x => x.GetSimple()).ToList();

           
           
            return Returned;
        }

        [Route("api/ControlAPI/GetStudentRecommendedCourses")]
        [ActionName("GetStudentRecommendedCourses")]
        [HttpGet]
        public List<CourseSimple> GetStudentRecommendedCourses(int intFaculty,int intStudent,string strCourseCode)
        {
            if (strCourseCode == null)
                strCourseCode = "";


            CourseCol objCourseCol = new CourseCol(true,0);
            if(intStudent!=0)
            {
                StudentBiz objBiz = new StudentBiz() { ID = intStudent,Faculty=intFaculty };
                objCourseCol = objBiz.GetRecommendedCourse();

            }
            List<CourseSimple> Returned = objCourseCol.Cast<CourseBiz>().Where(y=>(strCourseCode==""||(y.Code.CheckStr(strCourseCode))||y.NameA.CheckStr(strCourseCode)||y.NameE.CheckStr(strCourseCode))).Select(x => x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/ControlAPI/GetStudentRegisteredCourses")]
        [ActionName("GetStudentRegisteredCourses")]
        [HttpGet]
        public List<RegisterationSimple> GetStudentRegisteredCourses(int intFaculty,int intStudent, int intSemester)
        {


            RegisterationCol objRegisterationCol = new RegisterationCol(intFaculty,new SemesterBiz() { ID=intSemester},new CourseBiz(),new StudentBiz() { ID=intStudent},0,1,2,2,false);
           // CourseCol objCourseCol = new CourseCol(true);
          
            List<RegisterationSimple> Returned = objRegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/Control/GetRegisteration")]
        [ActionName("GetRegisteration")]
        [HttpGet]
        public List<RegisterationSimple> GetRegisteration( int intFaculty,int intSemester, int intStudent,int intCourse,int intPostStatus,bool? blPreInc=false,int? intLevel=0, int? intCourseLevel = 0,bool? blIncludePre=false)
        {


            RegisterationCol objRegisterationCol = new RegisterationCol(intFaculty,new SemesterBiz() { ID = intSemester }, new CourseBiz() { ID=intCourse}, new StudentBiz() { ID = intStudent }, intLevel.GetValueOrDefault(), 1, intPostStatus, 0,false,intCourseLevel:intCourseLevel, blPreInc: blPreInc.GetValueOrDefault());
            if (blIncludePre.GetValueOrDefault()) 
            {
                objRegisterationCol.SetPrequisitCol();
            }
            // CourseCol objCourseCol = new CourseCol(true);

            List<RegisterationSimple> Returned = objRegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/ControlAPI/GetStudentAllSemester")]
        [ActionName("GetStudentAllSemester")]
        [HttpGet]
        public List<SemesterSimple> GetStudentAllSemester(int intFaculty,int intStudent)
        {


            RegisterationCol objRegisterationCol = new RegisterationCol(intFaculty,new SemesterBiz(), new CourseBiz(), new StudentBiz() { ID = intStudent }, 0, 0, 0, 0,false);
            // CourseCol objCourseCol = new CourseCol(true);
           
           
            SemesterCol objSemCol = objRegisterationCol.SemesterCol;

            List<SemesterSimple> Returned =objSemCol.Cast<SemesterBiz>().Select(x=>x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/ControlAPI/GetAuthorizedCourse")]
        [ActionName("GetAuthorizedCourse")]
        [HttpGet]
        public List<CourseSimple> GetAuthorizedCourse(int intFaculty,int intUser, string strCourseCode)
        {
             

            UserBiz objUserBiz = new UserBiz(intUser);
            List<int> lstAssigned = new List<int>();
            string strCourseIDS = "";
            CourseCol objCourseCol = new CourseCol(intFaculty,strCourseCode, 0, 0);
            // UserBiz objUserBiz = new UserBiz(intUser);
            if (objUserBiz.UserFunctionInstantCol.GetIndex(RegisterationExamBiz.UMSAllCourses) == -1)
            {
                UserObjectAssignmentCol objCol = new AssignmentObjectBiz("ExamCourseFaculty"+intFaculty.ToString()).GetAllAssignedObjectCol(objUserBiz);
                lstAssigned = objCol.Cast<UserObjectAssignmentBiz>().Select(z => z.ObjectValue).ToList();
                strCourseIDS = objCol.IDsStr;
                if (strCourseIDS == "")
                    strCourseIDS = "-1";

            }
            if (objUserBiz.ID==0)
            {
                return new List<CourseSimple>();
            }



            //List<CourseSimple> Returned = objCourseCol.Cast<CourseBiz>().Select(x => x.GetSimple()).ToList();
            List<CourseSimple> Returned = objCourseCol.Cast<CourseBiz>().Select(z=>z.GetSimple()).Where(y=> objUserBiz.UserFunctionInstantCol.GetIndex(RegisterationExamBiz.UMSAllCourses) != -1 || lstAssigned.Where(m=>m==y.ID).ToList().Count>0).ToList();


            return Returned;
        }

        [Route("api/ControlAPI/GetAuthorizedExam")]
        [ActionName("GetAuthorizedExam")]
        [HttpGet]
        public List<ExamSimple> GetAuthorizedExam(int intUser,int intSemester, int intCourse,int intExamType,int intLevel,int intFaculty)
        {
            string strCourseIDS = "";
            //UserBiz objUserBiz = new UserBiz(intUser);
            //if (objUserBiz.UserFunctionInstantCol.GetIndex(RegisterationExamBiz.UMSAllCourses) == -1)
            //{
            //    UserObjectAssignmentCol objCol = new AssignmentObjectBiz("RegisterationExamCourse").GetAllAssignedObjectCol(objUserBiz);
            //    strCourseIDS = objCol.IDsStr;
            //    if (strCourseIDS == "")
            //        strCourseIDS = "-1";

            //}
            ExamCol objExamCol = new ExamCol(intCourse, strCourseIDS, intExamType, intSemester, 1,intLevel,intFaculty);
            objExamCol.SetGroupCol(false,intFaculty);
            List<ExamSimple> Returned = objExamCol.Cast<ExamBiz>().Select(x => x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/ControlAPI/GetCourseRecommededStudent")]
        [ActionName("GetCourseRecommededStudent")]
        [HttpGet]
        public List<StudentSimple> GetCourseRecommededStudent(int intSemester, int intCourse,string strStudentCode)
        {

            CourseBiz objCourse = new CourseBiz() { ID = intCourse };
 
          List<StudentSimple> Returned = new List<StudentSimple>();

            if(intCourse!= 0)
            {
                StudentCol objCol = objCourse.GetRecommendedStudentCol(strStudentCode);
                Returned = objCol.Cast<StudentBiz>().Select(x => x.GetSimple()).ToList();
            }

            return Returned;
        }
        [Route("api/Control/GetStudent")]
        [ActionName("GetStudent")]
        [HttpGet]
        public List<StudentSimple> GetStudent(int intFaculty,int intLevel,  string strStudentCode)
        {

            

            List<StudentSimple> Returned = new List<StudentSimple>();

            StudentCol objCol = new StudentCol(intFaculty,strStudentCode, intLevel, 1, false, DateTime.Now, DateTime.Now);
            Returned = objCol.Cast<StudentBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }

        [Route("api/Control/GetTeacher")]
        [ActionName("GetTeacher")]
        [HttpGet]
        public List<TeacherSimple> GetTeacher(int intFaculty, int intType, string strTeacherCode)
        {



            List<TeacherSimple> Returned = new List<TeacherSimple>();

            TeacherCol objCol = new TeacherCol(intFaculty, intType,strTeacherCode);
            Returned = objCol.Cast<TeacherBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }

        [Route("api/Control/GetStudentResult")]
        [ActionName("GetStudentResult")]
        [HttpGet]
        public List<StudentResultSimple> GetStudentResult(int intFaculty,int intStatement,int intLevel, string strStudentCode,int intStoppedStatus)
        {
  List<StudentResultSimple> Returned = new List<StudentResultSimple>();

            StudentResultCol objCol = new StudentResultCol(intFaculty,new ResultStatementBiz() { ID=intStatement},intLevel,strStudentCode,intStoppedStatus,false);
            Returned = objCol.Cast<StudentResultBiz>().Select(x => x.GetSimple()).ToList();

            return Returned;
        }


        [Route("api/ControlAPI/GetCourseRegisteredStudent")]
        [ActionName("GetCourseRegisteredStudent")]
        [HttpGet]
        public List<RegisterationSimple> GetCourseRegisteredStudent(int intFaculty,int intSemester, int intCourse, string strStudentCode)
        {

            CourseBiz objCourse = new CourseBiz() { ID = intCourse };
            RegisterationCol objRegisterationCol = new RegisterationCol(intFaculty, new SemesterBiz() { ID = intSemester }, strStudentCode, new CourseBiz() { ID = intCourse });
            List<RegisterationSimple> Returned = new List<RegisterationSimple>();

          
                Returned = objRegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList();
           
            return Returned;
        }
        [Route("api/ControlAPI/UploadRegisteredStudent")]
        [ActionName("UploadRegisteredStudent")]
        [HttpPost]
        public void UploadRegisteredStudent(SemesterCourseRegisteration objReg)
        {
            if (objReg.intStudent == 0 && objReg.intCourse > 0)
            {
                RegisterationBiz.RegisterStudentCol(objReg.intUser, objReg.intSemester, objReg.intCourse, objReg.lstStudent.Select(x => x.ID).ToList());
            }
            else
            {
                RegisterationBiz.RegisterCourseCol(objReg.FacultyID,objReg.intUser, objReg.intSemester, objReg.intStudent, objReg.lstCourse.Select(x => x.ID).ToList());
            }
        }
        [Route("api/ControlAPI/AddEditExam")]
        [ActionName("AddEditExam")]
        [HttpPost]
        public ExamSimple AddEditExam(ExamSimple objExam) 
        {
            ExamBiz objBiz = objExam.GetBiz();
            if(objBiz.CourseBiz.ID>0&&objBiz.SemesterBiz.ID>0 &&objBiz.Type!=0 && objExam.ID==0)
            {
                objBiz.AddUnique(objExam.User);
            }
            else if(objExam.ID!=0)
            {
                objBiz.Edit(objExam.User);
            }
            objExam.ID = objBiz.ID;
            return objExam;
        }
        [Route("api/ControlAPI/AddEditLecture")]
        [ActionName("AddEditLecture")]
        [HttpPost]
        public LectureSimple AddEditLecture(LectureSimple objLecture)
        {
            LectureBiz objBiz = objLecture.GetBiz();
            //objBiz.Type = objLecture.TypeSimple.ID;
            if (objBiz.CourseBiz.ID > 0 && objBiz.SemesterBiz.ID > 0 && objBiz.TypeBiz.ID != 0 && objLecture.ID == 0)
            {
                objBiz.AddUnique(objLecture.User);
            }
            objLecture.ID = objBiz.ID;
            objLecture.GUUID = objBiz.GUUID;
            return objLecture;
        }

        [Route("api/ControlAPI/SearchLecture")]
        [ActionName("SearchLecture")]
        [HttpPost]
        [AcceptVerbs("GET", "POST")]
        public List<LectureSimple> SearchLecture(LectureSearch objSearch)
        {
            string strCourseIDS = "";
            //UserBiz objUserBiz = new UserBiz(intUser);
            //if (objUserBiz.UserFunctionInstantCol.GetIndex(RegisterationLectureBiz.UMSAllCourses) == -1)
            //{
            //    UserObjectAssignmentCol objCol = new AssignmentObjectBiz("RegisterationLectureCourse").GetAllAssignedObjectCol(objUserBiz);
            //    strCourseIDS = objCol.IDsStr;
            //    if (strCourseIDS == "")
            //        strCourseIDS = "-1";

            //}

            LectureCol objLectureCol = new LectureCol(objSearch.intFaculty,objSearch.intSemester,objSearch.intStudent,objSearch.intType,objSearch.intCourse,objSearch.intProf,objSearch.intSection,objSearch.blIsDateRange,objSearch.dtStart,objSearch.dtEnd);
            List<LectureSimple> Returned = objLectureCol.Cast<LectureBiz>().Select(x => x.GetSimple()).ToList();



            return Returned;
        }

        [Route("api/ControlAPI/AddEditRegisterationGroup")]
        [ActionName("AddEditRegisterationGroup")]
        [HttpPost]
        public RegisterationGroupSimple AddEditRegisterationGroup(RegisterationGroupSimple objRegisterationGroup)
        {
            RegisterationGroupBiz objBiz = objRegisterationGroup.GetBiz();
            if (objBiz.CourseBiz.ID > 0 && objBiz.SemesterBiz.ID > 0 &&objBiz.NameA!= null &&objBiz.NameA!="")
            {
                objBiz.AddUnique(objRegisterationGroup.User);
            }
            objRegisterationGroup.ID = objBiz.ID;
            return objRegisterationGroup;
        }

        [Route("api/ControlAPI/UploadRegisterationGroupStudent")]
        [ActionName("UploadRegisterationGroupStudent")]
        [HttpPost]
        public RegisterationGroupSimple UploadRegisterationGroupStudent(RegisterationGroupSimple objRegisterationGroup)
        {
            RegisterationGroupBiz objBiz = objRegisterationGroup.GetBiz();
          if(objRegisterationGroup.StudentIDLst.Count >0)
            {
                objBiz.JoinRegisterationLst(objRegisterationGroup.StudentIDLst);
            }
            return objRegisterationGroup;
        }

        [Route("api/ControlAPI/DeleteRegisterationGroupStudent")]
        [ActionName("DeleteRegisterationGroupStudent")]
        [HttpPost]
        public RegisterationGroupSimple DeleteRegisterationGroupStudent(RegisterationGroupSimple objRegisterationGroup)
        {
            RegisterationGroupBiz objBiz = objRegisterationGroup.GetBiz();
          
                objBiz.DeleteStudent();
          
            return objRegisterationGroup;
        }

        [Route("api/ControlAPI/GetRegisterationGroup")]
        [ActionName("GetRegisterationGroup")]
        [HttpGet]
        public List<RegisterationGroupSimple> GetRegisterationGroup(int intFaculty, int intSemester, int intCourse,int intLectureType,int intEXamType,int intCourseLevel)
        {
            if (intSemester == 0)
            {
                intSemester = SemesterBiz.MaxSemester;
            }
            List<RegisterationGroupSimple> Returned = new List<RegisterationGroupSimple>();
            RegisterationGroupCol objCol = new RegisterationGroupCol(intFaculty, intSemester, intCourse, intLectureType,intEXamType,intCourseLevel);
            Returned = objCol.Cast<RegisterationGroupBiz>().Select(x => x.GetSimple()).ToList() ;
            return Returned;
        }

        [Route("api/ControlAPI/GetHall")]
        [ActionName("GetHall")]
        [HttpGet]
        public List<HallSimple> GetHall(int intFaculty)
        {
            HallCol objCol = new HallCol(intFaculty);
            List<HallSimple> Returned = objCol.Cast<HallBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;
        }
        [Route("api/ControlAPI/GetRegisterationGroupXML")]
        [ActionName("GetRegisterationGroupXML")]
        [HttpGet]
        public string GetRegisterationGroupXML(int intFaculty, int intSemester, int intCourse, int intLectureType, int intCourseLevel)
        {
            if (intSemester == 0)
            {
                intSemester = SemesterBiz.MaxSemester;
            }
            RegisterationGroupCol objCol = new RegisterationGroupCol(intFaculty, intSemester, intCourse, intLectureType,0, intCourseLevel);
            objCol.SetRegisterationCol(intFaculty);
            DataTable dtTemp = objCol.GetRegisterationTable();
            DataSet Ds = new DataSet();
            Ds.Tables.Add(dtTemp);

            string Returned = Ds.GetXml();
             
            return Returned;
        }

        [Route("api/ControlAPI/GetRegisterationGroupStudent")]
        [ActionName("GetRegisterationGroupStudent")]
        [HttpGet]
        public List<RegisterationSimple> GetRegisterationGroupStudent(int intFaculty, int intGroup)
        {
            List<RegisterationSimple> Returned = new List<RegisterationSimple>();
            RegisterationGroupBiz objBiz = new RegisterationGroupBiz() { ID = intGroup, FacultyBiz = new FacultyBiz() { ID = intFaculty } };
            Returned = objBiz.RegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).OrderBy(y=>y.StudentName).ToList();
            return Returned;
        }
        [Route("api/ControlAPI/GetRegisterationGroupRecommendedStudent")]
        [ActionName("GetRegisterationGroupRecommendedStudent")]
        [HttpGet]
        public List<RegisterationSimple> GetRegisterationGroupRecommendedStudent(int intFaculty, int intGroup)
        {
            List<RegisterationSimple> Returned = new List<RegisterationSimple>();
            RegisterationGroupBiz objBiz = new RegisterationGroupBiz() { ID = intGroup, FacultyBiz = new FacultyBiz() { ID = intFaculty } };
            Returned = objBiz.RecommendedRegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).OrderBy(z=> { int intTemp = 0;int.TryParse(z.SeatNo, out intTemp);return intTemp; }).ToList();
            return Returned;
        }
        [Route("api/ControlAPI/UploadRegisterationEQ")]
        [ActionName("UploadRegisterationEQ")]
        [HttpPost]
        public void UploadRegisterationEQ(SemesterCourseRegisteration objReg)
        {
            //RegisterationBiz.RegisterStudentCol(objReg.intUser, objReg.intSemester, objReg.intCourse, objReg.lstStudent.Select(x => x.ID).ToList());
        }
        [Route("api/ControlAPI/CheckRegisterationEQ")]
        [ActionName("CheckRegisterationEQ")]
        [HttpPost]
        public bool CheckRegisterationEQ(int intFaculty,SemesterCourseRegisteration objReg)
        {
            RegisterationCol objCol = new RegisterationCol(intFaculty,new SemesterBiz(), new CourseBiz() { ID = objReg.intCourse }, new StudentBiz() { ID = objReg.intStudent },0, 0, 0, 0,false);
            return objCol.Count == 0;
        }


        [Route("api/ControlAPI/GetExamRegisteration")]
        [ActionName("GetExamRegisteration")]
        [HttpGet]
        public List<RegisterationExamSimple> GetExamRegisteration(int intExam,int intOrderType,int? intRegisteration=0,int?intFaculty=0)
        {

             
            ExamBiz objExam = new ExamBiz(intExam);
            RegisterationExamCol objRegCol = new RegisterationExamCol(true);
            if (intExam != 0)
            {
                 objRegCol =objExam.RegisterationCol;
            }
            else if(intRegisteration.GetValueOrDefault()!=0)
            {
                objRegCol = new RegisterationExamCol(objExam, new SemesterBiz(), new CourseBiz(), new StudentBiz(), intFaculty.GetValueOrDefault(), intRegisteration.GetValueOrDefault());
            }            
List<RegisterationExamSimple> Returned = objRegCol.Cast<RegisterationExamBiz>().Select(x=>x.GetSimple()).OrderBy(y=> intOrderType==0? y.RegisterationSimple.StudentCode: y.RegisterationSimple.StudentName).ToList();

            return Returned;
        }

        [Route("api/ControlAPI/GetLectureRegisteration")]
        [ActionName("GetLectureRegisteration")]
        [HttpGet]
        public List<RegisterationSimple> GetLectureRegisteration(int intLecture, int intOrderType)
        {


            LectureBiz objLecture = new LectureBiz(intLecture);
            List<RegisterationSimple> Returned = objLecture.RegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).OrderBy(y => intOrderType == 0 ? y.StudentCode : y.StudentName).ToList();

            return Returned;
        }
        [Route("api/ControlAPI/GetLectureQR")]
        [ActionName("GetLectureQR")]
        [HttpGet]
        public string GetLectureQR(int intLectureID)
        {
            LectureBiz objBiz = new LectureBiz(intLectureID);
            string strQR = SharpVision.SystemBase.SysUtility.GenerateBarcode(objBiz.GUUID);
            string imgQRURL = string.Format("data:image/jpg;base64,{0}", strQR);
            return imgQRURL;

        }
        [Route("api/ControlAPI/UploadRegExamGrade")]
        [ActionName("UploadRegExamGrade")]
        [HttpPost]
        public void UploadRegExamGrade(RegisterationExamSimple objReg)
        {
            RegisterationExamBiz objBiz;
            if (objReg.RegisterationSimple!= null &&objReg.RegisterationSimple.ID>0&& objReg.lstExam.Count == 0)
            {
                 objBiz = objReg.GetBiz();
                if (objBiz.ID == 0)
                {
                    objBiz.Add();
                }
                else
                objBiz.Edit();
            }
            else
            {
                RegisterationExamCol objExamCol = new RegisterationExamCol(true);

                foreach(RegisterationExamSimple objSimple in objReg.lstExam)
                {
                    objBiz = objSimple.GetBiz();
                    //objBiz.Edit();
                    objExamCol.Add(objBiz);

                }
                objExamCol.UploadMultiExam(objReg.EvaluationUsr);

            }
        }


        public void UploadRegCol(RegisterationSimple objReg)
        {
           
            UserBiz objUser = new UserBiz(objReg.UserID);
            if ((objReg.UserID > 0 || (objReg.UserName != "" && objReg.Password != "")) && objUser.ID > 0)
            {
                if (objUser.UserFunctionInstantCol.GetIndex(RegisterationBiz.UMSEditRegistrationDegree) > -1)
                {
                    //MeasureAlertBiz.EditRegisteration(intAlert, objUser.ID);
                    //RegisterationBiz
                    foreach (RegisterationSimple objSimple in objReg.lstReg)
                    { RegisterationBiz.EditRegDegree(objUser.ID, objSimple.ID, objSimple.SemesterWorkDegree, objSimple.MidtermDegree, objSimple.OralDegree, objSimple.PracticalDegree, objSimple.FinalDegree, objSimple.Bonus,objSimple.ClinicalDegree, objSimple.Note); }
                   
                }
            }

        }

        DataTable GetTable(List<RegisterationSimple> lstReg)
        {
            double dblTemp = 0;
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Semester"), new DataColumn("StudentCode"), new DataColumn("CourseCode"), new DataColumn("SW"), new DataColumn("MT"), new DataColumn("Practical"), new DataColumn("Oral"), new DataColumn("Final"), new DataColumn("Bonus") });
            DataRow objDrTemp;
            
            foreach (RegisterationSimple objSimple  in lstReg)
            {
                objDrTemp = Returned.NewRow();

                objDrTemp["Semester"] = objSimple.Semester;
                
                objDrTemp["StudentCode"] = objSimple.StudentCode;

               
                objDrTemp["CourseCode"] =objSimple.CourseCode;
                dblTemp = 0;
               
                objDrTemp["SW"] = objSimple.SemesterWorkDegree;
                dblTemp = 0;
                
                objDrTemp["MT"] = objSimple.MidtermDegree;
                dblTemp = 0;
               
                objDrTemp["Practical"] = objSimple.PracticalDegree;
             
                objDrTemp["Oral"] = objSimple.OralDegree;

             
                objDrTemp["Final"] = objSimple.FinalDegree;

 
                objDrTemp["Bonus"] = objSimple.Bonus;
                Returned.Rows.Add(objDrTemp);
            }
            return Returned;
        }

    }
}
