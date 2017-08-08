using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DAO
/// </summary>
public static class DAO
{
    static DAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }
     public static string connectionStr
     {
         get { return WebConfigurationManager.ConnectionStrings["sharePhotosDB"].ConnectionString; }
     }
     public static SqlConnection GetConnection()
     {
         SqlConnection con = new SqlConnection(connectionStr);
         if (con.State != ConnectionState.Open)
         {
             con.Open();
         }
         return con;
     }
    //insert delete update
     public static int IDU(string sql, CommandType cmdType, SqlParameter[] param)
     {
         using (SqlConnection con = DAO.GetConnection())
         {
             using (SqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 cmd.CommandType = cmdType;
                 if (param != null)
                 {
                     cmd.Parameters.AddRange(param);
                 }
                 return cmd.ExecuteNonQuery();

             }
         }
     }
     public static DataTable GetDataTable(string sql, CommandType cmdType, SqlParameter[] param)
     {

         DataTable dt;
         using (SqlConnection con = DAO.GetConnection())
         {
             using (SqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = sql;
                 cmd.CommandType = cmdType;
                 if (param != null)
                 {
                     cmd.Parameters.AddRange(param);
                 }

                 using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                 {
                     dt = new DataTable();
                     da.Fill(dt);

                     return dt;
                 }

             }
         }
     }
}