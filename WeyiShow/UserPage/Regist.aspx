<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Regist.aspx.cs" Inherits="WeyiShow.UserPage.Regist" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/regist.css" rel="stylesheet" />
    <link rel="stylesheet" href="../css/jquery-ui.min.css" />
    <link rel="stylesheet" href="../css/theme.css" />

    <script src="../js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../js/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui.min.js" type="text/javascript"></script>
    <%--    <script src="js/Register.js" type="text/javascript"></script>--%>
    <script type="text/javascript">

        function djs() {

            //短信验证码  
            var InterValObj; //timer变量，控制时间    
            var count = 60; //间隔函数，1秒执行    
            var curCount;//当前剩余秒数

            curCount = count;

            $("#getcode").attr("disabled", "true");
            $("#getcode").val("请在" + curCount + "秒内输入验证码");
            InterValObj = window.setInterval(SetRemainTime, 1000); // 启动计时器，1秒执行一次     

            $("#telephonenameTip").html("<font color='#339933'> 短信验证码已发到您的手机,请查收(30分钟内有效)</font>");

            //timer处理函数    
            function SetRemainTime() {
                if (curCount == 0) {
                    window.clearInterval(InterValObj);// 停止计时器    
                    $("#getcode").removeAttr("disabled");// 启用按钮    
                    $("#getcode").val("重新发送验证码");
                    $("#telephonenameTip").html("");
                    code = ""; // 清除验证码。如果不清除，过时间后，输入收到的验证码依然有效    
                } else {
                    curCount--;
                    $("#getcode").val("请在" + curCount + "秒内输入验证码");
                }
            }
        }
        function shibai() {
            $("#telephonenameTip").html("<font color='red'>× 短信验证码发送失败，请重新发送</font>");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <div class="zhuti container">
            <div class=" left col-sm-9 col-xs-12">

                <div class="form-group">
                    <label for="txtUserName" class="col-sm-2 control-label">用户名</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="txtUserName" runat="server" class="form-control" Style="width: 300px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="用户名不能为空"
                                ControlToValidate="txtUserName" Display="Dynamic" ValidationGroup="UserRegist"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvCheckUserName" runat="server"
                                ControlToValidate="txtUserName" Display="Dynamic"
                                ValidationGroup="UserCheck" ErrorMessage="请输入要检查的用户名">请输入要检查的用户名</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <label for="txtPwd" class="col-sm-2 control-label">密码</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" class="form-control" Style="width: 300px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:RequiredFieldValidator ID="rfvPwd" runat="server" ErrorMessage="密码不能为空" ControlToValidate="txtPwd"
                                ValidationGroup="UserRegist" Display="Dynamic" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <label for="txtPwdAgain" class="col-sm-2 control-label">确认密码</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="txtPwdAgain" runat="server" TextMode="Password" class="form-control" Style="width: 300px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:RequiredFieldValidator ID="rfvPwdAgain" runat="server" ErrorMessage="重复密码不能为空"
                                ControlToValidate="txtPwdAgain" ValidationGroup="UserRegist" Display="Dynamic"
                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPwd" runat="server" ControlToCompare="txtPwd" ControlToValidate="txtPwdAgain"
                                ErrorMessage="两次密码输入不一致" SetFocusOnError="True" ValidationGroup="UserRegist"
                                Display="Dynamic">*</asp:CompareValidator>
                        </div>
                    </div>
                </div>



                <div class="form-group">
                    <label for="txtEmail1" class="col-sm-2 control-label">邮箱</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" Style="width: 300px;" >
                            </asp:TextBox>
                        </div>
                         <div style="float: left;">
                 <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="请输入邮箱" ValidationGroup="UserRegist">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="请输入正确的邮箱" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="txtAddress" class="col-sm-2 control-label">收货地址</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="txtAddress" runat="server" class="form-control" Style="width: 300px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="txtAddress" ErrorMessage="请填写收货地址"
                                ValidationGroup="UserRegist">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>


                <div class="form-group">
                    <label for="PhoneNum" class="col-sm-2 control-label">手机号</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="PhoneNum" runat="server" class="form-control" Style="width: 300px;"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="PhoneNum" ErrorMessage="请输入手机号" ValidationGroup="UserRegist">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="PhoneNum" ErrorMessage="请输入正确的手机号"
                                ValidationExpression="^1(3|4|5|7|8)\d{9}$"></asp:RegularExpressionValidator>

                        </div>

                    </div>
                </div>






                <div class="form-group">
                    <label for="sjyzm" class="col-sm-2 control-label">手机验证码</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="sjyzm" runat="server" class="form-control" Style="width: 140px;"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 5px;">

                            <asp:Button ID="getcode" runat="server" Text="点击获取手机验证码" class="btn btn-info" OnClick="getcode_Click" />
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <p id="telephonenameTip"></p>
                        </div>

                    </div>
                </div>

                <div class="form-group">
                    <label for="yzm" class="col-sm-2 control-label">验证码</label>
                    <div class="col-sm-6">
                        <div style="float: left;">
                            <asp:TextBox ID="yzm" runat="server" class="form-control" Style="width: 140px;"></asp:TextBox>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:ImageButton ID="imgValidCode" runat="server" ImageUrl="~/UserPage/ValidCode.ashx" CssClass="btn_img hid" Style="margin-top: 0px;" />

                        </div>
                    </div>
                </div>



                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="立即注册" ValidationGroup="UserRegist" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnReset" runat="server" class="btn btn-warning" Text="重置" Style="width: 82px; margin-left: 10px;" />
                    </div>
                </div>

                <asp:ValidationSummary ID="vsUserRegist" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="UserRegist" />


            </div>


            <div class="right col-sm-3 hidden-xs">
                <div class="list-group">
                    <%-- <h1  class="list-group-item ">
                操作类型
              </h1>--%>
                    <img src="../img/erweima.jpg" alt="Alternate Text" class="img-thumbnail" />
                    <h4 style="text-align: center;">扫码关注"唯艺网"</h4>
                </div>

            </div>
        </div>

    </form>

    <nav class="navbar navbar-default" style="background: rgba(0,0,0,0); border: 0px;">
        <div class="container">
            <ol class="breadcrumb" style="background: rgba(0,0,0,0); color: #fff; margin-bottom: 10px; text-align: center">
                <li><a href="index.aspx">首页</a></li>
                <li><a href="Regist.aspx">注册</a></li>
                <li><a href="Login.aspx">登录</a></li>
                <li><a href="#">个人中心</a></li>
                <li><a href="#">关于我们</a></li>
            </ol>
            <center><p style="margin-bottom:15px;">Copyright © 滁州市贝艺得网络技术有限公司 &nbsp&nbsp&nbsp&nbsp 备案号：皖ICP备16001383号-1</p></center>

        </div>
    </nav>



</body>




</html>

