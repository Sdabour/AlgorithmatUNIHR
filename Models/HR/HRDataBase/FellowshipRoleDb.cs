using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSDataBase;
using SharpVision.SystemBase;
using System.Data;
using System.Data.SqlClient;
using SharpVision.Base.BaseDataBase;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.GL.GLDataBase;

namespace SharpVision.HR.HRDataBase
{
    public class FellowshipRoleDb
    {
        #region Private Data
      
        #endregion
        #region Constructors
        public FellowshipRoleDb()
        { }
        public FellowshipRoleDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        int _ID;
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        int _JobNature;

        public int JobNature
        {
            get { return _JobNature; }
            set { _JobNature = value; }
        }
        int _SalaryOrMotivation;

        public int SalaryOrMotivation
        {
            get { return _SalaryOrMotivation; }
            set { _SalaryOrMotivation = value; }
        }

        string _Desc;
        public string Desc
        {
            set { _Desc = value; }
            get { return _Desc; }
        }
        double _StartSalary;
        public double StartSalary
        {
            set { _StartSalary = value; }
            get { return _StartSalary; }
        }
        double _EndSalary;
        public double EndSalary
        {
            set { _EndSalary = value; }
            get { return _EndSalary; }
        }
        double _FellowshipPerc;
        public double FellowshipPerc
        {
            set { _FellowshipPerc = value; }
            get { return _FellowshipPerc; }
        }
        double _FellowshipValue;
        public double FellowshipValue
        {
            set { _FellowshipValue = value; }
            get { return _FellowshipValue; }
        }

        public string AddStr
        {
            get
            {
                string Returned = " insert into  HRFellowshipRole(   RoleJobNature, RoleSalaryOrMotivation"+
                    ", RoleDesc, RoleStartSalary, RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue " +
                      ") values ("+ _JobNature + "," + _SalaryOrMotivation +",'"+_Desc+"',"+_StartSalary+
                      ","+_EndSalary+","+_FellowshipPerc+","+_FellowshipValue+")";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update  HRFellowshipRole  " +
                    " set    RoleJobNature="+ _JobNature +
                    ", RoleSalaryOrMotivation="+_SalaryOrMotivation +
                   ", RoleDesc='" + _Desc + "'" +
                   ", RoleStartSalary=" + _StartSalary +
                    ", RoleEndSalary=" + _EndSalary +
", RoleFellowshipPerc=" + _FellowshipPerc +
", RoleFellowshipValue=" + _FellowshipValue +
 " where RoleID = " + _ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update  HRFellowshipRole set Dis = GetDate() where  RoleID = " + _ID;
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = "SELECT RoleID, RoleJobNature, RoleSalaryOrMotivation, RoleDesc, RoleStartSalary" +
                    ", RoleEndSalary, RoleFellowshipPerc, RoleFellowshipValue "+
                          " FROM     dbo.HRFellowshipRole ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            int.TryParse( objDr["RoleID"].ToString(),out _ID);
            _Desc = objDr["RoleDesc"].ToString();
             double.TryParse( objDr["RoleStartSalary"].ToString(),out _StartSalary);
            double.TryParse( objDr["RoleEndSalary"].ToString(),out _EndSalary);
            double.TryParse( objDr["RoleFellowshipPerc"].ToString(),out _FellowshipPerc);
            double.TryParse( objDr["RoleFellowshipValue"].ToString(),out _FellowshipValue);
            int.TryParse(objDr["RoleJobNature"].ToString(), out _JobNature);
            int.TryParse(objDr["RoleSalaryOrMotivation"].ToString(), out _SalaryOrMotivation);

        }
        #endregion
        #region Public Methods
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
            string strSql = SearchStr +" where Dis is null ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}
