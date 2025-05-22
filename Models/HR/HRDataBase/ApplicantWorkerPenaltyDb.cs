using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerPenaltyDb
    {
        #region Private Data
        private int _PenaltyID;
        private int _PenaltyApplicantID;
        private int _PenaltyType;
        private int _PenaltyReason;
        private DateTime _PenaltyDate;

        private string _PenaltyDesc;
        private string _PenaltyReasonDesc;
        private int _PenaltyPerson;
        private int _PenaltyEstimationStatement;
        private int _PenaltyStatus;
        private int _AttachmentID;

        private bool _PenaltyDateStatusSearch;
        private DateTime _PenaltyDateFromSearch;
        private DateTime _PenaltyDateToSearch;
        protected bool _InsDateStatusSearch;
        protected DateTime _InsDateFromSearch;
        protected DateTime _InsDateToSearch;
        string _ApplicantIDs;
        static DataTable _CachPenaltyPersonTable;
        bool _SetApplicantCache;
        int _UserIDSearch;

        bool _GetPenaltyIsNotStatement;

        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyDb()
        {
        }
        public ApplicantWorkerPenaltyDb(DataRow objDR)
        {
            SetData(objDR);
        }
        public ApplicantWorkerPenaltyDb(int intPenaltyApplicantID)
        {
            _PenaltyApplicantID = intPenaltyApplicantID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            SetData(objDR);
        }
        #endregion
        #region Public Properties
        public int PenaltyID
        {
            set
            {
                _PenaltyID = value;
            }
            get
            {
                return _PenaltyID;
            }

        }
        public int PenaltyApplicantID
        {
            set
            {
                _PenaltyApplicantID = value;
            }
            get
            {
                return _PenaltyApplicantID;
            }

        }
        public int PenaltyType
        {
            set
            {
                _PenaltyType = value;
            }
            get
            {
                return _PenaltyType;
            }

        }
        public int PenaltyReason
        {
            set
            {
                _PenaltyReason = value;
            }
            get
            {
                return _PenaltyReason;
            }

        }
        public int PenaltyPerson
        {
            set
            {
                _PenaltyPerson = value;
            }
            get
            {
                return _PenaltyPerson;
            }

        }
        public int PenaltyEstimationStatement
        {
            set
            {
                _PenaltyEstimationStatement = value;
            }
            get
            {
                return _PenaltyEstimationStatement;
            }

        }
        public int PenaltyStatus
        {
            set
            {
                _PenaltyStatus = value;
            }
            get
            {
                return _PenaltyStatus;
            }

        }
        public int AttachmentID
        {
            set
            {
                _AttachmentID = value;
            }
            get
            {
                return _AttachmentID;
            }

        }
        public string PenaltyDesc
        {
            set
            {
                _PenaltyDesc = value;
            }
            get
            {
                return _PenaltyDesc;
            }

        }
        public DateTime PenaltyDate
        {
            set
            {
                _PenaltyDate = value;
            }
            get
            {
                return _PenaltyDate;
            }

        }
        public string PenaltyReasonDesc
        {
            set
            {
                _PenaltyReasonDesc = value;
            }
            get
            {
                return _PenaltyReasonDesc;
            }

        }
        public bool PenaltyDateStatusSearch
        {
            set
            {
                _PenaltyDateStatusSearch = value;
            }
            get
            {
                return _PenaltyDateStatusSearch;
            }

        }
        public DateTime PenaltyDateFromSearch
        {
            set
            {
                _PenaltyDateFromSearch = value;
            }
            get
            {
                return _PenaltyDateFromSearch;
            }

        }
        public DateTime PenaltyDateToSearch
        {
            set
            {
                _PenaltyDateToSearch = value;
            }
            get
            {
                return _PenaltyDateToSearch;
            }

        }
        public bool InsDateStatusSearch
        {
            set
            {
                _InsDateStatusSearch = value;
            }
            get
            {
                return _InsDateStatusSearch;
            }

        }
        public DateTime InsDateFromSearch
        {
            set
            {
                _InsDateFromSearch = value;
            }
            get
            {
                return _InsDateFromSearch;
            }

        }
        public DateTime InsDateToSearch
        {
            set
            {
                _InsDateToSearch = value;
            }
            get
            {
                return _InsDateToSearch;
            }

        }
        public bool SetApplicantCache
        {
            set
            {
                _SetApplicantCache = value;
            }
        }
        public int UserIDSearch
        {
            set
            {
                _UserIDSearch = value;
            }
        }
        public bool GetPenaltyIsNotStatement
        {
            set
            {
                _GetPenaltyIsNotStatement = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }
        }
        public static DataTable CachPenaltyPersonTable
        {
            set
            {
                _CachPenaltyPersonTable = value;
            }
            get
            {
                if (_CachPenaltyPersonTable == null)
                {
                    _CachPenaltyPersonTable = new DataTable();
                    _CachPenaltyPersonTable.Columns.Add("ApplicantID");
                }
                return _CachPenaltyPersonTable;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerPenalty.PenaltyID,HRApplicantWorkerPenalty.PenaltyApplicantID, HRApplicantWorkerPenalty.PenaltyType, HRApplicantWorkerPenalty.PenaltyReason, " +
                                  " HRApplicantWorkerPenalty.PenaltyDate, HRApplicantWorkerPenalty.PenaltyDesc, HRApplicantWorkerPenalty.PenaltyPerson, " +
                                  " HRApplicantWorkerPenalty.PenaltyEstimationStatement, HRApplicantWorkerPenalty.PenaltyStatus, HRApplicantWorkerPenalty.AttachmentID,HRApplicantWorkerPenalty.PenaltyReasonDesc,ApplicantWorkerTable.*,PenaltyTypeTable.*,PenaltyReasonTable.*" +
                                  " FROM         HRApplicantWorkerPenalty INNER JOIN (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID=HRApplicantWorkerPenalty.PenaltyApplicantID" +
                                  " Left Outer Join (" + PenaltyTypeDb.SearchStr + ") PenaltyTypeTable On HRApplicantWorkerPenalty.PenaltyType=PenaltyTypeTable.PenaltyTypeID" +
                                  " Left Outer Join (" + PenaltyReasonDb.SearchStr + ") PenaltyReasonTable On HRApplicantWorkerPenalty.PenaltyReason=PenaltyReasonTable.PenaltyReasonID";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dlPenaltyDate = _PenaltyDate.ToOADate() - 2;
                string strReturn = " INSERT INTO HRApplicantWorkerPenalty " +
                      "(PenaltyApplicantID, PenaltyType, PenaltyReason, " +
                      " PenaltyDate, PenaltyDesc, PenaltyPerson," +
                      " PenaltyEstimationStatement, PenaltyStatus, " +
                      " AttachmentID,PenaltyReasonDesc, UsrIns, TimIns)" +
                      " VALUES  " +
                      " (" + _PenaltyApplicantID + "," + _PenaltyType + "," + _PenaltyReason + "," +
                      " " + dlPenaltyDate + ",'" + _PenaltyDesc + "'," + _PenaltyPerson + "," +
                      " " + _PenaltyEstimationStatement + "," + _PenaltyStatus + "," +
                      " " + _AttachmentID + ",'" + _PenaltyReasonDesc + "'," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }

        }
        public string EditStr
        {
            get
            {
                double dlPenaltyDate = _PenaltyDate.ToOADate() - 2;
                string strReturn = " UPDATE    HRApplicantWorkerPenalty " +
                                   " SET  PenaltyType =" + _PenaltyType + "" +
                                   " , PenaltyReason =" + _PenaltyReason + "" +
                                   " , PenaltyDate =" + dlPenaltyDate + "" +
                                   " , PenaltyReasonDesc ='" + _PenaltyReasonDesc + "'" +
                                   " , PenaltyDesc ='" + _PenaltyDesc + "'" +
                                   " , PenaltyPerson =" + _PenaltyPerson + "" +
                                   " , PenaltyEstimationStatement =" + _PenaltyEstimationStatement + "" +
                                   " , PenaltyStatus =" + _PenaltyStatus + "" +
                                   " , AttachmentID =" + _AttachmentID + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " Where PenaltyID = " + _PenaltyID + " And PenaltyApplicantID =" + _PenaltyApplicantID + "";
                return strReturn;
            }

        }
        public string DeleteStr
        {
            get
            {

                string strReturn = " Delete From HRApplicantWorkerPenalty " +
                                   " Where PenaltyID = " + _PenaltyID + " And PenaltyApplicantID = " + _PenaltyApplicantID + "";
                return strReturn;
            }

        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDR)
        {
            _PenaltyID = int.Parse(objDR["PenaltyID"].ToString());
            _PenaltyApplicantID = int.Parse(objDR["PenaltyApplicantID"].ToString());
            _PenaltyType = int.Parse(objDR["PenaltyType"].ToString());
            _PenaltyReason = int.Parse(objDR["PenaltyReason"].ToString());
            _PenaltyPerson = int.Parse(objDR["PenaltyPerson"].ToString());
            _PenaltyEstimationStatement = int.Parse(objDR["PenaltyEstimationStatement"].ToString());
            _PenaltyStatus = int.Parse(objDR["PenaltyStatus"].ToString());
            _AttachmentID = int.Parse(objDR["AttachmentID"].ToString());
            _PenaltyDate = DateTime.Parse(objDR["PenaltyDate"].ToString());
            _PenaltyDesc = objDR["PenaltyDesc"].ToString();
            _PenaltyReasonDesc = objDR["PenaltyReasonDesc"].ToString();
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _PenaltyID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
        }

        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " WHERE    (1=1)";
            if (_PenaltyID != 0)
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyID = " + _PenaltyID;
            if (_PenaltyApplicantID != 0)
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyApplicantID = " + _PenaltyApplicantID;
            if (_ApplicantIDs != null && _ApplicantIDs != "")
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyApplicantID in (" + _ApplicantIDs+")";
            if (_PenaltyPerson != 0)
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyPerson = " + _PenaltyPerson;
            if (_PenaltyType != 0)
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyType = " + _PenaltyType;
            if (_PenaltyReason != 0)
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyReason = " + _PenaltyReason;

            if (_PenaltyDateStatusSearch == true)
            {
                double dlFrom = _PenaltyDateFromSearch.Date.ToOADate() - 2;
                double dlTo = _PenaltyDateToSearch.Date.ToOADate() - 2;
                if (dlFrom == dlTo)
                    dlTo = dlTo + 1;
                strSql = strSql + " and HRApplicantWorkerPenalty.PenaltyDate Between " + dlFrom + " And " + dlTo + "";
            }
             if (_InsDateStatusSearch == true)
            {                
                double dblFrom = SysUtility.Approximate(_InsDateFromSearch.ToOADate() - 2, 1, ApproximateType.Down);
                double dblTo = SysUtility.Approximate(_InsDateToSearch.ToOADate() - 2, 1, ApproximateType.Up);
                strSql = strSql + " And  HRApplicantWorkerPenalty.TimIns Between " + dblFrom + " And "+ dblTo +" ";                                   
            }
            if (_UserIDSearch != 0)
            {
                strSql += " And HRApplicantWorkerPenalty.UsrIns = " + _UserIDSearch + "";
            }
            if (_GetPenaltyIsNotStatement)
            {
                double dlFrom = _PenaltyDateFromSearch.Date.ToOADate() - 2;
                double dlTo = _PenaltyDateToSearch.Date.ToOADate() - 2;
                if (dlFrom == dlTo)
                    dlTo = dlTo + 1;
                string st = " And  (PenaltyDate Between " + dlFrom + " And " + dlTo + ")))";
                strSql += " And PenaltyID in (SELECT     DiscountPenalty FROM         HRApplicantWorkerPenaltyDiscount " +
                          " WHERE     (DiscountPenalty IN " +
                          " (SELECT     PenaltyID " +
                          " FROM         HRApplicantWorkerPenalty " +
                          " WHERE (1=1) "+ st +" " +
                          " AND (DiscountStatement = 0) )";
            }


            if (_SetApplicantCache == true)
            {
                ApplicantWorkerDb.SetCashTable();
                ApplicantWorkerDb.ApplicantIDs = " select PenaltyApplicantID from (" + strSql + ") as NativeTable ";

            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
