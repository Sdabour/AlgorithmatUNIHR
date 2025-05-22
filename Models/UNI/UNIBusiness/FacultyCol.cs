using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
using SharpVision.SystemBase;
using System.Collections;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class FacultyCol:CollectionBase
    {

        #region Constructor
        public FacultyCol()
        {
            FacultyBiz objBiz = new FacultyBiz();
            objBiz.ID = 0;
           

            FacultyDb objDb = new FacultyDb();

            DataTable dtTemp = objDb.Search();

            if (dtTemp != null)
            {
                foreach (DataRow
                        objDR in dtTemp.Rows)
                {
                    objBiz = new FacultyBiz(objDR);
                    Add(objBiz);
                }
            }
        }
        public FacultyCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            FacultyBiz objBiz = new FacultyBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            FacultyDb objDb = new FacultyDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new FacultyBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public FacultyBiz this[int intIndex]
        {
            get
            {
                return (FacultyBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(FacultyBiz objBiz)
        {
            List.Add(objBiz);
        }
        public FacultyCol GetCol(string strTemp)
        {
            FacultyCol Returned = new FacultyCol(true);
            foreach (FacultyBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("FacultyID"), new DataColumn("FacultyCode"), new DataColumn("FacultyNameA"), new DataColumn("FacultyNameE") });
            DataRow objDr;
            foreach (FacultyBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["FacultyID"] = objBiz.ID;
                objDr["FacultyCode"] = objBiz.Code;
                objDr["FacultyNameA"] = objBiz.NameA;
                objDr["FacultyNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public FacultyBiz GetByID(int intID)
        {
            FacultyBiz Returned = new FacultyBiz();
            foreach(FacultyBiz objBiz in this)
            {
                if(objBiz.ID== intID)
                {
                    Returned = objBiz;
                    break;
                }
            }
            return Returned;
        }
        #endregion
    }
}