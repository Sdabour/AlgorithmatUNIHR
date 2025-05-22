function FillMSGApplicant()
{
 
    var vrServiceUrl = "../api/ApplicantWorkerAPI/GetApplicantSingleByName";
    var vrName = document.getElementById("txtEmployeeFilter").value;
    var vrName1 = document.getElementById("txtEmployeeFilter1").value;
    if (vrName1 != null && vrName1 != "")
        vrName = vrName1;
    var vrCheckSelected = document.getElementById("chkOnlySelected").checked;
    if (vrCheckSelected)
    {
        var vrEmployeeTable = GetSelectedEmployeeTable();
        document.getElementById("dvEmployee").innerHTML = vrEmployeeTable;
        DisplayEmployeeModal();
    }
    else {
        $.ajax({
            type: 'GET',
            url: vrServiceUrl,
            contentType: 'application/json; charset=utf-8',

            dataType: 'json',
            data: {
                strName: vrName
            },
            success: successFunc,
            error: errorFunc
        });
    }

    function successFunc(data, status) {


        var strTemp = "<table>";
        var vrApplicant = new ApplicantSingle();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {

             
            strTemp += vrApplicant.GetDatRow(data[vrIndex]);
        }
        strTemp += "</table>";
        //tblFreeVisitDisplay
        document.getElementById("dvEmployee").innerHTML = strTemp;
        if (data.length > 0)
        {
            DisplayEmployeeModal();
        }
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }
}

function FillMSGSector1() {

    FillMSGSector();
    DisplaySectorModal();
}
function AddNewGroup()
{

    var vrGroupStr = document.getElementById("txtNewGroupName").value;
    if (vrGroupStr == null || vrNewGroupStr == "")
    {
        alert("فضلا حدد اسم المجموعة");
        return;
    }
    var vrSelectedApp = document.getElementById("lblSelectedEmployee").value;
    if (vrSelectedApp == null || vrSelectedApp == "") {
        alert("فضلا حدد الموظفين");
        return;
    }

    var vrNewGroup;
    var vrAppID = document.getElementById("lblAppID").getAttribute("value");

    if (vrAppID == null || vrAppID == "")
        return;

    var vrToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJjMGM1NTU1NS00ZTFkLTRhZGEtYmQ2Zi05YWM5NzAyMWJlNzEiLCJVc2VyTmFtZSI6InNhIiwiZXhwIjoxNjgyODU4MDAxLCJpc3MiOiJKV1RBdXRoZW50aWNhdGlvblNlcnZlciIsImF1ZCI6IkpXVFNlcnZpY2VQb3N0bWFuQ2xpZW50In0.ODt0nwYgcb6Rv_2tmv3bMwCRPUxpjXWWATE1yG_bjjw";

    vrToken = "Bearer " + vrToken;
    vrAppID = vrAppID.split("|")[0];
    vrNewGroup = GetGroup();

    var vrNewGroupStr = JSON.stringify(vrNewGroup);

    var vrServiceUrl = "../api/MSGGroupAPI/SaveNewGroup";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            "Authorization": vrToken
        },
        data: vrNewGroupStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {

    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    ClearNewGroup();
    CloseNewGroupModal();
}

function FillMSGGroup() {

    var vrServiceUrl = "../api/MSGGroupAPI/GetApplicantGroup";
    var vrAppID = document.getElementById("lblAppID").getAttribute("value");

    if (vrAppID == null || vrAppID == "")
        return;

    vrAppID = vrAppID.split("|")[0];

   
      
        $.ajax({
            type: 'GET',
            url: vrServiceUrl,
            contentType: 'application/json; charset=utf-8',

            dataType: 'json',
            data: {
                intApplicant: vrAppID
            },
            success: successFunc,
            error: errorFunc
        });
    

    function successFunc(data, status) {


        var strTemp = "<table>";
        var vrApplicant = new Group();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {


            strTemp += vrApplicant.GetDatRow(data[vrIndex]);
        }
        strTemp += "</table>";
        //tblFreeVisitDisplay
        document.getElementById("dvGroupExplore").innerHTML = strTemp;
        if (data.length > 0) {
           // DisplayGroupExploreModal();
        }
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }
}