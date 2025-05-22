
function SearchRegisterationGroup() {
   
   
    var vrSemester = 0;//

    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;

    var vrFaculty = GetCurrentFacultyID();
    var vrCourse = GetCurrentCourse();
    var vrLectureType = 0;
    var vrLevel = 0;
    var vrExamType = 0;
    if (document.getElementById("tblExamGrroup") == null) {
        vrExamType = GetExamType();
    }
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }
    if (document.getElementById("cmbLectureType") != null) {
        vrLectureType = Number(document.getElementById("cmbLectureType").value);
    }
    if (document.getElementById("tblExamGrroup") != null)
        vrLectureType = 3;
    if (vrFaculty == 0 || vrSemester == 0)
        return;
    var vrServiceUrl = "../api/ControlAPI/GetRegisterationGroup";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intSemester: vrSemester, intCourse: vrCourse.ID, intLectureType: vrLectureType, intEXamType:vrExamType,intCourseLevel:vrLevel },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        FillRegisterationGroupTable(data);
        // setTimeout(OnMSG, 30000);
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SaveRegisterationGroupXML() {


    var vrSemester = 0;//

    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;

    var vrFaculty = GetCurrentFacultyID();
    var vrCourse = GetCurrentCourse();
    var vrLectureType = 0;
    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }
    if (document.getElementById("cmbLectureType") != null) {
        vrLectureType = Number(document.getElementById("cmbLectureType").value);
    }
    var vrServiceUrl = "../api/ControlAPI/GetRegisterationGroupXML";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intSemester: vrSemester, intCourse: vrCourse.ID, intLectureType: vrLectureType, intCourseLevel: vrLevel },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var vrFileName = new Date().getTime().toString()+".xlx";
        const fs = require('fs');
         
        fs.writeFile(vrFileName, data, (err) => {
            if (err) throw err;
            else {
                console.log("ok")
            }
        });
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SaveRegisterationGroup() {
    var vrRegisterationGroup = GetRegisterationGroupData();
    if (vrRegisterationGroup.NameA == "") {
        alert("حدد وصف المجموعة");
        return;
    }
    if (vrRegisterationGroup.Course.ID == 0 || vrRegisterationGroup.Semester.ID == 0) {
        alert("حدد ال course");
        return;
    }

    var vrUser = GetCurrentUser();


    vrRegisterationGroup.User = vrUser.ID;
    


    var vrServiceUrl = "../api/ControlAPI/AddEditRegisterationGroup";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrRegisterationGroup),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //try {
        //    ClearCurrentCourse();
        //} catch { }
        var vrGroup = data;
        SetRegisterationGroupData(vrGroup);
         
    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function SetRegisterationGroupDataByID(vrGroupID) {
    var vrGroupStr = document.getElementById("lblRegisterationGroup" + vrGroupID.toString()).value;
    var vrGroup = JSON.parse(vrGroupStr);
    SetRegisterationGroupData(vrGroup);
    }
function SetRegisterationGroupData(vrGroup) {
    SetSelectedRegisterationGroupData(vrGroup);
    var lstRegisteration = GetGroupRecommendedRegisteration(vrGroup.ID, vrGroup.Faculty.ID);
    var lstSelected = GetGroupRegisteration(vrGroup.ID, vrGroup.Faculty.ID);
    var vrReg = GetRegisterationStudentSelectionTable(lstRegisteration, lstSelected);
    document.getElementById("tblGroupReg").innerHTML = vrReg;
    document.getElementById('chkSelectAll').checked = false;
    document.getElementById('myRegisterationGroupModal').style.display = 'none';
}
function ShowGroupModal() {
    document.getElementById('myRegisterationGroupModal').style.display = 'block';
}
function GetGroupRegisteration(vrGroup, vrFaculty) {
    var Returned = [];
    var vrServiceUrl = "../api/ControlAPI/GetRegisterationGroupStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intGroup:vrGroup },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        Returned = data;
        // setTimeout(OnMSG, 30000);
    }



    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return Returned;
}
function GetGroupRecommendedRegisteration(vrGroup, vrFaculty) {
    var Returned = [];
    var vrServiceUrl = "../api/ControlAPI/GetRegisterationGroupRecommendedStudent";
    $.ajax({
        method: 'GET',

        url: vrServiceUrl,
        async: false,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: { intFaculty: vrFaculty, intGroup: vrGroup },
        success: successFunc,
        error: errorFunc
    });



    function successFunc(data, status) {
        var vrGender = 0
        if (document.getElementById("rdGenderMale") != null && document.getElementById("rdGenderMale").checked) {
            vrGender = 1;
        }
        if (document.getElementById("rdGenderFemale") != null && document.getElementById("rdGenderFemale").checked) {
            vrGender = 2;
        }
         Returned = data.filter(x => (vrGender==0 || x.StudentGender==vrGender));
        // setTimeout(OnMSG, 30000);
    }



    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return Returned;
}

function UploadGroupStudent() {
    var vrGroup = GetCurrentGroup();
    if (vrGroup.ID == 0) {
        alert("فضلا حدد المجموعة");
        return;
    }
    if (vrGroup.StudentIDLst.length ==0) {
        alert("فضلا حدد الطلبة");
        return;
    }
    var vrUser = GetCurrentUser();


    vrGroup.User = vrUser.ID;



    var vrServiceUrl = "../api/ControlAPI/UploadRegisterationGroupStudent";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrGroup),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //try {
        //    ClearCurrentCourse();
        //} catch { }
        var vrGroup = data;
        SetRegisterationGroupData(vrGroup);

    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function ClearGroupStudent() {
    var vrGroup = GetCurrentGroup();
    if (vrGroup.ID == 0) {
        alert("فضلا حدد المجموعة");
        return;
    }
    if (!confirm("هل حقا تود حذف الطلبة من المجموعة")) { return;}
    var vrUser = GetCurrentUser();


    vrGroup.User = vrUser.ID;



    var vrServiceUrl = "../api/ControlAPI/DeleteRegisterationGroupStudent";
    $.ajax({
        method: 'POST',

        url: vrServiceUrl,
        async: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        data: JSON.stringify(vrGroup),
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        alert("OK");
        //try {
        //    ClearCurrentCourse();
        //} catch { }
        var vrGroup = data;
        SetRegisterationGroupData(vrGroup);

    }


    function errorFunc(jqXHR, textStatus, errorThrown) {

    }
    return false;
}
function FillRegisterationGroupStudentData(vrGroup) {
    var vrFaculty = GetCurrentFacultyID();
    var lstReg = GetGroupRegisteration(vrGroup, vrFaculty);
    var vrReg = GetRegisterationStudentSelectionTable(lstReg, lstReg);
    /*document.getElementById("tblGroupReg").innerHTML = vrReg;*/
    document.getElementById('myRegisterationGroupStudentModal').style.display = 'block';
}
function OnGroupDownloadClick(vrDetailed) {


    var vrSemester = 0;//

    var vrSemeseterObj = GetCurrentSemester();
    vrSemester = vrSemeseterObj.ID;
    if (vrSemester == null || vrSemester == 0)
        vrSemester = 0;

    var vrFaculty = GetCurrentFacultyID();
    var vrCourse = GetCurrentCourse();
    var vrLectureType = 0;
    var vrExamType = 0;
    vrExamType = GetExamType();
    var vrLevel = 0;
    if (document.getElementById("cmbLevel") != null) {
        vrLevel = Number(document.getElementById("cmbLevel").value);

    }
    if (document.getElementById("cmbLectureType") != null) {
        vrLectureType = Number(document.getElementById("cmbLectureType").value);
    }
    var vrUrl = window.location.href;
    var vrUrlArr = vrUrl.split("?");
    vrUrl = "../Control/Download_GroupPDF" + "?Semester=" + vrSemester;
    
    vrUrl += "&Level=" + vrLevel;
    vrUrl += "&LectureType=" + vrLectureType;
    vrUrl += "&ExamType="+vrExamType;
    vrUrl += "&Course=" + vrCourse.ID;
    vrUrl += "&Faculty=" + vrFaculty;
    vrUrl += "&Detailed=" + vrDetailed;
    window.location.replace(vrUrl);
   
    return;
}
 