<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/userInfo.master" AutoEventWireup="true" CodeFile="PersonInfo.aspx.cs" Inherits="USER_PersonInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td align="center" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 504px" align="right">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="用户名:  "></asp:Label>
&nbsp;</td>
        <td align="left">
            <asp:Label ID="txtusername" runat="server" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 504px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height: 18px; " align="center" colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="18px" 
                ForeColor="#FF0066" Text="收货信息"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 504px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 504px" align="right">
            <asp:Label ID="Label2" runat="server" Text="收货人姓名：  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbname" runat="server" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 504px" align="right">
            <asp:Label ID="Label3" runat="server" Text="收货人联系号码：  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbphone" runat="server" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 504px" align="right">
            <asp:Label ID="Label4" runat="server" Text="收货人邮编号码：  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbpost" runat="server" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 504px" align="right">
            <asp:Label ID="Label5" runat="server" Text="收货人地址：  "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lbaddress" runat="server" Text="*"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 504px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

