using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationCostCenterSimple
    {
        //ID,Name,SectorHeadValue,Ratio,MotivationStatementID,MotivationStatementDesc

        #region Properties
        public int ID;
        public string Name;
        public double SectorHeadValue;
        public double Ratio;
        public double BounsOnDeserved;
        public double Credit;
        public double PreviousCredit;
        public double MotivationStatementID;
        public string MotivationStatementDesc;
        public double TotalSalaryAndHeadSectorValue;
        public List<ApplicantWorkerMotivationSimple> MotivationLst = new List<ApplicantWorkerMotivationSimple>();
        #endregion
    }
}