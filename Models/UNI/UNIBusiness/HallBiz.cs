using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class HallBiz
    {

        #region Constructor
        public HallBiz()
        {
            _HallDb = new HallDb();
        }
        public HallBiz(DataRow objDr)
        {
            _HallDb = new HallDb(objDr);
        }

        #endregion
        #region Private Data
        HallDb _HallDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _HallDb.ID = value;
            get => _HallDb.ID;
        }
        FacultyBiz _FacultyBiz;
       public FacultyBiz FacultyBiz
        {
            set => _FacultyBiz = value;
            get
            {
                if (_FacultyBiz == null)
                    _FacultyBiz = new FacultyBiz() { ID = _HallDb.FacultyID, Code = _HallDb.FacultyCode, NameA = _HallDb.FacultyNameA, NameE = _HallDb.FacultyNameE };
                return _FacultyBiz;

            }
        }
        public string Name
        {
            set => _HallDb.Name = value;
            get => _HallDb.Name;
        }

        public double Capacity
        {
            set => _HallDb.Capacity = value;
            get => _HallDb.Capacity;
        }
        LectureTypeBiz _LectureTypeBiz;
        public LectureTypeBiz LectureTypeBiz { set => _LectureTypeBiz = value;
        get
            {
                if (_LectureTypeBiz == null)
                    _LectureTypeBiz = new LectureTypeBiz() { Code = _HallDb.LectureTypeCode, ID = _HallDb.LectureTypeID, NameA = _HallDb.LectureTypeNameA, NameE = _HallDb.LectureTypeNameE };
                return _LectureTypeBiz;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _HallDb.Add();
        }
        public void Edit()
        {
            _HallDb.Edit();
        }
        public void Delete()
        {
            _HallDb.Delete();
        }
        #endregion
    }
}