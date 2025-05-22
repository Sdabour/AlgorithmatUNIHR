using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseBusiness;
using SharpVision.CRM.CRMDataBase;
using SharpVision.SystemBase;

namespace SharpVision.CRM.CRMBusiness
{
    public class UnitTypeCol : BaseCol
    {
        public UnitTypeCol(bool blIsEmpty)
        {
            if (blIsEmpty)
                return;
            UnitTypeDb objDb = new UnitTypeDb();
            
            DataTable dtTemp = objDb.Search();
            UnitTypeBiz objBiz =  new UnitTypeBiz();
            objBiz.ID = 0;
            objBiz.NameA = "€Ì— „Õœœ";
            Add(objBiz);
            foreach (DataRow objDR in dtTemp.Rows)
            {
                //objBiz = new UnitTypeBiz(objDR);
                //this.Add(objBiz);
                Add(new UnitTypeBiz(objDR));
            }

        }
        public UnitTypeCol()
        {
            UnitTypeDb objDb = new UnitTypeDb();

            DataTable dtTemp = objDb.Search();
            UnitTypeBiz objBiz = new UnitTypeBiz();
            foreach (DataRow objDR in dtTemp.Rows)
            {
                Add(new UnitTypeBiz(objDR));
            }

        }
        public UnitTypeCol(int intID)
        {
            UnitTypeDb objDb = new UnitTypeDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            UnitTypeBiz objBiz;

            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new UnitTypeBiz(objDR);
                this.Add(objBiz);
            }

        }

        public virtual UnitTypeBiz this[int intIndex]
        {
            get
            {
                return (UnitTypeBiz)this.List[intIndex];
            }
        }

        public virtual void Add(UnitTypeBiz objBiz)
        {

            this.List.Add(objBiz);
        }
    }
}
