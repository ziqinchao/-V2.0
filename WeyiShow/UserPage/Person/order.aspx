<%@ Page Language="C#" MasterPageFile="~/UserPage/Person/PersonFrame.Master" AutoEventWireup="true" Inherits="WeyiShow.UserPage.Person.order" CodeBehind="order.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/orstyle.css" rel="stylesheet" type="text/css">
    <div class="user-order">

        <!--标题 -->
        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-danger am-text-lg">订单管理</strong> / <small>Order</small></div>
        </div>
        <hr />

        <div class="am-tabs am-tabs-d2 am-margin" data-am-tabs>

            <ul class="am-avg-sm-5 am-tabs-nav am-nav am-nav-tabs">
                <li class="am-active"><a href="#tab1">所有订单</a></li>
                <li><a href="#tab2">待付款</a></li>
                <li><a href="#tab3">待发货</a></li>
                <li><a href="#tab4">待收货</a></li>
                <li><a href="#tab5">待评价</a></li>
            </ul>

            <div class="am-tabs-bd">
                <div class="am-tab-panel am-fade am-in am-active" id="tab1">
                    <div class="order-top">
                        <div class="th th-item">
                            <td class="td-inner">商品</td>
                        </div>
                        <div class="th th-price">
                            <td class="td-inner">单价</td>
                        </div>
                        <div class="th th-number">
                            <td class="td-inner">数量</td>
                        </div>
                        <div class="th th-operation">
                            <td class="td-inner">商品操作</td>
                        </div>
                        <div class="th th-amount">
                            <td class="td-inner">合计</td>
                        </div>
                        <div class="th th-status">
                            <td class="td-inner">交易状态</td>
                        </div>
                        <div class="th th-change">
                            <td class="td-inner">交易操作</td>
                        </div>
                    </div>

                    <div class="order-main">
                        <div class="order-list">
                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
                                <ItemTemplate>
                                    <!--交易成功-->
                                    <div class="order-status5">
                                        <div class="order-title">
                                            <div class="dd-num">
                                                订单编号：<a href="javascript:;"><asp:Label ID="productid" runat="server"
                                                    Text='<%#Eval("ProductId") %>' /></a>
                                            </div>
                                            <span>成交时间：<asp:Label ID="Label1" runat="server"
                                                Text='<%#Eval("OrderDate") %>' /></span>

                                        </div>
                                        <div class="order-content">
                                            <div class="order-left">
                                                <ul class="item-list">
                                                    <li class="td td-item">
                                                        <div class="item-pic">
                                                            <a href="#" class="J_MakePoint">

                                                                <asp:Image ID="Image1" runat="server" CssClass="itempic J_ItemImg"
                                                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImageUrl") %>' />
                                                            </a>
                                                        </div>
                                                        <div class="item-info">
                                                            <div class="item-basic-info">
                                                                <a href="#">
                                                                    <p>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>' /></p>
                                                                    <p class="info-little">
                                                                        <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("ProductName") %>' />


                                                                    </p>
                                                                </a>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="td td-price">
                                                        <div class="item-price">
                                                            <asp:Label ID="price" runat="server"
                                                                Text='<%#Eval("Price") %>' />

                                                        </div>
                                                    </li>
                                                    <li class="td td-number">
                                                        <div class="item-number">
                                                            <span>×</span>
                                                            <asp:Label ID="Label2" runat="server"
                                                                Text='<%#Eval("Number") %>' />

                                                        </div>
                                                    </li>
                                                    <li class="td td-operation">
                                                        <div class="item-operation">
                                                        </div>
                                                    </li>
                                                </ul>


                                            </div>
                                            <div class="order-right">
                                                <li class="td td-amount">
                                                    <div class="item-amount">
                                                        合计：<asp:Label ID="Label4" runat="server" Text='<%#Eval("SumPrice") %>' />

                                                        <p>含运费：<span>10.00</span></p>
                                                    </div>
                                                </li>
                                                <div class="move-right">
                                                    <li class="td td-status">
                                                        <div class="item-status">
                                                            <p class="Mystatus">交易成功</p>
                                                            <p class="order-info"><a href="orderinfo.html">订单详情</a></p>
                                                            <p class="order-info"><a href="logistics.html">查看物流</a></p>
                                                        </div>
                                                    </li>
                                                    <li class="td td-change">
                                                        <div class="am-btn am-btn-danger anniu">
                                                            删除订单
                                                        </div>
                                                    </li>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <%--这是分隔线模板--%>
                                    <tr>
                                        <td colspan="2">
                                            <hr style="border-top: 1pt;" />
                                        </td>
                                    </tr>
                                </SeparatorTemplate>
                                <FooterTemplate>
                                    <%--这是脚模板--%>
                                    <tr>
                                        <td colspan="2" style="font-size: 12pt; color: #0099ff; background-color: #e6feda;">共<asp:Label ID="lblpc" runat="server" Text="Label"></asp:Label>页 当前为第  
        <asp:Label ID="lblp" runat="server" Text="Label"></asp:Label>页  
        <asp:HyperLink ID="hlfir" runat="server" Text="首页"></asp:HyperLink>
                                            <asp:HyperLink ID="hlp" runat="server" Text="上一页"></asp:HyperLink>
                                            <asp:HyperLink ID="hln" runat="server" Text="下一页"></asp:HyperLink>
                                            <asp:HyperLink ID="hlla" runat="server" Text="尾页"></asp:HyperLink>
                                            跳至第  
         <asp:DropDownList ID="ddlp" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlp_SelectedIndexChanged">
         </asp:DropDownList>页  
                                        </td>
                                    </tr>
                                    </table>  
                                </FooterTemplate>
                            </asp:Repeater>




                        </div>

                    </div>

                </div>
                <div class="am-tab-panel am-fade" id="tab2">

                    <div class="order-top">
                        <div class="th th-item">
                            <td class="td-inner">商品</td>
                        </div>
                        <div class="th th-price">
                            <td class="td-inner">单价</td>
                        </div>
                        <div class="th th-number">
                            <td class="td-inner">数量</td>
                        </div>
                        <div class="th th-operation">
                            <td class="td-inner">商品操作</td>
                        </div>
                        <div class="th th-amount">
                            <td class="td-inner">合计</td>
                        </div>
                        <div class="th th-status">
                            <td class="td-inner">交易状态</td>
                        </div>
                        <div class="th th-change">
                            <td class="td-inner">交易操作</td>
                        </div>
                    </div>

                    <div class="order-main">
                        <div class="order-list">
                            <div class="order-status1">
                                <div class="order-title">
                                    <div class="dd-num">订单编号：<a href="javascript:;">1601430</a></div>
                                    <span>成交时间：2015-12-20</span>
                                    <!--    <em>店铺：小桔灯</em>-->
                                </div>
                                <div class="order-content">
                                    <div class="order-left">
                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/62988.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>礼盒袜子女秋冬 纯棉袜加厚 韩国可爱 </p>
                                                            <p class="info-little">
                                                                颜色分类：李清照
																			
                                                                <br />
                                                                尺码：均码
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="order-right">
                                        <li class="td td-amount">
                                            <div class="item-amount">
                                                合计：676.00
															
                                                <p>含运费：<span>10.00</span></p>
                                            </div>
                                        </li>
                                        <div class="move-right">
                                            <li class="td td-status">
                                                <div class="item-status">
                                                    <p class="Mystatus">等待买家付款</p>
                                                    <p class="order-info"><a href="#">取消订单</a></p>

                                                </div>
                                            </li>
                                            <li class="td td-change">
                                                <a href="pay.html">
                                                    <div class="am-btn am-btn-danger anniu">
                                                        一键支付
                                                    </div>
                                                </a>
                                            </li>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="am-tab-panel am-fade" id="tab3">
                    <div class="order-top">
                        <div class="th th-item">
                            <td class="td-inner">商品</td>
                        </div>
                        <div class="th th-price">
                            <td class="td-inner">单价</td>
                        </div>
                        <div class="th th-number">
                            <td class="td-inner">数量</td>
                        </div>
                        <div class="th th-operation">
                            <td class="td-inner">商品操作</td>
                        </div>
                        <div class="th th-amount">
                            <td class="td-inner">合计</td>
                        </div>
                        <div class="th th-status">
                            <td class="td-inner">交易状态</td>
                        </div>
                        <div class="th th-change">
                            <td class="td-inner">交易操作</td>
                        </div>
                    </div>

                    <div class="order-main">
                        <div class="order-list">
                            <div class="order-status2">
                                <div class="order-title">
                                    <div class="dd-num">订单编号：<a href="javascript:;">1601430</a></div>
                                    <span>成交时间：2015-12-20</span>
                                    <!--    <em>店铺：小桔灯</em>-->
                                </div>
                                <div class="order-content">
                                    <div class="order-left">
                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款</a>
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/62988.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>礼盒袜子女秋冬 纯棉袜加厚 韩国可爱 </p>
                                                            <p class="info-little">
                                                                颜色分类：李清照
																			
                                                                <br />
                                                                尺码：均码
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款</a>
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                    <div class="order-right">
                                        <li class="td td-amount">
                                            <div class="item-amount">
                                                合计：676.00
															
                                                <p>含运费：<span>10.00</span></p>
                                            </div>
                                        </li>
                                        <div class="move-right">
                                            <li class="td td-status">
                                                <div class="item-status">
                                                    <p class="Mystatus">买家已付款</p>
                                                    <p class="order-info"><a href="orderinfo.html">订单详情</a></p>
                                                </div>
                                            </li>
                                            <li class="td td-change">
                                                <div class="am-btn am-btn-danger anniu">
                                                    提醒发货
                                                </div>
                                            </li>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="am-tab-panel am-fade" id="tab4">
                    <div class="order-top">
                        <div class="th th-item">
                            <td class="td-inner">商品</td>
                        </div>
                        <div class="th th-price">
                            <td class="td-inner">单价</td>
                        </div>
                        <div class="th th-number">
                            <td class="td-inner">数量</td>
                        </div>
                        <div class="th th-operation">
                            <td class="td-inner">商品操作</td>
                        </div>
                        <div class="th th-amount">
                            <td class="td-inner">合计</td>
                        </div>
                        <div class="th th-status">
                            <td class="td-inner">交易状态</td>
                        </div>
                        <div class="th th-change">
                            <td class="td-inner">交易操作</td>
                        </div>
                    </div>

                    <div class="order-main">
                        <div class="order-list">
                            <div class="order-status3">
                                <div class="order-title">
                                    <div class="dd-num">订单编号：<a href="javascript:;">1601430</a></div>
                                    <span>成交时间：2015-12-20</span>
                                    <!--    <em>店铺：小桔灯</em>-->
                                </div>
                                <div class="order-content">
                                    <div class="order-left">
                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/62988.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>礼盒袜子女秋冬 纯棉袜加厚 韩国可爱 </p>
                                                            <p class="info-little">
                                                                颜色分类：李清照
																			
                                                                <br />
                                                                尺码：均码
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>

                                    </div>
                                    <div class="order-right">
                                        <li class="td td-amount">
                                            <div class="item-amount">
                                                合计：676.00
															
                                                <p>含运费：<span>10.00</span></p>
                                            </div>
                                        </li>
                                        <div class="move-right">
                                            <li class="td td-status">
                                                <div class="item-status">
                                                    <p class="Mystatus">卖家已发货</p>
                                                    <p class="order-info"><a href="orderinfo.html">订单详情</a></p>
                                                    <p class="order-info"><a href="logistics.html">查看物流</a></p>
                                                    <p class="order-info"><a href="#">延长收货</a></p>
                                                </div>
                                            </li>
                                            <li class="td td-change">
                                                <div class="am-btn am-btn-danger anniu">
                                                    确认收货
                                                </div>
                                            </li>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="am-tab-panel am-fade" id="tab5">
                    <div class="order-top">
                        <div class="th th-item">
                            <td class="td-inner">商品</td>
                        </div>
                        <div class="th th-price">
                            <td class="td-inner">单价</td>
                        </div>
                        <div class="th th-number">
                            <td class="td-inner">数量</td>
                        </div>
                        <div class="th th-operation">
                            <td class="td-inner">商品操作</td>
                        </div>
                        <div class="th th-amount">
                            <td class="td-inner">合计</td>
                        </div>
                        <div class="th th-status">
                            <td class="td-inner">交易状态</td>
                        </div>
                        <div class="th th-change">
                            <td class="td-inner">交易操作</td>
                        </div>
                    </div>

                    <div class="order-main">
                        <div class="order-list">
                            <!--不同状态的订单	-->
                            <div class="order-status4">
                                <div class="order-title">
                                    <div class="dd-num">订单编号：<a href="javascript:;">1601430</a></div>
                                    <span>成交时间：2015-12-20</span>

                                </div>
                                <div class="order-content">
                                    <div class="order-left">
                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>

                                    </div>
                                    <div class="order-right">
                                        <li class="td td-amount">
                                            <div class="item-amount">
                                                合计：676.00
															
                                                <p>含运费：<span>10.00</span></p>
                                            </div>
                                        </li>
                                        <div class="move-right">
                                            <li class="td td-status">
                                                <div class="item-status">
                                                    <p class="Mystatus">交易成功</p>
                                                    <p class="order-info"><a href="orderinfo.html">订单详情</a></p>
                                                    <p class="order-info"><a href="logistics.html">查看物流</a></p>
                                                </div>
                                            </li>
                                            <li class="td td-change">
                                                <a href="commentlist.html">
                                                    <div class="am-btn am-btn-danger anniu">
                                                        评价商品
                                                    </div>
                                                </a>
                                            </li>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="order-status4">
                                <div class="order-title">
                                    <div class="dd-num">订单编号：<a href="javascript:;">1601430</a></div>
                                    <span>成交时间：2015-12-20</span>
                                    <!--    <em>店铺：小桔灯</em>-->
                                </div>
                                <div class="order-content">
                                    <div class="order-left">
                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/62988.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>礼盒袜子女秋冬 纯棉袜加厚 韩国可爱 </p>
                                                            <p class="info-little">
                                                                颜色分类：李清照
																			
                                                                <br />
                                                                尺码：均码
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>

                                        <ul class="item-list">
                                            <li class="td td-item">
                                                <div class="item-pic">
                                                    <a href="#" class="J_MakePoint">
                                                        <img src="../images/kouhong.jpg_80x80.jpg" class="itempic J_ItemImg">
                                                    </a>
                                                </div>
                                                <div class="item-info">
                                                    <div class="item-basic-info">
                                                        <a href="#">
                                                            <p>美康粉黛醉美唇膏 持久保湿滋润防水不掉色</p>
                                                            <p class="info-little">
                                                                颜色：12#川南玛瑙
																			
                                                                <br />
                                                                包装：裸装
                                                            </p>
                                                        </a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="td td-price">
                                                <div class="item-price">
                                                    333.00
															
                                                </div>
                                            </li>
                                            <li class="td td-number">
                                                <div class="item-number">
                                                    <span>×</span>2
															
                                                </div>
                                            </li>
                                            <li class="td td-operation">
                                                <div class="item-operation">
                                                    <a href="refund.html">退款/退货</a>
                                                </div>
                                            </li>
                                        </ul>


                                    </div>
                                    <div class="order-right">
                                        <li class="td td-amount">
                                            <div class="item-amount">
                                                合计：676.00
															
                                                <p>含运费：<span>10.00</span></p>
                                            </div>
                                        </li>
                                        <div class="move-right">
                                            <li class="td td-status">
                                                <div class="item-status">
                                                    <p class="Mystatus">交易成功</p>
                                                    <p class="order-info"><a href="orderinfo.html">订单详情</a></p>
                                                    <p class="order-info"><a href="logistics.html">查看物流</a></p>
                                                </div>
                                            </li>
                                            <li class="td td-change">
                                                <a href="commentlist.html">
                                                    <div class="am-btn am-btn-danger anniu">
                                                        评价商品
                                                    </div>
                                                </a>
                                            </li>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>

