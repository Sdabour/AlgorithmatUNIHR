using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationGroupCol:CollectionBase
    {

        #region Constructor
        public RegisterationGroupCol()
        {

        }
        public RegisterationGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            RegisterationGroupBiz objBiz = new RegisterationGroupBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            RegisterationGroupDb objDb = new RegisterationGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new RegisterationGroupBiz(objDR);
                Add(objBiz);
            }
        }
        public RegisterationGroupCol(int intFacultyID,int intSemesterID,int intCourseID,int intLectureType,int intExamType,int intCourseLevel)
        {
            RegisterationGroupDb objDb = new RegisterationGroupDb() { Semester = intSemesterID, Course = intCourseID, Faculty = intFacultyID ,LectureType=intLectureType,ExamType=intExamType,CourseLevel=intCourseLevel};
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new RegisterationGroupBiz(objDr));

            }

        }
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public RegisterationGroupBiz this[int intIndex]
        {
            get
            {
                return (RegisterationGroupBiz)this.List[intIndex];
            }
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach (RegisterationGroupBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(RegisterationGroupBiz objBiz)
        {
            List.Add(objBiz);
        }
        public RegisterationGroupCol GetCol(string strTemp)
        {
            RegisterationGroupCol Returned = new RegisterationGroupCol(true);
            foreach (RegisterationGroupBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("GroupID"), new DataColumn("GroupFaculty"), new DataColumn("GroupCode"), new DataColumn("GroupNameA"), new DataColumn("GroupNameE"), new DataColumn("GroupSemester"), new DataColumn("GroupCourse"), new DataColumn("GroupLectureType"), new DataColumn("GroupFacultyID"), new DataColumn("GroupFacultyNameA"), new DataColumn("GroupFacultyNameE"), new DataColumn("GroupCourseID"), new DataColumn("GroupCourseCode"), new DataColumn("GroupCourseNameA"), new DataColumn("GroupCourseNameE"), new DataColumn("GroupSemesterID"), new DataColumn("GroupSemesterDesc"), new DataColumn("GroupLectureTypeID"), new DataColumn("GroupLectureTypeCode"), new DataColumn("GroupLectureTypeNameA"), new DataColumn("GroupLectureTypeNameE") });
            DataRow objDr;
            foreach (RegisterationGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["GroupID"] = objBiz.ID;
                objDr["GroupFaculty"] = objBiz.FacultyBiz.ID;
                objDr["GroupCode"] = objBiz.Code;
                objDr["GroupNameA"] = objBiz.NameA;
                objDr["GroupNameE"] = objBiz.NameE;
                objDr["GroupSemester"] = objBiz.Semester;
                objDr["GroupCourse"] = objBiz.Course;
                objDr["GroupLectureType"] = objBiz.LectureType;
                objDr["GroupFacultyID"] = objBiz.FacultyBiz.ID;
                objDr["GroupFacultyNameA"] = objBiz.FacultyBiz.NameA;
                objDr["GroupFacultyNameE"] = objBiz.FacultyBiz.NameE;
                objDr["GroupCourseID"] = objBiz.CourseBiz.ID;
                objDr["GroupCourseCode"] = objBiz.CourseBiz.Code;
                objDr["GroupCourseNameA"] = objBiz.CourseBiz.NameA;
                objDr["GroupCourseNameE"] = objBiz.CourseBiz.NameE;
                objDr["GroupSemesterID"] = objBiz.SemesterBiz.ID;
                objDr["GroupSemesterDesc"] = objBiz.SemesterBiz.Desc;
                objDr["GroupLectureTypeID"] = objBiz.LectureTypeBiz.ID;
                objDr["GroupLectureTypeCode"] = objBiz.LectureTypeBiz.Code;
                objDr["GroupLectureTypeNameA"] = objBiz.LectureTypeBiz.NameA;
                objDr["GroupLectureTypeNameE"] = objBiz.LectureTypeBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetRegisterationNo()
        {
            if (Count == 0)
                return;
            DataTable dtTemp = new RegisterationGroupDb() { IDs = IDs }.GetGroupRegisterationCount();
            if (dtTemp.Rows.Count == 0)
                return;
            Hashtable hsCourse = new Hashtable();
            DataRow[] arrDr;
            int intTemp = 0;
            CourseBiz objCourse;
            foreach(RegisterationGroupBiz objBiz in this)
            {
                arrDr = dtTemp.Select("GroupID=" + objBiz.ID.ToString());
                if(arrDr.Length>0)
                {
                    int.TryParse(arrDr[0]["RegisterationCount"].ToString(), out intTemp);

                    objBiz.RegisterationNo = intTemp;
                    objBiz.MaxSeatNo = arrDr[0]["MaxSeatNo"].ToString();
                    objBiz.MinSeatNo = arrDr[0]["MinSeatNo"].ToString();
                }
                if (hsCourse[objBiz.CourseBiz.ID.ToString()] != null)
                {
                    objCourse = (CourseBiz)hsCourse[objBiz.CourseBiz.ID.ToString()];
                    objCourse.RegisterationNo += objBiz.RegisterationNo;
                }
                else
                {
                    objCourse = objBiz.CourseBiz;
                    objCourse.RegisterationNo += objBiz.RegisterationNo;
                    hsCourse.Add(objCourse.ID.ToString(), objCourse);
                }
                       
            }
        }
       public void SetRegisterationCol(int intFaculty)
        {
            if (Count == 0)
                return;
            RegisterationGroupDb objDb = new RegisterationGroupDb() { IDs = IDs,Faculty=intFaculty };
            DataTable dtTemp = objDb.GetGroupRegisteration();
            DataRow[] arrDr;
            RegisterationBiz objReg;
            foreach(RegisterationGroupBiz objBiz in this)
            {
                objBiz.RegisterationCol = new RegisterationCol(true, 0);
                arrDr = dtTemp.Select("RegisterationGroupID=" + objBiz.ID, "RegisterationSeatNo");
                foreach(DataRow objDr in arrDr)
                {
                    objReg = new RegisterationBiz(objDr);
                    objReg.GroupBiz = objBiz;
                    objBiz.RegisterationCol.Add(objReg);
                }
            }
        }
        public DataTable GetRegisterationTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("Group"), new DataColumn("StudentCode"), new DataColumn("StudentName"), new DataColumn("StudentSeatNo"), new DataColumn("CourseCode"), new DataColumn("CourseNameA"), new DataColumn("CourseNameE"), new DataColumn("CreditHour") });
            DataRow objDr;
            foreach(RegisterationGroupBiz objGroup in this)
            {
                foreach(RegisterationBiz objReg in objGroup.RegisterationCol)
                {
                    objDr = Returned.NewRow();
                    objDr["Group"] = objGroup.NameA;
                    objDr["StudentCode"] = objReg.StudentBiz.Code;
                    objDr["StudentName"] = objReg.StudentBiz.NameA;
                    objDr["StudentSeatNo"] = objReg.SeatNO;
                    objDr["CourseCode"] = objReg.CourseBiz.Code;
                    objDr["CourseNameA"] = objReg.CourseBiz.NameA;
                    objDr["CourseNameE"] = objReg.CourseBiz.NameE;
                    objDr["CreditHour"] = objReg.CourseBiz.CreditHour;
                    Returned.Rows.Add(objDr);
                }
            }
            return Returned;
        }
        #endregion

    }
}