using Com.Alipay;
using FineUI;
using FineUI.Examples;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class OrderSure : PageBase
    {
        string userguid = "";
        DB_ReceiveInfo dbri = new DB_ReceiveInfo();
        DB_OrderInfo dboin = new DB_OrderInfo();
        DB_OrderItem dboit = new DB_OrderItem();
        DataTable table;
        double sumPrice = 0.0f;
        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            string s1 = Request.QueryString["GridCart"];
            string s2 = Request.QueryString["ProductId"];
            if (s1 != null)
            {
                BindGridCart();
                OutputSummaryData();
            }
            else if (s2 != null)
            {
                BindGrid();
                OutputSummaryData();
            }
            if (!Page.IsPostBack)
            {
                BindStringListToDropDownList();                
                LoadData();
            }

        }

        /// <summary>
        /// 给DropDownList绑定数据
        /// </summary>
        private void BindStringListToDropDownList()
        {
            DataSet ds = dbri.SelectReceiveRemark(userguid);
            DataTable dt = ds.Tables[0];


            DropDownList1.DataTextField = "ReceiveRemark";
            DropDownList1.DataValueField = "RowGuid";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new FineUI.ListItem("请选择", "00"));
        }


        /// <summary>
        /// DropDownList1的index改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            string rowguid = "";
            if (DropDownList1.SelectedItem != null)
            {
                rowguid = DropDownList1.SelectedValue;
                //labResult.Text = String.Format("选中项：{0}（值：{1}）", DropDownList1.SelectedItem.Text, DropDownList1.SelectedValue);
            }

            DataTable dt = dbri.SelectByRowGuid(rowguid).Tables[0];
            if (dt.Rows.Count > 0)
            {
                UserName.Text = dt.Rows[0]["ReceiveName"].ToString();
                TextBox1.Text = dt.Rows[0]["ReceivePhone"].ToString();
                TextBox2.Text = dt.Rows[0]["ReceivePost"].ToString();
                TextBox3.Text = dt.Rows[0]["ReceiveAddress"].ToString();
            }


        }






        private void LoadData()
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }


        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑



            // 2. 关闭本窗体，然后回发父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑

            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        /// 从商品详情页面获取商品信息并绑定到grid1
        /// </summary>
        private void BindGrid()
        {
            table = new DB_ProductGood().SelectByProductId(Request.QueryString["ProductId"]).Table;
            table.Columns.Add(new DataColumn("num", typeof(string)));
            table.Rows[0]["num"] = 1;
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 从购物车页面取出购物车信息的字符串，解析后绑定到grid1控件
        /// </summary>
        private void BindGridCart()
        {
            ///解析字符串
            string strwhere = "";
            List<string> a = new List<string>();
            List<string> b = new List<string>();
            string sss = Request.QueryString["GridCart"];
            string[] rowStr = sss.Split('!');
            for (int i = 0; i < rowStr.Length; i++)   //for遍历数组
            {
                string[] cellStr = rowStr[i].Split('.');
                if(cellStr.Length==2)
                {
                    a.Add(cellStr[0]);
                    b.Add(cellStr[1]);
                    new DB_ShopCar().UpdateNum(userguid, cellStr[0], Convert.ToInt32(cellStr[1]));
                    if (i == 0)
                        strwhere += " and ProductId='" + cellStr[0] + "'";
                    else
                        strwhere += " or ProductId='" + cellStr[0] + "'";
                }
                
            }
            string[] num = b.ToArray();

            //绑定数据到grid
            table = new DB_ProductGood().SelectByProductIds(strwhere).Table;
            table.Columns.Add(new DataColumn("num", typeof(string)));
            for (int i = 0; i < num.Length; i++)
            {
                table.Rows[i]["num"] = num[i];
            }
            Grid1.DataSource = table;
            Grid1.DataBind();

        }

        //获取单行的小计
        protected string GetXiaoji(object priceobj, object numberobj)
        {
            float price = Convert.ToSingle(priceobj);
            int number = Convert.ToInt32(numberobj);

            return String.Format("{0:F}", price * number);
        }

        /// <summary>
        /// 合计行
        /// </summary>
        private void OutputSummaryData()
        {
            DataTable source = table;
            
            foreach (DataRow row in source.Rows)
            {
                //System.Web.UI.WebControls.Label lable = FindControl("sum") as System.Web.UI.WebControls.Label;
                //string a = lable.Text.ToString();
                sumPrice += Convert.ToDouble(row["num"])*Convert.ToDouble(row["Price"]);
            }

            JObject summary = new JObject();
            summary.Add("sumPrice", sumPrice.ToString("F2"));


            Grid1.SummaryData = summary;

        }


        /// <summary>
        /// 修改收货信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEditClick_Click(object sender, EventArgs e)
        {
            if (btnEditClick.Text == "修改")
            {
                UserName.Enabled = true;
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
                btnEditClick.Text = "确定修改";
            }
            else
            {
                int i = dbri.Update(DropDownList1.SelectedValue.Trim(), UserName.Text, TextBox1.Text, TextBox2.Text, TextBox3.Text);
                if (i == 1)
                {
                    UserName.Enabled = false;
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox3.Enabled = false;
                    btnEditClick.Text = "修改";
                    Alert.ShowInTop("修改成功！");
                }
                else
                {
                    Alert.ShowInTop("修改失败！");
                }
            }

        }

        protected void btnBuyClick_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex <= 0)
            {
                Alert.ShowInTop("请选择收货地址！");
                BindStringListToDropDownList();
                return;
            }
            //商户订单号，商户网站订单系统中唯一订单号，必填
            string out_trade_no = new GetGuid().GetUserGuid();
            DateTime time = DateTime.Now;

            //添加订单信息表
            int TJOI = dboin.Insert(out_trade_no, time, userguid,sumPrice.ToString(), "待付款",DropDownList1.SelectedValue);
            if (TJOI == 1)
            {
                //遍历购物车
                foreach (DataRow myRow in table.Rows)
                {                    
                    try
                    {
                        //添加订单列表表orderitem
                        string ProductId = myRow[0].ToString();
                        int num = Convert.ToInt32(myRow[8]);
                        double Price = Convert.ToDouble(myRow[4]);

                        dboit.Insert(out_trade_no, ProductId, Price, num, Price * num);
                    }
                    catch (Exception mess)
                    {
                        Alert.ShowInTop(mess.Message);
                    }                    
                }
            }
            //订单名称，必填
            string subject = new DB_UserInfomation().SelectUserName(userguid)+"的订单";

            //付款金额，必填
            string total_fee = sumPrice.ToString().Trim();

            //收银台页面上，商品展示的超链接，必填
            string show_url = "我的订单";

            //商品描述，可空
            string body = "我的商品描述";
            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("seller_id", Config.seller_id);
            sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("body", body);
            //其他业务参数根据在线开发文档，添加参数.文档地址:https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.2Z6TSk&treeId=60&articleId=103693&docType=1
            //如sParaTemp.Add("参数名","参数值");

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            //PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(sHtmlText) + ActiveWindow.GetHideReference());
            Response.Write(sHtmlText);
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference(sHtmlText));
           
        }

        /// <summary>
        /// 添加收货地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "添加收货地址")
            {
                TextBox4.Hidden = false;
                TextBox5.Hidden = false;
                TextBox6.Hidden = false;
                TextBox7.Hidden = false;
                TextBox8.Hidden = false;
                Label1.Hidden = false;
                btnAdd.Text = "确定添加";
            }
            else
            {
                string rowguid = new GetGuid().GetUserGuid();
                int i = dbri.Insert(userguid, rowguid, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text);
                if (i == 1)
                {
                    TextBox4.Hidden = true;
                    TextBox5.Hidden = true;
                    TextBox6.Hidden = true;
                    TextBox7.Hidden = true;
                    TextBox8.Hidden = true;
                    Label1.Hidden = true;
                    btnAdd.Text = "添加收货地址";
                    Alert.ShowInTop("添加成功！");
                    BindStringListToDropDownList();
                }
                else
                {
                    Alert.ShowInTop("添加失败！");
                }
            }

        }

        
    }
}
