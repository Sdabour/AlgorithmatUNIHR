var Lecture = /** @class */ (function () {
    function Lecture() {
    }
    return Lecture;
}());
function GetLectureRow(vrLecture) {
    var Returned = "";
    var Returned = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblLecture" + vrLecture.ID + "\" value='" + JSON.stringify(vrLecture) + "'\>" + vrLecture.DateStr + "</td>";
    Returned += "<td>" + vrLecture.CourseSimple.Code + "</td>";
    Returned += "<td>" + vrLecture.CourseSimple.NameA + "</td>";
    Returned += "<td>" + vrLecture.TeacherSimple.Name + "</td>";
    Returned += "<td>" + vrLecture.StartTimeStr + "</td>";
    Returned += "<td>" + vrLecture.EndTimeStr + "</td>";
    if (document.getElementById("myLectureSearchModal") != null) {
        Returned += "<td><input type='button' value='+' onclick=\"ReturnLecture(" + vrLecture.ID.toString() + ");RefreshQR();SetLectureRegisterationData(" + vrLecture.ID.toString() + ");\"\>" + "</td>";
    }
    return Returned;
}
function GetLectureTable(lstLecture) {
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstLecture.length; vrIndex++) {
        vrTable += GetLectureRow(lstLecture[vrIndex]);
    }
    vrTable += "</table>";
    return vrTable;
}
function CheckLectureData() {
    var Returned = true;
    var vrCourse = GetCurrentCourse();
    if (vrCourse.ID == 0) {
        alert("حدد الكورس");
        return false;
    }
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return false;
    }
    if (document.getElementById("cmbLectureType") == null || document.getElementById("cmbLectureType").value == "0") {
        alert("حدد نوع المحاضرة");
        return false;
    }
    var vrTeacher;
    vrTeacher = GetCurrentTeatcher();
    if (vrTeacher.ID == 0) {
        alert("حدد المحاضر");
        return false;
    }
    return Returned;
}
function GetLectureData() {
    var Returned = new Lecture();
    var vrCourse = GetCurrentCourse();
    var strSemester = document.getElementById("lblSemester").value;
    var vrSemester = JSON.parse(strSemester);
    Returned.SemesterSimple = vrSemester;
    Returned.CourseSimple = vrCourse;
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
    Returned.Date = new Date();
    /*    Returned.EndTime = new Date((<HTMLInputElement>document.getElementById("dtEndTime")).value);*/
    /* Returned.Desc = (<HTMLInputElement>document.getElementById("txtLectureDesc")).value;*/
    var vrType = Number(document.getElementById("cmbLectureType").value);
    Returned.TypeSimple = new LectureType();
    Returned.TypeSimple.ID = vrType;
    Returned.TeacherSimple = GetCurrentTeatcher();
    return Returned;
}
function ShowLectureModal() {
    document.getElementById('myLectureModal').style.display = 'block';
}
function ReturnLecture(vrLectureID) {
    var vrLecture = new Lecture();
    var vrLectureStr = document.getElementById("lblLecture" + vrLectureID).value;
    vrLecture = JSON.parse(vrLectureStr);
    SetSelectedLectureData(vrLecture);
}
function SetSelectedLectureData(vrLecture) {
    var vrLectureStr = JSON.stringify(vrLecture);
    document.getElementById("lblSelectedLecture").value = vrLectureStr;
    document.getElementById("lblSelectedLectureCourseCode").innerText = vrLecture.CourseSimple.Code;
    document.getElementById("lblSelectedLectureCourseName").innerText = vrLecture.CourseSimple.NameA;
    document.getElementById("lblSelectedLectureDate").innerText = vrLecture.Date.toString().substring(1, 10).toString();
    if (document.getElementById("myLectureSearchModal") != null) {
        document.getElementById('myLectureSearchModal').style.display = 'none';
    }
}
function GetCurrentLecture() {
    var vrLecture = new Lecture();
    vrLecture.ID = 0;
    if (document.getElementById("lblSelectedLecture") == null || document.getElementById("lblSelectedLecture").value == "") {
        return vrLecture;
    }
    var vrLectureStr = document.getElementById("lblSelectedLecture").value;
    vrLecture = JSON.parse(vrLectureStr);
    return vrLecture;
}
function GetRegisterationLectureRow(vrReg, vrIndex) {
    var Returned = "";
    var vrID = vrReg.ID.toString();
    Returned += "<tr>";
    Returned += "<td>" + vrIndex + "<input type=\"hidden\" id=\"lblRegLecture" + vrID + "\" value='" + JSON.stringify(vrReg) + "' />" + "</td>";
    Returned += "<td><input type=\"checkBox\" id=\"chkSelected" + vrID + "\"  onchange=\"CheckLectureReg(" + vrID + ");\" />" + "</td>";
    Returned += "<td>" + vrReg.StudentCode + "</td>";
    Returned += "<td>" + vrReg.StudentName + "</td>";
    /* Returned += "<td><input type=\"button\" class=\"form-control\" id=\"btnSaveReg" + vrReg.ID + "\" value=\"حفظ\" onclick=\"SaveRegisterationLecture(" + vrReg.ID + "," + vrReg.ID + ")\"/></td>";*/
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationLectureLst(lstReg) {
    var vrIDs = [];
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstReg.length; vrIndex++) {
        if (document.getElementById("txtFilter") == null || document.getElementById("txtFilter").value == "" || lstReg[vrIndex].StudentName.indexOf(document.getElementById("txtFilter").value) != -1 || lstReg[vrIndex].StudentCode.indexOf(document.getElementById("txtFilter").value) != -1)
            vrTable += GetRegisterationLectureRow(lstReg[vrIndex], vrIndex + 1);
        vrIDs[vrIDs.length] = lstReg[vrIndex].ID.toString();
    }
    vrTable += "</table>";
    document.getElementById("tblReg").innerHTML = vrTable;
    document.getElementById("lblLectureIDs").value = JSON.stringify(vrIDs);
}
function CheckLectureReg(vrID) {
    if (document.getElementById("chkSelected") != null) {
    }
}
function CheckAllLectureRegisteration() {
    var vrChecked = false;
    if (document.getElementById("chkSelectAll") == null)
        return;
    vrChecked = document.getElementById("chkSelectAll").checked;
    var arrReg = [];
    if (document.getElementById("lblRegIDs") != null && document.getElementById("lblRegIDs").value != "") {
        arrReg = JSON.parse(document.getElementById("lblRegIDs").value);
    }
}
//# sourceMappingURL=Lecture.js.map