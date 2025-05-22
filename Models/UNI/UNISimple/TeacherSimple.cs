using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class TeacherSimple
    {

        #region Properties
        public int ID;
        public string Code;
        public string Name;
        public string FamousName;
        public string ShortName;
        public int FunctionGroup;
        public FacultySimple Faculty = new FacultySimple();
        public TeacherTypeSimple Type = new TeacherTypeSimple();
        #endregion
    }

}