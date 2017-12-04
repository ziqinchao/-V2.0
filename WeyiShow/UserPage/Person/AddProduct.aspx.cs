using FineUI;
using FineUI.Examples;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeyiShow.Libraries;

namespace WeyiShow.UserPage.Person
{
    public partial class AddProduct : System.Web.UI.Page
    {
        DB_ProductGood dbpg = new DB_ProductGood();
        string userguid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            GlobleClass.ExecBeforPageLoad(this.Page);
            if (!IsPostBack)
            {
               

            }
        }


        //protected void UploadImage_OnClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (imageUpload.PostedFile.FileName == "")
        //        {
        //            GlobleClass.PopInfo(this.Page, "要上传的文件不允许为空！");
        //            return;
        //        }
        //        else
        //        {
        //            string filePath = imageUpload.PostedFile.FileName;
        //            string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
        //            string fileSn = System.DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //            string serverpath = Server.MapPath(@"~\images\Goods\") + fileSn + filename.Substring(filename.LastIndexOf("."));
        //            string relativepath = @"~\images\Goods\" + fileSn + filename.Substring(filename.LastIndexOf("."));
        //            imageUpload.PostedFile.SaveAs(serverpath);
        //            hdimg.Value = relativepath;
        //            ImageMap1.ImageUrl = relativepath;
        //        }

        //    }
        //    catch (Exception error)
        //    {
        //        GlobleClass.PopInfo(this.Page, "处理发生错误！原因：" + error.ToString());
        //    }
        //}
        //protected void Add_Click(object sender, EventArgs e)
        //{
        //    hdID.Value = "";
        //    txtname.Text = "";
        //    txtprice.Text = "";
        //    txtunit.Text = "";
        //    txtintroduce.Text = "";
        //    txtclass.Text = "";
        //    txtspecial.Text = "";
        //    hdimg.Value = "";
        //}
        //protected void Save_Click(object sender, EventArgs e)
        //{
        //    if (hdID.Value.Trim().Length > 0)
        //    {
        //        //if (dc3.updateGood(hdID.Value.Trim(), txtname.Text, txtintroduce.Text, txtunit.Text, hdimg.Value, txtprice.Text, txtclass.Text, txtspecial.Text, DropDownList1.SelectedValue))
        //        //{
        //        //    GlobleClass.PopInfo(this.Page, "操作成功！");
        //        //}
        //        //else
        //        //{
        //        //    GlobleClass.PopInfo(this.Page, "操作失败！");
        //        //}
        //    }
        //    else
        //    {
        //        //if (dc3.SaveGood(hdID.Value.Trim(), txtname.Text, txtintroduce.Text, txtunit.Text, hdimg.Value, txtprice.Text, txtclass.Text, txtspecial.Text, DropDownList1.SelectedValue))
        //        //{
        //        //    GlobleClass.PopInfo(this.Page, "操作成功！");
        //        //}
        //        //else
        //        //{
        //        //    GlobleClass.PopInfo(this.Page, "操作失败！");
        //        //}
        //    }
        //}

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            dbpg.Insert(userguid, "", txtname.Text, txttitle.Text, picsp.Text, txtprice.Text, 1, classs.Text, DropDownList2.Text, 0, DateTime.Now, CKEditor1.Text);
        }
    }
}