using FineUI.Examples;
using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class Regist : System.Web.UI.Page
    {
        YunpianCode co = new YunpianCode();
        DB_UserInfomation userinfo = new DB_UserInfomation();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPwd.Attributes["value"] = txtPwd.Text;
            txtPwdAgain.Attributes["value"] = txtPwdAgain.Text;
            Session.Timeout = 30;

        }


        /// <summary>
        /// 获取验证码并发送到对应的手机号码上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void getcode_Click(object sender, EventArgs e)
        {
            string phone = PhoneNum.Text.Trim();
            string code = co.GetRandom(6);
            Session["Sjcode"] = code;
            // Response.Write("<script> alert('" + code.ToString() + "'); </script> ");
            string isSend = co.SingleSend(phone, code);
            if (Convert.ToInt32(isSend)==0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "myscript", "<script>djs();</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "myscript", "<script>shibai();</script>");
            }
        }





        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetGuid getguid = new GetGuid();
            string userguid=getguid.GetUserGuid();
            DateTime time = DateTime.Now;
            string s = sjyzm.Text.Trim();
            string ss = Session["Sjcode"].ToString();
            bool isEqual = s.Equals(ss);
            if (isEqual)
            {
                if (yzm.Text.ToUpper().Equals(Session["ValidCode"].ToString().ToUpper()))
                {                   
                    bool bResult = userinfo.Insert(userguid, txtUserName.Text.Trim(), txtPwd.Text.Trim(), txtEmail.Text.Trim(), PhoneNum.Text.Trim(), txtAddress.Text.Trim(),"0",time);
                    if (bResult)
                    {
                        Response.Write("<script>alert('注册成功！');window.location.href = 'Login.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('注册失败！')</script>");
                    } 
                }
                else
                {
                    Response.Write("<script>alert('验证码输入错误，请重新输入！')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('手机验证码输入错误，请重新获取！')</script>");
            }
        }
        
    }
}