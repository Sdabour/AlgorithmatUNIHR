using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class ScheduleDb
    {
        //ScheduleID, ScheduleStartTime, ScheduleDurationInMinutes, ScheduleGroup, ScheduleHall, ScheduleAttendanceMandatory, ScheduleNote, ScheduleFacultyIF, ScheduleFacultyCode, ScheduleFacultyNameA, ScheduleFacultyNameE, 
        //ScheduleSemesterID, ScheduleSemesterDesc, ScheduleCourseID, ScheduleCourseCode

        #region Constructor
        public ScheduleDb()
        {
        }
        public ScheduleDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _WeekDay;
        public int WeekDay
        {
            set => _WeekDay = value;
            get => _WeekDay;
        }
        DateTime _StartTime;
        public DateTime StartTime
        {
            set => _StartTime = value;
            get => _StartTime;
        }
        double _DurationInMinutes;
        public double DurationInMinutes
        {
            set => _DurationInMinutes = value;
            get => _DurationInMinutes;
        }
        int _Hall;
        public int Hall
        {
            set => _Hall = value;
            get => _Hall;
        }
        bool _AttendanceMandatory;
        public bool AttendanceMandatory
        {
            set => _AttendanceMandatory = value;
            get => _AttendanceMandatory;
        }
        string _Note;
        public string Note
        {
            set => _Note = value;
            get => _Note;
        }
        int _FacultyID;
        public int FacultyID
        {
            set => _FacultyID = value;
            get => _FacultyID;
        }
        string _FacultyCode;
        public string FacultyCode
        {
            set => _FacultyCode = value;
            get => _FacultyCode;
        }
        string _FacultyNameA;
        public string FacultyNameA
        {
            set => _FacultyNameA = value;
            get => _FacultyNameA;
        }
        string _FacultyNameE;
        public string FacultyNameE
        {
            set => _FacultyNameE = value;
            get => _FacultyNameE;
        }
        int _SemesterID;
        public int SemesterID
        {
            set => _SemesterID = value;
            get => _SemesterID;
        }
        string _SemesterDesc;
        public string SemesterDesc
        {
            set => _SemesterDesc = value;
            get => _SemesterDesc;
        }
        int _CourseID;
        public int CourseID
        {
            set => _CourseID = value;
            get => _CourseID;
        }
        string _CourseCode;
        public string CourseCode
        {
            set => _CourseCode = value;
            get => _CourseCode;
        }
        string _CourseNameA;
        public string CourseNameA
        {
            set => _CourseNameA = value;
            get => _CourseNameA;
        }
        string _CourseNameE;
        public string CourseNameE
        {
            set => _CourseNameE = value;
            get => _CourseNameE;
        }
        int _GroupID;
        public int GroupID
        {
            set => _GroupID = value;
            get => _GroupID;
        }
        string _GroupCode;
        public string GroupCode
        {
            set => _GroupCode = value;
            get => _GroupCode;
        }
        string _GroupNameA;
        public string GroupNameA
        {
            set => _GroupNameA = value;
            get => _GroupNameA;
        }
        string _GroupNameE;
        public string GroupNameE
        {
            set => _GroupNameE = value;
            get => _GroupNameE;
        }
        int _LectureTypeID;
        public int LectureTypeID
        {
            set => _LectureTypeID = value;
            get => _LectureTypeID;
        }
        string _LectureTypeCode;
        public string LectureTypeCode
        {
            set => _LectureTypeCode = value;
            get => _LectureTypeCode;
        }
        string _LectureTypeNameA;
        public string LectureTypeNameA
        {
            set => _LectureTypeNameA = value;
            get => _LectureTypeNameA;
        }
        string _LectureTypeNameE;
        public string LectureTypeNameE
        {
            set => _LectureTypeNameE = value;
            get => _LectureTypeNameE;
        }
        int _TeacherID;
        public int TeacherID
        {
            set => _TeacherID = value;
            get => _TeacherID;
        }
        string _TeacherCode;
        public string TeacherCode
        {
            set => _TeacherCode = value;
            get => _TeacherCode;
        }
        string _TeacherName;
        public string TeacherName
        {
            set => _TeacherName = value;
            get => _TeacherName;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNISchedule (ScheduleID,ScheduleWeekDay,ScheduleStartTime,ScheduleDurationInMinutes,ScheduleHall,ScheduleAttendanceMandatory,ScheduleNote,FacultyID,FacultyCode,FacultyNameA,FacultyNameE,SemesterID,SemesterDesc,CourseID,CourseCode,ScheduleCourseNameA,ScheduleCourseNameE,ScheduleGroupID,ScheduleGroupCode,ScheduleGroupNameA,ScheduleGroupNameE,ScheduleLectureTypeID,ScheduleLectureTypeCode,ScheduleLectureTypeNameA,ScheduleLectureTypeNameE,ScheduleTeacherID,ScheduleTeacherCode,ScheduleTeacherName,UsrIns,TimIns) values (," + ID + "," + WeekDay + "," + (StartTime.ToOADate() - 2).ToString() + "," + DurationInMinutes + "," + Hall + "," + (AttendanceMandatory ? 1 : 0) + ",'" + Note + "'," + FacultyID + ",'" + FacultyCode + "','" + FacultyNameA + "','" + FacultyNameE + "'," + SemesterID + ",'" + SemesterDesc + "'," + CourseID + ",'" + CourseCode + "','" + CourseNameA + "','" + CourseNameE + "'," + GroupID + ",'" + GroupCode + "','" + GroupNameA + "','" + GroupNameE + "'," + LectureTypeID + ",'" + LectureTypeCode + "','" + LectureTypeNameA + "','" + LectureTypeNameE + "'," + TeacherID + ",'" + TeacherCode + "','" + TeacherName + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNISchedule set " + "ScheduleID=" + ID + "" +
           ",ScheduleWeekDay=" + WeekDay + "" +
           ",ScheduleStartTime=" + (StartTime.ToOADate() - 2).ToString() + "" +
           ",ScheduleDurationInMinutes=" + DurationInMinutes + "" +
           ",ScheduleHall=" + Hall + "" +
           ",ScheduleAttendanceMandatory=" + (AttendanceMandatory ? 1 : 0) + "" +
           ",ScheduleNote='" + Note + "'" +
           ",FacultyID=" + FacultyID + "" +
           ",FacultyCode='" + FacultyCode + "'" +
           ",FacultyNameA='" + FacultyNameA + "'" +
           ",FacultyNameE='" + FacultyNameE + "'" +
           ",SemesterID=" + SemesterID + "" +
           ",SemesterDesc='" + SemesterDesc + "'" +
           ",CourseID=" + CourseID + "" +
           ",CourseCode='" + CourseCode + "'" +
           ",ScheduleCourseNameA='" + CourseNameA + "'" +
           ",ScheduleCourseNameE='" + CourseNameE + "'" +
           ",ScheduleGroupID=" + GroupID + "" +
           ",ScheduleGroupCode='" + GroupCode + "'" +
           ",ScheduleGroupNameA='" + GroupNameA + "'" +
           ",ScheduleGroupNameE='" + GroupNameE + "'" +
           ",ScheduleLectureTypeID=" + LectureTypeID + "" +
           ",ScheduleLectureTypeCode='" + LectureTypeCode + "'" +
           ",ScheduleLectureTypeNameA='" + LectureTypeNameA + "'" +
           ",ScheduleLectureTypeNameE='" + LectureTypeNameE + "'" +
           ",ScheduleTeacherID=" + TeacherID + "" +
           ",ScheduleTeacherCode='" + TeacherCode + "'" +
           ",ScheduleTeacherName='" + TeacherName + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNISchedule set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @"SELECT dbo.UNISchedule.ScheduleID, dbo.UNISchedule.ScheduleWeekDay, dbo.UNISchedule.ScheduleStartTime, dbo.UNISchedule.ScheduleDurationInMinutes, dbo.UNISchedule.ScheduleHall, 
                                    dbo.UNISchedule.ScheduleAttendanceMandatory, dbo.UNISchedule.ScheduleNote, dbo.UNIFaculty.FacultyID, dbo.UNIFaculty.FacultyCode, dbo.UNIFaculty.FacultyNameA, dbo.UNIFaculty.FacultyNameE, 
                                    dbo.UNISemester.SemesterID, dbo.UNISemester.SemesterDesc, dbo.UNICourse.CourseID, dbo.UNICourse.CourseCode, dbo.UNICourse.CourseNameA AS ScheduleCourseNameA, 
                                    dbo.UNICourse.CourseNameE AS ScheduleCourseNameE, dbo.UNIGroup.GroupID AS ScheduleGroupID, dbo.UNIGroup.GroupCode AS ScheduleGroupCode, dbo.UNIGroup.GroupNameA AS ScheduleGroupNameA, 
                                    dbo.UNIGroup.GroupNameE AS ScheduleGroupNameE, dbo.UNILectureType.LectureTypeID AS ScheduleLectureTypeID, dbo.UNILectureType.LectureTypeCode AS ScheduleLectureTypeCode, 
                                    dbo.UNILectureType.LectureTypeNameA AS ScheduleLectureTypeNameA, dbo.UNILectureType.LectureTypeNameE AS ScheduleLectureTypeNameE, TeacherTable.ApplicantID AS ScheduleTeacherID, 
                                    TeacherTable.ApplicantCode AS ScheduleTeacherCode, TeacherTable.ApplicantFirstName AS ScheduleTeacherName
                  FROM      dbo.UNISchedule INNER JOIN
                                    dbo.UNIFaculty ON dbo.UNISchedule.ScheduleFaculty = dbo.UNIFaculty.FacultyID INNER JOIN
                                    dbo.UNISemester ON dbo.UNISchedule.ScheduleSemester = dbo.UNISemester.SemesterID INNER JOIN
                                    dbo.UNICourse ON dbo.UNISchedule.ScheduleCourse = dbo.UNICourse.CourseID INNER JOIN
                                    dbo.UNILectureType ON dbo.UNISchedule.ScheduleLectureType = dbo.UNILectureType.LectureTypeID LEFT OUTER JOIN
                                        (SELECT dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicantWorker.ApplicantStatusID
                                         FROM      dbo.HRApplicant INNER JOIN
                                                           dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID
                                         WHERE(dbo.HRApplicantWorker.ApplicantStatusID = 1)) AS TeacherTable ON dbo.UNISchedule.ScheduleTeacher = TeacherTable.ApplicantID LEFT OUTER JOIN
                                    dbo.UNIGroup ON dbo.UNISchedule.ScheduleGroup = dbo.UNIGroup.GroupID";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ScheduleID"] != null)
                int.TryParse(objDr["ScheduleID"].ToString(), out _ID);

            if (objDr.Table.Columns["ScheduleWeekDay"] != null)
                int.TryParse(objDr["ScheduleWeekDay"].ToString(), out _WeekDay);

            if (objDr.Table.Columns["ScheduleStartTime"] != null)
                DateTime.TryParse(objDr["ScheduleStartTime"].ToString(), out _StartTime);

            if (objDr.Table.Columns["ScheduleDurationInMinutes"] != null)
                double.TryParse(objDr["ScheduleDurationInMinutes"].ToString(), out _DurationInMinutes);

            if (objDr.Table.Columns["ScheduleHall"] != null)
                int.TryParse(objDr["ScheduleHall"].ToString(), out _Hall);

            if (objDr.Table.Columns["ScheduleAttendanceMandatory"] != null)
                bool.TryParse(objDr["ScheduleAttendanceMandatory"].ToString(), out _AttendanceMandatory);

            if (objDr.Table.Columns["ScheduleNote"] != null)
                _Note = objDr["ScheduleNote"].ToString();

            if (objDr.Table.Columns["FacultyID"] != null)
                int.TryParse(objDr["FacultyID"].ToString(), out _FacultyID);

            if (objDr.Table.Columns["FacultyCode"] != null)
                _FacultyCode = objDr["FacultyCode"].ToString();

            if (objDr.Table.Columns["FacultyNameA"] != null)
                _FacultyNameA = objDr["FacultyNameA"].ToString();

            if (objDr.Table.Columns["FacultyNameE"] != null)
                _FacultyNameE = objDr["FacultyNameE"].ToString();

            if (objDr.Table.Columns["SemesterID"] != null)
                int.TryParse(objDr["SemesterID"].ToString(), out _SemesterID);

            if (objDr.Table.Columns["SemesterDesc"] != null)
                _SemesterDesc = objDr["SemesterDesc"].ToString();

            if (objDr.Table.Columns["CourseID"] != null)
                int.TryParse(objDr["CourseID"].ToString(), out _CourseID);

            if (objDr.Table.Columns["CourseCode"] != null)
                _CourseCode = objDr["CourseCode"].ToString();

            if (objDr.Table.Columns["ScheduleCourseNameA"] != null)
                _CourseNameA = objDr["ScheduleCourseNameA"].ToString();

            if (objDr.Table.Columns["ScheduleCourseNameE"] != null)
                _CourseNameE = objDr["ScheduleCourseNameE"].ToString();

            if (objDr.Table.Columns["ScheduleGroupID"] != null)
                int.TryParse(objDr["ScheduleGroupID"].ToString(), out _GroupID);

            if (objDr.Table.Columns["ScheduleGroupCode"] != null)
                _GroupCode = objDr["ScheduleGroupCode"].ToString();

            if (objDr.Table.Columns["ScheduleGroupNameA"] != null)
                _GroupNameA = objDr["ScheduleGroupNameA"].ToString();

            if (objDr.Table.Columns["ScheduleGroupNameE"] != null)
                _GroupNameE = objDr["ScheduleGroupNameE"].ToString();

            if (objDr.Table.Columns["ScheduleLectureTypeID"] != null)
                int.TryParse(objDr["ScheduleLectureTypeID"].ToString(), out _LectureTypeID);

            if (objDr.Table.Columns["ScheduleLectureTypeCode"] != null)
                _LectureTypeCode = objDr["ScheduleLectureTypeCode"].ToString();

            if (objDr.Table.Columns["ScheduleLectureTypeNameA"] != null)
                _LectureTypeNameA = objDr["ScheduleLectureTypeNameA"].ToString();

            if (objDr.Table.Columns["ScheduleLectureTypeNameE"] != null)
                _LectureTypeNameE = objDr["ScheduleLectureTypeNameE"].ToString();

            if (objDr.Table.Columns["ScheduleTeacherID"] != null)
                int.TryParse(objDr["ScheduleTeacherID"].ToString(), out _TeacherID);

            if (objDr.Table.Columns["ScheduleTeacherCode"] != null)
                _TeacherCode = objDr["ScheduleTeacherCode"].ToString();

            if (objDr.Table.Columns["ScheduleTeacherName"] != null)
                _TeacherName = objDr["ScheduleTeacherName"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}