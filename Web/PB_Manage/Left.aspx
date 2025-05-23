<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Left.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Left" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
想要改变框架的滚动条颜色的时候，把上边的一行去掉就可以了，但是页面的样式就引用不上了
<html xmlns="http://www.w3.org/1999/xhtml">--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>拼搏在线后台管理</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css_l.css" />
    <style type="text/css">

BODY { SCROLLBAR-ARROW-COLOR:#006699;
SCROLLBAR-FACE-COLOR:#DEE3E7;
SCROLLBAR-DARKSHADOW-COLOR:#DEE3E7;
SCROLLBAR-HIGHLIGHT-COLOR:##DEE3E7;
SCROLLBAR-3DLIGHT-COLOR:#EFEFEF;
SCROLLBAR-SHADOW-COLOR:#98AAB1;
SCROLLBAR-TRACK-COLOR:#EFEFEF;}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="LeftDiv">
            <table width="160" border="0" align="center" cellpadding="0" cellspacing="0" class="MB">
                <tr>
                    <td>
                        <img src="images/Us_l1.jpg" width="160" height="32" alt="" /></td>
                </tr>
                <tr>
                    <td height="28" background="images/Us_l2.jpg">
                        <table width="98%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="82%" align="center">
                                    <a href="Default.aspx" class="guanli">管理首页</a>&nbsp;<strong>|</strong>&nbsp; <a href="LoginOut.aspx"
                                        class="guanli" onclick="script:return confirm('真的要退出吗！');" >退出</a></td>
                                <td width="18%">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div class="LeftMenuDiv" id="LeftMenu">
                <div runat="server" id="dvCustomerPowers">
                    <div class="SubMenuClose" id='BigMenu' onclick="if(document.getElementById('ChildMenuSmall').style.display=='none'){document.getElementById('ChildMenuSmall').style.display='block';}else{document.getElementById('ChildMenuSmall').style.display='none';}"
                        style='background-image: url(images/menu_80.jpg)'>
                        常用功能管理
                    </div>
                    <div class="ChildMenuDiv" id="ChildMenuSmall" style="display: none;">
                        <asp:Repeater ID="rptCustomerPowers" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="ChildMenuNormal">
                                    <table width="95%">
                                        <tr>
                                            <td style="width: 14%" align="center">
                                                <img alt="" src="images/menu_li.jpg" width="9" height="9" />
                                            </td>
                                            <td style="width: 86%" align="left">
                                                <a href="<%# Eval("URL")%>" target="ShowPage" class="menu_small">
                                                    <%# Eval("Name")%>
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" OnRowCreated="MyGridView_RowCreated"
                    DataKeyNames="ID,RootID,Depth,FlagMenu" BorderStyle="None" BorderWidth="0px"
                    CellPadding="0" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Panel ID="pnlSub" runat="server">
                                    <div class="SubMenuClose" id='SubMenu<%# Eval("ID")%>' style='background-image: url(images/menu_<%#DataBinder.Eval(Container.DataItem,"ID") %>.jpg)'>
                                        <%# Eval("Name")%>
                                    </div>
                                </asp:Panel>
                                <div class="ChildMenuDiv" id="ChildMenu<%# Eval("ID")%>" style="display: none;">
                                    <asp:Repeater ID="rptChild" DataSource="<%# Dview%>" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="ChildMenuNormal">
                                                <table width="95%">
                                                    <tr>
                                                        <td style="width: 14%" align="center">
                                                            <img alt="" src="images/menu_li.jpg" width="9" height="9" />
                                                        </td>
                                                        <td style="width: 86%" align="left">
                                                            <a href="<%# Eval("URL")%>" target="ShowPage" class="menu_small">
                                                                <%# Eval("Name")%>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle BorderStyle="None" BorderWidth="0px" />
                </asp:GridView>
                <table width="160" border="0" align="center" cellpadding="0" cellspacing="0" class="MT MB">
                    <tr>
                        <td bgcolor="#DDE4F9">
                            <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="2" align="left">
                                        版权所有：</td>
                                </tr>
                                <tr>
                                    <td width="13%">
                                        &nbsp;
                                    </td>
                                    <td width="87%" align="left">
                                        <a href="http://www.pinble.com/" target="_blank" class="menu_small">拼搏在线<br />
                                            (Pinble.Com)</a></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <a href="http://bbs.pinble.com/" target="_blank" class="menu_small">拼搏论坛<br />
                                            (Bbs.Pinble.Com)</a></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td align="left">
                                        <a href="http://blog.pinble.com/" target="_blank" class="menu_small">拼搏博客<br />
                                            Blog.Pinble.Com)</a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
