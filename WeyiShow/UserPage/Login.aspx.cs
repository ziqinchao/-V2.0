using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userphone"] != null)
            {
                txtUserPhone.Text = Session["userphone"].ToString();
            }

            //用户输入
            txtUserPhone.Attributes.Add("Value", "请输入手机号码");
            txtUserPhone.Attributes.Add("OnFocus", "if(this.value=='请输入手机号码') {this.value=''}");
            txtUserPhone.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入手机号码'}");
            //密码输入
            txtPwd.Attributes.Add("Value", "请输入密码");
            txtPwd.Attributes.Add("OnFocus", "if(this.value=='请输入密码'){this.value=''}");
            txtPwd.Attributes.Add("OnBlur", "if(this.value==''){this.value='请输入密码'}");

            //验证码
            txtValidCode.Attributes.Add("Value", "验证码");
            txtValidCode.Attributes.Add("OnFocus", "if(this.value=='验证码') {this.value=''}");
            txtValidCode.Attributes.Add("OnBlur", "if(this.value==''){this.value='验证码'}");


            //
            if (!IsPostBack)
            {
                //内容
            }



        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtValidCode.Text.ToUpper().Equals(Session["ValidCode"].ToString().ToUpper()))
            {

                //调用DataClass的IsUserExist方法判断输入的信息是否正确
                bool bFlag = new DB_UserInfomation().Select(txtUserPhone.Text, txtPwd.Text);
                if (bFlag)
                {
                    Response.Write("<script>alert('欢迎" + txtUserPhone.Text + "登录')</script>");
                    Session.Add("userphone", txtUserPhone.Text.Trim());
                    if (int.Parse(new DB_UserInfomation().SelectUserRole(txtUserPhone.Text)) == 1)
                    {
                        Response.Redirect("../AdminPage/index.aspx");
                    }
                    else if (int.Parse(new DB_UserInfomation().SelectUserRole(txtUserPhone.Text)) == 0)
                    {
                        Response.Redirect("index.aspx");
                    }
                    else
                    {

                    }

                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误，请重新输入！')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('验证码输入错误，请重新输入！')</script>");
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            txtUserPhone.Text = null;
            txtPwd.Text = null;
            txtValidCode.Text = null;
        }
    }
}