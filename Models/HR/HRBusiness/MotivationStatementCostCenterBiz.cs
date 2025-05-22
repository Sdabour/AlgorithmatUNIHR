using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using SharpVision.Base.BaseDataBase;
using SharpVision.HR.HRDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementCostCenterBiz
    {
        #region Private Data
        MotivationStatementCostCenterDb _MotivationStatementCostCenterDb;
        MotivationStatementBiz _MotivationStatementBiz;
        CostCenterHRBiz _CostCenterHRBiz;
        CostCenterTypeBiz _CostCenterTypeBiz;
        MotivationStatementCostCenterApplicantCol _ApplicantCol;
        MotivationStatementCostCenterApplicantCol _SelectedApplicantCol;
        MotivationStatementCostCenterApplicantCol _SpecialCaseApplicantCol;
        ApplicantWorkerManyStatementCol _ManyStatementCol;
        byte _MotivationStatus;
        ApplicantWorkerMotivationStatementCol _ApplicantWorkerMotivationStatementCol;
        double _TotalStatementDeserved = -1;
        double _TotalStatementDeservedBank = -1;
        double _TotalStatementDeservedCoffer = -1;
        int _SearchOpertaion;
        double _SearchValueFrom;
        double _SearchValueTo;
        bool _FilterManyStatement;
        double _RangeMotivationRatio = 1;
        #endregion
        #region Constructors
        public MotivationStatementCostCenterBiz()
        {
            _MotivationStatementCostCenterDb = new MotivationStatementCostCenterDb();
            _CostCenterHRBiz = new CostCenterHRBiz();
            _MotivationStatementBiz = new MotivationStatementBiz();
            _CostCenterTypeBiz = new CostCenterTypeBiz();
        }
        public MotivationStatementCostCenterBiz(DataRow objDr)
        {
            _MotivationStatementCostCenterDb = new MotivationStatementCostCenterDb(objDr);
            _CostCenterHRBiz = new CostCenterHRBiz(objDr);
            _MotivationStatementBiz = new MotivationStatementBiz(objDr);
            _RangeMotivationRatio = (_MotivationStatementCostCenterDb.MotivationRatio / 100);
            _CostCenterTypeBiz = new CostCenterTypeBiz(objDr);
        }
        public MotivationStatementCostCenterBiz(MotivationStatementBiz objMotivationStatementBiz, CostCenterHRBiz objCostCenter)
        {
            _MotivationStatementCostCenterDb = new MotivationStatementCostCenterDb(objMotivationStatementBiz.ID, objCostCenter.ID);
            _CostCenterHRBiz = new CostCenterHRBiz(_MotivationStatementCostCenterDb.CostCenter);
            _MotivationStatementBiz = objMotivationStatementBiz;
            _RangeMotivationRatio = (_MotivationStatementCostCenterDb.MotivationRatio / 100);
            _CostCenterTypeBiz = new CostCenterTypeBiz(_MotivationStatementCostCenterDb.CostCenterType);
        }
        #endregion
        #region Public Properties
        public MotivationStatementBiz MotivationStatementBiz { set { _MotivationStatementBiz = value; } get { return _MotivationStatementBiz; } }
        public CostCenterHRBiz CostCenterHRBiz { set { _CostCenterHRBiz = value; } get
            {
                return _CostCenterHRBiz; } }
        public CostCenterTypeBiz CostCenterTypeBiz { set { _CostCenterTypeBiz = value; } get { return _CostCenterTypeBiz; } }        
        public double MotivationStatementAddValue { set { _MotivationStatementCostCenterDb.MotivationStatementAddValue = value; } get { return _MotivationStatementCostCenterDb.MotivationStatementAddValue; } }
        public double BounsOnDeserved { set { _MotivationStatementCostCenterDb.BounsOnDeserved = value; } get { return _MotivationStatementCostCenterDb.BounsOnDeserved; } }
        public bool IsIncludeAllApplicant { set { _MotivationStatementCostCenterDb.IsIncludeAllApplicant = value; } get { return _MotivationStatementCostCenterDb.IsIncludeAllApplicant; } }
        public string Remarks { set { _MotivationStatementCostCenterDb.Remarks = value; } get { return _MotivationStatementCostCenterDb.Remarks; } }
        public double MotivationRatio { set { _MotivationStatementCostCenterDb.MotivationRatio = value; } get { return _MotivationStatementCostCenterDb.MotivationRatio; } }
        public byte ApplicantStatus { set { _MotivationStatementCostCenterDb.ApplicantStatus = value; } get { return _MotivationStatementCostCenterDb.ApplicantStatus; } }
        public MotivationStatementCostCenterApplicantCol ApplicantCol
        {
            set
            {
                _ApplicantCol = value; 
            }
            get
            {
                if (IsIncludeAllApplicant)
                    return new MotivationStatementCostCenterApplicantCol(false);
                if (_ApplicantCol == null)
                {
                    
                    _ApplicantCol = new MotivationStatementCostCenterApplicantCol(MotivationStatementBiz.ID, CostCenterHRBiz.ID, CostCenterHRBiz.ID.ToString());
                }

                return _ApplicantCol;
            }
        }
        public MotivationStatementCostCenterApplicantCol SelectedApplicantCol
        {
            set
            {
                _SelectedApplicantCol = value;
            }
            get
            {
                if (IsIncludeAllApplicant)
                    return new MotivationStatementCostCenterApplicantCol(false);
                if (_SelectedApplicantCol == null)
                {
                    _SelectedApplicantCol = new MotivationStatementCostCenterApplicantCol(MotivationStatementBiz.ID, CostCenterHRBiz.ID, (byte)1);
                }

                return _SelectedApplicantCol;
            }
        }
        public MotivationStatementCostCenterApplicantCol SpecialCaseApplicantCol
        {
            set
            {
                _SpecialCaseApplicantCol = value;
            }
            get
            {
                if (IsIncludeAllApplicant)
                    return new MotivationStatementCostCenterApplicantCol(false);
                if (_SpecialCaseApplicantCol == null)
                {
                    _SpecialCaseApplicantCol = new MotivationStatementCostCenterApplicantCol(MotivationStatementBiz.ID, CostCenterHRBiz.ID, (byte)2);
                }

                return _SpecialCaseApplicantCol;
            }
        }
        public ApplicantWorkerManyStatementCol ManyStatementCol
        {
            set
            {
                _ManyStatementCol = value;
            }
            get
            {
                if (_ManyStatementCol == null)
                {
                    double dlTotalSalary = 0;
                    if (this.CostCenterHRBiz.ID != 0)
                    {
                        bool blIsDependonStartDate = false;
                        if (_MotivationStatementBiz.DateStartDateLimit.Year != 1900)
                            blIsDependonStartDate = true;

                        _ManyStatementCol = new ApplicantWorkerManyStatementCol(_MotivationStatementBiz, _MotivationStatementBiz.GetGlobalStatementCol,
                        this.CostCenterHRBiz, (byte)this.ApplicantStatus, 1, blIsDependonStartDate, _MotivationStatementBiz.DateStartDateLimit
                        , this.IsIncludeAllApplicant, this.GetApplicantCol().IDs, _MotivationStatus, new CostCenterHRBiz());


                        _ManyStatementCol.SetSumVariable();
                        
                        _ManyStatementCol.GetSumVariable();
                        dlTotalSalary = _ManyStatementCol.SumTotalSalary;

                    }
                    else
                    {
                        _ManyStatementCol = new ApplicantWorkerManyStatementCol(_MotivationStatementBiz,1);
                        _ManyStatementCol.SetSumVariable();
                        _ManyStatementCol.GetSumVariable();
                        dlTotalSalary = _ManyStatementCol.SumTotalSalary;
                      
                    }
                    if (_FilterManyStatement)
                    {

                        _ManyStatementCol = GetManyStatementDependeOnSearchOperration(_ManyStatementCol);
                        _ManyStatementCol.SetSumVariable();
                        _ManyStatementCol.GetSumVariable();

                        if (dlTotalSalary != 0)
                            _RangeMotivationRatio = _ManyStatementCol.SumTotalSalary / dlTotalSalary;
                        else
                            _RangeMotivationRatio = 1;
                    }

                   

                }
                return _ManyStatementCol;
            }
        }
        public double TotalSalary
        {
            get
            {
                return ManyStatementCol.SumTotalSalary;
            }
        }
        public double TotalSalaryAndHeadSectorValue
        {
            get
            {
                double Returned;
                if (_FilterManyStatement)

                    Returned =  ManyStatementCol.SumTotalSalary + this.MotivationStatementAddValue * RangeMotivationRatio;
                else
                  Returned =(ManyStatementCol.SumTotalSalary + this.MotivationStatementAddValue) * RangeMotivationRatio;
                //Returned += MotivationStatementAddValue;
                return Returned;
            }
        }
        public double TotalDeservedValue
        {
            get
            {
                //if (_MotivationStatus == 0)
                //{
                double dlVal = (TotalSalaryAndHeadSectorValue * this.MotivationRatio) / 100;
                dlVal += this.BounsOnDeserved;
                return dlVal;
                //}
                //else if (_MotivationStatus == 2)
                //{
                //    double dlReminder = GetReminderTotalDeservedValue();
                //    dlReminder = dlReminder * RangeMotivationRatio;
                //    return dlReminder;
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }
        public byte MotivationStatus
        {
            set
            {
                _MotivationStatus = value;
            }
        }
        public ApplicantWorkerMotivationStatementCol ApplicantWorkerMotivationStatementCol
        {
            set
            {
                _ApplicantWorkerMotivationStatementCol = value;
            }
            get
            {
                if (_ApplicantWorkerMotivationStatementCol == null)
                {
                    _ApplicantWorkerMotivationStatementCol = new ApplicantWorkerMotivationStatementCol(_MotivationStatementBiz, this);
                }
                return _ApplicantWorkerMotivationStatementCol;
            }
        }
        public double TotalStatementDeserved
        {
            set
            {
                _TotalStatementDeserved = value;
            }
            get
            {
                if (_TotalStatementDeserved == -1)
                {
                    _TotalStatementDeserved = 0;
                    _TotalStatementDeservedBank = 0;
                    _TotalStatementDeservedCoffer = 0;
                    foreach (ApplicantWorkerMotivationStatementBiz objBiz in ApplicantWorkerMotivationStatementCol)
                    {
                        if (CheckApplicantInManyStatementCol(objBiz.ApplicantWorkerBiz))
                        {
                            _TotalStatementDeserved += objBiz.MotivationValue;
                            if (objBiz.AccountBankNo != null && objBiz.AccountBankNo != "")
                                _TotalStatementDeservedBank += objBiz.MotivationValue;
                            else
                                _TotalStatementDeservedCoffer += objBiz.MotivationValue;
                        }
                    }
                }
                return _TotalStatementDeserved;
            }
        }
        public double TotalStatementDeservedBank
        {
            set
            {
                _TotalStatementDeservedBank = value;
            }
            get
            {                
                return _TotalStatementDeservedBank;
            }
        }
        public double TotalStatementDeservedCoffer
        {
            set
            {
                _TotalStatementDeservedCoffer = value;
            }
            get
            {
                return _TotalStatementDeservedCoffer;
            }
        }
        public bool CheckApplicantInManyStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {
            
            foreach (ApplicantWorkerManyStatementBiz objBiz in ManyStatementCol)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantWorkerBiz.ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckApplicantInMotivationStatementCol(ApplicantWorkerBiz objApplicantWorkerBiz)
        {

            foreach (ApplicantWorkerMotivationStatementBiz objBiz in ApplicantWorkerMotivationStatementCol)
            {
                if (objBiz.ApplicantWorkerBiz.ID == objApplicantWorkerBiz.ID)
                {
                    return true;
                }
            }
            return false;
        }
        public int SearchOpertaion
        {
            set { _SearchOpertaion = value; }
            get { return _SearchOpertaion; }
        }
        public bool FilterManyStatement
        {
            set { _FilterManyStatement = value; }
            get { return _FilterManyStatement; }
        }
        public double SearchValueFrom
        {
            set { _SearchValueFrom = value; }
            get { return _SearchValueFrom; }
        }
        public double SearchValueTo
        {
            set { _SearchValueTo = value; }
            get { return _SearchValueTo; }
        }
        public double RangeMotivationRatio
        {
            set { _RangeMotivationRatio = value; }
            get {
                if (_RangeMotivationRatio == 0)
                {
                    _RangeMotivationRatio = 0;
                    if (_FilterManyStatement)
                        return _RangeMotivationRatio;
                    if (_SearchOpertaion != 0)
                    {
                        double dlTotalSalary = GetTotalValueDependeOnSearchOperration();
                        _RangeMotivationRatio = dlTotalSalary / ManyStatementCol.SumTotalSalary;
                    }
                }
                return _RangeMotivationRatio; 
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _MotivationStatementCostCenterDb.CostCenter = CostCenterHRBiz.ID;            
            _MotivationStatementCostCenterDb.MotivationStatement = _MotivationStatementBiz.ID;
            _MotivationStatementCostCenterDb.CostCenterType = CostCenterHRBiz.CostCenterTypeBiz.ID;            
            _MotivationStatementCostCenterDb.Add();

        }
        public void Edit()
        {
            _MotivationStatementCostCenterDb.MotivationStatement = _MotivationStatementBiz.ID;
            _MotivationStatementCostCenterDb.CostCenter = CostCenterHRBiz.ID;
            _MotivationStatementCostCenterDb.CostCenterType = CostCenterHRBiz.CostCenterTypeBiz.ID;
            _MotivationStatementCostCenterDb.Edit();
        }
        public void Delete()
        {
            _MotivationStatementCostCenterDb.MotivationStatement = _MotivationStatementBiz.ID;
            _MotivationStatementCostCenterDb.CostCenter = CostCenterHRBiz.ID;
            _MotivationStatementCostCenterDb.Delete();
        }
        public ApplicantWorkerCol GetApplicantCol()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol() ;
            foreach (MotivationStatementCostCenterApplicantBiz objBiz in ApplicantCol)
            {
                if (objBiz.ApplicantWorkerBiz.ID == 4066)
                { }
                objCol.Add(objBiz.ApplicantWorkerBiz);
            }
            return objCol;
        }
        public ApplicantWorkerCol GetSelectedApplicantCol()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();
            foreach (MotivationStatementCostCenterApplicantBiz objBiz in SelectedApplicantCol)
            {
                objCol.Add(objBiz.ApplicantWorkerBiz);
            }
            return objCol;
        }
        public ApplicantWorkerCol GetSpecialCaseApplicantCol()
        {
            ApplicantWorkerCol objCol = new ApplicantWorkerCol();
            foreach (MotivationStatementCostCenterApplicantBiz objBiz in SpecialCaseApplicantCol)
            {
                objCol.Add(objBiz.ApplicantWorkerBiz);
            }
            return objCol;
        }
        public double GetReminderTotalDeservedValue()
        {
            if (TotalStatementDeserved == 0)
                return TotalDeservedValue;
            ApplicantWorkerManyStatementCol objManyStatementCol;
            bool blIsDependonStartDate = false;
            if (_MotivationStatementBiz.DateStartDateLimit.Year != 1900)
                blIsDependonStartDate = true;

            objManyStatementCol = new ApplicantWorkerManyStatementCol(_MotivationStatementBiz, _MotivationStatementBiz.GetGlobalStatementCol,
            this.CostCenterHRBiz, (byte)this.ApplicantStatus, 1, blIsDependonStartDate, _MotivationStatementBiz.DateStartDateLimit
            , this.IsIncludeAllApplicant, this.GetApplicantCol().IDs, 0, new CostCenterHRBiz());
            //objManyStatementCol.SetSumVariable();
            //objManyStatementCol.GetSumVariable();
            objManyStatementCol.SetSumVariable();
            objManyStatementCol.GetSumVariable();
            double dlVal = ((objManyStatementCol.SumTotalSalary + this.MotivationStatementAddValue) * this.MotivationRatio) / 100;
            dlVal += this.BounsOnDeserved;

            double Reminder = dlVal - TotalStatementDeserved;
            return Reminder;
        }

        bool CheckTotalValue(double dlValue)
        {
            if (_SearchOpertaion != 0)
            {
                if (_SearchOpertaion == 1) // between
                {
                    if (dlValue >= _SearchValueFrom && dlValue <= _SearchValueTo)
                    {
                        return true;
                    }
                }
                else if (_SearchOpertaion == 2) // Less than
                {
                    if (dlValue <= _SearchValueTo)
                    {
                        return true;
                    }
                }
                else if (_SearchOpertaion == 3) // large than
                {
                    if (dlValue >= _SearchValueFrom)
                    {
                        return true;
                    }
                }
                else if (_SearchOpertaion == 4) // equal
                {
                    if (dlValue == _SearchValueFrom)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return true;
            }
            return false;
        }
        double GetTotalValueDependeOnSearchOperration()
        {
            double dlTotal = 0;
            foreach (ApplicantWorkerManyStatementBiz objBiz in ManyStatementCol)
            {
                if (CheckTotalValue(objBiz.TotalSalary))
                {
                    dlTotal += objBiz.TotalSalary;
                }
            }

            return dlTotal;
        }
        ApplicantWorkerManyStatementCol GetManyStatementDependeOnSearchOperration(ApplicantWorkerManyStatementCol objManyStatementCol)
        {
            ApplicantWorkerManyStatementCol objCol = new ApplicantWorkerManyStatementCol(true) ;
            if (_SearchOpertaion == 0)
                return objManyStatementCol;
            foreach (ApplicantWorkerManyStatementBiz objBiz in objManyStatementCol)
            {
                if (CheckTotalValue(objBiz.TotalSalary))
                {
                    objCol.Add(objBiz);                    
                }
            }

            return objCol;
        }
        #endregion
    }
}
