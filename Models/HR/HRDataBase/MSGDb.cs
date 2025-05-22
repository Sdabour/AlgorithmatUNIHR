using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;
namespace SharpVision.HR.HRDataBase
{
    public class MSGDb
    {
        /*
         * MSGID, MSGDate, MSGHeader, MSGText, MSGSender, MSGNotifyBySMS, MSGNotifyByMail, MSGSetAlarm, MSGAlarmDate, MSGAlarmed, MSGStop, MSGParent, MSGSenderApplicant, MSGSenderApplicantCode, 
                   MSGSenderApplicantName

         */
        #region Constructor
        public MSGDb()
        {
        }
        public MSGDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
        {
            set => _ID = value;
            get => _ID;
        }
        DateTime _Date;
        public DateTime Date
        {
            set => _Date = value;
            get => _Date;
        }
        string _Header;
        public string Header
        {
            set => _Header = value;
            get => _Header;
        }
        string _Text;
        public string Text
        {
            set => _Text = value;
            get => _Text;
        }
        int _Sender;
        public int Sender
        {
            set => _Sender = value;
            get => _Sender;
        }
        bool _NotifyBySMS;
        public bool NotifyBySMS
        {
            set => _NotifyBySMS = value;
            get => _NotifyBySMS;
        }
        bool _NotifyByMail;
        public bool NotifyByMail
        {
            set => _NotifyByMail = value;
            get => _NotifyByMail;
        }
        bool _SetAlarm;
        public bool SetAlarm
        {
            set => _SetAlarm = value;
            get => _SetAlarm;
        }
        DateTime _AlarmDate;
        public DateTime AlarmDate
        {
            set => _AlarmDate = value;
            get => _AlarmDate;
        }
        bool _Alarmed;
        public bool Alarmed
        {
            set => _Alarmed = value;
            get => _Alarmed;
        }
        bool _Stop;
        public bool Stop
        {
            set => _Stop = value;
            get => _Stop;
        }
        int _Parent;
        public int Parent
        {
            set => _Parent = value;
            get => _Parent;
        }
        int _Family;
        public int Family
        {
            set => _Family = value;
            get => _Family;
        }
        int _SenderApplicant;
        public int SenderApplicant
        {
            set => _SenderApplicant = value;
            get => _SenderApplicant;
        }
        int _ReceiverApplicantID;
        public int ReceiverApplicantID { set => _ReceiverApplicantID = value; }
        string _SenderApplicantCode;
        public string SenderApplicantCode
        {
            set => _SenderApplicantCode = value;
            get => _SenderApplicantCode;
        }
        string _SenderApplicantName;
        public string SenderApplicantName
        {
            set => _SenderApplicantName = value;
            get => _SenderApplicantName;
        }
        string _APplicantIDs;
        public string ApplicantIDs
        {
            set => _APplicantIDs = value;
        }
        string _SectorIDs;
        public string SectorIDs
        {
            set => _SectorIDs = value;
        }
        bool _GetOnlyInMsg;
        public bool GetOnlyInMsg
        {
            set => _GetOnlyInMsg = value;
        }
        int _ApplicantID;
        public int ApplicantID
        { set => _ApplicantID = value;
            get => _ApplicantID;
        }
        int _Group;
        public int Group
        { set => _Group = value; get => _Group; }
        string _GroupName;
        public string GroupName
        { set => _GroupName = value; get => _GroupName; }
        int _Type;
        public int Type
        { set => _Type = value; get => _Type; }
        bool _IsSeen;
        public  bool IsSeen 
        {
            set => _IsSeen = value;
            get => _IsSeen;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into HRMSG (MSGType,MSGDate,MSGHeader,MSGText,MSGGroup,MSGSender,MSGNotifyBySMS,MSGNotifyByMail,MSGSetAlarm,MSGAlarmDate,MSGAlarmed,MSGParent,UsrIns,TimIns) values (" + _Type+","+ (Date.ToOADate() - 2).ToString() + ",'" + Header + "','" + Text + "'," +_Group +","+ Sender + "," + (NotifyBySMS ? 1 : 0) + "," + (NotifyByMail ? 1 : 0) + "," + (SetAlarm ? 1 : 0) + "," + (AlarmDate.ToOADate() - 2).ToString() + "," + (Alarmed ? 1 : 0) + "," + Parent + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                Returned += @" declare @ID numeric(18,0);
           set @ID = (select @@IDENTITY) ";
                Returned += @" update dbo.HRMSG set MSGParent=ISNULL(HRMSG_1.MSGParent, dbo.HRMSG.MSGID) ,MSGFamily=ISNULL(HRMSG_1.MSGFamily, dbo.HRMSG.MSGID),MSGGroup=isnull(HRMSG_1.MSGGroup,dbo.HRMSG.MSGGroup) 
   FROM dbo.HRMSG LEFT OUTER JOIN
                  dbo.HRMSG AS HRMSG_1 ON dbo.HRMSG.MSGParent = HRMSG_1.MSGID
WHERE(dbo.HRMSG.MSGID = @ID) ";
                if (_Parent != 0)
                {

                    Returned += @" insert into HRMSGApplicant (MSGID, MSGApplicant)
 SELECT @ID, MSGApplicant
FROM     dbo.HRMSGApplicant
WHERE  (MSGID = " + _Parent + ") ";
                    Returned += @" insert into HRMSGSector(MSGID, MSGSector)
   SELECT @ID, MSGSector
FROM     dbo.HRMSGSector
WHERE  (MSGID = " + _Parent+@") ";
                }

                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRMSG set MSGHeader='" + Header + "'" +
           ",MSGText='" + Text + "'" +
           ",MSGSender=" + Sender + "" +
           ",MSGNotifyBySMS=" + (NotifyBySMS ? 1 : 0) + "" +
           ",MSGNotifyByMail=" + (NotifyByMail ? 1 : 0) + "" +
           ",MSGSetAlarm=" + (SetAlarm ? 1 : 0) + "" +
           ",MSGAlarmDate=" + (AlarmDate.ToOADate() - 2).ToString() + "" +
           ",MSGAlarmed=" + (Alarmed ? 1 : 0) + "" +
           ",MSGStop=" + (Stop ? 1 : 0) + "" +
           ",MSGParent=" + Parent + "" 
           + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where MSGID="+ID;
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRMSG set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string strInMsgSector = @"with SectorTable(SectorID,SectorParentID) as
(
SELECT dbo.HRSector.SectorID,SectorParentID
FROM     dbo.HRApplicantWorkerCurrentSubSector INNER JOIN
                  dbo.HRSubSector ON dbo.HRApplicantWorkerCurrentSubSector.SubSectorID = dbo.HRSubSector.SubSectorID INNER JOIN
                  dbo.HRSector ON dbo.HRSubSector.SectorID = dbo.HRSector.SectorID
WHERE  (dbo.HRApplicantWorkerCurrentSubSector.ApplicantID = "+_ReceiverApplicantID+@")
union all 
SELECT  HRSector_1.SectorID,HRSector_1.SectorParentID
FROM    dbo.HRSector as HRSector_1
inner join SectorTable on (HRSector_1.SectorID = SectorTable.SectorParentID) 
where HRSector_1.SectorID <>HRSector_1.SectorParentID

)  ";
                //                string strMsgSector = @"SELECT dbo.HRMSGSector.MSGID
                //FROM     dbo.HRMSGSector ";
                string strMSGSeen = @"SELECT MAX(SeenID) AS MaxSeenID, SeenMSG
FROM     dbo.HRMSGSeen
WHERE  (SeenApplicant = "+ _ReceiverApplicantID + @")
GROUP BY SeenMSG";
                string strMSGParentStr = @" SELECT MSGFamily as MSGParentFamily,MSGGroup as MSGParentGroup
FROM     dbo.HRMSG
WHERE  (MSGID = "+_Parent+")";
                string strMsgApplicant = @"SELECT MSGID
FROM dbo.HRMSGApplicant
WHERE(MSGApplicant = "+_ReceiverApplicantID+")";
                string Returned = "";
                if (_ReceiverApplicantID != 0)
                    Returned += strInMsgSector;

                Returned += @" SELECT distinct dbo.HRMSG.MSGID,dbo.HRMSG.MSGType, dbo.HRMSG.MSGDate, dbo.HRMSG.MSGHeader, dbo.HRMSG.MSGText, dbo.HRMSG.MSGGroup,dbo.HRMSG.MSGSender, dbo.HRMSG.MSGNotifyBySMS, dbo.HRMSG.MSGNotifyByMail, dbo.HRMSG.MSGSetAlarm, 
                                    dbo.HRMSG.MSGAlarmDate, dbo.HRMSG.MSGAlarmed, dbo.HRMSG.MSGStop, dbo.HRMSG.MSGParent,dbo.HRMSG.MSGFamily, derivedtbl_1.MSGSenderApplicant, derivedtbl_1.MSGSenderApplicantCode, derivedtbl_1.MSGSenderApplicantName,HRGroup.GroupNameA as GroupName ";
                if (_ReceiverApplicantID != 0)
                    Returned += ",case when MaxSeenID is null then 0 else 1 end as MSGIsSeen ";

                  Returned+=@" FROM      dbo.HRMSG  
   left outer join HRGroup on HRMSG.MSGGroup = HRGroup.GroupID ";
                if(_Parent!=0)
                {
                    Returned += @" inner join ("+strMSGParentStr+ @") as ParentTable 
    on (HRMSG.MSGGroup =0 and HRMSG.MSGFamily = ParentTable.MSGParentFamily)
  or (HRMSG.MSGGroup >0 and HRMSG.MSGGroup=ParentTable.MSGParentGroup) ";
                }
                Returned+=@" INNER JOIN
                                        (SELECT dbo.HRApplicant.ApplicantID AS MSGSenderApplicant, dbo.HRApplicantWorker.ApplicantCode AS MSGSenderApplicantCode, dbo.HRApplicant.ApplicantFirstName AS MSGSenderApplicantName
                                         FROM      dbo.HRApplicant INNER JOIN
                                                           dbo.HRApplicantWorker ON dbo.HRApplicant.ApplicantID = dbo.HRApplicantWorker.ApplicantID) AS derivedtbl_1 ON dbo.HRMSG.MSGSender = derivedtbl_1.MSGSenderApplicant ";
                if (_ReceiverApplicantID != 0)
                {
                    string strMSGGroup = @"SELECT MSGGroup
FROM     dbo.HRGroupApplicant
WHERE  (MSGGroupApplicant = "+_ReceiverApplicantID+@")";
                    Returned += @" left outer join ("+strMSGGroup+@") as MSGGroupTable  on HRMsg.MSGGroup = MSGGroupTable.MSGGroup ";
                    Returned += @" left outer join (" + strMSGSeen + @") as SeenTable 
  on HRMsg.MsgID = SeenTable.SeenMSG ";
                    Returned += @" left outer join HRMSGSector on HRMSG.MSGID = HRMSGSector.MSGID " +
                        @" left outer  join SectorTable as MSGSectorTable  on HRMSGSector.MSGSector = MSGSectorTable.SectorID  
          left outer join (" + strMsgApplicant + @") as MSGApplicantTable on HRMSG.MSGID = MSGApplicantTable.MSGID 
           
           where HRMSG.Dis is  null 
   and HRMSG.MSGStop is null and (MSGApplicantTable.MSGID is not null or MSGSectorTable.SectorID is not null or MSGGroupTable.MSGGroup is not null)  ";
                   
                }

                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["MSGID"] != null)
                int.TryParse(objDr["MSGID"].ToString(), out _ID);

            if (objDr.Table.Columns["MSGDate"] != null)
                DateTime.TryParse(objDr["MSGDate"].ToString(), out _Date);

            if (objDr.Table.Columns["MSGHeader"] != null)
                _Header = objDr["MSGHeader"].ToString();

            if (objDr.Table.Columns["MSGText"] != null)
                _Text = objDr["MSGText"].ToString();

            if (objDr.Table.Columns["MSGSender"] != null)
                int.TryParse(objDr["MSGSender"].ToString(), out _Sender);

            if (objDr.Table.Columns["MSGNotifyBySMS"] != null)
                bool.TryParse(objDr["MSGNotifyBySMS"].ToString(), out _NotifyBySMS);

            if (objDr.Table.Columns["MSGNotifyByMail"] != null)
                bool.TryParse(objDr["MSGNotifyByMail"].ToString(), out _NotifyByMail);

            if (objDr.Table.Columns["MSGSetAlarm"] != null)
                bool.TryParse(objDr["MSGSetAlarm"].ToString(), out _SetAlarm);

            if (objDr.Table.Columns["MSGAlarmDate"] != null)
                DateTime.TryParse(objDr["MSGAlarmDate"].ToString(), out _AlarmDate);

            if (objDr.Table.Columns["MSGAlarmed"] != null)
                bool.TryParse(objDr["MSGAlarmed"].ToString(), out _Alarmed);

            if (objDr.Table.Columns["MSGStop"] != null)
                bool.TryParse(objDr["MSGStop"].ToString(), out _Stop);

            if (objDr.Table.Columns["MSGParent"] != null)
                int.TryParse(objDr["MSGParent"].ToString(), out _Parent);

            if (objDr.Table.Columns["MSGFamily"] != null)
                int.TryParse(objDr["MSGFamily"].ToString(), out _Family);

            if (objDr.Table.Columns["MSGSenderApplicant"] != null)
                int.TryParse(objDr["MSGSenderApplicant"].ToString(), out _SenderApplicant);

            if (objDr.Table.Columns["MSGSenderApplicantCode"] != null)
                _SenderApplicantCode = objDr["MSGSenderApplicantCode"].ToString();

            if (objDr.Table.Columns["MSGSenderApplicantName"] != null)
                _SenderApplicantName = objDr["MSGSenderApplicantName"].ToString();
            if (objDr.Table.Columns["MSGGroup"] != null)
                int.TryParse(objDr["MSGGroup"].ToString(), out _Group);
            if (objDr.Table.Columns["GroupName"] != null)
                _GroupName = objDr["GroupName"].ToString();
            _IsSeen = false;
            if (objDr.Table.Columns["MSGIsSeen"] != null)
                _IsSeen = objDr["MSGIsSeen"].ToString() == "1";
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
          ID=  SysData.SharpVisionBaseDb.InsertIdentityTable(strSql);
            JoinApplicant();
            JoinSector();

        }
        void JoinApplicant()
        {
            if (_APplicantIDs == null || _APplicantIDs == "")
                return;
            string strSql = @"insert into HRMSGApplicant (MSGID, MSGApplicant) 
  SELECT "+ID+@" AS MsgID, dbo.HRApplicantWorker.ApplicantID
FROM     dbo.HRApplicantWorker left outer JOIN
                      (SELECT MSGID, MSGApplicant
                       FROM      dbo.HRMSGApplicant
                       WHERE   (MSGID = "+ID+ @")) AS OLDMSGApplicant
 on HRApplicantWorker.ApplicantID = OLDMSGApplicant.MSGApplicant 
 WHERE  (dbo.HRApplicantWorker.ApplicantID IN (" + _APplicantIDs + @")) AND (dbo.HRApplicantWorker.ApplicantStatusID = 1) and OLDMSGApplicant.MSGApplicant is null ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        void JoinSector()
        {
            if (_SectorIDs == null || _SectorIDs == "")
                return;
            string strSql = @"insert into HRMSGSector (MSGID, MSGSector) 
 SELECT DISTINCT "+_ID+@" AS MSGID, dbo.HRSector.SectorID
FROM     dbo.HRSector left outer JOIN
                      (SELECT MSGID, MSGSector
                       FROM      dbo.HRMSGSector
                       WHERE   (MSGID = "+_ID+ @")) AS derivedtbl_1 ON dbo.HRSector.SectorID = derivedtbl_1.MSGSector
WHERE (dbo.HRSector.SectorID in ("+_SectorIDs+@"))  and (derivedtbl_1.MSGID IS NULL)";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }

        public DataTable Search()
        {
            string strSql = SearchStr;

            if(_ReceiverApplicantID==0)
            strSql += " where HRMSG.Dis is null ";
            if (_Parent != 0)
            {
                //strSql += @" and  ((MSGID = "+_Parent+@") OR
                //  (MSGParent = "+_Parent+"))";
            }
            if(_ReceiverApplicantID!=0 ||_Parent!= 0)
            strSql += " order by HRMSG.MSGID desc ";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void SeeAMSG()
        {
            string strSql = @" insert into HRMSGSeen (SeenDate, SeenMSG, SeenApplicant) " +
                @" SELECT GETDATE() AS SeenDate, "+_ID+@" AS MSGID, dbo.HRApplicant.ApplicantID
FROM     dbo.HRApplicant LEFT OUTER JOIN
                      (SELECT SeenApplicant
                       FROM      dbo.HRMSGSeen
                       WHERE   (SeenMSG = "+_ID+ @")) AS derivedtbl_1 ON dbo.HRApplicant.ApplicantID = derivedtbl_1.SeenApplicant
WHERE  (derivedtbl_1.SeenApplicant IS NULL)  AND (dbo.HRApplicant.ApplicantID = "+_ApplicantID+") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        #endregion
    }
}