<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WeyiShow.UserPage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="../js/jquery-3.2.1.min.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
        <div><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>


        <div style="text-align:center;"> 
        <div>用户名：<input type="text" id="txt_username" /></div>
        <div>密  码：<input type="password" id="txt_password"  /></div>
        <div><input type="button" value="登录" id="btn_login" class="btn-default" /></div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#btn_login").click(function () {
                $.ajax({
                    type: "get",
                    url: "http://localhost:233/WebServiceTest.asmx",
                    data: { xmlCaseInfo: $("#txt_username").val() },
                    success: function (data, status) {
                        if (status == "success") {
                            if (!data.bRes) {
                                alert("登录失败");
                                return;
                            }
                            alert("登录成功");
                            //登录成功之后将用户名和用户票据带到主界面
                            window.location = "/Home/Index?UserName=" + data.UserName + "&Ticket=" + data.Ticket;
                        }
                    },
                    error: function (e) {
                    },
                    complete: function () {

                    }

                });
            });
        });
    </script>
</body>
</html>
