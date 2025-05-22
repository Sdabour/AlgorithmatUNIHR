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
    public class ApplicantWorkerPayBackDb
    {
        #region Private Data
        private int _PayBackID;
        private int _Applicant;
        private float _Value;
        private DateTime _Date;
        private string _Desc;
        private int _Statement;
        string _IDsStr;
        #endregion
        #region Constructors
        public ApplicantWorkerPayBackDb()
        {
        }
        public ApplicantWorkerPayBackDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public ApplicantWorkerPayBackDb(int intApplicant,int intStatement)
        {
            if(intApplicant==0 && intStatement==0)
                return;
            _Applicant = intApplicant;
            _Statement = intStatement;

            DataTable objDT = Search();
            if (objDT.Rows.Count != 0)
            {
                foreach (DataRow  objDr in objDT.Rows)
                {
                    SetData(objDr);
                }
            }
        }
        #endregion
        #region Public Properties
        public int PayBackID
        {
            set
            {
                _PayBackID = value;
            }
            get
            {
                return _PayBackID;
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
        public float Value
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
        public string IDsStr
        {
            set
            {
                _IDsStr = value;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " SELECT     HRApplicantWorkerPayBack.PayBackID, HRApplicantWorkerPayBack.PayBackApplicant, HRApplicantWorkerPayBack.PayBackValue, "+
                                  " HRApplicantWorkerPayBack.PayBackDate, HRApplicantWorkerPayBack.PayBackDesc, HRApplicantWorkerPayBack.PayBackStatement,ApplicantWorkerTable.*,GlobalStatementTable.*" +
                                  " FROM         HRApplicantWorkerPayBack "+
                                  " Inner join (" + new ApplicantWorkerDb().ShortSearchStr + ") as ApplicantWorkerTable On ApplicantWorkerTable.ApplicantID = HRApplicantWorkerPayBack.PayBackApplicant" +
                                  " Left Outer join (" + GlobalStatementDb.SearchStr + ") as GlobalStatementTable On GlobalStatementTable.StatementID = HRApplicantWorkerPayBack.PayBackStatement";
                return Returned;
            }
        }
        public string AddStr
        {
            get
            {
                double dlPayBackDate = _Date.ToOADate() - 2;
                string strReturn = " INSERT INTO HRApplicantWorkerPayBack "+
                                   " (PayBackApplicant, PayBackValue, PayBackDate, PayBackDesc, PayBackStatement, UsrIns, TimIns) "+
                                   " VALUES     (" + _Applicant + "," + _Value + "," + dlPayBackDate + ",'" + _Desc + "'," + _Statement + "," + SysData.CurrentUser.ID + ",GetDate()) ";
                return strReturn;
            }

        }
        public string EditStr
        {
            get
            {
                double dlPayBackDate = _Date.ToOADate() - 2;
                string strReturn = " UPDATE    HRApplicantWorkerPayBack "+
                                   " SET PayBackApplicant = " + _Applicant + "" +
                                   ", PayBackValue = " + _Value + "" +
                                   ", PayBackDate = " + dlPayBackDate + "" +
                                   ", PayBackDesc = '" + _Desc + "'" +
                                   ", PayBackStatement = " + _Statement + "" +
                                   ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                   " WHERE     (PayBackID = " + _PayBackID + ")";
                return strReturn;
            }

        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " DELETE FROM HRApplicantWorkerPayBack" +
                                   " WHERE     (PayBackID = " + _PayBackID + ")";
                return strReturn;
            }

        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["PayBackID"].ToString() == "")
                return;
            _PayBackID = int.Parse(objDr["PayBackID"].ToString());
            _Applicant = int.Parse(objDr["PayBackApplicant"].ToString());
            _Value = float.Parse(objDr["PayBackValue"].ToString());
            _Date = DateTime.Parse(objDr["PayBackDate"].ToString());
            _Desc = objDr["PayBackDesc"].ToString();
            _Statement = int.Parse(objDr["PayBackStatement"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _PayBackID = SystemBase.SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
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
            if (_PayBackID != 0)
            {
                strSql += " And PayBackID = "+ _PayBackID +"";
            }
            if (_Applicant != 0)
            {
                strSql += " And PayBackApplicant = " + _Applicant + "";
            }
            if (_Statement != 0)
            {
                strSql += " And PayBackStatement = " + _Statement + "";
            }
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void EditStatement()
        {
            if (_IDsStr == null || _IDsStr == "")
                return;
            string strSql = " UPDATE    HRApplicantWorkerPayBack" +
                                  "  SET " +
                                  " PayBackStatement =" + _Statement + "" +
                                  ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " Where PayBackID in (" + _IDsStr + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}
