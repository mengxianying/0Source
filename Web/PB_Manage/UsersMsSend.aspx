<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UsersMsSend.aspx.cs" Inherits="Pbzx.Web.PB_Manage.UsersMsSend" %>

<%@ Register Src="../UserCenter/Contorls/UcMsgCount.ascx" TagName="UcMsgCount" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户短消息服务</title>

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <table width="98%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
            class="MT">
            <tr>
                <td bgcolor="#F3F3F3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="Right_bg1">
                                <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                    <tr>
                                        <td width="91%" align="left">
                                            当前位置：
                                            <asp:Label ID="lblTitle1" runat="server" Text=""></asp:Label>管理</td>
                                        <td width="9%" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="98%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
            class="MT">
            <tr bgcolor="#F7FBFF">
                <td width="20" height="25">
                    <img src="/images/web/Uc_li.gif" alt="" /></td>
                <td width="780" valign="bottom">
                    <span class="uc_font_blue14">
                        <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></span></td>
            </tr>
        </table>
        <table width="98%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
            class="MT">
            <tr bgcolor="#ffffff">
                <td>
                    <asp:GridView ID="MyGridView" runat="server" Width="100%" AutoGenerateColumns="False"
                        CssClass="GridView_Table" DataKeyNames="ID" >
                        <PagerSettings Mode="NumericFirstLast" Visible="False" />
                        <FooterStyle CssClass="GridView_Footer" />
                        <Columns>
                            <asp:TemplateField HeaderText="已读">
                                <ItemTemplate>
                                    <%#Eval("flag").ToString() == "0" ? "<img src='/images/web/m_issend_1.gif' alt='已发送，对方未查阅。' />" : "<img src='/images/web/m_issend_2.gif' alt='已发送，且对方已查阅。' />"%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="收件人">
                                <ItemTemplate>
                                    <%#Eval("incept")%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="主题">
                                <ItemTemplate>
                                    <%# FormartTitleA(Eval("ID"), Eval("title"))%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="日期">
                                <ItemTemplate>
                                    <%#Eval("sendtime", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="大小">
                                <ItemTemplate>
                                    <%# Pbzx.Common.Method.GetStrLen(Eval("content").ToString()) + "Byte"%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="全选">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" name="sel" value="<%#Eval("id") %>" /></ItemTemplate>
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="GridView_Row" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <PagerStyle CssClass="GridView_Pager" />
                        <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                        <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                       <%-- <EmptyDataTemplate>
                            <table width="100%" border="0" cellpadding="3" cellspacing="0" bgcolor="#DCEDFC">
                                <tr>
                                    <td width="8%" align="center">
                                        已读
                                    </td>
                                    <td width="15%" align="center">
                                        发件人</td>
                                    <td width="50%" align="center">
                                        主题</td>
                                    <td width="15%" align="center">
                                        日期</td>
                                    <td width="8%" align="center">
                                        大小</td>
                                    <td width="4%" align="center">
                                        操作</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>--%>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table width="98%">
            <tr>
                <td  height="28" valign="bottom" align="right">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="第一页;" LastPageText="最后一页;" NextPageText="下一页;" NumericButtonCount="3"
                        OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页;" ShowCustomInfoSection="Right"
                        CustomInfoStyle='vertical-align:middle;' ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" class="pagestyle" CustomInfoSectionWidth="35%"
                        HorizontalAlign="Center" SubmitButtonClass="page_go" PageSize="19">
                    </webdiyer:AspNetPager>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <table cellpadding="0" cellspacing="1" width="80%">
                        <tr>
                            <td align="right">
                                节省每一分空间，请及时删除无用消息<asp:Label ID="lblDel" runat="server" Text=""></asp:Label>&nbsp;
                                <input class="chkbox" name="chkall" onclick="javascript:if(this.checked==true){AllChecked();}else{UnAllChecked();}"
                                    type="checkbox" value="on" />选中所有显示记录
                                <asp:Button ID="btnSC" runat="server" Text="删除收信箱" OnClientClick="{if(confirm('确定删除选定的纪录吗?')){return true;}return false;}"
                                    OnClick="btnSC_Click" Width="100px" Height="26px" />&nbsp;
                                <asp:Button ID="btnQK" runat="server" Text="清空收信箱" OnClientClick="{if(confirm('确定清除所有的纪录吗?')){return true;}return false;}"
                                    OnClick="btnQK_Click" Width="100px" Height="26px" />
                            </td>
                            <td style="width: 10px;">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
