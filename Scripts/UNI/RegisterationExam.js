var RegisterationExam = /** @class */ (function () {
    function RegisterationExam() {
        this.RegisterationSimple = new Registeration();
        this.ExamSimple = new Exam();
        this.lstExam = [];
    }
    RegisterationExam.prototype.RegisterationExam = function () { };
    return RegisterationExam;
}());
function GetRegisterationExamRow(vrReg, vrIndex) {
    var Returned = "";
    var vrID = vrReg.RegisterationSimple.ID + "-" + vrReg.ExamSimple.ID;
    Returned += "<tr>";
    Returned += "<td>" + vrIndex + "<input type=\"hidden\" id=\"lblRegExam" + vrID + "\" value='" + JSON.stringify(vrReg) + "' />" + "</td>";
    if (document.getElementById("lblCurrentRegisteration") == null) {
        Returned += "<td>" + vrReg.RegisterationSimple.StudentCode + "</td>";
        Returned += "<td>" + vrReg.RegisterationSimple.StudentName + "</td>";
        /* Returned += "<td>" + vrReg.RegisterationSimple.StudentCode + "</td>";*/
    }
    else {
        Returned += "<td>" + vrReg.ExamSimple.TypeStr + "</td>";
    }
    Returned += "<td><input type=\"number\" class=\"form-control\" style=\"text-align:center;\" id=\"txtDegree" + vrID + "\" value=\"" + vrReg.Degree + "\" /></td>";
    Returned += "<td>" + vrReg.ExamSimple.Grade + "</td>";
    Returned += "<td><input type=\"text\" placeholder=\"Note\" class=\"form-control\" id=\"txtNote" + vrID + "\" value=\"" + vrReg.Note + "\" /></td>";
    Returned += "<td>WF</td>";
    var vrCheck = vrReg.Status == 7 ? "checked" : "";
    Returned += "<td><input type=\"checkbox\" class=\"form-control\" id=\"chkExamWf" + vrID + "\"  " + vrCheck + " /></td>";
    Returned += "<td><input type=\"button\" class=\"form-control\" id=\"btnSaveReg" + vrReg.RegisterationSimple.ID + "\" value=\"حفظ\" onclick=\"SaveRegisterationExam(" + vrReg.RegisterationSimple.ID + "," + vrReg.ExamSimple.ID + ")\"/></td>";
    Returned += "</tr>";
    return Returned;
}
function FillRegisterationExamLst(lstReg) {
    var vrIDs = [];
    var vrTable = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < lstReg.length; vrIndex++) {
        vrTable += GetRegisterationExamRow(lstReg[vrIndex], vrIndex + 1);
        vrIDs[vrIDs.length] = lstReg[vrIndex].RegisterationSimple.ID + "-" + lstReg[vrIndex].ExamSimple.ID;
    }
    vrTable += "</table>";
    document.getElementById("tblRegExam").innerHTML = vrTable;
    document.getElementById("lblExamIDs").value = JSON.stringify(vrIDs);
}
function GetRegExam(vrID) {
    var vrReg = new RegisterationExam();
    if (document.getElementById("lblRegExam" + vrID) != null) {
        vrReg = JSON.parse(document.getElementById("lblRegExam" + vrID).value);
        var vrValue = Number(document.getElementById("txtDegree" + vrID).value);
        var vrNote = document.getElementById("txtNote" + vrID).value;
        if (vrReg.Degree != vrValue && vrValue <= vrReg.ExamSimple.Grade)
            vrReg.Degree = vrValue;
        if (vrReg.Note != vrNote)
            vrReg.Note = vrNote;
        var vrChecked = document.getElementById("chkExamWf" + vrID).checked;
        vrReg.Status = vrChecked ? 7 : 0;
    }
    return vrReg;
}
function CheckRegExam(vrID) {
    var Returned = false;
    var vrReg = new RegisterationExam();
    if (document.getElementById("lblRegExam" + vrID) != null) {
        vrReg = JSON.parse(document.getElementById("lblRegExam" + vrID).value);
        var vrValue = Number(document.getElementById("txtDegree" + vrID).value);
        var vrNote = document.getElementById("txtNote" + vrID).value;
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
function GetRegExamLst() {
    var vrRegLst = [];
    var vrLstIDs = [];
    if (document.getElementById("lblExamIDs") != null) {
        vrLstIDs = JSON.parse(document.getElementById("lblExamIDs").value);
        var vrReg;
        for (var vrIndex = 0; vrIndex < vrLstIDs.length; vrIndex++) {
            if (CheckRegExam(vrLstIDs[vrIndex])) {
                vrReg = GetRegExam(vrLstIDs[vrIndex]);
                vrRegLst[vrRegLst.length] = vrReg;
            }
        }
    }
    return vrRegLst;
}
//# sourceMappingURL=RegisterationExam.js.map