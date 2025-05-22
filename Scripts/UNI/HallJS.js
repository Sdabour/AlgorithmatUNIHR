function SearchHall() {
 var vrFaculty = GetCurrentFacultyID();
    
    if (document.getElementById("tblExamGrroup") == null) {
        
    }
    
    var vrServiceUrl = "../api/ControlAPI/GetHall";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty},
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillHallTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}