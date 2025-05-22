using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.Milango.MilangoDb
{
    public class MilangoCustomerUnitDb
    {

        #region Constructor
        public MilangoCustomerUnitDb()
        {
        }
        public MilangoCustomerUnitDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        string _CustomerBp;
        public string CustomerBp
        {
            set => _CustomerBp = value;
            get => _CustomerBp;
        }
        string _UnitCode;
        public string UnitCode
        {
            set => _UnitCode = value;
            get => _UnitCode;
        }
        string _UnitProjectName;
        public string UnitProjectName
        {
            set => _UnitProjectName = value;
            get => _UnitProjectName;
        }
        string _UnitProjectCode;
        public string UnitProjectCode
        {
            set => _UnitProjectCode = value;
            get => _UnitProjectCode;
        }
        int _UnitStatus;
        public int UnitStatus
        {
            set => _UnitStatus = value;
            get => _UnitStatus;
        }
        bool _UnitChanged;
        public bool UnitChanged
        {
            set => _UnitChanged = value;
            get => _UnitChanged;
        }
        bool _UnitChangesSent;
        public bool UnitChangesSent
        {
            set => _UnitChangesSent = value;
            get => _UnitChangesSent;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into MILANGOCustomerUnit (CustomerBp,UnitCode,UnitProjectName,UnitProjectCode,UnitStatus,UnitChanged,UnitChangesSent,UsrIns,TimIns) values (,'" + CustomerBp + "','" + UnitCode + "','" + UnitProjectName + "','" + UnitProjectCode + "'," + UnitStatus + "," + (UnitChanged ? 1 : 0) + "," + (UnitChangesSent ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MILANGOCustomerUnit set " + "CustomerBp='" + CustomerBp + "'" +
           ",UnitCode='" + UnitCode + "'" +
           ",UnitProjectName='" + UnitProjectName + "'" +
           ",UnitProjectCode='" + UnitProjectCode + "'" +
           ",UnitStatus=" + UnitStatus + "" +
           ",UnitChanged=" + (UnitChanged ? 1 : 0) + "" +
           ",UnitChangesSent=" + (UnitChangesSent ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MILANGOCustomerUnit set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select CustomerBp,UnitCode,UnitProjectName,UnitProjectCode,UnitStatus,UnitChanged,UnitChangesSent from MILANGOCustomerUnit  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CustomerBp"] != null)
                _CustomerBp = objDr["CustomerBp"].ToString();

            if (objDr.Table.Columns["UnitCode"] != null)
                _UnitCode = objDr["UnitCode"].ToString();

            if (objDr.Table.Columns["UnitProjectName"] != null)
                _UnitProjectName = objDr["UnitProjectName"].ToString();

            if (objDr.Table.Columns["UnitProjectCode"] != null)
                _UnitProjectCode = objDr["UnitProjectCode"].ToString();

            if (objDr.Table.Columns["UnitStatus"] != null)
                int.TryParse(objDr["UnitStatus"].ToString(), out _UnitStatus);

            if (objDr.Table.Columns["UnitChanged"] != null)
                bool.TryParse(objDr["UnitChanged"].ToString(), out _UnitChanged);

            if (objDr.Table.Columns["UnitChangesSent"] != null)
                bool.TryParse(objDr["UnitChangesSent"].ToString(), out _UnitChangesSent);
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