<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WeyiShow.UserPage.Person.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../../js/jquery-3.2.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="cardPic">
            
            <%--<asp:Image ID="imgprv" runat="server" Height="90px" Width="75px" ImageUrl="~/UserPage/images/cardbgz.png" />--%>
             <img id="pic" src="../images/cardbgf.png"/>
            <%--<input id="upload" name="upload" accept="image/*" type="file" style="display: none" />--%>
            <asp:FileUpload ID="fupload" runat="server" style="display: none" onchange='prvimg.UpdatePreview(this)' />
            <p class="titleText">身份证正面</p>
        </div>


        <div class="cardPic">
            
            <%--<asp:Image ID="imgprv" runat="server" Height="90px" Width="75px" ImageUrl="~/UserPage/images/cardbgz.png" />--%>
             <img id="pic1" src="../images/cardbgf.png"/>
            <%--<input id="upload" name="upload" accept="image/*" type="file" style="display: none" />--%>
            <asp:FileUpload ID="fupload1" runat="server" style="display: none" onchange='prvimg.UpdatePreview(this)' />
            <p class="titleText">身份证正面</p>
        </div>

        <div>
            <input type="text" name="txt" id="txt1" class="ttt" value="" />
        </div>

        <table>
            <tr>
                <td>File:</td>
                <td>
                    

                </td>
                <td>
                    <%--<asp:Image ID="imgprv" runat="server" Height="90px" Width="75px" />--%>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload Selected File" /></td>
            </tr>
        </table>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#pic").click(function () {
                $("#fupload").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                //$("#upload").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                $("#fupload").on("change", function () {
                    var objUrl = getObjectURL(this.files[0]); //获取图片的路径，该路径不是图片在本地的路径
                    if (objUrl) {
                        $("#pic").attr("src", objUrl); //将图片路径存入src中，显示出图片
                    }
                });
            });
        });

        $(function () {
            $("#pic1").click(function () {
                $("#fupload1").click(); //隐藏了input:file样式后，点击头像就可以本地上传
                $("#fupload1").on("change", function () {
                    var objUrl = getObjectURL(this.files[0]); //获取图片的路径，该路径不是图片在本地的路径
                    if (objUrl) {
                        $("#pic1").attr("src", objUrl); //将图片路径存入src中，显示出图片
                    }
                    
                });
            });
        });

        $("#btnUpload").click(function (evt) {
            var fileUpload = $("#fupload").get(0);
            var files = fileUpload.files;

            var fileUpload1 = $("#fupload1").get(0);
            var files1 = fileUpload1.files;

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            for (var i = 0; i < files1.length; i++) {
                data.append(files1[i].name, files1[i]);
            }
            var tex = $(" input[ name='txt' ] ").val()
            data.append('txt',tex);

            $.ajax({
                url: "FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) { alert(result); },
                error: function (err) {
                    alert(err.statusText)
                }
            });

            evt.preventDefault();
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
    </script>
</body>
</html>
