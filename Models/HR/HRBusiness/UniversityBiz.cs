using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.COMMON.COMMONDataBase;
using SharpVision.Base.BaseBusiness;

namespace SharpVision.COMMON.COMMONBusiness
{
    public class UniversityBiz : BaseSingleBiz
    {
        #region Private Data
        CountryBiz _CountryBiz;
        #endregion
        #region Constructors
        public UniversityBiz()
        {
            _BaseDb = new UniversityDb();
            _CountryBiz = new CountryBiz();
        }
        public UniversityBiz(int intUniversityID)
        {
            _BaseDb = new UniversityDb(intUniversityID);
            _CountryBiz = new CountryBiz(((UniversityDb)_BaseDb).Country);
        }
        public UniversityBiz(DataRow objDR)
        {
            _BaseDb = new UniversityDb(objDR);
            _CountryBiz = new CountryBiz(objDR);

        }
        public UniversityBiz(UniversityDb objUniversityDb)
        {
            _BaseDb = objUniversityDb;
            _CountryBiz = new CountryBiz(((UniversityDb)_BaseDb).Country);
        }

        #endregion
        #region Public Properties
        public CountryBiz CountryBiz
        {
            set
            {
                _CountryBiz = value;
            }
            get
            {
                return _CountryBiz;
            }
        }
        public string NameAComp
        {
            set
            {
                ((UniversityDb)_BaseDb).NameAComp = value;
            }
            get
            {
                return ((UniversityDb)_BaseDb).NameAComp;
            }
        }
        public string NameEComp
        {
            set
            {
                ((UniversityDb)_BaseDb).NameEComp = value;
            }
            get
            {
                return ((UniversityDb)_BaseDb).NameEComp;
            }
        }
        #endregion
        #region Public Methods

        public static void Add(string strNameA, string strNameE, string strNameAComp, string strNameEComp,int intCountry)
        {
            UniversityDb objDb = new UniversityDb();
            objDb.NameA = strNameA;
            objDb.NameE = strNameE;
            objDb.NameAComp = strNameAComp;
            objDb.NameEComp = strNameEComp;
            objDb.Country = intCountry;
            objDb.Add();

        }
        public static void Edit(int intUniversityID, string strNameA, string strNameE, string strNameAComp, string strNameEComp,int intCountry)
        {
            UniversityDb objDb = new UniversityDb();
            objDb.ID = intUniversityID;
            objDb.NameA = strNameA;
            objDb.NameE = strNameE;
            objDb.NameAComp = strNameAComp;
            objDb.NameEComp = strNameEComp;
            objDb.Country = intCountry;
            objDb.Edit();

        }
        public static void Delete(int intUniversityID)
        {
            UniversityDb objDb = new UniversityDb();
            objDb.ID = intUniversityID;
            objDb.Delete();
        }
        public UniversityBiz Copy()
        {
            UniversityBiz Returned = new UniversityBiz();
            Returned.ID = this.ID;
            Returned.NameA = this.NameA;
            Returned.NameE = this.NameE;
            Returned.NameAComp = this.NameAComp;
            Returned.NameEComp = this.NameEComp;
            Returned._CountryBiz = this._CountryBiz;
            return Returned;
        }
        #endregion
    }
}
