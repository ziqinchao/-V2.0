using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using WeyiShow.Libraries;
using WeyiShow.MODELS;

namespace WeyiShow.UserPage
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userphone"] != null)
            {

            }
            else
            {
                Response.Redirect("UserPage/Login.aspx");
            }

            GlobleClass.ExecBeforPageLoad(this.Page);
            query();
            query2();
            query3();
        }

        private void query()
        {
            DataTable dt = new DB_ProductGood().SelectByDropDown("推荐新品").Tables[0];
            dlResult.DataSource = dt;
            dlResult.DataBind();
        }
        private void query2()
        {
            DataTable dt = new DB_ProductGood().SelectByDropDown("热卖专区").Tables[0];
            dlResult2.DataSource = dt;
            dlResult2.DataBind();
        }
        private void query3()
        {
            DataTable dt = new DB_ProductGood().SelectByDropDown("促销专区").Tables[0];
            dlResult3.DataSource = dt;
            dlResult3.DataBind();
        }
        protected void dlResult_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detailSee")
            {
                Session["address"] = "";
                Session["address"] = "indexm.aspx";
                //GlobleClass.OpenWindow("GoodDetail.aspx?ProductId=" + dlResult.DataKeys[e.Item.ItemIndex].ToString(), "_blank", "600", "800");
                Response.Redirect("GoodDetail.aspx?ProductId=" + dlResult.DataKeys[e.Item.ItemIndex].ToString());
            }
            else if (e.CommandName == "buyGoods")
            {
                AddShopCartItem(e, dlResult);
            }
        }



        //当购买商品时，获取商品信息
        public commOrderItem GetSubGoodsInformation(DataListCommandEventArgs e, DataList DLName)
        {
            //获取购物车中的信息
            commOrderItem Goods = new commOrderItem();
            Goods.ProductId = DLName.DataKeys[e.Item.ItemIndex].ToString();//产品编号
            string GoodsInfo = e.CommandArgument.ToString();//价格
            Goods.Price = GoodsInfo;
            return (Goods);

        }
        public void AddShopCartItem(DataListCommandEventArgs e, DataList DLName)
        {

            if (Session["userphone"] != null)
            {
                commOrderItem Goods = null;
                Goods = GetSubGoodsInformation(e, DLName);
                if (Goods == null)
                {
                    //显示错误信息
                    Response.Write("<script>alert('没有可用的数据');location='indexm.aspx';</script>");
                    return;
                }
                else
                {
                    //取得当前购物车有无此已购商品
                    string sql = "select * from ShopCar where ProductId=@ProductId and UserName=@UserName";
                    SqlParameter[] parameters ={ new SqlParameter("@ProductId", SqlDbType.VarChar, 50),
                new SqlParameter("@UserName", SqlDbType.VarChar, 50)};
                    parameters[0].Value = Goods.ProductId;
                    parameters[1].Value = Session["username"].ToString().Trim();
                    int i = new DataBaseHelper().Select(sql, parameters).Rows.Count;
                    if (i > 0)
                    {
                        sql = @"update ShopCar
		                    set Number=(Number+1),
			                    SumPrice=(SumPrice+@Price)                                
                            where ProductId=@ProductId and UserName=@UserName";
                    }
                    else
                    {
                        sql = @"Insert into ShopCar(UserName,ProductId,ProductName,ImageUrl,Price,Number,SumPrice)
		                   values(@UserName,@ProductId,@ProductName,@ImageUrl,@Price,1,@SumPrice)";

                    }
                    SqlParameter[] parameters1 ={
                new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                new SqlParameter("@ProductId", SqlDbType.VarChar, 50),
                new SqlParameter("@ProductName", SqlDbType.VarChar, 50),
                new SqlParameter("@ImageUrl", SqlDbType.VarChar, 50),
                 new SqlParameter("@Price", SqlDbType.Float),
                new SqlParameter("@SumPrice", SqlDbType.Float)
                                            };
                    string phone = Session["userphone"].ToString().Trim();
                    parameters1[0].Value = Session["userphone"].ToString().Trim();
                    parameters1[1].Value = Goods.ProductId;
                    parameters1[2].Value = new DB_ProductGood().GetDetail(Goods.ProductId).ProductName;
                    parameters1[3].Value = new DB_ProductGood().GetDetail(Goods.ProductId).ImageUrl;
                    parameters1[4].Value = float.Parse(Goods.Price);
                    parameters1[5].Value = float.Parse(Goods.Price);


                    //执行

                    int s = new DataBaseHelper().ExecuteNonQuery(sql, parameters1);

                    if (s > 0)
                    {
                        //GlobleClass.PopInfo(this.Page, "恭喜您，添加成功！");
                    }
                    else
                    {
                        GlobleClass.PopInfo(this.Page, "操作不成功！");
                    }
                }
            }
            else
            {
                GlobleClass.PopInfo(this.Page, "请先登录，谢谢！");
            }

        }
        protected void dlResult2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detailSee")
            {
                Session["address"] = "";
                Session["address"] = "indexm.aspx";
                //GlobleClass.OpenWindow("GoodDetail.aspx?ProductId=" + dlResult.DataKeys[e.Item.ItemIndex].ToString(), "_blank", "600", "800");
                Response.Redirect("GoodDetail.aspx?ProductId=" + dlResult2.DataKeys[e.Item.ItemIndex].ToString());
            }
            else if (e.CommandName == "buyGoods")
            {
                AddShopCartItem(e, dlResult2);
            }
        }
        protected void dlResult3_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "detailSee")
            {
                Session["address"] = "";
                Session["address"] = "indexm.aspx";
                //GlobleClass.OpenWindow("GoodDetail.aspx?ProductId=" + dlResult.DataKeys[e.Item.ItemIndex].ToString(), "_blank", "600", "800");
                Response.Redirect("GoodDetail.aspx?ProductId=" + dlResult3.DataKeys[e.Item.ItemIndex].ToString());
            }
            else if (e.CommandName == "buyGoods")
            {
                AddShopCartItem(e, dlResult3);
            }
        }

        public static string VarStr(string sString, int nLeng)
        {
            int index = sString.IndexOf(".");
            if (index == -1 || index + 2 >= sString.Length)
                return sString;
            else
                return sString.Substring(0, (index + nLeng + 1));
        }
    }
}