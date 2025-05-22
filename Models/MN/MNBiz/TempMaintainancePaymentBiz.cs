using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMN.MN.MNDb;
using System.Data;
using SharpVision.GL.GLBusiness;
namespace AlgorithmatMN.MN.MNBiz
{
    public class TempMaintainancePaymentBiz
    {

        #region Constructor
        public TempMaintainancePaymentBiz()
        {
            _PaymentDb = new TempMaintainancePaymentDb();
        }
        public TempMaintainancePaymentBiz(DataRow objDr)
        {
            _PaymentDb = new TempMaintainancePaymentDb(objDr);
        }
        public TempMaintainancePaymentBiz(string strPaymentRef)
        {
            if (strPaymentRef == null || strPaymentRef == "")
            {
                _PaymentDb = new TempMaintainancePaymentDb();
                return;
            }
            string strTime = strPaymentRef.Substring(0, 4);
            string strID = strPaymentRef.Substring(4, strPaymentRef.Length - 4);
            string strSecond = strTime.Substring(2, 2);
            string strMinute = strTime.Substring(0, 2);
            int intID = 0;
            int.TryParse(strID, out intID);
            int intSecond = -1;
            int intMinute = -1;
            int.TryParse(strSecond, out intSecond);
            int.TryParse(strMinute, out intMinute);
            _PaymentDb = new TempMaintainancePaymentDb();
            if (intID ==0)
            {
                
                return;
            }
            TempMaintainancePaymentDb objDb = new TempMaintainancePaymentDb() { ID=intID,Second=intSecond,Minute=intMinute};
        
            //objDb.Second 
            DataTable dtTemp = objDb.Search();
           if(dtTemp.Rows.Count >0)
            {
                _PaymentDb = new TempMaintainancePaymentDb(dtTemp.Rows[0]);
               

            }
        }
        #endregion
        #region Private Data
        TempMaintainancePaymentDb _PaymentDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _PaymentDb.ID = value;
            }
            get
            {
                return _PaymentDb.ID;
            }
        }
        public int Scheduling
        {
            set
            {
                _PaymentDb.Scheduling = value;
            }
            get
            {
                return _PaymentDb.Scheduling;
            }
        }
        public DateTime Date
        {
            set
            {
                _PaymentDb.Date = value;
            }
            get
            {
                return _PaymentDb.Date;
            }
        }
        public double Value
        {
            set
            {
                _PaymentDb.Value = value;
            }
            get
            {
                return _PaymentDb.Value;
            }
        }
        public int InternalRef
        {
            set
            {
                _PaymentDb.InternalRef = value;
            }
            get
            {
                return _PaymentDb.InternalRef;
            }
        }
        public int PayementInternalType
        {
            set
            {
                _PaymentDb.PayementInternalType = value;
            }
            get
            {
                return _PaymentDb.PayementInternalType;
            }
        }
        public string Desc
        {
            set
            {
                _PaymentDb.Desc = value;
            }
            get
            {
                return _PaymentDb.Desc;
            }
        }
        public int System
        {
            set
            {
                _PaymentDb.System = value;
            }
            get
            {
                return _PaymentDb.System;
            }
        }
        public int Condition
        {
            set
            {
                _PaymentDb.Condition = value;
            }
            get
            {
                return _PaymentDb.Condition;
            }
        }
        public int GLID
        {
            set
            {
                _PaymentDb.GLID = value;
            }
            get
            {
                return _PaymentDb.GLID;
            }
        }
        public string BankRef
        {
            set
            {
                _PaymentDb.BankRef = value;
            }
            get
            {
                return _PaymentDb.BankRef;
            }
        }
       MaintainancePaymentBiz  _MaintainancePaymentBiz;
        public MaintainancePaymentBiz GLPaymentBiz
        { set => _MaintainancePaymentBiz = value;
        get
            {
                if (_MaintainancePaymentBiz == null)
                {
                    _MaintainancePaymentBiz = new MaintainancePaymentBiz();
                }
                    return _MaintainancePaymentBiz;
            }
        }
        public string TempPaymentRef
        { get => _PaymentDb.TempPaymentRef; }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _PaymentDb.Add();
        }
        public void Edit()
        {
            _PaymentDb.Edit();
        }
        public void Delete()
        {
            _PaymentDb.Delete();
        }
        public ROBiz GetROBiz()
        {
            ROBiz objROBiz = new ROBiz();
            CreditBiz objCreditBiz = new CreditBiz();
            string strPaymentDesc = "";
            CreditConditionBiz objCondition = new CreditConditionBiz();
            if (Scheduling != 0)
            {
                TempSchedulingBiz objScheduling = new TempSchedulingBiz(Scheduling);
                objCreditBiz = new CreditBiz(objScheduling.Credit);
                objROBiz = objCreditBiz.ROBiz;
                PaymentStrategyBiz objStrategyBiz = new PaymentStrategyBiz(objScheduling.Strategy);
                PaymentStrategyCol objSTrategyCol = new PaymentStrategyCol(true);
                objSTrategyCol.Add(objStrategyBiz);
                objSTrategyCol.SetConditionCol();

                objCreditBiz.ConditionCol = objCreditBiz.GetConditionCol(objScheduling.AdvancedValue, objScheduling.StartDate, objStrategyBiz, true);
                //objCreditBiz.SaveStrategy();
               // objCreditBiz.SetConditionCol();
                List<CreditConditionBiz> lstCondition = objCreditBiz.ConditionCol.Cast<CreditConditionBiz>().Where(x => x.DueDate.Date == objScheduling.StartDate.Date).ToList();
                strPaymentDesc = "سداد دفعة مقدمة من مصاريف الصيانة";
                if (lstCondition.Count > 0)
                    objCondition = lstCondition[0];
            }
            else
            {
                if (Condition != 0)
                {
                    objCondition = new CreditConditionBiz(Condition);
                    objROBiz = objCondition.CreditBiz.ROBiz;
                    strPaymentDesc = "سداد " + objCondition.Desc;
                }
                else
                {
                    objROBiz = new ROBiz(InternalRef);

                    strPaymentDesc = "سداد دفعة";
                }

            }
            return objROBiz;
        }
        public void PerformPayment(string strBankRef,out CreditBiz objCreditBiz)
        {
          
            objCreditBiz = new CreditBiz();

            if (GLID > 0||ID==0)
                return;
           
            string strPaymentDesc = "";
            ROBiz objROBiz = new ROBiz();
            objCreditBiz = new CreditBiz();

            CreditConditionBiz objCondition = new CreditConditionBiz();
            if (Scheduling != 0)
            {
                TempSchedulingBiz objScheduling = new TempSchedulingBiz(Scheduling);
                objCreditBiz = new CreditBiz(objScheduling.Credit);
                objROBiz = objCreditBiz.ROBiz;
                PaymentStrategyBiz objStrategyBiz = new PaymentStrategyBiz(objScheduling.Strategy);
                PaymentStrategyCol objSTrategyCol = new PaymentStrategyCol(true);
                objSTrategyCol.Add(objStrategyBiz);
                objSTrategyCol.SetConditionCol();

                objCreditBiz.ConditionCol = objCreditBiz.GetConditionCol(objScheduling.AdvancedValue, objScheduling.StartDate, objStrategyBiz, true);
                objCreditBiz.SaveStrategy();
                objCreditBiz.SetConditionCol();
                List<CreditConditionBiz> lstCondition = objCreditBiz.ConditionCol.Cast<CreditConditionBiz>().Where(x => x.DueDate.Date == objScheduling.StartDate.Date).ToList();
                strPaymentDesc = "سداد دفعة مقدمة من مصاريف الصيانة";
                if (lstCondition.Count > 0)
                    objCondition = lstCondition[0];
            }
            else
            {
                if (Condition != 0)
                {
                    objCondition = new CreditConditionBiz(Condition);
                    objROBiz = objCondition.CreditBiz.ROBiz;
                    strPaymentDesc = "سداد "+ objCondition.Desc;
                }
                else
                {
                    objROBiz = new ROBiz(InternalRef);

                    strPaymentDesc = "سداد دفعة";
                }
               
            }
            MaintainancePaymentBiz objBiz = new MaintainancePaymentBiz() { ROBiz = objROBiz, Value = Value, Date = Date, Desc = strPaymentDesc, Type = PaymentType.Online };
            objBiz.ConditionBiz = objCondition;
            objBiz.Add();
            BankRef = strBankRef;
            GLID = objBiz.ID;
            _PaymentDb.EditBankRef();

        }
        #endregion
    }
}