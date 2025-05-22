using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class StudentDb
    {

        #region Constructor
        public StudentDb()
        {
        }
        public StudentDb(DataRow objDr)
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
        bool _IgnoreFaculty = false;
        public bool IgnoreFaculty { set => _IgnoreFaculty = value; }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        DateTime _BirthDate;
        public DateTime BirthDate
        {
            set => _BirthDate = value;
            get => _BirthDate;
        }
        int _Gender;
        public int Gender { set => _Gender = value; get => _Gender; }
        string _Mobile1;
        public string Mobile1
        {
            set => _Mobile1 = value;
            get => _Mobile1;
        }
        string _Mobile2;
        public string Mobile2
        {
            set => _Mobile2 = value;
            get => _Mobile2;
        }
        string _Phone1;
        public string Phone1
        {
            set => _Phone1 = value;
            get => _Phone1;
        }
        string _Phone2;
        public string Phone2
        {
            set => _Phone2 = value;
            get => _Phone2;
        }
        string _Address;
        public string Address
        {
            set => _Address = value;
            get => _Address;
        }
        string _Email;
        public string Email
        {
            set => _Email = value;
            get => _Email;
        }
        string _Password;
        public string Password { set => _Password = value; get => _Password; }
        int _HomeCity;
        public int HomeCity
        {
            set => _HomeCity = value;
            get => _HomeCity;
        }
        int _HomeCountry;
        public int HomeCountry
        {
            set => _HomeCountry = value;
            get => _HomeCountry;
        }
        int _LastGrade;
        public int LastGrade
        { set => _LastGrade = value; get => _LastGrade; }
        int _Status;
        public int Status { set => _Status = value; get => _Status; }
        int _SendingStatus;
        public int SendingStatus { set => _SendingStatus = value; }
        int _CourseID;
        public int CourseID { set => _CourseID = value; }
        int _CourseRegisterationStatus;
        public int CourseRegisterationStatus { set => _CourseRegisterationStatus = value; }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; }
        bool _AllStudent;
        public bool AllStudent { set => _AllStudent = value; }
        DataTable _StudentTable;
        public DataTable StudentTable { set => _StudentTable = value; get => _StudentTable; }
        string _IDs;
        public string IDs { set => _IDs = value; }
        int _CurrentSemester;
        public int CurrentSemester { set => _CurrentSemester = value; }
        bool _Selected;
        public bool Selected { set => _Selected = value; }
        #region Result Properties
        string _MaxResultCGPA;
        public string MaxResultCGPA
        {
            set => _MaxResultCGPA = value;
            get => _MaxResultCGPA;
        }
        double _MaxResultCPoints;
        public double MaxResultCPoints
        {
            set => _MaxResultCPoints = value;
            get => _MaxResultCPoints;
        }
        double _MaxResultTotalCreditHour;
        public double MaxResultTotalCreditHour
        {
            set => _MaxResultTotalCreditHour = value;
            get => _MaxResultTotalCreditHour;
        }
        double _MaxResultEarnedHour;
        public double MaxResultEarnedHour
        {
            set => _MaxResultEarnedHour = value;
            get => _MaxResultEarnedHour;
        }
        string _MaxResultSGPA;
        public string MaxResultSGPA
        {
            set => _MaxResultSGPA = value;
            get => _MaxResultSGPA;
        }
        double _MaxResultSPoints;
        public double MaxResultSPoints
        {
            set => _MaxResultSPoints = value;
            get => _MaxResultSPoints;
        }
        string _MaxResultNote;
        public string MaxResultNote
        {
            set => _MaxResultNote = value;
            get => _MaxResultNote;
        }

        #endregion
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIStudent (StudentCode,StudentNameA,StudentNameE,StudentBirthDate,StudentMobile1,StudentMobile2,StudentPhone1,StudentPhone2,StudentAddress,StudentEmail,StudentHomeCity,StudentHomeCountry,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "'," + (BirthDate.ToOADate() - 2).ToString() + ",'" + Mobile1 + "','" + Mobile2 + "','" + Phone1 + "','" + Phone2 + "','" + Address + "','" + Email + "'," + HomeCity + "," + HomeCountry + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIStudent set " + "StudentID=" + ID + "" +
           ",StudentCode='" + Code + "'" +
           ",StudentNameA='" + NameA + "'" +
           ",StudentNameE='" + NameE + "'" +
           ",StudentBirthDate=" + (BirthDate.ToOADate() - 2).ToString() + "" +
           ",StudentMobile1='" + Mobile1 + "'" +
           ",StudentMobile2='" + Mobile2 + "'" +
           ",StudentPhone1='" + Phone1 + "'" +
           ",StudentPhone2='" + Phone2 + "'" +
           ",StudentAddress='" + Address + "'" +
           ",StudentEmail='" + Email + "'" +
           ",StudentHomeCity=" + HomeCity + "" +
           ",StudentHomeCountry=" + HomeCountry + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIStudent set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                //                string strLastGrade = @"SELECT RegisterationStudent, MAX(RegisterationGrade) AS LastGrade
                //FROM     dbo.UNIRegisteration
                //GROUP BY RegisterationStudent";
                string strLastResult = @"SELECT ResultStudent, MAX(ResultID) AS MaxResultID
                  FROM      dbo.UNIStudentResult
                  GROUP BY ResultStudent";
                string strMaxResult = @"SELECT dbo.UNIStudent.StudentID AS MaxResultStudent, UNIStudentResult_1.ResultCGPA AS MaxResultCGPA, UNIStudentResult_1.ResultCPoints AS MaxResultCPoints, 
                  UNIStudentResult_1.ResultTotalCreditHour AS MaxResultTotalCreditHour, UNIStudentResult_1.ResultEarnedHour AS MaxResultEarnedHour, UNIStudentResult_1.ResultSGPA AS MaxResultSGPA, 
                  UNIStudentResult_1.ResultSPoints AS MaxResultSPoints, UNIStudentResult_1.ResultNote AS MaxResultNote
FROM     (" + strLastResult + @") AS MaxResultTable LEFT OUTER JOIN
                  dbo.UNIStudentResult AS UNIStudentResult_1 ON MaxResultTable.MaxResultID = UNIStudentResult_1.ResultID RIGHT OUTER JOIN
                  dbo.UNIStudent ON MaxResultTable.ResultStudent = dbo.UNIStudent.StudentID";
                string strSent = @"SELECT StudentID, MAX(SentDate) AS MaxSentDate
FROM     dbo.UNISentMail
GROUP BY StudentID";
                string Returned = @" select UNIStudent.StudentID,UNIStudent.StudentFaculty,StudentCode,StudentNameA,StudentNameE,StudentBirthDate,StudentMobile1,StudentMobile2,StudentPhone1,StudentPhone2,StudentAddress,StudentEmail,StudentHomeCity,StudentHomeCountry,UNIStudent.StudentStatus,isnull(UNIStudent.Gender,0) as StudentGender,isnull(dbo.UNILevel.LevelOrder,1) LastGrade, MaxResultTable.*
  from  UNIStudent";
                //  left outer join (" + strLastGrade+ @") as LastGradeTable 
                //on UNIStudent.StudentID = LastGradeTable.RegisterationStudent 
                Returned += " left outer join (" + strMaxResult + @") as MaxResultTable  
  on  UNIStudent.StudentID = MaxResultTable.MaxResultStudent
   INNER JOIN
                  dbo.UNILevel ON 
    UNIStudent.StudentFaculty = UNILevel.LevelFaculty and   ISNULL(MaxResultTable.MaxResultEarnedHour, 0) >= dbo.UNILevel.LevelCreditHourFrom AND ISNULL(MaxResultTable.MaxResultEarnedHour, 0) <= dbo.UNILevel.LevelCreditHourTo  
  LEFT OUTER JOIN
                  (" + strSent + @") as SentTable ON dbo.UNIStudent.StudentID = SentTable.StudentID
  ";
                if (_Selected)
                {
                    Returned += " inner join VUNISelectedStudent on UNIStudent.StudentID = VUNISelectedStudent.StudentID  ";
                }
                Returned += @" where dbo.UNIStudent.StudentFaculty = " + _Faculty;
                //                Returned += @" inner join VUNIFaildStudent
                //on VUNIFaildStudent.RegisterationStudent = UNIStudent.StudentID
                //";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["StudentID"] != null)
                int.TryParse(objDr["StudentID"].ToString(), out _ID);

            if (objDr.Table.Columns["StudentFaculty"] != null)
                int.TryParse(objDr["StudentFaculty"].ToString(), out _Faculty);
            if (objDr.Table.Columns["StudentCode"] != null)
                _Code = objDr["StudentCode"].ToString();

            if (objDr.Table.Columns["StudentNameA"] != null)
                _NameA = objDr["StudentNameA"].ToString();

            if (objDr.Table.Columns["StudentNameE"] != null)
                _NameE = objDr["StudentNameE"].ToString();
            if (objDr.Table.Columns["StudentGender"] != null)
                int.TryParse(objDr["StudentGender"].ToString(), out _Gender);
            if (objDr.Table.Columns["StudentBirthDate"] != null)
                DateTime.TryParse(objDr["StudentBirthDate"].ToString(), out _BirthDate);

            if (objDr.Table.Columns["StudentMobile1"] != null)
                _Mobile1 = objDr["StudentMobile1"].ToString();

            if (objDr.Table.Columns["StudentMobile2"] != null)
                _Mobile2 = objDr["StudentMobile2"].ToString();

            if (objDr.Table.Columns["StudentPhone1"] != null)
                _Phone1 = objDr["StudentPhone1"].ToString();

            if (objDr.Table.Columns["StudentPhone2"] != null)
                _Phone2 = objDr["StudentPhone2"].ToString();

            if (objDr.Table.Columns["StudentAddress"] != null)
                _Address = objDr["StudentAddress"].ToString();

            if (objDr.Table.Columns["StudentEmail"] != null)
                _Email = objDr["StudentEmail"].ToString();

            if (objDr.Table.Columns["StudentHomeCity"] != null)
                int.TryParse(objDr["StudentHomeCity"].ToString(), out _HomeCity);

            if (objDr.Table.Columns["StudentHomeCountry"] != null)
                int.TryParse(objDr["StudentHomeCountry"].ToString(), out _HomeCountry);
            if (objDr.Table.Columns["LastGrade"] != null)
                int.TryParse(objDr["LastGrade"].ToString(), out _LastGrade);
            SetResultData(objDr);
        }
        void SetResultData(DataRow objDr)
        {

            if (objDr.Table.Columns["MaxResultCGPA"] != null)
                _MaxResultCGPA = objDr["MaxResultCGPA"].ToString();

            if (objDr.Table.Columns["MaxResultCPoints"] != null)
                double.TryParse(objDr["MaxResultCPoints"].ToString(), out _MaxResultCPoints);

            if (objDr.Table.Columns["MaxResultTotalCreditHour"] != null)
                double.TryParse(objDr["MaxResultTotalCreditHour"].ToString(), out _MaxResultTotalCreditHour);

            if (objDr.Table.Columns["MaxResultEarnedHour"] != null)
                double.TryParse(objDr["MaxResultEarnedHour"].ToString(), out _MaxResultEarnedHour);

            if (objDr.Table.Columns["MaxResultSGPA"] != null)
                _MaxResultSGPA = objDr["MaxResultSGPA"].ToString();

            if (objDr.Table.Columns["MaxResultSPoints"] != null)
                double.TryParse(objDr["MaxResultSPoints"].ToString(), out _MaxResultSPoints);

            if (objDr.Table.Columns["MaxResultNote"] != null)
                _MaxResultNote = objDr["MaxResultNote"].ToString();
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
            if (_IDs == null || _IDs == "")
                return;
            string strSql = "update UNIStudent set StudentStatus = " + _Status + " where StudentID in (" + _IDs + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        
        public DataTable Search()
        {
            string strSql = SearchStr;
            //strSql += " and UniStudent.StudentID = 298 ";
            if (!_AllStudent)
                strSql += " and (StudentStatus=1) ";
            if (_Status == 1)
                strSql += " and (StudentStatus=1) ";
            if (_Status == 2)
                strSql += " and (StudentStatus>1) ";
            if (_IDs != null && _IDs != "")
                strSql += " and UNIStudent.StudentID in(" + _IDs + ") ";

            if (_SendingStatus == 1 && (_Code == null || _Code == ""))
                strSql += " AND (ISNULL(dbo.UNIStudent.StudentEmail, '') <> '')  and (SentTable.StudentID IS NULL)";
            if (_Code != null && _Code != "")
                strSql += " and (StudentCode like '%" + _Code + "%' or StudentNameA like '%" + _Code + "%') ";

            if (_LastGrade != 0)
                strSql += " and isnull(dbo.UNILevel.LevelOrder,1) = " + _LastGrade;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
      
        public DataTable GetUnpostedCount()
        {
            string strSql = @"SELECT dbo.UNIStudent.StudentID, COUNT(dbo.UNIRegisteration.RegisterationID) AS UnPostedCount
FROM     dbo.UNIStudent INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIStudent.StudentID = dbo.UNIRegisteration.RegisterationStudent
WHERE  (dbo.UNIRegisteration.RegisterationSemester = " + _CurrentSemester + @") AND (ISNULL(dbo.UNIRegisteration.RegisterationPosted, 0) = 0) and (dbo.UNIStudent.StudentID in(" + _IDs + @"))
GROUP BY dbo.UNIStudent.StudentID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetStudentByUserNameAndPass()
        {
            DataTable Returned = new DataTable();
            string strSql = @"SELECT UNIStudent.StudentID,UNIStudent.StudentCode,UNIStudent.StudentNameA,dbo.UNIStudent.StudentEmail
FROM     dbo.UNIStudentPass AS MaxNotLogedInPass RIGHT OUTER JOIN
                      (SELECT StudentID, MAX(CASE WHEN StudentPassLoginDate IS NOT NULL THEN PassID ELSE 0 END) AS MaxLogedPassID, MAX(PassID) AS MaxPassID
                       FROM      dbo.UNIStudentPass AS UNIStudentPass_1
                       GROUP BY StudentID) AS MaxPassTable ON MaxNotLogedInPass.PassID = MaxPassTable.MaxPassID LEFT OUTER JOIN
                  dbo.UNIStudentPass AS MaxLogedinPassTable ON MaxPassTable.MaxLogedPassID = MaxLogedinPassTable.PassID RIGHT OUTER JOIN
                  dbo.UNIStudent ON MaxPassTable.StudentID = dbo.UNIStudent.StudentID
WHERE  
(ISNULL(dbo.UNIStudent.StudentEmail, dbo.UNIStudent.StudentCode) = 'Karem.PT22003@std.ahuc.edu.eg') AND (ISNULL(dbo.UNIStudent.StudentEmail, ISNULL(dbo.UNIStudent.StudentCode, '')) <> '')
and ((isnull(MaxLogedinPassTable.StudentPass,'') <> '' ) 
or( isnull(MaxNotLogedInPass.StudentPass,'')<>'' ))";
            return Returned;
        }
        public string CreateNewPass()
        {
            string Returned = "";
            if(_Code!= null && _Code!= "")
            {
                Returned = Guid.NewGuid().ToString();

            }
            return Returned;
        }
                public void SaveSent()
        {
            string strSql = @"insert into UNISentMail(StudentID,SentDate,Email) values(" + _ID + ",GetDate(),'" + _Email + "') ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void UploadStudent()
        {
            if (_StudentTable == null || _StudentTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table UNIStudentTemp");
            SqlBulkCopy objCopy = new SqlBulkCopy
(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "UNIStudentTemp";
            objCopy.WriteToServer(_StudentTable);
            string strSql = @"update dbo.UNIStudent set StudentEmail= CASE WHEN isnull(dbo.UNIStudent.StudentEmail, '') = '' THEN dbo.UNIStudentTemp.EMail ELSE dbo.UNIStudent.StudentEmail END , dbo.UNIStudent.StudentMobile1= 
                  CASE WHEN isnull(dbo.UNIStudent.StudentMobile1, '') = '' THEN dbo.UNIStudentTemp.Mobile ELSE dbo.UNIStudent.StudentMobile1 END, dbo.UNIStudent.StudentPhone1= CASE WHEN isnull(dbo.UNIStudent.StudentPhone1, '') 
                  = '' THEN dbo.UNIStudentTemp.Phone ELSE dbo.UNIStudent.StudentPhone1 END
FROM     dbo.UNIStudentTemp INNER JOIN
                  dbo.UNIStudent ON dbo.ReplaceStringComp(dbo.UNIStudentTemp.Code) = dbo.ReplaceStringComp(dbo.UNIStudent.StudentCode)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into UNIStudent (StudentFaculty,StudentCode, StudentNameA, StudentMobile1, StudentPhone1, StudentAddress, StudentEmail,StudentStatus,UsrIns,TimIns)
SELECT "+SysData.FacultyID+@" as StudentFaculty1,dbo.UNIStudentTemp.Code, dbo.UNIStudentTemp.Name, dbo.UNIStudentTemp.Mobile, dbo.UNIStudentTemp.Phone, dbo.UNIStudentTemp.Address, dbo.UNIStudentTemp.EMail, 1 AS SStatus, "+SysData.CurrentUser.ID+ @" AS UsrIns, GETDATE() AS TimIns
FROM     dbo.UNIStudentTemp LEFT OUTER JOIN
                  dbo.UNIStudent ON dbo.ReplaceStringComp(dbo.UNIStudentTemp.Code) = dbo.ReplaceStringComp(dbo.UNIStudent.StudentCode)
  WHERE  (dbo.UNIStudent.StudentID IS NULL) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable GetRecommendedRegisterationCourse()
        {
            string strPreRegisteredStudent = @"SELECT dbo.UNIRegisteration.RegisterationCourse AS PreRegisteredCourse
FROM     dbo.UNIRegisteration INNER JOIN
                      (SELECT RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxRegisterationSemester
                       FROM      dbo.UNIRegisteration AS UNIRegisteration_1
                       GROUP BY RegisterationStudent, RegisterationCourse) AS MaxRegisterationTable ON dbo.UNIRegisteration.RegisterationStudent = MaxRegisterationTable.RegisterationStudent AND 
                  dbo.UNIRegisteration.RegisterationCourse = MaxRegisterationTable.RegisterationCourse AND dbo.UNIRegisteration.RegisterationSemester = MaxRegisterationTable.MaxRegisterationSemester
WHERE  (NOT (isnull(dbo.UNIRegisteration.RegisterationStatus,0) IN (2, 3, 4))) AND (dbo.UNIRegisteration.RegisterationStudent = " + ID + ")  ";
            //strPreRegisteredStudent +=" AND (isnull(dbo.UNIRegisteration.VerbalGPA,'') <> 'f')";
            strPreRegisteredStudent += " AND (isnull(dbo.UNIRegisteration.VerbalGPA,'') not in  ('f','C-','D+','D','wf')) and isnull(UNIRegisteration.RegisterationStatus,0) <>3  ";
            string strMaxSemester = @"SELECT MAX(SemesterID) AS MaxSemesterID
FROM     dbo.UNISemester";
            string strPassedPrequisite = @"SELECT dbo.UNICourse.CourseID, COUNT(DISTINCT dbo.UNICoursePrequisit.CoursePrequisitCourseID) AS PassedPrequisitCourseCount
FROM     dbo.UNICourse INNER JOIN
                  dbo.UNICoursePrequisit ON dbo.UNICourse.CourseID = dbo.UNICoursePrequisit.CourseID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNICoursePrequisit.CoursePrequisitCourseID = dbo.UNIRegisteration.RegisterationCourse
WHERE   (dbo.UNIRegisteration.RegisterationStudent = " + _ID + @") ";
            strPassedPrequisite +=@" AND (NOT (isnull(dbo.UNIRegisteration.RegisterationStatus,0) IN (2, 3, 4))) AND (isnull(dbo.UNIRegisteration.VerbalGPA,'') not in ('f','wf'))
GROUP BY dbo.UNICourse.CourseID";

            string strCoursePrequisitCount = @"SELECT dbo.UNICoursePrequisit.CourseID, COUNT(DISTINCT dbo.UNICourse.CourseID) AS CoursePrequisitCount
FROM     dbo.UNICoursePrequisit INNER JOIN
                  dbo.UNICourse ON dbo.UNICoursePrequisit.CoursePrequisitCourseID = dbo.UNICourse.CourseID
GROUP BY dbo.UNICoursePrequisit.CourseID ";
            string strSql ="select CourseTable.* from ("+ new CourseDb() { Faculty=Faculty}.SearchStr +
                @") as CourseTable  left outer join ("+strPreRegisteredStudent+ @") as PreregisteredTable  on CourseTable.CourseID = PreregisteredTable.PreRegisteredCourse 
  left outer join ("+strPassedPrequisite+ @") as PassedTable on 
 CourseTable.CourseID = PassedTable.CourseID  
 left outer join ("+strCoursePrequisitCount+ @") CoursePrequisitTable  on  CourseTable.CourseID =  CoursePrequisitTable.CourseID ";
            strSql += " where (1=1) ";
            strSql += " and  PreregisteredTable.PreRegisteredCourse is null ";

            strSql += " and (isnull(CoursePrequisitTable.CoursePrequisitCount,0) =0 or isnull(CoursePrequisitTable.CoursePrequisitCount,0) = isnull(PassedTable.PassedPrequisitCourseCount,0)) ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public  void StopStudent()
        {
            if (_CurrentSemester == 0 || _IDs == null || _IDs == "")
                return;
            string strSql = @"insert into UNISemesterStoppedStudent
  (SemesterID,StudentID,UsrIns,TimIns)
SELECT " + _CurrentSemester+@" AS Semester, StudentID,"+SysData.CurrentUser.ID+@" as as UsrIns1,GetDate() as TimIns1
  FROM     dbo.UNIStudent
WHERE  (ISNULL(StudentStatus, 1) = 1) AND (StudentFaculty = "+SysData.FacultyID+@") AND (StudentID IN ("+_IDs+"))";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public void EnableStudent()
        {
            if (_CurrentSemester == 0 || _IDs == null || _IDs == "")
                return;
            string strSql = @"update UNISemesterStoppedStudent set Dis = GetDate() 
   from UNISemesterStoppedStudent
   inner join UNIStudent on UNISemesterStoppedStudent.StudentID = UNIStudent.StudentID
   WHERE UNISemesterStoppedStudent.SemesterID="+_CurrentSemester+@" and  (ISNULL(StudentStatus, 1) = 1) AND (StudentFaculty = " + SysData.FacultyID + @") AND (UNIStudent.StudentID IN (" + _IDs + "))";

            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);


        }
        public DataTable GetStoppedStudent()
        {
            string strSql = @"SELECT dbo.UNISemesterStoppedStudent.StudentID
FROM     dbo.UNISemesterStoppedStudent INNER JOIN
                  dbo.UNIStudent ON dbo.UNISemesterStoppedStudent.StudentID = dbo.UNIStudent.StudentID
WHERE  (dbo.UNISemesterStoppedStudent.SemesterID ="+_CurrentSemester+@") AND (dbo.UNISemesterStoppedStudent.Dis IS NULL) AND (dbo.UNIStudent.StudentFaculty = "+SysData.FacultyID+")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}