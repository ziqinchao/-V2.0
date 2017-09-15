<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/tetle.master" AutoEventWireup="true" Inherits="USER_MakeSure" CodeBehind="MakeSure.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td colspan="5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="18px"
                    ForeColor="#FF0066" Text="请确定收货信息"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label8" runat="server" Text="收货人姓名:    "></asp:Label>
                <asp:Label ID="lbname" runat="server" Text="*"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Text="联系号码:  "></asp:Label>
                <asp:Label ID="lbphone" runat="server" Text="*"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label2" runat="server" Text="邮编号:    "></asp:Label>
                <asp:Label ID="lbpost" runat="server" Text="*"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="4">
                <asp:Label ID="Label3" runat="server" Text="收货地址:  "></asp:Label>
                <asp:Label ID="lbaddress" runat="server" Text="*"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="noedit" runat="server" Text="  无  需  更  改  "
                    OnClick="noedit_Click" />
            </td>
            <td colspan="2">
                <asp:Button ID="edit" runat="server" Text=" 需 要 更 改 " OnClick="edit_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td>
                <asp:Label ID="Label9" runat="server" Text="更新姓名:  "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRename" runat="server" Height="17px" Width="350px"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px; height: 17px"></td>
            <td style="height: 17px; width: 112px">
                <asp:Label ID="Label5" runat="server" Text="需更新号码:  "></asp:Label>
            </td>
            <td style="height: 17px" colspan="2">
                <asp:TextBox ID="editphone" runat="server" Height="17px" Width="350px"></asp:TextBox>
            </td>
            <td style="height: 17px"></td>
            <td style="height: 17px"></td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td>
                <asp:Label ID="Label6" runat="server" Text="需更新邮编号:  "></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="editpost" runat="server" Height="17px" Width="350px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="editpost" ErrorMessage="请正确填写" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="需更新地址:  "></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="editaddress" runat="server" Height="17px" Width="350px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td>&nbsp;</td>
            <td colspan="2">
                <asp:Button ID="sureedit" runat="server" Text=" 确 认 更 改 "
                    OnClick="sureedit_Click" />
                <asp:Button ID="quxiao" runat="server" OnClick="quxiao_Click"
                    Text=" 取 消 更 改 " />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 136px">&nbsp;</td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="提交" /></td>
            
            <td><asp:Button ID="btnzkk" runat="server" Text="再看看" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
</asp:Content>

