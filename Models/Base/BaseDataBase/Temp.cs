using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
namespace BaseDataBase
{
    class Temp
    {
        //for copy only


        //#region Private Data
        //int _ID;
        //string _Code;
        //#endregion
        //#region Constructors

        //#endregion
        //#region Public Properties
        //public int ID
        //{
        //    set
        //    {
        //        _ID = value;
        //    }
        //    get
        //    {
        //        return _ID;
        //    }
        //}
        //public string Code
        //{
        //    set
        //    {
        //        _Code = value;
        //    }
        //    get
        //    {
        //        return _Code;
        //    }
        //}
        public string AddStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = "";
                return Returned;
            }
        }
        //public static string SearchStr
        //{
        //    get
        //    {
        //        string Returned = "";
        //        return Returned;
        //    }
        //}
        //#endregion
        //#region Private Methods
        //void SetData(DataRow objDr)
        //{

        //}
        //#endregion
        //#region Public Methods
        //public void Add()
        //{
        //    string strSql = AddStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public void Edit()
        //{
        //    string strSql = EditStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public void Delete()
        //{
        //    string strSql = DeleteStr;
        //    SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        //}
        //public DataTable Search()
        //{
        //    string strSql = SearchStr;
        //    return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        //}
        //#endregion



        

        void TempVoid()
        {
            DataTable _CurrentResultTable = new DataTable();
            DataTable dtReadTable = new DataTable();
        var vrJoined=    from objDr in _CurrentResultTable.AsEnumerable()
            join objDr1 in dtReadTable.AsEnumerable()
on new { Meter = objDr.Field<int>("EMeter"), MeasureType = objDr.Field<int>("EMeasureType") } equals new { Meter = objDr1.Field<int>("EMeter"), MeasureType = objDr1.Field<int>("EMeasureType") }
         select new { ProductName1 = objDr.Field<string>("ProductName"), ProductName2 = objDr1.Field<string>("ProductName") ,Value1=objDr.Field<double>("EMeasureValue"), Value2 = objDr1.Field<double>("EMeasureValue"),Threshold = objDr.Field<double>("EMeasureValue") };
            List<string> lstProduct1 = vrJoined.Where(x =>Math.Abs(x.Value1 - x.Value2) > x.Threshold).Select(y=>y.ProductName1).ToList();
            List<string> lstProduct2 = vrJoined.Where(x => x.ProductName1!= x.ProductName2).Select(y => y.ProductName1).ToList();
            if(lstProduct1.Count>0 || lstProduct2.Count>0)
            { 
            }
            int intCount =  vrJoined.Count();
        }


       


    }
}
