var Hall = /** @class */ (function () {
    function Hall() {
        this.ID = 0;
        this.Faculty = new Faculty();
        this.Name = "";
        this.Capacity = 0;
        this.LectureType = new LectureType();
    }
    return Hall;
}());
function GetHallRow(vrHall) {
    var Returned = "";
    Returned += "<tr>";
    Returned += "<input type=\"hidden\" id=\"lblHall" + vrHall.ID.toString() + "\" value='" + JSON.stringify(vrHall) + "'>";
    Returned += "<td>" + vrHall.Faculty.NameA + "</td>";
    Returned += "<td>" + vrHall.Name + "</td>";
    Returned += "<td>" + vrHall.Capacity.toString() + "</td>";
    Returned += "<td>" + vrHall.LectureType.NameA + "</td>";
    Returned += "<td><input type=\"button\" id=\"btnReturnHall" + vrHall.ID.toString() + "\" value=\"+\" onclick=\"SetCurrentHall(" + vrHall.ID + ")\" /></td>";
    vrHall.LectureType.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillHallTable(lstHall) {
    var strTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstHall.length; vrIndex++) {
        strTable += GetHallRow(lstHall[vrIndex]);
    }
    strTable += "</table>";
    if (document.getElementById("tblHall") != null) {
        document.getElementById("tblHall").innerHTML = strTable;
    }
}
function SetCurrentHall(vrID) {
    var vrHallStr = document.getElementById("lblHall" + vrID.toString()).value;
    var vrCurrentGroup = 0;
    if (document.getElementById("lblHallGroup") != null) {
        vrCurrentGroup = Number(document.getElementById("lblHallGroup").value);
    }
    var vrHallLabel = "lblSelectedHall";
    if (vrCurrentGroup != 0) {
        vrHallLabel = "lblGroupHallSelected";
        vrHallLabel += vrCurrentGroup.toString();
        document.getElementById(vrHallLabel).value = vrHallStr;
        var vrHall = JSON.parse(vrHallStr);
        vrHallLabel = "lblGroupHall";
        vrHallLabel += vrCurrentGroup.toString();
        document.getElementById(vrHallLabel).innerText = vrHall.Name;
    }
    if (document.getElementById("myHallModal") != null) {
        document.getElementById("myHallModal").style.display = "none";
    }
}
function GetCurrentHall() {
}
//# sourceMappingURL=Hall.js.map