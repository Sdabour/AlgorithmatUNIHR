using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class ExamDb
    {

        #region Constructor
        public ExamDb()
        {
        }
        public ExamDb(DataRow objDr)
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
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        DateTime _StartTime;
        public DateTime StartTime { set => _StartTime = value; get => _StartTime; }
        DateTime _EndTime;
        public DateTime EndTime { set => _EndTime = value; get => _EndTime; }

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
        int _Type;
        public int Type
        {
            set => _Type = value;
            get => _Type;
        }
        int _Grade;
        public int Grade
        {
            set => _Grade = value;
            get => _Grade;
        }
        int _SemesterID;
        public int SemesterID
        {
            set => _SemesterID = value;
            get => _SemesterID;
        }
        string _SemesterDesc;
        public string SemesterDesc
        {
            set => _SemesterDesc = value;
            get => _SemesterDesc;
        }
        int _CourseID;
        public int CourseID
        {
            set => _CourseID = value;
            get => _CourseID;
        }
        int _Level;
        public int Level { set => _Level=value; }
        int _CourseFaculty;
        public int CourseFaculty
        {
            set => _CourseFaculty = value;
            get => _CourseFaculty;
        }
        string _CourseIDs;
        public string CourseIDs { set => _CourseIDs = value; }
        string _CourseCode;
        public string CourseCode
        {
            set => _CourseCode = value;
            get => _CourseCode;
        }
        string _CourseNameA;
        public string CourseNameA
        {
            set => _CourseNameA = value;
            get => _CourseNameA;
        }
        string _CourseNameE;
        public string CourseNameE
        {
            set => _CourseNameE = value;
            get => _CourseNameE;
        }

        int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        bool _SelectedOnly;
        public bool SelectedOnly { set => _SelectedOnly = value; }
        int _HallID;
        public int HallID { get => _HallID; }
        string _HallName;
        public string HallName { get => _HallName; }
        int _User;
        public int User { set => _User = value;
            get => _User == 0 ? SysData.CurrentUser.ID : _User;
        }
        DataTable _StudentDegreeTable;
        public DataTable StudentDegreeTable { set => _StudentDegreeTable=value; }
        DataTable _ExamTable;
        public DataTable ExamTable { set => _ExamTable = value; }
        DataTable _GroupTable;
        public DataTable GroupTable { set => _GroupTable = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIExam (ExamDesc,ExamDate,ExamSemester,ExamCourse,ExamType,ExamGrade,UsrIns,TimIns) values ('" + Desc + "'," + (Date.ToOADate() - 2).ToString() + "," + Semester + "," + Course + "," + Type + "," + Grade + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string AddUniqueStr
        {
            get
            {
                string strExamDegree = @"CASE WHEN "+_Type+@" = 1 THEN CourseMidtermDegree WHEN "+_Type+" = 2 THEN CourseSemesterWorkDegree WHEN "+_Type+@" = 4 THEN CoursePracticalDegree WHEN "+_Type+@" = 3 THEN CourseOralDegree WHEN "+_Type+ @" = 5 THEN CourseFinalDegree 
 when "+_Type+@"=6 then CourseClinicalDegree 
ELSE 0 END ";
                string Returned = @" insert into UNIExam (ExamDesc,ExamDate,ExamSemester,ExamCourse,ExamType,ExamGrade,ExamStartTime,ExamEndTime,UsrIns,TimIns) 
                  select '" + Desc + "' as ExmDesc," + (Date.ToOADate() - 2).ToString() + " as ExamDate," + Semester + " as SemesterDate," + Course + " as SemesterCourse," + Type + " as SemesterType," + strExamDegree + " as SemesterGrade,"+ (_StartTime.ToOADate()-2).ToString()+" as EXamStartTime,"+ (_EndTime.ToOADate() - 2).ToString() + " as ExamEndTime," + User + @" as SemeseterUser,GetDate() as TimIns  
              FROM     dbo.UNICourse LEFT OUTER JOIN
                      (SELECT ExamCourse
                       FROM      dbo.UNIExam
                       WHERE   (ExamSemester = "+_Semester+@") AND (ExamCourse = "+_Course+@") AND (ExamType = "+_Type+@")) AS derivedtbl_1 ON dbo.UNICourse.CourseID = derivedtbl_1.ExamCourse
WHERE  (dbo.UNICourse.CourseID = "+_Course+ @") and "+strExamDegree+@"<>0  AND (derivedtbl_1.ExamCourse IS NULL) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIExam set ExamDesc='" + Desc + "'" +
           ",ExamDate=" + (Date.Date.ToOADate() - 2).ToString() + ",ExamStartTime="+(_StartTime.AddHours(2).ToOADate()-2)+", ExamEndTime="+(_EndTime.AddHours(2).ToOADate()-2)
           +@",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ExamID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIExam set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {

                string Returned = @" SELECT dbo.UNIExam.ExamID, dbo.UNIExam.ExamDesc, dbo.UNIExam.ExamDate, dbo.UNIExam.ExamSemester, dbo.UNIExam.ExamCourse, dbo.UNIExam.ExamType, dbo.UNIExam.ExamGrade, 
              dbo.UNIExam.ExamStartTime,dbo.UNIExam.ExamEndTime,                      dbo.UNISemester.SemesterID AS ExamSemesterID, dbo.UNISemester.SemesterDesc AS ExamSemesterDesc, dbo.UNICourse.CourseID AS ExamCourseID, dbo.UNICourse.CourseFaculty AS ExamCourseFaculty, dbo.UNICourse.CourseCode AS ExamCourseCode, 
                                    dbo.UNICourse.CourseNameA AS ExamCourseNameA, dbo.UNICourse.CourseNameE AS ExamCourseNameE,UNIHall.HallID as ExamHallID,UNIHall.HallName as ExamHallName
                  FROM      dbo.UNIExam INNER JOIN
                                    dbo.UNISemester ON dbo.UNIExam.ExamSemester = dbo.UNISemester.SemesterID INNER JOIN
                                    dbo.UNICourse ON dbo.UNIExam.ExamCourse = dbo.UNICourse.CourseID 
 left outer join UNIHall on UNIExam.ExamHall = UNIHall.HallID ";
                if (_SelectedOnly)
                    Returned += " inner join VUNISelectedExam on UNIExam.ExamID = VUNISelectedExam.ExamID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ExamID"] != null)
                int.TryParse(objDr["ExamID"].ToString(), out _ID);

            if (objDr.Table.Columns["ExamDesc"] != null)
                _Desc = objDr["ExamDesc"].ToString();

            if (objDr.Table.Columns["ExamDate"] != null)
                DateTime.TryParse(objDr["ExamDate"].ToString(), out _Date);

            if (objDr.Table.Columns["ExamStartTime"] != null)
                DateTime.TryParse(objDr["ExamStartTime"].ToString(), out _StartTime);
            if (objDr.Table.Columns["ExamEndTime"] != null)
                DateTime.TryParse(objDr["ExamEndTime"].ToString(), out _EndTime);
            if (objDr.Table.Columns["ExamSemester"] != null)
                int.TryParse(objDr["ExamSemester"].ToString(), out _Semester);

            if (objDr.Table.Columns["ExamCourse"] != null)
                int.TryParse(objDr["ExamCourse"].ToString(), out _Course);

            if (objDr.Table.Columns["ExamType"] != null)
                int.TryParse(objDr["ExamType"].ToString(), out _Type);

            if (objDr.Table.Columns["ExamGrade"] != null)
                int.TryParse(objDr["ExamGrade"].ToString(), out _Grade);

            if (objDr.Table.Columns["ExamSemesterID"] != null)
                int.TryParse(objDr["ExamSemesterID"].ToString(), out _SemesterID);

            if (objDr.Table.Columns["ExamSemesterDesc"] != null)
                _SemesterDesc = objDr["ExamSemesterDesc"].ToString();

            if (objDr.Table.Columns["ExamCourseID"] != null)
                int.TryParse(objDr["ExamCourseID"].ToString(), out _CourseID);
            if (objDr.Table.Columns["ExamCourseFaculty"] != null)
                int.TryParse(objDr["ExamCourseFaculty"].ToString(), out _CourseFaculty);
            if (objDr.Table.Columns["ExamCourseCode"] != null)
                _CourseCode = objDr["ExamCourseCode"].ToString();

            if (objDr.Table.Columns["ExamCourseNameA"] != null)
                _CourseNameA = objDr["ExamCourseNameA"].ToString();

            if (objDr.Table.Columns["ExamCourseNameE"] != null)
                _CourseNameE = objDr["ExamCourseNameE"].ToString();
            if (objDr.Table.Columns["ExamHallName"] != null)
                _HallName = objDr["ExamHallName"].ToString();
            if (objDr.Table.Columns["ExamHallID"] != null)
                int.TryParse(objDr["ExamHallID"].ToString(), out _HallID);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void AddUnique()
        {
                  ID= SysData.SharpVisionBaseDb.InsertIdentityTable(AddUniqueStr);

        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinGroup();
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where dbo.UNIExam.Dis is null ";
            if(_ID!= 0)
            {
                strSql += " and UNIExam.ExamStatus = 0 and UNIExam.ExamID = "+_ID;
            }
            if (Semester != 0)
                strSql += " and dbo.UNIExam.ExamSemester = "+_Semester;
            if (_CourseID != 0)
                strSql += " and dbo.UNIExam.ExamCourse ="+_CourseID;
            if (_CourseIDs != null&& _CourseIDs!= "")
                strSql += " and dbo.UNIExam.ExamCourse in(" + _CourseIDs+")";
            if (_Type != 0)
                strSql += " and dbo.UNIExam.ExamType ="+_Type;
            if (Status != 0)
                strSql += " and UNIExam.ExamStatus = 0 ";
            if(_Level!=0)
            { strSql += " and UNICourse.CourseRecommendedGrade="+_Level; }
            if (_CourseFaculty != 0)
            { strSql += " and UNICourse.CourseFaculty=" + _CourseFaculty; }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void UploadExamRegisterationExcel()
        {
            if (_ID == 0 || _StudentDegreeTable == null || _StudentDegreeTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table UNITempStudentExam");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "UNITempStudentExam";
            objCopy.WriteToServer(_StudentDegreeTable);
            string strSql = "";
            strSql = @"update  dbo.UNIRegisterationExam set RegisterationExamDegree= dbo.UNITempStudentExam.Degree, dbo.UNIRegisterationExam.RegisterationExamNote= dbo.UNITempStudentExam.Note, dbo.UNIRegisterationExam.RegisterationExamStatus= 
                  dbo.UNITempStudentExam.Status, dbo.UNIRegisterationExam.UsrUpd="+SysData.CurrentUser.ID+@", dbo.UNIRegisterationExam.TimUpd =GetDate()
  FROM     dbo.UNITempStudentExam INNER JOIN
                      (SELECT dbo.UNIExam.ExamID, dbo.UNIStudent.StudentID, dbo.UNIRegisteration.RegisterationID, dbo.UNIStudent.StudentCode, dbo.UNICourse.CourseCode, ISNULL(dbo.UNIStudent.StudentStatus, 0) AS StudentStatus
                       FROM      dbo.UNIRegisteration INNER JOIN
                                         dbo.UNIExam ON dbo.UNIRegisteration.RegisterationSemester = dbo.UNIExam.ExamSemester AND dbo.UNIRegisteration.RegisterationCourse = dbo.UNIExam.ExamCourse INNER JOIN
                                         dbo.UNIStudent ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudent.StudentID INNER JOIN
                                         dbo.UNICourse ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICourse.CourseID
                       WHERE   (dbo.UNIExam.ExamID = 1) AND (ISNULL(dbo.UNIStudent.StudentStatus, 0) <= 1)) AS derivedtbl_1 ON dbo.UNITempStudentExam.Code = derivedtbl_1.StudentCode INNER JOIN
                  dbo.UNIExam AS UNIExam_1 ON derivedtbl_1.ExamID = UNIExam_1.ExamID INNER JOIN
                  dbo.UNIRegisterationExam ON derivedtbl_1.RegisterationID = dbo.UNIRegisterationExam.RegisterationExamRegisteration AND derivedtbl_1.ExamID = dbo.UNIRegisterationExam.RegisterationExamExam ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql=@"insert into UNIRegisterationExam
(RegisterationExamRegisteration, RegisterationExamExam, RegisterationExamGrade, RegisterationExamDegree, RegisterationExamNote, RegisterationExamDate, RegisterationExamEvaluationEmployee, 
                  RegisterationExamEvaluationUsr, RegisterationExamStatus, UsrIns,TimIns
)
SELECT derivedtbl_1.RegisterationID, derivedtbl_1.ExamID, UNIExam_1.ExamGrade, dbo.UNITempStudentExam.Degree, dbo.UNITempStudentExam.Note, UNIExam_1.ExamDate, 0 AS EVEmployee, "+SysData.CurrentUser.ID+ @" AS EVUser, dbo.UNITempStudentExam.Status AS ExamStatus, " + SysData.CurrentUser.ID+@" AS UsrIns, 
                  GETDATE() AS TimIns
FROM     dbo.UNITempStudentExam INNER JOIN
                      (SELECT dbo.UNIExam.ExamID, dbo.UNIStudent.StudentID, dbo.UNIRegisteration.RegisterationID, dbo.UNIStudent.StudentCode, dbo.UNICourse.CourseCode, ISNULL(dbo.UNIStudent.StudentStatus, 0) AS StudentStatus
                       FROM      dbo.UNIRegisteration INNER JOIN
                                         dbo.UNIExam ON dbo.UNIRegisteration.RegisterationSemester = dbo.UNIExam.ExamSemester AND dbo.UNIRegisteration.RegisterationCourse = dbo.UNIExam.ExamCourse INNER JOIN
                                         dbo.UNIStudent ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudent.StudentID INNER JOIN
                                         dbo.UNICourse ON dbo.UNIRegisteration.RegisterationCourse = dbo.UNICourse.CourseID
                       WHERE   (dbo.UNIExam.ExamID = "+_ID+@") AND (ISNULL(dbo.UNIStudent.StudentStatus, 0) <= 1)) AS derivedtbl_1 ON dbo.UNITempStudentExam.Code = derivedtbl_1.StudentCode INNER JOIN
                  dbo.UNIExam AS UNIExam_1 ON derivedtbl_1.ExamID = UNIExam_1.ExamID LEFT OUTER JOIN
                  dbo.UNIRegisterationExam ON derivedtbl_1.RegisterationID = dbo.UNIRegisterationExam.RegisterationExamRegisteration AND derivedtbl_1.ExamID = dbo.UNIRegisterationExam.RegisterationExamExam
WHERE  (dbo.UNIRegisterationExam.RegisterationExamID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void JoinGroup()
        {
            if (_GroupTable == null || _GroupTable.Rows.Count == 0)
                return;

            string strSql = "delete from UNIExamGroupTemp where UserID = "+User;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName="UNIExamGroupTemp";
            objCopy.WriteToServer(_GroupTable);
            strSql = "delete from UNIExamGroup where ExamID="+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into UNIExamGroup (ExamID,GroupID,HallID)
    select "+_ID+ @" as ExamID1,GroupID,HallID from 
 UNIExamGroupTemp where UserID = "+User;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}