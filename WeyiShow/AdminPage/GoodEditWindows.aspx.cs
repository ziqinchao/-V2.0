using FineUI;
using FineUI.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeyiShow.AdminPage
{
    public partial class GoodEditWindows : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
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
    }
}