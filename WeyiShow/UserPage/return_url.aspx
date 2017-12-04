<%@ Page Language="C#" AutoEventWireup="true" Inherits="return_url" CodeFile="return_url.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>页面跳转同步通知页面</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <div style="font-size: large;">
            <f:Label ID="Label1" runat="server"></f:Label>
        </div>
        <f:SimpleForm ID="SimpleForm1" BodyPadding="5px" Width="550px" LabelWidth="100px" EnableCollapse="true"
            runat="server" ShowBorder="True" ShowHeader="false">

            <Items>
                <f:Label Label="订单号：" ID="productid" runat="server"></f:Label>
                <f:Label Label="总金额：" ID="sumprice" runat="server"></f:Label>
                <f:Label Label="支付时间：" ID="time" runat="server"></f:Label>
                <f:Label Label="描述：" ID="xiangqing" runat="server"></f:Label>
                <f:Button ID="btnClose" EnablePostBack="false" Text="继续看看" runat="server" Icon="SystemClose">
                </f:Button>
            </Items>
        </f:SimpleForm>
    </form>
</body>
</html>
