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
    public class ApplicantWorkerFellowShipPaymentDb
    {

        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected double _Value;
        protected string _Desc;
        protected DateTime _Date;
        protected int _FellowShipPaymentType;
        protected int _FellowShipPaymentMainType;
        protected int _Statement;
        string _IDsStr;
        string _ApplicantIDs;
        protected DateTime _DateFromSearch;
        protected DateTime _DateToSearch;
        protected bool _DateSearch;
        bool _SetApplicantCache;
        #endregion
        #region Constructors
        public ApplicantWorkerFellowShipPaymentDb()
        {
        }
        public ApplicantWorkerFellowShipPaymentDb(DataRow objDr)
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
        public int FellowShipPaymentType
        {
            set
            {
                _FellowShipPaymentType = value;
            }
            get
            {
                return _FellowShipPaymentType;
            }
        }
        public int FellowShipPaymentMainType
        {
            set
            {
                _FellowShipPaymentMainType = value;
            }
            get
            {
                return _FellowShipPaymentMainType;
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
                string Returned = " INSERT INTO HRApplicantWorkerFellowShipPayment" +
                                  " (PaymentApplicant, PaymentValue, PaymentDesc, PaymentDate,FellowShipPaymentType,FellowShipPaymentMainType,PaymentStatement, UsrIns, TimIns)" +
                                  " VALUES (" + _Applicant + "," + _Value + "," +
                                  " '" + _Desc + "'," + dlDate + "," + _FellowShipPaymentType + "," + _FellowShipPaymentMainType + "," + _Statement + "," +
                                  "" + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dlDate = _Date.ToOADate() - 2;
                string Returned = " UPDATE    HRApplicantWorkerFellowShipPayment" +
                                  " SET PaymentApplicant =" + _Applicant + "" +
                                  " ,PaymentValue =" + _Value + "" +
                                  " ,PaymentDesc ='" + _Desc + "'" +
                                  " ,PaymentDate =" + dlDate + "" +
                                  " ,PaymentStatement =" + _Statement + "" +                                  
                                  " ,FellowShipPaymentType =" + _FellowShipPaymentType + "" +
                                  " ,FellowShipPaymentMainType =" + _FellowShipPaymentMainType + "" +   
                                  " ,UsrUpd =" + SysData.CurrentUser.ID + "" +
                                  " ,TimUpd =GetDate()" +
                                  " WHERE     (PaymentID = " + _ID + ")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " UPDATE    HRApplicantWorkerFellowShipPayment" +
                                  " SET Dis =GetDate()" +
                                  " WHERE     (PaymentID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerFellowShipPayment.PaymentID, HRApplicantWorkerFellowShipPayment.PaymentApplicant,"+
                                  " HRApplicantWorkerFellowShipPayment.PaymentDesc, HRApplicantWorkerFellowShipPayment.PaymentDate,"+
                                  " HRApplicantWorkerFellowShipPayment.PaymentValue,HRApplicantWorkerFellowShipPayment.FellowShipPaymentType"+
                                  " ,HRApplicantWorkerFellowShipPayment.PaymentStatement" +
                                  " ,ApplicantWorkerTable.* ,FellowShipPaymentTypeTable.*" +
                                  " FROM         HRApplicantWorkerFellowShipPayment " +
                                  " Inner join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID =  HRApplicantWorkerFellowShipPayment.PaymentApplicant " +
                                 // " Inner join (" + FellowShipPaymentMainTypeDb.SearchStr + ") as FellowShipPaymentMainTypeTable On FellowShipPaymentMainTypeTable.FellowShipPaymentMainTypeID =  HRApplicantWorkerFellowShipPayment.FellowShipPaymentMainType "+
                                  " Inner join (" + FellowShipPaymentTypeDb.SearchStr + ") as FellowShipPaymentTypeTable On FellowShipPaymentTypeTable.FellowShipPaymentTypeID =  HRApplicantWorkerFellowShipPayment.FellowShipPaymentType ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["PaymentID"].ToString() == "")
                return;
            _ID = int.Parse(objDr["PaymentID"].ToString());
            _Applicant = int.Parse(objDr["PaymentApplicant"].ToString());
            _Value = double.Parse(objDr["PaymentValue"].ToString());
            _Desc = objDr["PaymentDesc"].ToString();
            _Date = DateTime.Parse(objDr["PaymentDate"].ToString());
            _FellowShipPaymentType = int.Parse(objDr["FellowShipPaymentTypeID"].ToString());
            _Statement = int.Parse(objDr["PaymentStatement"].ToString());
            _FellowShipPaymentMainType = int.Parse(objDr["FellowShipPaymentMainTypeID"].ToString());
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
                strSql = strSql + "  And PaymentApplicant = " + _Applicant + "";
            }
            if (_Statement != 0)
            {
                strSql = strSql + "  And PaymentStatement = " + _Statement + "";
            }
            if (_FellowShipPaymentType != 0)
            {
                strSql = strSql + "  And FellowShipPaymentType = " + _FellowShipPaymentType + "";
            }
            if (_FellowShipPaymentMainType != 0)
            {
                strSql = strSql + "  And FellowShipPaymentMainType = " + _FellowShipPaymentMainType + "";
            }
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql = strSql + " And PaymentApplicant In ( " + _ApplicantIDs + ")";

            if (_DateSearch == true)
            {
                int intFrom;
                double d = _DateFromSearch.ToOADate() - 2;
                intFrom = (int)d;

                int intTo;
                double dd = _DateToSearch.ToOADate() - 2;
                intTo = (int)dd + 1;

                strSql += " and PaymentDate between " + intFrom + " And " + intTo + "";
            }
            if (_SetApplicantCache == true)
            {
                ApplicantWorkerDb.SetCashTable();
                ApplicantWorkerDb.ApplicantIDs = " select PaymentApplicant from (" + strSql + ") as NativeTable ";
            }
            
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerFellowShipPayment" +
                                  "  SET " +
                                  " PaymentStatement =" + _Statement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where PaymentID in (" + _IDsStr + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
