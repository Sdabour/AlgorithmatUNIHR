using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ScheduleSimple
    {

        #region Properties
        public int ID;
        public int WeekDay;
        public DateTime StartTime;
        public double DurationInMinutes;
        public int Hall;
        public bool AttendanceMandatory;
        public string Note;
        public int FacultyID;
        public string FacultyCode;
        public string FacultyNameA;
        public string FacultyNameE;
        public int SemesterID;
        public string SemesterDesc;
        public int CourseID;
        public string CourseCode;
        public string CourseNameA;
        public string CourseNameE;
        public int GroupID;
        public string GroupCode;
        public string GroupNameA;
        public string GroupNameE;
        public int LectureTypeID;
        public string LectureTypeCode;
        public string LectureTypeNameA;
        public string LectureTypeNameE;
        public int TeacherID;
        public string TeacherCode;
        public string TeacherName;
        #endregion
    }
}