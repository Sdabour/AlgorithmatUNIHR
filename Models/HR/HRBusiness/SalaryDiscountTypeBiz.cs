using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class SalaryDiscountTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public SalaryDiscountTypeBiz()
        {
            _BaseDb = new SalaryDiscountTypeDb();
        }
        public SalaryDiscountTypeBiz(int intID)
        {
            _BaseDb = new SalaryDiscountTypeDb(intID);
        }
        public SalaryDiscountTypeBiz(DataRow objDR)
        {
            _BaseDb = new SalaryDiscountTypeDb(objDR);
        }
        public SalaryDiscountTypeBiz(SalaryDiscountTypeDb objDb)
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
            ((SalaryDiscountTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((SalaryDiscountTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((SalaryDiscountTypeDb)_BaseDb).Delete();
        }
        public SalaryDiscountTypeBiz  Copy()
        {
            SalaryDiscountTypeBiz Returned = new SalaryDiscountTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        
        #endregion
    }
}
