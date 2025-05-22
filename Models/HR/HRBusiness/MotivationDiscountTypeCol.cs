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
    public class MotivationDiscountTypeCol : CollectionBase
    {
        public MotivationDiscountTypeCol()
        {
            MotivationDiscountTypeBiz objBiz;

            MotivationDiscountTypeDb objDb = new MotivationDiscountTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new MotivationDiscountTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public MotivationDiscountTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                MotivationDiscountTypeBiz objBiz;
                objBiz = new MotivationDiscountTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                MotivationDiscountTypeDb objDb = new MotivationDiscountTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new MotivationDiscountTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public MotivationDiscountTypeCol(bool blIsEmpty,int intMotivationDiscountType)
        {
            if (!blIsEmpty)
            {
                MotivationDiscountTypeBiz objBiz;
                objBiz = new MotivationDiscountTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                MotivationDiscountTypeDb objDb = new MotivationDiscountTypeDb();
                objDb.ID = intMotivationDiscountType;
                DataTable dtTemp = objDb.Search();

                
                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new MotivationDiscountTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual MotivationDiscountTypeBiz this[int intIndex]
        {
            get
            {

                return (MotivationDiscountTypeBiz)this.List[intIndex];

         }   }

        public virtual MotivationDiscountTypeBiz this[string strIndex]
        {
            get
            {
                MotivationDiscountTypeBiz Returned = new MotivationDiscountTypeBiz();
                foreach (MotivationDiscountTypeBiz objBiz in this)
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


        public virtual void Add(MotivationDiscountTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(MotivationDiscountTypeCol objCol)
        {
            foreach (MotivationDiscountTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public MotivationDiscountTypeCol Copy()
        {
            MotivationDiscountTypeCol Returned = new MotivationDiscountTypeCol(true);
            foreach (MotivationDiscountTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static MotivationDiscountTypeBiz GetMotivationDiscountTypeBiz(int intID)
        {
            foreach (MotivationDiscountTypeBiz objBiz in MotivationDiscountTypeCol.CacheMotivationDiscountTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new MotivationDiscountTypeBiz();
        }

        static MotivationDiscountTypeCol _CacheMotivationDiscountTypeCol;
        public static MotivationDiscountTypeCol CacheMotivationDiscountTypeCol
        {
            set
            {
                _CacheMotivationDiscountTypeCol = value;
            }
            get
            {
                if (_CacheMotivationDiscountTypeCol == null)
                {
                    _CacheMotivationDiscountTypeCol = new MotivationDiscountTypeCol(false);
                }
                return _CacheMotivationDiscountTypeCol;
            }
        }
    }
}
