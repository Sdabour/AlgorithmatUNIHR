using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using AlgorithmatMVC.UNI.UNIBusiness;
using SharpVision.SystemBase;
using CrystalDecisions.CrystalReports.Engine;
namespace AlgorithmatUNI.UNI.UNIReport
{
    public class UNIRep
    {
        string _Title;
        RegisterationExamCol _RegisterationExamCol;
        RegisterationCol _RegisterationCol;
        List<CourseSimple> _CourseLst;
        List<StudentResultSimple> _ResultLst;
        StudentCol _StudentCol;
        ExamCol _ExamCol;
        dsUNIStudent _DS = new dsUNIStudent();
        public UNIRep(string strTitle, RegisterationExamCol objExamCol)
        {
            _Title = strTitle;
            _RegisterationExamCol = objExamCol;
            SetMain();
            SetRegisterationExamCol();
            ReportClass rep = new ReportClass();



            rep = new repUNIRegisterationExam();
            rep.SetDataSource(_DS);
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        public UNIRep(string strTitle, ExamCol objExamCol)
        {
            _Title = strTitle;
            _ExamCol = objExamCol;
            SetMain();
            SetExamRegisterationCol(_ExamCol, ref _DS);
            ReportClass rep = new ReportClass();



            rep = new repUNIExamRegisterationSeatNo();
            rep.SetDataSource(_DS);
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        public UNIRep(string strTitle, StudentCol objStudentCol)
        {
            _Title = strTitle;
            _StudentCol = objStudentCol;
            SetMain();
            SetStudentCol();
            ReportClass rep = new ReportClass();



            rep = new repUNIStudentResultLastStudentOrder();
            rep.SetDataSource(_DS);
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        public UNIRep(string strTitle, RegisterationCol objCol,int intType)
        {
            _Title = strTitle;
            _RegisterationCol = objCol;
            SetMain();
            SetRegisterationCol();
            ReportClass rep = new ReportClass();


            if (intType == 0)
                rep = new repUNIRegisterationCourse();
            else if (intType == 1)
                rep = new repUNIRegisterationStudent1();
            else if (intType == 2)
                rep = new repUNIRegisterationStudentSemester();
            else if (intType == 3)
                rep = new repUNIRegisterationStudentSimple();
            else if (intType == 4)
                rep = new repUNIRegisterationCourseSeatNo();
            else
                rep = new repUNIRegisterationStudentSimpleResult();
            rep.SetDataSource(_DS);
            
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        public UNIRep(string strTitle, List<CourseSimple> lstCourse)
        {
            _Title = strTitle;
            _CourseLst = lstCourse;
            SetMain();
            SetCourseLst();
            ReportClass rep = new ReportClass();



            rep = new repUNIRegisterationCourseBivot();
            rep.SetDataSource(_DS);
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        public UNIRep(string strTitle, List<StudentResultSimple> lstResult,int intType)
        {
            _Title = strTitle;
            _ResultLst = lstResult;
            SetMain();
            SetResultLst();
            ReportClass rep = new ReportClass();


            if(intType==0)
            rep = new repUNIStudentResult();
            else if(intType == 1)
                rep = new repUNIStudentResultSGPA();
            else if (intType == 2)
                rep = new repUNIStudentResultLast();
            else 
                rep = new repUNIStudentResultLastStudentOrder();
            rep.SetDataSource(_DS);
            frmDisplayReport frm = new frmDisplayReport();
            frm.ReportViewer.ReportSource = rep;

            frm.Show();
        }
        void SetMain()
        {
            DataTable dtTemp = _DS.Tables["Main"];
            DataRow drTemp = dtTemp.NewRow();
            drTemp["User"] = SysData.CurrentUser.Name;
            dtTemp.Rows.Add(drTemp);
        }
        void SetRegisterationExamCol()
        {
            DataTable dtRegisteration = _DS.Tables["RegisterationExam"];
            DataRow objDr;
            foreach (RegisterationExamBiz objBiz in _RegisterationExamCol)
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
            objDr["ExamNote"] = objBiz.Note;
            if (objDr.Table.Columns["StudentSeatNo"] != null)
                objDr["StudentSeatNo"] = objBiz.RegisterationBiz.SeatNO;

        }
        void SetRegisterationCol()
        {
            if (_RegisterationCol == null)
                return;
            DataTable dtReg = _DS.Tables["Registeration"];
            DataRow drReg;
            foreach(RegisterationBiz objBiz in _RegisterationCol)
            {
                drReg = dtReg.NewRow();
                SetRegisterationRow(objBiz, ref drReg);

                dtReg.Rows.Add(drReg);
            }

        }
        void SetRegisterationRow(RegisterationBiz objBiz,ref DataRow objDr)
        {
            objDr["CourseID"] = objBiz.CourseBiz.ID;
            objDr["CourseCode"] = objBiz.CourseBiz.Code;
            objDr["CourseNameA"] = objBiz.CourseBiz.NameA;
            objDr["CourseNameE"] = objBiz.CourseBiz.NameE;
            objDr["CourseCH"] = objBiz.CourseBiz.CreditHour;
            objDr["SemesterDesc"] = objBiz.SemesterBiz.Desc;
            objDr["SemesterID"] = objBiz.SemesterBiz.ID;
            objDr["SemesterType"] = objBiz.SemesterBiz.Type== SemesterType.EQ?1:0;
            objDr["StudentCode"] = objBiz.StudentBiz.Code;
            objDr["StudentName"] = objBiz.StudentBiz.NameA;
            objDr["MidtermDegree"] = objBiz.MidtermDegree;
            objDr["SemesterWorkDegree"] = objBiz.SemesterWorkDegree;
            objDr["PracticalDegree"] = objBiz.PracticalDegree;
            objDr["OralDegree"] = objBiz.OralDegree;
            objDr["FinalDegree"] = objBiz.FinalDegree;
            objDr["ClinicalDegree"] =objBiz.CStatus == 7 ?"WF":  objBiz.ClinicalDegree.ToString() ;
            objDr["Bonus"] = objBiz.Bonus;
            objDr["VerbalGPA"] = objBiz.VerbalGPA;
            objDr["GPA"] = objBiz.Points;
            objDr["RegisterationStatus"] = objBiz.Status;
            objDr["RegisterationNote"] = objBiz.Note;

            objDr["RegisterationFinalTotalDegree"] = objBiz.CourseFinalDegree;
            objDr["RegisterationTotal"] = objBiz.TotalValue+objBiz.Bonus;
            objDr["StudentCGPA"] = objBiz.StudentBiz.MaxResultCGPA;

            objDr["StudentLevel"] = objBiz.StudentBiz.LastGrade;
            objDr["StudentCH"] = objBiz.StudentBiz.MaxResultTotalCreditHour;
            
            objDr["StudentEH"] = objBiz.StudentBiz.MaxResultEarnedHour;
            objDr["StudentPoints"] = objBiz.StudentBiz.MaxResultCPoints;
            objDr["SeatNo"] = objBiz.SeatNO;
            if(objDr.Table.Columns["GroupName"]!= null)
            objDr["GroupName"] = objBiz.GroupBiz.HallBiz.ID == 0 ? objBiz.GroupBiz.NameA : objBiz.GroupBiz.HallBiz.Name;

        }
        void SetCourseLst()
        {
            DataTable dtTemp = _DS.Tables["ResultCourse"];
            DataRow objDr;
            foreach(CourseSimple objBiz in _CourseLst)
            {
                objDr = dtTemp.NewRow();
                SetCourseRow(objBiz, ref objDr);
                dtTemp.Rows.Add(objDr);
            }
        }

        void SetCourseRow(CourseSimple objCourse,ref DataRow objDr)
        {
            objDr["CourseID"] = objCourse.ID;
            objDr["CourseCode"] = objCourse.Code;
            objDr["CourseNameA"] = objCourse.NameA;
            objDr["CourseNameE"] = objCourse.NameE;
            objDr["CourseCH"] = objCourse.CreditHour;
            objDr["RegisteredCount"] = objCourse.RegisterationNo.ToString();
            objDr["CourseLevelOrder"] = objCourse.RecommendedGrade;
            objDr["CourseLevel"] = objCourse.RecommendedGrade.ToString();
            List<COMMONGradeSimple> lstGrade;
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "A+").ToList();
            objDr["APCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "A").ToList();
            objDr["ACount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "A-").ToList();
            objDr["AMCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "B+").ToList();
            objDr["BPCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "B").ToList();
            objDr["BCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "B-").ToList();
            objDr["BMCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "C+").ToList();
            objDr["CPCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "C").ToList();
            objDr["CCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "C-").ToList();
            objDr["CMCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "D+").ToList();

            objDr["DPCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "D").ToList();
            objDr["DCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "F").ToList();
            objDr["FCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "D-").ToList();
            objDr["DMCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "WF").ToList();
            objDr["WFCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "W").ToList();
            objDr["WCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "IC").ToList();
            objDr["ICCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "Canceled").ToList();
            objDr["CanceledCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "DS").ToList();
            objDr["DSCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";

            lstGrade = objCourse.GradeLst.Where(objGrade => objGrade.Verbal == "DN").ToList();
            objDr["DNCount"] = lstGrade.Count() > 0 ? lstGrade[0].RegisterationLst.Count.ToString() : "";
        }
        void SetGroupCol(RegisterationGroupCol objCol,DataSet ds)
        {
            DataTable dtTemp =ds.Tables["Group"];
            DataRow objDr;
            foreach(RegisterationGroupBiz objBiz in objCol)
            {
                objDr = dtTemp.NewRow();
                SetGroupRow(objBiz, ref objDr);
                dtTemp.Rows.Add(objDr);
            }
        }
        void SetGroupRow(RegisterationGroupBiz objBiz,ref DataRow objDr)
        {
            CourseBiz objCourse = objBiz.CourseBiz;
            objDr["CourseID"] = objCourse.ID;
            objDr["CourseCode"] = objCourse.Code;
            objDr["CourseNameA"] = objCourse.NameA;
            objDr["CourseNameE"] = objCourse.NameE;
            objDr["CourseCH"] = objCourse.CreditHour;
            if (objDr.Table.Columns["RegisteredCount"] != null)
            {
                objDr["RegisteredCount"] = objCourse.RegisterationNo.ToString();
            }
            objDr["GroupRegisteredCount"] = objBiz.RegisterationNo;
            if (objDr.Table.Columns["CourseLevelOrder"] != null)
            {
                objDr["CourseLevelOrder"] = objCourse.RecommendedGrade;
            }
            if (objDr.Table.Columns["CourseLevel"] != null)
            {
                objDr["CourseLevel"] = @"Level" + objCourse.RecommendedGrade.ToString();
            }
            objDr["GroupName"] =  objBiz.HallBiz.ID==0? objBiz.NameA:objBiz.HallBiz.Name;
            objDr["GroupRegisteredCount"] = objBiz.RegisterationNo;
            objDr["GroupStartSeatNo"] = objBiz.MinSeatNo;
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
            objDr["ExamDate"] = objBiz.Date;
            objDr["ExamStartTime"] = objBiz.StartTime.ToString("HH:mm");
            objDr["ExamEndTime"] = objBiz.EndTime.ToString("HH:mm");
            objDr["ExamRegisteredCount"] = objBiz.RegisteredCount;
            objDr["ExamStartSeatNo"] = objBiz.StartSeatNo;
            objDr["ExamEndSeatNo"] = objBiz.EndSeatNo;

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
                        SetRegisterationRow(objReg, ref objDr);
                        SetGroupRow(objReg.GroupBiz, ref objDr);
                            SetExamRow(objExam, ref objDr);
                        dtTemp.Rows.Add(objDr);
                    }

                }
            }
        }

        void SetResultLst()
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
        void SetResultRow(StudentResultSimple objBiz,ref DataRow objDr)
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


        void SetStudentCol()
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
            objDr["StudentLevel"] = objBiz.ID == 0 ? objStudent.LastGrade:objBiz.OldLevelOrder;
            objDr["ResultLevel"] =  objStudent.LastGrade;
            objDr["ResultCGPA"] =  objBiz.ID>0  ?objBiz.CPoints.ToString():"";
            objDr["ResultSGPA"] =  objBiz.ID>0? objBiz.SPoints.ToString():"";
            objDr["ResultVerbalCGPA"] = objBiz.ID > 0 ? objBiz.CGPA:"";
            objDr["ResultVerbalSGPA"] = objBiz.ID > 0 ? objBiz.SGPA :"";
            objDr["ResultTCH"] = objBiz.ID>0?   objBiz.TotalCreditHour.ToString():"";
            objDr["ResultECH"] = objBiz.ID > 0 ? objBiz.EarnedHour.ToString():"";
            objDr["ResultSCH"] = objBiz.SCreditHour;
            objDr["ResultSEH"] = objBiz.ID > 0 ? objBiz.SEarnedHour.ToString():"";
            objDr["OldLevelDesc"] = objBiz.ID > 0 ? objBiz.OldLevelDesc:"Level1";
            objDr["OldLevelOrder"] = objBiz.ID > 0 ? objBiz.OldLevelOrder:objStudent.LastGrade;
            objDr["NewLevelDesc"] = objBiz.ID > 0 ? objBiz.NewLevelDesc:"Level1";
            objDr["NewLevelOrder"] = objBiz.ID > 0 ? objBiz.NewLevelOrder :objStudent.LastGrade;
        }
    }
}
