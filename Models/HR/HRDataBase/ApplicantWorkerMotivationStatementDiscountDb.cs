using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerMotivationStatementDiscountDb
    {
        #region Private Data
        protected int _ID;
        protected int _ApplicantWorkerMotivationStatement;
        protected string _Desc;
        protected double _DiscountValue;        
        protected int _MotivationDiscountType;
        string _StatementIDs;

        public string StatementIDs
        {
          
            set { _StatementIDs = value; }
        }
        #endregion
        #region Constractors
        public ApplicantWorkerMotivationStatementDiscountDb()
        {

        }
       
        public ApplicantWorkerMotivationStatementDiscountDb(DataRow objDR)
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
        public double DiscountValue
        {
            set
            {
                _DiscountValue = value;
            }
            get
            {
                return _DiscountValue;
            }
        }        
        public int MotivationDiscountType
        {
            set
            {
                _MotivationDiscountType = value;
            }
            get
            {
                return _MotivationDiscountType;
            }
        }        
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     ID,ApplicantWorkerMotivationStatement, DiscountDesc, DiscountValue,MotivationDiscountType,MotivationDiscountTypeTable.*" +
                                  " FROM         HRApplicantWorkerMotivationStatementDiscount "+
                                  " Left Outer join (" + MotivationDiscountTypeDb.SearchStr + ") as MotivationDiscountTypeTable " +
                                  " On MotivationDiscountTypeTable.MotivationDiscountTypeID = HRApplicantWorkerMotivationStatementDiscount.MotivationDiscountType";
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
            _Desc = objDR["DiscountDesc"].ToString();
            _DiscountValue = double.Parse(objDR["DiscountValue"].ToString());            
            if (objDR["MotivationDiscountType"].ToString() != "")
                _MotivationDiscountType = int.Parse(objDR["MotivationDiscountType"].ToString());
            
        }
        #endregion
        #region Public Methods
        public void Add()
        {            
            string strSql = " INSERT INTO HRApplicantWorkerMotivationStatementDiscount" +
                            " (ApplicantWorkerMotivationStatement, DiscountDesc, DiscountValue,MotivationDiscountType)" +
                            " VALUES     (" + _ApplicantWorkerMotivationStatement + ",'" + _Desc + "'," +
                            _DiscountValue + "," + _MotivationDiscountType + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    HRApplicantWorkerMotivationStatementDiscount" +
                            " SET   ApplicantWorkerMotivationStatement =" + _ApplicantWorkerMotivationStatement + "" +
                            " , DiscountDesc ='" + _Desc + "'" +
                            " , DiscountValue = " + _DiscountValue + "" +
                            " , DiscountType = " + _MotivationDiscountType + "" +                            
                            " Where ID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM HRApplicantWorkerMotivationStatementDiscount " +
                " Where Where ID = " + _ID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_ApplicantWorkerMotivationStatement != 0)
                strSql += " and ApplicantWorkerMotivationStatement = " + _ApplicantWorkerMotivationStatement + "";
            if (_StatementIDs != null && _StatementIDs != "")
                strSql += " and ApplicantWorkerMotivationStatement in (" + _StatementIDs + ") ";
            if (_ID != 0)
                strSql += " And ID = " + _ID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
