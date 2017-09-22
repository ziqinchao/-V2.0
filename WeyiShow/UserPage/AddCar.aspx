<%@ Page Title="" Language="C#" MasterPageFile="~/UserPage/tetle.master" AutoEventWireup="true" Inherits="USER_AddCar" CodeFile="AddCar.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
  


    <f:PageManager ID="PageManager1" runat="server" />
        <f:Grid ID="Grid1"  DataKeyNames="Id,Name" AllowCellEditing="true" runat="server" Title="表格"  EnableSummary="true" SummaryPosition="Flow">
            <Columns>
                <f:RowNumberField />
                <f:TemplateField>
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </f:TemplateField>
                <f:BoundField DataField="ProductName" MinWidth="400px" HeaderText="商品名称" />
                <f:ImageField DataImageUrlField="ImageUrl" MinWidth="200px" DataImageUrlFormatString="{0}" HeaderText="图片">                    
                </f:ImageField>
                <f:BoundField DataField="Price" HeaderText="单价"/>
                <f:RenderField Width="100px" ColumnID="EntranceYear" DataField="Number" FieldType="Int"
                    HeaderText="数量">
                    <Editor>
                        <f:NumberBox ID="tbxEditorEntranceYear" NoDecimal="true" NoNegative="true" MinValue="1"
                            MaxValue="2025" runat="server">
                        </f:NumberBox>
                    </Editor>
                </f:RenderField>
                <f:BoundField DataField="SumPrice" ColumnID="fee" HeaderText="总价" />
                
            </Columns>
        </f:Grid>
    <f:HiddenField runat="server" ID="hfGrid1Summary"></f:HiddenField>


</asp:Content>

