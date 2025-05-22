class Faculty {
    public ID: number;
    public Code: string;
    public NameA: string;
    public NameE: string;

}
function GetCurrentFacultyID(): number {
    var Returned: number = 0;
    if (document.getElementById("lblCurrentFaculty") != null) {
        try {
            var vrFaculty: Faculty = JSON.parse((<HTMLInputElement>document.getElementById("lblCurrentFaculty")).value);
            Returned = vrFaculty.ID;
        }
        catch {}
    }
    return Returned;
}