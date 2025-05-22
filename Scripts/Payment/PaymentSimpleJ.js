function AddCacheInstallmentPayment(intInstallmentID) {

    var vrPayment = GetInstallmentCachePayment(intInstallmentID);
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Value > vrPayment.Installment.Remaining) {
        return;
    }
    if (!confirm("هل تود سداد مبلغ " + vrPayment.Value))
        return;
    UploadInstallmentPayment(vrPayment);
    FillStudentSimpleInstallment();
}
function AddInstallmentPayment() {

    var vrPayment = GetInstallmentPayment();
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Type == 1 && vrPayment.CheckID == 0) {
        alert("فضلا حدد الشيك");
        return;
    }
    if (!confirm("هل تود سداد مبلغ " + vrPayment.Value))
        return;

    UploadInstallmentPayment(vrPayment);
    FillStudentSimpleInstallment();
}
function UploadInstallmentPayment(vrPayment) {

    var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/AddInstallmentPayment";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
}

function AddPayment(vrType) {

    var vrPayment = GetPaymentSimple();
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Type == 1 && vrPayment.CheckID == 0) {
        alert("فضلا حدد الشيك");
        return;
    }
    if (!confirm("هل تود سداد مبلغ " + vrPayment.Value))
        return;

    UploadPaymentSimple(vrPayment, vrType);
    FillStudentSimpleInstallment();
}
function UploadPaymentSimple(vrPayment, vrType) {

    var vrPaymentStr = JSON.stringify(vrPayment);

    var vrServiceUrl = "../api/PaymentAPI/Add" + vrType + "Payment";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        // alert("Success");
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {
        //alert("xx");
    }
}
function FillPaymentLst(vrType) {
    if (document.getElementById("lblStudentValue") == null || document.getElementById("lblStudentValue").value == "")
        return;
    var vrStudent = JSON.parse(document.getElementById("lblStudentValue").value);

    var vrServiceUrl = "../api/PaymentAPI/Get" + vrType + "Payment";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intRreservationID: vrStudent.ID }
        ,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var vrPayment = new PaymentSimple();
        vrStudent.PaymentSimple = [];

        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            vrPayment = data[vrIndex];
            vrStudent.PaymentLst[vrIndex] = vrMulct;
        }
        document.getElementById("lblStudentValue").value = JSON.stringify(vrStudent);
        ShowPaymentSimple(vrType);
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
}

//////////Common function

function DeletePayment(vrPaymentID) {

    //var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/DeletePayment";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intPaymentID: vrPaymentID, intDelete: 0 },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    ClosePaymentModal();

}
function CollectPayment(vrPaymentID) {

    var vrPayment = new PaymentSimple();
    vrPayment = GetPaymentForCollection(vrPaymentID);
    var vrPaymentStr = JSON.stringify(vrPayment);
    var vrServiceUrl = "../api/PaymentAPI/CollectPayment";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    ClosePaymentModal();

}

function AddInstallmentDiscountUpload(vrDiscount) {

    var vrDiscountStr = JSON.stringify(vrDiscount);
    var vrServiceUrl = "../api/PaymentAPI/AddDiscount";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrDiscountStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
}

function AddInstallmentDiscount(intInstallmentID) {

    var vrPayment = GetInstallmentDiscount(intInstallmentID);
    if (vrPayment.Value == 0) {
        alert("حدد القيمة");
        return;
    }
    if (vrPayment.Desc == "") {
        alert("حدد وصف");
        return;
    }
    if (!confirm("هل تود خصم مبلغ " + vrPayment.Value))
        return;

    AddInstallmentDiscountUpload(vrPayment);
    FillStudentSimpleInstallment();

}

function DeleteDiscount(vrDiscountID, vrInstallmentID) {

    //var vrDiscountStr = JSON.stringify(vrDiscount);
    var vrServiceUrl = "../api/PaymentAPI/DeleteDiscount";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intDiscountID: vrDiscountID, intInstallmentID: vrInstallmentID },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillStudentSimpleInstallment();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    CloseDiscountModal();

}
function OnPrintClick() {
    var vrPayment = GetPaymentSimple();
    var vrPaymentStr = JSON.stringify(vrPayment);
    var vrRTF = document.getElementById("txtReceipt_rte-edit-view");
    var vrText = vrRTF.innerText;
    //vrRTF = vrRTF.value;
    vrText = vrRTF.ej2_instances[0];
    vrText = vrRTF.innerHTML;
    vrText = vrRTF.value;
    var vrServiceUrl = "../api/ReceiptAPI/GetReceiptModel";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrPaymentStr
        ,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        document.getElementById("txtReceipt_rte-edit-view").RTF = data;
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }

}
function OnReceiptPrintClick1() {
    if (document.getElementById("lblStudentValue") == null) {
        return;
    }
    var vrStudent = JSON.parse(document.getElementById("lblStudentValue").value);
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../StudentPayment/Download_ReceiptPDF" + "?StudentID=" + vrStudent.ID;
    //{
    //    vrUrl = vrUrl.replace("UploadFile", "AttachmentIndex");
    //}
    window.location.replace(vrUrl);
    //document.body.ad
    return;
}
function OnReceiptPrintClick() {
    var vrHtml = GetReceiptHTML();
    printDiv("", vrHtml);
}
function GetReceiptHTML() {
    if (document.getElementById("lblStudentValue") == null) {
        return "";
    }
    var vrStudent = JSON.parse(document.getElementById("lblStudentValue").value);
    var vrServiceUrl = "../api/PaymentAPI/GetPaymentReceiptStr";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intStudentID: vrStudent.ID }
        ,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        printDiv("", data);
        return data;

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return "";
}
function printDiv(strHeader, strBody) {
    var vrCSS = "<link href=\"~/wwwroot/css/bootstrap.min.css\" rel=\"stylesheet\" type = \"text/css\">";
    vrCSS += "<link href=\"~/wwwroot/css/bootstrap_limitless.min.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href= \"~/css/layout.min.css\" rel = \"stylesheet\" type = \"text/css\" >" +
        "<link href=\"~/wwwroot/css/components.min.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"~/css/colors.min.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"~/wwwroot/css/custom.css\" rel=\"stylesheet\" type=\"text/css\">";


    vrCSS = " <link href=\"/wwwroot/css/bootstrap.min.ar.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"/wwwroot/css/bootstrap_limitless.min.ar.css\" rel =\"stylesheet\" type =\"text/css\" >" +
        "<link href=\"/wwwroot/css/layout.min.ar.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"/wwwroot/css/components.min.ar.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"/css/colors.min.ar.css\" rel=\"stylesheet\" type=\"text/css\">" +
        "<link href=\"/wwwroot/css/custom.ar.css\" rel=\"stylesheet\" type=\"text/css\">";
    var divDvHeader = strHeader;

    var divContents = strBody;


    var a = window.open('', '', 'height=500, width=500');
    a.document.write(vrCSS);
    a.document.write('<html>');
    a.document.write('<html>');


    a.document.write('<body dir=\"rtl\">');
    a.document.write(divDvHeader);
    a.document.write(divContents);
    a.document.write('</body></html>');


}