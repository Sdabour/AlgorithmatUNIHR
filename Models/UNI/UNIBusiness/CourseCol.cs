using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatMVC.UNI.UniDataBase;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class CourseCol:CollectionBase
    {

        #region Constructor
        public CourseCol(int intFacultyID)
        {
            CourseBiz objBiz = new CourseBiz();
            
            CourseDb objDb = new CourseDb();
            objDb.Faculty = intFacultyID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CourseBiz(objDR);
                Add(objBiz);
            }
        }
        public CourseCol(bool blIsEmbty,int intFacultyID)
        {
            if (blIsEmbty)
                return;
            CourseBiz objBiz = new CourseBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            CourseDb objDb = new CourseDb();
            objDb.Faculty = intFacultyID;

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CourseBiz(objDR);
                Add(objBiz);
            }
        }

        public CourseCol(int intFacultyID,string strCode,int intSemester,int intLevel)
        {
 
            CourseBiz objBiz = new CourseBiz();
            

            CourseDb objDb = new CourseDb();
            objDb.Code = strCode;
            objDb.RecommendedGrade = intLevel;
            //objDb.seme
            objDb.Faculty = intFacultyID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CourseBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public CourseBiz this[int intIndex]
        {
            get
            {
                return (CourseBiz)this.List[intIndex];
            }
        }
        static CourseCol _CacheCourseCol;
        public static CourseCol CacheCourseCol
        {
            get
            {
                if(_CacheCourseCol== null)
                {
                    _CacheCourseCol = new CourseCol(false,SysData.FacultyID);
                }
                return _CacheCourseCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(CourseBiz objBiz)
        {
            List.Add(objBiz);
        }
        public CourseCol GetCol(string strTemp)
        {
            CourseCol Returned = new CourseCol(true,0);
            foreach (CourseBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp)|| objBiz.NameE.CheckStr(strTemp) || objBiz.Code.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CourseID"), new DataColumn("CourseCode"), new DataColumn("CourseNameA"), new DataColumn("CourseNameE"), new DataColumn("CourseDesc"), new DataColumn("CourseCreditHour"), new DataColumn("CourseTotalDegree"), new DataColumn("CourseMidtermDegree"), new DataColumn("CourseSemesterWorkDegree"), new DataColumn("CoursePracticalDegree"), new DataColumn("CourseOralDegree"), new DataColumn("CourseFinalDegree"), new DataColumn("CourseRecommendedGrade") });
            DataRow objDr;
            foreach (CourseBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CourseID"] = objBiz.ID;
                objDr["CourseCode"] = objBiz.Code;
                objDr["CourseNameA"] = objBiz.NameA;
                objDr["CourseNameE"] = objBiz.NameE;
                objDr["CourseDesc"] = objBiz.Desc;
                objDr["CourseCreditHour"] = objBiz.CreditHour;
                objDr["CourseTotalDegree"] = objBiz.TotalDegree;
                objDr["CourseMidtermDegree"] = objBiz.MidtermDegree;
                objDr["CourseSemesterWorkDegree"] = objBiz.SemesterWorkDegree;
                objDr["CoursePracticalDegree"] = objBiz.PracticalDegree;
                objDr["CourseOralDegree"] = objBiz.OralDegree;
                objDr["CourseFinalDegree"] = objBiz.FinalDegree;
                objDr["CourseRecommendedGrade"] = objBiz.RecommendedGrade;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public CourseCol Copy()
        {
            CourseCol Returned = new CourseCol(true,0);
            foreach (CourseBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        public static CourseCol GetRegisteredCourseCol(int intSemester,int intFaculty)
        {
            CourseCol Returned = new CourseCol(true,0);
            CourseDb objDb = new CourseDb() {OnlyHasRegisteration=true, SemesterID =intSemester,Faculty=intFaculty};

            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Returned.Add(new CourseBiz(objDr));
            }
            return Returned;
        }
        #endregion

    }
}