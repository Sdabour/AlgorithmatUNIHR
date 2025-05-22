class MSG
{
    public ID: number;
    public Date: Date;
    public Time: string;
    
    public Header: string;
    public Text: string;
    public Sender: number;
    public Group: number;
   
    public GroupName: string;
    public NotifyBySMS: boolean;
    public NotifyByMail: boolean;
    public SetAlarm: boolean;
    public AlarmDate: Date;
    public Alarmed: boolean;
    public Stop: boolean;
    public Parent: number;
    public SenderApplicant: number;
    public SenderApplicantCode: string;
    public SenderApplicantName: string;
    public Seen: boolean;
    public LstAppIDs: number[] =[];
    public LstSectorIDs: number[] = [];
    
}
 function GetMsg(): MSG {

    let Returned: MSG = new MSG();
    let AppLst: ApplicantSingle[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value != null && (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value != "") {
        AppLst = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value);
        Returned.LstAppIDs = AppLst.map(x => x.ID);
    }
    let SectorLst: SectorSimple[] = [];
    if ((<HTMLInputElement>document.getElementById("lblSelectedSector")).value != null && (<HTMLInputElement>document.getElementById("lblSelectedSector")).value != "") {
        SectorLst = JSON.parse((<HTMLInputElement>document.getElementById("lblSelectedSector")).value);
        Returned.LstSectorIDs = SectorLst.map(x => x.ID);
    }
     if ((<HTMLElement>document.getElementById("tdMSGBody")).innerText != null) {
         var vrTemp = document.getElementById("tdMSGBody");
         Returned.Text = (<HTMLElement>document.getElementById("tdMSGBody")).innerText;

     }
     if ((<HTMLInputElement>document.getElementById("txtMSGSubject")).value != null) {
       
         Returned.Header = (<HTMLInputElement>document.getElementById("txtMSGSubject")).value;

     }
     if ((<HTMLInputElement>document.getElementById("lblMainMSG")).value != null) {

         Returned.Parent = Number((<HTMLInputElement>document.getElementById("lblMainMSG")).value);

     }
     var vrGroupStr: string = (<HTMLInputElement>document.getElementById("lblGroup")).value;
     if (vrGroupStr != "")
     {
         var vrGroup: Group = JSON.parse(vrGroupStr);
         Returned.Group = vrGroup.ID;
         Returned.GroupName = vrGroup.NameA;
     }
    return Returned;
}
function ClearMsg(){

    let Returned: MSG = new MSG();
    let AppLst: ApplicantSingle[] = [];
    (<HTMLInputElement>document.getElementById("lblSelectedEmployee")).value = "";
    
    (<HTMLInputElement>document.getElementById("lblSelectedSector")).value = "";
    (<HTMLElement>document.getElementById("tdMSGBody")).innerText = "";
    
    (<HTMLInputElement>document.getElementById("txtMSGSubject")).value = "";
    (<HTMLInputElement>document.getElementById("lblGroup")).value = "";
    (<HTMLInputElement>document.getElementById("txtMSGGroup")).value = "";
    
}
function ClearSubMSG()
{
    document.getElementById("tblMSGThread").innerHTML = "";
    document.getElementById("lblMainMSG").innerHTML = "";
    document.getElementById("lblMainMSG").setAttribute("value", "0");
    document.getElementById("lblMainMSGCount").setAttribute("value", "0");
}
function GetMSGURL(objBiz: MSG) {
    var vrSender = objBiz.Group==0 ? objBiz.SenderApplicantName:objBiz.GroupName;
    var vrImage: string = objBiz.Seen ? "success.png" : "placeholder.jpg";
    vrImage = objBiz.Seen ? "Seen.png" : "Unseen.png";
    //"pnotify""placeholders"
    let Returned: string = "<li class=\"media\">" +
        "<div class=\"md-3 position-relative\" >" +
        "<img src=\"../wwwroot/images/pnotify/"+vrImage+"\" width = \"36\" height = \"36\" class=\"rounded-circle\" style=\"width: 18px; height: 18px;\" alt = \"\" >" +
        "</div>";

              Returned+=  "<div class=\"media-body\">"+
                    "<div class=\"media-title\" >"+
                        "<a href=\"#\" onclick=\"SeeMSG("+objBiz.ID+")\" >"+
                           "<span class=\"font-weight-semibold\" >"+vrSender+" </span>"+
                      "<span class=\"text-muted float-right font-size-sm\" > "+objBiz.Time+" </span>"+
                                    "</a>"+
                                    "</div>"+
                  "<span class=\"text-muted\">"+objBiz.Header+"</span>"+
                                        "</div>"+
                                        "</li>";
    return Returned;
}
function GetMSGTableRows(lstMSG:MSG[]):string
{
    var Returned: string = "";
    var vrMSG: MSG;
    for (var vrIndex = 0; vrIndex < lstMSG.length; vrIndex++) {
        vrMSG = lstMSG[vrIndex];
        Returned += GetThreadMSGTableStr(vrMSG);
    }
    return Returned;
   
}
function GetThreadMSGTableStr(objMsg:MSG): string
{
    var Returned: string = "<tr>"+
        "<td>"+
        "<table width=\"280\" border = \"0\" cellpadding = \"0\" cellspacing = \"0\" align = \"right\">"+
            "<tbody>"+
            "<tr>"+
        "<td height=\"60\" valign = \"middle\" width = \"100%\" align = \"right\">" +
        objMsg.SenderApplicantName +"</br>"+ objMsg.Time +"</br>"+
        objMsg.Text +
                "</td>"+
                "</tr>"+
                "</tbody>"+
                "</table>"+
                "</td>"+
                "</tr>";
    return Returned;
}

function FillMSGSelectedApplicant()
{
}