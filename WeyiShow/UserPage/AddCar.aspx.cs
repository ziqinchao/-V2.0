using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WeyiShow.Libraries;
using System.Data;
using FineUI.Examples;
using Newtonsoft.Json.Linq;

public partial class USER_AddCar : PageBase
{
    string userguid="";
    protected void Page_Load(object sender, EventArgs e)
    {
        GlobleClass.ExecBeforPageLoad(this.Page);
        if (Session["userphone"] == null)
        {
            Response.Write("<script>alert('请重新登录！')</script>");
            Response.Redirect("Login.aspx");
        }
        else
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            //if (new DataClass3().getGoodCount(Session["userphone"].ToString()) > 0)
            //{
            //    lbtotal.Text = new DataClass3().getPriceTotal(Session["username"].ToString()).ToString();
            //} 
        }

        if (!IsPostBack)
        {
            BindGrid();
            OutputSummaryData();
        }
    }
    DataTable table;
    private void BindGrid()
    {
        table = new DB_ShopCar().SelectByUserGuid(userguid).Table;
        Grid1.DataSource = table;
        Grid1.DataBind();
    }

    private void OutputSummaryData()
    {
        DataTable source = table;
        double feeTotal = 0.0f;
        foreach (DataRow row in source.Rows)
        {            
            feeTotal += Convert.ToDouble(row["SumPrice"]);
        }
        JObject summary = new JObject();
        summary.Add("fee", feeTotal.ToString("F2"));
        Grid1.SummaryData = summary;

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //if ((e.Item.FindControl("CheckBox1") as CheckBox).Checked==true) {
        //GlobleClass.PopInfo(this.Page, "" +(e.Item.FindControl("Label1") as Label).Text+"");
        string id= (e.Item.FindControl("Label1") as Label).Text;
        if (e.CommandName == "delete")
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('请重新登录！')</script>");
                Response.Redirect("Login.aspx");
            }
            //if (delete(id))
            //{
            //    Response.Redirect("AddCar.aspx");
            //}
            //else 
            //{
            //    Response.Write("<script>alert('失败！')</script>");
            //}
        }
        else if (e.CommandName == "decrease")
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('请重新登录！')</script>");
                Response.Redirect("Login.aspx");
            }
            //if (new DataClass3().getNumber(id) < 1)
            //{
            //    GlobleClass.PopInfo(this.Page, "您的数字太小了！");
            //}
            //else
            //{
            //    //if (new DataClass3().decreaseNum(id, Session["username"].ToString(),(e.Item.FindControl("Label3") as Label).Text))
            //    //{
            //    //    Response.Redirect("AddCar.aspx");
            //    //}
            //}
        }
        else if (e.CommandName == "add")
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('请重新登录！')</script>");
                Response.Redirect("Login.aspx");
            }
            //if (new DataClass3().addNum(id, Session["username"].ToString(), (e.Item.FindControl("Label3") as Label).Text))
            //{
            //    Response.Redirect("AddCar.aspx");
            //}
        }
    }

    //private bool delete(string id)
    //{
    //    string strname = Session["username"].ToString();
    //    string strComm = @"delete  ShopCar where UserName=@NAME and ProductId=@ID";
    //    SqlParameter[] pms = new SqlParameter[] { 
    //        new SqlParameter("@NAME",System.Data.SqlDbType.VarChar,50){ Value=strname },
    //        new SqlParameter("@ID",System.Data.SqlDbType.VarChar,50){ Value=id },
    //        };
    //    //return SqlHelper.ExecuteNonQuery(strComm, System.Data.CommandType.Text, pms) > 0 ? true : false;
    //}

    protected void submit_Click(object sender, EventArgs e)
    {
        //if (new DataClass3().getGoodCount(Session["username"].ToString()) == 0)
        //{
        //    GlobleClass.PopInfo(this.Page, "购物车中没物品，请去选购");
        //}
        //else
        //{
        //    Response.Redirect("MakeSure.aspx?SumPrice=" + lbtotal.Text);
        //}
    }
}