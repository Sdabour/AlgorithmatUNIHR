using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;
using System.Collections;
using SharpVision.SystemBase;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class StudentDiscountCol:CollectionBase
    {
        public StudentDiscountCol(bool blIsempty)
        {
            if (!blIsempty)
            {
                StudentDiscountDb objDb = new StudentDiscountDb();
                DataTable dtTemp = objDb.Search();
                foreach (DataRow objDr in dtTemp.Rows)
                {
                    Add(new StudentDiscountBiz(objDr));
                }
            }
        }
        public StudentDiscountCol(int intID)
        {
            StudentDiscountDb objDb = new StudentDiscountDb();
            objDb.ID = intID;
            DataTable dtTemp = objDb.Search();
            SetData(dtTemp);


        }

        public StudentDiscountCol(  bool isDiscountDateRange, DateTime dtDiscountDateFrom, DateTime dtDiscountDateTo, double dblValFrom, double dblValTo)
        {
            StudentDiscountDb objDb = new StudentDiscountDb();
            
           
            objDb.IsDiscountdateRange = isDiscountDateRange;
            objDb.DiscountDateFrom = dtDiscountDateFrom;
            objDb.DiscountDateTo = dtDiscountDateTo;
            objDb.ValFrom = dblValFrom;
            objDb.ValTo = dblValTo;
            // objDb.CellID = objCellBiz.ID;
            

            DataTable dtTemp = objDb.Search();
            SetData(dtTemp);
        }

        public StudentDiscountBiz this[int intIndex]
        {

            get
            {
                return (StudentDiscountBiz)List[intIndex];
            }
        }
        public double NonScheduledValue
        {
            get
            {
                double Returned = 0;
                foreach (StudentDiscountBiz objBiz in this)
                {
                    if (!objBiz.Scheduled)
                        Returned += objBiz.Value;
                }
                return Returned;
            }
        }
        public double TotalValue
        {
            get
            {
                double Returned = 0;

                foreach (StudentDiscountBiz objBiz in this)
                {
                    Returned += objBiz.Value;
                }

                return Returned;
            }
        }


        void SetData(DataTable dtTemp)
        {
            StudentDiscountBiz objBiz;
            StudentDiscountDb objDb;
            Hashtable hsTemp = new Hashtable();

            foreach (DataRow objDr in dtTemp.Rows)
            {
                objBiz = new StudentDiscountBiz(objDr);

                Add(objBiz);
            }
            List<string> arrStr = SysUtility.GetStringArr(dtTemp, "StudentID", 200);
            StudentDb objStudentDb;
            string strTemp;
            foreach (string strStudentIDs in arrStr)
            {
                objStudentDb = new StudentDb();
                objStudentDb.IDs = strStudentIDs;
                DataTable dtStudent = objStudentDb.Search();
                StudentBiz objStudentBiz;
                foreach (DataRow objDr in dtStudent.Rows)
                {
                    objStudentBiz = new StudentBiz(objDr);
                    //strTemp = objStudentBiz.UnitStr;
                    //strTemp = objStudentBiz.CustomerStr;
                    if (hsTemp[objStudentBiz.ID.ToString()] == null)
                    {
                        hsTemp.Add(objStudentBiz.ID.ToString(), objStudentBiz);
                    }


                }

            }
            foreach (StudentDiscountBiz objDiscountBiz in this)
            {
                if (hsTemp[objDiscountBiz.StudentID.ToString()] != null)
                    objDiscountBiz.StudentBiz = (StudentBiz)hsTemp[objDiscountBiz.StudentID.ToString()];
                else
                    objDiscountBiz.StudentBiz = new StudentBiz();

            }
        }


        public void Scheduled()
        {
            foreach (StudentDiscountBiz objBiz in this)
            {
                if (!objBiz.Scheduled)
                    objBiz.Schedul();
            }
        }
        public void Add(StudentDiscountBiz objBiz)
        {
            List.Add(objBiz);

        }





        internal DataTable GetTable(string strName)
        {
            DataTable dtReturned = new DataTable(strName);
            dtReturned.Columns.AddRange(new DataColumn[] { new DataColumn("DiscountID"), new DataColumn("StudentID"), new DataColumn("DiscountReason"), new DataColumn("DiscountDate"), new DataColumn("DiscountValue"), new DataColumn("Scheduled"), new DataColumn("TypeID") });
            DataRow objDr;
            foreach (StudentDiscountBiz objBiz in this)
            {

                objDr = dtReturned.NewRow();

                objDr["DiscountID"] = objBiz.ID;
                objDr["StudentID"] = objBiz.StudentBiz.ID;
                objDr["DiscountReason"] = objBiz.Reason;
                objDr["DiscountDate"] = objBiz.Date;
                objDr["DiscountValue"] = objBiz.Value;
                objDr["Scheduled"] = objBiz.Scheduled;
                objDr["TypeID"] = objBiz.TypeBiz.ID;
                dtReturned.Rows.Add(objDr);

            }
            return dtReturned;

        }
        public StudentDiscountCol Copy(StudentBiz objStudentBiz)
        {
            StudentDiscountCol Returned = new StudentDiscountCol(true);
            StudentDiscountBiz objTemp;
            foreach (StudentDiscountBiz objBiz in this)
            {
                objTemp = objBiz.Copy();
                objTemp.StudentBiz = objStudentBiz;
                Returned.Add(objTemp);

            }
            return Returned;
        }
        internal DataTable GetTable()
        {
            return GetTable("Discount");

        }


    }
}