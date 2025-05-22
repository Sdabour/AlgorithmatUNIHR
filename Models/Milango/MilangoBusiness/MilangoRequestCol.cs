using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using AlgorithmatMVC.Milango.MilangoDb;
using System.Data;
using System.Collections;
namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class MilangoRequestCol:CollectionBase
    {

        #region Constructor
        public MilangoRequestCol()
        {

        }
        public MilangoRequestCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MilangoRequestBiz objBiz = new MilangoRequestBiz();
            
            MilangoRequestDb objDb = new MilangoRequestDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MilangoRequestBiz(objDR);
                Add(objBiz);
            }
        }
       
        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MilangoRequestBiz this[int intIndex]
        {
            get
            {
                return (MilangoRequestBiz)this.List[intIndex];
            }
        }
        public List<MilangoRequestSimple> SimpleLst
        {
            get
            {
                List<MilangoRequestSimple> Returned = this.Cast<MilangoRequestBiz>().Select(x=>x.GetSimple()).ToList();
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MilangoRequestBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MilangoRequestCol GetCol(string strTemp)
        {
            MilangoRequestCol Returned = new MilangoRequestCol(true);
            foreach (MilangoRequestBiz objBiz in this)
            {
                if (objBiz.Description.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("ProjectCode"), new DataColumn("UnitCode"), new DataColumn("SAPPartner"), new DataColumn("CategoryID"), new DataColumn("CategoryNameA"), new DataColumn("CategoryNameE"), new DataColumn("ServiceID"), new DataColumn("ServiceNameA"), new DataColumn("ServiceNameE"), new DataColumn("SubmitDate", System.Type.GetType("System.DateTime")), new DataColumn("Summary"), new DataColumn("Description"), new DataColumn("StatusCode"), new DataColumn("StatusNameA"), new DataColumn("StatusNameE"), new DataColumn("StatusNote"), new DataColumn("StatusDT", System.Type.GetType("System.DateTime")), new DataColumn("Done", System.Type.GetType("System.Boolean")) });
            DataRow objDr;
            foreach (MilangoRequestBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["ProjectCode"] = objBiz.ProjectCode;
                objDr["UnitCode"] = objBiz.UnitCode;
                objDr["SAPPartner"] = objBiz.SAPPartner;
                objDr["CategoryID"] = objBiz.CategoryID;
                objDr["CategoryNameA"] = objBiz.CategoryNameA;
                objDr["CategoryNameE"] = objBiz.CategoryNameE;
                objDr["ServiceID"] = objBiz.ServiceID;
                objDr["ServiceNameA"] = objBiz.ServiceNameA;
                objDr["ServiceNameE"] = objBiz.ServiceNameE;
                objDr["SubmitDate"] = objBiz.SubmitDate;
                objDr["Summary"] = objBiz.Summary;
                objDr["Description"] = objBiz.Description;
                objDr["StatusCode"] = objBiz.StatusCode;
                objDr["StatusNameA"] = objBiz.StatusNameA;
                objDr["StatusNameE"] = objBiz.StatusNameE;
                objDr["StatusNote"] = objBiz.StatusNote;
                objDr["StatusDT"] = objBiz.StatusDT;
                objDr["Done"] = objBiz.Done;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static MilangoRequestCol GetRequestCol(string strBp)
        {
            string[] arrStr = strBp.Split("-".ToCharArray());
            string strNewBp = "";
            int intTemp = 0;
            foreach(string strTemp in arrStr)
            {
                int.TryParse(strTemp, out intTemp);
                if (strNewBp != "")
                    strNewBp += ",";
                strNewBp += "'" + intTemp.ToString() + "'";
            }
            MilangoRequestCol Returned = new MilangoRequestCol(true);
            if(strNewBp!="")
            {
                MilangoRequestDb objDb = new MilangoRequestDb() { BpStr = strNewBp };
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                    Returned.Add(new MilangoRequestBiz(objDr));
            }
            return Returned;
        }
        #endregion
    }
}