using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentSemesterCol:CollectionBase
    {
        public StudentSemesterBiz this[int intIndex]
        {
            get
            {
                return (StudentSemesterBiz)List[intIndex];
            }
        }

        public void Add(StudentSemesterBiz objBiz)
        {
            List.Add(objBiz);
        }
    }
}