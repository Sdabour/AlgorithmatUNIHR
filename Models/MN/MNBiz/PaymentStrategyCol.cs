using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using AlgorithmatMN.MN.MNDb;
using System.Data;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
   public class PaymentStrategyCol:CollectionBase
    {

        #region Constructor
        public PaymentStrategyCol()
        {

        }
        public PaymentStrategyCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            PaymentStrategyBiz objBiz = new PaymentStrategyBiz();
           

            PaymentStrategyDb objDb = new PaymentStrategyDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new PaymentStrategyBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public PaymentStrategyBiz this[int intIndex]
        {
            get
            {
                return (PaymentStrategyBiz)this.List[intIndex];
            }
        }
        public string IDsStr 
        {
            get
            {
                string Returned = "";
                foreach(PaymentStrategyBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(PaymentStrategyBiz objBiz)
        {
            List.Add(objBiz);
        }
        public PaymentStrategyCol GetCol(string strTemp,CreditBiz objCreditBiz)
        {
            if (objCreditBiz == null)
                objCreditBiz = new CreditBiz();
            PaymentStrategyCol Returned = new PaymentStrategyCol(true);
            foreach (PaymentStrategyBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp)
                    && 
                    (objCreditBiz.ID == 0 || objBiz.MaxValue==objBiz.MinValue|| (objBiz.MinValue<=(-1*objCreditBiz.Closing) && objBiz.MaxValue >= (-1 * objCreditBiz.Closing))
                    )
                    &&
                    (objCreditBiz.ID==0 || objBiz.Project==""||objBiz.Project==objCreditBiz.ROBiz.ProjectCode)
                    && 
                    (objBiz.Year == 0 ||(objCreditBiz.ID==0 ||objBiz.Year == objCreditBiz.Year))
                    )
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StrategyID"), new DataColumn("StrategyDesc"), new DataColumn("StrategyYear"), new DataColumn("StrategyProject"), new DataColumn("StrategyMonthCount"), new DataColumn("StrategyDiscount"), new DataColumn("StrategyMinValue"), new DataColumn("StrategyMaxValue") });
            DataRow objDr;
            foreach (PaymentStrategyBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["StrategyID"] = objBiz.ID;
                objDr["StrategyDesc"] = objBiz.Desc;
                objDr["StrategyYear"] = objBiz.Year;
                objDr["StrategyProject"] = objBiz.Project;
                objDr["StrategyMonthCount"] = objBiz.MonthCount;
                objDr["StrategyDiscount"] = objBiz.Discount;
                objDr["StrategyMinValue"] = objBiz.MinValue;
                objDr["StrategyMaxValue"] = objBiz.MaxValue;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public void SetConditionCol()
        {
            PaymentStrategyConditionDb objDb = new PaymentStrategyConditionDb() { StrategyIDs = IDsStr };
            DataTable dtTemp = objDb.Search();
            DataRow[] arrDr;
            foreach(PaymentStrategyBiz objStrategy in this)
            {
                arrDr = dtTemp.Select("ConditionStrategy=" + objStrategy.ID.ToString(), "ConditionNo");
                foreach(DataRow objDr in arrDr)
                {
                    objStrategy.ConditionCol.Add(new PaymentStrategyConditionBiz(objDr));
                }
            }
        }
        #endregion
    }
}
