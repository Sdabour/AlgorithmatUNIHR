using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
namespace AlgorithmatMVC.Milango.MilangoDb
{
    public class MilangoCustomerDb
    {

        #region Constructor
        public MilangoCustomerDb()
        {
        }
        public MilangoCustomerDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        string _Bp;
        public string Bp
        {
            set => _Bp = value;
            get => _Bp;
        }
        string _No;
        public string No
        {
            set => _No = value;
            get => _No;
        }
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Name;
        public string Name
        {
            set => _Name = value;
            get => _Name;
        }
        string _MobileNo;
        public string MobileNo
        {
            set => _MobileNo = value;
            get => _MobileNo;
        }
        int _Status;
        public int Status
        {
            set => _Status = value;
            get => _Status;
        }
        bool _Changed;
        public bool Changed
        {
            set => _Changed = value;
            get => _Changed;
        }
        bool _ChangesSent;
        public bool ChangesSent
        {
            set => _ChangesSent = value;
            get => _ChangesSent;
        }
        DataTable _UnitTable;
        public DataTable UnitTable
        { set => _UnitTable = value; }
        public string AddStr
        {
            get
            {
                string Returned = @" insert into MILANGOCustomer (CustomerBp,CustomerNo,CustomerID,CustomerName,CustomerMobileNo,CustomerStatus,CustomerChanged,CustomerChangesSent) 
                    select '" + Bp + "' as Bp1,'" + No + "' as No1," + ID + " as ID1,'" + Name + "' as Name1,'" + MobileNo + "' as MobileNo1," + Status + @" as CustomerStatus1,0 as Changed1,1 as ChangesSent1 
 where not exists (select CustomerBp from MILANGOCustomer where CustomerBp='"+Bp+"') ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update MILANGOCustomer set " + "CustomerBp='" + Bp + "'" +
           ",CustomerNo='" + No + "'" +
           ",CustomerID=" + ID + "" +
           ",CustomerName='" + Name + "'" +
           ",CustomerMobileNo='" + MobileNo + "'" +
           ",CustomerStatus=" + Status + "" +
           ",CustomerChanged=" + (Changed ? 1 : 0) + "" +
           ",CustomerChangesSent=" + (ChangesSent ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update MILANGOCustomer set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select CustomerBp,CustomerNo,CustomerID,CustomerName,CustomerMobileNo,CustomerStatus,CustomerChanged,CustomerChangesSent from MILANGOCustomer  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["CustomerBp"] != null)
                _Bp = objDr["CustomerBp"].ToString();

            if (objDr.Table.Columns["CustomerNo"] != null)
                _No = objDr["CustomerNo"].ToString();

            if (objDr.Table.Columns["CustomerID"] != null)
                int.TryParse(objDr["CustomerID"].ToString(), out _ID);

            if (objDr.Table.Columns["CustomerName"] != null)
                _Name = objDr["CustomerName"].ToString();

            if (objDr.Table.Columns["CustomerMobileNo"] != null)
                _MobileNo = objDr["CustomerMobileNo"].ToString();

            if (objDr.Table.Columns["CustomerStatus"] != null)
                int.TryParse(objDr["CustomerStatus"].ToString(), out _Status);

            if (objDr.Table.Columns["CustomerChanged"] != null)
                bool.TryParse(objDr["CustomerChanged"].ToString(), out _Changed);

            if (objDr.Table.Columns["CustomerChangesSent"] != null)
                bool.TryParse(objDr["CustomerChangesSent"].ToString(), out _ChangesSent);
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            JoinUnitTable();
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
        void JoinUnitTable()
        {
            if (_UnitTable == null || _UnitTable.Rows.Count == 0)
                return;
            SysData.SharpVisionBaseDb.ExecuteNonQuery("truncate table MILANGOCustomerUnitTemp");
            SqlBulkCopy objCopy = new SqlBulkCopy(SysData.SharpVisionBaseDb.sqlConnection.ConnectionString);
            objCopy.DestinationTableName = "MILANGOCustomerUnitTemp";
            objCopy.WriteToServer(_UnitTable);
            string strInnerCustomerUnit = @"SELECT ISNULL(MILANGOCustomerUnit_1.CustomerBp, MILANGOCustomerUnitTemp_1.CustomerBp) AS Bp

                   FROM      (SELECT dbo.MILANGOCustomerUnit.CustomerBp, dbo.MILANGOCustomerUnit.UnitCode, dbo.MILANGOCustomerUnit.UnitProjectName, dbo.MILANGOCustomerUnit.UnitProjectCode
FROM     dbo.MILANGOCustomerUnit INNER JOIN
                  dbo.MILANGOCustomerUnitTemp ON dbo.MILANGOCustomerUnit.CustomerBp = dbo.MILANGOCustomerUnitTemp.CustomerBp) AS MILANGOCustomerUnit_1 FULL OUTER JOIN

                                     dbo.MILANGOCustomerUnitTemp as MILANGOCustomerUnitTemp_1  ON MILANGOCustomerUnit_1.CustomerBp =  MILANGOCustomerUnitTemp_1.CustomerBp AND MILANGOCustomerUnit_1.UnitCode = MILANGOCustomerUnitTemp_1.UnitCode AND

                                     MILANGOCustomerUnit_1.UnitProjectCode = MILANGOCustomerUnitTemp_1.UnitProjectCode

                   WHERE(ISNULL(MILANGOCustomerUnit_1.CustomerBp, MILANGOCustomerUnitTemp_1.CustomerBp) IS NULL) OR
                                     (MILANGOCustomerUnitTemp_1.CustomerBp IS NULL)";
            string strSql = @" update dbo.MILANGOCustomerUnit set UnitChanged= 1, dbo.MILANGOCustomerUnit.UnitChangesSent=0
FROM dbo.MILANGOCustomerUnit
INNER JOIN (
"+strInnerCustomerUnit+@"
) AS derivedtbl_1 ON dbo.MILANGOCustomerUnit.CustomerBp = derivedtbl_1.Bp";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

            strSql = @"delete
FROM     dbo.MILANGOCustomerUnit
WHERE  (CustomerBp IN
                      (SELECT CustomerBp
                       FROM      dbo.MILANGOCustomerUnitTemp))";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
            strSql = @"insert into MILANGOCustomerUnit (CustomerBp, UnitCode, UnitProjectName, UnitProjectCode, UnitStatus, UnitChanged, UnitChangesSent
) 
 SELECT distinct CustomerBp, UnitCode, UnitProjectName, UnitProjectCode, UnitStatus, UnitChanged, UnitChangesSent
FROM     dbo.MILANGOCustomerUnitTemp ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }
        #endregion
    }
}