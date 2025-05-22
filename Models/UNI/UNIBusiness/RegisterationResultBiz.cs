using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class RegisterationResultBiz:RegisterationBiz
    {
        public RegisterationResultBiz()
        {
            _RegisterationDb = new RegisterationResultDb();
        }
        public RegisterationResultBiz(DataRow objDr)
        {
            _RegisterationDb = new RegisterationResultDb(objDr);
            if (_RegisterationDb.ID == 687)
            {

            }
            _CourseBiz = new CourseBiz(objDr);
            _SemesterBiz = new SemesterBiz(objDr);
             
        }
    }
}