using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class CourseSimple
    {

        #region Properties
        public int ID;
        public string Code;
        public string NameA;
        public string NameE;
        public string Desc;
        public int CreditHour;
        public int TotalDegree;
        public int MidtermDegree;
        public int SemesterWorkDegree;
        public int PracticalDegree;
        public int OralDegree;
        public int FinalDegree;
        public int ClinicalDegree;
        public int RecommendedGrade;
        public int SemesterRegisterationCount;

        public int Semester;
        public int RegisterationNo;
        public List<RegisterationSimple> lstRegisteration = new List<RegisterationSimple>();
        public List<COMMONGradeSimple> GradeLst = new List<COMMONGradeSimple>();
        #endregion
    }
}