using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class information : System.Web.UI.Page
    {
        string userguid = "";
        DB_UserInfomation dbui = new DB_UserInfomation();
        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            userguid1.Text = userguid;
            if (!IsPostBack)
            {
                BindBirth();
                BindForm();
            }
        }

        public void BindForm()
        {
            
            DataView dv = dbui.SelectUserInfo(userguid);
            username2.Text = dv.Table.Rows[0]["UserNickName"].ToString();
            username1.Text = dv.Table.Rows[0]["UserName"].ToString();
            string sexCode = dv.Table.Rows[0]["UserSex"].ToString();
            if (sexCode == "1")
            {
                RadioButton1.Checked = true;
            }
            else if (sexCode == "2")
            {
                RadioButton2.Checked = true;
            }
            else
                RadioButton3.Checked = true;

            if (dv.Table.Rows[0]["BirthDay"].ToString() != null&& dv.Table.Rows[0]["BirthDay"].ToString() != "")
            {
                DateTime birth = Convert.ToDateTime(dv.Table.Rows[0]["BirthDay"]);
                Year.Text = birth.Year.ToString();
                Month.Text = birth.Month.ToString();
                Day.Text = birth.Day.ToString();
            }
            
            userphone.Text= dv.Table.Rows[0]["UserPhone"].ToString();
            useremail.Text = dv.Table.Rows[0]["UserEmail"].ToString();

        }

        public void BindBirth()
        {
            //填充DropDownList
            int i = 0;
            Year.Items.Clear();
            for (i = 1900; i <= DateTime.Now.Year; i++)
            {
                ListItem item = new ListItem(i.ToString(), i.ToString());
                Year.Items.Add(item);
            }
            Month.Items.Clear();
            for (i = 1; i <= 12; i++)
            {
                string t = i < 10 ? "0" + i.ToString() : i.ToString();
                ListItem item = new ListItem(t, i.ToString());
                Month.Items.Add(item);
            }
            Day.Items.Clear();
            for (i = 1; i <= 31; i++)
            {
                string t = i < 10 ? "0" + i.ToString() : i.ToString();
                ListItem item = new ListItem(t, i.ToString());
                Day.Items.Add(item);
            }
            //给年和月的onchange 绑定方法，用于处理闰年的情况
            Year.Attributes["onchange"] = "OnSelectChange(" + Year.ClientID + "," + Month.ClientID + "," + Day.ClientID + ");";
            Month.Attributes["onchange"] = "OnSelectChange(" + Year.ClientID + "," + Month.ClientID + "," + Day.ClientID + ");";
            Year.SelectedValue = DateTime.Now.Year.ToString();
            Month.SelectedValue = DateTime.Now.Month.ToString();
            Day.SelectedValue = DateTime.Now.Day.ToString();
        }



        //公共属性，用于获取设置整个控件的日期值
        public DateTime Date
        {
            get { return DateTime.Parse(Year.SelectedValue + "-" + Month.SelectedValue + "-" + Day.SelectedValue); }
            set
            {
                Year.SelectedValue = value.Year.ToString();
                Month.SelectedValue = value.Month.ToString();
                Day.SelectedValue = value.Day.ToString();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string username = username1.Text;
            string nickname = username2.Text;
            string time = Year.Text + Month.Text + Day.Text;
            DateTime dtime = Convert.ToDateTime(time);
            string phone = userphone.Text;
            string email = useremail.Text;
            int sex = 0;
            if (RadioButton1.Checked)
                sex = 0;
            if (RadioButton2.Checked)
                sex = 1;
            if (RadioButton3.Checked)
                sex = 3;
            int i = dbui.UpdateUserInfo(userguid, nickname, username, sex, email, phone,dtime);
            if (i == 1)
            {
                Response.Write("<script>alert('修改成功！');</script>");
            }
            else
                Response.Write("<script>alert('修改失败！');</script>");

        }

       
    }
}