<%@ Page Language="C#" AutoEventWireup="True" CodeFile="index.aspx.cs" Inherits="WeyiShow.AdminPage.index" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员</title>
    <style>
        #header table {
            width: 100%;
            border-spacing: 0;
            border-collapse: separate;
        }

            #header table td {
                padding: 0;
            }

        #header .title a,
        #header .pro a {
            font-weight: bold;
            font-size: 24px;
            text-decoration: none;
            line-height: 50px;
            margin-left: 10px;
        }

        #header .pro {
            position: absolute;
            top: 0;
            right: 10px;
        }

        .bottomtable {
            width: 100%;
            font-size: 12px;
        }


        /* 主题相关样式 - neptune */
        .f-theme-neptune #header,
        .f-theme-neptune .bottomtable,
        .f-theme-neptune .x-splitter {
            background-color: #1475BB;
            color: #fff;
        }

            .f-theme-neptune #header a,
            .f-theme-neptune .bottomtable a {
                color: #fff;
            }

            .f-theme-neptune #header .x-btn-over.x-btn-default-small {
                background-color: #3487c3;
            }


        /* 主题相关样式 - blue/classic */
        .f-theme-classic #header,
        .f-theme-classic .bottomtable {
            background-color: #DFE8F6;
            color: #000;
        }

            .f-theme-classic #header a,
            .f-theme-classic .bottomtable a {
                color: #000;
            }

            .f-theme-classic #header .x-btn-over.x-btn-default-small {
                background-color: #e4f3ff;
            }


        /* 主题相关样式 - gray */
        .f-theme-gray #header,
        .f-theme-gray .bottomtable {
            background-color: #E0E0E0;
            color: #333;
        }

            .f-theme-gray #header a,
            .f-theme-gray .bottomtable a {
                color: #333;
            }

            .f-theme-gray #header .x-btn-over.x-btn-default-small {
                background-color: #f3f3f3;
            }


        /* 主题相关样式 - crisp */
        .f-theme-crisp #header,
        .f-theme-crisp .bottomtable,
        .f-theme-crisp .x-splitter {
            background-color: #E1E1E1;
            color: #000;
        }

            .f-theme-crisp #header a,
            .f-theme-crisp .bottomtable a {
                color: #000;
            }

            .f-theme-crisp #header .x-btn-inner-default-small {
                color: #000;
            }

            .f-theme-crisp #header .x-btn-over.x-btn-default-small .x-btn-inner-default-small {
                color: #fff;
            }

            .f-theme-crisp #header .x-btn-over.x-btn-default-small {
                background-color: #3487c3;
            }


        /* 主题相关样式 - triton */
        .f-theme-triton #header,
        .f-theme-triton .bottomtable,
        .f-theme-triton .x-splitter {
            background-color: #477aa6;
            color: #fff;
        }

            .f-theme-triton #header a,
            .f-theme-triton .bottomtable a {
                color: #fff;
            }

            .f-theme-triton #header .x-btn-over.x-btn-default-small {
                background-color: #5795cb;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="50px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Content>
                        <div id="header">
                            <table>
                                <tr>
                                    <td>
                                        <div class="title">
                                            <a href="#">唯艺网</a>
                                        </div>
                                    </td>
                                    <td style="text-align: right;">
                                        <div class="pro" style="line-height: 49px; margin-right: 30px">
                                            <span>欢迎</span>
                                            <asp:Label ID="username" runat="server" Text="admin"></asp:Label>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnzhuxiao" runat="server" OnClick="btnzhuxiao_Click" Text="注销" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </f:Region>
                <f:Region ID="Region2" Split="true" Width="200px" ShowHeader="true" Title="菜单"
                    EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                    <Items>
                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true" EnableLines="true" ID="leftMenuTree">
                            <Nodes>
                                <f:TreeNode Text="商城管理" Expanded="true">
                                    <f:TreeNode Text="订单管理" NavigateUrl="~/hello.aspx"></f:TreeNode>
                                    <f:TreeNode Text="用户管理" NavigateUrl="~/login.aspx"></f:TreeNode>
                                    <f:TreeNode Text="商品管理" NavigateUrl="CommodityManage.aspx"></f:TreeNode>
                                    <f:TreeNode Text="上传商品" NavigateUrl="UploadGoods.aspx"></f:TreeNode>
                                    <f:TreeNode Text="实名认证审核" NavigateUrl=""></f:TreeNode>

                                </f:TreeNode>
                                <f:TreeNode Text="网站管理" Expanded="true">
                                    <f:TreeNode Text="修改密码" NavigateUrl="~/hello.aspx"></f:TreeNode>
                                    <f:TreeNode Text="访问量" NavigateUrl="~/login.aspx"></f:TreeNode>
                                    <f:TreeNode Text="留言管理" NavigateUrl="~/login.aspx"></f:TreeNode>

                                </f:TreeNode>
                            </Nodes>
                        </f:Tree>
                    </Items>
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center"
                    runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Items>
                                        <f:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                            runat="server">
                                            <h2>FineUI（开源版）</h2>
                                            基于 ExtJS 的开源 ASP.NET 控件库
                                        
                                            <br />
                                            <h2>FineUI的使命</h2>
                                            创建 No JavaScript，No CSS，No UpdatePanel，No ViewState，No WebServices 的网站应用程序
                                        
                                            <br />
                                            <h2>支持的浏览器</h2>
                                            Chrome、Firefox、Safari、IE 8.0+
                                        
                                            <br />
                                            <h2>授权协议</h2>
                                            Apache License v2.0（ExtJS 库在 <a target="_blank" href="http://www.sencha.com/license">GPL v3</a> 协议下发布）
                                            
                                            <br />
                                            <h2>相关链接</h2>
                                            首页：<a target="_blank" href="http://fineui.com/">http://fineui.com/</a>
                                            <br />
                                            论坛：<a target="_blank" href="http://fineui.com/bbs/">http://fineui.com/bbs/</a>
                                            <br />
                                            示例：<a target="_blank" href="http://fineui.com/demo/">http://fineui.com/demo/</a>
                                            <br />
                                            文档：<a target="_blank" href="http://fineui.com/doc/">http://fineui.com/doc/</a>
                                            <br />
                                            <br />
                                            <br />
                                            <br />

                                            <hr />
                                            <br />
                                            <a target="_blank" href="http://fineui.com/pro/">【推荐】FineUI（专业版） - 简单易用、速度飞快、皮肤多彩、经济实惠！</a>

                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
                <f:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <f:ContentPanel ID="ContentPanel3" runat="server" ShowBorder="false" ShowHeader="false">
                            <table class="bottomtable">
                            </table>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
    </form>
    <script>
        var menuClientID = '<%= leftMenuTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        // 页面控件初始化完毕后，会调用用户自定义的onReady函数
        F.ready(function () {

            var treeMenu = F(menuClientID);
            var mainTabStrip = F(tabStripClientID);

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateHash: 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // maxTabCount: 最大允许打开的选项卡数量
            // maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });

        });
    </script>
</body>
</html>
