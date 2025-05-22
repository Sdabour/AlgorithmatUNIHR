using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementDiscountCol : BaseCol
    {
        public ApplicantWorkerStatementDiscountCol(bool blIsempty)
        {

        }

        public ApplicantWorkerStatementDiscountCol(int intID)
        {
            ApplicantWorkerStatementDiscountDb objDb = new ApplicantWorkerStatementDiscountDb();
            objDb.OriginStatement = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerStatementDiscountBiz(objDr));
            }
        }

        public ApplicantWorkerStatementDiscountBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerStatementDiscountBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public string DescDiscount
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerStatementDiscountBiz objBiz in this)
                    if (objBiz.Desc != "")
                        Returned += objBiz.Desc + "\n\r";
                return Returned;
            }
        }
        public void Add(ApplicantWorkerStatementDiscountBiz objBiz)
        {
            List.Add(objBiz);

        }
        public DataTable GetTable()
        {
            return GetTable("Discount");
        }
        public DataTable GetTable(string strTableName)
        {
            DataTable Returned = new DataTable(strTableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("OriginStatement"),new DataColumn("DiscountDesc")
                ,new DataColumn("DiscountValue"),new DataColumn("DiscountDate"),new DataColumn("DiscountType"),new DataColumn("DiscountID")});
            DataRow objDr;
            foreach (ApplicantWorkerStatementDiscountBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["OriginStatement"] = objBiz.OriginStatement;
                objDr["DiscountDesc"] = objBiz.Desc;
                objDr["DiscountValue"] = objBiz.Value;
                objDr["DiscountDate"] = objBiz.Date;
                objDr["DiscountType"] = objBiz.DiscountTypeBiz.ID;
                objDr["DiscountID"] = objBiz.DiscountID;
                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
    }
}
