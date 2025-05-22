using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpVision.HR.HRBusiness
{
    public class MSGSimple
    {

        #region Properties
        public int ID;
        public DateTime Date;
        public string Time { get 
            {
                string Returned =Date.Date==DateTime.Now.Date ? Date.ToString("HH:mm"):Date.ToString("yy-MM-dd");

                return Returned;
            } }

        public int Type;
        public int Group;
        public string GroupName;

        public string Header;
        public string Text;
        public int Sender;
        public bool NotifyBySMS;
        public bool NotifyByMail;
        public bool SetAlarm;
        public DateTime AlarmDate;
        public bool Alarmed;
        public bool Stop;
        public int Parent;
        public int SenderApplicant;
        public string SenderApplicantCode;
        public string SenderApplicantName;
        public bool Seen;
        public List<int> LstAppIDs = new List<int>();
        public List<int> LstSectorIDs = new List<int>();
        #endregion
    }
}