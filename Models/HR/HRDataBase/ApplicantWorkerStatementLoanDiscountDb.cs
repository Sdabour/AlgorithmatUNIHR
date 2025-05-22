using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
namespace SharpVision.HR.HRDataBase
{
    public class ApplicantWorkerStatementLoanDiscountDb
    {
        #region Private Data
        protected int _ID;
        protected int _Statement;
        protected int _Loan;
        string _LoanIDs;

       
        protected double _Value;
        protected int _GlobalStatementSearch;
        protected int _ApplicantSearch;
        protected string _ApplicantIDs;
        int _NotGreaterThanIDSearch;
        int _GlobalStatement;
        string _GlobalStatementDesc;
        DateTime _GlobalStatementDate;

      

        #endregion
        #region Constructors
        public ApplicantWorkerStatementLoanDiscountDb()
        {
        }
        public ApplicantWorkerStatementLoanDiscountDb(DataRow objDr)
        {
            SetData(objDr);
        }
        #endregion
        #region Public Properties
        public int ID
        {
            set
            {
                _ID = value;
            }
            get
            {
                return _ID;
            }
        }
        public int Statement
        {
            set
            {
                _Statement = value;
            }
            get
            {
                return _Statement;
            }
        }
        public int Loan
        {
            set
            {
                _Loan = value;
            }
            get
            {
                return _Loan;
            }
        }
        public string LoanIDs
        {
            get { return _LoanIDs; }
            set { _LoanIDs = value; }
        }
        public double Value
        {
            set
            {
                _Value = value;
            }
            get
            {
                return _Value;
            }
        }
        public DateTime GlobalStatementDate
        {
            get { return _GlobalStatementDate; }
            set { _GlobalStatementDate = value; }
        }
        public string GlobalStatementDesc
        {
            get { return _GlobalStatementDesc; }
            set { _GlobalStatementDesc = value; }
        }
        public int GlobalStatement
        {
            get { return _GlobalStatement; }
            set { _GlobalStatement = value; }
        }
        public int GlobalStatementSearch
        {
            set
            {
                _GlobalStatementSearch = value;
            }
        }
        public int NotGreaterThanIDSearch
        {
            set
            {
                _NotGreaterThanIDSearch = value;
            }
        }
        public int ApplicantSearch
        {
            set
            {
                _ApplicantSearch = value;
            }
        }
        public string ApplicantIDs
        {
            set
            {
                _ApplicantIDs = value;
            }

        }
        public string AddStr
        {
            get
            {
                string Returned = " INSERT INTO HRApplicantWorkerStatementLoanDiscount"+
                                  " (DiscountStatement, DiscountLoan, DiscountValue, UsrIns, TimIns)"+
                                  " VALUES ("+
                                  "" + _Statement+"," + _Loan +"," +
                                  "" + _Value +"," + SysData.CurrentUser.ID +",GetDate())";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " UPDATE    HRApplicantWorkerStatementLoanDiscount"+
                                  " SET DiscountStatement =" + _Statement + "" +
                                  " ,DiscountLoan =" + _Loan + "" +
                                  " ,DiscountValue =" + _Value + "" +
                                  " ,UsrUpd =" + SysData.CurrentUser.ID + ", TimUpd =GetDate()" +
                                  " WHERE (DiscountID = "+ _ID +")";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " DELETE FROM HRApplicantWorkerStatementLoanDiscount"+
                                  " WHERE     (DiscountID = " + _ID + ") And (DiscountStatement = "+ _Statement +")";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {
                string strStatement = "SELECT  dbo.HRApplicantWorkerStatement.OriginStatementID AS DiscountOriginStatement, dbo.HRApplicantWorkerStatement.GlobalStatment AS DiscountGlobalStatement, "+
                      " dbo.HRGlobalStatement.StatementDesc AS DiscountStatementDesc, dbo.HRGlobalStatement.StatementDate AS DiscountStatementDate "+
                      " FROM         dbo.HRApplicantWorkerStatement INNER JOIN "+
                      " dbo.HRGlobalStatement ON dbo.HRApplicantWorkerStatement.GlobalStatment = dbo.HRGlobalStatement.StatementID"; 
                string Returned = " SELECT     HRApplicantWorkerStatementLoanDiscount.DiscountID, HRApplicantWorkerStatementLoanDiscount.DiscountStatement,"+
                                  " HRApplicantWorkerStatementLoanDiscount.DiscountLoan, HRApplicantWorkerStatementLoanDiscount.DiscountValue,ApplicantWorkerLoanTable.*,ApplicantWorkerStatementTable.* " +
                                  " FROM         HRApplicantWorkerStatementLoanDiscount "+
                                  " Inner Join (" + ApplicantWorkerLoanDb.SearchStr + ") as ApplicantWorkerLoanTable "+
                                  " ON HRApplicantWorkerStatementLoanDiscount.DiscountLoan =  ApplicantWorkerLoanTable.LoanID"+
                                  " Inner Join (" + strStatement + ") as ApplicantWorkerStatementTable " +
                                  " ON HRApplicantWorkerStatementLoanDiscount.DiscountStatement =  ApplicantWorkerStatementTable.DiscountOriginStatement ";
                return Returned;
            }
        }
        #endregion
        #region Private Methods
        void SetData(DataRow objDr)
        {
            _ID = int.Parse(objDr["DiscountID"].ToString());
            _Statement = int.Parse(objDr["DiscountStatement"].ToString());
            _Loan = int.Parse(objDr["DiscountLoan"].ToString());
            _Value = double.Parse(objDr["DiscountValue"].ToString());
            if (objDr.Table.Columns["DiscountGlobalStatement"] != null && objDr["DiscountGlobalStatement"].ToString() != "")
                _GlobalStatement = int.Parse(objDr["DiscountGlobalStatement"].ToString());
            if (objDr.Table.Columns["DiscountStatementDesc"] != null)
                _GlobalStatementDesc = objDr["DiscountStatementDesc"].ToString();
            if (objDr.Table.Columns["DiscountStatementDate"] != null && objDr["DiscountStatementDate"].ToString() != "")
                _GlobalStatementDate = DateTime.Parse(objDr["DiscountStatementDate"].ToString());
           
        }
        #endregion
        #region Public Methods
        public void Add()
        {
            _ID = SysData.SharpVisionBaseDb.InsertIdentityTable(AddStr);
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
            if (_ID != 0)
                StrSql = StrSql + " And DiscountID = " + _ID + "";
            if (_Statement != 0)
                StrSql = StrSql + " And DiscountStatement = " + _Statement + "";

            if (_NotGreaterThanIDSearch != 0)
                StrSql = StrSql + " And DiscountStatement <= " + _NotGreaterThanIDSearch + "";

            if (_Loan != 0)
                StrSql = StrSql + " And DiscountLoan = " + _Loan + "";
            if (_LoanIDs != null && _LoanIDs!= "")
                StrSql = StrSql + " And DiscountLoan in  (" + _LoanIDs + ")";
            if (_GlobalStatementSearch != 0)
                StrSql = StrSql + " And ApplicantWorkerStatementTable.DiscountGlobalStatement = " + _GlobalStatementSearch + "";
            if (_ApplicantSearch != 0)
                StrSql = StrSql + " And ApplicantWorkerLoanTable.ApplicantID = " + _ApplicantSearch + "";
            if (_ApplicantIDs != null && _ApplicantIDs!="")
                StrSql = StrSql + " And ApplicantWorkerLoanTable.ApplicantID in ( " + _ApplicantIDs + ")";

            StrSql += " Order By ApplicantWorkerLoanTable.LoanRequestDate";
            return SysData.SharpVisionBaseDb.ReturnDatatable(StrSql);
        }
       
        #endregion
    }
}
