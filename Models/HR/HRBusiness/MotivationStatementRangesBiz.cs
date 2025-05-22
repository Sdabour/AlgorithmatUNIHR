using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementRangesBiz
    {
        #region Private Data
        MotivationStatementRangesDb _MotivationStatementRangesDb;
        int _TotalApplicantCount = -1;
        double _TotalMotivationValue = -1;
        int _TotalApplicantCountManagement = -1;
        double _TotalMotivationValueManagement = -1;
        int _TotalApplicantCountMarketing = -1;
        double _TotalMotivationValueMarketing = -1;
        


     

        int _TotalApplicantCountBank = -1;
        double _TotalMotivationValueBank = -1;

        int _TotalApplicantCountBankAhly = -1;
        double _TotalMotivationValueBankAhly = -1;

        int _TotalApplicantCountBankAlex = -1;
        double _TotalMotivationValueBankAlex = -1;

        int _TotalApplicantCountCoffer = -1;
        double _TotalMotivationValueCoffer = -1;

        int _TotalApplicantCountBankManagement = -1;
        double _TotalMotivationValueBankManagement = -1;
        int _TotalApplicantCountCofferManagement = -1;
        double _TotalMotivationValueCofferManagement = -1;

        int _TotalApplicantCountBankMarketing = -1;
        double _TotalMotivationValueBankMarketing = -1;
        int _TotalApplicantCountCofferMarketing = -1;
        double _TotalMotivationValueCofferMarketing = -1;


        //int _TotalApplicantCountBankAhly = -1;
        //double _TotalMotivationValueBankAhly = -1;


        int _TotalPaidApplicantCount1 = -1;
        double _TotalPaidMotivationValue1 = -1;
        int _TotalPaidPrivateApplicantCount2 = -1;
        double _TotalPaidPrivateMotivationValue2 = -1;
        #endregion
        #region Constructors
        public MotivationStatementRangesBiz()
        {
            _MotivationStatementRangesDb = new MotivationStatementRangesDb();
        }
        public MotivationStatementRangesBiz(DataRow objDr)
        {
            _MotivationStatementRangesDb = new MotivationStatementRangesDb(objDr);
        }
        #endregion
        #region Public Properties        
        public int MotivationStatement { set { _MotivationStatementRangesDb.MotivationStatement = value; } get { return _MotivationStatementRangesDb.MotivationStatement; } }
        public int CostCenterType { set { _MotivationStatementRangesDb.CostCenterType = value; } get { return _MotivationStatementRangesDb.CostCenterType; } }
        public int RangeFrom { set { _MotivationStatementRangesDb.RangeFrom = value; } get { return _MotivationStatementRangesDb.RangeFrom; } }
        public int RangeTo { set { _MotivationStatementRangesDb.RangeTo = value; } get { return _MotivationStatementRangesDb.RangeTo; } }
        public string Remarks { set { _MotivationStatementRangesDb.Remarks = value; } get { return _MotivationStatementRangesDb.Remarks; } }
        public bool IsFinish { set { _MotivationStatementRangesDb.IsFinish = value; } get { return _MotivationStatementRangesDb.IsFinish; } }
        
        public double PrivateAdditionValueManagement { set { _MotivationStatementRangesDb.PrivateAdditionValueManagement = value; } get { return _MotivationStatementRangesDb.PrivateAdditionValueManagement; } }
        public int PrivateApplicantCountManagement { set { _MotivationStatementRangesDb.PrivateApplicantCountManagement = value; } get { return _MotivationStatementRangesDb.PrivateApplicantCountManagement; } }
       
        public double PrivateAdditionValueMarketing { set { _MotivationStatementRangesDb.PrivateAdditionValueMarketing = value; } get { return _MotivationStatementRangesDb.PrivateAdditionValueMarketing; } }
        public int PrivateApplicantCountMarketing { set { _MotivationStatementRangesDb.PrivateApplicantCountMarketing = value; } get { return _MotivationStatementRangesDb.PrivateApplicantCountMarketing; } }

        public int TotalApplicantCount { set { _TotalApplicantCount = value; } get { return _TotalApplicantCount; } }
        public double TotalMotivationValue { set { _TotalMotivationValue = value; } get { return _TotalMotivationValue; } }

        public int TotalApplicantCountCoffer { set { _TotalApplicantCountCoffer = value; } get { return _TotalApplicantCountCoffer; } }
        public double TotalMotivationValueCoffer { set { _TotalMotivationValueCoffer = value; } get { return _TotalMotivationValueCoffer; } }

        public int TotalApplicantCountBank { set { _TotalApplicantCountBank = value; } get { return _TotalApplicantCountBank; } }
        public double TotalMotivationValueBank { set { _TotalMotivationValueBank = value; } get { return _TotalMotivationValueBank; } }


        public int TotalApplicantCountBankAhly 
        { 
            set
            {
                _TotalApplicantCountBankAhly = value;
            } 
            get 
            { 
                return _TotalApplicantCountBankAhly;
            }
        }
        public double TotalMotivationValueBankAhly
        { 
            set 
            {
                _TotalMotivationValueBankAhly = value; 
            } 
            get
            { 
                return _TotalMotivationValueBankAhly; 
            } 
        }

        public int TotalApplicantCountBankAlex
        {
            set
            {
                _TotalApplicantCountBankAlex = value;
            }
            get
            {
                return _TotalApplicantCountBankAlex;
            }
        }
        public double TotalMotivationValueBankAlex
        {
            set
            {
                _TotalMotivationValueBankAlex = value;
            }
            get
            {
                return _TotalMotivationValueBankAlex;
            }
        }

        public int TotalPaidApplicantCount1 { set { _TotalPaidApplicantCount1 = value; } get { return _TotalPaidApplicantCount1; } }
        public double TotalPaidMotivationValue1 { set { _TotalPaidMotivationValue1 = value; } get { return _TotalPaidMotivationValue1; } }

        public int TotalPaidPrivateApplicantCount2 { set { _TotalPaidPrivateApplicantCount2 = value; } get { return _TotalPaidPrivateApplicantCount2; } }
        public double TotalPaidPrivateMotivationValue2 { set { _TotalPaidPrivateMotivationValue2 = value; } get { return _TotalPaidPrivateMotivationValue2; } }


        public int TotalApplicantCountManagement { set { _TotalApplicantCountManagement = value; } get { return _TotalApplicantCountManagement; } }
        public double TotalMotivationValueManagement { set { _TotalMotivationValueManagement = value; } get { return _TotalMotivationValueManagement; } }

        public int TotalApplicantCountCofferManagement { set { _TotalApplicantCountCofferManagement = value; } get { return _TotalApplicantCountCofferManagement; } }
        public double TotalMotivationValueCofferManagement { set { _TotalMotivationValueCofferManagement = value; } get { return _TotalMotivationValueCofferManagement; } }

        public int TotalApplicantCountBankManagement { set { _TotalApplicantCountBankManagement = value; } get { return _TotalApplicantCountBankManagement; } }
        public double TotalMotivationValueBankManagement { set { _TotalMotivationValueBankManagement = value; } get { return _TotalMotivationValueBankManagement; } }

        public int TotalApplicantCountMarketing { set { _TotalApplicantCountMarketing = value; } get { return _TotalApplicantCountMarketing; } }
        public double TotalMotivationValueMarketing { set { _TotalMotivationValueMarketing = value; } get { return _TotalMotivationValueMarketing; } }

        public int TotalApplicantCountCofferMarketing { set { _TotalApplicantCountCofferMarketing = value; } get { return _TotalApplicantCountCofferMarketing; } }
        public double TotalMotivationValueCofferMarketing { set { _TotalMotivationValueCofferMarketing = value; } get { return _TotalMotivationValueCofferMarketing; } }

        public int TotalApplicantCountBankMarketing { set { _TotalApplicantCountBankMarketing = value; } get { return _TotalApplicantCountBankMarketing; } }
        public double TotalMotivationValueBankMarketing { set { _TotalMotivationValueBankMarketing = value; } get { return _TotalMotivationValueBankMarketing; } }

        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        public void Add()
        {
            _MotivationStatementRangesDb.Add();
        }
        public void Edit()
        {
            _MotivationStatementRangesDb.Edit();
        }
        public void Delete()
        {
            _MotivationStatementRangesDb.Delete();
        }
        public void InitTotals()
        {

            _TotalApplicantCount = 0;
            _TotalMotivationValue = 0;
            _TotalApplicantCountManagement = 0;
            _TotalMotivationValueManagement = 0;

            _TotalApplicantCountBank = 0;
            _TotalMotivationValueBank = 0;

            _TotalApplicantCountBankAhly = 0;
            _TotalMotivationValueBankAhly = 0;

            _TotalApplicantCountBankAlex = 0;
            _TotalMotivationValueBankAlex = 0;

            _TotalApplicantCountCoffer = 0;
            _TotalMotivationValueCoffer = 0;

            _TotalApplicantCountBankManagement = 0;
            _TotalMotivationValueBankManagement = 0;

            _TotalApplicantCountCofferManagement = 0;
            _TotalMotivationValueCofferManagement = 0;

            _TotalApplicantCountMarketing = 0;
            _TotalMotivationValueMarketing = 0;
            _TotalApplicantCountBankMarketing = 0;
            _TotalMotivationValueBankMarketing = 0;

            _TotalApplicantCountCofferMarketing = 0;
            _TotalMotivationValueCofferMarketing = 0;

            _TotalPaidApplicantCount1 = 0;
            _TotalPaidMotivationValue1 = 0;
            _TotalPaidPrivateApplicantCount2 = 0;
            _TotalPaidPrivateMotivationValue2 = 0;
        }
        #endregion

        //public int TotalApplicantCountBankAhly { set { _TotalApplicantCountBankAhly = value; } get { return _TotalApplicantCountBankAhly; } }
        //public double TotalMotivationValueBankAhly { set { _TotalMotivationValueBankAhly = value; } get { return _TotalMotivationValueBankAhly; } }

       
    }
}
