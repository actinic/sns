using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace sns
{
    public partial class GetImageDatafromDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             if (!IsPostBack)
            {
                string sProductID = Request.QueryString["id"];
                 int spid=Int32.Parse(sProductID);

                 string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                 SqlConnection con = new SqlConnection(CS);//connects with database
                 string sql = "select picname from picsAdmin where pid=@spid";
                 SqlCommand cmd = new SqlCommand(sql, con);//executes sql queries

                cmd.Parameters.Add("@spid", spid);

                
                
            }
             
        }
    }
}