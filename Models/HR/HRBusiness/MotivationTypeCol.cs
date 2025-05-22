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
    public class MotivationTypeCol : CollectionBase
    {
        public MotivationTypeCol()
        {
            MotivationTypeBiz objBiz;

            MotivationTypeDb objDb = new MotivationTypeDb();
            DataTable dtTemp = objDb.Search();
            

            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new MotivationTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public MotivationTypeCol(int intMotivationTypeID)
        {
            MotivationTypeBiz objBiz;

            MotivationTypeDb objDb = new MotivationTypeDb();
            objDb.IDSearch = intMotivationTypeID;
            DataTable dtTemp = objDb.Search();


            foreach (DataRow DR in dtTemp.Rows)
            {
                objBiz = new MotivationTypeBiz(DR);

                this.Add(objBiz);
            }

        }
        public MotivationTypeCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                MotivationTypeBiz objBiz;
                objBiz = new MotivationTypeBiz();
                objBiz.ID = 0;
                objBiz.NameA = "غير محدد";
                this.Add(objBiz);
                MotivationTypeDb objDb = new MotivationTypeDb();
                DataTable dtTemp = objDb.Search();


                foreach (DataRow DR in dtTemp.Rows)
                {
                    objBiz = new MotivationTypeBiz(DR);

                    this.Add(objBiz);
                }
            }

        }
        public virtual MotivationTypeBiz this[int intIndex]
        {
            get
            {

                return (MotivationTypeBiz)this.List[intIndex];

         }   }

        public virtual MotivationTypeBiz this[string strIndex]
        {
            get
            {
                MotivationTypeBiz Returned = new MotivationTypeBiz();
                foreach (MotivationTypeBiz objBiz in this)
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


        public virtual void Add(MotivationTypeBiz objBiz)
        {
            if (this[objBiz.Name].Name == null || this[objBiz.Name].Name == "")
            {
                this.List.Add(objBiz.Copy());
            }

        }


        public virtual void Add(MotivationTypeCol objCol)
        {
            foreach (MotivationTypeBiz objBiz in objCol)
            {
                if (this[objBiz.Name].ID == 0)
                    this.List.Add(objBiz.Copy());

            }
        }

        public MotivationTypeCol Copy()
        {
            MotivationTypeCol Returned = new MotivationTypeCol(true);
            foreach (MotivationTypeBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }
        public string IDs
        {
            get
            {
                string strReturn = "";
                foreach (MotivationTypeBiz objBiz in this)
                {
                    if (strReturn != "")
                        strReturn += "," + objBiz.ID.ToString();
                    else
                        strReturn += objBiz.ID.ToString();
                }
                return strReturn;
            }
        }

        public static MotivationTypeBiz GetMotivationTypeBiz(int intID)
        {
            foreach (MotivationTypeBiz objBiz in MotivationTypeCol.CacheMotivationTypeCol)
            {
                if (objBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new MotivationTypeBiz();
        }

        static MotivationTypeCol _CacheMotivationTypeCol;
        public static MotivationTypeCol CacheMotivationTypeCol
        {
            set
            {
                _CacheMotivationTypeCol = value;
            }
            get
            {
                if (_CacheMotivationTypeCol == null)
                {
                    _CacheMotivationTypeCol = new MotivationTypeCol(false);
                }
                return _CacheMotivationTypeCol;
            }
        }
    }
}
