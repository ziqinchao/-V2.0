using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class USER_PersonInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userphone"] == null)
        {
            Response.Write("<script>alert('请重新登录！')</script>");
            Response.Redirect("Login.aspx");
        }
        else
        {
            //commcontact model = null;
            //model = new DataClass2().getreceiveInfo(Session["username"].ToString());
            //txtusername.Text = model.username;
            //lbname.Text = model.receivename;
            //lbaddress.Text = model.address;
            //lbphone.Text = model.userphone;
            //lbpost.Text = model.post;
        }
    }
}