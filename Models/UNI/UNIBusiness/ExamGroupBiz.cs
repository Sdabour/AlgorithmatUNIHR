using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ExamGroupBiz
    {

        HallBiz _HallBiz;
        public HallBiz HallBiz { set => _HallBiz = value;
            get {
                if (_HallBiz == null)
                    _HallBiz = new HallBiz();
                return _HallBiz;
            } }
        RegisterationGroupBiz _GroupBiz;
        public RegisterationGroupBiz GroupBiz
        {
            set => _GroupBiz = value;
            get
            {
                if (_GroupBiz == null)
                    _GroupBiz = new RegisterationGroupBiz();
                return _GroupBiz;
            }
        }
    }
}