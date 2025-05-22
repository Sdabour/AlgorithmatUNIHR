class ApplicantValue
{
    public Reference: number;
    public Code: string;
    public Name: string;
    public Value: number;
    public User: number;
   
}
function GetApplicantMotivationValueList(vrCost:number): ApplicantValue[]
{
    var Returned: ApplicantValue[]=[];
    var vrCostCenter: MotivationCostCenter = new MotivationCostCenter();
    vrCostCenter = JSON.parse((<HTMLInputElement>document.getElementById("lblMotivationCostCenter"+vrCost)).value);
    var vrApplicantLst: ApplicantWorkerMotivation[] = vrCostCenter.MotivationLst;
    var vrStatement: number = Number((<HTMLInputElement>document.getElementById("lblStatementID")).value);

    var vrValue: number = 0;
    var vrMotivation: ApplicantValue;
    var vrUser :User= GetCurrentUser();
    for (var vrIndex = 0; vrIndex < vrApplicantLst.length; vrIndex++) {
        vrMotivation = new ApplicantValue();
        vrMotivation.Code = vrApplicantLst[vrIndex].ApplicantCode;
        vrMotivation.Name = vrApplicantLst[vrIndex].ApplicantName;
        /*Returned[vrIndex].Code = vrApplicantLst[vrIndex].ApplicantCode;*/
        vrValue = Number((<HTMLInputElement>document.getElementById("txtValue" + vrApplicantLst[vrIndex].ApplicantID.toString())).value);
        vrMotivation.Value = vrValue;
        
        vrMotivation.User = vrUser.ID;
        vrMotivation.Reference = vrStatement;
        Returned[vrIndex] = vrMotivation;
    }
    return Returned;
}