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
    public class FellowShipPaymentDb
    {

        #region Private Data
        protected int _ID;
        protected int _Applicant;
        protected double _Value;
        protected string _Desc;
        protected DateTime _Date;
        protected DateTime _RequestDate;
        protected int _FellowShipPaymentType;
        protected int _FellowShipPaymentMainType;
        protected int _Statement;
        protected string _IDBuffer;
        protected string _Remarks;

        string _IDsStr;
        string _StatementIDs;
        string _ApplicantIDs;
        protected DateTime _DateFromSearch;
        protected DateTime _DateToSearch;
        protected bool _DateSearch;

        protected byte _IsPaymentDateSearch;
        protected byte _IsApplicantSearch;
        bool _SetApplicantCache;
        #endregion
        #region Constructors
        public FellowShipPaymentDb()
        {
        }
        public FellowShipPaymentDb(DataRow objDr)
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
        public DateTime RequestDate
        {
            set
            {
                _RequestDate = value;
            }
            get
            {
                return _RequestDate;
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
        public string IDBuffer
        {
            set
            {
                _IDBuffer = value;
            }
            get
            {
                return _IDBuffer;
            }
        }
        public string Remarks
        {
            set
            {
                _Remarks = value;
            }
            get
            {
                return _Remarks;
            }
        }
        public string StatementIDs
        {
            set
            {
                _StatementIDs = value;
            }
        }
        public byte IsPaymentDateSearch
        {
            set
            {
                _IsPaymentDateSearch = value;
            }
        }
        public byte IsApplicantSearch
        {
            set
            {
                _IsApplicantSearch = value;
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
        double _StartValue;

        public double StartValue
        {
            get { return _StartValue; }
            set { _StartValue = value; }
        }
        double _EndValue;

        public double EndValue
        {
            get { return _EndValue; }
            set { _EndValue = value; }
        }
        public string AddStr
        {
            get
            {
                double dlDate = _Date.ToOADate() - 2;
                double dlRequestDate = _RequestDate.ToOADate() - 2;
                string Returned = " INSERT INTO HRFellowShipPayment" +
                                  " (PaymentApplicant, PaymentValue, PaymentDesc, PaymentDate,RequestDate,FellowShipPaymentType,FellowShipPaymentMainType,PaymentStatement, UsrIns, TimIns)" +
                                  " VALUES (" + _Applicant + "," + _Value + "," +
                                  " '" + _Desc + "'," + dlDate + ","+ dlRequestDate +"," + _FellowShipPaymentType + "," + _FellowShipPaymentMainType + "," + _Statement + "," +
                                  "" + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                double dlDate = _Date.ToOADate() - 2;
                double dlRequestDate = _RequestDate.ToOADate() - 2;
                string Returned = " UPDATE    HRFellowShipPayment" +
                                  " SET PaymentApplicant =" + _Applicant + "" +
                                  " ,PaymentValue =" + _Value + "" +
                                  " ,PaymentDesc ='" + _Desc + "'" +
                                  " ,PaymentDate =" + dlDate + "" +
                                  " ,RequestDate =" + dlRequestDate + "" +
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
                string Returned = " UPDATE    HRFellowShipPayment" +
                                  " SET Dis =GetDate()" +
                                  " WHERE     (PaymentID = " + _ID + ")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRFellowShipPayment.PaymentID, HRFellowShipPayment.PaymentApplicant,"+
                                  " HRFellowShipPayment.PaymentDesc, HRFellowShipPayment.PaymentDate,HRFellowShipPayment.RequestDate," +
                                  " HRFellowShipPayment.PaymentValue,HRFellowShipPayment.FellowShipPaymentType,HRFellowShipPayment.FellowShipPaymentMainType" +
                                  " ,HRFellowShipPayment.PaymentStatement,HRFellowShipPayment.IDBuffer,HRFellowShipPayment.Remarks" +
                                  " ,ApplicantWorkerTable.* ,FellowShipPaymentTypeTable.*,FellowShipPaymentMainTypeTable.*" +
                                  " FROM         HRFellowShipPayment " +
                                  " Left outer  join (" + new ApplicantWorkerDb().SearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID =  HRFellowShipPayment.PaymentApplicant "+
                                  " Left Outer  join (" + FellowShipPaymentMainTypeDb.SearchStr + ") as FellowShipPaymentMainTypeTable On FellowShipPaymentMainTypeTable.FellowShipPaymentMainTypeID =  HRFellowShipPayment.FellowShipPaymentMainType " +
                                  " Left Outer  join (" + FellowShipPaymentTypeDb.SearchStr + ") as FellowShipPaymentTypeTable On FellowShipPaymentTypeTable.FellowShipPaymentTypeID =  HRFellowShipPayment.FellowShipPaymentType ";
                
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
            if (objDr["PaymentApplicant"].ToString() != "")
                _Applicant = int.Parse(objDr["PaymentApplicant"].ToString());
            _Value = double.Parse(objDr["PaymentValue"].ToString());
            _Desc = objDr["PaymentDesc"].ToString();
            if (objDr["PaymentDate"].ToString() != "")
                _Date = DateTime.Parse(objDr["PaymentDate"].ToString());
            else
                _Date = new DateTime(1900,1,1);

            if (objDr["RequestDate"].ToString() != "")
                _RequestDate = DateTime.Parse(objDr["RequestDate"].ToString());
            else
                _RequestDate = new DateTime(1900, 1, 1);


            if (objDr["FellowShipPaymentTypeID"].ToString() != "")
                _FellowShipPaymentType = int.Parse(objDr["FellowShipPaymentTypeID"].ToString());
            if(objDr["PaymentStatement"].ToString()!="")
            _Statement = int.Parse(objDr["PaymentStatement"].ToString());
            if (objDr["FellowShipPaymentMainTypeID"].ToString() != "")
                _FellowShipPaymentMainType = int.Parse(objDr["FellowShipPaymentMainTypeID"].ToString());

            _IDBuffer = objDr["IDBuffer"].ToString();
            _Remarks = objDr["Remarks"].ToString();
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
            if (_StatementIDs != null && _StatementIDs!="" && _StatementIDs!="0")
            {
                strSql = strSql + "  And PaymentStatement in (" + _StatementIDs + ")";
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
            if (_EndValue > 0)
                strSql += "  and HRFellowShipPayment.PaymentValue >=" + _StartValue +
                    " and HRFellowShipPayment.PaymentValue <= "+_EndValue;
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
            if (_IsPaymentDateSearch != 0)
            {
                strSql += " and ((PaymentDate is null) or ( YEAR(PaymentDate) = 1900) or ( YEAR(PaymentDate) = 1))";
            }
            if (_IsApplicantSearch != 0)
            {
                strSql += " and ((PaymentApplicant is null) Or (PaymentApplicant = 0))";
            }
            if (_SetApplicantCache == true)
            {
                ApplicantWorkerDb.SetCashTable();
                ApplicantWorkerDb.ApplicantIDs = " select PaymentApplicant from (" + strSql + ") as NativeTable ";
            }
            strSql += " Order By PaymentID";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRFellowShipPayment" +
                                  "  SET " +
                                  " PaymentStatement =" + _Statement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where PaymentID in (" + _IDsStr + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void EditStatementAndDate(int intID,int intStatement,DateTime dtDate)
        {
            double dlDate = dtDate.ToOADate() - 2;
            string strSql = " UPDATE    HRFellowShipPayment" +
                                  "  SET " +
                                  "  PaymentStatement =" + intStatement + "" +
                                  " , PaymentDate =" + dlDate + "" +
                                  " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where PaymentID = "+ intID + "";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        #endregion
    }
}
