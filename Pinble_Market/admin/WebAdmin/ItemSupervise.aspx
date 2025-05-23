<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemSupervise.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.ItemSupervise" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="../../Css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="0" Width="100%" AllowPaging="True" CssClass="GridView_Table" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
            <PagerSettings Mode="NumericFirstLast" Visible="False" />
            <FooterStyle CssClass="GridView_Footer" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="彩种">
                <ItemTemplate>
                 <a href='LotteryBreed.aspx?Name=<%# Eval("NvarName") %>'><%# Eval("NvarName") %></a>  
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目名称">
                <ItemTemplate>
                  <a href='Item.aspx?type=<%# Eval("TypeName") %>&name=<%# Eval("NvarName") %>'><%# Eval("NvarName") %><%# Eval("TypeName") %></a>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布人">
                <ItemTemplate>
                 <a href='UserItem.aspx?Name=<%# Eval("UserId") %>'> 
                     <asp:Label ID="lab_userName" runat="server"></asp:Label></a>   
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="价格" />
                <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <asp:Label ID="Lab_state" runat="server" ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddl_state" runat="server">
                    </asp:DropDownList>
                </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发布时间">
                <ItemTemplate>
                    <%# string.Format("{0:u}", Eval("Time")).Substring(0, 10) %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="查看详细">
                <ItemTemplate>
                    <%# Eval("say") %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <RowStyle CssClass="GridView_Row" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle CssClass="GridView_Pager" />
                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
        </asp:GridView>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                    </tr>
                </table>
    </div>
    </form>
</body>
</html>
