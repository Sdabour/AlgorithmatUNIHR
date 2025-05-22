using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class FacultyDb
    {

        #region Constructor
        public FacultyDb()
        {
        }
        public FacultyDb(DataRow objDr)
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
        string _Dean;
        public string Dean
        {
            set => _Dean = value;
            get => _Dean;
        }
        string _ControlHead;
        public string ControlHead
        {
            set => _ControlHead = value;
            get => _ControlHead;
        }
        string _ControlViceHead;
        public string ControlViceHead
        {
            set => _ControlViceHead = value;
            get => _ControlViceHead;
        }
        string _CommitteeHead;
        public string CommitteeHead
        {
            set => _CommitteeHead = value;
            get => _CommitteeHead;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNIFaculty (FacultyID,FacultyCode,FacultyNameA,FacultyNameE,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "','" + NameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNIFaculty set " + "FacultyID=" + ID + "" +
           ",FacultyCode='" + Code + "'" +
           ",FacultyNameA='" + NameA + "'" +
           ",FacultyNameE='" + NameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNIFaculty set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select FacultyID,FacultyCode,FacultyNameA,FacultyNameE,FacultyDean,FacultyControlHead,FacultyControlViceHead,FacultyCommitteeHead 
   from UNIFaculty  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["FacultyID"] != null)
                int.TryParse(objDr["FacultyID"].ToString(), out _ID);

            if (objDr.Table.Columns["FacultyCode"] != null)
                _Code = objDr["FacultyCode"].ToString();

            if (objDr.Table.Columns["FacultyNameA"] != null)
                _NameA = objDr["FacultyNameA"].ToString();

            if (objDr.Table.Columns["FacultyNameE"] != null)
                _NameE = objDr["FacultyNameE"].ToString();
            if (objDr.Table.Columns["FacultyDean"] != null)
                _Dean = objDr["FacultyDean"].ToString();

            if (objDr.Table.Columns["FacultyControlHead"] != null)
                _ControlHead = objDr["FacultyControlHead"].ToString();

            if (objDr.Table.Columns["FacultyControlViceHead"] != null)
                _ControlViceHead = objDr["FacultyControlViceHead"].ToString();

            if (objDr.Table.Columns["FacultyCommitteeHead"] != null)
                _CommitteeHead = objDr["FacultyCommitteeHead"].ToString();
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