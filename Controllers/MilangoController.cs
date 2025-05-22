using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SharpVision.CRM.CRMBusiness;
using SharpVision.Base.BaseDataBase;
using SharpVision.SAP.SAPBuisness;
using System.Web;
using AlgorithmatMVC.Milango.MilangoBiz;
using AlgorithmatMN.MN.MNBiz;
using RestSharp;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.Controllers
{

    public class MilangoUserID
    {
        public string NationalId;
        public string UserId;
        public string CustomerNo;
        public string UserName;
        public string PhoneNumber;
        public static bool CheckSecreteKey(string strKey)
        {
            string strSql = @"SELECT COUNT(*) AS KeyCount
FROM     dbo.UMSSecreteKey
WHERE  (SecreteKey = '"+strKey+"') AND (Dis IS NULL)";
            object objTemp = SysData.SharpVisionBaseDb.ReturnScalar(strSql);
            return (int)SysData.SharpVisionBaseDb.ReturnScalar(strSql) > 0;
        }
    }
    public class MilangoUnit
    {
        public string Bp;
        public string Contract;
        public string UnitCode;
        public string UnitProjectCode;
        public string UnitProjectName;
        public string Status;
        public bool IsMultiTenance;

    }
    public enum MilangoUserStatus
    { active, inactive, blocked }
    public class MilangoBE
    {
        public string BECode = "";
        public string BENameA = "";
        public string BENameE = "";
    }
    public class MilangoUser
    {

        public MilangoUserID user_id = new MilangoUserID();
        public List<MilangoUnit> unit_codes = new List<MilangoUnit>();
        public string status = StatusStrLst[(int)MilangoUserStatus.active];
        public static List<string> StatusStrLst
        {
            get
            {
                List<string> Returned = new List<string>();
                Returned.Add("active");
                Returned.Add("inactive");
                Returned.Add("blocked");
                return Returned;
            }
        }

    }
   public static class MilangoExtensions
    {
        public static MilangoCustomerBiz GetCustomerBiz(this MilangoUser objBiz)
        {
            MilangoCustomerBiz Returned = new MilangoCustomerBiz() { Bp = objBiz.user_id.UserId, Changed = true, ChangesSent = false, ID = 0, MobileNo = objBiz.user_id.PhoneNumber, Name = objBiz.user_id.UserName, No = objBiz.user_id.CustomerNo, Status = 0, UnitCol = new MilangoCustomerUnitCol(true) };
            foreach (MilangoUnit objUnit in objBiz.unit_codes)
                Returned.UnitCol.Add(objUnit.GetCustomerUnitBiz(Returned.Bp));

            return Returned;
        }
        public static MilangoCustomerUnitBiz GetCustomerUnitBiz(this MilangoUnit objBiz,string strBp)
        {
            MilangoCustomerUnitBiz Returned = new MilangoCustomerUnitBiz() { CustomerBp = strBp, UnitChanged = false, UnitChangesSent = true, UnitCode = objBiz.UnitCode, UnitProjectCode = objBiz.UnitProjectCode, UnitProjectName = objBiz.UnitProjectName, UnitStatus = 1 };
            return Returned;
        }
    }
    public class MilangoController : ApiController
    {



        #region SMS
        [HttpPost]
        [AcceptVerbs("GET")]
        public bool SendSMS(string strPhone,string strMSG)
        {
            string strOnline = System.Configuration.ConfigurationManager.AppSettings["OnlineData"];
            if (strOnline == null || strOnline != "0")
                return false;
            string Returned = Send(strPhone, strMSG, "ALMORSHEDY");
            return Returned==null||Returned=="";

        }

        [HttpPost]
        [AcceptVerbs("GET")]
        public List<ROSimple> GetROSimple(string strUserID)
        {

            List<ROSimple> Returned = SAPCustomerContactCol.GetUnitLst(strUserID);
            return Returned;

        }

        [HttpPost]
        [AcceptVerbs("GET")]
        [Route("api/Milango/SendAHUCSMS")]
        [ActionName("SendAHUCSMS")]
        public bool SendAHUCSMS(string strPhone, string strMSG)
        {
            string strOnline = System.Configuration.ConfigurationManager.AppSettings["OnlineData"];
            if (strOnline == null || strOnline != "0")
                return false;
            string Returned = Send(strPhone, strMSG, "AHUC");
            //return SendAHUC(strPhone, strMSG);
            return Returned == null || Returned == "";

        }
        [HttpPost]
        [AcceptVerbs("GET")]
        [Route("api/Milango/SendMCMSMS")]
        [ActionName("SendMCMSMS")]
        public bool SendMCMSMS(string strPhone, string strMSG)
        {
            string strOnline = System.Configuration.ConfigurationManager.AppSettings["OnlineData"];
            if (strOnline == null || strOnline != "0")
                return false;
            string Returned = SendMCM(strPhone, strMSG);
            return Returned==null||Returned=="";

        }
        bool Send1(string PhoneNum,string Msg)
        {
            string ServiceUrl = @"https://mshastra.com/sendurl.aspx?user=ALMORSHEDY&pwd=sb41pepu&senderid=ALMORSHEDY";
            
            string strError = "";
            HttpWebRequest objRequest;
            HttpWebResponse objResponse;
            Stream objStream;
            try
            {

                string strPhoneNum = PhoneNum;
                if (PhoneNum.Length == 11)
                    strPhoneNum = "2" + PhoneNum;

                byte[] bytes = new byte[Msg.Length * sizeof(char)];
                bytes = System.Text.Encoding.Unicode.GetBytes(Msg);
                // System.Buffer.BlockCopy(Msg.ToCharArray(), 0, bytes, 0, bytes.Length);
                UnicodeEncoding uni = new UnicodeEncoding();
                string strMsg = uni.GetString(bytes);

                string strUrl = ServiceUrl;

                //OLD
                //strUrl+= "&Recipients=" + strPhoneNum + "&MessageText=" + Msg;
                if (strPhoneNum.Length <= 15)
                    strUrl = strUrl.Replace("comma", "");
                strUrl += @"&mobileno=" + strPhoneNum + @"&msgtext=" + Msg + @"&priority=High&CountryCode=ALL";


                objRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                objRequest.Timeout = 3 * 60 * 1000;
                objResponse = (HttpWebResponse)objRequest.GetResponse();

                objStream = objResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objStream, Encoding.UTF8);

                string strReply = objReader.ReadToEnd();
                string ProviderID = strReply;
                return true;
            }
            catch (Exception objEx)
            {
                strError = objEx.Message;
                return false;
            }
            //objRequest.RequestUri = strUrl;


        }
        string Send(string PhoneNum, string Msg,string strSenderName)
        {
            if(strSenderName== null || strSenderName=="")
             strSenderName = "MCM";
            string strVersion = "60";

            string strURL = @"https://apis.cequens.com/sms/v1/messages";

            HttpClient objClient = new HttpClient();
            #region PayLoad Data
            System.Collections.Specialized.NameValueCollection objVC = new System.Collections.Specialized.NameValueCollection();
            string strID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);

            objVC.Add("messageText", Msg);
            objVC.Add("senderName", strSenderName);
            objVC.Add("messageType", "text");
            objVC.Add("recipients", PhoneNum);

            #endregion

            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(strURL);


            //request.Method = "POST";
            //request.ContentType = "application/json;charset=iso-8859-1";
            string strData = JsonHelper.BuildJsonFromNVC(objVC);
            byte[] utf8bytes = Encoding.UTF8.GetBytes(strData);
            byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);
            string strToken = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6Ijc3ZjdkNzliYjkxNTBjNzMyYzdiNzEyNmI1YzM3MjllNTcyNDlhMThiZDcwZTUyYjRlNjJkOGE1YjA4YTY4OTYwZWQ2ZDBmYmNjY2M3OTU1ZWY3Y2Q4OTQ3OGQ4ZWQ4MWU0Njg2MzU4NTFkZjQwYmM5YzFjNGUwOGFiMDJlOGIxN2ZjYWU1NDAyNTkzY2Q2ZTZjZDkwNGE4ZDI1YWE1ODUiLCJpYXQiOjE3MDU0ODg4MjksImV4cCI6MzI4MzM2ODgyOX0.hcQIxs88fWOzEU-Es5P-hLSqGqRmwz06NqQYr2t2rgc";
            //request.ContentLength = strData.Length;

            string strTempCredintial = strToken;
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));
            credentials = strTempCredintial;
            //request.Headers.Add("Authorization", "Basic " + credentials);

            //request.ContentLength = iso8859bytes.Length;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Stream postStream;
            // Write request data
            for (int intTemp = 0; intTemp < 4; intTemp++)
            {
                try
                {
                    #region 



                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = utf8bytes.Length;
                    request.Headers.Add("Authorization", credentials);

                    //   request.ContentLength = iso8859bytes.Length;
                    #endregion
                    postStream = request.GetRequestStream();
                    {
                        postStream.Write(utf8bytes, 0, utf8bytes.Length);
                        break;
                    }
                }
                catch (Exception objEx)
                {
                    request = (HttpWebRequest)WebRequest.Create(strURL);
                }
            }
            // Get response
            string strResponse = "";
            HttpWebResponse response1;
            for (int intTemp = 0; intTemp < 2; intTemp++)
            {
                try
                {
                    response1 = request.GetResponse() as HttpWebResponse;
                    {
                        // Get the response stream
                        StreamReader reader = new StreamReader(response1.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));
                        strResponse = reader.ReadToEnd();
                        break;
                    }
                }
                catch (WebException wex)
                {

                }
            }
            if (strResponse != "")
            {
                System.Collections.Specialized.NameValueCollection objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                strResponse = objNameCol["session"];
                if (strResponse != null)
                {
                    objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                    strResponse = objNameCol["id"];
                }
            }
            return strResponse;
        }
        bool SendAHUC(string PhoneNum, string Msg)
        {
            string ServiceUrl = @"https://mshastra.com/sendurl.aspx?user=AlHayah&pwd=1ebp9ujh&senderid=AHUC";

            string strError = "";
            HttpWebRequest objRequest;
            HttpWebResponse objResponse;
            Stream objStream;
            try
            {

                string strPhoneNum = PhoneNum;
                if (PhoneNum.Length == 11)
                    strPhoneNum = "2" + PhoneNum;

                byte[] bytes = new byte[Msg.Length * sizeof(char)];
                bytes = System.Text.Encoding.Unicode.GetBytes(Msg);
                // System.Buffer.BlockCopy(Msg.ToCharArray(), 0, bytes, 0, bytes.Length);
                UnicodeEncoding uni = new UnicodeEncoding();
                string strMsg = uni.GetString(bytes);

                string strUrl = ServiceUrl;

                //OLD
                //strUrl+= "&Recipients=" + strPhoneNum + "&MessageText=" + Msg;
                if (strPhoneNum.Length <= 15)
                    strUrl = strUrl.Replace("comma", "");
                strUrl += @"&mobileno=" + strPhoneNum + @"&msgtext=" + Msg + @"&priority=High&CountryCode=ALL";


                objRequest = (HttpWebRequest)WebRequest.Create(strUrl);
                objRequest.Timeout = 3 * 60 * 1000;
                objResponse = (HttpWebResponse)objRequest.GetResponse();

                objStream = objResponse.GetResponseStream();
                StreamReader objReader = new StreamReader(objStream, Encoding.UTF8);

                string strReply = objReader.ReadToEnd();
                string ProviderID = strReply;
                return true;
            }
            catch (Exception objEx)
            {
                strError = objEx.Message;
                return false;
            }
            //objRequest.RequestUri = strUrl;


        }
        

        string SendMCM(string PhoneNum, string Msg)
        {
            string strSenderName = "MCM";
            string strVersion = "60";
          
            string strURL = @"https://apis.cequens.com/sms/v1/messages";

            HttpClient objClient = new HttpClient();
            #region PayLoad Data
            System.Collections.Specialized.NameValueCollection objVC = new System.Collections.Specialized.NameValueCollection();
            string strID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);

            objVC.Add("messageText",Msg);
            objVC.Add("senderName", strSenderName);
            objVC.Add("messageType", "text");
            objVC.Add("recipients", PhoneNum);
            
            #endregion

            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(strURL);


            //request.Method = "POST";
            //request.ContentType = "application/json;charset=iso-8859-1";
            string strData = JsonHelper.BuildJsonFromNVC(objVC);
            byte[] utf8bytes = Encoding.UTF8.GetBytes(strData);
            byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);
            string strToken = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6Ijc3ZjdkNzliYjkxNTBjNzMyYzdiNzEyNmI1YzM3MjllNTcyNDlhMThiZDcwZTUyYjRlNjJkOGE1YjA4YTY4OTYwZWQ2ZDBmYmNjY2M3OTU1ZWY3Y2Q4OTQ3OGQ4ZWQ4MWU0Njg2MzU4NTFkZjQwYmM5YzFjNGUwOGFiMDJlOGIxN2ZjYWU1NDAyNTkzY2Q2ZTZjZDkwNGE4ZDI1YWE1ODUiLCJpYXQiOjE3MDU0ODg4MjksImV4cCI6MzI4MzM2ODgyOX0.hcQIxs88fWOzEU-Es5P-hLSqGqRmwz06NqQYr2t2rgc";
            //request.ContentLength = strData.Length;
           
            string strTempCredintial =strToken;
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));
            credentials = strTempCredintial;
            //request.Headers.Add("Authorization", "Basic " + credentials);

            //request.ContentLength = iso8859bytes.Length;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Stream postStream;
            // Write request data
            for (int intTemp = 0; intTemp < 4; intTemp++)
            {
                try
                {
                    #region 



                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = utf8bytes.Length;
                    request.Headers.Add("Authorization",credentials);
                   
                 //   request.ContentLength = iso8859bytes.Length;
                    #endregion
                    postStream = request.GetRequestStream();
                    {
                        postStream.Write(utf8bytes, 0, utf8bytes.Length);
                        break;
                    }
                }
                catch (Exception objEx)
                {
                    request = (HttpWebRequest)WebRequest.Create(strURL);
                }
            }
            // Get response
            string strResponse = "";
            HttpWebResponse response1;
            for (int intTemp = 0; intTemp < 2; intTemp++)
            {
                try
                {
                    response1 = request.GetResponse() as HttpWebResponse;
                    {
                        // Get the response stream
                        StreamReader reader = new StreamReader(response1.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));
                        strResponse = reader.ReadToEnd();
                        break;
                    }
                }
                catch (WebException wex)
                {

                }
            }
            if (strResponse != "")
            {
                System.Collections.Specialized.NameValueCollection objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                strResponse = objNameCol["session"];
                if (strResponse != null)
                {
                    objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                    strResponse = objNameCol["id"];
                }
            }
            return strResponse;
        }
        #endregion
        #region GetUser Milango

        [HttpPost]
        [AcceptVerbs("GET")]

        public Object GetToken(string strSecreteKey)
        {




            string strkey = strSecreteKey;//"UWNLIGZKCFJKPQTSAMEHODRYBQPKJFCKkcfjkpq";
            if (!MilangoUserID.CheckSecreteKey(strkey))
                return null;


            string strIssuer = System.Configuration.ConfigurationManager.AppSettings["TokenIssuer"];
            string strAudience = System.Configuration.ConfigurationManager.AppSettings["TokenAudience"];



            strkey += "SAMEH1981";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("UserID", "Milango"));
          

            //permClaims.Add(new Claim("name", "bilal"));

            //Create Security Token object by giving required parameters    

            var token = new JwtSecurityToken(strIssuer, //Issure    
                            strAudience,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddHours(20),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            //System.Web.Security.FormsAuthentication.SetAuthCookie("UserName:Milango", false);
            return new { data = jwt_token };
        }
       // [Authorize]
        [HttpPost]
        [AcceptVerbs("GET")]
        public MilangoUser GetUser(string phone)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new MilangoUser();

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }

            MilangoUser Returned = GetUserSap(phone);// GetUserRE(phone);
            MilangoCustomerBiz objCustomer = Returned.GetCustomerBiz();
            if (objCustomer.Bp != null && objCustomer.Bp != "")
            {
                objCustomer.Add();
            }
            else if(Returned.unit_codes.Count==0)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found"));
            }

            return Returned;
        }

        //[Authorize]
        [HttpPost]
        [AcceptVerbs("GET")]
        public List<MilangoBE> GetProjects()
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new List<MilangoBE>();

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }
            List<MilangoBE> Returned = new List<MilangoBE>();
            ProjectCol objCol = new ProjectCol(false);
            Returned = objCol.Cast<ProjectBiz>().Where(x => x.ID > 0 && x.NameE != null && x.NameE != "").Select(y => new MilangoBE() { BECode = y.Code, BENameA = y.NameA, BENameE = y.NameE }).ToList();

            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return Returned;
        }
        MilangoUser GetUserRE(string phone)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new MilangoUser();

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UserID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }

            if (phone == null || phone == "")
                return new MilangoUser();
            MilangoUser Returned = new MilangoUser();
            CustomerCol objCol = new CustomerCol("", phone,
             "", "", new ProjectCol(true));
            if (objCol.Count > 0)
            {
                foreach (CustomerBiz objCustomer in objCol)
                {
                    Returned = new MilangoUser() { user_id = new MilangoUserID { UserId = "", CustomerNo = "", PhoneNumber = objCustomer.Mobile, UserName = objCustomer.Name }, status = MilangoUser.StatusStrLst[(int)MilangoUserStatus.active] };
                    ReservationCol objReservationCol = objCustomer.ReservationCol;
                    if (objReservationCol.Count == 0)
                        continue;
                    foreach (ReservationBiz objReservationBiz in objReservationCol)
                    {
                        Returned.unit_codes.Add(new MilangoUnit() { UnitCode = objReservationBiz.UnitCodeStr, UnitProjectCode = "", UnitProjectName = objReservationBiz.ProjectFullName });

                    }
                    break;
                }


            }
            return Returned;
        }
        MilangoUser GetUserSap(string phone)
        {
            if (phone == null || phone == "")
                return new MilangoUser();
            //PARTNER,CustomerFullName ,PERSNUMBER,CUSTOMER,IDNUMBER,PhoneNo,BE,ROCode,ContractNo
 

            MilangoUser Returned = new MilangoUser();
            SAPCustomerContactCol objCol = new SAPCustomerContactCol(phone);
            SAPCustomerContactCol objBpCol = new SAPCustomerContactCol(true);
            SAPCustomerContactBiz objBiz = new SAPCustomerContactBiz();
           if(objCol.Count>0)
            {
                objBiz = objCol[0];
                //objBiz.PARTNER = objCol.BPStr;
                foreach (SAPCustomerContactBiz objCOntactBiz in objCol)
                    //if(objCOntactBiz.PARTNER==objBiz.PARTNER )
                    {
                        objBpCol.Add(objCOntactBiz);
                    }
                Returned = new MilangoUser() { user_id = new MilangoUserID() { NationalId=objBiz.IDNUMBER, UserId = objCol.BPStr, CustomerNo = objBiz.CUSTOMER, PhoneNumber = objBiz.PhoneNo, UserName = objBiz.CustomerFullName }, status = MilangoUser.StatusStrLst[(int)MilangoUserStatus.active] };
                Returned.unit_codes = new List<MilangoUnit>();
                foreach (SAPCustomerContactBiz objCustomer in objBpCol)
                    Returned.unit_codes.Add(new MilangoUnit() { Bp=objCustomer.PARTNER,UnitCode = objCustomer.ROCode, UnitProjectCode = objCustomer.BE, UnitProjectName = objCustomer.BE,Contract=objCustomer.ContractNo ,IsMultiTenance=false,Status="Active"});
            }
           
            return Returned;
        }

       
        [HttpPost]
        [AcceptVerbs("GET")]
        [Route("api/Milango/GETCICUser")]
        [ActionName("GETCICUser")]
        public  string GETCICUser(string PhoneNum)
        {
             string strURL = @"http://10.0.4.17:50000/sap/opu/odata/CICRE/MOBILE_PAYMENT_SRV/GetUserSet?sap-client=250";

            HttpClient objClient = new HttpClient();
            #region PayLoad Data
            System.Collections.Specialized.NameValueCollection objVC = new System.Collections.Specialized.NameValueCollection();
            string strID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);

            objVC.Add("PhoneNumber", PhoneNum);

            objVC.Add("Units", "[]");
            objVC.Add("user_Phones", "[]");
            #endregion

            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(strURL);


           
            string strData = JsonHelper.BuildJsonFromNVC(objVC);
            byte[] utf8bytes = Encoding.UTF8.GetBytes(strData);
            #region Security
            byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);
            #region TokenCredintial
            //string strToken = @"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ0b2tlbiI6Ijc3ZjdkNzliYjkxNTBjNzMyYzdiNzEyNmI1YzM3MjllNTcyNDlhMThiZDcwZTUyYjRlNjJkOGE1YjA4YTY4OTYwZWQ2ZDBmYmNjY2M3OTU1ZWY3Y2Q4OTQ3OGQ4ZWQ4MWU0Njg2MzU4NTFkZjQwYmM5YzFjNGUwOGFiMDJlOGIxN2ZjYWU1NDAyNTkzY2Q2ZTZjZDkwNGE4ZDI1YWE1ODUiLCJpYXQiOjE3MDU0ODg4MjksImV4cCI6MzI4MzM2ODgyOX0.hcQIxs88fWOzEU-Es5P-hLSqGqRmwz06NqQYr2t2rgc";
            ////request.ContentLength = strData.Length;

            //string strTempCredintial = strToken;
            //string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));
            //credentials = strTempCredintial;
            #endregion
            #region Basic authentication 
            string strUserName = "payment_int";
            
            string strPass = "S@p987654321";
            string strTempCredintial = $"{strUserName}:{strPass}";
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));
            #endregion
            request.Headers.Add("X-Requested-With", "X");
            //request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");

            request.Headers.Add("Authorization", "Basic " + credentials);
            request.Headers.Add("x-csrf-token", "");
            request.Headers.Add("Cookie", "SAP_SESSIONID_QAS_250=-1ouA7Wyls7hEYiuGBTF8ivQMZaGEhHvgO4AUFacrjI%3d; sap-usercontext=sap-client=250");
            request.ContentLength = iso8859bytes.Length;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            #endregion
            Stream postStream;
            // Write request data
            for (int intTemp = 0; intTemp < 4; intTemp++)
            {
                try
                {
                    #region 



                    request.Method = "POST";
                    //request.ContentType = "application/json";
                    request.ContentType = "application/json;charset=iso-8859-1";
                    request.ContentLength = utf8bytes.Length;
                    request.Headers.Add("Authorization", "Basic "+credentials);
                  
                    //   request.ContentLength = iso8859bytes.Length;
                    #endregion
                    postStream = request.GetRequestStream();
                    {
                        postStream.Write(utf8bytes, 0, utf8bytes.Length);
                        break;
                    }
                }
                catch (Exception objEx)
                {
                    request = (HttpWebRequest)WebRequest.Create(strURL);
                }
            }
            // Get response
            string strResponse = "";
            HttpWebResponse response1;
            for (int intTemp = 0; intTemp < 2; intTemp++)
            {
                try
                {
                    response1 = request.GetResponse() as HttpWebResponse;
                    {
                        // Get the response stream
                        StreamReader reader = new StreamReader(response1.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"));
                        strResponse = reader.ReadToEnd();
                        break;
                    }
                }
                catch (WebException wex)
                {

                }
            }
            if (strResponse != "")
            {
                System.Collections.Specialized.NameValueCollection objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                strResponse = objNameCol["session"];
                if (strResponse != null)
                {
                    objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                    strResponse = objNameCol["id"];
                }
            }
            return strResponse;
        }
        #region Services
        [HttpPost]
        [AcceptVerbs("GET")]
        [Route("api/Milango/GetCategories")]
        [ActionName("GetCategories")]
        public List<ServiceCategory> GetCategories()
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new List<ServiceCategory>();

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }
            List<ServiceCategory> Returned = MilangoService.GetCategories();
            

            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return Returned;
        }
        [HttpPost]
        [AcceptVerbs("GET")]
        [Route("api/Milango/GetItems")]
        [ActionName("GetItems")]
        public List<ServiceItem> GetItems()
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new List<ServiceItem>();

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }
            List<ServiceItem> Returned = MilangoService.GetItems();


            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return Returned;
        }

      [HttpPost]
        [Route("api/Milango/SubmitTicket")]
        [ActionName("SubmitTicket")]
        public int SubmitTicket(int category, int item, string user, DateTime time, string project, string unit, string comment, string imageurl)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return 0;

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }
            int Returned = MilangoService.SubmitTicket(category,item,user, time, project,unit, comment, imageurl);


            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return Returned;
        }
        [HttpGet]
        [Route("api/Milango/GetTicket")]
        [ActionName("GetTicket")]
        public List<MilangoRequestSimple> GetTicket(string strBp)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                

            }
            else
            {
                string strToken = objMsg.Headers.Authorization.ToString();
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }
            MilangoRequestCol objCol = MilangoRequestCol.GetRequestCol(strBp);
            return objCol.SimpleLst;
        }

        #endregion
        #endregion
    }
}

