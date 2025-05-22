var MotivationCostCenter = /** @class */ (function () {
    function MotivationCostCenter() {
        this.IncludeSectorHeadValue = false;
        this.AdjustRemainingValue = false;
        this.MotivationLst = [];
    }
    return MotivationCostCenter;
}());
function PerformDivisionDependsOnEvaluation(objBiz, blIncludeSectorHeadValue, blAdjustRemainingValue) {
    var vrTotalSalaries = objBiz.MotivationLst.map(function (x) { return x.TotalSalary; }).reduce(function (a, b) { return a + b; });
    var vrValue = vrTotalSalaries;
    if (blIncludeSectorHeadValue)
        vrValue = vrValue + objBiz.SectorHeadValue;
    //vrValue *= objBiz.Ratio / 100;
    var objMotivation = new ApplicantWorkerMotivation();
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.TempRecommended = objMotivation.TotalSalary * (objMotivation.FStEvaluationStatementValue / 100) * (objBiz.Ratio / 100);
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
    var vrTotalRecommended = objBiz.MotivationLst.map(function (x) { return x.TempRecommended; }).reduce(function (a, b) { return a + b; });
    var vrNewRatio = 0;
    vrNewRatio = blAdjustRemainingValue ? ((vrValue * objBiz.Ratio / 100) / vrTotalRecommended) : 1;
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.MotivationValue = objMotivation.TempRecommended * vrNewRatio;
        objMotivation.MotivationNetValue = objMotivation.MotivationValue;
        objMotivation.MotivationBonusValue = objMotivation.MotivationNetValue - objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
}
function PerformDivision(objBiz, blIncludeSectorHeadValue, blAdjustRemainingValue) {
    /*var vrTotalSalaries: number = objBiz.MotivationLst.map(function (x) { return x.TotalSalary; }).reduce(function (a, b) { return a + b; });*/
    var vrTotalSalaries = objBiz.TotalSalaryAndHeadSectorValue;
    var vrValue = vrTotalSalaries;
    if (!blIncludeSectorHeadValue)
        vrValue = vrTotalSalaries - (objBiz.SectorHeadValue * objBiz.Ratio / 100);
    //vrValue *= objBiz.Ratio / 100;
    var objMotivation = new ApplicantWorkerMotivation();
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        /* objMotivation.TempRecommended = objMotivation.TotalSalary * (objMotivation.FStEvaluationStatementValue / 100) * (objBiz.Ratio / 100);*/
        objMotivation.TempRecommended = objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
    var vrTotalRecommended = objBiz.MotivationLst.length == 0 ? 0 : objBiz.MotivationLst.map(function (x) { return x.TempRecommended; }).reduce(function (a, b) { return a + b; });
    var vrNewRatio = 0;
    vrNewRatio = blAdjustRemainingValue ? ((vrValue * objBiz.Ratio / 100) / (vrTotalRecommended == 0 ? 1 : vrTotalRecommended)) : 1;
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.MotivationValue = objMotivation.TempRecommended * vrNewRatio;
        objMotivation.MotivationNetValue = objMotivation.MotivationValue;
        objMotivation.MotivationBonusValue = objMotivation.MotivationNetValue - objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
}
function GetCurrentCostCenter(vrCostCenter) {
    var vrCost = new MotivationCostCenter();
    if (document.getElementById("lblMotivationCostCenter" + vrCostCenter) != null) {
        var vrCostStr = document.getElementById("lblMotivationCostCenter" + vrCostCenter).value;
        vrCost = JSON.parse(vrCostStr);
    }
    return vrCost;
}
function PerformCostDevision(vrCostCenter) {
    var vrCost = GetCurrentCostCenter(vrCostCenter);
    var blJustify = document.getElementById("chkJustify" + vrCostCenter).checked;
    var blDevideSectorHeader = document.getElementById("chkDevideSectorHeadValue" + vrCostCenter).checked;
    PerformDivision(vrCost, blDevideSectorHeader, blJustify);
    var vrCostStr = JSON.stringify(vrCost);
    document.getElementById("lblMotivationCostCenter" + vrCostCenter).value = vrCostStr;
    try {
        FillCostMotivationTable(vrCostCenter);
        GetRemainingValue(vrCostCenter);
    }
    catch (_a) { }
    return false;
}
function PerformAllCostDeVision() {
    var vrCostIDs = JSON.parse(document.getElementById("lblAllCostIDs").value);
    for (var vrIndex = 0; vrIndex < vrCostIDs.length; vrIndex++) {
        if (document.getElementById("lblMotivationCostCenter" + vrCostIDs[vrIndex]) != null) {
            PerformCostDevision(vrCostIDs[vrIndex]);
        }
    }
}
function GetRemainingValue(vrCostCenter) {
    var objBiz = GetCurrentCostCenter(vrCostCenter);
    var vrTotal = objBiz.MotivationLst.map(function (x) { return x.MotivationValue; }).reduce(function (x, y) { return x + y; });
    var vrTotalSalaries = objBiz.TotalSalaryAndHeadSectorValue;
    //vrTotalSalaries = objBiz.
    var blIncludeSectorHeadValue = document.getElementById("chkDevideSectorHeadValue" + vrCostCenter).checked;
    //var vrValue: number = vrTotalSalaries;
    ////if (blIncludeSectorHeadValue)
    //    vrValue = vrValue + objBiz.SectorHeadValue;
    //vrValue *= objBiz.Ratio / 100;
    var vrValue = vrTotalSalaries;
    if (!blIncludeSectorHeadValue)
        vrValue = vrTotalSalaries - (objBiz.SectorHeadValue * objBiz.Ratio / 100);
    vrValue += objBiz.BounsOnDeserved;
    var vrRemaining = vrValue - vrTotal;
    try {
        document.getElementById("lblRemainingValue" + vrCostCenter).innerText = vrRemaining.toFixed(0);
    }
    catch (_a) { }
    try {
        document.getElementById("lblDevidedValue" + vrCostCenter).innerText = vrTotal.toFixed(0);
    }
    catch (_b) { }
    return vrRemaining;
}
//# sourceMappingURL=MotivationCostCenter.js.map