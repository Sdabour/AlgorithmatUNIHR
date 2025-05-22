using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgorithmatMVC.UNI.UniDataBase;
using System.Data;

namespace AlgorithmatMVC.UNI.UNIBusiness
{
    public class COMMONGradeBiz
    {

        #region Constructor
        public COMMONGradeBiz()
        {
            _COMMONGradeDb = new COMMONGradeDb();
        }
        public COMMONGradeBiz(DataRow objDr)
        {
            _COMMONGradeDb = new COMMONGradeDb(objDr);
        }

        #endregion
        #region Private Data
        COMMONGradeDb _COMMONGradeDb;
        #endregion
        #region Properties
        public int Faculty
        {
            set => _COMMONGradeDb.Faculty = value;
            get => _COMMONGradeDb.Faculty;
        }
        public int MinPerc
        {
            set => _COMMONGradeDb.MinPerc = value;
            get => _COMMONGradeDb.MinPerc;
        }
        public int MaxPerc
        {
            set => _COMMONGradeDb.MaxPerc = value;
            get => _COMMONGradeDb.MaxPerc;
        }
        public string Verbal
        {
            set => _COMMONGradeDb.Verbal = value;
            get => _COMMONGradeDb.Verbal;
        }
        public double Points
        {
            set => _COMMONGradeDb.Points = value;
            get => _COMMONGradeDb.Points;
        }
        public double GetPoints(double dblPerc)
        {
            if(dblPerc==1)
            {

            }
            dblPerc *= 100;
            double Returned = _COMMONGradeDb.Points;
            if(dblPerc>0 && _COMMONGradeDb.Points != MaxPoints &&dblPerc>MinPerc)
            {
                double dblMaxPerc = MaxPerc > 100 ? 100 : MaxPerc;
                

                double dblTemp = (dblMaxPerc - dblPerc) + 1;
                dblTemp = dblTemp / ((dblMaxPerc - MinPerc) + 1);
                dblTemp = (dblPerc - MinPerc) / (dblMaxPerc - MinPerc);
                dblTemp = dblTemp * (MaxPoints- _COMMONGradeDb.Points);
                Returned += dblTemp;
            
            }
            string strRetuned = Returned.ToString("0.00");
            double.TryParse(strRetuned, out Returned);
            return Returned;
        }
        public double MaxPoints
        {
            set => _COMMONGradeDb.MaxPoints = value;
            get => _COMMONGradeDb.MaxPoints;
        }
        #endregion
        #region Private Method

        #endregion
        #region Public Method 
        public void Add()
        {
            _COMMONGradeDb.Add();
        }
        public void Edit()
        {
            _COMMONGradeDb.Edit();
        }
        public void Delete()
        {
            _COMMONGradeDb.Delete();
        }
        public COMMONGradeBiz Copy()
        {
            COMMONGradeBiz Returned = new COMMONGradeBiz() { MaxPerc = MaxPerc, MinPerc = MinPerc, Points = _COMMONGradeDb.Points,MaxPoints=MaxPoints, Verbal = Verbal,Faculty=Faculty };
            return Returned;
        }
        #endregion
    }
}