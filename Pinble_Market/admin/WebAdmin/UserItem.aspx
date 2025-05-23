<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserItem.aspx.cs" Inherits="Pinble_Market.admin.WebAdmin.UserItem" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" rel="stylesheet" href="../../Css/css.css" />
    <link type="text/css" rel="stylesheet" href="../../Css/head.css" />
     <script language="javascript" type="text/javascript" src="../../JS/GridView.js"></script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px;
                margin-top: 10px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                            </div>
                            <div class="keyword">
                                <img src="../../image/hot.gif" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">提示：所有商户所发布的项目。用户删除状态、说明用户已经把项目删除。 </span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" CellPadding="3" BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True" OnRowCreated="myGridView_RowCreated"
                OnRowDataBound="myGridView_RowDataBound" OnRowCancelingEdit="myGridView_RowCancelingEdit"
                OnRowEditing="myGridView_RowEditing" OnRowUpdating="myGridView_RowUpdating">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号" />
                    <asp:TemplateField HeaderText="商户">
                        <ItemTemplate>
                            <%# Eval("UserId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>
                            <%# Eval("NvarName") %>
                            <%# Eval("TypeName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="彩种">
                        <ItemTemplate>
                            <a href='LotteryBreed.aspx?Name=<%# Pbzx.Common.Input.Encrypt(Eval("NvarName").ToString()) %>'>
                                <%# Eval("NvarName") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Price" HeaderText="价格" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="Lab_state" runat="server"></asp:Label>
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
                    <asp:TemplateField HeaderText="内容介绍">
                        <ItemTemplate>
                              <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
               <HeaderStyle Font-Bold="True" CssClass="form"/>
            </asp:GridView>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged" />全选
                        <asp:Button ID="btn_delete" runat="server" Text="删除" OnClick="btn_delete_Click" />
                        <asp:Button ID="btn_cancel" runat="server" Text="取消" OnClick="btn_cancel_Click" />
                    </td>
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
