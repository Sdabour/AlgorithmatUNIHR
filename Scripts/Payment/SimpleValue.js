var SimpleValue = /** @class */ (function () {
    function SimpleValue(intID, intTypeID, strTypeName, strDesc, dblValue, dtDate, strValueLabel) {
        this.MethodID = -1;
        this.MethodName = "";
        this.ForeignID = 0;
        this.ID = intID;
        this.TypeID = intTypeID;
        this.TypeName = strTypeName;
        this.Desc = strDesc;
        this.Value = dblValue;
        this.Date = dtDate;
        this.SetControls(strValueLabel);
        var vrUser = GetCurrentUser();
        this.UserIns = vrUser.ID;
        this.Branch = vrUser.Branch;
        this.Employee = vrUser.EmpID;
    }
    SimpleValue.prototype.SetControls = function (Label) {
        this.ValueLabel = Label;
        this.txtLabelValue = "txt" + Label + "Value";
        this.cmbLabelType = "cmb" + Label + "Type";
        this.cmbLabelMethod = "cmb" + Label + "Method";
        this.txtLabelDesc = "txt" + Label + "Desc";
        this.lblSelectedLabel = "lblSelected" + Label;
        this.lblDeletedLabel = "lblDeleted" + Label;
        this.dvSelectedLabel = "dvSelected" + Label;
        this.btnAddLabel = "btnAdd" + Label;
        this.dtLabelDate = "dt" + Label;
    };
    SimpleValue.prototype.FillSelectedTable = function () {
        var objBiz;
        if (document.getElementById(this.lblSelectedLabel) == null)
            return;
        var vrSelectedStr = document.getElementById(this.lblSelectedLabel).getAttribute("value");
        var vrSelectedLst;
        vrSelectedLst = JSON.parse(vrSelectedStr);
        var Returned;
        Returned = "<table class=\"table\">";
        var vrUnitID;
        var intIndex;
        for (intIndex = 0; intIndex < vrSelectedLst.length; intIndex++) {
            Returned += "<tr>";
            objBiz = vrSelectedLst[intIndex];
            vrUnitID = "lblUnit" + objBiz.ID;
            Returned += "<input type=\"hidden\" id=\"" + vrUnitID + "\" value='" + JSON.stringify(objBiz) + "'\>";
            Returned += "<td>" + objBiz.ID + "</td>";
            if (objBiz.TypeName == undefined || objBiz.TypeName == null) {
                objBiz.TypeName = "";
            }
            Returned += "<td>" + objBiz.TypeName + "</td>";
            if (objBiz.Desc == undefined || objBiz.Desc == null) {
                objBiz.Desc = "";
            }
            Returned += "<td>" + objBiz.Desc + "</td>";
            if (objBiz.MethodID != -1) {
                Returned += "<td>" + objBiz.MethodName + "</td>";
            }
            Returned += "<td>" + objBiz.Value + "</td>";
            Returned += "<td>" + objBiz.Date.toString().substring(0, 10) + "</td>";
            Returned += "<td><input type=\"button\" value=\"-\" id=\"btnDelete" + this.ValueLabel + intIndex + "\"  onclick=\"return onDeleteValueClick('" + this.ValueLabel + "'," + intIndex + ")\" name=\"btnDelete" + this.ValueLabel + intIndex + "\" /></td>";
            Returned += "</tr>";
        }
        Returned += "</table>";
        document.getElementById(this.dvSelectedLabel).innerHTML = Returned;
        var objStudent = new Student();
        var dblRemaining = 0; //objStudent.GetRemainingValue();
        if (document.getElementById("txtDevidedValue") != null) {
            document.getElementById("txtDevidedValue").value = dblRemaining.toString();
        }
        return Returned;
    };
    SimpleValue.prototype.AddValueToSelected = function () {
        var _this = this;
        var vrSelectedLbl = document.getElementById(this.lblSelectedLabel);
        var vrSelectedStr = vrSelectedLbl.getAttribute("value");
        var vrSelectedLst;
        if (vrSelectedStr != "")
            vrSelectedLst = JSON.parse(vrSelectedStr);
        else
            vrSelectedLst = [];
        var objBiz;
        //let strDate = document.getElementById(this.dtLabelDate);
        //objBiz.TypeID = parseInt(document.getElementById(this.cmbLabelType).ej2_instances[0].value);
        //let strDateValue: string;
        //strDateValue = strDate.getAttribute("value");
        //objBiz.Date =new Date(document.getElementById(this.dtLabelDate).getAttribute("value"));
        //objBiz.Desc = document.getElementById(this.txtLabelDesc).getAttribute("value");
        //objBiz.Value = parseFloat(document.getElementById(this.txtLabelValue).getAttribute("value"));
        //objBiz.TypeID = parseInt(document.getElementById(this.cmbLabelType).getAttribute("value"));
        if (vrSelectedLst.filter(function (x) { return x.ID > 0 && x.ID == _this.ID; }).length == 0) {
            vrSelectedLst[vrSelectedLst.length] = this;
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrSelectedLst));
            this.FillSelectedTable();
            document.getElementById(this.txtLabelValue).setAttribute("value", "0");
            document.getElementById(this.txtLabelDesc).setAttribute("value", "");
        }
    };
    SimpleValue.prototype.DeleteValue = function (strLabel, intIndex) {
        var objBiz;
        this.ValueLabel = strLabel;
        var vrSelectedLbl = document.getElementById(this.lblSelectedLabel);
        var vrDeletedLbl = document.getElementById(this.lblDeletedLabel);
        var vrSelectedStr = vrSelectedLbl.getAttribute("value");
        var vrDeletedStr = vrDeletedLbl.getAttribute("value");
        var vrSelectedLst;
        var vrDeletedLst;
        vrDeletedLst = [];
        if (vrDeletedStr != null && vrDeletedStr != "") {
            vrDeletedLst = JSON.parse(vrDeletedStr);
        }
        var vrNewSelectedLst;
        vrNewSelectedLst = [];
        vrSelectedLst = JSON.parse(vrSelectedStr);
        if (vrSelectedLst.length > intIndex) {
            var vrIndex = void 0;
            for (vrIndex = 0; vrIndex < vrSelectedLst.length; vrIndex++) {
                objBiz = vrSelectedLst[vrIndex];
                if (intIndex != vrIndex) {
                    vrNewSelectedLst[vrNewSelectedLst.length] = objBiz;
                }
                else if (objBiz.ID != 0) {
                    vrDeletedLst[vrDeletedLst.length] = objBiz;
                }
            }
            vrSelectedLbl.setAttribute("value", JSON.stringify(vrNewSelectedLst));
            vrDeletedLbl.setAttribute("value", JSON.stringify(vrDeletedLst));
            this.FillSelectedTable();
        }
    };
    return SimpleValue;
}());
function onDeleteValueClick(strLabel, inTIndex) {
    if (strLabel == "TempPayment") {
        return;
    }
    var vrSimpleValue = new SimpleValue(0, 0, "", "", 0, new Date("2023-01-01"), strLabel);
    vrSimpleValue.DeleteValue(strLabel, inTIndex);
}
//# sourceMappingURL=SimpleValue.js.map