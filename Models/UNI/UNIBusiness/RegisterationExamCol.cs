using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationExamCol:CollectionBase
    {

        #region Constructor
        public RegisterationExamCol()
        {

        }
        public RegisterationExamCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            RegisterationExamBiz objBiz = new RegisterationExamBiz();
          
            RegisterationExamDb objDb = new RegisterationExamDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationExamBiz(objDR);
                Add(objBiz);
            }
        }
        public RegisterationExamCol(ExamBiz objExamBiz,SemesterBiz objSemester,CourseBiz objCourse,StudentBiz objStudent,int intFaculty,int? intRegisteration,int? intStoppedStatus=0,bool?blOnlySelected=false)
        {
            if (objSemester == null)
                objSemester = new SemesterBiz();
            if (objStudent == null)
                objStudent = new StudentBiz();
            if (objCourse == null)
                objCourse = new CourseBiz();
            if (objExamBiz == null)
                objExamBiz = new ExamBiz();
            RegisterationExamBiz objBiz = new RegisterationExamBiz();

            RegisterationExamDb objDb = new RegisterationExamDb();
            objDb.Exam = objExamBiz.ID;
            objDb.Course = objCourse.ID;
            objDb.Student = objStudent.ID;
            objDb.Semester = objSemester.ID;
            objDb.Faculty = intFaculty;
            objDb.StoppedStatus = intStoppedStatus.GetValueOrDefault();

            objDb.OnlySelected = blOnlySelected.GetValueOrDefault();
            objDb.Registeration = intRegisteration.GetValueOrDefault();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationExamBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public RegisterationExamBiz this[int intIndex]
        {
            get
            {
                return (RegisterationExamBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(RegisterationExamBiz objBiz)
        {
            List.Add(objBiz);
        }
        public RegisterationExamCol GetCol(string strTemp)
        {
            RegisterationExamCol Returned = new RegisterationExamCol(true);
            foreach (RegisterationExamBiz objBiz in this)
            {
                //if (objBiz.Name.CheckStr(strTemp))
                //    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("RegisterationExamID"), new DataColumn("RegisterationExamRegisteration"), new DataColumn("RegisterationExamExam"), new DataColumn("RegisterationExamGrade"), new DataColumn("RegisterationExamDegree"), new DataColumn("RegisterationExamNote"), new DataColumn("RegisterationExamDate", System.Type.GetType("System.DateTime")), new DataColumn("RegisterationExamEvaluationEmployee"), new DataColumn("RegisterationExamEvaluationUsr"), new DataColumn("RegisterationExamStatus") });
            DataRow objDr;
            foreach (RegisterationExamBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["RegisterationExamID"] = objBiz.ID;
                objDr["RegisterationExamRegisteration"] = objBiz.Registeration;
                objDr["RegisterationExamExam"] = objBiz.Exam;
                objDr["RegisterationExamGrade"] = objBiz.Grade;
                objDr["RegisterationExamDegree"] = objBiz.Degree;
                objDr["RegisterationExamNote"] = objBiz.Note;
                objDr["RegisterationExamDate"] = objBiz.Date;
                objDr["RegisterationExamEvaluationEmployee"] = objBiz.EvaluationEmployee;
                objDr["RegisterationExamEvaluationUsr"] = objBiz.EvaluationUsr;
                objDr["RegisterationExamStatus"] = objBiz.Status;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public DataTable GetInsertTable(int intUser)
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] {  new DataColumn("RegisterationExamRegisteration"), new DataColumn("RegisterationExamExam"), new DataColumn("RegisterationExamDegree"), new DataColumn("RegisterationExamNote"), new DataColumn("UsrIns") });
            DataRow objDr;
            foreach (RegisterationExamBiz objBiz in this)
            {
                objDr = Returned.NewRow();
               
                objDr["RegisterationExamRegisteration"] = objBiz.RegisterationBiz.ID;
                objDr["RegisterationExamExam"] = objBiz.ExamBiz.ID;
               
                objDr["RegisterationExamDegree"] = objBiz.Degree;
                objDr["RegisterationExamNote"] = objBiz.Note;
                
           
                objDr["UsrIns"] = intUser;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void UploadMultiExam(int intUser)
        {

            RegisterationExamDb objDb = new RegisterationExamDb() { User = intUser, ExamTable = this.GetInsertTable(intUser) };
            objDb.UploadMultipleExam();
        }
        public StudentCol GetStudentCol(int intFaculty)
        {
            StudentCol Returned = new StudentCol(true, 0);
            Hashtable hsTemp = new Hashtable();
            StudentBiz objStudent = new StudentBiz();

            foreach (RegisterationExamBiz objBiz in this)
            {
                if(hsTemp[objBiz.RegisterationBiz.StudentBiz.ID.ToString()]== null)
                {
                    objStudent = objBiz.RegisterationBiz.StudentBiz;
                    hsTemp.Add(objBiz.RegisterationBiz.StudentBiz.ID.ToString(), objStudent);
                    Returned.Add(objStudent);
                }
                else
                {
                    objStudent = (StudentBiz)hsTemp[objBiz.RegisterationBiz.StudentBiz.ID.ToString()];
                }
                objStudent.ExamCol.Add(objBiz);
            }
         
                return Returned;
        }
        #endregion
    }
}