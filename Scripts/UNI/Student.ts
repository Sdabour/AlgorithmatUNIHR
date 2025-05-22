class Student
{
    public ID: number;
    public Code: string;
    public NameA: string;
    public NameE: string;
    public BirthDate: Date;
    public Mobile1: string;
    public Mobile2: string;
    public Phone1: string;
    public Phone2: string;
    public Address: string;
    public Email: string;
    public HomeCity: number;
    public HomeCountry: number;
    public Points: number;
    public Verbal: string;
    public EarnedHours: number;
 
    public TotalHours: number;
    public Level: string;
    public LastGrade: number;
    public MaxResultCGPA: string;
    public MaxResultCPoints: number;
    public MaxResultTotalCreditHour: number;
    public MaxResultEarnedHour: number;
    public MaxResultSGPA: string;
    public MaxResultSPoints: number;
    public MaxResultNote: string;


    //public lstRegisteration: Registeration[] = [];
    public lstSemester: Semester[] = [];
    GetRegisterationLst(lstSemester:Semester[]): Registeration[] {
        var Returned: Registeration[] = [];
        for (var vrIndex = 0; vrIndex <lstSemester.length; vrIndex++) {
            for (var vrIndex1 = 0; vrIndex1 < lstSemester[vrIndex].lstRegisteration.length; vrIndex1++) {
                Returned[Returned.length] = lstSemester[vrIndex].lstRegisteration[vrIndex1];
            }
        }
        return Returned;
    }
}

function GetStudentPivotTableRow(objBiz: Student,objCourseCol:Course[]): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudent"+ objBiz.ID +"' value='"+JSON.stringify(objBiz)+"'/>";
    Returned += "<td><input type='button' value='-' onclick='ShowRegisterationModal("+objBiz.ID+")'></td>";
    Returned += "<td>" + objBiz.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
   // text - align: center;>
        Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + objBiz.NameA + "</label></td>";
    Returned += "<td>" + objBiz.Points + "</td>";
    Returned += "<td>" + objBiz.EarnedHours + "</td>";
   // Returned += "<td>" + objBiz.Verbal + "</td>";
    var vrCourse: Course;
    var vrReg: Registeration;
    var vrRegLst:Registeration[];
    for (var vrIndex = 0; vrIndex < objCourseCol.length; vrIndex++)
    {
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
function GetStudentRow(vrStudent: Student,vrIndex:number): string{
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='+' onclick='AddStudentToSelectedTable(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";
    Returned+="</tr>"
    return Returned;
}
function GetStudentFullRow(vrStudent: Student, vrIndex: number): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='+' onclick='AddStudentToSelectedTable(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";
    Returned += "<td>" + vrStudent.Email + "</td>";
    Returned += "<td>Level" + vrStudent.Level + "</td>";
    Returned += "</tr>"
    return Returned;
}
function GetStudentFullTable(lstStudent: Student[]):string {
    var Returned: string = "<table class=\"table\">";
    for (var vrIndex = 1; vrIndex <= lstStudent.length; vrIndex++) {
        Returned += GetStudentFullRow(lstStudent[vrIndex - 1], vrIndex);
    }
    Returned += "</table>";
    return Returned;
}
function GetStudentSimpleRow(vrStudent: Student, vrIndex: number): string {
    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input  type='button' id='btnReturnStudent"+vrStudent.ID.toString()+"' value='+' onclick='SetSelectedStudent(" + vrStudent.ID + ");try{GetStudentSemesterRegisteration();}catch{};return false;'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td>" + vrStudent.NameA + "</td>";

    Returned += "</tr>"
    return Returned;
}
function GetSeldectedStudentRow(vrStudent:Student,vrIndex:number): string {
    

    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblSelectedStudent" + vrStudent.ID + "' value='" + JSON.stringify(vrStudent) + "'/>";
    Returned += "<td><input type='button' value='-' onclick='RemoveSelectdStudent(" + vrStudent.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrStudent.Code + "</td>";
    //Returned += "<td>" + vrStudent.NameA + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrStudent.NameA + "</label></td>";
    Returned += "</tr>"
    return Returned;
}
function AddStudentToSelectedTable(vrStudentID: number) {
    var vrStudent = JSON.parse((<HTMLInputElement>document.getElementById("lblStudent"+vrStudentID)).value);

    var vrStudentStr: string = (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value;
    var lstSelectedStudent: Student[] = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);

    }
    if (lstSelectedStudent.length ==0 || lstSelectedStudent.filter(x=>x.ID==vrStudentID).length==0) {
        lstSelectedStudent[lstSelectedStudent.length] = vrStudent;
        (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value = JSON.stringify(lstSelectedStudent);

        FillSelectedStudentTable();
    }
  

}
function SetSelectedStudent(vrStudentID: number) {
    var vrStudent:Student = JSON.parse((<HTMLInputElement>document.getElementById("lblStudent" + vrStudentID)).value);
    (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value = JSON.stringify( vrStudent);
    (<HTMLInputElement>document.getElementById("lblStudentCode")).innerText = vrStudent.Code;
    (<HTMLInputElement>document.getElementById("lblStudentName")).innerText = vrStudent.NameA;
    if (document.getElementById("lblStudentEH") != null) {
        (<HTMLInputElement>document.getElementById("lblStudentEH")).innerText = vrStudent.MaxResultEarnedHour.toString();
    }
    if (document.getElementById("lblStudentCGPA") != null) {
        (<HTMLInputElement>document.getElementById("lblStudentCGPA")).innerText = vrStudent.MaxResultCPoints.toString();
    }
    if (document.getElementById("lblStudentLevel") != null) {
        (<HTMLInputElement>document.getElementById("lblStudentLevel")).innerText = vrStudent.Level;
    }
    (<HTMLInputElement>document.getElementById("myStudentModal")).style.display = "none";


}
function FillSelectedStudentTable() {
    var vrStudentStr: string = (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value;
    var vrStudent: Student;
    var lstSelectedStudent: Student[] = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);

    }
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstSelectedStudent.length; vrIndex++) {
        vrStudent = lstSelectedStudent[vrIndex];

       // vrTable += "<tr>";
        vrTable += GetSeldectedStudentRow(vrStudent,vrIndex+1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblSelectedStudent")).innerHTML = vrTable;

}
function FillStudentTable(lstStudent:Student[]) {
    var vrStudent: Student; 
    (<HTMLInputElement>document.getElementById("lblStudent")).value = JSON.stringify(lstStudent);
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];

      //  vrTable += "<tr>";
        vrTable += GetStudentRow(vrStudent,vrIndex+1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblStudent")).innerHTML = vrTable;

}
function FillStudentSimpleTable(lstStudent: Student[]) {
    var vrStudent: Student;
    (<HTMLInputElement>document.getElementById("lblStudent")).value = JSON.stringify(lstStudent);
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];

        //  vrTable += "<tr>";
        vrTable += GetStudentSimpleRow(vrStudent, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblStudent")).innerHTML = vrTable;

}
function RemoveSelectdStudent(vrStudentID: number) {
    var vrStudentStr: string = (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value;
    var vrStudent: Student;
    var lstSelectedStudent: Student[] = [];
    var lstNewSelectedStudent: Student[] = [];
    if (vrStudentStr != null && vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);
        for (var vrIndex = 0; vrIndex < lstSelectedStudent.length; vrIndex++) {
            if (lstSelectedStudent[vrIndex].ID != vrStudentID) {
                lstNewSelectedStudent[lstNewSelectedStudent.length] = lstSelectedStudent[vrIndex];

            }
            (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value = JSON.stringify(lstNewSelectedStudent);
            FillSelectedStudentTable();
        }
    }
}
function GetStudentData():Student {
    var Returned: Student = new Student();
    var vrTemp: string ="";
    if (document.getElementById("lblStudent") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("lblStudent")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned = JSON.parse(vrTemp);
        }
    }
    if (document.getElementById("txtStudentCode") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentCode")).value;
        if (vrTemp != null && vrTemp != "") {
          Returned.Code = vrTemp;
        }
    }
    if (document.getElementById("txtStudentNameA") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentNameA")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.NameA = vrTemp;
        }
    }
    if (document.getElementById("txtStudentNameE") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentNameE")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.NameE = vrTemp;
        }
    }
    if (document.getElementById("dtStudentBirthDate") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("dtStudentBirthDate")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.BirthDate =new Date(vrTemp);
        }
    }
    if (document.getElementById("txtStudentMobile1") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentMobile1")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Mobile1 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentMobile2") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentMobile2")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Mobile2 = vrTemp;
        }
    }

    if (document.getElementById("txtStudentPhone1") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentPhone1")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Phone1 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentPhone2") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentPhone2")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Phone2 = vrTemp;
        }
    }
    if (document.getElementById("txtStudentAddress") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentAddress")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Address = vrTemp;
        }
    }
    if (document.getElementById("txtStudentEmail") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("txtStudentEmail")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.Email = vrTemp;
        }
    }
    if (document.getElementById("cmbHomeCity") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("cmbHomeCity")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.HomeCity = Number(vrTemp);
        }

    }
    if (document.getElementById("cmbHomeCountry") != null) {
        vrTemp = (<HTMLInputElement>document.getElementById("cmbHomeCountry")).value;
        if (vrTemp != null && vrTemp != "") {
            Returned.HomeCountry = Number(vrTemp);
        }

    }
    return Returned;
}

function SetStudentData(vrStudent:Student){
     
    var vrTemp: string = "";
    if (document.getElementById("lblStudent") != null) {
       (<HTMLInputElement>document.getElementById("lblStudent")).value=JSON.stringify(vrStudent);
        
    }
    if (document.getElementById("txtStudentCode") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentCode")).value = vrStudent.Code;
        }
   
    if (document.getElementById("txtStudentNameA") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentNameA")).value = vrStudent.NameA;
    }
    if (document.getElementById("txtStudentNameE") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentNameE")).value = vrStudent.NameE;
    }
    if (document.getElementById("dtStudentBirthDate") != null) {
        (<HTMLInputElement>document.getElementById("dtStudentBirthDate")).value = vrStudent.BirthDate.toISOString().substring(0, 10);
    }
    if (document.getElementById("txtStudentMobile1") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentMobile1")).value = vrStudent.Mobile1;
    }
    if (document.getElementById("txtStudentMobile2") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentMobile2")).value = vrStudent.Mobile2;
    }

    if (document.getElementById("txtStudentPhone1") != null) {
       (<HTMLInputElement>document.getElementById("txtStudentPhone1")).value = vrStudent.Phone1;
    }
    if (document.getElementById("txtStudentPhone2") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentPhone2")).value = vrStudent.Phone2;
    }
    if (document.getElementById("txtStudentAddress") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentAddress")).value = vrStudent.Address;
    }
    if (document.getElementById("txtStudentEmail") != null) {
        (<HTMLInputElement>document.getElementById("txtStudentEmail")).value = vrStudent.Email;
    }
    if (document.getElementById("cmbHomeCity") != null) {
        (<HTMLInputElement>document.getElementById("cmbHomeCity")).value = vrStudent.HomeCity.toString();

    }
    if (document.getElementById("cmbHomeCountry") != null) {
        (<HTMLInputElement>document.getElementById("cmbHomeCountry")).value = vrStudent.HomeCountry.toString();

    }
   
}
function SelectAllStudent() {
    var vrStudentStr: string = (<HTMLInputElement>document.getElementById("lblStudent")).value;
    var lstStudent: Student[] = [];
    if (vrStudentStr != "") {
        lstStudent = JSON.parse(vrStudentStr);
    }
    var vrStudent: Student = new Student();
    var lstSelectedStudent: Student[] = [];
    vrStudentStr = (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value;
    if (vrStudentStr != "") {
        lstSelectedStudent = JSON.parse(vrStudentStr);

    }
    for (var vrIndex = 0; vrIndex < lstStudent.length; vrIndex++) {
        vrStudent = lstStudent[vrIndex];
        if (lstSelectedStudent.filter(x => x.ID == vrStudent.ID).length == 0) {
            lstSelectedStudent[lstSelectedStudent.length] = vrStudent;
        }
    }
    vrStudentStr = JSON.stringify(lstSelectedStudent);
    (<HTMLInputElement>document.getElementById("lblSelectedStudent")).value = vrStudentStr;
    FillSelectedStudentTable();
    (<HTMLInputElement>document.getElementById("myStudentModal")).style.display = "none";
}