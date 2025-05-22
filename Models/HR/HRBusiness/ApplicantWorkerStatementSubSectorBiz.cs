using System;
using System.Collections.Generic;
using System.Text;
using SharpVision.HR.HRBusiness;
using SharpVision.HR.HRDataBase;
using System.Data;

namespace SharpVision.HR.HRBusiness
{
    public class ApplicantWorkerStatementSubSectorBiz
    {
         #region Private Data
        ApplicantWorkerStatementSubSectorDb _StatementSubSectorDb;
        ApplicantWorkerStatementBiz _ApplicantWorkerStatementBiz;
        SubSectorBiz _SubSectorBiz;
        #endregion
        #region Constructors
        public ApplicantWorkerStatementSubSectorBiz()
        {
            _StatementSubSectorDb = new ApplicantWorkerStatementSubSectorDb();
            _ApplicantWorkerStatementBiz = new ApplicantWorkerStatementBiz();
            //_SubSectorBiz = new SubSectorBiz();
        }
        public ApplicantWorkerStatementSubSectorBiz(DataRow objDr)
        {
            _StatementSubSectorDb = new ApplicantWorkerStatementSubSectorDb(objDr);
            //_ApplicantWorkerStatementBiz = new ApplicantWorkerStatementBiz(objDr);
            if (objDr["BranchID"].ToString() == "" || objDr["BranchID"].ToString() == "0")
                _SubSectorBiz = new SubSectorCellBiz(objDr);
            else
                _SubSectorBiz = new SubSectorBranchBiz(objDr);
        }
        public ApplicantWorkerStatementSubSectorBiz(ApplicantWorkerStatementBiz objApplicantWorkerStatementBiz, SubSectorBiz objSubSectorBiz)
        {
            _ApplicantWorkerStatementBiz = objApplicantWorkerStatementBiz;
            _SubSectorBiz = objSubSectorBiz;
        }
        #endregion
        #region Public Properties
        public ApplicantWorkerStatementBiz ApplicantWorkerStatementBiz
        {
            set
            {
                _ApplicantWorkerStatementBiz = value;
            }
            get
            {
                return _ApplicantWorkerStatementBiz;
            }
        }
        public SubSectorBiz SubSectorBiz
        {
            set
            {
                _SubSectorBiz = value;
            }
            get
            {
                return _SubSectorBiz;
            }
        }       
        #endregion
        #region Private Methods

        #endregion
        #region Public Methods
        public void Add()
        {
            _StatementSubSectorDb.OrginStatement = _ApplicantWorkerStatementBiz.ID;
            _StatementSubSectorDb.SubSector = _SubSectorBiz.ID;
            _StatementSubSectorDb.Add();
        }        
        public void Delete()
        {
            _StatementSubSectorDb.OrginStatement = _ApplicantWorkerStatementBiz.ID;            
            _StatementSubSectorDb.Add();
        }
        #endregion
    }
}
