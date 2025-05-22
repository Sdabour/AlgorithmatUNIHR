using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public static class UNIExtention
    {
        public static StudentSimple GetSimple(this StudentBiz objBiz)
        {
            //lstRegisteration = objBiz.RegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList()
            StudentSimple Returned = new StudentSimple() { Address = objBiz.Address, BirthDate = objBiz.BirthDate, Code = objBiz.Code,Gender=objBiz.Gender, Email = objBiz.Email, HomeCity = objBiz.HomeCity, HomeCountry = objBiz.HomeCountry, ID = objBiz.ID, Mobile1 = objBiz.Mobile1, Mobile2 = objBiz.Mobile2, NameA = objBiz.NameA, NameE = objBiz.NameE, Phone1 = objBiz.Phone1, Phone2 = objBiz.Phone2, Points = objBiz.RegisterationCol.COMMONGrade.GetPoints(0), Verbal = objBiz.RegisterationCol.COMMONGrade.Verbal
           ,EarnedHours=objBiz.RegisterationCol.EarnedCreditHours,TotalHours=objBiz.RegisterationCol.TotalCreditHours,MaxResultCGPA=objBiz.MaxResultCGPA,MaxResultCPoints=objBiz.MaxResultCPoints,MaxResultEarnedHour=objBiz.MaxResultEarnedHour,MaxResultNote=objBiz.MaxResultNote,MaxResultSGPA=objBiz.MaxResultSGPA,MaxResultSPoints=objBiz.MaxResultSPoints,MaxResultTotalCreditHour=objBiz.MaxResultTotalCreditHour,Level=objBiz.LastGrade.ToString(),LastGrade=objBiz.LastGrade };
             COMMONGradeBiz objGrade= objBiz.RegisterationCol.COMMONGrade;
            var vrSemester = from objReg in objBiz.RegisterationCol.Cast<RegisterationBiz>()
                             orderby (objReg.SemesterBiz.Type==SemesterType.EQ ?1:0), objReg.Semester descending
                             group objReg by new { SemesterID = objReg.SemesterBiz.ID, SemesterName = objReg.SemesterBiz.Desc } into objSem
                             select objSem;
            Returned.lstSemester = new List<SemesterSimple>();
            SemesterSimple objSimple;
            RegisterationCol objTempRegiestrationCol;
            foreach (var vrSem in vrSemester)
            {
                objTempRegiestrationCol = new RegisterationCol(true,0);
                objSimple = new SemesterSimple() { Desc = vrSem.Key.SemesterName, ID = vrSem.Key.SemesterID, lstRegisteration = vrSem.ToList().Select(x => x.GetSimple()).ToList() };
                objTempRegiestrationCol.Add(vrSem.ToList());
                objSimple.Grade = objTempRegiestrationCol.COMMONGrade.GetPoints(0);
                objSimple.Verbal = objTempRegiestrationCol.COMMONGrade.Verbal;
                objSimple.TotalHours = objTempRegiestrationCol.TotalCreditHours;
                objSimple.EarnedHours = objTempRegiestrationCol.EarnedCreditHours;
                Returned.lstSemester.Add(objSimple);
            }
            return Returned;
        }

        public static StudentResultSimple GetSimple(this StudentResultBiz objBiz)
        {
            //lstRegisteration = objBiz.RegisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList()
            StudentResultSimple Returned = new StudentResultSimple()
            {
                StudentSimple = objBiz.StudentBiz.GetSimple(),
                ID = objBiz.ID,
                EarnedHour = objBiz.EarnedHour,
                CGPA = objBiz.CGPA,
                CPoints = objBiz.CPoints,
                Level = objBiz.Level,
                Note=objBiz.Note,
                
SCreditHour=objBiz.SCreditHour,
SEarnedHour=objBiz.SEarnedHour,
SGPA=objBiz.SGPA,
SPoints=objBiz.SPoints,
Stopped=objBiz.Stopped,
StopReason=objBiz.StopReason,
TotalCreditHour=objBiz.TotalCreditHour,NewLevelDesc=objBiz.NewLevelDesc,NewLevelOrder=objBiz.NewLevelOrder,OldLevelDesc=objBiz.OldLevelDesc,OldLevelOrder=objBiz.OldLevelOrder
            };
            var vrSemester = from objReg in objBiz.RegisterationCol.Cast<RegisterationBiz>()
                             orderby objReg.Semester descending
                             group objReg by new { SemesterID = objReg.SemesterBiz.ID, SemesterName = objReg.SemesterBiz.Desc } into objSem
                             select objSem;
            Returned.lstSemester = new List<SemesterSimple>();
            SemesterSimple objSimple;
            RegisterationCol objTempRegiestrationCol;
            foreach (var vrSem in vrSemester)
            {
                objTempRegiestrationCol = new RegisterationCol(true,0);
                objSimple = new SemesterSimple() { Desc = vrSem.Key.SemesterName, ID = vrSem.Key.SemesterID, lstRegisteration = vrSem.ToList().Select(x => x.GetSimple()).ToList() };
                objTempRegiestrationCol.Add(vrSem.ToList());
                objSimple.Grade = objTempRegiestrationCol.COMMONGrade.GetPoints(0);
                objSimple.Verbal = objTempRegiestrationCol.COMMONGrade.Verbal;
                objSimple.TotalHours = objTempRegiestrationCol.TotalCreditHours;
                objSimple.EarnedHours = objTempRegiestrationCol.EarnedCreditHours;
                Returned.lstSemester.Add(objSimple);
            }
            return Returned;
        }
        public static SemesterSimple GetSemesterByID(this List<SemesterSimple>lstSemester,int intSemester)
        {
            SemesterSimple Returned = new SemesterSimple();
            List<SemesterSimple> lstTemp = lstSemester.Where(x => x.ID == intSemester).ToList();
            if (lstTemp.Count > 0)
                Returned = lstTemp[0];

            return Returned;
        }
        public static StudentResultBiz GetStudentResult(this StudentBiz objBiz,ResultStatementBiz objStatementBiz)
        {
            StudentSimple objSimple = objBiz.GetSimple();
            SemesterSimple objCurrentSemester = objSimple.lstSemester.GetSemesterByID(objStatementBiz.Semester);
            StudentResultBiz Returned = new StudentResultBiz() { CGPA=objSimple.Verbal,CPoints=objSimple.Points,EarnedHour=objSimple.EarnedHours,Level=objBiz.LastGrade
                ,SGPA=objCurrentSemester.ID>0?objCurrentSemester.Verbal:"",SPoints=objCurrentSemester.ID>0 ?objCurrentSemester.Grade:0,Student=objSimple.ID,TotalCreditHour=objSimple.TotalHours,StudentBiz=objBiz,StatementBiz=objStatementBiz,
                SCreditHour = objSimple.lstSemester.Count > 0 ? objSimple.lstSemester[0].TotalHours : 0,
                SEarnedHour = objSimple.lstSemester.Count > 0 ? objSimple.lstSemester[0].EarnedHours : 0
            };
            Returned.RegisterationCol = objBiz.RegisterationCol;
            return Returned;
        }
        public static StudentResultCol GetResultCol(this StudentCol objCol,ResultStatementBiz objStatementBiz)
        {
            List<LevelBiz> lstLevel = objCol.LevelLst;
            StudentResultCol Returned = new StudentResultCol(true,0);
            List<StudentResultBiz> lstResult = objCol.Cast<StudentBiz>().Select(x => x.GetStudentResult(objStatementBiz)).ToList();
            foreach(StudentResultBiz objResultBiz in lstResult)
            {
                Returned.Add(objResultBiz);
            }
            return Returned;
        }
        public static RegisterationSimple GetSimple(this RegisterationBiz objBiz)
        {
            RegisterationSimple Returned = new RegisterationSimple() { Bonus=objBiz.Bonus,Course=objBiz.CourseBiz.ID,CourseCode=objBiz.CourseBiz.Code,CourseFinalDegree=objBiz.CourseFinalDegree,CourseName=objBiz.CourseBiz.NameA,Date=objBiz.Date,FinalDegree=objBiz.FinalDegree,GPA=objBiz.VerbalGPA,Grade=objBiz.Level,ID=objBiz.ID,Iteration=objBiz.SemesterCount,MidtermDegree=objBiz.MidtermDegree,OralDegree=objBiz.OralDegree,Points=objBiz.Points,PracticalDegree=objBiz.PracticalDegree,Semester=objBiz.Semester,SemesterDesc=objBiz.SemesterBiz.Desc,SemesterWorkDegree=objBiz.SemesterWorkDegree,Student=objBiz.Student,TotalValue=objBiz.TotalValue,CourseSimple=objBiz.CourseBiz.GetSimple(),Note=objBiz.Note,Status= (int)objBiz.Status,StudentCode=objBiz.StudentCode,StudentGender=objBiz.StudentBiz.Gender,StudentName=objBiz.StudentName,EqualName=objBiz.EqualName,ResultID=objBiz.ResultID,Posted=objBiz.Posted,MainRegisterationID=objBiz.MainRegisterationID,SourceFinalDegree=objBiz.SourceFinalDegree,SourceGPA=objBiz.SourceGPA,SourceMidtermDegree=objBiz.SourceMidtermDegree,SourceNote=objBiz.SourceNote,SourceOralDegree=objBiz.SourceOralDegree,SourcePracticalDegree=objBiz.SourcePracticalDegree,SourceRegisterationDate=objBiz.SourceRegisterationDate,SourceRegisterationID=objBiz.SourceRegisterationID,SourceResult=objBiz.SourceResult,SourceSemesterDesc=objBiz.SourceSemesterDesc,SourceSemesterID=objBiz.SourceSemesterID,SourceSemesterWorkDegree=objBiz.SourceSemesterWorkDegree,SourceStatus=objBiz.SourceStatus,SourceVerbalGPA=objBiz.SourceVerbalGPA,SeatNo=objBiz.SeatNO,ClinicalDegree=objBiz.ClinicalDegree,CStatus=objBiz.CStatus,FStatus=objBiz.FStatus,MTStatus=objBiz.MTStatus,OStatus=objBiz.OStatus,PStatus=objBiz.PStatus,SWStatus=objBiz.SWStatus,PrequisitCourseCount=objBiz.PrequisitCourseCount,PrequisitPassedCourseCount=objBiz.PrequisitPassedCourseCount};
            Returned.PrequisitLst = objBiz.PrequisitCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList();
            return Returned;
        }
        public static LevelSimple GetSimple(this LevelBiz objBiz)
        {
            LevelSimple Returned = new LevelSimple() { Level = objBiz.Level, LevelDesc = objBiz.LevelDesc, lstStudent = objBiz.StudentCol.Cast<StudentBiz>().Select(x => x.GetSimple()).ToList(),lstCourse=objBiz.CourseCol.Cast<CourseBiz>().Select(x=>x.GetSimple()).ToList() ,
            CreditHourFrom=objBiz.CreditHourFrom,CreditHourTo=objBiz.CreditHourTo,Desc=objBiz.Desc,Faculty=objBiz.Faculty,ID=objBiz.ID,LowGPALimitedHour=objBiz.LowGPALimitedHour,Order=objBiz.Order,SemesterType1MaxLimitedHour=objBiz.SemesterType1MaxLimitedHour,SemesterType2MaxLimitedHour=objBiz.SemesterType2MaxLimitedHour,SemesterType3MaxLimitedHour=objBiz.SemesterType3MaxLimitedHour};
          
            return Returned;
        }
        public static CourseSimple GetSimple(this CourseBiz objBiz)
        {
            CourseSimple Returned = new CourseSimple() { Code=objBiz.Code,CreditHour=objBiz.CreditHour,Desc=objBiz.Desc,FinalDegree=objBiz.FinalDegree,ID=objBiz.ID,MidtermDegree=objBiz.MidtermDegree,NameA=objBiz.NameA,NameE=objBiz.NameE,OralDegree=objBiz.OralDegree,PracticalDegree=objBiz.PracticalDegree,RecommendedGrade=objBiz.RecommendedGrade,SemesterWorkDegree=objBiz.SemesterWorkDegree,TotalDegree=objBiz.TotalDegree,ClinicalDegree=objBiz.ClinicalDegree};
            return Returned;
        }
        public static SemesterSimple GetSimple(this SemesterBiz objBiz)
        {
            SemesterSimple Retured = new SemesterSimple() { DateEnd = objBiz.DateEnd, DateStart = objBiz.DateStart, Desc = objBiz.Desc, ID = objBiz.ID, MaxStatementID = objBiz.MaxStatementID,Type=(int)objBiz.Type };

            Retured.lstRegisteration = objBiz.REgisterationCol.Cast<RegisterationBiz>().Select(x => x.GetSimple()).ToList();
            return Retured;
        }
      public static ResultStatementSimple GetSimple(this ResultStatementBiz objBiz)
        {
            ResultStatementSimple Returned = new ResultStatementSimple() { ID = objBiz.ID, Date = objBiz.Date, Desc = objBiz.Desc, Faculty = objBiz.Faculty, ResultPublishDate = objBiz.ResultPublishDate, Semester = objBiz.Semester, Status = objBiz.Status };
            return Returned;
        }
       public static ExamSimple GetSimple(this ExamBiz objBiz)
        {
            ExamSimple Returned = new ExamSimple() { CourseSimple = objBiz.CourseBiz.GetSimple(),Date=objBiz.Date,Desc=objBiz.Desc,Grade=objBiz.Grade,ID=objBiz.ID,SemesterSimple=objBiz.SemesterBiz.GetSimple(),Type=(int)objBiz.Type,StartTime=objBiz.StartTime,EndTime=objBiz.EndTime,Hall=objBiz.HallBiz.GetSimple(),TypeStr=objBiz.TypeName};
            Returned.GroupLst = objBiz.LstGroup.Select(x => new ExamGroupSimple() { GroupSimple = x.GroupBiz.GetSimple(), HallSimple = x.HallBiz.GetSimple() }).ToList();
            return Returned;
        }
        public static ExamBiz GetBiz(this ExamSimple objBiz )
        {
            ExamBiz Returned = new ExamBiz() { ID = objBiz.ID, Course = objBiz.CourseSimple.ID, CourseBiz = new CourseBiz() { ID = objBiz.CourseSimple.ID }, Date = objBiz.Date, Desc = objBiz.Desc, Semester = objBiz.SemesterSimple.ID, SemesterBiz = new SemesterBiz() { ID = objBiz.SemesterSimple.ID }, Type = (ExamType)objBiz.Type,EndTime=objBiz.EndTime,StartTime=objBiz.StartTime };
            Returned.LstGroup = objBiz.GroupLst.Select(x => new ExamGroupBiz() { GroupBiz = new RegisterationGroupBiz() { ID = x.GroupSimple.ID }, HallBiz = new HallBiz() { ID = x.HallSimple.ID } }).ToList();
            return Returned;
        }

        public static LectureBiz GetBiz(this LectureSimple objBiz)
        {
            LectureBiz Returned = new LectureBiz() { ID = objBiz.ID, Course = objBiz.CourseSimple.ID, CourseBiz = new CourseBiz() { ID = objBiz.CourseSimple.ID }, Date = objBiz.Date, Semester = objBiz.SemesterSimple.ID, SemesterBiz = new SemesterBiz() { ID = objBiz.SemesterSimple.ID }, TypeBiz = new LectureTypeBiz() { ID = objBiz.TypeSimple.ID,Code=objBiz.CourseSimple.Code,NameA=objBiz.CourseSimple.NameA,NameE=objBiz.CourseSimple.NameE },StartTime =objBiz.StartTime,EndTime=objBiz.EndTime,TeacherBiz=new TeacherBiz() { ID=objBiz.TeacherSimple.ID} };
            return Returned;
        }

        public static LectureSimple GetSimple(this LectureBiz objBiz)
        {
            LectureSimple Returned = new LectureSimple() { CourseSimple = objBiz.CourseBiz.GetSimple(), Date = objBiz.Date,  ID = objBiz.ID, SemesterSimple = objBiz.SemesterBiz.GetSimple(), Type = (int)objBiz.Type, StartTime = objBiz.StartTime, EndTime = objBiz.EndTime };
            //, Hall = objBiz.HallBiz.GetSimple()
            return Returned;
        }

        public static RegisterationExamSimple GetSimple(this RegisterationExamBiz objBiz)
        {
            RegisterationExamSimple Returned = new RegisterationExamSimple() { Date = objBiz.Date, Degree = objBiz.Degree, ExamSimple = objBiz.ExamBiz.GetSimple(), RegisterationSimple = objBiz.RegisterationBiz.GetSimple(),Note=objBiz.Note ,Status=objBiz.Status,ID=objBiz.ID};
            return Returned;
        }
        public static RegisterationExamBiz GetBiz(this RegisterationExamSimple objBiz)
        {
            RegisterationExamBiz Returned = new RegisterationExamBiz() { Date = objBiz.Date, Degree = objBiz.Degree, ExamBiz =new ExamBiz() { ID=objBiz.ExamSimple.ID}, RegisterationBiz =new RegisterationBiz() { ID=objBiz.RegisterationSimple.ID}, Note = objBiz.Note ,Status=objBiz.Status,ID= objBiz.ID};
            return Returned;
          
        }
        public static FacultySimple GetSimple(this FacultyBiz objBiz)
        {
            FacultySimple Returned = new FacultySimple() { Code = objBiz.Code, NameA = objBiz.NameA, ID = objBiz.ID, NameE = objBiz.NameE };
            return Returned;
        }
        public static HallSimple GetSimple(this HallBiz objBiz)
        {
            HallSimple Returned = new HallSimple() { Capacity = objBiz.Capacity, Faculty = objBiz.FacultyBiz.GetSimple(), ID = objBiz.ID, LectureType = objBiz.LectureTypeBiz.GetSimple(), Name = objBiz.Name };
            return Returned;
        }
        public static LectureTypeSimple GetSimple(this LectureTypeBiz objBiz)
        {
            LectureTypeSimple Returned = new LectureTypeSimple() { Code = objBiz.Code, ID = objBiz.ID, NameA = objBiz.NameA, NameE = objBiz.NameE };
            return Returned;
        }
        public static TeacherTypeSimple GetSimple(this TeacherTypeBiz objBiz)
        {
            TeacherTypeSimple Returned = new TeacherTypeSimple() { Code = objBiz.Code, ID = objBiz.ID, NameA = objBiz.NameA,FunctionGroup=objBiz.FunctionGroup,JobNatureID=objBiz.JobNatureID,Order=objBiz.Order };
            return Returned;
        }
        public static TeacherSimple GetSimple(this TeacherBiz objBiz)
        {
            TeacherSimple Returned = new TeacherSimple() { Code = objBiz.Code, ID = objBiz.ID, Name = objBiz.Name, FunctionGroup = objBiz.FunctionGroup, Faculty=objBiz.FacultyBiz.GetSimple(),Type=objBiz.TypeBiz.GetSimple(),FamousName=objBiz.FamousName,ShortName=objBiz.ShortName };
            return Returned;
        }
        public static RegisterationGroupSimple GetSimple(this RegisterationGroupBiz objBiz)
        {
            RegisterationGroupSimple Returned = new RegisterationGroupSimple() { Code = objBiz.Code, Course = objBiz.CourseBiz.GetSimple(), Faculty = objBiz.FacultyBiz.GetSimple(), ID = objBiz.ID, LectureType = objBiz.LectureTypeBiz.GetSimple(), NameA = objBiz.NameA, NameE = objBiz.NameE, Semester = objBiz.SemesterBiz.GetSimple(),ExamType=(int)objBiz.ExamType };
            return Returned;
        }
        public static RegisterationGroupBiz GetBiz(this RegisterationGroupSimple objBiz)
        {
            RegisterationGroupBiz Returned = new RegisterationGroupBiz() {Code=objBiz.Code,
                CourseBiz=new CourseBiz() { ID = objBiz.Course.ID },FacultyBiz=new FacultyBiz() {ID=objBiz.Faculty.ID },ID=objBiz.ID,LectureTypeBiz=new LectureTypeBiz() { ID=objBiz.LectureType.ID},NameA=objBiz.NameA,NameE=objBiz.NameE,SemesterBiz=new SemesterBiz() { ID=objBiz.Semester.ID} ,ExamType=(ExamType)objBiz.ExamType};

            return Returned;
            
        }

    }
}