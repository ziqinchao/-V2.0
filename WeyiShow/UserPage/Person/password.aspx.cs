using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class password : System.Web.UI.Page
    {
        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            userguid1.Text = userguid;
        }
    }
}