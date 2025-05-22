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
    public class ApplicantWorkerBonusCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerBonusCol(bool IsEmpty)
        {
            
        }
        public ApplicantWorkerBonusCol()
        {
            ApplicantWorkerBonusDb _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb();
            DataTable dtApplicantWorkerBonus = _ApplicantWorkerBonusDb.Search();
            ApplicantWorkerBonusBiz objApplicantWorkerBonusBiz;

            foreach (DataRow DR in dtApplicantWorkerBonus.Rows)
            {
                objApplicantWorkerBonusBiz = new ApplicantWorkerBonusBiz(DR);
                this.Add(objApplicantWorkerBonusBiz);
            }

        }
        public ApplicantWorkerBonusCol(int intApplicant)
        {
            ApplicantWorkerBonusDb _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb();
            _ApplicantWorkerBonusDb.BonusApplicant = intApplicant;
            DataTable dtApplicantWorkerBonus = _ApplicantWorkerBonusDb.Search();
            ApplicantWorkerBonusBiz objApplicantWorkerBonusBiz;

            foreach (DataRow DR in dtApplicantWorkerBonus.Rows)
            {
                objApplicantWorkerBonusBiz = new ApplicantWorkerBonusBiz(DR);
                this.Add(objApplicantWorkerBonusBiz);
            }

        }
        public ApplicantWorkerBonusCol(DataRow objDR)
        {
            ApplicantWorkerBonusDb _ApplicantWorkerBonusDb = new ApplicantWorkerBonusDb();
            
            
            _ApplicantWorkerBonusDb.BonusApplicant = int.Parse(objDR["BonusApplicant"].ToString());                                                
            _ApplicantWorkerBonusDb.BonusStatement = int.Parse(objDR["BonusStatement"].ToString());
            _ApplicantWorkerBonusDb.BonusDateSearch = bool.Parse(objDR["BonusDateSearch"].ToString());
            _ApplicantWorkerBonusDb.BonusDateFromSearch = DateTime.Parse(objDR["BonusDateFromSearch"].ToString());
            _ApplicantWorkerBonusDb.BonusDateToSearch = DateTime.Parse(objDR["BonusDateToSearch"].ToString());

            DataTable dtApplicantWorkerBonus = _ApplicantWorkerBonusDb.Search();
            ApplicantWorkerBonusBiz objApplicantWorkerBonusBiz;

            foreach (DataRow DR in dtApplicantWorkerBonus.Rows)
            {
                objApplicantWorkerBonusBiz = new ApplicantWorkerBonusBiz(DR);
                this.Add(objApplicantWorkerBonusBiz);
            }
        }
        #endregion
        #region Public Properties
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerBonusBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerBonusBiz objBiz in this)
                    Returned += objBiz.BonusValue;
                return Returned;
            }
        }
        public virtual ApplicantWorkerBonusBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerBonusBiz)this.List[intIndex];
            }
        }
        public double IncreaseValue
        {
            get
            {
                foreach (ApplicantWorkerBonusBiz objBiz in this)
                {
                    if (objBiz.BonusReason.IndexOf("علاو") != -1)
                    {
                        return objBiz.BonusValue;
                    }

                }
                return 0;
            }
        }
        #endregion
        #region Private Methods
    

        public virtual void Add(ApplicantWorkerBonusBiz objBiz)
        {
            if (GetIndex(objBiz) == -1)
            this.List.Add(objBiz);
        }
        public int GetIndex(ApplicantWorkerBonusBiz objBiz)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].ID == objBiz.ID)
                    return intIndex;
            }
            return -1;
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerBonus");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("BonusID"), new DataColumn("BonusApplicant"), new DataColumn("BonusValue"),new DataColumn("BonusDay"), 
                new DataColumn("BonusReason"),new DataColumn("BonusDate"), new DataColumn("BonusImage"),new DataColumn("BonusStatement"),new DataColumn("BonusDateSearch") 
            });
            DataRow objDr;
            foreach (ApplicantWorkerBonusBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["BonusID"] = objBiz.ID;
                objDr["BonusApplicant"] = objBiz.BonusApplicant;
                objDr["BonusValue"] = objBiz.BonusValue;
                objDr["BonusDay"] = objBiz.BonusDay;
                objDr["BonusReason"] = objBiz.BonusReason;
                objDr["BonusDate"] = objBiz.BonusDate;
                objDr["BonusImage"] = objBiz.BonusImage;
                objDr["BonusStatement"] = objBiz.BonusStatement;
                objDr["BonusDateSearch"] = objBiz.BonusDateSearch;

                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }

        #endregion
        #region Public Methods
        public ApplicantWorkerBonusCol GetBonusCol(DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerBonusBiz objApplicantWorkerBonusBiz;
            ApplicantWorkerBonusCol Returned = new ApplicantWorkerBonusCol(true);
            foreach (ApplicantWorkerBonusBiz objBiz in this)
            {
                if (objBiz.BonusDate.Date >= dtFrom.Date && objBiz.BonusDate.Date <= dtTo.Date)
                {
                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        public void EditStatement(int intApplicantID,int intStatement)
        {
            ApplicantWorkerBonusDb objDb = new ApplicantWorkerBonusDb();
            objDb.BonusApplicant = intApplicantID;
            objDb.IDsStr = IDsStr;
            objDb.BonusStatement = intStatement;
            objDb.EditStatement();
        }

        #endregion
    }
}
