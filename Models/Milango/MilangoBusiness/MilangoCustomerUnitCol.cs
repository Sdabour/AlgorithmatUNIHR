using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using AlgorithmatMVC.Milango.MilangoDb;
namespace AlgorithmatMVC.Milango.MilangoBiz
{
   
    public class MilangoCustomerUnitCol:CollectionBase
    {

        #region Constructor
        public MilangoCustomerUnitCol()
        {

        }
        public MilangoCustomerUnitCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MilangoCustomerUnitBiz objBiz = new MilangoCustomerUnitBiz();
           

            MilangoCustomerUnitDb objDb = new MilangoCustomerUnitDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MilangoCustomerUnitBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MilangoCustomerUnitBiz this[int intIndex]
        {
            get
            {
                return (MilangoCustomerUnitBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MilangoCustomerUnitBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MilangoCustomerUnitCol GetCol(string strTemp)
        {
            MilangoCustomerUnitCol Returned = new MilangoCustomerUnitCol(true);
            foreach (MilangoCustomerUnitBiz objBiz in this)
            {
                
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("CustomerBp"), new DataColumn("UnitCode"), new DataColumn("UnitProjectName"), new DataColumn("UnitProjectCode"), new DataColumn("UnitStatus"), new DataColumn("UnitChanged", System.Type.GetType("System.Boolean")), new DataColumn("UnitChangesSent", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (MilangoCustomerUnitBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                //objDr["CustomerPhone"] = "";
                objDr["CustomerBp"] = objBiz.CustomerBp;
                objDr["UnitCode"] = objBiz.UnitCode;
                objDr["UnitProjectName"] = objBiz.UnitProjectName;
                objDr["UnitProjectCode"] = objBiz.UnitProjectCode;
                objDr["UnitStatus"] = objBiz.UnitStatus;
                objDr["UnitChanged"] = objBiz.UnitChanged;
                objDr["UnitChangesSent"] = objBiz.UnitChangesSent;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}