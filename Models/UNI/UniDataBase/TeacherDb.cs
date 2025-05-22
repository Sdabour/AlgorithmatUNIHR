using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpVision.SystemBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class TeacherDb
    {

        #region Constructor
        public TeacherDb()
        {
        }
        public TeacherDb(DataRow objDr)
        {
            SetData(objDr);
        }

        #endregion
        #region Properties
        int _ID;
        public int ID
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
        string _Name;
        public string Name
        {
            set => _Name = value;
            get => _Name;
        }
        string _FamousName;
        public string FamousName
        {
            set => _FamousName = value;
            get => _FamousName;
        }
        string _ShortName;
        public string ShortName
        {
            set => _ShortName = value;
            get => _ShortName;
        }
        int _FunctionGroup;
        public int FunctionGroup
        {
            set => _FunctionGroup = value;
            get => _FunctionGroup;
        }
        int _Faculty;
        public int Faculty
        {
            set => _Faculty = value;
            get => _Faculty;
        }
        string _FacultyCode;
        public string FacultyCode
        {
            set => _FacultyCode = value;
            get => _FacultyCode;
        }
        string _FacultyNameA;
        public string FacultyNameA
        {
            set => _FacultyNameA = value;
            get => _FacultyNameA;
        }
        string _FacultyNameE;
        public string FacultyNameE
        {
            set => _FacultyNameE = value;
            get => _FacultyNameE;
        }
        int _Type;
        public int Type { set => _Type = value; }
        public string AddStr
        {
            get
            {
                string Returned = " insert into UNITeacher (TeacherID,TeacherCode,TeacherName,TeacherFamousName,TeacherShortName,TeacherFunctionGroup,TeacherFaculty,TeacherFacultyCode,TeacherFacultyNameA,TeacherFacultyNameE,UsrIns,TimIns) values (," + ID + ",'" + Code + "','" + Name + "','" + FamousName + "','" + ShortName + "'," + FunctionGroup + "," + Faculty + ",'" + FacultyCode + "','" + FacultyNameA + "','" + FacultyNameE + "'," + SysData.CurrentUser.ID + ",GetDate() ) ";
                return Returned;
            }
        }
        public string EditStr
        {
            get
            {
                string Returned = " update UNITeacher set " + "TeacherID=" + ID + "" +
           ",TeacherCode='" + Code + "'" +
           ",TeacherName='" + Name + "'" +
           ",TeacherFamousName='" + FamousName + "'" +
           ",TeacherShortName='" + ShortName + "'" +
           ",TeacherFunctionGroup=" + FunctionGroup + "" +
           ",TeacherFaculty=" + Faculty + "" +
           ",TeacherFacultyCode='" + FacultyCode + "'" +
           ",TeacherFacultyNameA='" + FacultyNameA + "'" +
           ",TeacherFacultyNameE='" + FacultyNameE + "'" + ",UsrUpd=" + SysData.CurrentUser.ID + @",TimUpd=GetDate()  where ";
                return Returned;
            }
        }
        public string DeleteStr
        {
            get
            {
                string Returned = " update UNITeacher set Dis = GetDate() where  ";
                return Returned;
            }
        }
        public string SearchStr
        {
            get
            {
                string Returned = @" SELECT dbo.HRApplicantWorker.ApplicantID AS TeacherID, dbo.HRApplicantWorker.ApplicantCode AS TeacherCode, dbo.HRApplicant.ApplicantFirstName AS TeacherName, 
                                    dbo.HRApplicant.ApplicantFamousName AS TeacherFamousName, dbo.HRApplicant.ApplicantShortName AS TeacherShortName, dbo.UNITeacher.TeacherFunctionGroup, dbo.UNIFaculty.FacultyID AS TeacherFaculty, 
                                    dbo.UNIFaculty.FacultyCode AS TeacherFacultyCode, dbo.UNIFaculty.FacultyNameA AS TeacherFacultyNameA, dbo.UNIFaculty.FacultyNameE AS TeacherFacultyNameE,TypeTable.* 
                  FROM      dbo.UNIFaculty INNER JOIN
                                    dbo.UNITeacher INNER JOIN
                                    dbo.HRApplicantWorker INNER JOIN
                                    dbo.HRApplicant ON dbo.HRApplicantWorker.ApplicantID = dbo.HRApplicant.ApplicantID ON dbo.UNITeacher.TeacherID = dbo.HRApplicant.ApplicantID INNER JOIN
                                    dbo.UNITeacherType ON dbo.UNITeacher.TeacherType = dbo.UNITeacherType.TeacherTypeID ON dbo.UNIFaculty.FacultyID = dbo.UNITeacher.TeacherFaculty 
 inner join ("+new TeacherTypeDb().SearchStr+@") as TypeTable on UNITeacher.TeacherType=TypeTable.TeacherTypeID ";
                return Returned;
            }
        }
        #endregion
        #region Private Method
        void SetData(DataRow objDr)
        {

            if (objDr.Table.Columns["TeacherID"] != null)
                int.TryParse(objDr["TeacherID"].ToString(), out _ID);

            if (objDr.Table.Columns["TeacherCode"] != null)
                _Code = objDr["TeacherCode"].ToString();

            if (objDr.Table.Columns["TeacherName"] != null)
                _Name = objDr["TeacherName"].ToString();

            if (objDr.Table.Columns["TeacherFamousName"] != null)
                _FamousName = objDr["TeacherFamousName"].ToString();

            if (objDr.Table.Columns["TeacherShortName"] != null)
                _ShortName = objDr["TeacherShortName"].ToString();

            if (objDr.Table.Columns["TeacherFunctionGroup"] != null)
                int.TryParse(objDr["TeacherFunctionGroup"].ToString(), out _FunctionGroup);

            if (objDr.Table.Columns["TeacherFaculty"] != null)
                int.TryParse(objDr["TeacherFaculty"].ToString(), out _Faculty);

            if (objDr.Table.Columns["TeacherFacultyCode"] != null)
                _FacultyCode = objDr["TeacherFacultyCode"].ToString();

            if (objDr.Table.Columns["TeacherFacultyNameA"] != null)
                _FacultyNameA = objDr["TeacherFacultyNameA"].ToString();

            if (objDr.Table.Columns["TeacherFacultyNameE"] != null)
                _FacultyNameE = objDr["TeacherFacultyNameE"].ToString();
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
            string strSql = SearchStr + @" where (dbo.HRApplicantWorker.ApplicantStatusID=1) ";

            if (_Type != 0)
                strSql += " and (TypeTable.TeacherTypeID = "+_Type+")";
            if (_Faculty != 0)
                strSql += " and (dbo.UNIFaculty.FacultyID= " + _Faculty + ")";
            if (_Code != null && _Code != "")
                strSql += @" and (dbo.HRApplicantWorker.ApplicantCode like '%"+_Code+@"%'
 or isnull(dbo.HRApplicant.ApplicantFirstName,'') like '%"+_Code+ @"%'
 or isnull(dbo.HRApplicant.ApplicantFamousName,'')  like '%" + _Code + @"%'
or isnull(dbo.HRApplicant.ApplicantShortName,'')  like '%" + _Code + @"%'
 )";
            return SysData.SharpVisionBaseDb.ReturnDatatable(strSql);
        }
        #endregion
    }
}