using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class SalaryBonusTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public SalaryBonusTypeBiz()
        {
            _BaseDb = new SalaryBonusTypeDb();
        }
        public SalaryBonusTypeBiz(int intID)
        {
            _BaseDb = new SalaryBonusTypeDb(intID);
        }
        public SalaryBonusTypeBiz(DataRow objDR)
        {
            _BaseDb = new SalaryBonusTypeDb(objDR);
        }
        public SalaryBonusTypeBiz(SalaryBonusTypeDb objDb)
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
            ((SalaryBonusTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((SalaryBonusTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((SalaryBonusTypeDb)_BaseDb).Delete();
        }
        public SalaryBonusTypeBiz  Copy()
        {
            SalaryBonusTypeBiz Returned = new SalaryBonusTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }        
        #endregion
    }
}
