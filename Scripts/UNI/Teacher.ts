class Teacher {
    public ID: number;
    public Code: string;
    public Name: string;
    public FamousName: string;
    public ShortName: string;
    public FunctionGroup: number;
    public Type: TeacherType = new TeacherType();
    public Faculty: Faculty=new Faculty();

}
function GetTeacherSimpleRow(vrTeacher:Teacher,vrIndex:number): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblTeacher" + vrTeacher.ID + "' value='" + JSON.stringify(vrTeacher) + "'/>";
    Returned += "<td><input  type='button' id='btnReturnTeacher" + vrTeacher.ID.toString() + "' value='+' onclick='SetSelectedTeacher(" + vrTeacher.ID + ");try{GetTeacherSemesterRegisteration();}catch{};return false;'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrTeacher.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrTeacher.Name + "</td>";
    Returned += "<td>" + vrTeacher.Type.NameA + "</td>";
    Returned += "</tr>"
    return Returned;
}
function GetTeacherFullTable(lstTeacher: Teacher[]): string {
    var Returned: string = "<table class=\"table\">";
    for (var vrIndex = 1; vrIndex <= lstTeacher.length; vrIndex++) {
        Returned += GetTeacherSimpleRow(lstTeacher[vrIndex - 1], vrIndex);
    }
    Returned += "</table>";
    return Returned;
}
function SetSelectedTeacher(vrTeacherID: number) {
    var vrTeacher: Teacher = JSON.parse((<HTMLInputElement>document.getElementById("lblTeacher" + vrTeacherID)).value);
    (<HTMLInputElement>document.getElementById("lblSelectedTeacher")).value = JSON.stringify(vrTeacher);
    (<HTMLInputElement>document.getElementById("lblTeacherCode")).innerText = vrTeacher.Code;
    (<HTMLInputElement>document.getElementById("lblTeacherName")).innerText = vrTeacher.Name;
    if (document.getElementById("lblTeacherType") != null) {
        (<HTMLInputElement>document.getElementById("lblTeacherType")).innerText = vrTeacher.Type.NameA;
    }
   
    (<HTMLInputElement>document.getElementById("myTeacherModal")).style.display = "none";


}
function GetCurrentTeatcher(): Teacher {
    var Returned: Teacher = new Teacher();
    if (document.getElementById("lblSelectedTeacher") != null && (<HTMLInputElement>document.getElementById("lblSelectedTeacher")).value!="") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedTeacher")).value);
    }
    return Returned;
}