<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FriendLink_Manage.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.FriendLink_Manage" EnableEventValidation="false" %>

<%@ Register Src="Controls/UcFriendLink.ascx" TagName="UcFriendLink" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function OpenEdite(TbName, PrimaryKey, ColName, ColName2, SortID, StrWhere, myWidth, myHeight) {
            var aa = '';
            var result = window.open('PopFram/PublicSort.aspx?TbName=' + TbName + '&PrimaryKey=' + PrimaryKey + '&ColName=' + ColName + '&ColName2=' + ColName2 + '&SortID=' + SortID + '&StrWhere=' + StrWhere + '', 'newwindow', 'height=' + myHeight + ', width=' + myWidth + ', top=' + (screen.height - 500) / 2 + ',left=' + (screen.width - 800) / 2 + ' toolbar=no, menubar=no, scrollbars=yes, resizable=no,location=no, status=no');
            //,'','dialogHeight:800px;dialogWidth:600px;center:yes;help:no;resizable:no;scroll:yes;status:no; scrollbars:No;toolbar:no;menubar:no;location:no;' 
            if (aa == 'yes') {
                location.reload();
            }
        }

    </script>
</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divOperator" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>友情链接管理
                                        </td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                        <tr>
                            <td align="CENTER">
                                <a href="FriendLink_Manage.aspx">友情链接管理</a> |&nbsp;<a href="FriendLink_Editor.aspx">添加友情链接信息</a>&nbsp;|
                                <a href="#" onclick="OpenEdite('PBnet_Links','IntID','IntSiteName','NteSiteUrl','SortOrder','','1000','700')">
                                    友情链接排序</a><%--|&nbsp;&nbsp;<a
                                        href="FriendLink_Sort.aspx">友情链接排序</a>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="4" cellspacing="1" bgcolor="#E7A427"
            aligin="left" class="MT">
            <tr bgcolor="#F7FBFF" align="left">
                <td>
                    <uc1:UcFriendLink ID="UcFriendLink1" runat="server" ReUrl="FriendLink_Manage.aspx">
                    </uc1:UcFriendLink>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                    class="MT">
                    <tr bgcolor="#ffffff">
                        <td>
                            <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                CellPadding="3" Width="100%" AllowPaging="True" DataKeyNames="IntID" OnRowCreated="MyGridView_RowCreated"
                                CssClass="GridView_Table" AllowSorting="True" OnSorting="MyGridView_Sorting">
                                <FooterStyle CssClass="GridView_Footer" />
                                <Columns>
                                    <asp:BoundField HeaderText="编号" DataField="IntID">
                                        <ItemStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="NteSiteUrl" DataTextField="IntSiteName"
                                        HeaderText="网站名称" Target="_blank">
                                        <ItemStyle Width="15%" />
                                    </asp:HyperLinkField>
                                    <asp:TemplateField HeaderText="网站Logo">
                                        <ItemTemplate>
                                            <%#GetPic(Eval("NteLogoUrl"))%>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SortOrder" HeaderText="排序" SortExpression="SortOrder">
                                        <ItemStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NvarSiteAdmin" HeaderText="站长">
                                        <ItemStyle Width="10%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="链接类型">
                                        <ItemTemplate>
                                            <%# Pbzx.Common.Method.GetLinksType(Eval("IntLinkType"))%>
                                        </ItemTemplate>
                                        <ItemStyle Width="8%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="推荐" SortExpression="BitIsGood">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnIsGood" CommandArgument='<%# Eval("IntID") %>' runat="server"
                                                OnCommand="lbtnIsGood_Command"><%# Convert.ToBoolean(Eval("BitIsGood")) ? "<font color='blue'>已推荐</font>" : "<font color='black'>不推荐</font>"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="添加时间" SortExpression="ModifyTime">
                                        <ItemTemplate>
                                            <%# Eval("ModifyTime")%>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态" SortExpression="BitIsOK">
                                        <ItemTemplate>
                                            <%--  <asp:LinkButton ID="lbtnIsOK" CommandArgument='<%# Eval("IntID") %>' runat="server"
                                                OnCommand="lbtnIsOK_Command">        </asp:LinkButton>--%>
                                            <%# GetStatus(Eval("BitIsOK"))%>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFields="IntID" DataNavigateUrlFormatString="FriendLink_Editor.aspx?ID={0}"
                                        HeaderText="编辑" Text="编辑">
                                        <ItemStyle Width="5%" />
                                    </asp:HyperLinkField>
                                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete1"
                                                OnClientClick="return confirm('您确定要删除吗?')" Text="删除" OnCommand="LinkButton1_Command"
                                                CommandArgument='<%# Eval("IntID") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <PagerStyle CssClass="GridView_Pager" />
                                <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                                <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                                <RowStyle CssClass="GridView_Row" />
                                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table cellpadding="2" cellspacing="0" border="0" width="100%">
            <tr>
                <td>
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" NumericButtonCount="3"
                        OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上页" ShowCustomInfoSection="Right"
                        ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                        CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                        HorizontalAlign="Center" PageSize="20">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
