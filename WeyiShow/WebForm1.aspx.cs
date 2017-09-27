using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;
using WeyiShow.Yunpian;
using Newtonsoft.Json;
using WeyiShow.MODELS;

namespace WeyiShow
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ss= new Code().SingleSend();
            YunResult yunpian = JsonConvert.DeserializeObject<YunResult>(ss);
            TextBox2.Text = yunpian.code + yunpian.msg + yunpian.mobile;
        }
    }


   

}