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
    public class LevelCol:CollectionBase
    {

        #region Constructor
        public LevelCol()
        {
            LevelDb objDb = new LevelDb();

            DataTable dtTemp = objDb.Search();

            LevelBiz objBiz;
            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new LevelBiz(objDR);
                Add(objBiz);
            }
        }
        public LevelCol(bool blIsEmbty,int intFaculty)
        {
            if (blIsEmbty)
                return;
            LevelBiz objBiz = new LevelBiz();
            objBiz.Desc = "غير محدد";
            Add(objBiz);
            LevelDb objDb = new LevelDb();
            objDb.Faculty = intFaculty;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new LevelBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public LevelBiz this[int intIndex]
        {
            get
            {
                return (LevelBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(LevelBiz objBiz)
        {
            List.Add(objBiz);
        }
        public LevelCol GetCol(string strTemp)
        {
            LevelCol Returned = new LevelCol(true,0);
            foreach (LevelBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("LevelID"), new DataColumn("LevelFaculty"), new DataColumn("LevelOrder"), new DataColumn("LevelDesc"), new DataColumn("LevelCreditHourFrom"), new DataColumn("LevelCreditHourTo"), new DataColumn("LevelSemesterType1MaxLimitedHour"), new DataColumn("LevelSemesterType2MaxLimitedHour"), new DataColumn("LevelSemesterType3MaxLimitedHour"), new DataColumn("LevelLowGPALimitedHour") });
            DataRow objDr;
            foreach (LevelBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["LevelID"] = objBiz.ID;
                objDr["LevelFaculty"] = objBiz.Faculty;
                objDr["LevelOrder"] = objBiz.Order;
                objDr["LevelDesc"] = objBiz.Desc;
                objDr["LevelCreditHourFrom"] = objBiz.CreditHourFrom;
                objDr["LevelCreditHourTo"] = objBiz.CreditHourTo;
                objDr["LevelSemesterType1MaxLimitedHour"] = objBiz.SemesterType1MaxLimitedHour;
                objDr["LevelSemesterType2MaxLimitedHour"] = objBiz.SemesterType2MaxLimitedHour;
                objDr["LevelSemesterType3MaxLimitedHour"] = objBiz.SemesterType3MaxLimitedHour;
                objDr["LevelLowGPALimitedHour"] = objBiz.LowGPALimitedHour;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}