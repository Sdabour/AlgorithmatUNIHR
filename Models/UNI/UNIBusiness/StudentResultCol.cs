using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentResultCol : CollectionBase
    {

        #region Constructor
        public StudentResultCol()
        {

        }
        public StudentResultCol(bool blIsEmbty,int intFaculty)
        {
            if (blIsEmbty)
                return;
            StudentResultBiz objBiz = new StudentResultBiz();
            objBiz.ID = 0;


            StudentResultDb objDb = new StudentResultDb();
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new StudentResultBiz(objDR);
                Add(objBiz);
            }
        }
        public StudentResultCol(int intFaculty,ResultStatementBiz objStatement,int intLevel,string StrCode,int intStoppedStatus,bool blSelected)
        {

            if (objStatement == null)
                objStatement = new ResultStatementBiz();


            StudentResultDb objDb = new StudentResultDb() { Faculty=intFaculty,Statement=objStatement.ID,Level=intLevel,StudentCode= StrCode,StoppedStatus=intStoppedStatus,OnlySelectedStudents=blSelected};

            DataTable dtTemp = objDb.Search();
            StudentResultBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new StudentResultBiz(objDR);
                Add(objBiz);
            }
        }
        public StudentResultCol(StudentCol objStudentCol)
        {

           


            StudentResultDb objDb = new StudentResultDb() { Faculty = objStudentCol[0].Faculty, StudentIDs=objStudentCol.IDsStr};

            DataTable dtTemp = objDb.Search();
            StudentResultBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new StudentResultBiz(objDR);
                Add(objBiz);
            }
        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public StudentResultBiz this[int intIndex]
        {
            get
            {
                return (StudentResultBiz)this.List[intIndex];
            }
        }
        public string IDsStr
        { get
            {
                string Returned = "";
                foreach (StudentResultBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public List<LevelBiz> PostedLevelLst
        {
            get
            {

                List<LevelBiz> Returned = new List<LevelBiz>();
                var vrGrdLst = from objStudent in this.Cast<StudentResultBiz>()
                               group objStudent by objStudent.Level
                            into GradeID
                               select GradeID;
                LevelBiz objGrade;
                foreach (var vrGrd in vrGrdLst)
                {
                    objGrade = new LevelBiz() { Level = vrGrd.Key };
                    // objGrade.StudentCol = new StudentCol(true);
                    foreach (StudentResultBiz objResult in vrGrd.ToList())
                    {
                        objResult.StudentBiz.ResultBiz = objResult;
                        objGrade.StudentCol.Add(objResult.StudentBiz);
                    }
                    objGrade.StudentCol.SetResultRegisterationCol();
                    objGrade.CourseCol = objGrade.StudentCol.CourseCol;
                    Returned.Add(objGrade);
                }
                return Returned;
            }
        }
        public RegisterationCol RegisterationCol
        {
            get
            {
                RegisterationCol Returned = new RegisterationCol(true,0);
                foreach(StudentResultBiz objBiz in this)
                {
                    foreach(RegisterationBiz objReg in objBiz.RegisterationCol)
                    {
                        objReg.StudentBiz = objBiz.StudentBiz;
                        objReg.StudentBiz.MaxResultBiz = objBiz;
                        Returned.Add(objReg);
                    }
                }
                return Returned;
            }
        }
        public StudentCol StudentCol
        {
            get
            {
                StudentCol Returned = new StudentCol();
                foreach(StudentResultBiz objBiz in this)
                {
                    Returned.Add(objBiz.StudentBiz);
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(StudentResultBiz objBiz)
        {
            List.Add(objBiz);
        }
        public StudentResultCol GetCol(string strTemp)
        {
            StudentResultCol Returned = new StudentResultCol(true,0);
            foreach (StudentResultBiz objBiz in this)
            {

                Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ResultID"), new DataColumn("ResultStatement"), new DataColumn("ResultStudent"), new DataColumn("ResultCGPA"), new DataColumn("ResultCPoints"), new DataColumn("ResultTotalCreditHour"), new DataColumn("ResultEarnedHour"), new DataColumn("ResultSCreditHour"), new DataColumn("ResultSEarnedHour"), new DataColumn("ResultSGPA"), new DataColumn("ResultSPoints"), new DataColumn("ResultNote"), new DataColumn("ResultLevel"), new DataColumn("ResultStopped", System.Type.GetType("System.Boolean")), new DataColumn("ResultStopReason") });
            DataRow objDr;
            foreach (StudentResultBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ResultID"] = objBiz.ID;
                objDr["ResultStatement"] = objBiz.StatementBiz.ID;
                objDr["ResultStudent"] = objBiz.StudentBiz.ID;
                objDr["ResultCGPA"] = objBiz.CGPA;
                objDr["ResultCPoints"] = objBiz.CPoints;
                objDr["ResultTotalCreditHour"] = objBiz.TotalCreditHour;
                objDr["ResultEarnedHour"] = objBiz.EarnedHour;
                objDr["ResultSCreditHour"] = objBiz.SCreditHour;
                objDr["ResultSEarnedHour"] = objBiz.SEarnedHour;

                objDr["ResultSGPA"] = objBiz.SGPA;
                objDr["ResultSPoints"] = objBiz.SPoints;
                objDr["ResultNote"] = objBiz.Note;
                objDr["ResultLevel"] = objBiz.Level;
                objDr["ResultStopped"] = objBiz.Stopped;
                objDr["ResultStopReason"] = objBiz.StopReason;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public DataTable GetRegisterationTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StudentID"), new DataColumn("RegisterationID") ,new DataColumn("VerbalGPA"),new DataColumn("GPA"),new DataColumn("Bonus") });
            DataRow objDr;
            foreach (StudentResultBiz objBiz in this)
            {
                foreach (RegisterationBiz objReg in objBiz.RegisterationCol)
                {
                    objDr = Returned.NewRow();
                    objDr["StudentID"] = objBiz.ID;
                    objDr["RegisterationID"] = objReg.ID;
                    objDr["VerbalGPA"] = objReg.VerbalGPA;
                    objDr["GPA"] = objReg.Points;
                    objDr["Bonus"] = objReg.Bonus;
                    Returned.Rows.Add(objDr);
                }
            }
            return Returned;
        }
        public void SaveResult(int intStatement)
        {
            StudentResultDb objDb = new StudentResultDb() { Statement=intStatement,ResultTable = GetTable(),RegisterationTable = GetRegisterationTable() };
            objDb.SaveReult();

        }
        public void SetRegisterationCol()
        {
            if (Count == 0)
                return;
            RegisterationResultDb objDb = new RegisterationResultDb();
            objDb.ResultIDs = IDsStr;
            objDb.ResultStatus = 1;
            objDb.Faculty = this[0].StudentBiz.Faculty;
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            RegisterationResultBiz objRegResult;
            foreach (StudentResultBiz objBiz in this)
            {
                arrDr = dtTemp.Select("RegisterationStudent=" + objBiz.Student, "CourseCode,SemesterID");
                objBiz.RegisterationCol = new RegisterationCol();
                foreach(DataRow objDr in arrDr)
                {
                    objRegResult = new RegisterationResultBiz(objDr);
                    objBiz.StudentBiz.ResultBiz = objBiz;             
                    objRegResult.StudentBiz = objBiz.StudentBiz;       objBiz.RegisterationCol.Add(objRegResult);
                }
            }
        }
        public void Stop(bool blStopped)
        {
            StudentResultDb objDb = new StudentResultDb() { IDs = IDsStr };
            objDb.Stopped = blStopped;
            objDb.Stop();
        }
        public void Delete()
        {
            StudentResultDb objDb = new StudentResultDb() { IDs = IDsStr };
            objDb.DeleteResultCol();

        }
        public StudentCol GetStudentResultCol()
        {
            StudentCol Returned = new StudentCol(true,0);
            List<StudentResultBiz> lstResult = this.Cast<StudentResultBiz>().Where(x => !x.Stopped).ToList();
            if (lstResult.Count == 0)
                return Returned;
           SetRegisterationCol();
            string strIDs = "";

            foreach(StudentResultBiz objBiz1 in lstResult)
            {
                if (strIDs != "")
                    strIDs += ",";
                strIDs += objBiz1.StudentBiz.ID.ToString();
            }
            StudentDb objStudentDb = new StudentDb();
            objStudentDb.IDs = strIDs;
            int intFaculty = 1;
            if (Count > 0)
                intFaculty = this[0].StudentBiz.Faculty;
            objStudentDb.Faculty = intFaculty;
            DataTable dtTemp = objStudentDb.Search();
            DataRow[] arrDr;
            StudentBiz objStudentBiz;
            foreach(StudentResultBiz objBiz in this)
            {
                if(objBiz.Stopped)
                {
                    continue;
                }

                arrDr = dtTemp.Select("StudentID=" + objBiz.StudentBiz.ID);
               if(arrDr.Length>0)
                {
                    objStudentBiz = new StudentBiz(arrDr[0]);
                    objStudentBiz.ResultBiz = objBiz;
                    objStudentBiz.RegisterationCol = objBiz.RegisterationCol;
                    Returned.Add(objStudentBiz);
                }
            }
            return Returned;
        }

        #endregion
    }
}