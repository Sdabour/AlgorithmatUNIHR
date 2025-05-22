class CostCenter {
    public ID: number;
    public Code: string;
    public NameA: string;
    public NameE: string;
    public OrderVal: number;
    public ParentID: number;
    public FamilyID: number;
    public Level: number;
    public TypeID: number;
    public TypeNameA: string;
    public TypeNameE: string;

}
function GetCostCenterCheckRow(vrCost: CostCenter):string {
    var Returned: string = "";
    Returned += "<tr>";
 
    Returned += "<td><input type='button' value='+' onclick='AddCostToSelected(" + vrCost.ID + ")'></td>";
   // Returned += "<td>" + vrCost.Code + "</td>";
    Returned += "<td>" + vrCost.TypeNameA + "</td>";
    Returned += "<td>" + vrCost.NameA + "</td>";


    Returned += "</tr>";
    return Returned;
}
function GetSelectedCostCenterRow(vrCost: CostCenter): string {
    var Returned: string = "";
    Returned += "<tr>";
    
  
    // Returned += "<td>" + vrCost.Code + "</td>";
    Returned += "<td>" + vrCost.TypeNameA + "</td>";
    Returned += "<td>" + vrCost.NameA + "</td>";

    Returned += "<td><input type='button' value='-' onclick='RemoveCostSelected(" + vrCost.ID + ")'></td>";
    Returned += "</tr>";
    return Returned;
}

function FillFilteredCostCenterTable() {
    var vrCostCenterName: string = "";
    if (document.getElementById("txtFilterCostCenter") != null) {
        vrCostCenterName = (<HTMLInputElement>document.getElementById("txtFilterCostCenter")).value;

    }
    var vrCostCentLst: CostCenter[] = [];
    var vrCostCenterStr = (<HTMLInputElement>document.getElementById("lblAllCostCenter")).value; 
    vrCostCentLst = JSON.parse((<HTMLInputElement>document.getElementById("lblAllCostCenter")).value);
    var vrFilterCostCenter: CostCenter[]=[];
    vrFilterCostCenter = vrCostCentLst.filter(x => x.NameA.indexOf(vrCostCenterName) > -1);
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrFilterCostCenter.length; vrIndex++) {
        vrTable += GetCostCenterCheckRow(vrFilterCostCenter[vrIndex]);

    }
    vrTable += "</table>";
    if (document.getElementById("tblCostCenter") != null) {
        (<HTMLInputElement>document.getElementById("tblCostCenter")).innerHTML=vrTable;

    }
}

function FillSelectedCostCenterTable() {
   
    var vrCostCentLst: CostCenter[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value != "") {
      vrCostCentLst = JSON.parse ((<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value);
    }
    var vrTable: string = "<table class=\"table\">";
    for (var vrIndex = 0; vrIndex < vrCostCentLst.length; vrIndex++) {
        vrTable += GetSelectedCostCenterRow(vrCostCentLst[vrIndex]);

    }
    vrTable += "</table>";
    if (document.getElementById("tblSelectedCostCenter") != null) {
        (<HTMLInputElement>document.getElementById("tblSelectedCostCenter")).innerHTML = vrTable;

    }
}
function AddCostToSelected(vrCostID:number) {
    var vrCostCentLst: CostCenter[] = [];
    var vrSelectedCostCenter: CostCenter[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value != "") {
        vrSelectedCostCenter = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value);
    }

    var vrFilterCostCenter: CostCenter[] = vrSelectedCostCenter.filter(x => x.ID == vrCostID);
    if (vrFilterCostCenter.length > 0) {
        return;
    }

    vrCostCentLst = JSON.parse((<HTMLInputElement>document.getElementById("lblAllCostCenter")).value);
    vrFilterCostCenter = vrCostCentLst.filter(x => x.ID == vrCostID);
    if (vrFilterCostCenter.length > 0) {
        vrSelectedCostCenter[vrSelectedCostCenter.length] = vrFilterCostCenter[0];

    }
    (<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value = JSON.stringify(vrSelectedCostCenter);
    FillSelectedCostCenterTable();
}

function RemoveCostSelected(vrCostID: number) {
    var vrCostCentLst: CostCenter[] = [];
    var vrSelectedCostCenter: CostCenter[] = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value);

    var vrFilterCostCenter: CostCenter[] = vrSelectedCostCenter.filter(x => x.ID != vrCostID);
    if (vrFilterCostCenter.length==vrSelectedCostCenter.length) {
        return;
    }

    
  
    (<HTMLInputElement>document.getElementById("lblSelectedCostCenter")).value = JSON.stringify(vrFilterCostCenter);
    FillSelectedCostCenterTable();
}


