using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WeyiShow.UserPage.Person
{
    /// <summary>
    /// FileUploadHandler 的摘要说明
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        string time = DateTime.Now.ToString("yyyyMMddHHmmss");
                        string fname = context.Server.MapPath("~/uploads/" +time+ file.FileName);
                        file.SaveAs(fname);
                        sb.Append("~/uploads/" +time+ file.FileName);
                        sb.Append("%");
                    }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(sb);
                }
            }
            catch (Exception)
            {

                context.Response.ContentType = "text/plain";
                context.Response.Write("上传失败，请重试");
            }
            

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