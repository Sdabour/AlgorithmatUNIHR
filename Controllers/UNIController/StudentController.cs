using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.UMS.UMSBusiness;
using AlgorithmatMVC.UNI.UNIBusiness;
using SharpVision.SystemBase;
using System.Web.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Newtonsoft.Json;

namespace AlgorithmatMVC.Controllers.UNIController
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CheckStudent(StudentBiz objUserBiz)
        {


            //InitializeConnection();
            UserBiz objNewUser = new UserBiz();
            string strUserName = Request.Form["Name"];
            //Session[]
            string strPass = Request.Form["Password"];
           
            int intFaculty = 0;
            string strFaculty = Request.Form["cmbFaculty"];
            int.TryParse(strFaculty, out intFaculty);
            if (intFaculty == 0)
            {
                strFaculty = Request.Form["lblCurrentFaculty"];
                int.TryParse(strFaculty, out intFaculty);
            }
            if (strUserName == null)
                strUserName = "";
            if (strPass == null)
                strPass = "";

            if (strUserName == "" || strPass == "")
                return RedirectToAction("StudentLogIn", "Student");

            UserBiz.CheckUser(strUserName, strPass, out objNewUser);
            if (objNewUser.ID == 0)
                return RedirectToAction("index", "Login");
            else
            {

                UserFunctionInstantCol objTempCol = objNewUser.UserFunctionInstantCol;
                

                Session["CurrentUser"] = objNewUser;
                //SysData.CurrentUser = objNewUser;
                UserSimple objUserSimple = objNewUser.UserSimple;
                
                bool blAllFacultiesAuthorized = objTempCol.GetIndex(FacultyBiz.UMSAllFaculties) > -1;
                if (!blAllFacultiesAuthorized)
                {
                    AssignmentObjectBiz objAssignmentBiz = new AssignmentObjectBiz(FacultyBiz.FacultyAssignObject);
                    UserObjectAssignmentCol objAssignedCol = objAssignmentBiz.GetAllAssignedObjectCol(objNewUser);
                    List<int> lstIDs = objAssignedCol.Cast<UserObjectAssignmentBiz>().Select(x => x.ObjectValue).ToList();
                    if (lstIDs.Count == 0)
                    {
                        intFaculty = 0;
                        return RedirectToAction("index", "Login");
                    }
                    else if (lstIDs.Count == 1 || !lstIDs.Contains(intFaculty))
                    {
                        intFaculty = lstIDs[0];
                    }

                }

                string strFacultyCol = Request.Form["lblFacultyCol"];

                //FacultyCol objFacultyCol = new FacultyCol(true);
                FacultySimple objSimple = new FacultySimple();
                if (strFacultyCol != null && strFacultyCol != "")
                {
                    List<FacultySimple> lstFaculty = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FacultySimple>>(strFacultyCol);
                    if (intFaculty == 0 && lstFaculty.Count > 0 && blAllFacultiesAuthorized)
                    {
                        intFaculty = lstFaculty[0].ID;
                    }
                    objSimple = lstFaculty.Where(x => x.ID == intFaculty).ToList().Count > 0 ? lstFaculty.Where(x => x.ID == intFaculty).ToList()[0] : new FacultySimple();


                }

                objUserSimple.Faculty = intFaculty;
                Session["CurrentFaculty"] = JsonConvert.SerializeObject(objSimple);

                string strUser = JsonConvert.SerializeObject(objNewUser.UserSimple);
                FormsAuthentication.SetAuthCookie(strUser, true);

                // return RedirectToAction("Index", "Visit");

                // return RedirectToAction("Index", "Unit");
                // return RedirectToAction("Index", "Ticket");
                //UserBiz objTemp = SysData.CurrentUser;
                                   return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        [AcceptVerbs("GET")]

        public Object GetToken(string strSecreteKey,string strStudentMail,string strPass,string strName,string strCode)
        {




            string strkey = strSecreteKey;//"UWNLIGZKCFJKPQTSAMEHODRYBQPKJFCKkcfjkpq";
            if (!MilangoUserID.CheckSecreteKey(strkey))
                return null;


            string strIssuer = System.Configuration.ConfigurationManager.AppSettings["TokenIssuer"];
            string strAudience = System.Configuration.ConfigurationManager.AppSettings["TokenAudience"];




            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(strkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            //permClaims.Add(new Claim("RO", strRo));
            //permClaims.Add(new Claim("ProjectCode", strProjectCode));

            //permClaims.Add(new Claim("name", "bilal"));

            //Create Security Token object by giving required parameters    

            var token = new JwtSecurityToken(strIssuer, //Issure    
                            strAudience,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddHours(20),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            System.Web.Security.FormsAuthentication.SetAuthCookie("UserName:Milango", false);
            return new { data = jwt_token };
        }
    }
}