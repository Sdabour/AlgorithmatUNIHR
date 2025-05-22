using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ScheduleCol:CollectionBase
    {

        #region Constructor
        public ScheduleCol()
        {

        }
        public ScheduleCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ScheduleBiz objBiz = new ScheduleBiz();
           

            ScheduleDb objDb = new ScheduleDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ScheduleBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ScheduleBiz this[int intIndex]
        {
            get
            {
                return (ScheduleBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ScheduleBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ScheduleCol GetCol(string strTemp)
        {
            ScheduleCol Returned = new ScheduleCol(true);
            foreach (ScheduleBiz objBiz in this)
            {
                if (objBiz.CourseNameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ScheduleID"), new DataColumn("ScheduleWeekDay"), new DataColumn("ScheduleStartTime", System.Type.GetType("System.DateTime")), new DataColumn("ScheduleDurationInMinutes"), new DataColumn("ScheduleHall"), new DataColumn("ScheduleAttendanceMandatory", System.Type.GetType("System.Boolean")), new DataColumn("ScheduleNote"), new DataColumn("FacultyID"), new DataColumn("FacultyCode"), new DataColumn("FacultyNameA"), new DataColumn("FacultyNameE"), new DataColumn("SemesterID"), new DataColumn("SemesterDesc"), new DataColumn("CourseID"), new DataColumn("CourseCode"), new DataColumn("ScheduleCourseNameA"), new DataColumn("ScheduleCourseNameE"), new DataColumn("ScheduleGroupID"), new DataColumn("ScheduleGroupCode"), new DataColumn("ScheduleGroupNameA"), new DataColumn("ScheduleGroupNameE"), new DataColumn("ScheduleLectureTypeID"), new DataColumn("ScheduleLectureTypeCode"), new DataColumn("ScheduleLectureTypeNameA"), new DataColumn("ScheduleLectureTypeNameE"), new DataColumn("ScheduleTeacherID"), new DataColumn("ScheduleTeacherCode"), new DataColumn("ScheduleTeacherName") });
            DataRow objDr;
            foreach (ScheduleBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ScheduleID"] = objBiz.ID;
                objDr["ScheduleWeekDay"] = objBiz.WeekDay;
                objDr["ScheduleStartTime"] = objBiz.StartTime;
                objDr["ScheduleDurationInMinutes"] = objBiz.DurationInMinutes;
                objDr["ScheduleHall"] = objBiz.Hall;
                objDr["ScheduleAttendanceMandatory"] = objBiz.AttendanceMandatory;
                objDr["ScheduleNote"] = objBiz.Note;
                objDr["FacultyID"] = objBiz.FacultyID;
                objDr["FacultyCode"] = objBiz.FacultyCode;
                objDr["FacultyNameA"] = objBiz.FacultyNameA;
                objDr["FacultyNameE"] = objBiz.FacultyNameE;
                objDr["SemesterID"] = objBiz.SemesterID;
                objDr["SemesterDesc"] = objBiz.SemesterDesc;
                objDr["CourseID"] = objBiz.CourseID;
                objDr["CourseCode"] = objBiz.CourseCode;
                objDr["ScheduleCourseNameA"] = objBiz.CourseNameA;
                objDr["ScheduleCourseNameE"] = objBiz.CourseNameE;
                objDr["ScheduleGroupID"] = objBiz.GroupID;
                objDr["ScheduleGroupCode"] = objBiz.GroupCode;
                objDr["ScheduleGroupNameA"] = objBiz.GroupNameA;
                objDr["ScheduleGroupNameE"] = objBiz.GroupNameE;
                objDr["ScheduleLectureTypeID"] = objBiz.LectureTypeID;
                objDr["ScheduleLectureTypeCode"] = objBiz.LectureTypeCode;
                objDr["ScheduleLectureTypeNameA"] = objBiz.LectureTypeNameA;
                objDr["ScheduleLectureTypeNameE"] = objBiz.LectureTypeNameE;
                objDr["ScheduleTeacherID"] = objBiz.TeacherID;
                objDr["ScheduleTeacherCode"] = objBiz.TeacherCode;
                objDr["ScheduleTeacherName"] = objBiz.TeacherName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}