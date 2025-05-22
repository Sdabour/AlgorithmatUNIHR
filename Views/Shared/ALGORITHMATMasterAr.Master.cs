using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpVision.SystemBase;
namespace Algorithmat
{
    public partial class ALGORITHMATMasterAr : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeConnection();
            SetHeaderLink();
            
        }
        void InitializeConnection()
        {
            int intLanguage = 0;
            string strLang = Request["Lang"];
            string strConnection = System.Configuration.ConfigurationManager.AppSettings["DBCon"];
            string strImage = System.Configuration.ConfigurationManager.AppSettings["ImageURL"];
            SysData.SharpVisionBaseDb = new SharpVision.Base.BaseDataBase.BaseDb(strConnection);
            SysData.Language = intLanguage;
            //SysData.WebImagePath = strImage;
        }
        public void SetHeaderLink()
        {
            int intOrder = 1;
            int intCntID, intPageID;
            intCntID = 0;
            intPageID = 0;
            if (Request["cnt"] != null)
                int.TryParse(Request["cnt"].ToString(),out intCntID);
            if (Request["pg"] != null)
                int.TryParse(Request["pg"].ToString(), out intPageID);
            if (intPageID == 1)
                intOrder = 1;
            if (intCntID > 0)
                intOrder = intCntID + 1;
            //int.TryParse( idMenuOrder.InnerText,out intOrder);
            int intTempCntID = 0;
            int intTempPgID = 0;
            
            switch (intOrder)
            {
                case 1: a1.Attributes["class"] = "active"; break;
                case 2: a2.Attributes["class"] = "active"; break;
                case 3: a3.Attributes["class"] = "active"; break;
                case 4: a4.Attributes["class"] = "active"; break;
                case 5: a5.Attributes["class"] = "active"; break;
            }
        }
    }
}