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
    public class ApplicantWorkerStatementBonusCol : BaseCol
    {
        public ApplicantWorkerStatementBonusCol(bool blIsempty)
        {

        }

        public ApplicantWorkerStatementBonusCol(int intID)
        {
            ApplicantWorkerStatementBonusDb objDb = new ApplicantWorkerStatementBonusDb();
            objDb.OriginStatement = intID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                Add(new ApplicantWorkerStatementBonusBiz(objDr));
            }
        }

        public ApplicantWorkerStatementBonusBiz this[int intIndex]
        {

            get
            {
                return (ApplicantWorkerStatementBonusBiz)List[intIndex];
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
                    Returned += objBiz.Value;
                return Returned;
            }
        }
        public double BonusHourValue
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
                {

                    Returned +=0;
                }
                return Returned;
            }
        }
        public double BonusDayCount
        {
            get
            {
                double Returned = 0;
                foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
                {

                    Returned += objBiz.DayCount;
                }
                return Returned;
            }
        }
        public string DescBonus
        {
            get
            {
                string Returned = "";
                foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
                {
                    if(objBiz.Desc!="")
                    Returned += objBiz.Desc + "\n\r";
                }
                return Returned;
            }
        }
        public double IncreaseValue
        {
            get
            {
                foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
                {
                    if (objBiz.Desc.IndexOf("ÚáÇæ") != -1)
                    {
                        return objBiz.Value;
                    }

                }
                return 0;
            }
        }
        public void Add(ApplicantWorkerStatementBonusBiz objBiz)
        {
            List.Add(objBiz);

        }
        public int GetIndex(string strDesc)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].Desc == strDesc)
                    return intIndex;
            }
            return -1;
        }
        public DataTable GetTable()
        {
            return GetTable("Bonus");
        }
        public DataTable GetTable(string strTableName)
        {
            DataTable Returned = new DataTable(strTableName);
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("OriginStatement"),new DataColumn("BonusDesc")
                ,new DataColumn("BonusValue"),new DataColumn("BonusDate"),new DataColumn("BonusType")
                ,new DataColumn("BonusID"),new DataColumn("BonusDayCount"),
                new DataColumn("BonusDayReferenceCount"),new DataColumn("BonusHourCount")
                ,new DataColumn("BonusHourRefrenceCount")});
            DataRow objDr;
            foreach (ApplicantWorkerStatementBonusBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["OriginStatement"] = objBiz.OriginStatement;
                objDr["BonusDesc"] = objBiz.Desc;
                objDr["BonusValue"] = objBiz.Value;
                objDr["BonusDate"] = objBiz.Date;
                objDr["BonusType"] = objBiz.BonusTypeBiz.ID;
                objDr["BonusID"] = objBiz.BonusID;
                objDr["BonusDayCount"] = objBiz.DayCount;
                objDr["BonusDayReferenceCount"] = objBiz.DayReferenceCount;
                objDr["BonusHourCount"] = objBiz.HourCount;
                objDr["BonusHourRefrenceCount"] = objBiz.HourRefrenceCount;
                Returned.Rows.Add(objDr);
            }
            return Returned;

        }
    }
}
