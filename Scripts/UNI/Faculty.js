var Faculty = /** @class */ (function () {
    function Faculty() {
    }
    return Faculty;
}());
function GetCurrentFacultyID() {
    var Returned = 0;
    if (document.getElementById("lblCurrentFaculty") != null) {
        try {
            var vrFaculty = JSON.parse(document.getElementById("lblCurrentFaculty").value);
            Returned = vrFaculty.ID;
        }
        catch (_a) { }
    }
    return Returned;
}
//# sourceMappingURL=Faculty.js.map