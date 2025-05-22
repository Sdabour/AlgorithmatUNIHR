using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class CourseDb
    {// CourseID, CourseCode, CourseNameA, CourseNameE, CourseDesc, CourseCreditHour, CourseTotalDegree, CourseMidtermDegree, CourseSemesterWorkDegree, CoursePracticalDegree, CourseOralDegree, CourseFinalDegree,CourseRecommendedGrade


        #region Constructor
        public CourseDb()
        {
        }
        public CourseDb(DataRow objDr)
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
        { set => _Faculty = value;
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
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        int _CreditHour;
        public int CreditHour
        {
            set => _CreditHour = value;
            get => _CreditHour;
        }
        int _TotalDegree;
        public int TotalDegree
        {
            set => _TotalDegree = value;
            get => _TotalDegree;
        }
        int _MidtermDegree;
        public int MidtermDegree
        {
            set => _MidtermDegree = value;
            get => _MidtermDegree;
        }
        int _SemesterWorkDegree;
        public int SemesterWorkDegree
        {
            set => _SemesterWorkDegree = value;
            get => _SemesterWorkDegree;
        }
        int _PracticalDegree;
        public int PracticalDegree
        {
            set => _PracticalDegree = value;
            get => _PracticalDegree;
        }
        int _OralDegree;
        public int OralDegree
        {
            set => _OralDegree = value;
            get => _OralDegree;
        }
        int _FinalDegree;
        public int FinalDegree
        {
            set => _FinalDegree = value;
            get => _FinalDegree;
        }
        int _ClinicalDegree;
        public int ClinicalDegree
        {
            set => _ClinicalDegree = value;
            get => _ClinicalDegree;
        }
        int _RecommendedGrade;
        public int RecommendedGrade
        {
            set => _RecommendedGrade = value;
            get => _RecommendedGrade;
        }
        int _SemesterID;
        public int SemesterID
        { set => _SemesterID = value;
            get => _SemesterID;
        }
        double _MaxBonus;
        public double MaxBonus
        { set => _MaxBonus = value; get => _MaxBonus; }
        bool _BonusForAll;
        public bool BonusForAll
        { set => _BonusForAll = value; get => _BonusForAll; }

        double _FinalMinDegree;
        public double FinalMinDegree
        { set => _FinalMinDegree = value; get => _FinalMinDegree; }
        string _StudentName;
        public string StudentName { set => _StudentName = value; }
        bool _OnlyHasRegisteration;
        public bool OnlyHasRegisteration
        {
            set => _OnlyHasRegisteration=value;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNICourse (CourseCode,CourseNameA,CourseNameE,CourseDesc,CourseCreditHour,CourseTotalDegree,CourseMidtermDegree,CourseSemesterWorkDegree,CoursePracticalDegree,CourseOralDegree,CourseFinalDegree,CourseRecommendedGrade,UsrIns,TimIns) values ('" + Code + "','" + NameA + "','" + NameE + "','" + Desc + "'," + CreditHour + "," + TotalDegree + "," + MidtermDegree + "," + SemesterWorkDegree + "," + PracticalDegree + "," + OralDegree + "," + FinalDegree + "," + RecommendedGrade + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNICourse set CourseCode='" + Code + "'" +
           ",CourseNameA='" + NameA + "'" +
           ",CourseNameE='" + NameE + "'" +
           ",CourseDesc='" + Desc + "'" +
           ",CourseCreditHour=" + CreditHour + "" +
           ",CourseTotalDegree=" + TotalDegree + "" +
           ",CourseMidtermDegree=" + MidtermDegree + "" +
           ",CourseSemesterWorkDegree=" + SemesterWorkDegree + "" +
           ",CoursePracticalDegree=" + PracticalDegree + "" +
           ",CourseOralDegree=" + OralDegree + "" +
           ",CourseFinalDegree=" + FinalDegree + "" +
           ",CourseRecommendedGrade=" + RecommendedGrade + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where CourseID= "+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNICourse set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strUniSemester = @"SELECT dbo.UNISemesterCourse.SemesterID as CourseLastSemester, dbo.UNISemesterCourse.CourseID as SemesterCourseID, dbo.UNISemesterCourse.CourseSemesterMaxBonus as CourseSemesterMaxBonusC, dbo.UNISemesterCourse.CourseSemesterBonusForAll as MaxCourseSemesterBonusForAll
FROM     (SELECT MAX(SemesterID) AS MaxSemester
                  FROM      dbo.UNISemester) AS MaxSemesterTable INNER JOIN
                  dbo.UNISemesterCourse ON MaxSemesterTable.MaxSemester = dbo.UNISemesterCourse.SemesterID";
                string Returned = @" select UNICourse.CourseID,UNICourse.CourseFaculty,UNICourse.CourseCode,UNICourse.CourseNameA,CourseNameE,CourseDesc,CourseCreditHour,CourseTotalDegree,CourseMidtermDegree,CourseSemesterWorkDegree,CoursePracticalDegree,CourseOralDegree,CourseFinalDegree,CourseClinicalDegree,CourseRecommendedGrade,CourseMaxBonus, CourseFinalMinDegree,CourseSemesterTable.* 
   from UNICourse  
 left outer join (" + strUniSemester+ @") as CourseSemesterTable
  on UNICourse.CourseID = CourseSemesterTable.SemesterCourseID ";
                if(_OnlyHasRegisteration)
                {
                    string strRegisteration = @"SELECT DISTINCT RegisterationCourse
FROM     dbo.UNIRegisteration
WHERE  (RegisterationSemester = "+_SemesterID+")";
                    Returned += " inner join ("+strRegisteration+ @") as RegisterationTable on  UNICourse.CourseID=RegisterationTable.RegisterationCourse ";
                }
                Returned += @" where (CourseFaculty=" + _Faculty + ") ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CourseID"] != null)
                int.TryParse(objDr["CourseID"].ToString(), out _ID);

            if (objDr.Table.Columns["CourseCode"] != null)
                _Code = objDr["CourseCode"].ToString();

            if (objDr.Table.Columns["CourseNameA"] != null)
                _NameA = objDr["CourseNameA"].ToString();

            if (objDr.Table.Columns["CourseNameE"] != null)
                _NameE = objDr["CourseNameE"].ToString();

            if (objDr.Table.Columns["CourseDesc"] != null)
                _Desc = objDr["CourseDesc"].ToString();

            if (objDr.Table.Columns["CourseCreditHour"] != null)
                int.TryParse(objDr["CourseCreditHour"].ToString(), out _CreditHour);

            if (objDr.Table.Columns["CourseTotalDegree"] != null)
                int.TryParse(objDr["CourseTotalDegree"].ToString(), out _TotalDegree);

            if (objDr.Table.Columns["CourseMidtermDegree"] != null)
                int.TryParse(objDr["CourseMidtermDegree"].ToString(), out _MidtermDegree);

            if (objDr.Table.Columns["CourseSemesterWorkDegree"] != null)
                int.TryParse(objDr["CourseSemesterWorkDegree"].ToString(), out _SemesterWorkDegree);

            if (objDr.Table.Columns["CoursePracticalDegree"] != null)
                int.TryParse(objDr["CoursePracticalDegree"].ToString(), out _PracticalDegree);
            if (objDr.Table.Columns["CourseClinicalDegree"] != null)
                int.TryParse(objDr["CourseClinicalDegree"].ToString(), out _ClinicalDegree);


            if (objDr.Table.Columns["CourseOralDegree"] != null)
                int.TryParse(objDr["CourseOralDegree"].ToString(), out _OralDegree);

            if (objDr.Table.Columns["CourseFinalDegree"] != null)
                int.TryParse(objDr["CourseFinalDegree"].ToString(), out _FinalDegree);

            if (objDr.Table.Columns["CourseRecommendedGrade"] != null)
                int.TryParse(objDr["CourseRecommendedGrade"].ToString(), out _RecommendedGrade);
            if (objDr.Table.Columns["CourseMaxBonus"] != null)
                double.TryParse(objDr["CourseMaxBonus"].ToString(), out _MaxBonus);
            double dbTemp = 0;
            if (objDr.Table.Columns["CourseSemesterMaxBonusC"] != null)
                double.TryParse(objDr["CourseSemesterMaxBonusC"].ToString(), out dbTemp);

            if (dbTemp != 0)
                _MaxBonus = dbTemp;
            else
            {
                if (objDr.Table.Columns["CourseSemesterMaxBonusC"] != null)
                    double.TryParse(objDr["CourseSemesterMaxBonusC"].ToString(), out dbTemp);
                if (dbTemp != 0)
                    _MaxBonus = dbTemp;
            }

            if(objDr.Table.Columns["CourseSemesterBonusForAll"]!= null )
            {
                bool.TryParse(objDr["CourseSemesterBonusForAll"].ToString(), out _BonusForAll);

            }
            else if (objDr.Table.Columns["MaxCourseSemesterBonusForAll"] != null)
            {
                bool.TryParse(objDr["MaxCourseSemesterBonusForAll"].ToString(), out _BonusForAll);
            }
            if (objDr.Table.Columns["CourseFinalMinDegree"] != null)
                double.TryParse(objDr["CourseFinalMinDegree"].ToString(), out _FinalMinDegree);

            if (objDr.Table.Columns["CourseFaculty"] != null)
                int.TryParse(objDr["CourseFaculty"].ToString(), out _Faculty);
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
            string strSql = SearchStr;//+ " where (CourseFaculty="+_Faculty+") ";

            if (_Code != null && _Code != "")
                strSql += " and (CourseCode like '%"+_Code+"%'  or CourseNameA like '%"+_Code +"%' or CourseNameE like '%"+_Code+"%') ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public DataTable GetRegisterationStudent()
        {
            if (ID == 0)
                return new DataTable();
            string strPreRegisteredStudent = @"SELECT dbo.UNIRegisteration.RegisterationStudent AS PreRegisteredStudent
FROM     dbo.UNIRegisteration INNER JOIN
                      (SELECT RegisterationStudent, RegisterationCourse, MAX(RegisterationSemester) AS MaxRegisterationSemester
                       FROM      dbo.UNIRegisteration AS UNIRegisteration_1
                       GROUP BY RegisterationStudent, RegisterationCourse) AS MaxRegisterationTable ON dbo.UNIRegisteration.RegisterationStudent = MaxRegisterationTable.RegisterationStudent AND 
                  dbo.UNIRegisteration.RegisterationCourse = MaxRegisterationTable.RegisterationCourse AND dbo.UNIRegisteration.RegisterationSemester = MaxRegisterationTable.MaxRegisterationSemester
WHERE  (NOT (isnull(dbo.UNIRegisteration.RegisterationStatus,0) IN (2, 3, 4))) AND (dbo.UNIRegisteration.RegisterationCourse = " + ID+ ")  AND (isnull(dbo.UNIRegisteration.VerbalGPA,'') not in ('f','IC')) ";
            string strCourseLevel = @"SELECT CourseRecommendedGrade
FROM     dbo.UNICourse
WHERE  (CourseID = "+ID+")";
            string strSql ="select * from (" +new StudentDb().SearchStr+") as StudentTable ";
            strSql += @" left outer join ("+strPreRegisteredStudent+ @") as PreRegisterationTable1  on StudentTable.StudentID = PreRegisterationTable1.PreRegisteredStudent
 where StudentTable.StudentStatus=1 and  PreRegisterationTable1.PreRegisteredStudent is null and  StudentTable.LastGrade >= (" + strCourseLevel+@")";
            if(_StudentName!= null&& _StudentName!= "")
            {
                strSql += " and (StudentNameA like '%"+_StudentName+"%' or StudentCode like '%"+_StudentName+"%')";
            }
            strSql += " order by StudentNameA asc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void SaveSemesterCourseBonus()
        {

            string strSql = @"update dbo.UNISemesterCourse
 set CourseSemesterMaxBonus= "+_MaxBonus+", CourseSemesterBonusForAll="+(_BonusForAll?1:0)+@"
WHERE(SemesterID = " + _SemesterID+") AND(CourseID = "+_ID+")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
           strSql= @"
insert into UNISemesterCourse (SemesterID, CourseID, CourseSemesterMaxBonus, CourseSemesterBonusForAll
)
SELECT " + _SemesterID+@" AS SemesterID1, "+_ID+@" AS CourseID1, "+_MaxBonus+@" AS CourseSemesterMaxBonus, "+(_BonusForAll?1:0)+@" AS CourseSEmesterForAll
FROM dbo.UNICourse
WHERE(CourseID = "+_ID+@") AND(NOT EXISTS
                    (SELECT SemesterID, CourseID

                     FROM      dbo.UNISemesterCourse

                     WHERE(SemesterID = "+_SemesterID+@") AND(CourseID = "+_ID+")))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        
        #endregion
    }
}