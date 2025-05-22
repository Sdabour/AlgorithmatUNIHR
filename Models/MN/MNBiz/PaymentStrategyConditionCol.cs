using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using SharpVision.SystemBase;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class PaymentStrategyConditionCol:CollectionBase
    {

        #region Constructor
        public PaymentStrategyConditionCol()
        {

        }
        public PaymentStrategyConditionCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            PaymentStrategyConditionBiz objBiz = new PaymentStrategyConditionBiz();
            

            PaymentStrategyConditionDb objDb = new PaymentStrategyConditionDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new PaymentStrategyConditionBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public PaymentStrategyConditionBiz this[int intIndex]
        {
            get
            {
                return (PaymentStrategyConditionBiz)this.List[intIndex];
            }
        }
        
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(PaymentStrategyConditionBiz objBiz)
        {
            List.Add(objBiz);
        }
        public PaymentStrategyConditionCol GetCol(string strTemp)
        {
            PaymentStrategyConditionCol Returned = new PaymentStrategyConditionCol(true);
            foreach (PaymentStrategyConditionBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ConditionStrategy"), new DataColumn("ConditionDesc"), new DataColumn("ConditionPerc"), new DataColumn("ConditionNo"), new DataColumn("ConditionMonthNo"),new DataColumn("ConditionAllowance"),new DataColumn("ConditionDiscountPerc") });
            DataRow objDr;
            int intIndex = 0;
            foreach (PaymentStrategyConditionBiz objBiz in this)
            {
                 intIndex++;
                objDr = Returned.NewRow();
                objDr["ConditionStrategy"] = objBiz.Strategy;
                objDr["ConditionDesc"] = objBiz.Desc;
                objDr["ConditionPerc"] = objBiz.Perc;
                objDr["ConditionNo"] = intIndex;
                objDr["ConditionMonthNo"] = objBiz.MonthNo;
                objDr["ConditionAllowance"] = objBiz.Allowance;
                objDr["ConditionDiscountPerc"] = objBiz.DiscountPerc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}
