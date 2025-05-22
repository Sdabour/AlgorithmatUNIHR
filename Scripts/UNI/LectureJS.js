

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

        data: { intFaculty: vrFaculty, intUser: vrUserID, strCourseCode: vrCourseCode },
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
function RefreshQR() {
    var vrLecture = GetCurrentLecture();
    if (vrLecture.ID == 0)
        return;
    var vrServiceUrl = "../api/ControlAPI/GetLectureQR";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intLectureID:vrLecture.ID },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        document.getElementById("imgQR").src = data;
        setTimeout(RefreshQR, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        setTimeout(RefreshQR, 30000);

    }
    return false;
}

 
function SearchLecture() {
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
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != null && document.getElementById("lblSelectedCourse").value != "") {
        var vrCourse = JSON.parse(document.getElementById("lblSelectedCourse").value);
        vrCourseID = vrCourse.ID;

    }
    var vrType = 0;
     
    var vrStudent = 0;
    var vrTeacher = 0;
    var vrSection = 0;
    var vrIsDateRange = false;
    var vrStartDate = new Date();
    var vrEndDate = new Date();
    var vrSearch = { intUser: vrUserID, intFaculty: vrFaculty, intSemester: vrSemester, intStudent: vrStudent, intType: vrType, intCourse: vrCourseID, intProf: vrTeacher, intSection: vrSection, blIsDateRange: vrIsDateRange, dtStart: vrStartDate, dtEnd: vrEndDate };
    var vrSearchStr = JSON.stringify(vrSearch);
    var vrServiceUrl = "../api/ControlAPI/SearchLecture";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data:vrSearchStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

        document.getElementById("tblLectureSearch").innerHTML =GetLectureTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown)
    {
        var vrMsg = errorThrown;
    }
    return false;
}
function SetLectureRegisterationData(vrLectureID) {
    if (vrLectureID == 0) { return; }
    var vrOrderType = 0;
    if (document.getElementById("chkOrderByName") != null &&document.getElementById("chkOrderByName").checked) { vrOrderType = 1; }
    var vrServiceUrl = "../api/ControlAPI/GetLectureRegisteration";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intLecture: vrLectureID, intOrderType: vrOrderType },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        //var vrLectureIDs = data.map(x => x.ID);
        //document.getElementById("lblLectureIDs").value = JSON.parse(vrLectureIDs);
        FillRegisterationLectureLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}
function SaveRegisterationLecture(vrRegID, vrLectureID) {
    var vrID = vrRegID + "-" + vrLectureID;

    var vrLectureStr = document.getElementById("lblLecture" + vrLectureID).value;
    var vrLecture = JSON.parse(vrLectureStr);
    //var vrRegLectureStr = document.getElementById("lblRegLecture").value;
    var vrUser = GetCurrentUser();

    var vrRegLecture = JSON.parse(document.getElementById("lblRegLecture" + vrID).value);
    vrRegLecture.User = vrUser.ID;
    var vrDegree = Number(document.getElementById("txtDegree" + vrID).value);
    vrRegLecture.Degree = vrDegree;
    vrRegLecture.Note = document.getElementById("txtNote" + vrID).value;
    if (vrRegLecture.Degree > vrRegLecture.LectureSimple.Grade) {
        alert("الدرجة لا يمكن ان تتجاوز" + vrRegLecture.LectureSimple.Grade);
        return;
    }
    var vrEmployeeStr = document.getElementById("lblSelectedEmployee").value;
    var vrEmployeeID = 0;
    if (vrEmployeeStr != null && vrEmployeeStr != "") {
        vrEmployeeID = JSON.parse(vrEmployeeStr).ID;

    }
    vrRegLecture.EvaluationEmployee = vrEmployeeID;

    var vrServiceUrl = "../api/ControlAPI/UploadRegLectureGrade";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrRegLecture),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //FillRegisterationLectureLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}

function SaveRegisterationLectureCol() {


    var vrUser = GetCurrentUser();



    var vrEmployeeStr = document.getElementById("lblSelectedEmployee").value;
    var vrEmployeeID = 0;
    if (vrEmployeeStr != null && vrEmployeeStr != "") {
        vrEmployeeID = JSON.parse(vrEmployeeStr).ID;

    }
    var vrRegLecture = { EvaluationUsr: vrUser.ID, EvaluationEmployee: vrEmployeeID, lstLecture: GetRegLectureLst() };
    //vrRegLecture.User = vrUser.ID;
    //vrRegLecture.EvaluationEmployee = vrEmployeeID;
    //vrRegLecture.lstLecture = GetRegLectureLst();
    var vrServiceUrl = "../api/ControlAPI/UploadRegLectureGrade";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrRegLecture),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //FillRegisterationLectureLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}

function SaveLecture() {
    var vrLecture = GetLectureData();
    if (vrLecture.CourseSimple.ID == 0 || vrLecture.SemesterSimple.ID == 0 || vrLecture.Type == 0) {
        return;
    }

    var vrUser = GetCurrentUser();



    /*vrLecture.TeacherSimple = GetCurrentTeatcher();*/

    var vrServiceUrl = "../api/ControlAPI/AddEditLecture";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrLecture),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        try {
            ClearCurrentCourse();
        } catch { }
        SetSelectedLectureData(data);
        SetLectureRegisterationData(data.ID);
        //FillRegisterationLectureLst(data);
        
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function OnRegisterationLectureDownloadClick(vrType) {

    if (document.getElementById("lblSelectedLecture") == null || document.getElementById("lblSelectedLecture").value == "")
        return;

    var vrLecture = JSON.parse(document.getElementById("lblSelectedLecture").value);
    var vrFaculty = GetCurrentFacultyID();
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_RegisterationLecturePDF" + "?LectureID=" + vrLecture.ID + "&Faculty=" + vrFaculty;

    //{
    //    vrUrl = vrUrl.replace("UploadFile", "AttachmentIndex");
    //}
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}
function OnLectureDownloadClick(vrDetailed) {


    var vrSemester = 0;//

    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;

    var vrFaculty = GetCurrentFacultyID();
    var vrCourse = GetCurrentCourse();
    var vrLectureType = 0;
    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }

    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_LectureGroupPDF" + "?Semester=" + vrSemester;

    vrUrl += "&Level=" + vrLevel;
    vrUrl += "&LectureType=" + vrLectureType;
    vrUrl += "&Course=" + vrCourse.ID;
    vrUrl += "&Faculty=" + vrFaculty;
    vrUrl += "&Detailed=" + vrDetailed;
    window.location.replace(vrUrl);

    return;
}


