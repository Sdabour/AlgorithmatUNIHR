using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class CourseBiz
    {

        #region Constructor
        public CourseBiz()
        {
            _CourseDb = new CourseDb();
        }
        public CourseBiz(DataRow objDr)
        {
            _CourseDb = new CourseDb(objDr);
        }

        #endregion
        #region Private Data
        CourseDb _CourseDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _CourseDb.ID = value;
            get => _CourseDb.ID;
        }
        public int Faculty
        {
            set => _CourseDb.Faculty = value;
            get => _CourseDb.Faculty;
        }
        public string Code
        {
            set => _CourseDb.Code = value;
            get => _CourseDb.Code;
        }
        public string NameA
        {
            set => _CourseDb.NameA = value;
            get => _CourseDb.NameA;
        }
        public string NameE
        {
            set => _CourseDb.NameE = value;
            get => _CourseDb.NameE;
        }
        public string Desc
        {
            set => _CourseDb.Desc = value;
            get => _CourseDb.Desc;
        }
        public int CreditHour
        {
            set => _CourseDb.CreditHour = value;
            get => _CourseDb.CreditHour;
        }
        public int TotalDegree
        {
            set => _CourseDb.TotalDegree = value;
            get => _CourseDb.TotalDegree;
        }
        public int MidtermDegree
        {
            set => _CourseDb.MidtermDegree = value;
            get => _CourseDb.MidtermDegree;
        }
        public int SemesterWorkDegree
        {
            set => _CourseDb.SemesterWorkDegree = value;
            get => _CourseDb.SemesterWorkDegree;
        }
        public int PracticalDegree
        {
            set => _CourseDb.PracticalDegree = value;
            get => _CourseDb.PracticalDegree;
        }
        public int OralDegree
        {
            set => _CourseDb.OralDegree = value;
            get => _CourseDb.OralDegree;
        }
        public int FinalDegree
        {
            set => _CourseDb.FinalDegree = value;
            get => _CourseDb.FinalDegree;
        }
        public int ClinicalDegree
        {
            set => _CourseDb.ClinicalDegree = value;
            get => _CourseDb.ClinicalDegree;
        }
        public int RecommendedGrade
        {
            set => _CourseDb.RecommendedGrade = value;
            get => _CourseDb.RecommendedGrade;
        }
        public double FinalMinDegree
        {
            set => _CourseDb.FinalMinDegree = value;
            get => _CourseDb.FinalMinDegree;
        }
        public double MaxBonus
        {
            set => _CourseDb.MaxBonus = value;
            get {
                double Returned = 0;
                if (_CourseDb.MaxBonus > 0)
                    Returned = _CourseDb.MaxBonus;
                return Returned; }
        }
        public bool BonusForAll
        { set => _CourseDb.BonusForAll = value;
            get => _CourseDb.BonusForAll;
        }
        RegisterationCol _RegisterationCol;
        public RegisterationCol RegisterationCol
        {
            set => _RegisterationCol = value;
            get
            {
                if (_RegisterationCol == null)
                    _RegisterationCol = new RegisterationCol(true,0);
                return _RegisterationCol;
            }
        }
        int _RegisterationNo;
        public int RegisterationNo
        {
            set => _RegisterationNo = value;
            get => _RegisterationNo;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _CourseDb.Add();
        }
        public void Edit()
        {
            _CourseDb.Edit();
        }
        public void Delete()
        {
            _CourseDb.Delete();
        }
        public StudentCol GetRecommendedStudentCol(string strName)
        {
            StudentCol Returned = new StudentCol(true,0);
            _CourseDb.StudentName = strName;
            DataTable dtTemp = _CourseDb.GetRegisterationStudent();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new StudentBiz(objDr));
            }
            return Returned;
        }
        //public RegisterationCol GetRecommendedRegisterationCol(string strName)
        //{
        //    RegisterationCol Returned = new RegisterationCol(true);
        //    _CourseDb.RegisterationName = strName;
        //    DataTable dtTemp = _CourseDb.GetRegisterationRegisteration();
        //    foreach (DataRow objDr in dtTemp.Rows)
        //    {
        //        Returned.Add(new RegisterationBiz(objDr));
        //    }
        //    return Returned;
        //}
        public void SaveSemesterBonus(int intSemester,double dblBonus,bool blBonusISForAll)
        {
            CourseDb objDb = new CourseDb() { SemesterID = intSemester, ID = ID, MaxBonus = dblBonus, BonusForAll = blBonusISForAll };
            objDb.SaveSemesterCourseBonus();
        }
        #endregion
    }
}