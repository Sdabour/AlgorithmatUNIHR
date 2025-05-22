using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using SharpVision.GL.GLDataBase;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class StudentDiscountDb
    {
        #region Private Data
        int _ID;
        int _StudentID;
        double _Value;
        string _Reason;
        DateTime _Date;
        bool _Scheduled;
        int _TypeID;
        string _StudentIDs;

        #region Private Data For Student
        protected bool _IsDateRange;
        protected DateTime _DateFrom;
        protected DateTime _DateTo;

        
         

        protected double _ValFrom;
        protected double _ValTo;

        protected bool _IsDiscountdateRange;
        protected DateTime _DiscountDateFrom;
        protected DateTime _DiscountDateTo;

        #endregion

        #endregion

        #region Constructors
        public StudentDiscountDb()
        {

        }
        public StudentDiscountDb(int intID)
        {
            _ID = intID;
            DataTable dtTemp = Search();
            DataRow objDR = dtTemp.Rows[0];
            _StudentID = int.Parse(objDR["StudentID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());
        }
        public StudentDiscountDb(DataRow objDR)
        {
            _ID = int.Parse(objDR["DiscountID"].ToString());
            _StudentID = int.Parse(objDR["StudentID"].ToString());
            _Reason = objDR["DiscountReason"].ToString();
            _Date = DateTime.Parse(objDR["DiscountDate"].ToString());
            _Value = double.Parse(objDR["DiscountValue"].ToString());
            _Scheduled = bool.Parse(objDR["Scheduled"].ToString());
            _TypeID = int.Parse(objDR["TypeID"].ToString());


        }
        #endregion

        #region Public Properties
        public DateTime Date
        {
            set
            {
                _Date = value;
            }
            get
            {
                return _Date;
            }

        }
        public string Reason
        {
            set
            {
                _Reason = value;
            }
            get
            {
                return _Reason;
            }

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

        public int StudentID
        {
            set
            {
                _StudentID = value;
            }
            get
            {
                return _StudentID;
            }

        }

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
        public bool Scheduled
        {
            set
            {
                _Scheduled = value;
            }
            get
            {
                return _Scheduled;
            }

        }
        public int TypeID
        {
            set
            {
                _TypeID = value;
            }
            get
            {
                return _TypeID;
            }
        }
        public string StudentIDs
        {
            set
            {
                _StudentIDs = value;
            }
            get
            {
                return _StudentIDs;
            }
        }

        public bool IsDateRange
        {
            set
            {
                _IsDateRange = value;
            }
            get
            {
                return _IsDateRange;
            }
        }
        public DateTime DateFrom
        {
            set
            {
                _DateFrom = value;
            }
        }
        public DateTime DateTo
        {
            set
            {
                _DateTo = value;
            }
        }


       

        public double ValFrom
        {
            set
            {
                _ValFrom = value;
            }
            get
            {
                return _ValFrom;

            }
        }
        public double ValTo
        {
            set
            {
                _ValTo = value;
            }
            get
            {
                return _ValTo;
            }
        }

        public bool IsDiscountdateRange
        {
            set
            {
                _IsDiscountdateRange = value;
            }
            get
            {
                return _IsDiscountdateRange;
            }
        }
        public DateTime DiscountDateFrom
        {
            set
            {
                _DiscountDateFrom = value;
            }
            get
            {
                return _DiscountDateFrom;
            }
        }
        public DateTime DiscountDateTo
        {
            set
            {
                _DiscountDateTo = value;
            }
            get
            {
                return _DiscountDateTo;
            }
        }

        public string AddStr
        {
            get
            {
                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " INSERT INTO CRMStudentDiscount" +
                                " ( StudentID, DiscountValue, DiscountReason, DiscountDate,Scheduled,TypeID)" +
                                " VALUES     (" + _StudentID + "," + _Value + ",'" + _Reason + "'," + dblDate + "," + intScheduled + "," + _TypeID + ") ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {

                int intScheduled = _Scheduled ? 1 : 0;
                double dblDate = _Date.ToOADate() - 2;
                string Returned = " UPDATE    CRMStudentDiscount" +
                                " SET   DiscountValue =" + _Value + "" +
                                " , Scheduled = " + intScheduled + "" +
                                " , TypeID = " + _TypeID + "" +
                                " , DiscountReason ='" + _Reason + "'" +
                                " , DiscountDate =" + dblDate + "" +
                                " WHERE   StudentID = " + _StudentID + " and  (DiscountID = " + _ID + ") ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {

                string Returned = " DELETE FROM CRMStudentDiscount  WHERE  StudentID  =" + _StudentID + " and  (DiscountID = " + _ID + ") ";
                return Returned;
            }
        }
        public static string SearchStr
        {
            get
            {

                string Returned = " SELECT     CRMStudentDiscount.DiscountID, CRMStudentDiscount.StudentID, CRMStudentDiscount.DiscountValue, " +
                                   " CRMStudentDiscount.DiscountReason, CRMStudentDiscount.DiscountDate, CRMStudentDiscount.Scheduled, " +
                                   " CRMStudentDiscount.TypeID,DiscountTypeTable.*" +
                                   " FROM         CRMStudentDiscount LEFT OUTER JOIN" +
                                   " (" + DiscountTypeDb.SearchStr + ") as DiscountTypeTable ON CRMStudentDiscount.TypeID = DiscountTypeTable.DiscountTypeID ";
                return Returned;
            }
        }
        #endregion

        #region Private Methods

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

        public void Schedul()
        {
            int intSchedul = _Scheduled ? 1 : 0;
            string strSql = "  UPDATE    CRMStudentDiscount" +
                            " SET   Scheduled =" + _Scheduled + "" +
                            " WHERE     (StudentID = " + _StudentID + ") AND (DiscountID = " + _ID + ") ";
            SysData.SharpVisionBaseDb.ExecuteNonQuery(strSql);

        }

        public void Delete()
        {
            SysData.SharpVisionBaseDb.ExecuteNonQuery(DeleteStr);
        }
        public DataTable Search()
        {

            double dblDateFrom = _DateFrom.ToOADate() - 2;
            int TempStartDate = (int)dblDateFrom;
            double dblDateTimeto = _DateTo.ToOADate() - 2;
            int TempEndDate = (int)dblDateTimeto;

            
           



            double dblDiscountDateFrom = _DiscountDateFrom.ToOADate() - 2;
            int TempDiscountDateFrom = (int)dblDiscountDateFrom;
            double dblDiscountDateTo = _DiscountDateTo.ToOADate() - 2;
            int TempDiscountDateTo = (int)dblDiscountDateTo;


            string strSql = SearchStr + " WHERE    (1=1) ";
            if (_ID != 0)
                strSql = strSql + " and DiscountID = " + _ID.ToString();
            if (_StudentID != 0)
                strSql = strSql + " and StudentID = " + _StudentID.ToString();
            else if (_StudentIDs != null && _StudentIDs != "")
                strSql = strSql + " and StudentID  in (" + _StudentIDs + ") ";
            if (_TypeID != 0)
                strSql = strSql + " and TypeID = " + _TypeID + " ";
            if (_ValTo != 0 && _ValFrom != 0)
                strSql = strSql + " and  CRMStudentDiscount.DiscountValue >= " + _ValFrom + " and CRMStudentDiscount.DiscountValue <= " + _ValTo + "";
            if (_IsDiscountdateRange)
                strSql = strSql + " and Convert(float,CRMStudentDiscount.DiscountDate) >= " + TempDiscountDateFrom + " and Convert(float,CRMStudentDiscount.DiscountDate) < " + TempDiscountDateTo + " ";

           


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql, "Discount");


        }
        #endregion
    }
}