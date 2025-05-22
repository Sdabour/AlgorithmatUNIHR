using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class SemesterDb
    {
        //SemesterID, SemesterDesc, SemesterDateStart, SemesterDateEnd

        #region Constructor
        public SemesterDb()
        {
        }
        public SemesterDb(DataRow objDr)
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
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        DateTime _DateStart;
        public DateTime DateStart
        {
            set => _DateStart = value;
            get => _DateStart;
        }
        DateTime _DateEnd;
        public DateTime DateEnd
        {
            set => _DateEnd = value;
            get => _DateEnd;
        }
        int _Type;
        public int Type
        {
            set => _Type = value;get => _Type;
        }
        int _MaxStatementID;
        public int MaxStatementID
        {
            get => _MaxStatementID ;

        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNISemester (SemesterDesc,SemesterDateStart,SemesterDateEnd,SemesterType,UsrIns,TimIns) values ('" + Desc + "'," + (DateStart.ToOADate() - 2).ToString() + "," + (DateEnd.ToOADate() - 2).ToString() + ","+_Type +","+ SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNISemester set SemesterDesc='" + Desc + "'" +
           ",SemesterDateStart=" + (DateStart.ToOADate() - 2).ToString() + "" +
           ",SemesterDateEnd=" + (DateEnd.ToOADate() - 2).ToString() + "" +
           ",SemesterType="+_Type+
           ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where SemesterID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNISemester set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strResult = "";
                string Returned = @" select SemesterID,SemesterDesc,SemesterDateStart,SemesterDateEnd,SemesterType,SemesterMaxStatement 
  from UNISemester 
      LEFT OUTER JOIN
                      (SELECT StatementSemester, MAX(StatementID) AS SemesterMaxStatement
                       FROM      dbo.UNIResultStatement
                       GROUP BY StatementSemester) AS MaxStatementTable ON dbo.UNISemester.SemesterID = MaxStatementTable.StatementSemester ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["SemesterID"] != null)
                int.TryParse(objDr["SemesterID"].ToString(), out _ID);

            if (objDr.Table.Columns["SemesterDesc"] != null)
                _Desc = objDr["SemesterDesc"].ToString();

            if (objDr.Table.Columns["SemesterDateStart"] != null)
                DateTime.TryParse(objDr["SemesterDateStart"].ToString(), out _DateStart);

            if (objDr.Table.Columns["SemesterDateEnd"] != null)
                DateTime.TryParse(objDr["SemesterDateEnd"].ToString(), out _DateEnd);
            if (objDr.Table.Columns["SemesterMaxStatement"] != null)
                int.TryParse(objDr["SemesterMaxStatement"].ToString(), out _MaxStatementID);
            if (objDr.Table.Columns["SemesterType"] != null)
                int.TryParse(objDr["SemesterType"].ToString(), out _Type);
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
            strSql += " order by case when SemesterType = 5 then 1 else 0 end ";

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public static int MaxSemester()
        {
            string strSql = @"SELECT MAX(SemesterID) AS MaxSemester
FROM     dbo.UNISemester";
            return (int)SysData.SharpVisionBaseDb.ReturnScalar(strSql);
        }
        public DataTable GetLastSemester()
        {
            string strMaxSemester = @"SELECT MAX(SemesterID) AS MaxSemester
 FROM     dbo.UNISemester where SemesterType <>5 ";
            string strSql = SearchStr + "  inner join ("+strMaxSemester+ @") as MaxSemesterTable  on UNISemester.SemesterID=MaxSemesterTable.MaxSemester ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}