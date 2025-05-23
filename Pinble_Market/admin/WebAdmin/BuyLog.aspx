<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BuyLog.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.BuyLog" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="../../Css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" CellPadding="0" Width="100%" AllowPaging="True" OnRowCreated="GridView1_RowCreated"
                OnRowDataBound="GridView1_RowDataBound" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowUpdating="GridView1_RowUpdating"  CssClass="GridView_Table">
                 <PagerSettings Mode="NumericFirstLast" Visible="False" />
                                <FooterStyle CssClass="GridView_Footer" />
                <Columns>
                    <asp:BoundField HeaderText="序号" />
                    <asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>
                            <asp:Label ID="Lab_ItemName" runat="server"></asp:Label><%# Eval("LotteryType") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商户名称">
                        <ItemTemplate>
                            <asp:Label ID="Lab_ShopName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="客户名称">
                        <ItemTemplate>
                           <%# Eval("buyuserid")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="续费设置">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Continue" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lab_buyContinue" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="购买期限">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Term" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("Term") %>
                            个月
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="起订时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("BeginTime")).Substring(0, 10)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="到期时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("EndTime")).Substring(0, 10) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目价格">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_Price" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("Price") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目状态">
                        <ItemTemplate>
                            <asp:Label ID="Lab_state" runat="server"></asp:Label>
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
