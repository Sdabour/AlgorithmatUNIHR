using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentSemesterBiz
    {
        public int SemesterID;
        public string SemesterDesc;

        RegisterationCol _RegisterationCol;
        public RegisterationCol RegisterationCol
        {
            set => _RegisterationCol = value;
            get
            {
                if (_RegisterationCol == null)
                    _RegisterationCol = new RegisterationCol(true,0);
                return _RegisterationCol;
            }
        }
    }
}