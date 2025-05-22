class MotivationStatement {
    public ID: number;
    public Desc: string;
    public DateFrom: Date;
    public DateTo: Date;
    public DateStartDateLimit: number;
    public ApplicantStatus: number;
    public MonthName: string;
    public VacationDay: number;
    public ParentID: number;
    public MotivationType: number;
    public MotivationIsAddedBonus: boolean;

}
function GetMotivationStatetmentRow(vrStatement:MotivationStatement): string
{
    var Returned: string = "<tr>";
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
function ReturnMotivationStatement(vrStatementID: number) {
    var vrStatement: MotivationStatement = JSON.parse((<HTMLInputElement>document.getElementById("lblMotivationStatement" + vrStatementID.toString())).value);
    if (document.getElementById("lblCurrentMotivationStatement") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentMotivationStatement")).value = JSON.stringify(vrStatement);


    }
    if (document.getElementById("lblCurrentMotivationStatementDesc") != null) {
        (<HTMLInputElement>document.getElementById("lblCurrentMotivationStatementDesc")).innerText = vrStatement.Desc;


    }
    document.getElementById('myStatementModal').style.display = 'none';
}
function FillMotivationStatementTable(lstStatement: MotivationStatement[]) {
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstStatement.length; vrIndex++) {
        vrTable += GetMotivationStatetmentRow(lstStatement[vrIndex]);
    }
    vrTable += "</table>";
    if (document.getElementById("tblStatement") != null) {
        (<HTMLElement>document.getElementById("tblStatement")).innerHTML = vrTable;
    }

}