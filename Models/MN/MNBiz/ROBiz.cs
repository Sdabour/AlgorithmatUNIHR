using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmatMN.MN.MNDb;
using System.Data;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ROBiz
    {

        #region Constructor
        public ROBiz()
        {
            _RODb = new RODb();
        }
        public ROBiz(DataRow objDr)
        {
            _RODb = new RODb(objDr);
        }
        public ROBiz(int intID,string strProjectCode,string strunitCode)
        {
            RODb objDb = new RODb();
            objDb.ID = intID;

            objDb.ProjectCode = strProjectCode;
            objDb.Code = strunitCode;
            DataTable dtTemp = objDb.Search();
            
            if (dtTemp.Rows.Count > 0)
            {
                _RODb = new RODb(dtTemp.Rows[0]);
            }
            else 
            {
                _RODb = new RODb();
            }
        }
        public ROBiz(int intID)
        {
            RODb objDb = new RODb();
            objDb.ID = intID;

           
            DataTable dtTemp = objDb.Search();

            if (dtTemp.Rows.Count > 0)
            {
                _RODb = new RODb(dtTemp.Rows[0]);
            }
            else
            {
                _RODb = new RODb();
            }
        }
        #endregion
        #region Private Data
        RODb _RODb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _RODb.ID = value;
            }
            get
            {
                return _RODb.ID;
            }
        }
        public string Code
        {
            set
            {
                _RODb.Code = value;
            }
            get
            {
                return _RODb.Code;
            }
        }
        public double Area
        {
            set
            {
                _RODb.Area = value;
            }
            get
            {
                return _RODb.Area;
            }
        }
        public double Value
        { get => _RODb.Value; }
        public DateTime ContractingDate { get => _RODb.ContractingDate; }
        public bool IsCanceled { get => _RODb.IsCanceled; }
        public DateTime CancelDate { get => _RODb.CancelDate; }
        public string Key1 { get => ProjectCode + "-" + Code+"-"+ReservationID.ToString(); }
        public string Key { get => ID.ToString(); }
        public string TowerCode
        {
            set
            {
                _RODb.TowerCode = value;
            }
            get
            {
                return _RODb.TowerCode;
            }
        }
        public string ProjectCode
        {
            set
            {
                _RODb.ProjectCode = value;
            }
            get
            {
                return _RODb.ProjectCode;
            }
        }
        public string NativeProjectCode
        {
            set
            {
                _RODb.NativeProjectCode = value;
            }
            get
            {
                string Returned = _RODb.ProjectCode;
                if (_RODb.NativeProjectCode != null && _RODb.NativeProjectCode != "")
                    Returned = _RODb.NativeProjectCode;
                return Returned;
            }
        }
        public bool Occupied { set => _RODb.Occupied = value; get => _RODb.Occupied; }
        public bool LocalOwned { set => _RODb.LocalOwned = value; get => _RODb.LocalOwned; }
        public int Type
        {
            set
            {
                _RODb.Type = value;
            }
            get
            {
                return _RODb.Type;
            }
        }
        public string TypeStr { get => Type == 1 ? "سكني" : (Type == 2 ? "تجاري" : (Type==3?"اقتصادى":"ادارى")); }

        public int ReservationID
        {
            set
            {
                _RODb.ReservationID = value;
            }
            get
            {
                return _RODb.ReservationID;
            }
        }
        public double TypeWeight
        { get => Type == 1 ? 1 : 2; }
        public string SapContract
        {
            set
            {
                _RODb.SapContract = value;
            }
            get
            {
                return _RODb.SapContract;
            }
        }
        public string SapCustomerNo
        {
            set
            {
                _RODb.SapCustomerNo = value;
            }
            get
            {
                return _RODb.SapCustomerNo;
            }
        }
        public string Customer
        {
            set
            {
                _RODb.Customer = value;
            }
            get
            {
                return _RODb.Customer;
            }
        }
        public DateTime DeliveryDate
        {
            set
            {
                _RODb.DeliveryDate = value;
            }
            get
            {
                return _RODb.DeliveryDate;
            }
        }
        public bool IsEnded
        { set => _RODb.IsEnded = value;
            get => _RODb.IsEnded;
        }
       public  bool CheckIsEnded(DateTime dtDate)
        {
          
            return IsEnded && EndDate.Date <= dtDate.Date;
            
        }
        public DateTime EndDate
        {
            set
            {
                _RODb.EndDate = value;
            }
            get
            {
                return _RODb.EndDate;
            }
        }
        public double InitialMaintainanceValue
        {
            set
            {
                _RODb.InitialMaintainanceValue = value;
            }
            get
            {
                return _RODb.InitialMaintainanceValue;
            }
        }
        public double MaintainanceBonusPercPerYear
        {
            set
            {
                _RODb.MaintainanceBonusPercPerYear = value;
            }
            get
            {
                return _RODb.MaintainanceBonusPercPerYear;
            }
        }
        CreditCol _CreditCol;
        public CreditCol CreditCol 
        { set => _CreditCol = value;
            get 
            {
                if (_CreditCol == null)
                    _CreditCol = new CreditCol(true);
                return _CreditCol;
            }
        }
        public CreditBiz LastCreditBiz
        {
            get
            {

                return CreditCol.Count == 0 ? new CreditBiz() { EndDate=DateTime.Now} : CreditCol[CreditCol.Count - 1];
            }
        }
        CreditBiz _MaxCreditBiz;
        public CreditBiz MaxCreditBiz
        {
            set
            {
                _MaxCreditBiz = value;
            }
            get
            {
                if(_MaxCreditBiz == null)
                {
                    _MaxCreditBiz = new CreditBiz() { BonusValue = _RODb.MaxCreditBonusValue, Cost = _RODb.MaxCreditCost, DiscountValue = _RODb.MaxCreditDiscountValue, EndDate = _RODb.MaxCreditEndDate, CrditInitialValue = _RODb.MaxCreditInitialValue, ID = _RODb.MaxCreditID, PaymentValue = _RODb.MaxCreditPaymentValue, ROBiz = this, StartDate = _RODb.MaxCreditStartDate, Year = _RODb.MaxCreditYearID };

                }
                return _MaxCreditBiz;
            }
        }
        public double Closing
        { get
            { double Returned = 0;
                Returned = CreditCol.Count > 0 ? CreditCol[CreditCol.Count - 1].Closing : 0;
                    return Returned;
            }
        }
        public double CreditedClosing
        {
            get
            {
                double Returned = 0;
                if (CreditCol.Count == 0 && MaxCreditBiz.ID > 0)
                    CreditCol.Add(MaxCreditBiz);
                List<CreditBiz> lstCredit = CreditCol.Cast<CreditBiz>().Where(x => x.ID > 0).OrderBy(x=>x.ID).ToList();
                Returned = lstCredit.Count > 0 ? lstCredit[lstCredit.Count - 1].Closing : 0;
                return Returned;
            }
        }
        public double LastDueValue
        {
            get
            {
                double Returned = 0;
                Returned = CreditCol.Count > 0 ? CreditCol[CreditCol.Count - 1].LastDueValue : 0;
                return Returned;
            }
        }
        public double LastMeterCost
        {
            get
            {
                double Returned = 0;
                Returned = CreditCol.Count > 0 ? (CreditCol[CreditCol.Count - 1].Cost)/Area: 0;
                return Returned;
            }
        }
        public double LastCost
        {
            get
            {
                double Returned = 0;
                Returned = CreditCol.Count > 0 ? (CreditCol[CreditCol.Count - 1].Cost)  : 0;
                return Returned;
            }
        }
        public double TotalCost
        { get => CreditCol.Count > 0 ? CreditCol.Cast<CreditBiz>().Sum(x => x.Cost) : 0; }
        public double TotalBonus
        { get => CreditCol.Count > 0 ? CreditCol.Cast<CreditBiz>().Sum(x => x.BonusValue) : 0; }
        CreditRangeBiz _RangeBiz;
        public CreditRangeBiz RangeBiz
        { set => _RangeBiz = value;
            get { 
                if (_RangeBiz == null)
                                 _RangeBiz = new CreditRangeBiz() { Desc=""};
                return _RangeBiz;
            }
        }
        public double Required
        { get => InitialMaintainanceValue - Closing>0? InitialMaintainanceValue - Closing:0; }
        public double LastDueCostDiff
        { get => Closing < 0 ? -1 * Closing : (Closing>0&& Closing<InitialMaintainanceValue ?LastCreditBiz.CostDiff:0);
                }
        CreditConditionCol _ConditionCol; 
        public CreditConditionCol ConditionCol
        {
            set => _ConditionCol = value;
            get
            {
                if (_ConditionCol == null)
                {
                    _ConditionCol = new CreditConditionCol(true);
                    CreditConditionDb objDb = new CreditConditionDb() { ROIDs = ID.ToString() };
                    DataTable dtTemp = objDb.Search();
                   
                    foreach (DataRow objDr in dtTemp.Rows)
                    {
                        _ConditionCol.Add(new CreditConditionBiz(objDr));
                    }
                    List<CreditConditionBiz> lstCondition = (from objCondition in _ConditionCol.Cast<CreditConditionBiz>()
                                                            orderby (objCondition.RemainingValue < 10 ? 1 : 0), objCondition.DueDate
                                                            select objCondition).ToList();
                    _ConditionCol = new CreditConditionCol(true);
                    foreach (CreditConditionBiz objConditionBiz in lstCondition)
                        _ConditionCol.Add(objConditionBiz);
                }
                return _ConditionCol;
            }
        }
        public double ConditionRmainingValue
        {
            get 
            {
                double Returned = ConditionCol.Cast<CreditConditionBiz>().Sum(x => x.Value - x.TotalDiscountValue - x.TotalPaidValue);
                
                return Returned;
            }
        }
        public double ValueToBeDevided
        {
            get
            {
                double Returned = -1 * CreditedClosing;
                Returned -= ConditionRmainingValue + NonCreditedDiscountCol.Cast<MaintainanceDiscountBiz>().Sum(x => x.Value) + NonCreditedPaymentCol.Cast<MaintainancePaymentBiz>().Sum(x => x.Value); 
                return Returned;
            }
        }
        MaintainanceDiscountCol _NonCreditedDiscountCol;
        public MaintainanceDiscountCol NonCreditedDiscountCol
        {
            get
            {
                if (_NonCreditedDiscountCol == null)
                {
                    _NonCreditedDiscountCol = new MaintainanceDiscountCol();
                    DataTable dtTemp = new MaintainanceDiscountDb() { CreditedStatus = 2, ROIDs = ID.ToString() }.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _NonCreditedDiscountCol.Add(new MaintainanceDiscountBiz(objDr));
                }
                return _NonCreditedDiscountCol;

            }
        }
        MaintainancePaymentCol _PaymentCol;
        public MaintainancePaymentCol NonCreditedPaymentCol
        {
            set => _PaymentCol = value;
            get
            {
                if (_PaymentCol == null)
                {
                    _PaymentCol = new MaintainancePaymentCol(true);
                    MaintainancePaymentDb objDb = new MaintainancePaymentDb() { ROIDs = ID.ToString(),CreditedStatus=2 };
                    DataTable dtTemp = objDb.Search();
                    foreach (DataRow objDr in dtTemp.Rows)
                        _PaymentCol.Add(new MaintainancePaymentBiz(objDr));
                }
                return _PaymentCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _RODb.Add();
        }
        public void Edit()
        {
            _RODb.Edit();
        }
        public void EditMaintainanceValue()
        {
            _RODb.EditMaintainanceValue();
        }
        public void Delete()
        {
            _RODb.Delete();
        }
        #endregion
    }
}
