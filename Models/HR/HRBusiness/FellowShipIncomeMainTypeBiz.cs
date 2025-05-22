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
    public class FellowShipIncomeMainTypeBiz : BaseSingleBiz
    {
        #region Private Data
        
        #endregion
        #region Constructors
        public FellowShipIncomeMainTypeBiz()
        {
            _BaseDb = new FellowShipIncomeMainTypeDb();
        }
        public FellowShipIncomeMainTypeBiz(int intJobID)
        {
            _BaseDb = new FellowShipIncomeMainTypeDb(intJobID);
        }
        public FellowShipIncomeMainTypeBiz(DataRow objDR)
        {
            _BaseDb = new FellowShipIncomeMainTypeDb(objDR);
        }

        public FellowShipIncomeMainTypeBiz(FellowShipIncomeMainTypeDb objJobDb)
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
            FellowShipIncomeMainTypeDb objDb = new FellowShipIncomeMainTypeDb();
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;            
            objDb.Add();
        }
        public static void Edit(int intFellowShipIncomeMainTypeID, string strJobNameA, string strJobNameE)
        {
            FellowShipIncomeMainTypeDb objDb = new FellowShipIncomeMainTypeDb();
            objDb.ID = intFellowShipIncomeMainTypeID;
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;            
            objDb.Edit();
        }
        public static void Delete(int intFellowShipIncomeMainTypeID)
        {
            FellowShipIncomeMainTypeDb objDb = new FellowShipIncomeMainTypeDb();
            objDb.ID = intFellowShipIncomeMainTypeID;
            objDb.Delete();
        }
        public FellowShipIncomeMainTypeBiz Copy()
        {
            FellowShipIncomeMainTypeBiz Returned = new FellowShipIncomeMainTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;           
            return Returned;
        }
        #endregion
    }
}
