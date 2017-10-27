<%@ Page Language="C#" AutoEventWireup="True" CodeFile="CommodityManage.aspx.cs"
    Inherits="WeyiShow.AdminPage.CommodityManage" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" runat="server" />
        <%-- <f:Grid ID="Grid1" ShowBorder="true" ShowHeader="true" Title="表格" EnableCollapse="true" Width="850px"
            runat="server" DataKeyNames="Id,Name" AllowCellEditing="true" ClicksToEdit="2"  
            DataIDField="Id">--%>
        <f:Grid ID="Grid1" EnableCollapse="true" AllowCellEditing="true" DataKeyNames="Id,Name" runat="server" Title="表格" OnPreDataBound="Grid1_PreDataBound">
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server">
                    <Items>                        
                        <f:Button ID="btnNew" runat="server" Icon="Add" EnablePostBack="false" OnClientClick="openUploadGoods();"
                            Text="新增数据">
                        </f:Button>
                        <f:Button ID="btnDelete" Text="删除选中行" Icon="Delete" EnablePostBack="false" runat="server">
                        </f:Button>
                        <f:ToolbarFill runat="server">
                        </f:ToolbarFill>
                        <f:Button ID="btnReset" Text="重置表格数据" EnablePostBack="false" runat="server">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Columns>
                <f:TemplateField ColumnID="Number" Width="60px">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField DataField="ProductId" ExpandUnusedSpace="true" DataFormatString="{0}" HeaderText="商品编号" />

                <f:TemplateField HeaderText="上传者姓名" ColumnID="TJRName">
                    <ItemTemplate>
                        <%# GetTJRName(Eval("TJRGuid")) %>
                    </ItemTemplate>
                </f:TemplateField>
                <f:RenderField Width="100px" ColumnID="ProductName" DataField="ProductName" FieldType="String"
                    HeaderText="商品名称">
                    <Editor>
                        <f:TextBox ID="tbxEditorName" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

                <f:RenderField Width="100px" ColumnID="Price" DataField="Price" FieldType="String"
                    HeaderText="价格">
                    <Editor>
                        <f:TextBox ID="TextBox1" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="100px" ColumnID="Class" DataField="Class" FieldType="String"
                    HeaderText="类别">
                    <Editor>
                        <f:TextBox ID="TextBox2" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>
                <f:RenderField Width="120px" ColumnID="FBData" DataField="FBData" FieldType="Date"
                    Renderer="Date" RendererArgument="yyyy-MM-dd" HeaderText="上传时间">
                    <Editor>
                        <f:DatePicker ID="DatePicker1" runat="server">
                        </f:DatePicker>
                    </Editor>
                </f:RenderField>

                <f:RenderField Width="100px" ColumnID="Topceng" DataField="Topceng" FieldType="Int"
                    ExpandUnusedSpace="true" HeaderText="热度">
                    <Editor>
                        <f:TextBox ID="tbxEditorMajor" Required="true" runat="server">
                        </f:TextBox>
                    </Editor>
                </f:RenderField>

                <f:WindowField ColumnID="myWindowField" Width="80px" WindowID="Window1" HeaderText="编辑"
                    Icon="Pencil" ToolTip="编辑" DataTextFormatString="{0}" DataIFrameUrlFields="ProductId"
                    DataIFrameUrlFormatString="GoodEditWindows.aspx?id={0}" DataWindowTitleField="Name"
                    DataWindowTitleFormatString="编辑 - {0}" />
                <f:LinkButtonField ColumnID="Delete" HeaderText="&nbsp;" Width="80px" EnablePostBack="false"
                    Icon="Delete" />
            </Columns>
        </f:Grid>


        <br />
        <f:Button ID="Button2" runat="server" Text="保存数据" OnClick="Button2_Click">
        </f:Button>
        <br />
        <br />
        <f:Label ID="labResult" EncodeText="false" runat="server">
        </f:Label>
        <br />

        <f:Window ID="Window1" Title="编辑" Hidden="true" EnableIFrame="true" runat="server"
            CloseAction="HidePostBack"
            EnableMaximize="true" EnableResize="true" Target="Top"
            IsModal="False" Width="850px" Height="450px">
        </f:Window>

    </form>
     <script type="text/javascript">

        var basePath = '<%= ResolveUrl("~/") %>';

         function openUploadGoods() {
             parent.addExampleTab.apply(null, ['hello_fineui_tab', basePath + 'basic/UploadGoods.aspx', '上传商品', basePath + 'res/images/filetype/vs_aspx.png', undefined, true]);
        }

        
    </script>

</body>
</html>
