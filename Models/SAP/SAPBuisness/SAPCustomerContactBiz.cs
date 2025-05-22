using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SAP.SAPDataBase;
namespace SharpVision.SAP.SAPBuisness
{
    public class SAPCustomerContactBiz
    {

        #region Constructor
        public SAPCustomerContactBiz()
        {
            _SAPCustomerContactDb = new SAPCustomerContactDb();
        }
        public SAPCustomerContactBiz(DataRow objDr)
        {
            _SAPCustomerContactDb = new SAPCustomerContactDb(objDr);
        }

        #endregion
        #region Private Data
        SAPCustomerContactDb _SAPCustomerContactDb;
        #endregion
        #region Properties
        public string PARTNER
        {
            set => _SAPCustomerContactDb.PARTNER = value;
            get => _SAPCustomerContactDb.PARTNER;
        }
        public string CustomerFullName
        {
            set => _SAPCustomerContactDb.CustomerFullName = value;
            get => _SAPCustomerContactDb.CustomerFullName;
        }
        public string PERSNUMBER
        {
            set => _SAPCustomerContactDb.PERSNUMBER = value;
            get => _SAPCustomerContactDb.PERSNUMBER;
        }
        public string CUSTOMER
        {
            set => _SAPCustomerContactDb.CUSTOMER = value;
            get => _SAPCustomerContactDb.CUSTOMER;
        }
        public string IDNUMBER
        {
            set => _SAPCustomerContactDb.IDNUMBER = value;
            get => _SAPCustomerContactDb.IDNUMBER;
        }
        public string PhoneNo
        {
            set => _SAPCustomerContactDb.PhoneNo = value;
            get => _SAPCustomerContactDb.PhoneNo;
        }
        public string BE
        {
            set => _SAPCustomerContactDb.BE = value;
            get => _SAPCustomerContactDb.BE;
        }
        public string ROCode
        {
            set => _SAPCustomerContactDb.ROCode = value;
            get => _SAPCustomerContactDb.ROCode;
        }
        public string ContractNo
        {
            set => _SAPCustomerContactDb.ContractNo = value;
            get => _SAPCustomerContactDb.ContractNo;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _SAPCustomerContactDb.Add();
        }
        public void Edit()
        {
            _SAPCustomerContactDb.Edit();
        }
        public void Delete()
        {
            _SAPCustomerContactDb.Delete();
        }
        #endregion
    }
}