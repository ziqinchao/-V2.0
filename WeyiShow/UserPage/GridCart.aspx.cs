using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using FineUI.Examples;
using FineUI;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage
{
    public partial class GridCart : PageBase
    {
        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        #region BindGrid

        private void BindGrid()
        {
            DataTable table = new DB_ShopCar().SelectByUserGuid(userguid).Table;
            Grid1.DataSource = table;
            Grid1.DataBind();

            Grid1.SelectedRowIndexArray = new int[] { 0, 1 };
        }


        #endregion

        #region Events

        protected void btnGotoPay_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ol>");
            foreach(int rowIndex in Grid1.SelectedRowIndexArray) {
                System.Web.UI.WebControls.TextBox tbxNumber = (System.Web.UI.WebControls.TextBox)Grid1.Rows[rowIndex].FindControl("tbxNumber");

                sb.AppendFormat("<li>{0}（{1}）</li>", Grid1.DataKeys[rowIndex][0], tbxNumber.Text);
            }
            sb.Append("</ol><hr/>");

            sb.AppendFormat("共 {0} 件商品，总计 ¥{1}", Request.Form["TOTAL_NUMBER"], Request.Form["TOTAL_PRICE"]);

            Alert.Show(sb.ToString(), MessageBoxIcon.Information);
        }

        #endregion




        //获取单行的小计
        protected string GetXiaoji(object priceobj, object numberobj)
        {
            float price = Convert.ToSingle(priceobj);
            int number = Convert.ToInt32(numberobj);

            return String.Format("{0:F}", price * number);
        }

        

    }
}
