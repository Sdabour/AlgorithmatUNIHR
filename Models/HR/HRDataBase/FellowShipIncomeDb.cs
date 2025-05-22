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
    public class FellowShipIncomeDb
    {
        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected double _Value;
        protected string _Desc;
        protected DateTime _Date;        
        protected int _FellowShipIncomeMainType;
        protected int _Statement;
        string _IDsStr;
        string _ApplicantIDs;
        protected DateTime _DateFromSearch;
        protected DateTime _DateToSearch;
        protected bool _DateSearch;
        bool _SetApplicantCache;
        #endregion
        #region Constructors
        public FellowShipIncomeDb()
        {
        }
        public FellowShipIncomeDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
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
        public int Applicant
        {
            set
            {
                _Applicant = value;
            }
            get
            {
                return _Applicant;
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
        public int FellowShipIncomeMainType
        {
            set
            {
                _FellowShipIncomeMainType = value;
            }
            get
            {
                return _FellowShipIncomeMainType;
            }
        }
        public int Statement
        {
            set
            {
                _Statement = value;
            }
            get
            {
                return _Statement;
            }
        }
        public bool DateSearch
        {
            set
            {
                _DateSearch = value;
            }            
        }
        public DateTime DateFromSearch
        {
            set
            {
                _DateFromSearch = value;
            }            
        }
        public DateTime DateToSearch
        {
            set
            {
                _DateToSearch = value;
            }            
        }
        public bool SetApplicantCache
        {
            set
            {
                _SetApplicantCache = value;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }

        }
        public string AddStr
        {
            get
            {
                double dlDate = _Date.ToOADate() - 2;
                string Returned = " INSERT INTO HRFellowShipIncome" +
                                  " (IncomeApplicant, IncomeValue, IncomeDesc, IncomeDate,FellowShipIncomeMainType,IncomeStatement, UsrIns, TimIns)" +
                                  " VALUES (" + _Applicant + "," + _Value + "," +
                                  " '" + _Desc + "'," + dlDate + "," + _FellowShipIncomeMainType + "," + _Statement + "," +
                                  "" + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dlDate = _Date.ToOADate() - 2;
                string Returned = " UPDATE    HRFellowShipIncome" +
                                  " SET IncomeApplicant =" + _Applicant + "" +
                                  " ,IncomeValue =" + _Value + "" +
                                  " ,IncomeDesc ='" + _Desc + "'" +
                                  " ,IncomeDate =" + dlDate + "" +
                                  " ,IncomeStatement =" + _Statement + "" +                                  
                                  
                                  " ,FellowShipIncomeMainType =" + _FellowShipIncomeMainType + "" +   
                                  " ,UsrUpd =" + SysData.CurrentUser.ID + "" +
                                  " ,TimUpd =GetDate()" +
                                  " WHERE     (IncomeID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRFellowShipIncome" +
                                  " SET Dis =GetDate()" +
                                  " WHERE     (IncomeID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRFellowShipIncome.IncomeID, HRFellowShipIncome.IncomeApplicant," +
                                  " HRFellowShipIncome.IncomeDesc, HRFellowShipIncome.IncomeDate," +
                                  " HRFellowShipIncome.IncomeValue,HRFellowShipIncome.FellowShipIncomeMainType" +
                                  " ,HRFellowShipIncome.IncomeStatement" +
                                  " ,ApplicantWorkerTable.* ,FellowShipIncomeMainTypeTable.*" +
                                  " FROM         HRFellowShipIncome " +
                                  " Left Outer join (" + new ApplicantWorkerDb().SearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID =  HRFellowShipIncome.IncomeApplicant " +
                                  " Left Outer join (" + FellowShipIncomeMainTypeDb.SearchStr + ") as FellowShipIncomeMainTypeTable On FellowShipIncomeMainTypeTable.FellowShipIncomeMainTypeID =  HRFellowShipIncome.FellowShipIncomeMainType ";
                                  //" Inner join (" + FellowShipIncomeTypeDb.SearchStr + ") as FellowShipIncomeTypeTable On FellowShipIncomeTypeTable.FellowShipIncomeTypeID =  HRFellowShipIncome.FellowShipIncomeType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["IncomeID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["IncomeID"].ToString());
            _Applicant = int.Parse(objDr["IncomeApplicant"].ToString());
            _Value = double.Parse(objDr["IncomeValue"].ToString());
            _Desc = objDr["IncomeDesc"].ToString();
            _Date = DateTime.Parse(objDr["IncomeDate"].ToString());
            //_FellowShipIncomeType = int.Parse(objDr["FellowShipIncomeTypeID"].ToString());
            _Statement = int.Parse(objDr["IncomeStatement"].ToString());
            _FellowShipIncomeMainType = int.Parse(objDr["FellowShipIncomeMainTypeID"].ToString());
        }

        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where Dis is null ";
            if (_Applicant != 0)
            {
                strSql = strSql + "  And IncomeApplicant = " + _Applicant + "";
            }
            if (_Statement != 0)
            {
                strSql = strSql + "  And IncomeStatement = " + _Statement + "";
            }            
            if (_FellowShipIncomeMainType != 0)
            {
                strSql = strSql + "  And FellowShipIncomeMainType = " + _FellowShipIncomeMainType + "";
            }
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql = strSql + " And IncomeApplicant In ( " + _ApplicantIDs + ")";

            if (_DateSearch == true)
            {
                int intFrom;
                double d = _DateFromSearch.ToOADate() - 2;
                intFrom = (int)d;

                int intTo;
                double dd = _DateToSearch.ToOADate() - 2;
                intTo = (int)dd + 1;

                strSql += " and IncomeDate between " + intFrom + " And " + intTo + "";
            }
            if (_SetApplicantCache == true)
            {
                ApplicantWorkerDb.SetCashTable();
                ApplicantWorkerDb.ApplicantIDs = " select IncomeApplicant from (" + strSql + ") as NativeTable ";
            }
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRFellowShipIncome" +
                                  "  SET " +
                                  " IncomeStatement =" + _Statement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where IncomeID in (" + _IDsStr + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
