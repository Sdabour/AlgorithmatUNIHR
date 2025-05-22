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
    public class SalaryDiscountTypeDb : BaseSelfRelatedDb
    {
        #region Private Data
        int _IDSearch;
        #endregion
        #region Constructors
        public SalaryDiscountTypeDb()
        {
        }
        public SalaryDiscountTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public SalaryDiscountTypeDb(int intID)
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

                string Returned = " INSERT INTO HRDiscountType" +
                                  " (DiscountTypeNameA, DiscountTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRDiscountType " +
                                  " SET DiscountTypeNameA ='" + _NameA + "'" +
                                  ", DiscountTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (DiscountTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRDiscountType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (DiscountTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRDiscountType.DiscountTypeID, HRDiscountType.DiscountTypeNameA, HRDiscountType.DiscountTypeNameE FROM         HRDiscountType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["DiscountTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["DiscountTypeID"].ToString());
            _NameA = objDr["DiscountTypeNameA"].ToString();
            _NameE = objDr["DiscountTypeNameE"].ToString();
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
                strSql += " And DiscountTypeID=" + _IDSearch + "";
            }
            strSql += " Order By DiscountTypeID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
