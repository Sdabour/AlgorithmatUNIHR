using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementSalaryDetailsDb
    {
        #region Private Data
        protected int _OrginStatement;
        protected int _DetailType;
        protected double _DetailValue;
        protected double _DetailRecomendedValue;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementSalaryDetailsDb()
        {
        }
        public ApplicantWorkerStatementSalaryDetailsDb(DataRow objDr)
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
        public int DetailType
        {
            set
            {
                _DetailType = value;
            }
            get
            {
                return _DetailType;
            }
        }
        public double DetailValue
        {
            set
            {
                _DetailValue = value;
            }
            get
            {
                return _DetailValue;
            }
        }
        public double DetailRecomendedValue
        {
            set
            {
                _DetailRecomendedValue = value;
            }
            get
            {
                return _DetailRecomendedValue;
            }
        }
        public string AddStr
        {
            get
            {
                string Returned = " Insert Into HRApplicantWorkerStatementSalaryDetails " +
                                  " (OrginStatement,DetailType,DetailValue,DetailRecomendedValue, UsrIns, TimIns)"+
                                  " Values "+
                                  " (" + _OrginStatement + "," + _DetailType + "," + _DetailValue + "," + _DetailRecomendedValue + "," + SysData.CurrentUser.ID + ",GetDate())";
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
                string Returned = " Delete From ApplicantWorkerStatementSalaryDetails"+
                                  " Where OrginStatement ="+ _OrginStatement +" ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string Returned = " Select  HRApplicantWorkerStatementSalaryDetails.OrginStatement,HRApplicantWorkerStatementSalaryDetails.DetailType," +
                                  " HRApplicantWorkerStatementSalaryDetails.DetailValue,HRApplicantWorkerStatementSalaryDetails.DetailRecomendedValue,DetailTypeTable.* " +
                                  " From HRApplicantWorkerStatementSalaryDetails "+
                                 // " Left Outer Join (" + ApplicantWorkerStatementDb.SearchStr + ") as ApplicantWorkerStatemenTable On HRApplicantWorkerStatementSalaryDetails.OrginStatement=ApplicantWorkerStatemenTable.OriginStatementID"+
                                  " Left Outer Join (" + DetailTypeDb.SearchStr + ") as DetailTypeTable On DetailTypeTable.DetailTypeID = HRApplicantWorkerStatementSalaryDetails.DetailType";

                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _OrginStatement = int.Parse(objDr["OrginStatement"].ToString());
            _DetailType = int.Parse(objDr["DetailType"].ToString());
            _DetailValue = int.Parse(objDr["DetailValue"].ToString());
            _DetailRecomendedValue = int.Parse(objDr["DetailRecomendedValue"].ToString());
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
