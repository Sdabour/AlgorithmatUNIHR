using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementSubSectorDb
    {
        #region Private Data
        protected int _OrginStatement;
        protected int _SubSector;
        #endregion
        #region Constructors
         public ApplicantWorkerStatementSubSectorDb()
        {
        }
        public ApplicantWorkerStatementSubSectorDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int OrginStatement
        {
            set
            {
                _OrginStatement = value;
            }
            get
            {
                return _OrginStatement;
            }
        }
        public int SubSector
        {
            set
            {
                _SubSector = value;
            }
            get
            {
                return _SubSector;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " Insert Into HRApplicantWorkerStatementSubSector " +
                                  " (OrginStatement,SubSector,UsrIns, TimIns)" +
                                  " Values " +
                                  " (" + _OrginStatement + "," + _SubSector + "," + SysData.CurrentUser.ID + ",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " Delete From HRApplicantWorkerStatementSubSector" +
                                  " Where OrginStatement =" + _OrginStatement + " ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " Select  HRApplicantWorkerStatementSubSector.StatementSubsectorID"+
                    ",HRApplicantWorkerStatementSubSector.OrginStatement,HRApplicantWorkerStatementSubSector.SubSector," +
                                  " SubSectorTable.* " +
                                  " From HRApplicantWorkerStatementSubSector " +                   
                                  " Left Outer Join (" + SubSectorDb.SearchStr + ") as SubSectorTable On SubSectorTable.SubSectorID = HRApplicantWorkerStatementSubSector.SubSector";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            if (objDr["OrginStatement"].ToString() == "")
                return;
            _OrginStatement = int.Parse(objDr["OrginStatement"].ToString());
            _SubSector = int.Parse(objDr["SubSector"].ToString());
            
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(AddStr);
        }
        public void Edit()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(EditStr);
        }
        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {
            string StrSql = SearchStr + " Where 1=1 ";
            if (_OrginStatement != 0)
                StrSql = StrSql + " And OrginStatement = " + _OrginStatement + "";


            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
        #endregion
    }
}
