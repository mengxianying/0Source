<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Agent.aspx.cs" Inherits="Pbzx.Web.Agent" %>

<%@ Register Src="Contorls/Agent_AD.ascx" TagName="Agent_AD" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Agent_menu.ascx" TagName="Agent_menu" TagPrefix="uc4" %>
<%@ Register Src="Contorls/Agent_province.ascx" TagName="Agent_province" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>代理商列表_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="robots" content="all" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="css/agent.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Head ID="Head1" runat="server" />
        <uc5:Agent_AD ID="Agent_AD1" runat="server"></uc5:Agent_AD>
        <div class="bodyw MT">
            <div class="A_l">
                <uc4:Agent_menu ID="Agent_menu1" runat="server"></uc4:Agent_menu>
            </div>
            <div class="A_r">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
                    <tr>
                        <td bgcolor="#f5f5f5" class="a_border">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="87%" height="25" valign="bottom" class="A_biao">
                                        当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'><span class="A_biao">拼博在线彩神通软件</span></a>
                                        >> <a href="/Agent.aspx"><span class="A_biao">代理专区</span></a> >> 代理商列表
                                    </td>
                                    <td width="13%">
                                        查询&nbsp;<uc3:Agent_province ID="Agent_province1" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CCCCCC">
                            <tr bgcolor="#4099F2">
                                <td width="10%" bgcolor="#69B2F6" class="A_biao2">
                                    省份</td>
                                <td width="14%" bgcolor="#69B2F6" class="A_biao2">
                                    地区</td>
                                <td width="13%" bgcolor="#69B2F6" class="A_biao2">
                                    联系人</td>
                                <td width="22%" bgcolor="#69B2F6" class="A_biao2">
                                    联系电话</td>
                                <td width="41%" bgcolor="#69B2F6" class="A_biao2">
                                    详细地址</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr bgcolor="#FFFFFF">
                            <td class="blue12">
                                <a href="Agent.aspx?province=<%# Pbzx.Common.Input.Encrypt(Eval("Province").ToString())%>">
                                    <%# (Eval("Province"))%>
                                </a>
                            </td>
                            <td>
                                <%# Eval("agttype")%>
                            </td>
                            <td class="blue12">
                                <a href="Agent_explain.aspx?id=<%# Eval("id")%>" target="_blank">
                                    <%# (Eval("Name"))%>
                                </a>
                            </td>
                            <td>
                                <%# (Eval("Telephone"))%>
                            </td>
                            <td align="left">
                                <%# (Eval("Address"))%>
                            </td>
                        </tr>
                        </a>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr bgcolor="#f5f5f5">
                            <td>
                                 <a href="Agent.aspx?province=<%# Pbzx.Common.Input.Encrypt(Eval("Province").ToString())%>">
                                    <%# (Eval("Province"))%>
                                </a>
                            </td>
                            <td>
                                <%# Eval("agttype")%>
                            </td>
                            <td class="blue12">
                                <a href="Agent_explain.aspx?id=<%# Eval("id")%>" target="_blank">
                                    <%# (Eval("Name"))%>
                                </a>
                            </td>
                            <td>
                                <%# (Eval("Telephone"))%>
                            </td>
                            <td align="left">
                                <%# (Eval("Address"))%>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td height="32" valign="bottom" align="center">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                                CustomInfoStyle='vertical-align:middle;' class="pagestyle" CustomInfoSectionWidth="35%"
                                HorizontalAlign="Center">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
