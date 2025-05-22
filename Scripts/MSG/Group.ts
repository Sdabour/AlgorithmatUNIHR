class Group {
    public ID: number;
    public Code: string;
    public EstablishDate: Date;
    public NameA: string;
    public NameE: string;
    public Desc: string;
    public ApplicantLst: ApplicantSingle[] = [];
    GetDatRow(objBiz: Group): string {
        let Returned: string = "";
        let strTemp: string = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblGroup" + objBiz.ID + "\" value='" + strTemp + "' /></td>";
        Returned += "<td>" + objBiz.NameA + "</td>";
        Returned += "<td>" + objBiz.Desc + "</td>";
       
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnGroup" + objBiz.ID + "\"  onclick=\" CloseGroupExploreModal();return onGroupClick(" + objBiz.ID + ")\" name=\"btnGroup" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    }
    GetSelectedDatRow(objBiz: Group): string {
        let Returned: string = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedGroup" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.NameA + "</td>";
        Returned += "<td>" + objBiz.Desc + "</td>";
       
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedGroup" + objBiz.ID + "\"  onclick=\"return onGroupClick('" + objBiz.ID + "')\" name=\"btnSelectedGroup" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    }

}
function GetGroup(): Group
{
    var vrGroup: Group = new Group();
    vrGroup.NameA = (<HTMLInputElement>document.getElementById("txtNewGroupName")).value;
    vrGroup.Desc = (<HTMLInputElement>document.getElementById("txtNewGroupDesc")).value;
    var vrSelectedApplicant: string = (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value;

    var vrAppLst: ApplicantSingle[] = [];
    if (vrSelectedApplicant != "")
        vrAppLst = JSON.parse(vrSelectedApplicant);

    var vrAppID : string = (<HTMLInputElement>document.getElementById("lblAppID")).value;

    if (vrAppID == null || vrAppID == "")
        return;
    vrAppID = vrAppID.split("|")[0];
    var objApp: ApplicantSingle = new ApplicantSingle();
    objApp.ID = Number(vrAppID);
    vrAppLst[vrAppLst.length] = objApp;
    vrGroup.ApplicantLst = vrAppLst;

    return vrGroup;
}
function ClearNewGroup() {
    (<HTMLInputElement>document.getElementById("txtNewGroupName")).value ="";
    (<HTMLInputElement>document.getElementById("txtNewGroupDesc")).value = "";
    (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value = "";
}
function onGroupClick(intID: number)
{
    var vrGroup: Group = new Group();
    var vrGroupStr: string = (<HTMLInputElement>document.getElementById("lblGroup" + intID.toString())).value;
    vrGroup = JSON.parse(vrGroupStr);
    (<HTMLInputElement>document.getElementById("lblGroup")).value = vrGroupStr;
    (<HTMLInputElement>document.getElementById("txtMSGGroup")).value = vrGroup.NameA;

}