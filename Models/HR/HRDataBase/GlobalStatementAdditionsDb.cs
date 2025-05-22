using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class GlobalStatementAdditionsDb
    {
        #region Private Data
        protected int _GlobalStatement;
        protected string _Desc;
        protected float _Value;
        protected int _WorkNo;
        protected int _CostCenter;
        #endregion
        #region Constructors
        public GlobalStatementAdditionsDb()
        {
        }
        public GlobalStatementAdditionsDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int GlobalStatement
        {
            set
            {
                _GlobalStatement = value;
            }
            get
            {
                return _GlobalStatement;
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
        public int WorkNo
        {
            set
            {
                _WorkNo = value;
            }
            get
            {
                return _WorkNo;
            }
        }
        public int CostCenter
        {
            set
            {
                _CostCenter = value;
            }
            get
            {
                return _CostCenter;
            }
        }

        public string AddStr
        {
            get
            {
                string ReturnedStr = " INSERT INTO HRGlobalStatementAdditions" +
                                     " (GlobalStatement, AdditionDesc,AdditionValue,WorkNo,CostCenter) "+
                                     " VALUES (" + _GlobalStatement + ",'" + _Desc + "'," + _Value + "," + _WorkNo + ","+ _CostCenter +")";
                return ReturnedStr;
            }
        }        
        public string DeleteStr
        {
            get
            {
                string ReturnedStr = " DELETE FROM HRGlobalStatementAdditions" +
                                     " WHERE     (GlobalStatement = " + _GlobalStatement + ")";
                return ReturnedStr;
            }
        }
        public static string SearchStr
        {
            get
            {
                string ReturnedStr = " SELECT     HRGlobalStatementAdditions.GlobalStatement, HRGlobalStatementAdditions.AdditionDesc ,"+
                                     " HRGlobalStatementAdditions.AdditionValue,HRGlobalStatementAdditions.WorkNo,HRGlobalStatementAdditions.CostCenter as CostCenterAdditional" +
                                     " ,CostCenterHRTable.*" +
                                     " FROM  HRGlobalStatementAdditions "+
                                     " Left Outer join (" + CostCenterHRDb.SearchStr + ") as CostCenterHRTable "+
                                     " On CostCenterHRTable.CostCenterID = HRGlobalStatementAdditions.CostCenter";                                     
                return ReturnedStr;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _GlobalStatement = int.Parse(objDr["GlobalStatement"].ToString());
            _Desc = objDr["AdditionDesc"].ToString();
            _Value = float.Parse(objDr["AdditionValue"].ToString());
            _WorkNo = int.Parse(objDr["WorkNo"].ToString());
            _CostCenter = int.Parse(objDr["CostCenterAdditional"].ToString());
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
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
            if (_CostCenter != 0)
                StrSql = StrSql + " And CostCenterAdditional = " + _CostCenter + "";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
