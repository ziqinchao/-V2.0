using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using WeyiShow.Libraries;

namespace WeyiShow.WebService
{
    /// <summary>
    /// WebServiceTest 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceTest : System.Web.Services.WebService
    {
        DB_WebService DBW = new DB_WebService();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userphone"></param>
        /// <param name="userpwd"></param>
        /// <param name="IdentityGuid"></param>
        /// <returns></returns>
        [WebMethod]
        public string LoginYz(string userphone, string userpwd, string IdentityGuid)
        {
            return DBW.Login(userphone, userpwd, IdentityGuid);
            //<?xml version="1.0" encoding="utf-8"?><paras><IdentityGuid>WeyiShow999</IdentityGuid><UserPhone>13063627273</UserPhone><UserPwd>123456</UserPwd></paras>
        }

    }
   
}
