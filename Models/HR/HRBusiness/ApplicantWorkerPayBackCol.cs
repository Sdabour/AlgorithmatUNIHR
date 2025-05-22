using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerPayBackCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerPayBackCol(bool blEmpty)
        {
        }
        public ApplicantWorkerPayBackCol(ApplicantWorkerBiz objApplicantWorkerBiz, GlobalStatementBiz objGlobalStatementBiz)
        {
            ApplicantWorkerPayBackDb objDb = new ApplicantWorkerPayBackDb();
            objDb.Applicant = objApplicantWorkerBiz.ID;
            objDb.Statement = objGlobalStatementBiz.ID;
            DataTable ObjTemp = objDb.Search();
            foreach (DataRow objDr in ObjTemp.Rows)
            {
                this.Add(new ApplicantWorkerPayBackBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual ApplicantWorkerPayBackBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerPayBackBiz)this.List[intIndex];
            }
        }

        public double TotalValue
        {
            get
            {
                double dlReturned = 0;
                foreach (ApplicantWorkerPayBackBiz objbiz in this)
                {
                    dlReturned += objbiz.Value;
                }
                return dlReturned;
            }
        }
        public string Remarks
        {
            get
            {
                string str = "";
                foreach (ApplicantWorkerPayBackBiz objbiz in this)
                {
                    if (str == "")
                        str = objbiz.Desc;
                    else
                        str += "\n" + objbiz.Desc;
                }
                return str;
            }
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerPayBackBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.PayBackID.ToString();
                }

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable(" HRApplicantWorkerPayBack");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("PayBackApplicant"), new DataColumn("PayBackValue"),
                new DataColumn("PayBackDate"),new DataColumn("PayBackDesc"), new DataColumn("PayBackStatement") 
            ,new DataColumn("PayBackID")});
            DataRow objDr;
            foreach (ApplicantWorkerPayBackBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["PayBackID"] = objBiz.PayBackID;
                objDr["PayBackApplicant"] = objBiz.ApplicantWorkerBiz.ID;
                objDr["PayBackValue"] = objBiz.Value;
                objDr["PayBackDate"] = objBiz.Date;
                objDr["PayBackDesc"] = objBiz.Desc;
                objDr["PayBackStatement"] = objBiz.StatementBiz.ID;                

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public virtual void Add(ApplicantWorkerPayBackBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(ApplicantWorkerPayBackBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].PayBackID == objBiz.PayBackID)
                    return intIndex;
            }
            return -1;
        }
        public void EditStatement(int intStatementID)
        {
            ApplicantWorkerPayBackDb objDb = new ApplicantWorkerPayBackDb();
            objDb.Statement = intStatementID;
            objDb.IDsStr = IDsStr;
            objDb.EditStatement();
        }
        #endregion
    }
}
