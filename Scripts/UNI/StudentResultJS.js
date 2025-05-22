function SearchStudentResult() {
    var vrLevel = 0;
    var vrCode = "";
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = document.getElementById("cmbLevel").value;

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
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/Control/GetStudentResult";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {intFaculty:vrFaculty,
            intStatement: vrStatement, intLevel: vrLevel, strStudentCode: vrCode, intStoppedStatus:vrStoppedStatus
        },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var vrStudentTable = GetStudentResultFullTable(data);
        document.getElementById("dvStudentResult").innerHTML = vrStudentTable;
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;

}

function OnResultSearchDownloadClick(vrIsDetailed) {
    var vrLevel = 0;
    var vrCode = "";
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = document.getElementById("cmbLevel").value;

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
    vrUrl = "../Control/Download_ResultPDF" + "?StatementID=" + vrStatement + "&Level=" + vrLevel + "&StudentCode=" + vrCode +"&StoppedStatus="+vrStoppedStatus+"&Detailed="+vrIsDetailed;
    var vrFaculty = GetCurrentFacultyID();
    vrUrl += "&Faculty=" + vrFaculty;
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}