using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVision.CRM.CRMBusiness;
 namespace  AlgorithmatMN.MN.MNBiz
{
    public class ProjectYearCostBiz
    {
        
        public ProjectBiz ProjectBiz
        {
             get => ProjectCol.CacheProjectCol[_Project];
        }
        string _Project;
        public string Project
        { set => _Project = value; get => _Project; }
        int _Year;
        public int Year { set => _Year = value; get => _Year; }
        ProjectCostCol _CostCol;
        public ProjectCostCol CostCol
        { get
            { 
            if(_CostCol== null)
                {
                    _CostCol = new ProjectCostCol(true);
                }
                return _CostCol;
            }
        }
        ROCol _ROCol;
        public ROCol ROCol
        {
            set => _ROCol = value;
            get { if (_ROCol == null)
                    _ROCol = new ROCol(true);
                return _ROCol;
            }
        }
        public double ResArea
        { get => ROCol.Cast<ROBiz>().Sum(x => x.Type == 1 ? x.Area : 0); }
        public double NonResArea
        { get => ROCol.Cast<ROBiz>().Sum(x => x.Type != 1 ? x.Area : 0); }
        public double TotalCost { get => CostCol.Cast<ProjectCostBiz>().Sum(x => x.Value); }
        public double TotalArea
        { get => ROCol.Cast<ROBiz>().Sum(x => x.Area); }
        public double TotalWeightedArea
        { get => ROCol.Cast<ROBiz>().Sum(x => x.Area*x.TypeWeight); }
        public double CostPerMeter { get => TotalCost / TotalWeightedArea; }
    }
}
