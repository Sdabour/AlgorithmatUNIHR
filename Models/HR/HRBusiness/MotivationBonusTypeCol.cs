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
    public class MotivationBonusTypeCol : CollectionBase
    {
        public MotivationBonusTypeCol()
        {
            MotivationBonusTypeBiz objBiz;

            MotivationBonusTypeDb objDb = new MotivationBonusTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new MotivationBonusTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public MotivationBonusTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                MotivationBonusTypeBiz objBiz;
                objBiz = new MotivationBonusTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                MotivationBonusTypeDb objDb = new MotivationBonusTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new MotivationBonusTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public MotivationBonusTypeCol(bool blIsEmpty,int intMotivationBonusType)
        {
            if (!blIsEmpty)
            {
                MotivationBonusTypeBiz objBiz;
                objBiz = new MotivationBonusTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                MotivationBonusTypeDb objDb = new MotivationBonusTypeDb();
                objDb.ID = intMotivationBonusType;
                DataTable dtTemp = objDb.Search();

                
                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new MotivationBonusTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual MotivationBonusTypeBiz this[int intIndex]
        {
            get
            {

                return (MotivationBonusTypeBiz)this.List[intIndex];

         }   }

        public virtual MotivationBonusTypeBiz this[string strIndex]
        {
            get
            {
                MotivationBonusTypeBiz Returned = new MotivationBonusTypeBiz();
                foreach (MotivationBonusTypeBiz objBiz in this)
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


        public virtual void Add(MotivationBonusTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(MotivationBonusTypeCol objCol)
        {
            foreach (MotivationBonusTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public MotivationBonusTypeCol Copy()
        {
            MotivationBonusTypeCol Returned = new MotivationBonusTypeCol(true);
            foreach (MotivationBonusTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static MotivationBonusTypeBiz GetMotivationBonusTypeBiz(int intID)
        {
            foreach (MotivationBonusTypeBiz objBiz in MotivationBonusTypeCol.CacheMotivationBonusTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new MotivationBonusTypeBiz();
        }

        static MotivationBonusTypeCol _CacheMotivationBonusTypeCol;
        public static MotivationBonusTypeCol CacheMotivationBonusTypeCol
        {
            set
            {
                _CacheMotivationBonusTypeCol = value;
            }
            get
            {
                if (_CacheMotivationBonusTypeCol == null)
                {
                    _CacheMotivationBonusTypeCol = new MotivationBonusTypeCol(false);
                }
                return _CacheMotivationBonusTypeCol;
            }
        }
    }
}
