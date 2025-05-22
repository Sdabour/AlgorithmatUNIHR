using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    /// <summary>
    /// this is a prsentaion for the composition of student course and semester 
    /// Regiseteration status Normal,Approved=1,W=2,IC=3,Canceled=4,DS=5,DN=6,WF=7,P=8,IncPre=9
    /// </summary>
    public class RegisterationDb
    {
        //RegisterationID, RegisterationStudent, RegisterationDate, RegisterationSemester, RegisterationCourse, RegisterationGrade, RegisterationIteration, MidtermDegree, SemesterWorkDegree, PracticalDegree, OralDegree, FinalDegree

        #region Constructor
        public RegisterationDb()
        {
        }
        public RegisterationDb(DataRow objDr)
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
        int _Student;
        public int Student
        {
            set => _Student = value;
            get => _Student;
        }
        int _StudentGender;
        public int StudentGender
        {
            set => _StudentGender = value;
            get => _StudentGender;
        }
        string _StudentCode;
        public string StudentCode
        {
            set => _StudentCode = value;
            get => _StudentCode; }
        
        string _StudentMail;
        public string StudentMail
        { get => _StudentMail; }
        string _StudentName;
        public string StudentName
        { get => _StudentName; }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        int _Semester;
        public int Semester
        {
            set => _Semester = value;
            get => _Semester;
        }
        int _Course;
        public int Course
        {
            set => _Course = value;
            get => _Course;
        }
        string _CourseCode;
        public string CourseCode { set => _CourseCode = value; }
        int _EqualID;
        public int EqualID{ get => _EqualID; set => _EqualID = value; }
        string _EqualNameA;
        public string EqualNameA { set => _EqualNameA = value; get => _EqualNameA; }
        int _UniverstyID;
        public int UniverstyID { set => _UniverstyID = value; get => _UniverstyID; }
        string _EqualNameE;
        public string EqualNameE { set => _EqualNameE = value; get => _EqualNameE; }
        string _CourseIDs;
        public string CourseIDs
        { set => _CourseIDs = value; }
        int _Level;
        public int Level
        {
            set => _Level = value;
            get => _Level;
        }
        int _CourseLevel;
        public int CourseLevel
        {
            set => _CourseLevel = value;
            get => _CourseLevel;
        }
        int _Iteration;
        public int Iteration
        {
            set => _Iteration = value;
            get => _Iteration;
        }
       protected double _MidtermDegree;
        public double MidtermDegree
        {
            set => _MidtermDegree = value;
            get => _MidtermDegree;
        }
        protected double _SemesterWorkDegree;
        public double SemesterWorkDegree
        {
            set => _SemesterWorkDegree = value;
            get => _SemesterWorkDegree;
        }
        protected double _PracticalDegree;
        public double PracticalDegree
        {
            set => _PracticalDegree = value;
            get => _PracticalDegree;
        }
        protected double _OralDegree;
        public double OralDegree
        {
            set => _OralDegree = value;
            get => _OralDegree;
        }
        protected double _FinalDegree;
        public double FinalDegree
        {
            set => _FinalDegree = value;
            get => _FinalDegree;
        }
        protected double _FinalMinDegree;
        public double FinalMinDegree
        {
            set => _FinalMinDegree = value;
            get => _FinalMinDegree;
        }
        protected double _Bonus;
        public double Bonus
        { set => _Bonus = value; get => _Bonus; }
        int _SemesterCount;
        public int SemesterCount { set => _SemesterCount = value; get => _SemesterCount; }

        int _FailureCount;
        public int FailureCount { set => _FailureCount = value; get => _FailureCount; }
        double _MaxGPA;
        public double MaxGPA { set => _MaxGPA = value; get => _MaxGPA; }
        

        protected int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        string _StudentIDs;
        public string StudentIDs
        { set => _StudentIDs = value; }
        protected int _CourseFinalDegree;
        public int CourseFinalDegree
        { get => _CourseFinalDegree; }
        protected string _Note;
        public string Note
        { set => _Note = value;
            get => _Note;
        }
        bool _Posted;
        public bool Posted
        { set => _Posted = value; get => _Posted; }
        protected int _ResultID;
        public int ResultID { set => _ResultID = value; get => _ResultID; }
        int _PostStatus;
        public int PostStatus { set => _PostStatus = value; }
        int _ResultStatus;
        public int ResultStatus { set => _ResultStatus = value; }
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
        //string _StudentIDs;

        bool _OnlyMaxRegisteration = false;
        public bool OnlyMaxRegisteration
        {
            set => _OnlyMaxRegisteration = value;
        }
        string _IDs;
        public string IDs
        { set => _IDs = value; }
        protected string _ResultIDs;
        public string ResultIDs
        {
            set => _ResultIDs = value;
        }
        #region Source Properties
        int _MainRegisterationID;
        public int MainRegisterationID
        {
            set => _MainRegisterationID = value;
            get => _MainRegisterationID;
        }
        int _SourceRegisterationID;
        public int SourceRegisterationID
        {
            set => _SourceRegisterationID = value;
            get => _SourceRegisterationID;
        }
        DateTime _SourceRegisterationDate;
        public DateTime SourceRegisterationDate
        {
            set => _SourceRegisterationDate = value;
            get => _SourceRegisterationDate;
        }
        int _SourceSemesterID;
        public int SourceSemesterID
        {
            set => _SourceSemesterID = value;
            get => _SourceSemesterID;
        }
        string _SourceSemesterDesc;
        public string SourceSemesterDesc
        {
            set => _SourceSemesterDesc = value;
            get => _SourceSemesterDesc;
        }
        double _SourceMidtermDegree;
        public double SourceMidtermDegree
        {
            set => _SourceMidtermDegree = value;
            get => _SourceMidtermDegree;
        }
        double _SourceSemesterWorkDegree;
        public double SourceSemesterWorkDegree
        {
            set => _SourceSemesterWorkDegree = value;
            get => _SourceSemesterWorkDegree;
        }
        double _SourcePracticalDegree;
        public double SourcePracticalDegree
        {
            set => _SourcePracticalDegree = value;
            get => _SourcePracticalDegree;
        }
        double _SourceOralDegree;
        public double SourceOralDegree
        {
            set => _SourceOralDegree = value;
            get => _SourceOralDegree;
        }
        double _SourceFinalDegree;
        public double SourceFinalDegree
        {
            set => _SourceFinalDegree = value;
            get => _SourceFinalDegree;
        }
        string _SourceVerbalGPA;
        public string SourceVerbalGPA
        {
            set => _SourceVerbalGPA = value;
            get => _SourceVerbalGPA;
        }
        double _SourceGPA;
        public double SourceGPA
        {
            set => _SourceGPA = value;
            get => _SourceGPA;
        }
        int _SourceStatus;
        public int SourceStatus
        {
            set => _SourceStatus = value;
            get => _SourceStatus;
        }
        string _SourceNote;
        public string SourceNote
        {
            set => _SourceNote = value;
            get => _SourceNote;
        }
        int _SourceResult;
        public int SourceResult
        {
            set => _SourceResult = value;
            get => _SourceResult;
        }

       protected string _VerbalGPA;
        public string VerbalGPA
        {
            set => _VerbalGPA = value;
            get => _VerbalGPA;
        }
        protected double _GPA;
        public double GPA
        {
            set => _GPA = value;
            get => _GPA;
        }


        protected double _FinalTotalDegree;
        public double FinalTotalDegree
        {
            set => _FinalTotalDegree = value;
            get => _FinalTotalDegree;
        }
        protected double _FinalMidtermDegree;
        public double FinalMidtermDegree
        {
            set => _FinalMidtermDegree = value;
            get => _FinalMidtermDegree;
        }
        protected double _FinalSemesterWorkDegree;
        public double FinalSemesterWorkDegree
        {
            set => _FinalSemesterWorkDegree = value;
            get => _FinalSemesterWorkDegree;
        }
        protected double _FinalPracticalDegree;
        public double FinalPracticalDegree
        {
            set => _FinalPracticalDegree = value;
            get => _FinalPracticalDegree;
        }
        protected double _FinalOralDegree;
        public double FinalOralDegree
        {
            set => _FinalOralDegree = value;
            get => _FinalOralDegree;
        }
        protected double _FinalFinalDegree;
        public double FinalFinalDegree
        {
            set => _FinalFinalDegree = value;
            get => _FinalFinalDegree;
        }
        protected double _ClinicalDegree;
        public double ClinicalDegree
        { set => _ClinicalDegree = value;
            get => _ClinicalDegree;
        }
        protected double _FinalClinicalDegree;
        public double FinalClinicalDegree
        {
            set => _FinalClinicalDegree = value;
            get => _FinalClinicalDegree;
        }
        string _SeatNo;
        public string SeatNo { set => _SeatNo = value; get => _SeatNo; }
        int _MTStatus;
        public int MTStatus
        {
            set => _MTStatus = value;
            get => _MTStatus;
        }
        int _SWStatus;
        public int SWStatus
        {
            set => _SWStatus = value;
            get => _SWStatus;
        }
        int _PStatus;
        public int PStatus
        {
            set => _PStatus = value;
            get => _PStatus;
        }
        int _OStatus;
        public int OStatus
        {
            set => _OStatus = value;
            get => _OStatus;
        }
        int _FStatus;
        public int FStatus
        {
            set => _FStatus = value;
            get => _FStatus;
        }
        int _CStatus;
        public int CStatus
        {
            set => _CStatus = value;
            get => _CStatus;
        }
         int _PrequisitCourseCount;
        public int PrequisitCourseCount { set => _PrequisitCourseCount = value; get => _PrequisitCourseCount; }
        int _PrequisitPassedCourseCount;
        public int PrequisitPassedCourseCount { set => _PrequisitPassedCourseCount = value; get => _PrequisitPassedCourseCount; }
        bool _OnlyNonCompleted;
        public bool OnlyNonCompleted { set => _OnlyNonCompleted = value; }
        bool _OnlySelected;
        public bool OnlySelected
        {
            set => _OnlySelected = value;
        }
        bool _IncludeCanceledStudent;
        public bool IncludeCanceledStudent
        { set => _IncludeCanceledStudent = value; }
        #endregion
        DataTable _RegisterationTable;
        public DataTable RegisterationTable { set => _RegisterationTable = value; }
        public string AddStr
        {
            get
            {
                //string Returned = " insert into UNIRegisteration (RegisterationStudent,RegisterationDate,RegisterationSemester,RegisterationCourse,RegisterationGrade,RegisterationIteration,MidtermDegree,SemesterWorkDegree,PracticalDegree,OralDegree,FinalDegree,RegisterationFinalTotalDegree,UsrIns,TimIns)" +
                // @" values (" + Student + "," + (Date.ToOADate() - 2).ToString() + "," + Semester + "," + Course + "," + Level + "," + Iteration + "," + MidtermDegree + "," + SemesterWorkDegree + "," + PracticalDegree + "," + OralDegree + "," + FinalDegree + "," + _CourseFinalDegree + "," + User + ",GetDate() ) ";
                string strOldReg = @"SELECT RegisterationID AS OldRegisterationID, RegisterationStudent, RegisterationCourse
FROM     dbo.UNIRegisteration
WHERE  (ISNULL(VerbalGPA, '') <> 'F') AND (NOT (RegisterationStatus IN (2, 3, 5))) AND (RegisterationCourse = "+ _Course + ") and (RegisterationStudent="+_Student+")";
                string Returned = " insert into UNIRegisteration (RegisterationStudent,RegisterationDate,RegisterationSemester,RegisterationCourse,RegisterationGrade,RegisterationIteration,MidtermDegree,SemesterWorkDegree,PracticalDegree,OralDegree,FinalDegree,RegisterationFinalTotalDegree,UsrIns,TimIns)" +
                    @" select " + Student + " as Student," + (Date.ToOADate() - 2).ToString() + " as RegDate," + Semester + " as RegSemester," + Course + " as RegCourse," + Level + " as RegLevel," + Iteration + " as RegIteration," + MidtermDegree + " as RegMidtermDegree," + SemesterWorkDegree + " as RegSemesterWorkDegree," + PracticalDegree + " as RegPracticalDegree," + OralDegree + " as RegOralDegree," + FinalDegree +" as REGFinalDegree ,"+_CourseFinalDegree+ " as REGCourseFinalDegree," + User + " as UsrIns,GetDate() as TimIns " +
                    @" from UNICourse
      where UNICourse.CourseID = " + _Course + " and not exists ("+strOldReg+") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIRegisteration set " + "RegisterationID=" + ID + "" +
           ",MidtermDegree=" + MidtermDegree + "" +
           ",SemesterWorkDegree=" + SemesterWorkDegree + "" +
           ",PracticalDegree=" + PracticalDegree + "" +
           ",OralDegree=" + OralDegree + "" +
           ",FinalDegree=" + FinalDegree + ",Bonus="+Bonus +
           ",UsrUpd=" + User + @",TimUpd=GetDate()  where RegisterationID=" + ID+ " and isnull(RegisterationResult,0)=0 and  isnull(RegisterationPosted,0)=0";
                return Returned;
            }
        }
        public string EditDegreeStr
        {
            get
            {
                string strMaxSemester = @"SELECT MAX(SemesterID) AS MaxSemester
FROM     dbo.UNISemester ";
                string Returned = " update UNIRegisteration set  MidtermDegree=case when " + MidtermDegree + "=0 then MidtermDegree else "+ MidtermDegree +" end " +
           ",SemesterWorkDegree=case when " + SemesterWorkDegree + "=0 then SemesterWorkDegree else "+SemesterWorkDegree +
           " end,PracticalDegree=case when " + PracticalDegree + "=0 then PracticalDegree else " + PracticalDegree + " end "+
           ",OralDegree=case when " + OralDegree + "=0 then OralDegree else "+ OralDegree +" end " +
           ",FinalDegree=case when " + FinalDegree + " = 0 then FinalDegree else "+ FinalDegree + " end,Bonus=case when " + Bonus +
           "=0 then Bonus else "+ Bonus + " end" +
          " , ClinicalDegree =case when " + ClinicalDegree + " = 0 then ClinicalDegree else " + ClinicalDegree + " end "+
           ",RegisterationNote='" + _Note +"'"+
           ",UsrUpd=" + User + @",TimUpd=GetDate() 
 from dbo.UNIRegisteration left outer JOIN
                      ("+strMaxSemester+@") AS SemesterTable ON dbo.UNIRegisteration.RegisterationSemester = SemesterTable.MaxSemester where RegisterationID=" + ID + " and isnull(RegisterationResult,0)=0 and isnull(RegisterationPosted,0)=0";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = @" delete  from dbo.UNIRegisteration
WHERE(RegisterationPosted = 0) AND(RegisterationResult = 0) AND(RegisterationID = "+_ID+")";
                return Returned;
            }
        }
        public  string BaseSearchStr
        {
            get
            {

                string strSource = @"SELECT dbo.UNIRegisterationSource.RegisterationID AS MainRegisterationID, dbo.UNIRegisterationSource.SourceRegisterationID, dbo.UNIRegisteration.RegisterationDate AS SourceRegisterationDate, 
                  dbo.UNISemester.SemesterID AS SourceSemesterID, dbo.UNISemester.SemesterDesc AS SourceSemesterDesc, dbo.UNIRegisteration.MidtermDegree AS SourceMidtermDegree, 
                  dbo.UNIRegisteration.SemesterWorkDegree AS SourceSemesterWorkDegree, dbo.UNIRegisteration.PracticalDegree AS SourcePracticalDegree, dbo.UNIRegisteration.OralDegree AS SourceOralDegree, 
                  dbo.UNIRegisteration.FinalDegree AS SourceFinalDegree, dbo.UNIRegisteration.VerbalGPA AS SourceVerbalGPA, dbo.UNIRegisteration.GPA AS SourceGPA, dbo.UNIRegisteration.RegisterationStatus AS SourceStatus, 
                  dbo.UNIRegisteration.RegisterationNote AS SourceNote, dbo.UNIRegisteration.RegisterationResult AS SourceResult
FROM     dbo.UNISemester INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNISemester.SemesterID = dbo.UNIRegisteration.RegisterationSemester INNER JOIN
                  dbo.UNIRegisterationSource ON dbo.UNIRegisteration.RegisterationID = dbo.UNIRegisterationSource.SourceRegisterationID ";
                //                string strPreRegisteration = @"SELECT RegisterationStudent, RegisterationCourse, MAX(GPA) AS MaxGPA, SUM(CASE WHEN VerbalGPA = 'F' THEN 1 ELSE 0 END) AS FailureCount
                //FROM dbo.UNIRegisteration
                //WHERE(RegisterationPosted = 1) OR
                //                (ISNULL(RegisterationResult, 0) > 0)
                //GROUP BY RegisterationStudent, RegisterationCourse";
                string strIgnoredStatus = "2,3,4";
                string strMaxRegesteration = @"SELECT  RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxSemester, sum(case when RegisterationStatus in (" + strIgnoredStatus + @") then 0 else 1 end) AS SemesterCount,MAX(isnull(GPA,0)) AS MaxGPA, SUM(CASE WHEN isnull(VerbalGPA,'') = 'F' and RegisterationStatus not in (" + strIgnoredStatus + @") THEN 1 ELSE 0 END) AS FailureCount
                  FROM      dbo.UNIRegisteration
             GROUP BY RegisterationStudent, RegisterationCourse";
                string strMaxStudentCourseRegistrationStr = @"SELECT MAX(RegisterationID) AS MaxRegisterationID, RegisterationStudent, RegisterationCourse
FROM     dbo.UNIRegisteration
GROUP BY RegisterationStudent, RegisterationCourse ";
                string strSemestrCourse = @"SELECT SemesterID, CourseID, CourseSemesterMaxBonus,CourseSemesterBonusForAll
   FROM     dbo.UNISemesterCourse";
                string strMaxResult = @"SELECT dbo.UNIStudent.StudentID AS MaxResultStudent, UNIStudentResult_1.ResultCGPA AS MaxResultCGPA, UNIStudentResult_1.ResultCPoints AS MaxResultCPoints, 
                  UNIStudentResult_1.ResultTotalCreditHour AS MaxResultTotalCreditHour, UNIStudentResult_1.ResultEarnedHour AS MaxResultEarnedHour, UNIStudentResult_1.ResultSGPA AS MaxResultSGPA, 
                  UNIStudentResult_1.ResultSPoints AS MaxResultSPoints, UNIStudentResult_1.ResultNote AS MaxResultNote
FROM     (SELECT ResultStudent, MAX(ResultID) AS MaxResultID
                  FROM      dbo.UNIStudentResult
                  GROUP BY ResultStudent) AS MaxResultTable LEFT OUTER JOIN
                  dbo.UNIStudentResult AS UNIStudentResult_1 ON MaxResultTable.MaxResultID = UNIStudentResult_1.ResultID RIGHT OUTER JOIN
                  dbo.UNIStudent ON MaxResultTable.ResultStudent = dbo.UNIStudent.StudentID";
                string strStudent = @"SELECT StudentID AS RegisterationStudentID, StudentFaculty AS RegisterationStudentFaculty, StudentCode AS RegisterationStudentCode, StudentNameA AS RegisterationStudentName,StudentStatus as RegisterationStudentStatus,dbo.UNIStudent.StudentEmail as RegisterationStudentMail,isnull(UNIStudent.Gender,0) as RegisterationStudentGender
FROM     dbo.UNIStudent ";
                
                if(_Level>0)
                {
                    strStudent += " left outer join (" + strMaxResult + @") as MaxResultTable  
  on  UNIStudent.StudentID = MaxResultTable.MaxResultStudent
   INNER JOIN
                  dbo.UNILevel ON UNILevel.LevelFaculty = UNIStudent.StudentFaculty and ISNULL(MaxResultTable.MaxResultEarnedHour, 0) >= dbo.UNILevel.LevelCreditHourFrom AND ISNULL(MaxResultTable.MaxResultEarnedHour, 0) <= dbo.UNILevel.LevelCreditHourTo  ";
                    strStudent += " where  isnull(dbo.UNILevel.LevelOrder,1) ="+_Level;
                }
                string strResult = @"SELECT dbo.UNIRegisteration.RegisterationID
FROM     dbo.UNIRegisteration INNER JOIN
                  dbo.UNIStudentResult ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudentResult.ResultStudent INNER JOIN
                  dbo.UNISemester ON dbo.UNIRegisteration.RegisterationSemester = dbo.UNISemester.SemesterID INNER JOIN
                  dbo.UNIResultStatement ON dbo.UNIStudentResult.ResultStatement = dbo.UNIResultStatement.StatementID AND dbo.UNISemester.SemesterID <= dbo.UNIResultStatement.StatementSemester
WHERE  (dbo.UNIRegisteration.RegisterationResult > 0) AND (dbo.UNIStudentResult.ResultID IN (" + (_ResultIDs == null ? "" : _ResultIDs) + "))";
                string strUNI = @"SELECT UniversityID AS EQUniID, UniversityNameA AS EQUniNameA, UniversityNameE AS EQUniNameE
FROM     dbo.COMMONUniversity";
                //MaxRegisterationTable join
                ////AND 
                //UNIRegisteration.RegisterationSemester = MaxRegesterationTable.MaxSemester
                string Returned = @" select UNIRegisteration.RegisterationID,UNIRegisteration.RegisterationStudent,RegisterationDate,UNIRegisteration.RegisterationSemester,UNIRegisteration.RegisterationCourse,RegisterationGrade,RegisterationIteration
";
                Returned += @",isnull(MidtermTable.FinalDegree,MidtermDegree) as MidtermDegree,isnull(MidtermTable.LastExamStatus,0) as MTStatus
,isnull(SemesterworkTable.FinalDegree,SemesterWorkDegree) as SemesterWorkDegree,isnull(SemesterworkTable.LastExamStatus,0) as SWStatus
,isnull(PracticalTable.FinalDegree,PracticalDegree) PracticalDegree,isnull(PracticalTable.LastExamStatus,0) as PStatus
,isnull(OralTable.FinalDegree,OralDegree) as OralDegree,isnull(OralTable.LastExamStatus,0) as OStatus
,isnull(FinalTable.FinalDegree,UNIRegisteration.FinalDegree) as FinalDegree,isnull(FinalTable.LastExamStatus,0) as FStatus
,isnull(ClinicalTable.FinalDegree,UNIRegisteration.ClinicalDegree) as ClinicalDegree,isnull(ClinicalTable.LastExamStatus,0) as CStatus
,Bonus,RegisterationCourseFinalDegree,RegisterationFinalTotalDegree,RegisterationStatus,RegisterationNote,RegisterationResult,RegisterationFinalMinDegree,RegisterationSeatNo,RegisterationPosted,MaxRegesterationTable.SemesterCount,MaxRegesterationTable.MaxGPA,MaxRegesterationTable.FailureCount,CourseTable.*,SemesterTable.*,SemesterCourseTable.CourseSemesterMaxBonus,SemesterCourseTable.CourseSemesterBonusForAll,StudentTable.RegisterationStudentCode,StudentTable.RegisterationStudentName,StudentTable.RegisterationStudentFaculty,StudentTable.RegisterationStudentMail,StudentTable.RegisterationStudentGender,
 dbo.UNIRegisterationEqual.RegisterationID AS EqualRegisterationID, dbo.UNIRegisterationEqual.RegisterationEqualCourseNameA AS EqualRegisterationNameA, 
                  dbo.UNIRegisterationEqual.RegisterationEqualCourseNameE AS EqualRegisterationNameE";
                Returned += @",PrequisitTable.PrequisitCourseCount,PrequisitTable.PrequisitPassedCourseCount";
    Returned+=@" from UNIRegisteration  
  left outer join (" + strMaxRegesteration + @") as MaxRegesterationTable
  on UNIRegisteration.RegisterationStudent = MaxRegesterationTable.RegisterationStudent AND UNIRegisteration.RegisterationCourse = MaxRegesterationTable.RegisterationCourse  
  left outer join (" + strSemestrCourse + @") SemesterCourseTable
    ON dbo.UNIRegisteration.RegisterationCourse = SemesterCourseTable.CourseID AND dbo.UNIRegisteration.RegisterationSemester = SemesterCourseTable.SemesterID 
  inner join (" + strStudent + @") as StudentTable 
  on UNIRegisteration.RegisterationStudent = StudentTable.RegisterationStudentID ";
                //              Returned += @"inner join (" + new StudentDb().SearchStr + @") as StudentTable 
                //on UNIRegisteration.RegisterationStudent = StudentTable.StudentID"; 
                Returned += @" inner join (" + new CourseDb() { Faculty=Faculty}.SearchStr + @") as CourseTable 
 on UNIRegisteration.RegisterationCourse = CourseTable.CourseID  
  inner join (" + new SemesterDb().SearchStr + @") as SemesterTable 
 on  UNIRegisteration.RegisterationSemester = SemesterTable.SemesterID ";
                Returned += @" LEFT OUTER JOIN
                  dbo.UNIRegisterationEqual ON dbo.UNIRegisteration.RegisterationID = dbo.UNIRegisterationEqual.RegisterationID ";
                Returned += @" left outer join (" + strSource + @") as SourceTable on UNIRegisteration.RegisterationID = SourceTable.MainRegisterationID ";
                Returned += " left outer join ("+RegisterationPrequisitSearchStr+ @") as PrequisitTable on UNIRegisteration.RegisterationID = PrequisitTable.RegisterationID ";
                //Midterm=1,SemesterWork=2,Oral=3,Practical=4,Final=5
                #region Midterm=1,SemesterWork=2,Oral=3,Practical=4,Final=5,Clinical 6
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(1) + @") MidtermTable  on dbo.UNIRegisteration.RegisterationID =MidtermTable.RegisterationExamRegisteration ";
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(2) + @") SemesterworkTable  on dbo.UNIRegisteration.RegisterationID =SemesterworkTable.RegisterationExamRegisteration ";
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(3) + @") OralTable  on dbo.UNIRegisteration.RegisterationID =OralTable.RegisterationExamRegisteration ";
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(4) + @") PracticalTable  on dbo.UNIRegisteration.RegisterationID =PracticalTable.RegisterationExamRegisteration ";
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(5) + @") FinalTable  on dbo.UNIRegisteration.RegisterationID =FinalTable.RegisterationExamRegisteration ";
                Returned += " left outer join (" + RegisterationExamDb.GetExamResultByTypeStr(6) + @") ClinicalTable  on dbo.UNIRegisteration.RegisterationID =ClinicalTable.RegisterationExamRegisteration ";
                #endregion
                ////
                if (_OnlyMaxRegisteration)
                    Returned += " inner join (" + strMaxStudentCourseRegistrationStr + @") as MaxTable on UNIRegisteration.RegisterationID = MaxTable.MaxRegisterationID ";

              
                return Returned;
            }
        }
        public virtual string SearchStr
        {
            get
            {


                string Returned = BaseSearchStr;
                if(_Level >0)
                {
                    //string strLevel
                }
                if(_OnlySelected)
                {
                    Returned += " inner join VUNISelectedRegisteration on UNIRegisteration.RegisterationID = VUNISelectedRegisteration.RegisterationID";
                }
                if ( _ResultIDs != null && _ResultIDs != "")
                {

                    //Returned += " inner join ("+_ResultIDs+ @") as ResultRegiterationTable on UNIRegisteration.RegisterationID =ResultRegiterationTable.RegisterationID ";
                    Returned += @" INNER JOIN
                      (SELECT ResultID, ResultStudent
                       FROM      dbo.UNIStudentResult
                       WHERE(ResultID IN(" + _ResultIDs + @"))) AS derivedtbl_1 ON dbo.UNIRegisteration.RegisterationStudent = derivedtbl_1.ResultStudent AND dbo.UNIRegisteration.RegisterationResult > 0 AND
                  dbo.UNIRegisteration.RegisterationResult <= derivedtbl_1.ResultID";
                }
                Returned += " where (StudentTable.RegisterationStudentFaculty=" + _Faculty+")";
                if (!_IncludeCanceledStudent)
                    Returned += " and StudentTable.RegisterationStudentStatus=1 ";
                return Returned;
            }
        }
        public string RegisterationPrequisitSearchStr
        {
            get
            {
                string Returned = @"SELECT RegisterationID, PrequisitCourseCount, PrequisitPassedCourseCount
FROM     (SELECT dbo.UNIRegisteration.RegisterationID, COUNT(DISTINCT dbo.UNICourse.CourseID) AS PrequisitCourseCount, COUNT(DISTINCT derivedtbl_1.RegisterationCourse) AS PrequisitPassedCourseCount
                  FROM      dbo.UNIRegisteration INNER JOIN
                                    dbo.UNICoursePrequisit ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICoursePrequisit.CourseID INNER JOIN
                                    dbo.UNICourse ON dbo.UNICoursePrequisit.CoursePrequisitCourseID = dbo.UNICourse.CourseID LEFT OUTER JOIN
                                        (SELECT RegisterationStudent, RegisterationCourse, UNIRegisteration_1.RegisterationID
                                         FROM      dbo.UNIRegisteration AS UNIRegisteration_1
          LEFT OUTER JOIN
                  UNIRegisterationEqual ON UNIRegisteration_1.RegisterationID = UNIRegisterationEqual.RegisterationID 
                                         WHERE   (RegisterationPosted = 1 or UNIRegisterationEqual.RegisterationID  is not null) AND ((GPA > 0) OR
                                                            ISNULL(VerbalGPA, '') in ('T','P'))) AS derivedtbl_1 ON dbo.UNIRegisteration.RegisterationStudent = derivedtbl_1.RegisterationStudent AND 
                                    dbo.UNICoursePrequisit.CoursePrequisitCourseID = derivedtbl_1.RegisterationCourse
                  GROUP BY dbo.UNIRegisteration.RegisterationID, dbo.UNIRegisteration.RegisterationStudent, dbo.UNIRegisteration.RegisterationCourse) AS derivedtbl_2";
                return Returned;
            }
        }
        public string StudentCoursePrequisitSearchStr
        {
            get
            {
                string Returned = @"SELECT StudentCourseTable.StudentID AS PrequisitStudentID, StudentCourseTable.CourseID AS  PrequisitCourseID, ISNULL(PassedCourseTable.PrequisitPassedCount, 0) AS PrequisitPassedCount, 
                  StudentCourseTable.PrequisitCourseCount
FROM     (SELECT dbo.UNIStudent.StudentID, CoursePrequisitTable.CourseID, CoursePrequisitTable.PrequisitCourseCount
                  FROM      (SELECT dbo.UNICourse.CourseID, COUNT(DISTINCT dbo.UNICoursePrequisit.CoursePrequisitCourseID) AS PrequisitCourseCount
                                     FROM      dbo.UNICourse INNER JOIN
                                                       dbo.UNICoursePrequisit ON dbo.UNICourse.CourseID = dbo.UNICoursePrequisit.CourseID INNER JOIN
                                                       dbo.UNICourse AS UNICourse_1 ON dbo.UNICoursePrequisit.CoursePrequisitCourseID = UNICourse_1.CourseID
                                     GROUP BY dbo.UNICourse.CourseID) AS CoursePrequisitTable CROSS JOIN
                                    dbo.UNIStudent
                  GROUP BY dbo.UNIStudent.StudentID, CoursePrequisitTable.CourseID, CoursePrequisitTable.PrequisitCourseCount) AS StudentCourseTable LEFT OUTER JOIN
                      (SELECT UNICourse_2.CourseID, dbo.UNIRegisteration.RegisterationStudent, COUNT(distinct RegisterationCourse) AS PrequisitPassedCount
                       FROM      dbo.UNICoursePrequisit AS UNICoursePrequisit_2 INNER JOIN
                                         dbo.UNICourse AS UNICourse_2 ON UNICoursePrequisit_2.CourseID = UNICourse_2.CourseID INNER JOIN
                                         dbo.UNIRegisteration ON UNICoursePrequisit_2.CoursePrequisitCourseID = dbo.UNIRegisteration.RegisterationCourse
                       WHERE   (NOT (ISNULL(dbo.UNIRegisteration.VerbalGPA, '') IN ('', 'IC', 'F')))
                       GROUP BY UNICourse_2.CourseID, dbo.UNIRegisteration.RegisterationStudent) AS PassedCourseTable ON StudentCourseTable.StudentID = PassedCourseTable.RegisterationStudent AND 
                  StudentCourseTable.CourseID = PassedCourseTable.CourseID
";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        protected virtual void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["RegisterationID"] != null)
                int.TryParse(objDr["RegisterationID"].ToString(), out _ID);

            if (objDr.Table.Columns["RegisterationStudent"] != null)
                int.TryParse(objDr["RegisterationStudent"].ToString(), out _Student);

            if (objDr.Table.Columns["RegisterationDate"] != null)
                DateTime.TryParse(objDr["RegisterationDate"].ToString(), out _Date);

            if (objDr.Table.Columns["RegisterationSemester"] != null)
                int.TryParse(objDr["RegisterationSemester"].ToString(), out _Semester);

            if (objDr.Table.Columns["RegisterationStudentGender"] != null)
                int.TryParse(objDr["RegisterationStudentGender"].ToString(), out _StudentGender);
            if (objDr.Table.Columns["RegisterationCourse"] != null)
                int.TryParse(objDr["RegisterationCourse"].ToString(), out _Course);

            if (objDr.Table.Columns["RegisterationGrade"] != null)
                int.TryParse(objDr["RegisterationGrade"].ToString(), out _Level);

            if (objDr.Table.Columns["RegisterationIteration"] != null)
                int.TryParse(objDr["RegisterationIteration"].ToString(), out _Iteration);

            if (objDr.Table.Columns["MidtermDegree"] != null)
                double.TryParse(objDr["MidtermDegree"].ToString(), out _MidtermDegree);

            if (objDr.Table.Columns["SemesterWorkDegree"] != null)
                double.TryParse(objDr["SemesterWorkDegree"].ToString(), out _SemesterWorkDegree);

            if (objDr.Table.Columns["PracticalDegree"] != null)
                double.TryParse(objDr["PracticalDegree"].ToString(), out _PracticalDegree);

            if (objDr.Table.Columns["OralDegree"] != null)
                double.TryParse(objDr["OralDegree"].ToString(), out _OralDegree);

            if (objDr.Table.Columns["FinalDegree"] != null)
                double.TryParse(objDr["FinalDegree"].ToString(), out _FinalDegree);

            if (objDr.Table.Columns["ClinicalDegree"] != null)
                double.TryParse(objDr["ClinicalDegree"].ToString(), out _ClinicalDegree);
            if (objDr.Table.Columns["Bonus"] != null)
                double.TryParse(objDr["Bonus"].ToString(), out _Bonus);
            if (objDr.Table.Columns["RegisterationStatus"] != null)
                int.TryParse(objDr["RegisterationStatus"].ToString(), out _Status);
            if (objDr.Table.Columns["RegisterationCourseFinalDegree"] != null)
                int.TryParse(objDr["RegisterationCourseFinalDegree"].ToString(), out _CourseFinalDegree);

            
            if (objDr.Table.Columns["RegisterationFinalMinDegree"] != null)
                double.TryParse(objDr["RegisterationFinalMinDegree"].ToString(), out _FinalMinDegree);
            if (objDr.Table.Columns["RegisterationFinalTotalDegree"] != null)
                int.TryParse(objDr["RegisterationFinalTotalDegree"].ToString(), out _CourseFinalDegree);
            if (objDr.Table.Columns["SemesterCount"] != null)
                int.TryParse(objDr["SemesterCount"].ToString(), out _SemesterCount);

            if (objDr.Table.Columns["FailureCount"] != null)
                int.TryParse(objDr["FailureCount"].ToString(), out _FailureCount);
            if (objDr.Table.Columns["MaxGPA"] != null)
                double.TryParse(objDr["MaxGPA"].ToString(), out _MaxGPA);
            if (objDr.Table.Columns["RegisterationNote"] != null)
                _Note = objDr["RegisterationNote"].ToString();
            if (objDr.Table.Columns["RegisterationStudentCode"] != null)
                _StudentCode = objDr["RegisterationStudentCode"].ToString();
            if (objDr.Table.Columns["RegisterationStudentName"] != null)
                _StudentName = objDr["RegisterationStudentName"].ToString();
            if (objDr.Table.Columns["RegisterationPosted"] != null)
                bool.TryParse(objDr["RegisterationPosted"].ToString(), out _Posted);
            if (objDr.Table.Columns["RegisterationResult"] != null)
                int.TryParse(objDr["RegisterationResult"].ToString(), out _ResultID);
            SetSourceData(objDr);
            if (objDr.Table.Columns["RegisterationStudentFaculty"] != null)
                int.TryParse(objDr["RegisterationStudentFaculty"].ToString(), out _Faculty);
            if (objDr.Table.Columns["RegisterationStudentMail"] != null)
                _StudentMail = objDr["RegisterationStudentMail"].ToString();

            if (objDr.Table.Columns["MTStatus"] != null)
                int.TryParse(objDr["MTStatus"].ToString(), out _MTStatus);

            if (objDr.Table.Columns["SWStatus"] != null)
                int.TryParse(objDr["SWStatus"].ToString(), out _SWStatus);

            if (objDr.Table.Columns["PStatus"] != null)
                int.TryParse(objDr["PStatus"].ToString(), out _PStatus);

            if (objDr.Table.Columns["OStatus"] != null)
                int.TryParse(objDr["OStatus"].ToString(), out _OStatus);

            if (objDr.Table.Columns["FStatus"] != null)
                int.TryParse(objDr["FStatus"].ToString(), out _FStatus);

            if (objDr.Table.Columns["CStatus"] != null)
                int.TryParse(objDr["CStatus"].ToString(), out _CStatus);
            if (_FStatus == 7)
                _Status = 7;
            if (objDr.Table.Columns["PrequisitCourseCount"] != null)
                int.TryParse(objDr["PrequisitCourseCount"].ToString(), out _PrequisitCourseCount);
            if (objDr.Table.Columns["PrequisitPassedCourseCount"] != null)
                int.TryParse(objDr["PrequisitPassedCourseCount"].ToString(), out _PrequisitPassedCourseCount);
            if( _PrequisitCourseCount>_PrequisitPassedCourseCount)
            {
                _Status = 3;
                
            }
            if (_CourseFinalDegree == 0)
            {

            }
        }
        void SetSourceData(DataRow objDr)
        {

            if (objDr.Table.Columns["MainRegisterationID"] != null)
                int.TryParse(objDr["MainRegisterationID"].ToString(), out _MainRegisterationID);

            if (objDr.Table.Columns["SourceRegisterationID"] != null)
                int.TryParse(objDr["SourceRegisterationID"].ToString(), out _SourceRegisterationID);

            if (objDr.Table.Columns["SourceRegisterationDate"] != null)
                DateTime.TryParse(objDr["SourceRegisterationDate"].ToString(), out _SourceRegisterationDate);

            if (objDr.Table.Columns["SourceSemesterID"] != null)
                int.TryParse(objDr["SourceSemesterID"].ToString(), out _SourceSemesterID);

            if (objDr.Table.Columns["SourceSemesterDesc"] != null)
                _SourceSemesterDesc = objDr["SourceSemesterDesc"].ToString();

            if (objDr.Table.Columns["SourceMidtermDegree"] != null)
                double.TryParse(objDr["SourceMidtermDegree"].ToString(), out _SourceMidtermDegree);

            if (objDr.Table.Columns["SourceSemesterWorkDegree"] != null)
                double.TryParse(objDr["SourceSemesterWorkDegree"].ToString(), out _SourceSemesterWorkDegree);

            if (objDr.Table.Columns["SourcePracticalDegree"] != null)
                double.TryParse(objDr["SourcePracticalDegree"].ToString(), out _SourcePracticalDegree);

            if (objDr.Table.Columns["SourceOralDegree"] != null)
                double.TryParse(objDr["SourceOralDegree"].ToString(), out _SourceOralDegree);

            if (objDr.Table.Columns["SourceFinalDegree"] != null)
                double.TryParse(objDr["SourceFinalDegree"].ToString(), out _SourceFinalDegree);

            if (objDr.Table.Columns["SourceVerbalGPA"] != null)
                _SourceVerbalGPA = objDr["SourceVerbalGPA"].ToString();

            if (objDr.Table.Columns["SourceGPA"] != null)
                double.TryParse(objDr["SourceGPA"].ToString(), out _SourceGPA);

            if (objDr.Table.Columns["SourceStatus"] != null)
                int.TryParse(objDr["SourceStatus"].ToString(), out _SourceStatus);

            if (objDr.Table.Columns["SourceNote"] != null)
                _SourceNote = objDr["SourceNote"].ToString();

            if (objDr.Table.Columns["SourceResult"] != null)
                int.TryParse(objDr["SourceResult"].ToString(), out _SourceResult);
            if (objDr.Table.Columns["RegisterationSeatNo"] != null)
                _SeatNo = objDr["RegisterationSeatNo"].ToString();
            if (objDr.Table.Columns["EqualRegisterationID"] != null)
                int.TryParse(objDr["EqualRegisterationID"].ToString(), out _EqualID);
            if (objDr.Table.Columns["EqualRegisterationNameA"] != null)
                _EqualNameA = objDr["EqualRegisterationNameA"].ToString();
            if (objDr.Table.Columns["EqualRegisterationNameE"] != null)
                _EqualNameE = objDr["EqualRegisterationNameE"].ToString();

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
        public void EditDegree()
        {
            string strSql = EditDegreeStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
           // string strNahas = "";
            string strSql = SearchStr ;
            //strSql += " and UNIRegisteration.RegisterationID=1841";
            if (_ID != 0)
                strSql += " and UNIRegisteration.RegisterationID="+_ID;

            if (_StudentIDs != null && _StudentIDs != "")
                strSql += " and UNIRegisteration.RegisterationStudent in (" + _StudentIDs+") ";
            if (_Student != 0)
                strSql += " and UNIRegisteration.RegisterationStudent =" + _Student + "";

            if (_Course != 0)
                strSql += " and UNIRegisteration.RegisterationCourse = "+_Course;
            if (_CourseIDs != null && _CourseIDs!= "")
                strSql += " and UNIRegisteration.RegisterationCourse in (" + _CourseIDs +") ";
            if (_Semester != 0)
                strSql += " and UNIRegisteration.RegisterationSemester="+_Semester;

            if (_CourseLevel != 0)
            {
                strSql += " and CourseTable.CourseRecommendedGrade=" + _CourseLevel;
            }

            if (_StudentCode!= null && _StudentCode != "")
                strSql += " and (RegisterationStudentCode like '%"+_StudentCode+ "%' or dbo.ReplaceStringComp(RegisterationStudentName) like '%"+ SysUtility.ReplaceStringComp(_StudentCode) +"%')";
            if (_CourseCode != null && _CourseCode != "")
                strSql += " and (CourseCode like '%" + _CourseCode + "%' or CourseNameA like '%" + _CourseCode + "%')";
            if(_Status==1)
            {
                strSql += @" and isnull(dbo.UNIRegisteration.RegisterationStatus,0) in (0,1)
 ";
            }
            if (_Status == 4)
            {
                strSql += @" and isnull(dbo.UNIRegisteration.RegisterationStatus,0) in (2,4)
 ";
            }
            if (_Status == 3)
            {
                strSql += @" and isnull(dbo.UNIRegisteration.RegisterationStatus,0) =3
 ";
            }
            if (_PostStatus == 1)
                strSql += " and (RegisterationPosted = 1 or RegisterationResult>0) ";
            else if (_PostStatus == 2)
                strSql += " and (RegisterationPosted = 0 and isnull(RegisterationResult,0)=0) ";
            if (_OnlyNonCompleted)
                strSql += @" and (PrequisitTable.PrequisitCourseCount<>PrequisitTable.PrequisitPassedCourseCount) ";
            if (_ResultStatus == 1&&(_ResultIDs== null ||_ResultIDs==""))
                strSql += " and RegisterationResult >0 ";
            else if (_ResultStatus == 2)
                strSql += " and RegisterationResult = 0 ";
            strSql += " order by RegisterationStudentName ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void UploadStudent()
        {
            if (_StudentIDs == null || _StudentIDs == "" || _Semester == 0 || _Course == 0)
                return;
            string strPreRegisteredStudent = @"SELECT dbo.UNIRegisteration.RegisterationStudent AS PreRegisteredStudent
FROM     dbo.UNIRegisteration INNER JOIN
                      (SELECT RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxRegisterationSemester
                       FROM      dbo.UNIRegisteration AS UNIRegisteration_1
                       GROUP BY RegisterationStudent, RegisterationCourse) AS MaxRegisterationTable ON dbo.UNIRegisteration.RegisterationStudent = MaxRegisterationTable.RegisterationStudent AND 
                  dbo.UNIRegisteration.RegisterationCourse = MaxRegisterationTable.RegisterationCourse AND dbo.UNIRegisteration.RegisterationSemester = MaxRegisterationTable.MaxRegisterationSemester
WHERE  (NOT (dbo.UNIRegisteration.RegisterationStatus IN (2, 3, 4)))";
            //strPreRegisteredStudent+= " AND (dbo.UNIRegisteration.RegisterationCourse = " + _Course + ")  AND (dbo.UNIRegisteration.VerbalGPA <> 'f')";
            strPreRegisteredStudent += " AND (dbo.UNIRegisteration.RegisterationCourse = " + _Course + ")  AND (dbo.UNIRegisteration.VerbalGPA not in('f','D','D+','C-'))";
            string strCourse = @"SELECT CourseTotalDegree, CourseMidtermDegree, CourseSemesterWorkDegree, CoursePracticalDegree, CourseOralDegree, CourseFinalDegree
FROM     dbo.UNICourse
WHERE  (CourseID = "+_Course+@")";
            string strCourseLevel = @"SELECT CourseRecommendedGrade
FROM     dbo.UNICourse
WHERE  (CourseID = " + _Course + ")";
            string strSql = @"select  StudentTable.StudentID,GetDate() as RegisterationDate," + Semester + " as RegisterationSemester," + Course + @" as RegisterationCourse,0 as RegisterationLevel,0 as RegisterationIteration,0 as RegisterationMidtermDegree ,0 as RegisterationSemesterWorkDegree ,0 as RegisterationPracticalDegree ,0 as RegisterationOralDegree ,0 as  RegisterationFinalDegree ,CourseTable.CourseTotalDegree, CourseTable.CourseMidtermDegree, CourseTable.CourseSemesterWorkDegree, CourseTable.CoursePracticalDegree, CourseTable.CourseOralDegree, CourseTable.CourseFinalDegree,CourseTable.CourseFinalMinDegree
," + User + @" as UsrIns1,GetDate() as TimIns1 from (" + new StudentDb().SearchStr + ") as StudentTable ";
            strSql += @" cross join ("+strCourse+@") as CourseTable left outer join (" + strPreRegisteredStudent + @") as PreRegisterationTable1  on StudentTable.StudentID = PreRegisterationTable1.PreRegisteredStudent
 where StudentTable.StudentStatus=1 and  PreRegisterationTable1.PreRegisteredStudent is null and  StudentTable.LastGrade >= (" + strCourseLevel + @") and StudentTable.StudentID in ("+_StudentIDs+") ";
           strSql= @" insert into UNIRegisteration (RegisterationStudent,RegisterationDate,RegisterationSemester,RegisterationCourse,RegisterationGrade,RegisterationIteration,MidtermDegree,SemesterWorkDegree,PracticalDegree,OralDegree,FinalDegree, RegisterationFinalTotalDegree, RegisterationFinalMidtermDegree, RegisterationFinalSemesterWorkDegree, RegisterationFinalPracticalDegree, RegisterationFinalOralDegree, RegisterationFinalFinalDegree,RegisterationFinalMinDegree
,UsrIns,TimIns) 
   " + strSql ;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void UploadStudentCourse()
        {
              if (_CourseIDs == null || _CourseIDs == "" || _Semester == 0 || _Student == 0)
                return;
            string strPreRegisteredStudent = @"SELECT dbo.UNIRegisteration.RegisterationStudent AS PreRegisteredStudent
FROM     dbo.UNIRegisteration INNER JOIN
                      (SELECT RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxRegisterationSemester
                       FROM      dbo.UNIRegisteration AS UNIRegisteration_1
                       GROUP BY RegisterationStudent, RegisterationCourse) AS MaxRegisterationTable ON dbo.UNIRegisteration.RegisterationStudent = MaxRegisterationTable.RegisterationStudent AND 
                  dbo.UNIRegisteration.RegisterationCourse = MaxRegisterationTable.RegisterationCourse AND dbo.UNIRegisteration.RegisterationSemester = MaxRegisterationTable.MaxRegisterationSemester
WHERE  (NOT (dbo.UNIRegisteration.RegisterationStatus IN (2, 3, 4))) AND (dbo.UNIRegisteration.RegisterationCourse in (" + _CourseIDs + ")) ";
            //strPreRegisteredStudent += " AND (dbo.UNIRegisteration.VerbalGPA <> 'f')";
            strPreRegisteredStudent += @" AND(dbo.UNIRegisteration.VerbalGPA not in ('wf','f', 'D', 'D+', 'C-')) ";
            strPreRegisteredStudent +=" and dbo.UNIRegisteration.RegisterationStudent = "+_Student+"";
            string strCourse = @"SELECT CourseID,CourseTotalDegree, CourseMidtermDegree, CourseSemesterWorkDegree, CoursePracticalDegree, CourseOralDegree, CourseFinalDegree,CourseFinalMinDegree
 FROM     dbo.UNICourse
WHERE  (CourseID in (" + _CourseIDs + @"))";
//            string strCourseLevel = @"SELECT CourseRecommendedGrade
//FROM     dbo.UNICourse
//WHERE  (CourseID = " + _Course + ")";

            string strSql = @"select  distinct StudentTable.StudentID,GetDate() as RegisterationDate," + Semester + @" as RegisterationSemester,CourseTable.CourseID as RegisterationCourse,0 as RegisterationLevel,0 as RegisterationIteration,0 as RegisterationMidtermDegree ,0 as RegisterationSemesterWorkDegree ,0 as RegisterationPracticalDegree ,0 as RegisterationOralDegree ,0 as  RegisterationFinalDegree ,CourseTable.CourseTotalDegree, CourseTable.CourseMidtermDegree, CourseTable.CourseSemesterWorkDegree, CourseTable.CoursePracticalDegree, CourseTable.CourseOralDegree, CourseTable.CourseFinalDegree
,CourseTable.CourseFinalMinDegree," + User + @" as UsrIns1,GetDate() as TimIns1 from (" + new StudentDb() { Faculty=Faculty}.SearchStr + ") as StudentTable ";
            strSql += @" cross join (" + strCourse + @") as CourseTable left outer join (" + strPreRegisteredStudent + @") as PreRegisterationTable1  on StudentTable.StudentID = PreRegisterationTable1.PreRegisteredStudent
 where StudentTable.StudentStatus=1 and  PreRegisterationTable1.PreRegisteredStudent is null    and StudentTable.StudentID="+_Student;
            strSql = @" insert into UNIRegisteration (RegisterationStudent,RegisterationDate,RegisterationSemester,RegisterationCourse,RegisterationGrade,RegisterationIteration,MidtermDegree,SemesterWorkDegree,PracticalDegree,OralDegree,FinalDegree, RegisterationFinalTotalDegree, RegisterationFinalMidtermDegree, RegisterationFinalSemesterWorkDegree, RegisterationFinalPracticalDegree, RegisterationFinalOralDegree, RegisterationFinalFinalDegree,RegisterationFinalMinDegree
,UsrIns,TimIns) 
   " + strSql;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            string strSource = @"insert into UNIRegisterationSource (RegisterationID, SourceRegisterationID
) 
  SELECT dbo.UNIRegisteration.RegisterationID, MAX(UNIRegisteration_1.RegisterationID) AS SourceRegisteration
FROM     dbo.UNIRegisteration INNER JOIN
                  dbo.UNIRegisteration AS UNIRegisteration_1 ON dbo.UNIRegisteration.RegisterationStudent = UNIRegisteration_1.RegisterationStudent AND dbo.UNIRegisteration.RegisterationID > UNIRegisteration_1.RegisterationID AND 
                  dbo.UNIRegisteration.RegisterationSemester > UNIRegisteration_1.RegisterationSemester AND dbo.UNIRegisteration.RegisterationCourse = UNIRegisteration_1.RegisterationCourse
GROUP BY dbo.UNIRegisteration.RegisterationID, dbo.UNIRegisteration.RegisterationStudent,dbo.UNIRegisteration.RegisterationCourse, dbo.UNIRegisteration.RegisterationSemester
HAVING (dbo.UNIRegisteration.RegisterationStudent = " + _Student+ ") AND (dbo.UNIRegisteration.RegisterationSemester = "+_Semester+")   AND (dbo.UNIRegisteration.RegisterationCourse in ("+_CourseIDs+"))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSource);
        }
        public void SaveEQH()
        {
            string strSql = AddStr;
            strSql += @" declare @ID int;
     set @ID = (select @@IDENTITY as NewID)
     insert into UNIRegisterationEqual (RegisterationID, RegisterationEqualCourseNameA, RegisterationEqualCourseNameE, RegisterationEqualUniversty
)
 select @ID as RegID,'"+_EqualNameA+"' as EQNameA,'"+ _EqualNameE +"' as EQNameE,"+_UniverstyID+ @" as EQUniverstyID 
   from UNIRegisteration where RegisterationID = @ID and RegisterationStudent="+_Student;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void EditPosted()
        {
            int intPosted = _Posted ? 1 : 0;

            string strSql = @"update  dbo.UNIRegisteration set RegisterationPosted = " + intPosted + @"
   WHERE(RegisterationPosted != " + intPosted + ") AND(RegisterationID IN(" + _IDs + @")) ";// "AND(RegisterationStatus = 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStatus()
        {
            

            string strSql = @"update  dbo.UNIRegisteration set RegisterationStatus = " + _Status + @",RegisterationPosted=0,RegisterationResult=0 
   WHERE (RegisterationID IN(" + _IDs + @"))
 and (
((isnull(RegisterationPosted,0) =0) and (isnull(RegisterationResult,0) =0))
or
 (RegisterationStatus=3 and "+_Status+@"=0)
)";// "AND(RegisterationStatus = 0) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void UploadRegisterationExcel()
        {
            if (_RegisterationTable == null || _RegisterationTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table UNIRegisterationTemp");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "UNIRegisterationTemp";
            objCopy.WriteToServer(_RegisterationTable);
            string strSql = @" update dbo.UNIRegisteration set  MidtermDegree = case when dbo.UNIRegisterationTemp.MT=0 then dbo.UNIRegisteration.MidtermDegree else MT end
, dbo.UNIRegisteration.SemesterWorkDegree=case when  dbo.UNIRegisterationTemp.SW>0 then SW else dbo.UNIRegisteration.SemesterWorkDegree end
, dbo.UNIRegisteration.PracticalDegree= case when dbo.UNIRegisterationTemp.Practical=0 then dbo.UNIRegisteration.PracticalDegree else Practical end 
                  ,dbo.UNIRegisteration.OralDegree= case when dbo.UNIRegisterationTemp.Oral=0 then dbo.UNIRegisteration.OralDegree else Oral end
				  , dbo.UNIRegisteration.FinalDegree= case when dbo.UNIRegisterationTemp.Final=0 then  dbo.UNIRegisteration.FinalDegree else Final end
				  , dbo.UNIRegisteration.Bonus= case when  dbo.UNIRegisterationTemp.Bonus=0 then  dbo.UNIRegisteration.Bonus else dbo.UNIRegisterationTemp.Bonus end
 ,RegisterationSeatNo=case when isnull(UNIRegisterationTemp.SeatNo,'')  ='' then RegisterationSeatNo else UNIRegisterationTemp.SeatNo end 
FROM     dbo.UNIRegisterationTemp INNER JOIN
                  dbo.UNIStudent ON dbo.UNIRegisterationTemp.StudentCode = dbo.UNIStudent.StudentCode INNER JOIN
                  dbo.UNICourse ON dbo.UNIRegisterationTemp.CourseCode = dbo.UNICourse.CourseCode INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIStudent.StudentID = dbo.UNIRegisteration.RegisterationStudent AND dbo.UNIRegisterationTemp.Semester = dbo.UNIRegisteration.RegisterationSemester AND 
                  dbo.UNICourse.CourseID = dbo.UNIRegisteration.RegisterationCourse 
 where (UNICourse.CourseFaculty = " + SysData.FacultyID+") and (UNIStudent.StudentFaculty="+SysData.FacultyID+ ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql= @"insert into  dbo.UNIRegisteration
 (RegisterationStudent, RegisterationDate, RegisterationSemester, RegisterationCourse, RegisterationGrade, RegisterationIteration, MidtermDegree, SemesterWorkDegree, PracticalDegree, OralDegree, FinalDegree, Bonus, 
                  RegisterationCourseFinalDegree, VerbalGPA, GPA, RegisterationStatus, RegisterationNote, RegisterationResult, RegisterationFinalTotalDegree, RegisterationFinalMidtermDegree, RegisterationFinalSemesterWorkDegree, 
                  RegisterationFinalPracticalDegree, RegisterationFinalOralDegree, RegisterationFinalFinalDegree,RegisterationFinalMinDegree,RegisterationSeatNo, RegisterationPosted, UsrIns, TimIns
)";
            double dblTimIns = DateTime.Now.ToOADate() - 2;
            strSql += @" SELECT dbo.UNIStudent.StudentID, GETDATE() AS RegDate, dbo.UNIRegisterationTemp.Semester, dbo.UNICourse.CourseID, 0 AS Grade, 0 AS Iteration, dbo.UNIRegisterationTemp.MT, dbo.UNIRegisterationTemp.SW, 
                  dbo.UNIRegisterationTemp.Practical, dbo.UNIRegisterationTemp.Oral, dbo.UNIRegisterationTemp.Final, dbo.UNIRegisterationTemp.Bonus, dbo.UNICourse.CourseTotalDegree, '' AS VerbalGPA, 0 AS GPA, 0 AS RegStatus, '' AS Note,
                  0 AS RegResult, dbo.UNICourse.CourseTotalDegree AS FinalTotalDegree, dbo.UNICourse.CourseMidtermDegree, dbo.UNICourse.CourseSemesterWorkDegree, dbo.UNICourse.CoursePracticalDegree, dbo.UNICourse.CourseOralDegree, 
                  dbo.UNICourse.CourseFinalDegree,dbo.UNICourse.CourseFinalMinDegree,UNIRegisterationTemp.SeatNO , 0 AS Posted, " + SysData.CurrentUser.ID+ @" AS UsrIns, "+dblTimIns+ @" AS TimIns
FROM dbo.UNIRegisterationTemp INNER JOIN
                  dbo.UNIStudent ON dbo.UNIRegisterationTemp.StudentCode = dbo.UNIStudent.StudentCode INNER JOIN
                  dbo.UNICourse ON replace(dbo.UNIRegisterationTemp.CourseCode,' ','') = replace(dbo.UNICourse.CourseCode,' ','') LEFT OUTER JOIN
                  dbo.UNIRegisteration ON dbo.UNIStudent.StudentID = dbo.UNIRegisteration.RegisterationStudent  AND
                  dbo.UNICourse.CourseID = dbo.UNIRegisteration.RegisterationCourse 
  left outer join ("+StudentCoursePrequisitSearchStr+@") as PrequisitTable 
 on UNICourse.CourseID = PrequisitTable.PrequisitCourseID and UNIStudent.StudentID = PrequisitTable.PrequisitStudentID
WHERE(dbo.UNIRegisteration.RegisterationID IS NULL) AND (dbo.UNICourse.CourseFaculty = " + SysData.FacultyID+@") AND (dbo.UNIStudent.StudentFaculty = "+SysData.FacultyID+ @") 
 and (PrequisitTable.PrequisitStudentID is null or PrequisitTable.PrequisitCourseCount=PrequisitTable.PrequisitPassedCount)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" insert into UNIRegisterationEqual (RegisterationID, RegisterationEqualCourseNameA, RegisterationEqualCourseNameE, RegisterationEqualUniversty
)";
            strSql += @"SELECT dbo.UNIRegisteration.RegisterationID, dbo.UNIRegisterationTemp.EQCourseNameA, dbo.UNIRegisterationTemp.EQCourseNameE, dbo.UNIRegisterationTemp.UniID
FROM     dbo.UNIRegisteration INNER JOIN
                  dbo.UNIStudent ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudent.StudentID INNER JOIN
                  dbo.UNICourse ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICourse.CourseID INNER JOIN
                  dbo.UNIRegisterationTemp ON REPLACE(dbo.UNICourse.CourseCode, ' ', '') = REPLACE(dbo.UNIRegisterationTemp.CourseCode, ' ', '') AND REPLACE(dbo.UNIStudent.StudentCode, ' ', '') 
                  = REPLACE(dbo.UNIRegisterationTemp.StudentCode, ' ', '')
WHERE  (ISNULL(dbo.UNIRegisterationTemp.UniID, 0) > 0) AND (dbo.UNIRegisteration.TimIns = "+dblTimIns+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @" update dbo.UNIRegisteration set VerbalGPA= dbo.UNICommonGrade.GradeVerbal, dbo.UNIRegisteration.GPA= (dbo.UNICommonGrade.GradePoints+dbo.UNICommonGrade.GradeMaxPoints)/2
, dbo.UNIRegisteration.FinalDegree= dbo.UNICommonGrade.GradeMaxPerc - 0.02 , 
                  dbo.UNIRegisteration.RegisterationCourseFinalDegree= 100, dbo.UNIRegisteration.RegisterationSemester= MaxEqSemester.MaxSemester
FROM     dbo.UNIRegisteration INNER JOIN
                  dbo.UNIStudent ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudent.StudentID INNER JOIN
                  dbo.UNICourse ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICourse.CourseID INNER JOIN
                  dbo.UNIRegisterationTemp ON REPLACE(dbo.UNICourse.CourseCode, ' ', '') = REPLACE(dbo.UNIRegisterationTemp.CourseCode, ' ', '') AND REPLACE(dbo.UNIStudent.StudentCode, ' ', '') 
                  = REPLACE(dbo.UNIRegisterationTemp.StudentCode, ' ', '') INNER JOIN
                  dbo.UNICommonGrade ON dbo.UNIRegisterationTemp.EQCourseVerbalGPA = dbo.UNICommonGrade.GradeVerbal 
   and UNICourse.CourseFaculty  = UNICommonGrade.GradeFaculty
  CROSS JOIN
                      (SELECT MAX(SemesterID) AS MaxSemester
                       FROM      dbo.UNISemester
                       WHERE   (SemesterType = 5)) AS MaxEqSemester
WHERE  (ISNULL(dbo.UNIRegisterationTemp.UniID, 0) > 0) AND (dbo.UNIRegisteration.TimIns = " + dblTimIns+@")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable GetPrequisit()
        {
            string strSql = @"SELECT dbo.UNIRegisteration.RegisterationID AS MainRegisterationID, UNIRegisteration_1.RegisterationID AS PreRegisterationID
FROM     dbo.UNICoursePrequisit INNER JOIN
                  dbo.UNIRegisteration AS UNIRegisteration_1 ON dbo.UNICoursePrequisit.CoursePrequisitCourseID = UNIRegisteration_1.RegisterationCourse INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNICoursePrequisit.CourseID = dbo.UNIRegisteration.RegisterationCourse AND UNIRegisteration_1.RegisterationStudent = dbo.UNIRegisteration.RegisterationStudent
WHERE  (dbo.UNIRegisteration.RegisterationID IN ("+_IDs+"))";
            strSql = "select RegisterationTable.*,PrequisitTable.MainRegisterationID  from (" + BaseSearchStr+") as RegisterationTable  inner join ("+strSql+ ") as PrequisitTable  on RegisterationTable.RegisterationID = PrequisitTable.PreRegisterationID ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion


    }
}