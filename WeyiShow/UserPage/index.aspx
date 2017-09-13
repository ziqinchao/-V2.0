<%@ Page  Language="C#" MasterPageFile="~/UserPage/indexm.master" AutoEventWireup="true" Inherits="WeyiShow.UserPage.index" Codebehind="index.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="tuijian" style="margin-left: 20px; padding-top: 20px;">
        <asp:DataList ID="dlResult" runat="server" HorizontalAlign="Left"
            RepeatColumns="4" GridLines="Vertical" Width="1300px"
            OnItemCommand="dlResult_ItemCommand" DataKeyField="ProductId"
            CellSpacing="30" CellPadding="30">
            <ItemTemplate>               

                    <div class="row">
                        <div class="col-sm-12 col-lg-12">
                            <div class="thumbnail">
                                <a href="../USER/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
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
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div>
        <asp:DataList ID="dlResult2" runat="server" HorizontalAlign="Left"
            RepeatColumns="4" GridLines="Vertical"
            DataKeyField="ProductId"
            CellSpacing="30" CellPadding="30" Width="1300px"
            OnItemCommand="dlResult2_ItemCommand">
            <ItemTemplate>

               <div class="row">




                        <div class="col-sm-12 col-lg-12">
                            <div class="thumbnail">
                                <a href="../USER/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
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
                <%--<div class="row">
                    <div class="col-sm-12 col-md-4">
                        <div class="thumbnail">
                            <a href="../USER/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
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
                                    <%# GlobleClass.VarStr(DataBinder.Eval(Container.DataItem, "Price").ToString(),2)%>
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
                </div>--%>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
     <div id="Div2" style="margin-left: 20px; padding-top: 20px;">
        <asp:DataList ID="dlResult3" runat="server" HorizontalAlign="Left"
            RepeatColumns="4" GridLines="Vertical"
            DataKeyField="ProductId"
            Width="1300px" CellSpacing="30" CellPadding="30" OnItemCommand="dlResult3_ItemCommand">
            <ItemTemplate>
                  <div class="row">
                        <div class="col-sm-12 col-lg-12">
                            <div class="thumbnail">
                                <a href="../USER/GoodDetail.aspx?ProductId=<%# Eval("ProductId") %>">
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
    </div>
</asp:Content>




