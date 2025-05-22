using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.HR.HRDataBase;
namespace SharpVision.HR.HRBusiness
{
    public class MSGGroupBiz
    {

        #region Constructor
        public MSGGroupBiz()
        {
            _GroupDb = new MSGGroupDb();
        }
        public MSGGroupBiz(DataRow objDr)
        {
            _GroupDb = new MSGGroupDb(objDr);
        }

        #endregion
        #region Private Data
        MSGGroupDb _GroupDb;
        #endregion
        #region Properties
        public double ID
        {
            set => _GroupDb.ID = value;
            get => _GroupDb.ID;
        }
        public string Code
        {
            set => _GroupDb.Code = value;
            get => _GroupDb.Code;
        }
        public DateTime EstablishDate
        {
            set => _GroupDb.EstablishDate = value;
            get => _GroupDb.EstablishDate;
        }
        public string NameA
        {
            set => _GroupDb.NameA = value;
            get => _GroupDb.NameA;
        }
        public string NameE
        {
            set => _GroupDb.NameE = value;
            get => _GroupDb.NameE;
        }
        public string Desc
        {
            set => _GroupDb.Desc = value;
            get => _GroupDb.Desc;
        }
        List<ApplicantSingle> _ApplicantLst;
        public List<ApplicantSingle> ApplicantLst
        {
            get
            {
                if (_ApplicantLst == null)
                    _ApplicantLst = new List<ApplicantSingle>();
                return _ApplicantLst;
            }
        }
        #endregion
        #region Private Method
        string GetAppIDs()
        {
            string strAppIDs = "";
            foreach (ApplicantSingle objBiz in ApplicantLst)
            {
                if (strAppIDs != "")
                    strAppIDs += ",";
                strAppIDs += objBiz.ID.ToString();
            }
            return strAppIDs;
        }
        #endregion
        #region Public Method 
        public void Add()
        {
            _GroupDb.ApplicantIDs = GetAppIDs();
            _GroupDb.Add();
        }
        public void Edit()
        {
            _GroupDb.Edit();
        }
        public void Delete()
        {
            _GroupDb.Delete();
        }
        public static MSGGroupCol GetAppGroupCol(int intAppID)
        {
            MSGGroupDb objDb = new MSGGroupDb { ApplicantIDs = intAppID.ToString() };
            MSGGroupCol Returned = new MSGGroupCol(true);
            DataTable dtTemp = objDb.Search();
            foreach (DataRow objDr in dtTemp.Rows)
                Returned.Add(new MSGGroupBiz(objDr));

            return Returned;
        }
        #endregion
    }
}