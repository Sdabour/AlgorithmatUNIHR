using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationGroupSimple
    {

        #region Properties
        public int ID;
        //public int Faculty;
        public string Code;
        public string NameA;
        public string NameE;
        
        public FacultySimple Faculty = new FacultySimple();

        
        public CourseSimple Course = new CourseSimple();
        public SemesterSimple Semester = new SemesterSimple();
        //public int SemesterID;
        //public string SemesterDesc;
        public LectureTypeSimple LectureType = new LectureTypeSimple();
        public int ExamType;
        public List<int> StudentIDLst = new List<int>();
        public int User;
        #endregion
    }
}