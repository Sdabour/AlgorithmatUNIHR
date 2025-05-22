class Registeration {
    public ID: number;
    public EqualID: number;
    public EqualName;

    public Student: number;
    public  StudentCode:string;
    public StudentName: string;
    public StudentGender: number;
    public Date: Date;
    public Semester: number;
    public SemesterDesc: string;
    public Course: number;
    public CourseCode: string;
    public CourseName: string;
    public CourseFinalDegree: number;

    public Level: number;
    public Iteration: number;
    public MidtermDegree: number;
    public SemesterWorkDegree: number;
    public PracticalDegree: number;
    public OralDegree: number;
    public FinalDegree: number;
    public ClinicalDegree: number;
    public Bonus: number;
    public TotalValue:number;
    public  Points:number;
    public GPA: string;
    public VerbalGPA:string;
    public Note: string;
    public Posted:boolean;
    public ResultID:number;
    public UserID: number;
    public UserName: string;
    public Password: string;
    public SeatNo: string;
    public GroupName: string;
    public CourseSimple: Course;
    public PrequisitCourseCount: number;
    public PrequisitPassedCourseCount: number;
    public PrequisitLst: Registeration[] = [];

    public MainRegisterationID: number;
    public SourceRegisterationID: number;
    public SourceRegisterationDate: Date;
    public SourceSemesterID: number;
    public SourceSemesterDesc: string;
    public SourceMidtermDegree: number;
    public SourceSemesterWorkDegree: number;
    public SourcePracticalDegree: number;
    public SourceOralDegree: number;
    public SourceFinalDegree: number;
    public SourceVerbalGPA: string;
    public SourceGPA: number;
    public SourceStatus: number;
    public SourceNote: string;
    public SourceResult: number;
    public MTStatus: number;
    public SWStatus: number;
    public PStatus: number;
    public OStatus: number;
    public FStatus: number;
    public CStatus: number;

}
function GetRegisterationRow(vrRegisteration: Registeration):string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
   /* Returned += "<td><input type='button' onClick=\"ShowRegistrationEditModal(" + vrRegisteration.ID.toString() + ")\"/> </td>";*/
    Returned += "<td>" + vrRegisteration.ID.toString() + "</td>";
    Returned += "<td>" + vrRegisteration.CourseCode + "</td>";
    Returned += "<td>" + vrRegisteration.CourseName + "</td>";
    Returned += "<td>" + vrRegisteration.CourseSimple.CreditHour + "</td>";
    Returned += "<td>" + vrRegisteration.Points + "</td>";
    Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    Returned += "<td>" + vrRegisteration.MidtermDegree + "</td>";
    Returned += "<td>" + vrRegisteration.SemesterWorkDegree + "</td>";
    Returned += "<td>" + vrRegisteration.OralDegree + "</td>";
    Returned += "<td>" + vrRegisteration.PracticalDegree + "</td>";
    Returned += "<td>" + vrRegisteration.FinalDegree + "</td>";
    Returned += "<td>" + vrRegisteration.Bonus+ "</td>";
    Returned += "<td>" + vrRegisteration.ClinicalDegree + "</td>";
    if (vrRegisteration.PrequisitCourseCount > 0 && vrRegisteration.PrequisitLst.length>0) {
        Returned += "<td><input type=\"button\" value=\"Prequisit\"></td>";
    }
    Returned += "</tr>";
    return Returned;
}

function GetRegisterationSimpleRow(vrRegisteration: Registeration, vrPreviousID: number): string {
    var vrPreviousReg: Registeration = new Registeration();
    var vrPrvRegStr: string = "";
    if (document.getElementById("lblRegisteration" + vrPreviousID.toString()) != null) {
        vrPrvRegStr = (<HTMLInputElement>document.getElementById("lblRegisteration" + vrPreviousID.toString())).value;
    }
    if (document.getElementById("lblRegisteration" + vrPreviousID.toString()) != null && (<HTMLInputElement>document.getElementById("lblRegisteration" + vrPreviousID.toString())).value != "") {
        vrPreviousReg = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisteration" + vrPreviousID.toString())).value);
    }
    var Returned: string = "";
    Returned += "<tr>";
   /* Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "' />";*/
    /* Returned += "<td><input type='button' onClick=\"ShowRegistrationEditModal(" + vrRegisteration.ID.toString() + ")\"/> </td>";*/
    Returned += "<td>";
   
        Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID.toString() + "' value='" + JSON.stringify(vrRegisteration) + "' />";
   
    Returned+= vrRegisteration.ID.toString() + "</td>";
    if (vrPreviousReg.ID == 0 || vrPreviousReg.Course != vrRegisteration.Course) {
        Returned += "<td>" + vrRegisteration.CourseCode + "</td>";
        Returned += "<td>" + vrRegisteration.CourseName + "</td>";
        Returned += "<td>" + vrRegisteration.CourseSimple.CreditHour + "</td>";
    }
    else {
        Returned += "<td></td><td></td><td></td>";
    }
    if (vrPreviousReg.ID == 0 || vrPreviousReg.Student != vrRegisteration.Student) {
        Returned += "<td>" + vrRegisteration.StudentCode + "</td>";
        Returned += "<td>" + vrRegisteration.StudentName + "</td>";
       
    }
    else {
        Returned += "<td></td><td></td>";
    }

    Returned += "<td>" + vrRegisteration.Points + "</td>";
    Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    Returned += "<td>" + vrRegisteration.MidtermDegree + "</td>";
    Returned += "<td>" + vrRegisteration.SemesterWorkDegree + "</td>";
    Returned += "<td>" + vrRegisteration.OralDegree + "</td>";
    Returned += "<td>" + vrRegisteration.PracticalDegree + "</td>";

    Returned += "<td>" + vrRegisteration.FinalDegree + "</td>";
    Returned += "<td>" + vrRegisteration.Bonus + "</td>";
    Returned += "<td>" + vrRegisteration.ClinicalDegree + "</td>";
    if (vrRegisteration.PrequisitCourseCount > 0 && vrRegisteration.PrequisitLst.length > 0) {
        Returned += "<td><input type=\"button\" value=\"Prequisit\" onclick=\"ShowPrequisitModal("+vrRegisteration.ID+")\"></td>";
    }
    Returned += "</tr>";
    return Returned;
}
function GetRegisterationSimpleTable(vrRegLst: Registeration[]): string
{
    var PrevID = 0;
    var Returned: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrRegLst.length; vrIndex++) {
        if (vrIndex > 0)
        {
            PrevID = vrRegLst[vrIndex - 1].ID;
        }
        Returned += GetRegisterationSimpleRow(vrRegLst[vrIndex], PrevID);
    }
    Returned += "</table>";
    return Returned;
}

function GetRegisterationEditTable(vrRegLst: Registeration[]): string {
    var vrContainsOral: boolean = vrRegLst.filter(x=>x.CourseSimple.OralDegree>0).length>0;
    var vrContaintPractical: boolean = vrRegLst.filter(x => x.CourseSimple.PracticalDegree > 0).length > 0;
    var vrContainsClinical: boolean = vrRegLst.filter(x => x.CourseSimple.ClinicalDegree > 0).length > 0;
    var PrevID = 0;
    var Returned: string = "<table class=\"table\">";
    Returned += "<tr><th></th><th>code</th>";
    Returned += "<th>Name </th>";
    Returned += "<th>GPA </th>";
    Returned += "<th></th>";
    Returned += "<th>MT</th>";
    Returned += "<th>SW</th>";
    if (vrContainsOral) {
        Returned += "<th style=\"width=30px;\">Oral</th>";
    }
    if (vrContaintPractical) {
        Returned += "<th>Practical</th>";
    }
    Returned += "<th>Final</th>";
    Returned += "<th>Bonus</th>";
    if (vrContainsClinical) {
        Returned += "<th>Clinical</th>";
    }
    Returned+="</tr>";
    for (var vrIndex = 0; vrIndex < vrRegLst.length; vrIndex++) {
        if (vrIndex > 0) {
            PrevID = vrRegLst[vrIndex - 1].ID;
        }
        Returned += GetRegisterationStudentEditRow(vrRegLst[vrIndex],vrContainsOral,vrContaintPractical,vrContainsClinical);
    }
    Returned += "</table>";
    return Returned;
}
function GetRegisterationDisplayRow(vrRegisteration: Registeration): string
{
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
    /* Returned += "<td><input type='button' onClick=\"ShowRegistrationEditModal(" + vrRegisteration.ID.toString() + ")\"/> </td>";*/
    Returned += "<td>" + vrRegisteration.ID.toString() + "</td>";
    Returned += "<td>" + vrRegisteration.CourseCode + "</td>";
    Returned += "<td>" + vrRegisteration.CourseName + "</td>";
    Returned += "<td>" + vrRegisteration.CourseSimple.CreditHour + "</td>";
    if (vrRegisteration.ResultID > 0) {
        Returned += "<td>" + vrRegisteration.Points + "</td>";
        Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
        Returned += "<td></td>";
    }
    else {
        Returned += "<td>" + "</td>";
        Returned += "<td>" + "</td>";
        if (vrRegisteration.Posted) {
            Returned += "<td></td>";
        }
        else {


            Returned += "<td><input type=\"button\" onclick=\"DeleteRegisteration(" + vrRegisteration.ID + ")\" value=\"-\"/></td>";
        }
    }
        //if(vrRegisteration)

    Returned += "</tr>";
    return Returned;
}

function GetRegisterationDisplaySimpleRow(vrRegisteration: Registeration): string {
    var Returned: string = "";
    Returned += "<tr>";
    
     
    Returned += "<td>" + vrRegisteration.ID.toString() + "</td>";
    Returned += "<td>" + vrRegisteration.SemesterDesc + "</td>";
    Returned += "<td>" + vrRegisteration.CourseCode + "</td>";
    Returned += "<td>" + vrRegisteration.CourseName + "</td>";
    Returned += "<td>" + vrRegisteration.CourseSimple.CreditHour + "</td>";
     
        Returned += "<td>" + vrRegisteration.Points + "</td>";
        Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
        
     
     

    Returned += "</tr>";
    return Returned;
}

function GetRegisterationStudentRow(vrRegisteration: Registeration): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
    Returned += "<td><input type='button' onClick=\"ShowRegistrationEditModal(" + vrRegisteration.ID.toString() + ")\"/> </td>";
    Returned += "<td>" + vrRegisteration.StudentCode + "</td>";
    Returned += "<td>" + vrRegisteration.StudentName + "</td>";
  
    Returned += "<td>" + vrRegisteration.Points + "</td>";
    Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    Returned += "<td>" + vrRegisteration.MidtermDegree + "</td>";
    Returned += "<td>" + vrRegisteration.SemesterWorkDegree + "</td>";
    Returned += "<td>" + vrRegisteration.OralDegree + "</td>";
    Returned += "<td>" + vrRegisteration.PracticalDegree + "</td>";
    Returned += "<td>" + vrRegisteration.FinalDegree + "</td>";
    Returned += "<td>" + vrRegisteration.Bonus + "</td>";

    Returned += "</tr>";
    return Returned;
}
function CheckRegisterationStudentEdit(vrRegID: number) :boolean{
    var Returned: boolean = false;
    var vrReg: Registeration;
    if (document.getElementById("lblRegisteration" + vrRegID) != null) {
        vrReg = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisteration" + vrRegID)).value);
        Returned = true;
        vrReg.Bonus = Number((<HTMLInputElement>document.getElementById("txtBonus" + vrRegID)).value);
        if (vrReg.CourseSimple.ClinicalDegree > 0) {
            vrReg.ClinicalDegree = Number((<HTMLInputElement>document.getElementById("txtClinical" + vrRegID)).value);
            if (vrReg.ClinicalDegree > vrReg.CourseSimple.ClinicalDegree) {
                Returned = false;
                
            }
        }
        if (vrReg.CourseSimple.OralDegree> 0) {
            vrReg.OralDegree = Number((<HTMLInputElement>document.getElementById("txtOral" + vrRegID)).value);
            if (vrReg.OralDegree > vrReg.CourseSimple.OralDegree) {
                Returned = false;

            }
        }

        if (vrReg.CourseSimple.PracticalDegree > 0) {
            vrReg.PracticalDegree = Number((<HTMLInputElement>document.getElementById("txtPractical" + vrRegID)).value);
            if (vrReg.PracticalDegree > vrReg.CourseSimple.PracticalDegree) {
                Returned = false;

            }
        }
        if (vrReg.CourseSimple.MidtermDegree > 0) {
            vrReg.MidtermDegree = Number((<HTMLInputElement>document.getElementById("txtMidterm" + vrRegID)).value);
            if (vrReg.MidtermDegree > vrReg.CourseSimple.MidtermDegree) {
                Returned = false;

            }
        }

        if (vrReg.CourseSimple.SemesterWorkDegree > 0) {
            vrReg.SemesterWorkDegree = Number((<HTMLInputElement>document.getElementById("txtSemesterWork" + vrRegID)).value);
            if (vrReg.SemesterWorkDegree > vrReg.CourseSimple.SemesterWorkDegree) {
                Returned = false;

            }
        }
        if (vrReg.CourseSimple.FinalDegree > 0) {
            vrReg.FinalDegree = Number((<HTMLInputElement>document.getElementById("txtFinal" + vrRegID)).value);
            if (vrReg.FinalDegree > vrReg.CourseSimple.FinalDegree) {
                Returned = false;

            }
        }


    }
    var vrID = "lblOK" + vrRegID.toString();
    if (document.getElementById(vrID) != null &&!Returned) {
        (<HTMLElement>document.getElementById("lblOK" + vrRegID.toString())).innerText = "X";
    }
    return Returned;
}

function GetRegisterationStudentEditRow(vrRegisteration: Registeration,vrContainOral:boolean,vrContainPractical:boolean,vrContainClinical): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
    Returned += "<td><input type='button' onClick=\"ShowRegisterationExamModal(" + vrRegisteration.ID.toString() + ")\" value=\"EX\"/> </td>";
    Returned += "<td>" + vrRegisteration.StudentCode + "</td>";
    Returned += "<td>" + vrRegisteration.StudentName + "</td>";

    Returned += "<td>" + vrRegisteration.Points + "</td>";
    Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    Returned += "<td>" +
        " <input type=\"number\" id=\"txtMidterm"+vrRegisteration.ID.toString()+"\" class=\"form-control form-control-sm\" value=" + vrRegisteration.MidtermDegree+" /></br>"+ vrRegisteration.CourseSimple.MidtermDegree +"</td>";
    Returned += "<td>" + " <input type=\"number\" id=\"txtSemesterWork" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.SemesterWorkDegree + " /></br>" +vrRegisteration.CourseSimple.SemesterWorkDegree+ "</td>";
    if (vrContainOral) {
        Returned += "<td>" + " <input type=\"number\" id=\"txtOral" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.OralDegree + " /></br>" +vrRegisteration.CourseSimple.OralDegree+ "</td>";
    }
    if (vrContainPractical) {
        Returned += "<td>" + " <input type=\"number\" id=\"txtPractical" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.PracticalDegree + " /></br>"+vrRegisteration.CourseSimple.PracticalDegree + "</td>";
    }

    Returned += "<td>" + " <input type=\"number\" id=\"txtFinal" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.FinalDegree + " /></br>" +vrRegisteration.CourseSimple.FinalDegree + "</td>";
    Returned += "<td>" + " <input type=\"number\" id=\"txtBonus" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.Bonus + " />" + "</td>";
    if (vrContainClinical) {
        Returned += "<td>" + " <input type=\"number\" id=\"txtClinical" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.ClinicalDegree + " /></br>" +vrRegisteration.CourseSimple.ClinicalDegree+ "</td>";
    }
    Returned += "<td>" + " <input type=\"number\" id=\"txtNote" + vrRegisteration.ID.toString() + "\" class=\"form-control form-control-sm\" value=" + vrRegisteration.Note + " /></br>" +  "</td>";
    Returned += "<td id=\"lblOK" + vrRegisteration.ID + "\"><label  id=\"lblOK" + vrRegisteration.ID + "\" style=\"background-color:aliceblue; color:red;font-size:large;\"></label></td>";
    Returned += "<td><button id='btnSaveRegisteration" + vrRegisteration.ID + "' onClick='SaveRegisterationSimple(" + vrRegisteration.ID + ")'>Save</button></td>";

    Returned += "</tr>";
    return Returned;
}
function GetRegisterationStudentSimpleRow(vrIndex:number,vrRegisteration: Registeration): string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
    Returned += "<td><input type='button' value=\"-\" onClick=\"DeleteRegister(" + vrRegisteration.ID.toString() + ")\"/> </td>";
    Returned += "<td>"+vrIndex+"</td>";
    Returned += "<td>" + vrRegisteration.StudentCode + "</td>";
    Returned += "<td>" + vrRegisteration.StudentName + "</td>";
    if (vrRegisteration.EqualName != "") {
        Returned += "<td>" + vrRegisteration.EqualName + "</td>";
        Returned += "<td>" + vrRegisteration.Points + "</td>";
        Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    }
    else {
        Returned += "<td></td>";
        Returned += "<td></td>";
        Returned += "<td></td>";
    }

    Returned += "</tr>";
    return Returned;
}
function FillRegisteredStudentTable(lstRegisteration: Registeration[]) {
    var vrStudent: string = "";
    vrStudent += "<table class=\"table\">";
    var vrRegisteration: Registeration = new Registeration();
    for (var vrIndex = 0; vrIndex < lstRegisteration.length; vrIndex++) {
        vrRegisteration = lstRegisteration[vrIndex];
        vrStudent += GetRegisterationStudentSimpleRow(vrIndex+1,vrRegisteration);
    }
    vrStudent += "</table>";
    (<HTMLInputElement>document.getElementById("dvRegisteredStudent")).innerHTML = vrStudent;
}
function GetRegisterationStudentSelectionTable(lstReg: Registeration[], lstSelectedID: Registeration[]): string  {
    var vrIDs: number[] = lstReg.map(x => x.ID);

    if (document.getElementById("lblRegIDs") != null) {
        (<HTMLInputElement>document.getElementById("lblRegIDs")).value = JSON.stringify(vrIDs);
    }
    if (document.getElementById("txtSelectNo") != null) {
        (<HTMLInputElement>document.getElementById("txtSelectNo")).value = lstSelectedID.length==0 ? vrIDs.length.toString():lstSelectedID.length.toString();
    }
    var Returned: string = "<table class=\"table\">";
    var vrSelected: boolean;
    for (var vrIndex = 0; vrIndex < lstReg.length; vrIndex++) {
        vrSelected = lstSelectedID.filter(x => x.ID == lstReg[vrIndex].ID).length > 0;
        Returned += GetRegisterationStudentSelectionRow(vrIndex + 1, lstReg[vrIndex], vrSelected);
    }
    Returned += "</table>";
    return Returned;
}
function GetRegisterationStudentSelectionRow(vrIndex: number, vrRegisteration: Registeration,vrSelected:boolean): string {
    var Returned: string = "";
    
    Returned += "<tr>";
    Returned += "<input type='hidden' id='lblRegisteration" + vrRegisteration.ID + "' value='" + JSON.stringify(vrRegisteration) + "'>";
    Returned += "<td><input type='checkbox' id='chkSelectedReg" + vrRegisteration.ID + "'";
    if (vrSelected) { Returned += " checked " };
    Returned += "></td>";
    Returned += "<td><input type='button' value=\"-\" onClick=\"DeleteRegister(" + vrRegisteration.ID.toString() + ")\"/> </td>";
    Returned += "<td>" + vrIndex + "</td>";
    Returned += "<td>" + vrRegisteration.SeatNo + "</td>";
    Returned += "<td>" + vrRegisteration.StudentCode + "</td>";
    Returned += "<td>" + vrRegisteration.StudentName + "</td>";
    if (vrRegisteration.EqualName != "") {
        Returned += "<td>" + vrRegisteration.EqualName + "</td>";
        Returned += "<td>" + vrRegisteration.Points + "</td>";
        Returned += "<td>" + vrRegisteration.VerbalGPA + "</td>";
    }
    else {
        Returned += "<td></td>";
        Returned += "<td></td>";
        Returned += "<td></td>";
    }

    Returned += "</tr>";
    return Returned;
}

function GetRegistrationLstTable(lstRegisteration:Registeration[]): string {
    var Returned: string = "";
    Returned += "<tr>";

    Returned += "<th></th>";
    Returned += "<th></th>";
    Returned += "<th></th>";
    Returned += "<th>ch</th>";
    Returned += "<th>Points</th>";
    Returned += "<th>GPA</th>";
    Returned += "<th>MidtermDegree</th>";
    Returned += "<th>SemesterWorkDegree</th>";
    Returned += "<th>OralDegree</th>";
    Returned += "<th>PracticalDegree</th>";
    Returned += "<th>FinalDegree</th>";
    Returned += "<th>bonus</th>";
    Returned += "<th>Clinical</th>";
    Returned += "</tr>";
    for (var vrIndex = 0; vrIndex < lstRegisteration.length; vrIndex++) {
        Returned += GetRegisterationRow(lstRegisteration[vrIndex]);
    }
    return Returned;
}
function GetRegistrationStudentLstTable(lstRegisteration: Registeration[]): string {
    var Returned: string = "";
    Returned += "<tr>";

    Returned += "<th></th>";
    Returned += "<th></th>";
    Returned += "<th></th>";
   
    Returned += "<th>Points</th>";
    Returned += "<th>GPA</th>";
    Returned += "<th>MidtermDegree</th>";
    Returned += "<th>SemesterWorkDegree</th>";
    Returned += "<th>OralDegree</th>";
    Returned += "<th>PracticalDegree</th>";
    Returned += "<th>FinalDegree</th>";
    Returned += "<th>bonus</th>";
    Returned += "<th>Clinical</th>";
    Returned += "</tr>";
    for (var vrIndex = 0; vrIndex < lstRegisteration.length; vrIndex++) {
        Returned += GetRegisterationStudentRow(lstRegisteration[vrIndex]);
    }
    return Returned;
}
function ShowRegisterationModal(vrStudent: number) {
    var vrStudentBiz: Student;
    vrStudentBiz = JSON.parse((<HTMLInputElement>document.getElementById("lblStudent" + vrStudent)).value);
   
    var vrTempStudent: Student = new Student();
    if (vrStudentBiz.lstSemester.length > 0) {
        //(<HTMLElement>document.getElementById("lblSemesterDesc")).innerText = vrStudentBiz.lstSemester[0].Desc;
        var vrTable: string = "";

        vrTable = "<div class=\"form-row\">"+
            "<div class=\"col-2\">"+
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrStudentBiz.Code + "</label></div>";
        vrTable += "<div class=\"col-3\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrStudentBiz.NameA + "</label></div>"; 
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">T.Hours</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrStudentBiz.TotalHours + "</label></div>"; 
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">E.Hours</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrStudentBiz.EarnedHours + "</label></div>"; 
        
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">CGPA</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrStudentBiz.Points + "</label></div>"; 
        vrTable += "</div>";
        for (var vrIndex = 0; vrIndex < vrStudentBiz.lstSemester.length; vrIndex++) {
            //dvOldSemester
            vrTable += "<div class=\"form-row\">";
               vrTable+= "<div class=\"col-3\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].Desc + "</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">SGPA</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].Grade + "</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">T.Hours</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].TotalHours + "</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">E.Hours</label>" +
                "</div>";
            vrTable += "<div class=\"col-1\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].EarnedHours + "</label>" +
                "</div>";
            vrTable += "</div>";
            
            vrTable += "<div class=\"table-responsive\">" +
                "<table class=\"table\">";
            vrTable += GetRegistrationLstTable(vrStudentBiz.lstSemester[vrIndex].lstRegisteration);
            vrTable += "</table></div>";

        }
       document.getElementById("dvOldSemester").innerHTML= vrTable;
        document.getElementById("myRegisterationModal").style.display = "block";
    }
}
function ShowRegisterationModal1(vrStudent: number) {
    var vrStudentBiz: Student;
    vrStudentBiz = JSON.parse((<HTMLInputElement>document.getElementById("lblStudent" + vrStudent)).value);
    var vrTemp = (<HTMLElement>document.getElementById("RegisterationStudentCode"));
    (<HTMLElement>document.getElementById("RegisterationStudentCode")).innerText = vrStudentBiz.Code;
    (<HTMLElement>document.getElementById("RegisterationStudentName")).innerText = vrStudentBiz.NameA;
    (<HTMLElement>document.getElementById("RegisterationStudentGPA")).innerText = "CGPA";
    (<HTMLElement>document.getElementById("RegisterationStudentPoints")).innerText = vrStudentBiz.Points.toString();
    var vrTempStudent: Student = new Student();
    if (vrStudentBiz.lstSemester.length > 0) {
        //(<HTMLElement>document.getElementById("lblSemesterDesc")).innerText = vrStudentBiz.lstSemester[0].Desc;
        var vrTable: string = "";

        //var vrTable: string = GetRegistrationLstTable(vrStudentBiz.lstSemester[0].lstRegisteration);
        //(<HTMLElement>document.getElementById("tblStudentRegisteration")).innerHTML = vrTable;
        vrTable = "";
        for (var vrIndex = 0; vrIndex < vrStudentBiz.lstSemester.length; vrIndex++) {
            //dvOldSemester
            vrTable += "<div class=\"form-row\">" +
                "<div class=\"col-3\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].Desc + "</label>" +
                "</div>";
            vrTable += "<div class=\"col-3\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">SGPA</label>" +
                "</div>";
            vrTable += "<div class=\"col-3\" >" +
                "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
                "text - align: center;\">" + vrStudentBiz.lstSemester[vrIndex].Grade + "</label>" +
                "</div>";
            vrTable += "</div>";
            vrTable += "<div class=\"table-responsive\">" +
                "<table class=\"table\">";
            vrTable += GetRegistrationLstTable(vrStudentBiz.lstSemester[vrIndex].lstRegisteration);
            vrTable += "</table></div>";

        }
        document.getElementById("dvOldSemester").innerHTML = vrTable;
        document.getElementById("myRegisterationModal").style.display = "block";
    }
}
function ShowRegistrationEditModal(vrRegistrationID: number) {
    var vrRegisteration: Registeration = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisteration" + vrRegistrationID)).value);
    SetRegisterationEditData(vrRegisteration);
    
   
}
function SetRegisterationEditData(vrRegisteration: Registeration) {
    (<HTMLInputElement>document.getElementById("lblRegistrationEdit")).value = JSON.stringify(vrRegisteration);
    (<HTMLInputElement>document.getElementById("txtMidterm")).value = vrRegisteration.MidtermDegree.toString();
    (<HTMLInputElement>document.getElementById("txtSemesterWork")).value = vrRegisteration.SemesterWorkDegree.toString();
    if (document.getElementById("txtPractical") != null) {
        (<HTMLInputElement>document.getElementById("txtPractical")).value = vrRegisteration.PracticalDegree.toString();
    }
    if (document.getElementById("txtOral") != null) {
        (<HTMLInputElement>document.getElementById("txtOral")).value = vrRegisteration.OralDegree.toString();
    }
    if (document.getElementById("txtClinical") != null) {
        (<HTMLInputElement>document.getElementById("txtClinical")).value = vrRegisteration.ClinicalDegree.toString();
    }

    (<HTMLInputElement>document.getElementById("txtFinal")).value = vrRegisteration.FinalDegree.toString();
    (<HTMLInputElement>document.getElementById("txtBonus")).value = vrRegisteration.Bonus.toString();
    (<HTMLInputElement>document.getElementById("txtNote")).value = vrRegisteration.Note;
    document.getElementById("myRegisterationEditModal").style.display = "block";
}
function GetRegisterationEditData(): Registeration{
    
    var Returned: Registeration = JSON.parse((<HTMLInputElement>document.getElementById("lblRegistrationEdit")).value);
    Returned.Bonus = Number((<HTMLInputElement>document.getElementById("txtBonus")).value);
    Returned.FinalDegree = Number((<HTMLInputElement>document.getElementById("txtFinal")).value);

    Returned.SemesterWorkDegree = Number((<HTMLInputElement>document.getElementById("txtSemesterWork")).value);
    if (document.getElementById("txtPractical") != null) {
        Returned.PracticalDegree = Number((<HTMLInputElement>document.getElementById("txtPractical")).value);
    }
    if (document.getElementById("txtOral") != null) {
        Returned.OralDegree = Number((<HTMLInputElement>document.getElementById("txtOral")).value);
    }
    if (document.getElementById("txtClinical") != null) {
        Returned.ClinicalDegree = Number((<HTMLInputElement>document.getElementById("txtClinical")).value);
    }
    Returned.MidtermDegree = Number((<HTMLInputElement>document.getElementById("txtMidterm")).value);
    Returned.Note = (<HTMLInputElement>document.getElementById("txtNote")).value;
/*    Returned.OralDegree = Number((<HTMLInputElement>document.getElementById("txtOral")).value);*/
/*Returned. = Number((<HTMLInputElement>document.getElementById("txtFinal")).value);*/
    var vrUser:User = GetCurrentUser();
    Returned.UserID = vrUser.ID;
    
    return Returned;
}
function GetRegisterationByIDEditData(vrID:number): Registeration {

    var Returned: Registeration = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisteration"+vrID.toString())).value);
    Returned.Bonus = Number((<HTMLInputElement>document.getElementById("txtBonus" + vrID.toString())).value);
    Returned.FinalDegree = Number((<HTMLInputElement>document.getElementById("txtFinal" + vrID.toString())).value);

    Returned.SemesterWorkDegree = Number((<HTMLInputElement>document.getElementById("txtSemesterWork" + vrID.toString())).value);
    if (document.getElementById("txtPractical" + vrID.toString()) != null) {
        Returned.PracticalDegree = Number((<HTMLInputElement>document.getElementById("txtPractical" + vrID.toString())).value);
    }
    if (document.getElementById("txtOral" + vrID.toString()) != null) {
        Returned.OralDegree = Number((<HTMLInputElement>document.getElementById("txtOral" + vrID.toString())).value);
    }
    if (document.getElementById("txtClinical" + vrID.toString()) != null) {
        Returned.PracticalDegree = Number((<HTMLInputElement>document.getElementById("txtClinical" + vrID.toString())).value);
    }
    Returned.MidtermDegree = Number((<HTMLInputElement>document.getElementById("txtMidterm" + vrID.toString())).value);
    Returned.Note = (<HTMLInputElement>document.getElementById("txtNote" + vrID.toString())).value;
    /*    Returned.OralDegree = Number((<HTMLInputElement>document.getElementById("txtOral")).value);*/
    /*Returned. = Number((<HTMLInputElement>document.getElementById("txtFinal")).value);*/
    var vrUser: User = GetCurrentUser();
    Returned.UserID = vrUser.ID;

    return Returned;
}
function GetSemesterRegisteration(lstSemester:Semester[],vrMainSemester:number) {
    var vrTable: string = "";
    vrTable += "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstSemester.length; vrIndex++) {
        //dvOldSemester
        //lstSemester[vrIndex].ID != vrMainSemester)
        if (false)
        {
            //vrTable += "<div class=\"form-row\">";
            //vrTable += "<div class=\"col-3\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">" +  lstSemester[vrIndex].Desc + "</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">SGPA</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">" +  lstSemester[vrIndex].Grade + "</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">T.Hours</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">" +   lstSemester[vrIndex].TotalHours + "</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">E.Hours</label>" +
            //    "</div>";
            //vrTable += "<div class=\"col-1\" >" +
            //    "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            //    "text - align: center;\">" +  lstSemester[vrIndex].EarnedHours + "</label>" +
            //    "</div>";
            //vrTable += "</div>";

        }

       // vrTable += "<div class=\"table-responsive\">" +
        //vrTable +="<table class=\"table\">";
        vrTable += "<tr><td>";
        vrTable += "<label class=\"text-black\" style =\"background-color:" + "aliceblue;" +
            "text - align: center;\">" + lstSemester[vrIndex].Desc + "</label>";
        vrTable += "</td></tr>";
        for (var vrIndex1 = 0; vrIndex1 < lstSemester[vrIndex].lstRegisteration.length; vrIndex1++) {
            vrTable += GetRegisterationDisplayRow(lstSemester[vrIndex].lstRegisteration[vrIndex1]);
        }
        //vrTable += "</table>";


    }
    vrTable += "</table>";
    return vrTable;

}
function GetTotalRegisterationHour():number {
    var Returned: number = 0;
    var vrTemp: string = (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value;
    var vrTotalHour: number = 0;
    var vrSelectedCourses:Course[] = JSON.parse(vrTemp);
    if (vrSelectedCourses.length > 0)
    {
        vrTotalHour = vrSelectedCourses.map(x => x.CreditHour).reduce((a, b) => a + b);

    }
    vrTemp = (<HTMLInputElement>document.getElementById("lblRegisteredCourses")).value;
    var vrRegLst: Registeration[] = [];
    if (vrTemp != "") {
        vrRegLst = JSON.parse(vrTemp);
    }
    if (vrRegLst.length > 0) {
        vrTotalHour += vrRegLst.filter(y=>y.SourceStatus!=3).map(x => x.CourseSimple.CreditHour).reduce((a, b) => a + b);
    }
    (<HTMLInputElement>document.getElementById("lblSemesterHour")).innerText = vrTotalHour.toString();
    return vrTotalHour;
}
function GetRegisterationLst(): Registeration[] {
    var Returned: Registeration[] = [];
    var vrIDs: number[] = [];
    vrIDs = JSON.parse((<HTMLInputElement>document.getElementById("lblIDs")).value);
    for (var vrID in vrIDs) {
        Returned[Returned.length] = GetRegisterationByIDEditData(Number(vrID));
    }
    return Returned;
}
function CheckRegisterationLst(): boolean {
    var Returned: boolean = true;
    var vrIDs: number[] = [];
    vrIDs = JSON.parse((<HTMLInputElement>document.getElementById("lblIDs")).value);
    for (var vrIndex = 0; vrIndex < vrIDs.length; vrIndex++) {
        Returned = Returned && CheckRegisterationStudentEdit(vrIDs[vrIndex]);
    }
    return Returned;
}
function CheckAllRegisteration() {
    var vrIDs: number[] = [];
    var vrIDLen: number = vrIDs.length;
    if (document.getElementById("txtSelectNo") != null) {
        vrIDLen=Number((<HTMLInputElement>document.getElementById("txtSelectNo")).value);
    }
    
    if (document.getElementById("lblRegIDs") != null && (<HTMLInputElement>document.getElementById("lblRegIDs")).value!="") {
        vrIDs = JSON.parse((<HTMLInputElement>document.getElementById("lblRegIDs")).value);
        if (vrIDLen == 0) {
            vrIDLen = vrIDs.length;
        }
    }
    for (var vrIndex = 0; vrIndex < vrIDLen; vrIndex++) {
        (<HTMLInputElement>document.getElementById("chkSelectedReg" + vrIDs[vrIndex].toString())).checked = (<HTMLInputElement>document.getElementById("chkSelectAll")).checked;
    }
}
function ShowPrequisitModal(vrRegID: number) {
    
    var vrReg: Registeration = JSON.parse((<HTMLInputElement>document.getElementById("lblRegisteration" + vrRegID)).value);
    if (document.getElementById("lblBaseStudentCode") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseStudentCode")).innerText = vrReg.StudentCode;
    }
    if (document.getElementById("lblBaseStudentName") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseStudentName")).innerText = vrReg.StudentName;
    }
    if (document.getElementById("lblBaseCourseCode") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCourseCode")).innerText = vrReg.CourseCode;
    }
    if (document.getElementById("lblBaseCourseNameA") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCourseNameA")).innerText = vrReg.CourseName;
    }

     
    if (document.getElementById("lblBaseCourseGPA") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCourseGPA")).innerText = vrReg.GPA;
    }
    if (document.getElementById("lblBaseCourseVerbalGPA") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCourseVerbalGPA")).innerText = vrReg.VerbalGPA;
    }
    if (document.getElementById("lblBaseCoursePrequisitCount") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCoursePrequisitCount")).innerText = vrReg.PrequisitCourseCount.toString();
    }
    if (document.getElementById("lblBaseCoursePassedPrequisitCount") != null) {
        (<HTMLInputElement>document.getElementById("lblBaseCoursePassedPrequisitCount")).innerText = vrReg.PrequisitPassedCourseCount.toString();
    }



    var vrRegStr: string = "<table>";
    for (var vrIndex = 0; vrIndex < vrReg.PrequisitLst.length; vrIndex++) {
        vrRegStr += GetRegisterationDisplaySimpleRow(vrReg.PrequisitLst[vrIndex]);
    }
    vrRegStr += "</table>";
    (<HTMLInputElement>document.getElementById("tblPrequisit")).innerHTML = vrRegStr;
    (<HTMLInputElement>document.getElementById("myPrequisitModal")).style.display = "block";

}