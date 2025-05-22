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
    public class FellowShipPaymentTypeCol : CollectionBase
    {
        public FellowShipPaymentTypeCol()
        {
            FellowShipPaymentTypeBiz objBiz;

            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            DataTable dtJob = objDb.Search();
            

            foreach (DataRow DR in dtJob.Rows)
            {
                objBiz = new FellowShipPaymentTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public FellowShipPaymentTypeCol(FellowShipPaymentMainTypeBiz objFellowShipPaymentMainTypeBiz)
        {
            FellowShipPaymentTypeBiz objBiz;
            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            objDb.FellowShipPaymentMainType = objFellowShipPaymentMainTypeBiz.ID;
            DataTable dtJob = objDb.Search();
            foreach (DataRow DR in dtJob.Rows)
            {
                objBiz = new FellowShipPaymentTypeBiz(DR);
                this.Add(objBiz);
            }
        }
        public FellowShipPaymentTypeCol(FellowShipPaymentMainTypeBiz objFellowShipPaymentMainTypeBiz, bool blIsEmpty)
        {
            FellowShipPaymentTypeBiz objBiz;
            if (!blIsEmpty)
            {
                objBiz = new FellowShipPaymentTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                this.Add(objBiz);
            }
            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            objDb.FellowShipPaymentMainType = objFellowShipPaymentMainTypeBiz.ID;
            DataTable dtJob = objDb.Search();
            foreach (DataRow DR in dtJob.Rows)
            {
                objBiz = new FellowShipPaymentTypeBiz(DR);
                this.Add(objBiz);
            }
        }
        public FellowShipPaymentTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                FellowShipPaymentTypeBiz objBiz;
                objBiz = new FellowShipPaymentTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "€Ì— „Õœœ";
                this.Add(objBiz);
                FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
                DataTable dtJob = objDb.Search();
                foreach (DataRow DR in dtJob.Rows)
                {
                    objBiz = new FellowShipPaymentTypeBiz(DR);
                    this.Add(objBiz);
                }
            }

        }
        public virtual FellowShipPaymentTypeBiz this[int intIndex]
        {
            get
            {
                return (FellowShipPaymentTypeBiz)this.List[intIndex];
            }
        }

        public virtual FellowShipPaymentTypeBiz this[string strIndex]
        {
            get
            {
                FellowShipPaymentTypeBiz Returned = new FellowShipPaymentTypeBiz();
                foreach (FellowShipPaymentTypeBiz objBiz in this)
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


        public virtual void Add(FellowShipPaymentTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }
        public virtual void Add(JobCol objCol)
        {
            foreach (FellowShipPaymentTypeBiz objBiz in objCol)
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
        public static FellowShipPaymentTypeBiz GetFellowShipPaymentTypeBiz(int intID)
        {
            foreach (FellowShipPaymentTypeBiz objBiz in FellowShipPaymentTypeCol.CacheFellowShipPaymentTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new FellowShipPaymentTypeBiz();
        }

        static FellowShipPaymentTypeCol _CacheFellowShipPaymentTypeCol;
        public static FellowShipPaymentTypeCol CacheFellowShipPaymentTypeCol
        {
            set
            {
                _CacheFellowShipPaymentTypeCol = value;
            }
            get
            {
                if (_CacheFellowShipPaymentTypeCol == null)
                {
                    _CacheFellowShipPaymentTypeCol = new FellowShipPaymentTypeCol(false);
                }
                return _CacheFellowShipPaymentTypeCol;
            }
        }
    }
}
