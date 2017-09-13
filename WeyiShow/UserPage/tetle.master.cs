using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class USER_tetle : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            zhuxiao.Visible = false;
            huanying.Visible = false;
            login.Visible = true;
            register.Visible = true;

        }
        else
        {
            zhuxiao.Visible = true;
            huanying.Visible = true;
            login.Visible = false;
            register.Visible = false;
            huanying.Text = "会员：" + Session["username"].ToString();
        }

    }
    protected void zhuxiao_Click(object sender, EventArgs e)
    {
        Session.Remove("username");
        Response.Redirect("index.aspx");
    }
    protected void submittext_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllProduct.aspx?ProductName=" + searchtext.Text.Trim());
    }
}
