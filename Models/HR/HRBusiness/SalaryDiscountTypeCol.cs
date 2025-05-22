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
    public class SalaryDiscountTypeCol : CollectionBase
    {
        public SalaryDiscountTypeCol()
        {
            SalaryDiscountTypeBiz objBiz;

            SalaryDiscountTypeDb objDb = new SalaryDiscountTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new SalaryDiscountTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public SalaryDiscountTypeCol(int intDiscountTypeID)
        {
            SalaryDiscountTypeBiz objBiz;

            SalaryDiscountTypeDb objDb = new SalaryDiscountTypeDb();
            objDb.IDSearch = intDiscountTypeID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new SalaryDiscountTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public SalaryDiscountTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SalaryDiscountTypeBiz objBiz;
                objBiz = new SalaryDiscountTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                SalaryDiscountTypeDb objDb = new SalaryDiscountTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new SalaryDiscountTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual SalaryDiscountTypeBiz this[int intIndex]
        {
            get
            {

                return (SalaryDiscountTypeBiz)this.List[intIndex];

         }   }

        public virtual SalaryDiscountTypeBiz this[string strIndex]
        {
            get
            {
                SalaryDiscountTypeBiz Returned = new SalaryDiscountTypeBiz();
                foreach (SalaryDiscountTypeBiz objBiz in this)
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


        public virtual void Add(SalaryDiscountTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(SalaryDiscountTypeCol objCol)
        {
            foreach (SalaryDiscountTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }
        public SalaryDiscountTypeCol Copy()
        {
            SalaryDiscountTypeCol Returned = new SalaryDiscountTypeCol(true);
            foreach (SalaryDiscountTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static SalaryDiscountTypeBiz GetSalaryDiscountTypeBiz(int intID)
        {
            foreach (SalaryDiscountTypeBiz objBiz in SalaryDiscountTypeCol.CacheSalaryDiscountTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new SalaryDiscountTypeBiz();
        }

        static SalaryDiscountTypeCol _CacheSalaryDiscountTypeCol;
        public static SalaryDiscountTypeCol CacheSalaryDiscountTypeCol
        {
            set
            {
                _CacheSalaryDiscountTypeCol = value;
            }
            get
            {
                if (_CacheSalaryDiscountTypeCol == null)
                {
                    _CacheSalaryDiscountTypeCol = new SalaryDiscountTypeCol(false);
                }
                return _CacheSalaryDiscountTypeCol;
            }
        }
    }
}
