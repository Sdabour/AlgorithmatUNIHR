using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace SharpVision.HR.HRBusiness
{
    public class MSGBiz
    {

        #region Constructor
        public MSGBiz()
        {
            _MSGDb = new MSGDb();
        }
        public MSGBiz(DataRow objDr)
        {
            _MSGDb = new MSGDb(objDr);
        }

        #endregion
        #region Private Data
        MSGDb _MSGDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _MSGDb.ID = value;
            get => _MSGDb.ID;
        }
        public DateTime Date
        {
            set => _MSGDb.Date = value;
            get => _MSGDb.Date;
        }
        public string Header
        {
            set => _MSGDb.Header = value;
            get => _MSGDb.Header;
        }
        public string Text
        {
            set => _MSGDb.Text = value;
            get => _MSGDb.Text;
        }
        public int Sender
        {
            set => _MSGDb.Sender = value;
            get => _MSGDb.Sender;
        }
        public bool NotifyBySMS
        {
            set => _MSGDb.NotifyBySMS = value;
            get => _MSGDb.NotifyBySMS;
        }
        public bool NotifyByMail
        {
            set => _MSGDb.NotifyByMail = value;
            get => _MSGDb.NotifyByMail;
        }
        public bool SetAlarm
        {
            set => _MSGDb.SetAlarm = value;
            get => _MSGDb.SetAlarm;
        }
        public DateTime AlarmDate
        {
            set => _MSGDb.AlarmDate = value;
            get => _MSGDb.AlarmDate;
        }
        public bool Alarmed
        {
            set => _MSGDb.Alarmed = value;
            get => _MSGDb.Alarmed;
        }
        public bool Stop
        {
            set => _MSGDb.Stop = value;
            get => _MSGDb.Stop;
        }
        public int Parent
        {
            set => _MSGDb.Parent = value;
            get => _MSGDb.Parent;
        }
        public int Family
        {
            set => _MSGDb.Family = value;
            get => _MSGDb.Family;
        }
        public int SenderApplicant
        {
            set => _MSGDb.SenderApplicant = value;
            get => _MSGDb.SenderApplicant;
        }
        public int Group
        {
            set => _MSGDb.Group = value;
            get => _MSGDb.Group;
        }
        public string GroupName
        {
            set => _MSGDb.GroupName = value;
            get => _MSGDb.GroupName;
        }
        public string SenderApplicantCode
        {
            set => _MSGDb.SenderApplicantCode = value;
            get => _MSGDb.SenderApplicantCode;
        }
        public string SenderApplicantName
        {
            set => _MSGDb.SenderApplicantName = value;
            get => _MSGDb.SenderApplicantName;
        }
        public bool IsSeen
        { get => _MSGDb.IsSeen;
        }
        List<SectorSimple> _SectorLst;
        public List<SectorSimple> SectorLst
        { set => _SectorLst = value;
        get
            {
                if(_SectorLst == null)
                {
                    _SectorLst = new List<SectorSimple>();

                }
                return _SectorLst;
            }
        }
        List<ApplicantSingle> _ApplicantLst;
        public List<ApplicantSingle> ApplicantLst
        {
            set => _ApplicantLst = value;
            get
            {
                if (_ApplicantLst == null)
                {
                    _ApplicantLst = new List<ApplicantSingle>();

                }
                return _ApplicantLst;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MSGDb.ApplicantIDs = ApplicantLst.Select(objBiz => objBiz.ID).ToList().GetStr();
            _MSGDb.SectorIDs = SectorLst.Select(objBiz => objBiz.ID).ToList().GetStr();
            _MSGDb.Add();
        }
        public void Edit()
        {
            _MSGDb.Edit();
        }
        public void Delete()
        {
           
            _MSGDb.Delete();
        }
        public MSGCol GetMSGThread(int intApp)
        {
            MSGCol REturned = new MSGCol(true);
            MSGDb objMSGDb = new MSGDb();
            objMSGDb.Parent = ID;
            DataTable dtTemp = objMSGDb.Search();
            
            foreach (DataRow objDr in dtTemp.Rows)
                REturned.Add(new MSGBiz(objDr));
            objMSGDb.ID = ID;
            objMSGDb.ApplicantID = intApp;
            objMSGDb.SeeAMSG();
            return REturned;

        }
       public static OnChangeEventHandler OnReceivingMSG = new OnChangeEventHandler((sender, notification) => { });
        #endregion
    }
}