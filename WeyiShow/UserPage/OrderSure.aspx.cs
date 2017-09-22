using FineUI;
using FineUI.Examples;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
           
            if (!Page.IsPostBack)
            {
                BindStringListToDropDownList();
                BindGrid();
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
                TextBox1.Text= dt.Rows[0]["ReceivePhone"].ToString();
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

        private void BindGrid()
        {
            DataTable table = new DB_ProductGood().SelectByProductId(Request.QueryString["ProductId"]).Table;

            Grid1.DataSource = table;
            Grid1.DataBind();
        }

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
                else {
                    Alert.ShowInTop("修改失败！");
                }
            }
            
        }

        protected void btnBuyClick_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "添加收货地址")
            {
                TextBox4.Hidden = false;
                TextBox5.Hidden = false;
                TextBox6.Hidden = false;
                TextBox7.Hidden = false;
                TextBox8.Hidden = false;
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
