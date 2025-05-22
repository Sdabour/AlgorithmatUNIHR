using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Collections;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public enum SemesterType { NotSpecified,Fall,Spring,Summer,EQ=5}
    public class SemesterBiz
    {

        #region Constructor
        public SemesterBiz()
        {
            _SemesterDb = new SemesterDb();
        }
        public SemesterBiz(DataRow objDr)
        {
            _SemesterDb = new SemesterDb(objDr);
        }

        #endregion
        #region Private Data
        SemesterDb _SemesterDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _SemesterDb.ID = value;
            get => _SemesterDb.ID;
        }
        public string Desc
        {
            set => _SemesterDb.Desc = value;
            get => _SemesterDb.Desc;
        }
        public DateTime DateStart
        {
            set => _SemesterDb.DateStart = value;
            get => _SemesterDb.DateStart;
        }
        public DateTime DateEnd
        {
            set => _SemesterDb.DateEnd = value;
            get => _SemesterDb.DateEnd;
        }

        public static int MaxSemester
        {
            get => SemesterDb.MaxSemester();
        }
        public int MaxStatementID
        {
            get => _SemesterDb.MaxStatementID;
        }
        public SemesterType Type
        {
            set => _SemesterDb.Type = (int)value;
            get => (SemesterType)_SemesterDb.Type;
        }
        public static SemesterBiz LastSemesterBiz
        {
            get
            {
                SemesterBiz Returned = new SemesterBiz();
                DataTable dtTemp = new SemesterDb().GetLastSemester();
                if(dtTemp.Rows.Count>0)
                {
                    Returned = new SemesterBiz(dtTemp.Rows[0]);
                }
                return Returned;
            }
        }
        RegisterationCol _RegisterationCol;
        public RegisterationCol REgisterationCol
        {
            set => _RegisterationCol = value;
            get
            {
                if (_RegisterationCol == null)
                    _RegisterationCol = new RegisterationCol(true,0);
                return _RegisterationCol;
            }
        }
        public Hashtable StoppedStudentHash
        {
            get
            {
                Hashtable Returned = new Hashtable();
                if(ID!=0)
                {
                    StudentDb objDb = new StudentDb() { CurrentSemester=ID};
                    DataTable dtTemp = objDb.GetStoppedStudent();
                    int intTemp = 0;
                    foreach(DataRow objDr in dtTemp.Rows)
                    {
                        intTemp = 0;
                        if(int.TryParse(objDr["StudentID"].ToString(),out intTemp))
                          {
                            if (Returned[intTemp.ToString()] == null)
                                Returned.Add(intTemp.ToString(), intTemp);
                        }
                    }
                }
                return Returned;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _SemesterDb.Add();
        }
        public void Edit()
        {
            _SemesterDb.Edit();
        }
        public void Delete()
        {
            _SemesterDb.Delete();
        }
        #endregion
    }
}