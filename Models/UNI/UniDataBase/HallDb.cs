using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class HallDb
    {

        #region Constructor
        public HallDb()
        {
        }
        public HallDb(DataRow objDr)
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
        int _FacultyID;
        public int FacultyID
        {
            set => _FacultyID = value;
            get => _FacultyID;
        }
        string _FacultyCode;
        public string FacultyCode
        {
            set => _FacultyCode = value;
            get => _FacultyCode;
        }
        string _FacultyNameA;
        public string FacultyNameA
        {
            set => _FacultyNameA = value;
            get => _FacultyNameA;
        }
        string _FacultyNameE;
        public string FacultyNameE
        {
            set => _FacultyNameE = value;
            get => _FacultyNameE;
        }
        string _Name;
        public string Name
        {
            set => _Name = value;
            get => _Name;
        }
        double _Capacity;
        public double Capacity
        {
            set => _Capacity = value;
            get => _Capacity;
        }
        int _LectureTypeID;
        public int LectureTypeID
        {
            set => _LectureTypeID = value;
            get => _LectureTypeID;
        }
        string _LectureTypeCode;
        public string LectureTypeCode
        {
            set => _LectureTypeCode = value;
            get => _LectureTypeCode;
        }
        string _LectureTypeNameA;
        public string LectureTypeNameA
        {
            set => _LectureTypeNameA = value;
            get => _LectureTypeNameA;
        }
        string _LectureTypeNameE;
        public string LectureTypeNameE
        {
            set => _LectureTypeNameE = value;
            get => _LectureTypeNameE;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIHall (HallID,HallFacultyID,HallFacultyCode,HallFacultyNameA,HallFacultyNameE,HallName,HallCapacity,HallLectureTypeID,HallLectureTypeCode,HallLectureTypeNameA,HallLectureTypeNameE,UsrIns,TimIns) values (," + ID + "," + FacultyID + ",'" + FacultyCode + "','" + FacultyNameA + "','" + FacultyNameE + "','" + Name + "'," + Capacity + "," + LectureTypeID + ",'" + LectureTypeCode + "','" + LectureTypeNameA + "','" + LectureTypeNameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIHall set " + "HallID=" + ID + "" +
           ",HallFacultyID=" + FacultyID + "" +
           ",HallFacultyCode='" + FacultyCode + "'" +
           ",HallFacultyNameA='" + FacultyNameA + "'" +
           ",HallFacultyNameE='" + FacultyNameE + "'" +
           ",HallName='" + Name + "'" +
           ",HallCapacity=" + Capacity + "" +
           ",HallLectureTypeID=" + LectureTypeID + "" +
           ",HallLectureTypeCode='" + LectureTypeCode + "'" +
           ",HallLectureTypeNameA='" + LectureTypeNameA + "'" +
           ",HallLectureTypeNameE='" + LectureTypeNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIHall set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.UNIHall.HallID, dbo.UNIFaculty.FacultyID AS HallFacultyID, dbo.UNIFaculty.FacultyCode AS HallFacultyCode, dbo.UNIFaculty.FacultyNameA AS HallFacultyNameA, dbo.UNIFaculty.FacultyNameE AS HallFacultyNameE, 
                  dbo.UNIHall.HallName, dbo.UNIHall.HallCapacity, dbo.UNILectureType.LectureTypeID AS HallLectureTypeID, dbo.UNILectureType.LectureTypeCode AS HallLectureTypeCode, 
                  dbo.UNILectureType.LectureTypeNameA AS HallLectureTypeNameA, dbo.UNILectureType.LectureTypeNameE AS HallLectureTypeNameE
FROM     dbo.UNIHall INNER JOIN
                  dbo.UNIFaculty ON dbo.UNIHall.HallFaculty = dbo.UNIFaculty.FacultyID LEFT OUTER JOIN
                  dbo.UNILectureType ON dbo.UNIHall.HallLectureType = dbo.UNILectureType.LectureTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["HallID"] != null)
                int.TryParse(objDr["HallID"].ToString(), out _ID);

            if (objDr.Table.Columns["HallFacultyID"] != null)
                int.TryParse(objDr["HallFacultyID"].ToString(), out _FacultyID);

            if (objDr.Table.Columns["HallFacultyCode"] != null)
                _FacultyCode = objDr["HallFacultyCode"].ToString();

            if (objDr.Table.Columns["HallFacultyNameA"] != null)
                _FacultyNameA = objDr["HallFacultyNameA"].ToString();

            if (objDr.Table.Columns["HallFacultyNameE"] != null)
                _FacultyNameE = objDr["HallFacultyNameE"].ToString();

            if (objDr.Table.Columns["HallName"] != null)
                _Name = objDr["HallName"].ToString();

            if (objDr.Table.Columns["HallCapacity"] != null)
                double.TryParse(objDr["HallCapacity"].ToString(), out _Capacity);

            if (objDr.Table.Columns["HallLectureTypeID"] != null)
                int.TryParse(objDr["HallLectureTypeID"].ToString(), out _LectureTypeID);

            if (objDr.Table.Columns["HallLectureTypeCode"] != null)
                _LectureTypeCode = objDr["HallLectureTypeCode"].ToString();

            if (objDr.Table.Columns["HallLectureTypeNameA"] != null)
                _LectureTypeNameA = objDr["HallLectureTypeNameA"].ToString();

            if (objDr.Table.Columns["HallLectureTypeNameE"] != null)
                _LectureTypeNameE = objDr["HallLectureTypeNameE"].ToString();
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
            string strSql = SearchStr + " where (1=1)";
            if (_FacultyID != 0)
                strSql += " and UNIFaculty.FacultyID="+_FacultyID;


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}