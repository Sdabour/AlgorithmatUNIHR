using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Collections;
using AlgorithmatMVC.UNI.UniDataBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class SemesterCol:CollectionBase
    {

        #region Constructor
        public SemesterCol()
        {
            SemesterDb objDb = new SemesterDb();

            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "SemesterID desc");
            SemesterBiz objBiz;
            foreach (DataRow objDR in arrDr)
            {
                objBiz = new SemesterBiz(objDR);
                Add(objBiz);
            }
        }
        public SemesterCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            SemesterBiz objBiz = new SemesterBiz();
            objBiz.ID = 0;
          

            SemesterDb objDb = new SemesterDb();

            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr = dtTemp.Select("", "SemesterID desc");

            foreach (DataRow objDR in arrDr)
            {
                objBiz = new SemesterBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public SemesterBiz this[int intIndex]
        {
            get
            {
                return (SemesterBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(SemesterBiz objBiz)
        {
            List.Add(objBiz);
        }
        public SemesterCol GetCol(string strTemp)
        {
            SemesterCol Returned = new SemesterCol(true);
            foreach (SemesterBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("SemesterID"), new DataColumn("SemesterDesc"), new DataColumn("SemesterDateStart", System.Type.GetType("System.DateTime")), new DataColumn("SemesterDateEnd", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (SemesterBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["SemesterID"] = objBiz.ID;
                objDr["SemesterDesc"] = objBiz.Desc;
                objDr["SemesterDateStart"] = objBiz.DateStart;
                objDr["SemesterDateEnd"] = objBiz.DateEnd;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public SemesterCol Copy()
        {
            SemesterCol Returned = new SemesterCol(true);
            foreach (SemesterBiz objBiz in this)
                Returned.Add(objBiz);
            return Returned;
        }
        #endregion
    }
}