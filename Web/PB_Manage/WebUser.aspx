<%@ Page Language="C#" AutoEventWireup="True" Codebehind="WebUser.aspx.cs" Inherits="Pbzx.Web.PB_Manage.WebUser" %>

<%@ Register Src="Controls/UcWebUser.ascx" TagName="UcWebUser" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站注册用户管理</title>
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
                                                当前位置：
                                                <asp:Label ID="labAction" runat="server" />网站用户管理</td>
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
            <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#E7A427"
                class="MT">
                <tr>
                    <td bgcolor="#F7FBFF" align="left">
                        <uc1:UcWebUser ID="UcWebUser1" runat="server"></uc1:UcWebUser>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="1" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr bgcolor="#ffffff">
                    <td>
                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                            CellPadding="0" CssClass="GridView_Table" DataKeyNames="UserID" Width="100%"
                            OnRowDataBound="MyGridView_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="UserID" HeaderText="序号" />
                                <asp:BoundField HeaderText="用户名" DataField="UserName" />
                                <asp:TemplateField HeaderText="邮箱地址">
                                    <ItemTemplate>
                                        <%#Eval("UserEmail") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="手机号码">
                                    <ItemTemplate>
                                        <%#Eval("Mobile")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户类型">
                                    <ItemTemplate>
                                         <a href="WebUser.aspx?UserClass=<%#Eval("UserClass") %>"> <%#Eval("UserClass")%> </a>                                 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请时间">
                                    <ItemTemplate>
                                        <%#Eval("JoinDate", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最后登录时间">
                                    <ItemTemplate>
                                        <%#Eval("LastLogin", "{0:yyyy-MM-dd HH:mm:ss}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最后登录IP">
                                    <ItemTemplate>
                                        <div title='IP地址:<%#DataBinder.Eval(Container.DataItem,"UserLastIP")%>&#13;'>
                                            <%#   Pbzx.Web.WebFunc.GetIpName(Eval("UserLastIP"))%>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="查看">
                                    <ItemTemplate>
                                        <a href="WebUser_Editor.aspx?ID=<%#Eval("UserID") %>" target="_blank">查看 </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="GridView_Row" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <PagerStyle CssClass="GridView_Pager" />
                            <HeaderStyle Font-Bold="True" CssClass="GridView_Header" />
                            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
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
