using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentSimple
    {

        #region Properties
        public int ID;
        public string Code;
        public string NameA;
        public string NameE;
        public int Gender;//1 male,2Female
        public DateTime BirthDate;
        public string Mobile1;
        public string Mobile2;
        public string Phone1;
        public string Phone2;
        public string Address;
        string _Email;
        public string Email { set => _Email = value; get => _Email == null || _Email == "" ? Code + "@std.ahuc.edu.eg" : _Email; }
        public int HomeCity;
        public int HomeCountry;
        public double Points;
        public string Verbal;
        public int EarnedHours;
        public int TotalHours;
        public string Level;
        public int LastGrade;
        #region Result Properties
        public string MaxResultCGPA;
        public double MaxResultCPoints;
        public double MaxResultTotalCreditHour;
        public double MaxResultEarnedHour;
        public string MaxResultSGPA;
        public double MaxResultSPoints;
        public string MaxResultNote;
        #endregion
        //public List<RegisterationSimple> lstRegisteration = new List<RegisterationSimple>();
        public List<SemesterSimple> lstSemester=new List<SemesterSimple>();
        public void SaveAsSent()
        {
            AlgorithmatMVC.UNI.UniDataBase.StudentDb objDb = new UniDataBase.StudentDb() { ID = ID, Email = Email };
            objDb.SaveSent();
        }
        #endregion
    }
}