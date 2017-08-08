using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace sns
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(CS);
                using (conn)
                {
                    SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM picsAdmin", conn);
                    ad.Fill(dt);
                }
                DataList1.DataSource = dt;
                DataList1.DataBind();
                //LoadImages();
            }
        }

        private void LoadImages()
        {
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/admin/images")))
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fi = new FileInfo(strfile);
                imageButton.ImageUrl = "~/admin/images/" + fi.Name;
                imageButton.Height = Unit.Pixel(500);
                imageButton.Style.Add("padding", "5px");
                imageButton.Width = Unit.Pixel(100);
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                Panel1.Controls.Add(imageButton);
            }
        }
        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
           // Response.Redirect("main.aspx?ImageURL=" +
                //((ImageButton)sender).ImageUrl);
        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            search.Text = "You clicked the link button";
        }

        
    }
}