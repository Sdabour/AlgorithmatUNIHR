

function UpladRegisteration() {
    var vrRegisteration = GetRegisterationEditData();

    if (vrRegisteration.ID == 0)
    {
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
function FillSemesterCourse() {
    var vrSemester = document.getElementById("cmbSemester").value;
    var vrStudentCode = document.getElementById("txtName").value;
    var vrCourseCode = document.getElementById("txtCourseName").value;

    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/ControlAPI/GetSemesterCourse";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty,intSemester: vrSemester, strStudentCode:vrStudentCode, strCourseCode:vrCourseCode },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status)
    {
        var vrCourseTable = GetCoursePivotTable(data);
        document.getElementById("dvCourse").innerHTML = vrCourseTable;
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
     
    }
    return false;
}
function SearchSimpleStudent() {
   
   
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrLevel = 0;
    
    var vrStudentCode = document.getElementById("txtStudentName").value;
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/Control/GetStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intLevel:vrLevel, strStudentCode: vrStudentCode },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentSimpleTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SearchStudent() {
    var vrLevel = 0;
    var vrCode = "";
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = document.getElementById("cmbLevel").value;

    }
    if (document.getElementById("txtName") != null) {
        vrCode = document.getElementById    ("txtName").value;

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
            intFaculty:vrFaculty,intLevel: vrLevel, strStudentCode: vrCode
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
function OnStudentSearchDownloadClick(vrIsDetailed) {
    var vrLevel = 0;
    var vrCode = "";
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = document.getElementById("cmbLevel").value;

    }
    var vrOnlySelected = 0;
    if (document.getElementById("chkSelectedOnly") != null) {
        vrOnlySelected = document.getElementById("chkSelectedOnly").checked ? 1 : 0;
    }
    if (document.getElementById("txtName") != null) {
        vrCode = document.getElementById("txtName").value;

    }
    var vrStoppedStatus = 0;
    if (document.getElementById("rdStoppedNotStopped") != null && document.getElementById("rdStoppedNotStopped").checked) {
        vrStoppedStatus = 2;
    }
    if (document.getElementById("rdStoppedStopped") != null && document.getElementById("rdStoppedStopped").checked) {
        vrStoppedStatus = 1;
    }
    var vrStatement = 0;
    if (document.getElementById("lblStatement") != null && document.getElementById("lblStatement").value != "") {
        vrStatement = JSON.parse(document.getElementById("lblStatement").value).ID;
    }
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_StudentPDF" + "?StatementID=" + vrStatement + "&Level=" + vrLevel + "&StudentCode=" + vrCode + "&StoppedStatus=" + vrStoppedStatus + "&Detailed=" + vrIsDetailed;
    var vrFaculty = GetCurrentFacultyID();
    vrUrl += "&Faculty=" + vrFaculty;
    vrUrl += "&OnlySelected="+vrOnlySelected;
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}