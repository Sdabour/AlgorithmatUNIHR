using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.UMS.UMSDataBase;
using SharpVision.COMMON.COMMONDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class MotivationStatementCostCenterDb
    {
        #region Private Data
        protected int _MotivationStatement;
        protected int _CostCenter;
        protected double _MotivationStatementAddValue;
        protected double _BounsOnDeserved;
        protected bool _IsIncludeAllApplicant;
        protected string _Remarks;
        protected double _MotivationRatio;
        protected byte _ApplicantStatus;
        protected int _CostCenterType;
        protected string _CostCenterIDs;
        protected string _MotivationStatementIDs;
        #endregion
        #region Constructors
        public MotivationStatementCostCenterDb()
        {
        }
        public MotivationStatementCostCenterDb(DataRow objDr)
        {
            SetData(objDr);
        }
        public MotivationStatementCostCenterDb(int intMotivationStatement, int intCostCenter)
        {
            _MotivationStatement = intMotivationStatement;
            _CostCenter = intCostCenter;
            DataTable dtTemp = Search();
            if (dtTemp.Rows.Count != 0)
                SetData(dtTemp.Rows[0]);
        }
        #endregion
        #region Public Properties
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int CostCenter { set { _CostCenter = value; } get { return _CostCenter; } }        
        public double MotivationStatementAddValue { set { _MotivationStatementAddValue = value; } get { return _MotivationStatementAddValue; } }
        public double BounsOnDeserved { set { _BounsOnDeserved = value; } get { return _BounsOnDeserved; } }
        public bool IsIncludeAllApplicant { set { _IsIncludeAllApplicant = value; } get { return _IsIncludeAllApplicant; } }
        public string Remarks { set { _Remarks = value; } get { return _Remarks; } }
        public string CostCenterIDs { set { _CostCenterIDs = value; } }

        public string MotivationStatementIDs { set { _MotivationStatementIDs = value; } }
        public double MotivationRatio { set { _MotivationRatio = value; } get { return _MotivationRatio; } }
        public byte ApplicantStatus { set { _ApplicantStatus = value; } get { return _ApplicantStatus; } }
        public int CostCenterType { set { _CostCenterType = value; } get { return _CostCenterType; } }        
        public string AddStr
        {
            get
            {
                int intIsIncludeAllApplicant = _IsIncludeAllApplicant ? 1 : 0;
                string ReturnedStr = " INSERT INTO HRMotivationStatementCostCenter " +
                                     " (MotivationStatement, CostCenter,MotivationStatementAddValue,BounsOnDeserved,IsIncludeAllApplicant," +
                                     " MotivationRatio,Remarks,ApplicantStatus,CostCenterTypeTemp,UsrIns,TimIns)" +
                                     " VALUES (" + _MotivationStatement + "," + _CostCenter + "," + _MotivationStatementAddValue + "" +
                                     " ," + _BounsOnDeserved + "," + intIsIncludeAllApplicant + "," + _MotivationRatio + "," +
                                     " '" + _Remarks + "'," + ApplicantStatus + ","+ _CostCenterType +"" +
                                     " ," + SysData.CurrentUser.ID + ",GetDate())";
                return ReturnedStr;
            }
        }
        public string EditStr
        {
            get
            {
                int intIsIncludeAllApplicant = _IsIncludeAllApplicant ? 1 : 0;
                string ReturnedStr = " UPDATE    HRMotivationStatementCostCenter "+
                                     "  SET MotivationStatementAddValue =" + _MotivationStatementAddValue + "" +
                                     ", BounsOnDeserved =" + _BounsOnDeserved + "" +
                                     ", IsIncludeAllApplicant =" + intIsIncludeAllApplicant + "" +
                                     ", Remarks ='" + _Remarks + "'" +
                                     ", MotivationRatio = " + _MotivationRatio + "" +
                                     ", ApplicantStatus = " + _ApplicantStatus + "" +
                                     ", CostCenterTypeTemp = " + _CostCenterType + "" +
                                     ", UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                     " WHERE     (CostCenter = " + _CostCenter + ") AND (MotivationStatement = " + _MotivationStatement + ")";
                return ReturnedStr;
            }
        }
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " Delete From HRMotivationStatementCostCenter " +
                                     " Where  MotivationStatement = " + _MotivationStatement + "" +
                                     " And CostCenter = " + _CostCenter + "";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT  MotivationStatement,MotivationStatementAddValue, BounsOnDeserved, IsIncludeAllApplicant,"+
                                     " CostCenterTypeTemp,Remarks,MotivationRatio,ApplicantStatus,CostCenterHRTable.*,MotivationStatementTable.* " +
                                     " FROM         HRMotivationStatementCostCenter " +
                                     " Inner join (" + CostCenterHRDb.SearchStr + ") as CostCenterHRTable " +
                                     " ON CostCenterHRTable.CostCenterID = HRMotivationStatementCostCenter.CostCenter "+
                                     " Inner Join (" + MotivationStatementDb.SearchStr + ") as MotivationStatementTable "+
                                     " On MotivationStatementTable.MotivationStatementID = HRMotivationStatementCostCenter.MotivationStatement";
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _CostCenter = int.Parse(objDr["CostCenterID"].ToString());
            _MotivationStatementAddValue = double.Parse(objDr["MotivationStatementAddValue"].ToString());
            _BounsOnDeserved = double.Parse(objDr["BounsOnDeserved"].ToString());
            _IsIncludeAllApplicant = bool.Parse(objDr["IsIncludeAllApplicant"].ToString());
            _Remarks = objDr["Remarks"].ToString();
            _MotivationRatio = double.Parse(objDr["MotivationRatio"].ToString());
            _ApplicantStatus = byte.Parse(objDr["ApplicantStatus"].ToString());
            _CostCenterType = int.Parse(objDr["CostCenterTypeTemp"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
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
            string StrSql = SearchStr + " Where 1=1 ";
            if (_MotivationStatement != 0)
                StrSql = StrSql + " And HRMotivationStatementCostCenter.MotivationStatement = " + _MotivationStatement + "";

            if (_CostCenter != 0)
                StrSql = StrSql + " And HRMotivationStatementCostCenter.CostCenter = " + _CostCenter + "";
            if (_CostCenterIDs != null && _CostCenterIDs !="")
                StrSql = StrSql + " And HRMotivationStatementCostCenter.CostCenter in (" + _CostCenterIDs + ")";
            if (_MotivationStatementIDs != null && _MotivationStatementIDs != "")
                StrSql = StrSql + " And HRMotivationStatementCostCenter.MotivationStatement in (" + _MotivationStatementIDs + ")";
            if (_CostCenterType != 0)
                StrSql = StrSql + " And HRMotivationStatementCostCenter.CostCenterTypeTemp = " + _CostCenterType + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
