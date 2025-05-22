using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;


namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementSalaryDetailsCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerStatementSalaryDetailsCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerStatementSalaryDetailsCol()
        {
            ApplicantWorkerStatementSalaryDetailsDb _ApplicantWorkerStatementSalaryDetailsDb = new ApplicantWorkerStatementSalaryDetailsDb();
            DataTable dtApplicantWorkerStatementSalaryDetails = _ApplicantWorkerStatementSalaryDetailsDb.Search();
            ApplicantWorkerStatementSalaryDetailsBiz objApplicantWorkerStatementSalaryDetailsBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementSalaryDetails.Rows)
            {
                objApplicantWorkerStatementSalaryDetailsBiz = new ApplicantWorkerStatementSalaryDetailsBiz(DR);
                this.Add(objApplicantWorkerStatementSalaryDetailsBiz);
            }
        }
        public ApplicantWorkerStatementSalaryDetailsCol(int intOrginStatement)
        {
            ApplicantWorkerStatementSalaryDetailsDb _ApplicantWorkerStatementSalaryDetailsDb = new ApplicantWorkerStatementSalaryDetailsDb();
            _ApplicantWorkerStatementSalaryDetailsDb.OrginStatement = intOrginStatement;
            DataTable dtApplicantWorkerStatementSalaryDetails = _ApplicantWorkerStatementSalaryDetailsDb.Search();
            ApplicantWorkerStatementSalaryDetailsBiz objApplicantWorkerStatementSalaryDetailsBiz;

            foreach (DataRow DR in dtApplicantWorkerStatementSalaryDetails.Rows)
            {
                objApplicantWorkerStatementSalaryDetailsBiz = new ApplicantWorkerStatementSalaryDetailsBiz(DR);
                this.Add(objApplicantWorkerStatementSalaryDetailsBiz);
            }
        }
        #endregion
        #region Public Properties
        public double TotalRecommendedValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementSalaryDetailsBiz objBiz in this)
                    Returned += objBiz.DetailRecomendedValue;
                return Returned;
            }
        }
        public virtual ApplicantWorkerStatementSalaryDetailsBiz this[int intIndex]
        {
            set
            {
                this.List[intIndex] = value;
            }
            get
            {
                return (ApplicantWorkerStatementSalaryDetailsBiz)this.List[intIndex];
            }
        }

        #endregion
        #region Private Methods
       
        #endregion
        #region Public Methods
       
        public virtual void Add(ApplicantWorkerStatementSalaryDetailsBiz objBiz)
        {
            int intIndex = GetIndex(objBiz);
            if (intIndex == -1) 
              this.List.Add(objBiz);



        }
        public virtual void Add(ApplicantWorkerStatementSalaryDetailsCol objCol)
        {
            foreach (ApplicantWorkerStatementSalaryDetailsBiz objBiz in objCol)
                Add(objBiz);


        }
        public int GetIndex(ApplicantWorkerStatementSalaryDetailsBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (objBiz.DetailTypeBiz.ID == this[intIndex].DetailTypeBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        public double GetSalaryDetailsRecommendedValue(int intSalaryTypeID)
        {
            double Returned = 0;
            foreach (ApplicantWorkerStatementSalaryDetailsBiz objBiz in this)
            {
                if (objBiz.DetailTypeBiz.ID == intSalaryTypeID||
                    (objBiz.DetailTypeBiz.ID != 2 && objBiz.DetailTypeBiz.ID != 3 && objBiz.DetailTypeBiz.ID != 5 && intSalaryTypeID == 4))
                    return objBiz.DetailRecomendedValue;
            }
            return Returned;
        }
        public double GetSalaryDetailsValue1(int intSalaryTypeID,bool blIsForDisplaying)
        {
            double Returned = 0;
            foreach (ApplicantWorkerStatementSalaryDetailsBiz objBiz in this)
            {
                if (objBiz.DetailTypeBiz.ID == intSalaryTypeID ||
                    (objBiz.DetailTypeBiz.ID != 2 && objBiz.DetailTypeBiz.ID != 3 && objBiz.DetailTypeBiz.ID != 5 && intSalaryTypeID == 4))
                {
                    
                    //Returned += objBiz.DetailValue == 0 && blIsForDisplaying ? objBiz.DetailRecomendedValue : objBiz.DetailValue;
                    Returned += objBiz.DetailValue  ;
                }
               

            }
            return Returned;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerStatementSalaryDetails");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("OrginStatement"), new DataColumn("DetailType"), 
                new DataColumn("DetailValue"),new DataColumn("DetailRecomendedValue"), 
                
            });
            DataRow objDr;
            foreach (ApplicantWorkerStatementSalaryDetailsBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["OrginStatement"] = objBiz.ApplicantWorkerStatementBiz.ID;
                objDr["DetailType"] = objBiz.DetailTypeBiz.ID;
                objDr["DetailValue"] = objBiz.DetailValue;
                objDr["DetailRecomendedValue"] = objBiz.DetailRecomendedValue;

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
    }
}
