using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class StudentResultDb
    {

        #region Constructor
        public StudentResultDb()
        {
        }
        public StudentResultDb(DataRow objDr)
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
        int _Faculty;
        public int Faculty { set => _Faculty = value; get => _Faculty; }
        int _Statement;
        public int Statement
        {
            set => _Statement = value;
            get => _Statement;
        }
        int _Student;
        public int Student
        {
            set => _Student = value;
            get => _Student;
        }
        string _StudentIDs;
        public string StudentIDs { set => _StudentIDs = value; }
        string _CGPA;
        public string CGPA
        {
            set => _CGPA = value;
            get => _CGPA;
        }
        double _CPoints;
        public double CPoints
        {
            set => _CPoints = value;
            get => _CPoints;
        }
        double _TotalCreditHour;
        public double TotalCreditHour
        {
            set => _TotalCreditHour = value;
            get => _TotalCreditHour;
        }
        double _EarnedHour;
        public double EarnedHour
        {
            set => _EarnedHour = value;
            get => _EarnedHour;
        }
        double _SCreditHour;
        public double SCreditHour
        {
            set => _SCreditHour = value;
            get => _SCreditHour;
        }
        double _SEarnedHour;
        public double SEarnedHour
        {
            set => _SEarnedHour = value;
            get => _SEarnedHour;
        }
        string _SGPA;
        public string SGPA
        {
            set => _SGPA = value;
            get => _SGPA;
        }
        double _SPoints;
        public double SPoints
        {
            set => _SPoints = value;
            get => _SPoints;
        }
        string _Note;
        public string Note
        {
            set => _Note = value;
            get => _Note;
        }
        int _Level;
        public int Level
        {
            set => _Level = value;
            get => _Level;
        }
        bool _Stopped;
        public bool Stopped
        {
            set => _Stopped = value;
            get => _Stopped;
        }
        string _StopReason;
        public string StopReason
        {
            set => _StopReason = value;
            get => _StopReason;
        }
        bool _Sent;
        public bool Sent { set => _Sent = value; get => _Sent; }
        DateTime _SentDate;
        public DateTime SentDate { set => _SentDate = value; get => _SentDate; }
        bool _OnlySelectedStudents;

        public bool OnlySelectedStudents { set => _OnlySelectedStudents=value; }
        int _LastStatemenetStatus = 0;
        public int LastStatementStatus { set => _LastStatemenetStatus = value; }
        #region Student
        int _StudentID;
        public int StudentID
        {
            set => _StudentID = value;
            get => _StudentID;
        }
        string _StudentCode;
        public string StudentCode
        {
            set => _StudentCode = value;
            get => _StudentCode;
        }
        string _StudentNameA;
        public string StudentNameA
        {
            set => _StudentNameA = value;
            get => _StudentNameA;
        }
        string _StudentNameE;
        public string StudentNameE
        {
            set => _StudentNameE = value;
            get => _StudentNameE;
        }
        string _StudentMobile;
        public string StudentMobile
        {
            set => _StudentMobile = value;
            get => _StudentMobile;
        }
        string _StudentEmail;
        public string StudentEmail
        {
            set => _StudentEmail = value;
            get => _StudentEmail;
        }
        string _IDs;
        public string IDs { set => _IDs = value; }
        #endregion
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
        int _StoppedStatus;
        public int StoppedStatus
        { set => _StoppedStatus = value; }
        int _NewLevelOrder;
        public int NewLevelOrder { set => _NewLevelOrder = value; get => _NewLevelOrder; }
        string _NewLevelDesc;
        public string NewLevelDesc { set => _NewLevelDesc = value; get => _NewLevelDesc; }
        int _OldLevelOrder;
        public int OldLevelOrder { set => _OldLevelOrder = value; get => _OldLevelOrder; }
        string _OldLevelDesc;
        public string OldLevelDesc { set => _OldLevelDesc = value; get => _OldLevelDesc; }

        DataTable _ResultTable;
        public DataTable ResultTable { set => _ResultTable = value; }
        DataTable _RegisterationTable;
        public DataTable RegisterationTable { set => _RegisterationTable = value; }

        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIStudentResult (ResultID,ResultStatement,ResultStudent,ResultCGPA,ResultCPoints,ResultTotalCreditHour,ResultEarnedHour,ResultSGPA,ResultSPoints,ResultNote,ResultLevel,ResultStopped,ResultStopReason,UsrIns,TimIns) values (" + Statement + "," + Student + ",'" + CGPA + "'," + CPoints + "," + TotalCreditHour + "," + EarnedHour + ",'" + SGPA + "'," + SPoints + ",'" + Note + "'," + Level + "," + (Stopped ? 1 : 0) + ",'" + StopReason + "'," + User + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIStudentResult set " + "ResultID=" + ID + "" +
           ",ResultStatement=" + Statement + "" +
           ",ResultStudent=" + Student + "" +
           ",ResultCGPA='" + CGPA + "'" +
           ",ResultCPoints=" + CPoints + "" +
           ",ResultTotalCreditHour=" + TotalCreditHour + "" +
           ",ResultEarnedHour=" + EarnedHour + "" +
           ",ResultSGPA='" + SGPA + "'" +
           ",ResultSPoints=" + SPoints + "" +
           ",ResultNote='" + Note + "'" +
           ",ResultLevel=" + Level + "" +
           ",ResultStopped=" + (Stopped ? 1 : 0) + "" +
           ",ResultStopReason='" + StopReason + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIStudentResult set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strStudent = @"SELECT StudentID AS ResultStudentID,StudentFaculty
 as ResultStudentFaculty, StudentCode AS ResultStudentCode, StudentNameA AS ResultStudentNameA, StudentNameE AS ResultStudentNameE, StudentMobile1 AS ResultStudentMobile, 
                  StudentEmail AS ResultStudentEmail
  FROM     dbo.UNIStudent 
 where StudentStatus =1 ";
                
                string strLastStatement = @"SELECT ResultStudent as MaxResultStudent, MAX(ResultID) AS MaxResultID
FROM     dbo.UNIStudentResult
GROUP BY ResultStudent";
                string Returned = @" select ResultID,ResultStatement,ResultStudent,ResultCGPA,ResultCPoints,ResultTotalCreditHour,ResultEarnedHour,dbo.UNIStudentResult.ResultSCreditHour, dbo.UNIStudentResult.ResultSEarnedHour
,ResultSGPA,ResultSPoints,ResultNote,ResultLevel,ResultStopped,ResultStopReason,ResultSent,StudentTable.*,StatementTable.*
 ,dbo.UNILevel.LevelOrder AS NewLevelOrder, dbo.UNILevel.LevelDesc AS NewLevelDesc
,PreviousLevelTable.LevelOrder AS OldLevelOrder, PreviousLevelTable.LevelDesc AS OldLevelDesc
  from UNIStudentResult  
  inner join (" + strStudent+ @") as StudentTable on UNIStudentResult.ResultStudent=StudentTable.ResultStudentID 
   left outer join ("+new ResultStatementDb().SearchStr + @") as StatementTable 
   on UNIStudentResult.ResultStatement =StatementTable.StatementID ";
                Returned += @" INNER JOIN
                  dbo.UNILevel ON
   StudentTable.ResultStudentFaculty=UNILevel.LevelFaculty and 
 dbo.UNIStudentResult.ResultEarnedHour >= dbo.UNILevel.LevelCreditHourFrom AND dbo.UNIStudentResult.ResultEarnedHour <= dbo.UNILevel.LevelCreditHourTo
  ";
                string strPreviousEarnedHour = @" dbo.UNIStudentResult.ResultEarnedHour - dbo.UNIStudentResult.ResultSEarnedHour ";
                Returned += @" INNER JOIN
                  dbo.UNILevel as PreviousLevelTable ON StudentTable.ResultStudentFaculty  = PreviousLevelTable.LevelFaculty and " + strPreviousEarnedHour+@" >= PreviousLevelTable.LevelCreditHourFrom AND "+strPreviousEarnedHour+@" <= PreviousLevelTable.LevelCreditHourTo
  ";
                if (_OnlySelectedStudents)
                {
                    Returned += @" inner join VUNISelectedStudent
  on UNIStudentResult.ResultStudent = VUNISelectedStudent.StudentID   ";
                }
                if (_Statement == 0)
                {
                    Returned += " inner join ("+strLastStatement+ @") as MaxResultTable 
   on UNIStudentResult.ResultID =MaxResultTable.MaxResultID ";
                }
                Returned += " where (ResultStudentFaculty="+_Faculty+") ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ResultID"] != null)
                int.TryParse(objDr["ResultID"].ToString(), out _ID);

            if (objDr.Table.Columns["ResultStatement"] != null)
                int.TryParse(objDr["ResultStatement"].ToString(), out _Statement);

            if (objDr.Table.Columns["ResultStudent"] != null)
                int.TryParse(objDr["ResultStudent"].ToString(), out _Student);

            if (objDr.Table.Columns["ResultCGPA"] != null)
                _CGPA = objDr["ResultCGPA"].ToString();

            if (objDr.Table.Columns["ResultCPoints"] != null)
                double.TryParse(objDr["ResultCPoints"].ToString(), out _CPoints);

            if (objDr.Table.Columns["ResultTotalCreditHour"] != null)
                double.TryParse(objDr["ResultTotalCreditHour"].ToString(), out _TotalCreditHour);

            if (objDr.Table.Columns["ResultEarnedHour"] != null)
                double.TryParse(objDr["ResultEarnedHour"].ToString(), out _EarnedHour);

            if (objDr.Table.Columns["ResultSCreditHour"] != null)
                double.TryParse(objDr["ResultSCreditHour"].ToString(), out _SCreditHour);

            if (objDr.Table.Columns["ResultSEarnedHour"] != null)
                double.TryParse(objDr["ResultSEarnedHour"].ToString(), out _SEarnedHour);


            if (objDr.Table.Columns["ResultSGPA"] != null)
                _SGPA = objDr["ResultSGPA"].ToString();

            if (objDr.Table.Columns["ResultSPoints"] != null)
                double.TryParse(objDr["ResultSPoints"].ToString(), out _SPoints);

            if (objDr.Table.Columns["ResultNote"] != null)
                _Note = objDr["ResultNote"].ToString();

            if (objDr.Table.Columns["ResultLevel"] != null)
                int.TryParse(objDr["ResultLevel"].ToString(), out _Level);

            if (objDr.Table.Columns["ResultStopped"] != null)
                bool.TryParse(objDr["ResultStopped"].ToString(), out _Stopped);

            if (objDr.Table.Columns["ResultStopReason"] != null)
                _StopReason = objDr["ResultStopReason"].ToString();
            if (objDr.Table.Columns["ResultStudentID"] != null)
                int.TryParse(objDr["ResultStudentID"].ToString(), out _StudentID);

            if (objDr.Table.Columns["ResultStudentCode"] != null)
                _StudentCode = objDr["ResultStudentCode"].ToString();

            if (objDr.Table.Columns["ResultStudentNameA"] != null)
                _StudentNameA = objDr["ResultStudentNameA"].ToString();

            if (objDr.Table.Columns["ResultStudentNameE"] != null)
                _StudentNameE = objDr["ResultStudentNameE"].ToString();

            if (objDr.Table.Columns["ResultStudentMobile"] != null)
                _StudentMobile = objDr["ResultStudentMobile"].ToString();

            if (objDr.Table.Columns["ResultStudentEmail"] != null)
                _StudentEmail = objDr["ResultStudentEmail"].ToString();

            if (objDr.Table.Columns["OldLevelOrder"] != null)
                int.TryParse(objDr["OldLevelOrder"].ToString(), out _OldLevelOrder);


            if (objDr.Table.Columns["ResultStudentFaculty"] != null)
                int.TryParse(objDr["ResultStudentFaculty"].ToString(), out _Faculty);

            if (objDr.Table.Columns["OldLevelDesc"] != null)
                _OldLevelDesc = objDr["OldLevelDesc"].ToString();

            if (objDr.Table.Columns["NewLevelOrder"] != null)
                int.TryParse(objDr["NewLevelOrder"].ToString(), out _NewLevelOrder);

            if (objDr.Table.Columns["NewLevelDesc"] != null)
                _NewLevelDesc = objDr["NewLevelDesc"].ToString();
            if(objDr.Table.Columns["ResultSent"] != null)
            {
                _Sent = DateTime.TryParse(objDr["ResultSent"].ToString(), out _SentDate);
            }
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
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr  ;
            //strSql += " and ResultStudent in (SELECT StudentID FROM dbo.VTempRegisterationUpdate)";
            if (_StudentCode != null && _StudentCode != "")
                strSql += " and (ResultStudentCode like '%"+_StudentCode+@"%' or ResultStudentNameA like '%"+_StudentCode+@"%'
 or ResultStudentNameE like '%"+_StudentCode+"%')";
            if(_Statement != 0)
            {
                strSql += " and dbo.UNIStudentResult.ResultStatement = "+_Statement;
            }
            if (_StoppedStatus == 1)
                strSql += " and dbo.UNIStudentResult.ResultStopped =1";
            if (_StoppedStatus == 2)
                strSql += " and dbo.UNIStudentResult.ResultStopped =0 ";
            if(_Level!=0)
            {
                if(_Statement>0)
                strSql += " and PreviousLevelTable.LevelOrder ="+_Level;
                else
                    strSql += " and UNILevel.LevelOrder =" + _Level;
            }
            if(_StudentIDs!= null&&_StudentIDs!="")
            {
                strSql += " and ResultStudent in("+_StudentIDs+")";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public string UpdateDegreeStr
        {
            get
            {
                _Faculty = SysData.FacultyID;
                string Returned = @" update   UNIRegisteration set MidtermDegree=isnull(MidtermTable.FinalDegree,MidtermDegree) 
,SemesterWorkDegree = isnull(SemesterworkTable.FinalDegree,SemesterWorkDegree) 
, PracticalDegree=isnull(PracticalTable.FinalDegree,PracticalDegree)
,OralDegree = isnull(OralTable.FinalDegree,OralDegree) 
,FinalDegree =isnull(FinalTable.FinalDegree,UNIRegisteration.FinalDegree)
,ClinicalDegree = isnull(ClinicalTable.FinalDegree,UNIRegisteration.ClinicalDegree)

    from UNIRegisteration  
  left outer join (SELECT  RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxSemester, sum(case when RegisterationStatus in (2,3,4) then 0 else 1 end) AS SemesterCount,MAX(isnull(GPA,0)) AS MaxGPA, SUM(CASE WHEN isnull(VerbalGPA,'') = 'F' and RegisterationStatus not in (2,3,4) THEN 1 ELSE 0 END) AS FailureCount
                  FROM      dbo.UNIRegisteration
             GROUP BY RegisterationStudent, RegisterationCourse) as MaxRegesterationTable
  on UNIRegisteration.RegisterationStudent = MaxRegesterationTable.RegisterationStudent AND UNIRegisteration.RegisterationCourse = MaxRegesterationTable.RegisterationCourse  
  left outer join (SELECT SemesterID, CourseID, CourseSemesterMaxBonus,CourseSemesterBonusForAll
   FROM     dbo.UNISemesterCourse) SemesterCourseTable
    ON dbo.UNIRegisteration.RegisterationCourse = SemesterCourseTable.CourseID AND dbo.UNIRegisteration.RegisterationSemester = SemesterCourseTable.SemesterID 
  inner join (SELECT StudentID AS RegisterationStudentID, StudentFaculty AS RegisterationStudentFaculty, StudentCode AS RegisterationStudentCode, StudentNameA AS RegisterationStudentName,StudentStatus as RegisterationStudentStatus,dbo.UNIStudent.StudentEmail as RegisterationStudentMail,isnull(UNIStudent.Gender,0) as RegisterationStudentGender
FROM     dbo.UNIStudent ) as StudentTable 
  on UNIRegisteration.RegisterationStudent = StudentTable.RegisterationStudentID  inner join ( select UNICourse.CourseID,UNICourse.CourseFaculty,UNICourse.CourseCode,UNICourse.CourseNameA,CourseNameE,CourseDesc,CourseCreditHour,CourseTotalDegree,CourseMidtermDegree,CourseSemesterWorkDegree,CoursePracticalDegree,CourseOralDegree,CourseFinalDegree,CourseClinicalDegree,CourseRecommendedGrade,CourseMaxBonus, CourseFinalMinDegree,CourseSemesterTable.* 
   from UNICourse  
 left outer join (SELECT dbo.UNISemesterCourse.SemesterID as CourseLastSemester, dbo.UNISemesterCourse.CourseID as SemesterCourseID, dbo.UNISemesterCourse.CourseSemesterMaxBonus as CourseSemesterMaxBonusC, dbo.UNISemesterCourse.CourseSemesterBonusForAll as MaxCourseSemesterBonusForAll
FROM     (SELECT MAX(SemesterID) AS MaxSemester
                  FROM      dbo.UNISemester) AS MaxSemesterTable INNER JOIN
                  dbo.UNISemesterCourse ON MaxSemesterTable.MaxSemester = dbo.UNISemesterCourse.SemesterID) as CourseSemesterTable
  on UNICourse.CourseID = CourseSemesterTable.SemesterCourseID  where (CourseFaculty="+_Faculty+@") ) as CourseTable 
 on UNIRegisteration.RegisterationCourse = CourseTable.CourseID  
  inner join ( select SemesterID,SemesterDesc,SemesterDateStart,SemesterDateEnd,SemesterType,SemesterMaxStatement 
  from UNISemester 
      LEFT OUTER JOIN
                      (SELECT StatementSemester, MAX(StatementID) AS SemesterMaxStatement
                       FROM      dbo.UNIResultStatement
                       GROUP BY StatementSemester) AS MaxStatementTable ON dbo.UNISemester.SemesterID = MaxStatementTable.StatementSemester ) as SemesterTable 
 on  UNIRegisteration.RegisterationSemester = SemesterTable.SemesterID  LEFT OUTER JOIN
                  dbo.UNIRegisterationEqual ON dbo.UNIRegisteration.RegisterationID = dbo.UNIRegisterationEqual.RegisterationID  left outer join (SELECT dbo.UNIRegisterationSource.RegisterationID AS MainRegisterationID, dbo.UNIRegisterationSource.SourceRegisterationID, dbo.UNIRegisteration.RegisterationDate AS SourceRegisterationDate, 
                  dbo.UNISemester.SemesterID AS SourceSemesterID, dbo.UNISemester.SemesterDesc AS SourceSemesterDesc, dbo.UNIRegisteration.MidtermDegree AS SourceMidtermDegree, 
                  dbo.UNIRegisteration.SemesterWorkDegree AS SourceSemesterWorkDegree, dbo.UNIRegisteration.PracticalDegree AS SourcePracticalDegree, dbo.UNIRegisteration.OralDegree AS SourceOralDegree, 
                  dbo.UNIRegisteration.FinalDegree AS SourceFinalDegree, dbo.UNIRegisteration.VerbalGPA AS SourceVerbalGPA, dbo.UNIRegisteration.GPA AS SourceGPA, dbo.UNIRegisteration.RegisterationStatus AS SourceStatus, 
                  dbo.UNIRegisteration.RegisterationNote AS SourceNote, dbo.UNIRegisteration.RegisterationResult AS SourceResult
FROM     dbo.UNISemester INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNISemester.SemesterID = dbo.UNIRegisteration.RegisterationSemester INNER JOIN
                  dbo.UNIRegisterationSource ON dbo.UNIRegisteration.RegisterationID = dbo.UNIRegisterationSource.SourceRegisterationID ) as SourceTable on UNIRegisteration.RegisterationID = SourceTable.MainRegisterationID  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 1)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 1)) MidtermTable  on dbo.UNIRegisteration.RegisterationID =MidtermTable.RegisterationExamRegisteration  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 2)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 2)) SemesterworkTable  on dbo.UNIRegisteration.RegisterationID =SemesterworkTable.RegisterationExamRegisteration  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 3)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 3)) OralTable  on dbo.UNIRegisteration.RegisterationID =OralTable.RegisterationExamRegisteration  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 4)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 4)) PracticalTable  on dbo.UNIRegisteration.RegisterationID =PracticalTable.RegisterationExamRegisteration  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 5)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 5)) FinalTable  on dbo.UNIRegisteration.RegisterationID =FinalTable.RegisterationExamRegisteration  left outer join (SELECT COUNT(dbo.UNIRegisterationExam.RegisterationExamID) AS ExamCount, dbo.UNIRegisterationExam.RegisterationExamRegisteration, 
                  SUM(dbo.UNIRegisterationExam.RegisterationExamDegree / dbo.UNIRegisterationExam.RegisterationExamGrade) / COUNT(dbo.UNIRegisterationExam.RegisterationExamID) * 
                  CASE WHEN UniExam.ExamType = 1 THEN dbo.UNIRegisteration.RegisterationFinalMidtermDegree WHEN UniExam.ExamType = 2 THEN dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree WHEN UniExam.ExamType = 3 THEN dbo.UNIRegisteration.RegisterationFinalPracticalDegree
                   WHEN UniExam.ExamType = 4 THEN dbo.UNIRegisteration.RegisterationFinalOralDegree WHEN UniExam.ExamType = 5 THEN dbo.UNIRegisteration.RegisterationFinalFinalDegree 
 WHEN UniExam.ExamType = 6 THEN dbo.UNIRegisteration.RegisterationFinalClinicalDegree
END AS FinalDegree,MaxStatusTable.RegisterationExamStatus as LastExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                  dbo.UNIExam ON dbo.UNIRegisterationExam.RegisterationExamExam = dbo.UNIExam.ExamID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIRegisterationExam.RegisterationExamRegisteration = dbo.UNIRegisteration.RegisterationID
 inner join (SELECT dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIRegisterationExam.RegisterationExamStatus
FROM     dbo.UNIRegisterationExam INNER JOIN
                      (SELECT UNIRegisterationExam_1.RegisterationExamRegisteration, MAX(UNIRegisterationExam_1.RegisterationExamID) AS MaxExamID, dbo.UNIExam.ExamType
                       FROM      dbo.UNIRegisterationExam AS UNIRegisterationExam_1 INNER JOIN
                                         dbo.UNIExam ON UNIRegisterationExam_1.RegisterationExamExam = dbo.UNIExam.ExamID
                       GROUP BY UNIRegisterationExam_1.RegisterationExamRegisteration, dbo.UNIExam.ExamType
                       HAVING  (dbo.UNIExam.ExamType = 6)) AS MaxEXamTable ON dbo.UNIRegisterationExam.RegisterationExamID = MaxEXamTable.MaxExamID) as MaxStatusTable 
 on dbo.UNIRegisteration.RegisterationID =  MaxStatusTable.RegisterationExamRegisteration 
GROUP BY dbo.UNIRegisterationExam.RegisterationExamRegisteration, dbo.UNIExam.ExamType, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, 
                  dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree, dbo.UNIRegisteration.RegisterationFinalClinicalDegree,MaxStatusTable.RegisterationExamStatus
  HAVING (dbo.UNIExam.ExamType = 6)) ClinicalTable  on dbo.UNIRegisteration.RegisterationID =ClinicalTable.RegisterationExamRegisteration ";
                return Returned;
            }
        }
        public void SaveReult()
        {
            if ((_RegisterationTable == null || _RegisterationTable.Rows.Count == 0) || (_ResultTable == null || _ResultTable.Rows.Count == 0))
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table UNIStudentRegisterationTemp");
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table UNIStudentResultTemp");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "UNIStudentRegisterationTemp";
            objCopy.WriteToServer(_RegisterationTable);
            objCopy.DestinationTableName = "UNIStudentResultTemp";
            objCopy.WriteToServer(_ResultTable);
            double dblTimIns = (DateTime.Now.ToOADate() - 2);
            string strSql = @"insert into UNIStudentResult (ResultStatement, ResultStudent, ResultCGPA, ResultCPoints, ResultTotalCreditHour, ResultEarnedHour,ResultSCreditHour, ResultSEarnedHour
, ResultSGPA, ResultSPoints, ResultNote, ResultLevel, ResultStopped, ResultStopReason, UsrIns, TimIns
)
 SELECT dbo.UNIStudentResultTemp.ResultStatement, dbo.UNIStudentResultTemp.ResultStudent, dbo.UNIStudentResultTemp.ResultCGPA, dbo.UNIStudentResultTemp.ResultCPoints, dbo.UNIStudentResultTemp.ResultTotalCreditHour, 
                  dbo.UNIStudentResultTemp.ResultEarnedHour, dbo.UNIStudentResultTemp.ResultSCreditHour, 
                  dbo.UNIStudentResultTemp.ResultSEarnedHour, dbo.UNIStudentResultTemp.ResultSGPA, dbo.UNIStudentResultTemp.ResultSPoints, dbo.UNIStudentResultTemp.ResultNote, dbo.UNIStudentResultTemp.ResultLevel, 
                  dbo.UNIStudentResultTemp.ResultStopped, dbo.UNIStudentResultTemp.ResultStopReason, " + User+@" AS UsrIns, "+dblTimIns+@" AS Expr1
FROM     dbo.UNIStudentResultTemp LEFT OUTER JOIN
                  dbo.UNIStudentResult ON dbo.UNIStudentResultTemp.ResultStatement = dbo.UNIStudentResult.ResultStatement AND dbo.UNIStudentResultTemp.ResultStudent = dbo.UNIStudentResult.ResultStudent
WHERE  (dbo.UNIStudentResult.ResultID IS NULL) ";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"update dbo.UNIRegisteration set  RegisterationResult=dbo.UNIStudentResult.ResultID
,VerbalGPA= dbo.UNIStudentRegisterationTemp.VerbalGPA,GPA= dbo.UNIStudentRegisterationTemp.GPA ,Bonus=dbo.UNIStudentRegisterationTemp.Bonus 

 FROM     dbo.UNIStudentRegisterationTemp INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIStudentRegisterationTemp.RegisterationID = dbo.UNIRegisteration.RegisterationID INNER JOIN
                  dbo.UNIStudentResult ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudentResult.ResultStudent INNER JOIN
                  dbo.UNISemester ON dbo.UNIRegisteration.RegisterationSemester <= dbo.UNISemester.SemesterID INNER JOIN
                  dbo.UNIResultStatement ON dbo.UNIStudentResult.ResultStatement = dbo.UNIResultStatement.StatementID AND dbo.UNISemester.SemesterID = dbo.UNIResultStatement.StatementSemester
WHERE  (dbo.UNIRegisteration.RegisterationResult = 0) AND (dbo.UNIStudentResult.TimIns = " + dblTimIns+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            if(_Statement== 0)
            {
                _Statement = 2;
            }
            if (_Faculty == 0)
                _Faculty = SysData.FacultyID;

            strSql = UpdateDegreeStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = @"insert into UNIRegisterationResult (RegisterationID, RegisterationResult, RegisterationStatus, MidtermDegree, SemesterWorkDegree, PracticalDegree, OralDegree, FinalDegree,ClinicalDegree, Bonus, RegisterationCourseFinalDegree, VerbalGPA, GPA, RegisterationNote, 
                  RegisterationFinalTotalDegree, RegisterationFinalMidtermDegree, RegisterationFinalSemesterWorkDegree, RegisterationFinalPracticalDegree, RegisterationFinalOralDegree, RegisterationFinalFinalDegree
) ";
            strSql += @"SELECT dbo.UNIRegisteration.RegisterationID, dbo.UNIStudentResult.ResultID, dbo.UNIRegisteration.RegisterationStatus, dbo.UNIRegisteration.MidtermDegree, dbo.UNIRegisteration.SemesterWorkDegree, 
                  dbo.UNIRegisteration.PracticalDegree, dbo.UNIRegisteration.OralDegree, dbo.UNIRegisteration.FinalDegree,dbo.UNIRegisteration.ClinicalDegree, dbo.UNIRegisteration.Bonus, dbo.UNIRegisteration.RegisterationCourseFinalDegree, dbo.UNIRegisteration.VerbalGPA, 
                  dbo.UNIRegisteration.GPA, dbo.UNIRegisteration.RegisterationNote, dbo.UNIRegisteration.RegisterationFinalTotalDegree, dbo.UNIRegisteration.RegisterationFinalMidtermDegree, 
                  dbo.UNIRegisteration.RegisterationFinalSemesterWorkDegree, dbo.UNIRegisteration.RegisterationFinalPracticalDegree, dbo.UNIRegisteration.RegisterationFinalOralDegree, dbo.UNIRegisteration.RegisterationFinalFinalDegree
FROM     dbo.UNIRegisteration INNER JOIN
                  dbo.UNICourse ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICourse.CourseID INNER JOIN
                  dbo.UNIStudentResult ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudentResult.ResultStudent 
  AND dbo.UNIRegisteration.RegisterationResult = dbo.UNIStudentResult.ResultID  
INNER JOIN
                  dbo.UNIStudentRegisterationTemp ON dbo.UNIRegisteration.RegisterationID = dbo.UNIStudentRegisterationTemp.RegisterationID
WHERE  (dbo.UNIStudentResult.ResultStatement = " + Statement+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Stop()
        {
            if (_IDs == null || _IDs == "")
                return;
            int intStoped = _Stopped ? 1 : 0;
            string strReason = _Stopped ? _StopReason : "";
            if (strReason == null)
                strReason = "";
            string strSql = @" update dbo.UNIStudentResult set ResultStopped="+intStoped+@", ResultStopReason='"+strReason+@"'
WHERE(ResultID IN("+_IDs+ ")) and (ResultStopped<>"+intStoped+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Send()
        {
            if (_IDs == null || _IDs == "")
                return;
            string  strSentDate = _Sent ?( DateTime.Now.ToOADate()-2).ToString() : "NULL";
             
            string strSql = @" update dbo.UNIStudentResult set ResultSent=" + strSentDate + @" 
WHERE(ResultID IN(" + _IDs + ")) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void DeleteResultCol()
        {
            if (_IDs == null || _IDs == "")
                return;
            string strSql = "delete from UNIStudentResult where UNIStudentResult.ResultID in ("+_IDs+")";

             strSql += @" update UNIRegisteration set RegisterationResult =0
  WHERE(RegisterationResult IN(" + _IDs + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}