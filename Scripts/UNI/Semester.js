var Semester = /** @class */ (function () {
    function Semester() {
        this.lstRegisteration = [];
    }
    return Semester;
}());
function GetCurrentSemester() {
    var Returned = new Semester();
    if (document.getElementById("lblSemester") != null && document.getElementById("lblSemester").value != "") {
        Returned = JSON.parse(document.getElementById("lblSemester").value);
    }
    return Returned;
}
//# sourceMappingURL=Semester.js.map