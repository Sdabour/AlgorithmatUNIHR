function SearchCourse() {
    SearchAllCourse();
}
function SearchAllCourse() {
    var vrSemester = 0;//document.getElementById("cmbSemester").value;
    //var vrStudentCode = document.getElementById("txtName").value;
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

        data: { intFaculty:vrFaculty, intSemester: vrSemester, strCourseCode: vrCourseCode, intLevel:vrLevel },
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

