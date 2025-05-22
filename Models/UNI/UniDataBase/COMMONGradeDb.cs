using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class COMMONGradeDb
    {

        #region Constructor
        public COMMONGradeDb()
        {
        }
        public COMMONGradeDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _Faculty;
        public int Faculty { set => _Faculty = value; get => _Faculty; }
        int _MinPerc;
        public int MinPerc
        {
            set => _MinPerc = value;
            get => _MinPerc;
        }
        int _MaxPerc;
        public int MaxPerc
        {
            set => _MaxPerc = value;
            get => _MaxPerc;
        }
        string _Verbal;
        public string Verbal
        {
            set => _Verbal = value;
            get => _Verbal;
        }
        double _Points;
        public double Points
        {
            set => _Points = value;
            get => _Points;
        }
        double _MaxPoints;
        public double MaxPoints
        {
            set => _MaxPoints = value;
            get => _MaxPoints;
        }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNICOMMONGrade (GradeMinPerc,GradeMaxPerc,GradeVerbal,GradePoints,UsrIns,TimIns) values (," + MinPerc + "," + MaxPerc + ",'" + Verbal + "'," + Points + "," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNICOMMONGrade set " + "GradeMinPerc=" + MinPerc + "" +
           ",GradeMaxPerc=" + MaxPerc + "" +
           ",GradeVerbal='" + Verbal + "'" +
           ",GradePoints=" + Points + "" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNICOMMONGrade set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = " select GradeFaculty,GradeMinPerc,GradeMaxPerc,GradeVerbal,GradePoints,GradeMaxPoints  from UNICOMMONGrade  ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["GradeMinPerc"] != null)
                int.TryParse(objDr["GradeMinPerc"].ToString(), out _MinPerc);

            if (objDr.Table.Columns["GradeMaxPerc"] != null)
                int.TryParse(objDr["GradeMaxPerc"].ToString(), out _MaxPerc);

            if (objDr.Table.Columns["GradeVerbal"] != null)
                _Verbal = objDr["GradeVerbal"].ToString();

            if (objDr.Table.Columns["GradePoints"] != null)
                double.TryParse(objDr["GradePoints"].ToString(), out _Points);
            if (objDr.Table.Columns["GradeMaxPoints"] != null)
                double.TryParse(objDr["GradeMaxPoints"].ToString(), out _MaxPoints);
            if (objDr.Table.Columns["GradeFaculty"] != null)
                int.TryParse(objDr["GradeFaculty"].ToString(), out _Faculty);
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
            string strSql = SearchStr + " where (1=1) ";


            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}