<%@ Page Language="C#" AutoEventWireup="true" Inherits="WeyiShow.WebForm1" CodeFile="WebForm1.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:DropDownList ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" runat="server"></asp:DropDownList>
    </form>
</body>
</html>
