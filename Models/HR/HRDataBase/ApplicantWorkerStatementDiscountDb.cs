using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementDiscountDb
    {
        #region Private Data
        protected int _OriginStatement;
        string _StatementIDs;

       
        protected string _Desc;
        protected double _Value;
        protected DateTime _Date;
        protected int _DiscountType;
        protected int _DiscountID;
        #endregion
        #region Constractors
        public ApplicantWorkerStatementDiscountDb()
        {

        }
        public ApplicantWorkerStatementDiscountDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ApplicantWorkerStatementDiscountDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        public int OriginStatement
        {
            set
            {
                _OriginStatement = value;
            }
            get
            {
                return _OriginStatement;
            }
        }
        public string StatementIDs
        {
            get { return _StatementIDs; }
            set { _StatementIDs = value; }
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
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }
        }
        public int DiscountType
        {
            set
            {
                _DiscountType = value;
            }
            get
            {
                return _DiscountType;
            }
        }
        public int DiscountID
        {
            set
            {
                _DiscountID = value;
            }
            get
            {
                return _DiscountID;
            }
        }

        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     OriginStatement, DiscountDesc, DiscountValue,DiscountDate ,DiscountType,DiscountID,DiscountTypeTable.*" +
                                  " FROM         HRApplicantWorkerStatementDiscount "+
                                  " Left Outer join (" + SalaryDiscountTypeDb.SearchStr + ") as DiscountTypeTable " +
                                  " On DiscountTypeTable.DiscountTypeID = HRApplicantWorkerStatementDiscount.DiscountType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _OriginStatement = int.Parse(objDR["OriginStatement"].ToString());
            _Desc = objDR["DiscountDesc"].ToString();
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            if(objDR["DiscountDate"].ToString()!="")
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            if (objDR["DiscountType"].ToString() != "")
                _DiscountType = int.Parse(objDR["DiscountType"].ToString());
            if (objDR["DiscountID"].ToString() != "")
                _DiscountID = int.Parse(objDR["DiscountID"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO HRApplicantWorkerStatementDiscount" +
                            " (OriginStatement, DiscountDesc, DiscountValue,DiscountDate,DiscountType,DiscountID)" +
                            " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                            _Value + "," + dblDate + "," + _DiscountType + "," + _DiscountID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    HRApplicantWorkerStatementDiscount" +
                            " SET   OriginStatement =" + _OriginStatement + "" +
                            " , DiscountDesc ='" + _Desc + "'" +
                            " , DiscountValue = " + _Value + "" +
                            " , DiscountType = " + _DiscountType + "" +
                            " , DiscountID = " + _DiscountID + "" +
                            " Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = " DELETE FROM HRApplicantWorkerStatementDiscount " +
                " Where OriginStatement = " + _OriginStatement + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_OriginStatement != 0)
                strSql += " and OriginStatement = " + _OriginStatement + "";

            if(_StatementIDs != null && _StatementIDs!= "")
                strSql += " and OriginStatement in ("+ _StatementIDs + ") " ;
            if (_DiscountID != 0)
                strSql += " And DiscountID = " + _DiscountID + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
