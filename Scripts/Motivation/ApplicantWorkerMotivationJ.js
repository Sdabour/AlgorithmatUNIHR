const { json } = require("d3");

function UploadMotivationValue(vrReviewd,vrCostCenter) {
    var vrMotivationValue = GetApplicantMotivationValueList(vrCostCenter);
    var vrCostFactor = { Reviewed: vrReviewd, lstValue:vrMotivationValue};

    var vrServiceUrl = "../api/ApplicantWorkerMotivationAPI/UploadMotivationLst";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrCostFactor),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //FillRegisterationExamLst(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;


}

function FillMotivationStatemenet() {
   
    var vrServiceUrl = "../api/ApplicantWorkerMotivationAPI/GetMotivationStatemet";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillMotivationStatementTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function FillCostCenter() {
    var vrLstCostCenter = [];
    if (document.getElementById("lblAllCostCenter") != null) {
        try {
            vrLstCostCenter = JSON.parse(document.getElementById("lblAllCostCenter").value);

            return;
        }
        catch {}
    }
    var vrServiceUrl = "../api/ApplicantWorkerMotivationAPI/GetCostCenter";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: {},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

        FillMotivationStatementTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function FillApplicantMotivationStatemenet() {

    var vrServiceUrl = "../api/ApplicantWorkerMotivationAPI/GetApplicantWorkerMotivation";
    var vrCostCenterIDs = [];
    if (document.getElementById("lblSelectedCostCenter") != null && document.getElementById("lblSelectedCostCenter").value != "") {
        vrCostCenterIDs = JSON.parse(document.getElementById("lblSelectedCostCenter").value).map(x=>x.ID);
    }

    var vrStatement = JSON.parse(document.getElementById("lblCurrentMotivationStatement").value);
    
    var vrSearch = {Statement: vrStatement.ID, lstCostIDs:vrCostCenterIDs};
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrSearch),
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        if (document.getElementById("lblAllApplicantMotivation") != null) {
            document.getElementById("lblAllApplicantMotivation").value = JSON.stringify(data);
        }
        FillApplicantWorkerMotivationTable();
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
