class SectorSimple
{
    public ID: number;
    public Code: string;
    public Name: string;
    public Level: number;
    public ParentID: number;
    public Family: number;
    public ParentName: string;
    public FamilyName: string;
    GetDatRow(objBiz: SectorSimple): string {
        let Returned: string = "";
        let strTemp: string = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblSector" + objBiz.ID + "\" value='" + strTemp + "' /></td>";
        Returned += "<td>" + objBiz.Level + "</td>";
        Returned += "<td>" + objBiz.FamilyName + "</td>";
        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnSector" + objBiz.ID + "\"  onclick=\" CloseSectorModal();return onSectorClick('" + objBiz.ID + "')\" name=\"btnSector" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    }
    GetSelectedDatRow(objBiz: SectorSimple): string {
        let Returned: string = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedSector" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.Level + "</td>";
        Returned += "<td>" + objBiz.FamilyName + "</td>";
        Returned += "<td>" + objBiz.ParentName + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedSector" + objBiz.ID + "\"  onclick=\"return onSectorClick('" + objBiz.ID + "')\" name=\"btnSelectedSector" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    }

}

function onSectorClick(intSector: number) {
    let vrSectorLbl: string = "lblSector" + intSector;
    let strSector: string = (<HTMLInputElement>document.getElementById(vrSectorLbl)).value;
    var vrTempElement = <HTMLInputElement>document.getElementById(vrSectorLbl);
    let strSelected: string = (<HTMLInputElement>document.getElementById("lblSelectedSector")).value;


    let lstSector: SectorSimple[] = [];
    if (strSelected != "") {
        lstSector = JSON.parse(strSelected);

    }
    let objBiz: SectorSimple = JSON.parse(strSector);
    if (lstSector.filter(x => x.ID == objBiz.ID).length == 0) {
        lstSector[lstSector.length] = objBiz;
    }
    strSelected = JSON.stringify(lstSector);
    document.getElementById("lblSelectedSector").setAttribute("value", strSelected);

    FillSelectedSector();

}
function FillSelectedSector() {

    let strSelected: string = document.getElementById("lblSelectedSector").getAttribute("value");


    let lstSector: SectorSimple[];
    if (strSelected != "") {
        lstSector = JSON.parse(strSelected);

    }
    var vrIndex: number = 0;
    var vrSelectedSectorStr: string = "";
    var vrTable: string;
    vrTable = "<table>";
    let objBiz: SectorSimple = new SectorSimple();
    for (vrIndex = 0; vrIndex < lstSector.length; vrIndex++) {
        vrTable += objBiz.GetSelectedDatRow(lstSector[vrIndex]);
        if (vrSelectedSectorStr != "")
            vrSelectedSectorStr += "&";
        vrSelectedSectorStr += lstSector[vrIndex].Name;
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("txtSectorRecepient")).value = vrSelectedSectorStr;

    document.getElementById("dvSelectedSector").innerHTML = vrTable;

}
function FillMSGSector() {
    let strFilter: string = (<HTMLInputElement>document.getElementById("txtDepartmentFilter")).value;
    let strAllSector: string = (<HTMLInputElement>document.getElementById("lblAllSector")).value;
    let lstAllSector: SectorSimple[] = JSON.parse(strAllSector);
    let lstSector: SectorSimple[] = lstAllSector.filter(x => x.Name.indexOf(strFilter) != -1 || x.ParentName.indexOf(strFilter) != -1 || x.FamilyName.indexOf(strFilter) != -1);
    let vrTable: string = "<table>";
    let objBiz: SectorSimple =new SectorSimple();
    for (var vrIndex = 0; vrIndex < lstSector.length; vrIndex++)
    {
        vrTable += objBiz.GetDatRow(lstSector[vrIndex]);
    }

    vrTable += "</table>";
    document.getElementById("dvSector").innerHTML = vrTable;
    

}