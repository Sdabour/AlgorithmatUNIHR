class StudentResult {

    public ID: number;
    public Statement: number;
    public Student: number;
    public  StudentSimple:Student;
    public CGPA: string;
    public CPoints: number;
    public TotalCreditHour: number;
    public EarnedHour: number;
    public SCreditHour: number;
    public SEarnedHour: number;
    public SGPA: string;
    public SPoints: number;
    public Note: string;
    public Level: number;
    public Stopped: boolean;

    public StopReason: string;
    public NewLevelOrder:number;

    public NewLevelDesc:string;

    public  OldLevelOrder:number;

    public OldLevelDesc:string;
    public lstSemester: Semester[] = [];
       
}
function GetStudentResultPivotTableRow(objBiz: StudentResult, objCourseCol: Course[]): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudentResult" + objBiz.ID + "' value='" + JSON.stringify(objBiz) + "'/>";
    Returned += "<td><input type='button' value='تفاصيل' onclick='ShowRegisterationModal(" + objBiz.ID + ")'></td>";
    Returned += "<td>" + objBiz.StudentSimple.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + objBiz.StudentSimple.NameA + "</label></td>";
    Returned += "<td>" + objBiz.CPoints + "</td>";
    Returned += "<td>" + objBiz.EarnedHour + "</td>";

    // Returned += "<td>" + objBiz.Verbal + "</td>";
    var vrCourse: Course;
    var vrReg: Registeration;
    var vrRegLst: Registeration[];
    for (var vrIndex = 0; vrIndex < objCourseCol.length; vrIndex++) {
        vrCourse = objCourseCol[vrIndex];
        vrReg = new Registeration();
        vrReg.ID = 0;
        var vrTempStudent: Student = new Student();
        vrRegLst = vrTempStudent.GetRegisterationLst(objBiz.lstSemester).filter(x => x.Course == vrCourse.ID);
        if (vrRegLst.length > 0) {
            vrReg = vrRegLst[0];

        }
        Returned += "<td>";
        if (vrReg.ID > 0) {
            Returned += vrReg.GPA;
        }
        Returned += "</td>";
        Returned += "<td>";
        if (vrReg.ID > 0) {
            Returned += vrReg.Points;
        }
        Returned += "</td>";

    }
    Returned += "</tr>";
    return Returned;
}
function GetStudentResultRow(vrStudent: StudentResult): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='تثبيت' onclick='AddStudentToSelectedTable(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrStudent.StudentSimple.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrStudent.StudentSimple.NameA + "</label></td>";
    Returned += "</tr>"
    return Returned;
}
function GetStudentResultSimpleRow(vrResult: StudentResult): string {
    var Returned: string = "<tr>";
    Returned += "<td>" + vrResult.StudentSimple.Code + "</td>";
    Returned += "<td>" + vrResult.StudentSimple.NameA + "</td>";
    Returned += "<td>" + vrResult.CGPA + "</td>";
    Returned += "<td>" + vrResult.CPoints + "</td>";
    Returned += "<td>SGPA : [" + vrResult.SGPA + "]</td>";
    Returned += "<td>" + vrResult.SPoints + "</td>";

    Returned += "<td>TH:" + vrResult.TotalCreditHour + "</td>";
    Returned += "<td>EH:" + vrResult.EarnedHour + "</td>";
    Returned += "<td>SCH:" + vrResult.SCreditHour + "</td>";
    Returned += "<td>SEH:" + vrResult.SEarnedHour + "</td>";

    Returned += "<td>Old Level:" + vrResult.OldLevelDesc + "</td>";
    Returned += "<td>New Level:" + vrResult.NewLevelDesc + "</td>";
    Returned += "</tr>";
    return Returned;
}
function GetStudentResultFullTable(vrResultLst: StudentResult[]) :string{
    var Returned: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrResultLst.length; vrIndex++) {
        Returned += GetStudentResultSimpleRow(vrResultLst[vrIndex]);
    }
    Returned += "</table>";
    return Returned;

}
