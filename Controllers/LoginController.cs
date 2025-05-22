using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpVision.UMS.UMSBusiness;
using SharpVision.SystemBase;
using System.Web.Security;
using AlgorithmatMVC.Controllers.HRController;
using Newtonsoft.Json;
using SharpVision.HR.HRBusiness;
using AlgorithmatMVC.UNI.UNIBusiness;
namespace AlgorithmatMVC.Controllers
{
    public class LoginController : Controller
    {
        void InitializeConnection()
        {
            #region IntializeConnection
            int intLanguage = 1;
            int intSystem = 6;
            string strSys = System.Configuration.ConfigurationManager.AppSettings["SysID"];
            if (strSys != null)
            {
                int.TryParse(strSys, out intSystem);
            }
            SystemBiz objSystemBiz = new SystemBiz() { ID = intSystem };
            string strLang = Request["Lang"];
            string strConnection = System.Configuration.ConfigurationManager.AppSettings["SVDBCon"];
            string strImage = System.Configuration.ConfigurationManager.AppSettings["ImageURL"];
            SysData.SharpVisionBaseDb = new SharpVision.Base.BaseDataBase.BaseDb(strConnection);
            UserBiz.SetUmsBaseConnection(strConnection, 0);
            SysData.Language = intLanguage;
            #endregion
        }
        // GET: Login
        public ActionResult Index()
        {
            UserBiz objUserBiz = new UserBiz();
            objUserBiz.ID = 1;
            int intFaculty = 0;
            string strFaculty = Request["Faculty"];
            if (strFaculty != null)
                int.TryParse(strFaculty, out intFaculty);
            ViewBag.Faculty = intFaculty;
  return View("LoginHR");
    // return View("LoginUNI");
           
        }
        [HttpPost]
        public ActionResult CheckUser(UserBiz objUserBiz)
        {
           

            InitializeConnection();
            UserBiz objNewUser = new UserBiz();
            string strUserName = Request.Form["Name"];
            //Session[]
            string strPass = Request.Form["Password"];
            string strBranchID = Request.Form["cmbBranch"];
            int intBranch = 0;
            int intFaculty = 0;
            string strFaculty =Request.Form["cmbFaculty"];
            int.TryParse(strFaculty, out intFaculty);
             if(intFaculty==0)
            {
                strFaculty = Request.Form["lblCurrentFaculty"];
                int.TryParse(strFaculty, out intFaculty);
            }
            if (intFaculty == 0)
                intFaculty = 1;
            if (strUserName == null)
                strUserName = "";
            if (strPass == null)
                strPass = "";
            
            if(strUserName == "" || strPass== "" )
                return RedirectToAction("index", "Login");

            UserBiz.CheckUser(strUserName, strPass, out objNewUser);
            if (objNewUser.ID == 0)
               return RedirectToAction("index", "Login");
            else
            {
                
                UserFunctionInstantCol objTempCol = objNewUser.UserFunctionInstantCol;
                if (Session["BranchCol"] != null)
                {
                    UMSBranchBiz objBranchBiz = ((UMSBranchCol)Session["BranchCol"])[strBranchID];
                    Session["Branch"] = objBranchBiz;

                }
                
                Session["CurrentUser"] = objNewUser;
                Session["SectorID"] = null;
                Session["ApplicantCol"] = null;
                Session["SectorSimpleLst"] = null;
                Session["AssignedSectorTable"] = null;
                //SysData.CurrentUser = objNewUser;
                UserSimple objUserSimple = objNewUser.UserSimple;
                objUserSimple.Branch = intBranch;
                bool blAllFacultiesAuthorized = objTempCol.GetIndex(FacultyBiz.UMSAllFaculties) > -1;
                if (SysData.SysID ==21&& !blAllFacultiesAuthorized)
                {
                    AssignmentObjectBiz objAssignmentBiz = new AssignmentObjectBiz(FacultyBiz.FacultyAssignObject);
                    UserObjectAssignmentCol objAssignedCol = objAssignmentBiz.GetAllAssignedObjectCol(objNewUser);
                    List<int> lstIDs = objAssignedCol.Cast<UserObjectAssignmentBiz>().Select(x => x.ObjectValue).ToList();
                    if(lstIDs.Count==0)
                    {
                        intFaculty = 0;
                        return RedirectToAction("index", "Login");
                    }
                    else if(lstIDs.Count==1 || !lstIDs.Contains(intFaculty))
                    {
                        intFaculty = lstIDs[0];
                    }

                }
             
                string strFacultyCol = Request.Form["lblFacultyCol"];

                //FacultyCol objFacultyCol = new FacultyCol(true);
                FacultySimple objSimple = new FacultySimple();
                if (strFacultyCol!=null&& strFacultyCol!="")
                {
                    List<FacultySimple> lstFaculty = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FacultySimple>>(strFacultyCol);
                    if (intFaculty == 0 && lstFaculty.Count>0 &&blAllFacultiesAuthorized)
                    {
                        intFaculty = lstFaculty[0].ID;
                    }
                        objSimple = lstFaculty.Where(x => x.ID == intFaculty).ToList().Count>0? lstFaculty.Where(x => x.ID == intFaculty).ToList()[0]:new FacultySimple();
                      
                   
                }

                if (intFaculty == 0)
                    intFaculty = 1;
                objUserSimple.Faculty = intFaculty;
                Session["CurrentFaculty"] = JsonConvert.SerializeObject(objSimple);
                Session["FacultyID"] = intFaculty;
            string strUser = JsonConvert.SerializeObject(objNewUser.UserSimple);
                FormsAuthentication.SetAuthCookie(objNewUser.Name, false);

                // return RedirectToAction("Index", "Visit");

                // return RedirectToAction("Index", "Unit");
                // return RedirectToAction("Index", "Ticket");
                //UserBiz objTemp = SysData.CurrentUser;
                Session["ApplicantCol"] = null;
         if (ApplicantWorkerEstimationStatementBiz.UMSApplicantEstimationAuthorized )
          {
             return RedirectToAction("Index", "ApplicantWorkerEstimationSearch");
          }
         else
          return RedirectToAction("Index", "Home");
            }

            
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            //EmployeeSectorAssignmentCol.AssignedSectorTable = null;
            return View("LoginUNI");
            //return View("LoginHR");
            // return View("Index");
        }
        public ActionResult ChangePasswordIndex()
        {
            return View("ChangePassword");
        }
        public ActionResult ChangePassword()
        {
            
            if (SysData.CurrentUser != null && SysData.CurrentUser.ID != 0)
            {
                UserBiz objUserBiz = new UserBiz();
                string strOldPassWord = Request.Form["txtOldPassword"];
                string strPassword = Request.Form["txtNewPassword"];
                objUserBiz = SysData.CurrentUser;
                objUserBiz.EditPassword(strPassword);
            }

            return View("LoginHR");
        }
        [Authorize]
        public ActionResult DsiplayUserLst()
        {
            return View("CreateUserLst");
        }
        [Authorize]
        public ActionResult CreateUser()
        {
            string strAppID = Request["AppID"];
            int intApp = 0;
            int.TryParse(strAppID,out intApp);
            ApplicantWorkerBiz objAppBiz = new ApplicantWorkerBiz(intApp);
            if (objAppBiz.User != 0)
            {
                objAppBiz.UserBiz = new UserBiz(objAppBiz.User);
            }
            ViewBag.ApplicantWorker = objAppBiz;
            return View("CreateUser");
        }
        [Authorize]
        [HttpPost]
      
        public ActionResult SaveUser()
        {
            int intAppID = 0;
            string strUserName = Request.Form["Name"];
            string strPassWord = Request.Form["Password"];
            string strTemp = Request.Form["lblUser"];
            int intUser = 0;
            int.TryParse(strTemp, out intUser);
             strTemp = Request.Form["lblApp"];
            int.TryParse(strTemp, out intAppID);
            UserBiz objUserBiz = new UserBiz(intUser);
            objUserBiz.ID = intUser;
           
            objUserBiz.Password = strPassWord;
            if (intUser == 0)
            {
                objUserBiz.Name = strUserName;
                objUserBiz.FullName = strUserName;
            }
                int intGroup = 105;//التقييمات
            if (objUserBiz.ID != 0 && objUserBiz.GroupID != 0 && objUserBiz.GroupID != 105)
            {
                List<UserGroupBiz> lstGroup = (objUserBiz.GroupCol.Cast<UserGroupBiz>().Where(x => x.GroupID == 105)).ToList();
                if (lstGroup.Count == 0)
                {
                    objUserBiz.GroupCol.Add(new UserGroupBiz() { UserID = intUser, IsPermanent = true, GroupID = intGroup, GroupBiz = new GroupBiz() { ID = intGroup }, StartDate = DateTime.Now });
                    if (objUserBiz.GroupBiz.ID == 0)
                        objUserBiz.GroupBiz = new GroupBiz() { ID = intGroup };
                }

            }
            else
            {
                objUserBiz.GroupBiz = new GroupBiz() { ID = intGroup };
                objUserBiz.GroupID = intGroup;
            }
            objUserBiz.EmployeeBiz = new EmployeeBiz() { ID = intAppID };
            if (objUserBiz.ID == 0)
                objUserBiz.Add();
            else
                objUserBiz.Edit();
            return View("CreateUserLst");

        }

    }
}