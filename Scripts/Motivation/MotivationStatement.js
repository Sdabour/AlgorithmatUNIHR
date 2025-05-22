var MotivationStatement = /** @class */ (function () {
    function MotivationStatement() {
    }
    return MotivationStatement;
}());
function GetMotivationStatetmentRow(vrStatement) {
    var Returned = "<tr>";
    Returned += "<input type='hidden' id='lblMotivationStatement" + vrStatement.ID + "' value='" + JSON.stringify(vrStatement) + "'/>";
    Returned += "<td><input type='button' value='+' onclick='ReturnMotivationStatement(" + vrStatement.ID + ")'></td>";
    Returned += "<td>" + vrStatement.ID.toString() + "</td>";
    Returned += "<td>" + vrStatement.Desc + "</td>";
    Returned += "<td>" + vrStatement.MonthName.toString() + "</td>";
    Returned += "<td>" + (vrStatement.MotivationIsAddedBonus ? "ارباح" : "") + "</td>";
    Returned += "<td>" + vrStatement.ID.toString() + "</td>";
    Returned += "</tr>";
    return Returned;
}
function ReturnMotivationStatement(vrStatementID) {
    var vrStatement = JSON.parse(document.getElementById("lblMotivationStatement" + vrStatementID.toString()).value);
    if (document.getElementById("lblCurrentMotivationStatement") != null) {
        document.getElementById("lblCurrentMotivationStatement").value = JSON.stringify(vrStatement);
    }
    if (document.getElementById("lblCurrentMotivationStatementDesc") != null) {
        document.getElementById("lblCurrentMotivationStatementDesc").innerText = vrStatement.Desc;
    }
    document.getElementById('myStatementModal').style.display = 'none';
}
function FillMotivationStatementTable(lstStatement) {
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstStatement.length; vrIndex++) {
        vrTable += GetMotivationStatetmentRow(lstStatement[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblStatement") != null) {
        document.getElementById("tblStatement").innerHTML = vrTable;
    }
}
//# sourceMappingURL=MotivationStatement.js.map