using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AlgorithmatMN.MN.MNBiz;

using System.Text;
using SharpVision.SAP.SAPBuisness;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using SharpVision.SystemBase;
using System.Web;
using System.Data.SqlClient;
namespace AlgorithmatMVC.Controllers
{
    [Serializable]
    public class PaymentResponse
    {
        public string SessionID;
        public string TransactionID;
        public string Merchant;
    }
    [Serializable]
    public class SimpleStrategy
    {
        public int ID;
        public string Desc;
        public int MonthNo;
        public int ConditionNo;
        public double DownPaymentPerc;
        public string PaymentPeriod;

    }
   public class SimpleROPaymentPlan
    {
        public int ID;
        public string DESC;
        public int ROID;
        public double DownPayment;
        public double Discount;
        public int ConditionCount;
        public double ConditionValue;
    }
    public class SimpleCredit
    {
        public int ROID;
        public int CreditID;
        public string BE;
        public string ROCode;
        public string YearDesc;
        public double InitialValue;
        public double PaidValue;
        public double DiscountValue;
        public double Cost;
        public double Profit;
        public double Closing;
        public double NonCreditedPaidValue;
        public double NonCreditedDiscount;
        public double ValueToBeDevided;
        public List<SimpleROPaymentPlan> PaymentPlanLst = new List<SimpleROPaymentPlan>();
        public List<SimpleCondition> ConditionLst = new List<SimpleCondition>();
    }
    public class SimpleCondition
    {
        public int ID;
        public string Desc;
        public DateTime DueDate;
        public double Value;
        public double TotalPaidValue;
        public double TotalDiscountValue;
        public double RemainingValue;
        public double DueValue;
        public int Allowance;
        public string StatementDesc;
    }
     
    public static class MNExtendMethods
    {
        public static SimpleCredit SimpleCredit(this CreditBiz objCreditBiz,PaymentStrategyCol objStrategyCol)
        {
            CreditConditionCol objConditionCol = new CreditConditionCol(true);
            ROBiz objRo = objCreditBiz.ROBiz;
            SimpleCredit Returned = new SimpleCredit() { Closing = objCreditBiz.Closing, Cost = objCreditBiz.Cost, CreditID = objCreditBiz.ID, DiscountValue = objCreditBiz.DiscountValue, InitialValue = objCreditBiz.CrditInitialValue, NonCreditedDiscount = objRo.NonCreditedDiscountCol.TotalValue, NonCreditedPaidValue = objRo.NonCreditedPaymentCol.TotalValue, PaidValue = objCreditBiz.PaymentValue, Profit = objCreditBiz.BonusValue, YearDesc = objCreditBiz.YearBiz.YearBiz.Desc ,ValueToBeDevided=objRo.ValueToBeDevided,BE=objRo.ProjectCode,ROCode=objRo.Code,ROID=objRo.ID};
            PaymentStrategyCol objCol = objStrategyCol.GetCol("", objCreditBiz);
            if (objCreditBiz.ConditionCol.Count == 0)
            {
                foreach (PaymentStrategyBiz objStrategy in objCol)
                {
                    Returned.PaymentPlanLst.Add(objStrategy.GetRoPaymentPlan(objCreditBiz));
                }
            }
            else
            {
                foreach (CreditConditionBiz objCondition in objCreditBiz.ConditionCol)
                    Returned.ConditionLst.Add(objCondition.SimpleCondition()); 
            }
            return Returned;
        }
        public static SimpleCondition SimpleCondition(this CreditConditionBiz objBiz)
        {
            SimpleCondition Returned = new SimpleCondition() {Desc=objBiz.Desc,DueDate=objBiz.DueDate,ID=objBiz.ID,TotalDiscountValue= objBiz.TotalDiscountValue,TotalPaidValue=objBiz.TotalPaidValue,Value=objBiz.Value
                ,RemainingValue=objBiz.RemainingValue,
                DueValue= objBiz.RecommendedValue,Allowance=objBiz.Allowance,StatementDesc=objBiz.CreditBiz.YearBiz.YearBiz.EndDate.Month.ToString()+"-"+ objBiz.CreditBiz.YearBiz.YearBiz.No.ToString()};
            return Returned;
        }
        public static SimpleStrategy SimpleStrategy(this PaymentStrategyBiz objStrategy)
        {
            SimpleStrategy Returned = new SimpleStrategy() {Desc=objStrategy.Desc,ID=objStrategy.ID,MonthNo= objStrategy.MonthCount};
            List<PaymentStrategyConditionBiz> arrCondition = objStrategy.ConditionCol.Cast<PaymentStrategyConditionBiz>().Where(x => x.MonthNo == 0).ToList();
            Returned.DownPaymentPerc = arrCondition.Count > 0 ? arrCondition[0].Perc : 0;
            Returned.ConditionNo = objStrategy.ConditionCol.Count - 1;
            string strType =Returned.ConditionNo == 0?"" :( (Returned.MonthNo / Returned.ConditionNo) == 3 ? "Q" : ((Returned.MonthNo / Returned.ConditionNo) == 6 ? "S" : ((Returned.MonthNo / Returned.ConditionNo) == 12 ? "A" :((Returned.MonthNo / Returned.ConditionNo) == 1? "M": "N"))));
            Returned.PaymentPeriod = strType;
                return Returned;
        }
        public static SimpleROPaymentPlan GetRoPaymentPlan(this PaymentStrategyBiz objBiz,CreditBiz objCredit)
        {
            SimpleROPaymentPlan Returned = new SimpleROPaymentPlan() { ConditionCount =objBiz.ConditionCount,Discount= objBiz.GetDiscount(objCredit.ROBiz),ConditionValue=objBiz.GetConditionValue(objCredit.ROBiz),DESC=objBiz.Desc,DownPayment=objBiz.GetDownPayment(objCredit.ROBiz),ID=objBiz.ID,ROID=objCredit.ROBiz.ID};

            return Returned;
        }
    }
    public class MaintainancePaymentController : ApiController
    {
        #region Old EMptyFunction
        // GET: api/MaintainancePayment
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MaintainancePayment/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MaintainancePayment
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/MaintainancePayment/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MaintainancePayment/5
        public void Delete(int id)
        {
        }
        #endregion
        [HttpGet]
        public IEnumerable<SimpleStrategy> GetStrategies(string strProjectCode, string strRO)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new List<SimpleStrategy>();

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

            List<SimpleStrategy> Returned = new List<SimpleStrategy>();
            ROBiz objRO = new ROBiz(0, strProjectCode, strRO);
            PaymentStrategyCol objStrategyCol = new PaymentStrategyCol(false);
            objStrategyCol.GetCol("", objRO.MaxCreditBiz);
            objStrategyCol.SetConditionCol();
            Returned = (from objStrategy in objStrategyCol.Cast<PaymentStrategyBiz>()
                        select objStrategy.SimpleStrategy()).ToList();
            return Returned;
        }
       
      
        [Route("api/MaintainancePayment/GetCredit")]
        [ActionName("GetCredit")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public SimpleCredit GetCredit(string strProjectCode, string strRO)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new  SimpleCredit();

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


            SimpleCredit Returned = new SimpleCredit();
            ROBiz objRo = new ROBiz(0,strProjectCode, strRO);
            CreditBiz objCreditBiz = objRo.MaxCreditBiz;
            Returned = objCreditBiz.SimpleCredit(new PaymentStrategyCol(true));
            return Returned;
        }
        //[Authorize]
        [Route("api/MaintainancePayment/GetCreditLst")]
        [ActionName("GetCreditLst")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public List<SimpleCredit> GetCreditLst(string strUserID)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                return new List<SimpleCredit>();

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

            List<ROSimple>
             lstRo = SAPCustomerContactCol.GetUnitLst(strUserID);

            PaymentStrategyCol objSTrategyCol = new PaymentStrategyCol(false);
            CreditCol objCreditCol =new CreditCol(lstRo);
            ROCol objRoCol = objCreditCol.ROCol;
            objCreditCol = objRoCol.LastCreditCol;
            objCreditCol.SetConditionCol();

            List <SimpleCredit> 
Returned = objCreditCol.Cast<CreditBiz>().Select(x => x.SimpleCredit(objSTrategyCol)).ToList();
            return Returned;
        }

        //[Authorize]
        [Route("api/MaintainancePayment/GetCondition")]
        [ActionName("GetCondition")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public List<SimpleCondition> GetCondition(string strProjectCode, string strRO)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new List<SimpleCondition>();

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

            ROBiz objRO = new ROBiz(0, strProjectCode, strRO);
            List<SimpleCondition> Returned = (from objCondition in objRO.ConditionCol.Cast<CreditConditionBiz>()
                                              select objCondition.SimpleCondition()).ToList();
            return Returned;
        }
        //[Authorize]
        [Route("api/MaintainancePayment/GetNewCondition")]
        [ActionName("GetNewCondition")]
        [HttpGet]
        [AcceptVerbs("GET")]
        public List<SimpleCondition> GetNewCondition(int intStrategyID,double dblAdvancedValue,string strProjectCode, string strRO)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new List<SimpleCondition>();

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

            ROBiz objRO = new ROBiz(0, strProjectCode, strRO);
            if (objRO.ID != 0)
                objRO.CreditCol.Add(objRO.MaxCreditBiz);
            
            PaymentStrategyBiz objStrategyBiz = new PaymentStrategyBiz(intStrategyID);
            PaymentStrategyCol objStrategyCol = new PaymentStrategyCol(true);
         
            
            objStrategyCol.Add(objStrategyBiz);
            objStrategyCol.SetConditionCol();
            CreditBiz objCredit = objRO.MaxCreditBiz;

            CreditConditionCol objConditionCol = objCredit.GetConditionCol(dblAdvancedValue, DateTime.Now, objStrategyBiz,false);
            List<SimpleCondition> Returned = (from objCondition in objConditionCol.Cast<CreditConditionBiz>()
                                              select objCondition.SimpleCondition()).ToList();
            return Returned;
        }
     //[Authorize]
        [Route("api/MaintainancePayment/ScheduleCredit")]
        [ActionName("ScheduleCredit")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public string  ScheduleCredit(int intStrategyID, double dblAdvancedValue, string strProjectCode, string strRO)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return "";

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

            ROBiz objRO = new ROBiz(0, strProjectCode, strRO);
            if (objRO.ID != 0)
                objRO.CreditCol.Add(objRO.MaxCreditBiz);

            PaymentStrategyBiz objStrategyBiz = new PaymentStrategyBiz(intStrategyID);
            PaymentStrategyCol objStrategyCol = new PaymentStrategyCol(true);
            objStrategyCol.Add(objStrategyBiz);
            objStrategyCol.SetConditionCol();
            CreditBiz objCredit = objRO.MaxCreditBiz;

            TempSchedulingBiz objScheduling = new TempSchedulingBiz() { AdvancedValue = dblAdvancedValue, Credit = objCredit.ID, RO = objCredit.ROBiz.ID, StartDate = DateTime.Now, Strategy = intStrategyID };
            objScheduling.Add();



            
            string  Returned = objScheduling.TempPaymentRef;
            return Returned;
        }
       //[Authorize]
        [Route("api/MaintainancePayment/PerformScheduling")]
        [ActionName("PerformScheduling")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public List<SimpleCondition> PerformScheduling(string strPaymentRef,string strBankRef)
        {

            HttpRequestMessage objMsg = this.ActionContext.Request;

            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new List<SimpleCondition>() ;

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


            TempMaintainancePaymentBiz objPaymetBiz = new TempMaintainancePaymentBiz(strPaymentRef);
            CreditBiz objCredit = new CreditBiz();
            objPaymetBiz.PerformPayment(strBankRef,out objCredit);
            ROBiz objRO = objCredit.ROBiz;
            objRO.ConditionCol= null;

            List<SimpleCondition> Returned = (from objCondition in objRO.ConditionCol.Cast<CreditConditionBiz>()
                                              select objCondition.SimpleCondition()).ToList();
            return Returned;
        }



       //[Authorize]
        [Route("api/MaintainancePayment/PayACondition")]
        [ActionName("PayACondition")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public string PayACondition(int intConditionID, double dblValue)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;
            
            if(objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return "";

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

            CreditConditionBiz objCondition = new CreditConditionBiz(intConditionID);
            if (objCondition.ID == 0 )//|| !CheckTokenProjectRO(objCondition.CreditBiz.ROBiz.Code, objCondition.CreditBiz.ROBiz.ProjectCode))
                return "";


            ROBiz objRO = objCondition.CreditBiz.ROBiz;
            if (objRO.ID != 0)
                objRO.CreditCol.Add(objRO.MaxCreditBiz);

         
            CreditBiz objCredit = objRO.MaxCreditBiz;

            TempMaintainancePaymentBiz objPayment = new TempMaintainancePaymentBiz() { Condition = intConditionID, Date = DateTime.Now, Desc = objCondition.Desc, InternalRef = objRO.ID, Value = dblValue };

          
            objPayment.Add();




            string Returned = objPayment.TempPaymentRef;
            return Returned;
        }
       
        [Route("api/MaintainancePayment/PayAnAmount")]
        [ActionName("PayAnAmount")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public string PayAnAmount(int intRo, double dblValue)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;
            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
               //return "";

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


            ROBiz objRO = new ROBiz(intRo);
            
            if (objRO.ID == 0)// || !CheckTokenProjectRO(objRO.Code, objRO.ProjectCode))
                return "";


        //    ROBiz objRO = objCondition.CreditBiz.ROBiz;
            if (objRO.ID != 0)
                objRO.CreditCol.Add(objRO.MaxCreditBiz);


            CreditBiz objCredit = objRO.MaxCreditBiz;
            string strDesc = "TestPayment"+"سداد دفعة من الصيانة";
            TempMaintainancePaymentBiz objPayment = new TempMaintainancePaymentBiz() { Condition = 0, Date = DateTime.Now, Desc = strDesc, InternalRef = objRO.ID, Value = dblValue };


            objPayment.Add();




            string Returned = objPayment.TempPaymentRef;
            return Returned;
        }
        //[Authorize]
        [Route("api/MaintainancePayment/PayACreditCondition")]
        [ActionName("PayACreditCondition")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public PaymentResponse PayACreditCondition(string strTransactionID)
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
                string strUser = MaintainancePaymentController.GetClaimValue(strToken, "UserID").Replace("'", "");
                if (strUser != "Milango")
                {
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));

                }
            }

            TempMaintainancePaymentBiz objPayment = new TempMaintainancePaymentBiz(strTransactionID);
            //objPayment.Add();


            if(objPayment.ID==0)
            {
                return new PaymentResponse() { Merchant="",SessionID="",TransactionID=""};
            }

            // string strTransactionID = objPayment.TempPaymentRef;
            string strDesc = objPayment.Desc;
            string strMerchant = "";
            if (strDesc == "")
                strDesc ="Test A Payment : "+ "سداد دفعة صيانة";
           string strSessionID = GetSessionStr(strTransactionID, strDesc, objPayment.Value,out strMerchant);
            PaymentResponse objResponse = new PaymentResponse() { SessionID = strSessionID, TransactionID = strTransactionID ,Merchant=strMerchant};

            return  objResponse ;
        }
        //[Authorize]
        [Route("api/MaintainancePayment/PerformAPayment")]
        [ActionName("PerformAPayment")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public List<SimpleCondition> PerformAPayment(string strPaymentRef, string strBankRef)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;
            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized"));
                return new List<SimpleCondition>();

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

            TempMaintainancePaymentBiz objPaymetBiz = new TempMaintainancePaymentBiz(strPaymentRef);
            CreditBiz objCredit = new CreditBiz();
            objPaymetBiz.PerformPayment(strBankRef, out objCredit);
            ROBiz objRO = objCredit.ROBiz;
            objRO.ConditionCol = null;

            List<SimpleCondition> Returned = (from objCondition in objRO.ConditionCol.Cast<CreditConditionBiz>()
                                              select objCondition.SimpleCondition()).ToList();
            return Returned;
        }
  
        [Route("api/MaintainancePayment/GetROToken")]
        [ActionName("GetROToken")]
        [HttpPost]
        [AcceptVerbs("GET")]
        public Object GetROToken(string strKey,string strProjectCode,string strRo)
        {
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //string json = await client.GetStringAsync(url);
            //string strTemp = HttpWebRequest.
            if(!MilangoUserID.CheckSecreteKey(strKey))
            {
                return new object();
            }
            string strkey = "SAMEHODRYBUWNLIGZKCFJKPQT";
           strkey = System.Configuration.ConfigurationManager.AppSettings["TokenPublicKey"];
            string strIssuer = System.Configuration.ConfigurationManager.AppSettings["TokenIssuer"];
            string strAudience = System.Configuration.ConfigurationManager.AppSettings["TokenAudience"];
       
           
                

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
              
            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
           permClaims.Add(new Claim("RO", strRo));
           permClaims.Add(new Claim("ProjectCode",strProjectCode));
            
            //permClaims.Add(new Claim("name", "bilal"));

            //Create Security Token object by giving required parameters    
        
            var token = new JwtSecurityToken(strIssuer, //Issure    
                            strAudience,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddMinutes(20),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
           System.Web.Security.FormsAuthentication.SetAuthCookie("UserName:Anonymous", false);
            return new { data = jwt_token };
        }



        [Route("api/MaintainancePayment/GetSession")]
        [ActionName("GetSession")]
        [HttpPost]
        [AcceptVerbs("POST")]
        public string GetSession(string strTransactionID, string strDesc, double dblValue)
        {
            string strMerchant = "";
           return GetSessionStr(strTransactionID,strDesc,dblValue,out strMerchant);
        }
        string GetSessionStr(string strTransactionID, string strDesc, double dblValue, out string strMerchant)
        {
            string strVersion = "60";
            strMerchant = "Test770025000101";
            strMerchant = "770025000101";
            string strURL = "https://fabmisr.gateway.mastercard.com/api/rest/version/" + strVersion + @"/merchant/" + strMerchant + "/session";

            HttpClient objClient = new HttpClient();
            #region PayLoad Data
            System.Collections.Specialized.NameValueCollection objVC = new System.Collections.Specialized.NameValueCollection();
            string strID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);
            objVC.Add("apiOperation", "CREATE_CHECKOUT_SESSION");
            objVC.Add("interaction.operation", "PURCHASE");
            objVC.Add("agreement.id", strID);
            objVC.Add("agreement.type", "OTHER");
            objVC.Add("order.currency", "EGP");
            objVC.Add("order.description", HttpUtility.HtmlEncode(strDesc));
            objVC.Add("order.id", strTransactionID);
            objVC.Add("order.amount", dblValue.ToString());
            #endregion

            HttpWebRequest request;
            request= (HttpWebRequest)WebRequest.Create(strURL);


            //request.Method = "POST";
            //request.ContentType = "application/json;charset=iso-8859-1";
            string strData = JsonHelper.BuildJsonFromNVC(objVC);
            byte[] utf8bytes = Encoding.UTF8.GetBytes(strData);
            byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);

            //request.ContentLength = strData.Length;
            string strUserName = "merchant.Test770025000101";
            strUserName = "merchant.770025000101";
            string strPass = "84e0278944c93a3609724d9c9679f686";//test pass 
            strPass = "de257961f9a8a36714ba2a2e2ca781ca";
            string strTempCredintial = $"{strUserName}:{strPass}";
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));

            //request.Headers.Add("Authorization", "Basic " + credentials);

            //request.ContentLength = iso8859bytes.Length;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Stream postStream ;
            // Write request data
            for (int intTemp = 0; intTemp < 4; intTemp++)
            {
                try
                {
                    #region 
                  


                    request.Method = "POST";
                    request.ContentType = "application/json;charset=iso-8859-1";
                    request.ContentLength = strData.Length;
                    request.Headers.Add("Authorization", "Basic " + credentials);
                    request.ContentLength = iso8859bytes.Length;
                    #endregion
                    postStream = request.GetRequestStream();
                    {
                        postStream.Write(iso8859bytes, 0, iso8859bytes.Length);
                        break;
                    }
                }
                catch(Exception objEx) {
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
                objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                strResponse = objNameCol["id"];
            }
            return strResponse;
        }

        string GetSessionStr1(string strTransactionID, string strDesc, double dblValue, out string strMerchant)
        {
            string strVersion = "60";
            strMerchant = "Test770025000101";
           
            string strURL = "https://fabmisr.gateway.mastercard.com/api/rest/version/" + strVersion + @"/merchant/" + strMerchant + "/session";

            HttpClient objClient = new HttpClient();
            #region PayLoad Data
            System.Collections.Specialized.NameValueCollection objVC = new System.Collections.Specialized.NameValueCollection();
            string strID = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);
            objVC.Add("apiOperation", "CREATE_CHECKOUT_SESSION");
            objVC.Add("interaction.operation", "PURCHASE");
            objVC.Add("agreement.id", strID);
            objVC.Add("agreement.type", "OTHER");
            objVC.Add("order.currency", "EGP");
            objVC.Add("order.description", HttpUtility.HtmlEncode(strDesc));
            objVC.Add("order.id", strTransactionID);
            objVC.Add("order.amount", dblValue.ToString());
            #endregion

            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(strURL);


            //request.Method = "POST";
            //request.ContentType = "application/json;charset=iso-8859-1";
            string strData = JsonHelper.BuildJsonFromNVC(objVC);
            byte[] utf8bytes = Encoding.UTF8.GetBytes(strData);
            byte[] iso8859bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), utf8bytes);

            //request.ContentLength = strData.Length;
            string strUserName = "merchant.Test770025000101";
          
            string strPass = "84e0278944c93a3609724d9c9679f686";//test pass 
           
            string strTempCredintial = $"{strUserName}:{strPass}";
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(strTempCredintial));

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
                    request.ContentType = "application/json;charset=iso-8859-1";
                    request.ContentLength = strData.Length;
                    request.Headers.Add("Authorization", "Basic " + credentials);
                    request.ContentLength = iso8859bytes.Length;
                    #endregion
                    postStream = request.GetRequestStream();
                    {
                        postStream.Write(iso8859bytes, 0, iso8859bytes.Length);
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
                objNameCol = JsonHelper.BuildNVCFromJson(strResponse);
                strResponse = objNameCol["id"];
            }
            return strResponse;
        }
        bool CheckTokenProjectRO(string strRO, string strProjectCode)
        {
            HttpRequestMessage objMsg = this.ActionContext.Request;
            if (objMsg.Headers.Authorization == null ||
            !string.Equals(objMsg.Headers.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
            string.IsNullOrEmpty(objMsg.Headers.Authorization.Parameter))
            {
                return false;

            }
           

            string strToken = objMsg.Headers.Authorization.ToString();
            string strTokenRo = GetClaimValue(strToken, "RO").Replace("'","");
            string strTokenProjectCode = GetClaimValue(strToken, "ProjectCode").Replace("'","");
            //if(strRO != strTokenRo|| strProjectCode!= strTokenProjectCode)
            return strRO.ToUpper() == strTokenRo.ToUpper() && strProjectCode.ToUpper() == strTokenProjectCode.ToUpper();
        }
        public static string GetClaimValue(string strToken, string strCalimKey)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = strToken;
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;
            var T = 0;


            string Returned="Milango";
            if(tokenS.ValidTo<DateTime.Now)
            {
                Returned = "";
            }
            else if (tokenS.Claims.Where(x => x.Type == strCalimKey).ToList().Count > 0)
            {
                 Returned = tokenS.Claims.First(claim => claim.Type == strCalimKey).Value;
            }
            return Returned;
        }
         PaymentResponse PayACreditCondition3232(int intRO, int intCredit, int intConditionID, double dblValue)
        {

            CreditBiz objCredit = new CreditBiz();
            string strDesc = "";
            ROBiz objRO = new ROBiz();
            if (intConditionID > 0)
            {
                CreditConditionBiz objCondition = new CreditConditionBiz(intConditionID);
                objCredit = objCondition.CreditBiz;
                strDesc = objCondition.Desc;
            }
            else if (intRO > 0)
            {
                objRO = new ROBiz(intRO);
            }
            else
                objCredit = new CreditBiz(intCredit);
            if (objRO.ID == 0)
                objRO = objCredit.ROBiz;
            if (objRO.ID != 0)
                objRO.CreditCol.Add(objRO.MaxCreditBiz);


            objCredit = objRO.MaxCreditBiz;

            TempMaintainancePaymentBiz objPayment = new TempMaintainancePaymentBiz() { Condition = intConditionID, Date = DateTime.Now, Desc = strDesc, InternalRef = objRO.ID, Value = dblValue };


            objPayment.Add();




            string strTransactionID = objPayment.TempPaymentRef;
            string strMerchant = "";
            if (strDesc == "")
                strDesc = "سداد دفعة صيانة";
            string strSessionID = GetSessionStr(strTransactionID, strDesc, dblValue, out strMerchant);
            PaymentResponse objResponse = new PaymentResponse() { SessionID = strSessionID, TransactionID = strTransactionID, Merchant = strMerchant };

            return objResponse;
        }
    }
}
