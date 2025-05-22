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
    public class ExamCol:CollectionBase
    {

        #region Constructor
        public ExamCol()
        {

        }
        public ExamCol(SemesterBiz objSemesterBiz,int intFaculty)
        {
            if (objSemesterBiz == null)
                objSemesterBiz = new SemesterBiz();
            ExamDb objDb = new ExamDb() { Semester = objSemesterBiz.ID,CourseFaculty=intFaculty };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new ExamBiz(objDr));
            }

        }
        public ExamCol(int intCourseID,string strCourseIDs,int intExamType,int intSemester,int intStatus,int intLevel,int intFaculty,bool? blOnlySelected=false)
        {
            ExamDb objDb = new ExamDb() {CourseID=intCourseID,CourseIDs=strCourseIDs,Type=intExamType,Semester=intSemester,Status=intStatus,Level=intLevel,CourseFaculty=intFaculty ,SelectedOnly=blOnlySelected.GetValueOrDefault()};
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new ExamBiz(objDr));
            }

        }
        public ExamCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ExamBiz objBiz = new ExamBiz();
           

            ExamDb objDb = new ExamDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ExamBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ExamBiz this[int intIndex]
        {
            get
            {
                return (ExamBiz)this.List[intIndex];
            }
        }
        public string IDs
        {
            get
            {
                string Returned = "";
                foreach(ExamBiz objBiz in this)
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
        public void Add(ExamBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ExamCol GetCol(string strTemp,int intCourse)
        {
            ExamCol Returned = new ExamCol(true);
            foreach (ExamBiz objBiz in this)
            {
                if (objBiz.CourseBiz.NameA.CheckStr(strTemp)&&(intCourse == 0 || objBiz.CourseBiz.ID==intCourse))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ExamID"), new DataColumn("ExamDesc"), new DataColumn("ExamDate", System.Type.GetType("System.DateTime")), new DataColumn("ExamSemester"), new DataColumn("ExamCourse"), new DataColumn("ExamType"), new DataColumn("ExamGrade"), new DataColumn("ExamSemesterID"), new DataColumn("ExamSemesterDesc"), new DataColumn("ExamCourseID"), new DataColumn("ExamCourseCode"), new DataColumn("ExamCourseNameA"), new DataColumn("ExamCourseNameE") });
            DataRow objDr;
            foreach (ExamBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ExamID"] = objBiz.ID;
                objDr["ExamDesc"] = objBiz.Desc;
                objDr["ExamDate"] = objBiz.Date;
                objDr["ExamSemester"] = objBiz.Semester;
                objDr["ExamCourse"] = objBiz.Course;
                objDr["ExamType"] = objBiz.Type;
                objDr["ExamGrade"] = objBiz.Grade;
                objDr["ExamSemesterID"] = objBiz.SemesterBiz.ID;
                objDr["ExamSemesterDesc"] = objBiz.SemesterBiz.Desc;
                objDr["ExamCourseID"] = objBiz.CourseBiz.ID;
                objDr["ExamCourseCode"] = objBiz.CourseBiz.Code;
                objDr["ExamCourseNameA"] = objBiz.CourseBiz.NameA;
                objDr["ExamCourseNameE"] = objBiz.CourseBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public ExamCol Copy()
        {
            ExamCol Returned = new ExamCol(true);
            foreach (ExamBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        public void SetGroupCol(bool blSetRegisteration,int intFaculty)
        {
            if (Count == 0)
                return;
            RegisterationGroupDb objGroupDb = new RegisterationGroupDb() { Faculty = intFaculty, ExamIDs = IDs };
            DataTable dtTemp = objGroupDb.Search();

            DataRow[] arrDr;
            RegisterationGroupBiz objGroup;
            RegisterationGroupCol objCol =new RegisterationGroupCol(true);
            foreach(ExamBiz objExam in this)
            {
                arrDr = dtTemp.Select("GroupExamID=" + objExam.ID);
                foreach(DataRow objDr in arrDr)
                {
                    objGroup = new RegisterationGroupBiz(objDr);
                    objExam.GroupCol.Add(objGroup);
                    objExam.LstGroup.Add(new ExamGroupBiz() { GroupBiz = objGroup, HallBiz = new HallBiz() { ID = objGroup.HallBiz.ID, Name = objGroup.HallBiz.Name } });
                    objCol.Add(objGroup);
                }
            }
            objCol.SetRegisterationNo();
            
           foreach(ExamBiz objBiz in this)
            {
                objBiz.StartSeatNo = objBiz.GroupCol.Cast<RegisterationGroupBiz>().Min(x => x.MinSeatNo);
                objBiz.EndSeatNo = objBiz.GroupCol.Cast<RegisterationGroupBiz>().Max(x => x.MaxSeatNo);
                objBiz.RegisteredCount = objBiz.GroupCol.Cast<RegisterationGroupBiz>().Sum(x => x.RegisterationNo);
            }
             if (blSetRegisteration)
                objCol.SetRegisterationCol(intFaculty);
        }
       public RegisterationExamCol GetRegisterationExamCol(int intFaculty)
        {
            RegisterationExamCol Returned = new RegisterationExamCol(true);
           if(Count>0)
            {
                RegisterationExamDb objExamDb = new RegisterationExamDb() { Faculty =intFaculty,ExamIDs = IDs };
                DataTable dtTemp = objExamDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                    Returned.Add(new RegisterationExamBiz(objDr));
            }
            return Returned;
        }
        #endregion
    }
}