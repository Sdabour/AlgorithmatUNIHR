using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementCol : CollectionBase
    {
        #region Private Data

        #endregion
        #region Constructors
        public MotivationStatementCol(bool IsEmpty)
        {
        }
        public MotivationStatementCol()
        {
            MotivationStatementDb objDb = new MotivationStatementDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementBiz(objDr));
            }
        }
        public MotivationStatementCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementDb objDb = new MotivationStatementDb();
            objDb.ID = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementBiz(objDr));
            }
        }
        public MotivationStatementCol(byte byIncludeStatus, MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementDb objDb = new MotivationStatementDb();
            objDb.IDIncludeStatus = byIncludeStatus;
            objDb.IDIncludeSearch = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public virtual MotivationStatementBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementBiz objBiz)
        {
           
            this.List.Add(objBiz);
        }
        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (MotivationStatementBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.ID.ToString();
                }
                return Returned;
            }
        }
        MotivationStatementCostCenterCol _CostCenterCol;
        static CostCenterTypeBiz _CostCenterTypeBiz;
        public static CostCenterTypeBiz CostCenterTypeBiz
        {
            set
            {
                _CostCenterTypeBiz = value;
            }
            get
            {
                return _CostCenterTypeBiz;
            }
        }
        public MotivationStatementCostCenterCol CostCenterCol
        {
            set
            {
                _CostCenterCol = value;
            }
            get
            {
                if (_CostCenterCol == null)
                {
                    _CostCenterCol = new MotivationStatementCostCenterCol(this, _CostCenterTypeBiz);
                }
                return _CostCenterCol;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static MotivationStatementBiz GetLastMotivationStatementBiz()
        {
            MotivationStatementCol objCol = new MotivationStatementCol();
            if (objCol == null || objCol.Count == 0)
                return null;
            else
                return objCol[objCol.Count - 1];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDesc">Part of The Desc</param>
        /// <param name="intIsAddedBonus">0 dont care,1 is AddedBonus,2 is motivation</param>
        /// <returns></returns>
        public MotivationStatementCol GetCol(string strDesc,int intIsAddedBonus)
        {
            MotivationStatementCol Returned = new MotivationStatementCol(true);
            IEnumerable<MotivationStatementBiz> objCol = from objBiz in this.Cast<MotivationStatementBiz>()
                                                         where objBiz.Desc.CheckStr(strDesc) &&
                                                         (intIsAddedBonus == 0 ||
                                                         (intIsAddedBonus == 1 && objBiz.IsAddedBonus) ||
                                                         (intIsAddedBonus == 2 && !objBiz.IsAddedBonus))
                                                         select objBiz;
            foreach (MotivationStatementBiz objBiz in objCol)
                Returned.Add(objBiz);


            return Returned;
        }
        #endregion
    }
}
