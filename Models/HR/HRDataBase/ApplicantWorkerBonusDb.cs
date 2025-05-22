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
    public class ApplicantWorkerBonusDb
    {
        #region Private Data

        protected int _ID;
        protected int _BonusApplicant;
        protected string _BonusReason;
        protected DateTime _BonusDate;
        protected int _BonusImage;
        protected int _BonusStatement;
        protected float _BonusValue;
        protected float _BonusDay;
        protected bool _BonusDateSearch;
        protected DateTime _BonusDateFromSearch;
        protected DateTime _BonusDateToSearch;
        string _IDsStr;
        #region Data For Search
        bool _OnlyNonStatemented;
        #endregion
        #endregion
        #region Constructors
        public ApplicantWorkerBonusDb()
        {
        }
        public ApplicantWorkerBonusDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ApplicantWorkerBonusDb(int intApplicant)
        {
            _BonusApplicant = intApplicant;
            DataTable objDt = Search();
            if (objDt.Rows.Count != 0)
                SetData(objDt.Rows[0]);
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
        public int BonusApplicant
        {
            set
            {
                _BonusApplicant = value;
            }
            get
            {
                return _BonusApplicant;
            }
        }
        public float BonusValue
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
        public float BonusDay
        {
            set
            {
                _BonusDay = value;
            }
            get
            {
                return _BonusDay;
            }
        }
        public string BonusReason
        {
            set
            {
                _BonusReason = value;
            }
            get
            {
                return _BonusReason;
            }
        }
        public DateTime BonusDate
        {
            set
            {
                _BonusDate = value;
            }
            get
            {
                return _BonusDate;
            }
        }
        public int BonusImage
        {
            set
            {
                _BonusImage = value;
            }
            get
            {
                return _BonusImage;
            }
        }
        public int BonusStatement
        {
            set
            {
                _BonusStatement = value;
            }
            get
            {
                return _BonusStatement;
            }
        }
        public bool BonusDateSearch
        {
            set
            {
                _BonusDateSearch = value;
            }
            get
            {
                return _BonusDateSearch;
            }
        }
        public DateTime BonusDateFromSearch
        {
            set
            {
                _BonusDateFromSearch = value;
            }
            get
            {
                return _BonusDateFromSearch;
            }
        }
        public DateTime BonusDateToSearch
        {
            set
            {
                _BonusDateToSearch = value;
            }
            get
            {
                return _BonusDateToSearch;
            }
        }
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public bool OnlyNonStatemented
        {
            set
            {
                _OnlyNonStatemented = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerBonus.BonusID, HRApplicantWorkerBonus.BonusApplicant, HRApplicantWorkerBonus.BonusReason,HRApplicantWorkerBonus.BonusValue,HRApplicantWorkerBonus.BonusDay, " +
                                  " HRApplicantWorkerBonus.BonusDate, HRApplicantWorkerBonus.BonusImage, HRApplicantWorkerBonus.BonusStatement,ApplicantWorkerTable.*" +
                                  " FROM         HRApplicantWorkerBonus "+
                                  " INNER JOIN (" + new ApplicantWorkerDb().ShortSearchStr + ") ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID=HRApplicantWorkerBonus.BonusApplicant";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dlBonusDate = _BonusDate.ToOADate() - 2;             
                string strReturn = " INSERT INTO HRApplicantWorkerBonus "+
                                   " (BonusApplicant, BonusValue,BonusDay,BonusReason, BonusDate, BonusImage, BonusStatement, UsrIns, TimIns)" +
                                   " VALUES "+
                                   "(" + _BonusApplicant + "," + _BonusValue + "," + _BonusDay + ",'" + _BonusReason + "'," + dlBonusDate + "," +
                                   "" + _BonusImage + "," + _BonusStatement + "," +
                                   "" + SysData.CurrentUser.ID + ",GetDate()) ";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                double dlBonusDate = _BonusDate.ToOADate() - 2;
                string strReturn = " UPDATE    HRApplicantWorkerBonus "+
                                   " SET BonusReason ='" + _BonusReason + "'" +
                                   ", BonusDate =" + dlBonusDate + "" +
                                   ", BonusValue =" + _BonusValue + "" +
                                   ", BonusDay =" + _BonusDay + "" +
                                   ", BonusImage =" + _BonusImage + "" +
                                   ", BonusStatement =" + _BonusStatement + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " WHERE     (BonusID = " + _ID + ") AND (BonusApplicant = " + _BonusApplicant + ") ";
                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " Delete From HRApplicantWorkerBonus "+
                                   " WHERE     (BonusID = " + _ID + ") AND (BonusApplicant = " + _BonusApplicant + ") "; 
                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["BonusID"].ToString());
            if (objDr["BonusValue"].ToString() != "")
                _BonusValue = float.Parse(objDr["BonusValue"].ToString());
            if (objDr["BonusDay"].ToString() != "")
                _BonusDay = float.Parse(objDr["BonusDay"].ToString());
            _BonusApplicant = int.Parse(objDr["BonusApplicant"].ToString());
            _BonusReason = objDr["BonusReason"].ToString();
            _BonusDate = DateTime.Parse(objDr["BonusDate"].ToString());
            _BonusImage = int.Parse(objDr["BonusImage"].ToString());
            _BonusStatement = int.Parse(objDr["BonusStatement"].ToString());
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
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerBonus "+
                                   " SET  BonusStatement =" + _BonusStatement + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " WHERE     (BonusID in (" + _IDsStr + ")) AND (BonusApplicant = " + _BonusApplicant + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " Where 1=1 ";
            if (_BonusApplicant != 0)
                strSql = strSql + " And BonusApplicant = " + _BonusApplicant + "";
            if (_BonusStatement != 0)
                strSql += " and HRApplicantWorkerBonus.BonusStatement =" + _BonusStatement;
            if (_OnlyNonStatemented)
                strSql += " and HRApplicantWorkerBonus.BonusStatement =0 ";
            if (_BonusDateSearch == true)
            {
                int intBonusFrom;
                double d = _BonusDateFromSearch.ToOADate() - 2;
                intBonusFrom = (int)d;

                int intBonusTo;
                double dd = _BonusDateToSearch.ToOADate() - 2;
                intBonusTo = (int)dd + 1;

                strSql = strSql + " And convert(float,HRApplicantWorkerBonus.BonusDate) Between  "+ intBonusFrom +" and "+ intBonusTo +"";
                
            }

            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
