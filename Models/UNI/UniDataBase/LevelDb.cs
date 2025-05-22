using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class LevelDb
    {

        #region Constructor
        public LevelDb()
        {
        }
        public LevelDb(DataRow objDr)
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
        int _Faculty;
        public int Faculty
        {
            set => _Faculty = value;
            get => _Faculty;
        }
        int _Order;
        public int Order
        {
            set => _Order = value;
            get => _Order;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }
        int _CreditHourFrom;
        public int CreditHourFrom
        {
            set => _CreditHourFrom = value;
            get => _CreditHourFrom;
        }
        int _CreditHourTo;
        public int CreditHourTo
        {
            set => _CreditHourTo = value;
            get => _CreditHourTo;
        }
        int _SemesterType1MaxLimitedHour;
        public int SemesterType1MaxLimitedHour
        {
            set => _SemesterType1MaxLimitedHour = value;
            get => _SemesterType1MaxLimitedHour;
        }
        int _SemesterType2MaxLimitedHour;
        public int SemesterType2MaxLimitedHour
        {
            set => _SemesterType2MaxLimitedHour = value;
            get => _SemesterType2MaxLimitedHour;
        }
        int _SemesterType3MaxLimitedHour;
        public int SemesterType3MaxLimitedHour
        {
            set => _SemesterType3MaxLimitedHour = value;
            get => _SemesterType3MaxLimitedHour;
        }
        int _LowGPALimitedHour;
        public int LowGPALimitedHour
        {
            set => _LowGPALimitedHour = value;
            get => _LowGPALimitedHour;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UniLevel (LevelID,LevelFaculty,LevelOrder,LevelDesc,LevelCreditHourFrom,LevelCreditHourTo,LevelSemesterType1MaxLimitedHour,LevelSemesterType2MaxLimitedHour,LevelSemesterType3MaxLimitedHour,LevelLowGPALimitedHour,UsrIns,TimIns) values (," + ID + "," + Faculty + "," + Order + ",'" + Desc + "'," + CreditHourFrom + "," + CreditHourTo + "," + SemesterType1MaxLimitedHour + "," + SemesterType2MaxLimitedHour + "," + SemesterType3MaxLimitedHour + "," + LowGPALimitedHour + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UniLevel set  LevelFaculty=" + Faculty + "" +
           ",LevelOrder=" + Order + "" +
           ",LevelDesc='" + Desc + "'" +
           ",LevelCreditHourFrom=" + CreditHourFrom + "" +
           ",LevelCreditHourTo=" + CreditHourTo + "" +
           ",LevelSemesterType1MaxLimitedHour=" + SemesterType1MaxLimitedHour + "" +
           ",LevelSemesterType2MaxLimitedHour=" + SemesterType2MaxLimitedHour + "" +
           ",LevelSemesterType3MaxLimitedHour=" + SemesterType3MaxLimitedHour + "" +
           ",LevelLowGPALimitedHour=" + LowGPALimitedHour + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where LevelID="+_ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UniLevel set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select LevelID,LevelFaculty,LevelOrder,LevelDesc,LevelCreditHourFrom,LevelCreditHourTo,LevelSemesterType1MaxLimitedHour,LevelSemesterType2MaxLimitedHour,LevelSemesterType3MaxLimitedHour,LevelLowGPALimitedHour from UniLevel  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["LevelID"] != null)
                int.TryParse(objDr["LevelID"].ToString(), out _ID);

            if (objDr.Table.Columns["LevelFaculty"] != null)
                int.TryParse(objDr["LevelFaculty"].ToString(), out _Faculty);

            if (objDr.Table.Columns["LevelOrder"] != null)
                int.TryParse(objDr["LevelOrder"].ToString(), out _Order);

            if (objDr.Table.Columns["LevelDesc"] != null)
                _Desc = objDr["LevelDesc"].ToString();

            if (objDr.Table.Columns["LevelCreditHourFrom"] != null)
                int.TryParse(objDr["LevelCreditHourFrom"].ToString(), out _CreditHourFrom);

            if (objDr.Table.Columns["LevelCreditHourTo"] != null)
                int.TryParse(objDr["LevelCreditHourTo"].ToString(), out _CreditHourTo);

            if (objDr.Table.Columns["LevelSemesterType1MaxLimitedHour"] != null)
                int.TryParse(objDr["LevelSemesterType1MaxLimitedHour"].ToString(), out _SemesterType1MaxLimitedHour);

            if (objDr.Table.Columns["LevelSemesterType2MaxLimitedHour"] != null)
                int.TryParse(objDr["LevelSemesterType2MaxLimitedHour"].ToString(), out _SemesterType2MaxLimitedHour);

            if (objDr.Table.Columns["LevelSemesterType3MaxLimitedHour"] != null)
                int.TryParse(objDr["LevelSemesterType3MaxLimitedHour"].ToString(), out _SemesterType3MaxLimitedHour);

            if (objDr.Table.Columns["LevelLowGPALimitedHour"] != null)
                int.TryParse(objDr["LevelLowGPALimitedHour"].ToString(), out _LowGPALimitedHour);
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
            string strSql = SearchStr + " where (1=1) ";

            if (_Faculty != 0)
                strSql += " and LevelFaculty ="+_Faculty;
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}