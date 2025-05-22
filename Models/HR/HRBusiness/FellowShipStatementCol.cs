using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class FellowShipStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public FellowShipStatementCol()
        {
            FellowShipStatementDb objDb = new FellowShipStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new FellowShipStatementBiz(objDr));
            }
        }
        public FellowShipStatementCol(bool isEmpty)
        {
        }
        public FellowShipStatementCol(string strIDs)
        {
            FellowShipStatementDb objDb = new FellowShipStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new FellowShipStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public string IDs
        {
            get
            {
                string str = "";
                foreach (FellowShipStatementBiz objBiz in this)
                {
                    if (str != "")
                        str += "," + objBiz.ID.ToString();
                    else
                        str = objBiz.ID.ToString();
                }
                return str;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public virtual FellowShipStatementBiz this[int intIndex]
        {
            get
            {
                return (FellowShipStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(FellowShipStatementBiz objBiz)
        {
            this.List.Add(objBiz);
        }

        public static FellowShipStatementBiz GetLastFellowShipStatementBiz()
        {
            FellowShipStatementCol objCol = new FellowShipStatementCol();
            if (objCol == null || objCol.Count == 0)
                return null;
            else
                return objCol[0];
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (FellowShipStatementBiz objBiz in this)
            {
                if (objBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        #endregion
    }
}
