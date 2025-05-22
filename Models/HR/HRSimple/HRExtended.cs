using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace SharpVision.HR.HRBusiness
{
  
    public static  class HRExtended
    {
        public static ApplicantSingle GetApplicantSingle(this ApplicantWorkerBiz objBiz)
        {
            ApplicantSingle Returned = new ApplicantSingle() { Code = objBiz.Code, Department = objBiz.CurrentSubSectorBiz.SubSectorBiz.SectorName, ID = objBiz.ID, Job = objBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name, Name = objBiz.Name };
            return Returned;
        }
        public static MSGSimple GetSimpleMSG(this MSGBiz objBiz)
        {
            string strHeader = objBiz.Header== null|| objBiz.Header==""?objBiz.Text.Substring(0,objBiz.Text.Length>100?100:objBiz.Text.Length):objBiz.Header;
            MSGSimple Returned = new MSGSimple() { AlarmDate = objBiz.AlarmDate, Alarmed = objBiz.Alarmed, Date = objBiz.Date, Header = strHeader, ID = objBiz.ID, NotifyByMail = objBiz.NotifyByMail, NotifyBySMS = objBiz.NotifyBySMS, Parent = objBiz.Parent, Sender = objBiz.Sender, SenderApplicant = objBiz.SenderApplicant, SenderApplicantCode = objBiz.SenderApplicantCode, SenderApplicantName = objBiz.SenderApplicantName, SetAlarm = objBiz.SetAlarm, Stop = objBiz.Stop, Text = objBiz.Text,Group=objBiz.Group,GroupName=objBiz.GroupName ,Seen=objBiz.IsSeen};

            return Returned;
        }
        public static ApplicantWorkerMotivationSimple GetSimple(this ApplicantWorkerManyStatementBiz objBiz)
        {
            ApplicantWorkerMotivationStatementBiz objStatement1, objStatement2, objStatement3;
            objStatement1 = objBiz.RelatedStatementCol.Count > 0 ? objBiz.RelatedStatementCol[objBiz.RelatedStatementCol.Count-1] : new ApplicantWorkerMotivationStatementBiz();
            objStatement2 = objBiz.RelatedStatementCol.Count > 1 ? objBiz.RelatedStatementCol[objBiz.RelatedStatementCol.Count - 2] : new ApplicantWorkerMotivationStatementBiz();
            objStatement3 = objBiz.RelatedStatementCol.Count > 2 ? objBiz.RelatedStatementCol[objBiz.RelatedStatementCol.Count - 2] : new ApplicantWorkerMotivationStatementBiz();
            ApplicantWorkerEstimationStatementBiz objEstimation1, objEstimation2, objEstimation3;
            objEstimation1 = objBiz.EstimationStatementCol.Count > 0 ? objBiz.EstimationStatementCol[0] : new ApplicantWorkerEstimationStatementBiz();
            objEstimation2 = objBiz.EstimationStatementCol.Count > 1 ? objBiz.EstimationStatementCol[1] : new ApplicantWorkerEstimationStatementBiz();
            objEstimation3 = objBiz.EstimationStatementCol.Count > 2 ? objBiz.EstimationStatementCol[2] : new ApplicantWorkerEstimationStatementBiz();
            ApplicantWorkerMotivationSimple Returned = new ApplicantWorkerMotivationSimple() { AbsenceValue = double.Parse( objBiz.AbsenceValue.ToString("0")), ApplicantCode = objBiz.ApplicantWorkerBiz.Code, ApplicantID = objBiz.ApplicantWorkerBiz.ID, ApplicantName = objBiz.ApplicantWorkerBiz.Name, AttendanceTotalDiscountValue = 0, BaseSalary = objBiz.BaseSalary, DelayValue = objBiz.DelayValue, DetailsValue = objBiz.TotalSalary - objBiz.BaseSalary, FStEvaluationStatementDesc = objEstimation1.EstimationStatementBiz.EstimationStatementDesc, FStEvaluationStatementID = objEstimation1.ID, FStEvaluationStatementValue = double.Parse(objEstimation1.EstimationValue.ToString("0")), FStSatementID = objStatement1.ID, FStStatementDesc = objStatement1.MotivationStatementBiz.Desc, FStStatementValue = double.Parse( objStatement1.MotivationValue.ToString("0")), JobDesc = objBiz.ApplicantWorkerBiz.CurrentSubSectorBiz.JobNatureTypeBiz.Name, PenalityValue = objBiz.PenaltyValue,
                SNdEvaluationStatementDesc = objEstimation2.EstimationStatementBiz.EstimationStatementDesc,
                SNdEvaluationStatementID = objEstimation1.ID,
                SNdEvaluationStatementValue = double.Parse(objEstimation2.EstimationValue.ToString("0")),
                SNdStatementID = objStatement1.ID,
                SNdStatetmentDesc = objStatement2.MotivationStatementBiz.Desc,
                SNdStatementValue = objStatement2.MotivationValue
                 , StartDate = objBiz.ApplicantWorkerBiz.StartDate.ToString("yyyy-MM"), TotalSalary = objBiz.TotalSalary
            ,SavedValue=objBiz.SavedValue,MotivationValue=objBiz.SavedValue,Reviewed=objBiz.Reviewed,Stopped=objBiz.Stopped};
            return Returned;
        }


        public static void SetEstimationStatement(this MotivationStatementCostCenterBiz objBiz)
        {
            MotivationStatementCostCenterCol objCostCol = new MotivationStatementCostCenterCol(true);
            objCostCol.Add(objBiz);
            
            DataTable dtEstimationStatementValues =  objCostCol.EstimationTable;
            DataRow[] arrDr;
            foreach(ApplicantWorkerManyStatementBiz objStatement in objBiz.ManyStatementCol)
            {
                arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.MainEstimationStatementBiz.ID + "", "");
                if (arrDr.Length > 0)
                    objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));
                arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.EstimationStatement1Biz.ID + "", "");
                if(arrDr.Length>0)
                    objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));

                arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.EstimationStatement2Biz.ID + "", "");
                if (arrDr.Length > 0)
                    objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));
            }

        }

        public static void SetMotivationStatement(this MotivationStatementCostCenterBiz objBiz)
        {
            MotivationStatementCostCenterCol objCostCol = new MotivationStatementCostCenterCol(true);
            objCostCol.Add(objBiz);
            DataTable dtMotivationStatementValues = objCostCol.RelatedMotivationTable;
            DataRow[] arrDr;
            foreach (ApplicantWorkerManyStatementBiz objStatement in objBiz.ManyStatementCol)
            {
                arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement1Biz.ID + "", "");
                if (arrDr.Length > 0)
                    objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));
                arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement2Biz.ID + "", "");
                if (arrDr.Length > 0)
                    objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));

                arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement3Biz.ID + "", "");
                if (arrDr.Length > 0)
                    objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));
            }

        }
        public static void SetCurrentMotivationStatement(this MotivationStatementCostCenterBiz objBiz)
        {
            SharpVision.HR.HRDataBase.ApplicantWorkerMotivationStatementDb objDB = new HRDataBase.ApplicantWorkerMotivationStatementDb() { MotivationStatementSearch = objBiz.MotivationStatementBiz.ID, ApplicantIDs = objBiz.ManyStatementCol.ApplicantIDs };
            DataTable dtTemp = objDB.Search();
            DataRow[] arrDr;
            if(dtTemp.Rows.Count>0)
            {
                foreach(ApplicantWorkerManyStatementBiz objMany in objBiz.ManyStatementCol)
                {
                    arrDr = dtTemp.Select("MotivationApplicant=" + objMany.ApplicantWorkerBiz.ID);
                    if(arrDr.Length>0)
                    {
                        objMany.StatementBiz = new ApplicantWorkerMotivationStatementBiz(arrDr[0]);

                    }
                }
            }

        }

        #region CostCol
        public static void SetEstimationStatement(this MotivationStatementCostCenterCol objCostCol)
        {
            //MotivationStatementCostCenterBiz objBiz = new MotivationStatementCostCenterBiz();
             

            DataTable dtEstimationStatementValues = objCostCol.EstimationTable;
            DataRow[] arrDr;
            foreach(MotivationStatementCostCenterBiz objBiz in objCostCol)
            {
                foreach (ApplicantWorkerManyStatementBiz objStatement in objBiz.ManyStatementCol)
                {
                    arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.MainEstimationStatementBiz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));
                    arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.EstimationStatement1Biz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));

                    arrDr = dtEstimationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And EstimationStatement=" + objBiz.MotivationStatementBiz.EstimationStatement2Biz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.EstimationStatementCol.Add(new ApplicantWorkerEstimationStatementBiz(arrDr[0]));
                }
            }

        }

        public static void SetMotivationStatement(this MotivationStatementCostCenterCol objCostCol)
        {
            //MotivationStatementCostCenterCol objCostCol = new MotivationStatementCostCenterCol(true);
            DataTable dtMotivationStatementValues = objCostCol.RelatedMotivationTable;
            DataRow[] arrDr;
            foreach (MotivationStatementCostCenterBiz objBiz in objCostCol)
            {


                foreach (ApplicantWorkerManyStatementBiz objStatement in objBiz.ManyStatementCol)
                {
                    arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement1Biz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));
                    arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement2Biz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));

                    arrDr = dtMotivationStatementValues.Select("Applicant=" + objStatement.ApplicantWorkerBiz.ID + " And MotivationStatement=" + objBiz.MotivationStatementBiz.RelatedStatement3Biz.ID + "", "");
                    if (arrDr.Length > 0)
                        objStatement.RelatedStatementCol.Add(new ApplicantWorkerMotivationStatementBiz(arrDr[0]));
                }
            }

        }
        public static void SetCurrentMotivationStatement(this MotivationStatementCostCenterCol objCostCol)
        {
            SharpVision.HR.HRDataBase.ApplicantWorkerMotivationStatementDb objDB = new HRDataBase.ApplicantWorkerMotivationStatementDb() { MotivationStatementSearch = objCostCol.MotivationStatementBiz.ID, ApplicantIDs = objCostCol.ManyStatementCol.ApplicantIDs };
            DataTable dtTemp = objDB.Search();
            DataRow[] arrDr;
            if (dtTemp.Rows.Count > 0)
            {
                foreach (MotivationStatementCostCenterBiz objBiz in objCostCol)
                {
                    foreach (ApplicantWorkerManyStatementBiz objMany in objBiz.ManyStatementCol)
                    {
                        arrDr = dtTemp.Select("MotivationApplicant=" + objMany.ApplicantWorkerBiz.ID);
                        if (arrDr.Length > 0)
                        {
                            objMany.StatementBiz = new ApplicantWorkerMotivationStatementBiz(arrDr[0]);

                        }
                    }
                }
            }

        }
        #endregion
        public static MotivationCostCenterSimple GetSimple(this MotivationStatementCostCenterBiz objBiz)
        {
            MotivationCostCenterSimple Returned = new MotivationCostCenterSimple() { ID =objBiz.CostCenterHRBiz.ID,MotivationStatementDesc=objBiz.MotivationStatementBiz.Desc,MotivationStatementID=objBiz.MotivationStatementBiz.ID,Name=objBiz.CostCenterHRBiz.Name,Ratio=objBiz.MotivationRatio,SectorHeadValue = objBiz.MotivationStatementAddValue,BounsOnDeserved=objBiz.BounsOnDeserved,TotalSalaryAndHeadSectorValue=objBiz.TotalSalaryAndHeadSectorValue};
            Returned.MotivationLst = objBiz.ManyStatementCol.Cast<ApplicantWorkerManyStatementBiz>().Select(x => x.GetSimple()).OrderBy(y=>y.Stopped?1:0).ToList();

            return Returned;
        }
        public static MotivationStatementSimple GetSimple(this MotivationStatementBiz objBiz)
        {
            MotivationStatementSimple Returned = new MotivationStatementSimple() { DateFrom = objBiz.DateFrom, DateTo = objBiz.DateTo, Desc = objBiz.Desc, ID = objBiz.ID, MonthName = objBiz.MonthName, MotivationIsAddedBonus = objBiz.IsAddedBonus, MotivationType = objBiz.MotivationTypeBiz.ID, ParentID = objBiz.ParentBiz.ID, VacationDay = objBiz.VacationDay };
            return Returned;
        }
        public static CostCenterSimple GetSimple(this CostCenterHRBiz objBiz)
        {
            CostCenterSimple Returned = new CostCenterSimple() { Code = objBiz.Code, FamilyID = objBiz.FamilyID, ID = objBiz.ID, Level = objBiz.Level, NameA = objBiz.Name, NameE = objBiz.NameE, OrderVal = objBiz.OrderVal, ParentID = objBiz.ParentID, TypeID = objBiz.CostCenterTypeBiz.ID, TypeNameA = objBiz.CostCenterTypeBiz.NameA, TypeNameE = objBiz.CostCenterTypeBiz.NameE };
            return Returned;
        }
        public static ApplicantWorkerMotivationSimple GetSimple(this ApplicantWorkerMotivationStatementBiz objBiz)
        {
            ApplicantWorkerMotivationSimple Returned = new ApplicantWorkerMotivationSimple() { ApplicantCode = objBiz.ApplicantWorkerBiz.Code, ApplicantID = objBiz.ApplicantWorkerBiz.ID, ApplicantName = objBiz.ApplicantWorkerBiz.Name, BaseSalary = objBiz.BaseSalaryValue, AttendanceTotalDiscountValue = objBiz.DelayDiscountValue, DelayValue = objBiz.DelayDiscountValue, JobDesc = objBiz.JobNatureTypeBiz.Name, MotivationBonusValue = objBiz.BonusValue, MotivationDiscountValue = objBiz.DiscountValue, DetailsValue = objBiz.BaseSalaryDetailValue, ID = objBiz.ID, MotivationValue = objBiz.MotivationValue, PenalityValue = objBiz.SumPenaltyDiscount, MotivationNetValue = objBiz.MotivationValue,CostCenterName=objBiz.CostCenterHRBiz.Name,SectorName=objBiz.ApplicantWorkerBiz.SectorStr ,StartDate=objBiz.ApplicantWorkerBiz.StartDate.ToString("yyyy-MM-dd"),};
            return Returned;
        }
    }
}