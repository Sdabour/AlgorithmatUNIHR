using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationExamBiz
    {

        #region Constructor
        public RegisterationExamBiz()
        {
            _RegisterationExamDb = new RegisterationExamDb();
        }
        public RegisterationExamBiz(DataRow objDr)
        {
            _RegisterationExamDb = new RegisterationExamDb(objDr);
            _ExamBiz = new ExamBiz(objDr);
            _RegisterationBiz = new RegisterationBiz(objDr);
        }

        #endregion
        #region Private Data
        RegisterationExamDb _RegisterationExamDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _RegisterationExamDb.ID = value;
            get => _RegisterationExamDb.ID;
        }
        public int Registeration
        {
            set => _RegisterationExamDb.Registeration = value;
            get => _RegisterationExamDb.Registeration;
        }
        public int Exam
        {
            set => _RegisterationExamDb.Exam = value;
            get => _RegisterationExamDb.Exam;
        }
        public int Grade
        {
            set => _RegisterationExamDb.Grade = value;
            get => _RegisterationExamDb.Grade;
        }
        public double Degree
        {
            set => _RegisterationExamDb.Degree = value;
            get => _RegisterationExamDb.Degree;
        }
        public string Note
        {
            set => _RegisterationExamDb.Note = value;
            get => _RegisterationExamDb.Note;
        }
        public DateTime Date
        {
            set => _RegisterationExamDb.Date = value;
            get => _RegisterationExamDb.Date;
        }
        public int EvaluationEmployee
        {
            set => _RegisterationExamDb.EvaluationEmployee = value;
            get => _RegisterationExamDb.EvaluationEmployee;
        }
        public int EvaluationUsr
        {
            set => _RegisterationExamDb.EvaluationUsr = value;
            get => _RegisterationExamDb.EvaluationUsr;
        }
        public int Status
        {
            set => _RegisterationExamDb.Status = value;
            get => _RegisterationExamDb.Status;
        }
        ExamBiz _ExamBiz;
        public ExamBiz ExamBiz
        {
            set => _ExamBiz = value;
            get
            {
                if (_ExamBiz == null)
                    _ExamBiz = new ExamBiz();
                return _ExamBiz;
            }
        }
        RegisterationBiz _RegisterationBiz;
        public RegisterationBiz RegisterationBiz
        {
            set => _RegisterationBiz = value;
            get
            {
                if (_RegisterationBiz == null)
                    _RegisterationBiz = new RegisterationBiz();
                return _RegisterationBiz;
            }
        }
        #region UMS
        public static int UMSAllCourses = 2422;
        
        #endregion
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _RegisterationExamDb.Registeration = RegisterationBiz.ID;
            _RegisterationExamDb.Exam = ExamBiz.ID;
            _RegisterationExamDb.Add();
        }
        public void Edit()
        {
            _RegisterationExamDb.Registeration = RegisterationBiz.ID;
            _RegisterationExamDb.Exam = ExamBiz.ID;

            _RegisterationExamDb.Edit();
        }
        public void EditStatus()
        {
            _RegisterationExamDb.Registeration = RegisterationBiz.ID;
            _RegisterationExamDb.Exam = ExamBiz.ID;

            _RegisterationExamDb.EditStatus();
        }
        public void Delete()
        {
            _RegisterationExamDb.Delete();
        }
        #endregion
    }
}