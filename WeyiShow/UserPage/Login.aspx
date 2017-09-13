<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WeyiShow.UserPage.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户登录</title>
    <link rel="shortcut icon" href="../favicon.ico" type="image/x-icon"/>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/supersized.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/reset.css"/>    
    <link rel="stylesheet" href="../css/style.css"/>
    <script type="text/javascript" src="../js/jquery-1.8.2.min.js"></script>
    <script src="../js/supersized.3.2.7.min.js"></script>
    <script src="../js/supersized-init.js"></script>
    <style>
        .btn_img {
            padding:0px;
        }

        .txt_user {
            width:300px;
            margin-top:0px;
        }
        .user_left {
            float:left;
        }
        .hid {
            width:90px;
            height:30px;
            line-height:30px;
            margin-left:5px;
        }
        .blo {
            margin-top:25px;
        }
        

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <h1 style="margin-top:50px;">帐号登录</h1> 
         <div class="page-container" style="width:500px;">
            
                   
                    <div class="clearfix blo">
                        <div class="user_left">
                            <asp:TextBox ID="txtUserPhone" runat="server" class="username form-control txt_user"></asp:TextBox>
                        </div>
                        <div class="user_left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtUserName" ErrorMessage="手机号码" ForeColor="#FF0066" CssClass="hid"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="clearfix blo">
                        <div class="user_left">
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" class="password form-control txt_user"></asp:TextBox>
                        </div>
                        <div class="user_left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtPwd" ErrorMessage="输入密码" ForeColor="#FF0066" CssClass="hid"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="clearfix blo">
                        <div class="user_left">
                            <asp:TextBox ID="txtValidCode" runat="server" class="username form-control txt_user" style="width:200px;"></asp:TextBox>
                        </div>
                        <div class="user_left">
                            <asp:ImageButton ID="imgValidCode" runat="server" ImageUrl="~/UserPage/ValidCode.ashx" CssClass="btn_img hid" style="margin-top:0px;"/>
                        </div>
                    </div> 

             <div class="clearfix blo">
                 <div class="user_left">
                      <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" Text="登录" class="btn btn-primary txt_user" />
                            
                 </div>
                 <div class="user_left">
                     <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="重置" class="btn btn-danger txt_user" style="margin-top:5px;"/>
                 </div>

             </div>
        </div>
       
    </form>

    <nav class="navbar navbar-default navbar-fixed-bottom" style="background:rgba(0,0,0,0); border:0px;">
  <div class="container">
        <ol class="breadcrumb" style="background:rgba(0,0,0,0);color:#fff;margin-bottom:10px;">
          <li><a href="index.aspx">首页</a></li>
          <li><a href="regist.aspx">注册</a></li>
          <li><a href="Default.aspx">登录</a></li>
          <li><a href="#">个人中心</a></li>
          <li><a href="#">关于我们</a></li>
        </ol>
       <center><p style="margin-bottom:15px;">Copyright © 滁州市贝艺得网络技术有限公司 &nbsp&nbsp&nbsp&nbsp 备案号：皖ICP备16001383号-1</p></center>
    
  </div>
</nav>
    
    
</body>
</html>
