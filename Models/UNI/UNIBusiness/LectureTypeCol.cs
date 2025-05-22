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
    public class LectureTypeCol:CollectionBase
    {

        #region Constructor
        public LectureTypeCol()
        {

        }
        public LectureTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            LectureTypeBiz objBiz = new LectureTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            LectureTypeDb objDb = new LectureTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new LectureTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public LectureTypeBiz this[int intIndex]
        {
            get
            {
                return (LectureTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(LectureTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public LectureTypeCol GetCol(string strTemp)
        {
            LectureTypeCol Returned = new LectureTypeCol(true);
            foreach (LectureTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("LectureTypeID"), new DataColumn("LectureTypeCode"), new DataColumn("LectureTypeNameA"), new DataColumn("LectureTypeNameE") });
            DataRow objDr;
            foreach (LectureTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["LectureTypeID"] = objBiz.ID;
                objDr["LectureTypeCode"] = objBiz.Code;
                objDr["LectureTypeNameA"] = objBiz.NameA;
                objDr["LectureTypeNameE"] = objBiz.NameE;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}