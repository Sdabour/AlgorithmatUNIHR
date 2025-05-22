var Course = /** @class */ (function () {
    function Course() {
        this.GradeLst = [];
    }
    return Course;
}());
function GetCoursePivotTableRow(objBiz, objGradeCol) {
    var Returned = "<tr>";
    Returned += "<td>" + objBiz.Code + "</td>";
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + objBiz.NameA + "</label></td>";
    Returned += "<td>" + objBiz.RegisterationNo + "</td>";
    var vrCOMMONGrade;
    var vrGradeLst = [];
    var vrTempCOMMONGrade;
    var vrLbl = "";
    for (var vrIndex = 0; vrIndex < objGradeCol.length; vrIndex++) {
        vrCOMMONGrade = objGradeCol[vrIndex];
        vrGradeLst = objBiz.GradeLst.filter(function (x) { return x.Verbal == vrCOMMONGrade.Verbal; });
        vrLbl = objBiz.ID.toString() + "-" + vrIndex.toString();
        vrTempCOMMONGrade = new COMMONGrade();
        if (vrGradeLst.length > 0)
            vrTempCOMMONGrade = vrGradeLst[0];
        Returned += "<td>";
        if (vrGradeLst.length > 0) {
            Returned += "<input type=\"hidden\" id=\"" + vrLbl + "\" value='" + JSON.stringify(vrTempCOMMONGrade) + "'>";
            Returned += "<input type=\"button\" value=\"" + vrTempCOMMONGrade.Verbal + "\"  onclick=\"ShowGradeRegisterationModal('" + vrLbl + "')\"/>";
        }
        Returned += "</td>";
        Returned += "<td>";
        if (vrGradeLst.length > 0) {
            Returned += vrTempCOMMONGrade.RegisterationLst.length;
        }
        Returned += "</td>";
    }
    Returned += "</tr>";
    return Returned;
}
function GetCOMMONGradeLst(lstCourse) {
    var Returned = [];
    for (var vrCourseIndex = 0; vrCourseIndex < lstCourse.length; vrCourseIndex++) {
        for (var vrGradeIndex = 0; vrGradeIndex < lstCourse[vrCourseIndex].GradeLst.length; vrGradeIndex++) {
            if (Returned.filter(function (x) { return x.Verbal == lstCourse[vrCourseIndex].GradeLst[vrGradeIndex].Verbal; }).length == 0)
                Returned[Returned.length] = lstCourse[vrCourseIndex].GradeLst[vrGradeIndex];
        }
    }
    return Returned;
}
function GetCoursePivotTable(objCourseLst) {
    var lstGrade = GetCOMMONGradeLst(objCourseLst);
    var Returned = "<table class=\"table\">";
    Returned += "<tr><th></th><th></th><th></th>";
    for (var vrGradeIndex = 0; vrGradeIndex < lstGrade.length; vrGradeIndex++) {
        Returned += "<th></th>";
        Returned += "<th>" + lstGrade[vrGradeIndex].Verbal + "</th>";
    }
    Returned += "</tr>";
    for (var vrCourseIndex = 0; vrCourseIndex < objCourseLst.length; vrCourseIndex++) {
        Returned += GetCoursePivotTableRow(objCourseLst[vrCourseIndex], lstGrade);
    }
    Returned += "</table>";
    return Returned;
}
function ShowGradeRegisterationModal(vrLbl) {
    var vrGrade = JSON.parse(document.getElementById(vrLbl).value);
    var lstRegisteration = vrGrade.RegisterationLst;
    var vrRegisterationStr = GetRegistrationLstTable(lstRegisteration);
    //myRegisterationModal,
    //(<HTMLElement>document.getElementById("lblSemesterDesc")).innerText = vrStudentBiz.lstSemester[0].Desc;
    var vrTable = "";
    vrTable = "<div class=\"form-row\">" +
        "<div class=\"col-2\">" +
        "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.Verbal + "</label></div>";
    vrTable += "<div class=\"col-1\">" +
        "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">عدد</label></div>";
    vrTable += "<div class=\"col-1\">" +
        "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst.length + "</label></div>";
    if (vrGrade.RegisterationLst.length > 0) {
        vrTable += "<div class=\"col-3\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseCode + "</label></div>";
        vrTable += "<div class=\"col-3\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseName + "</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">CH</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseSimple.CreditHour + "</label></div>";
    }
    //dvOldSemester
    vrTable += "<div class=\"table-responsive\">" +
        "<table class=\"table\">";
    vrTable += GetRegistrationStudentLstTable(vrGrade.RegisterationLst);
    vrTable += "</table></div>";
    document.getElementById("dvSemester").innerHTML = vrTable;
    document.getElementById("myRegisterationModal").style.display = "block";
}
function GetCourseRow(vrCourse) {
    var Returned = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblCourse" + vrCourse.ID + "\" value='" + JSON.stringify(vrCourse) + "'\>" + vrCourse.ID + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    Returned += "<td>" + vrCourse.NameA + "</td>";
    Returned += "<td>" + vrCourse.NameE + "</td>";
    Returned += "<td>" + vrCourse.CreditHour + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    var vrTemp = "ReturnCourse(" + vrCourse.ID + ")";
    if (document.getElementById("tblSelectedCourse") != null)
        vrTemp = "if(CheckCourseValidation()){AddCourseToSelectedTable(" + vrCourse.ID + ");}";
    Returned += "<td><input type='button' value='+' onclick=\"" + vrTemp + "\"\>" + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillCourseTable(lstCourse) {
    var vrAllCoursesAuthorized = 1;
    if (document.getElementById("lblAllCoursesAuthorized") != null) {
        vrAllCoursesAuthorized = document.getElementById("lblAllCoursesAuthorized").value.toString() == "1" ? 1 : 0;
    }
    var vrAssignedCourses = [];
    if (vrAllCoursesAuthorized == 0) {
        if (document.getElementById("lblAssignedCourse") != null) {
            var vrAssignedCourseStr = document.getElementById("lblAssignedCourse").value;
            vrAssignedCourses = JSON.parse(vrAssignedCourseStr);
        }
    }
    var vrCourseStr = "<table class=\"table\">";
    var vrCourse;
    for (var vrIndex = 0; vrIndex < lstCourse.length; vrIndex++) {
        vrCourse = lstCourse[vrIndex];
        if (vrAllCoursesAuthorized == 1 || vrAssignedCourses.filter(function (x) { return x == vrCourse.ID; }).length > 0) {
            vrCourseStr += GetCourseRow(lstCourse[vrIndex]);
        }
    }
    vrCourseStr += "</table>";
    document.getElementById("tblCourse").innerHTML = vrCourseStr;
}
function ShowCourseModal() {
    document.getElementById('myCourseModal').style.display = 'block';
}
function ReturnCourse(vrCourseID) {
    var vrCourse = new Course();
    var vrCourseStr = document.getElementById("lblCourse" + vrCourseID).value;
    vrCourse = JSON.parse(vrCourseStr);
    document.getElementById("lblSelectedCourse").value = vrCourseStr;
    document.getElementById("lblSelectedCourseCode").innerText = vrCourse.Code;
    document.getElementById("lblSelectedCourseName").innerText = vrCourse.NameA;
    document.getElementById("lblSelectedCourseCH").innerText = vrCourse.CreditHour.toString();
    document.getElementById("lblSelectedCourseFinalDegree").innerText = vrCourse.TotalDegree.toString();
    document.getElementById('myCourseModal').style.display = 'none';
}
function AddCourseToSelectedTable(vrCourseID) {
    var vrCourse = JSON.parse(document.getElementById("lblCourse" + vrCourseID).value);
    var vrCourseStr = document.getElementById("lblSelectedCourse").value;
    var lstSelectedCourse = [];
    if (vrCourseStr != null && vrCourseStr != "") {
        lstSelectedCourse = JSON.parse(vrCourseStr);
    }
    if (lstSelectedCourse.length == 0 || lstSelectedCourse.filter(function (x) { return x.ID == vrCourseID; }).length == 0) {
        lstSelectedCourse[lstSelectedCourse.length] = vrCourse;
        document.getElementById("lblSelectedCourse").value = JSON.stringify(lstSelectedCourse);
        FillSelectedCourseTable();
    }
}
function FillSelectedCourseTable() {
    var vrCourseStr = document.getElementById("lblSelectedCourse").value;
    var vrCourse;
    var lstSelectedCourse = [];
    if (vrCourseStr != null && vrCourseStr != "") {
        lstSelectedCourse = JSON.parse(vrCourseStr);
    }
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstSelectedCourse.length; vrIndex++) {
        vrCourse = lstSelectedCourse[vrIndex];
        // vrTable += "<tr>";
        vrTable += GetSeldectedCourseRow(vrCourse, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    document.getElementById("tblSelectedCourse").innerHTML = vrTable;
    if (document.getElementById("lblSemesterHour") != null && document.getElementById("lblSemesterHour").value != "") {
        var vrCh = GetTotalRegisterationHour();
    }
}
function GetSeldectedCourseRow(vrCourse, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblSelectedCourse" + vrCourse.ID + "' value='" + JSON.stringify(vrCourse) + "'/>";
    Returned += "<td><input type='button' value='-' onclick='RemoveSelectedCourse(" + vrCourse.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.NameA + "</label></td>";
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.NameE + "</label></td>";
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.CreditHour.toString() + "</label></td>";
    Returned += "</tr>";
    return Returned;
}
function RemoveSelectedCourse(vrCourseID) {
    var vrSelectedCourseLst = [];
    var vrNewSelectedCourseLst = [];
    if (document.getElementById("lblSelectedCourse").value != "") {
        vrSelectedCourseLst = JSON.parse(document.getElementById("lblSelectedCourse").value);
        var vrIndex = 0;
        for (vrIndex = 0; vrIndex < vrSelectedCourseLst.length; vrIndex++) {
            if (vrSelectedCourseLst[vrIndex].ID != vrCourseID) {
                vrNewSelectedCourseLst[vrNewSelectedCourseLst.length] = vrSelectedCourseLst[vrIndex];
            }
        }
        document.getElementById("lblSelectedCourse").value = JSON.stringify(vrNewSelectedCourseLst);
        FillSelectedCourseTable();
    }
}
function GetCurrentCourse() {
    var Returned = new Course();
    Returned.ID = 0;
    if (document.getElementById("lblSelectedCourse") != null && document.getElementById("lblSelectedCourse").value != "") {
        Returned = JSON.parse(document.getElementById("lblSelectedCourse").value);
    }
    return Returned;
}
function SetCurrentCourse(vrCourse) {
    var vrCourseStr = JSON.stringify(vrCourse);
    document.getElementById("lblSelectedCourse").value = vrCourseStr;
    document.getElementById("lblSelectedCourseCode").innerText = vrCourse.Code;
    document.getElementById("lblSelectedCourseName").innerText = vrCourse.NameA;
    document.getElementById("lblSelectedCourseCH").innerText = vrCourse.CreditHour.toString();
    document.getElementById("lblSelectedCourseFinalDegree").innerText = vrCourse.TotalDegree.toString();
}
function ClearCurrentCourse() {
    var vrCourseStr = "";
    document.getElementById("lblSelectedCourse").value = vrCourseStr;
    document.getElementById("lblSelectedCourseCode").innerText = "";
    document.getElementById("lblSelectedCourseName").innerText = "";
    document.getElementById("lblSelectedCourseCH").innerText = "";
    document.getElementById("lblSelectedCourseFinalDegree").innerText = "";
}
function CheckCourseAuthorized(vrCourse) {
    var Returned = true;
    if (document.getElementById("lblAllCoursesAuthorized") != null) {
        if (document.getElementById("lblAllCoursesAuthorized").value == "1") {
            return true;
        }
    }
    if (document.getElementById("lblAssignedCourse") != null) {
        var vrAssigned = [];
        if (document.getElementById("lblAssignedCourse").value != "") {
            vrAssigned = JSON.parse(document.getElementById("lblAssignedCourse").value);
        }
        if (vrAssigned.filter(function (x) { return x == vrCourse.ID; }).length == 0)
            return false;
    }
    return Returned;
}
//# sourceMappingURL=Course.js.map