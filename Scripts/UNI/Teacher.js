var Teacher = /** @class */ (function () {
    function Teacher() {
        this.Type = new TeacherType();
        this.Faculty = new Faculty();
    }
    return Teacher;
}());
function GetTeacherSimpleRow(vrTeacher, vrIndex) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblTeacher" + vrTeacher.ID + "' value='" + JSON.stringify(vrTeacher) + "'/>";
    Returned += "<td><input  type='button' id='btnReturnTeacher" + vrTeacher.ID.toString() + "' value='+' onclick='SetSelectedTeacher(" + vrTeacher.ID + ");try{GetTeacherSemesterRegisteration();}catch{};return false;'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrTeacher.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrTeacher.Name + "</td>";
    Returned += "<td>" + vrTeacher.Type.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetTeacherFullTable(lstTeacher) {
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 1; vrIndex <= lstTeacher.length; vrIndex++) {
        Returned += GetTeacherSimpleRow(lstTeacher[vrIndex - 1], vrIndex);
    }
    Returned += "</table>";
    return Returned;
}
function SetSelectedTeacher(vrTeacherID) {
    var vrTeacher = JSON.parse(document.getElementById("lblTeacher" + vrTeacherID).value);
    document.getElementById("lblSelectedTeacher").value = JSON.stringify(vrTeacher);
    document.getElementById("lblTeacherCode").innerText = vrTeacher.Code;
    document.getElementById("lblTeacherName").innerText = vrTeacher.Name;
    if (document.getElementById("lblTeacherType") != null) {
        document.getElementById("lblTeacherType").innerText = vrTeacher.Type.NameA;
    }
    document.getElementById("myTeacherModal").style.display = "none";
}
function GetCurrentTeatcher() {
    var Returned = new Teacher();
    if (document.getElementById("lblSelectedTeacher") != null && document.getElementById("lblSelectedTeacher").value != "") {
        Returned = JSON.parse(document.getElementById("lblSelectedTeacher").value);
    }
    return Returned;
}
//# sourceMappingURL=Teacher.js.map