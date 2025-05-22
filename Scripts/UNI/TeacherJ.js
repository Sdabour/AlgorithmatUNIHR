function SearchSimpleTeacher() {
    var vrTeacherType = 0;
    var vrCode = "";
    if (document.getElementById("cmbTeacherType") != null) {
        vrTeacherType = document.getElementById("cmbTeacherType").value;

    }
    if (document.getElementById("txtTeacherName") != null) {
        vrCode = document.getElementById("txtTeacherName").value;

    }
    var vrFaculty = GetCurrentFacultyID();
    var vrServiceUrl = "../api/Control/GetTeacher";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {
            intFaculty: vrFaculty, intType: vrTeacherType, strTeacherCode: vrCode
        },
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var vrTeacherTable = GetTeacherFullTable(data);
        document.getElementById("tblTeacher").innerHTML = vrTeacherTable;
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;

}