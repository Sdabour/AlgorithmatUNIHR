 
 
function SearchStudent() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null) {
        SearchSingleStudent();
        return;
    }
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);
    
    var vrSemester = vrSemesterObj.ID;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrLevel = 0;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null &&document.getElementById("lblSelectedCourse").value != "")
    {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;
    }
    if (vrCourseID == 0)
        return;
    var vrFaculty = GetCurrentFacultyID();
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/GetCourseRecommededStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intSemester: vrSemester, intCourse: vrCourseID, strStudentCode:vrStudentCode },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}


function SearchCourse() {
    if (document.getElementById("dvRegisteredCourse") == null) {
        try {
            SearchAllCourse();
            return;
        } catch {
            SearchAllCourse1();
            return;
        }
    }
    if (document.getElementById("lblSelectedStudent") == null || document.getElementById("lblSelectedStudent").value== "")
        return;
    var vrStudent = JSON.parse(document.getElementById("lblSelectedStudent").value);
    var vrSemester = 0;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
    var vrCourseCode = document.getElementById("txtCourseName").value;
   
    var vrLevel = 0;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/GetStudentRecommendedCourses";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intStudent: vrStudent.ID, strCourseCode: vrCourseCode },
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

function GetCourseRegistredStudent() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrLevel = 0;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;
    }
    if (vrCourseID == 0)
        return;
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/GetCourseRegisteredStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intSemester: vrSemester, intCourse: vrCourseID, strStudentCode: vrStudentCode },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillRegisteredStudentTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function UploadRegisterationStudent() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
     
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;
    }
    if (vrCourseID == 0)
        return;
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    if (vrStudentStr == null || vrStudentStr == "")
        return;
    var vrStudentLst = JSON.parse(vrStudentStr);
    var vrUser = GetCurrentUser();
    var vrFaculty = GetCurrentFacultyID();
    var vrReg = { intUser: vrUser.ID, intCourse: vrCourseID, intSemester: vrSemester, lstStudent: vrStudentLst,FacultyID:vrFaculty };

    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/UploadRegisteredStudent";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrReg),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentTable(data);
        alert("OK");
        //GetStudentSemesterRegisteration();
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function UploadRegisterationCourse() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;

    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    //var vrCourseID = 0;
    var vrCourseLst=[];
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
         vrCourseLst = JSON.parse(document.getElementById("lblSelectedCourse").value);
        
    }
    if (vrCourseLst.length == 0)
        return;
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    if (vrStudentStr == null || vrStudentStr == "")
        return;
    var vrStudent = JSON.parse(vrStudentStr);
    var vrStudentLst = [];
    var vrAllowedHour = document.getElementById("lblSemesterAllowedHour").innerText;
    if (vrAllowedHour == "" || vrAllowedHour == "0")
        return;
    var vrSemesterHour = document.getElementById("lblSemesterHour").innerText;
    if (vrSemesterHour == "" || vrSemester == "0")
        return;
    if (parseInt(vrSemesterHour) > parseInt(vrAllowedHour)) {
        alert("عدد الساعات المسموح لا يمكن ان يتجاوز " + vrAllowedHour);
        return;
    }
    var vrUser = GetCurrentUser();
    var vrFaculty = GetCurrentFacultyID();
    var vrReg = { intUser: vrUser.ID, intCourse: 0, intSemester: vrSemester, lstStudent: vrStudentLst, intStudent: vrStudent.ID, lstCourse:vrCourseLst,FacultyID : vrFaculty };
    /*var vrStudentCode = document.getElementById("txtStudentName").value;*/
    var vrServiceUrl = "../api/ControlAPI/UploadRegisteredStudent";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrReg),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        //FillStudentTable(data);
        // setTimeout(OnMSG, 30000);
        alert("OK");
        GetStudentSemesterRegisteration();
        OnRegisterationDownloadClick(0);

    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SetCourseData(vrCourseID)
{
    ReturnCourse(vrCourseID);
    GetCourseRegistredStudent();
}
function GetRegistrationExamStudent() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
   
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;
    }
    if (vrCourseID == 0)
        return;
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/GetCourseRegisteredStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intSemester: vrSemester, intCourse: vrCourseID, strStudentCode: vrStudentCode },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillRegisteredStudentTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function UploadRegisterationEQ() {
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;

    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrCourseID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseStr = document.getElementById("lblSelectedCourse").value;
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;
    }
    if (vrCourseID == 0) {
        alert("حدد الcourse المعادل ");
        return;
    }
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    if (vrStudentStr == null || vrStudentStr == "")
        return;

    var vrStudent = JSON.parse(vrStudentStr);
    var vrUser = GetCurrentUser();
    var vrValue = document.getElementById("txtFinalValue").value;
    var vrEQNameA = document.getElementById("txtEQNameA").value;
    var vrEQNameE = document.getElementById("txtEQNameE").value;
    if ((vrEQNameA == null || vrEQNameA == "") && (vrEQNameE == null || vrEQNameE == "")) {
        alert("يجب تحديد اسم الEQ Course");
        return;
    }
    if (vrValue == null || vrValue == ""||vrValue==0) {
        alert("يجب تحديد درجة ال EQ Course");
        return;
    }
    var vrUniStr = document.getElementById("lblSelectedUniversty").value;
    if (vrUniStr == "") {
        alert("يجب تحديد الجامعة");
        return;
    }
    var vrUni = JSON.parse(vrUniStr);
    if (vrUni.ID == 0) {
        alert("يجب تحديد الجامعة");
        return;
    }
    var vrUniID = vrUni.ID;

    var vrReg = { intUser: vrUser.ID, intCourse: vrCourseID, intSemester: vrSemester, intStudent: vrStudent.ID, dblEQFinalDegree: vrValue, strEQNameA: vrEQNameA, strEQNameE: vrEQNameE ,intUni:vrUniID};
    if (!CheckCourseRegisteration(vrReg)) {
        alert("تم تسجيل الطالب فى نفس ال course ");
        return;
    }
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/UploadRegisterationEQ";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrReg),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}

function CheckCourseRegisteration(vrReg) {
    var Returned = false;
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrServiceUrl = "../api/ControlAPI/CheckRegisterationEQ";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async:false
        ,
        data: JSON.stringify(vrReg),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        Returned= data ==true;
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        //return false;
    }
    return Returned;
}
function CheckCourseValidation() {
    return true;
}
function GetStudentSemesterRegisteration() {
    if (document.getElementById("dvRegisteredCourse") == null)
        return;
    if (document.getElementById("lblSemester") == null || document.getElementById("lblSemester").value == null)
        return;
    var vrSemesterObj = JSON.parse(document.getElementById("lblSemester").value);

    var vrSemester = vrSemesterObj.ID;
     
   
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    if (document.getElementById("lblSelectedStudent") == null || document.getElementById("lblSelectedStudent").value == "")
        return;
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    if (vrStudentStr == null || vrStudentStr == "")
        return;
    var vrStudent = JSON.parse(document.getElementById("lblSelectedStudent").value);
   
    var vrUser = GetCurrentUser();
   
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/GetStudentAllSemester";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty ,intStudent: vrStudent.ID },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var vrSemesterLst = data.filter(x => x.ID == vrSemesterObj.ID);
        var vrSemesterCourseLst = [];
        var vrCourseLst = [];
        for (var vrSIndex = 0; vrSIndex < data.length; vrSIndex++) {
            for (var vrRegIndex = 0; vrRegIndex < data[vrSIndex].lstRegisteration.length; vrRegIndex++)
            {
                vrCourseLst[vrCourseLst.length] = data[vrSIndex].lstRegisteration[vrRegIndex];
            }
        }
        if (vrSemesterLst.length > 0) {
            vrSemesterCourseLst = vrSemesterLst[0].lstRegisteration;
        }
        var vrTable = GetSemesterRegisteration(data, vrSemester);
        //lblRegisteredCourses
        document.getElementById("lblSelectedCourse").value = JSON.stringify([]);
        FillSelectedCourseTable();
        if (document.getElementById("tblCourse") != null) {
            document.getElementById("tblCourse").innerHTML = "";
         //   FillSelectedCourseTable();
        }
            //lblSelectedCourse
        document.getElementById("lblRegisteredCourses").value = JSON.stringify(vrSemesterCourseLst);

        document.getElementById("lblAllRegisteredCourses").value = JSON.stringify(vrCourseLst);
        var vrLimitedHour = GetMaxRegisterationCreditHour(vrStudent, vrSemesterObj);
        var vrAllowed = GetMaxRegisterationCreditHour(vrStudent, vrSemesterObj);

        document.getElementById("lblSemesterAllowedHour").innerText = vrAllowed;
        var vrCH = GetTotalRegisterationHour();
        
        document.getElementById("dvRegisteredCourse").innerHTML = vrTable;
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function DeleteRegisteration(vrRegisteration) {
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/DeleteRegisteration";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intRegisteration: vrRegisteration ,intFaculty:vrFaculty},
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


function OnRegisterationDownloadClick(vrType) {

    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    var vrFaculty = GetCurrentFacultyID();
    if (vrStudentStr == null || vrStudentStr == "")
        return;
    var vrStudent = JSON.parse(vrStudentStr);
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_RegisterationPDF" + "?StudentID=" + vrStudent.ID;
    if (vrType != null) {
        vrUrl += "&ReportType=" + vrType;
    }
    vrUrl += "&Faculty="+vrFaculty;
    //{
    //    vrUrl = vrUrl.replace("UploadFile", "AttachmentIndex");
    //}
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}
function OnRegisterationSearchDownloadClick(vrType) {
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    var vrStudentObj = {ID:0};
    if (vrStudentStr != null && vrStudentStr != "") {
        vrStudentObj = JSON.parse(vrStudentStr);
    }
    var vrCourseStr = document.getElementById("lblSelectedCourse").value;

    var vrCourseObj = { ID:0 };
    if (vrCourseStr != null && vrCourseStr != "") {
        vrCourseObj = JSON.parse(vrCourseStr);

    }
    var vrSemester = 0;

    if (document.getElementById("cmbSemester") != null) {
        vrSemester = document.getElementById("cmbSemester").value;

    }
    else {
        var vrSemesterObj = GetCurrentSemester();
        if (vrSemesterObj.ID > 0) {
            vrSemester = vrSemesterObj.ID;
        }
    }

    var vrPostStatus = 0;
    if (document.getElementById("chkPosted") != null) {
        vrPostStatus = document.getElementById("chkPosted").checked ? 1 : 0;
    }
    var vrPreInc = false;
    if (document.getElementById("chkPreInc") != null) {
        vrPreInc = document.getElementById("chkPreInc").checked;
    }
    var vrSelected = false;
    if (document.getElementById("chkSelected") != null) {
        vrSelected = document.getElementById("chkSelected").checked;
    }

    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);
    }
    var vrCourseLevel = 0;
    if (document.getElementById("cmbCourseLevel") != null) {
        vrCourseLevel = Number(document.getElementById("cmbCourseLevel").value);
    }


    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_RegisterationPDF" + "?StudentID=" + vrStudentObj.ID+"&CourseID="+vrCourseObj.ID +"&Semester="+vrSemester;
    if (vrType != null) {
        vrUrl += "&ReportType=" + vrType;
    }
    if (vrLevel != 0) {
        vrUrl += "&Level=" + vrLevel;
    }
    if (vrCourseLevel != 0) {
        vrUrl += "&CourseLevel=" + vrCourseLevel;
    }
    if (vrPostStatus != 0) {
        vrUrl += "&PostStatus=" + vrPostStatus;
    }
    if (vrPreInc) {
        vrUrl += "&PreInc=1";
    }
    if (vrSelected) {
        vrUrl += "&Selected=1";
    }
    //{
    //    vrUrl = vrUrl.replace("UploadFile", "AttachmentIndex");
    //}
    var vrFaculty = GetCurrentFacultyID();
    vrUrl += "&Faculty=" + vrFaculty;
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}
function SearchSingleStudent() {
    var vrLevel = 0;
    var vrCode = "";
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = document.getElementById("cmbLevel").value;

    }
    if (document.getElementById("txtName") != null) {
        vrCode = document.getElementById("txtName").value;

    }
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/Control/GetStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {
            intFaculty: vrFaculty, intLevel: vrLevel, strStudentCode: vrCode
        },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var vrStudentTable = GetStudentFullTable(data);
        document.getElementById("dvStudent").innerHTML = vrStudentTable;
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;

}
function SearchRegisteration() {
    var vrSemester = 0;
     
    if (document.getElementById("cmbSemester") != null) {
        vrSemester = document.getElementById("cmbSemester").value;

    }
    
    var vrStudent = 0;
    if (document.getElementById("lblSelectedStudent") != null && document.getElementById("lblSelectedStudent").value !="") {
        var vrStudentObj = JSON.parse(document.getElementById("lblSelectedStudent").value);
        vrStudent = vrStudentObj.ID;
    }
    var vrCourse = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseObj = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourse = vrCourseObj.ID;
    }
    var vrPostStatus = 0;
    if (document.getElementById("chkPosted") != null) {
        vrPostStatus = document.getElementById("chkPosted").checked ? 1 : 0;
    }
    var vrPreInc = false;
    if (document.getElementById("chkPreInc") != null) {
        vrPreInc = document.getElementById("chkPreInc").checked ;
    }

    var vrIncludePre = false;
    if (document.getElementById("chkIncludePre") != null) {
        vrIncludePre = document.getElementById("chkIncludePre").checked;
    }

    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);
    }
    var vrCourseLevel = 0;
    if (document.getElementById("cmbCourseLevel") != null) {
        vrCourseLevel = Number(document.getElementById("cmbCourseLevel").value);
    }
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/Control/GetRegisteration";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {
            intFaculty: vrFaculty,
            intSemester: vrSemester, intStudent: vrStudent,
            intLevel: vrLevel,
intCourseLevel:vrCourseLevel
, intCourse: vrCourse, intPostStatus: vrPostStatus, blPreInc: vrPreInc,blIncludePre:vrIncludePre
        },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var vrRegisterationTable = GetRegisterationSimpleTable(data);
        document.getElementById("dvRegisteration").innerHTML = vrRegisterationTable;
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;

}

function SearchRegisterationEdit() {
    var vrSemester = 0;

    
    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;

    var vrStudent = 0;
    if (document.getElementById("lblSelectedStudent") != null && document.getElementById("lblSelectedStudent").value != "") {
        var vrStudentObj = JSON.parse(document.getElementById("lblSelectedStudent").value);
        vrStudent = vrStudentObj.ID;
    }
    var vrCourse = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourseObj = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourse = vrCourseObj.ID;
    }
    var vrPostStatus = 0;
    var vrFaculty = GetCurrentFacultyID();
    if (vrSemester == 0 || vrCourse == 0) {
        return;
    }
    var vrServiceUrl = "../api/Control/GetRegisteration";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {
            intFaculty: vrFaculty,
            intSemester: vrSemester, intStudent: vrStudent, intCourse: vrCourse, intPostStatus: vrPostStatus
        },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var vrRegisterationTable = GetRegisterationEditTable(data);
        document.getElementById("dvRegisteration").innerHTML = vrRegisterationTable;
        var vrIDs = data.map(x => x.ID);
        document.getElementById("lblIDs").value = JSON.stringify(vrIDs);

        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;

}

function SaveRegisterationSimple(vrRegID) {
    if (!CheckRegisterationStudentEdit(vrRegID)) {
        alert("فضلا راجع البيانات");
        return;

    }
    var vrReg = GetRegisterationByIDEditData(vrRegID);
    var vrUser = GetCurrentUser();
    vrReg.UserID = vrUser.ID;
    UploadRegisterationSimple(vrReg);
}
function SaveRegisterationCol() {


   

 
    if (!CheckRegisterationLst()) {
        alert("فضلا راجع البيانات");
        return;
    }
    var lstReg = GetRegisterationLst();
   
    UploadRegisterationLst(lstReg);
   
    return false;


}
function UploadRegisterationLst(lstReg)
{
    var vrUser = GetCurrentUser();
    var vrReg = { UserID: vrUser.ID, lstReg: lstReg};
    var vrServiceUrl = "../api/ControlAPI/UploadRegCol";
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
}
function UploadRegisterationSimple(vrReg) {
    var vrRegisteration = vrReg;

    if (vrRegisteration.ID == 0) {
        return;
    }
    //return;
    var vrRegistrationStr = JSON.stringify(vrRegisteration);

    var vrServiceUrl = "../api/ControlAPI/EditRegisteration";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: vrRegistrationStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        alert("OK");
        // setTimeout(OnAlert, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        document.getElementById("lblMessageCount").innerText = "";
        //setTimeout(OnHandShake, 30000);
    }

    return false;
}

function SearchAllCourse1() {
    var vrSemester = 0; 
    var vrCourseCode = document.getElementById("txtCourseName").value;
    var vrLevel = 0;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/GetCourse";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intSemester: vrSemester, strCourseCode: vrCourseCode, intLevel: vrLevel },
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