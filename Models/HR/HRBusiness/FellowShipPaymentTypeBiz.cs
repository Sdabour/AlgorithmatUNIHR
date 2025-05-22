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
    public class FellowShipPaymentTypeBiz : BaseSingleBiz
    {
        #region Private Data
        FellowShipPaymentMainTypeBiz _FellowShipPaymentMainTypeBiz;
        #endregion
        #region Constructors
        public FellowShipPaymentTypeBiz()
        {
            _BaseDb = new FellowShipPaymentTypeDb();
        }
        public FellowShipPaymentTypeBiz(int intJobID)
        {
            _BaseDb = new FellowShipPaymentTypeDb(intJobID);
        }
        public FellowShipPaymentTypeBiz(DataRow objDR)
        {
            _BaseDb = new FellowShipPaymentTypeDb(objDR);
        }

        public FellowShipPaymentTypeBiz(FellowShipPaymentTypeDb objJobDb)
        {
            _BaseDb = objJobDb;
        }
        #endregion
        #region Public Properties  
        public FellowShipPaymentMainTypeBiz FellowShipPaymentMainTypeBiz
        {
            set { _FellowShipPaymentMainTypeBiz = value; }
            get { return _FellowShipPaymentMainTypeBiz; }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public static void Add(string strJobNameA, string strJobNameE,int intMainTypeId)
        {
            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;
            objDb.FellowShipPaymentMainType = intMainTypeId;
            objDb.Add();
        }
        public static void Edit(int intFellowShipPaymentTypeID, string strJobNameA, string strJobNameE, int intMainTypeId)
        {
            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            objDb.ID = intFellowShipPaymentTypeID;
            objDb.NameA = strJobNameA;
            objDb.NameE = strJobNameE;
            objDb.FellowShipPaymentMainType = intMainTypeId;
            objDb.Edit();
        }
        public static void Delete(int intFellowShipPaymentTypeID)
        {
            FellowShipPaymentTypeDb objDb = new FellowShipPaymentTypeDb();
            objDb.ID = intFellowShipPaymentTypeID;
            objDb.Delete();
        }
        public FellowShipPaymentTypeBiz Copy()
        {
            FellowShipPaymentTypeBiz Returned = new FellowShipPaymentTypeBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;           
            return Returned;
        }
        #endregion
    }
}
