<%@ Page Language="C#" MasterPageFile="~/UserPage/indexm.master" AutoEventWireup="true" Inherits="WeyiShow.UserPage.index" Codebehind="index.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row" style="margin-left: 20px; padding-top: 20px; float: left;">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <!--下面就是模板了，数据就是根据下面的模样循环显示的-->
                <div class="col-xs-6 col-md-3">
                    <div class="thumbnail">
                        <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>" class="thumbnail">
                            <asp:Image ID="Image1" runat="server" Height="280px" Width="300px" CssClass="img-responsive img-rounded"
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImageUrl") %>' />
                        </a>
                        <div style="margin-left: 20px">
                            <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                                <h4>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("ProductName") %>' />
                                </h4>
                            </a>
                            <h5>简介：
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>' />
                            </h5>
                            <h5>价格:
                            <asp:Label ID="MarketPriceLabel" runat="server"
                                Text='<%#Eval("Price") %>' /></h5>

                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <div class="row" style="margin-left: 20px; padding-top: 20px; float: left;">
        <asp:Repeater ID="dlResult2" runat="server">
            <ItemTemplate>
                <!--下面就是模板了，数据就是根据下面的模样循环显示的-->
                <div class="col-xs-6 col-md-3">
                    <div class="thumbnail">
                        <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>" class="thumbnail">
                            <asp:Image ID="Image1" runat="server" Height="280px" Width="300px" CssClass="img-responsive img-rounded"
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImageUrl") %>' />
                        </a>
                        <div style="margin-left: 20px">
                            <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                                <h4>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("ProductName") %>' />
                                </h4>
                            </a>

                            <h5>简介：
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>' />
                            </h5>
                            <h5>价格:
                            <asp:Label ID="MarketPriceLabel" runat="server"
                                Text='<%#Eval("Price") %>' /></h5>

                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <div class="row" style="margin-left: 20px; padding-top: 20px; float: left;">
        <asp:Repeater ID="dlResult3" runat="server">
            <ItemTemplate>
                <!--下面就是模板了，数据就是根据下面的模样循环显示的-->
                <div class="col-xs-6 col-md-3">
                    <div class="thumbnail">
                        <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>" class="thumbnail">
                            <asp:Image ID="Image1" runat="server" Height="280px" Width="300px" CssClass="img-responsive img-rounded"
                                ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImageUrl") %>' />
                        </a>
                        <div style="margin-left: 20px">
                            <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                                <h4><asp:Label ID="NameLabel" runat="server" Text='<%#Eval("ProductName") %>' />
                                </h4>
                            </a>

                            <h5>简介：
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Title") %>' />
                            </h5>
                            <h5>价格:
                            <asp:Label ID="MarketPriceLabel" runat="server"
                                Text='<%#Eval("Price") %>' /></h5>

                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <%--<div id="Div2" style="margin-left: 20px; padding-top: 20px;">
        <asp:DataList ID="dlResult3" runat="server" HorizontalAlign="Left"
            RepeatColumns="4" GridLines="Vertical"
            DataKeyField="ProductId"
            Width="1300px" CellSpacing="30" CellPadding="30" OnItemCommand="dlResult3_ItemCommand">
            <ItemTemplate>
                <div class="row">
                    <div class="col-sm-12 col-lg-12">
                        <div class="thumbnail">
                            <a href="../UserPage/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
                                <asp:Image ID="Image1" runat="server"
                                    ImageUrl='<%# DataBinder.Eval(Container.DataItem,"ImageUrl") %>' />
                            </a>
                            <div class="caption">
                                <h3>

                                    <asp:Label ID="Label1" runat="server" Text="产品名:">                               
                                    </asp:Label>
                                    <%#DataBinder.Eval(Container.DataItem, "ProductName")%>
                                </h3>
                                <p>
                                    <asp:Label ID="Label2" runat="server" Text="价格:"></asp:Label>
                                    <%# VarStr(DataBinder.Eval(Container.DataItem, "Price").ToString(),2)%>
                                    ￥
                                </p>
                                <p>
                                    <asp:LinkButton ID="lnkbtnClass" class="btn btn-primary" runat="server" CommandName="detailSee">详细</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkbtnBuy" runat="server" class="btn btn-default"
                                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Price") %>'
                                        CommandName="buyGoods">购买</asp:LinkButton>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:DataList>
    </div>--%>
</asp:Content>




