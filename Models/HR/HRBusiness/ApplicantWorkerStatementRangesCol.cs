using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementRangesCol : CollectionBase
    {
        #region Private Data
        int _TotalApplicantCount = -1;
        double _TotalDeservedValue = -1;

        int _TotalApplicantCountBank = -1;
        double _TotalDeservedValueBank = -1;

        int _TotalApplicantCountCoffer = -1;
        double _TotalDeservedValueCoffer = -1; 
        
        int _TotalApplicantCount1 = -1;
        double _TotalDeservedValue1 = -1;

        int _TotalApplicantCountBank1 = -1;
        double _TotalDeservedValueBank1 = -1;

        int _TotalApplicantCountCoffer1 = -1;
        double _TotalDeservedValueCoffer1 = -1;


        int _TotalApplicantCount2 = -1;
        double _TotalDeservedValue2 = -1;

        int _TotalApplicantCountBank2 = -1;
        double _TotalDeservedValueBank2 = -1;

        int _TotalApplicantCountCoffer2 = -1;
        double _TotalDeservedValueCoffer2 = -1;




        int _TotalApplicantCountPaid = -1;
        double _TotalDeservedValuePaid = -1;

        int _TotalApplicantCountPaidBank = -1;
        double _TotalDeservedValuePaidBank = -1;

        int _TotalApplicantCountPaidCoffer = -1;
        double _TotalDeservedValuePaidCoffer = -1;


        int _TotalApplicantCountPaid1 = -1;
        double _TotalDeservedValuePaid1 = -1;

        int _TotalApplicantCountPaidBank1 = -1;
        double _TotalDeservedValuePaidBank1 = -1;

        int _TotalApplicantCountPaidCoffer1 = -1;
        double _TotalDeservedValuePaidCoffer1 = -1;


        int _TotalApplicantCountPaid2 = -1;
        double _TotalDeservedValuePaid2 = -1;

        int _TotalApplicantCountPaidBank2 = -1;
        double _TotalDeservedValuePaidBank2 = -1;

        int _TotalApplicantCountPaidCoffer2 = -1;
        double _TotalDeservedValuePaidCoffer2 = -1;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementRangesCol()
        {
        }
        #endregion
        #region Public Properties
        public int TotalApplicantCount { set { _TotalApplicantCount = value; } get { return _TotalApplicantCount; }}
        public double TotalDeservedValue { set { _TotalDeservedValue = value; } get { return _TotalDeservedValue; } }

        public int TotalApplicantCountBank { set { _TotalApplicantCountBank = value; } get { return _TotalApplicantCountBank; } }
        public double TotalDeservedValueBank { set { _TotalDeservedValueBank = value; } get { return _TotalDeservedValueBank; } }

        public int TotalApplicantCountCoffer { set { _TotalApplicantCountCoffer = value; } get { return _TotalApplicantCountCoffer; } }
        public double TotalDeservedValueCoffer { set { _TotalDeservedValueCoffer = value; } get { return _TotalDeservedValueCoffer; } }

        public int TotalApplicantCount1 { set { _TotalApplicantCount1 = value; } get { return _TotalApplicantCount1; } }
        public double TotalDeservedValue1 { set { _TotalDeservedValue1 = value; } get { return _TotalDeservedValue1; } }

        public int TotalApplicantCountBank1 { set { _TotalApplicantCountBank1 = value; } get { return _TotalApplicantCountBank1; } }
        public double TotalDeservedValueBank1 { set { _TotalDeservedValueBank1 = value; } get { return _TotalDeservedValueBank1; } }

        public int TotalApplicantCountCoffer1 { set { _TotalApplicantCountCoffer1 = value; } get { return _TotalApplicantCountCoffer1; } }
        public double TotalDeservedValueCoffer1 { set { _TotalDeservedValueCoffer1 = value; } get { return _TotalDeservedValueCoffer1; } }

        public int TotalApplicantCount2 { set { _TotalApplicantCount2 = value; } get { return _TotalApplicantCount2; } }
        public double TotalDeservedValue2 { set { _TotalDeservedValue2 = value; } get { return _TotalDeservedValue2; } }

        public int TotalApplicantCountBank2 { set { _TotalApplicantCountBank2 = value; } get { return _TotalApplicantCountBank2; } }
        public double TotalDeservedValueBank2 { set { _TotalDeservedValueBank2 = value; } get { return _TotalDeservedValueBank2; } }

        public int TotalApplicantCountCoffer2 { set { _TotalApplicantCountCoffer2 = value; } get { return _TotalApplicantCountCoffer2; } }
        public double TotalDeservedValueCoffer2 { set { _TotalDeservedValueCoffer2 = value; } get { return _TotalDeservedValueCoffer2; } }




        public int TotalApplicantCountPaid { set { _TotalApplicantCountPaid = value; } get { return _TotalApplicantCountPaid; } }
        public double TotalDeservedValuePaid { set { _TotalDeservedValuePaid = value; } get { return _TotalDeservedValuePaid; } }

        public int TotalApplicantCountPaidBank { set { _TotalApplicantCountPaidBank = value; } get { return _TotalApplicantCountPaidBank; } }
        public double TotalDeservedValuePaidBank { set { _TotalDeservedValuePaidBank = value; } get { return _TotalDeservedValuePaidBank; } }

        public int TotalApplicantCountPaidCoffer { set { _TotalApplicantCountPaidCoffer = value; } get { return _TotalApplicantCountPaidCoffer; } }
        public double TotalDeservedValuePaidCoffer { set { _TotalDeservedValuePaidCoffer = value; } get { return _TotalDeservedValuePaidCoffer; } }

        public int TotalApplicantCountPaid1 { set { _TotalApplicantCountPaid1 = value; } get { return _TotalApplicantCountPaid1; } }
        public double TotalDeservedValuePaid1 { set { _TotalDeservedValuePaid1 = value; } get { return _TotalDeservedValuePaid1; } }

        public int TotalApplicantCountPaidBank1 { set { _TotalApplicantCountPaidBank1 = value; } get { return _TotalApplicantCountPaidBank1; } }
        public double TotalDeservedValuePaidBank1 { set { _TotalDeservedValuePaidBank1 = value; } get { return _TotalDeservedValuePaidBank1; } }

        public int TotalApplicantCountPaidCoffer1 { set { _TotalApplicantCountPaidCoffer1 = value; } get { return _TotalApplicantCountPaidCoffer1; } }
        public double TotalDeservedValuePaidCoffer1 { set { _TotalDeservedValuePaidCoffer1 = value; } get { return _TotalDeservedValuePaidCoffer1; } }


        public int TotalApplicantCountPaid2 { set { _TotalApplicantCountPaid2 = value; } get { return _TotalApplicantCountPaid2; } }
        public double TotalDeservedValuePaid2 { set { _TotalDeservedValuePaid2 = value; } get { return _TotalDeservedValuePaid2; } }

        public int TotalApplicantCountPaidBank2 { set { _TotalApplicantCountPaidBank2 = value; } get { return _TotalApplicantCountPaidBank2; } }
        public double TotalDeservedValuePaidBank2 { set { _TotalDeservedValuePaidBank2 = value; } get { return _TotalDeservedValuePaidBank2; } }

        public int TotalApplicantCountPaidCoffer2 { set { _TotalApplicantCountPaidCoffer2 = value; } get { return _TotalApplicantCountPaidCoffer2; } }
        public double TotalDeservedValuePaidCoffer2 { set { _TotalDeservedValuePaidCoffer2 = value; } get { return _TotalDeservedValuePaidCoffer2; } }

        public virtual ApplicantWorkerStatementRangesBiz this[int intIndex]
        {
            get
            {
                return (ApplicantWorkerStatementRangesBiz)this.List[intIndex];
            }
        }
        public virtual void Add(ApplicantWorkerStatementRangesBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void InitTotals()
        {
            _TotalApplicantCount = 0;
            _TotalDeservedValue = 0;

            _TotalApplicantCountBank = 0;
            _TotalDeservedValueBank1 = 0;

            _TotalApplicantCountCoffer = 0;
            _TotalDeservedValueCoffer = 0;

            _TotalApplicantCount1 = 0;
            _TotalDeservedValue1 = 0;

            _TotalApplicantCountBank1 = 0;
            _TotalDeservedValueBank1 = 0;

            _TotalApplicantCountCoffer1 = 0;
            _TotalDeservedValueCoffer1 = 0;

            _TotalApplicantCount2 = 0;
            _TotalDeservedValue2 = 0;

            _TotalApplicantCountBank2 = 0;
            _TotalDeservedValueBank2 = 0;

            _TotalApplicantCountCoffer2 = 0;
            _TotalDeservedValueCoffer2 = 0;

             _TotalApplicantCountPaid = 0;
             _TotalDeservedValuePaid = 0;

             _TotalApplicantCountPaidBank = 0;
             _TotalDeservedValuePaidBank = 0;

             _TotalApplicantCountPaidCoffer = 0;
             _TotalDeservedValuePaidCoffer = 0;


             _TotalApplicantCountPaid1 = 0;
             _TotalDeservedValuePaid1 = 0;

             _TotalApplicantCountPaidBank1 = 0;
             _TotalDeservedValuePaidBank1 = 0;

             _TotalApplicantCountPaidCoffer1 = 0;
             _TotalDeservedValuePaidCoffer1 = 0;

             _TotalApplicantCountPaid2 = 0;
             _TotalDeservedValuePaid2 = 0;

             _TotalApplicantCountPaidBank2= 0;
             _TotalDeservedValuePaidBank2 = 0;

             _TotalApplicantCountPaidCoffer2 = 0;
             _TotalDeservedValuePaidCoffer2 = 0;
        }
        public void SetTotals()
        {
            _TotalApplicantCount = -1;
            _TotalDeservedValue = -1;

            _TotalApplicantCountBank = -1;
            _TotalDeservedValueBank1 = -1;

            _TotalApplicantCountCoffer = -1;
            _TotalDeservedValueCoffer = -1;

            _TotalApplicantCount1 = -1;
            _TotalDeservedValue1 = -1;

            _TotalApplicantCountBank1 = -1;
            _TotalDeservedValueBank1 = -1;

            _TotalApplicantCountCoffer1 = -1;
            _TotalDeservedValueCoffer1 = -1;

            _TotalApplicantCount2 = -1;
            _TotalDeservedValue2 = -1;

            _TotalApplicantCountBank2 = -1;
            _TotalDeservedValueBank2 = -1;

            _TotalApplicantCountCoffer2 = -1;
            _TotalDeservedValueCoffer2 = -1;

            _TotalApplicantCountPaid = -1;
            _TotalDeservedValuePaid = -1;

            _TotalApplicantCountPaidBank = -1;
            _TotalDeservedValuePaidBank = -1;

            _TotalApplicantCountPaidCoffer = -1;
            _TotalDeservedValuePaidCoffer = -1;


            _TotalApplicantCountPaid1 = -1;
            _TotalDeservedValuePaid1 = -1;

            _TotalApplicantCountPaidBank1 = -1;
            _TotalDeservedValuePaidBank1 = -1;

            _TotalApplicantCountPaidCoffer1 = -1;
            _TotalDeservedValuePaidCoffer1 = -1;

            _TotalApplicantCountPaid2 = -1;
            _TotalDeservedValuePaid2 = -1;

            _TotalApplicantCountPaidBank2 = -1;
            _TotalDeservedValuePaidBank2 = -1;

            _TotalApplicantCountPaidCoffer2 = -1;
            _TotalDeservedValuePaidCoffer2 = -1;
        }
        #endregion
    }
}
