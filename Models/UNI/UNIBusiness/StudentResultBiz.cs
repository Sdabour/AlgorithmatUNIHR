using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentResultBiz
    {

        #region Constructor
        public StudentResultBiz()
        {
            _StudentResultDb = new StudentResultDb();
        }
        public StudentResultBiz(DataRow objDr)
        {
            _StudentResultDb = new StudentResultDb(objDr);
            _StatementBiz = new ResultStatementBiz(objDr);
        }

        #endregion
        #region Private Data
        StudentResultDb _StudentResultDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _StudentResultDb.ID = value;
            get => _StudentResultDb.ID;
        }
        public int Statement
        {
            set => _StudentResultDb.Statement = value;
            get => _StudentResultDb.Statement;
        }
        public int Student
        {
            set => _StudentResultDb.Student = value;
            get => _StudentResultDb.Student;
        }
        public string CGPA
        {
            set => _StudentResultDb.CGPA = value;
            get => _StudentResultDb.CGPA;
        }
        public double CPoints
        {
            set => _StudentResultDb.CPoints = value;
            get => _StudentResultDb.CPoints;
        }
        public double TotalCreditHour
        {
            set => _StudentResultDb.TotalCreditHour = value;
            get => _StudentResultDb.TotalCreditHour;
        }
        public double EarnedHour
        {
            set => _StudentResultDb.EarnedHour = value;
            get => _StudentResultDb.EarnedHour;
        }
        public double SCreditHour
        {
            set => _StudentResultDb.SCreditHour = value;
            get => _StudentResultDb.SCreditHour;
        }
        public double SEarnedHour
        {
            set => _StudentResultDb.SEarnedHour = value;
            get => _StudentResultDb.SEarnedHour;
        }
        public string SGPA
        {
            set => _StudentResultDb.SGPA = value;
            get => _StudentResultDb.SGPA;
        }
        public double SPoints
        {
            set => _StudentResultDb.SPoints = value;
            get => _StudentResultDb.SPoints;
        }
        public string Note
        {
            set => _StudentResultDb.Note = value;
            get => _StudentResultDb.Note;
        }
        public int Level
        {
            set => _StudentResultDb.Level = value;
            get => _StudentResultDb.Level;
        }
        public bool Stopped
        {
            set => _StudentResultDb.Stopped = value;
            get => _StudentResultDb.Stopped;
        }
        public string StopReason
        {
            set => _StudentResultDb.StopReason = value;
            get => _StudentResultDb.StopReason;
        }
        public bool Sent {
            set => _StudentResultDb.Sent = value;
            get => _StudentResultDb.Sent;
        }
        StudentBiz _StudentBiz;
        public StudentBiz StudentBiz
        {
            set => _StudentBiz = value;
            get
            {
                if(_StudentBiz== null)
                {
                    _StudentBiz = new StudentBiz() { ID = _StudentResultDb.Student, Code = _StudentResultDb.StudentCode, Email = _StudentResultDb.StudentEmail, Mobile1 = _StudentResultDb.StudentMobile, NameA = _StudentResultDb.StudentNameA, NameE = _StudentResultDb.StudentNameE ,Faculty=_StudentResultDb.Faculty};
                }
                return _StudentBiz;
            }
        }
        SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz
        { set => _SemesterBiz = value;
            get
            {
                if (_SemesterBiz == null)
                    _SemesterBiz = new SemesterBiz();
                return _SemesterBiz;
            }
        }
        public int NewLevelOrder { set => _StudentResultDb.NewLevelOrder = value; get => _StudentResultDb.NewLevelOrder; }
        
        public string NewLevelDesc { set => _StudentResultDb.NewLevelDesc = value; get => _StudentResultDb.NewLevelDesc; }
       
        public int OldLevelOrder { set => _StudentResultDb.OldLevelOrder = value; get => _StudentResultDb.OldLevelOrder; }
       
        public string OldLevelDesc { set => _StudentResultDb.OldLevelDesc = value; get => _StudentResultDb.OldLevelDesc; }
        RegisterationCol _RegisterationCol;
        public RegisterationCol RegisterationCol
        {
            set => _RegisterationCol = value;
            get
            {
                if(_RegisterationCol== null)
                {
                    _RegisterationCol = new RegisterationCol(true,0);

                }
                return _RegisterationCol;
            }
        }
        ResultStatementBiz _StatementBiz;
        public ResultStatementBiz StatementBiz
        { set => _StatementBiz = value;
        get
            {
                if (_StatementBiz == null)
                    _StatementBiz = new ResultStatementBiz();
                return _StatementBiz;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _StudentResultDb.Add();
        }
        public void Edit()
        {
            _StudentResultDb.Edit();
        }
        public void Delete()
        {
            _StudentResultDb.Delete();
        }
        public void Send(bool blSent)
        {
            _StudentResultDb.IDs = ID.ToString();
            _StudentResultDb.Sent = blSent;
            _StudentResultDb.Send();
        }
        #endregion
    }
}