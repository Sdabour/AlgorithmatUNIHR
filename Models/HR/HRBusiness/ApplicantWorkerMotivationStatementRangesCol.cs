using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationStatementRangesCol : CollectionBase
    {
        #region Private Data
        int _TotalApplicantCount = -1;
        double _TotalMotivationValue = -1;
        
        //int _TotalApplicantCount1 = -1;
        //double _TotalMotivationValue1 = -1;
        
        //int _TotalApplicantCount2 = -1;
        //double _TotalMotivationValue2 = -1;

        int _TotalApplicantCountPaid = -1;
        double _TotalMotivationValuePaid = -1;
        
        int _TotalApplicantCountPaid1 = -1;
        double _TotalMotivationValuePaid1 = -1;

        int _TotalApplicantCountPaidBank = -1;
        double _TotalMotivationValuePaidBank = -1;

        int _TotalApplicantCountPaidCoffer = -1;
        double _TotalMotivationValuePaidCoffer = -1;

        
        int _TotalPrivateApplicantCountPaid2 = -1;
        double _TotalPrivateMotivationValuePaid2 = -1;
        #endregion
        #region Constructors
        public ApplicantWorkerMotivationStatementRangesCol()
        {
        }
        #endregion
        #region Public Properties
        public int TotalApplicantCount { set { _TotalApplicantCount = value; } get { return _TotalApplicantCount; }}
        public double TotalMotivationValue { set { _TotalMotivationValue = value; } get { return _TotalMotivationValue; } }

        //public int TotalApplicantCount1 { set { _TotalApplicantCount1 = value; } get { return _TotalApplicantCount1; } }
        //public double TotalDeservedValue1 { set { _TotalMotivationValue1 = value; } get { return _TotalMotivationValue1; } }

        //public int TotalApplicantCount2 { set { _TotalApplicantCount2 = value; } get { return _TotalApplicantCount2; } }
        //public double TotalDeservedValue2 { set { _TotalMotivationValue2 = value; } get { return _TotalMotivationValue2; } }

        public int TotalPaidApplicantCount { set { _TotalApplicantCountPaid = value; } get { return _TotalApplicantCountPaid; } }
        public double TotalPaidMotivationValue { set { _TotalMotivationValuePaid = value; } get { return _TotalMotivationValuePaid; } }

        public int TotalPaidApplicantCount1 { set { _TotalApplicantCountPaid1 = value; } get { return _TotalApplicantCountPaid1; } }
        public double TotalPaidMotivationValue1 { set { _TotalMotivationValuePaid1 = value; } get { return _TotalMotivationValuePaid1; } }

        public int TotalPaidApplicantCountBank { set { _TotalApplicantCountPaidBank = value; } get { return _TotalApplicantCountPaidBank; } }
        public double TotalPaidMotivationValueBank { set { _TotalMotivationValuePaidBank = value; } get { return _TotalMotivationValuePaidBank; } }

        public int TotalPaidApplicantCountCoffer { set { _TotalApplicantCountPaidCoffer = value; } get { return _TotalApplicantCountPaidCoffer; } }
        public double TotalPaidMotivationValueCoffer { set { _TotalMotivationValuePaidCoffer = value; } get { return _TotalMotivationValuePaidCoffer; } }

        public int TotalPaidPrivateApplicantCount2 { set { _TotalPrivateApplicantCountPaid2 = value; } get { return _TotalPrivateApplicantCountPaid2; } }
        public double TotalPaidPrivateMotivationValue2 { set { _TotalPrivateMotivationValuePaid2 = value; } get { return _TotalPrivateMotivationValuePaid2; } }


        public virtual ApplicantWorkerMotivationStatementRangesBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerMotivationStatementRangesBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ApplicantWorkerMotivationStatementRangesBiz objBiz)
        {
            if (GetIndex(objBiz.StatementBiz.ID) == -1)
                this.List.Add(objBiz);

            //this.List.Add(objBiz);
        }
        public int GetIndex(int intMotivationID)
        {
            for (int intIndex = 0; intIndex < Count; intIndex++)
            {
                if (this[intIndex].StatementBiz.ID == intMotivationID)
                    return intIndex;
            }
            return -1;
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void InitTotals()
        {
             _TotalApplicantCount = 0;
             _TotalMotivationValue = 0;
             //_TotalApplicantCount1 = 0;
             //_TotalMotivationValue1 = 0;
             //_TotalApplicantCount2 = 0;
             //_TotalMotivationValue2 = 0;

             _TotalApplicantCountPaid = 0;
             _TotalMotivationValuePaid = 0;
             _TotalApplicantCountPaid1 = 0;
             _TotalMotivationValuePaid1 = 0;
             _TotalPrivateApplicantCountPaid2 = 0;
             _TotalPrivateMotivationValuePaid2 = 0;



        }
        public void GetTotals()
        {
            _TotalApplicantCount = 0;
            _TotalMotivationValue = 0;
            //_TotalApplicantCount1 = 0;
            //_TotalMotivationValue1 = 0;
            //_TotalApplicantCount2 = 0;
            //_TotalMotivationValue2 = 0;

            _TotalApplicantCountPaid = 0;
            _TotalMotivationValuePaid = 0;
            _TotalApplicantCountPaid1 = 0;
            _TotalMotivationValuePaid1 = 0;

            _TotalApplicantCountPaidBank = 0;
            _TotalMotivationValuePaidBank = 0;

            _TotalApplicantCountPaidCoffer = 0;
            _TotalMotivationValuePaidCoffer = 0;


            _TotalPrivateApplicantCountPaid2 = 0;
            _TotalPrivateMotivationValuePaid2 = 0;


            foreach (ApplicantWorkerMotivationStatementRangesBiz objBiz in this)
            {
                _TotalApplicantCount++;
                _TotalMotivationValue += objBiz.StatementBiz.MotivationValue;

                if (objBiz.RangesBiz.IsFinish)
                {
                    _TotalApplicantCountPaid1++;
                    _TotalMotivationValuePaid1 += objBiz.StatementBiz.MotivationValue;

                    if (objBiz.StatementBiz.AccountBankNo != null && objBiz.StatementBiz.AccountBankNo != "")
                    {
                        _TotalApplicantCountPaidBank++;
                        _TotalMotivationValuePaidBank += objBiz.StatementBiz.MotivationValue;
                    }
                    else
                    {
                        _TotalApplicantCountPaidCoffer++;
                        _TotalMotivationValuePaidCoffer += objBiz.StatementBiz.MotivationValue;
                    }
                }
            }
        }
        #endregion
    }
}
