using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class ResultStatementDb
    {

        #region Constructor
        public ResultStatementDb()
        {
        }
        public ResultStatementDb(DataRow objDr)
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
        int _Semester;
        public int Semester
        {
            set => _Semester = value;
            get => _Semester;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        int _Faculty;
        public int Faculty
        {
            set => _Faculty = value;
            get => _Faculty;
        }
        int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        DateTime _ResultPublishDate;
        public DateTime ResultPublishDate
        {
            set => _ResultPublishDate = value;
            get => _ResultPublishDate;
        }
        int _OnlyLastStatementStatus;
        public int OnlyLastStatementStatus { set => _OnlyLastStatementStatus = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIResultStatement (StatementDesc,StatementSemester,StatementDate,StatementFaculty,StatementStatus,ResultStatementPublishDate,UsrIns,TimIns) values ('" + Desc + "'," + Semester + "," + (Date.ToOADate() - 2).ToString() + "," + Faculty + "," + Status + "," + (ResultPublishDate.ToOADate() - 2).ToString() + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIResultStatement set StatementDesc='" + Desc + "'" +
           ",StatementSemester=" + Semester + "" +
           ",StatementDate=" + (Date.ToOADate() - 2).ToString() + "" +
           ",StatementFaculty=" + Faculty + "" +
           ",StatementStatus=" + Status + "" +
           ",ResultStatementPublishDate=" + (ResultPublishDate.ToOADate() - 2).ToString() + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where  StatementID = " + ID + "";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIResultStatement set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select StatementID,StatementDesc,StatementSemester,StatementDate,StatementFaculty,StatementStatus,ResultStatementPublishDate,SemesterTable.* 
  from UNIResultStatement 
   inner join ("+new SemesterDb().SearchStr+ @") as SemesterTable 
 on UNIResultStatement.StatementSemester = SemesterTable.SemesterID";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["StatementID"] != null)
                int.TryParse(objDr["StatementID"].ToString(), out _ID);

            if (objDr.Table.Columns["StatementDesc"] != null)
                _Desc = objDr["StatementDesc"].ToString();

            if (objDr.Table.Columns["StatementSemester"] != null)
                int.TryParse(objDr["StatementSemester"].ToString(), out _Semester);

            if (objDr.Table.Columns["StatementDate"] != null)
                DateTime.TryParse(objDr["StatementDate"].ToString(), out _Date);

            if (objDr.Table.Columns["StatementFaculty"] != null)
                int.TryParse(objDr["StatementFaculty"].ToString(), out _Faculty);

            if (objDr.Table.Columns["StatementStatus"] != null)
                int.TryParse(objDr["StatementStatus"].ToString(), out _Status);

            if (objDr.Table.Columns["ResultStatementPublishDate"] != null)
                DateTime.TryParse(objDr["ResultStatementPublishDate"].ToString(), out _ResultPublishDate);
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
            string strSql = SearchStr + " where (Dis is null) ";

            if (_OnlyLastStatementStatus == 1)
                strSql += @"  and dbo.UNIResultStatement.StatementID
 =(SELECT MAX(StatementID) AS LastStatement
FROM dbo.UNIResultStatement
WHERE(Dis IS NULL))";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}