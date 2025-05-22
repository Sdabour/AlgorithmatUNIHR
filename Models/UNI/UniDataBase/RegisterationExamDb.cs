using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class RegisterationExamDb
    {

        #region Constructor
        public RegisterationExamDb()
        {
        }
        public RegisterationExamDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        int _Registeration;
        public int Registeration
        {
            set => _Registeration = value;
            get => _Registeration;
        }
        int _Exam;
        public int Exam
        {
            set => _Exam = value;
            get => _Exam;
        }
        string _ExamIDs;
       public string ExamIDs { set => _ExamIDs = value; }
        int _Faculty;
        public int Faculty { set => _Faculty=value; }
        int _Grade;
        public int Grade
        {
            set => _Grade = value;
            get => _Grade;
        }
        double _Degree;
        public double Degree
        {
            set => _Degree = value;
            get => _Degree;
        }
        string _Note;
        public string Note
        {
            set => _Note = value;
            get => _Note;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        int _EvaluationEmployee;
        public int EvaluationEmployee
        {
            set => _EvaluationEmployee = value;
            get => _EvaluationEmployee;
        }
        int _EvaluationUsr;
        public int EvaluationUsr
        {
            set => _EvaluationUsr = value;
            get => _EvaluationUsr;
        }
        int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        int _User = 0;
        public int User
        {
            set => _User = value;
            get
            {
                if (_User == 0)
                    return SysData.CurrentUser.ID;
                return _User;
            }
        }
        int _Student;
        public int Student { set => _Student = value; }
        int _Course;
        public int Course { set => _Course = value; }
        int _Semester;
        public int Semester { set => _Semester = value; }
        DataTable _ExamTable;
        public DataTable ExamTable { set => _ExamTable = value; }
        //int _User;
        //public int User { set => _User = value;
        //    get => _User == 0 ? SysData.CurrentUser.ID ? _User; }
        int _StoppedStatus;
        public int StoppedStatus { set => _StoppedStatus = value; }
        bool _OnlySelected;
        public bool OnlySelected { set => _OnlySelected = value; }
        public string AddStr
        {
            get
            {
                string strExam = @"SELECT ExamID,ExamGrade
FROM     dbo.UNIExam
WHERE  (ExamID = "+_Exam+")";
                string Returned = " insert into UNIRegisterationExam (RegisterationExamRegisteration,RegisterationExamExam,RegisterationExamGrade,RegisterationExamDegree,RegisterationExamNote,RegisterationExamDate,RegisterationExamEvaluationEmployee,RegisterationExamEvaluationUsr,RegisterationExamStatus,UsrIns,TimIns) select " + Registeration + " as ExamRegisteration," + Exam + " as Exam1,ExamTable.ExamGrade as ExamGrade," + Degree + " as ExamDegree,'" + Note + "' as ExamNote," + (Date.Date.ToOADate() - 2).ToString() + " as ExamDate," + EvaluationEmployee + " as Employee," + User + " as User1," + Status + " as STatus1," +User + @" as UserIns,GetDate() as TimIns
  FROM     dbo.UNIRegisteration
  cross join (" + strExam + @") as ExamTable
  WHERE  (RegisterationID = " + _Registeration+@")
AND (NOT EXISTS
                      (SELECT RegisterationExamID
                       FROM      dbo.UNIRegisterationExam
 
                       WHERE   (RegisterationExamRegisteration = "+_Registeration+@") AND (RegisterationExamExam = "+_Exam+ @")
)) 
  and isnull(RegisterationResult,0)=0 and  isnull(RegisterationPosted,0)=0";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIRegisterationExam set RegisterationExamDegree=" + Degree + "" +
           ",RegisterationExamNote='" + Note + "'" +
          
           ",RegisterationExamStatus=" + Status + "" + ",UsrUpd=" + User + @",TimUpd=GetDate() 
  FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
WHERE   RegisterationExamRegisteration  =" + _Registeration + " and RegisterationExamExam ="+_Exam + @" and (ISNULL(dbo.UNIRegisteration.RegisterationResult, 0) = 0) AND (ISNULL(dbo.UNIRegisteration.RegisterationPosted, 0) = 0) ";
                Returned += " "+AddStr;
                return Returned;
            }
        }
        public string EditStatusStr
        {
            get
            {
                string Returned = " update UNIRegisterationExam set  RegisterationExamStatus=" + Status + "" + ",UsrUpd=" + User + @",TimUpd=GetDate() 
  FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
WHERE   RegisterationExamRegisteration  =" + _Registeration + " and RegisterationExamExam =" + _Exam + @" and (ISNULL(dbo.UNIRegisteration.RegisterationResult, 0) = 0) AND (ISNULL(dbo.UNIRegisteration.RegisterationPosted, 0) = 0) ";
                Returned += " " + AddStr;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIRegisterationExam set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strStopStatus = @"SELECT distinct StudentID
FROM     dbo.UNISemesterStoppedStudent
WHERE  (SemesterID = "+_Semester+") AND (Dis IS NULL)";

                string Returned = @" select UNIRegisterationExam.RegisterationExamID,UNIRegisterationExam.RegisterationExamRegisteration,UNIRegisterationExam.RegisterationExamExam,RegisterationExamGrade,RegisterationExamDegree,RegisterationExamNote,RegisterationExamDate,RegisterationExamEvaluationEmployee,RegisterationExamEvaluationUsr,RegisterationExamStatus,ExamTable.*,RegisterationTable.*  
  from UNIRegisterationExam 
   inner join (" + new ExamDb().SearchStr+ @") as ExamTable 
   on UNIRegisterationExam.RegisterationExamExam = ExamTable.ExamID
   inner join ("+new RegisterationDb() { Faculty=_Faculty}.SearchStr+ @") as RegisterationTable
   on UNIRegisterationExam.RegisterationExamRegisteration = RegisterationTable.RegisterationID  ";
                Returned += @" INNER JOIN
                      (SELECT     RegisterationExamExam, RegisterationExamRegisteration, MAX(RegisterationExamID) AS MaxRegisterationExamID
                       FROM        dbo.UNIRegisterationExam AS UNIRegisterationExam_1
                       GROUP BY RegisterationExamExam, RegisterationExamRegisteration) AS derivedtbl_1 ON dbo.UNIRegisterationExam.RegisterationExamExam = derivedtbl_1.RegisterationExamExam AND
                  dbo.UNIRegisterationExam.RegisterationExamRegisteration = derivedtbl_1.RegisterationExamRegisteration AND dbo.UNIRegisterationExam.RegisterationExamID = derivedtbl_1.MaxRegisterationExamID";
                if(_StoppedStatus!= 0)
                {
                    Returned += @" left outer join ("+strStopStatus+ @") as StoppedTable 
   on  RegisterationTable.RegisterationStudent = StoppedTable.StudentID ";
                }
                if(_OnlySelected)
                {
                    Returned += " inner join VUNIRegisterationExamSelected on UNIRegisterationExam.RegisterationExamID  = VUNIRegisterationExamSelected.RegisterationExamID";
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["RegisterationExamID"] != null)
                int.TryParse(objDr["RegisterationExamID"].ToString(), out _ID);

            if (objDr.Table.Columns["RegisterationExamRegisteration"] != null)
                int.TryParse(objDr["RegisterationExamRegisteration"].ToString(), out _Registeration);
            if(_Registeration ==60031)
            {

            }
            if (objDr.Table.Columns["RegisterationExamExam"] != null)
                int.TryParse(objDr["RegisterationExamExam"].ToString(), out _Exam);

            if (objDr.Table.Columns["RegisterationExamGrade"] != null)
                int.TryParse(objDr["RegisterationExamGrade"].ToString(), out _Grade);

            if (objDr.Table.Columns["RegisterationExamDegree"] != null)
                double.TryParse(objDr["RegisterationExamDegree"].ToString(), out _Degree);

            if (objDr.Table.Columns["RegisterationExamNote"] != null)
                _Note = objDr["RegisterationExamNote"].ToString();

            if (objDr.Table.Columns["RegisterationExamDate"] != null)
                DateTime.TryParse(objDr["RegisterationExamDate"].ToString(), out _Date);

            if (objDr.Table.Columns["RegisterationExamEvaluationEmployee"] != null)
                int.TryParse(objDr["RegisterationExamEvaluationEmployee"].ToString(), out _EvaluationEmployee);

            if (objDr.Table.Columns["RegisterationExamEvaluationUsr"] != null)
                int.TryParse(objDr["RegisterationExamEvaluationUsr"].ToString(), out _EvaluationUsr);

            if (objDr.Table.Columns["RegisterationExamStatus"] != null)
                int.TryParse(objDr["RegisterationExamStatus"].ToString(), out _Status);
        }
        public static string GetExamResultByTypeStr(int intType)
        {
            string strMaxExamStatus = @"SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = "+intType+")) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID";
            string Returned = @"SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (" + strMaxExamStatus+ @") as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = " + intType+")";
            return Returned;
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStatus()
        {
            string strSql = EditStatusStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where (1=1) ";
            if (_Registeration != 0)
                strSql += " and UNIRegisterationExam.RegisterationExamRegisteration=" + _Registeration;
            if (_Exam != 0)
                strSql += " and UNIRegisterationExam.RegisterationExamExam = "+ _Exam;
            if(_ExamIDs!= null&& _ExamIDs!= "")
                strSql += " and RegisterationExamExam in (" + _ExamIDs +") ";
            if (_Course != 0)
                strSql += " and RegisterationTable.RegisterationCourse="+_Course;
            if (_Student != 0)
                strSql += " and RegisterationTable.RegisterationStudent="+_Student;
            if (_Semester != 0)
                strSql += " and RegisterationTable.RegisterationSemester=" + _Semester;
            if(_StoppedStatus!= 0)
            {
                if (_StoppedStatus == 1)
                    strSql += " and (StoppedTable.StudentID is not null) ";
                else if (_StoppedStatus == 2)
                    strSql += " and (StoppedTable.StudentID is null) ";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void UploadMultipleExam()
        {
            if (_ExamTable == null || _ExamTable.Rows.Count == 0)
                return;
            string strSql = @"delete from UNIRegisterationExamTemp where  UsrIns="+User;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "UNIRegisterationExamTemp";
            objCopy.WriteToServer(_ExamTable);
            strSql = @"update dbo.UNIRegisterationExam set RegisterationExamDegree= dbo.UNIRegisterationExamTemp.RegisterationExamDegree ,
dbo.UNIRegisterationExam.RegisterationExamNote=dbo.UNIRegisterationExamTemp.RegisterationExamNote, 
dbo.UNIRegisterationExam.UsrUpd= dbo.UNIRegisterationExamTemp.UsrIns, dbo.UNIRegisterationExam.TimUpd= GETDATE()
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIRegisterationExamTemp ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisterationExamTemp.RegisterationExamRegisteration AND 
                  dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIRegisterationExamTemp.RegisterationExamExam 
   INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration =  dbo.UNIRegisteration.RegisterationID
  where UNIRegisterationExamTemp.UsrIns =" + User + " and (ISNULL(dbo.UNIRegisteration.RegisterationResult, 0) = 0) AND (ISNULL(dbo.UNIRegisteration.RegisterationPosted, 0) = 0) ";
  
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = @"insert into UNIRegisterationExam ( RegisterationExamRegisteration, RegisterationExamExam, RegisterationExamGrade, RegisterationExamDegree, RegisterationExamNote, RegisterationExamDate, RegisterationExamEvaluationEmployee, 
                  RegisterationExamEvaluationUsr, RegisterationExamStatus, UsrIns, TimIns
)";
            strSql += @"SELECT dbo.UNIRegisterationExamTemp.RegisterationExamRegisteration, dbo.UNIRegisterationExamTemp.RegisterationExamExam, dbo.UNIExam.ExamGrade, dbo.UNIRegisterationExamTemp.RegisterationExamDegree, 
                  dbo.UNIRegisterationExamTemp.RegisterationExamNote, dbo.UNIExam.ExamDate, 0 AS Expr1, dbo.UNIRegisterationExamTemp.UsrIns, 0 AS ExamStatus, dbo.UNIRegisterationExamTemp.UsrIns AS UsrIns1, GETDATE() AS Expr2
FROM     dbo.UNIRegisterationExamTemp INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExamTemp.RegisterationExamExam = dbo.UNIExam.ExamID LEFT OUTER JOIN
                  dbo.UNIRegisterationExam ON dbo.UNIRegisterationExamTemp.RegisterationExamRegisteration = dbo.UNIRegisterationExam.RegisterationExamRegisteration AND 
                  dbo.UNIRegisterationExamTemp.RegisterationExamExam = dbo.UNIRegisterationExam.RegisterationExamExam
   INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExamTemp.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID

  WHERE  (dbo.UNIRegisterationExamTemp.UsrIns = " + User+ @") and (ISNULL(dbo.UNIRegisteration.RegisterationResult, 0) = 0) AND (ISNULL(dbo.UNIRegisteration.RegisterationPosted, 0)=0) AND (dbo.UNIRegisterationExam.RegisterationExamID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            

        }
        #endregion
    }
}