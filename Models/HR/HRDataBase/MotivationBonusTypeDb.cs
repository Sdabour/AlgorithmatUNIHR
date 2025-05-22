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
    public class MotivationBonusTypeDb : BaseSelfRelatedDb
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationBonusTypeDb()
        {
        }
        public MotivationBonusTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public MotivationBonusTypeDb(int intID)
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
        public string AddStr
        {
            get
            {

                string Returned = " INSERT INTO HRMotivationBonusType" +
                                  " (MotivationBonusTypeNameA, MotivationBonusTypeNameE, UsrIns, TimIns)" +
                                  " VALUES ('" + _NameA + "','" + _NameE + "',"+ SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {


                string Returned = " UPDATE    HRMotivationBonusType " +
                                  " SET MotivationBonusTypeNameA ='" + _NameA + "'" +
                                  ", MotivationBonusTypeNameE ='" + _NameE + "'" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE     (MotivationBonusTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRMotivationBonusType " +
                                " SET Dis =GetDate() " +
                                " WHERE     (MotivationBonusTypeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT     HRMotivationBonusType.MotivationBonusTypeID, HRMotivationBonusType.MotivationBonusTypeNameA, HRMotivationBonusType.MotivationBonusTypeNameE FROM         HRMotivationBonusType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["MotivationBonusTypeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["MotivationBonusTypeID"].ToString());
            _NameA = objDr["MotivationBonusTypeNameA"].ToString();
            _NameE = objDr["MotivationBonusTypeNameE"].ToString();
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
            if (_ID != 0)
            {
                strSql += " And MotivationBonusTypeID ="+ _ID +"";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
