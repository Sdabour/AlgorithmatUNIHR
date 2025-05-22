using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Collections;
using SharpVision.SystemBase;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class HallCol:CollectionBase
    {

        #region Constructor
        public HallCol(int intFaculty)
        {
            HallDb objDb = new HallDb() { FacultyID = intFaculty };
            DataTable dtTemp = objDb.Search();
            foreach(DataRow objDr in dtTemp.Rows)
            {
                Add(new HallBiz(objDr));
            }

        }
        public HallCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            HallBiz objBiz = new HallBiz();
            

            HallDb objDb = new HallDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new HallBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public HallBiz this[int intIndex]
        {
            get
            {
                return (HallBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(HallBiz objBiz)
        {
            List.Add(objBiz);
        }
        public HallCol GetCol(string strTemp)
        {
            HallCol Returned = new HallCol(true);
            foreach (HallBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("HallID"), new DataColumn("HallFacultyID"), new DataColumn("HallFacultyCode"), new DataColumn("HallFacultyNameA"), new DataColumn("HallFacultyNameE"), new DataColumn("HallName"), new DataColumn("HallCapacity"), new DataColumn("HallLectureTypeID"), new DataColumn("HallLectureTypeCode"), new DataColumn("HallLectureTypeNameA"), new DataColumn("HallLectureTypeNameE") });
            DataRow objDr;
            foreach (HallBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["HallID"] = objBiz.ID;
                objDr["HallFacultyID"] = objBiz.FacultyBiz.ID;
                objDr["HallFacultyCode"] = objBiz.FacultyBiz.Code;
                objDr["HallFacultyNameA"] = objBiz.FacultyBiz.NameA;
                objDr["HallFacultyNameE"] = objBiz.FacultyBiz.NameE;
                objDr["HallName"] = objBiz.Name;
                objDr["HallCapacity"] = objBiz.Capacity;
                objDr["HallLectureTypeID"] = objBiz.LectureTypeBiz.ID;
                objDr["HallLectureTypeCode"] = objBiz.LectureTypeBiz.Code;
                objDr["HallLectureTypeNameA"] = objBiz.LectureTypeBiz.NameA;
                objDr["HallLectureTypeNameE"] = objBiz.LectureTypeBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}