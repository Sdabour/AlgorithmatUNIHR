 
function SearchCourse() {
    var vrSemester = 0;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
    var vrCourseCode = document.getElementById("txtCourseName").value;
    var vrLevel = 0;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrUser = GetCurrentUser();
    var vrUserID = vrUser.ID;
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/GetAuthorizedCourse";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intUser: vrUserID, strCourseCode: vrCourseCode},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillCourseTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SetCourseData(vrCourseID) {
    ReturnCourse(vrCourseID);
     
}
function SearchExam() {
    var vrSemester = 0;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
    if (document.getElementById("lblSemester") != null && document.getElementById("lblSemester").value != "") {
        vrSemester = JSON.parse(document.getElementById("lblSemester").value).ID;
    }
    var vrCourseCode = "";
    if (document.getElementById("txtCourseName") != null) {
        vrCourseCode = document.getElementById("txtCourseName").value;
    }
    var vrFaculty = GetCurrentFacultyID();
    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrUser = GetCurrentUser();
    var vrUserID = vrUser.ID;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value!="") {
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;

    }
    var vrType = 0;
    vrType = GetExamType();

    var vrServiceUrl = "../api/ControlAPI/GetAuthorizedExam";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intUser: vrUserID, intSemester:vrSemester, intCourse:vrCourseID, intExamType:vrType,intLevel:vrLevel,intFaculty:vrFaculty },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
       
        FillExamTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
} 
function SetExamData(vrExamID)
{
    var vrRegisterationID = 0;
    if (vrExamID != 0) {
        var vrExamStr = document.getElementById("lblExam" + vrExamID).value;
        var vrExam = JSON.parse(vrExamStr);
        ReturnExam(vrExamID);
    }
    else if (document.getElementById("lblCurrentRegisteration") != null || document.getElementById("lblCurrentRegisteration").value != "")//this is in case there is a particular Registeration
    {
         vrRegisterationID = document.getElementById("lblCurrentRegisteration").value;
    }
    var vrFaculty = GetCurrentFacultyID();
    var vrOrderType = 0;
    if (document.getElementById("chkOrderByName")!= null &&document.getElementById("chkOrderByName").checked) { vrOrderType = 1;}
    var vrServiceUrl = "../api/ControlAPI/GetExamRegisteration";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intExam: vrExamID, intOrderType: vrOrderType, intRegisteration:vrRegisterationID,intFaculty:vrFaculty },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status)
    {
        //var vrExamIDs = data.map(x => x.ID);
        //document.getElementById("lblExamIDs").value = JSON.parse(vrExamIDs);
        FillRegisterationExamLst(data);
        if (document.getElementById("myRegExamModal") != null) {
            document.getElementById("myRegExamModal").style.display = "block";
        }
        
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}
function SaveRegisterationExam(vrRegID, vrExamID) {
    var vrID = vrRegID + "-" + vrExamID;
    var vrExam = { ID: 0 };
    if (document.getElementById("lblExam" + vrExamID) != null) {
        var vrExamStr = document.getElementById("lblExam" + vrExamID).value;
        vrExam = JSON.parse(vrExamStr);
    }
    //var vrRegExamStr = document.getElementById("lblRegExam").value;
    var vrUser = GetCurrentUser();

    var vrRegExam = JSON.parse(document.getElementById("lblRegExam" + vrID).value);
    vrRegExam.User = vrUser.ID;
    var vrDegree = Number(document.getElementById("txtDegree" + vrID).value);
    vrRegExam.Degree = vrDegree;
    vrRegExam.Note = document.getElementById("txtNote" + vrID).value;
    var vrChecked = document.getElementById("chkExamWf" + vrID).checked;
    vrRegExam.Status = vrChecked?7:0;
    if (vrRegExam.Degree > vrRegExam.ExamSimple.Grade) {
        alert("الدرجة لا يمكن ان تتجاوز" + vrRegExam.ExamSimple.Grade);
        return;
    }
    var vrEmployeeStr = "";
    if (document.getElementById("lblSelectedEmployee") != null) {  vrEmployeeStr = document.getElementById("lblSelectedEmployee").value;
}
    var vrEmployeeID = 0;
    if (vrEmployeeStr != null && vrEmployeeStr != "") {
        vrEmployeeID = JSON.parse(vrEmployeeStr).ID;

    }
    vrRegExam.EvaluationEmployee = vrEmployeeID;

    var vrServiceUrl = "../api/ControlAPI/UploadRegExamGrade";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrRegExam),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status)
    {
        alert("OK");
        //FillRegisterationExamLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}

function SaveRegisterationExamCol()
{
    
    
    var vrUser = GetCurrentUser();

   
    
    var vrEmployeeStr = document.getElementById("lblSelectedEmployee").value;
    var vrEmployeeID = 0;
    if (vrEmployeeStr != null && vrEmployeeStr != "") {
        vrEmployeeID = JSON.parse(vrEmployeeStr).ID;

    }
    var vrRegExam = { EvaluationUsr: vrUser.ID, EvaluationEmployee: vrEmployeeID, lstExam : GetRegExamLst()};
    //vrRegExam.User = vrUser.ID;
    //vrRegExam.EvaluationEmployee = vrEmployeeID;
    //vrRegExam.lstExam = GetRegExamLst();
    var vrServiceUrl = "../api/ControlAPI/UploadRegExamGrade";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrRegExam),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //FillRegisterationExamLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}
function SaveExam() {
    var vrExam = GetExamData();
    if (vrExam.CourseSimple.ID == 0 || vrExam.SemesterSimple.ID == 0 || vrExam.Type==0) {
        return;
    }
    
    var vrUser = GetCurrentUser();



    /*var vrEmployeeStr = document.getElementById("lblSelectedEmployee").value;*/
    //var vrEmployeeID = 0;
    //if (vrEmployeeStr != null && vrEmployeeStr != "") {
    //    vrEmployeeID = JSON.parse(vrEmployeeStr).ID;

    //}
    vrExam.User = vrUser.ID;
   
    var vrServiceUrl = "../api/ControlAPI/AddEditExam";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrExam),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        try {
            ClearCurrentCourse();
        } catch { }

        //FillRegisterationExamLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function OnRegisterationExamDownloadClick(vrType) {

    if (document.getElementById("lblSelectedExam") == null || document.getElementById("lblSelectedExam").value == "")
        return;

    var vrExam = JSON.parse(document.getElementById("lblSelectedExam").value);
    var vrFaculty = GetCurrentFacultyID(); 
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_RegisterationExamPDF" + "?ExamID=" + vrExam.ID +"&Faculty="+vrFaculty;
    
    //{
    //    vrUrl = vrUrl.replace("UploadFile", "AttachmentIndex");
    //}
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}
function OnExamDownloadClick(vrDetailed) {


    var vrSemester = 0;//

    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;

    var vrFaculty = GetCurrentFacultyID();
    var vrCourse = GetCurrentCourse();
    var vrType = 0;
    vrType = GetExamType();
    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }
  
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_ExamGroupPDF" + "?Semester=" + vrSemester;

    vrUrl += "&Level=" + vrLevel;
    vrUrl += "&ExamType=" + vrType;
    vrUrl += "&Course=" + vrCourse.ID;
    vrUrl += "&Faculty=" + vrFaculty;
    vrUrl += "&Detailed=" + vrDetailed;
    window.location.replace(vrUrl);

    return;
}

function ShowRegisterationExamModal(vrRegID) {
    if (document.getElementById("lblCurrentRegisteration") != null) {
        document.getElementById("lblCurrentRegisteration").value = vrRegID;
        SetExamData(0);
    }
        }
