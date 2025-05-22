using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class HallSimple
    {

        #region Properties
        public int ID;
        public FacultySimple Faculty = new FacultySimple();
        public string Name;
        public double Capacity;
        public LectureTypeSimple LectureType = new LectureTypeSimple();
        #endregion
    }
}