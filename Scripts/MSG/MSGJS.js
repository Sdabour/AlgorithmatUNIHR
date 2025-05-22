

function OnMSG() {
    if (document.getElementById("lblMainMSG").value != null && document.getElementById("lblMainMSG").value != "" && document.getElementById("lblMainMSG").value !="0") {
        var vrMSGID = document.getElementById("lblMainMSG").value;
        SeeMSG(vrMSGID);
        return;
    }
    var vrAppID = document.getElementById("lblAppID").getAttribute("value");

    if (vrAppID == null || vrAppID == "")
        return;
    vrAppID = vrAppID.split("|")[0];

     
    //if (document.getElementById("lblTrackAuthorized").value == "0")
    //    return;
    


    var vrServiceUrl =  "../api/MSGAPI/GetApplicantInboxMSG";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
       
        data: {intApplicant:vrAppID},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var strMSG = "";
      
        var vrNotSeen = data.filter(function (vrObj) { return vrObj.Seen == false ; });

        var vrMsgCount = vrNotSeen.length == 0 ? "" : vrNotSeen.length;
        document.getElementById("lblMessageCount").innerText = vrMsgCount;
        document.getElementById("ulMSG").innerHTML = "";
        var objMSG = new MSG();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            strMSG += GetMSGURL(data[vrIndex]);
        }
        document.getElementById("ulMSG").innerHTML = strMSG;
       
       // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {
        document.getElementById("lblMessageCount").innerText = "";
        //setTimeout(OnHandShake, 30000);
    }


}

function SendMSG() {

    var vrMSG = GetMsg();

    
    var vrAppID = document.getElementById("lblAppID").getAttribute("value");

    if (vrAppID == null || vrAppID == "")
        return;
    vrAppID = vrAppID.split("|")[0];
    vrMSG.Sender = vrAppID;
    var vrMSGStr = JSON.stringify(vrMSG);
    var vrServiceUrl = "../api/MSGAPI/SaveMSG";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: vrMSGStr,
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        document.getElementById("lblMainMSG").value = data;
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {
      
    }
    ClearMsg();
    //CloseMSGModal();
}
function SeeMSG(vrMSGID)
{
    if (vrMSGID == 0)
        return;
    var vrAppID = document.getElementById("lblAppID").getAttribute("value");

    if (vrAppID == null || vrAppID == "")
        return;
    vrAppID = vrAppID.split("|")[0];
   
    var vrParm = { intApp: vrAppID, intMSG: vrMSGID };
    var vrParmStr = JSON.stringify(vrParm);

    
    var vrServiceUrl = "../api/MSGAPI/SeeMSG";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { intApp: vrAppID, intMSG: vrMSGID },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status)
    {
        
        var vrMSGCount = document.getElementById("lblMainMSGCount").value;
        if (vrMSGCount == null || vrMSGCount == "" || vrMSGCount != data.length) {
            var vrStrMSG = GetMSGTableRows(data);//
            vrMSGCount = data.length;
            document.getElementById("tblMSGThread").innerHTML = vrStrMSG;
            document.getElementById("lblMainMSG").value = vrMSGID;
            document.getElementById("lblMainMSGCount").value = vrMSGCount;
        }
        DisplayMsgModal();
    }
    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    //ClearMsg();
    //CloseMSGModal();
}


/////
function InitializeMSGModal() {
    var ModalMSG = document.getElementById("myMSGModal");



    // Get the <span> element that closes the modal
    var spanMSG = document.getElementById("MSGClose");

    // When the user clicks on the button, open the modal


    // When the user clicks on <span> (x), close the modal
    spanMSG.onclick = function () {
        ModalMSG.style.display = "none";


    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        //if (event.target == modal) {
        //    modal.style.display = "none";
        //}

    }
}
function DisplayMsgModal() {

    var ModalMSG = document.getElementById("myMSGModal");
    if (ModalMSG == null) {
        InitializeMSGModal();
        ModalMSG = document.getElementById("myMSGModal");
    }
    ModalMSG.style.display = "block";
    return false;
}
function CloseMSGModal() {
    var ModalMSG = document.getElementById("myMSGModal");
    ModalMSG.style.display = "none";
    document.getElementById("lblMainMSG").value = "";
    document.getElementById("lblMainMSGCount").value = "";

}
function DisplayEmployeeModal() {
    var ModalEmployee = document.getElementById("myEmployeeModal");
    ModalEmployee.style.display = "block";
    return false;
}
function CloseEmployeeModal() {
    var ModalEmployee = document.getElementById("myEmployeeModal");
    ModalEmployee.style.display = "none";


}
function DisplaySelectedEmployeeModal() {
    //var ModalSelectedEmployee = document.getElementById("mySelectedEmployeeModal");
    //ModalSelectedEmployee.style.display = "block";
    return false;
}
function CloseSelectedEmployeeModal() {
    //var ModalSelectedEmployee = document.getElementById("mySelectedEmployeeModal");
    //ModalSelectedEmployee.style.display = "none";


}

function DisplaySectorModal() {
    var ModalSector = document.getElementById("mySectorModal");
    ModalSector.style.display = "block";
    return false;
}
function CloseSectorModal() {
    var ModalSector = document.getElementById("mySectorModal");
    ModalSector.style.display = "none";


}
function DisplaySelectedSectorModal() {
    var ModalSelectedSector = document.getElementById("mySelectedSectorModal");
    ModalSelectedSector.style.display = "block";
    return false;
}
function CloseSelectedSectorModal() {
    var ModalSelectedSector = document.getElementById("mySelectedSectorModal");
    ModalSelectedSector.style.display = "none";


}

function DisplayNewGroupModal() {
    var ModalNewGroup = document.getElementById("myNewGroupModal");
    ModalNewGroup.style.display = "block";
    return false;
}
function CloseNewGroupModal() {
    var ModalNewGroup = document.getElementById("myNewGroupModal");
    ModalNewGroup.style.display = "none";


}
function DisplayGroupExploreModal() {
    var ModalNewGroup = document.getElementById("myGroupExploreModal");
    ModalNewGroup.style.display = "block";
    return false;
}
function CloseGroupExploreModal() {
    var ModalNewGroup = document.getElementById("myGroupExploreModal");
    ModalNewGroup.style.display = "none";


}