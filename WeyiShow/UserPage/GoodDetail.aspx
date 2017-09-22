<%@ Page Language="C#" MasterPageFile="~/UserPage/tetle.master" AutoEventWireup="true" Inherits="WeyiShow.UserPage.GoodDetail" CodeFile="GoodDetail.aspx.cs" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container" style="margin-top: 20px; border-bottom: 1px solid #666;">
        <div style="height: 300px;" class="pull-left">
            <asp:ImageMap ID="ImageMapPhoto" runat="server" class="img-thumbnail" Style="max-height: 300px; max-width: 260px;">
            </asp:ImageMap>
        </div>
        <div class="pull-left" style="margin-left: 30px">
            <div class="form-group clearfix">
                <div class="pull-left">
                    <label class=" control-label">商品名称：</label>
                </div>
                <div class="pull-left">
                    <asp:Label ID="lbname" runat="server" Text="*"></asp:Label>
                    <asp:HiddenField ID="hdID" runat="server" />
                </div>
            </div>
            <div class="form-group clearfix">
                <div class="pull-left">
                    <label class=" control-label">商品分类：</label>
                </div>
                <div class="pull-left">
                    <asp:Label ID="lbclass" runat="server" Text="*"></asp:Label>
                </div>
            </div>
            <div class="form-group clearfix">
                <div class="pull-left">
                    <label class=" control-label">单位：</label>
                </div>
                <div class="pull-left">
                    <asp:Label ID="lbunit" runat="server" Text="*"></asp:Label>
                </div>
            </div>
            <div class="form-group clearfix">
                <div class="pull-left">
                    <label class=" control-label">单价：</label>
                </div>
                <div class="pull-left">
                    <asp:Label ID="lbprice" runat="server" Text="*"></asp:Label>
                </div>
            </div>
            <div class="form-group clearfix">
                 <f:PageManager ID="PageManager2" runat="server" />
                <div class="pull-left">
                   
                     <asp:Button ID="addCar" runat="server" Text=" 添加购物车 " OnClick="addCar_Click" class="btn btn-danger" />
                  
                    <f:Button ID="Button2" runat="server" EnablePostBack="false" Text="购 买" Width="96px"  CssClass="btn btn-primary"  Height="34px">
                    </f:Button>

                    <f:Window ID="Window1" IconUrl="~/res/images/16/11.png" runat="server" Hidden="true"
                        IsModal="true" Target="Parent" EnableMaximize="true" EnableResize="true" 
                        Title="Popup Window 2" CloseAction="HidePostBack"
                        EnableIFrame="true" Height="500px" Width="650px">
                    </f:Window>
                </div>
            </div>

        </div>

    </div>

    <div style="margin-left: 10%; width: 78%;">
        <div class="center-block">
            <h3 style="text-align: center">商品详情</h3>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
        </div>
    </div>




    
</asp:Content>

