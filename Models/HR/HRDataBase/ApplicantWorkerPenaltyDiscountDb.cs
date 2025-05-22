using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerPenaltyDiscountDb
    {
        #region Private Data
        protected int _ID;    
        protected int _DiscountPenalty;
        protected float _DiscountValue;
        protected string _DiscountDesc;
        protected int _DiscountStatement;
        string _StatementIDs;

       
        protected bool _ApplicantStatusSearch;
        protected int _ApplicantIDSearch;
        protected int _StatementStatusSearch;
        string _IDsStr;
        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyDiscountDb()
        {
        }
        public ApplicantWorkerPenaltyDiscountDb(DataRow objDr)
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
        public int DiscountPenalty
        {
            set
            {
                _DiscountPenalty = value;
            }
            get
            {
                return _DiscountPenalty;
            }
        }
        public float DiscountValue
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
        public string DiscountDesc
        {
            set
            {
                _DiscountDesc = value;
            }
            get
            {
                return _DiscountDesc;
            }
        }
        public int DiscountStatement
        {
            set
            {
                _DiscountStatement = value;
            }
            get
            {
                return _DiscountStatement;
            }
        }
        public string StatementIDs
        {
            get { return _StatementIDs; }
            set { _StatementIDs = value; }
        }
        public int ApplicantIDSearch
        {
            set
            {
                _ApplicantIDSearch = value;
            }
            get
            {
                return _ApplicantIDSearch;
            }
        }

        public bool ApplicantStatusSearch
        {
            set
            {
                _ApplicantStatusSearch = value;
            }
            get
            {
                return _ApplicantStatusSearch;
            }
        }
        public int StatementStatusSearch
        {
            set
            {
                _StatementStatusSearch = value;
            }
            get
            {
                return _StatementStatusSearch;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public string AddStr
        {
            get
            {
                string ReturnedStr = " INSERT INTO HRApplicantWorkerPenaltyDiscount "+
                                     " (DiscountPenalty, DiscountDesc, DiscountStatement,DiscountValue," +
                                     " UsrIns, TimIns)"+
                                     " VALUES (" + _DiscountPenalty + ",'" + _DiscountDesc + "'," + _DiscountStatement + ","+ _DiscountValue +"," +
                                     " " + SysData.CurrentUser.ID + ",GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                                          
                string ReturnedStr = " UPDATE    HRApplicantWorkerPenaltyDiscount "+
                                     "  SET DiscountDesc ='" + _DiscountDesc + "'" +
                                     " , DiscountStatement =" + _DiscountStatement + "" +
                                     " , DiscountValue =" + _DiscountValue + "" +
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd = GetDate()" +
                                     " WHERE     (DiscountPenalty = " + _DiscountPenalty + ") AND (DiscountID = " + _ID + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRApplicantWorkerPenaltyDiscount" +
                                     " WHERE     (DiscountID = " + _ID + ") AND (DiscountPenalty = " + _DiscountPenalty + ")";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     HRApplicantWorkerPenaltyDiscount.DiscountID, HRApplicantWorkerPenaltyDiscount.DiscountPenalty, "+
                                     " HRApplicantWorkerPenaltyDiscount.DiscountDesc, HRApplicantWorkerPenaltyDiscount.DiscountStatement,HRApplicantWorkerPenaltyDiscount.DiscountValue,ApplicantWorkerPenaltyTable.* " +
                                     " FROM         HRApplicantWorkerPenaltyDiscount "+
                                     " Left Outer Join (" + ApplicantWorkerPenaltyDb.SearchStr + ") as ApplicantWorkerPenaltyTable ON ApplicantWorkerPenaltyTable.PenaltyID=HRApplicantWorkerPenaltyDiscount.DiscountPenalty";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["DiscountID"].ToString());
            _DiscountPenalty = int.Parse(objDr["DiscountPenalty"].ToString());
            _DiscountValue = float.Parse(objDr["DiscountValue"].ToString());
            _DiscountDesc = objDr["DiscountDesc"].ToString();
            _DiscountStatement = int.Parse(objDr["DiscountStatement"].ToString());            
        }
        #endregion
        #region Public Methods
        public  void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }
        public  void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerPenaltyDiscount " +
                                     "  SET DiscountStatement =" + _DiscountStatement + "" +
                                     " , UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd = GetDate()" +
                                     " WHERE     (DiscountID in ( " + _IDsStr + "))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public  void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public  DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_ID != 0)
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountID = "+ _ID +"";
            
            if (_StatementStatusSearch ==1)
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountStatement = 0";
            else if (_StatementStatusSearch == 2)
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountStatement = " + _DiscountStatement + "";

            if (_StatementIDs != null && _StatementIDs != "")
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountStatement  in ("+_StatementIDs+") ";
            if (_DiscountPenalty != 0)
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountPenalty = " + _DiscountPenalty + "";
            if (_ApplicantStatusSearch == true)
                StrSql = StrSql + " And HRApplicantWorkerPenaltyDiscount.DiscountPenalty in (SELECT     PenaltyID FROM         HRApplicantWorkerPenalty WHERE     (PenaltyApplicantID = "+ _ApplicantIDSearch +") )";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
