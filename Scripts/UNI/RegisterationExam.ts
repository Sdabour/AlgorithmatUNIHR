class RegisterationExam {
    RegisterationExam() {}
    public ID: number;
    public Registeration: number;
    public Exam: number;
    public Grade: number;
    public Degree: number;
    public Note: string;
    public Date: Date;
    public EvaluationEmployee: number;
    public EvaluationUsr: number;
    public Status: number;
    public RegisterationSimple: Registeration = new Registeration();
    public ExamSimple: Exam = new Exam();
    public User: number;
    public lstExam: RegisterationExam[]=[];

}
function GetRegisterationExamRow(vrReg: RegisterationExam,vrIndex:number): string {
    var Returned: string = "";
    var vrID: string = vrReg.RegisterationSimple.ID + "-" + vrReg.ExamSimple.ID;
    Returned += "<tr>";
    Returned += "<td>" + vrIndex + "<input type=\"hidden\" id=\"lblRegExam" + vrID + "\" value='" + JSON.stringify(vrReg) + "' />" + "</td>";
    if (document.getElementById("lblCurrentRegisteration") == null) {
        Returned += "<td>" + vrReg.RegisterationSimple.StudentCode + "</td>";
        Returned += "<td>" + vrReg.RegisterationSimple.StudentName + "</td>";
        /* Returned += "<td>" + vrReg.RegisterationSimple.StudentCode + "</td>";*/
    }
    else {
        Returned += "<td>"+vrReg.ExamSimple.TypeStr+"</td>";
    }
    Returned += "<td><input type=\"number\" class=\"form-control\" style=\"text-align:center;\" id=\"txtDegree" + vrID + "\" value=\"" + vrReg.Degree + "\" /></td>";
    Returned += "<td>" + vrReg.ExamSimple.Grade + "</td>";
    Returned += "<td><input type=\"text\" placeholder=\"Note\" class=\"form-control\" id=\"txtNote" + vrID + "\" value=\"" + vrReg.Note + "\" /></td>";
    Returned += "<td>WF</td>";
    var vrCheck: string = vrReg.Status == 7? "checked":"";
    Returned += "<td><input type=\"checkbox\" class=\"form-control\" id=\"chkExamWf" + vrID + "\"  "+vrCheck+" /></td>";
    Returned += "<td><input type=\"button\" class=\"form-control\" id=\"btnSaveReg" + vrReg.RegisterationSimple.ID + "\" value=\"حفظ\" onclick=\"SaveRegisterationExam(" + vrReg.RegisterationSimple.ID + "," + vrReg.ExamSimple.ID + ")\"/></td>";
   
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationExamLst(lstReg: RegisterationExam[]) {
    var vrIDs: string[]=[];
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstReg.length; vrIndex++) {
        vrTable += GetRegisterationExamRow(lstReg[vrIndex], vrIndex + 1);
        vrIDs[vrIDs.length] = lstReg[vrIndex].RegisterationSimple.ID + "-" + lstReg[vrIndex].ExamSimple.ID
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblRegExam")).innerHTML = vrTable;
    (<HTMLInputElement>document.getElementById("lblExamIDs")).value = JSON.stringify(vrIDs);

}
function GetRegExam(vrID: string):RegisterationExam{
    var vrReg: RegisterationExam = new RegisterationExam();
    if (document.getElementById("lblRegExam" + vrID) != null) {
        vrReg = JSON.parse((<HTMLInputElement>document.getElementById("lblRegExam" + vrID)).value);
        var vrValue: number = Number((<HTMLInputElement>document.getElementById("txtDegree" + vrID)).value);
        var vrNote:string = (<HTMLInputElement>document.getElementById("txtNote" + vrID)).value
        if (vrReg.Degree != vrValue && vrValue <= vrReg.ExamSimple.Grade)
            vrReg.Degree = vrValue;
        if (vrReg.Note != vrNote)
            vrReg.Note = vrNote;
        var vrChecked: boolean = (<HTMLInputElement>document.getElementById("chkExamWf" + vrID)).checked;
        vrReg.Status = vrChecked?7:0;
    }
    return vrReg;

}

function CheckRegExam(vrID: string): boolean{
    var Returned: boolean = false;

    var vrReg: RegisterationExam = new RegisterationExam();
    if (document.getElementById("lblRegExam" + vrID) != null) {
        vrReg = JSON.parse((<HTMLInputElement>document.getElementById("lblRegExam" + vrID)).value);
        var vrValue: number = Number((<HTMLInputElement>document.getElementById("txtDegree" + vrID)).value);
        var vrNote: string = (<HTMLInputElement>document.getElementById("txtNote" + vrID)).value
        if (vrReg.Degree != vrValue && vrValue <= vrReg.ExamSimple.Grade) {
            vrReg.Degree = vrValue;
            Returned = true;
        }
        if (vrReg.Note != vrNote) {
            vrReg.Note = vrNote;
            Returned = true;
        }
    }
    return Returned;

}
function GetRegExamLst(): RegisterationExam[] {
    var vrRegLst: RegisterationExam[] = [];
    var vrLstIDs: string[] = [];
    if (document.getElementById("lblExamIDs") != null)
    {
        vrLstIDs = JSON.parse((<HTMLInputElement>document.getElementById("lblExamIDs")).value);
        var vrReg: RegisterationExam;
        for (var vrIndex = 0; vrIndex < vrLstIDs.length; vrIndex++) {
            if (CheckRegExam(vrLstIDs[vrIndex])) {
                vrReg = GetRegExam(vrLstIDs[vrIndex]);
                vrRegLst[vrRegLst.length] = vrReg;
            }
        }
    }
    return vrRegLst;
}