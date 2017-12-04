using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Text;
using WeyiShow.Libraries;

namespace Test_Ajax.Linkage
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class LinkageAjax : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["type"]))
            {
                switch (context.Request.QueryString["type"])
                {
                    case "GetZoneInfo":
                        GetZoneInfo(context);
                        break;
                    case "AddReceive":
                        AddReceive(context);
                        break;
                    case "EditInformation":
                        EditInformation(context);
                        break;
                    case "ModifyPwd":
                        ModifyPwd(context);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 省市县三级联动
        /// </summary>
        /// <param name="context"></param>
        public void GetZoneInfo(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["zoneID"])
                && !string.IsNullOrEmpty(context.Request.QueryString["level"]))
            {
                string controlName = "";
                switch (context.Request.QueryString["level"])
                {
                    case"1":
                        controlName = "Drop_City";
                        break;
                    case"2":
                        controlName = "Drop_County";
                        break;
                    default:
                        return;
                }
                DB_Area ser = new DB_Area();
                DataTable dt = ser.GetZoneInfo(int.Parse(context.Request.QueryString["zoneID"]));
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("<select name=\"{0}\" id=\"{1}\" onchange=\"ChangeSlect(this.options[this.selectedIndex].value,this.name)\">", controlName, controlName));
                sb.Append("<option value=\"0\">未选择</option>");
                foreach (DataRow row in dt.Rows)
                {

                    sb.Append("<option value=\"");
                    sb.Append(row["codeID"].ToString());
                    sb.Append("\">");
                    sb.Append(row["name"].ToString());
                    sb.Append("</option>");
                }
                sb.Append("</select>");

                context.Response.Write(sb.ToString());
            }
        }


        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="context"></param>
        public void AddReceive(HttpContext context)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["rename"])
                && !string.IsNullOrEmpty(context.Request.QueryString["rephone"]) )
            {
                string userguid= context.Request.QueryString["userguid"];
                string rename = context.Request.QueryString["rename"];
                string rephone = context.Request.QueryString["rephone"];
                string readdress = context.Request.QueryString["readdress"];
                int i = new DB_ReceiveInfo().Insert(userguid, new GetGuid().GetUserGuid(), rename, rephone, "", readdress, "");

                context.Response.Write(i);
            }
        }

        /// <summary>
        /// 修改个人信息
        /// </summary>
        /// <param name="context"></param>
        public void EditInformation(HttpContext context)
        {
            string userguid = context.Request.QueryString["userguid"];
            string username = context.Request.QueryString["username"];
            string nickname = context.Request.QueryString["nickname"];
            string time = context.Request.QueryString["time"];
            DateTime dtime = Convert.ToDateTime(time);
            string phone = context.Request.QueryString["phone"];
            string email = context.Request.QueryString["email"];
            int sex = Convert.ToInt32(context.Request.QueryString["sex"]);

            int i = new DB_UserInfomation().UpdateUserInfo(userguid, nickname, username, sex, email, phone, dtime);
            context.Response.Write(i);
        }


        /// <summary>
        /// 修改密码（个人中心）
        /// </summary>
        /// <param name="context"></param>
        public void ModifyPwd(HttpContext context)
        {
            int i;
            DB_UserInfomation dbui = new DB_UserInfomation();
            string userguid = context.Request.QueryString["userguid"];
            string oldpwd = context.Request.QueryString["oldpwd"];
            string newpwd = context.Request.QueryString["newpwd"];
            DataView dv = dbui.SelectByGuidPwd(userguid,oldpwd);
            if (dv.Count == 1)
            {
                int n = dbui.UpdatePwd(userguid, newpwd);
                if (n == 1)
                    i = 1;
                else
                    i = 0;
            }
            else
                i = 0;                       
            context.Response.Write(i);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
