using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class LevelBiz
    {
       public int Level { set; get; }
        public string LevelDesc { get
            {
               string Returned = Level==0?"NotSpecified": "Level " + Level.ToString();

                return Returned;
            } }
        StudentCol _StudentCol;
        public StudentCol StudentCol
        {
            set => _StudentCol = value;
            get
            {
                if (_StudentCol == null)
                    _StudentCol = new StudentCol(true,0);
                return _StudentCol;
            }
        }
        CourseCol _CourseCol;
        public CourseCol CourseCol
        {
            set
            {
                _CourseCol = value;
            }
            get
            {
                if (_CourseCol == null)
                    _CourseCol = new CourseCol(true,0);
                return _CourseCol;
            }
        }

        #region Constructor
        public LevelBiz()
        {
            _LevelDb = new LevelDb();
        }
        public LevelBiz(DataRow objDr)
        {
            _LevelDb = new LevelDb(objDr);
            Level = _LevelDb.Order;

        }

        #endregion
        #region Private Data
        LevelDb _LevelDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _LevelDb.ID = value;
            get => _LevelDb.ID;
        }
        public int Faculty
        {
            set => _LevelDb.Faculty = value;
            get => _LevelDb.Faculty;
        }
        public int Order
        {
            set => _LevelDb.Order = value;
            get => _LevelDb.Order;
        }
        public string Desc
        {
            set => _LevelDb.Desc = value;
            get => _LevelDb.Desc;
        }
        public int CreditHourFrom
        {
            set => _LevelDb.CreditHourFrom = value;
            get => _LevelDb.CreditHourFrom;
        }
        public int CreditHourTo
        {
            set => _LevelDb.CreditHourTo = value;
            get => _LevelDb.CreditHourTo;
        }
        public int SemesterType1MaxLimitedHour
        {
            set => _LevelDb.SemesterType1MaxLimitedHour = value;
            get => _LevelDb.SemesterType1MaxLimitedHour;
        }
        public int SemesterType2MaxLimitedHour
        {
            set => _LevelDb.SemesterType2MaxLimitedHour = value;
            get => _LevelDb.SemesterType2MaxLimitedHour;
        }
        public int SemesterType3MaxLimitedHour
        {
            set => _LevelDb.SemesterType3MaxLimitedHour = value;
            get => _LevelDb.SemesterType3MaxLimitedHour;
        }
        public int LowGPALimitedHour
        {
            set => _LevelDb.LowGPALimitedHour = value;
            get => _LevelDb.LowGPALimitedHour;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _LevelDb.Add();
        }
        public void Edit()
        {
            _LevelDb.Edit();
        }
        public void Delete()
        {
            _LevelDb.Delete();
        }
        #endregion
    }
}