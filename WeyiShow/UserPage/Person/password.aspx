<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="WeyiShow.UserPage.Person.password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/stepstyle.css" rel="stylesheet" type="text/css" />
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">修改密码</strong> / <small>Password</small></div>
    </div>
    <hr />
    <!--进度条-->
    <div class="m-progress">
        <div class="m-progress-list">
            <span class="step-1 step">
                <em class="u-progress-stage-bg"></em>
                <i class="u-stage-icon-inner">1<em class="bg"></em></i>
                <p class="stage-name">重置密码</p>
            </span>
            <span class="step-2 step">
                <em class="u-progress-stage-bg"></em>
                <i class="u-stage-icon-inner">2<em class="bg"></em></i>
                <p class="stage-name">完成</p>
            </span>
            <span class="u-progress-placeholder"></span>
        </div>
        <div class="u-progress-bar total-steps-2">
            <div class="u-progress-bar-inner"></div>
        </div>
    </div>
    <div class="am-form am-form-horizontal">
        <div class="am-form-group">
            <label for="user-old-password" class="am-form-label">原密码</label>
            <div class="am-form-content">
                <input type="password" id="user-old-password" placeholder="请输入原登录密码">
            </div>
        </div>
        <div class="am-form-group">
            <label for="user-new-password" class="am-form-label">新密码</label>
            <div class="am-form-content">
                <input type="password" id="user-new-password" placeholder="由数字、字母组合">
            </div>
        </div>
        <div class="am-form-group">
            <label for="user-confirm-password" class="am-form-label">确认密码</label>
            <div class="am-form-content">
                <input type="password" id="user-confirm-password" placeholder="请再次输入上面的密码">
            </div>
        </div>
        <div class="info-btn">
            <a class="am-btn am-btn-danger" onclick="ModifyPwd();">保存修改</a>
        </div>
        <div style="display: none">
            <asp:TextBox ID="userguid1" runat="server"></asp:TextBox>
        </div>

    </div>
    <script type="text/javascript">
        function ModifyPwd() {
            var oldpwd = $("#user-old-password").val();
            var newpwd = $("#user-new-password").val();
            var confirm = $("#user-confirm-password").val();
            var userguid = $('#<%=userguid1.ClientID%>').val();
            if (newpwd == confirm) {
                $.ajax({
                    type: "POST",
                    url: "LinkageAjax.ashx?type=ModifyPwd" + "&oldpwd=" + oldpwd + "&newpwd=" + newpwd + "&userguid=" + userguid + "&random=" + Math.random(),
                    data: "",
                    beforeSend: function () { },
                    success: function (msg) {
                        if (msg == 1) {
                            alert("修改成功");
                            location = location;
                        }
                        else {
                            alert("修改失败");
                            location = location;
                        }

                    },
                    error: function () { alert("网络繁忙，请稍后再试。"); },
                    complete: function () { }
                });
            }
            else {
                alert("密码不一致，请重新输入");
            }
        }

    </script>

</asp:Content>
