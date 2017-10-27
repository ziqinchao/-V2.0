using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WeyiShow.Libraries
{
    public class DB_WebService
    {
        string ConnectionStringName = "WeyiShow_Connection";


       
        public string Login(string userphone, string userpwd,string IdentityGuid)
        {
            string Status = "";
            string Description1 = "";
            string json = "";

            try
            {
                if (ChekHasRight(IdentityGuid))
                {
                    Status = "1";//校验通过成功
                    Description1 = "成功";                   
                    DataTable dv_cinfo = new DB_UserInfomation().SelectInfo(userphone, userpwd).Table;
                    if (dv_cinfo.Rows.Count > 0)
                    {
                        json = "{\"LoginStatus\":\"1\",\"UserName\":\""+ dv_cinfo.Rows[0]["UserName"].ToString() + "\",\"UserRole\":\"" + dv_cinfo.Rows[0]["UserRole"].ToString() + "\"}";
                        //json += "[";
                        //for (int i = 0; i < dv_cinfo.Rows.Count; i++)
                        //{

                        //    json += "{";
                        //    json += "\"" + "UserName" + "\":\"" + Convert.ToString(dv_cinfo.Rows[i]["UserName"]) + "\",";//用户名
                        //    json += "\"" + "UserRole" + "\":\"" + Convert.ToString(dv_cinfo.Rows[i]["UserRole"]) + "\"";//用户角色
                        //    json += "},";
                        //}
                        //json += "]";
                        //json = json.Remove(json.Length - 2, 1);
                    }
                    else
                    {
                        json = "";
                    }
                }
                else
                {
                    Status = "0";//校验不通过
                    Description1 = "所提供的IdentityGuid不正确！";
                }
            }
            catch (Exception ex)
            {
                Status = "0";//发生异常不成功
                Description1 = ex.ToString();

            }
            if (Status == "0")
            {
                return rtnInfo(Status, Description1);//返回的状态信息
            }
            else
            {
                return json;//返回详情信息
            }
        }


        /// <summary>
        /// 判断调用方是否有权限调用我们的函数
        /// </summary>
        /// <param name="IdentityGuid">WebConfig中预先配置的WebService调用标识</param>
        /// <returns></returns>
        public bool ChekHasRight(string IdentityGuid)
        {
            /*
             * 该函数调用前，需要在以下节中进行配置
             * <AppSettings>
             *   <add key="IdentityGuid" value="约定好的标识" />
             * </AppSettings>
             */
            string strIdentityConfig = System.Configuration.ConfigurationManager.AppSettings["IdentityGuid"];
            if (strIdentityConfig == IdentityGuid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public string rtnInfo(string Status, string Description)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                XmlElement xe = xd.CreateElement("EpointDataBody");
                xd.AppendChild(xe);
                XmlElement xdate = xd.CreateElement("DATA");
                xe.AppendChild(xdate);
                XmlElement xere = xd.CreateElement("ReturnInfo");
                xdate.AppendChild(xere);
                XmlElement xs;
                xs = xd.CreateElement("Status");
                xs.InnerText = Status; //写入成功与否的标记
                xere.AppendChild(xs);
                xs = xd.CreateElement("Description");
                xs.InnerText = Description;//错误或异常信息描述
                xere.AppendChild(xs);
                XmlElement xearea = xd.CreateElement("UserArea"); //UserArea 节
                xdate.AppendChild(xearea);
                return xd.OuterXml;
            }
            catch (Exception ex)
            {
                
                return "";
            }
        }
    }
}
