using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;
using SharpVision.SAP.SAPDataBase;
using SharpVision.Base.BaseBusiness;
using AlgorithmatMN.MN.MNBiz;
namespace SharpVision.SAP.SAPBuisness
{
   
    public class SAPCustomerContactCol:CollectionBase
    {

        #region Constructor
        public SAPCustomerContactCol(string strPhone)
        {
            SAPCustomerContactDb objDb = new SAPCustomerContactDb() { PhoneNo = strPhone };
            {
                //DataTable dtTemp1 = objDb.GetQuery();
            }
            DataTable dtTemp = objDb.Search();
            if (dtTemp != null)
            {
                if (dtTemp.Rows.Count > 0)
                {
                    dtTemp = dtTemp.Select().Distinct().CopyToDataTable();
                 
                    string strKey = "";
                    SAPCustomerContactBiz objBiz = new SAPCustomerContactBiz();
                    Hashtable hsTemp = new Hashtable();

                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objBiz = new SAPCustomerContactBiz(objDr);
                        strKey = objBiz.PARTNER + "-" + objBiz.ContractNo;
                        if (hsTemp[strKey] == null)
                        {
                            hsTemp.Add(strKey, "");
                            Add(objBiz);
                        }
                    }
                }
            }
        }

        public SAPCustomerContactCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
         
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public SAPCustomerContactBiz this[int intIndex]
        {
            get
            {
                return (SAPCustomerContactBiz)this.List[intIndex];
            }
        }
        public string BPStr
        {
            get
            {
                string Returned = "";
                Hashtable hsTemp = new Hashtable();
                foreach(SAPCustomerContactBiz objBiz in this)
                {
                    if (hsTemp[objBiz.PARTNER] != null)
                        continue;
                    hsTemp.Add(objBiz.PARTNER, objBiz.PARTNER);
                    if (Returned != "")
                        Returned += "-";
                    Returned += objBiz.PARTNER;
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(SAPCustomerContactBiz objBiz)
        {
            List.Add(objBiz);
        }
        public SAPCustomerContactCol GetCol(string strTemp)
        {
            SAPCustomerContactCol Returned = new SAPCustomerContactCol(true);
            foreach (SAPCustomerContactBiz objBiz in this)
            {
                if (objBiz.CustomerFullName.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("PARTNER"), new DataColumn("CustomerFullName"), new DataColumn("PERSNUMBER"), new DataColumn("CUSTOMER"), new DataColumn("IDNUMBER"), new DataColumn("PhoneNo"), new DataColumn("BE"), new DataColumn("ROCode"), new DataColumn("ContractNo") });
            DataRow objDr;
            foreach (SAPCustomerContactBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["PARTNER"] = objBiz.PARTNER;
                objDr["CustomerFullName"] = objBiz.CustomerFullName;
                objDr["PERSNUMBER"] = objBiz.PERSNUMBER;
                objDr["CUSTOMER"] = objBiz.CUSTOMER;
                objDr["IDNUMBER"] = objBiz.IDNUMBER;
                objDr["PhoneNo"] = objBiz.PhoneNo;
                objDr["BE"] = objBiz.BE;
                objDr["ROCode"] = objBiz.ROCode;
                objDr["ContractNo"] = objBiz.ContractNo;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static List<ROSimple> GetUnitLst(string strUserID)
        {
            List<ROSimple> Returned = new List<ROSimple>();
            SAPCustomerContactDb objDb = new SAPCustomerContactDb() { UserIDStr = strUserID };
            {
                //DataTable dtTemp1 = objDb.GetQuery();
            }
            int intTemp = 0;
            DataTable dtTemp = objDb.GetUserRO();
            if (dtTemp != null)
            {
                if (dtTemp.Rows.Count > 0)
                {
                    dtTemp = dtTemp.Select().Distinct().CopyToDataTable();

                    string strKey = "";
                    SAPCustomerContactBiz objBiz = new SAPCustomerContactBiz();
                    Hashtable hsTemp = new Hashtable();

                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        objBiz = new SAPCustomerContactBiz(objDr);
                        strKey = objBiz.BE + "-" + objBiz.ROCode;
                        if (hsTemp[strKey] == null)
                        {
                            hsTemp.Add(strKey, "");
                            Returned.Add(new ROSimple() { BE = objBiz.BE, RO = objBiz.ROCode });
                        }
                    }
                }
            }
            return Returned;
        }
        #endregion
    }
}