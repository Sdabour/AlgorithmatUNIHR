using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerMotivationStatementBonusDb
    {
        #region Private Data
        protected int _ID;
        protected int _ApplicantWorkerMotivationStatement;
        protected string _Desc;
        protected double _BonusValue;        
        protected int _MotivationBonusType;
        
        #endregion
        #region Constractors
        public ApplicantWorkerMotivationStatementBonusDb()
        {

        }
       
        public ApplicantWorkerMotivationStatementBonusDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
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
        public int ApplicantWorkerMotivationStatement
        {
            set
            {
                _ApplicantWorkerMotivationStatement = value;
            }
            get
            {
                return _ApplicantWorkerMotivationStatement;
            }
        }
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
        public double BonusValue
        {
            set
            {
                _BonusValue = value;
            }
            get
            {
                return _BonusValue;
            }
        }        
        public int MotivationBonusType
        {
            set
            {
                _MotivationBonusType = value;
            }
            get
            {
                return _MotivationBonusType;
            }
        }        
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ID,ApplicantWorkerMotivationStatement, BonusDesc, BonusValue,MotivationBonusType,MotivationBonusTypeTable.*" +
                                  " FROM         HRApplicantWorkerMotivationStatementBonus "+
                                  " Left Outer join (" + MotivationBonusTypeDb.SearchStr + ") as MotivationBonusTypeTable " +
                                  " On MotivationBonusTypeTable.MotivationBonusTypeID = HRApplicantWorkerMotivationStatementBonus.MotivationBonusType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            if (objDR["ID"].ToString() == "")
                return;
                _ID = int.Parse(objDR["ID"].ToString());

            _ApplicantWorkerMotivationStatement = int.Parse(objDR["ApplicantWorkerMotivationStatement"].ToString());
            _Desc = objDR["BonusDesc"].ToString();
            _BonusValue = double.Parse(objDR["BonusValue"].ToString());            
            if (objDR["MotivationBonusType"].ToString() != "")
                _MotivationBonusType = int.Parse(objDR["MotivationBonusType"].ToString());
            
        }
        #endregion
        #region Public Methods
        public void Add()
        {            
            string strSql = " INSERT INTO HRApplicantWorkerMotivationStatementBonus" +
                            " (ApplicantWorkerMotivationStatement, BonusDesc, BonusValue,MotivationBonusType)" +
                            " VALUES     (" + _ApplicantWorkerMotivationStatement + ",'" + _Desc + "'," +
                            _BonusValue + "," + _MotivationBonusType + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    HRApplicantWorkerMotivationStatementBonus" +
                            " SET   ApplicantWorkerMotivationStatement =" + _ApplicantWorkerMotivationStatement + "" +
                            " , BonusDesc ='" + _Desc + "'" +
                            " , BonusValue = " + _BonusValue + "" +
                            " , BonusType = " + _MotivationBonusType + "" +                            
                            " Where ID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM HRApplicantWorkerMotivationStatementBonus " +
                " Where Where ID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ApplicantWorkerMotivationStatement != 0)
                strSql += " and ApplicantWorkerMotivationStatement = " + _ApplicantWorkerMotivationStatement + "";
            if (_ID != 0)
                strSql += " And ID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
