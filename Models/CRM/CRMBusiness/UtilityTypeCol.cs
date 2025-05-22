using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.UMS.UMSBusiness;
using SharpVision.CRM.CRMDataBase;

using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.CRM.CRMBusiness
{
    public class UtilityTypeCol : BaseCol
    {
        public UtilityTypeCol(bool blIsempty)
        {

        }
        public UtilityTypeCol()
        {
            UtilityTypeDb objDb = new UtilityTypeDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UtilityTypeBiz(objDr));
            }
        }
        public UtilityTypeCol(int intID)
        {
            UtilityTypeDb objDb = new UtilityTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new UtilityTypeBiz(objDr));
            }
        }

        public UtilityTypeBiz this[int intIndex]
        {
           
            get
            {
                return (UtilityTypeBiz)List[intIndex];
            }
        }

        public void Add(UtilityTypeBiz objBiz)
        {
            List.Add(objBiz);
 
        }
    }
}