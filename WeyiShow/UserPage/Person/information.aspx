<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="true" Inherits="WeyiShow.UserPage.Person.information" CodeBehind="information.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/infstyle.css" rel="stylesheet" type="text/css">
    <div class="user-info">
        <!--标题 -->
        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">个人资料</strong> / <small>Personal&nbsp;information</small></div>
        </div>
        <hr />

        <!--头像 -->
        <div class="user-infoPic">

            <div class="filePic">
                <input type="file" class="inputPic" allowexts="gif,jpeg,jpg,png,bmp" accept="image/*">
                <img class="am-circle am-img-thumbnail" src="images/getAvatar.jpg" alt="" />
            </div>

            <p class="am-form-help">头像</p>

            <div class="info-m">
                <div><b>用户名：<i>小叮当</i></b></div>
                <div class="u-level">
                    <span class="rank r2">
                        <s class="vip1"></s><a class="classes" href="#">铜牌会员</a>
                    </span>
                </div>
                <div class="u-safety">
                    <a href="safety.html">账户安全
								
                        <span class="u-profile"><i class="bc_ee0000" style="width: 60px;" width="0">60分</i></span>
                    </a>
                </div>
            </div>
        </div>

        <!--个人信息 -->
        <div class="info-main">
            <form class="am-form am-form-horizontal">

                <div class="am-form-group">
                    <label for="user-name2" class="am-form-label">昵称</label>
                    <div class="am-form-content">
                        <%--<input type="text" id="user-name2" placeholder="nickname">--%>
                        <asp:TextBox ID="username2" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="am-form-group">
                    <label for="user-name" class="am-form-label">姓名</label>
                    <div class="am-form-content">
                        <%--<input type="text" id="user-name2" placeholder="name">--%>
                        <asp:TextBox ID="username1" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="am-form-group">
                    <label class="am-form-label">性别</label>
                    <div class="am-form-content sex">
                        
                        <label class="am-radio-inline">
                            <asp:RadioButton ID="RadioButton1" GroupName="xingbie" Text="男" runat="server" data-am-ucheck />
									
                        </label>
                        <label class="am-radio-inline">
                            <asp:RadioButton ID="RadioButton2" GroupName="xingbie" Text="女" runat="server" data-am-ucheck />
									
                        </label>
                        <label class="am-radio-inline">
                           <asp:RadioButton ID="RadioButton3" GroupName="xingbie" Text="保密" runat="server" data-am-ucheck />
									
                        </label>
                    </div>
                </div>

                <div class="am-form-group">
                    <label for="user-birth" class="am-form-label">生日</label>
                    <div class="am-form-content birth">
                        <div class="birth-select">
                            <asp:DropDownList ID="Year"  runat="server" >
                            </asp:DropDownList>
                            <em>年</em>
                        </div>
                        <div class="birth-select2">
                            <asp:DropDownList ID="Month" runat="server" >
                            </asp:DropDownList>
                            <em>月</em>
                        </div>
                        <div class="birth-select2">
                            <asp:DropDownList ID="Day" runat="server">
                            </asp:DropDownList>
                            <em>日</em>
                        </div>
                    </div>

                </div>
                <div class="am-form-group">
                    <label for="user-phone" class="am-form-label">电话</label>
                    <div class="am-form-content">
                        <%--<input id="user-phone" placeholder="telephonenumber" type="tel">--%>
                        <asp:TextBox ID="userphone" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="am-form-group">
                    <label for="user-email" class="am-form-label">电子邮件</label>
                    <div class="am-form-content">
                       <%-- <input id="user-email" placeholder="Email" type="email">--%>
                        <asp:TextBox ID="useremail" runat="server"></asp:TextBox>
                    </div>
                </div>
               <%-- <div class="am-form-group address">
                    <label for="user-address" class="am-form-label">收货地址</label>
                    <div class="am-form-content address">
                        <a href="address.aspx">
                            <p class="new-mu_l2cw">
                                <span class="province">湖北</span>省
											
                        <span class="city">武汉</span>市
											
                        <span class="dist">洪山</span>区
											
                        <span class="street">雄楚大道666号(中南财经政法大学)</span>
                                <span class="am-icon-angle-right"></span>
                            </p>
                        </a>

                    </div>
                </div>
                <div class="am-form-group safety">
                    <label for="user-safety" class="am-form-label">账号安全</label>
                    <div class="am-form-content safety">
                        <a href="safety.html">

                            <span class="am-icon-angle-right"></span>

                        </a>

                    </div>
                </div>--%>
                <div class="info-btn">
                    <asp:Button ID="btnsave" class="am-btn am-btn-danger" runat="server" Text="保存修改" OnClick="btnsave_Click" />
                    <%--<div class="am-btn am-btn-danger">保存修改</div>--%>
                </div>

            </form>

        </div>

    </div>

    <script type="text/javascript">
        var bigArray = new Array(1, 3, 5, 7, 8, 10, 12);
        function OnSelectChange(year, month, day) {
            if (month.value == 2)//选中的月份为2月
            {
                if (checkYear(year.value))//闰年
                {
                    fillDay(day, 29);
                }
                else {
                    fillDay(day, 28);
                }
            }
            else {
                if (inArray(month.value, bigArray)) {
                    fillDay(day, 31);
                }
                else {
                    fillDay(day, 30);
                }
            }
        }
        function checkYear(year) {
            return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) ? 1 : 0;
        }
        function fillDay(day, days) {
            while (day.options.length > 0) {
                day.remove(0);
            }
            for (i = 1; i <= days; i++) {
                var oOption = document.createElement("OPTION");
                if (i < 10) {
                    oOption.innerText = "0" + i;
                }
                else {
                    oOption.innerText = i;
                }
                oOption.value = i;
                day.appendChild(oOption);
            }
        }
        function inArray(oObj, oArray) {
            for (i = 0; i < oArray.length; i++) {
                if (oObj == oArray[i]) {
                    return true;
                }
            }
            return false;
        }

    </script>
</asp:Content>
