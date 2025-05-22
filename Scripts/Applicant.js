var ApplicantSingle = /** @class */ (function () {
    function ApplicantSingle() {
    }
    //intType 0 =>Evaluation 1=>User
    ApplicantSingle.prototype.FillApplicantLst = function (strApplicantLbl, strApplicantTble, strApplicantCode, strApplicantName, intStatus, intType) {
        var vrApplicant = document.getElementById(strApplicantLbl);
        if (vrApplicant == null) {
            return;
        }
        var strApplicant = vrApplicant.getAttribute("value");
        if (strApplicant != "") {
            var arrApplicant = JSON.parse(strApplicant);
            document.getElementById("lblTotalCount").innerText = arrApplicant.length.toString();
            document.getElementById("lblProcessedCount").innerText = arrApplicant.filter(function (objX) { return objX.Processed; }).length.toString();
            var arrApplicantFilter = void 0;
            arrApplicantFilter = arrApplicant.filter(function (x) {
                return strApplicantCode == "" || x.Code.indexOf(strApplicantCode) > -1;
            });
            arrApplicantFilter = arrApplicantFilter.filter(function (x) {
                return (strApplicantName == "") || (x.Name.indexOf(strApplicantName) > -1) || (x.Code.indexOf(strApplicantName) > -1);
            });
            arrApplicantFilter = arrApplicantFilter.filter(function (x) {
                return (intStatus == 0 || (intStatus == 1 && x.Processed) || (intStatus == 2 && !x.Processed));
            });
            var objSingle = void 0;
            var strApplicantRow = void 0;
            strApplicantRow = "";
            for (var intIndex = 0; intIndex < arrApplicantFilter.length && intIndex < 100; intIndex++) {
                objSingle = arrApplicantFilter[intIndex];
                strApplicantRow += "<tr  style=\"max-width:100%;text-align:right;line-height:10px;\">";
                strApplicantRow += "<td style=\"padding:5px;\" width=\"10%\">";
                strApplicantRow += objSingle.Code == null ? "&nbsp;" : objSingle.Code;
                strApplicantRow += "</td>";
                strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"40%\" dir=\"rtl\">" + objSingle.Name + " </td>";
                strApplicantRow += "<td style=\"padding:5px;\" align=\"center\" width=\"35%\" dir=\"rtl\">" + objSingle.Job + " </td>";
                strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\" >";
                strApplicantRow += (objSingle.Processed ? "تم" : "X");
                strApplicantRow += "</td>";
                strApplicantRow += "<td style=\"padding:5px;\" width = \"5%\" >";
                strApplicantRow += (objSingle.Value == null ? "&nbsp;" : objSingle.Value);
                strApplicantRow += " </td>";
                strApplicantRow += "<td style=\"padding:5px; \" width=\"5%\">";
                if (!objSingle.IsCurrentApplicant) {
                    strApplicantRow += this.GetRef(intType, objSingle);
                }
                strApplicantRow += "</td>";
                strApplicantRow += "</tr>";
                // strApplicantRow += "</table></td></tr>";
            }
            vrApplicant = document.getElementById(strApplicantTble);
            vrApplicant.innerHTML = strApplicantRow;
            //document.getElementById(strApplicantTble).setAttribute("innerHtml", strApplicantRow);
        }
    };
    ApplicantSingle.prototype.GetRef = function (intType, objSingle) {
        var Returned;
        Returned = window.location.origin;
        if (intType == 0) {
            Returned = "<a href = \"" + Returned + "/ApplicantWorkerEstimation/index?AppID=" + objSingle.ID + "&StatementID=" + objSingle.ForiegnID.toString() + "\">&#1578;&#1602;&#1610;&#1610;&#1605; </a>";
        }
        else if (intType == 1) {
            Returned = "<a href = \"" + Returned + "/Login/CreateUser?AppID=" + objSingle.ID + "\">مستخدم </a>";
        }
        return Returned;
    };
    ApplicantSingle.prototype.RadioButtonStr = function (intID) {
        var Returned;
        Returned = "";
        Returned += "<div class=\"form - group pt - 2\">" +
            "< label class=\"font-weight-semibold\" > Left stacked styled < /label> " +
            "< div class=\"form-check\" >" +
            "<label class=\"form-check-label\" >" +
            "<div class=\"uniform-choice\" > <span class=\"checked\" > <input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" checked = \"\" data - fouc=\"\" > </span></div >" +
            "Selected styled" +
            "< /label>" +
            "< /div>" +
            "  < div class=\"form-check\" >" +
            "<label class=\"form-check-label\" >";
        " <div class=\"uniform-choice\" >  <span><input type=\"radio\" class=\"form-check-input-styled\" name = \"stacked-radio-left\" data - fouc=\"\" > </span></div >" +
            "Unselected styled " +
            "< /label> " +
            " < /div> " +
            "</div> ";
        return Returned;
    };
    ApplicantSingle.prototype.GetDatRow = function (objBiz) {
        var strSelected = document.getElementById("lblSelectedEmployee").value;
        var lstEmployee = [];
        if (strSelected != "") {
            lstEmployee = JSON.parse(strSelected);
        }
        var vrChecked = "";
        if (lstEmployee.filter(function (objEmployee) { return objEmployee.ID == objBiz.ID; }).length > 0) {
            vrChecked = "checked";
        }
        var Returned = "";
        var strTemp = JSON.stringify(objBiz);
        Returned += "<tr>";
        Returned += "<td><input type=\"hidden\" id=\"lblEmployee" + objBiz.ID + "\" value='" + strTemp + "' /></td>";
        Returned += "<td>" + objBiz.Code + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.Department + "</td>";
        Returned += "<td>" + objBiz.Job + "</td>";
        /*   Returned += "<td><input type=\"button\" value=\"تثبيت\" id=\"btnEmployee" + objBiz.ID + "\"  onclick=\" CloseEmployeeModal();return onEmployeeClick('" + objBiz.ID + "')\" name=\"btnEmployee" + objBiz.ID + "\" /></td>";*/
        Returned += "<td>" +
            "<input id=\"chkEmployee" + objBiz.ID + "\"" +
            " type =\"checkbox\" onchange=\"onEmployeeCheck('" + objBiz.ID + "');\" " + vrChecked + "  /></td>";
        Returned += "</tr>";
        return Returned;
    };
    ApplicantSingle.prototype.GetSelectedDatRow = function (objBiz) {
        var Returned = "";
        Returned += "<tr>";
        Returned += "<input type=\"hidden\" id=\"lblSelectedEmployee" + objBiz.ID + "\" value=\"" + JSON.stringify(objBiz) + "\"/>";
        Returned += "<td>" + objBiz.Code + "</td>";
        Returned += "<td>" + objBiz.Name + "</td>";
        Returned += "<td>" + objBiz.Department + "</td>";
        Returned += "<td>" + objBiz.Job + "</td>";
        Returned += "<td><input type=\"button\" value=\"-\" id=\"btnSelectedEmployee" + objBiz.ID + "\"  onclick=\"return onEmployeeClick('" + objBiz.ID + "')\" name=\"btnSelectedEmployee" + objBiz.ID + "\" /></td>";
        Returned += "</tr>";
        return Returned;
    };
    return ApplicantSingle;
}());
var EstimationStatementSingle = /** @class */ (function () {
    function EstimationStatementSingle() {
    }
    return EstimationStatementSingle;
}());
var ApplicantEstimationStatementSingle = /** @class */ (function () {
    function ApplicantEstimationStatementSingle() {
    }
    return ApplicantEstimationStatementSingle;
}());
var ApplicantEstimationStatementElementSingle = /** @class */ (function () {
    function ApplicantEstimationStatementElementSingle() {
    }
    ApplicantEstimationStatementElementSingle.prototype.SetEstimationTotals = function (intElementID, strNewValue) {
        var objElementCol;
        var objElement = new ApplicantEstimationStatementElementSingle();
        var strElementCol;
        strElementCol = document.getElementById("lblElementCol").getAttribute("value");
        objElementCol = JSON.parse(strElementCol);
        var dblTotal = 0;
        var dblTotalRef = 0;
        var dblValue = 0;
        var dblEstimationValue = 0;
        var strEstimationName = "txtEstimationValue" + intElementID.toString();
        var objEstimationControl = document.getElementById(strEstimationName);
        var dblElementWeight = 0;
        var strValue = strNewValue;
        try {
            dblValue = parseFloat(strValue);
        }
        catch (_a) { }
        var objFilterElementCol;
        objFilterElementCol = objElementCol.filter(function (x) { return x.ElementID == intElementID; });
        if (objFilterElementCol.length > 0) {
            objElement = objFilterElementCol[0];
            dblEstimationValue = objElement.ElementValue;
            if (dblValue > dblEstimationValue) {
                alert("الدرجة اكبر من المتوقع");
                objEstimationControl.innerText = dblEstimationValue.toString();
                dblValue = dblEstimationValue;
            }
            strValue = (dblValue * 100 / objElement.ElementValue).toFixed().toString();
            var objEstimationControl1 = document.getElementById("txtPerc" + intElementID.toString());
            objEstimationControl1.innerText = strValue;
            objFilterElementCol[0].EstimationValue = dblValue;
            objFilterElementCol = null;
            objFilterElementCol = objElementCol.filter(function (x) { return x.Group == objElement.Group; });
            dblValue = 0;
            strValue = "lblGroupValue" + objElement.Group.toString();
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++) {
                if (objFilterElementCol[intIndex].ElementWeight == 0) {
                    objFilterElementCol[intIndex].ElementWeight = 100 / objFilterElementCol.length;
                }
                dblValue += (objFilterElementCol[intIndex].EstimationValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight;
            }
            document.getElementById(strValue).innerText = Math.round(dblValue).toString();
        }
        if (objElement.ElementID > 0) {
            objEstimationControl = null;
            objFilterElementCol = objElementCol;
            objFilterElementCol = objFilterElementCol.filter(function (x) { return x.EstimationValue != -1; });
            dblTotal = 0;
            dblTotalRef = 0;
            var objValueElement;
            var dblTotalValue1 = 0;
            for (var intIndex = 0; intIndex < objFilterElementCol.length; intIndex++) {
                objEstimationControl = null;
                objEstimationControl = document.getElementById("chkStopElement" + objFilterElementCol[intIndex].ElementID.toString());
                if (objEstimationControl.getAttribute("checked") == "true")
                    continue;
                objValueElement = null;
                objValueElement = document.getElementById("txtEstimationValue" + objFilterElementCol[intIndex].ElementID.toString());
                var strValue_1 = objValueElement.value;
                dblValue = 0;
                try {
                    dblValue = parseFloat(strValue_1);
                    dblTotal += dblValue;
                    dblTotalRef += objFilterElementCol[intIndex].ElementValue;
                    dblTotalValue1 += (dblValue / objFilterElementCol[intIndex].ElementValue) * objFilterElementCol[intIndex].ElementWeight * (objFilterElementCol[intIndex].GroupPerc / 100);
                }
                catch (_b) { }
            }
            objEstimationControl = null;
            document.getElementById("lblTotalValue").innerText = Math.round(dblTotalValue1).toString();
            document.getElementById("lblTotalPerc").innerText = (dblTotal * 100 / dblTotalRef).toFixed().toString();
            strValue = dblEstimationValue > 0 ? (dblValue * 100 / dblEstimationValue).toString() : "";
        }
    };
    return ApplicantEstimationStatementElementSingle;
}());
function onEmployeeClick(intEmployee) {
    var vrEmployeeLbl = "lblEmployee" + intEmployee;
    var strEmployee = document.getElementById(vrEmployeeLbl).value;
    var vrTempElement = document.getElementById(vrEmployeeLbl);
    var strSelected = document.getElementById("lblSelectedEmployee").value;
    var lstEmployee = [];
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);
    }
    var objBiz = JSON.parse(strEmployee);
    if (lstEmployee.filter(function (x) { return x.ID == objBiz.ID; }).length == 0) {
        lstEmployee[lstEmployee.length] = objBiz;
    }
    strSelected = JSON.stringify(lstEmployee);
    document.getElementById("lblSelectedEmployee").setAttribute("value", strSelected);
    FillSelectedEmployee();
}
function onEmployeeCheck(intEmployee) {
    var vrEmployeeLbl = "lblEmployee" + intEmployee;
    var strEmployee = document.getElementById(vrEmployeeLbl).value;
    var vrTempElement = document.getElementById(vrEmployeeLbl);
    var vrCheckEmployee = document.getElementById("chkEmployee" + intEmployee).checked;
    var strSelected = document.getElementById("lblSelectedEmployee").value;
    var lstEmployee = [];
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);
    }
    var objBiz = JSON.parse(strEmployee);
    if (vrCheckEmployee) {
        if (lstEmployee.filter(function (x) { return x.ID == objBiz.ID; }).length == 0) {
            lstEmployee[lstEmployee.length] = objBiz;
        }
    }
    else {
        var lstNew = [];
        for (var vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++) {
            if (lstEmployee[vrIndex].ID != objBiz.ID) {
                lstNew[lstNew.length] = lstEmployee[vrIndex];
            }
        }
        lstEmployee = lstNew;
    }
    strSelected = JSON.stringify(lstEmployee);
    document.getElementById("lblSelectedEmployee").setAttribute("value", strSelected);
    FillSelectedEmployee();
}
function FillSelectedEmployee() {
    var strSelected = document.getElementById("lblSelectedEmployee").getAttribute("value");
    var lstEmployee;
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);
    }
    var vrIndex = 0;
    var vrSelectedEmployeeStr = "";
    var vrTable;
    vrTable = "<table>";
    var objBiz = new ApplicantSingle();
    for (vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++) {
        vrTable += objBiz.GetSelectedDatRow(lstEmployee[vrIndex]);
        if (vrSelectedEmployeeStr != "")
            vrSelectedEmployeeStr += "&";
        vrSelectedEmployeeStr += lstEmployee[vrIndex].Name;
    }
    vrTable += "</table>";
    document.getElementById("txtApplicantRecepient").value = vrSelectedEmployeeStr;
    document.getElementById("dvSelectedEmployee").innerHTML = vrTable;
}
function GetSelectedEmployeeTable() {
    var strSelected = document.getElementById("lblSelectedEmployee").getAttribute("value");
    var lstEmployee;
    if (strSelected != "") {
        lstEmployee = JSON.parse(strSelected);
    }
    var vrIndex = 0;
    var vrSelectedEmployeeStr = "";
    var vrTable;
    vrTable = "<table>";
    var objBiz = new ApplicantSingle();
    for (vrIndex = 0; vrIndex < lstEmployee.length; vrIndex++) {
        vrTable += objBiz.GetDatRow(lstEmployee[vrIndex]);
        if (vrSelectedEmployeeStr != "")
            vrSelectedEmployeeStr += "&";
        vrSelectedEmployeeStr += lstEmployee[vrIndex].Name;
    }
    vrTable += "</table>";
    return vrTable;
}
//# sourceMappingURL=Applicant.js.map