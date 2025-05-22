using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.HR.HRDataBase;

namespace SharpVision.HR.HRBusiness
{
    public class GlobalStatementRangesBiz
    {
        #region Private Data
        GlobalStatementRangesDb _GlobalStatementRangesDb;
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

        int _TotalApplicantCountBankAhly = -1;
        double _TotalValueBankAhly = -1;

        int _TotalApplicantCountBankAlex = -1;
        double _TotalValueBankAlex = -1;

        int _TotalApplicantCountBankEG = -1;
        double _TotalValueBankEG = -1;

        int _TotalApplicantCountBank2 = -1;
        double _TotalDeservedValueBank2 = -1;
        
        int _TotalApplicantCountCoffer2 = -1;
        double _TotalDeservedValueCoffer2 = -1;
        #endregion
        #region Constructors
        public GlobalStatementRangesBiz()
        {
            _GlobalStatementRangesDb = new GlobalStatementRangesDb();
        }
        public GlobalStatementRangesBiz(DataRow objDr)
        {
            _GlobalStatementRangesDb = new GlobalStatementRangesDb(objDr);
        }
        #endregion
        #region Public Properties        
        public int GlobalStatement { set { _GlobalStatementRangesDb.GlobalStatement = value; } get { return _GlobalStatementRangesDb.GlobalStatement; } }
        public int RangeFrom { set { _GlobalStatementRangesDb.RangeFrom = value; } get { return _GlobalStatementRangesDb.RangeFrom; } }
        public int RangeTo { set { _GlobalStatementRangesDb.RangeTo = value; } get { return _GlobalStatementRangesDb.RangeTo; } }
        public string Remarks { set { _GlobalStatementRangesDb.Remarks = value; } get { return _GlobalStatementRangesDb.Remarks; } }
        public bool IsFinish { set { _GlobalStatementRangesDb.IsFinish = value; } get { return _GlobalStatementRangesDb.IsFinish; } }
        public int TotalApplicantCount { set { _TotalApplicantCount = value; } get { return _TotalApplicantCount; } }
        public double TotalDeservedValue { set { _TotalDeservedValue = value; } get { return _TotalDeservedValue; } }

        public int TotalApplicantCountBank { set { _TotalApplicantCountBank = value; } get { return _TotalApplicantCountBank; } }
        public double TotalDeservedValueBank { set { _TotalDeservedValueBank = value; } get { return _TotalDeservedValueBank; } }

        public int TotalApplicantCountCoffer { set { _TotalApplicantCountCoffer = value; } get { return _TotalApplicantCountCoffer; } }
        public double TotalDeservedValueCoffer { set { _TotalDeservedValueCoffer = value; } get { return _TotalDeservedValueCoffer; } }

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
        public double TotalValueBankAhly
        {
            set
            {
                _TotalValueBankAhly = value;
            }
            get
            {
                return _TotalValueBankAhly;
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
        public double TotalValueBankAlex
        {
            set
            {
                _TotalValueBankAlex = value;
            }
            get
            {
                return _TotalValueBankAlex;
            }
        }

        public int TotalApplicantCountBankEG
        {
            set
            {
                _TotalApplicantCountBankEG = value;
            }
            get
            {
                return _TotalApplicantCountBankEG;
            }
        }
        public double TotalValueBankEG
        {
            set
            {
                _TotalValueBankEG = value;
            }
            get
            {
                return _TotalValueBankEG;
            }
        }

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
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods

        public void Add()
        {
            _GlobalStatementRangesDb.Add();
        }
        public void Edit()
        {
            _GlobalStatementRangesDb.Edit();
        }
        public void Delete()
        {
            _GlobalStatementRangesDb.Delete();
        }
        public void InitTotals()
        {
            _TotalApplicantCount = 0;
            _TotalDeservedValue = 0;

            _TotalApplicantCountBank = 0;
            _TotalDeservedValueBank = 0;

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
            _TotalApplicantCountBankAhly = 0;
             _TotalValueBankAhly = 0;

            _TotalApplicantCountBankAlex = 0;
             _TotalValueBankAlex = 0;

             _TotalApplicantCountBankEG = 0;
             _TotalValueBankEG = 0;
        }
        #endregion
    }
}
