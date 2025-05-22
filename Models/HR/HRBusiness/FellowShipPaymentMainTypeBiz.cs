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
    public class FellowShipPaymentMainTypeBiz : BaseSingleBiz
    {
        #region Private Data
        
        #endregion
        #region Constructors
        public FellowShipPaymentMainTypeBiz()
        {
            _BaseDb = new FellowShipPaymentMainTypeDb();
        }
        public FellowShipPaymentMainTypeBiz(int intJobID)
        {
            _BaseDb = new FellowShipPaymentMainTypeDb(intJobID);
        }
        public FellowShipPaymentMainTypeBiz(DataRow objDR)
        {
            _BaseDb = new FellowShipPaymentMainTypeDb(objDR);
        }

        public FellowShipPaymentMainTypeBiz(FellowShipPaymentMainTypeDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties     
        
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE)
        {
            FellowShipPaymentMainTypeDb objDb = new FellowShipPaymentMainTypeDb();
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;            
            objDb.Add();
        }
        public static void Edit(int intFellowShipPaymentMainTypeID, string strJobNameA, string strJobNameE)
        {
            FellowShipPaymentMainTypeDb objDb = new FellowShipPaymentMainTypeDb();
            objDb.ID = intFellowShipPaymentMainTypeID;
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;            
            objDb.Edit();
        }
        public static void Delete(int intFellowShipPaymentMainTypeID)
        {
            FellowShipPaymentMainTypeDb objDb = new FellowShipPaymentMainTypeDb();
            objDb.ID = intFellowShipPaymentMainTypeID;
            objDb.Delete();
        }
        public FellowShipPaymentMainTypeBiz Copy()
        {
            FellowShipPaymentMainTypeBiz Returned = new FellowShipPaymentMainTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;           
            return Returned;
        }
        #endregion
    }
}
