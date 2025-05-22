using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class TeacherTypeBiz
    {

        #region Constructor
        public TeacherTypeBiz()
        {
            _TeacherTypeDb = new TeacherTypeDb();
        }
        public TeacherTypeBiz(DataRow objDr)
        {
            _TeacherTypeDb = new TeacherTypeDb(objDr);
        }

        #endregion
        #region Private Data
        TeacherTypeDb _TeacherTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _TeacherTypeDb.ID = value;
            get => _TeacherTypeDb.ID;
        }
        public string Code
        {
            set => _TeacherTypeDb.Code = value;
            get => _TeacherTypeDb.Code;
        }
        public string NameA
        {
            set => _TeacherTypeDb.NameA = value;
            get => _TeacherTypeDb.NameA;
        }
        public int Order
        {
            set => _TeacherTypeDb.Order = value;
            get => _TeacherTypeDb.Order;
        }
        public int FunctionGroup
        {
            set => _TeacherTypeDb.FunctionGroup = value;
            get => _TeacherTypeDb.FunctionGroup;
        }
        public int JobNatureID
        {
            set => _TeacherTypeDb.JobNatureID = value;
            get => _TeacherTypeDb.JobNatureID;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _TeacherTypeDb.Add();
        }
        public void Edit()
        {
            _TeacherTypeDb.Edit();
        }
        public void Delete()
        {
            _TeacherTypeDb.Delete();
        }
        #endregion
    }
}