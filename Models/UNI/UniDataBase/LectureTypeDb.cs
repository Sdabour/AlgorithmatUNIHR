using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class LectureTypeDb
    {

        #region Constructor
        public LectureTypeDb()
        {
        }
        public LectureTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }

        public string AddStr
        {
            get
            {
                string Returned = " insert into UNILectureType (LectureTypeID,LectureTypeCode,LectureTypeNameA,LectureTypeNameE,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNILectureType set " + "LectureTypeID=" + ID + "" +
           ",LectureTypeCode='" + Code + "'" +
           ",LectureTypeNameA='" + NameA + "'" +
           ",LectureTypeNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNILectureType set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select LectureTypeID,LectureTypeCode,LectureTypeNameA,LectureTypeNameE from UNILectureType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["LectureTypeID"] != null)
                int.TryParse(objDr["LectureTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["LectureTypeCode"] != null)
                _Code = objDr["LectureTypeCode"].ToString();

            if (objDr.Table.Columns["LectureTypeNameA"] != null)
                _NameA = objDr["LectureTypeNameA"].ToString();

            if (objDr.Table.Columns["LectureTypeNameE"] != null)
                _NameE = objDr["LectureTypeNameE"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}