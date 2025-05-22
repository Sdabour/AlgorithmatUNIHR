//SetPaymentCheckLabel
//SowPaymentCheckModal
//GetInstallmentCahchePayment
//GetPaymentTypeCmbStr
//CloseCheckModal
//ShowCheckModal
//ClosePaymentModal
//ShowPaymentModal
//ShowInstallmentPaymentModal
var PaymentSimple = /** @class */ (function () {
    function PaymentSimple() {
    }
    return PaymentSimple;
}());
function ShowInstallmentPaymentModal(intInstallment) {
    if (document.getElementById("lblCurrentInstallment") != null) {
        document.getElementById("lblCurrentInstallment").value = intInstallment.toString();
    }
    var vrInstallmentLable = document.getElementById("lblInstallment" + intInstallment).getAttribute("value");
    var objInstallment = JSON.parse(vrInstallmentLable);
    var vrDiv = "";
    vrDiv = "<div class=\"form-row\">";
    vrDiv += "<input type=\"hidden\" id=\"lblInstallment\" value=\"" + intInstallment + "\">";
    vrDiv += "<div class=\"col-2\">" + objInstallment.TypeName + "</div>";
    vrDiv += "<div class=\"col-1\">تاريخ استحقاق</div><div class=\"col-2\">" + "Date" + "</div>";
    vrDiv += "<div class=\"col-1\">قيمة</div><div class=\"col-2\">" + objInstallment.Value + "</div>";
    vrDiv += "<div class=\"col-1\">متبقى</div><div class=\"col-2\">" + objInstallment.Value + "</div>";
    vrDiv += "</div></br>";
    vrDiv += "<div class=\"form-row\"></div>";
    //vrDiv += "</div>";
    var vrPaymentLst = []; //objInstallment.PaymentLst;
    vrDiv += GetPaymentDiv(vrPaymentLst, 0, "AddInstallmentPayment");
    document.getElementById("dvPayment").innerHTML = vrDiv;
    ShowPaymentModal();
}
function ShowPaymentSimple(vrType) {
    if (document.getElementById("lblStudentValue") == null)
        return;
    var vrStudent = JSON.parse(document.getElementById("lblStudentValue").value);
    /*  var vrFunctionAddStr: string = "Add"+vrType+"Payment";*/
    var vrFunctionAddStr = "AddPayment('" + vrType + "')";
    //var vrDiv: string = GetPaymentDiv(vrStudent.PaymentLst, 0, vrFunctionAddStr);
    //(<HTMLInputElement>document.getElementById("dvPayment")).innerHTML = vrDiv;
}
function GetPaymentDiv(vrPaymentLst, vrInitialValue, vrAddPaymentFunctionStr) {
    var vrDiv = "";
    //////////
    {
        if (vrAddPaymentFunctionStr.indexOf("(") == -1) {
            vrAddPaymentFunctionStr = vrAddPaymentFunctionStr + "()";
        }
        vrDiv += "<div class=\"form-row\">";
        vrDiv += "<div class=\"col-1\">القيمة</div><div class=\"col-2\">" +
            "<input type=\"number\"  class=\"form-control\"  id = \"txtPaymentValue\" name = \"txtPaymentValue\"   placeholder = \"Not Assigned\" value = \"" + vrInitialValue + "\">" +
            "</div>";
        vrDiv += "<div class=\"col-1\">نوع السداد</div><div class=\"col-2\">" + GetPaymentTypeCmbStr("cmbPaymentType") + "</div>";
        var vrChangePaymentDateAuthorized = GetChangePaymentDateAuthorized();
        if (vrChangePaymentDateAuthorized) {
            vrDiv += "<div class=\"col-2\">";
            vrDiv += "<input type=\"date\"  class=\"form-control\"  name=\"dtPayment\" id=\"dtPayment\"/>";
            vrDiv += "</div>";
        }
        if (document.getElementById("lblCostTypeLst") != null) {
            vrDiv += "<div class=\"col-2\">";
            vrDiv += GetAdministrativeCostTypeCmbStr("cmbCostType");
            vrDiv += "</div>";
        }
        if (document.getElementById("lblPaymentType") != null && document.getElementById("lblPaymentType").value == "Temp") {
            vrDiv += "<div class=\"col-2\">" +
                "<input type=\"text\"  class=\"form-control\"  id = \"txtTempPaymentDesc\" name = \"txtTempPaymentDesc\"   placeholder = \"وصف\" value = \"\">" +
                "</div>";
        }
        vrDiv += "<div class=\"col-2\"><input type=\"button\" name=\"btnAddPayment\" id=\"btnAddPayment\" value=\"سداد\" onclick=\"return " + vrAddPaymentFunctionStr + ";\"></div>";
        vrDiv += "</div></br>";
        //lblInstallmentCheckID,lblInstallmentCheckCode,lblInstallmentCheckDate,lblInstallmentCheckBank,lblInstallmentCheckValue
        vrDiv += "<div class=\"form-row\">";
        vrDiv += "<div class=\"col-2\"  id=\"lblPaymentCheckID\" name=\"lblPaymentCheckID\"></div>";
        vrDiv += "<div class=\"col-2\" id=\"lblPaymentCheckCode\" name=\"lblPaymentCheckCode\"></div>";
        vrDiv += "<div class=\"col-2\"  id=\"lblPaymentCheckDate\" name=\"lblPaymentCheckDate\"></div>";
        vrDiv += "<div class=\"col-2\" id=\"lblPaymentCheckBank\" name=\"lblPaymentCheckBank\"></div>";
        vrDiv += "<div class=\"col-2\"  id=\"lblPaymentCheckValue\" name=\"lblPaymentCheckValue\"></div>";
        vrDiv += "</div></br>";
    }
    /////////
    vrDiv += "<div class=\"table-responsive\" id=\"dvStudent\">";
    vrDiv += "<table class=\"table\">";
    var objPayment;
    for (var vrIndex = 0; vrIndex < vrPaymentLst.length; vrIndex++) {
        objPayment = vrPaymentLst[vrIndex];
        //   vrDiv += "<div class\"form-row\">";
        // vrDiv += "<div class=\"col-2\">" + objInstallment.PaymentLst[vrIndex].Value + "</div>";
        //vrDiv += "</div>";
        vrDiv += "<tr>";
        vrDiv += "<td><input type=\"hidden\" id=\"lblPayment" + objPayment.ID.toString() + "\" value='" + JSON.stringify(objPayment) + "' />" + objPayment.DateStr + "</td>";
        vrDiv += "<td>" + objPayment.Value + "</td>";
        vrDiv += "<td>" + objPayment.TypeDesc + "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0 && objPayment.IsCollected) {
            vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";
        }
        else {
            vrDiv += "<input type=\"button\" name=\"btnDeletePayment" + objPayment.ID + "\" id=\"btnDeletePayment" + objPayment.ID + "\" value=\"حذف\" onclick=\"DeletePayment(" + objPayment.ID + ")\"/>";
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0 && !objPayment.IsCollected) {
            vrDiv += "<input type=\"text\" name=\"txtCollectPayment" + objPayment.ID + "\" id=\"txtCollectPayment" + objPayment.ID + "\" value=\"" + objPayment.Value.toFixed(0) + "\" />";
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0 && !objPayment.IsCollected && vrChangePaymentDateAuthorized) {
            vrDiv += "<input type=\"date\" name=\"dtCollectPayment" + objPayment.ID + "\" id=\"dtCollectPayment" + objPayment.ID + "\"/>";
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0) {
            if (!objPayment.IsCollected) {
                vrDiv += "<input type=\"button\" name=\"btnCollectPayment" + objPayment.ID + "\" id=\"btnCollectPayment" + objPayment.ID + "\" value=\"تحصيل\" onclick=\"CollectPayment(" + objPayment.ID + ")\"/>";
            }
            else {
                /*       vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";*/
            }
        }
        vrDiv += "</td>";
        vrDiv += "<td>";
        if (objPayment.CheckID > 0) {
            if (!objPayment.IsCollected) {
                vrDiv += "<input type=\"button\" name=\"btnDiscountPayment" + objPayment.ID + "\" id=\"btnDiscountPayment" + objPayment.ID + "\" value=\"خصم\" onclick=\"DiscountCollectedPayment(" + objPayment.ID + ")\"/>";
            }
            else {
                /*       vrDiv += "<input type=\"button\" name=\"btnDisCollectPayment" + objPayment.ID + "\" id=\"btnDisCollectPayment" + objPayment.ID + "\" value=\"الغاء تحصيل\" onclick=\"DisCollectPayment(" + objPayment.ID + ")\"/>";*/
            }
        }
        vrDiv += "</td>";
        vrDiv += "</tr>";
    }
    vrDiv += "</table>";
    vrDiv += "</div>";
    return vrDiv;
}
function ShowPaymentModal() {
    var vrModal = document.getElementById("myPaymentModal");
    vrModal.style.display = "block";
    return false;
}
function ClosePaymentModal() {
    var vrModal = document.getElementById("myPaymentModal");
    vrModal.style.display = "none";
    return false;
}
function ShowCheckModal() {
    var vrModal = document.getElementById("myCheckModal");
    vrModal.style.display = "block";
    return false;
}
function CloseCheckModal() {
    var vrModal = document.getElementById("myCheckModal");
    vrModal.style.display = "none";
    return false;
}
function GetPaymentTypeCmbStr(strID) {
    var Returned = "";
    Returned += "<select class=\"form-control\" id=\"" + strID + "\" name=\"" + strID + "\" onchange=\"return SowPaymentCheckModal();\">" +
        "<option value = \"0\" > كاش </option>" +
        "<option value = \"1\" > شيك </option>" +
        "<option value = \"2\" > تحويل بنكى </option>" +
        "<option value = \"3\" > فيزا </option></select>";
    return Returned;
}
function GetAdministrativeCostTypeCmbStr(strID) {
    var Returned = "";
    if (document.getElementById("lblCostTypeLst") == null) {
        return "";
    }
    var lstType = [];
    var vrTemp = document.getElementById("lblCostTypeLst").value;
    lstType = JSON.parse(vrTemp);
    Returned += GetSerializableCmbStr(lstType, strID);
    return Returned;
}
function GetInstallmentCachePayment(intInstallment) {
    var vrUser = GetCurrentUser();
    var strInstallment = document.getElementById("lblInstallment" + intInstallment).value;
    var vrChangePaymentAuthorized = GetChangePaymentDateAuthorized();
    /* let objInstallment: InstallmentSimple = JSON.parse(strInstallment);*/
    var vrValue = Number(document.getElementById("txtInstallmentValue" + "ID").value);
    var Returned = new PaymentSimple();
    // Returned.Installment = objInstallment;
    // Returned.InstallmentID = objInstallment.ID;
    Returned.Value = vrValue;
    Returned.Type = 0;
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.Date = new Date();
    if (vrChangePaymentAuthorized) {
        /*var vrStrDate: string = (<HTMLInputElement>document.getElementById("dtPayment" + objInstallment.ID.toString())).value;*/
        //var vrPaymentDate: Date = new Date(vrStrDate == "" ? new Date() : new Date(vrStrDate));
        //Returned.Date = vrPaymentDate;
    }
    return Returned;
}
function GetInstallmentPayment() {
    var strInstallment = document.getElementById("lblInstallment").value;
    strInstallment = document.getElementById("lblInstallment" + strInstallment).value;
    /* let objInstallment: InstallmentSimple = JSON.parse(strInstallment);*/
    var Returned = new PaymentSimple();
    Returned = GetPaymentSimple();
    //Returned.InstallmentID = objInstallment.ID;
    return Returned;
}
function GetPaymentSimple() {
    var vrStudent = new Student();
    if (document.getElementById("lblStudentValue") != null &&
        document.getElementById("lblStudentValue").value != "") {
        vrStudent = JSON.parse(document.getElementById("lblStudentValue").value);
    }
    var vrChangePaymentAuthorized = GetChangePaymentDateAuthorized();
    var vrValue = Number(document.getElementById("txtPaymentValue").value);
    var vrDesc = "";
    if (document.getElementById("txtTempPaymentDesc") != null) {
        vrDesc = document.getElementById("txtTempPaymentDesc").value;
    }
    var vrUser = GetCurrentUser();
    var Returned = new PaymentSimple();
    Returned.StudentID = vrStudent.ID;
    Returned.Value = vrValue;
    Returned.Desc = vrDesc;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.Date = new Date();
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;
    if (vrChangePaymentAuthorized && document.getElementById("dtPayment") != null) {
        var vrPaymentDate = new Date(document.getElementById("dtPayment").value);
        Returned.Date = vrPaymentDate;
    }
    Returned.CheckID = 0;
    Returned.Type = Number(document.getElementById("cmbPaymentType").value);
    if (Returned.Type == 1) {
        var vrCheck = new CheckSimple();
        var vrCheckStr = document.getElementById("lblCurrentCheck").value;
        if (vrCheckStr != null && vrCheckStr != "")
            vrCheck = JSON.parse(vrCheckStr);
        var vrTempValue = vrCheck.Value - vrCheck.TotalPayment;
        if (Returned.Value > (vrCheck.Value - vrCheck.TotalPayment)) {
            Returned.Value = vrCheck.Value - vrCheck.TotalPayment;
            if (Returned.Value < 0) {
                Returned.Value = 0;
            }
        }
        Returned.CheckID = vrCheck.ID;
    }
    return Returned;
}
function GetPaymentForCollection(intPaymentID) {
    var vrChangePaymentAuthorized = GetChangePaymentDateAuthorized();
    var vrPaymentStr = document.getElementById("lblPayment" + intPaymentID.toString()).value;
    var vrValue = Number(document.getElementById("txtCollectPayment" + intPaymentID.toString()).value);
    var vrUser = GetCurrentUser();
    var Returned = JSON.parse(vrPaymentStr);
    // Returned.InstallmentID = objInstallment.ID;
    Returned.CollectedValue = vrValue;
    Returned.Branch = vrUser.Branch;
    Returned.User = vrUser.ID;
    Returned.EMployee = vrUser.EmpID;
    Returned.CollectingDate = new Date();
    Returned.ChangePaymentDateAuthorized = vrChangePaymentAuthorized;
    if (vrChangePaymentAuthorized) {
        var vrPaymentDate = new Date(document.getElementById("dtCollectPayment" + intPaymentID.toString()).value);
        Returned.CollectingDate = vrPaymentDate;
    }
    //Returned.Type = Number
    //    ((<HTMLInputElement>document.getElementById("cmbPaymentType")).value);
    return Returned;
}
function SetPaymentCheckLabel(intIndex) {
    var vrAllCheck = [];
    var vrAllCheckStr = document.getElementById("lblAllCheck").value;
    if (vrAllCheckStr != null && vrAllCheckStr != "") {
        vrAllCheck = JSON.parse(vrAllCheckStr);
    }
    if (vrAllCheck.length > intIndex) {
        var vrSimple = new CheckSimple();
        if (intIndex > -1)
            vrSimple = vrAllCheck[intIndex];
        document.getElementById("lblCurrentCheck").value = JSON.stringify(vrSimple);
        document.getElementById("lblPaymentCheckID").innerText = vrSimple.ID.toString();
        document.getElementById("lblPaymentCheckCode").innerText = vrSimple.Code;
        document.getElementById("lblPaymentCheckDate").innerText = vrSimple.ID == 0 ? "" : vrSimple.DueDate.toString().substring(0, 10);
        document.getElementById("lblPaymentCheckBank").innerText = vrSimple.BankName;
        document.getElementById("lblPaymentCheckValue").innerText = vrSimple.Value.toString();
    }
    CloseCheckModal();
}
function SowPaymentCheckModal() {
    var vrCheckStr = document.getElementById("lblAllCheck").value;
    var vrChkAll = [];
    if (vrCheckStr != null && vrCheckStr != "") {
        vrChkAll = JSON.parse(vrCheckStr);
        if (document.getElementById("cmbPaymentType").value == "1")
            ShowCheckModal();
        else
            CloseCheckModal();
    }
}
function GetChangePaymentDateAuthorized() {
    var blChangeDateAuthorized = true;
    if (document.getElementById("lblChangeDateAuthorized") != null) {
        blChangeDateAuthorized = document.getElementById("lblChangeDateAuthorized").value == "1";
    }
    return blChangeDateAuthorized;
}
//# sourceMappingURL=PaymentSimple.js.map