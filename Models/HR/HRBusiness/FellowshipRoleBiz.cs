using SharpVision.UMS.UMSBusiness;
using SharpVision.COMMON.COMMONDataBase;
using System.IO;
using SharpVision.GL.GLBusiness;
using SharpVision.SystemBase;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public enum FellowshipRoleMotivationOrSalary
    {
        Salary=0,
        Motivation=1
    }
    public class FellowshipRoleBiz
    {
        #region Private Data
        FellowshipRoleDb _RoleDb;
        #endregion
        #region Constructors
        public FellowshipRoleBiz()
        {
            _RoleDb = new FellowshipRoleDb();
        }
        public FellowshipRoleBiz(DataRow objDr)
        {
            _RoleDb = new FellowshipRoleDb(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set { _RoleDb.ID = value; }
            get { return _RoleDb.ID; }
        }
        public string Desc
        {
            set { _RoleDb.Desc = value; }
            get { return _RoleDb.Desc; }
        }
        public double StartSalary
        {
            set { _RoleDb.StartSalary = value; }
            get { return _RoleDb.StartSalary; }
        }
        public double EndSalary
        {
            set { _RoleDb.EndSalary = value; }
            get { return _RoleDb.EndSalary; }
        }
        public double FellowshipPerc
        {
            set { _RoleDb.FellowshipPerc = value; }
            get { return _RoleDb.FellowshipPerc; }
        }
        public double FellowshipValue
        {
            set { _RoleDb.FellowshipValue = value; }
            get { return _RoleDb.FellowshipValue; }
        }
        public int JobNature
        {
            get { return _RoleDb.JobNature; }
            set { _RoleDb.JobNature = value; }
        }
       

        public FellowshipRoleMotivationOrSalary SalaryOrMotivation
        {
            get { return (FellowshipRoleMotivationOrSalary)_RoleDb.SalaryOrMotivation; }
            set { _RoleDb.SalaryOrMotivation = (int)value; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion

    }
}
