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
using SharpVision.UMS.UMSBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerPenaltyCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public ApplicantWorkerPenaltyCol(bool IsEmpty)
        {
        }
        public ApplicantWorkerPenaltyCol()
        {
            ApplicantWorkerPenaltyDb _ApplicantWorkerPenaltyDb = new ApplicantWorkerPenaltyDb();
            _ApplicantWorkerPenaltyDb.SetApplicantCache = true;
            DataTable dtApplicantWorkerPenalty = _ApplicantWorkerPenaltyDb.Search();
            FillCachPenaltyPersonTable(dtApplicantWorkerPenalty);
            ApplicantWorkerPenaltyBiz objApplicantWorkerPenaltyBiz;

            foreach (DataRow DR in dtApplicantWorkerPenalty.Rows)
            {
                objApplicantWorkerPenaltyBiz = new ApplicantWorkerPenaltyBiz(DR);
                this.Add(objApplicantWorkerPenaltyBiz);
            }

        }
        public ApplicantWorkerPenaltyCol(DataRow objDR)
        {
            ApplicantWorkerPenaltyDb _ApplicantWorkerPenaltyDb = new ApplicantWorkerPenaltyDb();

            _ApplicantWorkerPenaltyDb.PenaltyApplicantID = int.Parse(objDR["PenaltyApplicantID"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyPerson = int.Parse(objDR["PenaltyPerson"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyType = int.Parse(objDR["PenaltyType"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyReason = int.Parse(objDR["PenaltyReason"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyDateFromSearch = DateTime.Parse(objDR["PenaltyDateFrom"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyDateToSearch = DateTime.Parse(objDR["PenaltyDateTo"].ToString());

            _ApplicantWorkerPenaltyDb.PenaltyDateStatusSearch = bool.Parse(objDR["PenaltyDateStatus"].ToString());


            _ApplicantWorkerPenaltyDb.PenaltyStatus = int.Parse(objDR["PenaltyStatus"].ToString());
            _ApplicantWorkerPenaltyDb.PenaltyEstimationStatement = int.Parse(objDR["PenaltyEstimationStatement"].ToString());
            _ApplicantWorkerPenaltyDb.SetApplicantCache = true;
            DataTable dtApplicantWorkerPenalty = _ApplicantWorkerPenaltyDb.Search();
            FillCachPenaltyPersonTable(dtApplicantWorkerPenalty);
            ApplicantWorkerPenaltyBiz objApplicantWorkerPenaltyBiz;

            foreach (DataRow DR in dtApplicantWorkerPenalty.Rows)
            {
                objApplicantWorkerPenaltyBiz = new ApplicantWorkerPenaltyBiz(DR);
                this.Add(objApplicantWorkerPenaltyBiz);
            }
        }
       
        public ApplicantWorkerPenaltyCol(UserBiz objUserBiz, bool blSearchDateStatus, DateTime dtFrom, DateTime dtTo)
        {
            ApplicantWorkerPenaltyDb objDb = new ApplicantWorkerPenaltyDb();

            objDb.UserIDSearch = objUserBiz.ID;           
            objDb.InsDateFromSearch = dtFrom;
            objDb.InsDateToSearch = dtTo;
            objDb.InsDateStatusSearch = blSearchDateStatus;
            objDb.SetApplicantCache = true;
            DataTable dtApplicantWorkerPenalty = objDb.Search();
            FillCachPenaltyPersonTable(dtApplicantWorkerPenalty);
            ApplicantWorkerPenaltyBiz objApplicantWorkerPenaltyBiz;

            foreach (DataRow DR in dtApplicantWorkerPenalty.Rows)
            {
                objApplicantWorkerPenaltyBiz = new ApplicantWorkerPenaltyBiz(DR);
                this.Add(objApplicantWorkerPenaltyBiz);
            }
        }
        #endregion
        #region Public Properties
        public double TotalPenaltyDiscount
        {
            get
            {
                double dbReturned = 0;
                foreach (ApplicantWorkerPenaltyBiz objBiz in this)
                {
                    dbReturned += objBiz.TotalDiscount;
                }
                return dbReturned;
            }
        }
        #endregion
        #region Private Methods
        public virtual ApplicantWorkerPenaltyBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerPenaltyBiz)this.List[intIndex];
            }
        }

        public virtual void Add(ApplicantWorkerPenaltyBiz objApplicantWorkerPenaltyBiz)
        {

            this.List.Add(objApplicantWorkerPenaltyBiz);
        }
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRApplicantWorkerPenalty");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("PenaltyID"), new DataColumn("PenaltyApplicantID"), 
                new DataColumn("PenaltyType"),new DataColumn("PenaltyReason"), new DataColumn("PenaltyPerson"),new DataColumn("PenaltyDate"),new DataColumn("PenaltyReasonDesc"),new DataColumn("PenaltyDesc") 
            ,new DataColumn("PenaltyEstimationStatement"),new DataColumn("PenaltyStatus"),new DataColumn("AttachmentID")});
            DataRow objDr;
            foreach (ApplicantWorkerPenaltyBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["PenaltyID"] = objBiz.PenaltyID;
                objDr["PenaltyApplicantID"] = objBiz.PenaltyApplicantBiz.ID;
                //objDr["PenaltyType"] = objBiz.PenaltyTypeBiz.ID;
                //objDr["PenaltyReason"] = objBiz.PenaltyReasonBiz.ID;
                objDr["PenaltyPerson"] = objBiz.PenaltyPersonBiz.ID;

                objDr["PenaltyEstimationStatement"] = objBiz.PenaltyEstimationStatement;
                objDr["PenaltyStatus"] = objBiz.PenaltyStatus;
                objDr["AttachmentID"] = objBiz.AttachmentBiz.ID;

                objDr["PenaltyDesc"] = objBiz.PenaltyDesc;
                objDr["PenaltyDate"] = objBiz.PenaltyDate;
                objDr["PenaltyReasonDesc"] = objBiz.PenaltyReasonDesc;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        static void FillCachPenaltyPersonTable(DataTable dtPenalty)
        {
            DataRow[] arrDR;
            arrDR = dtPenalty.Select("", "PenaltyPerson");
            string strTempPenaltyPerson = "";
            string strPenaltyPersonIDs = "";
            foreach (DataRow objDr in arrDR)
            {
                if (strTempPenaltyPerson != objDr["PenaltyPerson"].ToString())
                {
                    if (strPenaltyPersonIDs != "")
                        strPenaltyPersonIDs += ",";
                    strPenaltyPersonIDs += objDr["PenaltyPerson"].ToString();
                    strTempPenaltyPerson = objDr["PenaltyPerson"].ToString();
                }
            }

            ApplicantWorkerDb objApplicantWorkerDb = new ApplicantWorkerDb();
            objApplicantWorkerDb.IDs = strPenaltyPersonIDs;

            ApplicantWorkerPenaltyDb.CachPenaltyPersonTable = objApplicantWorkerDb.Search();
        }
        #endregion
        #region Public Methods
        public ApplicantWorkerPenaltyCol GetPenaltyCol(DateTime dtFrom, DateTime dtTo)
        {


            ApplicantWorkerPenaltyBiz objApplicantWorkerPenaltyBiz;
            ApplicantWorkerPenaltyCol Returned = new ApplicantWorkerPenaltyCol(true);
            foreach (ApplicantWorkerPenaltyBiz objBiz in this)
            {
                if (objBiz.PenaltyDate.Date >= dtFrom.Date && objBiz.PenaltyDate.Date <= dtTo.Date)
                {

                    Returned.Add(objBiz);
                }
            }
            return Returned;
        }
        #endregion
    }
}
