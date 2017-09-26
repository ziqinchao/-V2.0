<%@ Page Language="C#" AutoEventWireup="True" Inherits="WeyiShow.AdminPage.UploadGoods" Codebehind="UploadGoods.aspx.cs" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <style>
        .photo {
            height: 150px;
            line-height: 150px;
            overflow: hidden;
        }

            .photo img {
                height: 150px;
                vertical-align: middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" runat="server" Width="850px" EnableCollapse="true"
            ShowBorder="True" Title="表单">
            <Items>
                <f:TextBox runat="server" Label="商品名称" ID="GoodName" Required="true" ShowRedStar="true">
                </f:TextBox>
                <f:TextBox runat="server" Label="商品标题" ID="GoodTitle"
                    ShowRedStar="true">
                </f:TextBox>
                <f:NumberBox ID="GoodPrice" runat="server" Label="商品价格"
                    MinValue="0" NoDecimal="false" NoNegative="True" DecimalPrecision="2" Required="True" ShowRedStar="True">
                </f:NumberBox>
                <f:NumberBox Label="总数量" ID="GoodNum" runat="server"
                    NoDecimal="True" NoNegative="True" Required="True"
                    ShowRedStar="True" MinValue="0" />
                <f:DropDownList runat="server" ID="GoodClass" Label="类别">
                    <f:ListItem Text="雕塑" Value="Value1" Selected="true" />
                    <f:ListItem Text="编织" Value="Value2" />
                    <f:ListItem Text="油画" Value="Value3" />
                    <f:ListItem Text="可选项4" Value="Value4" />
                    <f:ListItem Text="可选项5" Value="Value5" />
                    <f:ListItem Text="可选项6" Value="Value6" />
                    <f:ListItem Text="可选择项7" Value="Value7" />
                    <f:ListItem Text="可选择项8" Value="Value8" />
                </f:DropDownList>


                <f:Image ID="imgPhoto" Label="商品图片：" CssClass="photo" ImageUrl="~/img/blank.png" ShowEmptyLabel="true" runat="server">
                </f:Image>
                <f:FileUpload runat="server" ID="filePhoto" ButtonText="上传个人头像" AcceptFileTypes="image/*" ButtonOnly="true"
                    AutoPostBack="true" OnFileSelected="filePhoto_FileSelected">
                </f:FileUpload>

            </Items>








        </f:SimpleForm>
        <f:ContentPanel ID="ContentPanel1" runat="server" BodyPadding="5px" Width="850px" EnableCollapse="true"
            ShowBorder="true" ShowHeader="true" Title="添加商品详情">
            <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="580">
		
            </CKEditor:CKEditorControl>
            
        </f:ContentPanel>
        <f:Button runat="server" Icon="SystemSave" ID="btnSubmit" OnClick="btnSubmit_Click"
            ValidateForms="SimpleForm1" Text="提交表单">
        </f:Button>

        <br />
    </form>
</body>
</html>
