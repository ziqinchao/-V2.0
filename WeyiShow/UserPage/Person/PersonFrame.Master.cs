using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class PersonFrame : System.Web.UI.MasterPage
    {
        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userphone"] == null)
            {
                Response.Write("<Script Language=JavaScript>...alert('请重新登录！');window.navigate('../Login.aspx');</Script>");
            }
            else
            {
                userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
                username.Text = new DB_UserInfomation().SelectUserName(userguid);
                
            }
        }

        

        protected void zhuxiao_Click1(object sender, EventArgs e)
        {
            Session.Remove("userphone");
            Response.Redirect("../index.aspx");
        }
    }
}