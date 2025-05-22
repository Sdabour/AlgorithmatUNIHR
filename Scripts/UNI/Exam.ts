 class Exam {
    public ID: number;
    public Desc: string;
     public Date: Date;
     public DateStr: string;
     public StartTime: Date;
     public EndTime: Date;
     public StartTimeStr: string;
     public EndTimeStr: string;
    public Semester: number;
    public Course: number;
     public Type: number;
     public TypeStr: string;
    public Grade: number;
    public SemesterID: number;
    public SemesterDesc: string;
    public CourseID: number;
    public CourseCode: string;
    public CourseNameA: string;
     public CourseNameE: string;
     public CourseSimple: Course = new Course();
     public SemesterSimple: Semester = new Semester();
     public GroupLst: ExamGroup[] = [];
     public User: number;
}
function GetExamRow(vrExam: Exam): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblExam" + vrExam.ID + "\" value='" + JSON.stringify(vrExam) + "'\>" + vrExam.DateStr + "</td>";
    Returned += "<td>" + vrExam.CourseSimple.Code + "</td>";
    Returned += "<td>" + vrExam.CourseSimple.NameA + "</td>";
    Returned += "<td>" + vrExam.Desc + "</td>";
    Returned += "<td>" + vrExam.StartTimeStr + "</td>";
    Returned += "<td>" + vrExam.EndTimeStr + "</td>";
    if (document.getElementById("myExamModal") != null) {
        Returned += "<td><input type='button' value='+' onclick=\"SetExamData(" + vrExam.ID + ")\"\>" + "</td>";
    }
    Returned += "</tr>";
    return Returned;
}
function FillExamTable(lstExam: Exam[]) {
    var vrExamStr: string = "<table class=\"table\">";
   
    for (var vrIndex = 0; vrIndex < lstExam.length; vrIndex++) {
    
      /*  vrCourse. = lstExam[vrIndex].CourseID;*/
        if (CheckExamTypeAuthorized(lstExam[vrIndex].Type) && CheckCourseAuthorized(lstExam[vrIndex].CourseSimple)) {
            vrExamStr += GetExamRow(lstExam[vrIndex]);
        }

    }
    vrExamStr += "</table>";
    (<HTMLInputElement>document.getElementById("tblExam")).innerHTML = vrExamStr;
}
function ShowExamModal() {
    document.getElementById('myExamModal').style.display = 'block';

}
function ReturnExam(vrExamID: number) {
    var vrExam: Exam = new Exam();
    var vrExamStr: string = (<HTMLInputElement>document.getElementById("lblExam" + vrExamID)).value;
    vrExam = JSON.parse(vrExamStr);
    if (document.getElementById("lblSelectedExam") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedExam")).value = vrExamStr;
    }
    if (document.getElementById("lblSelectedExamCourseCode") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedExamCourseCode")).innerText = vrExam.CourseSimple.Code;
    }
        if (document.getElementById("lblSelectedExamCourseName") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedExamCourseName")).innerText = vrExam.CourseSimple.NameA;
    }
    if (document.getElementById("lblSelectedExamDate") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedExamDate")).innerText = vrExam.Date.toString().substring(1, 10).toString();
    }
    if (document.getElementById("lblSelectedExamDesc") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedExamDesc")).innerText = vrExam.Desc;
    }
        (<HTMLInputElement>document.getElementById("lblSelectedExamGrade")).innerText = vrExam.Grade.toString();
    if (document.getElementById('myExamModal') != null) {
        document.getElementById('myExamModal').style.display = 'none';
    }
    try {
        SetAddEditExamData(vrExam);
    } catch { }
}
function SetAddEditExamData(vrExam:Exam) {
    (<HTMLInputElement>document.getElementById("dtExamDate")).value = vrExam.DateStr;
    (<HTMLInputElement>document.getElementById("dtStartTime")).value = vrExam.StartTimeStr;

    (<HTMLInputElement>document.getElementById("dtEndTime")).value = vrExam.EndTimeStr;
    SetCurrentCourse(vrExam.CourseSimple);
    SetExamType(vrExam.Type);
    if (document.getElementById("txtExamDesc") != null)
        (<HTMLInputElement>document.getElementById("txtExamDesc")).value = vrExam.Desc;
    if (document.getElementById("tblExamGrroup") != null) {
        try {

            GetExamGroupTable(vrExam.GroupLst);
        }
        catch { }
    }
}
function GetExamData(): Exam {
    var Returned: Exam = new Exam();
    if (document.getElementById("lblSelectedExam") != null && (<HTMLInputElement>document.getElementById("lblSelectedExam")).value != "") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedExam")).value);
    }
    var vrCourse: Course = GetCurrentCourse();
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return Returned;
    }
    var strSemester: string = (<HTMLInputElement>document.getElementById("lblSemester")).value;

    var vrSemester: Semester = JSON.parse(strSemester);
    Returned.SemesterSimple = vrSemester;
    Returned.CourseSimple = vrCourse;
    Returned.Date = new Date((<HTMLInputElement>document.getElementById("dtExamDate")).value);

    var vrTimeStr: string = (<HTMLInputElement>document.getElementById("dtStartTime")).value;
    var vrHour: number = 0;
    var vrMinute: number = 0;
    vrHour = Number(vrTimeStr.split(":")[0]);
    vrMinute = Number(vrTimeStr.split(":")[1]);
    Returned.StartTime = new Date();
    Returned.StartTime.setHours(vrHour, vrMinute);

    vrTimeStr = (<HTMLInputElement>document.getElementById("dtEndTime")).value;
    vrHour = 0;
    vrMinute = 0;
    vrHour = Number(vrTimeStr.split(":")[0]);
    vrMinute = Number(vrTimeStr.split(":")[1]);
    Returned.EndTime = new Date();
    Returned.EndTime.setHours(vrHour, vrMinute);
    //Returned.Date = new Date();
    Returned.Desc = (<HTMLInputElement>document.getElementById("txtExamDesc")).value;
    
    var vrType: number = GetExamType();
    if (!CheckExamTypeAuthorized(vrType)) {
        alert("ExamType Not Authorized");
        return Returned;
    }
    Returned.Type = vrType;
    Returned.Grade = GetExamTypeDegree(vrType);
    var vrHallStr: string = "";
    for (var vrIndex = 0; vrIndex < Returned.GroupLst.length; vrIndex++) {
        if (document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString()) != null && (<HTMLInputElement>document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString())).value != "") {
            vrHallStr = (<HTMLInputElement>document.getElementById("lblGroupHallSelected" + Returned.GroupLst[vrIndex].GroupSimple.ID.toString())).value;
            Returned.GroupLst[vrIndex].HallSimple = JSON.parse(vrHallStr);
        }
    }
    return Returned;
}
function GetExamType():number {
    var vrType: number = 0;
    var vrRdLst: string[] = GetExamTypeRadioLst();
    for (var vrIndex = 0; vrIndex < vrRdLst.length; vrIndex++) {
        if (document.getElementById(vrRdLst[vrIndex]) != null && (<HTMLInputElement>document.getElementById(vrRdLst[vrIndex])).checked) {
            vrType = vrIndex + 1;
            break;
        }
    }
    return vrType;
}
function GetExamTypeRadioLst(): string[] {
   
    var vrRdLst: string[] = [];
    vrRdLst[vrRdLst.length] = "rdExamTypeMidterm";
    vrRdLst[vrRdLst.length] = "rdExamTypeSemesterWork";
    vrRdLst[vrRdLst.length] = "rdExamTypeOral";
    vrRdLst[vrRdLst.length] = "rdExamTypePractical";
    vrRdLst[vrRdLst.length] = "rdExamTypeFinal";
    vrRdLst[vrRdLst.length] = "rdExamTypeClinical";
    return vrRdLst;
}
function SetExamType(vrType:number){
    //var vrType: number = 0;
    var vrRdLst: string[] = GetExamTypeRadioLst();

    if (vrType>0 && document.getElementById(vrRdLst[vrType-1]) != null) {
        (<HTMLInputElement>document.getElementById(vrRdLst[vrType - 1])).checked = true;
    }

    
    
}
function GetExamTypeStr(vrLectureType:number,vrExamType: number) {
    var Returned: string;
/* Midterm = 1, SemesterWork = 2, Oral = 3, Practical = 4, Final = 5,Clinical=6*/
    if (vrLectureType == 3) {
        Returned = vrExamType == 1 ? "Midterm" : (vrExamType == 2 ? "Semesterwork" : (vrExamType == 3 ? "Oral" : (vrExamType == 4 ? "Practical" : (vrExamType == 5 ? "Final" : (vrExamType ==6?"Clinical" : "Not Specified")))));
    }
    return Returned;
}
function GetExamTypeDegree(vrType:number): number {
    var Returned: number;
    var vrCourse: Course = GetCurrentCourse();
    if (vrCourse.ID > 0) {
        switch (vrType) {
            case 1: Returned = vrCourse.MidtermDegree; break;
            case 2: Returned = vrCourse.SemesterWorkDegree; break;
            case 3: Returned = vrCourse.OralDegree; break;
            case 4: Returned = vrCourse.PracticalDegree; break;
            case 5: Returned = vrCourse.FinalDegree; break;
            case 6: Returned = vrCourse.ClinicalDegree; break;
            default: Returned = 0;
        }
    }
    return Returned;
}
function CheckExamTypeAuthorized(vrExamType: number): boolean {
    var Returned: boolean = true;
    if (document.getElementById("lblAllExamAuthorized") != null) {
        if ((<HTMLInputElement>document.getElementById("lblAllExamAuthorized")).value == "1") {

            return true;
        }

    }
    if (document.getElementById("lblAssignedType") != null) {
        var vrAssigned: number[] = [];
        if ((<HTMLInputElement>document.getElementById("lblAssignedType")).value != "") {
            vrAssigned = JSON.parse((<HTMLInputElement>document.getElementById("lblAssignedType")).value);
        }
        if (vrAssigned.filter(x => x == vrExamType).length == 0) { return false; }


    }
    return Returned;

} 