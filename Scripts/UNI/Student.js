var Student = /** @class */ (function () {
    function Student() {
        //public lstRegisteration: Registeration[] = [];
        this.lstSemester = [];
    }
    Student.prototype.GetRegisterationLst = function (lstSemester) {
        var Returned = [];
        for (var vrIndex = 0; vrIndex < lstSemester.length; vrIndex++) {
            for (var vrIndex1 = 0; vrIndex1 < lstSemester[vrIndex].lstRegisteration.length; vrIndex1++) {
                Returned[Returned.length] = lstSemester[vrIndex].lstRegisteration[vrIndex1];
            }
        }
        return Returned;
    };
    return Student;
}());
function GetStudentPivotTableRow(objBiz, objCourseCol) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + objBiz.ID + "' value='" + JSON.stringify(objBiz) + "'/>";
    Returned += "<td><input type='button' value='-' onclick='ShowRegisterationModal(" + objBiz.ID + ")'></td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + objBiz.NameA + "</label></td>";
    Returned += "<td>" + objBiz.Points + "</td>";
    Returned += "<td>" + objBiz.EarnedHours + "</td>";
    // Returned += "<td>" + objBiz.Verbal + "</td>";
    var vrCourse;
    var vrReg;
    var vrRegLst;
    for (var vrIndex = 0; vrIndex < objCourseCol.length; vrIndex++) {
        vrCourse = objCourseCol[vrIndex];
        vrReg = new Registeration();
        vrReg.ID = 0;
        var vrTempStudent = new Student();
        vrRegLst = vrTempStudent.GetRegisterationLst(objBiz.lstSemester).filter(function (x) { return x.Course == vrCourse.ID; });
        if (vrRegLst.length > 0) {
            vrReg = vrRegLst[0];
        }
        Returned += "<td>";
        if (vrReg.ID > 0) {
            Returned += vrReg.GPA;
        }
        Returned += "</td>";
        Returned += "<td>";
        if (vrReg.ID > 0) {
            Returned += vrReg.Points;
        }
        Returned += "</td>";
    }
    Returned += "</tr>";
    return Returned;
}
function GetStudentRow(vrStudent, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='+' onclick='AddStudentToSelectedTable(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetStudentFullRow(vrStudent, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='+' onclick='AddStudentToSelectedTable(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";
    Returned += "<td>" + vrStudent.Email + "</td>";
    Returned += "<td>Level" + vrStudent.Level + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetStudentFullTable(lstStudent) {
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 1; vrIndex <= lstStudent.length; vrIndex++) {
        Returned += GetStudentFullRow(lstStudent[vrIndex - 1], vrIndex);
    }
    Returned += "</table>";
    return Returned;
}
function GetStudentSimpleRow(vrStudent, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input  type='button' id='btnReturnStudent" + vrStudent.ID.toString() + "' value='+' onclick='SetSelectedStudent(" + vrStudent.ID + ");try{GetStudentSemesterRegisteration();}catch{};return false;'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetSeldectedStudentRow(vrStudent, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblSelectedStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='-' onclick='RemoveSelectdStudent(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //Returned += "<td>" + vrStudent.NameA + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrStudent.NameA + "</label></td>";
    Returned += "</tr>";
    return Returned;
}
function AddStudentToSelectedTable(vrStudentID) {
    var vrStudent = JSON.parse(document.getElementById("lblStudent" + vrStudentID).value);
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    var lstSelectedStudent = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);
    }
    if (lstSelectedStudent.length == 0 || lstSelectedStudent.filter(function (x) { return x.ID == vrStudentID; }).length == 0) {
        lstSelectedStudent[lstSelectedStudent.length] = vrStudent;
        document.getElementById("lblSelectedStudent").value = JSON.stringify(lstSelectedStudent);
        FillSelectedStudentTable();
    }
}
function SetSelectedStudent(vrStudentID) {
    var vrStudent = JSON.parse(document.getElementById("lblStudent" + vrStudentID).value);
    document.getElementById("lblSelectedStudent").value = JSON.stringify(vrStudent);
    document.getElementById("lblStudentCode").innerText = vrStudent.Code;
    document.getElementById("lblStudentName").innerText = vrStudent.NameA;
    if (document.getElementById("lblStudentEH") != null) {
        document.getElementById("lblStudentEH").innerText = vrStudent.MaxResultEarnedHour.toString();
    }
    if (document.getElementById("lblStudentCGPA") != null) {
        document.getElementById("lblStudentCGPA").innerText = vrStudent.MaxResultCPoints.toString();
    }
    if (document.getElementById("lblStudentLevel") != null) {
        document.getElementById("lblStudentLevel").innerText = vrStudent.Level;
    }
    document.getElementById("myStudentModal").style.display = "none";
}
function FillSelectedStudentTable() {
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    var vrStudent;
    var lstSelectedStudent = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);
    }
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstSelectedStudent.length; vrIndex++) {
        vrStudent = lstSelectedStudent[vrIndex];
        // vrTable += "<tr>";
        vrTable += GetSeldectedStudentRow(vrStudent, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    document.getElementById("tblSelectedStudent").innerHTML = vrTable;
}
function FillStudentTable(lstStudent) {
    var vrStudent;
    document.getElementById("lblStudent").value = JSON.stringify(lstStudent);
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];
        //  vrTable += "<tr>";
        vrTable += GetStudentRow(vrStudent, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    document.getElementById("tblStudent").innerHTML = vrTable;
}
function FillStudentSimpleTable(lstStudent) {
    var vrStudent;
    document.getElementById("lblStudent").value = JSON.stringify(lstStudent);
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];
        //  vrTable += "<tr>";
        vrTable += GetStudentSimpleRow(vrStudent, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    document.getElementById("tblStudent").innerHTML = vrTable;
}
function RemoveSelectdStudent(vrStudentID) {
    var vrStudentStr = document.getElementById("lblSelectedStudent").value;
    var vrStudent;
    var lstSelectedStudent = [];
    var lstNewSelectedStudent = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);
        for (var vrIndex = 0; vrIndex < lstSelectedStudent.length; vrIndex++) {
            if (lstSelectedStudent[vrIndex].ID != vrStudentID) {
                lstNewSelectedStudent[lstNewSelectedStudent.length] = lstSelectedStudent[vrIndex];
            }
            document.getElementById("lblSelectedStudent").value = JSON.stringify(lstNewSelectedStudent);
            FillSelectedStudentTable();
        }
    }
}
function GetStudentData() {
    var Returned = new Student();
    var vrTemp = "";
    if (document.getElementById("lblStudent") != null) {
        vrTemp = document.getElementById("lblStudent").value;
        if (vrTemp != null && vrTemp != "") {
            Returned = JSON.parse(vrTemp);
        }
    }
    if (document.getElementById("txtStudentCode") != null) {
        vrTemp = document.getElementById("txtStudentCode").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Code = vrTemp;
        }
    }
    if (document.getElementById("txtStudentNameA") != null) {
        vrTemp = document.getElementById("txtStudentNameA").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.NameA = vrTemp;
        }
    }
    if (document.getElementById("txtStudentNameE") != null) {
        vrTemp = document.getElementById("txtStudentNameE").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.NameE = vrTemp;
        }
    }
    if (document.getElementById("dtStudentBirthDate") != null) {
        vrTemp = document.getElementById("dtStudentBirthDate").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.BirthDate = new Date(vrTemp);
        }
    }
    if (document.getElementById("txtStudentMobile1") != null) {
        vrTemp = document.getElementById("txtStudentMobile1").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Mobile1 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentMobile2") != null) {
        vrTemp = document.getElementById("txtStudentMobile2").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Mobile2 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentPhone1") != null) {
        vrTemp = document.getElementById("txtStudentPhone1").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Phone1 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentPhone2") != null) {
        vrTemp = document.getElementById("txtStudentPhone2").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Phone2 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentAddress") != null) {
        vrTemp = document.getElementById("txtStudentAddress").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Address = vrTemp;
        }
    }
    if (document.getElementById("txtStudentEmail") != null) {
        vrTemp = document.getElementById("txtStudentEmail").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Email = vrTemp;
        }
    }
    if (document.getElementById("cmbHomeCity") != null) {
        vrTemp = document.getElementById("cmbHomeCity").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.HomeCity = Number(vrTemp);
        }
    }
    if (document.getElementById("cmbHomeCountry") != null) {
        vrTemp = document.getElementById("cmbHomeCountry").value;
        if (vrTemp != null && vrTemp != "") {
            Returned.HomeCountry = Number(vrTemp);
        }
    }
    return Returned;
}
function SetStudentData(vrStudent) {
    var vrTemp = "";
    if (document.getElementById("lblStudent") != null) {
        document.getElementById("lblStudent").value = JSON.stringify(vrStudent);
    }
    if (document.getElementById("txtStudentCode") != null) {
        document.getElementById("txtStudentCode").value = vrStudent.Code;
    }
    if (document.getElementById("txtStudentNameA") != null) {
        document.getElementById("txtStudentNameA").value = vrStudent.NameA;
    }
    if (document.getElementById("txtStudentNameE") != null) {
        document.getElementById("txtStudentNameE").value = vrStudent.NameE;
    }
    if (document.getElementById("dtStudentBirthDate") != null) {
        document.getElementById("dtStudentBirthDate").value = vrStudent.BirthDate.toISOString().substring(0, 10);
    }
    if (document.getElementById("txtStudentMobile1") != null) {
        document.getElementById("txtStudentMobile1").value = vrStudent.Mobile1;
    }
    if (document.getElementById("txtStudentMobile2") != null) {
        document.getElementById("txtStudentMobile2").value = vrStudent.Mobile2;
    }
    if (document.getElementById("txtStudentPhone1") != null) {
        document.getElementById("txtStudentPhone1").value = vrStudent.Phone1;
    }
    if (document.getElementById("txtStudentPhone2") != null) {
        document.getElementById("txtStudentPhone2").value = vrStudent.Phone2;
    }
    if (document.getElementById("txtStudentAddress") != null) {
        document.getElementById("txtStudentAddress").value = vrStudent.Address;
    }
    if (document.getElementById("txtStudentEmail") != null) {
        document.getElementById("txtStudentEmail").value = vrStudent.Email;
    }
    if (document.getElementById("cmbHomeCity") != null) {
        document.getElementById("cmbHomeCity").value = vrStudent.HomeCity.toString();
    }
    if (document.getElementById("cmbHomeCountry") != null) {
        document.getElementById("cmbHomeCountry").value = vrStudent.HomeCountry.toString();
    }
}
function SelectAllStudent() {
    var vrStudentStr = document.getElementById("lblStudent").value;
    var lstStudent = [];
    if (vrStudentStr != "") {
        lstStudent = JSON.parse(vrStudentStr);
    }
    var vrStudent = new Student();
    var lstSelectedStudent = [];
    vrStudentStr = document.getElementById("lblSelectedStudent").value;
    if (vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);
    }
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];
        if (lstSelectedStudent.filter(function (x) { return x.ID == vrStudent.ID; }).length == 0) {
            lstSelectedStudent[lstSelectedStudent.length] = vrStudent;
        }
    }
    vrStudentStr = JSON.stringify(lstSelectedStudent);
    document.getElementById("lblSelectedStudent").value = vrStudentStr;
    FillSelectedStudentTable();
    document.getElementById("myStudentModal").style.display = "none";
}
//# sourceMappingURL=Student.js.map