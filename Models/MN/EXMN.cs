using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ROSimple { public string BE; public string RO; }
    public static class EXMN
    {
        public static DataTable GetRoTable(this List<ROSimple> lstRO)
        {
            
            DataTable dtTempRo = new DataTable();
            dtTempRo.Columns.AddRange(new DataColumn[] { new DataColumn("BE"), new DataColumn("ROCode") });
            DataRow objDr;
            foreach(ROSimple objSimple in lstRO)
            {
                objDr = dtTempRo.NewRow();
                objDr["BE"] = objSimple.BE;
                objDr["ROCode"] = objSimple.RO;
                dtTempRo.Rows.Add(objDr);
            }

            return dtTempRo;

        }
    }
}