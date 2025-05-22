
function FillUserList() {


    var vrServiceUrl = "../api/UserAPI/GetUserList";
    var vrGroup = 0;
    var vrUserName = "";
    if (document.getElementById("txtUserName") != null) {
        vrUserName = document.getElementById("txtUserName").value;
    }

    var vrUserFullName = "";
    var vrEmpID = 0;

    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intGroupID: vrGroup, strUserName: vrUserName, strFullName: vrUserFullName, intEmpID: vrEmpID }
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        FillUserTable(data);



    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;


}
function SetUserFunctionInstant(vrUser) {
    var vrServiceUrl = "../api/UserAPI/GetUserFunctionInstant";


    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intUserID: vrUser }
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        if (document.getElementById("lblAllFunctionInstant") != null) {
            document.getElementById("lblAllFunctionInstant").value = JSON.stringify(data);
            FillFunctionInstantTable();
        }

        // InitializeEmployeeModal();
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;
}

function AddEditUser() {
    if (!CHeckUserAddEditValidation()) {
        return;
    }
    var vrUser = GetUserData();
    var vrServiceUrl = "../api/UserAPI/AddEditUser";

    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: JSON.stringify(vrUser)
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {

        alert("OK");


    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;
}
function FillAissignmentObjectList() {


    var vrServiceUrl = "../api/AssignmentObjectAPI/GetAssignmentObjectLst";

    var vrName = "";



    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { strName: vrName }
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        document.getElementById("lblAllAssignmentObject").value = JSON.stringify(data);
        FillAssignmentObjectTable();



    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;


}

function FillAissignmentObjectValueList() {


    var vrServiceUrl = "../api/AssignmentObjectAPI/GetAssignmentObjectValueLst";
    if (document.getElementById("lblSelectedAssignmentObject") == null || document.getElementById("lblSelectedAssignmentObject").value == "") {
        return;
    }
    var vrSerial = JSON.parse(document.getElementById("lblSelectedAssignmentObject").value);

    var vrCode = vrSerial.Code;



    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { strCode: vrCode }
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        document.getElementById("lblAllAssignmentObjectValue").value = JSON.stringify(data);
        GetAissignmentObjectSelectedValueList();
        GetSerializableSimpleTable("AssignmentObjectValue");



    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;


}

function GetAissignmentObjectSelectedValueList() {


    var vrServiceUrl = "../api/AssignmentObjectAPI/GetUserAssignmentObjectValueLst";
    if (document.getElementById("lblSelectedAssignmentObject") == null || document.getElementById("lblSelectedAssignmentObject").value == "") {
        return [];
    }
    var vrUser = 0;
    if (document.getElementById("ID") == null) {
        document.getElementById("lblSelectdAssignmentObjectValue").value = "";
        return;
    }
    else {
        
        if (document.getElementById("ID").value != "") {
            var vrUserStr = document.getElementById("ID").value;
            vrUser = vrUserStr;
        }
    }
    if (vrUser == 0) {
        document.getElementById("lblSelectedAssignmentObjectValue").value = "";
        return;
    }
    var vrSerial = JSON.parse(document.getElementById("lblSelectedAssignmentObject").value);

    var vrCode = vrSerial.Code;



    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intUser: vrUser, strCode: vrCode }
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        document.getElementById("lblSelectedAssignmentObjectValue").value = JSON.stringify(data);
        //GetSerializableSimpleTable("AssignmentObjectValue");



    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;


}

function SaveUserAssignment() {
    var vrServiceUrl = "../api/AssignmentObjectAPI/AssignObjectUserValue";
    if (document.getElementById("lblSelectedAssignmentObject") == null || document.getElementById("lblSelectedAssignmentObject").value == "") {
        return;
    }
    var vrUser = 0;
    if (document.getElementById("ID") == null) {
        document.getElementById("lblSelectdAssignmentObjectValue").value = "";
        return;
    }
    else {
        if (document.getElementById("ID").value != "") {
            vrUser = Number(document.getElementById("ID").value);
        }
    }
    if (vrUser == 0) {
        alert("حدد المستخدم");
        document.getElementById("lblSelectedAssignmentObjectValue").value = "";
        return;
    }
    var vrSerial = JSON.parse(document.getElementById("lblSelectedAssignmentObject").value);

    var vrCode = vrSerial.Code;
    if (vrCode == null || vrCode == "") {
        alert("حدد الAssignment Object");

        return;
    }
    var vrLstAssignment = [];
    if (document.getElementById("lblSelectedAssignmentObjectValue") != null && document.getElementById("lblSelectedAssignmentObjectValue").value != "") {
        vrLstAssignment = JSON.parse(document.getElementById("lblSelectedAssignmentObjectValue").value);

    }
    if (vrLstAssignment.length == 0) {
        alert("لا يوجد Assignment");
        return;
    }
    var objAssign = { intUser: vrUser, strCode: vrCode, lstAssignment: vrLstAssignment };

    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        async: false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: JSON.stringify(objAssign)
        ,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        /*        document.getElementById("lblSelectedAssignmentObjectValue").value = JSON.stringify(data);*/
        //GetSerializableSimpleTable("AssignmentObjectValue");

        alert("OK");

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
        //setTimeout(FillServiceGroup, 10000);
    }


    return false;
}