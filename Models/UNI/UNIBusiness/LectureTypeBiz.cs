using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LectureTypeBiz
    {

        #region Constructor
        public LectureTypeBiz()
        {
            _LectureTypeDb = new LectureTypeDb();
        }
        public LectureTypeBiz(DataRow objDr)
        {
            _LectureTypeDb = new LectureTypeDb(objDr);
        }

        #endregion
        #region Private Data
        LectureTypeDb _LectureTypeDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _LectureTypeDb.ID = value;
            get => _LectureTypeDb.ID;
        }
        public string Code
        {
            set => _LectureTypeDb.Code = value;
            get => _LectureTypeDb.Code;
        }
        public string NameA
        {
            set => _LectureTypeDb.NameA = value;
            get => _LectureTypeDb.NameA;
        }
        public string NameE
        {
            set => _LectureTypeDb.NameE = value;
            get => _LectureTypeDb.NameE;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _LectureTypeDb.Add();
        }
        public void Edit()
        {
            _LectureTypeDb.Edit();
        }
        public void Delete()
        {
            _LectureTypeDb.Delete();
        }
        #endregion
    }
}