class Semester {
    public ID: number;
    public Desc: string;
    public DateStart: Date;
    public DateEnd: Date; 
    public  Grade:number;
    public Verbal: string;
    public Type: number;
    public EarnedHours: number;
    public TotalHours: number;
    public  lstRegisteration:Registeration[]=[];
}
function GetCurrentSemester(): Semester {
    var Returned: Semester = new Semester();
    if (document.getElementById("lblSemester") != null && (<HTMLInputElement>document.getElementById("lblSemester")).value != "") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblSemester")).value);
    }
    return Returned;
}