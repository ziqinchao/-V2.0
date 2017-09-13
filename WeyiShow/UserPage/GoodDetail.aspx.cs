using System;
using System.Collections.Generic;
using WeyiShow.MODELS;
using WeyiShow.Libraries;
using Com.Alipay;


public partial class USER_GoodDetail : System.Web.UI.Page
{
    string userguid;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        GlobleClass.ExecBeforPageLoad(this.Page);
        if (!IsPostBack)
        {
            if (Request["ProductId"] != null && Request["ProductId"].ToString().Trim().Length > 0)
            {

                hdID.Value = Request["ProductId"].ToString().Trim();
                //GetGoodsInfo(hdID.Value);
                Label1.Text = new DB_ProductGood().GetDetail(hdID.Value).Decriptions;
                GetGoodsInfo(Request.QueryString["ProductId"]);
                
            }
            
        }
      
    }
    public void GetGoodsInfo(string id)
    {
        //commProduct comm = new DB_ProductGood().getGoodInfo(id);
        lbname.Text = new DB_ProductGood().GetDetail(id).ProductName;
        lbclass.Text = new DB_ProductGood().GetDetail(id).Class;
        lbunit.Text = new DB_ProductGood().GetDetail(id).Title;
        lbprice.Text = new DB_ProductGood().GetDetail(id).Price;
        //lbspecial.Text = comm.Special;
        //txtintroduce.Text = comm.Introduce;
        ImageMapPhoto.ImageUrl = new DB_ProductGood().GetDetail(id).ImageUrl;
       // totalPrice.Text = comm.Price;
        //string sql = "SELECT  * FROM GOODS WHERE ID='" + id + "' ";
        //DataTable dt = new DataBaseHelper().Select(sql);
        //if (dt.Rows.Count > 0)
        //{
        //    txtName.Text = dt.Rows[0]["NAME"].ToString();
        //    ddlKind.SelectedValue = dt.Rows[0]["CLASS"].ToString();
        //    txtUnit.Text = dt.Rows[0]["UNIT"].ToString();
        //    txtPrice.Text = GlobleClass.VarStr(dt.Rows[0]["Price"].ToString(), 2);
        //    ImageMapPhoto.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
        //    txtShortDesc.Text = dt.Rows[0]["Introduce"].ToString();
        //}
    }
    protected void number_TextChanged(object sender, EventArgs e)
    {
        //null
    }
    private void panduan()
    {
        if (lbprice.Text.Contains("面议"))
        {
            lbprice.Text = "面议";
        }
        //else
        //{
        //    string s = number.Text.Trim();
        //    double a = double.Parse(s);
        //    if (s.Length > 0 && a > 0 && a <= 1000000000)
        //    {
        //        lbprice.Text = (a * double.Parse(lbprice.Text)).ToString();
        //    }
        //    else
        //    {
        //        GlobleClass.PopInfo(this.Page, "请正确填写！");
        //    }
        //}
    }
    //protected void jian_Click(object sender, EventArgs e)
    //{
    //    string s = number.Text.Trim();
    //    double a = double.Parse(s);
    //    if (a < 1)
    //    {
    //        panduan();
    //    }
    //    else
    //    {
    //        number.Text = (a - 1).ToString();
    //        panduan();
    //    }
    //}
    //protected void jia_Click(object sender, EventArgs e)
    //{
    //    string s = number.Text.Trim();
    //    double a = double.Parse(s);
    //    number.Text = (a + 1).ToString();
    //    panduan();
    //}
    protected void addCar_Click(object sender, EventArgs e)
    {

        if (Session["userphone"] == null)
        {
            Response.Write("<script>alert('请重新登录！')</script>");
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (new DB_ShopCar().Insert(userguid, hdID.Value,new DB_ProductGood().GetDetail(hdID.Value).ProductName, new DB_ProductGood().GetDetail(hdID.Value).ImageUrl,  float.Parse(lbprice.Text) ,'1', float.Parse(lbprice.Text)))
            {
                GlobleClass.PopInfo(this.Page, "添加购物车成功！");
            }
            else
            {
                GlobleClass.PopInfo(this.Page, "添加购物车失败！");
            }
        }
    }
    protected void buy_Click(object sender, EventArgs e)
    {

        if (Session["userphone"] == null)
        {
            Response.Write("<script>alert('请重新登录！')</script>");
            Response.Redirect("Login.aspx");
        }
        else
        {
            string userphone = Session["userphone"].ToString().Trim();
            userguid = new DB_UserInfomation().SelectUserGuid(userphone);
            //if (new DataClass2().SaveShopCar(Session["username"].ToString(), hdID.Value, lbname.Text, ImageMapPhoto.ImageUrl, float.Parse(lbprice.Text), int.Parse(number.Text), float.Parse(totalPrice.Text)))
            if (new DB_ShopCar().Insert(userguid, hdID.Value, new DB_ProductGood().GetDetail(hdID.Value).ProductName, new DB_ProductGood().GetDetail(hdID.Value).ImageUrl, float.Parse(lbprice.Text), '1', float.Parse(lbprice.Text)))
            {
                //Response.Redirect("MakeSure.aspx?SumPrice=" + totalPrice.Text.Trim());
                //商户订单号，商户网站订单系统中唯一订单号，必填
                string out_trade_no = new GetGuid().GetUserGuid();

                //订单名称，必填
                string subject = lbname.Text.Trim();

                //付款金额，必填
                //string total_fee = totalPrice.Text.Trim();
                string total_fee = lbprice.Text.Trim();

                //收银台页面上，商品展示的超链接，必填
                string show_url = lbname.Text.Trim();

                //商品描述，可空
                string body = lbname.Text.Trim();



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
                Response.Write(sHtmlText);
            }
            else
            {
                GlobleClass.PopInfo(this.Page, "购买失败！");
            }
        }
    }
}