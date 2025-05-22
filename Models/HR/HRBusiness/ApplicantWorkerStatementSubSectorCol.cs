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
    public class ApplicantWorkerStatementSubSectorCol : CollectionBase
    {
         #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerStatementSubSectorCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerStatementSubSectorCol()
        {
            ApplicantWorkerStatementSubSectorDb objDb = new ApplicantWorkerStatementSubSectorDb();
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerStatementSubSectorBiz objBiz;

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerStatementSubSectorBiz(DR);
                this.Add(objBiz);
            }
        }
        public ApplicantWorkerStatementSubSectorCol(int intOrginStatement)
        {
            ApplicantWorkerStatementSubSectorDb objDb = new ApplicantWorkerStatementSubSectorDb();
            objDb.OrginStatement = intOrginStatement;
            DataTable dtTemp = objDb.Search();
            ApplicantWorkerStatementSubSectorBiz objBiz;

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new ApplicantWorkerStatementSubSectorBiz(DR);
                this.Add(objBiz);
            }
        }
        #endregion
        #region Public Properties       
        public virtual ApplicantWorkerStatementSubSectorBiz this[int intIndex]
        {
            set
            {
                this.List[intIndex] = value;
            }
            get
            {
                return (ApplicantWorkerStatementSubSectorBiz)this.List[intIndex];
            }
        }

        #endregion
        #region Private Methods
       
        #endregion
        #region Public Methods

        public virtual void Add(ApplicantWorkerStatementSubSectorBiz objBiz)
        {
            int intIndex = GetIndex(objBiz);
            if (intIndex == -1) 
              this.List.Add(objBiz);
        }
        public virtual void Add(ApplicantWorkerStatementSubSectorCol objCol)
        {
            foreach (ApplicantWorkerStatementSubSectorBiz objBiz in objCol)
                Add(objBiz);


        }
        public int GetIndex(ApplicantWorkerStatementSubSectorBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (objBiz.SubSectorBiz.ID == this[intIndex].SubSectorBiz.ID)
                    return intIndex;
            }
            return -1;
        }       
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerStatementSubSector");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("OrginStatement"), new DataColumn("SubSector")
                
                
            });
            DataRow objDr;
            foreach (ApplicantWorkerStatementSubSectorBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["OrginStatement"] = objBiz.ApplicantWorkerStatementBiz.ID;
                objDr["SubSector"] = objBiz.SubSectorBiz.ID;               
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
    }
}
