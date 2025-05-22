using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationBonusTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public MotivationBonusTypeBiz()
        {
            _BaseDb = new MotivationBonusTypeDb();
        }
        public MotivationBonusTypeBiz(int intID)
        {
            _BaseDb = new MotivationBonusTypeDb(intID);
        }
        public MotivationBonusTypeBiz(DataRow objDR)
        {
            _BaseDb = new MotivationBonusTypeDb(objDR);
        }

        public MotivationBonusTypeBiz(MotivationBonusTypeDb objDb)
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
            ((MotivationBonusTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((MotivationBonusTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((MotivationBonusTypeDb)_BaseDb).Delete();
        }
        public MotivationBonusTypeBiz  Copy()
        {
            MotivationBonusTypeBiz Returned = new MotivationBonusTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        #endregion
    }
}
