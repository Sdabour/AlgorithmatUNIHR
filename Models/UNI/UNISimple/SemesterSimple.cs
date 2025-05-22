using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class SemesterSimple
    {

        #region Properties
        public int ID;
        public string Desc;
        public DateTime DateStart;
        public DateTime DateEnd;
        public int MaxStatementID;
        public double Grade;
        public string Verbal;
        public int Type;

        public int EarnedHours;
        public int TotalHours;
        public List<RegisterationSimple> lstRegisteration = new List<RegisterationSimple>();

        #endregion
    }
}