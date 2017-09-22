<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="True"
    Inherits="WeyiShow.UserPage.OrderSure" CodeFile="OrderSure.aspx.cs" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1"  runat="server" />

         

        <f:Grid ID="Grid1" Width="800px" DataKeyNames="Id,Name" runat="server" >
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>

                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>

                        <f:ToolbarText ID="ToolbarText1" Text="请仔细确认订单相关信息" runat="server">
                        </f:ToolbarText>

                    </Items>
                </f:Toolbar>
                
            </Toolbars>
            
            <Columns>
                <%--<f:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </f:TemplateField>--%>
                <f:BoundField DataField="ProductName" HeaderText="商品名称" />
                <f:BoundField DataField="Title" HeaderText="标题" />
                <f:BoundField DataField="Price" HeaderText="价格" />
                <f:BoundField DataField="Class" HeaderText="类别" />
                <%--<f:TemplateField HeaderText="商品名称">
                    <ItemTemplate>
                        <%# GetGender(Eval("ProductName")) %>
                    </ItemTemplate>
                </f:TemplateField>--%>
               <%-- <f:BoundField DataField="EntranceYear" HeaderText="入学年份" />
                <f:CheckBoxField DataField="AtSchool" HeaderText="是否在校" />
                <f:HyperLinkField HeaderText="所学专业" DataTextField="Major" DataTextFormatString="{0}"
                    DataNavigateUrlFields="Major" DataNavigateUrlFormatString="http://gsa.ustc.edu.cn/search?q={0}"
                    Target="_blank" ExpandUnusedSpace="true" />
                <f:ImageField DataImageUrlField="Group" DataImageUrlFormatString="~/res/images/16/{0}.png"
                    HeaderText="分组">
                </f:ImageField>--%>
            </Columns>
        </f:Grid>
        <f:Form ID="SimpleForm1" ShowBorder="false" ShowHeader="false"
            AutoScroll="true" BodyPadding="10px" runat="server">
            <%--<Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <f:Button ID="btnClose" EnablePostBack="false" Text="关闭" runat="server" Icon="SystemClose">
                        </f:Button>

                        <f:ToolbarFill ID="ToolbarFill1" runat="server">
                        </f:ToolbarFill>

                        <f:ToolbarText ID="ToolbarText1" Text="请仔细确认收货地址" runat="server">
                        </f:ToolbarText>

                    </Items>
                </f:Toolbar>
            </Toolbars>--%>



            <Rows>
                <f:FormRow>
                    <Items>
                        <f:DropDownList Label="选择收货地址" runat="server" ID="DropDownList1" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                        </f:DropDownList>
                        <f:TextBox runat="server" Label="收件人" Enabled="false" ID="UserName"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="手机号" Enabled="false" ID="TextBox1"></f:TextBox>
                        <f:TextBox runat="server" Label="邮编" Enabled="false" ID="TextBox2"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="收货地址" Enabled="false" ID="TextBox3"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:Button ID="btnAdd" Text="添加收货地址" OnClick="btnAdd_Click" runat="server"></f:Button>
                        <f:Button ID="btnEditClick" Text="修改" OnClick="btnEditClick_Click" runat="server"></f:Button>

                        <f:Button ID="btnBuyClick" Text="提交" OnClick="btnBuyClick_Click" runat="server"></f:Button>
                    </Items>
                </f:FormRow>



                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="地址标识（备注）" Hidden="true" ID="TextBox8"></f:TextBox>
                        <f:TextBox runat="server" Label="收件人" Hidden="true" ID="TextBox4"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="手机号" Hidden="true" ID="TextBox5"></f:TextBox>
                        <f:TextBox runat="server" Label="邮编" Hidden="true" ID="TextBox6"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                    <Items>
                        <f:TextBox runat="server" Label="收货地址" Hidden="true" ID="TextBox7"></f:TextBox>
                    </Items>
                </f:FormRow>
                <f:FormRow>
                </f:FormRow>

            </Rows>
        </f:Form>


       
    </form>
</body>
</html>
