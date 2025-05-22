using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentResultSimple
    {

        #region Properties
        public int ID;
        public int Statement;
        public int Student;
        public string CGPA;
        public double CPoints;
        public double TotalCreditHour;
        public double EarnedHour;
        public double SCreditHour;
        public double SEarnedHour;
        public string SGPA;
        public double SPoints;
        public string Note;
        public int Level;
        public bool Stopped;
        public string StopReason;
        public int NewLevelOrder;

        public string NewLevelDesc;

        public int OldLevelOrder;

        public string OldLevelDesc;

        public StudentSimple StudentSimple = new StudentSimple();
        public List<SemesterSimple> lstSemester = new List<SemesterSimple>();
        #endregion
    }
}