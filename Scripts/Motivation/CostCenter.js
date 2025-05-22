var CostCenter = /** @class */ (function () {
    function CostCenter() {
    }
    return CostCenter;
}());
function GetCostCenterCheckRow(vrCost) {
    var Returned = "";
    Returned += "<tr>";
    Returned += "<td><input type='button' value='+' onclick='AddCostToSelected(" + vrCost.ID + ")'></td>";
    // Returned += "<td>" + vrCost.Code + "</td>";
    Returned += "<td>" + vrCost.TypeNameA + "</td>";
    Returned += "<td>" + vrCost.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetSelectedCostCenterRow(vrCost) {
    var Returned = "";
    Returned += "<tr>";
    // Returned += "<td>" + vrCost.Code + "</td>";
    Returned += "<td>" + vrCost.TypeNameA + "</td>";
    Returned += "<td>" + vrCost.NameA + "</td>";
    Returned += "<td><input type='button' value='-' onclick='RemoveCostSelected(" + vrCost.ID + ")'></td>";
    Returned += "</tr>";
    return Returned;
}
function FillFilteredCostCenterTable() {
    var vrCostCenterName = "";
    if (document.getElementById("txtFilterCostCenter") != null) {
        vrCostCenterName = document.getElementById("txtFilterCostCenter").value;
    }
    var vrCostCentLst = [];
    var vrCostCenterStr = document.getElementById("lblAllCostCenter").value;
    vrCostCentLst = JSON.parse(document.getElementById("lblAllCostCenter").value);
    var vrFilterCostCenter = [];
    vrFilterCostCenter = vrCostCentLst.filter(function (x) { return x.NameA.indexOf(vrCostCenterName) > -1; });
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrFilterCostCenter.length; vrIndex++) {
        vrTable += GetCostCenterCheckRow(vrFilterCostCenter[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblCostCenter") != null) {
        document.getElementById("tblCostCenter").innerHTML = vrTable;
    }
}
function FillSelectedCostCenterTable() {
    var vrCostCentLst = [];
    if (document.getElementById("lblSelectedCostCenter").value != "") {
        vrCostCentLst = JSON.parse(document.getElementById("lblSelectedCostCenter").value);
    }
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrCostCentLst.length; vrIndex++) {
        vrTable += GetSelectedCostCenterRow(vrCostCentLst[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblSelectedCostCenter") != null) {
        document.getElementById("tblSelectedCostCenter").innerHTML = vrTable;
    }
}
function AddCostToSelected(vrCostID) {
    var vrCostCentLst = [];
    var vrSelectedCostCenter = [];
    if (document.getElementById("lblSelectedCostCenter").value != "") {
        vrSelectedCostCenter = JSON.parse(document.getElementById("lblSelectedCostCenter").value);
    }
    var vrFilterCostCenter = vrSelectedCostCenter.filter(function (x) { return x.ID == vrCostID; });
    if (vrFilterCostCenter.length > 0) {
        return;
    }
    vrCostCentLst = JSON.parse(document.getElementById("lblAllCostCenter").value);
    vrFilterCostCenter = vrCostCentLst.filter(function (x) { return x.ID == vrCostID; });
    if (vrFilterCostCenter.length > 0) {
        vrSelectedCostCenter[vrSelectedCostCenter.length] = vrFilterCostCenter[0];
    }
    document.getElementById("lblSelectedCostCenter").value = JSON.stringify(vrSelectedCostCenter);
    FillSelectedCostCenterTable();
}
function RemoveCostSelected(vrCostID) {
    var vrCostCentLst = [];
    var vrSelectedCostCenter = JSON.parse(document.getElementById("lblSelectedCostCenter").value);
    var vrFilterCostCenter = vrSelectedCostCenter.filter(function (x) { return x.ID != vrCostID; });
    if (vrFilterCostCenter.length == vrSelectedCostCenter.length) {
        return;
    }
    document.getElementById("lblSelectedCostCenter").value = JSON.stringify(vrFilterCostCenter);
    FillSelectedCostCenterTable();
}
//# sourceMappingURL=CostCenter.js.map