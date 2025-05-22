using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.UMS.UMSBusiness;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LectureSimple
    {

        #region Properties
        public int ID;
        public int Type;
        public int Course;
        public int Semester;
        public int Teacher;

        public DateTime Date;
        public string DateStr { get => Date.ToString("yyyy-MM-dd"); }
        public DateTime StartTime;
        public string StartTimeStr { get => StartTime.ToString("HH:mm"); }
        public DateTime EndTime;
        public string EndTimeStr { get => EndTime.ToString("HH:mm"); }
        public double BreakDurationInMinutes;
        public bool Scheduled;
        public bool AttendanceMandatory;
        public string Note;
        public int Hall;
        public int User;
        public string GUUID;
        public CourseSimple CourseSimple = new CourseSimple();
       public SemesterSimple SemesterSimple = new SemesterSimple();
        public LectureTypeSimple TypeSimple = new LectureTypeSimple();
        public TeacherSimple TeacherSimple = new TeacherSimple();
       
        #endregion
    }
}