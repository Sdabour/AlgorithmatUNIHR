

function OnReservation() {

    var objParm = { ID: 115, Name: 'Abdo' };
    

    var vrParm = JSON.stringify(objParm); //"{\"strID\":\"0\",\"strName\":\"Sameh\"}";

    var vrServiceUrl = "../api/ReservationWebController/GetReservation";
    var vrStarContractDate = document.getElementById("dtSUBRESContractFrom");
    
    var vrEndContractDate = document.getElementById("dtSUBRESContractTo");
    var vrIsContractDateRange = !Date.parse(vrStarContractDate) && !Date.parse(vrEndContractDate);//!default(vrStarContractDate) && !default(vrEndContractDate);
    var vrStarReservationDate = document.getElementById("dtSUBRESReservationFrom");
    var vrEndReservationDate = document.getElementById("dtSUBRESReservationTo");
    var vrIsReservationDateRange = !Date.parse(vrStarReservationDate) && !Date.parse(vrEndReservationDate);
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    
    var vrUnitCode = document.getElementById("txtSUBRESUnitCode").value;
    var vrProjectIDs = document.getElementById("SUBRESProjectCheckedCol").value;
    var vrBranchIDs = document.getElementById("SUBRESBranchCheckedCol").value;
    var vrResubmissionIDs = document.getElementById("SUBRESResubmissionTypeCheckedCol").value;
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            blIsContractingDateRange: vrIsContractDateRange
            , dtStartContractingDate :vrStarContractDate
            , dtEndContractingDate: vrEndContractDate
            , blIsReservationDateRange : vrIsReservationDateRange
            , dtReservationDateStart: vrStarReservationDate
            ,dtReservationEnd : vrEndReservationDate
            , strUnitCode: vrUnitCode
            , strProjectIDs : vrProjectIDs
            , strTowerIDs : ''
            , strResubmissionTypeIDs: vrResubmissionIDs
            ,strBranchIDs : vrBranchIDs
        },
        success: successResFunc,
        error: errorResFunc
    });


    function successResFunc(data, status) {


        var strTemp = "<tr height=10>" +
            "<th width= \"23\">" +
            "<input type=\"checkbox\" id=\"chkAllCustomer\" name=\"chkAllCustomer\" onchange=\"ChkChanged('chkAllCustomer', 'chkCustomer', 'CustomerCheckCol')\">" +
            " </th>" +
            "<th width=\"38\"><span lang=\"ar-eg\">&#1603;&#1608;&#1583;</span></th>" +
            "<th width=\"193\"><span lang=\"ar-eg\">&#1575;&#1587;&#1605;</span></th>" +
            "<th width=\"86\"><span lang=\"ar-eg\">&#1605;&#1588;&#1585;&#1608;&#1593;</span></th>" +
            "<th ><span lang=\"ar-eg\">&#1608;&#1581;&#1583;&#1577;</span></th>" +
            "</tr >";
        var vrCustomer;
        var arrCustomer = [];
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            vrCustomer = data[vrIndex];
            strTemp = strTemp + " <tr>  " +
                "<td width=\"23\"> " +
                " <input type=\"checkbox\" id=\"chkCustomer" + vrCustomer._ID + "\" name=\"chkCustomer" + vrCustomer._ID + "\">" +
                "</td><td width=\"38\">" + vrCustomer._ID + "</td> " +
                " <td width=\"193\">" + vrCustomer._Name + "</td> " +
                "<td width=\"86\">" + vrCustomer._Project + "</td> " +
                "<td>" + vrCustomer._UnitCode + "</td>" +
                "</tr>";
            arrCustomer[vrIndex] = vrCustomer._ID;
        }
        document.getElementById("CustomerCheckCol").value = JSON.stringify(arrCustomer);
        var strTemp1 = document.getElementById("CustomerCol");
        document.getElementById("CustomerCol").value = JSON.stringify(data);
        document.getElementById("tblCustomerDisplay").innerHTML = strTemp;
    }

    function errorResFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }

}

function OnCustomer() {

    var objParm = { ID : 115, Name : 'Abdo' };


    var vrParm = JSON.stringify(objParm); //"{\"strID\":\"0\",\"strName\":\"Sameh\"}";

    var vrServiceUrl = "../api/CustomerWebController/GetCustomer";
    var vrName = document.getElementById("txtCustomerName").value;
    var vrCustomerPhone = document.getElementById("txtCustomerPhone").value;
    var vrCustomerUnit = document.getElementById("txtCustomerUnitCode").value;
    var vrProjectIDs = document.getElementById("CustomerProjectCheckedCol").value;
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',
       
        dataType: 'json',
        data: {
            id: 0, strName: vrName,
            strPhone: vrCustomerPhone, strUnitCode: vrCustomerUnit, strIDNo: '',
            strProjectIDs: vrProjectIDs
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {
      

        var strTemp = "<tr height=10>"+
            "<th width= \"23\">"+
            "<input type=\"checkbox\" id=\"chkAllCustomer\" name=\"chkAllCustomer\" onchange=\"ChkChanged('chkAllCustomer', 'chkCustomer', 'CustomerCheckCol')\">"+
                " </th>"+
                "<th width=\"38\"><span lang=\"ar-eg\">&#1603;&#1608;&#1583;</span></th>"+
                "<th width=\"193\"><span lang=\"ar-eg\">&#1575;&#1587;&#1605;</span></th>"+
                "<th width=\"86\"><span lang=\"ar-eg\">&#1605;&#1588;&#1585;&#1608;&#1593;</span></th>"+
                "<th ><span lang=\"ar-eg\">&#1608;&#1581;&#1583;&#1577;</span></th>"+
                    "</tr >";
        var vrCustomer;
        var arrCustomer = [];
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++)
        {
            vrCustomer = data[vrIndex];
            strTemp = strTemp + " <tr>  " +
                "<td width=\"23\"> " +
                " <input type=\"checkbox\" id=\"chkCustomer" + vrCustomer._ID + "\" name=\"chkCustomer" + vrCustomer._ID + "\">" +
                "</td><td width=\"38\">"+ vrCustomer._ID +"</td> " +
                " <td width=\"193\">" + vrCustomer._Name+"</td> " +
                "<td width=\"86\">"+ vrCustomer._Project +"</td> " +
                "<td>"+ vrCustomer._UnitCode +"</td>" +
                "</tr>";
            arrCustomer[vrIndex] = vrCustomer._ID;
        }
    //tblFreeVisitDisplay
        document.getElementById("tblCustomerDisplay").innerHTML = strTemp;
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("Error :" + errorThrown);
    }

}
function FillSelectedCustomer() {
    var vrFrame = document.getElementById("CustomerFrame");

    var strCustomer = vrFrame.contentWindow.document.getElementById("CustomerCol").value;
    if (strCustomer == null || strCustomer == "")
        return;
        var vrCustomerCol = JSON.parse(strCustomer);
    var vrSelectedCustomer = [];
    var vrCheck;
    for (var vrIndex = 0; vrIndex < vrCustomerCol.length; vrIndex++)
    {
        vrCheck = vrFrame.contentWindow.document.getElementById("chkCustomer" + vrCustomerCol[vrIndex]._ID);
        if (vrCheck != null && vrCheck.checked) {
            vrSelectedCustomer[vrSelectedCustomer.length] = vrCustomerCol[vrIndex];
        }
    }

    var vrSelectedTable = "";
    var vrCurrentSelectedCustomer = [];
    var strCurrentSelectedCustomer = document.getElementById("SelectedCustomerCol").value;
    if (strCurrentSelectedCustomer != "")
        vrCurrentSelectedCustomer = JSON.parse(strCurrentSelectedCustomer);

    for (var vrIndex = 0; vrIndex < vrSelectedCustomer.length; vrIndex++) {
        vrCurrentSelectedCustomer[vrCurrentSelectedCustomer.length] = vrSelectedCustomer[vrIndex];

      
    }

    for (var vrIndex = 0; vrIndex < vrCurrentSelectedCustomer.length; vrIndex++) {
       

        vrSelectedTable += "<tr>";

        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._ID + "</td>";
        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._Name + "</td>";
        vrSelectedTable += "<td>" + vrCurrentSelectedCustomer[vrIndex]._IDNo + "</td>";
        vrSelectedTable += "</tr>"
    }


    document.getElementById("tblSelectedCustomer").innerHTML = vrSelectedTable;
    document.getElementById("SelectedCustomerCol").value = JSON.stringify(vrCurrentSelectedCustomer);

}    
function FillEMployee() {
    var vrEmployeeSector = 0;
    var vrEmployeeSectorCmbName = "cmbEmployeeSectorLevel";
    for (var vrIndex = 5; vrIndex >= 1; vrIndex--) {
        if (document.getElementById(vrEmployeeSectorCmbName + vrIndex).value > 0) {
            vrEmployeeSector = document.getElementById(vrEmployeeSectorCmbName + vrIndex).value;
            break;
        }
    }


    var objDvEmployee = document.getElementById("dvEmployee");
    objDvEmployee.innerHTML = "";
    var strName = document.getElementById("txtEmployeeName").value;
    var strCode = document.getElementById("txtEmployeeCode").value;

    var objEmpSearch = { ID: 0, Code: strCode, Name: strName, Job: "", EmployeeSector: "" };
    var vrEmpSearch = JSON.stringify(objEmpSearch);
    var objEmp = { strEmpCode: strCode, strEmpName: strName };
    //alert(JSON.stringify(objEmp));
    var vrServiceUrl = "../api/EmployeeWeb/GetEmployee";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: { intSectorID: vrEmployeeSector, strEmpCode: strCode, strEmpName: strName },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {


        var strDV = "<table class=\"table\">";
        var vrEmployee;
        var vrRdID;
        var vrRdChecked;
        var vrRdSpanClass;
        var vrEmployeeID;
        //  var vrTempEmp = new Employee();
        for (var vrIndex = 0; vrIndex < data.length; vrIndex++) {
            strDV += "<tr>";
            vrEmployee = data[vrIndex];
            strDV += GetEmployeeRow(vrEmployee);

            strDV += "</tr>";
        }
        strDV += "</table>"
        //alert(strDV);
        objDvEmployee.innerHTML = strDV;

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("ErrorFunct :" + errorThrown);
    }


    return false;


}
/**
 * check all changed
 * @param {any} strCheckAllName
 * @param {any} strCheckPrefix
 * @param {any} strIDsName
 */
function ChkChanged(strCheckAllName, strCheckPrefix, strIDsName)
{
    var objCheckAll = document.getElementById(strCheckAllName);
    var strCheckName;
    var objIDCol = [];
    var strIDs = document.getElementById(strIDsName).value;
    if (strIDs != null && strIDs != "")
    {
        objIDCol = JSON.parse(strIDs);
    }
    var blChecked = document.getElementById(strCheckAllName).checked;
    for (var intIndex = 0; intIndex < objIDCol.length; intIndex++)
    {
        strCheckName = strCheckPrefix + objIDCol[intIndex];
        document.getElementById(strCheckName).checked = blChecked;

    }


}

/**
 * 
 * @param {any} txtFilter ID of txtFilter input
 * @param {any} tblContainer ID of Table Contining the CheckBox and Desc
 * @param {any} strPrefix Prefix presents the prefix of the control naming like Floor or Tower (floor[tblFloor,chkFloor1,txtFloor],Tower[tblTower,chkTower,txtTower])
 * @param {any} txtChecked ID of hidden input storing the checked array 
 */
 function OnTxtFloorChanged(txtFilter,tblContainer,strPrefix,txtChecked)
  {
            var objText = document.getElementById(txtFilter);
            var txtValue = objText.value;
            //alert(txtValue);
            var objTblContainer = document.getElementById(tblContainer);
            var objCheckedText = document.getElementById(txtChecked);

            var strCheckedCol = objCheckedText.getAttribute("value");
            var objCol = JSON.parse(objTblContainer.getAttribute("ObjectCol"));
            var objSelectedCol = [];
           // alert(objCol.length);
            var intNewIndex = 0;
            for (var i = 0; i < objCol.length; i++)
            {
                if (objCol[i].Name.indexOf(txtValue, 0) != -1)
                {
                //objSelectedCol.add(objCol[i]);
                    objSelectedCol[intNewIndex] = objCol[i];
                    intNewIndex++;

                }
            }
            //alert("Selected Length:"+objSelectedCol.length);
            
            var objCheckedCol = [];
            if(strCheckedCol != "")
              objCheckedCol =  JSON.parse(strCheckedCol); 
            var strChecked;
            var strNewTable = "";
            for (var i = 0; i < objSelectedCol.length; i++)
            {
                strChecked = "";
                if (objCheckedCol.indexOf(objSelectedCol[i].ID.toString()) != -1)
                    strChecked = " checked ";
                
                strNewTable += "<tr>";
                strNewTable += "<td>";
                strNewTable += "<input id=\'" + strPrefix + objSelectedCol[i].ID + "\' type=checkbox " + strChecked +    
                " onchange=\"OnCheckChanged(\'"+ strPrefix+ objSelectedCol[i].ID +"\', \'"+ tblContainer +"\',\'"+objSelectedCol[i].ID+"\',\'"+ txtChecked +"\')\" />";
                strNewTable += "</td>";
                strNewTable += "<td>";
                strNewTable += objSelectedCol[i].Name ;
                strNewTable += "</td>";
                strNewTable += "</tr>";
            }
 
             objTblContainer.innerHTML = strNewTable;
}
/**
 * 
 * @param {any} strCheck CheckBox ID
 * @param {any} tblContainer contining table ID
 * @param {any} intID  Item ID presented by checkbox ex(FloorID,TowerID)
 * @param {any} txtChecked hidden Input storing the array of checked ids
 */
function OnCheckChanged(strCheck, tblContainer, intID,txtChecked)
{
    var objContainer = document.getElementById(tblContainer);
    var objChecked = document.getElementById(txtChecked);
    var strCheckedCol = objChecked.getAttribute("value");
    var objCheckedCol;
    if (strCheckedCol == null || strCheckedCol == "") {
        objCheckedCol = [];
    }
    else {
        objCheckedCol = JSON.parse(strCheckedCol);
    }
    var objCheck = document.getElementById(strCheck);
    var valChecked = objCheck.getAttribute("isChecked");
    valChecked = objContainer.getAttribute("id");
   // alert(objCheck.checked);
    if (document.getElementById(strCheck).checked == true) {
        objCheckedCol[objCheckedCol.length] = intID;
    }
    else {
        var intIndex = objCheckedCol.indexOf(intID);
          if (intIndex != -1)
              delete objCheckedCol[intIndex];
        }
  
    strCheckedCol = "";
    if (objCheckedCol.length > 0)
        strCheckedCol = JSON.stringify(objCheckedCol);
    strCheckedCol = strCheckedCol.replace(",null", "")
    strCheckedCol = strCheckedCol.replace("null,", "")
    strCheckedCol = strCheckedCol.replace("null", "")
    //document.getElementById(tblContainer).
    //    setAttribute("CheckedObjectCol", strCheckedCol);
    objChecked.setAttribute("value",strCheckedCol)

    //alert(strCheckedCol);
}



/**
 * 
 * @param {any} txtFilter ID of txtFilter input
 * @param {any} tblContainer ID of Table Contining the CheckBox and Desc
 * @param {any} strPrefix Prefix presents the prefix of the control naming like Floor or Tower (floor[tblFloor,chkFloor1,txtFloor],Tower[tblTower,chkTower,txtTower])
 * @param {any} txtChecked ID of hidden input storing the checked array 
 */
function OnTxtFilterChanged(txtFilter, tblContainer, strPrefix, txtChecked) {
    var objText = document.getElementById(txtFilter);
    var txtValue = objText.value;
    //alert(txtValue);
    var objTblContainer = document.getElementById(tblContainer);
    var objCheckedText = document.getElementById(txtChecked);

    var strCheckedCol = objCheckedText.getAttribute("value");
    var objCol = JSON.parse(objTblContainer.getAttribute("ObjectCol"));
    var objSelectedCol = [];
    // alert(objCol.length);
    var intNewIndex = 0;
    for (var i = 0; i < objCol.length; i++) {
        if (objCol[i].Name.indexOf(txtValue, 0) != -1) {
            //objSelectedCol.add(objCol[i]);
            objSelectedCol[intNewIndex] = objCol[i];
            intNewIndex++;

        }
    }
    //alert("Selected Length:"+objSelectedCol.length);

    var objCheckedCol = [];
    if (strCheckedCol != "")
        objCheckedCol = JSON.parse(strCheckedCol);
    var strChecked;
    var strNewTable = "";
    for (var i = 0; i < objSelectedCol.length; i++) {
        strChecked = "";
        if (objCheckedCol.indexOf(objSelectedCol[i].ID.toString()) != -1)
            strChecked = " checked ";
        strNewTable += "<tr><td>";
        strNewTable += "<label>";
        strNewTable += objSelectedCol[i].Name; 
        strNewTable += "<input id=\'" + strPrefix + objSelectedCol[i].ID + "\' type=checkbox " + strChecked +
            " onchange=\"OnCheckChanged(\'" + strPrefix + objSelectedCol[i].ID + "\', \'" + tblContainer + "\',\'" + objSelectedCol[i].ID + "\',\'" + txtChecked + "\')\" />";
        strNewTable += "<span>";
        strNewTable += "</span>";
        strNewTable += "</label>";
        strNewTable += "</tr></td>";
           }

    objTblContainer.innerHTML = strNewTable;
}
function ConfigureCheckOut(vrMerchant, vrSessionID) {
    if (vrMerchant== null || vrMerchant== ""|| vrSessionID == null || vrSessionID == "")
        return;
    Checkout.configure({
        merchant: vrMerchant,
        session: { id: vrSessionID },
        interaction: {
            merchant:{
        name: "AlmorshedyGroup",
        address: {
            line1: "الطريق الدائرى برج 5 بجوار توكيل البافارية"

        }
    }
        }}
    );
   
}

function PayAcondition(vrRO,vrCredit,vrCondition,vrValue,vrDesc) {




   

    var vrServiceUrl = "../api/MaintainancePayment/PayACreditCondition/";
     
    vrServiceUrl = "../api/MaintainancePayment/PayACreditCondition/";
    var vrReturnedSession = {};
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            intRO: vrRO, intCredit: vrCredit, intConditionID: vrCondition,
            dblValue: vrValue
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {


      

        vrReturnedSession = data;
        document.getElementById("lblResponse").value = JSON.stringify(vrReturnedSession);
        ConfigureCheckOut(vrReturnedSession.Merchant, vrReturnedSession.SessionID);
        Checkout.showLightbox();

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        vrReturnedSession = { SessionID: "", TransactionID:""};
    }
    return vrReturnedSession;
}
function PayATransaction(vrTransaction) {






    var vrServiceUrl = "../api/MaintainancePayment/PayACreditCondition/";

    vrServiceUrl = "../api/MaintainancePayment/PayACreditCondition/";
    var vrReturnedSession = {};
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,

        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            strTransactionID:vrTransaction
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {




        vrReturnedSession = data;
        document.getElementById("lblResponse").value = JSON.stringify(vrReturnedSession);
        ConfigureCheckOut(vrReturnedSession.Merchant, vrReturnedSession.SessionID);
        Checkout.showLightbox();

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        vrReturnedSession = { SessionID: "", TransactionID: "" };
    }
    return vrReturnedSession;
}

function GetSessionID(vrTransactionID, vrDesc, vrValue) {


     

    var vrServiceUrl = "../api/MaintainancePayment/GetSession";

   
    var vrReturnedSession = "";
    $.ajax({
        type: 'POST',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            strTransactionID: vrTransactionID, strDesc: vrDesc
            , dblValue: vrValue
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {


        //vrReturnedSession = 
    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        vrReturnedSession = "";
    }
    return vrReturnedSession;
}

function PerformAPayment(vrTransaction, vrBankRef) {

    var vrServiceUrl = "../api/MaintainancePayment/PerformAPayment";
    var vrToken = document.getElementById("lblToken").value;


    var vrReturnedSession = {};
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        contentType: 'application/json; charset=utf-8',
        headers: {
            'Authorization': vrToken
        },
        dataType: 'json',
        data: {
            strPaymentRef: vrTransaction, strBankRef: vrBankRef
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {




        alert("تم");
        document.close();

    }

    function errorFunc(jqXHR, textStatus, errorThrown) {
        alert("خطأ");
        document.close();
    }

}
function TempPayAmount() {


    var vrServiceUrl = "../api/MaintainancePayment/PayAnAmount/";
    var vrRO = document.getElementById("lblID").value;
    var vrValue = document.getElementById("txtValue").value;

    //vrServiceUrl = "../api/MaintainancePayment/PayACreditCondition/";
    var vrReturned = "";
    $.ajax({
        type: 'GET',
        url: vrServiceUrl,
        async:false,
        contentType: 'application/json; charset=utf-8',

        dataType: 'json',
        data: {
            intRo: vrRO, dblValue:vrValue
        },
        success: successFunc,
        error: errorFunc
    });


    function successFunc(data, status) {

        vrReturned = data;
        document.getElementById("lblTransactionID").setAttribute("value", vrReturned);
        //PayATransaction(vrReturned);


    }

    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return vrReturned;
}
function ConstructBankPaymentURLNew() {
    TempPayAmount();
        var vrValue = document.getElementById("txtValue").value;
        var vrID = document.getElementById("lblID").value;
        if (vrValue == null  || vrValue == "0")
            return false;
        if (vrID == null || vrID == "0")
            return false;

    var vrTransaction = document.getElementById("lblTransactionID").value;
    //var vrURL = "/Maintainance/BankPayment?TransactionID=" + vrTransaction;
    var vrURL = "/Maintainance/BankPayment";
    $.ajax({
        type: 'GET',
        url: vrURL,
        data: {
    strTransactionID: vrTransaction
  },
        success: function (result)
        {
           console.log(result);
        },
        dataType: "json"
    });
    var vrBtn = document.getElementById("btnPayAcreditCondition");
    //vrBtn.setAttribute("href", vrURL);
    //xhr.open();
     // xhr.
        return false;
}

function ConstructBankPaymentURL() {
    TempPayAmount();
    var vrValue = document.getElementById("txtValue").value;
    var vrID = document.getElementById("lblID").value;
    if (vrValue == null || vrValue == "0")
        return false;
    if (vrID == null || vrID == "0")
        return false;
    var vrTransaction = document.getElementById("lblTransactionID").value;

    var vrURL = "/Maintainance/BankPayment?strTransactionID=" + vrTransaction;
    var vrBtn = document.getElementById("btnPayAcreditCondition");
    vrBtn.setAttribute("href", vrURL);
    return true;
}