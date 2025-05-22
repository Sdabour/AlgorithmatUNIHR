class Course {
    public ID: number;
    public Code: string;
    public NameA: string;
    public NameE: string;
    public Desc: string;
    public CreditHour: number;
    public TotalDegree: number;
    public MidtermDegree: number;
    public SemesterWorkDegree: number;
    public PracticalDegree: number;
    public OralDegree: number;
    public FinalDegree: number;
    public ClinicalDegree : number;
    public RecommendedGrade: number;
    public GradeLst: COMMONGrade[] = [];
    public RegisterationNo: number;
}
function GetCoursePivotTableRow(objBiz: Course, objGradeCol: COMMONGrade[]): string {
    var Returned: string = "<tr>";
  
    Returned += "<td>" + objBiz.Code + "</td>";
   
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + objBiz.NameA + "</label></td>";
    Returned += "<td>" + objBiz.RegisterationNo + "</td>";
    
    var vrCOMMONGrade: COMMONGrade;
    var vrGradeLst: COMMONGrade[] = [];
    var vrTempCOMMONGrade: COMMONGrade;
    var vrLbl: string = "";
    for (var vrIndex = 0; vrIndex < objGradeCol.length; vrIndex++) {
        vrCOMMONGrade = objGradeCol[vrIndex];
        vrGradeLst = objBiz.GradeLst.filter(x => x.Verbal == vrCOMMONGrade.Verbal);

        vrLbl = objBiz.ID.toString() + "-" + vrIndex.toString(); 
        vrTempCOMMONGrade = new COMMONGrade();
        if (vrGradeLst.length > 0)
            vrTempCOMMONGrade = vrGradeLst[0];

      
        Returned += "<td>";
        if (vrGradeLst.length > 0) {
            Returned += "<input type=\"hidden\" id=\"" + vrLbl + "\" value='" + JSON.stringify(vrTempCOMMONGrade)+"'>";
            Returned += "<input type=\"button\" value=\""+ vrTempCOMMONGrade.Verbal+"\"  onclick=\"ShowGradeRegisterationModal('"+vrLbl+"')\"/>";
        }
        Returned += "</td>";
        Returned += "<td>";
        if (vrGradeLst.length>0) {
            Returned += vrTempCOMMONGrade.RegisterationLst.length;
        }
        Returned += "</td>";

    }
    Returned += "</tr>";
    return Returned;
}
function GetCOMMONGradeLst(lstCourse:Course[]): COMMONGrade[] {
    var Returned: COMMONGrade[] = [];

    for (var vrCourseIndex = 0; vrCourseIndex < lstCourse.length; vrCourseIndex++)
    {
        for (var vrGradeIndex = 0; vrGradeIndex < lstCourse[vrCourseIndex].GradeLst.length; vrGradeIndex++)
        {
            if (Returned.filter(x => x.Verbal == lstCourse[vrCourseIndex].GradeLst[vrGradeIndex].Verbal).length == 0)
                Returned[Returned.length] = lstCourse[vrCourseIndex].GradeLst[vrGradeIndex];
        }
    }
    return Returned;

}
function GetCoursePivotTable(objCourseLst: Course[]):string {
    var lstGrade: COMMONGrade[] = GetCOMMONGradeLst(objCourseLst);

    var Returned = "<table class=\"table\">";
    Returned += "<tr><th></th><th></th><th></th>";
    for (var vrGradeIndex = 0; vrGradeIndex < lstGrade.length; vrGradeIndex++) {
        Returned += "<th></th>";
        Returned += "<th>"+lstGrade[vrGradeIndex].Verbal+"</th>";
    }
    Returned += "</tr>";
    for (var vrCourseIndex = 0; vrCourseIndex < objCourseLst.length; vrCourseIndex++) {
        Returned += GetCoursePivotTableRow(objCourseLst[vrCourseIndex], lstGrade);
    }
    Returned += "</table>";
    return Returned;
}
function ShowGradeRegisterationModal(vrLbl: string) {
    var vrGrade: COMMONGrade = JSON.parse((<HTMLInputElement>document.getElementById(vrLbl)).value);
    var lstRegisteration: Registeration[] = vrGrade.RegisterationLst;
    var vrRegisterationStr: string = GetRegistrationLstTable(lstRegisteration);
    //myRegisterationModal,
    

    
        //(<HTMLElement>document.getElementById("lblSemesterDesc")).innerText = vrStudentBiz.lstSemester[0].Desc;
        var vrTable: string = "";

        vrTable = "<div class=\"form-row\">" +
            "<div class=\"col-2\">" +
        "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.Verbal + "</label></div>";
    vrTable += "<div class=\"col-1\">" +
        "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">عدد</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst.length + "</label></div>";
    if (vrGrade.RegisterationLst.length > 0) {
        vrTable += "<div class=\"col-3\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseCode + "</label></div>";
        vrTable += "<div class=\"col-3\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseName + "</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">CH</label></div>";
        vrTable += "<div class=\"col-1\">" +
            "<label class=\"text-black\" style =\"background-color: aliceblue;text-align:center;\"+ id=\"RegisterationStudentCode\">" + vrGrade.RegisterationLst[0].CourseSimple.CreditHour + "</label></div>";
    }
      
       

       
    
            //dvOldSemester
           

            vrTable += "<div class=\"table-responsive\">" +
                "<table class=\"table\">";
    vrTable += GetRegistrationStudentLstTable(vrGrade.RegisterationLst);
            vrTable += "</table></div>";

      
    document.getElementById("dvSemester").innerHTML = vrTable;
        document.getElementById("myRegisterationModal").style.display = "block";
    
}
function GetCourseRow(vrCourse: Course):string {
    var Returned: string = "";
    Returned += "<tr>";
    Returned += "<td><input type=\"hidden\" id=\"lblCourse"+vrCourse.ID+"\" value='"+JSON.stringify(vrCourse)+"'\>" + vrCourse.ID + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    Returned += "<td>" + vrCourse.NameA + "</td>";
    Returned += "<td>" + vrCourse.NameE + "</td>";
    Returned += "<td>" + vrCourse.CreditHour + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    var vrTemp = "ReturnCourse("+vrCourse.ID+")";
    if (document.getElementById("tblSelectedCourse") != null)
        vrTemp = "if(CheckCourseValidation()){AddCourseToSelectedTable("+vrCourse.ID+");}";
    Returned += "<td><input type='button' value='+' onclick=\""+vrTemp+"\"\>" + "</td>";
    Returned += "</tr>";
    return Returned;
}
function FillCourseTable(lstCourse: Course[]) {
    var vrAllCoursesAuthorized: number = 1;
    if (document.getElementById("lblAllCoursesAuthorized") != null) {
        vrAllCoursesAuthorized =(<HTMLInputElement>document.getElementById("lblAllCoursesAuthorized")).value.toString() == "1"?1:0;
    }
    var vrAssignedCourses: number[] = [];
    if (vrAllCoursesAuthorized == 0) {
        if (document.getElementById("lblAssignedCourse") != null) {
            var vrAssignedCourseStr: string = (<HTMLInputElement>document.getElementById("lblAssignedCourse")).value;
            vrAssignedCourses = JSON.parse(vrAssignedCourseStr);
        }
    }
    var vrCourseStr: string = "<table class=\"table\">";
    var vrCourse: Course;
    for (var vrIndex = 0; vrIndex < lstCourse.length; vrIndex++) {
        vrCourse = lstCourse[vrIndex];
        if (vrAllCoursesAuthorized == 1 || vrAssignedCourses.filter(x => x == vrCourse.ID).length > 0) {
            vrCourseStr += GetCourseRow(lstCourse[vrIndex]);
        }
    }
    vrCourseStr += "</table>";
    (<HTMLInputElement>document.getElementById("tblCourse")).innerHTML = vrCourseStr;  
}
function ShowCourseModal() {
    document.getElementById('myCourseModal').style.display = 'block';

}
function ReturnCourse(vrCourseID: number) {
    var vrCourse: Course = new Course();
    var vrCourseStr: string = (<HTMLInputElement>document.getElementById("lblCourse" + vrCourseID)).value;
    vrCourse = JSON.parse(vrCourseStr);
    (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value = vrCourseStr;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCode")).innerText = vrCourse.Code;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseName")).innerText = vrCourse.NameA;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCH")).innerText = vrCourse.CreditHour.toString();
    (<HTMLInputElement>document.getElementById("lblSelectedCourseFinalDegree")).innerText = vrCourse.TotalDegree.toString();
    document.getElementById('myCourseModal').style.display = 'none';
}

function AddCourseToSelectedTable(vrCourseID: number) {
    var vrCourse = JSON.parse((<HTMLInputElement>document.getElementById("lblCourse" + vrCourseID)).value);

    var vrCourseStr: string = (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value;
    var lstSelectedCourse: Course[] = [];
    if (vrCourseStr != null && vrCourseStr != "") {
        lstSelectedCourse = JSON.parse(vrCourseStr);

    }
    if (lstSelectedCourse.length == 0 || lstSelectedCourse.filter(x => x.ID == vrCourseID).length == 0) {
        lstSelectedCourse[lstSelectedCourse.length] = vrCourse;
        (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value = JSON.stringify(lstSelectedCourse);

        FillSelectedCourseTable();
    }
  

}
function FillSelectedCourseTable() {
    var vrCourseStr: string = (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value;
    var vrCourse: Course;
    var lstSelectedCourse: Course[] = [];
    if (vrCourseStr != null && vrCourseStr != "") {
        lstSelectedCourse = JSON.parse(vrCourseStr);

    }
    var vrTable = "<table class=\"table\" style=\"width:100%;scroll-behavior: auto;\">";
    for (var vrIndex = 0; vrIndex < lstSelectedCourse.length; vrIndex++) {
        vrCourse = lstSelectedCourse[vrIndex];

        // vrTable += "<tr>";
        vrTable += GetSeldectedCourseRow(vrCourse, vrIndex + 1);
        //vrTable += "</tr>";
    }
    vrTable += "</table>";
    (<HTMLInputElement>document.getElementById("tblSelectedCourse")).innerHTML = vrTable;

    if (document.getElementById("lblSemesterHour") != null && (<HTMLInputElement>document.getElementById("lblSemesterHour")).value != "") {
        var vrCh: number = GetTotalRegisterationHour();

    }

}
function GetSeldectedCourseRow(vrCourse: Course, vrIndex: number): string {


    var Returned: string = "<tr>";
    Returned += "<input type='hidden' id='lblSelectedCourse" + vrCourse.ID + "' value='" + JSON.stringify(vrCourse) + "'/>";
    Returned += "<td><input type='button' value='-' onclick='RemoveSelectedCourse(" + vrCourse.ID + ")'></td>";
    Returned += "<td>" + vrIndex.toString() + "</td>";
    Returned += "<td>" + vrCourse.Code + "</td>";
    //<label class="text-black" style=" background-color: aliceblue;
    // text - align: center;>
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.NameA + "</label></td>";
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.NameE + "</label></td>";
    Returned += "<td><label class=\"text-black\" style=\"background-color: aliceblue;text-align: center;\">" + vrCourse.CreditHour.toString() + "</label></td>";
    Returned += "</tr>"
    return Returned;
}
function RemoveSelectedCourse(vrCourseID) {
    var vrSelectedCourseLst: Course[] = [];
    var vrNewSelectedCourseLst: Course[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedCourse")).value != "") {
        vrSelectedCourseLst = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedCourse")).value);
        var vrIndex :number= 0;
        for (vrIndex = 0; vrIndex < vrSelectedCourseLst.length; vrIndex++) {
            if (vrSelectedCourseLst[vrIndex].ID != vrCourseID) {
                vrNewSelectedCourseLst[vrNewSelectedCourseLst.length] = vrSelectedCourseLst[vrIndex];
            }
        }
        (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value = JSON.stringify(vrNewSelectedCourseLst);
        FillSelectedCourseTable();
    }
}
function GetCurrentCourse(): Course {
    var Returned: Course = new Course();
    Returned.ID = 0;
    if (document.getElementById("lblSelectedCourse") != null && (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value!= "") {
        Returned = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedCourse")).value);
    }
    return Returned;
}
function SetCurrentCourse(vrCourse: Course) {
    var vrCourseStr: string = JSON.stringify(vrCourse);
    (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value = vrCourseStr;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCode")).innerText = vrCourse.Code;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseName")).innerText = vrCourse.NameA;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCH")).innerText = vrCourse.CreditHour.toString();
    (<HTMLInputElement>document.getElementById("lblSelectedCourseFinalDegree")).innerText = vrCourse.TotalDegree.toString();
}
function ClearCurrentCourse() {
    var vrCourseStr: string = "";
    (<HTMLInputElement>document.getElementById("lblSelectedCourse")).value = vrCourseStr;
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCode")).innerText = "";
    (<HTMLInputElement>document.getElementById("lblSelectedCourseName")).innerText = "";
    (<HTMLInputElement>document.getElementById("lblSelectedCourseCH")).innerText = "";
    (<HTMLInputElement>document.getElementById("lblSelectedCourseFinalDegree")).innerText = "";
}
function CheckCourseAuthorized(vrCourse: Course): boolean {
    var Returned: boolean = true;
    if (document.getElementById("lblAllCoursesAuthorized") != null) {
        if ((<HTMLInputElement>document.getElementById("lblAllCoursesAuthorized")).value == "1") {
            
            return true;
        }

    }
    if (document.getElementById("lblAssignedCourse") != null) {
        var vrAssigned: number[] = [];
        if ((<HTMLInputElement>document.getElementById("lblAssignedCourse")).value != "") {
            vrAssigned = JSON.parse((<HTMLInputElement>document.getElementById("lblAssignedCourse")).value);
        }
        if (vrAssigned.filter(x => x == vrCourse.ID).length == 0)
            return false;


    }
    return Returned;

}