using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ScheduleBiz
    {

        #region Constructor
        public ScheduleBiz()
        {
            _ScheduleDb = new ScheduleDb();
        }
        public ScheduleBiz(DataRow objDr)
        {
            _ScheduleDb = new ScheduleDb(objDr);
        }

        #endregion
        #region Private Data
        ScheduleDb _ScheduleDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _ScheduleDb.ID = value;
            get => _ScheduleDb.ID;
        }
        public int WeekDay
        {
            set => _ScheduleDb.WeekDay = value;
            get => _ScheduleDb.WeekDay;
        }
        public DateTime StartTime
        {
            set => _ScheduleDb.StartTime = value;
            get => _ScheduleDb.StartTime;
        }
        public double DurationInMinutes
        {
            set => _ScheduleDb.DurationInMinutes = value;
            get => _ScheduleDb.DurationInMinutes;
        }
        public int Hall
        {
            set => _ScheduleDb.Hall = value;
            get => _ScheduleDb.Hall;
        }
        public bool AttendanceMandatory
        {
            set => _ScheduleDb.AttendanceMandatory = value;
            get => _ScheduleDb.AttendanceMandatory;
        }
        public string Note
        {
            set => _ScheduleDb.Note = value;
            get => _ScheduleDb.Note;
        }
        public int FacultyID
        {
            set => _ScheduleDb.FacultyID = value;
            get => _ScheduleDb.FacultyID;
        }
        public string FacultyCode
        {
            set => _ScheduleDb.FacultyCode = value;
            get => _ScheduleDb.FacultyCode;
        }
        public string FacultyNameA
        {
            set => _ScheduleDb.FacultyNameA = value;
            get => _ScheduleDb.FacultyNameA;
        }
        public string FacultyNameE
        {
            set => _ScheduleDb.FacultyNameE = value;
            get => _ScheduleDb.FacultyNameE;
        }
        public int SemesterID
        {
            set => _ScheduleDb.SemesterID = value;
            get => _ScheduleDb.SemesterID;
        }
        public string SemesterDesc
        {
            set => _ScheduleDb.SemesterDesc = value;
            get => _ScheduleDb.SemesterDesc;
        }
        public int CourseID
        {
            set => _ScheduleDb.CourseID = value;
            get => _ScheduleDb.CourseID;
        }
        public string CourseCode
        {
            set => _ScheduleDb.CourseCode = value;
            get => _ScheduleDb.CourseCode;
        }
        public string CourseNameA
        {
            set => _ScheduleDb.CourseNameA = value;
            get => _ScheduleDb.CourseNameA;
        }
        public string CourseNameE
        {
            set => _ScheduleDb.CourseNameE = value;
            get => _ScheduleDb.CourseNameE;
        }
        public int GroupID
        {
            set => _ScheduleDb.GroupID = value;
            get => _ScheduleDb.GroupID;
        }
        public string GroupCode
        {
            set => _ScheduleDb.GroupCode = value;
            get => _ScheduleDb.GroupCode;
        }
        public string GroupNameA
        {
            set => _ScheduleDb.GroupNameA = value;
            get => _ScheduleDb.GroupNameA;
        }
        public string GroupNameE
        {
            set => _ScheduleDb.GroupNameE = value;
            get => _ScheduleDb.GroupNameE;
        }
        public int LectureTypeID
        {
            set => _ScheduleDb.LectureTypeID = value;
            get => _ScheduleDb.LectureTypeID;
        }
        public string LectureTypeCode
        {
            set => _ScheduleDb.LectureTypeCode = value;
            get => _ScheduleDb.LectureTypeCode;
        }
        public string LectureTypeNameA
        {
            set => _ScheduleDb.LectureTypeNameA = value;
            get => _ScheduleDb.LectureTypeNameA;
        }
        public string LectureTypeNameE
        {
            set => _ScheduleDb.LectureTypeNameE = value;
            get => _ScheduleDb.LectureTypeNameE;
        }
        public int TeacherID
        {
            set => _ScheduleDb.TeacherID = value;
            get => _ScheduleDb.TeacherID;
        }
        public string TeacherCode
        {
            set => _ScheduleDb.TeacherCode = value;
            get => _ScheduleDb.TeacherCode;
        }
        public string TeacherName
        {
            set => _ScheduleDb.TeacherName = value;
            get => _ScheduleDb.TeacherName;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ScheduleDb.Add();
        }
        public void Edit()
        {
            _ScheduleDb.Edit();
        }
        public void Delete()
        {
            _ScheduleDb.Delete();
        }
        #endregion
    }
}