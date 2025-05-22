using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNBiz
{
    public class ProjectYearBiz
    {
        int _Year;
        public int Year { set => _Year = value; get => _Year; }
        public YearBiz YearBiz
        {
            get
            {
                YearBiz Returned = new YearBiz();
                if (YearCol.CacheYearHs[Year.ToString()] != null)
                    Returned = (YearBiz)YearCol.CacheYearHs[Year.ToString()];
                return Returned;
            }
        }
        string _ProjectCode;
        public string ProjectCode { set => _ProjectCode = value; get => _ProjectCode; }
        public string Key
        { get => (_ProjectCode== null?"": _ProjectCode.Trim()).ToUpper() + "-" + Year.ToString(); }
       // DateTime _StartDate;
        public DateTime StartDate { get =>Year> 0&&YearCol.CacheYearHs[Year.ToString()]!=null? ((YearBiz)YearCol.CacheYearHs[Year.ToString()]).StartDate : new DateTime(DateTime.Now.Year,1,1); }
        //DateTime _EndDate;
        public DateTime EndDate { get {
                if (Year == 2022)
                { 
                }
                return Year > 0 && YearCol.CacheYearHs[Year.ToString()] != null ? ((YearBiz)YearCol.CacheYearHs[Year.ToString()]).EndDate : new DateTime(DateTime.Now.Year, 12, 31); } }
        public int Days { get => EndDate.Subtract(StartDate).Days + 1; }
        ProjectCostCol _CostCol;
        public ProjectCostCol CostCol
        { set => _CostCol = value;
            get 
            {
                if (_CostCol == null)
                    _CostCol = new ProjectCostCol(true);
                return _CostCol;
            }

        }
        public double CostPart
        { get =>CreditCol.Count>0? CostCol.TotalValue / CreditCol.TotalCostPart:0; }
        CreditCol _CreditCol;
        public CreditCol CreditCol
        { set => _CreditCol = value; 
            get 
            {
                if (_CreditCol == null)
                    _CreditCol = new CreditCol(true);
                return _CreditCol;
            } }
        public void SetCostCol(ProjectCostCol objCostCol)
        {
            int intYear = Year;
            YearBiz objYear = new YearBiz();
            if (YearCol.CacheYearHs[Year.ToString()] != null)
                objYear = (YearBiz)YearCol.CacheYearHs[Year.ToString()];
            string strProjectCode = ProjectCode;


            List<ProjectCostBiz> lstCost = (from objCost in objCostCol.Cast<ProjectCostBiz>()
                                            where objCost.Date.Date >= objYear.StartDate.Date
                                            &&
                                            objCost.Date.Date <= objYear.EndDate.Date
                                            && objCost.Project == strProjectCode
                                            orderby objCost.Year
                                            select objCost).ToList();
            //CostCol = new ProjectCostCol(true);
            foreach (ProjectCostBiz objBiz in lstCost)
            {

                 CostCol.Add(objBiz);
            }
            //return Returned;
        }
    }
}
