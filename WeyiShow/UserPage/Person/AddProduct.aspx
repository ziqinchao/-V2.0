<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="True" CodeBehind="AddProduct.aspx.cs" Inherits="WeyiShow.UserPage.Person.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/infstyle.css" rel="stylesheet" type="text/css">

    <div class="user-info">
        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">上传商品</strong> / <small>Personal&nbsp;information</small></div>
        </div>
        <hr />
        <div class="info-main">
            <form class="am-form am-form-horizontal">

                <div>
                    <div class="cardPic">
                        <img id="pic" src="../images/cardbgz.png">
                        <input id="upload" name="upload" accept="image/*" type="file" style="display: none" />
                    </div>
                    <input id="btnUpload" class="am-btn-primary" type="button" value="上传" />
                    <div style="display: none">
                        <asp:TextBox ID="picsp" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="am-form-group">
                    <label for="user-name2" class="am-form-label">商品名称</label>
                    <div class="am-form-content">
                        <%--<input type="text" id="user-name2" placeholder="nickname">--%>
                        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="am-form-group">
                    <label for="user-name" class="am-form-label">标题</label>
                    <div class="am-form-content">
                        <%--<input type="text" id="user-name2" placeholder="name">--%>
                        <asp:TextBox ID="txttitle" runat="server"></asp:TextBox>
                    </div>
                </div>



                <div class="am-form-group">
                    <label for="user-phone" class="am-form-label">价格</label>
                    <div class="am-form-content">
                        <%--<input id="user-phone" placeholder="telephonenumber" type="tel">--%>
                        <asp:TextBox ID="txtprice" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="am-form-group">
                    <label for="user-birth" class="am-form-label">类别</label>
                    <div class="am-form-content">
                        <div class="birth-select">
                            <asp:DropDownList ID="classs" runat="server">
                                <asp:ListItem Value="雕塑"></asp:ListItem>
                                <asp:ListItem Value="油画"></asp:ListItem>
                                <asp:ListItem Value="剪纸"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="am-form-group">
                    <label for="user-email" class="am-form-label">所属卖区</label>
                    <div class="am-form-content birth">
                        <div class="birth-select">
                            <asp:DropDownList ID="DropDownList2" runat="server">
                                <asp:ListItem Value="推荐新品"></asp:ListItem>
                                <asp:ListItem Value="热卖专区"></asp:ListItem>
                                <asp:ListItem Value="促销专区"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>


                <div>
                    <label for="user-email" class="am-form-label">商品详情</label>
                    <div style="margin-left:80px">
                        <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="300px" Width="100%">		
                        </CKEditor:CKEditorControl>
                        <script language="C#" runat="server">
                            protected override void OnLoad(EventArgs e)
                            {
                                CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
                                _FileBrowser.BasePath = "../ckfinder/";
                                _FileBrowser.SetupCKEditor(CKEditor1);
                            }
                        </script>
                    </div>
                </div>

                <div class="info-btn">
                    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" class="am-btn am-btn-danger" Text="上传" />
                </div>
                <div style="display: none">
                    <asp:TextBox ID="userguid1" runat="server"></asp:TextBox>
                </div>
            </form>

        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#pic").click(function () {
                $("#upload").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                $("#upload").on("change", function () {
                    var objUrl = getObjectURL(this.files[0]); //获取图片的路径，该路径不是图片在本地的路径
                    if (objUrl) {
                        $("#pic").attr("src", objUrl); //将图片路径存入src中，显示出图片
                    }
                });
            });
        });


        //建立一個可存取到該file的url
        function getObjectURL(file) {
            var url = null;
            if (window.createObjectURL != undefined) { // basic
                url = window.createObjectURL(file);
            } else if (window.URL != undefined) { // mozilla(firefox)
                url = window.URL.createObjectURL(file);
            } else if (window.webkitURL != undefined) { // webkit or chrome
                url = window.webkitURL.createObjectURL(file);
            }
            return url;
        }

        $("#btnUpload").click(function (evt) {
            var fileUpload = $("#upload").get(0);
            var files = fileUpload.files;



            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            var tex = $(" input[ name='txt' ] ").val()
            data.append('txt', tex);

            $.ajax({
                url: "FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    if (result != null) {
                        alert("上传成功");
                        var arry = result.split('%');
                        $("#picsp").val(arry[0]);
                    }
                },
                error: function (err) {
                    alert(err.statusText)
                }
            });

            evt.preventDefault();
        });


    </script>

</asp:Content>
