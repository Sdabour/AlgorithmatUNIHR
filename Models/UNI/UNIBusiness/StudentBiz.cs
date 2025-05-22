using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentBiz
    {

        #region Constructor
        public StudentBiz()
        {
            _StudentDb = new StudentDb();
        }
        public StudentBiz(DataRow objDr)
        {
            _StudentDb = new StudentDb(objDr);
        }
        public StudentBiz(int intID,int intFacultyID)
        {
            if (intID != 0)
            {
                StudentDb objDb = new StudentDb();
                objDb.IDs = intID.ToString();
                objDb.Faculty = intFacultyID;
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count > 0)
                {
                    _StudentDb = new StudentDb(dtTemp.Rows[0]);
                }
            }
            else
                _StudentDb = new StudentDb();
        }
        #endregion
        #region Private Data
        StudentDb _StudentDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _StudentDb.ID = value;
            get => _StudentDb.ID;
        }
        public int Gender
        {
            set => _StudentDb.Gender = value;
            get => _StudentDb.Gender;
        }
        public int Faculty
        {
            set => _StudentDb.Faculty = value;
            get => _StudentDb.Faculty;
        }
        public string Code
        {
            set => _StudentDb.Code = value;
            get => _StudentDb.Code;
        }
        public string NameA
        {
            set => _StudentDb.NameA = value;
            get => _StudentDb.NameA;
        }
        public string NameE
        {
            set => _StudentDb.NameE = value;
            get => _StudentDb.NameE;
        }
        public DateTime BirthDate
        {
            set => _StudentDb.BirthDate = value;
            get => _StudentDb.BirthDate;
        }
        public string Mobile1
        {
            set => _StudentDb.Mobile1 = value;
            get => _StudentDb.Mobile1;
        }
        public string Mobile2
        {
            set => _StudentDb.Mobile2 = value;
            get => _StudentDb.Mobile2;
        }
        public string Phone1
        {
            set => _StudentDb.Phone1 = value;
            get => _StudentDb.Phone1;
        }
        public string Phone2
        {
            set => _StudentDb.Phone2 = value;
            get => _StudentDb.Phone2;
        }
        public string Address
        {
            set => _StudentDb.Address = value;
            get => _StudentDb.Address;
        }
        public string Email
        {
            set => _StudentDb.Email = value;
            get => _StudentDb.Email==null || _StudentDb.Email==""?Code+ "@std.ahuc.edu.eg" : _StudentDb.Email;
        }
        public int HomeCity
        {
            set => _StudentDb.HomeCity = value;
            get => _StudentDb.HomeCity;
        }
        public int HomeCountry
        {
            set => _StudentDb.HomeCountry = value;
            get => _StudentDb.HomeCountry;
        }
        public int LastGrade
        {
            set => _StudentDb.LastGrade = value;
            get => _ResultBiz==null||_ResultBiz.ID==0? _StudentDb.LastGrade:_ResultBiz.Level;
        }
       
        public string MaxResultCGPA
        {
            set => _StudentDb.MaxResultCGPA = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultCGPA:_ResultBiz.CGPA;
        }
        public double MaxResultCPoints
        {
            set => _StudentDb.MaxResultCPoints = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultCPoints:_ResultBiz.CPoints;
        }
        public double MaxResultTotalCreditHour
        {
            set => _StudentDb.MaxResultTotalCreditHour = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultTotalCreditHour:_ResultBiz.TotalCreditHour;
        }
        public double MaxResultEarnedHour
        {
            set => _StudentDb.MaxResultEarnedHour = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultEarnedHour:_ResultBiz.EarnedHour;
        }
        public string MaxResultSGPA
        {
            set => _StudentDb.MaxResultSGPA = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultSGPA:_ResultBiz.SGPA;
        }
        public double MaxResultSPoints
        {
            set => _StudentDb.MaxResultSPoints = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultSPoints:_ResultBiz.SPoints;
        }
        public string MaxResultNote
        {
            set => _StudentDb.MaxResultNote = value;
            get => _ResultBiz == null || _ResultBiz.ID == 0 ? _StudentDb.MaxResultNote:_ResultBiz.Note;
        }
        StudentResultBiz _ResultBiz;
        public StudentResultBiz ResultBiz
        {
            set => _ResultBiz = value;
            get
           {
                if (_ResultBiz == null)
                    _ResultBiz = new StudentResultBiz();
                return _ResultBiz;
            } }
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
        RegisterationCol _NonPostedRegisterationCol;
        public RegisterationCol NonPostedRegisterationCol
        {
            set => _NonPostedRegisterationCol = value;
            get
            {
                if (_NonPostedRegisterationCol == null)
                {
                    RegisterationBiz objBiz = new RegisterationBiz();
                    _NonPostedRegisterationCol = new RegisterationCol(true,0);
                    if(ID!=0)
                    {
                        RegisterationDb objDb = new RegisterationDb() { Student = ID,PostStatus=2,Faculty = Faculty };
                        DataTable dtTemp = objDb.Search();
                        foreach(DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new RegisterationBiz(objDr);
                            objBiz.StudentBiz = this;
                            _NonPostedRegisterationCol.Add(objBiz);
                        }
                    }
                }
                return _NonPostedRegisterationCol;
            }
        }
        RegisterationCol _PostedRegisterationCol;
        public RegisterationCol PostedRegisterationCol
        {
            set => _PostedRegisterationCol = value;
            get
            {
                if (_PostedRegisterationCol == null)
                {
                    RegisterationBiz objBiz = new RegisterationBiz();
                    _PostedRegisterationCol = new RegisterationCol(true,0);
                    if (ID != 0)
                    {
                        RegisterationDb objDb = new RegisterationDb() { Student = ID, PostStatus = 1,Faculty = Faculty };
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new RegisterationBiz(objDr);
                            objBiz.StudentBiz = this;
                            _PostedRegisterationCol.Add(objBiz);
                        }
                    }
                }
                return _PostedRegisterationCol;
            }
        }
        StudentResultBiz _MaxResultBiz;
        public StudentResultBiz MaxResultBiz
        {
            set => _MaxResultBiz = value;
            get
            {
                if(_MaxResultBiz== null)
                {
                    _MaxResultBiz = new StudentResultBiz() { StudentBiz = this, CGPA = MaxResultCGPA,CPoints=MaxResultCPoints,EarnedHour=MaxResultEarnedHour, TotalCreditHour=MaxResultTotalCreditHour};
                }
                return _MaxResultBiz;
            }
        }
        int _UnPostedCount;
        public int UnPostedCount { set => _UnPostedCount = value; get => _UnPostedCount; }
        static int _StudentUserGroupID;
        RegisterationExamCol _ExamCol;
        public RegisterationExamCol ExamCol
        {
            set => _ExamCol = value;
            get
            {
                if (_ExamCol == null)
                    _ExamCol = new RegisterationExamCol(true);
                return _ExamCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _StudentDb.Add();
        }
        public void Edit()
        {
            _StudentDb.Edit();
        }
        public void Delete()
        {
            _StudentDb.Delete();
        }
        public CourseCol GetRecommendedCourse()
        {
            DataTable dtTemp = _StudentDb.GetRecommendedRegisterationCourse();
            CourseCol objCol = new CourseCol(true,0);
            foreach (DataRow objDr in dtTemp.Rows)
                objCol.Add(new CourseBiz(objDr));
            return objCol;
        }
        public static void UploadStudentTable(DataTable dtTemp)
        {
            StudentDb objDb = new StudentDb();
            objDb.StudentTable = dtTemp;
            objDb.UploadStudent();
        }
        public static bool CheckStudent(string strCode,string strPass,out StudentBiz objStudent)
        {
            objStudent = new StudentBiz();
            bool Returned = false;
            StudentDb objDb = new StudentDb() { };

            DataTable dtTemp = objDb.GetStudentByUserNameAndPass();
            if(dtTemp.Rows.Count>0)
            {

            }
            return Returned;
        }
        #endregion
    }
}