<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="True" Inherits="WeyiShow.UserPage.Person.address" Codebehind="address.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/addstyle.css" rel="stylesheet" type="text/css">

    <div class="user-address">
        <!--标题 -->
        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">地址管理</strong> / <small>Address&nbsp;list</small></div>
        </div>
        <hr />
        <ul class="am-avg-sm-1 am-avg-md-3 am-thumbnails">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <li class="user-addresslist defaultAddr">
                        <span class="new-option-r"><i class="am-icon-check-circle"></i>默认地址</span>
                        <p class="new-tit new-p-re">
                            <span class="new-txt">
                                <asp:Label ID="ReceiveName" runat="server"
                                    Text='<%#Eval("ReceiveName") %>' /></span>
                            <span class="new-txt-rd2">
                                <asp:Label ID="ReceivePhone" runat="server"
                                    Text='<%#Eval("ReceivePhone") %>' /></span>
                        </p>
                        <div class="new-mu_l2a new-p-re">
                            <p class="new-mu_l2cw">
                                <span class="title">地址：</span>
                                <span class="province">
                                    <asp:Label ID="ReceiveAddress" runat="server"
                                        Text='<%#Eval("ReceiveAddress") %>' /></span>
                            </p>
                        </div>
                        <div class="new-addr-btn">
                            <a href="#"><i class="am-icon-edit"></i>编辑</a>
                            <span class="new-addr-bar">|</span>
                            <asp:LinkButton runat="server" ID="lbtDelete" CommandArgument='<%#Eval("RowGuid") %>'
                                CommandName="Delete" OnClientClick="return confirm('是否删除')"><i class="am-icon-trash"></i>删除</asp:LinkButton>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
        <div style="display: none">
            <asp:TextBox ID="userguid1" runat="server"></asp:TextBox>
        </div>
        <div class="clear"></div>
        <a class="new-abtn-type" data-am-modal="{target: '#doc-modal-1', closeViaDimmer: 0}">添加新地址</a>
        <!--例子-->
        <div class="am-modal am-modal-no-btn" id="doc-modal-1">

            <div class="add-dress">

                <!--标题 -->
                <div class="am-cf am-padding">
                    <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">新增地址</strong> / <small>Add&nbsp;address</small></div>
                </div>
                <hr />

                <div class="am-u-md-12 am-u-lg-8" style="margin-top: 20px; margin-left: 3%;">
                    <form class="am-form am-form-horizontal">

                        <div class="am-form-group">
                            <label for="user-name" class="am-form-label">收货人：</label>
                            <div class="am-form-content">
                                <asp:TextBox ID="rename" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="am-form-group">
                            <label for="user-phone" class="am-form-label">手机号码：</label>
                            <div class="am-form-content">
                                <asp:TextBox ID="rephone" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="am-form-group">
                            <label for="user-address" class="am-form-label">所在地：</label>
                            <div class="am-form-content address">
                                <span id="span_Province">
                                    <asp:DropDownList ID="Drop_Province" runat="server"
                                        onchange="ChangeSlect(this.options[this.selectedIndex].value,this.name)"
                                        OnDataBound="Drop_Province_DataBound">
                                    </asp:DropDownList></span>
                                <span id="span_City"></span>
                                <span id="span_County"></span>
                            </div>
                        </div>

                        <div class="am-form-group">
                            <label for="user-intro" class="am-form-label">详细地址：</label>
                            <div class="am-form-content">
                                <asp:TextBox ID="reintro" runat="server"></asp:TextBox>
                                <small>100字以内写出你的详细地址...</small>
                            </div>
                        </div>

                        <div class="am-form-group">
                            <div class="am-u-sm-9 am-u-sm-push-3">
                                <%--<asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" class="am-btn am-btn-danger" Text="保存" />--%>
                                <a class="am-btn am-btn-danger" onclick="AddReceive();">保存</a>
                                <a href="javascript: void(0)" class="am-close am-btn am-btn-danger" data-am-modal-close>取消</a>
                            </div>
                        </div>
                    </form>
                </div>

            </div>

        </div>

    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".new-option-r").click(function () {
                $(this).parent('.user-addresslist').addClass("defaultAddr").siblings().removeClass("defaultAddr");
            });

            var $ww = $(window).width();
            if ($ww > 640) {
                $("#doc-modal-1").removeClass("am-modal am-modal-no-btn")
            }

        });
        <%--function delClick(rowguid) {
            $('#HiddenField1').val = rowguid;
            var s = "<%=delAdress() %>";
        }--%>


        function GetZoneInfo(zoneID, level) {
            $.ajax({
                type: "POST",
                url: "LinkageAjax.ashx?type=GetZoneInfo" + "&zoneID=" + zoneID + "&level=" + level + "&random=" + Math.random(),
                data: "",
                beforeSend: function () { },
                success: function (msg) {
                    switch (level) {
                        case 1:
                            $("#span_City").html(msg);
                            break;
                        case 2:
                            $("#span_County").html(msg);
                            break;
                        default:
                            break;
                    }

                },
                error: function () { alert("网络繁忙，请稍后再试。"); },
                complete: function () { }
            });
        }
        function ChangeSlect(zoneID, name) {
            if (zoneID == "0") return;
            switch (name) {
                case "ctl00$ContentPlaceHolder1$Drop_Province":
                    GetZoneInfo(zoneID, 1);
                    break;
                case "Drop_City":
                    GetZoneInfo(zoneID, 2);
                    break;
                default:
                    break;
            }
        }

        function AddReceive() {
            var userguid = $('#<%=userguid1.ClientID%>').val();
            var rename = $('#<%=rename.ClientID%>').val();
            var rephone = $('#<%=rephone.ClientID%>').val();
            var readdress = $('#<%=Drop_Province.ClientID%>').find("option:selected").text() + $("#span_City").find("option:selected").text() + $("#span_County").find("option:selected").text() + $('#<%=reintro.ClientID%>').val();
            $.ajax({
                type: "POST",
                url: "LinkageAjax.ashx?type=AddReceive" + "&userguid=" + userguid + "&rename=" + rename + "&rephone=" + rephone + "&readdress=" + readdress + "&random=" + Math.random(),
                data: "",
                beforeSend: function () { },
                success: function (msg) {
                    if (msg == 1) {
                        alert("添加成功");
                        location = location;
                    }
                    else {
                        alert("添加失败");
                        location = location;
                    }
                   
                },
                error: function () { alert("网络繁忙，请稍后再试。"); },
                complete: function () { }
            });
        }


    </script>


    <div class="clear"></div>


</asp:Content>
