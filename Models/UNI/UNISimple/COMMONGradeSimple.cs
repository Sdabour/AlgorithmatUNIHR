using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class COMMONGradeSimple
    {

        #region Properties
        public int MinPerc;
        public int MaxPerc;
        public string Verbal;
        public double Points;
        public List<RegisterationSimple> RegisterationLst=new List<RegisterationSimple>();
        #endregion
    }
}