var ApplicantWorkerMotivation = /** @class */ (function () {
    function ApplicantWorkerMotivation() {
        this.MotivationNetValue = 0;
        this.TempRecommended = 0;
    }
    ApplicantWorkerMotivation.prototype.GetRow = function (vrShowSalaryAuthorized, objBiz, intIndex, vrCost) {
        var Returned;
        Returned = "";
        var vrBackGround = objBiz.Stopped ? " style=\"background-color: cornsilk;\" " : "";
        Returned += "<tr" + vrBackGround + ">";
        var vrUnitID;
        vrUnitID = "lblEvaluation" + objBiz.ApplicantID;
        /* Returned += "<input type=\"hidden\" id=\"" + vrUnitID + "\" value='" + JSON.stringify(objBiz) + "'\>";*/
        Returned += "<td>" + intIndex + "</td>";
        Returned += "<td>" + (objBiz.Stopped ? "X" : "") + "</td>";
        Returned += "<td>" + objBiz.ApplicantCode + "</td>";
        Returned += "<td>" + objBiz.ApplicantName + "</td>";
        Returned += "<td>" + objBiz.JobDesc + "</td>";
        Returned += "<td>" + objBiz.StartDate + "</td>";
        //Returned += "<td>" + objBiz.MotivationValue.toFixed(0) + "</td>";
        if (objBiz.MotivationNetValue == null) {
            objBiz.MotivationNetValue = 0;
        }
        var vrValue = objBiz.SavedValue == 0 ? objBiz.MotivationNetValue : objBiz.SavedValue;
        if (!objBiz.Reviewed) {
            Returned += "<td style=\"width:200px;\"><input type=\"number\" value=\"" + vrValue.toFixed(0) + "\" id=\"txtValue" + objBiz.ApplicantID + "\" class= \"form-control bg-slate-600 border-slate-600 border-1\"    style=\"text-align:center;width:100px;\" onchange=\"return OnMotivationValueChange(" + (intIndex - 1).toString() + "," + vrCost + ")\" name=\"txtValue" + objBiz.ApplicantID + "\" /></td>";
        }
        else {
            Returned += "<td>" + vrValue.toFixed(0) + "</td>";
        }
        Returned += vrShowSalaryAuthorized ? "<td>" + objBiz.TotalSalary + "</td>" : "";
        //  Returned += "<td id=\"tdBonus" + objBiz.ApplicantID.toString() + "\">" + objBiz.MotivationBonusValue.toFixed(0) + "</td>";
        //Returned += "<td>" + objBiz.BaseSalary + "</td>";
        //Returned += "<td>" + objBiz.TotalSalary + "</td>";
        Returned += "<td>" + objBiz.FStStatementValue + "</td>";
        Returned += "<td>" + objBiz.SNdStatementValue + "</td>";
        Returned += "<td>" + objBiz.FStEvaluationStatementValue + "</td>";
        /*    Returned += "<td>" + objBiz.SNdEvaluationStatementValue + "</td>";*/
        Returned += "<td>" + objBiz.AbsenceValue + "</td>";
        Returned += "<td>" + objBiz.PenalityValue + "</td>";
        Returned += "<td>" + objBiz.DelayValue + "</td>";
        Returned += "<td>" + objBiz.AttendanceTotalDiscountValue + "</td>";
        Returned += "</tr>";
        return Returned;
    };
    return ApplicantWorkerMotivation;
}());
function GetApplicantWorkerMotivationRow(vrShowSalary, objBiz) {
    var Returned;
    Returned = "";
    Returned += "<tr>";
    var vrUnitID;
    vrUnitID = "lblEvaluation" + objBiz.ApplicantID;
    Returned += "<td>" + objBiz.ApplicantCode + "</td>";
    Returned += "<td>" + objBiz.ApplicantName + "</td>";
    Returned += "<td>" + objBiz.JobDesc + "</td>";
    Returned += "<td>" + objBiz.TotalSalary + "</td>";
    Returned += "<td>" + objBiz.StartDate + "</td>";
    //Returned += "<td>" + objBiz.MotivationValue.toFixed(0) + "</td>";
    if (objBiz.MotivationNetValue == null) {
        objBiz.MotivationNetValue = 0;
    }
    var vrValue = objBiz.SavedValue == 0 ? objBiz.MotivationNetValue : objBiz.SavedValue;
    {
        Returned += "<td>" + vrValue.toFixed(0) + "</td>";
    }
    Returned += "<td>" + objBiz.AbsenceValue + "</td>";
    Returned += "<td>" + objBiz.PenalityValue + "</td>";
    Returned += "<td>" + objBiz.DelayValue + "</td>";
    Returned += "<td>" + objBiz.AttendanceTotalDiscountValue + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillCostMotivationTable(vrCostCenter) {
    var vrShowSalaryAuthorized = false;
    if (document.getElementById("lblShowSalaryAuthorized") != null && document.getElementById("lblShowSalaryAuthorized").value == "1") {
        vrShowSalaryAuthorized = true;
    }
    var objCost = new MotivationCostCenter();
    if (vrCostCenter == 53) {
        vrCostCenter = vrCostCenter;
    }
    var objBiz = new MotivationCostCenter();
    var vrSelectedStr = document.getElementById("lblMotivationCostCenter" + vrCostCenter.toString()).getAttribute("value");
    var vrSelectedLst;
    objBiz = JSON.parse(vrSelectedStr);
    vrSelectedLst = objBiz.MotivationLst;
    var Returned;
    Returned = "<table class=\"table\">";
    Returned += "<thead>"; //" class=\"headrow\">";
    Returned += "<tr>";
    Returned += "<th></th>";
    Returned += "<th></th>";
    /*    Returned += "<th></th>";*/
    //Returned+="<th>الكود</th>";
    Returned += "<th colspan=3>بيانات الموظف</th>";
    //Returned += "<th>الوظيفة</th>";
    //Returned += "<th >تاريخ التعيين</th>";
    Returned += "<th colspan=2>الحافز</th>";
    //Returned += "<th>الاجمالى</th>";
    //Returned += "<th>الزيادة</th>";
    //Returned += "<th>الاجمالى</th>";
    Returned += "<th colspan=2>حافز</th>";
    //Returned += "<th>حافز2</th>";
    Returned += "<th></th>";
    Returned += "<th colspan=4>خصومات باليوم</th>";
    //Returned += "<th>جزاءات</th>";
    //Returned += "<th>تأخيرات</th>";
    //Returned += "<th>اجمالى</th>";
    Returned += "</tr>";
    Returned += "<tr>";
    Returned += "<th></th><th></th><th>الكود</th>";
    Returned += "<th>الموظف</th>";
    Returned += "<th>الوظيفة</th>";
    Returned += "<th>تاريخ التعيين</th>";
    Returned += "<th>الحافز</th>";
    Returned += vrShowSalaryAuthorized ? "<th>المرتب</th>" : "";
    // Returned += "<th>الاجمالى</th>";
    //Returned += "<th>الزيادة</th>";
    //Returned += "<th>الاساسى</th>";
    //Returned += "<th>الاجمالى</th>";
    Returned += "<th >" + (objBiz.MotivationLst.length == 0 || objBiz.MotivationLst[0].FStSatementID == 0 ? "حافز1" : objBiz.MotivationLst[0].FStStatementDesc) + "</th>";
    Returned += "<th >" + (objBiz.MotivationLst.length == 0 || objBiz.MotivationLst[0].SNdStatementID == 0 ? "حافز2" : objBiz.MotivationLst[0].SNdStatetmentDesc) + "</th>";
    Returned += "<th>تقييم</th>";
    Returned += "<th>الغياب</th>";
    Returned += "<th>جزاءات</th>";
    Returned += "<th>تأخيرات</th>";
    Returned += "<th>اجمالى</th>";
    Returned += "</tr>";
    Returned += "</thead>";
    var vrUnitID;
    var intIndex;
    var vrMotivation = new ApplicantWorkerMotivation();
    var vrTemp = new ApplicantWorkerMotivation();
    Returned += "<tbody>"; //" style=\"margin-top:100px;position:absolute;overflow:scroll;max-height:700px;\">";
    for (intIndex = 1; intIndex <= vrSelectedLst.length; intIndex++) {
        vrMotivation = vrSelectedLst[intIndex - 1];
        Returned += vrTemp.GetRow(vrShowSalaryAuthorized, vrMotivation, intIndex, vrCostCenter);
    }
    Returned += "</tbody>";
    Returned += "</table>";
    document.getElementById("dvApplicantMotivation" + vrCostCenter).innerHTML = Returned;
    return Returned;
}
function OnMotivationValueChange(intIndex, vrCostCenter) {
    var vrCost = new MotivationCostCenter();
    var vrCostStr = document.getElementById("lblMotivationCostCenter" + vrCostCenter.toString()).value;
    vrCost = JSON.parse(vrCostStr);
    var objBiz = vrCost.MotivationLst[intIndex];
    var vrValue = Number(document.getElementById("txtValue" + objBiz.ApplicantID.toString()).value);
    objBiz.MotivationNetValue = vrValue;
    objBiz.MotivationBonusValue = objBiz.MotivationNetValue - objBiz.MotivationValue;
    // this line added for temp
    objBiz.MotivationValue = vrValue;
    vrCost.MotivationLst[intIndex] = objBiz;
    var vrCostStr = JSON.stringify(vrCost);
    document.getElementById("lblMotivationCostCenter" + vrCostCenter.toString()).value = vrCostStr;
    var vrTotalRemaining = GetRemainingValue(vrCostCenter);
    document.getElementById("tdBonus" + objBiz.ApplicantID.toString()).innerText = objBiz.MotivationBonusValue.toFixed(0);
}
function FillApplicantWorkerMotivationTable() {
    //lblAllApplicantMotivation
    var vrStatementLst = [];
    if (document.getElementById("lblAllApplicantMotivation") != null && document.getElementById("lblAllApplicantMotivation").value != "") {
        vrStatementLst = JSON.parse(document.getElementById("lblAllApplicantMotivation").value);
    }
    var Returned = "<table class=\"table\">";
    var vrUnitID;
    var intIndex;
    var vrMotivation = new ApplicantWorkerMotivation();
    var vrTemp = new ApplicantWorkerMotivation();
    /////////
    Returned += "<tr>";
    Returned += "<th>كود</th>";
    Returned += "<th>اسم</th>";
    Returned += "<th>وظيفة</th>";
    //Returned += "<td>" + objBiz.StartDate + "</td>";
    Returned += "<th>مرتب</th>";
    Returned += "<th>تاريخ تعيين</th>";
    {
        Returned += "<th>قيمة</th>";
    }
    Returned += "<th>الغياب</th>";
    Returned += "<th>جزاء</th>";
    Returned += "<th>تأخير</th>";
    Returned += "<th>اجمالى خصومات</th>";
    Returned += "</tr>";
    /////////////////////////
    Returned += "<tbody>"; //" style=\"margin-top:100px;position:absolute;overflow:scroll;max-height:700px;\">";
    var vrFilter = "";
    if (document.getElementById("txtFilterName") != null) {
        vrFilter = document.getElementById("txtFilterName").value;
    }
    for (intIndex = 1; intIndex <= vrStatementLst.length; intIndex++) {
        vrMotivation = vrStatementLst[intIndex - 1];
        if (vrFilter == "" || vrMotivation.ApplicantCode.indexOf(vrFilter) > -1 || vrMotivation.ApplicantName.indexOf(vrFilter) > -1)
            Returned += GetApplicantWorkerMotivationRow(true, vrMotivation);
    }
    Returned += "</tbody>";
    Returned += "</table>";
    document.getElementById("tblApplicantMotivation").innerHTML = Returned;
    //return Returned;
}
//# sourceMappingURL=ApplicantWorkerMotivation.js.map