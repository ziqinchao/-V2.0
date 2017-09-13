using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class indexm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userphone"] == null)
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
                huanying.Text = "会员：" + Session["userphone"].ToString();
                if (int.Parse(new DB_UserInfomation().SelectUserRole(Session["userphone"].ToString())) == 1)
                {
                    Response.Redirect("Default.aspx");
                }
            }

        }
        protected void zhuxiao_Click(object sender, EventArgs e)
        {
            Session.Remove("userphone");
            Response.Redirect("index.aspx");
        }
        protected void submittext_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllProduct.aspx?ProductName=" + searchtext.Text.Trim());
        }
    }
}
