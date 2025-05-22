class RegisterationGroup {
    public ID: number;
    
    public Code: string;
    public NameA: string;
    public NameE: string;
    
   
    public Faculty: Faculty = new Faculty();
    public Course: Course = new Course();
    public Semester:Semester=new Semester();
    public LectureType: LectureType = new LectureType();
    public ExamType:number;
    public StudentIDLst: number[] = [];
    public User:number;

}
function GetRegisterationGroupData(): RegisterationGroup {
    var Returned: RegisterationGroup = new RegisterationGroup();
    var vrCourse: Course = GetCurrentCourse();
    if (!CheckCourseAuthorized(vrCourse)) {
        alert("Course Not Authorized");
        return Returned;
    }
    var strSemester: string = (<HTMLInputElement>document.getElementById("lblSemester")).value;

    var vrSemester: Semester = JSON.parse(strSemester);
    Returned.Semester = vrSemester;
    Returned.Course = vrCourse;
    Returned.Faculty = new Faculty();
    Returned.Faculty.ID = GetCurrentFacultyID();
    Returned.LectureType = new LectureType();
    Returned.ExamType = GetExamType();
    var vrLectureType: number = 0;
    if (document.getElementById("cmbLectureType") != null) {
        vrLectureType = Number((<HTMLInputElement>document.getElementById("cmbLectureType")).value);
        Returned.LectureType.ID = vrLectureType;
    }
    Returned.NameA = (<HTMLInputElement>document.getElementById("txtRegisterationGroupNameA")).value;

   
 

    return Returned;
}
function GetRegisterationGroupRow(vrRegisterationGroup: RegisterationGroup): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblRegisterationGroup" + vrRegisterationGroup.ID + "\" value='" + JSON.stringify(vrRegisterationGroup) + "'\>" + vrRegisterationGroup.ID + "</td>";
    Returned += "<td>" + vrRegisterationGroup.LectureType.NameA + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.Code + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.NameA + "</td>";
    Returned += "<td>" + vrRegisterationGroup.Course.NameE + "</td>";
    Returned += "<td>" + vrRegisterationGroup.NameA + "</td>";
    Returned += "<td>" + GetExamTypeStr(vrRegisterationGroup.LectureType.ID,vrRegisterationGroup.ExamType) + "</td>";
  /*  Returned += "<td>" + vrRegisterationGroup.Code + "</td>";*/
    var vrTemp = "ReturnRegisterationGroup(" + vrRegisterationGroup.ID + ");";
    if (document.getElementById("myRegisterationGroupStudentModal") == null && document.getElementById("tblGroupReg")!= null) {
        vrTemp += "SetRegisterationGroupDataByID(" + vrRegisterationGroup.ID + ");";
    }
    if (document.getElementById("tblExamGrroup") == null && document.getElementById("tblGroupReg")== null ) {
        vrTemp += " FillRegisterationGroupStudentData(" + vrRegisterationGroup.ID + "); ";
    }
    else {
        vrTemp += "ReturnNewExamGroup("+vrRegisterationGroup.ID.toString()+")";
    }
    //if (document.getElementById("tblSelectedRegisterationGroup") != null)
    //    vrTemp = "if(CheckRegisterationGroupValidation()){AddRegisterationGroupToSelectedTable(" + vrRegisterationGroup.ID + ");}";
    Returned += "<td><input type='button' value='+' onclick=\"" + vrTemp + "\"\>" + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationGroupTable(vrGroupLst: RegisterationGroup[]) {
    var Returned: string = "";
    Returned = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrGroupLst.length; vrIndex++) {
        Returned += GetRegisterationGroupRow(vrGroupLst[vrIndex]);
    }
    Returned += "</table>";
    (<HTMLInputElement>document.getElementById("tblRegisterationGroup")).innerHTML = Returned;  
   
}
function ReturnRegisterationGroup(vrGroupID:number) {
    var vrGroupStr: string = (<HTMLInputElement>document.getElementById("lblRegisterationGroup" + vrGroupID.toString())).value;
    var vrGroup: RegisterationGroup = JSON.parse(vrGroupStr);
    //checking Search Page
    if (document.getElementById("myRegisterationGroupStudentModal") == null) {
        SetSelectedRegisterationGroupData(vrGroup);
    }
}
function SetSelectedRegisterationGroupData(vrGroup: RegisterationGroup) {
    if (document.getElementById("lblSelectedGroup") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedGroup")).value = JSON.stringify(vrGroup);
    }
    if (document.getElementById("lblSelectedGroupCourseCode") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedGroupCourseCode")).innerText = vrGroup.Course.Code;
    }
    if (document.getElementById("lblSelectedGroupCourseNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedGroupCourseNameA")).innerText = vrGroup.Course.NameA;
    }
    if (document.getElementById("lblSelectedGroupCourseNameE") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedGroupCourseNameE")).innerText = vrGroup.Course.NameE;
    }
    if (document.getElementById("lblSelectedGroupNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblSelectedGroupNameA")).innerText = vrGroup.NameA;
    }
}
function GetCurrentGroup(): RegisterationGroup {
    var Returned: RegisterationGroup=new RegisterationGroup();
    if (document.getElementById("lblSelectedGroup") != null && (<HTMLInputElement>document.getElementById("lblSelectedGroup")).value!="") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedGroup")).value);
        Returned.StudentIDLst = [];
        if (document.getElementById("lblRegIDs") != null && (<HTMLInputElement>document.getElementById("lblRegIDs")).value != "") {
            var vrIDs: number[] = JSON.parse((<HTMLInputElement>document.getElementById("lblRegIDs")).value);
            for (var vrIndex = 0; vrIndex < vrIDs.length; vrIndex++) {
                if ((<HTMLInputElement>document.getElementById("chkSelectedReg" + vrIDs[vrIndex].toString())).checked) {
                    Returned.StudentIDLst[Returned.StudentIDLst.length] = vrIDs[vrIndex];
                }
            }
        }

    }
    return Returned;
}
function ReturnNewExamGroup(vrGroupID:number) {
    var vrRegisterationGroup: RegisterationGroup = new RegisterationGroup();
    if (document.getElementById("lblRegisterationGroup" + vrGroupID.toString()) != null) {
        vrRegisterationGroup = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisterationGroup" + vrGroupID.toString())).value);
    }
    var vrExam: Exam = new Exam();
    vrExam.GroupLst = [];
    var vrExamStr = (<HTMLInputElement>document.getElementById("lblSelectedExam")).value;
    if (vrExamStr != "") {
        vrExam = JSON.parse(vrExamStr);
        if (vrExam.GroupLst == null || vrExam.GroupLst.length == 0) { vrExam.GroupLst = []; }
        var vrExamGroup: ExamGroup = new ExamGroup();
        vrExamGroup.GroupSimple = vrRegisterationGroup;
        vrExam.GroupLst[vrExam.GroupLst.length] = vrExamGroup;
        (<HTMLInputElement>document.getElementById("lblSelectedExam")).value = JSON.stringify(vrExam);
        GetExamGroupTable(vrExam.GroupLst);
    }
    if (document.getElementById("myRegisterationGroupModal") != null) {
        document.getElementById("myRegisterationGroupModal").style.display = "none";
    }
}