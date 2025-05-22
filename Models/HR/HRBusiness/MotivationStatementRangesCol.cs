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
    public class MotivationStatementRangesCol : CollectionBase
    {
        #region Private Data
        ApplicantWorkerMotivationStatementRangesCol _StatementRangesCol; 
        #endregion
        #region Constructors
        public MotivationStatementRangesCol(bool blIsEmpty)
        {            
        }
        public MotivationStatementRangesCol()
        {
            MotivationStatementRangesDb objDb = new MotivationStatementRangesDb();
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRangesBiz(objDr));
            }
        }
        public MotivationStatementRangesCol(MotivationStatementBiz objMotivationStatementBiz)
        {
            MotivationStatementRangesDb objDb = new MotivationStatementRangesDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRangesBiz(objDr));
            }
        }
        public MotivationStatementRangesCol(MotivationStatementBiz objMotivationStatementBiz, CostCenterTypeBiz objCostCenterTypeBiz)
        {
            MotivationStatementRangesDb objDb = new MotivationStatementRangesDb();
            objDb.MotivationStatement = objMotivationStatementBiz.ID;
            if (objCostCenterTypeBiz != null)
                objDb.CostCenterType = objCostCenterTypeBiz.ID;
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
            {
                this.Add(new MotivationStatementRangesBiz(objDr));
            }
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerMotivationStatementRangesCol StatementRangesCol
        {
            set { _StatementRangesCol = value; }
            get
            {
                if (_StatementRangesCol == null)
                    _StatementRangesCol = new ApplicantWorkerMotivationStatementRangesCol();
                return _StatementRangesCol;
            }
        }
        public virtual MotivationStatementRangesBiz this[int intIndex]
        {
            get
            {
                return (MotivationStatementRangesBiz)this.List[intIndex];
            }
        }

        public virtual void Add(MotivationStatementRangesBiz objBiz)
        {
            this.List.Add(objBiz);
        }
        public double GetPrivateAdditionValueIsFinish
        {
            get
            {
                double dlValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (objBiz.IsFinish)
                        if (dlValue < objBiz.PrivateAdditionValueManagement)
                            dlValue = objBiz.PrivateAdditionValueManagement;
                }
                return dlValue;
            }
        }
        public double GetPrivateAdditionValueIsNotFinish
        {
            get
            {
                double dlValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (!objBiz.IsFinish)
                        if (dlValue < objBiz.PrivateAdditionValueManagement)
                            dlValue = objBiz.PrivateAdditionValueManagement;
                }
                return dlValue;
            }
        }
        public double GetPrivateAdditionValue
        {
            get
            {
                double dlValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                   
                        dlValue += objBiz.PrivateAdditionValueManagement;
                }
                return dlValue;
            }
        }


        public int GetMaxPrivateApplicantCountIsFinish
        {
            get
            {
                int intValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (objBiz.IsFinish)
                        if (intValue < objBiz.PrivateApplicantCountManagement)
                            intValue = objBiz.PrivateApplicantCountManagement;

                }
                return intValue;
            }
        }
        public int GetMaxPrivateApplicantCountIsNotFinish
        {
            get
            {
                int intValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (!objBiz.IsFinish)
                        if (intValue < objBiz.PrivateApplicantCountManagement)
                            intValue = objBiz.PrivateApplicantCountManagement;
                }
                return intValue;
            }
        }
        public int GetMaxPrivateApplicantCount
        {
            get
            {
                int intValue = 0;
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (intValue < objBiz.PrivateApplicantCountManagement)
                        intValue = objBiz.PrivateApplicantCountManagement;
                }
                return intValue;
            }
        }
        public string GetRemarkRangeIsFinish
        {
            get
            {
                string strValue = "";
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (objBiz.IsFinish)
                        if (objBiz.Remarks!="")
                            strValue += objBiz.Remarks + "\n";
                }
                return strValue;
            }
        }
        public string GetRemarkRangeIsNotFinish
        {
            get
            {
                string strValue = "";
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (!objBiz.IsFinish)
                        if (objBiz.Remarks != "")
                            strValue += objBiz.Remarks + "\n";
                }
                return strValue;
            }
        }
        #endregion
        #region Private Methods
        internal DataTable GetTable()
        {
            DataTable dtReturned = new DataTable("HRMotivationStatementRanges");
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("MotivationStatement"), new DataColumn("RangeFrom"),
                new DataColumn("RangeTo"), new DataColumn("Remarks"),new DataColumn("IsFinish"),new DataColumn("PrivateAdditionValue"),new DataColumn("PrivateApplicantCount"),new DataColumn("CostCenterType") });
            DataRow objDr;
            foreach (MotivationStatementRangesBiz objBiz in this)
            {
                objDr = dtReturned.NewRow();
                objDr["MotivationStatement"] = objBiz.MotivationStatement;
                objDr["RangeFrom"] = objBiz.RangeFrom;
                objDr["RangeTo"] = objBiz.RangeTo;
                objDr["Remarks"] = objBiz.Remarks;
                objDr["IsFinish"] = objBiz.IsFinish;
                objDr["PrivateAdditionValue"] = objBiz.PrivateAdditionValueManagement;
                objDr["PrivateApplicantCount"] = objBiz.PrivateApplicantCountManagement;
                objDr["CostCenterType"] = objBiz.CostCenterType;
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
                foreach (MotivationStatementRangesBiz objBiz in this)
                {
                    if (intMax < objBiz.RangeTo)
                        intMax = objBiz.RangeTo;
                }
                return intMax;
            }
        }
        public void BuiltStatementRanges(ApplicantWorkerManyStatementCol objManyStatementCol)
        {           
            InitTotalRanges();
            _StatementRangesCol = new ApplicantWorkerMotivationStatementRangesCol();
            _StatementRangesCol.InitTotals();
            foreach (ApplicantWorkerManyStatementBiz objManyStatementBiz in objManyStatementCol)
            {
                foreach (MotivationStatementRangesBiz objRangesBiz in this)
                {

                    if (objManyStatementBiz.TotalSalary >= objRangesBiz.RangeFrom && objManyStatementBiz.TotalSalary <= objRangesBiz.RangeTo)
                    {
                        objRangesBiz.TotalApplicantCount++;
                        objRangesBiz.TotalMotivationValue += objManyStatementBiz.TotalSalary;

                        _StatementRangesCol.TotalApplicantCount++;                        
                        _StatementRangesCol.TotalMotivationValue += objManyStatementBiz.TotalSalary;                       

                        if (objRangesBiz.IsFinish)
                        {
                            _StatementRangesCol.TotalPaidApplicantCount1++;
                            _StatementRangesCol.TotalPaidMotivationValue1 += objManyStatementBiz.TotalSalary;                                              
                        }
                        _StatementRangesCol.Add(new ApplicantWorkerMotivationStatementRangesBiz(objManyStatementBiz, objRangesBiz));

                        //if (blOneRange)
                        //    break;
                    }
                }
            }

            

        }
        public void BuiltStatementRanges(ApplicantWorkerMotivationStatementCol objStatementCol, 
            MotivationStatementBiz objMotivationStatementBiz,int intCostCenterType,bool blBaseSalaryRange)
        {
            ApplicantWorkerMotivationStatementCol _StatementCol = new ApplicantWorkerMotivationStatementCol(true);

            ApplicantWorkerManyStatementCol objManyStatementCol =
               ApplicantWorkerManyStatementCol.GetManyStatementCol(objMotivationStatementBiz, objStatementCol.ApplicantWorkerCol, 1);

            foreach (ApplicantWorkerMotivationStatementBiz objBiz in objStatementCol)
            {
                //if (intCostCenterType == 0)
                //{
                objBiz.ManyStatementBiz = objManyStatementCol.GetManyStatementBiz(objBiz.ApplicantWorkerBiz);
                _StatementCol.Add(objBiz);
                //}
                //else
                //{
                //    if (objBiz.CostCenterHRBiz.CostCenterTypeBiz.ID == intCostCenterType)
                //    {
                //        objBiz.ManyStatementBiz = objManyStatementCol.GetManyStatementBiz(objBiz.ApplicantWorkerBiz);
                //        _StatementCol.Add(objBiz);
                //    }
                //}
            }


            InitTotalRanges();
            _StatementRangesCol = new ApplicantWorkerMotivationStatementRangesCol();
            _StatementRangesCol.InitTotals();
            foreach (ApplicantWorkerMotivationStatementBiz objStatementBiz in _StatementCol)
            {
                foreach (MotivationStatementRangesBiz objRangesBiz in this)
                {
                    

                    if ((blBaseSalaryRange && objStatementBiz.ManyStatementBiz.TotalSalary >= objRangesBiz.RangeFrom && objStatementBiz.ManyStatementBiz.TotalSalary <= objRangesBiz.RangeTo) 
                        ||(!blBaseSalaryRange && objStatementBiz.MotivationValue >= objRangesBiz.RangeFrom && objStatementBiz.MotivationValue <= objRangesBiz.RangeTo) )
                    {
                        objRangesBiz.TotalApplicantCount++;
                        objRangesBiz.TotalMotivationValue += objStatementBiz.MotivationValue;

                        if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                        {

                            objRangesBiz.TotalApplicantCountBank++;

                            objRangesBiz.TotalMotivationValueBank += objStatementBiz.MotivationValue;
                            if (objStatementBiz.BankBiz.ID == (int)ApplicantBank.Ahly)
                            {
                                objRangesBiz.TotalApplicantCountBankAhly++;

                                objRangesBiz.TotalMotivationValueBankAhly += objStatementBiz.MotivationValue;
                            }
                            else
                            {
                                objRangesBiz.TotalApplicantCountBankAlex++;

                                objRangesBiz.TotalMotivationValueBankAlex += objStatementBiz.MotivationValue;
                            }

                        }
                        else
                        {
                            objRangesBiz.TotalApplicantCountCoffer++;
                            objRangesBiz.TotalMotivationValueCoffer += objStatementBiz.MotivationValue;
                        }

                        if (objStatementBiz.CostCenterHRBiz.CostCenterTypeBiz.ID == 1)
                        {
                            objRangesBiz.TotalApplicantCountManagement++;
                            objRangesBiz.TotalMotivationValueManagement += objStatementBiz.MotivationValue;

                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalApplicantCountBankManagement++;
                                objRangesBiz.TotalMotivationValueBankManagement += objStatementBiz.MotivationValue;
                            }
                            else
                            {
                                objRangesBiz.TotalApplicantCountCofferManagement++;
                                objRangesBiz.TotalMotivationValueCofferManagement += objStatementBiz.MotivationValue;
                            }
                        }
                        else if (objStatementBiz.CostCenterHRBiz.CostCenterTypeBiz.ID == 2)
                        {
                            objRangesBiz.TotalApplicantCountMarketing ++;
                            objRangesBiz.TotalMotivationValueMarketing += objStatementBiz.MotivationValue;

                            if (objStatementBiz.AccountBankNo != null && objStatementBiz.AccountBankNo != "")
                            {
                                objRangesBiz.TotalApplicantCountBankMarketing++;
                                objRangesBiz.TotalMotivationValueBankMarketing += objStatementBiz.MotivationValue;
                            }
                            else
                            {
                                objRangesBiz.TotalApplicantCountCofferMarketing++;
                                objRangesBiz.TotalMotivationValueCofferMarketing += objStatementBiz.MotivationValue;
                            }
                        }

                        //_StatementRangesCol.TotalApplicantCount++;
                        //_StatementRangesCol.TotalMotivationValue += objStatementBiz.MotivationValue;

                        //if (objRangesBiz.IsFinish)
                        //{
                        //    _StatementRangesCol.TotalPaidApplicantCount1++;
                        //    _StatementRangesCol.TotalPaidMotivationValue1 += objStatementBiz.MotivationValue;
                        //}
                        _StatementRangesCol.Add(new ApplicantWorkerMotivationStatementRangesBiz(objStatementBiz, objRangesBiz));

                        //if (blOneRange)
                        //    break;
                    }
                }
            }



        }
        public void InitTotalRanges()
        {
            foreach (MotivationStatementRangesBiz objRangesBiz in this)
            {
                objRangesBiz.InitTotals();
            }
        }
        #endregion
    }
}
