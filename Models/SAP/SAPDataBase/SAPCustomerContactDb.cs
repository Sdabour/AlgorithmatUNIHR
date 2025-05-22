using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.Base.BaseDataBase;
namespace SharpVision.SAP.SAPDataBase
{
    public class SAPCustomerContactDb
    {

        #region Constructor
        public SAPCustomerContactDb()
        {
        }
        public SAPCustomerContactDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        string _PARTNER;
        public string PARTNER
        {
            set => _PARTNER = value;
            get => _PARTNER;
        }
        string _CustomerFullName;
        public string CustomerFullName
        {
            set => _CustomerFullName = value;
            get => _CustomerFullName;
        }
        string _PERSNUMBER;
        public string PERSNUMBER
        {
            set => _PERSNUMBER = value;
            get => _PERSNUMBER;
        }
        string _CUSTOMER;
        public string CUSTOMER
        {
            set => _CUSTOMER = value;
            get => _CUSTOMER;
        }
        string _IDNUMBER;
        public string IDNUMBER
        {
            set => _IDNUMBER = value;
            get => _IDNUMBER;
        }
        string _PhoneNo;
        public string PhoneNo
        {
            set => _PhoneNo = value;
            get => _PhoneNo;
        }
        string _BE;
        public string BE
        {
            set => _BE = value;
            get => _BE;
        }
        string _ROCode;
        public string ROCode
        {
            set => _ROCode = value;
            get => _ROCode;
        }
        string _ContractNo;
        public string ContractNo
        {
            set => _ContractNo = value;
            get => _ContractNo;
        }
        string _UserIDStr;
        public string UserIDStr
        {
            set => _UserIDStr = value;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into SAPCustomerContact (PARTNER,CustomerFullName,PERSNUMBER,CUSTOMER,IDNUMBER,PhoneNo,BE,ROCode,ContractNo,UsrIns,TimIns) values (,'" + PARTNER + "','" + CustomerFullName + "','" + PERSNUMBER + "','" + CUSTOMER + "','" + IDNUMBER + "','" + PhoneNo + "','" + BE + "','" + ROCode + "','" + ContractNo + "',GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update SAPCustomerContact set " + "PARTNER='" + PARTNER + "'" +
           ",CustomerFullName='" + CustomerFullName + "'" +
           ",PERSNUMBER='" + PERSNUMBER + "'" +
           ",CUSTOMER='" + CUSTOMER + "'" +
           ",IDNUMBER='" + IDNUMBER + "'" +
           ",PhoneNo='" + PhoneNo + "'" +
           ",BE='" + BE + "'" +
           ",ROCode='" + ROCode + "'" +
           ",ContractNo='" + ContractNo + "'" + ",UsrUpd=,TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update SAPCustomerContact set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" select  Bp.PARTNER,Bp.NAME_FIRST+' '+Bp.NAME_LAST as CustomerFullName ,Bp.PERSNUMBER,BPCustomer.CUSTOMER,BpID.IDNUMBER,BPContact.TEL_NUMBER PhoneNo,RO.SWENR BE,RO.SMENR ROCode,Contract.RECNNR ContractNo,Contract.SYSTEM_STATUS
   from [SAPSR3].BUT000 Bp
 inner join 
 [SAPSR3].ADR2  BPContact
 on Bp.PERSNUMBER = BPContact.PERSNUMBER
 inner join [SAPSR3].BUT0ID BpID 
 on Bp.PARTNER = BpID.PARTNER
 inner join [SAPSR3].CVI_CUST_LINK BPCustomer
 on Bp.PARTNER_GUID = BPCustomer.PARTNER_GUID
  inner join [SAPSR3].[/CICRE/BU_PARTN] ContractBp
  on  Bp.PARTNER  =ContractBp.PARTNER
 inner join 
  [SAPSR3].[/CICRE/CONRACT] Contract
 on   ContractBp.INTRENO =Contract.INTRENO 
 inner join [SAPSR3].[/CICRE/BU_OBJECT] ContractRO
on Contract.INTRENO  = ContractRO.INTRENO
 inner join 
  [SAPSR3].[/CICRE/RU] RO
 on   ContractRO.RU_INTRENO =RO.INTRENO
  where Contract.SYSTEM_STATUS <>'CANC' and  BPContact.TEL_NUMBER='" + PhoneNo + "' and BPContact.PERSNUMBER <>'' ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["PARTNER"] != null)
                _PARTNER = objDr["PARTNER"].ToString();

            if (objDr.Table.Columns["CustomerFullName"] != null)
                _CustomerFullName = objDr["CustomerFullName"].ToString();

            if (objDr.Table.Columns["PERSNUMBER"] != null)
                _PERSNUMBER = objDr["PERSNUMBER"].ToString();

            if (objDr.Table.Columns["CUSTOMER"] != null)
                _CUSTOMER = objDr["CUSTOMER"].ToString();

            if (objDr.Table.Columns["IDNUMBER"] != null)
                _IDNUMBER = objDr["IDNUMBER"].ToString();

            if (objDr.Table.Columns["PhoneNo"] != null)
                _PhoneNo = objDr["PhoneNo"].ToString();

            if (objDr.Table.Columns["BE"] != null)
                _BE = objDr["BE"].ToString();

            if (objDr.Table.Columns["ROCode"] != null)
                _ROCode = objDr["ROCode"].ToString();
            int intTemp = 0;
            if (int.TryParse(_ROCode, out intTemp))
                _ROCode = intTemp.ToString();
            if (objDr.Table.Columns["ContractNo"] != null)
                _ContractNo = objDr["ContractNo"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
          
        }
        public void Edit()
        {
            string strSql = EditStr;
           
        }
        public void Delete()
        {
            string strSql = DeleteStr;
           
        }
        public DataTable Search()
        {
            string strSql = SearchStr ;


            return  BaseSybaseDb.ReturnDatatable(strSql); ;
        }
        public DataTable GetUserRO()
        {
            if (_UserIDStr == null)
                _UserIDStr = "";
            string[] arrIDs = _UserIDStr.Split('-');
           string strUserIDs = "";
            System.Collections.Hashtable hsTemp = new System.Collections.Hashtable();
            foreach(string strID in arrIDs)
            {
                if (hsTemp[strID] != null)
                    continue;
                hsTemp.Add(strID, strID);

                if (strUserIDs != "")
                    strUserIDs += ",";
                strUserIDs += "'" + strID + "'";
            }
                string strSql = @" select  Bp.PARTNER,Bp.NAME_FIRST+' '+Bp.NAME_LAST as CustomerFullName ,Bp.PERSNUMBER,BPCustomer.CUSTOMER ,RO.SWENR BE,RO.SMENR ROCode,Contract.RECNNR ContractNo,Contract.SYSTEM_STATUS
   from [SAPSR3].BUT000 Bp
 inner join [SAPSR3].CVI_CUST_LINK BPCustomer
 on Bp.PARTNER_GUID = BPCustomer.PARTNER_GUID
  inner join [SAPSR3].[/CICRE/BU_PARTN] ContractBp
  on  Bp.PARTNER  =ContractBp.PARTNER
 inner join 
  [SAPSR3].[/CICRE/CONRACT] Contract
 on   ContractBp.INTRENO =Contract.INTRENO 
 inner join [SAPSR3].[/CICRE/BU_OBJECT] ContractRO
on Contract.INTRENO  = ContractRO.INTRENO
 inner join 
  [SAPSR3].[/CICRE/RU] RO
 on   ContractRO.RU_INTRENO =RO.INTRENO
  where Contract.SYSTEM_STATUS <>'CANC' and  Bp.PARTNER in(" + strUserIDs + ") ";
  //          strSql = @" select  Bp.PARTNER,Bp.NAME_FIRST+' '+Bp.NAME_LAST as CustomerFullName ,Bp.PERSNUMBER 
  // from [SAPSR3].BUT000 Bp
  
  //where   Bp.PARTNER in(" + strUserIDs + ") ";
            return BaseSybaseDb.ReturnDatatable(strSql); ;
        }
        public DataTable GetQuery()
        {
            string strSql = "select count(*) as TotalCount,year(BKPFTable.CPUDT) as Year  from [SAPSR3].BKPF as BKPFTable  group by year(BKPFTable.CPUDT) ";
            strSql = "select count(*) as TotalCount,year(BKPFTable.ERDAT) as Year  from [SAPSR3].ESSR as BKPFTable  group by year(BKPFTable.ERDAT) ";
            strSql = @"select count(*) as TotalCount,year(MainTable.ERDAT) as Year  from [SAPSR3].ESSR as MainTable inner join  [SAPSR3].ESLL as DetailsTable 
   on MainTable.PACKNO = DetailsTable.PACKNO  
 group by year(MainTable.ERDAT) ";
            strSql = "select count(*) as TotalCount,year(BKPFTable.CPUDT) as Year  from [SAPSR3].BSAD as BKPFTable  group by year(BKPFTable.CPUDT) ";
            return BaseSybaseDb.ReturnDatatable(strSql); ;
        }
        #endregion
    }
}