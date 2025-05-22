using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SharpVision.Base.BaseDataBase;
using SharpVision.Base.BaseBusiness;
using SharpVision.GL.GLDataBase;
using SharpVision.SystemBase;
using SharpVision.COMMON.COMMONBusiness;
using SharpVision.HR.HRDataBase;
using SharpVision.GL.GLBusiness;
namespace SharpVision.HR.HRBusiness
{
    public class BankHRCol : BaseCol
    {
        BankHRBiz _RootBiz;
        public BankHRCol()
        {
            //BankHRDb objBankHRDb = new BankHRDb();

            //BankHRBiz objBankHRBiz;
            //foreach (DataRow DR in objBankHRDb.Search().Rows)
            //{
            //    objBankHRBiz = new BankHRBiz(DR);
            //    this.Add(objBankHRBiz);
            //}
        }
     
     
        public BankHRCol(bool blIsEmpty)
        {
            //if (!blIsEmpty)
            //{
            //    BankHRDb objDb = new BankHRDb();

            //    BankHRBiz objBankHRBiz;
            //    objBankHRBiz = new BankHRBiz();
            //    objBankHRBiz.ID = 0;
            //    objBankHRBiz.NameA = "غير محدد";
            //    objBankHRBiz.NameE = "Not Specified";
            //    this.Add(objBankHRBiz);
            //    foreach (DataRow DR in objDb.Search().Rows)
            //    {
            //        objBankHRBiz = new BankHRBiz(DR);
            //        this.Add(objBankHRBiz);

            //    }
            //}
        }
        public bool Contains(string strName)
        {
            bool blReturned = false;
            foreach (BankHRBiz objBankHRBiz in this)
            {
                if (objBankHRBiz.BankBiz.Name == strName)
                {
                    blReturned = true;
                    break;
                }
            }
            return blReturned;

        }
        public virtual BankHRBiz this[int intIndex]
        {
            get
            {
                return (BankHRBiz)this.List[intIndex];
            }
        }

        public string IDsStr
        {
            get
            {
                string Returned = "";
                foreach (BankHRBiz objBiz in this)
                {
                    if (Returned != "")
                        Returned += ",";
                    Returned += objBiz.BankBiz.ID.ToString();
                }
                return Returned;
            }
        }
        public BankHRBiz RootBiz
        {
            set
            {
                _RootBiz = value;
            }
        }
        public virtual void Add(BankHRBiz objBankHRBiz)
        {
            List.Add(objBankHRBiz);  
        }
        public int GetIndex(int intID)
        {
            int intIndex = 0;
            foreach (BankHRBiz objBiz in this)
            {
                if (objBiz.BankBiz.ID == intID)
                {
                    return intIndex;
                }
                intIndex++;
            }
            return -1;
        }
        public BankHRCol GetBankHRByNameCol(string strBankHRName)
        {

            BankHRCol Returned = new BankHRCol(true);
            strBankHRName = strBankHRName.Replace(" ", "");
            foreach (BankHRBiz objbiz in this)
            {
                if (SysUtility.ReplaceStringComp(objbiz.BankBiz.NameA).IndexOf(strBankHRName) != -1)
                {
                    Returned.Add(objbiz);
                }
            }

            return Returned;
        }
        public static BankHRBiz GetBankHRBiz(int intID)
        {
            foreach (BankHRBiz objBiz in BankHRCol.CacheBankHRCol)
            {
                if (objBiz.BankBiz.ID == intID)
                {
                    return objBiz;
                }
            }
            return new BankHRBiz();
        }

        static BankHRCol _CacheBankHRCol;
        public static BankHRCol CacheBankHRCol
        {
            set
            {
                _CacheBankHRCol = value;
            }
            get
            {
                if (_CacheBankHRCol == null)
                {
                    _CacheBankHRCol = new BankHRCol(false);
                }
                return _CacheBankHRCol;
            }
        }
        public BankCol BankCol
        {
            get
            {
                BankCol Returned = new BankCol(true);
                
                foreach (BankHRBiz objBiz in this)
                {
                    Returned.Add(objBiz.BankBiz);
                }
                return Returned;
            }
        }

    }
    
}


