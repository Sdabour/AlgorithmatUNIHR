var Exam = /** @class */ (function () {
    function Exam() {
        this.CourseSimple = new Course();
        this.SemesterSimple = new Semester();
        this.GroupLst = [];
    }
    return Exam;
}());
function GetExamRow(vrExam) {
    var Returned = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblExam" + vrExam.ID + "\" value='" + JSON.stringify(vrExam) + "'\>" + vrExam.DateStr + "</td>";
    Returned += "<td>" + vrExam.CourseSimple.Code + "</td>";
    Returned += "<td>" + vrExam.CourseSimple.NameA + "</td>";
    Returned += "<td>" + vrExam.Desc + "</td>";
    Returned += "<td>" + vrExam.StartTimeStr + "</td>";
    Returned += "<td>" + vrExam.EndTimeStr + "</td>";
    if (document.getElementById("myExamModal") != null) {
        Returned += "<td><input type='button' value='+' onclick=\"SetExamData(" + vrExam.ID + ")\"\>" + "</td>";
    }
    Returned += "</tr>";
    return Returned;
}
function FillExamTable(lstExam) {
    var vrExamStr = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstExam.length; vrIndex++) {
        /*  vrCourse. = lstExam[vrIndex].CourseID;*/
        if (CheckExamTypeAuthorized(lstExam[vrIndex].Type) && CheckCourseAuthorized(lstExam[vrIndex].CourseSimple)) {
            vrExamStr += GetExamRow(lstExam[vrIndex]);
        }
    }
    vrExamStr += "</table>";
    document.getElementById("tblExam").innerHTML = vrExamStr;
}
function ShowExamModal() {
    document.getElementById('myExamModal').style.display = 'block';
}
function ReturnExam(vrExamID) {
    var vrExam = new Exam();
    var vrExamStr = document.getElementById("lblExam" + vrExamID).value;
    vrExam = JSON.parse(vrExamStr);
    if (document.getElementById("lblSelectedExam") != null) {
        document.getElementById("lblSelectedExam").value = vrExamStr;
    }
    if (document.getElementById("lblSelectedExamCourseCode") != null) {
        document.getElementById("lblSelectedExamCourseCode").innerText = vrExam.CourseSimple.Code;
    }
    if (document.getElementById("lblSelectedExamCourseName") != null) {
        document.getElementById("lblSelectedExamCourseName").innerText = vrExam.CourseSimple.NameA;
    }
    if (document.getElementById("lblSelectedExamDate") != null) {
        document.getElementById("lblSelectedExamDate").innerText = vrExam.Date.toString().substring(1, 10).toString();
    }
    if (document.getElementById("lblSelectedExamDesc") != null) {
        document.getElementById("lblSelectedExamDesc").innerText = vrExam.Desc;
    }
    document.getElementById("lblSelectedExamGrade").innerText = vrExam.Grade.toString();
    if (document.getElementById('myExamModal') != null) {
        document.getElementById('myExamModal').style.display = 'none';
    }
    try {
        SetAddEditExamData(vrExam);
    }
    catch (_a) { }
}
function SetAddEditExamData(vrExam) {
    document.getElementById("dtExamDate").value = vrExam.DateStr;
    document.getElementById("dtStartTime").value = vrExam.StartTimeStr;
    document.getElementById("dtEndTime").value = vrExam.EndTimeStr;
    SetCurrentCourse(vrExam.CourseSimple);
    SetExamType(vrExam.Type);
    if (document.getElementById("txtExamDesc") != null)
        document.getElementById("txtExamDesc").value = vrExam.Desc;
    if (document.getElementById("tblExamGrroup") != null) {
        try {
            GetExamGroupTable(vrExam.GroupLst);
        }
        catch (_a) { }
    }
}
function GetExamData() {
    var Returned = new Exam();
    if (document.getElementById("lblSelectedExam") != null && document.getElementById("lblSelectedExam").value != "") {
        Returned = JSON.parse(document.getElementById("lblSelectedExam").value);
    }
    var vrCourse = GetCurrentCourse();
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return Returned;
    }
    var strSemester = document.getElementById("lblSemester").value;
    var vrSemester = JSON.parse(strSemester);
    Returned.SemesterSimple = vrSemester;
    Returned.CourseSimple = vrCourse;
    Returned.Date = new Date(document.getElementById("dtExamDate").value);
    var vrTimeStr = document.getElementById("dtStartTime").value;
    var vrHour = 0;
    var vrMinute = 0;
    vrHour = Number(vrTimeStr.split(":")[0]);
    vrMinute = Number(vrTimeStr.split(":")[1]);
    Returned.StartTime = new Date();
    Returned.StartTime.setHours(vrHour, vrMinute);
    vrTimeStr = document.getElementById("dtEndTime").value;
    vrHour = 0;
    vrMinute = 0;
    vrHour = Number(vrTimeStr.split(":")[0]);
    vrMinute = Number(vrTimeStr.split(":")[1]);
    Returned.EndTime = new Date();
    Returned.EndTime.setHours(vrHour, vrMinute);
    //Returned.Date = new Date();
    Returned.Desc = document.getElementById("txtExamDesc").value;
    var vrType = GetExamType();
    if (!CheckExamTypeAuthorized(vrType)) {
        alert("ExamType Not Authorized");
        return Returned;
    }
    Returned.Type = vrType;
    Returned.Grade = GetExamTypeDegree(vrType);
    var vrHallStr = "";
    for (var vrIndex = 0; vrIndex < Returned.GroupLst.length; vrIndex++) {
        if (document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString()) != null && document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString()).value != "") {
            vrHallStr = document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString()).value;
            Returned.GroupLst[vrIndex].HallSimple = JSON.parse(vrHallStr);
        }
    }
    return Returned;
}
function GetExamType() {
    var vrType = 0;
    var vrRdLst = GetExamTypeRadioLst();
    for (var vrIndex = 0; vrIndex < vrRdLst.length; vrIndex++) {
        if (document.getElementById(vrRdLst[vrIndex]) != null && document.getElementById(vrRdLst[vrIndex]).checked) {
            vrType = vrIndex + 1;
            break;
        }
    }
    return vrType;
}
function GetExamTypeRadioLst() {
    var vrRdLst = [];
    vrRdLst[vrRdLst.length] = "rdExamTypeMidterm";
    vrRdLst[vrRdLst.length] = "rdExamTypeSemesterWork";
    vrRdLst[vrRdLst.length] = "rdExamTypeOral";
    vrRdLst[vrRdLst.length] = "rdExamTypePractical";
    vrRdLst[vrRdLst.length] = "rdExamTypeFinal";
    vrRdLst[vrRdLst.length] = "rdExamTypeClinical";
    return vrRdLst;
}
function SetExamType(vrType) {
    //var vrType: number = 0;
    var vrRdLst = GetExamTypeRadioLst();
    if (vrType > 0 && document.getElementById(vrRdLst[vrType - 1]) != null) {
        document.getElementById(vrRdLst[vrType - 1]).checked = true;
    }
}
function GetExamTypeStr(vrLectureType, vrExamType) {
    var Returned;
    /* Midterm = 1, SemesterWork = 2, Oral = 3, Practical = 4, Final = 5,Clinical=6*/
    if (vrLectureType == 3) {
        Returned = vrExamType == 1 ? "Midterm" : (vrExamType == 2 ? "Semesterwork" : (vrExamType == 3 ? "Oral" : (vrExamType == 4 ? "Practical" : (vrExamType == 5 ? "Final" : (vrExamType == 6 ? "Clinical" : "Not Specified")))));
    }
    return Returned;
}
function GetExamTypeDegree(vrType) {
    var Returned;
    var vrCourse = GetCurrentCourse();
    if (vrCourse.ID > 0) {
        switch (vrType) {
            case 1:
                Returned = vrCourse.MidtermDegree;
                break;
            case 2:
                Returned = vrCourse.SemesterWorkDegree;
                break;
            case 3:
                Returned = vrCourse.OralDegree;
                break;
            case 4:
                Returned = vrCourse.PracticalDegree;
                break;
            case 5:
                Returned = vrCourse.FinalDegree;
                break;
            case 6:
                Returned = vrCourse.ClinicalDegree;
                break;
            default: Returned = 0;
        }
    }
    return Returned;
}
function CheckExamTypeAuthorized(vrExamType) {
    var Returned = true;
    if (document.getElementById("lblAllExamAuthorized") != null) {
        if (document.getElementById("lblAllExamAuthorized").value == "1") {
            return true;
        }
    }
    if (document.getElementById("lblAssignedType") != null) {
        var vrAssigned = [];
        if (document.getElementById("lblAssignedType").value != "") {
            vrAssigned = JSON.parse(document.getElementById("lblAssignedType").value);
        }
        if (vrAssigned.filter(function (x) { return x == vrExamType; }).length == 0) {
            return false;
        }
    }
    return Returned;
}
//# sourceMappingURL=Exam.js.map