using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ExamSimple
    {

        #region Properties
        public int ID;
        public string Desc;
        public DateTime Date;
        public DateTime StartTime;
        public DateTime EndTime;
        public string DateStr { get => Date.ToString("yyyy-MM-dd"); }
        public string StartTimeStr { get => StartTime.ToString("HH:mm"); }
             public string EndTimeStr { get => EndTime.ToString("HH:mm"); }
        public int Semester;
        public int Course;
        public int Type;
        public string TypeStr;
        
        public int Grade;
        //public int SemesterID;
        //public string SemesterDesc;
        //public int CourseID;
        //public string CourseCode;
        //public string CourseNameA;
        //public string CourseNameE;
        public SemesterSimple SemesterSimple = new SemesterSimple();
        public CourseSimple CourseSimple = new CourseSimple();
        public HallSimple Hall = new HallSimple(); 
        public int User;
        public List<ExamGroupSimple> GroupLst = new List<ExamGroupSimple>();
        #endregion
    }
}