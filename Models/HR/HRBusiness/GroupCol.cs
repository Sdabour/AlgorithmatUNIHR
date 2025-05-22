using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.HR.HRDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class MSGGroupCol:CollectionBase
    {

        #region Constructor
        public MSGGroupCol()
        {

        }
        public MSGGroupCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MSGGroupBiz objBiz = new MSGGroupBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            objBiz.NameE = "Not Specified";
            Add(objBiz);

            MSGGroupDb objDb = new MSGGroupDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MSGGroupBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MSGGroupBiz this[int intIndex]
        {
            get
            {
                return (MSGGroupBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MSGGroupBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MSGGroupCol GetCol(string strTemp)
        {
            MSGGroupCol Returned = new MSGGroupCol(true);
            foreach (MSGGroupBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("GroupID"), new DataColumn("GroupCode"), new DataColumn("GroupEstablishDate", System.Type.GetType("System.DateTime")), new DataColumn("GroupNameA"), new DataColumn("GroupNameE"), new DataColumn("GroupDesc") });
            DataRow objDr;
            foreach (MSGGroupBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["GroupID"] = objBiz.ID;
                objDr["GroupCode"] = objBiz.Code;
                objDr["GroupEstablishDate"] = objBiz.EstablishDate;
                objDr["GroupNameA"] = objBiz.NameA;
                objDr["GroupNameE"] = objBiz.NameE;
                objDr["GroupDesc"] = objBiz.Desc;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}