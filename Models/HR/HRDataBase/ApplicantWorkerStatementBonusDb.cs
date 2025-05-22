using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.Base.BaseDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementBonusDb
    {
        #region Private Data
        protected int _OriginStatement;
        protected string _Desc;
        protected double _Value;
        protected DateTime _Date;
        protected int _BonusType;
        protected int _BonusID;

        #endregion
        #region Constractors
        public ApplicantWorkerStatementBonusDb()
        {

        }
        public ApplicantWorkerStatementBonusDb(int intID)
        {
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        public ApplicantWorkerStatementBonusDb(DataRow objDR)
        {
            SetData(objDR);
        }
        #endregion
        #region Public Accessorice
        int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
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
        public int BonusType
        {
            set
            {
                _BonusType = value;
            }
            get
            {
                return _BonusType;
            }
        }
        public int BonusID
        {
            set
            {
                _BonusID = value;
            }
            get
            {
                return _BonusID;
            }
        }
        double _DayCount;

        public double DayCount
        {
            get { return _DayCount; }
            set { _DayCount = value; }
        }
        double _DayReferenceCount;

        public double DayReferenceCount
        {
            get { return _DayReferenceCount; }
            set { _DayReferenceCount = value; }
        }
        double _HourCount;

        public double HourCount
        {
            get { return _HourCount; }
            set { _HourCount = value; }
        }
        double _HourRefrenceCount;

        public double HourRefrenceCount
        {
            get { return _HourRefrenceCount; }
            set { _HourRefrenceCount = value; }
        }

        public string AddStr
        {
            get
            {
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " INSERT INTO HRApplicantWorkerStatementBonus" +
                                " (OriginStatement, BonusDesc, BonusValue"+
                                ", BonusDayCount, BonusDayReferenceCount, BonusHourCount, BonusHourRefrenceCount"+
                                ",BonusDate,BonusID)" +
                                " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                                _Value+ "," + _DayCount + "," +_DayReferenceCount + "," + _HourCount+ "," +
                                _HourRefrenceCount + "," + dblDate + "," + _BonusID + ") ";
                return Returned;

            }
        }
        public string EditStr
        {
            get 
            {
                string Returned  = " UPDATE    HRApplicantWorkerStatementBonus" +
                         " SET   OriginStatement =" + _OriginStatement + "" +
                         " , BonusDesc ='" + _Desc + "'" +
                         " , BonusValue = " + _Value + "" +
                         " , BonusType = " + _BonusType + "" +
                         " , BonusID = " + _BonusID + "" +
                         " Where  OriginStatement = " + _OriginStatement + " and StatementBonusID ="+ _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT    StatementBonusID, OriginStatement, BonusDesc, BonusValue" +
                    ", BonusDayCount, BonusDayReferenceCount, BonusHourCount, BonusHourRefrenceCount "+
                    ",BonusDate,BonusType,BonusTypeTable.*,BonusID" +
                                  " FROM         HRApplicantWorkerStatementBonus "+
                                  " Left Outer join ("+ SalaryBonusTypeDb.SearchStr +") as BonusTypeTable "+
                                  " On BonusTypeTable.BonusTypeID = HRApplicantWorkerStatementBonus.BonusType";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            int.TryParse(objDR["StatementBonusID"].ToString(), out _ID);
            _OriginStatement = int.Parse(objDR["OriginStatement"].ToString());
            _Desc = objDR["BonusDesc"].ToString();
            _Value = double.Parse(objDR["BonusValue"].ToString());
            _Date = DateTime.Parse(objDR["BonusDate"].ToString());
            if(objDR["BonusType"].ToString()!="")
            _BonusType = int.Parse(objDR["BonusType"].ToString());
        if (objDR["BonusID"].ToString() != "")
            _BonusID = int.Parse(objDR["BonusID"].ToString());
        double.TryParse(objDR["BonusDayCount"].ToString(), out _DayCount);
        double.TryParse(objDR["BonusDayReferenceCount"].ToString(), out _DayReferenceCount);
        double.TryParse(objDR["BonusHourCount"].ToString(), out _HourCount);
        double.TryParse(objDR["BonusHourRefrenceCount"].ToString(), out _HourRefrenceCount);
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            double dblDate = _Date.ToOADate() - 2;
            string strSql = " INSERT INTO HRApplicantWorkerStatementBonus" +
                            " (OriginStatement, BonusDesc, BonusValue,BonusDate,BonusType,BonusID)" +
                            " VALUES     (" + _OriginStatement + ",'" + _Desc + "'," +
                            _Value + "," + dblDate + "," + _BonusType + "," + _BonusID + ") ";
            strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = " UPDATE    HRApplicantWorkerStatementBonus" +
                            " SET   OriginStatement =" + _OriginStatement + "" +
                            " , BonusDesc ='" + _Desc + "'" +
                            " , BonusValue = " + _Value + "" +
                            " , BonusType = " + _BonusType + "" +
                            " , BonusID = " + _BonusID + "" +
                            " Where OriginStatement = " + _OriginStatement + "";
            strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public void Delete()
        {
            string strSql = " DELETE FROM HRApplicantWorkerStatementBonus Where OriginStatement = " +
                _OriginStatement + " and StatementBonusID = "+_ID;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1 = 1 ";
            if (_OriginStatement != 0)
                strSql += " and OriginStatement = " + _OriginStatement + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }

        #endregion
    }
}
