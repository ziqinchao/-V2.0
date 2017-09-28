using FineUI;
using FineUI.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class GoodDetail : PageBase
    {
        string userguid = "";
        DB_ReceiveInfo dbri = new DB_ReceiveInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                if (Request["ProductId"] != null && Request["ProductId"].ToString().Trim().Length > 0)
                {

                    hdID.Value = Request["ProductId"].ToString().Trim();
                    //GetGoodsInfo(hdID.Value);
                    Label1.Text = new DB_ProductGood().GetDetail(hdID.Value).Decriptions;
                    GetGoodsInfo(Request.QueryString["ProductId"]);

                }
                Button2.OnClientClick = Window1.GetShowReference("OrderSure.aspx?ProductId=" + hdID.Value, "确认订单相关信息");
            }

           
        }

        public void GetGoodsInfo(string id)
        {
            //commProduct comm = new DB_ProductGood().getGoodInfo(id);
            lbname.Text = new DB_ProductGood().GetDetail(id).ProductName;
            lbclass.Text = new DB_ProductGood().GetDetail(id).Class;
            lbunit.Text = new DB_ProductGood().GetDetail(id).Title;
            lbprice.Text = new DB_ProductGood().GetDetail(id).Price;            
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

        protected void addCar_Click(object sender, EventArgs e)
        {

            if (Session["userphone"] == null)
            {
                Response.Write("<script>alert('请重新登录！')</script>");
                Response.Redirect("Login.aspx");
            }
            else
            {
                userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
                if (new DB_ShopCar().Insert(userguid, hdID.Value, new DB_ProductGood().GetDetail(hdID.Value).ProductName, new DB_ProductGood().GetDetail(hdID.Value).ImageUrl, float.Parse(lbprice.Text.ToString()), '1', float.Parse(lbprice.Text)))
                {
                    GlobleClass.PopInfo(this.Page, "添加购物车成功！");
                }
                else
                {
                    GlobleClass.PopInfo(this.Page, "添加购物车失败！");
                }
            }
        }

        
    }
}