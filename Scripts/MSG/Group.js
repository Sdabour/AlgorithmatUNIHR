var Group = /** @class */ (function () {
    function Group() {
        this.ApplicantLst = [];
    }
    Group.prototype.GetDatRow = function (objBiz) {
        var Returned = "";
        var strTemp = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblGroup" + objBiz.ID + "\" value='" + strTemp + "' /></td>";
        Returned += "<td>" + objBiz.NameA + "</td>";
        Returned += "<td>" + objBiz.Desc + "</td>";
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnGroup" + objBiz.ID + "\"  onclick=\" CloseGroupExploreModal();return onGroupClick(" + objBiz.ID + ")\" name=\"btnGroup" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    Group.prototype.GetSelectedDatRow = function (objBiz) {
        var Returned = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedGroup" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.NameA + "</td>";
        Returned += "<td>" + objBiz.Desc + "</td>";
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedGroup" + objBiz.ID + "\"  onclick=\"return onGroupClick('" + objBiz.ID + "')\" name=\"btnSelectedGroup" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    return Group;
}());
function GetGroup() {
    var vrGroup = new Group();
    vrGroup.NameA = document.getElementById("txtNewGroupName").value;
    vrGroup.Desc = document.getElementById("txtNewGroupDesc").value;
    var vrSelectedApplicant = document.getElementById("lblSelectedEmployee").value;
    var vrAppLst = [];
    if (vrSelectedApplicant != "")
        vrAppLst = JSON.parse(vrSelectedApplicant);
    var vrAppID = document.getElementById("lblAppID").value;
    if (vrAppID == null || vrAppID == "")
        return;
    vrAppID = vrAppID.split("|")[0];
    var objApp = new ApplicantSingle();
    objApp.ID = Number(vrAppID);
    vrAppLst[vrAppLst.length] = objApp;
    vrGroup.ApplicantLst = vrAppLst;
    return vrGroup;
}
function ClearNewGroup() {
    document.getElementById("txtNewGroupName").value = "";
    document.getElementById("txtNewGroupDesc").value = "";
    document.getElementById("lblSelectedEmployee").value = "";
}
function onGroupClick(intID) {
    var vrGroup = new Group();
    var vrGroupStr = document.getElementById("lblGroup" + intID.toString()).value;
    vrGroup = JSON.parse(vrGroupStr);
    document.getElementById("lblGroup").value = vrGroupStr;
    document.getElementById("txtMSGGroup").value = vrGroup.NameA;
}
//# sourceMappingURL=Group.js.map