class Lecture {
    public ID: number;
    
    public Date: Date;
    public DateStr: string;
    public StartTime: Date;
    public StartTimeStr: string;
    public EndTime: Date;
    public EndTimeStr: string;
    public BreakDurationInMinutes: number;
    public Scheduled: boolean;
    public AttendanceMandatory: boolean;
    public Note: string;
    public Hall: number;
    public GUUID: string;
    public CourseSimple:Course;
    public SemesterSimple : Semester;
   public TeacherSimple : Teacher;
    public TypeSimple: LectureType;
}
function GetLectureRow(vrLecture: Lecture): string
{
    var Returned: string = "";
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblLecture" + vrLecture.ID + "\" value='" + JSON.stringify(vrLecture) + "'\>" + vrLecture.DateStr + "</td>";
    Returned += "<td>" + vrLecture.CourseSimple.Code + "</td>";
    Returned += "<td>" + vrLecture.CourseSimple.NameA + "</td>";
    Returned += "<td>" + vrLecture.TeacherSimple.Name + "</td>";
    Returned += "<td>" + vrLecture.StartTimeStr + "</td>";
    Returned += "<td>" + vrLecture.EndTimeStr + "</td>";
    if (document.getElementById("myLectureSearchModal") != null) {
        Returned += "<td><input type='button' value='+' onclick=\"ReturnLecture(" + vrLecture.ID.toString() + ");RefreshQR();SetLectureRegisterationData(" + vrLecture.ID.toString() + ");\"\>" + "</td>";
    }
    return Returned;
}
function GetLectureTable(lstLecture: Lecture[]) :string{
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstLecture.length; vrIndex++)
    {
        vrTable += GetLectureRow(lstLecture[vrIndex]);
    }
    vrTable += "</table>";
    return vrTable;
}
function CheckLectureData(): boolean {
    var Returned: boolean = true;
    var vrCourse: Course = GetCurrentCourse();
    if (vrCourse.ID == 0) {
        alert("حدد الكورس");
        return false;
    }
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return false;
    }
    if (document.getElementById("cmbLectureType") == null || (<HTMLInputElement>document.getElementById("cmbLectureType")).value == "0") {
        alert("حدد نوع المحاضرة");
        return false;
    }
    var vrTeacher: Teacher;
    vrTeacher = GetCurrentTeatcher();
    if (vrTeacher.ID == 0) {
        alert("حدد المحاضر");
        return false;
    }
    return Returned;
}
function GetLectureData(): Lecture {
    var Returned: Lecture = new Lecture();
    var vrCourse: Course = GetCurrentCourse();
    var strSemester: string = (<HTMLInputElement>document.getElementById("lblSemester")).value;

    var vrSemester: Semester = JSON.parse(strSemester);
    Returned.SemesterSimple = vrSemester;

    Returned.CourseSimple = vrCourse;
    var vrTimeStr: string = (<HTMLInputElement>document.getElementById("dtStartTime")).value;
    var vrHour: number=0;
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
    Returned.Date = new Date();


/*    Returned.EndTime = new Date((<HTMLInputElement>document.getElementById("dtEndTime")).value);*/
   /* Returned.Desc = (<HTMLInputElement>document.getElementById("txtLectureDesc")).value;*/

    var vrType: number = Number((<HTMLInputElement>document.getElementById("cmbLectureType")).value);
    
    Returned.TypeSimple = new LectureType();
    Returned.TypeSimple.ID = vrType;
    Returned.TeacherSimple = GetCurrentTeatcher();

    return Returned;
}
function ShowLectureModal() {
    document.getElementById('myLectureModal').style.display = 'block';

}

function ReturnLecture(vrLectureID: number) {
    var vrLecture: Lecture = new Lecture();
    var vrLectureStr: string = (<HTMLInputElement>document.getElementById("lblLecture" + vrLectureID)).value;
    vrLecture = JSON.parse(vrLectureStr);
    SetSelectedLectureData(vrLecture);
}
function SetSelectedLectureData(vrLecture: Lecture) {
    var vrLectureStr: string = JSON.stringify(vrLecture);


(<HTMLInputElement>document.getElementById("lblSelectedLecture")).value = vrLectureStr;
    (<HTMLInputElement>document.getElementById("lblSelectedLectureCourseCode")).innerText = vrLecture.CourseSimple.Code;
    (<HTMLInputElement>document.getElementById("lblSelectedLectureCourseName")).innerText = vrLecture.CourseSimple.NameA;
    (<HTMLInputElement>document.getElementById("lblSelectedLectureDate")).innerText = vrLecture.Date.toString().substring(1, 10).toString();


    if (document.getElementById("myLectureSearchModal") != null) { (<HTMLInputElement>document.getElementById('myLectureSearchModal')).style.display = 'none'; }
}
function GetCurrentLecture(): Lecture {
    var vrLecture: Lecture = new Lecture();
    vrLecture.ID = 0;
    if (document.getElementById("lblSelectedLecture") == null || (<HTMLInputElement>document.getElementById("lblSelectedLecture")).value == "") {
        return vrLecture;
    }
    var vrLectureStr = (<HTMLInputElement>document.getElementById("lblSelectedLecture")).value;
    vrLecture = JSON.parse(vrLectureStr);

    return vrLecture;
}

function GetRegisterationLectureRow(vrReg: Registeration, vrIndex: number): string {
    var Returned: string = "";
    var vrID: string = vrReg.ID.toString() ;
    Returned += "<tr>";
    Returned += "<td>" + vrIndex + "<input type=\"hidden\" id=\"lblRegLecture" + vrID + "\" value='" + JSON.stringify(vrReg) + "' />" + "</td>";
    Returned += "<td><input type=\"checkBox\" id=\"chkSelected" + vrID + "\"  onchange=\"CheckLectureReg("+vrID+");\" />" + "</td>";
    Returned += "<td>" + vrReg.StudentCode + "</td>";
    Returned += "<td>" + vrReg.StudentName + "</td>";
   
   
   
   /* Returned += "<td><input type=\"button\" class=\"form-control\" id=\"btnSaveReg" + vrReg.ID + "\" value=\"حفظ\" onclick=\"SaveRegisterationLecture(" + vrReg.ID + "," + vrReg.ID + ")\"/></td>";*/
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationLectureLst(lstReg: Registeration[]) {
    var vrIDs: string[] = [];
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstReg.length; vrIndex++) {
        if (document.getElementById("txtFilter") == null || (<HTMLInputElement>document.getElementById("txtFilter")).value == "" || lstReg[vrIndex].StudentName.indexOf((<HTMLInputElement>document.getElementById("txtFilter")).value) != -1 || lstReg[vrIndex].StudentCode.indexOf((<HTMLInputElement>document.getElementById("txtFilter")).value) != -1)
        vrTable += GetRegisterationLectureRow(lstReg[vrIndex], vrIndex + 1);
        vrIDs[vrIDs.length] = lstReg[vrIndex].ID.toString();
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblReg")).innerHTML = vrTable;
    (<HTMLInputElement>document.getElementById("lblLectureIDs")).value = JSON.stringify(vrIDs);

}
function CheckLectureReg(vrID: number) {
    if (document.getElementById("chkSelected") != null ) {

    }
}
function CheckAllLectureRegisteration() {
    var vrChecked: boolean = false;
    if (document.getElementById("chkSelectAll") == null)
        return;
    vrChecked = (<HTMLInputElement>document.getElementById("chkSelectAll")).checked;
    var arrReg: number[] = [];
    if (document.getElementById("lblRegIDs") != null && (<HTMLInputElement>document.getElementById("lblRegIDs")).value != "") {
        arrReg = JSON.parse((<HTMLInputElement>document.getElementById("lblRegIDs")).value);
    }
    

}