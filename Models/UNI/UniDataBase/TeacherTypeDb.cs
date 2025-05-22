using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class TeacherTypeDb
    {

        #region Constructor
        public TeacherTypeDb()
        {
        }
        public TeacherTypeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        int _Order;
        public int Order
        {
            set => _Order = value;
            get => _Order;
        }
        int _FunctionGroup;
        public int FunctionGroup
        {
            set => _FunctionGroup = value;
            get => _FunctionGroup;
        }
        int _JobNatureID;
        public int JobNatureID
        {
            set => _JobNatureID = value;
            get => _JobNatureID;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNITeacherType (TeacherTypeID,TeacherTypeCode,TeacherTypeNameA,TeacherTypeOrder,TeacherTypeFunctionGroup,TeacherTypeJobNatureID,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + NameA + "'," + Order + "," + FunctionGroup + "," + JobNatureID + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNITeacherType set " + "TeacherTypeID=" + ID + "" +
           ",TeacherTypeCode='" + Code + "'" +
           ",TeacherTypeNameA='" + NameA + "'" +
           ",TeacherTypeOrder=" + Order + "" +
           ",TeacherTypeFunctionGroup=" + FunctionGroup + "" +
           ",TeacherTypeJobNatureID=" + JobNatureID + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNITeacherType set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select TeacherTypeID,TeacherTypeCode,TeacherTypeNameA,TeacherTypeOrder,TeacherTypeFunctionGroup,TeacherTypeJobNatureID from UNITeacherType  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["TeacherTypeID"] != null)
                int.TryParse(objDr["TeacherTypeID"].ToString(), out _ID);

            if (objDr.Table.Columns["TeacherTypeCode"] != null)
                _Code = objDr["TeacherTypeCode"].ToString();

            if (objDr.Table.Columns["TeacherTypeNameA"] != null)
                _NameA = objDr["TeacherTypeNameA"].ToString();

            if (objDr.Table.Columns["TeacherTypeOrder"] != null)
                int.TryParse(objDr["TeacherTypeOrder"].ToString(), out _Order);

            if (objDr.Table.Columns["TeacherTypeFunctionGroup"] != null)
                int.TryParse(objDr["TeacherTypeFunctionGroup"].ToString(), out _FunctionGroup);

            if (objDr.Table.Columns["TeacherTypeJobNatureID"] != null)
                int.TryParse(objDr["TeacherTypeJobNatureID"].ToString(), out _JobNatureID);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}