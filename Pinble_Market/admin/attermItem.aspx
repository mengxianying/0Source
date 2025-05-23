<%@ Page Language="C#" AutoEventWireup="true" Codebehind="attermItem.aspx.cs" Inherits="Pinble_Market.admin.attermItem" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>购买信息页</title>
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
    <link href="../Css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <uc1:head ID="Head2" runat="server" />
        <div id="wrap" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="Title">
                <div class="return_title">
                    用户 <font color='red'>
                        <%= Pbzx.Common.Method.Get_UserName.ToString() %>
                    </font>到期的项目条件</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-bottom: 10px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="请输入会员名或条件名查询" />
                                <asp:ImageButton ID="Imbtn_hunt" runat="server" ImageUrl="../image/ieaarchBtn.gif" />
                            </div>
                            <div class="keyword">
                                <img src="../image/hot.gif" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">提示：到期的项目。如果不续订可以直接删除。继续使用请点击续订。</span></div>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                CellPadding="3" BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%"
                AllowPaging="True" OnRowCreated="myGridView_RowCreated" OnRowDataBound="myGridView_RowDataBound"
                OnRowEditing="myGridView_RowEditing" OnRowCancelingEdit="myGridView_RowCancelingEdit"
                OnRowUpdating="myGridView_RowUpdating1">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <%--                <RowStyle CssClass="f_1 form_title" />--%>
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号">
                        <HeaderStyle Height="24px" />
                        <ItemStyle Font-Size="14px" Height="24px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="条件">
                        <ItemTemplate>
                            <asp:Label ID="Lab_Name" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="彩种">
                        <ItemTemplate>
                            <asp:Label ID="Lab_Lottery" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商家">
                        <ItemTemplate>
                            <asp:Label ID="lab_shopName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="价格">
                        <ItemTemplate>
                            <%# Eval("Price") %>
                            彩金币</ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="购买期限">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Term" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("Term") %>
                            个月</ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订购时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("BeginTime")).Substring(0, 10) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="到期时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("EndTime")).Substring(0, 10) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="续费设置">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_Continue" runat="server">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Lab_Continue" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="续费设置" ShowEditButton="True" EditText="续费" />
                </Columns>
                <HeaderStyle Font-Bold="True" CssClass="form" />
            </asp:GridView>
            <table cellpadding="0" cellspacing="0" border="0" width="98%" id="tab">
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="cb_full" runat="server" AutoPostBack="true" OnCheckedChanged="cb_full_CheckedChanged"
                            Text="全选" />
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
                    </td>
                </tr>
            </table>
            <asp:Literal ID="litContent" runat="server"></asp:Literal>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
