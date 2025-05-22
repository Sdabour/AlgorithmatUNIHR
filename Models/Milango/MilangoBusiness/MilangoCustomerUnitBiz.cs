using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.Milango.MilangoDb;
using System.Data;
namespace AlgorithmatMVC.Milango.MilangoBiz
{
    public class MilangoCustomerUnitBiz
    {

        #region Constructor
        public MilangoCustomerUnitBiz()
        {
            _MilangoCustomerUnitDb = new MilangoCustomerUnitDb();
        }
        public MilangoCustomerUnitBiz(DataRow objDr)
        {
            _MilangoCustomerUnitDb = new MilangoCustomerUnitDb(objDr);
        }

        #endregion
        #region Private Data
        MilangoCustomerUnitDb _MilangoCustomerUnitDb;
        #endregion
        #region Properties
        public string CustomerBp
        {
            set => _MilangoCustomerUnitDb.CustomerBp = value;
            get => _MilangoCustomerUnitDb.CustomerBp;
        }
        public string UnitCode
        {
            set => _MilangoCustomerUnitDb.UnitCode = value;
            get => _MilangoCustomerUnitDb.UnitCode;
        }
        public string UnitProjectName
        {
            set => _MilangoCustomerUnitDb.UnitProjectName = value;
            get => _MilangoCustomerUnitDb.UnitProjectName;
        }
        public string UnitProjectCode
        {
            set => _MilangoCustomerUnitDb.UnitProjectCode = value;
            get => _MilangoCustomerUnitDb.UnitProjectCode;
        }
        public int UnitStatus
        {
            set => _MilangoCustomerUnitDb.UnitStatus = value;
            get => _MilangoCustomerUnitDb.UnitStatus;
        }
        public bool UnitChanged
        {
            set => _MilangoCustomerUnitDb.UnitChanged = value;
            get => _MilangoCustomerUnitDb.UnitChanged;
        }
        public bool UnitChangesSent
        {
            set => _MilangoCustomerUnitDb.UnitChangesSent = value;
            get => _MilangoCustomerUnitDb.UnitChangesSent;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _MilangoCustomerUnitDb.Add();
        }
        public void Edit()
        {
            _MilangoCustomerUnitDb.Edit();
        }
        public void Delete()
        {
            _MilangoCustomerUnitDb.Delete();
        }
        #endregion
    }
}