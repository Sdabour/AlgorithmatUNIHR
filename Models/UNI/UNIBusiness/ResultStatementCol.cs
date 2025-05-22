using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatMVC.UNI.UniDataBase;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ResultStatementCol:CollectionBase
    {

        #region Constructor
        public ResultStatementCol()
        {

        }
        public ResultStatementCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            ResultStatementBiz objBiz = new ResultStatementBiz();
           

            ResultStatementDb objDb = new ResultStatementDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new ResultStatementBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public ResultStatementBiz this[int intIndex]
        {
            get
            {
                return (ResultStatementBiz)this.List[intIndex];
            }
        }

        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(ResultStatementBiz objBiz)
        {
            List.Add(objBiz);
        }
        public ResultStatementCol GetCol(string strTemp)
        {
            ResultStatementCol Returned = new ResultStatementCol(true);
            foreach (ResultStatementBiz objBiz in this)
            {
                if (objBiz.Desc.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("StatementID"), new DataColumn("StatementDesc"), new DataColumn("StatementSemester"), new DataColumn("StatementDate", System.Type.GetType("System.DateTime")), new DataColumn("StatementFaculty"), new DataColumn("StatementStatus"), new DataColumn("ResultStatementPublishDate", System.Type.GetType("System.DateTime")) });
            DataRow objDr;
            foreach (ResultStatementBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["StatementID"] = objBiz.ID;
                objDr["StatementDesc"] = objBiz.Desc;
                objDr["StatementSemester"] = objBiz.Semester;
                objDr["StatementDate"] = objBiz.Date;
                objDr["StatementFaculty"] = objBiz.Faculty;
                objDr["StatementStatus"] = objBiz.Status;
                objDr["ResultStatementPublishDate"] = objBiz.ResultPublishDate;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public ResultStatementCol Copy()
        {
            ResultStatementCol Returned = new ResultStatementCol(true);
            foreach(ResultStatementBiz objBiz in this)
            {
                Returned.Add(objBiz);
            }
           return Returned;
        }
        #endregion
    }
}