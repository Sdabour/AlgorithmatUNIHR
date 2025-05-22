using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationExamSimple
    {

        #region Properties
        public int ID;
        public int Registeration;
        public int Exam;
        public int Grade;
        public double Degree;
        public string Note;
        public DateTime Date;
        public int EvaluationEmployee;
        public int EvaluationUsr;
        public int Status;
        public ExamSimple ExamSimple = new ExamSimple();
        public RegisterationSimple RegisterationSimple = new RegisterationSimple();
        public List<RegisterationExamSimple> lstExam = new List<RegisterationExamSimple>();
        #endregion
    }
}