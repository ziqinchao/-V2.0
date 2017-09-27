using FineUI;
using FineUI.Examples;
using System;
using System.Collections.Generic;
using WeyiShow.Libraries;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WeyiShow.AdminPage
{
    public partial class UploadGoods : PageBase
    {

        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userphone"].ToString() != "")
            {
                userguid = new DB_UserInfomation().SelectUserGuid(Session["userphone"].ToString());
                if (int.Parse(new DB_UserInfomation().SelectUserRole(Session["userphone"].ToString())) == 0)
                {
                    Response.Redirect("../UserPage/index.aspx");
                }
            }
            else
            {
                Response.Redirect("../UserPage/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                
            }
        }


        protected void filePhoto_FileSelected(object sender, EventArgs e)
        {
            if (filePhoto.HasFile)
            {
                string fileName = filePhoto.ShortFileName;

                if (!ValidateFileType(fileName))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }


                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                filePhoto.SaveAs(Server.MapPath("~/images/Goods/" + fileName));

                imgPhoto.ImageUrl = "~/images/Goods/" + fileName;

                // 清空文件上传组件
                filePhoto.Reset();
            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (imgPhoto.ImageUrl == "~/img/blank.png")
            {
                filePhoto.MarkInvalid("请先上传商品照片！");
                Alert.ShowInTop("请先上传商品照片！");
                return;
            }
            string productid = new GetGuid().GetUserGuid();
            DB_ProductGood dbpg = new DB_ProductGood();
            int i = dbpg.Insert(userguid, productid, GoodName.Text, GoodTitle.Text, imgPhoto.ImageUrl, GoodPrice.Text, Convert.ToInt32(GoodNum.Text), GoodClass.Text, "", '0', DateTime.Now, CKEditor1.Text);
            if (i == 1)
            {
                filePhoto.Reset();
                GoodName.Reset();
                GoodPrice.Reset();
                GoodTitle.Reset();
                GoodClass.Reset();
                CKEditor1.Text = "";
                Alert.ShowInTop("添加成功！");
            }
            //Alert.ShowInTop("用户名：" + tbxUserName.Text + "<br/>" +
            //        "邮箱：" + tbxEmail.Text + "<br/>" +
            //        "头像地址：" + imgPhoto.ImageUrl + "<br/>");

            //// 清空表单字段（注意，不要清空imgPhoto，否则就看不到上传的头像了）
            

        }

    }
}