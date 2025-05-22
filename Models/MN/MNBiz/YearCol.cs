using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
    public class YearCol : CollectionBase
    {
        static Hashtable _YearHs;
        public static Hashtable CacheYearHs
        {
            get
            {
                if (_YearHs == null)
                {
                    _YearHs = new Hashtable();
                    YearDb objYearDb = new YearDb();
                    DataTable dtTemp = objYearDb.Search();
                    YearBiz objBiz;
                    YearBiz objPrevious=new YearBiz();
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objBiz = new YearBiz(objDr);
                        if(objPrevious.ID!= 0)
                        {
                            if (objBiz.StartDate < objPrevious.EndDate)
                                objBiz.StartDate = objPrevious.EndDate.AddDays(1);
                        }
                        if (objBiz.EndDate.Date <= objBiz.StartDate.Date)
                            continue;
                            objPrevious = objBiz;
                       
                        _YearHs.Add(objBiz.ID.ToString(), objBiz);
                    }
                }
                return _YearHs;
            }
        }
        public static YearCol CacheYearCol
        {
            get
            {
                List<YearBiz> objYearCol = new List<YearBiz>();

                foreach(object objKey in CacheYearHs.Keys)
                {
                    objYearCol.Add((YearBiz)CacheYearHs[objKey.ToString()]);
                }
                objYearCol = (from objYear in objYearCol
                              orderby objYear.StartDate
                              select objYear).ToList();
                YearCol Returned = new YearCol(true);
                foreach (YearBiz objYearBiz in objYearCol)
                    Returned.Add(objYearBiz);
                return Returned;
            }
        }
        #region Constructor
        public YearCol()
        {

        }
        public YearCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            YearBiz objBiz = new YearBiz();
            

            YearDb objDb = new YearDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new YearBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public YearBiz this[int intIndex]
        {
            get
            {
                return (YearBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(YearBiz objBiz)
        {
            List.Add(objBiz);
        }
        public YearCol GetCol(string strTemp)
        {
            YearCol Returned = new YearCol(true);
            foreach (YearBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("YearID"), new DataColumn("YearNo"), new DataColumn("YearDesc"), new DataColumn("YearStartDate", System.Type.GetType("System.DateTime")), new DataColumn("YearEndDate", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (YearBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["YearID"] = objBiz.ID;
                objDr["YearNo"] = objBiz.No;
                objDr["YearDesc"] = objBiz.Desc;
                objDr["YearStartDate"] = objBiz.StartDate;
                objDr["YearEndDate"] = objBiz.EndDate;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public YearCol GetYearColFromStart(DateTime dtStart,DateTime dtEnd)
        {
            YearCol Returned = new YearCol(true);
            YearCol objYearCol = CacheYearCol;
            foreach(YearBiz objYearBiz in objYearCol)
            {
                if(objYearBiz.StartDate.Date.Year == 2007)
                {

                }
                //if (objYearBiz.StartDate.Date <= dtStart.Date &&
                //    objYearBiz.EndDate.Date >= dtStart.Date
                //    &&
                //    objYearBiz.StartDate.Date <= dtEnd.Date &&
                //    objYearBiz.EndDate.Date >= dtEnd.Date)
                if (objYearBiz.EndDate.Date >= dtStart.Date 
                    &&
                    objYearBiz.EndDate.Date <= dtEnd.Date )
                    Returned.Add(objYearBiz);
            }
            return Returned;
        }
        public YearBiz GetYearBiz(DateTime dtStart)
        {
            YearBiz Returned = new YearBiz();
            YearCol objYearCol = CacheYearCol;
            foreach (YearBiz objYearBiz in objYearCol)
            {
                if (objYearBiz.StartDate.Date.Year == 2021)
                {

                }
                //if (objYearBiz.StartDate.Date <= dtStart.Date &&
                //    objYearBiz.EndDate.Date >= dtStart.Date
                //    &&
                //    objYearBiz.StartDate.Date <= dtEnd.Date &&
                //    objYearBiz.EndDate.Date >= dtEnd.Date)
                if (objYearBiz.StartDate.Date <= dtStart.Date
                    &&
                    objYearBiz.EndDate.Date >= dtStart.Date)
                {
                    Returned= objYearBiz;
                    break;
                }
            }
            return Returned;
        }
        #endregion
    }
}
