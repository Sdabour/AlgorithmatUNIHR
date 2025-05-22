using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.Milango.MilangoDb
{
    public class MilangoRequestDb
    {

        #region Constructor
        public MilangoRequestDb()
        {
        }
        public MilangoRequestDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        string _ProjectCode;
        public string ProjectCode
        {
            set => _ProjectCode = value;
            get => _ProjectCode;
        }
        string _UnitCode;
        public string UnitCode
        {
            set => _UnitCode = value;
            get => _UnitCode;
        }
        string _SAPPartner;
        public string SAPPartner
        {
            set => _SAPPartner = value;
            get => _SAPPartner;
        }
        int _CategoryID;
        public int CategoryID
        {
            set => _CategoryID = value;
            get => _CategoryID;
        }
        string _CategoryNameA;
        public string CategoryNameA
        {
            set => _CategoryNameA = value;
            get => _CategoryNameA;
        }
        string _CategoryNameE;
        public string CategoryNameE
        {
            set => _CategoryNameE = value;
            get => _CategoryNameE;
        }
        int _ServiceID;
        public int ServiceID
        {
            set => _ServiceID = value;
            get => _ServiceID;
        }
        string _ServiceNameA;
        public string ServiceNameA
        {
            set => _ServiceNameA = value;
            get => _ServiceNameA;
        }
        string _ServiceNameE;
        public string ServiceNameE
        {
            set => _ServiceNameE = value;
            get => _ServiceNameE;
        }
        DateTime _SubmitDate;
        public DateTime SubmitDate
        {
            set => _SubmitDate = value;
            get => _SubmitDate;
        }
        string _Summary;
        public string Summary
        {
            set => _Summary = value;
            get => _Summary;
        }
        string _Description;
        public string Description
        {
            set => _Description = value;
            get => _Description;
        }
        string _StatusCode;
        public string StatusCode
        {
            set => _StatusCode = value;
            get => _StatusCode;
        }
        string _StatusNameA;
        public string StatusNameA
        {
            set => _StatusNameA = value;
            get => _StatusNameA;
        }
        string _StatusNameE;
        public string StatusNameE
        {
            set => _StatusNameE = value;
            get => _StatusNameE;
        }
        string _StatusNote;
        public string StatusNote
        {
            set => _StatusNote = value;
            get => _StatusNote;
        }
        DateTime _StatusDT;
        public DateTime StatusDT
        {
            set => _StatusDT = value;
            get => _StatusDT;
        }
        bool _Done;
        public bool Done
        {
            set => _Done = value;
            get => _Done;
        }
        string _BpStr;
        public string BpStr { set => _BpStr = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into VMilangoBPRequest (ProjectCode,UnitCode,SAPPartner,CategoryID,CategoryNameA,CategoryNameE,ServiceID,ServiceNameA,ServiceNameE,SubmitDate,Summary,Description,StatusCode,StatusNameA,StatusNameE,StatusNote,StatusDT,Done,UsrIns,TimIns) values (,'" + ProjectCode + "','" + UnitCode + "','" + SAPPartner + "'," + CategoryID + ",'" + CategoryNameA + "','" + CategoryNameE + "'," + ServiceID + ",'" + ServiceNameA + "','" + ServiceNameE + "'," + (SubmitDate.ToOADate() - 2).ToString() + ",'" + Summary + "','" + Description + "','" + StatusCode + "','" + StatusNameA + "','" + StatusNameE + "','" + StatusNote + "'," + (StatusDT.ToOADate() - 2).ToString() + "," + (Done ? 1 : 0) + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update VMilangoBPRequest set " + "ProjectCode='" + ProjectCode + "'" +
           ",UnitCode='" + UnitCode + "'" +
           ",SAPPartner='" + SAPPartner + "'" +
           ",CategoryID=" + CategoryID + "" +
           ",CategoryNameA='" + CategoryNameA + "'" +
           ",CategoryNameE='" + CategoryNameE + "'" +
           ",ServiceID=" + ServiceID + "" +
           ",ServiceNameA='" + ServiceNameA + "'" +
           ",ServiceNameE='" + ServiceNameE + "'" +
           ",SubmitDate=" + (SubmitDate.ToOADate() - 2).ToString() + "" +
           ",Summary='" + Summary + "'" +
           ",Description='" + Description + "'" +
           ",StatusCode='" + StatusCode + "'" +
           ",StatusNameA='" + StatusNameA + "'" +
           ",StatusNameE='" + StatusNameE + "'" +
           ",StatusNote='" + StatusNote + "'" +
           ",StatusDT=" + (StatusDT.ToOADate() - 2).ToString() + "" +
           ",Done=" + (Done ? 1 : 0) + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update VMilangoBPRequest set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select ProjectCode,UnitCode,SAPPartner,CategoryID,CategoryNameA,CategoryNameE,ServiceID,ServiceNameA,ServiceNameE,SubmitDate,Summary,Description,StatusCode,StatusNameA,StatusNameE,StatusNote,StatusDT,Done from VMilangoBPRequest  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["ProjectCode"] != null)
                _ProjectCode = objDr["ProjectCode"].ToString();

            if (objDr.Table.Columns["UnitCode"] != null)
                _UnitCode = objDr["UnitCode"].ToString();

            if (objDr.Table.Columns["SAPPartner"] != null)
                _SAPPartner = objDr["SAPPartner"].ToString();

            if (objDr.Table.Columns["CategoryID"] != null)
                int.TryParse(objDr["CategoryID"].ToString(), out _CategoryID);

            if (objDr.Table.Columns["CategoryNameA"] != null)
                _CategoryNameA = objDr["CategoryNameA"].ToString();

            if (objDr.Table.Columns["CategoryNameE"] != null)
                _CategoryNameE = objDr["CategoryNameE"].ToString();

            if (objDr.Table.Columns["ServiceID"] != null)
                int.TryParse(objDr["ServiceID"].ToString(), out _ServiceID);

            if (objDr.Table.Columns["ServiceNameA"] != null)
                _ServiceNameA = objDr["ServiceNameA"].ToString();

            if (objDr.Table.Columns["ServiceNameE"] != null)
                _ServiceNameE = objDr["ServiceNameE"].ToString();

            if (objDr.Table.Columns["SubmitDate"] != null)
                DateTime.TryParse(objDr["SubmitDate"].ToString(), out _SubmitDate);

            if (objDr.Table.Columns["Summary"] != null)
                _Summary = objDr["Summary"].ToString();

            if (objDr.Table.Columns["Description"] != null)
                _Description = objDr["Description"].ToString();

            if (objDr.Table.Columns["StatusCode"] != null)
                _StatusCode = objDr["StatusCode"].ToString();

            if (objDr.Table.Columns["StatusNameA"] != null)
                _StatusNameA = objDr["StatusNameA"].ToString();

            if (objDr.Table.Columns["StatusNameE"] != null)
                _StatusNameE = objDr["StatusNameE"].ToString();

            if (objDr.Table.Columns["StatusNote"] != null)
                _StatusNote = objDr["StatusNote"].ToString();

            if (objDr.Table.Columns["StatusDT"] != null)
                DateTime.TryParse(objDr["StatusDT"].ToString(), out _StatusDT);

            if (objDr.Table.Columns["Done"] != null)
                bool.TryParse(objDr["Done"].ToString(), out _Done);
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
            string strSql = SearchStr + " where (SAPPartner in ("+_BpStr+")) ";


            return SysData.MilngoServiceBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}