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
    public class GlobalStatementRangesCol : CollectionBase
    {
        #region Private Data
        ApplicantWorkerStatementRangesCol _StatementRangesCol; 
        #endregion
        #region Constructors
        public GlobalStatementRangesCol(bool blIsEmpty)
        {            
        }
        public GlobalStatementRangesCol()
        {
            GlobalStatementRangesDb objDb = new GlobalStatementRangesDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new GlobalStatementRangesBiz(objDr));
            }
        }
        public GlobalStatementRangesCol(GlobalStatementBiz objGlobalStatementBiz)
        {
            GlobalStatementRangesDb objDb = new GlobalStatementRangesDb();
            objDb.GlobalStatement = objGlobalStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new GlobalStatementRangesBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerStatementRangesCol StatementRangesCol
        {
            set { _StatementRangesCol = value; }
            get
            {
                if (_StatementRangesCol == null)
                    _StatementRangesCol = new ApplicantWorkerStatementRangesCol();
                return _StatementRangesCol;
            }
        }
        public virtual GlobalStatementRangesBiz this[int intIndex]
        {
            get
            {
                return (GlobalStatementRangesBiz)this.List[intIndex];
            }
        }

        public virtual void Add(GlobalStatementRangesBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRGlobalStatementRanges");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("GlobalStatement"), new DataColumn("RangeFrom"),
                new DataColumn("RangeTo"), new DataColumn("Remarks"),new DataColumn("IsFinish") });
            DataRow objDr;
            foreach (GlobalStatementRangesBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["GlobalStatement"] = objBiz.GlobalStatement;
                objDr["RangeFrom"] = objBiz.RangeFrom;
                objDr["RangeTo"] = objBiz.RangeTo;
                objDr["Remarks"] = objBiz.Remarks;
                objDr["IsFinish"] = objBiz.IsFinish;
                dtReturned.Rows.Add(objDr);
            }
            return dtReturned;

        }
        #endregion
        #region Public Methods
        public int MaxValue
        {
            get
            {
                int intMax = 0;
                foreach (GlobalStatementRangesBiz objBiz in this)
                {
                    if (intMax < objBiz.RangeTo)
                        intMax = objBiz.RangeTo;
                }
                return intMax;
            }
        }
        public void BuiltStatementRanges(ApplicantWorkerStatementCol objStatementCol,bool blOneRange)
        {           
            InitTotalRanges();
            _StatementRangesCol = new ApplicantWorkerStatementRangesCol();
            _StatementRangesCol.InitTotals();
            foreach (ApplicantWorkerStatementBiz objStatementBiz in objStatementCol)
            {
                foreach (GlobalStatementRangesBiz objRangesBiz in this)
                {

                    if (objStatementBiz.TotalDeserved >= objRangesBiz.RangeFrom && objStatementBiz.TotalDeserved <= objRangesBiz.RangeTo)
                    {
                        objRangesBiz.TotalApplicantCount++;
                        _StatementRangesCol.TotalApplicantCount++;
                        if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                        {
                            objRangesBiz.TotalApplicantCountBank++;
                            _StatementRangesCol.TotalApplicantCountBank++;

                        }
                        else
                        {
                            objRangesBiz.TotalApplicantCountCoffer++;
                            _StatementRangesCol.TotalApplicantCountCoffer++;
                        }

                        objRangesBiz.TotalDeservedValue += objStatementBiz.TotalDeserved;
                        _StatementRangesCol.TotalDeservedValue += objStatementBiz.TotalDeserved;
                        if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                        {
                            objRangesBiz.TotalDeservedValueBank += objStatementBiz.TotalDeserved;
                            _StatementRangesCol.TotalDeservedValueBank += objStatementBiz.TotalDeserved;
                            if (objStatementBiz.BankBiz.ID == (int)ApplicantBank.Ahly)
                            {
                                objRangesBiz.TotalApplicantCountBankAhly++;

                                objRangesBiz.TotalValueBankAhly += objStatementBiz.TotalDeserved;
                            }
                            else if (objStatementBiz.BankBiz.ID == (int)ApplicantBank.EG)
                            {
                                objRangesBiz.TotalApplicantCountBankEG++;

                                objRangesBiz.TotalValueBankEG += objStatementBiz.TotalDeserved;
                            }
                              else
                            {
                                objRangesBiz.TotalApplicantCountBankAlex++;

                                objRangesBiz.TotalValueBankAlex += objStatementBiz.TotalDeserved;
                            }
                        }
                        else
                        {
                            objRangesBiz.TotalDeservedValueCoffer += objStatementBiz.TotalDeserved;
                            _StatementRangesCol.TotalDeservedValueCoffer += objStatementBiz.TotalDeserved;
                        }

                        if (objStatementBiz.CostCenterBiz.CostCenterTypeBiz.ID == 1)
                        {
                            objRangesBiz.TotalApplicantCount1++;
                            _StatementRangesCol.TotalApplicantCount1++;
                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalApplicantCountBank1++;
                                _StatementRangesCol.TotalApplicantCountBank1++;
                            }
                            else
                            {
                                objRangesBiz.TotalApplicantCountCoffer1++;
                                _StatementRangesCol.TotalApplicantCountCoffer1++;
                            }
                            objRangesBiz.TotalDeservedValue1 += objStatementBiz.TotalDeserved;
                            _StatementRangesCol.TotalDeservedValue1 += objStatementBiz.TotalDeserved;
                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalDeservedValueBank1 += objStatementBiz.TotalDeserved;
                                _StatementRangesCol.TotalDeservedValueBank1 += objStatementBiz.TotalDeserved;
                            }
                            else
                            {
                                objRangesBiz.TotalDeservedValueCoffer1 += objStatementBiz.TotalDeserved;
                                _StatementRangesCol.TotalDeservedValueCoffer1 += objStatementBiz.TotalDeserved;
                            }


                        }
                        else
                        {
                            objRangesBiz.TotalApplicantCount2++;
                            _StatementRangesCol.TotalApplicantCount2++;
                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalApplicantCountBank2++;
                                _StatementRangesCol.TotalApplicantCountBank2++;
                            }
                            else
                            {
                                objRangesBiz.TotalApplicantCountCoffer2++;
                                _StatementRangesCol.TotalApplicantCountCoffer2++;
                            }
                            objRangesBiz.TotalDeservedValue2 += objStatementBiz.TotalDeserved;
                            _StatementRangesCol.TotalDeservedValue2 += objStatementBiz.TotalDeserved;
                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalDeservedValueBank2 += objStatementBiz.TotalDeserved;
                                _StatementRangesCol.TotalDeservedValueBank2 += objStatementBiz.TotalDeserved;
                            }
                            else
                            {
                                objRangesBiz.TotalDeservedValueCoffer2 += objStatementBiz.TotalDeserved;
                                _StatementRangesCol.TotalDeservedValueCoffer2 += objStatementBiz.TotalDeserved;
                            }
                        }

                        if (objRangesBiz.IsFinish)
                        {
                            _StatementRangesCol.TotalApplicantCountPaid++;
                            _StatementRangesCol.TotalDeservedValuePaid += objStatementBiz.TotalDeserved;
                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                _StatementRangesCol.TotalApplicantCountPaidBank++;
                                _StatementRangesCol.TotalDeservedValuePaidBank += objStatementBiz.TotalDeserved;
                            }
                            else
                            {
                                _StatementRangesCol.TotalApplicantCountPaidCoffer++;
                                _StatementRangesCol.TotalDeservedValuePaidCoffer += objStatementBiz.TotalDeserved;
                            }


                            if (objStatementBiz.CostCenterBiz.CostCenterTypeBiz.ID == 1)
                            {
                                _StatementRangesCol.TotalApplicantCountPaid1++;
                                _StatementRangesCol.TotalDeservedValuePaid1 += objStatementBiz.TotalDeserved;
                                if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                                {
                                    _StatementRangesCol.TotalApplicantCountPaidBank1++;
                                    _StatementRangesCol.TotalDeservedValuePaidBank1 += objStatementBiz.TotalDeserved;
                                }
                                else
                                {
                                    _StatementRangesCol.TotalApplicantCountPaidCoffer1++;
                                    _StatementRangesCol.TotalDeservedValuePaidCoffer1 += objStatementBiz.TotalDeserved;
                                }
                            }
                            else
                            {
                                _StatementRangesCol.TotalApplicantCountPaid2++;
                                _StatementRangesCol.TotalDeservedValuePaid2 += objStatementBiz.TotalDeserved;
                                if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                                {
                                    _StatementRangesCol.TotalApplicantCountPaidBank2++;
                                    _StatementRangesCol.TotalDeservedValuePaidBank2 += objStatementBiz.TotalDeserved;
                                }
                                else
                                {
                                    _StatementRangesCol.TotalApplicantCountPaidCoffer2++;
                                    _StatementRangesCol.TotalDeservedValuePaidCoffer2 += objStatementBiz.TotalDeserved;
                                }
                            }
                        }
                        _StatementRangesCol.Add(new ApplicantWorkerStatementRangesBiz(objStatementBiz, objRangesBiz));

                        if (blOneRange)
                            break;
                    }
                }
            }
        }
        public void InitTotalRanges()
        {
            foreach (GlobalStatementRangesBiz objRangesBiz in this)
            {
                objRangesBiz.InitTotals();
            }
        }
        #endregion
    }
}
