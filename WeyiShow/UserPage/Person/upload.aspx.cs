﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeyiShow.UserPage.Person
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;
            string msg = string.Empty;
            string error = string.Empty;
            string imgurl;
            if (files.Count > 0)
            {
                files[0].SaveAs(Server.MapPath("/") + System.IO.Path.GetFileName(files[0].FileName));
                msg = " 成功! 文件大小为:" + files[0].ContentLength;
                imgurl = "/" + files[0].FileName;
                string res = "{ error:'" + error + "', msg:'" + msg + "',imgurl:'" + imgurl + "'}";
                Response.Write(res);
                Response.End();
            }
        }
    }
}