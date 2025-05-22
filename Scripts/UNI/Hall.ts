 class Hall {
     public ID: number=0;
     public Faculty: Faculty=new Faculty();
     public Name: string="";
     public Capacity: number=0;
     public LectureType: LectureType=new LectureType();

}
function GetHallRow(vrHall: Hall): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type=\"hidden\" id=\"lblHall" + vrHall.ID.toString() + "\" value='" + JSON.stringify(vrHall) + "'>";

    Returned += "<td>" + vrHall.Faculty.NameA + "</td>";
    Returned += "<td>" + vrHall.Name + "</td>";
    Returned += "<td>" + vrHall.Capacity.toString() + "</td>";
    Returned += "<td>" + vrHall.LectureType.NameA + "</td>";
    Returned += "<td><input type=\"button\" id=\"btnReturnHall" + vrHall.ID.toString() + "\" value=\"+\" onclick=\"SetCurrentHall("+vrHall.ID+")\" /></td>"; vrHall.LectureType.NameA + "</td>";
    Returned += "</tr>";
    return Returned;
} 
function FillHallTable(lstHall: Hall[]) {
    var strTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstHall.length; vrIndex++) {
        strTable += GetHallRow(lstHall[vrIndex]);
    }
    strTable += "</table>";
    if (document.getElementById("tblHall") != null) { (<HTMLInputElement>document.getElementById("tblHall")).innerHTML = strTable; }

}
function SetCurrentHall(vrID:number) {
    var vrHallStr: string = (<HTMLInputElement>document.getElementById("lblHall" + vrID.toString())).value;
    var vrCurrentGroup: number = 0;
    if (document.getElementById("lblHallGroup") != null) {
        vrCurrentGroup = Number((<HTMLInputElement>document.getElementById("lblHallGroup")).value);

    }
    var vrHallLabel: string = "lblSelectedHall";
    if (vrCurrentGroup != 0) {
        
        vrHallLabel = "lblGroupHallSelected";
        vrHallLabel += vrCurrentGroup.toString();(<HTMLInputElement>document.getElementById(vrHallLabel)).value = vrHallStr;
        var vrHall: Hall = JSON.parse(vrHallStr);
        vrHallLabel = "lblGroupHall";
        vrHallLabel += vrCurrentGroup.toString();(<HTMLInputElement>document.getElementById(vrHallLabel)).innerText = vrHall.Name;
    }
    if (document.getElementById("myHallModal") != null) {
        document.getElementById("myHallModal").style.display = "none";
    }
    

}
function GetCurrentHall() {

}