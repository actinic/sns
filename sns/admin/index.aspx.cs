using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

namespace sns.admin
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from usersAdmin where username =@username and password=@password", con);
            cmd.Parameters.AddWithValue("@username", username.Text);
            //string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordInput.Text, "SHA1");
            cmd.Parameters.AddWithValue("@password", password.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("adminPics/adminPics.aspx");
                con.Close();
                //messageDisplay.Text = "true";
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
                con.Close();
            }
        }
    }
}