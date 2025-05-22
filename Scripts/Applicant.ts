class ApplicantSingle
{
    public Name: string;
   public ID: number;
    public Code: string;
    public Sector: string;
   public  Department: string;
   public Job: string;
    public Processed: boolean;
    public Value: string;
    public ForiegnID: number;
    public IsCurrentApplicant: boolean;
    //intType 0 =>Evaluation 1=>User
    FillApplicantLst(strApplicantLbl: string, strApplicantTble: string, strApplicantCode: string, strApplicantName: string, intStatus: number,intType:number) {
        var vrApplicant = document.getElementById(strApplicantLbl);
        if (vrApplicant == null)
        {
            return;
        }
        var strApplicant = vrApplicant.getAttribute("value");
    if (strApplicant != "") {
        let arrApplicant: ApplicantSingle[] = JSON.parse(strApplicant);
        document.getElementById("lblTotalCount").innerText = arrApplicant.length.toString();
        document.getElementById("lblProcessedCount").innerText = arrApplicant.filter(function (objX) { return objX.Processed;}).length.toString();
        let arrApplicantFilter  :ApplicantSingle[];
        arrApplicantFilter= arrApplicant.filter(x =>
            strApplicantCode == "" || x.Code.indexOf(strApplicantCode) > -1

        );
        arrApplicantFilter = arrApplicantFilter.filter(x =>
            (strApplicantName == "") || (x.Name.indexOf(strApplicantName) > -1) || (x.Code.indexOf(strApplicantName) > -1)

        );
        arrApplicantFilter = arrApplicantFilter.filter(x =>
            (intStatus == 0 || (intStatus == 1 && x.Processed) || (intStatus == 2 && !x.Processed))

        );
        let objSingle :ApplicantSingle;
        let strApplicantRow: string;
        strApplicantRow = "";
        for (var intIndex = 0; intIndex < arrApplicantFilter.length && intIndex <100; intIndex++)
        {
            objSingle = arrApplicantFilter[intIndex];
            strApplicantRow += "<tr  style=\"max-width:100%;text-align:right;line-height:10px;\">";
            strApplicantRow += "<td style=\"padding:5px;\" width=\"10%\">";
            strApplicantRow += objSingle.Code == null ? "&nbsp;" : objSingle.Code;
            strApplicantRow+= "</td>";
            strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"40%\" dir=\"rtl\">" + objSingle.Name + " </td>";
            strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"35%\" dir=\"rtl\">" + objSingle.Job  + " </td>";
            strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\" >";
            strApplicantRow += (objSingle.Processed ? "تم" : "X");
           strApplicantRow += "</td>";
            strApplicantRow += "<td style=\"padding:5px;\" width = \"5%\" >";
            strApplicantRow += (objSingle.Value == null ? "&nbsp;" : objSingle.Value);
            strApplicantRow += " </td>";
            strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\">";
            if (!objSingle.IsCurrentApplicant) {
                strApplicantRow += this.GetRef(intType,objSingle);
            }
            strApplicantRow+= "</td>";
            strApplicantRow += "</tr>";
           // strApplicantRow += "</table></td></tr>";
        }
        vrApplicant = document.getElementById(strApplicantTble);
        vrApplicant.innerHTML = strApplicantRow;
        //document.getElementById(strApplicantTble).setAttribute("innerHtml", strApplicantRow);


    }
    }
    GetRef(intType: number,objSingle:ApplicantSingle): string
    {
        let Returned: string;
        
        Returned =window.location.origin;
        if (intType == 0) {
            Returned = "<a href = \"" + Returned + "/ApplicantWorkerEstimation/index?AppID=" + objSingle.ID + "&StatementID=" + objSingle.ForiegnID.toString() + "\">&#1578;&#1602;&#1610;&#1610;&#1605; </a>";
        }
        else if (intType == 1) { Returned = "<a href = \"" + Returned + "/Login/CreateUser?AppID=" + objSingle.ID + "\">مستخدم </a>"; }
        return Returned;
    }
    RadioButtonStr(intID: number):string
    {
        let Returned: string;
        Returned = "";
        Returned += "<div class=\"form - group pt - 2\">"+
            "< label class=\"font-weight-semibold\" > Left stacked styled < /label> "+
                "< div class=\"form-check\" >"+
                    "<label class=\"form-check-label\" >"+
                        "<div class=\"uniform-choice\" > <span class=\"checked\" > <input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" checked = \"\" data - fouc=\"\" > </span></div >"+
                            "Selected styled"+
                                "< /label>"+
                                "< /div>"+

                              "  < div class=\"form-check\" >"+
                                    "<label class=\"form-check-label\" >"
                                        " <div class=\"uniform-choice\" >  <span><input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" data - fouc=\"\" > </span></div >"+
                                            "Unselected styled "+
                                                "< /label> "+
                                                " < /div> "+

                                           
                                                                "</div> ";
        return Returned;
    }
    GetDatRow(objBiz:ApplicantSingle): string {
        let strSelected: string = (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value;


        let lstEmployee: ApplicantSingle[] = [];
        if (strSelected != "") {
            lstEmployee = JSON.parse(strSelected);

        }

        var vrChecked: string = "";
        if (lstEmployee.filter(objEmployee => { return objEmployee.ID == objBiz.ID;}).length > 0)
        {
            vrChecked = "checked";
        }
        let Returned: string = "";
        let strTemp: string = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblEmployee"+objBiz.ID+"\" value='"+strTemp+"' /></td>";
        Returned += "<td>" + objBiz.Code + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.Department + "</td>";
        Returned += "<td>" + objBiz.Job + "</td>";
    /*   Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnEmployee" + objBiz.ID + "\"  onclick=\" CloseEmployeeModal();return onEmployeeClick('" + objBiz.ID + "')\" name=\"btnEmployee" + objBiz.ID + "\" /></td>";*/
        Returned += "<td>" +
            "<input id=\"chkEmployee" + objBiz.ID + "\"" +
            " type =\"checkbox\" onchange=\"onEmployeeCheck('"+objBiz.ID + "');\" "+vrChecked+"  /></td>";
        Returned += "</tr>";
        return Returned;
    }
    GetSelectedDatRow(objBiz:ApplicantSingle): string {
        let Returned: string = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedEmployee" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.Code + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.Department + "</td>";
        Returned += "<td>" + objBiz.Job + "</td>";
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedEmployee" + objBiz.ID + "\"  onclick=\"return onEmployeeClick('" + objBiz.ID + "')\" name=\"btnSelectedEmployee" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    }
}

class EstimationStatementSingle
{   
    public Desc: string;
    public ID: number;
    public Date: Date;
    public IsGlobal: boolean;
}
class ApplicantEstimationStatementSingle
{
    public Applicant: ApplicantSingle;
    public EstimationStatement: EstimationStatementSingle;
    public CostCenter: string;
    public EstimationGroup: string;
    public IsSummary: boolean;
}
class ApplicantEstimationStatementElementSingle {
    public Statement: number;
    public ElementID: number;
    public ElementDesc: string;
    public EstimationValue: number;
    public ElementValue: number;
    public IsFuzzyValue: boolean;
    public FuzzyValue: number;
    public Group: string;
    public GroupPerc: number;
    public GroupOrder: number;
    public GroupName: string;
    public ElementWeight: number;
    SetEstimationTotals(intElementID: number,strNewValue:string)
    {
        let objElementCol: ApplicantEstimationStatementElementSingle[];
        let objElement: ApplicantEstimationStatementElementSingle = new ApplicantEstimationStatementElementSingle();
        let strElementCol: string;
        
        strElementCol = document.getElementById("lblElementCol").getAttribute("value");
        objElementCol = JSON.parse(strElementCol);
        let dblTotal: number = 0;
        let dblTotalRef: number = 0;
        let dblValue: number = 0;
        let dblEstimationValue: number = 0;
        let strEstimationName: string = "txtEstimationValue" + intElementID.toString();
        var objEstimationControl = document.getElementById(strEstimationName);
        let dblElementWeight:number = 0;

        let strValue: string = strNewValue;
        try {
            dblValue = parseFloat(strValue);
        } catch { }
        let objFilterElementCol: ApplicantEstimationStatementElementSingle[];
        objFilterElementCol = objElementCol.filter(x => x.ElementID == intElementID);
        if (objFilterElementCol.length > 0)
        {
            objElement = objFilterElementCol[0];
            
            dblEstimationValue = objElement.ElementValue;
            if (dblValue > dblEstimationValue)
            {
                alert("الدرجة اكبر من المتوقع");
              
                objEstimationControl.innerText = dblEstimationValue.toString();
                dblValue = dblEstimationValue;
            }
             strValue = (dblValue * 100 / objElement.ElementValue).toFixed().toString();
            var objEstimationControl1 = document.getElementById("txtPerc" + intElementID.toString());
          
            objEstimationControl1.innerText = strValue;
            objFilterElementCol[0].EstimationValue = dblValue;
            objFilterElementCol = null;
            objFilterElementCol = objElementCol.filter(x => x.Group == objElement.Group);

            dblValue = 0;
             strValue = "lblGroupValue" + objElement.Group.toString();
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++)
            {
                if (objFilterElementCol[intIndex].ElementWeight == 0)
                {
                    objFilterElementCol[intIndex].ElementWeight = 100 / objFilterElementCol.length;
                }
                dblValue += (objFilterElementCol[intIndex].EstimationValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight;
            }
            document.getElementById(strValue).innerText =  Math.round(dblValue).toString();

        }
        if (objElement.ElementID > 0)
        {
            objEstimationControl = null;
            objFilterElementCol = objElementCol;
            objFilterElementCol = objFilterElementCol.filter(x => x.EstimationValue != -1);
            dblTotal = 0;
            dblTotalRef = 0;
            var objValueElement;
            let dblTotalValue1: number = 0;
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++)
            {
                objEstimationControl = null;
                objEstimationControl = document.getElementById("chkStopElement" + objFilterElementCol[intIndex].ElementID.toString());
                if (objEstimationControl.getAttribute("checked") == "true")
                    continue;
                objValueElement = null;
                objValueElement = document.getElementById("txtEstimationValue" + objFilterElementCol[intIndex].ElementID.toString());
                let strValue = objValueElement.value;
                dblValue = 0;
                
                try {
                    dblValue = parseFloat(strValue);
                    dblTotal += dblValue;
                    dblTotalRef += objFilterElementCol[intIndex].ElementValue;
                    dblTotalValue1 += (dblValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight * (objFilterElementCol[intIndex].GroupPerc/100);
                }
                catch { }
                

            }

            objEstimationControl = null;
            document.getElementById("lblTotalValue").innerText = Math.round( dblTotalValue1).toString();
            document.getElementById("lblTotalPerc").innerText = (dblTotal * 100 / dblTotalRef).toFixed().toString();
            strValue = dblEstimationValue > 0 ? (dblValue *100/ dblEstimationValue).toString() : "";
        
            
        }

    }
}
function onEmployeeClick(intEmployee: number)
{
    let vrEmployeeLbl: string = "lblEmployee" + intEmployee; 
    let strEmployee: string = (<HTMLInputElement>document.getElementById(vrEmployeeLbl)).value;
    var vrTempElement = <HTMLInputElement>document.getElementById(vrEmployeeLbl);
    let strSelected: string = (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value;


    let lstEmployee: ApplicantSingle[] =[];
    if (strSelected != "")
    {
        lstEmployee = JSON.parse(strSelected);

    }
    let objBiz: ApplicantSingle = JSON.parse(strEmployee);
    if (lstEmployee.filter(x => x.ID == objBiz.ID).length == 0) {
        lstEmployee[lstEmployee.length] = objBiz;
    }
    strSelected = JSON.stringify(lstEmployee);
    document.getElementById("lblSelectedEmployee").setAttribute("value", strSelected);
    
    FillSelectedEmployee();
   
}
function onEmployeeCheck(intEmployee: number) {
   
    let vrEmployeeLbl: string = "lblEmployee" + intEmployee;
    let strEmployee: string = (<HTMLInputElement>document.getElementById(vrEmployeeLbl)).value;
    var vrTempElement = <HTMLInputElement>document.getElementById(vrEmployeeLbl);
    var vrCheckEmployee = (<HTMLInputElement>document.getElementById("chkEmployee" + intEmployee)).checked;
    let strSelected: string = (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value;


    let lstEmployee: ApplicantSingle[] = [];
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);
        
    }
    let objBiz: ApplicantSingle = JSON.parse(strEmployee);
    if (vrCheckEmployee) {
        if (lstEmployee.filter(x => x.ID == objBiz.ID).length == 0) {
            lstEmployee[lstEmployee.length] = objBiz;
        }
    }
    else
    {
        var lstNew: ApplicantSingle[] = [];
        for (var vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++)
        {
            if (lstEmployee[vrIndex].ID != objBiz.ID)
            {
                lstNew[lstNew.length] = lstEmployee[vrIndex];
            }
        }
        lstEmployee = lstNew;
    }
    
    strSelected = JSON.stringify(lstEmployee);
    document.getElementById("lblSelectedEmployee").setAttribute("value", strSelected);

    FillSelectedEmployee();

}
function FillSelectedEmployee()
{
   
    let strSelected: string = document.getElementById("lblSelectedEmployee").getAttribute("value");


    let lstEmployee: ApplicantSingle[];
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);

    } 
    var vrIndex: number = 0;
    var vrSelectedEmployeeStr: string = "";
    var vrTable: string;
    vrTable = "<table>";
    let objBiz: ApplicantSingle = new ApplicantSingle();
    for (vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++) {
        vrTable += objBiz.GetSelectedDatRow(lstEmployee[vrIndex]);
        if (vrSelectedEmployeeStr != "")
            vrSelectedEmployeeStr += "&";
        vrSelectedEmployeeStr += lstEmployee[vrIndex].Name;
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("txtApplicantRecepient")).value = vrSelectedEmployeeStr;

    document.getElementById("dvSelectedEmployee").innerHTML = vrTable;

}

function GetSelectedEmployeeTable():string {

    let strSelected: string = document.getElementById("lblSelectedEmployee").getAttribute("value");


    let lstEmployee: ApplicantSingle[];
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);

    }
    var vrIndex: number = 0;
    var vrSelectedEmployeeStr: string = "";
    var vrTable: string;
    vrTable = "<table>";
    let objBiz: ApplicantSingle = new ApplicantSingle();
    for (vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++) {
        vrTable += objBiz.GetDatRow(lstEmployee[vrIndex]);
        if (vrSelectedEmployeeStr != "")
            vrSelectedEmployeeStr += "&";
        vrSelectedEmployeeStr += lstEmployee[vrIndex].Name;
    }
    vrTable += "</table>";
   
    return vrTable;
}