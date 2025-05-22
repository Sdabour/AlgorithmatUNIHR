using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AlgorithmatMN.MN.MNDb;
namespace AlgorithmatMN.MN.MNBiz
{
    public class YearBiz
    {

        #region Constructor
        public YearBiz()
        {
            _YearDb = new YearDb();
        }
        
        public YearBiz(DataRow objDr)
        {
            _YearDb = new YearDb(objDr);
        }

        #endregion
        #region Private Data
        YearDb _YearDb;
        #endregion
        #region Properties
        public int ID
        {
            set
            {
                _YearDb.ID = value;
            }
            get
            {
                return _YearDb.ID;
            }
        }
        public int No
        {
            set
            {
                _YearDb.No = value;
            }
            get
            {
                return _YearDb.No;
            }
        }
        public string Desc
        {
            set
            {
                _YearDb.Desc = value;
            }
            get
            {
                return _YearDb.Desc;
            }
        }
        public string Desc1
        {
            set
            {
                _YearDb.Desc1 = value;
            }
            get
            {
                return _YearDb.Desc1;
            }
        }
        public string Desc2
        {
            set
            {
                _YearDb.Desc2 = value;
            }
            get
            {
                return _YearDb.Desc2;
            }
        }
        public DateTime StartDate
        {
            set
            {
                _YearDb.StartDate = value;
            }
            get
            {
                return _YearDb.StartDate;
            }
        }
        public DateTime EndDate
        {
            set
            {
                _YearDb.EndDate = value;
            }
            get
            {
                return _YearDb.EndDate;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _YearDb.Add();
        }
        public void Edit()
        {
            _YearDb.Edit();
        }
        public void Delete()
        {
            _YearDb.Delete();
        }
        #endregion
    }
}
