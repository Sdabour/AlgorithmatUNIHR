using SharpVision.SystemBase;
using System;
using System.Data;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class LectureDb
    {

        #region Constructor
        public LectureDb()
        {
        }
        public LectureDb(DataRow objDr)
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
        int _Type;
        public int Type
        {
            set => _Type = value;
            get => _Type;
        }
        int _Course;
        public int Course
        {
            set => _Course = value;
            get => _Course;
        }
        int _Semester;
        public int Semester
        {
            set => _Semester = value;
            get => _Semester;
        }
        int _Teacher;
        public int Teacher
        {
            set => _Teacher = value;
            get => _Teacher;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        DateTime _StartTime;
        public DateTime StartTime
        {
            set => _StartTime = value;
            get => _StartTime;
        }
        DateTime _EndTime;
        public DateTime EndTime
        {
            set => _EndTime = value;
            get => _EndTime;
        }
        double _BreakDurationInMinutes;
        public double BreakDurationInMinutes
        {
            set => _BreakDurationInMinutes = value;
            get => _BreakDurationInMinutes;
        }
        bool _Scheduled;
        public bool Scheduled
        {
            set => _Scheduled = value;
            get => _Scheduled;
        }
        bool _AttendanceMandatory;
        public bool AttendanceMandatory
        {
            set => _AttendanceMandatory = value;
            get => _AttendanceMandatory;
        }
        string _Note;
        public string Note
        {
            set => _Note = value;
            get => _Note;
        }
        int _Hall;
        public int Hall
        {
            set => _Hall = value;
            get => _Hall;
        }
        string _GUUID;
        public string GUUID
        {
            set => _GUUID = value;
            get => _GUUID;
        }
        int _CourseID;
        public int CourseID
        {
            set => _CourseID = value;
            get => _CourseID;
        }
        int _CourseFaculty;
        public int CourseFaculty
        {
            set => _CourseFaculty = value;
            get => _CourseFaculty;
        }
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
        int _CourseCreditHour;
        public int CourseCreditHour
        {
            set => _CourseCreditHour = value;
            get => _CourseCreditHour;
        }
        int _CourseSemesterWorkDegree;
        public int CourseSemesterWorkDegree
        {
            set => _CourseSemesterWorkDegree = value;
            get => _CourseSemesterWorkDegree;
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
        int _SemesterType;
        public int SemesterType
        {
            set => _SemesterType = value;
            get => _SemesterType;
        }
        int _TypeID;
        public int TypeID
        {
            set => _TypeID = value;
            get => _TypeID;
        }
        string _TypeCode;
        public string TypeCode
        {
            set => _TypeCode = value;
            get => _TypeCode;
        }
        string _TypeNameA;
        public string TypeNameA
        {
            set => _TypeNameA = value;
            get => _TypeNameA;
        }
        string _TypeNameE;
        public string TypeNameE
        {
            set => _TypeNameE = value;
            get => _TypeNameE;
        }
        int _TeacherID;
        public int TeacherID
        {
            set => _TeacherID = value;
            get => _TeacherID;
        }
        string _TeacherCode;
        public string TeacherCode
        {
            set => _TeacherCode = value;
            get => _TeacherCode;
        }
        string _TeacherName;
        public string TeacherName
        {
            set => _TeacherName = value;
            get => _TeacherName;
        }
        int _LeactureTeacherStatus;
        public int LeactureTeacherStatus
        {
            set => _LeactureTeacherStatus = value;
            get => _LeactureTeacherStatus;
        }
        bool _IsDateRange;
        public bool IsDateRange { set => _IsDateRange = value; get => _IsDateRange; }
        DateTime _StartDate;
        public DateTime StartDate { set => _StartDate = value; get => _StartDate; }
        DateTime _EndDate;
        public DateTime EndDate { set => _EndDate = value; get => _EndDate; }
        public string AddStr
        {
            get
            {
                _GUUID = Guid.NewGuid().ToString();
                string Returned = " insert into UNILecture (LectureType,LectureCourse,LectureSemester,LectureTeacher,LectureDate,LectureStartTime,LectureEndTime,LectureBreakDurationInMinutes,LectureScheduled,LectureAttendanceMandatory,LectureNote,LectureHall,LectureGUUID,UsrIns,TimIns) values (" + Type + "," + Course + "," + Semester + "," + Teacher + "," + (Date.Date.ToOADate() - 2).ToString() + "," + (StartTime.ToOADate() - 2).ToString() + "," + (EndTime.ToOADate() - 2).ToString() + "," + BreakDurationInMinutes + "," + (Scheduled ? 1 : 0) + "," + (AttendanceMandatory ? 1 : 0) + ",'" + Note + "'," + Hall + ",'" + GUUID + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNILeacture set " + "LectureID=" + ID + "" +
           ",LectureType=" + Type + "" +
           ",LectureCourse=" + Course + "" +
           ",LectureSemester=" + Semester + "" +
           ",LectureTeacher=" + Teacher + "" +
           ",LectureDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",LectureStartTime=" + (StartTime.ToOADate() - 2).ToString() + "" +
           ",LectureEndTime=" + (EndTime.ToOADate() - 2).ToString() + "" +
           ",LectureBreakDurationInMinutes=" + BreakDurationInMinutes + "" +
           ",LectureScheduled=" + (Scheduled ? 1 : 0) + "" +
           ",LectureAttendanceMandatory=" + (AttendanceMandatory ? 1 : 0) + "" +
           ",LectureNote='" + Note + "'" +
           ",LectureHall=" + Hall + "" +
           ",LectureGUUID='" + GUUID + "'" +
           ",LectureCourseID=" + CourseID + "" +
           ",LectureCourseFaculty=" + CourseFaculty + "" +
           ",LectureCourseCode='" + CourseCode + "'" +
           ",LectureCourseNameA='" + CourseNameA + "'" +
           ",LectureCourseNameE='" + CourseNameE + "'" +
           ",LectureCourseCreditHour=" + CourseCreditHour + "" +
           ",LectureCourseSemesterWorkDegree=" + CourseSemesterWorkDegree + "" +
           ",LectureSemesterID=" + SemesterID + "" +
           ",LectureSemesterDesc='" + SemesterDesc + "'" +
           ",LectureSemesterType=" + SemesterType + "" +
           ",LectureTypeID=" + TypeID + "" +
           ",LectureTypeCode='" + TypeCode + "'" +
           ",LectureTypeNameA='" + TypeNameA + "'" +
           ",LectureTypeNameE='" + TypeNameE + "'" +
           ",LectureTeacherID=" + TeacherID + "" +
           ",LectureTeacherCode='" + TeacherCode + "'" +
           ",LectureTeacherName='" + TeacherName + "'" +
           ",LeactureTeacherStatus=" + LeactureTeacherStatus + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNILeacture set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.UNILecture.LectureID, dbo.UNILecture.LectureType, dbo.UNILecture.LectureCourse, dbo.UNILecture.LectureSemester, dbo.UNILecture.LectureTeacher, dbo.UNILecture.LectureDate, dbo.UNILecture.LectureStartTime, 
                                    dbo.UNILecture.LectureEndTime, dbo.UNILecture.LectureBreakDurationInMinutes, dbo.UNILecture.LectureScheduled, dbo.UNILecture.LectureAttendanceMandatory, dbo.UNILecture.LectureNote, dbo.UNILecture.LectureHall, 
                                    dbo.UNILecture.LectureGUUID, dbo.UNICourse.CourseID AS LectureCourseID, dbo.UNICourse.CourseFaculty AS LectureCourseFaculty, dbo.UNICourse.CourseCode AS LectureCourseCode, 
                                    dbo.UNICourse.CourseNameA AS LectureCourseNameA, dbo.UNICourse.CourseNameE AS LectureCourseNameE, dbo.UNICourse.CourseCreditHour AS LectureCourseCreditHour, 
                                    dbo.UNICourse.CourseSemesterWorkDegree AS LectureCourseSemesterWorkDegree, dbo.UNISemester.SemesterID AS LectureSemesterID, dbo.UNISemester.SemesterDesc AS LectureSemesterDesc, 
                                    dbo.UNISemester.SemesterType AS LectureSemesterType, dbo.UNILectureType.LectureTypeID, dbo.UNILectureType.LectureTypeCode, dbo.UNILectureType.LectureTypeNameA, dbo.UNILectureType.LectureTypeNameE, 
                                    TeacherTable.ApplicantID AS LectureTeacherID, TeacherTable.ApplicantCode AS LectureTeacherCode, TeacherTable.ApplicantFirstName AS LectureTeacherName, 
                                    TeacherTable.ApplicantStatusID AS LeactureTeacherStatus
                  FROM      dbo.UNILecture INNER JOIN
                                    dbo.UNILectureType ON dbo.UNILecture.LectureType = dbo.UNILectureType.LectureTypeID INNER JOIN
                                    dbo.UNISemester ON dbo.UNILecture.LectureSemester = dbo.UNISemester.SemesterID INNER JOIN
                                    dbo.UNICourse ON dbo.UNILecture.LectureCourse = dbo.UNICourse.CourseID LEFT OUTER JOIN
                                        (SELECT dbo.HRApplicant.ApplicantID, dbo.HRApplicantWorker.ApplicantCode, dbo.HRApplicant.ApplicantFirstName, dbo.HRApplicantWorker.ApplicantStatusID
                                         FROM      dbo.HRApplicant INNER JOIN
                                                           dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID) AS TeacherTable ON dbo.UNILecture.LectureTeacher = TeacherTable.ApplicantID";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["LectureID"] != null)
                int.TryParse(objDr["LectureID"].ToString(), out _ID);

            if (objDr.Table.Columns["LectureType"] != null)
                int.TryParse(objDr["LectureType"].ToString(), out _Type);

            if (objDr.Table.Columns["LectureCourse"] != null)
                int.TryParse(objDr["LectureCourse"].ToString(), out _Course);

            if (objDr.Table.Columns["LectureSemester"] != null)
                int.TryParse(objDr["LectureSemester"].ToString(), out _Semester);

            if (objDr.Table.Columns["LectureTeacher"] != null)
                int.TryParse(objDr["LectureTeacher"].ToString(), out _Teacher);

            if (objDr.Table.Columns["LectureDate"] != null)
                DateTime.TryParse(objDr["LectureDate"].ToString(), out _Date);

            if (objDr.Table.Columns["LectureStartTime"] != null)
                DateTime.TryParse(objDr["LectureStartTime"].ToString(), out _StartTime);

            if (objDr.Table.Columns["LectureEndTime"] != null)
                DateTime.TryParse(objDr["LectureEndTime"].ToString(), out _EndTime);

            if (objDr.Table.Columns["LectureBreakDurationInMinutes"] != null)
                double.TryParse(objDr["LectureBreakDurationInMinutes"].ToString(), out _BreakDurationInMinutes);

            if (objDr.Table.Columns["LectureScheduled"] != null)
                bool.TryParse(objDr["LectureScheduled"].ToString(), out _Scheduled);

            if (objDr.Table.Columns["LectureAttendanceMandatory"] != null)
                bool.TryParse(objDr["LectureAttendanceMandatory"].ToString(), out _AttendanceMandatory);

            if (objDr.Table.Columns["LectureNote"] != null)
                _Note = objDr["LectureNote"].ToString();

            if (objDr.Table.Columns["LectureHall"] != null)
                int.TryParse(objDr["LectureHall"].ToString(), out _Hall);

            if (objDr.Table.Columns["LectureGUUID"] != null)
                _GUUID = objDr["LectureGUUID"].ToString();

            if (objDr.Table.Columns["LectureCourseID"] != null)
                int.TryParse(objDr["LectureCourseID"].ToString(), out _CourseID);

            if (objDr.Table.Columns["LectureCourseFaculty"] != null)
                int.TryParse(objDr["LectureCourseFaculty"].ToString(), out _CourseFaculty);

            if (objDr.Table.Columns["LectureCourseCode"] != null)
                _CourseCode = objDr["LectureCourseCode"].ToString();

            if (objDr.Table.Columns["LectureCourseNameA"] != null)
                _CourseNameA = objDr["LectureCourseNameA"].ToString();

            if (objDr.Table.Columns["LectureCourseNameE"] != null)
                _CourseNameE = objDr["LectureCourseNameE"].ToString();

            if (objDr.Table.Columns["LectureCourseCreditHour"] != null)
                int.TryParse(objDr["LectureCourseCreditHour"].ToString(), out _CourseCreditHour);

            if (objDr.Table.Columns["LectureCourseSemesterWorkDegree"] != null)
                int.TryParse(objDr["LectureCourseSemesterWorkDegree"].ToString(), out _CourseSemesterWorkDegree);

            if (objDr.Table.Columns["LectureSemesterID"] != null)
                int.TryParse(objDr["LectureSemesterID"].ToString(), out _SemesterID);

            if (objDr.Table.Columns["LectureSemesterDesc"] != null)
                _SemesterDesc = objDr["LectureSemesterDesc"].ToString();

            if (objDr.Table.Columns["LectureSemesterType"] != null)
                int.TryParse(objDr["LectureSemesterType"].ToString(), out _SemesterType);

            if (objDr.Table.Columns["LectureTypeID"] != null)
                int.TryParse(objDr["LectureTypeID"].ToString(), out _TypeID);

            if (objDr.Table.Columns["LectureTypeCode"] != null)
                _TypeCode = objDr["LectureTypeCode"].ToString();

            if (objDr.Table.Columns["LectureTypeNameA"] != null)
                _TypeNameA = objDr["LectureTypeNameA"].ToString();

            if (objDr.Table.Columns["LectureTypeNameE"] != null)
                _TypeNameE = objDr["LectureTypeNameE"].ToString();

            if (objDr.Table.Columns["LectureTeacherID"] != null)
                int.TryParse(objDr["LectureTeacherID"].ToString(), out _TeacherID);

            if (objDr.Table.Columns["LectureTeacherCode"] != null)
                _TeacherCode = objDr["LectureTeacherCode"].ToString();

            if (objDr.Table.Columns["LectureTeacherName"] != null)
                _TeacherName = objDr["LectureTeacherName"].ToString();

            if (objDr.Table.Columns["LeactureTeacherStatus"] != null)
                int.TryParse(objDr["LeactureTeacherStatus"].ToString(), out _LeactureTeacherStatus);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            ID = SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
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
            string strSql = SearchStr + " where UNILecture.Dis is null ";

            if (ID != 0)
                strSql += " and dbo.UNILecture.LectureID ="+_ID;
            if (_CourseFaculty != 0)
                strSql += " and dbo.UNICourse.CourseFaculty="+_CourseFaculty;
            if (_Type != 0)
                strSql += " and dbo.UNILecture.LectureType="+_Type;
            if (_Semester != 0)
                strSql += " and dbo.UNILecture.LectureSemester="+_Semester;
            if (_Course != 0)
                strSql += " and dbo.UNILecture.LectureCourse="+_Course;
            if (_Teacher != 0)
                strSql += " and dbo.UNILecture.LectureTeacher="+_Teacher;
            if (_IsDateRange)
                strSql += @" and dbo.UNILecture.LectureDate
>="+(_StartDate.Date.ToOADate()-2)+ @" and dbo.UNILecture.LectureDate
<"+(_EndDate.Date.ToOADate()-1);
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetRegisteration()
        {
            if (_ID == 0)
                return new DataTable();
            string strRegisteration = @"SELECT dbo.UNIRegisteration.RegisterationID AS LectureRegisteration
FROM dbo.UNILecture INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNILecture.LectureCourse = dbo.UNIRegisteration.RegisterationCourse AND dbo.UNILecture.LectureSemester = dbo.UNIRegisteration.RegisterationSemester
WHERE(dbo.UNILecture.LectureID = "+_ID+")";
            string strSql = @"select RegisterationTable.* from ("+new RegisterationDb() { Faculty=CourseFaculty}.BaseSearchStr+@") as RegisterationTable inner join ("+strRegisteration+ @") as SelectedRegisterationTable on  RegisterationTable.RegisterationID = SelectedRegisterationTable.LectureRegisteration ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}