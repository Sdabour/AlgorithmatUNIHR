var ApplicantValue = /** @class */ (function () {
    function ApplicantValue() {
    }
    return ApplicantValue;
}());
function GetApplicantMotivationValueList(vrCost) {
    var Returned = [];
    var vrCostCenter = new MotivationCostCenter();
    vrCostCenter = JSON.parse(document.getElementById("lblMotivationCostCenter" + vrCost).value);
    var vrApplicantLst = vrCostCenter.MotivationLst;
    var vrStatement = Number(document.getElementById("lblStatementID").value);
    var vrValue = 0;
    var vrMotivation;
    var vrUser = GetCurrentUser();
    for (var vrIndex = 0; vrIndex < vrApplicantLst.length; vrIndex++) {
        vrMotivation = new ApplicantValue();
        vrMotivation.Code = vrApplicantLst[vrIndex].ApplicantCode;
        vrMotivation.Name = vrApplicantLst[vrIndex].ApplicantName;
        /*Returned[vrIndex].Code = vrApplicantLst[vrIndex].ApplicantCode;*/
        vrValue = Number(document.getElementById("txtValue" + vrApplicantLst[vrIndex].ApplicantID.toString()).value);
        vrMotivation.Value = vrValue;
        vrMotivation.User = vrUser.ID;
        vrMotivation.Reference = vrStatement;
        Returned[vrIndex] = vrMotivation;
    }
    return Returned;
}
//# sourceMappingURL=ApplicantValue.js.map