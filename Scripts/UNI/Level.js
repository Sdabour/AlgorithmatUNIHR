var Level = /** @class */ (function () {
    function Level() {
        this.lstStudent = [];
        this.lstCourse = [];
    }
    return Level;
}());
function GetLevelBivot() {
    var Returned = "<table class=\"table\"><tr><th></th> <th colspan=\"2\">Student</th>";
    //Returned += "<th>Points</th>";
    Returned += "<th>CGPA</th>";
    Returned += "<th>E.Hours</th>";
    var vrLevelStr = document.getElementById("lblLevel").value;
    var lstLevel = JSON.parse(vrLevelStr);
    var vrLevelIndex = document.getElementById("cmbLevel").value;
    var vrLevel = lstLevel[Number(vrLevelIndex)];
    var vrCourseLst = vrLevel.lstCourse;
    var vrCourse;
    for (var vrIndex = 0; vrIndex < vrCourseLst.length; vrIndex++) {
        vrCourse = vrCourseLst[vrIndex];
        Returned += "<th colspan=\"2\">" + vrCourse.NameA + "</th>";
    }
    Returned += "</tr>";
    var vrStudentName = document.getElementById("txtName").value;
    if (vrStudentName == null || vrStudentName == undefined)
        vrStudentName = "";
    var vrStudentLst = vrLevel.lstStudent.filter(function (x) { return vrStudentName == "" || x.NameA.indexOf(vrStudentName) != -1 || x.Code.indexOf(vrStudentName) != -1; });
    var vrStudent;
    for (var vrIndex = 0; vrIndex < vrStudentLst.length; vrIndex++) {
        vrStudent = vrStudentLst[vrIndex];
        Returned += GetStudentPivotTableRow(vrStudent, vrCourseLst);
    }
    Returned += "</table>";
    return Returned;
}
function FillLevel() {
    var vrTable = GetLevelBivot();
    document.getElementById("dvLevel").innerHTML = vrTable;
    return false;
}
function GetLevel(intLevel) {
    var Returned = new Level();
    if (document.getElementById("lblAllLevel") != null && document.getElementById("lblAllLevel").value != "") {
        var vrLevelLst = JSON.parse(document.getElementById("lblAllLevel").value);
        var vrLst = vrLevelLst.filter(function (x) { return x.Level == intLevel; });
        if (vrLst.length > 0)
            Returned = vrLst[0];
    }
    return Returned;
}
function GetMaxRegisterationCreditHour(vrStudent, vrSemester) {
    var vrLevel = GetLevel(vrStudent.LastGrade);
    var Returned = 0;
    if (vrSemester.Type == 1) {
        Returned = vrLevel.SemesterType1MaxLimitedHour;
    }
    else if (vrSemester.Type == 2) {
        Returned = vrLevel.SemesterType2MaxLimitedHour;
    }
    else if (vrSemester.Type == 3) {
        Returned = vrLevel.SemesterType3MaxLimitedHour;
    }
    if (vrStudent.LastGrade > 1 && vrStudent.MaxResultCPoints < 1 && Returned > vrLevel.LowGPALimitedHour) {
        Returned = vrLevel.LowGPALimitedHour;
    }
    //if(vrStudent.Level==)
    return Returned;
}
//# sourceMappingURL=Level.js.map