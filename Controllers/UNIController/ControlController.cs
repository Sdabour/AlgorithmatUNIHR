using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlgorithmatUNI.UNI.UNIReport;
using AlgorithmatMVC.UNI.UNIBusiness;
using System.Data;

namespace AlgorithmatMVC.Controllers.UNIController
{
    public class ControlController : Controller
    {
        // GET: Control
        public ActionResult Index()
        {
            return View("MainControl");
        }
        public ActionResult ResultIndex()
        {
            ViewBag.AfterSaving = true;
            return View("MainControl");
        }
        public ActionResult MainControlCourseIndex()
        {
            return View("MainControlCourse");
        }
        public ActionResult CourseRegisterationIndex()
        {
            return View("StudentRegisteration");
        }
        public ActionResult CourseRegisterationEHIndex()
        {
            return View("CourseRegisterationEH");
        }
        public ActionResult StudentSeach()
        {
            return View("StudentSearch");
        }
        public ActionResult RegisterationSearch()
        {
            return View("RegisterationSearch");
        }
        public ActionResult TeacherSimpleSearch()
        {
            return View("TeacherSimpleSearch");
        }
        public ActionResult RegisterationEdit()
        {
            return View("RegisterationEdit");
        }
        public ActionResult SemesterAddEdit()
        {
            return View("SemesterAddEdit");
        }
        public ActionResult Courses()
        {
            return View("Courses");
        }
        public ActionResult StudentAddEdit()
        {
            return View("StudentAddEdit");
        }
        public ActionResult CourseSimpleSearch()
        {
            return View("CourseSimpleSearch");
        }
        public ActionResult RegisterationExam()
        {
            return View("RegisterationExam");
        }
        public ActionResult StudentResultSearch()
        {
            return View("StudentResultSearch");
        }
        public ActionResult Lecture()
        {
            return View("LectureAddEdit");
        }
        public ActionResult RegisterationGroup()
        {
            return View("RegisterationGroup");
        }
        public ActionResult ExamIndex()
        {
            return View("Exam");
        }
        public ActionResult ExamSearch()
        {
            return View("ExamSearch");
        }
        public ActionResult RegisterationGroupSearch()
        {
            return View("RegisterationGroupSearch");
        }
        public ActionResult Download_RegisterationPDF()
        {

            int intStudent = 0;
            if(Request["StudentID"]!=null)
            {
                int.TryParse(Request["StudentID"], out intStudent);


            }

            int intType = 0;
            if (Request["ReportType"] != null)
            {
                int.TryParse(Request["ReportType"], out intType);


            }
            int intFaculty = 1;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }

            StudentBiz objStudent = new StudentBiz(intStudent,intFaculty);
            int intCourse = 0;
            if (Request["CourseID"] != null)
            {
                int.TryParse(Request["CourseID"], out intCourse);


            }
            int intSemester = 0;
            if (Request["Semester"] != null)
            {
                int.TryParse(Request["Semester"], out intSemester);


            }
            int intLevel = 0;
            if (Request["Level"] != null)
            {
                int.TryParse(Request["Level"], out intLevel);


            }
            int intCourseLevel = 0;
            if (Request["CourseLevel"] != null)
            {
                int.TryParse(Request["CourseLevel"], out intCourseLevel);


            }
            int intPreInc = 0;
            if (Request["PreInc"] != null)
            {
                int.TryParse(Request["PreInc"], out intPreInc);


            }
            int intPostStatus = 0;
            if (Request["PostStatus"] != null)
            {
                int.TryParse(Request["PostStatus"], out intPostStatus);


            }
            int intSelected = 0;
            if (Request["Selected"] != null)
            {
                int.TryParse(Request["Selected"], out intSelected);


            }
            dsUNIStudent ds = new dsUNIStudent();

           // int intPostStatus = 0;
            RegisterationCol objRegCol;
            if (intStudent > 0)
            {
                objRegCol = intType == 0 ? objStudent.NonPostedRegisterationCol : objStudent.PostedRegisterationCol;

            }
            else
            {
                objRegCol = new RegisterationCol(intFaculty,new SemesterBiz() { ID = intSemester }, new CourseBiz() { ID = intCourse }, new StudentBiz() { ID=intStudent}, intLevel, 0, intPostStatus, 0,intSelected==1,intCourseLevel:intCourseLevel,blPreInc:intPreInc==1);
                objRegCol.SetStudentCol(intFaculty);
            }

            SetRegisterationCol(objRegCol,ref ds);
            ReportDocument rd = new ReportDocument();

            if (intType == 0)
            {
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationStudentSimple.rpt"));
            }
            if (intType == 2)
            {
                int intOPCount = objRegCol.Cast<RegisterationBiz>().Where(x => x.CourseBiz.OralDegree > 0).ToList().Count;
                int intCCount = objRegCol.Cast<RegisterationBiz>().Where(x => x.CourseBiz.ClinicalDegree > 0).ToList().Count;
                if (intOPCount > 0&&intCCount==0)
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationCourse.rpt"));
                }
                else if (intCCount > 0)
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationCourseWithClinic.rpt"));
                }
                else
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationCourseNOOP.rpt"));
                }
            }
            else if (intType == 4)
            {
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationCourseSeatNo.rpt"));
            }
            else 
            {
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationStudentSemester.rpt"));
            }
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Registeration_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }

        public ActionResult Download_ResultPDF()
        {

            int intStatement = 0;
            if (Request["StatementID"] != null)
            {
                int.TryParse(Request["StatementID"], out intStatement);


            }

            int intLevel = 0;
            if (Request["Level"] != null)
            {
                int.TryParse(Request["Level"], out intLevel);


            }
            int intDetailed = 0;
            if (Request["Detailed"] != null)
            {
                int.TryParse(Request["Detailed"], out intDetailed);


            }
            int intFaculty = 1;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }
            string strStudentCode = "";
            if (Request["StudentCode"] != null)
            {
               strStudentCode =  Request["StudentCode"];


            }
            int intStoppedStatus = 0;
            if (Request["StoppedStatus"] != null)
            {
                int.TryParse(Request["StoppedStatus"], out intStoppedStatus);


            }

             
            
            dsUNIStudent ds = new dsUNIStudent();
          StudentResultCol  objCol = new StudentResultCol(intFaculty,new ResultStatementBiz() { ID=intStatement}, intLevel, strStudentCode, intStoppedStatus,false);
            objCol.GetStudentResultCol();
            RegisterationCol objRegCol = new RegisterationCol(true,0);
            if (intDetailed == 0)
            {
                List<StudentResultSimple> _ResultLst = objCol.Cast<StudentResultBiz>().Select(x => x.GetSimple()).ToList();


                SetResultLst(_ResultLst, ref ds);
            }
            else
            {
                objCol.SetRegisterationCol();
                 objRegCol = objCol.RegisterationCol;
                SetRegisterationCol(objRegCol, ref ds);
            }
              ReportDocument rd = new ReportDocument();

            if (intDetailed == 0)
            {
                if (intStatement > 0)
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIStudentREsult.rpt"));
                }
                else
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIStudentREsultLast.rpt"));
                }
            }
            else
            {
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationStudentSemester.rpt"));
            }
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Result_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }

        public ActionResult Download_StudentPDF()
        {

            int intStatement = 0;
            if (Request["StatementID"] != null)
            {
                int.TryParse(Request["StatementID"], out intStatement);


            }

            int intLevel = 0;
            if (Request["Level"] != null)
            {
                int.TryParse(Request["Level"], out intLevel);


            }
            int intDetailed = 0;
            if (Request["Detailed"] != null)
            {
                int.TryParse(Request["Detailed"], out intDetailed);


            }
            int intFaculty = 1;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }
            string strStudentCode = "";
            if (Request["StudentCode"] != null)
            {
                strStudentCode = Request["StudentCode"];


            }
            int intStoppedStatus = 0;
            if (Request["StoppedStatus"] != null)
            {
                int.TryParse(Request["StoppedStatus"], out intStoppedStatus);


            }



            dsUNIStudent ds = new dsUNIStudent();
            bool blIsOnlySelected = false;
            int intOnlySelected = 0;
            if (Request["OnlySelected"] != null)
            {
                int.TryParse(Request["OnlySelected"], out intOnlySelected);


            }
            blIsOnlySelected = intOnlySelected == 1;
            StudentCol objStudentCol = new StudentCol(true, 0);
            if (!blIsOnlySelected)
            {
                objStudentCol = new StudentCol(intFaculty, strStudentCode, intLevel, 1, false, DateTime.Now, DateTime.Now);
            }
            else
             objStudentCol = StudentCol.GetSelectStudentView(intFaculty);

            //StudentResultCol objCol = new StudentResultCol(intFaculty, new ResultStatementBiz() { ID = intStatement }, intLevel, strStudentCode, intStoppedStatus, false);

            objStudentCol.SetLastResultCol();





            RegisterationCol objRegCol = new RegisterationCol(true, 0);
            if (intDetailed == 0)
            {
                 


                SetStudentCol(objStudentCol, ref ds);
            }
            else
            {
                                objRegCol = new RegisterationCol(intFaculty, new SemesterBiz(), new CourseBiz(), objStudentCol, 0, 0);
                objRegCol.SetStudentCol(SharpVision.SystemBase.SysData.FacultyID);
                SetRegisterationCol(objRegCol, ref ds);
            }
            ReportDocument rd = new ReportDocument();

            if (intDetailed == 0)
            {
                 
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIStudentResultLastStudentOrder.rpt"));
                }
                
            }
            else
            {
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationStudentSimpleResult.rpt"));
            }
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Result_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }


        public ActionResult Download_GroupPDF()
        {

            int intStatement = 0;
          

            int intLevel = 0;
            if (Request["Level"] != null)
            {
                int.TryParse(Request["Level"], out intLevel);


            }
            int intSemester = 0;
            if (Request["Semester"] != null)
            {
                int.TryParse(Request["Semester"], out intSemester);


            }
            int intDetailed = 0;
            if (Request["Detailed"] != null)
            {
                int.TryParse(Request["Detailed"], out intDetailed);


            }
            int intFaculty = 1;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }

            int intCourse = 0;
            if (Request["Course"] != null)
            {
                int.TryParse(Request["Course"], out intCourse);


            }
            int intLectureType = 0;
            if (Request["LectureType"] != null)
            {
                int.TryParse(Request["LectureType"], out intLectureType);


            }
            int intExamType = 0;
            if (Request["ExamType"] != null)
            {
                int.TryParse(Request["ExamType"], out intExamType);


            }

            dsUNIStudent ds = new dsUNIStudent();
            RegisterationGroupCol objGroupCol = new RegisterationGroupCol(intFaculty, intSemester, intCourse, intLectureType,intExamType, intLevel);
            





            RegisterationCol objRegCol = new RegisterationCol(true, 0);

        
            
            ReportDocument rd = new ReportDocument();

            if (intDetailed == 0)
            {
                objGroupCol.SetRegisterationNo();
                SetGroupCol(objGroupCol, ds);
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIGroup.rpt"));
                }

            }
            else
            {
                objGroupCol.SetRegisterationCol(intFaculty);
                SetGroupRegisterationCol(objGroupCol, ref ds);
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationCourseSeatNoGroup.rpt"));
            }
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Result_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }

        public ActionResult Download_ExamGroupPDF()
        {

            int intStatement = 0;


            int intLevel = 0;
            if (Request["Level"] != null)
            {
                int.TryParse(Request["Level"], out intLevel);


            }
            int intSemester = 0;
            if (Request["Semester"] != null)
            {
                int.TryParse(Request["Semester"], out intSemester);


            }
            int intDetailed = 0;
            if (Request["Detailed"] != null)
            {
                int.TryParse(Request["Detailed"], out intDetailed);


            }
            int intFaculty = 1;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }

            int intCourse = 0;
            if (Request["Course"] != null)
            {
                int.TryParse(Request["Course"], out intCourse);


            }
            int intExamType = 0;
            if (Request["ExamType"] != null)
            {
                int.TryParse(Request["ExamType"], out intExamType);


            }

            ExamCol objExamCol = new ExamCol(intCourse, "", intExamType, intSemester, 0,intLevel,intFaculty);

            dsUNIStudent ds = new dsUNIStudent();
            


            ReportDocument rd = new ReportDocument();

            if (intDetailed == 0)
            {
                objExamCol.SetGroupCol(false,intFaculty);
               SetExamGroupCol(objExamCol, ds);
                {
                    rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIExamGroup.rpt"));
                }

            }
            else
            {
                 objExamCol.SetGroupCol(true,intFaculty);
                int intPracCount = 0;
                if(intDetailed == 3)
                {
                    intPracCount = objExamCol.Cast<ExamBiz>().Where(x => x.Type== ExamType.Oral|| x.Type == ExamType.Practical).ToList().Count;
                }
                string strReportName = intDetailed == 1?"repUNIExamRegisterationSeatNo.rpt":(intDetailed ==2? "repUNIExamRegisterationSeatNoNoSign.rpt":(intDetailed==3?(intPracCount>0? "repUNIExamRegisterationSeatNoDegree.rpt" : "repUNIExamRegisterationSeatNoDegreeNoOP.rpt") : (intDetailed ==4? "repUNIExamRegisterationSeatNoOPDegree.rpt" : "repUNIExamRegisterationSeatNo.rpt")));
                
SetExamRegisterationCol(objExamCol, ref ds);
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), strReportName));
            }
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Exam_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }
        public ActionResult Download_RegisterationExamPDF()
        {

            int intExam = 0;
            if (Request["ExamID"] != null)
            {
                int.TryParse(Request["ExamID"], out intExam);


            }

            int intFaculty = 0;
            if (Request["Faculty"] != null)
            {
                int.TryParse(Request["Faculty"], out intFaculty);


            }





            dsUNIStudent ds = new dsUNIStudent();

            int intPostStatus = 0;
            RegisterationExamCol objExamCol = new RegisterationExamCol(new ExamBiz() { ID = intExam }, new SemesterBiz(), new CourseBiz(), new StudentBiz(),intFaculty,intRegisteration:0);
          

            SetRegisterationExamCol(objExamCol, ref ds);
            ReportDocument rd = new ReportDocument();

          
                rd.Load(Path.Combine(Server.MapPath("~/views/UNIReport"), "repUNIRegisterationExam.rpt"));
          
            rd.SetDataSource(ds);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            string strPdf = "Exam_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            return File(stream, "application/pdf", strPdf);
        }

        void SetRegisterationCol(RegisterationCol _RegisterationCol,ref dsUNIStudent _DS)
        {
            if (_RegisterationCol == null)
                return;
            DataTable dtReg = _DS.Tables["Registeration"];
            DataRow drReg;

            int intRecordNo;
            var vrCourseGroup = _RegisterationCol.Cast<RegisterationBiz>().GroupBy(x => new { x.Course, x.Semester });
            foreach (var vrReg in vrCourseGroup)
            {
                intRecordNo = 1;
                foreach (RegisterationBiz objBiz in vrReg.ToList())
                {
                    drReg = dtReg.NewRow();
                    SetRegisterationRow(objBiz, ref drReg, intRecordNo);
                    intRecordNo++;

                    dtReg.Rows.Add(drReg);
                }
            }

        }
        void SetRegisterationRow(RegisterationBiz objBiz, ref DataRow objDr, int intRecordNo)
        {
            objDr["CourseID"] = objBiz.CourseBiz.ID;
            objDr["CourseCode"] = objBiz.CourseBiz.Code;
            objDr["CourseNameA"] = objBiz.CourseBiz.NameA;
            objDr["CourseNameE"] = objBiz.CourseBiz.NameE;
            objDr["CourseCH"] = objBiz.CourseBiz.CreditHour;
            objDr["SemesterDesc"] = objBiz.SemesterBiz.Desc;
            objDr["SemesterID"] = objBiz.SemesterBiz.ID;
            objDr["SemesterType"] = objBiz.SemesterBiz.Type == SemesterType.EQ ? 1 : 0;
            objDr["StudentCode"] = objBiz.StudentBiz.Code;
            objDr["StudentName"] = objBiz.StudentBiz.NameA;
            objDr["MidtermDegree"] = objBiz.MTStatus==7?"WF" : objBiz.MidtermDegree.ToString() ;
            objDr["SemesterWorkDegree"] = objBiz.SWStatus == 7 ? "WF" : objBiz.SemesterWorkDegree.ToString();
            objDr["PracticalDegree"] = objBiz.PStatus == 7 ? "WF" : objBiz.PracticalDegree.ToString();
            objDr["OralDegree"] = objBiz.OStatus == 7 ? "WF" : objBiz.OralDegree.ToString();
            objDr["ClinicalDegree"] = objBiz.CStatus == 7 ? "WF" : objBiz.ClinicalDegree.ToString();

            objDr["FinalDegree"] = objBiz.FStatus == 7 ? "WF" : objBiz.FinalDegree.ToString();
            objDr["Bonus"] = objBiz.Bonus;
            objDr["VerbalGPA"] = objBiz.VerbalGPA;
            objDr["GPA"] = objBiz.Points;
            objDr["RegisterationStatus"] = objBiz.Status;
            objDr["RegisterationNote"] = objBiz.Note;

            objDr["RegisterationFinalTotalDegree"] = objBiz.CourseFinalDegree;
            objDr["RegisterationTotal"] = objBiz.TotalValue;
            objDr["StudentCGPA"] = objBiz.StudentBiz.MaxResultBiz.CGPA;

            objDr["StudentLevel"] = objBiz.StudentBiz.LastGrade;
            objDr["StudentCH"] = objBiz.StudentBiz.MaxResultBiz.TotalCreditHour;

            objDr["StudentEH"] = objBiz.StudentBiz.MaxResultBiz.EarnedHour;
            objDr["StudentPoints"] = objBiz.StudentBiz.MaxResultBiz.CPoints;
            if(objDr.Table.Columns["RecordNo"]!=null)
            objDr["RecordNo"] = intRecordNo;
            objDr["SeatNo"] = objBiz.SeatNO;
            objDr["GroupName"] = objBiz.GroupBiz.HallBiz.ID==0? objBiz.GroupBiz.NameA:objBiz.GroupBiz.HallBiz.Name;
        }

        void SetResultLst(List<StudentResultSimple> _ResultLst,ref dsUNIStudent _DS )
        {
            DataTable dtTemp = _DS.Tables["Result"];
            DataRow objDr;
            foreach (StudentResultSimple objBiz in _ResultLst)
            {
                objDr = dtTemp.NewRow();
                SetResultRow(objBiz, ref objDr);
                dtTemp.Rows.Add(objDr);
            }
        }
        void SetResultRow(StudentResultSimple objBiz, ref DataRow objDr)
        {
            objDr["ResultID"] = objBiz.ID;
            objDr["ResultStatement"] = objBiz.Statement;

            objDr["StudentCode"] = objBiz.StudentSimple.Code;
            objDr["StudentNameA"] = objBiz.StudentSimple.NameA;
            objDr["StudentNameE"] = objBiz.StudentSimple.NameE;
            objDr["StudentLevel"] = objBiz.OldLevelOrder;
            objDr["ResultLevel"] = objBiz.NewLevelOrder;
            objDr["ResultCGPA"] = objBiz.CPoints;
            objDr["ResultSGPA"] = objBiz.SPoints;
            objDr["ResultVerbalCGPA"] = objBiz.CGPA;
            objDr["ResultVerbalSGPA"] = objBiz.SGPA;
            objDr["ResultTCH"] = objBiz.TotalCreditHour;
            objDr["ResultECH"] = objBiz.EarnedHour;
            objDr["ResultSCH"] = objBiz.SCreditHour;
            objDr["ResultSEH"] = objBiz.SEarnedHour;
            objDr["OldLevelDesc"] = objBiz.OldLevelDesc;
            objDr["OldLevelOrder"] = objBiz.OldLevelOrder;
            objDr["NewLevelDesc"] = objBiz.NewLevelDesc;
            objDr["NewLevelOrder"] = objBiz.NewLevelOrder;
        }

        void SetStudentCol(StudentCol _StudentCol, ref dsUNIStudent _DS)
        {
            DataTable dtTemp = _DS.Tables["Result"];
            DataRow objDr;
            foreach (StudentBiz objBiz in _StudentCol)
            {
                objDr = dtTemp.NewRow();
                SetStudentRow(objBiz, ref objDr);
                dtTemp.Rows.Add(objDr);
            }
        }
        void SetStudentRow(StudentBiz objStudent, ref DataRow objDr)
        {
            StudentResultSimple objBiz = objStudent.ResultBiz.GetSimple();
            objDr["ResultID"] = objBiz.ID;
            objDr["ResultStatement"] = objBiz.Statement;

            objDr["StudentCode"] = objStudent.Code;
            objDr["StudentNameA"] = objStudent.NameA;
            objDr["StudentNameE"] = objStudent.NameE;
            objDr["StudentLevel"] = objBiz.ID == 0 ? objStudent.LastGrade : objBiz.OldLevelOrder;
            objDr["ResultLevel"] = objStudent.LastGrade;
            objDr["ResultCGPA"] = objBiz.ID > 0 ? objBiz.CPoints.ToString() : "";
            objDr["ResultSGPA"] = objBiz.ID > 0 ? objBiz.SPoints.ToString() : "";
            objDr["ResultVerbalCGPA"] = objBiz.ID > 0 ? objBiz.CGPA : "";
            objDr["ResultVerbalSGPA"] = objBiz.ID > 0 ? objBiz.SGPA : "";
            objDr["ResultTCH"] = objBiz.ID > 0 ? objBiz.TotalCreditHour.ToString() : "";
            objDr["ResultECH"] = objBiz.ID > 0 ? objBiz.EarnedHour.ToString() : "";
            objDr["ResultSCH"] = objBiz.SCreditHour;
            objDr["ResultSEH"] = objBiz.ID > 0 ? objBiz.SEarnedHour.ToString() : "";
            objDr["OldLevelDesc"] = objBiz.ID > 0 ? objBiz.OldLevelDesc : "Level1";
            objDr["OldLevelOrder"] = objBiz.ID > 0 ? objBiz.OldLevelOrder : objStudent.LastGrade;
            objDr["NewLevelDesc"] = objBiz.ID > 0 ? objBiz.NewLevelDesc : "Level1";
            objDr["NewLevelOrder"] = objBiz.ID > 0 ? objBiz.NewLevelOrder : objStudent.LastGrade;
        }
        void SetRegisterationExamCol(RegisterationExamCol _ExamCol,ref dsUNIStudent _DS)
        {
            DataTable dtRegisteration = _DS.Tables["RegisterationExam"];
            DataRow objDr;
            foreach (RegisterationExamBiz objBiz in _ExamCol)
            {
                objDr = dtRegisteration.NewRow();
                SetRegisterationExamRow(objBiz, ref objDr);
                dtRegisteration.Rows.Add(objDr);
            }
        }
        void SetRegisterationExamRow(RegisterationExamBiz objBiz, ref DataRow objDr)
        {
            objDr["CourseID"] = objBiz.RegisterationBiz.CourseBiz.ID;
            objDr["CourseCode"] = objBiz.RegisterationBiz.CourseBiz.Code;
            objDr["CourseNameA"] = objBiz.RegisterationBiz.CourseBiz.NameA;
            objDr["CourseNameE"] = objBiz.RegisterationBiz.CourseBiz.NameE;
            objDr["ExamType"] = objBiz.ExamBiz.TypeName;
            objDr["ExamDate"] = objBiz.ID == 0 ? objBiz.ExamBiz.Date.ToString("yyyy-MM-dd") : objBiz.Date.ToString("yyyy-MM-dd");
            objDr["ExamType"] = objBiz.ExamBiz.TypeName;
            objDr["ExamGrade"] = objBiz.Grade;
            objDr["StudentCode"] = objBiz.RegisterationBiz.StudentCode;
            objDr["StudentName"] = objBiz.RegisterationBiz.StudentName;
            objDr["ExamDegree"] = objBiz.ID > 0 ? objBiz.Degree.ToString() : "";
            objDr["ExamNote"] =objBiz.Status ==(int)RegisterationStatus.WF ?@"WF
"+ objBiz.Note: objBiz.Note;
            if (objDr.Table.Columns["StudentSeatNo"] != null)
                objDr["StudentSeatNo"] = objBiz.RegisterationBiz.SeatNO;
        }

        void SetGroupCol(RegisterationGroupCol objCol, DataSet ds)
        {
            DataTable dtTemp = ds.Tables["Group"];
            DataRow objDr;
            foreach (RegisterationGroupBiz objBiz in objCol)
            {
                objDr = dtTemp.NewRow();
                SetGroupRow(objBiz, ref objDr);
                dtTemp.Rows.Add(objDr);
            }
        }
     
        void SetGroupRegisterationCol(RegisterationGroupCol objGroupCol, ref dsUNIStudent _DS)
        {
            if (objGroupCol == null)
                return;
            DataTable dtReg = _DS.Tables["Registeration"];
            DataRow drReg;

            int intRecordNo;
           foreach(RegisterationGroupBiz objGroup in objGroupCol)
            {
                intRecordNo = 1;
                foreach (RegisterationBiz objBiz in objGroup.RegisterationCol)
                {
                    drReg = dtReg.NewRow();
                    SetRegisterationRow(objBiz, ref drReg, intRecordNo);
                    intRecordNo++;

                    dtReg.Rows.Add(drReg);
                }
            }

        }

        void SetGroupRow(RegisterationGroupBiz objBiz, ref DataRow objDr)
        {
            CourseBiz objCourse = objBiz.CourseBiz;
            objDr["CourseID"] = objCourse.ID;
            objDr["CourseCode"] = objCourse.Code;
            objDr["CourseNameA"] = objCourse.NameA;
            objDr["CourseNameE"] = objCourse.NameE;
            objDr["CourseCH"] = objCourse.CreditHour;
            if(objDr.Table.Columns["RegisteredCount"]!= null)
            objDr["RegisteredCount"] = objCourse.RegisterationNo.ToString();
            objDr["GroupRegisteredCount"] = objBiz.RegisterationNo;
            if(objDr.Table.Columns["CourseLevelOrder"]!= null)
            objDr["CourseLevelOrder"] = objCourse.RecommendedGrade;
            if(objDr.Table.Columns["CourseLevel"]!= null)
            objDr["CourseLevel"] = @"Level" + objCourse.RecommendedGrade.ToString();
            objDr["GroupName"] = objBiz.HallBiz.ID == 0 ? objBiz.NameA : objBiz.HallBiz.Name;
            objDr["GroupRegisteredCount"] = objBiz.RegisterationNo;
            if(objDr.Table.Columns["GroupStartSeatNo"]!= null)
            objDr["GroupStartSeatNo"] = objBiz.MinSeatNo;
            if(objDr.Table.Columns["GroupEndSeatNo"]!= null)
            objDr["GroupEndSeatNo"] = objBiz.MaxSeatNo;
        }


        void SetExamGroupCol(ExamCol objCol, DataSet ds)
        {
            DataTable dtTemp = ds.Tables["Group"];
            DataRow objDr;
            foreach (ExamBiz objExam in objCol)
            {
                foreach (RegisterationGroupBiz objBiz in objExam.GroupCol)
                {
                    objDr = dtTemp.NewRow();
                    SetGroupRow(objBiz, ref objDr);
                    SetExamRow(objExam, ref objDr);
                    dtTemp.Rows.Add(objDr);

                }
            }
        }
        void SetExamRow(ExamBiz objBiz, ref DataRow objDr)
        {
            objDr["ExamType"] = objBiz.TypeName;
            objDr["ExamDate"] = objBiz.Date.ToString("yyyy-MM-dd");
            objDr["ExamStartTime"] = objBiz.StartTime.ToString("HH:mm");
            objDr["ExamEndTime"] = objBiz.EndTime.ToString("HH:mm");
            if (objDr.Table.Columns["ExamRegisteredCount"] != null)
            {
                objDr["ExamRegisteredCount"] = objBiz.RegisteredCount;
                objDr["ExamStartSeatNo"] = objBiz.StartSeatNo;
                objDr["ExamEndSeatNo"] = objBiz.EndSeatNo;
            }

        }

        void SetExamRegisterationCol(ExamCol objCol, ref dsUNIStudent ds)
        {
            DataTable dtTemp = ds.Tables["Registeration"];
            DataRow objDr;
            foreach (ExamBiz objExam in objCol)
            {
                foreach (RegisterationGroupBiz objBiz in objExam.GroupCol)
                {
                    foreach (RegisterationBiz objReg in objBiz.RegisterationCol)
                    {
                        objDr = dtTemp.NewRow();
                        //SetGroupRow(objBiz, ref objDr);
                        SetRegisterationRow(objReg, ref objDr,0);
                        SetGroupRow(objReg.GroupBiz, ref objDr);
                        SetExamRow(objExam, ref objDr);
                        dtTemp.Rows.Add(objDr);
                    }

                }
            }
        }

    }
}