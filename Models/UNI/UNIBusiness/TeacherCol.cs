using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class TeacherCol:CollectionBase
    {

        #region Constructor
        public TeacherCol()
        {

        }
        public TeacherCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TeacherBiz objBiz = new TeacherBiz();
           

            TeacherDb objDb = new TeacherDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TeacherBiz(objDR);
                Add(objBiz);
            }
        }
        public TeacherCol(int intFaculty,int intType,string strName)
        {
            TeacherDb objDb = new TeacherDb() { Faculty = intFaculty, Code = strName, Type = intType };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new TeacherBiz(objDr));

            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TeacherBiz this[int intIndex]
        {
            get
            {
                return (TeacherBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TeacherBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TeacherCol GetCol(string strTemp)
        {
            TeacherCol Returned = new TeacherCol(true);
            foreach (TeacherBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TeacherID"), new DataColumn("TeacherCode"), new DataColumn("TeacherName"), new DataColumn("TeacherFamousName"), new DataColumn("TeacherShortName"), new DataColumn("TeacherFunctionGroup"), new DataColumn("TeacherFaculty"), new DataColumn("TeacherFacultyCode"), new DataColumn("TeacherFacultyNameA"), new DataColumn("TeacherFacultyNameE") });
            DataRow objDr;
            foreach (TeacherBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TeacherID"] = objBiz.ID;
                objDr["TeacherCode"] = objBiz.Code;
                objDr["TeacherName"] = objBiz.Name;
                objDr["TeacherFamousName"] = objBiz.FamousName;
                objDr["TeacherShortName"] = objBiz.ShortName;
                objDr["TeacherFunctionGroup"] = objBiz.FunctionGroup;
                objDr["TeacherFaculty"] = objBiz.FacultyBiz.ID;
                objDr["TeacherFacultyCode"] = objBiz.FacultyBiz.Code;
                objDr["TeacherFacultyNameA"] = objBiz.FacultyBiz.NameA;
                objDr["TeacherFacultyNameE"] = objBiz.FacultyBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}