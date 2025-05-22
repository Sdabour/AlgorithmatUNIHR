using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMN.MN.MNDb;
using System.Collections;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class TempSchedulingCol:CollectionBase
    {

        #region Constructor
        public TempSchedulingCol()
        {

        }
        public TempSchedulingCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TempSchedulingBiz objBiz = new TempSchedulingBiz();
    
            TempSchedulingDb objDb = new TempSchedulingDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TempSchedulingBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TempSchedulingBiz this[int intIndex]
        {
            get
            {
                return (TempSchedulingBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TempSchedulingBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TempSchedulingCol GetCol(string strTemp)
        {
            TempSchedulingCol Returned = new TempSchedulingCol(true);
            foreach (TempSchedulingBiz objBiz in this)
            {
              
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("SchedulingID"), new DataColumn("SchedulingRO"), new DataColumn("SchedulingStrategy"), new DataColumn("SchedulingCredit"), new DataColumn("SchedulingAdvancedValue"), new DataColumn("SchedulingStartDate", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (TempSchedulingBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["SchedulingID"] = objBiz.ID;
                objDr["SchedulingRO"] = objBiz.RO;
                objDr["SchedulingStrategy"] = objBiz.Strategy;
                objDr["SchedulingCredit"] = objBiz.Credit;
                objDr["SchedulingAdvancedValue"] = objBiz.AdvancedValue;
                objDr["SchedulingStartDate"] = objBiz.StartDate;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}