using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationDiscountTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public MotivationDiscountTypeBiz()
        {
            _BaseDb = new MotivationDiscountTypeDb();
        }
        public MotivationDiscountTypeBiz(int intID)
        {
            _BaseDb = new MotivationDiscountTypeDb(intID);
        }
        public MotivationDiscountTypeBiz(DataRow objDR)
        {
            _BaseDb = new MotivationDiscountTypeDb(objDR);
        }

        public MotivationDiscountTypeBiz(MotivationDiscountTypeDb objDb)
        {
            _BaseDb = objDb;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public  void Add()
        {
            ((MotivationDiscountTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((MotivationDiscountTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((MotivationDiscountTypeDb)_BaseDb).Delete();
        }
        public MotivationDiscountTypeBiz  Copy()
        {
            MotivationDiscountTypeBiz Returned = new MotivationDiscountTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        #endregion
    }
}
