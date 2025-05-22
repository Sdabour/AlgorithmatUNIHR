var SectorSimple = /** @class */ (function () {
    function SectorSimple() {
    }
    SectorSimple.prototype.GetDatRow = function (objBiz) {
        var Returned = "";
        var strTemp = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblSector" + objBiz.ID + "\" value='" + strTemp + "' /></td>";
        Returned += "<td>" + objBiz.Level + "</td>";
        Returned += "<td>" + objBiz.FamilyName + "</td>";
        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnSector" + objBiz.ID + "\"  onclick=\" CloseSectorModal();return onSectorClick('" + objBiz.ID + "')\" name=\"btnSector" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    SectorSimple.prototype.GetSelectedDatRow = function (objBiz) {
        var Returned = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedSector" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.Level + "</td>";
        Returned += "<td>" + objBiz.FamilyName + "</td>";
        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedSector" + objBiz.ID + "\"  onclick=\"return onSectorClick('" + objBiz.ID + "')\" name=\"btnSelectedSector" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    return SectorSimple;
}());
function onSectorClick(intSector) {
    var vrSectorLbl = "lblSector" + intSector;
    var strSector = document.getElementById(vrSectorLbl).value;
    var vrTempElement = document.getElementById(vrSectorLbl);
    var strSelected = document.getElementById("lblSelectedSector").value;
    var lstSector = [];
    if (strSelected != "") {
        lstSector = JSON.parse(strSelected);
    }
    var objBiz = JSON.parse(strSector);
    if (lstSector.filter(function (x) { return x.ID == objBiz.ID; }).length == 0) {
        lstSector[lstSector.length] = objBiz;
    }
    strSelected = JSON.stringify(lstSector);
    document.getElementById("lblSelectedSector").setAttribute("value", strSelected);
    FillSelectedSector();
}
function FillSelectedSector() {
    var strSelected = document.getElementById("lblSelectedSector").getAttribute("value");
    var lstSector;
    if (strSelected != "") {
        lstSector = JSON.parse(strSelected);
    }
    var vrIndex = 0;
    var vrSelectedSectorStr = "";
    var vrTable;
    vrTable = "<table>";
    var objBiz = new SectorSimple();
    for (vrIndex = 0; vrIndex < lstSector.length; vrIndex++) {
        vrTable += objBiz.GetSelectedDatRow(lstSector[vrIndex]);
        if (vrSelectedSectorStr != "")
            vrSelectedSectorStr += "&";
        vrSelectedSectorStr += lstSector[vrIndex].Name;
    }
    vrTable += "</table>";
    document.getElementById("txtSectorRecepient").value = vrSelectedSectorStr;
    document.getElementById("dvSelectedSector").innerHTML = vrTable;
}
function FillMSGSector() {
    var strFilter = document.getElementById("txtDepartmentFilter").value;
    var strAllSector = document.getElementById("lblAllSector").value;
    var lstAllSector = JSON.parse(strAllSector);
    var lstSector = lstAllSector.filter(function (x) { return x.Name.indexOf(strFilter) != -1 || x.ParentName.indexOf(strFilter) != -1 || x.FamilyName.indexOf(strFilter) != -1; });
    var vrTable = "<table>";
    var objBiz = new SectorSimple();
    for (var vrIndex = 0; vrIndex < lstSector.length; vrIndex++) {
        vrTable += objBiz.GetDatRow(lstSector[vrIndex]);
    }
    vrTable += "</table>";
    document.getElementById("dvSector").innerHTML = vrTable;
}
//# sourceMappingURL=SectorSimple.js.map