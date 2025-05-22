using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Collections;
using AlgorithmatMVC.Milango.MilangoDb;
using System.Data;
namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class MilangoCustomerCol:CollectionBase
    {

        #region Constructor
        public MilangoCustomerCol()
        {

        }
        public MilangoCustomerCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MilangoCustomerBiz objBiz = new MilangoCustomerBiz();
           

            MilangoCustomerDb objDb = new MilangoCustomerDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MilangoCustomerBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MilangoCustomerBiz this[int intIndex]
        {
            get
            {
                return (MilangoCustomerBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MilangoCustomerBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MilangoCustomerCol GetCol(string strTemp)
        {
            MilangoCustomerCol Returned = new MilangoCustomerCol(true);
            foreach (MilangoCustomerBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CustomerBp"), new DataColumn("CustomerNo"), new DataColumn("CustomerID"), new DataColumn("CustomerName"), new DataColumn("CustomerMobileNo"), new DataColumn("CustomerStatus"), new DataColumn("CustomerChanged", System.Type.GetType("System.Boolean")), new DataColumn("CustomerChangesSent", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (MilangoCustomerBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["CustomerBp"] = objBiz.Bp;
                objDr["CustomerNo"] = objBiz.No;
                objDr["CustomerID"] = objBiz.ID;
                objDr["CustomerName"] = objBiz.Name;
                objDr["CustomerMobileNo"] = objBiz.MobileNo;
                objDr["CustomerStatus"] = objBiz.Status;
                objDr["CustomerChanged"] = objBiz.Changed;
                objDr["CustomerChangesSent"] = objBiz.ChangesSent;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}