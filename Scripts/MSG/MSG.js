var MSG = /** @class */ (function () {
    function MSG() {
        this.LstAppIDs = [];
        this.LstSectorIDs = [];
    }
    return MSG;
}());
function GetMsg() {
    var Returned = new MSG();
    var AppLst = [];
    if (document.getElementById("lblSelectedEmployee").value != null && document.getElementById("lblSelectedEmployee").value != "") {
        AppLst = JSON.parse(document.getElementById("lblSelectedEmployee").value);
        Returned.LstAppIDs = AppLst.map(function (x) { return x.ID; });
    }
    var SectorLst = [];
    if (document.getElementById("lblSelectedSector").value != null && document.getElementById("lblSelectedSector").value != "") {
        SectorLst = JSON.parse(document.getElementById("lblSelectedSector").value);
        Returned.LstSectorIDs = SectorLst.map(function (x) { return x.ID; });
    }
    if (document.getElementById("tdMSGBody").innerText != null) {
        var vrTemp = document.getElementById("tdMSGBody");
        Returned.Text = document.getElementById("tdMSGBody").innerText;
    }
    if (document.getElementById("txtMSGSubject").value != null) {
        Returned.Header = document.getElementById("txtMSGSubject").value;
    }
    if (document.getElementById("lblMainMSG").value != null) {
        Returned.Parent = Number(document.getElementById("lblMainMSG").value);
    }
    var vrGroupStr = document.getElementById("lblGroup").value;
    if (vrGroupStr != "") {
        var vrGroup = JSON.parse(vrGroupStr);
        Returned.Group = vrGroup.ID;
        Returned.GroupName = vrGroup.NameA;
    }
    return Returned;
}
function ClearMsg() {
    var Returned = new MSG();
    var AppLst = [];
    document.getElementById("lblSelectedEmployee").value = "";
    document.getElementById("lblSelectedSector").value = "";
    document.getElementById("tdMSGBody").innerText = "";
    document.getElementById("txtMSGSubject").value = "";
    document.getElementById("lblGroup").value = "";
    document.getElementById("txtMSGGroup").value = "";
}
function ClearSubMSG() {
    document.getElementById("tblMSGThread").innerHTML = "";
    document.getElementById("lblMainMSG").innerHTML = "";
    document.getElementById("lblMainMSG").setAttribute("value", "0");
    document.getElementById("lblMainMSGCount").setAttribute("value", "0");
}
function GetMSGURL(objBiz) {
    var vrSender = objBiz.Group == 0 ? objBiz.SenderApplicantName : objBiz.GroupName;
    var vrImage = objBiz.Seen ? "success.png" : "placeholder.jpg";
    vrImage = objBiz.Seen ? "Seen.png" : "Unseen.png";
    //"pnotify""placeholders"
    var Returned = "<li class=\"media\">" +
        "<div class=\"md-3 position-relative\" >" +
        "<img src=\"../wwwroot/images/pnotify/" + vrImage + "\" width = \"36\" height = \"36\" class=\"rounded-circle\" style=\"width: 18px; height: 18px;\" alt = \"\" >" +
        "</div>";
    Returned += "<div class=\"media-body\">" +
        "<div class=\"media-title\" >" +
        "<a href=\"#\" onclick=\"SeeMSG(" + objBiz.ID + ")\" >" +
        "<span class=\"font-weight-semibold\" >" + vrSender + " </span>" +
        "<span class=\"text-muted float-right font-size-sm\" > " + objBiz.Time + " </span>" +
        "</a>" +
        "</div>" +
        "<span class=\"text-muted\">" + objBiz.Header + "</span>" +
        "</div>" +
        "</li>";
    return Returned;
}
function GetMSGTableRows(lstMSG) {
    var Returned = "";
    var vrMSG;
    for (var vrIndex = 0; vrIndex < lstMSG.length; vrIndex++) {
        vrMSG = lstMSG[vrIndex];
        Returned += GetThreadMSGTableStr(vrMSG);
    }
    return Returned;
}
function GetThreadMSGTableStr(objMsg) {
    var Returned = "<tr>" +
        "<td>" +
        "<table width=\"280\" border = \"0\" cellpadding = \"0\" cellspacing = \"0\" align = \"right\">" +
        "<tbody>" +
        "<tr>" +
        "<td height=\"60\" valign = \"middle\" width = \"100%\" align = \"right\">" +
        objMsg.SenderApplicantName + "</br>" + objMsg.Time + "</br>" +
        objMsg.Text +
        "</td>" +
        "</tr>" +
        "</tbody>" +
        "</table>" +
        "</td>" +
        "</tr>";
    return Returned;
}
function FillMSGSelectedApplicant() {
}
//# sourceMappingURL=MSG.js.map