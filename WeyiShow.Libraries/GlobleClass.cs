using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for GlobleClass
/// </summary>
/// 
namespace WeyiShow.Libraries
{
    public class GlobleClass
    {
        /// <summary>
        /// 绑定GridView数据源，如果数据源无数据显示表头和提示信息；
        /// </summary>
        /// <param name="dtData">要绑定的数据表</param>
        /// <param name="gvData">要绑定的GridView</param>
        /// <param name="message">无数据时提示信息</param>
        public static void FillGridView(DataTable dtData, GridView gvData, string message)
        {
            if (dtData.Rows.Count > 0)
            {
                gvData.DataSource = dtData;
                gvData.DataBind();
                return;
            }
            else
            {
                if (message == null)
                {
                    message = "无可浏览数据！";
                }
                int gvColumns = gvData.Columns.Count;
                string[] drData = new string[gvColumns];
                //drData.SetValue(message, 0);
                dtData.Rows.Add(drData);
                gvData.DataSource = dtData;
                gvData.DataBind();
                for (int i = 1; i < gvColumns; i++)
                {
                    gvData.Rows[0].Cells[i].Visible = false;
                }
                gvData.Rows[0].Cells[0].ColumnSpan = gvColumns;
                gvData.Rows[0].Cells[0].Text = message;
            }
        }

        public static string DateFormate(string dateString)
        {
            return dateString.Remove(10);
        }

        /// <summary>
        /// 清除历史缓存
        /// </summary>
        public static void ExecBeforPageLoad(Page page)
        {
            page.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
            page.Response.AddHeader("pragma", "no-cache");
            page.Response.AddHeader("cache-control", "private");
            System.Web.HttpContext hc = System.Web.HttpContext.Current;


        }

        /// <summary>
        /// 用来截取小数点后nleng位
        /// </summary>
        /// <param name="sString">sString原字符串。</param>
        /// <param name="nLeng">nLeng长度。</param>
        /// <returns>处理后的字符串。</returns>
        public static string VarStr(string sString, int nLeng)
        {
            int index = sString.IndexOf(".");
            if (index == -1 || index + 2 >= sString.Length)
                return sString;
            else
                return sString.Substring(0, (index + nLeng + 1));
        }

        /// <summary>
        /// 用弹出窗口弹出提示信息
        /// </summary>
        /// <param name="strInfo">弹出窗口提示信息</param>
        public static void PopInfo(string strInfo)
        {
            System.Web.HttpContext hc = System.Web.HttpContext.Current;
            hc.Response.Write("<script language='javascript'>");
            hc.Response.Write("alert('" + strInfo + "');");
            hc.Response.Write("</script>");
        }
        /// <summary>
        /// 用弹出窗口弹出提示信息
        /// </summary>
        /// <param name="page">母窗口</param>
        /// <param name="resultString">弹出窗口提示信息</param>
        public static void PopInfo(System.Web.UI.Page page, string resultString)
        {
            string s = "<script language = 'javascript'> ";
            s += "alert('" + resultString + "')";
            s += "</script>";
            //  System.Web.HttpContext hc = System.Web.HttpContext.Current;
            //hc.Response.Write(s);
            if (!page.IsStartupScriptRegistered("OperResult"))
                page.RegisterStartupScript("OperResult", s);
        }

        /// <summary>
        /// 设置窗口大小和Target目标，并打开。
        /// </summary>
        /// <param name="url">要打开页面文件路径</param>
        /// <param name="target">Target目标</param>
        /// <param name="WindowHeight">设置窗口高度（单位px）</param>
        /// <param name="WindowWidth">设置窗口宽度（单位px）</param>
        public static void OpenWindow(string url, string target, string WindowHeight, string WindowWidth)
        {
            System.Web.HttpContext hc = System.Web.HttpContext.Current;
            hc.Response.Write("<script language='javascript'>");
            hc.Response.Write("window.open('" + url + "','" + target + "',");
            hc.Response.Write("'height='+'" + WindowHeight + "'+',width='+'" + WindowWidth + "'+',top=50,left=50,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=no');");
            hc.Response.Write("</script>");
        }

        /// <summary>
        /// 是否数值
        /// </summary>
        /// <param name="num">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string num)
        {
            //return Regex.IsMatch(num, @"^\+?[1-9][0-9]*$");
            bool result = true;
            try
            {
                Convert.ToDouble(num);
            }
            catch
            {
                result = false;
            }
            return result;

        }



    }
}
