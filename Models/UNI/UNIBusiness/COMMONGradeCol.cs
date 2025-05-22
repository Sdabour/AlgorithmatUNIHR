using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using AlgorithmatMVC.UNI.UniDataBase;
using SharpVision.SystemBase;
namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class COMMONGradeCol:CollectionBase
    {

        #region Constructor
        public COMMONGradeCol()
        {

        }
        public COMMONGradeCol(bool blIsEmbty)
        {
            if (blIsEmbty)
                return;
            COMMONGradeBiz objBiz = new COMMONGradeBiz();
          
            COMMONGradeDb objDb = new COMMONGradeDb();

            DataTable dtTemp = objDb.Search();


            foreach (DataRow objDR in dtTemp.Rows)
            {
                objBiz = new COMMONGradeBiz(objDR);
                Add(objBiz);
            }
        }

        #endregion
        #region Private Data

        #endregion
        #region Properties
        public COMMONGradeBiz this[int intIndex]
        {
            get
            {
                return (COMMONGradeBiz)this.List[intIndex];
            }
        }
        static COMMONGradeCol _CacheCOMMONGradeCol;
       public static COMMONGradeCol CacheCOMMONGradeCol
        {
            get
            {
                if (_CacheCOMMONGradeCol == null)
                    _CacheCOMMONGradeCol = new COMMONGradeCol(false);
                return _CacheCOMMONGradeCol;
            }
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add(COMMONGradeBiz objBiz)
        {
            List.Add(objBiz);
        }
        public COMMONGradeCol GetCol(string strTemp)
        {
            COMMONGradeCol Returned = new COMMONGradeCol(true);
            foreach (COMMONGradeBiz objBiz in this)
            {
                if (objBiz.Verbal.CheckStr(strTemp))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public DataTable GetTable()
        {
            DataTable Returned = new DataTable();
            Returned.Columns.AddRange(new DataColumn[] { new DataColumn("GradeMinPerc"), new DataColumn("GradeMaxPerc"), new DataColumn("GradeVerbal"), new DataColumn("GradePoints") });
            DataRow objDr;
            foreach (COMMONGradeBiz objBiz in this)
            {
                objDr = Returned.NewRow();
                objDr["GradeMinPerc"] = objBiz.MinPerc;
                objDr["GradeMaxPerc"] = objBiz.MaxPerc;
                objDr["GradeVerbal"] = objBiz.Verbal;
                objDr["GradePoints"] = objBiz.GetPoints(0);
                Returned.Rows.Add(objDr);
            }
            return Returned;
        }
        public COMMONGradeBiz GetCOMMONGrade(double dblPerc,int intFaculty)
        {
            COMMONGradeBiz Returned = new COMMONGradeBiz();
            List<COMMONGradeBiz> lstGrade = this.Cast<COMMONGradeBiz>().Where(x => x.Faculty == intFaculty || x.Faculty == 0).OrderBy(y => y.MinPerc).OrderBy(z => z.Faculty == 0 ? 1 : 0).ToList();

            
                foreach (COMMONGradeBiz objBiz in lstGrade)
            {
                if(dblPerc>=objBiz.MinPerc&& dblPerc<objBiz.MaxPerc)
                {
                    Returned = objBiz.Copy();
                    break;
                }
            }
            return Returned;
        }

        public COMMONGradeBiz GetCOMMONGradeByPoints(double dblPoints,int intFaculty)
        {
            COMMONGradeBiz Returned = new COMMONGradeBiz();
            COMMONGradeBiz objBiz = new COMMONGradeBiz() ;
            COMMONGradeBiz objMax=new COMMONGradeBiz();
            List<COMMONGradeBiz> lstGrade =this.Cast<COMMONGradeBiz>().Where(x=>x.Faculty==intFaculty || x.Faculty==0).OrderBy(y=>y.MinPerc).OrderBy(z=>z.Faculty==0?1:0).ToList();

            for(int intIndex =lstGrade.Count-1;intIndex>=1;intIndex--)
            {
                objBiz = lstGrade[intIndex];
                objMax = lstGrade[intIndex - 1];
                 
                if((objBiz.Points!= objBiz.MaxPoints&&dblPoints>=objBiz.Points && dblPoints<objBiz.MaxPoints) ||((objBiz.Points == objBiz.MaxPoints && dblPoints<objBiz.Points && dblPoints>=objMax.Points||
                    (objBiz.Points == objBiz.MaxPoints && dblPoints == objBiz.Points)
                    )))
                {
                    if (objBiz.MaxPoints != objBiz.Points)
                    {
                        Returned = objBiz.Copy();
                        Returned.Points = dblPoints;
                        Returned.MaxPoints = dblPoints;
                    }
                    else if(dblPoints < objBiz.GetPoints(0) && dblPoints >= objMax.GetPoints(0))
                    {
                        Returned = objMax.Copy();
                           Returned.Points = dblPoints;
                    }
                    else if (dblPoints == objBiz.GetPoints(0))
                    {
                        Returned = objMax.Copy();
                        Returned.Points = dblPoints;
                    }
                    break;
                }
                
            }
            if (Returned.Points == 0 && objBiz.Points>0 && objBiz.Points!= objBiz.MaxPoints)
            {
                Returned = objMax.Copy();
                Returned.MaxPoints = dblPoints;
            }
            if (lstGrade.Count>1&& Returned.GetPoints(0) == 0 && dblPoints == lstGrade[0].GetPoints(0)&&dblPoints!=0)
                Returned = lstGrade[1];
            if(dblPoints == 0&& lstGrade.Count>0)
            {
                Returned = lstGrade[0];
            }

            return Returned;
        }
        
        #endregion
    }
}