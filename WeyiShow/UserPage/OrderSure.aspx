<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="True"
    Inherits="WeyiShow.UserPage.OrderSure" CodeFile="OrderSure.aspx.cs" %>

<!DOCTYPE html>
<html>
<head id="head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />



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
                <f:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField DataField="ProductName" HeaderText="商品名称" />
                <f:BoundField DataField="Title" HeaderText="标题" />
                <f:BoundField DataField="Class" HeaderText="类别" />
                <f:BoundField DataField="Price" HeaderText="价格" />
                <f:BoundField DataField="num" HeaderText="数量" />
                <f:TemplateField HeaderText="小计" Width="120px" ColumnID="sumPrice">
                    <ItemTemplate>
                        <asp:Label runat="server" CssClass="xiaoji" Text='<%# "¥" + GetXiaoji(Eval("Price"), Eval("num")) %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>

            </Columns>
        </f:Grid>
        <div style="margin-bottom: 10px;">
            <input type="hidden" id="TOTAL_PRICE" name="TOTAL_PRICE" />
            总计：<span id="totalPrice" style="color: red; font-size: 1.5em; font-weight: bold;"></span>
        </div>
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
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var gridClientID = '<%= Grid1.ClientID %>';
        var numberSelector = '.f-grid-tpl input.number';
        var priceSelector = '.f-grid-tpl input.price';

        function getRowNumber(row) {
            var num = parseInt(row.find(numberSelector).val(), 10);
            if (isNaN(num)) {
                num = 0;
            }
            return num;
        }
        function getRowPrice(row) {
            return parseFloat(row.find(priceSelector).val());
        }

        function updateTotal() {
            var grid = F(gridClientID);
            var selection = grid.getSelectionModel().getSelection();
            var store = grid.getStore();

            var total = 0;
            $.each(selection, function (index, item) {
                var rowIndex = store.indexOf(item);
                var row = $(grid.body.el.dom).find('.x-grid-item').eq(rowIndex);
                total += getRowNumber(row) * getRowPrice(row);
            });

            
            $('#totalPrice').text("¥" + total.toFixed(2));

            
            $('#TOTAL_PRICE').val(total.toFixed(2));

           
        }

    
        // 页面第一次加载完成后调用的函数
        F.ready(function () {
            updateTotal();
        });

    </script>
</body>
</html>
