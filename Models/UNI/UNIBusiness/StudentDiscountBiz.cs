using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentDiscountBiz
    {
        #region Private Data
        StudentDiscountDb _StudentDiscountDb;
        StudentBiz _StudentBiz;
        DiscountTypeBiz _TypeBiz;
        #endregion
        #region Constructors
        public StudentDiscountBiz()
        {

            _StudentDiscountDb = new StudentDiscountDb();
            //_TypeBiz = new DiscountTypeBiz();
        }
        public StudentDiscountBiz(int intID)
        {
            _StudentDiscountDb = new StudentDiscountDb(intID);
            //_TypeBiz = new DiscountTypeBiz();

        }
        public StudentDiscountBiz(DataRow objDR)
        {
            _StudentDiscountDb = new StudentDiscountDb(objDR);
            if (_StudentDiscountDb.TypeID != 0)
                _TypeBiz = new DiscountTypeBiz(objDR);
            else
                _TypeBiz = new DiscountTypeBiz();

        }
        #endregion
        #region Public Properties
        public DateTime Date
        {
            set
            {
                _StudentDiscountDb.Date = value;
            }
            get
            {
                return _StudentDiscountDb.Date;
            }

        }
        public string Reason
        {
            set
            {
                _StudentDiscountDb.Reason = value;
            }
            get
            {
                return _StudentDiscountDb.Reason;
            }

        }
        public double Value
        {
            set
            {
                _StudentDiscountDb.Value = value;
            }
            get
            {
                return _StudentDiscountDb.Value;
            }

        }

        public StudentBiz StudentBiz
        {
            set
            {
                _StudentBiz = value;
            }
            get
            {
                if (_StudentBiz == null)
                    _StudentBiz = new StudentBiz();
                return _StudentBiz;
            }

        }
        internal int StudentID
        {
            get
            {
                return _StudentDiscountDb.StudentID;
            }
        }
        public int ID
        {
            set
            {
                _StudentDiscountDb.ID = value;
            }
            get
            {
                return _StudentDiscountDb.ID;
            }

        }
        public bool Scheduled
        {
            set
            {

                _StudentDiscountDb.Scheduled = value;
            }
            get
            {
                return _StudentDiscountDb.Scheduled;
            }

        }
        public DiscountTypeBiz TypeBiz
        {
            set
            {
                _TypeBiz = value;
            }
            get
            {
                return _TypeBiz;
            }
        }
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _StudentDiscountDb.StudentID = _StudentBiz.ID;
            _StudentDiscountDb.TypeID = _TypeBiz.ID;
            _StudentDiscountDb.Add();
        }
        public void Edit()
        {
            _StudentDiscountDb.StudentID = _StudentBiz.ID;
            _StudentDiscountDb.TypeID = _TypeBiz.ID;

            _StudentDiscountDb.Edit();
        }
        public void Schedul()
        {
            _StudentDiscountDb.Scheduled = true;
            _StudentDiscountDb.Schedul();

        }
        public void Delete()
        {
            _StudentDiscountDb.Delete();
        }
        public StudentDiscountBiz Copy()
        {
            StudentDiscountBiz Returned = new StudentDiscountBiz();
            Returned._StudentDiscountDb = _StudentDiscountDb;
            Returned._StudentDiscountDb.ID = 0;
            return Returned;
        }
        #endregion
    }
}