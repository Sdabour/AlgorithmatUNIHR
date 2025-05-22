class Level {
    public Level:number;
    public LevelDesc:string;
    public lstStudent: Student[] = [];
    public lstCourse: Course[] = [];


    public ID: number;
    public Faculty: number;
    public Order: number;
    public Desc: string;
    public CreditHourFrom: number;
    public CreditHourTo: number;
    public SemesterType1MaxLimitedHour: number;
    public SemesterType2MaxLimitedHour: number;
    public SemesterType3MaxLimitedHour: number;
    public LowGPALimitedHour: number;

}
function GetLevelBivot(): string {

    var Returned: string = "<table class=\"table\"><tr><th></th> <th colspan=\"2\">Student</th>";
   
    //Returned += "<th>Points</th>";
    Returned += "<th>CGPA</th>";
    Returned += "<th>E.Hours</th>";
    var vrLevelStr = (<HTMLInputElement>document.getElementById("lblLevel")).value;
    var lstLevel : Level[]= JSON.parse(vrLevelStr);
    var vrLevelIndex = (<HTMLInputElement>document.getElementById("cmbLevel")).value;
    var vrLevel: Level = lstLevel[Number(vrLevelIndex)];
    var vrCourseLst: Course[] = vrLevel.lstCourse;
    var vrCourse: Course;
    for (var vrIndex = 0; vrIndex < vrCourseLst.length; vrIndex++)
    {
        vrCourse = vrCourseLst[vrIndex];
        Returned += "<th colspan=\"2\">"+ vrCourse.NameA +"</th>";
    }
    Returned += "</tr>";
    var vrStudentName: string = (<HTMLInputElement>document.getElementById("txtName")).value;
    if (vrStudentName == null || vrStudentName == undefined)
        vrStudentName = "";
    var vrStudentLst: Student[] = vrLevel.lstStudent.filter(x => vrStudentName == "" || x.NameA.indexOf(vrStudentName) != -1 || x.Code.indexOf(vrStudentName) != -1);
    var vrStudent: Student;
    for (var vrIndex = 0; vrIndex < vrStudentLst.length; vrIndex++)
    {
        vrStudent = vrStudentLst[vrIndex];
        Returned += GetStudentPivotTableRow(vrStudent, vrCourseLst);
    }

    Returned += "</table>";
    return Returned;
}
function FillLevel(): boolean {
    var vrTable: string = GetLevelBivot();
    (<HTMLInputElement>document.getElementById("dvLevel")).innerHTML = vrTable;
    return false;
}
function GetLevel(intLevel): Level {
    var Returned: Level = new Level();
    if (document.getElementById("lblAllLevel") != null && (<HTMLInputElement>document.getElementById("lblAllLevel")).value != "") {
        var vrLevelLst: Level[] = JSON.parse((<HTMLInputElement>document.getElementById("lblAllLevel")).value);
        var vrLst: Level[] = vrLevelLst.filter(x => x.Level == intLevel);
        if (vrLst.length > 0)
            Returned = vrLst[0];
        
    }
    return Returned;
}
function GetMaxRegisterationCreditHour(vrStudent: Student, vrSemester: Semester): number{
    var vrLevel: Level = GetLevel(vrStudent.LastGrade);
    var Returned: number = 0;
    if (vrSemester.Type == 1) {

        Returned = vrLevel.SemesterType1MaxLimitedHour;
    }
    else if (vrSemester.Type == 2) {

        Returned = vrLevel.SemesterType2MaxLimitedHour;
    }
    else if (vrSemester.Type == 3) {

        Returned = vrLevel.SemesterType3MaxLimitedHour;
    }
    if (vrStudent.LastGrade > 1 && vrStudent.MaxResultCPoints < 1 && Returned > vrLevel.LowGPALimitedHour ) {
        Returned = vrLevel.LowGPALimitedHour;
    }
   
    //if(vrStudent.Level==)
    return Returned;
}
