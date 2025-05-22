class MotivationCostCenter {
    public ID: number;
    public Name: string;
    public SectorHeadValue: number;
    public Ratio: number;
    public MotivationStatementID:number;
    public MotivationStatementDesc: string;
    public IncludeSectorHeadValue: boolean = false;
    public AdjustRemainingValue: boolean = false;
    public TotalSalaryAndHeadSectorValue: number;
    public BounsOnDeserved: number;
    public Credit: number;
    public PreviousCredit: number;
    public MotivationLst: ApplicantWorkerMotivation[] = [];
   
}
function PerformDivisionDependsOnEvaluation(objBiz:MotivationCostCenter,blIncludeSectorHeadValue: boolean, blAdjustRemainingValue:boolean) {

    var vrTotalSalaries: number = objBiz.MotivationLst.map(function (x) { return x.TotalSalary; }).reduce(function (a, b) { return a + b; });


    var vrValue: number = vrTotalSalaries;
    if (blIncludeSectorHeadValue)
        vrValue = vrValue + objBiz.SectorHeadValue;

    //vrValue *= objBiz.Ratio / 100;
    var objMotivation: ApplicantWorkerMotivation = new ApplicantWorkerMotivation();
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.TempRecommended = objMotivation.TotalSalary * (objMotivation.FStEvaluationStatementValue / 100) * (objBiz.Ratio / 100);
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }

    var vrTotalRecommended: number = objBiz.MotivationLst.map(function (x) { return x.TempRecommended; }).reduce(function (a, b) { return a + b; });
    var vrNewRatio: number = 0;

    vrNewRatio = blAdjustRemainingValue ? ((vrValue * objBiz.Ratio / 100)/vrTotalRecommended) : 1;
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.MotivationValue = objMotivation.TempRecommended * vrNewRatio;
        objMotivation.MotivationNetValue = objMotivation.MotivationValue;
        objMotivation.MotivationBonusValue = objMotivation.MotivationNetValue-objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
}

function PerformDivision(objBiz: MotivationCostCenter, blIncludeSectorHeadValue: boolean, blAdjustRemainingValue: boolean) {

    /*var vrTotalSalaries: number = objBiz.MotivationLst.map(function (x) { return x.TotalSalary; }).reduce(function (a, b) { return a + b; });*/

    var vrTotalSalaries: number = objBiz.TotalSalaryAndHeadSectorValue;
    var vrValue: number = vrTotalSalaries;
    if (!blIncludeSectorHeadValue)
        vrValue = vrTotalSalaries - (objBiz.SectorHeadValue * objBiz.Ratio / 100);

    //vrValue *= objBiz.Ratio / 100;
    var objMotivation: ApplicantWorkerMotivation = new ApplicantWorkerMotivation();
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
    /* objMotivation.TempRecommended = objMotivation.TotalSalary * (objMotivation.FStEvaluationStatementValue / 100) * (objBiz.Ratio / 100);*/
        objMotivation.TempRecommended = objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }

    var vrTotalRecommended: number = objBiz.MotivationLst.length==0?0: objBiz.MotivationLst.map(function (x) { return x.TempRecommended; }).reduce(function (a, b) { return a + b; });
    var vrNewRatio: number = 0;

    vrNewRatio = blAdjustRemainingValue ? ((vrValue * objBiz.Ratio / 100) / (vrTotalRecommended== 0 ?1:vrTotalRecommended)) : 1;
    for (var vrIndex = 0; vrIndex < objBiz.MotivationLst.length; vrIndex++) {
        objMotivation = objBiz.MotivationLst[vrIndex];
        objMotivation.MotivationValue = objMotivation.TempRecommended * vrNewRatio;
        objMotivation.MotivationNetValue = objMotivation.MotivationValue;
        objMotivation.MotivationBonusValue = objMotivation.MotivationNetValue - objMotivation.MotivationValue;
        objBiz.MotivationLst[vrIndex] = objMotivation;
    }
}
function GetCurrentCostCenter(vrCostCenter): MotivationCostCenter {
    var vrCost: MotivationCostCenter = new MotivationCostCenter();
    if (document.getElementById("lblMotivationCostCenter" + vrCostCenter) != null) {
        var vrCostStr: string = (<HTMLInputElement>document.getElementById("lblMotivationCostCenter" + vrCostCenter)).value;
        vrCost = JSON.parse(vrCostStr);
    }
    return vrCost;
}
function PerformCostDevision(vrCostCenter) {
    var vrCost: MotivationCostCenter = GetCurrentCostCenter(vrCostCenter);
    var blJustify: boolean = (<HTMLInputElement>document.getElementById("chkJustify"+vrCostCenter)).checked;
    var blDevideSectorHeader: boolean = (<HTMLInputElement>document.getElementById("chkDevideSectorHeadValue"+vrCostCenter)).checked;
    PerformDivision(vrCost, blDevideSectorHeader,blJustify);
  var  vrCostStr : string = JSON.stringify(vrCost);
    (<HTMLInputElement>document.getElementById("lblMotivationCostCenter"+vrCostCenter)).value = vrCostStr;
    try {
    FillCostMotivationTable(vrCostCenter);
   
        GetRemainingValue(vrCostCenter);
    } catch {}
    return false;
}
function PerformAllCostDeVision() {
    var vrCostIDs: number[] = JSON.parse((<HTMLInputElement>document.getElementById("lblAllCostIDs")).value);
    for (var vrIndex = 0; vrIndex < vrCostIDs.length; vrIndex++) {
        if (document.getElementById("lblMotivationCostCenter" + vrCostIDs[vrIndex]) != null) {
            PerformCostDevision(vrCostIDs[vrIndex]);
        }
    }
    
}
function GetRemainingValue(vrCostCenter):number {
    
    var objBiz: MotivationCostCenter = GetCurrentCostCenter(vrCostCenter);
    var vrTotal: number = objBiz.MotivationLst.map(function (x) { return  x.MotivationValue; }).reduce(function (x, y) { return x + y; });
    var vrTotalSalaries: number = objBiz.TotalSalaryAndHeadSectorValue;
   
   
    //vrTotalSalaries = objBiz.
    var blIncludeSectorHeadValue: boolean = (<HTMLInputElement>document.getElementById("chkDevideSectorHeadValue"+vrCostCenter)).checked;

    //var vrValue: number = vrTotalSalaries;
    ////if (blIncludeSectorHeadValue)
    //    vrValue = vrValue + objBiz.SectorHeadValue;
    //vrValue *= objBiz.Ratio / 100;
    var vrValue: number = vrTotalSalaries;
    if (!blIncludeSectorHeadValue)
        vrValue = vrTotalSalaries - (objBiz.SectorHeadValue * objBiz.Ratio / 100);
    vrValue += objBiz.BounsOnDeserved;
    var vrRemaining: number = vrValue - vrTotal;
    try {
        (<HTMLInputElement>document.getElementById("lblRemainingValue"+vrCostCenter)).innerText = vrRemaining.toFixed(0);
    }
    catch { }
    try {
        (<HTMLInputElement>document.getElementById("lblDevidedValue"+vrCostCenter)).innerText = vrTotal.toFixed(0);
    }
    catch { }
    return vrRemaining;
}