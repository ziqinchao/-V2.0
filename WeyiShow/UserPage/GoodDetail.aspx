<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/tetle.master" AutoEventWireup="true" Inherits="USER_GoodDetail" Codebehind="GoodDetail.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container" style="margin-top:20px;border-bottom:1px solid #666;">
        <div style="height:300px;" class="pull-left">
            <asp:ImageMap ID="ImageMapPhoto" runat="server" class="img-thumbnail" style="max-height:300px; max-width:260px;">
                </asp:ImageMap>
        </div>
        <div class="pull-left" style="margin-left:30px">
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
                    <label  class=" control-label">单价：</label>
                </div>
                <div class="pull-left">
                       <asp:Label ID="lbprice" runat="server" Text="*"></asp:Label>
                </div>
            </div>
            <div class="form-group clearfix">
                <div class="pull-left">
                     <asp:Button ID="addCar" runat="server" Text=" 添加购物车 " OnClick="addCar_Click" class="btn btn-danger" />
                     <asp:Button ID="buy" runat="server" Text="购 买" OnClick="buy_Click" class="btn btn-primary" />
					  <asp:Button ID="Button1" runat="server" Text="Button" OnClick="buy_Click" />
                   
                </div>
            </div>
           
        </div>

    </div>

    <div style="margin-left:10%;width:78%;">
        <div class="center-block"><h3 style="text-align:center">商品详情</h3></div>
        <div>
             <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
        </div>
    </div>






















    



   <%-- <table style="width:100%;">
        <tr>
            <td style="width: 69px">
                &nbsp;</td>
            <td style="width: 192px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px; height: 24px;">
                </td>
            <td rowspan="9" style="width: 192px">
                <asp:ImageMap ID="ImageMapPhoto" runat="server" Width="260px" Height="300px">
                </asp:ImageMap>
            </td>
            <td rowspan="9" style="width: 92px">
                &nbsp;</td>
            <td style="height: 24px">
                商品名称:<asp:Label ID="lbname" runat="server" Text="*"></asp:Label>
                <asp:HiddenField ID="hdID" runat="server" />
            </td>
            <td style="height: 24px">
                </td>
        </tr>
        <tr>
            <td rowspan="6" style="width: 69px">
                &nbsp;</td>
            <td>
                商品类别:<asp:Label ID="lbclass" runat="server" Text="*"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                单位:<asp:Label ID="lbunit" runat="server" Text="*"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                单价:<asp:Label ID="lbprice" runat="server" Text="*"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                商品特点:<asp:Label ID="lbspecial" runat="server" Text="*"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                数量:<asp:Button ID="jian" runat="server" onclick="jian_Click" Text=" - " />
                <asp:TextBox ID="number" runat="server" ontextchanged="number_TextChanged" 
                    ReadOnly="True" Width="30px">1</asp:TextBox>
                <asp:Button ID="jia" runat="server" onclick="jia_Click" Text=" + " />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                价格:<asp:Label ID="totalPrice" runat="server" Text="*"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">
                &nbsp;</td>
            <td>
                <asp:Button ID="buy" runat="server" Text="购 买" BorderStyle="Solid" 
                    Height="22px" onclick="buy_Click" Width="66px" />
                <asp:Button ID="addCar" runat="server" Text=" 添加购物车 " onclick="addCar_Click" 
                    BorderStyle="Solid" Height="22px" Width="90px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 69px">
                &nbsp;</td>
            <td style="width: 192px">
                &nbsp;</td>
            <td style="width: 92px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <asp:Label ID="Label2" runat="server" Font-Size="25px" ForeColor="#FF0066" 
                    Text="商品介绍"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="Label1" runat="server" Text="*"></asp:Label>
            </td>
        </tr>
        </table>--%>
</asp:Content>

