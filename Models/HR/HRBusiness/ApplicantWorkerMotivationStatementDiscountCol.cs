using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementDiscountCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementDiscountCol(bool blIsempty)
        {

        }

        public ApplicantWorkerMotivationStatementDiscountCol(ApplicantWorkerMotivationStatementBiz objApplicantWorkerMotivationStatementBiz)
        {
            if (objApplicantWorkerMotivationStatementBiz == null || objApplicantWorkerMotivationStatementBiz.ID == 0)
                return;
            ApplicantWorkerMotivationStatementDiscountDb objDb = new ApplicantWorkerMotivationStatementDiscountDb();
            objDb.ApplicantWorkerMotivationStatement = objApplicantWorkerMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerMotivationStatementDiscountBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerMotivationStatementDiscountBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationStatementDiscountBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerMotivationStatementDiscountBiz objBiz in this)
                {
                    Returned += objBiz.DiscountValue;
                }
                return Returned;
            }
        }
        public string DescDiscount
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerMotivationStatementDiscountBiz objBiz in this)
                {
                    if (objBiz.Desc != "")
                        Returned += objBiz.Desc + "\n\r";
                }
                return Returned;
            }
        }
        public void Add(ApplicantWorkerMotivationStatementDiscountBiz objBiz)
        {
            List.Add(objBiz);
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        #endregion
    }
}
