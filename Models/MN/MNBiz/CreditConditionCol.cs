using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SharpVision.SystemBase;
using AlgorithmatMN.MN.MNDb;
using System.Collections;
namespace AlgorithmatMN.MN.MNBiz
{
    public class CreditConditionCol:CollectionBase
    {

        #region Constructor
        public CreditConditionCol()
        {

        }
        public CreditConditionCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            CreditConditionBiz objBiz = new CreditConditionBiz();
            

            CreditConditionDb objDb = new CreditConditionDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new CreditConditionBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public CreditConditionBiz this[int intIndex]
        {
            get
            {
                return (CreditConditionBiz)this.List[intIndex];
            }
        }
        public double TotalValue
        { get =>Count==0?0: this.Cast<CreditConditionBiz>().Sum(x => x.Value); }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(CreditConditionBiz objBiz)
        {
            List.Add(objBiz);
        }
        public CreditConditionCol GetCol(string strTemp)
        {
            CreditConditionCol Returned = new CreditConditionCol(true);
            foreach (CreditConditionBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ConditionID"), new DataColumn("ConditionCredit"), new DataColumn("ConditionStrategy"), new DataColumn("ConditionDesc"), new DataColumn("ConditionPerc"), new DataColumn("ConditionNo"), new DataColumn("ConditionDueDate", System.Type.GetType("System.DateTime")), new DataColumn("ConditionValue"),new DataColumn("ConditionAllowance") ,new DataColumn("ConditionDiscountPerc") });
            DataRow objDr;
            foreach (CreditConditionBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ConditionID"] = objBiz.ID;
                objDr["ConditionCredit"] = objBiz.Credit;
                objDr["ConditionStrategy"] = objBiz.Strategy;
                objDr["ConditionDesc"] = objBiz.Desc;
                objDr["ConditionPerc"] = objBiz.Perc;
                objDr["ConditionNo"] = objBiz.No;
                objDr["ConditionDueDate"] = objBiz.DueDate;
                objDr["ConditionValue"] = objBiz.Value;
                objDr["ConditionAllowance"] = objBiz.Allowance;
                objDr["ConditionDiscountPerc"] = objBiz.DiscountPerc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
