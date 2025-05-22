using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
using System.Collections;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class ResultStatementBiz
    {

        #region Constructor
        public ResultStatementBiz()
        {
            _ResultStatementDb = new ResultStatementDb();
            DataTable dtTemp = new DataTable();
            
        }
        public ResultStatementBiz(DataRow objDr)
        {
            _ResultStatementDb = new ResultStatementDb(objDr);
            _SemesterBiz = new SemesterBiz(objDr);
        }

        #endregion
        #region Private Data
        ResultStatementDb _ResultStatementDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _ResultStatementDb.ID = value;
            get => _ResultStatementDb.ID;
        }
        public string Desc
        {
            set => _ResultStatementDb.Desc = value;
            get => _ResultStatementDb.Desc;
        }
        public int Semester
        {
            set => _ResultStatementDb.Semester = value;
            get => _ResultStatementDb.Semester;
        }
        public DateTime Date
        {
            set => _ResultStatementDb.Date = value;
            get => _ResultStatementDb.Date;
        }
        public int Faculty
        {
            set => _ResultStatementDb.Faculty = value;
            get => _ResultStatementDb.Faculty;
        }
        public int Status
        {
            set => _ResultStatementDb.Status = value;
            get => _ResultStatementDb.Status;
        }
        public DateTime ResultPublishDate
        {
            set => _ResultStatementDb.ResultPublishDate = value;
            get => _ResultStatementDb.ResultPublishDate;
        }
        
      

        SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz
        {
            set => _SemesterBiz = value;
            get { if (_SemesterBiz == null)
                    _SemesterBiz = new SemesterBiz();
                return _SemesterBiz;
            }
        }
        static ResultStatementBiz _LastStatementBiz;
        public static ResultStatementBiz LastStatementBiz
        {
            get
            {
                ResultStatementBiz Returned = new ResultStatementBiz();
                ResultStatementDb objDb = new ResultStatementDb();
                objDb.OnlyLastStatementStatus = 1;
                DataTable dtTemp = objDb.Search();
                if (dtTemp.Rows.Count > 0)
                    Returned = new ResultStatementBiz(dtTemp.Rows[0]);

                return Returned;
            }
        }
        StudentResultCol _StudentResultCol;
        public StudentResultCol StudentResultCol
        {
            set => _StudentResultCol = value;
            get
            {
                if(_StudentResultCol==null &&ID!= 0)
                {
                    
                        StudentResultBiz objBiz;
                        _StudentResultHash = new Hashtable();
                    _StudentResultCol = new StudentResultCol(true,0);
                        StudentResultDb objDb = new StudentResultDb() { Statement = ID };
                        DataTable dtTemp = objDb.Search();
                        foreach (DataRow objDr in dtTemp.Rows)
                        {
                            objBiz = new StudentResultBiz(objDr);
                        _StudentResultCol.Add(objBiz);

                            if (_StudentResultHash[objBiz.StudentBiz.ID.ToString()]== null)
                            {
                            _StudentResultHash.Add(objBiz.StudentBiz.ID.ToString(), _StudentResultCol.Count - 1);
                        }
                     
                    }
                 

                }
                return _StudentResultCol;
            }
        }
        Hashtable _StudentResultHash;
        public Hashtable StudentResultHash
        {
            set => _StudentResultHash = value;
            get
            {
                if(_StudentResultHash==null&&ID>0)
                {
                    StudentResultCol objTempCol = StudentResultCol;
                   
                }
                return _StudentResultHash;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _ResultStatementDb.Add();
        }
        public void Edit()
        {
            _ResultStatementDb.Edit();
        }
        public void Delete()
        {
            _ResultStatementDb.Delete();
        }
        #endregion
    }
}