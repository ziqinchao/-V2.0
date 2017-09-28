using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.AdminPage
{
    public partial class index : System.Web.UI.Page
    {
        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userphone"].ToString() != "")
            {
                userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
                if (int.Parse(new DB_UserInfomation().SelectUserRole(Session["userphone"].ToString())) == 0)
                {
                    Response.Redirect("../UserPage/index.aspx");
                }
            }
            else
            {
                Response.Redirect("../UserPage/Login.aspx");
            }
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnzhuxiao_Click(object sender, EventArgs e)
        {
            Session.Remove("userphone");
            Response.Redirect("~/UserPage/index.aspx");
        }
    }
}