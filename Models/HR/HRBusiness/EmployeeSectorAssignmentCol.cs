using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.UMS.UMSBusiness;
using System;
using System.Collections;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
    public class EmployeeSectorAssignmentCol : CollectionBase
    {
        #region Private Data
        Hashtable _SectorTable = new Hashtable();
        #endregion
        #region Constructors
        public EmployeeSectorAssignmentCol(bool blIsEmpty)
        {

        }
        public EmployeeSectorAssignmentCol(EmployeeBiz objEmployeeBiz)
        {
            if (objEmployeeBiz == null || objEmployeeBiz.ID == 0)
                return;
            EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb();
            objDb.EmployeeID = objEmployeeBiz.ID;
            DataTable dtTemp = objDb.Search();
            EmployeeSectorAssignmentBiz objBiz;
            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new EmployeeSectorAssignmentBiz(objDr);
                objBiz.EmployeeBiz = objEmployeeBiz;
                Add(objBiz);
            }

        }
        #endregion
        #region Public Properties
        public EmployeeSectorAssignmentBiz this[int intIndex]
        {
            get
            {
                return (EmployeeSectorAssignmentBiz)List[intIndex];
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add(EmployeeSectorAssignmentBiz objBiz)
        {
            string strKey = objBiz.SectorBiz.ID.ToString();
            if (_SectorTable == null)
                _SectorTable = new Hashtable();
            if (_SectorTable[strKey] == null)
            {
                _SectorTable.Add(strKey, Count);
                List.Add(objBiz);
            }
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("AssignmentID"),
                new DataColumn("AssignmentEmployeeID") ,new DataColumn("AssignmentSectorID"),
                new DataColumn("AssignmentIsPermanent",Type.GetType("System.Boolean")) ,new DataColumn("AssignmenEndDate")});
            DataRow objDr;
            foreach (EmployeeSectorAssignmentBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["AssignmentID"] = objBiz.ID;
                objDr["AssignmentEmployeeID"] = objBiz.EmployeeBiz.ID;
                objDr["AssignmentSectorID"] = objBiz.SectorBiz.ID;
                objDr["AssignmentIsPermanent"] = objBiz.IsPermanent;
                objDr["AssignmenEndDate"] = objBiz.EndDate;

                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void AssignEmployeeSector(EmployeeBiz objBiz)
        {
            DataTable dtTemp = GetTable();
            EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb();
            objDb.SectorTable = dtTemp;
            objDb.EmployeeID = objBiz.ID;
            objDb.AssignSector();
        }
        //static Hashtable _AssignedSectorTable;

        public static Hashtable AssignedSectorTable
        {

            get
            {
                //Hashtable AssignedSectorTable;

                // if (_AssignedSectorTable == null)//new System.Web.Mvc.Controller().Session["AssignedSectorTable"])
                Hashtable _AssignedSectorTable;
                if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["AssignedSectorTable"] != null) 
                {
                    _AssignedSectorTable = (Hashtable)System.Web.HttpContext.Current.Session["AssignedSectorTable"];
                }
                else
                {
                    _AssignedSectorTable = new Hashtable();
                    if (SysData.CurrentUser.EmployeeBiz.ID > 0)
                    {
                        EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb();
                        UserBiz objUser = SysData.CurrentUser;
                        objDb.EmployeeID = objUser.EmployeeBiz.ID;
                        DataTable dtTemp = objDb.GetAllAssignedSector();
                        SectorBiz objBiz;
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new SectorBiz(objDr);
                            if (_AssignedSectorTable[objBiz.ID.ToString()] == null)
                            {
                                _AssignedSectorTable.Add(objBiz.ID.ToString(), objBiz);
                            }
                        }
                        System.Web.HttpContext.Current.Session["AssignedSectorTable"] = _AssignedSectorTable;
                    }
                }
                return _AssignedSectorTable;
            }
            //set { EmployeeSectorAssignmentCol._AssignedSectorTable = value; }
        }
         
        static SectorCol _AssignedSectorCol;
        public static SectorCol AssignedSectorCol
        {
            get
            {
                if (System.Web.HttpContext.Current.Session != null && System.Web.HttpContext.Current.Session["AssignedSectorCol"] != null)
                    _AssignedSectorCol = (SectorCol)System.Web.HttpContext.Current.Session["AssignedSectorCol"];
                   else
                {
                    _AssignedSectorCol = new SectorCol(true);
                    SectorBiz objBiz;
                    foreach (object objTemp in AssignedSectorTable.Keys)
                    {
                        //objBiz = new SectorBiz(((SectorBiz)AssignedSectorTable[objTemp]).ID);
                        if(AssignedSectorTable[objTemp]!= null)
                        _AssignedSectorCol.Add((SectorBiz)AssignedSectorTable[objTemp]);
                    }
                    System.Web.HttpContext.Current.Session["AssignedSectorCol"] = _AssignedSectorCol;
                }
                return _AssignedSectorCol;

            }
        }
        public static bool CheckSectorAssigned(int intSectorID)
        {
            bool Returned = true;
            Returned = !(AssignedSectorTable[intSectorID.ToString()] == null);
            return Returned; ;
        }
        public static string GetAssignedMotivationCostCenter()
        {
            string strSectorIDs = "";
            string Returned = "";
            
            AssignmentObjectBiz objAssignment = new AssignmentObjectBiz("MotivationCostCenter");
            UserObjectAssignmentCol objCol = objAssignment.GetAllAssignedObjectCol(SysData.CurrentUser);
            Hashtable hstTemp = new Hashtable();
            if (objCol.Count > 0)
            {
                foreach (UserObjectAssignmentBiz objBiz in objCol)
                {
                    if (hstTemp[objBiz.ObjectValue.ToString()] != null)
                        continue;
                    hstTemp.Add(objBiz.ObjectValue.ToString(), objBiz.ObjectValue.ToString());
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ObjectValue.ToString();
                }
            }
                return Returned;
        }
       public static MotivationStatementBiz GetLastAssignedMotivationStatement(string  strCostCenter)
        {
            if (strCostCenter == null || strCostCenter == "")
                return new MotivationStatementBiz();
            MotivationStatementBiz Returned = new MotivationStatementBiz();
            EmployeeSectorAssignmentDb objDb = new EmployeeSectorAssignmentDb() { CostCenterIDs = strCostCenter };
            

            DataTable dtTemp = objDb.GetLastAssignedMotivationStatement();
            if (dtTemp.Rows.Count > 0)
                Returned = new MotivationStatementBiz(dtTemp.Rows[0]);
            return Returned;
        }
        #endregion
    }
}
