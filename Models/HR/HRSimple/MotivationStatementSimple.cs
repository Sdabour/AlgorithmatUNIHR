using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.HR.HRBusiness
{
    public class MotivationStatementSimple
    {

        #region Properties
        public int ID;
        public string Desc;
        public DateTime DateFrom;
        public DateTime DateTo;
        public int DateStartDateLimit;
        public int ApplicantStatus;
        public string MonthName;
        public int VacationDay;
        public int ParentID;
        public int MotivationType;
        public bool MotivationIsAddedBonus;
        #endregion
    }
}