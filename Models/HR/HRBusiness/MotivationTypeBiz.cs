using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationTypeBiz : BaseSingleBiz
    {
        #region Private Data

        #endregion
        #region Constructors
         public MotivationTypeBiz()
        {
            _BaseDb = new MotivationTypeDb();
        }
        public MotivationTypeBiz(int intID)
        {
            _BaseDb = new MotivationTypeDb(intID);
        }
        public MotivationTypeBiz(DataRow objDR)
        {
            _BaseDb = new MotivationTypeDb(objDR);
        }
        public MotivationTypeBiz(MotivationTypeDb objDb)
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
            ((MotivationTypeDb)_BaseDb).Add();
        }
        public  void Edit()
        {            
            ((MotivationTypeDb)_BaseDb).Edit();
        }
        public  void Delete()
        {
            ((MotivationTypeDb)_BaseDb).Delete();
        }
        public MotivationTypeBiz  Copy()
        {
            MotivationTypeBiz Returned = new MotivationTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;            

            return Returned;
        }
        
        #endregion
    }
}
