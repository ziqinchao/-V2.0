using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;
using WeyiShow.MODELS;

public partial class USER_MakeSure : System.Web.UI.Page
{
    //DataClass3 dc3 = new DataClass3(); 
    string userguid = "";
    DB_ReceiveInfo dbri = new DB_ReceiveInfo();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userphone"] == null)
        {
            Response.Write("<script>alert('请重新登录！')</script>");
            Response.Redirect("Login.aspx");
        }
        else if (Request["SumPrice"] == null)
        {
            Response.Write("<script>alert('请选择要购买的商品！')</script>");
            Response.Redirect("index.aspx");
        }
        else
        {
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label9.Visible = false;
            txtRename.Visible = false;
            editphone.Visible = false;
            editpost.Visible = false;
            editaddress.Visible = false;
            sureedit.Visible = false;
            quxiao.Visible = false;
            btnsubmit.Visible = false;
            btnzkk.Visible = false;

            //获取userguid，并根据userguid查询出收货地址等相关信息
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            lbname.Text = dbri.GetDetail(userguid).ReceiveName;
            lbphone.Text = dbri.GetDetail(userguid).ReceivePhone;
            lbpost.Text = dbri.GetDetail(userguid).ReceivePost;
            lbaddress.Text = dbri.GetDetail(userguid).ReceiveAddress;           
        }
    }
    protected void edit_Click(object sender, EventArgs e)
    {
        Label5.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        Label9.Visible = true;
        txtRename.Visible = true;
        editphone.Visible = true;
        editpost.Visible = true;
        editaddress.Visible = true;
        sureedit.Visible = true;
        quxiao.Visible = true;
        noedit.Enabled = false;
    }
    protected void quxiao_Click(object sender, EventArgs e)
    {
        Label5.Visible = false;
        Label6.Visible = false;
        Label7.Visible = false;
        Label9.Visible = false;
        txtRename.Visible = false;
        editphone.Visible = false;
        editpost.Visible = false;
        editaddress.Visible = false;
        sureedit.Visible = false;
        quxiao.Visible = false;
        noedit.Enabled = true;
    }
    protected void sureedit_Click(object sender, EventArgs e)
    {
        if (editphone.Text.Trim() == "" || editpost.Text.Trim() == "" || editaddress.Text.Trim() == ""||txtRename.Text.Trim()=="")
        {
            GlobleClass.PopInfo(this.Page, "请输入完整！");
        }
        else
        {
            int isse = dbri.Update(userguid, txtRename.Text.Trim(), editphone.Text.Trim(), editpost.Text.Trim(), editaddress.Text.Trim());
            if (isse == 1)
            {
                Label5.Visible = false;
                Label6.Visible = false;
                Label7.Visible = false;
                Label9.Visible = false;
                txtRename.Visible = false;
                editphone.Visible = false;
                editpost.Visible = false;
                editaddress.Visible = false;
                sureedit.Visible = false;
                quxiao.Visible = false;
                noedit.Enabled = true;
                btnsubmit.Visible = true;
                btnzkk.Visible = true;

                lbname.Text = dbri.GetDetail(userguid).ReceiveName;
                lbphone.Text = dbri.GetDetail(userguid).ReceivePhone;
                lbpost.Text = dbri.GetDetail(userguid).ReceivePost;
                lbaddress.Text = dbri.GetDetail(userguid).ReceiveAddress;


                //List<ShopCar> list = new DB_ShopCar().GetShopCar(userguid);
                //for (int i = 0; i < list.Count; i++)
                //{
                //    dc3.SaveOrderItem(list[i].ProductName, list[i].GoodId, list[i].Number, list[i].SumPrice, list[i].ImageUrl, Session["username"].ToString());
                //}

                //if (dc3.saveOrderInfo(Request["SumPrice"].ToString(), Session["username"].ToString(), txtRename.Text.Trim(), editphone.Text.Trim(), editpost.Text.Trim(), editaddress.Text.Trim()))
                //{
                //    GlobleClass.PopInfo(this.Page, "订单提交成功！");
                //    Response.Redirect("MyOrder.aspx");
                //}
                //else
                //{
                //    GlobleClass.PopInfo(this.Page, "订单提交失败！");
                //}

            }
        }
        
    }
    protected void noedit_Click(object sender, EventArgs e)
    {
        btnsubmit.Visible = true;
        btnzkk.Visible = true;

        //List<ShopCar> list=dc3.getShopCar(Session["username"].ToString());
        //for (int i = 0; i < list.Count; i++)
        //{
        //    dc3.SaveOrderItem(list[i].ProductName, list[i].GoodId, list[i].Number, list[i].SumPrice, list[i].ImageUrl, Session["username"].ToString());         
        //}
        //if (dc3.deleteShopCar(Session["username"].ToString()))
        //{
        //    GlobleClass.PopInfo(this.Page, "good！");
        //}
        //else
        //{
        //    GlobleClass.PopInfo(this.Page, "shibai！");
        //}
        //if (dc3.saveOrderInfo(Request["SumPrice"].ToString(), Session["username"].ToString(), lbname.Text, lbphone.Text, lbpost.Text, lbaddress.Text))
        //{
        //    GlobleClass.PopInfo(this.Page, "订单提交成功！");
        //    Response.Redirect("MyOrder.aspx");
        //}
        //else
        //{
        //    GlobleClass.PopInfo(this.Page, "订单提交失败！");
        //}

    }
}