using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
namespace SharpVision.HR.HRBusiness
{
    public class FellowshipRoleCol : CollectionBase
    {
        public FellowshipRoleCol()
        {
            FellowshipRoleDb objDb = new FellowshipRoleDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Add(new FellowshipRoleBiz(objDr));
        }
        public FellowshipRoleCol(bool blIsEmpty)
        { }
        public FellowshipRoleBiz this[int intIndex]
        {
            get { return (FellowshipRoleBiz)List[intIndex]; }
            set { List[intIndex] = value; }
        }
        static FellowshipRoleCol _RoleCol;
        public static FellowshipRoleCol RoleCol
        {
            get
            {
                if(_RoleCol == null)
                     _RoleCol= new FellowshipRoleCol();

                return _RoleCol;
            }
        }
        public void Add(FellowshipRoleBiz objBiz)
        {
            List.Add(objBiz);
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("RoleID"), new DataColumn("RoleDesc"), 
                new DataColumn("RoleStartSalary"), new DataColumn("RoleEndSalary"), new DataColumn("RoleFellowshipPerc")
                , new DataColumn("RoleFellowshipValue") });
            DataRow objDr;
            foreach (FellowshipRoleBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["RoleID"] = objBiz.ID;
                objDr["RoleDesc"] = objBiz.Desc;
                objDr["RoleStartSalary"] = objBiz.StartSalary;
                objDr["RoleEndSalary"] = objBiz.EndSalary;
                objDr["RoleFellowshipPerc"] = objBiz.FellowshipPerc;
                objDr["RoleFellowshipValue"] = objBiz.FellowshipValue;



                Returned.Rows.Add(objDr);
            }
           
            return Returned;
        }
        public static double GetRecommendedFellowship(FellowshipRoleMotivationOrSalary objRoleMotivationOrSalary
            ,double dblSalary,ApplicantWorkerBiz objWorkerBiz)
        {
          double Returned = 0;
            foreach (FellowshipRoleBiz objRoleBiz in RoleCol)
            {
                if (objRoleBiz.SalaryOrMotivation == objRoleMotivationOrSalary &&
                    (objRoleBiz.JobNature ==0 || objRoleBiz.JobNature == objWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz.ID )&&
                    (dblSalary >= objRoleBiz.StartSalary && dblSalary <= objRoleBiz.EndSalary))
                {
                    Returned = (objRoleBiz.FellowshipPerc * dblSalary )/100;
                    if (Returned == 0)
                        Returned = objRoleBiz.FellowshipValue;

                    break;
                }
            }
            return Returned;
        }
    }
}
