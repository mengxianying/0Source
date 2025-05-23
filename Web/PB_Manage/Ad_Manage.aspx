<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Ad_Manage.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ad_Manage" %>

<%@ Register Src="Controls/UcAD.ascx" TagName="UcAD" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：广告管理>>广告管理列表</td>
                                            <td width="9%" align="right">
                                               <%-- <asp:Button ID="Button2" runat="server" Text=">>返回" OnClientClick="history.back();return false;" />--%></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td align="CENTER">
                                    <a href="Ad_Manage.aspx">广告管理列表</a> | <a href="Ad_Edit.aspx">添加广告</a> | <a href="AdvPlace_Manage.aspx">
                                        广告位列表</a>
                                    | <asp:LinkButton ID="lbtnUpDateIndex" runat="server" Text="生成首页" OnClick="lbtnUpDateIndex_Click" ></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcAD ID="UcAD1" runat="server" />
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" Width="100%" AllowPaging="True" DataKeyNames="ID" CssClass="GridView_Table"
                            OnSorting="MyGridView_Sorting" OnRowDataBound="MyGridView_RowDataBound"
                            OnSelectedIndexChanged="MyGridView_SelectedIndexChanged" AllowSorting="True">
                            <FooterStyle CssClass="GridView_Footer" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                            <RowStyle CssClass="GridView_Row" />
                            <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            <Columns>
                                <asp:TemplateField HeaderText="全选">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" name="sel" value='<%#Eval("ID") %>' /></ItemTemplate>
                                    <ItemStyle Width="3%" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="序号" SortExpression="ID">
                                    <EditItemTemplate>
                                        <asp:Label ID="lbxu" runat="server" Text='<%#Eval("ID")%>'></asp:Label>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="网站名称">
                                    <ItemTemplate>
                                        <a href='<%#Eval("pb_SiteUrl")%>' title='网站地址:<%#Eval("pb_SiteUrl")%>&#13;网站简介：<%# Pbzx.Common.Input.FilterHTML(Eval("pb_SiteIntro").ToString())%>'>
                                            <%#Eval("pb_SiteName")%>
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="广告位置" SortExpression="PlaceName">
                                    <ItemTemplate>
                                        <%#Eval("PlaceName")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="26%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="广告图片">
                                    <ItemTemplate>
                                        <%# GetAD(Eval("pb_SiteName"), Eval("pb_SiteUrl"), Eval("pb_ImgUrl"), Eval("PlaceName"), Eval("pb_ImgWidth"), Eval("pb_ImgHeight"))%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="35%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="过期时间" SortExpression="pb_ENDTime">
                                    <ItemTemplate>
                                        <%# Convert.ToDateTime(Eval("pb_ENDTime")) < DateTime.Now ? "<font color='red'>" + Eval("pb_ENDTime", "{0:yyyy-MM-dd}") + "</font>" : Eval("pb_ENDTime", "{0:yyyy-MM-dd}")%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="新" SortExpression="pb_IsSelected">
                                    <ItemTemplate>
                                        <%# Convert.ToBoolean(Eval("pb_IsSelected")) ? "<font color=green>新</font>" : "<font color=red></font>" %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href='Ad_Edit.aspx?ID=<%#Eval("ID") %>'>修改</a><%--|<asp:LinkButton ID="lbtnDel" runat="server"
                                            OnClientClick="return confirm('您确定要删除吗?')" CommandArgument='<%# Eval("ID") %>'
                                            OnCommand="lbtnDel_Command">删除</asp:LinkButton>--%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <table cellpadding="4" cellspacing="0">
                <tr>
                    <td>
                        <b>数据批量操作：</b></td>
                    <td>
                        &nbsp;&nbsp;<asp:Button ID="btnNew" runat="server" Text="（最新）" OnClientClick="return CheckBatchUpdate('最新')"
                            OnClick="btnNew_Click" />&nbsp;&nbsp;
                    </td>
                       <td>
                        &nbsp;&nbsp;<asp:Button ID="btnNNew" runat="server" Text="（不最新）" OnClientClick="return CheckBatchUpdate('不最新')"
                            OnClick="btnNNew_Click" />&nbsp;&nbsp;
                    </td>
                    <%--  <td>
                                    &nbsp;&nbsp;
                                    <asp:Button ID="btnSC" runat="server" Text="批量删除" OnClientClick="return CheckBatchUpdate('删除')" OnClick="btnSC_Click" />
                                    &nbsp;&nbsp;
                                </td>--%>
                    <td>
                    </td>
                    <td style="width: 15px;">
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                           FirstPageText="首页" LastPageText="尾页" NextPageText="下页"
                            OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                            CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                            HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                        <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
