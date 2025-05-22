using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;

namespace SharpVision.HR.HRDataBase
{
    public class GlobalStatementRangesDb
    {
        #region Private Data        
        protected int _GlobalStatement;
        protected int _RangeFrom;
        protected int _RangeTo;
        protected string _Remarks;
        protected bool _IsFinish;
        #endregion
        #region Constructors
        public GlobalStatementRangesDb()
        {
        }
        public GlobalStatementRangesDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties        
        public int GlobalStatement { set { _GlobalStatement = value; } get { return _GlobalStatement; } }
        public int RangeFrom { set { _RangeFrom = value; } get { return _RangeFrom; } }
        public int RangeTo { set { _RangeTo = value; } get { return _RangeTo; } }
        public string Remarks { set { _Remarks = value; } get { return _Remarks; } }
        public bool IsFinish { set { _IsFinish = value; } get { return _IsFinish; } }

        public string AddStr
        {
            get
            {
                int intIsFinish = _IsFinish ? 1 : 0;
                string strReturn=" INSERT INTO HRGlobalStatementRanges"+
                                 " (GlobalStatement, RangeFrom,RangeTo,Remarks,IsFinish, UsrIns, TimIns)" +
                                 " VALUES (" + _GlobalStatement + "," + _RangeFrom + "," + _RangeTo + ",'" + _Remarks + "'," + intIsFinish + "," + SysData.CurrentUser.ID + ",GetDate())";
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
                string strReturn = " Delete From HRGlobalStatementRanges WHERE (GlobalStatement =" + _GlobalStatement + ")";

                return strReturn;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strReturn = " SELECT      GlobalStatement, RangeFrom,RangeTo,Remarks,IsFinish " +
                                   " FROM         HRGlobalStatementRanges";

                return strReturn;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["GlobalStatement"].ToString() == "")
                return;

            _GlobalStatement = int.Parse(objDr["GlobalStatement"].ToString());
            _RangeFrom = int.Parse(objDr["RangeFrom"].ToString());
            _RangeTo = int.Parse(objDr["RangeTo"].ToString());
            _Remarks = objDr["Remarks"].ToString();
            if(objDr["IsFinish"].ToString()!="")
            _IsFinish = bool.Parse(objDr["IsFinish"].ToString());
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
            if (_GlobalStatement != 0)
                StrSql = StrSql + " And GlobalStatement = " + _GlobalStatement + "";
            StrSql += " Order by RangeTo";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
