using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class address : System.Web.UI.Page
    {
        string userguid = "";
        
        DB_ReceiveInfo dbri = new DB_ReceiveInfo();      

        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            userguid1.Text = userguid;
            if (!IsPostBack)
            {
                BindReceive();
                BindSSX();
            }
            
        }
        public void BindReceive()
        {
            DataTable dt = dbri.Select(userguid).Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        public int delAdress(object rowguid)
        {
            string RowGuid = rowguid.ToString();
            return dbri.Delete(RowGuid);
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            String str = e.CommandName.ToString();
            if (str == "Delete")
            {
                string RowGuid = e.CommandArgument.ToString();
                int i= dbri.Delete(RowGuid);
                if (i == 1)
                   Response.Redirect("address.aspx");
            }
            else if (str == "Update")
            {
                //修改操作
                //调用你写的修改方法进行修改
            }
        }



        protected void btnsave_Click(object sender, EventArgs e)
        {
            //string dizhi = sheng.Text + shi.Text + xian.Text + reintro.Text;
            //dbri.Insert(userguid, new GetGuid().GetUserGuid(), rename.Text, rephone.Text, "", dizhi, "");
        }

        public void BindSSX()
        {
            DataTable dt = new DB_Area().GetZoneInfo(0);
            Drop_Province.DataSource = dt;
            Drop_Province.DataTextField = "name";
            Drop_Province.DataValueField = "codeID";
            Drop_Province.DataBind();
        }

        protected void Drop_Province_DataBound(object sender, EventArgs e)
        {
            Drop_Province.Items.Insert(0, new ListItem("未选择", "0"));
            Drop_Province.SelectedValue = "0";
        }



    }
}