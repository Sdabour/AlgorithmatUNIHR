using System;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using System.Collections.Generic;
using AdoNetCore.AseClient;
namespace SharpVision.Base.BaseDataBase
{
    /// <summary>
    /// Summary description for DbConnection.
    /// </summary>
    /// 

    public class BaseSybaseDb
    {


        public static string SybaseConnStr
        {
            get
            {
                string strTemp = System.Configuration.ConfigurationManager.AppSettings["SYBASECon"];
                string Returned = strTemp;
                return Returned;
            }
        }
        List<string> _ExArr = new List<string>();
        public BaseSybaseDb()
        {
        }
        public BaseSybaseDb(string strDbServerName, string strDbUserID, string strDbPasswords, string strDbName)
        {
           

        }
        public BaseSybaseDb(string strConn)
        {
           // _sqlConnection = new sqlConnection(strConn);

        }
        
        public List<string> ExArr
        {
            get
            {
                if (_ExArr == null)
                    _ExArr = new List<string>();
                return _ExArr;
            }
        }
        public string ExStr
        {
            get
            {
                string Returned = "";
                foreach (string strTemp in ExArr)
                {
                    if (Returned != "")
                        Returned += "\n\t";
                    Returned += strTemp;
                }
                return Returned;
            }
        }
      
        

        
        public DataSet ReturnDataSet(string strSql) //select
        {
            try
            {

                using (AseConnection connection = new AseConnection(SybaseConnStr))
                {
                    connection.Open();
                    AseDataAdapter objAdapter = new AseDataAdapter(strSql, connection);
                    DataSet objDataSet = new DataSet();
                    objAdapter.Fill(objDataSet);
                    connection.Close();
                    return (objDataSet);
                }
            }
            catch
            {
                return null;
            }

        }
        public AseDataAdapter Adapter(string strSql)
        {
           AseConnection connection = new AseConnection(SybaseConnStr);
            connection.Open();
            AseDataAdapter Adpt = new AseDataAdapter(strSql, connection);
            return Adpt;
        }
        public object ReturnScalar(string strSql)
        {
            try
            {

                using (AseConnection connection = new AseConnection(SybaseConnStr))
                {
                    connection.Open();
                    object obj;
                   AseCommand com = new AseCommand(strSql, connection);
                    com.CommandTimeout = 99999999;
                    obj = com.ExecuteScalar();
                    connection.Close();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public object ReturnScalar(string strSql, AseConnection connection, AseTransaction objTrans)
        {
            try
            {


                object obj;
                AseCommand com = new AseCommand(strSql, connection);
                com.Transaction = objTrans;
                obj = com.ExecuteScalar();

                return obj;

            }
            catch
            {
                return null;
            }


        }

        public DataTable ReturnDatatable(string strSql, AseConnection connection)
        {
            string str = "";
            try
            {

                //SqlConnection connection = new SqlConnection(sqlConnection.ConnectionString);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                AseDataAdapter objAdapter = new AseDataAdapter(strSql, connection);
                objAdapter.SelectCommand.CommandTimeout = 99999999;
                DataTable objDatatable = new DataTable();
                objAdapter.Fill(objDatatable);
                return (objDatatable);

            }
            catch (SqlException ex)
            {
                str = ex.Message;

                return null;
            }


        }
        public static DataTable ReturnDatatable(string strSql)
        {
            string str = "";
            try
            {

                using (AseConnection connection = new AseConnection(SybaseConnStr))
                {
                    //connection.Open();  
                    //strSql = strSql.Replace("'", "''");
                    AseDataAdapter objAdapter = new AseDataAdapter(strSql, connection);
                    objAdapter.SelectCommand.CommandTimeout = 99999999;
                    DataTable objDatatable = new DataTable();

                    objAdapter.Fill(objDatatable);
                    connection.Close();

                    return (objDatatable);
                }


            }
            catch (SqlException ex)
            {
                str = ex.Message;

                return null;
            }
            finally
            {

            }


        }
        public DataTable ReturnDatatable(string strSql, string strTableName)
        {
            try
            {

                using (AseConnection connection = new AseConnection(SybaseConnStr))
                {
                    connection.Open();
                    AseDataAdapter objAdapter = new AseDataAdapter(strSql, connection);
                    objAdapter.SelectCommand.CommandTimeout = 99999999;
                    DataTable objDatatable = new DataTable(strTableName);
                    objAdapter.Fill(objDatatable);
                    connection.Close();
                    return (objDatatable);
                }
                //				return(objDatatable);
            }
            catch (SqlException ex)
            {
                string str = ex.Message;

                return null;
            }


        }

        public AseDataReader ReturnReader(string strSql) //select
        {

            AseConnection connection = new AseConnection(SybaseConnStr);
            connection.Open();
            //connection.Open();
            AseCommand objCommand = new AseCommand(strSql, connection);
            AseDataReader objReader = objCommand.ExecuteReader();
            //connection.Close();
            return (objReader);

        }




    }
     
}
