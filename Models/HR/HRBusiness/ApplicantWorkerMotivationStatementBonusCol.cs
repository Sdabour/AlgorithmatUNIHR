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
    public class ApplicantWorkerMotivationStatementBonusCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementBonusCol(bool blIsempty)
        {

        }

        public ApplicantWorkerMotivationStatementBonusCol(ApplicantWorkerMotivationStatementBiz objApplicantWorkerMotivationStatementBiz)
        {
            if (objApplicantWorkerMotivationStatementBiz == null || objApplicantWorkerMotivationStatementBiz.ID == 0)
                return;
            ApplicantWorkerMotivationStatementBonusDb objDb = new ApplicantWorkerMotivationStatementBonusDb();
            objDb.ApplicantWorkerMotivationStatement = objApplicantWorkerMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerMotivationStatementBonusBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerMotivationStatementBonusBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationStatementBonusBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerMotivationStatementBonusBiz objBiz in this)
                {
                    Returned += objBiz.BonusValue;
                }
                return Returned;
            }
        }
        public string DescBonus
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerMotivationStatementBonusBiz objBiz in this)
                {
                    if (objBiz.Desc != "")
                        Returned += objBiz.Desc + "\n\r";
                }
                return Returned;
            }
        }
        public void Add(ApplicantWorkerMotivationStatementBonusBiz objBiz)
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
