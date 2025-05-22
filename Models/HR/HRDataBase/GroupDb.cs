using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class MSGGroupDb
    {

        #region Constructor
        public MSGGroupDb()
        {
        }
        public MSGGroupDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        double _ID;
        public double ID
        {
            set => _ID = value;
            get => _ID;
        }
        string _Code;
        public string Code
        {
            set => _Code = value;
            get => _Code;
        }
        DateTime _EstablishDate;
        public DateTime EstablishDate
        {
            set => _EstablishDate = value;
            get => _EstablishDate;
        }
        string _NameA;
        public string NameA
        {
            set => _NameA = value;
            get => _NameA;
        }
        string _NameE;
        public string NameE
        {
            set => _NameE = value;
            get => _NameE;
        }
        string _Desc;
        public string Desc
        {
            set => _Desc = value;
            get => _Desc;
        }

        string _ApplicantIDs;
        public string ApplicantIDs
        {
            set => _ApplicantIDs = value;
        }
        public string AddStr
        {
            get
            {
                string Returned = @"
declare @ID int;
 
insert into HRGroup (GroupCode,GroupEstablishDate,GroupNameA,GroupNameE,GroupDesc,UsrIns,TimIns) values ('" + Code + "',GetDate(),'" + NameA + "','" + NameE + "','" + Desc + "'," + SysData.CurrentUser.ID + @",GetDate() )
  set @ID = (select @@IDENTITY);";
                Returned += JoinApplicantStr;
                return Returned;
            }
        }
        public string JoinApplicantStr
        {
            get
            {
                if (_ApplicantIDs == null || _ApplicantIDs == "")
                    return "";
                string strGroupID = ID == 0 ? "@ID" : ID.ToString();
                string strSql = @" insert into HRGroupApplicant (MSGGroup,MSGGroupApplicant) 
   SELECT " + strGroupID + @" AS GroupID1, ApplicantID
 FROM     dbo.HRApplicantWorker
WHERE  (ApplicantStatusID = 1) AND (ApplicantID IN (" + _ApplicantIDs + "))";
                return strSql;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update HRGroup set " + "GroupID=" + ID + "" +
           ",GroupCode='" + Code + "'" +
           ",GroupEstablishDate=" + (EstablishDate.ToOADate() - 2).ToString() + "" +
           ",GroupNameA='" + NameA + "'" +
           ",GroupNameE='" + NameE + "'" +
           ",GroupDesc='" + Desc + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update HRGroup set Dis = GetDate() where  GroupID="+_ID;
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select GroupID,GroupCode,GroupEstablishDate,GroupNameA,GroupNameE,GroupDesc from HRGroup  ";
                if (_ApplicantIDs == null)
                    _ApplicantIDs = "";
                string strApp = @" SELECT DISTINCT MSGGroup
FROM     dbo.HRGroupApplicant
WHERE  (MSGGroup > 0) AND (MSGGroupApplicant IN ("+_ApplicantIDs+"))";
                if (_ApplicantIDs != null && _ApplicantIDs != "")
                    Returned += " inner join ("+strApp+@") as ApplicantTable 
  on HRGroup.GroupID = ApplicantTable.MSGGroup ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["GroupID"] != null)
                double.TryParse(objDr["GroupID"].ToString(), out _ID);

            if (objDr.Table.Columns["GroupCode"] != null)
                _Code = objDr["GroupCode"].ToString();

            if (objDr.Table.Columns["GroupEstablishDate"] != null)
                DateTime.TryParse(objDr["GroupEstablishDate"].ToString(), out _EstablishDate);

            if (objDr.Table.Columns["GroupNameA"] != null)
                _NameA = objDr["GroupNameA"].ToString();

            if (objDr.Table.Columns["GroupNameE"] != null)
                _NameE = objDr["GroupNameE"].ToString();

            if (objDr.Table.Columns["GroupDesc"] != null)
                _Desc = objDr["GroupDesc"].ToString();
        }

        #endregion
        #region Public Method 
        public void Add()
        {
            string strSql = AddStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Edit()
        {
            string strSql = EditStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public void Delete()
        {
            string strSql = DeleteStr;
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);
        }
        public DataTable Search()
        {
            string strSql = SearchStr + " where Dis is null ";
         


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        public void JoinApplicant()
        {
            if (_ApplicantIDs == null || _ApplicantIDs == "")
                return;
            string strGroupID = ID == 0 ? "@ID" : ID.ToString();
            string strSql = @" insert into HRGroupApplicant (MSGGroup,MSGGroupApplicant) 
   SELECT "+strGroupID+@" AS GroupID1, ApplicantID
 FROM     dbo.HRApplicantWorker
WHERE  (ApplicantStatusID = 1) AND (ApplicantID IN ("+ _ApplicantIDs +"))";


        }
        #endregion
    }
}