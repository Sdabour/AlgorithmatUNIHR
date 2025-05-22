using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.HR.HRBusiness;
namespace AlgorithmatMVC.Controllers.HRController
{
    public class MSGAPIController : ApiController
    {
        public List<MSGSimple> GetApplicantInboxMSG(int intApplicant)
        {
            List<MSGSimple> Returned = new List<MSGSimple>();
            MSGCol objMsgCol = MSGCol.GetMsgCol(intApplicant);
            var vrMsg = from objMSG in objMsgCol.Cast<MSGBiz>()
                        orderby objMSG.ID descending
                        group objMSG by (objMSG.Group ==0 ? objMSG.Family: objMSG.Group) into MSGThread
                        select MSGThread;
            foreach(var vrThread in vrMsg)
            {
                Returned.Add(vrThread.ToList()[0].GetSimpleMSG());
            }
                        
            //foreach (MSGBiz objBiz in objMsgCol)
            //    Returned.Add(objBiz.GetSimpleMSG());

            return Returned;
        }
        [HttpPost]
        public int SaveMSG([FromBody]MSGSimple objMSG)
        {
            MSGBiz objBiz = new MSGBiz() { AlarmDate = objMSG.Alarmed ? objMSG.AlarmDate : DateTime.Now, Alarmed = objMSG.Alarmed, Date = DateTime.Now, Header = objMSG.Header, ID = objMSG.ID, NotifyByMail = objMSG.NotifyByMail, NotifyBySMS = objMSG.NotifyBySMS, Parent = objMSG.Parent, Sender = objMSG.Sender, SetAlarm = objMSG.SetAlarm, Text = objMSG.Text ,Group=objMSG.Group};
            objBiz.ApplicantLst = new List<ApplicantSingle>();
            foreach (int intID in objMSG.LstAppIDs)
                objBiz.ApplicantLst.Add(new ApplicantSingle() { ID = intID });
            objBiz.SectorLst = new List<SectorSimple>();
            foreach (int intID in objMSG.LstSectorIDs)
                objBiz.SectorLst.Add(new SectorSimple() { ID = intID });
            objBiz.Add();
            return objBiz.ID;
        }
        [Route("api/MSGAPI/SeeMSG")]
        [HttpGet]
       
        [ActionName("SeeMSG")]
       public List<MSGSimple> SeeMSG(int intApp,int intMSG)
        {
            MSGBiz objMsgBiz = new MSGBiz() { ID = intMSG };
            MSGCol objCoL = objMsgBiz.GetMSGThread(intApp);
           
            List<MSGSimple> Returned = objCoL.Cast<MSGBiz>().Select(x=> { return x.GetSimpleMSG(); }).ToList();
           
            return Returned;
           
        }
         
    }
}
