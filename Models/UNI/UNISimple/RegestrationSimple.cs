using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationSimple
    {

        #region Properties
        public int ID;
        public int Student;
        public string StudentCode;
        public string StudentName;
        public int StudentGender;
        public DateTime Date;
        public int Semester;
        public string SemesterDesc;
        public int Course;
        public string CourseCode ;
    public string CourseName;
        public int EqualID;
        public  string EqualName; 
        public int CourseFinalDegree;

        public int Grade;
        public int Iteration;
        public double MidtermDegree;
        public double SemesterWorkDegree;
        public double PracticalDegree;
        public double OralDegree;
        public double FinalDegree;
        public double ClinicalDegree;
        public double Bonus;
        public double TotalValue;
        public double Points;
        public string GPA;
        public int Status;
        public bool Posted;
        public int ResultID;

        
        public int MTStatus;
        public int SWStatus;
        public int PStatus;
        public int OStatus;
        public int FStatus;
        public int CStatus;
        public int PrequisitCourseCount;
        public int PrequisitPassedCourseCount;
        public List<RegisterationSimple> PrequisitLst = new List<RegisterationSimple>();
        public string VerbalGPA { get =>EqualID >0?"T": (Status == 3 ? "IC" : (Status == 2 ? "W" : (Status == 4 ? "Canceled" : GPA))); }
        public string Note;
    public int UserID;
    public  string UserName;
    public string SeatNo;
        public string GroupName;

    public string Password;
        public CourseSimple CourseSimple = new CourseSimple();
        public List<RegisterationSimple> lstReg = new List<RegisterationSimple>();
        #endregion

        #region Source Properties
        public int MainRegisterationID;
        public int SourceRegisterationID;
        public DateTime SourceRegisterationDate;
        public int SourceSemesterID;
        public string SourceSemesterDesc;
        public double SourceMidtermDegree;
        public double SourceSemesterWorkDegree;
        public double SourcePracticalDegree;
        public double SourceOralDegree;
        public double SourceFinalDegree;
        public string SourceVerbalGPA;
        public double SourceGPA;
        public int SourceStatus;
        public string SourceNote;
        public int SourceResult;
        #endregion
    }
}