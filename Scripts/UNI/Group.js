var RegisterationGroup = /** @class */ (function () {
    function RegisterationGroup() {
        this.Faculty = new Faculty();
        this.Course = new Course();
        this.Semester = new Semester();
        this.LectureType = new LectureType();
        this.StudentIDLst = [];
    }
    return RegisterationGroup;
}());
function GetRegisterationGroupData() {
    var Returned = new RegisterationGroup();
    var vrCourse = GetCurrentCourse();
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return Returned;
    }
    var strSemester = document.getElementById("lblSemester").value;
    var vrSemester = JSON.parse(strSemester);
    Returned.Semester = vrSemester;
    Returned.Course = vrCourse;
    Returned.Faculty = new Faculty();
    Returned.Faculty.ID = GetCurrentFacultyID();
    Returned.LectureType = new LectureType();
    Returned.ExamType = GetExamType();
    var vrLectureType = 0;
    if (document.getElementById("cmbLectureType") != null) {
        vrLectureType = Number(document.getElementById("cmbLectureType").value);
        Returned.LectureType.ID = vrLectureType;
    }
    Returned.NameA = document.getElementById("txtRegisterationGroupNameA").value;
    return Returned;
}
function GetRegisterationGroupRow(vrRegisterationGroup) {
    var Returned = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblRegisterationGroup" + vrRegisterationGroup.ID + "\" value='" + JSON.stringify(vrRegisterationGroup) + "'\>" + vrRegisterationGroup.ID + "</td>";
    Returned += "<td>" + vrRegisterationGroup.LectureType.NameA + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.Code + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.NameA + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.NameE + "</td>";
    Returned += "<td>" + vrRegisterationGroup.NameA + "</td>";
    Returned += "<td>" + GetExamTypeStr(vrRegisterationGroup.LectureType.ID, vrRegisterationGroup.ExamType) + "</td>";
    /*  Returned += "<td>" + vrRegisterationGroup.Code + "</td>";*/
    var vrTemp = "ReturnRegisterationGroup(" + vrRegisterationGroup.ID + ");";
    if (document.getElementById("myRegisterationGroupStudentModal") == null && document.getElementById("tblGroupReg") != null) {
        vrTemp += "SetRegisterationGroupDataByID(" + vrRegisterationGroup.ID + ");";
    }
    if (document.getElementById("tblExamGrroup") == null && document.getElementById("tblGroupReg") == null) {
        vrTemp += " FillRegisterationGroupStudentData(" + vrRegisterationGroup.ID + "); ";
    }
    else {
        vrTemp += "ReturnNewExamGroup(" + vrRegisterationGroup.ID.toString() + ")";
    }
    //if (document.getElementById("tblSelectedRegisterationGroup") != null)
    //    vrTemp = "if(CheckRegisterationGroupValidation()){AddRegisterationGroupToSelectedTable(" + vrRegisterationGroup.ID + ");}";
    Returned += "<td><input type='button' value='+' onclick=\"" + vrTemp + "\"\>" + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationGroupTable(vrGroupLst) {
    var Returned = "";
    Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrGroupLst.length; vrIndex++) {
        Returned += GetRegisterationGroupRow(vrGroupLst[vrIndex]);
    }
    Returned += "</table>";
    document.getElementById("tblRegisterationGroup").innerHTML = Returned;
}
function ReturnRegisterationGroup(vrGroupID) {
    var vrGroupStr = document.getElementById("lblRegisterationGroup" + vrGroupID.toString()).value;
    var vrGroup = JSON.parse(vrGroupStr);
    //checking Search Page
    if (document.getElementById("myRegisterationGroupStudentModal") == null) {
        SetSelectedRegisterationGroupData(vrGroup);
    }
}
function SetSelectedRegisterationGroupData(vrGroup) {
    if (document.getElementById("lblSelectedGroup") != null) {
        document.getElementById("lblSelectedGroup").value = JSON.stringify(vrGroup);
    }
    if (document.getElementById("lblSelectedGroupCourseCode") != null) {
        document.getElementById("lblSelectedGroupCourseCode").innerText = vrGroup.Course.Code;
    }
    if (document.getElementById("lblSelectedGroupCourseNameA") != null) {
        document.getElementById("lblSelectedGroupCourseNameA").innerText = vrGroup.Course.NameA;
    }
    if (document.getElementById("lblSelectedGroupCourseNameE") != null) {
        document.getElementById("lblSelectedGroupCourseNameE").innerText = vrGroup.Course.NameE;
    }
    if (document.getElementById("lblSelectedGroupNameA") != null) {
        document.getElementById("lblSelectedGroupNameA").innerText = vrGroup.NameA;
    }
}
function GetCurrentGroup() {
    var Returned = new RegisterationGroup();
    if (document.getElementById("lblSelectedGroup") != null && document.getElementById("lblSelectedGroup").value != "") {
        Returned = JSON.parse(document.getElementById("lblSelectedGroup").value);
        Returned.StudentIDLst = [];
        if (document.getElementById("lblRegIDs") != null && document.getElementById("lblRegIDs").value != "") {
            var vrIDs = JSON.parse(document.getElementById("lblRegIDs").value);
            for (var vrIndex = 0; vrIndex < vrIDs.length; vrIndex++) {
                if (document.getElementById("chkSelectedReg" + vrIDs[vrIndex].toString()).checked) {
                    Returned.StudentIDLst[Returned.StudentIDLst.length] = vrIDs[vrIndex];
                }
            }
        }
    }
    return Returned;
}
function ReturnNewExamGroup(vrGroupID) {
    var vrRegisterationGroup = new RegisterationGroup();
    if (document.getElementById("lblRegisterationGroup" + vrGroupID.toString()) != null) {
        vrRegisterationGroup = JSON.parse(document.getElementById("lblRegisterationGroup" + vrGroupID.toString()).value);
    }
    var vrExam = new Exam();
    vrExam.GroupLst = [];
    var vrExamStr = document.getElementById("lblSelectedExam").value;
    if (vrExamStr != "") {
        vrExam = JSON.parse(vrExamStr);
        if (vrExam.GroupLst == null || vrExam.GroupLst.length == 0) {
            vrExam.GroupLst = [];
        }
        var vrExamGroup = new ExamGroup();
        vrExamGroup.GroupSimple = vrRegisterationGroup;
        vrExam.GroupLst[vrExam.GroupLst.length] = vrExamGroup;
        document.getElementById("lblSelectedExam").value = JSON.stringify(vrExam);
        GetExamGroupTable(vrExam.GroupLst);
    }
    if (document.getElementById("myRegisterationGroupModal") != null) {
        document.getElementById("myRegisterationGroupModal").style.display = "none";
    }
}
//# sourceMappingURL=Group.js.map