using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.Milango.MilangoDb;
using System.Data;

namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class MilangoCustomerBiz
    {

        #region Constructor
        public MilangoCustomerBiz()
        {
            _MilangoCustomerDb = new MilangoCustomerDb();
        }
        public MilangoCustomerBiz(DataRow objDr)
        {
            _MilangoCustomerDb = new MilangoCustomerDb(objDr);
        }

        #endregion
        #region Private Data
        MilangoCustomerDb _MilangoCustomerDb;
        #endregion
        #region Properties
        public string Bp
        {
            set => _MilangoCustomerDb.Bp = value;
            get => _MilangoCustomerDb.Bp;
        }
        public string No
        {
            set => _MilangoCustomerDb.No = value;
            get => _MilangoCustomerDb.No;
        }
        public int ID
        {
            set => _MilangoCustomerDb.ID = value;
            get => _MilangoCustomerDb.ID;
        }
        public string Name
        {
            set => _MilangoCustomerDb.Name = value;
            get => _MilangoCustomerDb.Name;
        }
        public string MobileNo
        {
            set => _MilangoCustomerDb.MobileNo = value;
            get => _MilangoCustomerDb.MobileNo;
        }
        public int Status
        {
            set => _MilangoCustomerDb.Status = value;
            get => _MilangoCustomerDb.Status;
        }
        public bool Changed
        {
            set => _MilangoCustomerDb.Changed = value;
            get => _MilangoCustomerDb.Changed;
        }
        public bool ChangesSent
        {
            set => _MilangoCustomerDb.ChangesSent = value;
            get => _MilangoCustomerDb.ChangesSent;
        }
        MilangoCustomerUnitCol _UnitCol;
        public MilangoCustomerUnitCol UnitCol
        {
            set => _UnitCol = value;
            get
            {
                if (_UnitCol == null)
                    _UnitCol = new MilangoCustomerUnitCol(true);
                return _UnitCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MilangoCustomerDb.UnitTable = UnitCol.GetTable();
            _MilangoCustomerDb.Add();
        }
        public void Edit()
        {
            _MilangoCustomerDb.Edit();
        }
        public void Delete()
        {
            _MilangoCustomerDb.Delete();
        }
        #endregion
    }
}