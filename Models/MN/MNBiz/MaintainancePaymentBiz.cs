using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;
using SharpVision.GL.GLBusiness;
namespace AlgorithmatMN.MN.MNBiz
{
    public class MaintainancePaymentBiz: PaymentBiz
    {

        #region Constructor
        public MaintainancePaymentBiz()
        {
            _PaymentDb = new MaintainancePaymentDb() { Currency=1,CurrencyValue=1,Type=0,Direction=true};

        }
        public MaintainancePaymentBiz(DataRow objDr)
        {
            _PaymentDb = new MaintainancePaymentDb(objDr);
            _ROBiz = new ROBiz(objDr);
        }

        #endregion
        #region Private Data
         
        #endregion
        #region Properties
       
        public int CreditROID
        {
            set
            {
                ((MaintainancePaymentDb)_PaymentDb).CreditROID = value;
            }
            get
            {
                return ((MaintainancePaymentDb)_PaymentDb).CreditROID;
            }
        }
        ROBiz _ROBiz;
        public ROBiz ROBiz
        { set => _ROBiz = value;
            get => _ROBiz;
        }
        public int CreditID
        {
            set
            {
                ((MaintainancePaymentDb)_PaymentDb).CreditID = value;
            }
            get
            {
                return ((MaintainancePaymentDb)_PaymentDb).CreditID;
            }
        }
     public int CreditCondition
        { set=> ((MaintainancePaymentDb)_PaymentDb).CreditConditionID=value; 
        get=> ((MaintainancePaymentDb)_PaymentDb).CreditConditionID;
        }
        CreditConditionBiz _ConditionBiz;
        public CreditConditionBiz ConditionBiz
        { set => _ConditionBiz = value;
            get
            {
                if (_ConditionBiz == null)
                    _ConditionBiz = new CreditConditionBiz();
                return _ConditionBiz;
            }
            }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public override void Add()
        {
            ((MaintainancePaymentDb)_PaymentDb).CreditROID = ROBiz.ID;
            ((MaintainancePaymentDb)_PaymentDb).CreditConditionID = ConditionBiz.ID;
            ((MaintainancePaymentDb)_PaymentDb).Add();
        }
        public override void Edit()
        {
            ((MaintainancePaymentDb)_PaymentDb).CreditROID = ROBiz.ID;
            ((MaintainancePaymentDb)_PaymentDb).CreditConditionID = ConditionBiz.ID;
            ((MaintainancePaymentDb)_PaymentDb).Edit();
        }
        public void Delete()
        {
            ((MaintainancePaymentDb)_PaymentDb).Delete();
        }
        #endregion
    }
}
