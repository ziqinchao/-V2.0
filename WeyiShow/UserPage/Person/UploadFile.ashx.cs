using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    /// <summary>
    /// UploadFile 的摘要说明
    /// </summary>
    public class UploadFile : IHttpHandler
    {
        DB_UserContact dbuc = new DB_UserContact();
        public void ProcessRequest(HttpContext context)
        {
                       
            if (!string.IsNullOrEmpty(context.Request.QueryString["type"]))
            {
                switch (context.Request.QueryString["type"])
                {
                    case "Save":
                        Save(context);
                        break;
                    
                    default:
                        break;
                }
            }
        }
        public void Save(HttpContext context)
        {
            string pathz = context.Request.QueryString["pathz"];
            string pathf = context.Request.QueryString["pathf"];
            string username = context.Request.QueryString["username"];
            string usercard = context.Request.QueryString["usercard"];
            string userguid= context.Request.QueryString["userguid"];
            int i= dbuc.Insert(userguid, usercard, username, pathz, pathf, "", "");
            context.Response.Write(i);
        }

        private string uploadFile(string filenamePath)
        {
            //图片格式  
            string fileNameExit = filenamePath.Substring(filenamePath.IndexOf('.')).ToLower();
            if (!checkfileExit(fileNameExit))
            {
                return "图片格式不正确";
            }
            //保存路径  
            string toFilePath = "UploadFiles/";
            //物理完整路径  
            string toFileFullPath = HttpContext.Current.Server.MapPath(toFilePath);
            //检查是否有该路径，没有就创建  
            if (!Directory.Exists(toFileFullPath))
            {
                Directory.CreateDirectory(toFileFullPath);
            }
            //生成将要保存的随机文件名  
            string toFileName = getFileName();
            //将要保存的完整路径  
            string saveFile = toFileFullPath + toFileName + fileNameExit;
            //创建WebClient实例  
            WebClient myWebClient = new WebClient();
            //设定window网络安全认证  
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            //要上传的文件  
            FileStream fs = new FileStream(filenamePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            //使用UploadFile方法可以用下面的格式  
            myWebClient.UploadFile(saveFile, filenamePath);
            return saveFile;
        }
        /// <summary>  
        /// 检查图片格式  
        /// </summary>  
        /// <param name="_fileExit">文件后缀名</param>  
        /// <returns></returns>  
        private bool checkfileExit(string _fileExit)
        {
            string[] allowExit = new string[] { ".gif", ".jpg", ".png" };//判断文件类型  
            for (int i = 0; i < allowExit.Length; i++)
            {
                if (allowExit[i] == _fileExit)
                {
                    //符合文件类型则返回true;  
                    return true;
                }
            }
            return false;
        }
        /// <summary>  
        /// 得到随机的文件名  
        /// </summary>  
        /// <returns></returns>  
        public static string getFileName()
        {
            Random rd = new Random();
            StringBuilder serial = new StringBuilder();
            serial.Append(DateTime.Now.ToString("yyMMddHHmmssff"));
            serial.Append(rd.Next(0, 9999).ToString());
            return serial.ToString();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        //把返回值编译成json格式  
        public string uploadFileResult(string result)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jswriter = new JsonTextWriter(sw))
            {
                jswriter.Formatting = Formatting.Indented;
                jswriter.WriteStartObject();
                jswriter.WritePropertyName("result");
                jswriter.WriteValue(result);
                jswriter.WriteEnd();
            }
            return sb.ToString();
        }


        
    }
}