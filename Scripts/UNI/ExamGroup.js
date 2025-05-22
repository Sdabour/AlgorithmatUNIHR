var ExamGroup = /** @class */ (function () {
    function ExamGroup() {
    }
    return ExamGroup;
}());
function GetExamGroupRow(vrGroup) {
    if (vrGroup.HallSimple == undefined) {
        vrGroup.HallSimple = new Hall();
    }
    var vrHall = vrGroup.HallSimple;
    if (document.getElementById("lblGroupHallSelected" + vrGroup.GroupSimple.ID) != null) {
        vrHall = JSON.parse(document.getElementById("lblGroupHallSelected" + vrGroup.GroupSimple.ID).value);
        if (vrHall.ID != 0) {
            vrGroup.HallSimple = vrHall;
        }
    }
    var vrExam = new Exam();
    if (document.getElementById("lblSelectedExam") != null && document.getElementById("lblSelectedExam").value != "") {
        /*vrExam = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedExam")).value);*/
    }
    /*    var vrHall: Hall = new Hall();*/
    vrHall = vrGroup.HallSimple;
    if (vrHall == null || vrHall == undefined)
        vrHall = new Hall();
    var Returned = "<tr>";
    Returned += "<input type=\"hidden\" id=\"lblGroup" + vrGroup.GroupSimple.ID + "\" value='" + JSON.stringify(vrGroup) + "'>";
    Returned += "<td>" + vrGroup.GroupSimple.NameA + "</td>";
    Returned += "<td><button id='btnGetHall" + vrGroup.GroupSimple.ID + "' value =\"H\" onclick='ShowGroupHallModal(" + vrGroup.GroupSimple.ID + ")'>H</button></td>";
    Returned += "<td><input type=\"hidden\" id=\"lblGroupHallSelected" + vrGroup.GroupSimple.ID + "\" value='" + JSON.stringify(vrGroup.HallSimple) + "'/><label id=\"lblGroupHall" + vrGroup.GroupSimple.ID.toString() + "\">" + vrGroup.HallSimple.Name + "</label></td>";
    Returned += "<td><button id='btnDeleteGroup" + vrGroup.GroupSimple.ID + "' onclick='RemoveGroup(" + vrGroup.GroupSimple.ID + ")'>-</button></td>";
    Returned += "</tr>";
    return Returned;
}
function GetExamGroupTable(lstGroup) {
    var Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstGroup.length; vrIndex++) {
        Returned += GetExamGroupRow(lstGroup[vrIndex]);
    }
    Returned += "</table>";
    if (document.getElementById("tblExamGrroup") != null) {
        document.getElementById("tblExamGrroup").innerHTML = Returned;
    }
    return Returned;
}
function ShowGroupHallModal(vrGroupID) {
    if (document.getElementById("lblHallGroup") != null) {
        document.getElementById("lblHallGroup").value = vrGroupID.toString();
    }
    document.getElementById('myHallModal').style.display = "block";
}
function RemoveGroup(vrGroupID) {
    var vrExam = new Exam();
    if (document.getElementById("lblSelectedExam") != null && document.getElementById("lblSelectedExam").value != "") {
        vrExam = JSON.parse(document.getElementById("lblSelectedExam").value);
        var lstExamGroup = [];
        for (var vrIndex = 0; vrIndex < vrExam.GroupLst.length; vrIndex++) {
            if (vrExam.GroupLst[vrIndex].GroupSimple.ID != vrGroupID) {
                lstExamGroup[lstExamGroup.length] = vrExam.GroupLst[vrIndex];
            }
        }
        vrExam.GroupLst = lstExamGroup;
        document.getElementById("lblSelectedExam").value = JSON.stringify(vrExam);
        GetExamGroupTable(vrExam.GroupLst);
    }
}
//# sourceMappingURL=ExamGroup.js.map