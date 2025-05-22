using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerMotivationSimple
    {
        //ID,StatementID,StatementDate,StatementDesc,StatementDate,ApplicantID,ApplicantName,ApplicantCode,StartDate,JobDesc,BaseSalary,DetailsValue,TotalSalary,1StSatementID,FStStatementDesc,FStStatementValue,SNdStatementID,SNdStatetmentDesc,SNdStatementValue,FStEvaluationStatementID,FStEvaluationStatementDesc,FStEvaluationStatementValue,SNdEvaluationStatementID,SNdEvaluationStatementDesc,SNdEvaluationStatementValue,AbsenceValue,PenalityValue,DelayValue,AttendanceTotalDiscountValue,MotivationValue,MotivationBonusValue,MotivationDiscountValue,MotivationNetValue

        #region Properties
        public int ID;
        public int StatementID;
        public string StatementDate;
        public string StatementDesc;
        public int ApplicantID;
        public string ApplicantName;
        public string ApplicantCode;
        public string StartDate;
        public string JobDesc;
        public double BaseSalary;
        public double DetailsValue;
        public double TotalSalary;
        public int FStSatementID;
        public string FStStatementDesc;
        public double FStStatementValue;
        public int SNdStatementID;
        public string SNdStatetmentDesc;
        public double SNdStatementValue;
        public int FStEvaluationStatementID;
        public string FStEvaluationStatementDesc;
        public double FStEvaluationStatementValue;
        public int SNdEvaluationStatementID;
        public string SNdEvaluationStatementDesc;
        public double SNdEvaluationStatementValue;
        public double AbsenceValue;
        public double PenalityValue;
        public double DelayValue;
        public double AttendanceTotalDiscountValue;
        public double MotivationValue;
        public double MotivationBonusValue;
        public double MotivationDiscountValue;
        public double MotivationNetValue;
        public double SavedValue;
        public bool Reviewed;
        public bool Stopped;
        public string SectorName;
        public string CostCenterName;
        #endregion


    }
}