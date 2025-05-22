using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LectureCol:CollectionBase
    {

        #region Constructor
        public LectureCol()
        {

        }
        public LectureCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            LectureBiz objBiz = new LectureBiz();
        

            LectureDb objDb = new LectureDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new LectureBiz(objDR);
                Add(objBiz);
            }
        }
        public LectureCol(int intFaculty,int intSemester, int intStudent, int intType, int intCourse, int intProf, int intSection, bool blIsDateRange, DateTime dtStart, DateTime dtEnd)
        {
            LectureDb objDb = new LectureDb() { CourseFaculty = intFaculty, Semester = intSemester, Course = intCourse, Type = intType, Teacher = intProf, IsDateRange = blIsDateRange, StartDate = dtStart, EndDate = dtEnd };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new LectureBiz(objDr));
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public LectureBiz this[int intIndex]
        {
            get
            {
                return (LectureBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(LectureBiz objBiz)
        {
            List.Add(objBiz);
        }
        public LectureCol GetCol(string strTemp)
        {
            LectureCol Returned = new LectureCol(true);
            foreach (LectureBiz objBiz in this)
            {
                if (objBiz.Note.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("LectureID"), new DataColumn("LectureType"), new DataColumn("LectureCourse"), new DataColumn("LectureSemester"), new DataColumn("LectureTeacher"), new DataColumn("LectureDate", System.Type.GetType("System.DateTime")), new DataColumn("LectureStartTime", System.Type.GetType("System.DateTime")), new DataColumn("LectureEndTime", System.Type.GetType("System.DateTime")), new DataColumn("LectureBreakDurationInMinutes"), new DataColumn("LectureScheduled", System.Type.GetType("System.Boolean")), new DataColumn("LectureAttendanceMandatory", System.Type.GetType("System.Boolean")), new DataColumn("LectureNote"), new DataColumn("LectureHall"), new DataColumn("LectureGUUID"), new DataColumn("LectureCourseID"), new DataColumn("LectureCourseFaculty"), new DataColumn("LectureCourseCode"), new DataColumn("LectureCourseNameA"), new DataColumn("LectureCourseNameE"), new DataColumn("LectureCourseCreditHour"), new DataColumn("LectureCourseSemesterWorkDegree"), new DataColumn("LectureSemesterID"), new DataColumn("LectureSemesterDesc"), new DataColumn("LectureSemesterType"), new DataColumn("LectureTypeID"), new DataColumn("LectureTypeCode"), new DataColumn("LectureTypeNameA"), new DataColumn("LectureTypeNameE"), new DataColumn("LectureTeacherID"), new DataColumn("LectureTeacherCode"), new DataColumn("LectureTeacherName"), new DataColumn("LeactureTeacherStatus") });
            DataRow objDr;
            foreach (LectureBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["LectureID"] = objBiz.ID;
                objDr["LectureType"] = objBiz.Type;
                objDr["LectureCourse"] = objBiz.Course;
                objDr["LectureSemester"] = objBiz.Semester;
                objDr["LectureTeacher"] = objBiz.Teacher;
                objDr["LectureDate"] = objBiz.Date;
                objDr["LectureStartTime"] = objBiz.StartTime;
                objDr["LectureEndTime"] = objBiz.EndTime;
                objDr["LectureBreakDurationInMinutes"] = objBiz.BreakDurationInMinutes;
                objDr["LectureScheduled"] = objBiz.Scheduled;
                objDr["LectureAttendanceMandatory"] = objBiz.AttendanceMandatory;
                objDr["LectureNote"] = objBiz.Note;
                objDr["LectureHall"] = objBiz.Hall;
                objDr["LectureGUUID"] = objBiz.GUUID;
                //objDr["LectureCourseID"] = objBiz.CourseID;
                //objDr["LectureCourseFaculty"] = objBiz.CourseFaculty;
                //objDr["LectureCourseCode"] = objBiz.CourseCode;
                //objDr["LectureCourseNameA"] = objBiz.CourseNameA;
                //objDr["LectureCourseNameE"] = objBiz.CourseNameE;
                //objDr["LectureCourseCreditHour"] = objBiz.CourseCreditHour;
                //objDr["LectureCourseSemesterWorkDegree"] = objBiz.CourseSemesterWorkDegree;
                //objDr["LectureSemesterID"] = objBiz.SemesterID;
                //objDr["LectureSemesterDesc"] = objBiz.SemesterDesc;
                //objDr["LectureSemesterType"] = objBiz.SemesterType;
                //objDr["LectureTypeID"] = objBiz.TypeID;
                //objDr["LectureTypeCode"] = objBiz.TypeCode;
                //objDr["LectureTypeNameA"] = objBiz.TypeNameA;
                //objDr["LectureTypeNameE"] = objBiz.TypeNameE;
                //objDr["LectureTeacherID"] = objBiz.TeacherID;
                //objDr["LectureTeacherCode"] = objBiz.TeacherCode;
                //objDr["LectureTeacherName"] = objBiz.TeacherName;
                //objDr["LeactureTeacherStatus"] = objBiz.LeactureTeacherStatus;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}