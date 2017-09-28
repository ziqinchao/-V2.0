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
            GlobleClass.ExecBeforPageLoad(this.Page);
            if (!Page.IsPostBack)
            {
                query();
                query2();
                query3();
            }
        }
        private void query()
        {
            DataTable dt = new DB_ProductGood().SelectByDropDown("推荐新品").Tables[0];
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
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

    }
}