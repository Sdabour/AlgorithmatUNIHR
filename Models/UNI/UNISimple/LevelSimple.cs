using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LevelSimple
    {
        public int Level;
        public string LevelDesc;
       public List<StudentSimple> lstStudent=new List<StudentSimple>();
        public List<CourseSimple> lstCourse = new List<CourseSimple>();

        #region Properties
        public int ID;
        public int Faculty;
        public int Order;
        public string Desc;
        public int CreditHourFrom;
        public int CreditHourTo;
        public int SemesterType1MaxLimitedHour;
        public int SemesterType2MaxLimitedHour;
        public int SemesterType3MaxLimitedHour;
        public int LowGPALimitedHour;
        #endregion

    }
}