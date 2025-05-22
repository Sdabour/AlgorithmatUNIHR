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
using System.Linq;
namespace SharpVision.HR.HRBusiness
{
    public class SalaryBonusTypeCol : CollectionBase
    {
        public SalaryBonusTypeCol()
        {
            SalaryBonusTypeBiz objBiz;

            SalaryBonusTypeDb objDb = new SalaryBonusTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new SalaryBonusTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public SalaryBonusTypeCol(int intBonusTypeID)
        {
            SalaryBonusTypeBiz objBiz;

            SalaryBonusTypeDb objDb = new SalaryBonusTypeDb();
            objDb.IDSearch = intBonusTypeID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new SalaryBonusTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public SalaryBonusTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                SalaryBonusTypeBiz objBiz;
                objBiz = new SalaryBonusTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                SalaryBonusTypeDb objDb = new SalaryBonusTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new SalaryBonusTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual SalaryBonusTypeBiz this[int intIndex]
        {
            get
            {

                return (SalaryBonusTypeBiz)this.List[intIndex];

         }   }

        public virtual SalaryBonusTypeBiz this[string strIndex]
        {
            get
            {
                SalaryBonusTypeBiz Returned = new SalaryBonusTypeBiz();
                foreach (SalaryBonusTypeBiz objBiz in this)
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


        public virtual void Add(SalaryBonusTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(SalaryBonusTypeCol objCol)
        {
            foreach (SalaryBonusTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }
        public SalaryBonusTypeCol Copy()
        {
            SalaryBonusTypeCol Returned = new SalaryBonusTypeCol(true);
            foreach (SalaryBonusTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public static SalaryBonusTypeBiz GetSalaryBonusTypeBiz(int intID)
        {
            foreach (SalaryBonusTypeBiz objBiz in SalaryBonusTypeCol.CacheSalaryBonusTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new SalaryBonusTypeBiz();
        }

        static SalaryBonusTypeCol _CacheSalaryBonusTypeCol;
        public static SalaryBonusTypeCol CacheSalaryBonusTypeCol
        {
            set
            {
                _CacheSalaryBonusTypeCol = value;
            }
            get
            {
                if (_CacheSalaryBonusTypeCol == null)
                {
                    _CacheSalaryBonusTypeCol = new SalaryBonusTypeCol(false);
                }
                return _CacheSalaryBonusTypeCol;
            }
        }
        public SalaryBonusTypeCol GetCol(string strName)
        {
            SalaryBonusTypeCol Returned = new SalaryBonusTypeCol(true);
            IEnumerable<SalaryBonusTypeBiz> objCol = from objType in this.Cast<SalaryBonusTypeBiz>()
                                               where objType.Name.CheckStr(strName)
                                               select objType;
            foreach (SalaryBonusTypeBiz objBiz in objCol)
                Returned.Add(objBiz);
            return Returned;
        }
    }
}
