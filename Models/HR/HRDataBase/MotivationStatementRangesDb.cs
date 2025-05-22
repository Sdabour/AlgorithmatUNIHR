using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class MotivationStatementRangesDb
    {
        #region Private Data        
        protected int _MotivationStatement;
        protected int _RangeFrom;
        protected int _RangeTo;
        protected string _Remarks;
        protected bool _IsFinish;
        protected double _PrivateAdditionValueManagement;
        protected int _PrivateApplicantCountManagement;
        protected double _PrivateAdditionValueMarketing;
        protected int _PrivateApplicantCountMarketing;
        
        protected int _CostCenterType;
        protected int _CostCenterTypeSearch=-1;
        #endregion
        #region Constructors
        public MotivationStatementRangesDb()
        {
        }
        public MotivationStatementRangesDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties        
        public int MotivationStatement { set { _MotivationStatement = value; } get { return _MotivationStatement; } }
        public int CostCenterType { set { _CostCenterType = value; } get { return _CostCenterType; } }
        public int RangeFrom { set { _RangeFrom = value; } get { return _RangeFrom; } }
        public int RangeTo { set { _RangeTo = value; } get { return _RangeTo; } }
        public string Remarks { set { _Remarks = value; } get { return _Remarks; } }
        public bool IsFinish { set { _IsFinish = value; } get { return _IsFinish; } }
        public int PrivateApplicantCountManagement { set { _PrivateApplicantCountManagement = value; } get { return _PrivateApplicantCountManagement; } }
        public double PrivateAdditionValueManagement { set { _PrivateAdditionValueManagement = value; } get { return _PrivateAdditionValueManagement; } }
        public int PrivateApplicantCountMarketing { set { _PrivateApplicantCountMarketing = value; } get { return _PrivateApplicantCountMarketing; } }
        public double PrivateAdditionValueMarketing { set { _PrivateAdditionValueMarketing = value; } get { return _PrivateAdditionValueMarketing; } }
        public int CostCenterTypeSearch { set { _CostCenterTypeSearch = value; } get { return _CostCenterTypeSearch; } }
        public string AddStr
        {
            get
            {
                int intIsFinish = _IsFinish ? 1 : 0;
                string strReturn=" INSERT INTO HRMotivationStatementRanges"+
                                 " (MotivationStatement, RangeFrom,RangeTo,Remarks,IsFinish,PrivateAdditionValueManagement,PrivateApplicantCountManagement,PrivateAdditionValueMarketing,PrivateApplicantCountMarketing,CostCenterType, UsrIns, TimIns)" +
                                 " VALUES (" + _MotivationStatement + "," + _RangeFrom + "," + _RangeTo + ",'" + _Remarks + "'," + intIsFinish + "," + _PrivateAdditionValueManagement + "," + _PrivateApplicantCountManagement + "," + _PrivateAdditionValueMarketing + "," + _PrivateApplicantCountMarketing + "," + _CostCenterType + "," + SysData.CurrentUser.ID + ",GetDate())";
                return strReturn;
            }
        }
        public string EditStr
        {
            get
            {
                string strReturn = " ";

                return strReturn;
            }
        }
        public string DeleteStr
        {
            get
            {
                string strReturn = " Delete From HRMotivationStatementRanges WHERE (MotivationStatement =" + _MotivationStatement + ")";

                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT      MotivationStatement, RangeFrom,RangeTo,Remarks,IsFinish,PrivateAdditionValueManagement,PrivateApplicantCountManagement,PrivateAdditionValueMarketing,PrivateApplicantCountMarketing,CostCenterType " +
                                   " FROM         HRMotivationStatementRanges";

                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["MotivationStatement"].ToString() == "")
                return;

            _MotivationStatement = int.Parse(objDr["MotivationStatement"].ToString());
            _RangeFrom = int.Parse(objDr["RangeFrom"].ToString());
            _RangeTo = int.Parse(objDr["RangeTo"].ToString());
            _Remarks = objDr["Remarks"].ToString();
            if (objDr["IsFinish"].ToString() != "")
                _IsFinish = bool.Parse(objDr["IsFinish"].ToString());
            if (objDr["PrivateAdditionValueManagement"].ToString() != "")
            _PrivateAdditionValueManagement = double.Parse(objDr["PrivateAdditionValueManagement"].ToString());
            if (objDr["PrivateApplicantCountManagement"].ToString()!="")
            _PrivateApplicantCountManagement = int.Parse(objDr["PrivateApplicantCountManagement"].ToString());

            if (objDr["PrivateAdditionValueMarketing"].ToString() != "")
                _PrivateAdditionValueMarketing = double.Parse(objDr["PrivateAdditionValueMarketing"].ToString());
            if (objDr["PrivateApplicantCountMarketing"].ToString() != "")
                _PrivateApplicantCountMarketing = int.Parse(objDr["PrivateApplicantCountMarketing"].ToString());

        _CostCenterType = int.Parse(objDr["CostCenterType"].ToString());
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
                StrSql = StrSql + " And MotivationStatement = " + _MotivationStatement + "";
            if (_CostCenterType == -1)
                StrSql = StrSql + " and (CostCenterType = 0)";
            else if (_CostCenterType != 0)
                StrSql = StrSql + " and (CostCenterType = " + _CostCenterType + ")";


            if (_CostCenterTypeSearch != -1)
                StrSql = StrSql + " and (CostCenterType = " + _CostCenterType + ")";

            StrSql += " Order by RangeTo";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        public void DeleteRange(int intMotivationID, int intCostCenterType)
        {
            string str = "DELETE FROM HRMotivationStatementRanges WHERE     (MotivationStatement = " + intMotivationID + ") AND (CostCenterType = " + intCostCenterType + ")";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(str);
        }
        #endregion
    }
}
