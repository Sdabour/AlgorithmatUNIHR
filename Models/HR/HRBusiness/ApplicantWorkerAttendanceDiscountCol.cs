using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerAttendanceDiscountCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerAttendanceDiscountCol(bool IsEmpty)
        { 
        }
        public ApplicantWorkerAttendanceDiscountCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            ApplicantWorkerAttendanceDiscountDb _ApplicantWorkerAttendanceDiscountDb = new ApplicantWorkerAttendanceDiscountDb();
            _ApplicantWorkerAttendanceDiscountDb.Applicant = objApplicantWorkerBiz.ID;
            DataTable dtApplicantWorkerAttendanceDiscount = _ApplicantWorkerAttendanceDiscountDb.Search();
            ApplicantWorkerAttendanceDiscountBiz objApplicantWorkerAttendanceDiscountBiz;
            foreach (DataRow DR in dtApplicantWorkerAttendanceDiscount.Rows)
            {
                objApplicantWorkerAttendanceDiscountBiz = new ApplicantWorkerAttendanceDiscountBiz(DR);
                this.Add(objApplicantWorkerAttendanceDiscountBiz);
            }
        }               
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerAttendanceDiscountBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID;
                }
                return Returned;
            }
        }
        public double TotalAppliedValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerAttendanceDiscountBiz objBiz in this)
                {
                    Returned += objBiz.AppliedValue;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerAttendanceDiscountBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerAttendanceDiscountBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerAttendanceDiscountBiz objApplicantWorkerAttendanceDiscountBiz)
        {           
              this.List.Add(objApplicantWorkerAttendanceDiscountBiz);
        }
               
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerAttendanceDiscount");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DisocuntID"), new DataColumn("DiscountApplicant"), 
                new DataColumn("DiscountAttendanceStatment"),new DataColumn("DiscountFinancialStatement"),new DataColumn("DiscountValue")
            ,new DataColumn("DiscountDesc"),new DataColumn("DiscountAttendanceDayCount"),new DataColumn("DiscountAppliedValue")
            ,new DataColumn("DiscountAppliedValueUsr")});
            DataRow objDr;
            foreach (ApplicantWorkerAttendanceDiscountBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["DisocuntID"] = objBiz.ID;
                objDr["DiscountApplicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["DiscountAttendanceStatment"] = objBiz.ApplicantAttendanceStatementBiz.ID;
                objDr["DiscountFinancialStatement"] = objBiz.FinancialStatement;
                objDr["DiscountValue"] = objBiz.Value;
                objDr["DiscountAttendanceDayCount"] = objBiz.DayCount;
                objDr["DiscountAppliedValue"] = objBiz.AppliedValue;
                objDr["DiscountAppliedValueUsr"] = objBiz.AppliedValueUsr;
                objDr["DiscountDesc"] = objBiz.Desc;


                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods       
        public void EditStatement(int intStatementID)
        {
            ApplicantWorkerAttendanceDiscountDb objDb = 
                new ApplicantWorkerAttendanceDiscountDb();
            objDb.FinancialStatement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditFinancialStatement();
            
        }
        #endregion
    }
}
