using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AlgorithmatMVC.UNI.UniDataBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    //ds=>حرمان تاديبى
    //dn=>حرمان بناءا على غياب
    //wf غياب
    //P Pass
    //
    public enum RegisterationStatus
    {
        Normal,Approved=1,W=2,IC=3,Canceled=4,DS=5,DN=6,WF=7,P=8,IncPre=9
    }
    public class RegisterationBiz
    {

        #region Constructor
        public RegisterationBiz()
        {
            _RegisterationDb = new RegisterationDb();
        }
        public RegisterationBiz(DataRow objDr)
        {
            _RegisterationDb = new RegisterationDb(objDr);
            if(_RegisterationDb.ID== 687)
            {

            }
            _CourseBiz = new CourseBiz(objDr);
            _SemesterBiz = new SemesterBiz(objDr);
            
        }
        public RegisterationBiz(int intRegisteration,int intFaculty)
        {
            if(intRegisteration==0)
            {
                _RegisterationDb = new RegisterationDb();
                return;
            }
            DataRow objDr;
            RegisterationDb objDb = new RegisterationDb() { ID = intRegisteration,Faculty = intFaculty };
            DataTable dtTemp = objDb.Search();

            if (dtTemp.Rows.Count > 0)
            {
                objDr = dtTemp.Rows[0];
                _RegisterationDb = new RegisterationDb(objDr);

                _CourseBiz = new CourseBiz(objDr);
                _SemesterBiz = new SemesterBiz(objDr);
            }
            else
                _RegisterationDb = new RegisterationDb();
        }
        #endregion
        #region Private Data
       protected RegisterationDb _RegisterationDb;
        #endregion
        #region Properties
        public int ID
        {
            set => _RegisterationDb.ID = value;
            get => _RegisterationDb.ID;
        }
        public int Student
        {
            set => _RegisterationDb.Student = value;
            get => _RegisterationDb.Student;
        }
        public string StudentCode
        {
            
            get => _RegisterationDb.StudentCode;
        }
        public string EqualName
        {
            set => _RegisterationDb.EqualNameA = value;
            get => _RegisterationDb.EqualNameA==null?"":_RegisterationDb.EqualNameA;
        }
        public string StudentName
        {

            get => _RegisterationDb.StudentName;
        }
        public bool Posted { get => _RegisterationDb== null?false: _RegisterationDb.Posted; }
        public int ResultID { get => _RegisterationDb.ResultID; }
        
        public int Faculty
        { set => _RegisterationDb.Faculty = value;
            get => _RegisterationDb.Faculty ==0?StudentBiz.Faculty: _RegisterationDb.Faculty;
        }
        public DateTime Date
        {
            set => _RegisterationDb.Date = value;
            get => _RegisterationDb.Date;
        }
        public int Semester
        {
            set => _RegisterationDb.Semester = value;
            get => _RegisterationDb.Semester;
        }
        public int Course
        {
            set => _RegisterationDb.Course = value;
            get => _RegisterationDb.Course;
        }
        public int Level
        {
            set => _RegisterationDb.Level = value;
            get => _RegisterationDb.Level;
        }
        public int Iteration
        {
            set => _RegisterationDb.Iteration = value;
            get => _RegisterationDb.Iteration;
        }
        public double MidtermDegree
        {
            set => _RegisterationDb.MidtermDegree = value;
            get => _RegisterationDb.MidtermDegree;
        }
        public double SemesterWorkDegree
        {
            set => _RegisterationDb.SemesterWorkDegree = value;
            get => _RegisterationDb.SemesterWorkDegree;
        }
        public double PracticalDegree
        {
            set => _RegisterationDb.PracticalDegree = value;
            get => _RegisterationDb.PracticalDegree;
        }
        public double OralDegree
        {
            set => _RegisterationDb.OralDegree = value;
            get => _RegisterationDb.OralDegree;
        }
        public double FinalDegree
        {
            set => _RegisterationDb.FinalDegree = value;
            get => _RegisterationDb.FinalDegree;
        }

        public double ClinicalDegree
        {
            set => _RegisterationDb.ClinicalDegree = value;
            get => _RegisterationDb.ClinicalDegree;
        }

        public int MTStatus
        {
            set => _RegisterationDb.MTStatus = value;
            get => _RegisterationDb.MTStatus;
        }
        public int SWStatus
        {
            set => _RegisterationDb.SWStatus = value;
            get => _RegisterationDb.SWStatus;
        }
        public int PStatus
        {
            set => _RegisterationDb.PStatus = value;
            get => _RegisterationDb.PStatus;
        }
        public int OStatus
        {
            set => _RegisterationDb.OStatus = value;
            get => _RegisterationDb.OStatus;
        }
        public int FStatus
        {
            set => _RegisterationDb.FStatus = value;
            get => _RegisterationDb.FStatus;
        }
        public int CStatus
        {
            set => _RegisterationDb.CStatus = value;
            get => _RegisterationDb.CStatus;
        }
        public double FinalMinDegree
        {
            set => _RegisterationDb.FinalMinDegree = value;
            get => _RegisterationDb.FinalMinDegree;
        }
        public string Note
        {
            set => _RegisterationDb.Note=value;
            get => _RegisterationDb.Note;
        }
        public string SeatNO
        {
            set => _RegisterationDb.SeatNo = value;
            get => _RegisterationDb.SeatNo;
        }
        public int EqualID { get => _RegisterationDb.EqualID; }
        public double Bonus
        {
            set => _RegisterationDb.Bonus = value;
            get
            { 
                if(_RegisterationDb.ID== 1649)
                {

                }
                double Returned =_RegisterationDb.Bonus;
                if (Returned < CourseBiz.MaxBonus)
                    Returned = CourseBiz.MaxBonus;
                double intRef = 0.6 * CourseFinalDegree;
                if (Returned != 0 && (TotalValue >= (intRef - Returned) && TotalValue < intRef))
                {
                    Returned = intRef - TotalValue;
                }
                else
                    Returned = SemesterCount==1? _RegisterationDb.Bonus:0;

                if (_RegisterationDb.Bonus > 0 && _RegisterationDb.Bonus > Returned)
                    Returned = _RegisterationDb.Bonus;

                if (CourseBiz.BonusForAll && Returned < CourseBiz.MaxBonus)
                    Returned = CourseBiz.MaxBonus;

                if (FinalDegree < FinalMinDegree)
                    Returned = 0;

                return Returned;
            }
        }
       protected CourseBiz _CourseBiz;
        public CourseBiz CourseBiz
        { set => _CourseBiz = value; 
            get { 
                if (_CourseBiz == null) 
                    _CourseBiz = new CourseBiz();
                return _CourseBiz;
            } }
        protected StudentBiz _StudentBiz;
        public StudentBiz StudentBiz
        { set => _StudentBiz = value;
        get
            {
                if (_StudentBiz == null)
                    _StudentBiz = new StudentBiz() { ID=_RegisterationDb.Student,Code=_RegisterationDb.StudentCode,NameA=_RegisterationDb.StudentName,Faculty=_RegisterationDb.Faculty,Email=_RegisterationDb.StudentMail,Gender=_RegisterationDb.StudentGender};
                return _StudentBiz;
            }
        }
        protected SemesterBiz _SemesterBiz;
        public SemesterBiz SemesterBiz
        {
            set => _SemesterBiz = value;
            get
            {
                if (_SemesterBiz == null)
                    _SemesterBiz = new SemesterBiz();
                return _SemesterBiz;
            }
        }
        public RegisterationStatus Status
        {
            set => _RegisterationDb.Status=(int)value;
            get =>(RegisterationStatus) _RegisterationDb.Status;
        }
        public string StatusStr
        {
            get => Status == RegisterationStatus.Normal || Status == RegisterationStatus.Approved ? "OK" : Status.ToString();
        }
        public int CourseFinalDegree
        {
            //set => _RegisterationDb.CourseFinalDegree = value;
            get => _RegisterationDb.CourseFinalDegree;
        }
        static int MaxFailureDegree = 76;
        public double TotalValue
        {
            get
            { double Returned = MidtermDegree+SemesterWorkDegree+OralDegree+PracticalDegree+FinalDegree+ClinicalDegree;
                if(FailureCount>0 && (((double)Returned/(double)CourseFinalDegree)*100)>=MaxFailureDegree)
                {
                    Returned = (MaxFailureDegree * CourseFinalDegree) / 100;
                    Returned -= 0.01;
                }
                return Returned;
            }
        }
        public double Perc
        {
            get
            {
                 if(CourseBiz.ID==17)
                {

                }
                double Returned = TotalValue+Bonus;
                if (FailureCount > 0 && (((double)Returned / (double)CourseFinalDegree) * 100) >= MaxFailureDegree)
                {
                    Returned = (MaxFailureDegree * CourseFinalDegree) / 100;
                    Returned -= 0.01;
                }
                if (FinalDegree < FinalMinDegree)
                    Returned = 0;
                Returned = Returned / CourseFinalDegree;
                if(Status == RegisterationStatus.P)
                {
                    Returned = 0;
                }
                return Returned;
            }
        }
        public COMMONGradeBiz COMMONGradeBiz
        {
            get
            {
                if(Student == 195)
                {

                }
                COMMONGradeBiz Returned = new COMMONGradeBiz();
                double dblValue = Perc*100;
                Returned = COMMONGradeCol.CacheCOMMONGradeCol.GetCOMMONGrade(dblValue,Faculty);
                if (Status == RegisterationStatus.P)
                    Returned.Verbal = "P";
                return Returned;
            }
        }
        public double Points
        {
            get =>  COMMONGradeBiz.GetPoints(Perc);
        }
        public string VerbalGPA
        { get {
                string Returned = Status== RegisterationStatus.DS?"DS":(Status== RegisterationStatus.IC ?"IC":(Status== RegisterationStatus.W?"W": (Status == RegisterationStatus.WF ? "WF" :COMMONGradeBiz.Verbal)));
                Returned = Returned == null ? "" : Returned;
                if (Status == RegisterationStatus.P)
                    Returned = "P";
                //if (EqualID != 0)
                //    Returned = "T";
                Returned = Posted||ResultID>0? Returned : "";

                if (EqualID != 0)
                    Returned = "T";
                return Returned;
            } }
        public int SemesterCount
        { get => _RegisterationDb.SemesterCount; }
        public int FailureCount
        { get => _RegisterationDb.FailureCount; }
        RegisterationGroupBiz _GroupBiz;
        public RegisterationGroupBiz GroupBiz {
            set => _GroupBiz = value;
            get { if (_GroupBiz == null)
                    _GroupBiz = new RegisterationGroupBiz();
                return _GroupBiz;
            } }
        public double MaxGPA
        { get => _RegisterationDb.MaxGPA; }
        public int PrequisitCourseCount
        { get => _RegisterationDb.PrequisitCourseCount; }
        public int PrequisitPassedCourseCount
        { get => _RegisterationDb.PrequisitPassedCourseCount; }
        RegisterationCol _PrequisitCol;
        public RegisterationCol PrequisitCol
        {
            set => _PrequisitCol = value;
            get
            {
                if (_PrequisitCol == null)
                    _PrequisitCol = new RegisterationCol();
                return _PrequisitCol;
            }
        }
        public static int UMSEditRegistrationDegree { get => 2408; }

        #region Source Properties
        public int MainRegisterationID
        {
            set => _RegisterationDb.MainRegisterationID = value;
            get => _RegisterationDb.MainRegisterationID;
        }
        public int SourceRegisterationID
        {
            set => _RegisterationDb.SourceRegisterationID = value;
            get => _RegisterationDb.SourceRegisterationID;
        }
        public DateTime SourceRegisterationDate
        {
            set => _RegisterationDb.SourceRegisterationDate = value;
            get => _RegisterationDb.SourceRegisterationDate;
        }
        public int SourceSemesterID
        {
            set => _RegisterationDb.SourceSemesterID = value;
            get => _RegisterationDb.SourceSemesterID;
        }
        public string SourceSemesterDesc
        {
            set => _RegisterationDb.SourceSemesterDesc = value;
            get => _RegisterationDb.SourceSemesterDesc;
        }
        public double SourceMidtermDegree
        {
            set => _RegisterationDb.SourceMidtermDegree = value;
            get => _RegisterationDb.SourceMidtermDegree;
        }
        public double SourceSemesterWorkDegree
        {
            set => _RegisterationDb.SourceSemesterWorkDegree = value;
            get => _RegisterationDb.SourceSemesterWorkDegree;
        }
        public double SourcePracticalDegree
        {
            set => _RegisterationDb.SourcePracticalDegree = value;
            get => _RegisterationDb.SourcePracticalDegree;
        }
        public double SourceOralDegree
        {
            set => _RegisterationDb.SourceOralDegree = value;
            get => _RegisterationDb.SourceOralDegree;
        }
        public double SourceFinalDegree
        {
            set => _RegisterationDb.SourceFinalDegree = value;
            get => _RegisterationDb.SourceFinalDegree;
        }
        public string SourceVerbalGPA
        {
            set => _RegisterationDb.SourceVerbalGPA = value;
            get => _RegisterationDb.SourceVerbalGPA;
        }
        public double SourceGPA
        {
            set => _RegisterationDb.SourceGPA = value;
            get => _RegisterationDb.SourceGPA;
        }
        public int SourceStatus
        {
            set => _RegisterationDb.SourceStatus = value;
            get => _RegisterationDb.SourceStatus;
        }
        public string SourceNote
        {
            set => _RegisterationDb.SourceNote = value;
            get => _RegisterationDb.SourceNote;
        }
        public int SourceResult
        {
            set => _RegisterationDb.SourceResult = value;
            get => _RegisterationDb.SourceResult;
        }
        #endregion
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _RegisterationDb.Add();
        }
        public void Edit()
        {
            _RegisterationDb.Edit();
        }
        public void Delete()
        {
            _RegisterationDb.Delete();
        }
        public static void EditRegDegree(int intUser,int intID,double dblSemesterWork,double dblMidterm,double dblOral,double dblParctical,double dblFinal,double dblBonus,double dblClinicalDegree,string strNote)
        {
            RegisterationDb objDb = new RegisterationDb() { ID = intID, User = intUser, SemesterWorkDegree = dblSemesterWork, MidtermDegree = dblMidterm, OralDegree = dblOral, PracticalDegree = dblParctical, FinalDegree = dblFinal,ClinicalDegree=dblClinicalDegree, Bonus = dblBonus, Note = strNote };
            objDb.EditDegree();

        }
        public static void RegisterStudentCol(int intUserID,int intSemesterID,int intCourseID,List<int> lstIDs)
        {
            if (intSemesterID == 0 || intCourseID == 0 || (intUserID == 0&&SharpVision.SystemBase.SysData.CurrentUser.ID ==0)||lstIDs.Count == 0)
                return;
            string strStudentIDs = "";
            foreach(int intID in lstIDs)
            {
                if (strStudentIDs != "")
                    strStudentIDs += ",";
                strStudentIDs += intID.ToString();
            }
            RegisterationDb objDb = new RegisterationDb() {StudentIDs=strStudentIDs,Course=intCourseID,Semester=intSemesterID };
            objDb.UploadStudent();

        }
        public static void RegisterCourseCol(int intFacultyID,int intUserID, int intSemesterID, int intStudentID, List<int> lstIDs)
        {
            if (intSemesterID == 0||intFacultyID ==0 || intStudentID == 0 || intUserID == 0 || lstIDs.Count == 0)
                return;
            string strCourseIDs = "";
            foreach (int intID in lstIDs)
            {
                if (strCourseIDs != "")
                    strCourseIDs += ",";
                strCourseIDs += intID.ToString();
            }
            RegisterationDb objDb = new RegisterationDb() { CourseIDs = strCourseIDs, Student = intStudentID, Semester = intSemesterID ,Faculty=intFacultyID};
            objDb.UploadStudentCourse();

        }
        public void SaveEQH()
        {

        }
        public static void UploadReg(DataTable dtTemp)
        {
            RegisterationDb objDb = new RegisterationDb() { RegisterationTable=dtTemp};
            objDb.UploadRegisterationExcel();
        }
        #endregion
    }
}