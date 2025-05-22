using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class RegisterationGroupDb
    {

        #region Constructor
        public RegisterationGroupDb()
        {
        }
        public RegisterationGroupDb(DataRow objDr)
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
        public int Faculty
        {
            set => _Faculty = value;
            get => _Faculty;
        }
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
        int _CourseLevel;
        public int CourseLevel { set => _CourseLevel = value; get => _CourseLevel; }
        int _LectureType;
        public int LectureType
        {
            set => _LectureType = value;
            get => _LectureType;
        }
        int _FacultyID;
        public int FacultyID
        {
            set => _FacultyID = value;
            get => _FacultyID;
        }
        string _FacultyNameA;
        public string FacultyNameA
        {
            set => _FacultyNameA = value;
            get => _FacultyNameA;
        }
        string _FacultyNameE;
        public string FacultyNameE
        {
            set => _FacultyNameE = value;
            get => _FacultyNameE;
        }
        int _CourseID;
        public int CourseID
        {
            set => _CourseID = value;
            get => _CourseID;
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
        int _LectureTypeID;
        public int LectureTypeID
        {
            set => _LectureTypeID = value;
            get => _LectureTypeID;
        }
        int _ExamType;
        public int ExamType { set => _ExamType = value; get => _ExamType ; }
        string _LectureTypeCode;
        public string LectureTypeCode
        {
            set => _LectureTypeCode = value;
            get => _LectureTypeCode;
        }
        string _LectureTypeNameA;
        public string LectureTypeNameA
        {
            set => _LectureTypeNameA = value;
            get => _LectureTypeNameA;
        }
        string _LectureTypeNameE;
        public string LectureTypeNameE
        {
            set => _LectureTypeNameE = value;
            get => _LectureTypeNameE;
        }
        string _RegisterationIDs;
        public string RegisterationIDs { set => _RegisterationIDs = value; }
        int _User;
        public int User { set => _User = value;
            get => _User == 0 ? SysData.CurrentUser.ID:_User; }
        string _IDs;
        public string IDs { set => _IDs=value; }
        int _GroupID;
        public int GroupID { set => _GroupID = value; get => _GroupID; }
        int _HallID;
        public int HallID { set => _HallID = value; get => _HallID; }
        string _HallName;
        public string HallName { set => _HallName = value; get => _HallName; }
        string _ExamIDs;
        public string ExamIDs { set => _ExamIDs = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIGroup (GroupID,GroupFaculty,GroupCode,GroupNameA,GroupNameE,GroupSemester,GroupCourse,GroupLectureType,GroupFacultyID,GroupFacultyNameA,GroupFacultyNameE,GroupCourseID,GroupCourseCode,GroupCourseNameA,GroupCourseNameE,GroupSemesterID,GroupSemesterDesc,GroupLectureTypeID,GroupLectureTypeCode,GroupLectureTypeNameA,GroupLectureTypeNameE,UsrIns,TimIns) values (," + ID + "," + Faculty + ",'" + Code + "','" + NameA + "','" + NameE + "'," + Semester + "," + Course + "," + LectureType + "," + FacultyID + ",'" + FacultyNameA + "','" + FacultyNameE + "'," + CourseID + ",'" + CourseCode + "','" + CourseNameA + "','" + CourseNameE + "'," + SemesterID + ",'" + SemesterDesc + "'," + LectureTypeID + ",'" + LectureTypeCode + "','" + LectureTypeNameA + "','" + LectureTypeNameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIGroup set " + "GroupID=" + ID + "" +
           ",GroupFaculty=" + Faculty + "" +
           ",GroupCode='" + Code + "'" +
           ",GroupNameA='" + NameA + "'" +
           ",GroupNameE='" + NameE + "'" +
           ",GroupSemester=" + Semester + "" +
           ",GroupCourse=" + Course + "" +
           ",GroupLectureType=" + LectureType + "" +
           ",GroupFacultyID=" + FacultyID + "" +
           ",GroupFacultyNameA='" + FacultyNameA + "'" +
           ",GroupFacultyNameE='" + FacultyNameE + "'" +
           ",GroupCourseID=" + CourseID + "" +
           ",GroupCourseCode='" + CourseCode + "'" +
           ",GroupCourseNameA='" + CourseNameA + "'" +
           ",GroupCourseNameE='" + CourseNameE + "'" +
           ",GroupSemesterID=" + SemesterID + "" +
           ",GroupSemesterDesc='" + SemesterDesc + "'" +
           ",GroupLectureTypeID=" + LectureTypeID + "" +
           ",GroupLectureTypeCode='" + LectureTypeCode + "'" +
           ",GroupLectureTypeNameA='" + LectureTypeNameA + "'" +
           ",GroupLectureTypeNameE='" + LectureTypeNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIGroup set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string AddUniqueStr
        {
            get
            {
                if (_LectureType != 3&&_LectureType>0)
                    _ExamType = 0;
                if (_LectureType == 0 && _ExamType > 0)
                    _LectureType = 3;
                string strExistGroup = @"SELECT GroupID
FROM     dbo.UNIGroup
WHERE  (GroupFaculty = "+_Faculty+@") AND (GroupNameA = '"+_NameA+@"') AND (GroupSemester = "+_Semester+@") AND (GroupCourse = "+_Course+@") AND (GroupLectureType = "+_LectureType+ @") and (GroupExamType="+_ExamType+")";
                string strFromClause = @"
 FROM     dbo.UNICourse 
WHERE  (dbo.UNICourse.CourseID = "+_Course+@") AND not exists ("+strExistGroup+") ";
                string Returned = @" insert into UNIGroup (GroupFaculty,GroupCode,GroupNameA,GroupNameE,GroupSemester,GroupCourse,GroupLectureType,GroupExamType,UsrIns,TimIns) 
                   select " + Faculty + " as Faculty1,'" + Code + "' as Code1,'" + NameA + "' as NameA1,'" + NameE + "' as NameE1," + Semester + " as Semester1," + Course + " as Course1," + LectureType + " as LectureType1,"+_ExamType +@" as ExamType1," + User + " as UsrIns1,GetDate()  as TimIns1 "+strFromClause;
                Returned += @"
 "+strExistGroup;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.UNIGroup.GroupID, dbo.UNIGroup.GroupFaculty, dbo.UNIGroup.GroupCode, dbo.UNIGroup.GroupNameA, dbo.UNIGroup.GroupNameE, dbo.UNIGroup.GroupSemester, dbo.UNIGroup.GroupCourse, 
                                    dbo.UNIGroup.GroupLectureType,dbo.UNIGroup.GroupExamType, dbo.UNIFaculty.FacultyID AS GroupFacultyID, dbo.UNIFaculty.FacultyNameA AS GroupFacultyNameA, dbo.UNIFaculty.FacultyNameE AS GroupFacultyNameE, 
                                    dbo.UNICourse.CourseID AS GroupCourseID, dbo.UNICourse.CourseCode AS GroupCourseCode, dbo.UNICourse.CourseNameA AS GroupCourseNameA, dbo.UNICourse.CourseNameE AS GroupCourseNameE, UNICourse.CourseRecommendedGrade as GroupCourseLevel ,
                                    dbo.UNISemester.SemesterID AS GroupSemesterID, dbo.UNISemester.SemesterDesc AS GroupSemesterDesc, dbo.UNILectureType.LectureTypeID AS GroupLectureTypeID, 
                                    dbo.UNILectureType.LectureTypeCode AS GroupLectureTypeCode, dbo.UNILectureType.LectureTypeNameA AS GroupLectureTypeNameA, dbo.UNILectureType.LectureTypeNameE AS GroupLectureTypeNameE ";
                if (_ExamIDs != null && _ExamIDs != "")
                    Returned += ",GroupTable.GroupExamID,GroupTable.GroupHallID,GroupTable.GroupHallName ";
                    Returned += @"
                  FROM      dbo.UNIGroup INNER JOIN
                                    dbo.UNIFaculty ON dbo.UNIGroup.GroupFaculty = dbo.UNIFaculty.FacultyID INNER JOIN
                                    dbo.UNICourse ON dbo.UNIGroup.GroupCourse = dbo.UNICourse.CourseID INNER JOIN
                                    dbo.UNISemester ON dbo.UNIGroup.GroupSemester = dbo.UNISemester.SemesterID LEFT OUTER JOIN
                                    dbo.UNILectureType ON dbo.UNIGroup.GroupLectureType = dbo.UNILectureType.LectureTypeID ";
                if(_ExamIDs!= null && _ExamIDs!="")
                {
                    string strExamGroup = @" SELECT dbo.UNIGroup.GroupID AS ExamGroupID, dbo.UNIExam.ExamID AS GroupExamID, GroupHallTable.GroupHallID, GroupHallTable.GroupHallName
FROM     dbo.UNIExam INNER JOIN
                  dbo.UNIGroup ON dbo.UNIExam.ExamCourse = dbo.UNIGroup.GroupCourse AND dbo.UNIExam.ExamSemester = dbo.UNIGroup.GroupSemester inner JOIN
                      (SELECT dbo.UNIExamGroup.ExamID, dbo.UNIExamGroup.GroupID, dbo.UNIHall.HallID AS GroupHallID, dbo.UNIHall.HallName AS GroupHallName
                       FROM      dbo.UNIExamGroup left outer JOIN
                                         dbo.UNIHall ON dbo.UNIExamGroup.HallID = dbo.UNIHall.HallID) AS GroupHallTable ON dbo.UNIGroup.GroupID = GroupHallTable.GroupID AND dbo.UNIExam.ExamID = GroupHallTable.ExamID
WHERE  (dbo.UNIGroup.GroupLectureType = 3) AND (dbo.UNIExam.ExamID IN (" + _ExamIDs+"))";
                    Returned += " inner join ("+strExamGroup+ @") as GroupTable on UNIGroup.GroupID = GroupTable.ExamGroupID";
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["GroupID"] != null)
                int.TryParse(objDr["GroupID"].ToString(), out _ID);

            if (objDr.Table.Columns["GroupFaculty"] != null)
                int.TryParse(objDr["GroupFaculty"].ToString(), out _Faculty);

            if (objDr.Table.Columns["GroupCode"] != null)
                _Code = objDr["GroupCode"].ToString();

            if (objDr.Table.Columns["GroupNameA"] != null)
                _NameA = objDr["GroupNameA"].ToString();

            if (objDr.Table.Columns["GroupNameE"] != null)
                _NameE = objDr["GroupNameE"].ToString();

            if (objDr.Table.Columns["GroupSemester"] != null)
                int.TryParse(objDr["GroupSemester"].ToString(), out _Semester);

            if (objDr.Table.Columns["GroupCourse"] != null)
                int.TryParse(objDr["GroupCourse"].ToString(), out _Course);

            if (objDr.Table.Columns["GroupLectureType"] != null)
                int.TryParse(objDr["GroupLectureType"].ToString(), out _LectureType);

            if (objDr.Table.Columns["GroupFacultyID"] != null)
                int.TryParse(objDr["GroupFacultyID"].ToString(), out _FacultyID);

            if (objDr.Table.Columns["GroupFacultyNameA"] != null)
                _FacultyNameA = objDr["GroupFacultyNameA"].ToString();

            if (objDr.Table.Columns["GroupFacultyNameE"] != null)
                _FacultyNameE = objDr["GroupFacultyNameE"].ToString();

            if (objDr.Table.Columns["GroupCourseID"] != null)
                int.TryParse(objDr["GroupCourseID"].ToString(), out _CourseID);

            if (objDr.Table.Columns["GroupCourseCode"] != null)
                _CourseCode = objDr["GroupCourseCode"].ToString();

            if (objDr.Table.Columns["GroupCourseNameA"] != null)
                _CourseNameA = objDr["GroupCourseNameA"].ToString();

            if (objDr.Table.Columns["GroupCourseNameE"] != null)
                _CourseNameE = objDr["GroupCourseNameE"].ToString();

            if (objDr.Table.Columns["GroupSemesterID"] != null)
                int.TryParse(objDr["GroupSemesterID"].ToString(), out _SemesterID);

            if (objDr.Table.Columns["GroupSemesterDesc"] != null)
                _SemesterDesc = objDr["GroupSemesterDesc"].ToString();

            if (objDr.Table.Columns["GroupLectureTypeID"] != null)
                int.TryParse(objDr["GroupLectureTypeID"].ToString(), out _LectureTypeID);
            if (objDr.Table.Columns["GroupExamType"] != null)
                int.TryParse(objDr["GroupExamType"].ToString(), out _ExamType);

            if (objDr.Table.Columns["GroupLectureTypeCode"] != null)
                _LectureTypeCode = objDr["GroupLectureTypeCode"].ToString();

            if (objDr.Table.Columns["GroupLectureTypeNameA"] != null)
                _LectureTypeNameA = objDr["GroupLectureTypeNameA"].ToString();

            if (objDr.Table.Columns["GroupLectureTypeNameE"] != null)
                _LectureTypeNameE = objDr["GroupLectureTypeNameE"].ToString();
            //GroupCourseLevel
            if(objDr.Table.Columns["GroupCourseLevel"]!=null)
            int.TryParse(objDr["GroupCourseLevel"].ToString(), out _CourseLevel);
            if (objDr.Table.Columns["RegisterationGroupID"] != null)
                int.TryParse(objDr["RegisterationGroupID"].ToString(), out _GroupID);
            if (objDr.Table.Columns["GroupHallID"] != null)
                int.TryParse(objDr["GroupHallID"].ToString(), out _HallID);
            if (objDr.Table.Columns["GroupHallName"] != null)
                _HallName = objDr["GroupHallName"].ToString();
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
        public void DeleteStudent()
        {
            string strSql = @"delete FROM     dbo.UNIGroupRegisteration
WHERE(GroupID = "+_ID+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where UNIGroup.Dis is null ";
            if (_Faculty != 0)
                strSql += @" and  dbo.UNIGroup.GroupFaculty
 = "+_Faculty;
            if (_Semester != 0)
                strSql += @" and dbo.UNIGroup.GroupSemester
="+_Semester;
            if (_Course != 0)
                strSql += @" and dbo.UNIGroup.GroupCourse
 ="+_Course;
            if (_LectureType != 0)
                strSql += @" and  dbo.UNIGroup.GroupLectureType
 ="+_LectureType;
            if (_ExamType != 0)
                strSql += " and dbo.UNIGroup.GroupExamType=" + _ExamType;
            if(_CourseLevel!=0)
            strSql += " and UNICourse.CourseRecommendedGrade ="+_CourseLevel;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void AddUnique()
        {
            string strSql = AddUniqueStr;
             object objTemp =SysData.SharpVisionBaseDb.ReturnScalar(AddUniqueStr);
            if (objTemp != null)
                int.TryParse(objTemp.ToString(), out _ID);
        }

        public DataTable GetGroupRegisteration()
        {
            string strSql = "select StudentTable.*,UNIGroupRegisteration.GroupID as RegisterationGroupID from (" + new RegisterationDb() { Faculty = _Faculty }.SearchStr + @") as StudentTable 
    inner join UNIGroupRegisteration on StudentTable.RegisterationID = UNIGroupRegisteration.RegisterationID  ";
            if(_ID!=0)
      strSql+=" where UNIGroupRegisteration.GroupID =" + _ID;
            else
                strSql += " where UNIGroupRegisteration.GroupID in(" + _IDs +")";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        string ExceptedGroupRegisteration
        {
            get
            {
                string strExceptedSql = @"SELECT dbo.UNIGroupRegisteration.RegisterationID
FROM     dbo.UNIGroup INNER JOIN
                  dbo.UNIGroup AS UNIGroup_1 ON dbo.UNIGroup.GroupFaculty = UNIGroup_1.GroupFaculty AND dbo.UNIGroup.GroupSemester = UNIGroup_1.GroupSemester AND dbo.UNIGroup.GroupCourse = UNIGroup_1.GroupCourse AND 
                  dbo.UNIGroup.GroupLectureType = UNIGroup_1.GroupLectureType 
 AND 
                  dbo.UNIGroup.GroupExamType = UNIGroup_1.GroupExamType
 AND dbo.UNIGroup.GroupNameA <> UNIGroup_1.GroupNameA INNER JOIN
                  dbo.UNIGroupRegisteration ON UNIGroup_1.GroupID = dbo.UNIGroupRegisteration.GroupID
WHERE  (dbo.UNIGroup.GroupID = " + ID + ")";
                return strExceptedSql;

            }
        }
        public DataTable GetGroupRecommededRegisteration()
        {
            string strExceptedSql = ExceptedGroupRegisteration;

            string strSql = "select RegisterationTable.* from (" + new RegisterationDb() { Faculty = _Faculty }.SearchStr + @") as RegisterationTable 
   INNER JOIN
                  dbo.UNIGroup ON RegisterationTable.CourseFaculty = dbo.UNIGroup.GroupFaculty AND RegisterationTable.RegisterationCourse = dbo.UNIGroup.GroupCourse AND 
                  RegisterationTable.RegisterationSemester = dbo.UNIGroup.GroupSemester
 left outer join ("+strExceptedSql+@") as ExceptTable on RegisterationTable.RegisterationID = ExceptTable.RegisterationID 
WHERE  (dbo.UNIGroup.GroupID = "+_ID+ ") and (ExceptTable.RegisterationID is null)";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinRegisteration()
        {
            if (_ID == 0 || _RegisterationIDs == null || _RegisterationIDs == "")
                return;
            string strSql = @"delete FROM     dbo.UNIGroupRegisteration
WHERE(GroupID = "+_ID+@") AND(NOT(RegisterationID IN("+_RegisterationIDs+"))) ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into UNIGroupRegisteration (GroupID, RegisterationID
)";
            strSql += @" SELECT  "+_ID+@"  as GroupID,dbo.UNIRegisteration.RegisterationID
FROM     dbo.UNIRegisteration LEFT OUTER JOIN
                      ("+ExceptedGroupRegisteration+@") AS ExceptedTable ON dbo.UNIRegisteration.RegisterationID = ExceptedTable.RegisterationID LEFT OUTER JOIN
                      (SELECT GroupID, RegisterationID
                       FROM      dbo.UNIGroupRegisteration
                       WHERE   (GroupID = "+_ID+@")) AS AssignedTable ON dbo.UNIRegisteration.RegisterationID = AssignedTable.RegisterationID
WHERE  (dbo.UNIRegisteration.RegisterationID IN ("+_RegisterationIDs+@")) AND (AssignedTable.RegisterationID IS NULL) AND (ExceptedTable.RegisterationID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable GetGroupRegisterationCount()
        {
            if (_IDs == null || _IDs == "")
                return new DataTable();
            string strSql = @"SELECT dbo.UNIGroup.GroupID, COUNT(dbo.UNIRegisteration.RegisterationID) AS RegisterationCount,MIN(dbo.UNIRegisteration.RegisterationSeatNo) AS MinSeatNo, MAX(dbo.UNIRegisteration.RegisterationSeatNo) AS MaxSeatNo

  FROM     dbo.UNIGroup INNER JOIN
                  dbo.UNIGroupRegisteration ON dbo.UNIGroup.GroupID = dbo.UNIGroupRegisteration.GroupID INNER JOIN
                  dbo.UNIRegisteration ON dbo.UNIGroupRegisteration.RegisterationID = dbo.UNIRegisteration.RegisterationID INNER JOIN
                  dbo.UNIStudent ON dbo.UNIRegisteration.RegisterationStudent = dbo.UNIStudent.StudentID
WHERE  (dbo.UNIStudent.StudentStatus = 1)
GROUP BY dbo.UNIGroup.GroupID
HAVING (dbo.UNIGroup.GroupID IN (" + _IDs+"))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}