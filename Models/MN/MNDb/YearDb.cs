using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMN.MN.MNDb
{
    public class YearDb
    {

        #region Constructor
        public YearDb()
        {
        }
        public YearDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        int _No;
        public int No
        {
            set
            {
                _No = value;
            }
            get
            {
                return _No;
            }
        }
        string _Desc;
        public string Desc
        {
            set
            {
                _Desc = value;
            }
            get
            {
                return _Desc;
            }
        }
        string _Desc1;
        public string Desc1
        {
            set
            {
                _Desc1 = value;
            }
            get
            {
                return _Desc1;
            }
        }
        string _Desc2;
        public string Desc2
        {
            set
            {
                _Desc2 = value;
            }
            get
            {
                return _Desc2;
            }
        }
        DateTime _StartDate;
        public DateTime StartDate
        {
            set
            {
                _StartDate = value;
            }
            get
            {
                return _StartDate;
            }
        }
        DateTime _EndDate;
        public DateTime EndDate
        {
            set
            {
                _EndDate = value;
            }
            get
            {
                return _EndDate;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MNYear (YearID,YearNo,YearDesc,YearStartDate,YearEndDate,YearDesc1,YearDesc2,UsrIns,TimIns) values (" + No + ",'" + Desc + "'," + (StartDate.ToOADate() - 2).ToString() + "," + (EndDate.ToOADate() - 2).ToString()+",'"+_Desc1 +"','"+_Desc2+ "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MNYear set  YearNo=" + No + "" +
           ",YearDesc='" + Desc + "'" +
           ",YearStartDate=" + (StartDate.ToOADate() - 2).ToString() + "" +
           ",YearEndDate=" + (EndDate.ToOADate() - 2).ToString() + ""
           + ",YearDesc1='" + Desc1 + "'"
           + ",YearDesc2='" + Desc2 + "'"
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where YearID=" + ID ;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MNYear set Dis = GetDate() where YearID = "+ ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select YearID,YearNo,YearDesc,YearStartDate,YearEndDate,YearDesc1,YearDesc2 from MNYear  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["YearID"] != null)
                int.TryParse(objDr["YearID"].ToString(), out _ID);

            if (objDr.Table.Columns["YearNo"] != null)
                int.TryParse(objDr["YearNo"].ToString(), out _No);

            if (objDr.Table.Columns["YearDesc"] != null)
                _Desc = objDr["YearDesc"].ToString();

            if (objDr.Table.Columns["YearDesc1"] != null)
                _Desc1 = objDr["YearDesc1"].ToString();
            if (objDr.Table.Columns["YearDesc2"] != null)
                _Desc2 = objDr["YearDesc2"].ToString();
            if (objDr.Table.Columns["YearStartDate"] != null)
                DateTime.TryParse(objDr["YearStartDate"].ToString(), out _StartDate);

            if (objDr.Table.Columns["YearEndDate"] != null)
                DateTime.TryParse(objDr["YearEndDate"].ToString(), out _EndDate);
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

            strSql += " order by MNYear.YearStartDate ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
