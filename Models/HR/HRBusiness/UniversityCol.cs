using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using System.Collections;
using SharpVision.SystemBase;
namespace SharpVision.COMMON.COMMONBusiness
{
    public class UniversityCol : CollectionBase
    {
        public UniversityCol()
        {
            UniversityDb objUniversityDb = new UniversityDb();

            UniversityBiz objUniversityBiz;
            foreach (DataRow DR in objUniversityDb.Search().Rows)
            {
                objUniversityBiz = new UniversityBiz(DR);
                this.Add(objUniversityBiz);
            }
        }
        public UniversityCol(bool blIsEmpty)
        {
            if (!blIsEmpty)
            {
                UniversityDb objUniversityDb = new UniversityDb();

                UniversityBiz objUniversityBiz;
                objUniversityBiz = new UniversityBiz();
                objUniversityBiz.ID = 0;
                objUniversityBiz.NameA = "غير محدد";
                objUniversityBiz.NameE = "Not Specified";
                this.Add(objUniversityBiz);
                foreach (DataRow DR in objUniversityDb.Search().Rows)
                {
                    objUniversityBiz = new UniversityBiz(DR);
                    this.Add(objUniversityBiz);
                }
            }
        }
        public UniversityCol(string strNameAComp, string strNameEComp, int intUniversityID)
        {
            UniversityDb objDb = new UniversityDb();
            objDb.UniversityIDSearch = intUniversityID;
            objDb.NameACompSearch = strNameAComp;
            objDb.NameECompSearch = strNameEComp;
            UniversityBiz objBiz;
            foreach (DataRow DR in objDb.Search().Rows)
            {
                objBiz = new UniversityBiz(DR);
                this.Add(objBiz);

            }
        }
        public UniversityCol(string strNameAComp, string strNameEComp)
        {
            UniversityDb objDb = new UniversityDb();            
            objDb.NameAComp = strNameAComp;
            objDb.NameEComp = strNameEComp;
            UniversityBiz objBiz;
            foreach (DataRow DR in objDb.Search().Rows)
            {
                objBiz = new UniversityBiz(DR);
                this.Add(objBiz);

            }
        }
        public UniversityCol(int intCountryID)
        {
            UniversityDb objDb = new UniversityDb();
            objDb.CountrySearch = intCountryID;            
            UniversityBiz objBiz;
            foreach (DataRow DR in objDb.Search().Rows)
            {
                objBiz = new UniversityBiz(DR);
                this.Add(objBiz);

            }
        }
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (UniversityBiz objUniversityBiz in this)
            {
                if (objUniversityBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual UniversityBiz this[int intIndex]
        {
            get
            {
                return (UniversityBiz)this.List[intIndex];
            }
        }

        public virtual UniversityBiz this[string strIndex]
        {
            get
            {
                UniversityBiz Returned = new UniversityBiz();
                foreach (UniversityBiz objUniversityBiz in this)
                {
                    if (objUniversityBiz.Name == strIndex)
                    {
                        Returned = objUniversityBiz.Copy();
                        break;
                    }
                }
                return Returned;
            }
        }
        public virtual void Add(UniversityBiz objUniversityBiz)
        {
            this.List.Add(objUniversityBiz);

        }
        public UniversityCol GetCol(string strCode)
        {
            UniversityCol Returned = new UniversityCol(true);
            foreach(UniversityBiz objBiz in this)
            {
                if (objBiz.Name.CheckStr(strCode))
                    Returned.Add(objBiz);
            }
            return Returned;
        }
        public UniversityCol Copy()
        {
            UniversityCol Returned = new UniversityCol(true);
            foreach (UniversityBiz objTemp in this)
            {
                Returned.Add(objTemp.Copy());
            }
            return Returned;
        }


    }
}

