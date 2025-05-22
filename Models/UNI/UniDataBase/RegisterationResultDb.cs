using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SharpVision.SystemBase;
using System.Data.SqlClient;
namespace AlgorithmatMVC.UNI.UniDataBase
{
    public class RegisterationResultDb:RegisterationDb
    {
        public RegisterationResultDb() : base()
        {

        }
        public RegisterationResultDb(DataRow objDr):base(objDr)
        {

        }
        // string _ResultIDs;
       // public string ResultIDs { set => _ResultIDs = value; }
        int _ResultStatement;
        public int ResultStatement { set => _ResultStatement=value; }
        public override string SearchStr
        {
            get {
                string strResultRegisteration = @"SELECT dbo.UNIRegisterationResult.RegisterationID AS ResultRegisterationID, dbo.UNIRegisterationResult.RegisterationResult AS ResultRegisterationResult, dbo.UNIRegisterationResult.RegisterationStatus AS ResultRegisterationStatus, 
                  dbo.UNIRegisterationResult.MidtermDegree AS ResultRegisterationMidtermDegree, dbo.UNIRegisterationResult.SemesterWorkDegree AS ResultRegisterationSemesterWorkDegree, 
                  dbo.UNIRegisterationResult.PracticalDegree AS ResultRegisterationPracticalDegree, dbo.UNIRegisterationResult.OralDegree AS ResultRegisterationOralDegree, 
                  dbo.UNIRegisterationResult.FinalDegree AS ResultRegisterationFinalDegree, dbo.UNIRegisterationResult.Bonus AS ResultRegisterationBonus, 
                  dbo.UNIRegisterationResult.RegisterationCourseFinalDegree AS ResultRegisterationCourseFinalDegree, dbo.UNIRegisterationResult.VerbalGPA AS ResultRegisterationVerbalGPA, 
                  dbo.UNIRegisterationResult.GPA AS ResultRegisterationGPA, dbo.UNIRegisterationResult.RegisterationNote AS ResultRegisterationNote, 
                  dbo.UNIRegisterationResult.RegisterationFinalTotalDegree AS ResultRegisterationFinalTotalDegree, dbo.UNIRegisterationResult.RegisterationFinalMidtermDegree AS ResultRegisterationFinalMidtermDegree, 
                  dbo.UNIRegisterationResult.RegisterationFinalSemesterWorkDegree AS ResultRegisterationFinalSemesterWorkDegree, dbo.UNIRegisterationResult.RegisterationFinalPracticalDegree AS ResultRegisterationFinalPracticalDegree, 
                  dbo.UNIRegisterationResult.RegisterationFinalOralDegree AS ResultRegisterationFinalOralDegree, dbo.UNIRegisterationResult.RegisterationFinalFinalDegree AS ResultRegisterationFinalFinalDegree
FROM     dbo.UNIRegisterationResult INNER JOIN
                  dbo.UNIStudentResult AS UNIStudentResult_1 ON dbo.UNIRegisterationResult.RegisterationResult = UNIStudentResult_1.ResultID INNER JOIN
                  dbo.UNIStudentResult ON UNIStudentResult_1.ResultStudent = dbo.UNIStudentResult.ResultStudent AND UNIStudentResult_1.ResultID <= dbo.UNIStudentResult.ResultID
WHERE  (1 = 1)";
                string strResultIDs = "";
                if (_ResultID != 0)
                    strResultIDs = _ResultID.ToString();

                if (ResultID != 0)
                {
                    //(UNIStudentResult_1.ResultID = 1) 
                    strResultRegisteration += " and (UNIStudentResult.ResultID = "+_ResultID+") ";
                }
                if (_ResultIDs != null && _ResultIDs!="")
                {
                    //(UNIStudentResult_1.ResultID = 1) 
                    strResultRegisteration += " and (UNIStudentResult.ResultID in (" + _ResultIDs + ")) ";
                }
                if (_ResultStatement!=0)
                {
                    strResultRegisteration += @" AND(dbo.UNIStudentResult.ResultStatement = "+_ResultStatement+")";
                }
                string Returned = "select RegisterationTable.*,RegisterationResulTable.* from (" + base.BaseSearchStr + @") as RegisterationTable inner join ("+strResultRegisteration+ @") as RegisterationResulTable 
  on RegisterationTable.RegisterationID = RegisterationResulTable.ResultRegisterationID "; 
                return Returned;
        }
        }
        protected override void SetData(DataRow objDr)
        {
            base.SetData(objDr);
           

             

            if (objDr.Table.Columns["ResultRegisterationStatus"] != null)
                int.TryParse(objDr["ResultRegisterationStatus"].ToString(), out _Status);
            if (objDr.Table.Columns["ResultRegisterationResult"] != null)
            {
                int.TryParse(objDr["ResultRegisterationResult"].ToString(), out _ResultID);
            }
            if (objDr.Table.Columns["ResultRegisterationMidtermDegree"] != null)
                double.TryParse(objDr["ResultRegisterationMidtermDegree"].ToString(), out _MidtermDegree);

            if (objDr.Table.Columns["ResultRegisterationSemesterWorkDegree"] != null)
                double.TryParse(objDr["ResultRegisterationSemesterWorkDegree"].ToString(), out _SemesterWorkDegree);

            if (objDr.Table.Columns["ResultRegisterationPracticalDegree"] != null)
                double.TryParse(objDr["ResultRegisterationPracticalDegree"].ToString(), out _PracticalDegree);

            if (objDr.Table.Columns["ResultRegisterationOralDegree"] != null)
                double.TryParse(objDr["ResultRegisterationOralDegree"].ToString(), out _OralDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalDegree"].ToString(), out _FinalDegree);

            if (objDr.Table.Columns["ResultRegisterationBonus"] != null)
                double.TryParse(objDr["ResultRegisterationBonus"].ToString(), out _Bonus);

            //if (objDr.Table.Columns["ResultRegisterationCourseFinalDegree"] != null)
            //    int.TryParse(objDr["ResultRegisterationCourseFinalDegree"].ToString(), out _CourseFinalDegree);

            if (objDr.Table.Columns["ResultRegisterationVerbalGPA"] != null)
                _VerbalGPA = objDr["ResultRegisterationVerbalGPA"].ToString();

            if (objDr.Table.Columns["ResultRegisterationGPA"] != null)
                double.TryParse(objDr["ResultRegisterationGPA"].ToString(), out _GPA);

            if (objDr.Table.Columns["ResultRegisterationNote"] != null)
                _Note = objDr["ResultRegisterationNote"].ToString();

            //if (objDr.Table.Columns["ResultRegisterationFinalTotalDegree"] != null)
            //    double.TryParse(objDr["ResultRegisterationFinalTotalDegree"].ToString(), out _FinalTotalDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalMidtermDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalMidtermDegree"].ToString(), out _FinalMidtermDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalSemesterWorkDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalSemesterWorkDegree"].ToString(), out _FinalSemesterWorkDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalPracticalDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalPracticalDegree"].ToString(), out _FinalPracticalDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalOralDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalOralDegree"].ToString(), out _FinalOralDegree);

            if (objDr.Table.Columns["ResultRegisterationFinalFinalDegree"] != null)
                double.TryParse(objDr["ResultRegisterationFinalFinalDegree"].ToString(), out _FinalFinalDegree);
            if (PrequisitCourseCount > PrequisitPassedCourseCount)
            {
                _Status = 3;

            }
        }
    }
}