using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.HR.HRDataBase;
using System.Data;
using SharpVision.SystemBase;

using System.Collections;

namespace SharpVision.HR.HRBusiness
{
    public class MSGCol:CollectionBase
    {

        #region Constructor
        public MSGCol()
        {

        }
        public MSGCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            MSGBiz objBiz = new MSGBiz();
            objBiz.ID = 0;
        

            MSGDb objDb = new MSGDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new MSGBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public MSGBiz this[int intIndex]
        {
            get
            {
                return (MSGBiz)this.List[intIndex];
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(MSGBiz objBiz)
        {
            List.Add(objBiz);
        }
        public MSGCol GetCol(string strTemp)
        {
            MSGCol Returned = new MSGCol(true);
            foreach (MSGBiz objBiz in this)
            {
                if (objBiz.Header.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("MSGID"), new DataColumn("MSGDate", System.Type.GetType("System.DateTime")), new DataColumn("MSGHeader"), new DataColumn("MSGText"), new DataColumn("MSGSender"), new DataColumn("MSGNotifyBySMS", System.Type.GetType("System.Boolean")), new DataColumn("MSGNotifyByMail", System.Type.GetType("System.Boolean")), new DataColumn("MSGSetAlarm", System.Type.GetType("System.Boolean")), new DataColumn("MSGAlarmDate", System.Type.GetType("System.DateTime")), new DataColumn("MSGAlarmed", System.Type.GetType("System.Boolean")), new DataColumn("MSGStop", System.Type.GetType("System.Boolean")), new DataColumn("MSGParent"), new DataColumn("MSGSenderApplicant"), new DataColumn("MSGSenderApplicantCode"), new DataColumn("MSGSenderApplicantName") });
            DataRow objDr;
            foreach (MSGBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["MSGID"] = objBiz.ID;
                objDr["MSGDate"] = objBiz.Date;
                objDr["MSGHeader"] = objBiz.Header;
                objDr["MSGText"] = objBiz.Text;
                objDr["MSGSender"] = objBiz.Sender;
                objDr["MSGNotifyBySMS"] = objBiz.NotifyBySMS;
                objDr["MSGNotifyByMail"] = objBiz.NotifyByMail;
                objDr["MSGSetAlarm"] = objBiz.SetAlarm;
                objDr["MSGAlarmDate"] = objBiz.AlarmDate;
                objDr["MSGAlarmed"] = objBiz.Alarmed;
                objDr["MSGStop"] = objBiz.Stop;
                objDr["MSGParent"] = objBiz.Parent;
                objDr["MSGSenderApplicant"] = objBiz.SenderApplicant;
                objDr["MSGSenderApplicantCode"] = objBiz.SenderApplicantCode;
                objDr["MSGSenderApplicantName"] = objBiz.SenderApplicantName;
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public static MSGCol GetMsgCol(int intAppID)
        {
            MSGCol Returned = new MSGCol(true);
            MSGDb objDb = new MSGDb() {ReceiverApplicantID=intAppID };
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new MSGBiz(objDr));
            return Returned;
        }
        #endregion
    }
}