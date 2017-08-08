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
using System.Security.Cryptography;
using System.Text;

namespace sns.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.Page.User.Identity.IsAuthenticated)
            //{
            //Response.Redirect("~/index.aspx");
            //}
            if (!IsPostBack)
            {
                loadgrid();
            }
        }
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        public void loadgrid()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);//connects with database
            string sql = "select *from picsAdmin";
            SqlCommand cmd = new SqlCommand(sql, con);//executes sql queries

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();//collection of tables

            da.Fill(ds, "a");

            GridView1.DataSource = ds.Tables["a"];
            GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string dat = "  ";
                string picname = FileUpload1.FileName.ToString();
                Random rnd = new Random();
                int ran = rnd.Next(1, 99999);
                string temp = displayname.Text + picname + pictype.Text + ran;
                string imagesname = Hash(temp)+".jpg";
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("INSERT into picsAdmin (displayname,picname,type,dat) values(@displayname,@picname,@type,@dat)", con);
                    cmd.Parameters.AddWithValue("@displayname", displayname.Text);
                    
                    cmd.Parameters.AddWithValue("@picname", imagesname);
                    cmd.Parameters.AddWithValue("@type", pictype.Text);
                    cmd.Parameters.AddWithValue("@dat", dat);

                    try
                    {
                        con.Open();

                        Int32 rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Image uploaded successfully')</script>");
                            loadgrid();
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Upload your images')</script>");

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (FileUpload1.HasFile)
                    {
                        
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/admin/images/") + imagesname);
                    }
                }

            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CS);//connects with database
            string sql = "select *from picsAdmin where displayname=@displayname";//search by username
            SqlCommand cmd = new SqlCommand(sql, con);//executes sql queries
            cmd.Parameters.AddWithValue("@displayname", search.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();//collection of tables

            da.Fill(ds, "a");

            GridView1.DataSource = ds.Tables["a"];
            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            //get row item
            //int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Values[0]);
            //DataTable dt = blu.GetUserbyUserid(id);
            //if (dt.Rows.Count > 0)
            //{
                //usertype.Text = dt.Rows[0]["UserType"].ToString();
            //}

            loadgrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            loadgrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(CS);
            string sid = ((Label)GridView1.Rows[e.RowIndex].FindControl("pid")).Text;
            int pid = Convert.ToInt32(sid);
            TextBox displayname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDisplayName");
            DropDownList type = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddType");

            SqlCommand cmd = new SqlCommand("UPDATE picsAdmin set displayname=@displayname,type=@type where pid=@pid", con);
            cmd.Parameters.AddWithValue("@displayname", displayname.Text);
            cmd.Parameters.AddWithValue("@type", type.Text);
            cmd.Parameters.AddWithValue("@pid", pid);

            //int i = blu.UPdateUser(username.Text, password.Text, usertype.Text, userid);
            con.Open();
            Int32 rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                GridView1.EditIndex = -1;
                loadgrid();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            //TextBox test = (TextBox)GridView1.Rows[e.RowIndex].FindControl("displayname");
            string sid = ((Label)GridView1.Rows[e.RowIndex].FindControl("pid")).Text;
            int pid = Convert.ToInt32(sid);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE from picsAdmin where pid=@pid", con);
                cmd.Parameters.AddWithValue("@pid", pid);
                try
                {
                    con.Open();

                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        loadgrid();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static string Hash(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }
        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //selected code here
            if (e.CommandName.Equals("Select"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow clickedRow = GridView1.Rows[index];
                Label myTextBox = (Label)clickedRow.Cells[0].FindControl("pid");
                string text = myTextBox.Text;
                
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

}