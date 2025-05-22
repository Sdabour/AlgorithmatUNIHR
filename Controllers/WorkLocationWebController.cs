using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpVision.HR.HRBusiness;
namespace AlgorithmatMVC.Controllers
{
    public class SinglePoint
    {
        public int LocationID;
         
        public string PointType;
        public string PointLat;
        public string PointLong;
    }
    
    public class WorkLocationWebController : ApiController
    {
        [Route("api/WorkLocationWebController/UploadPoint")]
        [HttpPost]
        [ActionName("UploadPoint")]
        public void UploadPoint ([FromBody] SinglePoint objPoint)
        {
            WorkLocationBiz objLocation = new WorkLocationBiz();
            objLocation.ID = objPoint.LocationID;
          
            objLocation.UploadLocation(objPoint.PointType,objPoint.PointLat, objPoint.PointLong);


        }
        [Route("api/WorkLocationWebController/GetLocation")]
        [HttpPost]
        [ActionName("GetLocation")]
        public void GetLocation([FromBody] SinglePoint objPoint)
        {
            WorkLocationBiz objLocation = new WorkLocationBiz();
            objLocation.ID = objPoint.LocationID;
            double dblLong = 0;
            double dblLat = 0;
            
            
            objLocation.UploadLocation(objPoint.PointType, objPoint.PointLat, objPoint.PointLong);


        }

    }
}
