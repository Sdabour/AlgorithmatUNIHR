using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class SalaryBonusTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        int _IDSearch;
        #endregion
        #region Constructors
        public SalaryBonusTypeDb()
        {
        }
        public SalaryBonusTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public SalaryBonusTypeDb(int intID)
        {
            _ID = intID;
            if (_ID != 0)
            {
                DataTable dtTemp = Search();
                DataRow objDR = Search().Rows[0];
                SetData(objDR);
            }
        }
        #endregion
        #region Public Properties
        public int IDSearch
        {
            set
            {
                _IDSearch = value;
            }
        }
        public string AddStr
        {
            get
            {

                string Returned = " INSERT INTO HRBonusType" +
                                  " (BonusTypeNameA, BonusTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRBonusType " +
                                  " SET BonusTypeNameA ='" + _NameA + "'" +
                                  ", BonusTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (BonusTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRBonusType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (BonusTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRBonusType.BonusTypeID, HRBonusType.BonusTypeNameA, HRBonusType.BonusTypeNameE FROM         HRBonusType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["BonusTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["BonusTypeID"].ToString());
            _NameA = objDr["BonusTypeNameA"].ToString();
            _NameE = objDr["BonusTypeNameE"].ToString();
        }
        #endregion
        #region Public Methods
        public override void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public override void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public override DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is Null ";
            if (_IDSearch != 0)
            {
                strSql += " And BonusTypeID=" + _IDSearch + "";
            }
            strSql += " Order By BonusTypeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
