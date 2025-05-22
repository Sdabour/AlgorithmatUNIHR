using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AlgorithmatMVC.Milango.MilangoBiz
{
	public class MilangoService
	{
		public static string ConStr()
		{
			string strTemp = System.Configuration.ConfigurationManager.AppSettings["MilangoServiceDBCon"];
			return strTemp;// "server=.\\sql2014;database=DGDB;uid=sa;pwd=theking;";
			
		}
		public static int SubmitTicket(int category, int item, string user, DateTime time, string project, string unit, string comment, string imageurl)
		{
			string bp = user;
			if (bp.IndexOf("-") != -1)
			{
				string[] str = bp.Split('-');
				if(str.Length>0)
				bp = str[0];

			}
			SqlParameter ticketid = new SqlParameter("@requestid", 0);
			ticketid.Direction = System.Data.ParameterDirection.Output;

			SqlParameter[] parameters = new SqlParameter[] {
			new SqlParameter("@categoryid",category),
			new SqlParameter("@serviceid",item),
			new SqlParameter("@partner",bp),
			new SqlParameter("@timeslot",time),
			new SqlParameter("@projectcode",project),
			new SqlParameter("@unitcode",unit),
			new SqlParameter("@comment",comment),
			new SqlParameter("@imgurl",imageurl),
			ticketid,
		};
			SqlConnection con = new SqlConnection(ConStr());
			SqlCommand com = new SqlCommand("dbo.spApiAddRequest", con);
			com.Parameters.AddRange(parameters);
			com.CommandType = System.Data.CommandType.StoredProcedure;

			con.Open();
			com.ExecuteNonQuery();
			con.Close();

			return int.Parse(ticketid.Value.ToString());
		}
		public static List<ServiceCategory> GetCategories()
		{
			List<ServiceCategory> categories = new List<ServiceCategory>();
			SqlConnection con = new SqlConnection(ConStr());
			SqlCommand com = new SqlCommand("dbo.spApiGetCategories", con);
			com.CommandType = System.Data.CommandType.StoredProcedure;
			SqlDataAdapter ada = new SqlDataAdapter(com);
			DataTable dt = new DataTable();
			ada.Fill(dt);
			if (con.State != ConnectionState.Closed)
				con.Close();

			foreach (DataRow row in dt.Rows)
				categories.Add(new ServiceCategory(int.Parse(row["categoryid"].ToString()), row["NameAr"].ToString(), row["NameAr"].ToString(), int.Parse(row["parentid"].ToString())));

			return categories;
		}
		public static List<ServiceItem> GetItems()
		{
			List<ServiceItem> items = new List<ServiceItem>();
			SqlConnection con = new SqlConnection(ConStr());
			SqlCommand com = new SqlCommand("dbo.spApiGetServices", con);
			com.CommandType = System.Data.CommandType.StoredProcedure;
			SqlDataAdapter ada = new SqlDataAdapter(com);
			DataTable dt = new DataTable();
			ada.Fill(dt);
			if (con.State != ConnectionState.Closed)
				con.Close();

			foreach (DataRow row in dt.Rows)
				items.Add(new ServiceItem(int.Parse(row["ServiceID"].ToString()), row["NameAr"].ToString(), row["NameEn"].ToString(), int.Parse(row["CategoryID"].ToString()), double.Parse(row["Price"].ToString())));



			return items;
		}
	}
	public class ServiceCategory
	{
		public ServiceCategory(int categoryID, string categoryNameAr, string categoryNameEn, int parentID)
		{
			CategoryID = categoryID;
			CategoryNameAr = categoryNameAr;
			CategoryNameEn = categoryNameEn;
			ParentID = parentID;
		}
		public ServiceCategory()
		{
		}

		public int CategoryID { get; set; }
		public string CategoryNameAr { get; set; }
		public string CategoryNameEn { get; set; }
		public int ParentID { get; set; }

	}
	public class ServiceItem
	{

		public ServiceItem()
		{

		}

		public ServiceItem(int itemID, string itemNameAr, string itemNameEn, int categoryID, double itemPrice)
		{
			ItemID = itemID;
			NameAr = itemNameAr;
			NameEn = itemNameEn;
			CategoryID = categoryID;
			ItemPrice = itemPrice;
		}

		public int ItemID { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public int CategoryID { get; set; }
		public double ItemPrice { get; set; }
	}
}