using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Collections;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class TeacherTypeCol:CollectionBase
    {

        #region Constructor
        public TeacherTypeCol()
        {

        }
        public TeacherTypeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            TeacherTypeBiz objBiz = new TeacherTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "غير محدد";
            //objBiz.NameE = "Not Specified";
            Add(objBiz);

            TeacherTypeDb objDb = new TeacherTypeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new TeacherTypeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public TeacherTypeBiz this[int intIndex]
        {
            get
            {
                return (TeacherTypeBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(TeacherTypeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public TeacherTypeCol GetCol(string strTemp)
        {
            TeacherTypeCol Returned = new TeacherTypeCol(true);
            foreach (TeacherTypeBiz objBiz in this)
            {
                if (objBiz.NameA.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("TeacherTypeID"), new DataColumn("TeacherTypeCode"), new DataColumn("TeacherTypeNameA"), new DataColumn("TeacherTypeOrder"), new DataColumn("TeacherTypeFunctionGroup"), new DataColumn("TeacherTypeJobNatureID") });
            DataRow objDr;
            foreach (TeacherTypeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["TeacherTypeID"] = objBiz.ID;
                objDr["TeacherTypeCode"] = objBiz.Code;
                objDr["TeacherTypeNameA"] = objBiz.NameA;
                objDr["TeacherTypeOrder"] = objBiz.Order;
                objDr["TeacherTypeFunctionGroup"] = objBiz.FunctionGroup;
                objDr["TeacherTypeJobNatureID"] = objBiz.JobNatureID;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }

        #endregion
    }
}