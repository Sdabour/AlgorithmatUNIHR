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
    public class FellowShipPaymentMainTypeCol : CollectionBase
    {
        public FellowShipPaymentMainTypeCol()
        {
            FellowShipPaymentMainTypeBiz objBiz;

            FellowShipPaymentMainTypeDb objDb = new FellowShipPaymentMainTypeDb();
            DataTable dtJob = objDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objBiz = new FellowShipPaymentMainTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public FellowShipPaymentMainTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                FellowShipPaymentMainTypeBiz objBiz;
                objBiz = new FellowShipPaymentMainTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                this.Add(objBiz);
                FellowShipPaymentMainTypeDb objDb = new FellowShipPaymentMainTypeDb();
                DataTable dtJob = objDb.Search();
                foreach (DataRow DR in dtJob.Rows)
                {
                    objBiz = new FellowShipPaymentMainTypeBiz(DR);
                    this.Add(objBiz);
                }
            }

        }
        public virtual FellowShipPaymentMainTypeBiz this[int intIndex]
        {
            get
            {
                return (FellowShipPaymentMainTypeBiz)this.List[intIndex];
            }
        }

        public virtual FellowShipPaymentMainTypeBiz this[string strIndex]
        {
            get
            {
                FellowShipPaymentMainTypeBiz Returned = new FellowShipPaymentMainTypeBiz();
                foreach (FellowShipPaymentMainTypeBiz objBiz in this)
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


        public virtual void Add(FellowShipPaymentMainTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }
        public virtual void Add(JobCol objCol)
        {
            foreach (FellowShipPaymentMainTypeBiz objBiz in objCol)
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
        public static FellowShipPaymentMainTypeBiz GetFellowShipPaymentMainTypeBiz(int intID)
        {
            foreach (FellowShipPaymentMainTypeBiz objBiz in FellowShipPaymentMainTypeCol.CacheFellowShipPaymentMainTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new FellowShipPaymentMainTypeBiz();
        }

        static FellowShipPaymentMainTypeCol _CacheFellowShipPaymentMainTypeCol;
        public static FellowShipPaymentMainTypeCol CacheFellowShipPaymentMainTypeCol
        {
            set
            {
                _CacheFellowShipPaymentMainTypeCol = value;
            }
            get
            {
                if (_CacheFellowShipPaymentMainTypeCol == null)
                {
                    _CacheFellowShipPaymentMainTypeCol = new FellowShipPaymentMainTypeCol(false);
                }
                return _CacheFellowShipPaymentMainTypeCol;
            }
        }
    }
}
