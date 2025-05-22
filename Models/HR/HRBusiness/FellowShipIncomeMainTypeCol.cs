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
    public class FellowShipIncomeMainTypeCol : CollectionBase
    {
        public FellowShipIncomeMainTypeCol()
        {
            FellowShipIncomeMainTypeBiz objBiz;

            FellowShipIncomeMainTypeDb objDb = new FellowShipIncomeMainTypeDb();
            DataTable dtJob = objDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objBiz = new FellowShipIncomeMainTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public FellowShipIncomeMainTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                FellowShipIncomeMainTypeBiz objBiz;
                objBiz = new FellowShipIncomeMainTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                this.Add(objBiz);
                FellowShipIncomeMainTypeDb objDb = new FellowShipIncomeMainTypeDb();
                DataTable dtJob = objDb.Search();
                foreach (DataRow DR in dtJob.Rows)
                {
                    objBiz = new FellowShipIncomeMainTypeBiz(DR);
                    this.Add(objBiz);
                }
            }

        }
        public virtual FellowShipIncomeMainTypeBiz this[int intIndex]
        {
            get
            {
                return (FellowShipIncomeMainTypeBiz)this.List[intIndex];
            }
        }

        public virtual FellowShipIncomeMainTypeBiz this[string strIndex]
        {
            get
            {
                FellowShipIncomeMainTypeBiz Returned = new FellowShipIncomeMainTypeBiz();
                foreach (FellowShipIncomeMainTypeBiz objBiz in this)
                {
                    if (objBiz.Name == strIndex)
                    {
                        Returned = objBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }


        public virtual void Add(FellowShipIncomeMainTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }
        public virtual void Add(JobCol objCol)
        {
            foreach (FellowShipIncomeMainTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());
            }
        }

        public JobCol Copy()
        {
            JobCol Returned = new JobCol(true);
            foreach (JobBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static FellowShipIncomeMainTypeBiz GetFellowShipIncomeMainTypeBiz(int intID)
        {
            foreach (FellowShipIncomeMainTypeBiz objBiz in FellowShipIncomeMainTypeCol.CacheFellowShipIncomeMainTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new FellowShipIncomeMainTypeBiz();
        }

        static FellowShipIncomeMainTypeCol _CacheFellowShipIncomeMainTypeCol;
        public static FellowShipIncomeMainTypeCol CacheFellowShipIncomeMainTypeCol
        {
            set
            {
                _CacheFellowShipIncomeMainTypeCol = value;
            }
            get
            {
                if (_CacheFellowShipIncomeMainTypeCol == null)
                {
                    _CacheFellowShipIncomeMainTypeCol = new FellowShipIncomeMainTypeCol(false);
                }
                return _CacheFellowShipIncomeMainTypeCol;
            }
        }
    }
}
