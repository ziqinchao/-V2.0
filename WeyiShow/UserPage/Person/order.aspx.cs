using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class order : System.Web.UI.Page
    {
        DB_OrderInfo dboi = new DB_OrderInfo();
        string userguid = "0d09d316-9c01-4958-8322-9a268a78d551";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Repeater1.DataSource = BindRepeater1();
            Repeater1.DataBind();
        }

        public PagedDataSource BindRepeater1()
        {
            DataTable dt = dboi.SelectViewOrderInfoByUserGuid(userguid).Table;
            
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dt.DefaultView;
            pds.AllowPaging = true;//允许分页  
            pds.PageSize = 5;//单页显示项数  
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);
            return pds;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddlp = (DropDownList)e.Item.FindControl("ddlp");

                HyperLink lpfirst = (HyperLink)e.Item.FindControl("hlfir");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("hlp");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("hln");
                HyperLink lplast = (HyperLink)e.Item.FindControl("hlla");

                BindRepeater1().CurrentPageIndex = ddlp.SelectedIndex;

                int n = Convert.ToInt32(BindRepeater1().PageCount);//n为分页数  
                int i = Convert.ToInt32(BindRepeater1().CurrentPageIndex);//i为当前页  

                Label lblpc = (Label)e.Item.FindControl("lblpc");
                lblpc.Text = n.ToString();
                Label lblp = (Label)e.Item.FindControl("lblp");
                lblp.Text = Convert.ToString(BindRepeater1().CurrentPageIndex + 1);

                if (!IsPostBack)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ddlp.Items.Add(Convert.ToString(j + 1));
                    }
                }

                if (i <= 0)
                {
                    lpfirst.Enabled = false;
                    lpprev.Enabled = false;
                    lplast.Enabled = true;
                    lpnext.Enabled = true;
                }
                else
                {
                    lpprev.NavigateUrl = "?page=" + (i - 1);
                }
                if (i >= n - 1)
                {
                    lpfirst.Enabled = true;
                    lplast.Enabled = false;
                    lpnext.Enabled = false;
                    lpprev.Enabled = true;
                }
                else
                {
                    lpnext.NavigateUrl = "?page=" + (i + 1);
                }

                lpfirst.NavigateUrl = "?page=0";//向本页传递参数page  
                lplast.NavigateUrl = "?page=" + (n - 1);

                ddlp.SelectedIndex = Convert.ToInt32(BindRepeater1().CurrentPageIndex);//更新下拉列表框中的当前选中页序号  
            }

        }

        protected void ddlp_SelectedIndexChanged(object sender, EventArgs e)
        {//脚模板中的下拉列表框更改时激发  
            string pg = Convert.ToString((Convert.ToInt32(((DropDownList)sender).SelectedValue) - 1));//获取列表框当前选中项  
            Response.Redirect("repeate.aspx?page=" + pg);//页面转向  
        }
    }
}