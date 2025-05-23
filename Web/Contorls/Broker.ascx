<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Broker.ascx.cs" Inherits="Pbzx.Web.Contorls.Broker" %>
<%@ Register Src="UC_QQa.ascx" TagName="UC_QQa" TagPrefix="uc5" %>
<%@ Register Src="Uc_Flash.ascx" TagName="Uc_Flash" TagPrefix="uc3" %>
<%@ Register Src="UcLogin.ascx" TagName="UcLogin" TagPrefix="uc2" %>
<%@ Register Src="Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc1" %>
<%@ Import Namespace="Pbzx.Common" %>

<script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"></script>

<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0">
    <tr>
        <td bgcolor="#ffffff">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="27" background="images/web/br_lbg.jpg" class="br_lZ">
                        会员登录</td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td align="left">
                        <table width="88%" border="0" align="center" cellpadding="2" cellspacing="0" id="login"
                            runat="server">
                            <tr>
                                <td>
                                    <uc2:UcLogin ID="UcLogin1" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table width="85%" border="0" align="center" cellpadding="2" cellspacing="0" id="user"
                            runat="server">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="shenq" runat="server">
                                        <tr>
                                            <td style="height: 30px">
                                                <a href="/Broker_Agrt.aspx">
                                                    <img src="/Images/Web/sheng.gif" height="26" width="170" border="0" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="1" cellspacing="0" id="menu" runat="server">
                                        <tr>
                                            <td>
                                                <img src="/images/web/br_menu1.jpg" height="27" width="160" border="0" onclick="window.top.location.href='/UserCenter/User_Center.aspx?myUrl=My_broker.aspx'"
                                                    style="cursor: hand;" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" valign="bottom">
                                                <font color="red">
                                                    <asp:Label ID="lblBrokerState" runat="server" Text="" Visible="false"></asp:Label></font>
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                            <td>
                                            <a href=/Broker_Agrt2.aspx?up=2><img src="../images/web/br_menu2.jpg" height="27" width="160" border="0" /></a>                                                                                  
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td>
            <uc3:Uc_Flash ID="Uc_Flash1" runat="server" PlaceType="经纪人动画" />
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0"
    class="MT">
    <tr>
        <td bgcolor="#ffffff">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="27" background="images/web/br_lbg.jpg" class="br_lZ">
                        『彩神通』经纪人</td>
                </tr>
            </table>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="3">
                    </td>
                </tr>
            </table>
            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:DataList ID="dtliuc" runat="server" CellPadding="0">
                            <ItemTemplate>
                                <a href="/Broker.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>" class="menu">
                                    <div class="br_menubg1 brokerhang">
                                        <%#Eval("Btitle")%>
                                    </div>
                                </a>
                            </ItemTemplate>
                            <ItemStyle CssClass="brokerhang" />
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 18px">
                        <a href="#" onclick="CheckIsBroker();" class="menu">
                            <div class="br_menubg1 brokerhang">
                             <span  style="width:65; text-align:left;">在线申请</span></div>
                        </a>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DataList ID="dtxiangx" runat="server" CellPadding="0">
                            <ItemTemplate>
                                <a href="/Broker.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>" class="menu">
                                    <div class="br_menubg1 brokerhang">
                                        <%#Eval("Btitle")%>
                                    </div>
                                </a>
                            </ItemTemplate>
                            <ItemStyle CssClass="brokerhang" />
                        </asp:DataList>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                <tr>
                    <td align="left">
                        <asp:DataList ID="dthaoc" runat="server" CellPadding="0">
                            <ItemTemplate>
                                &nbsp;·<a href="/Broker.aspx?ID=<%#Input.Encrypt(Eval("ID").ToString()) %>"><%#Eval("Btitle")%>
                                </a>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0"
    class="MT">
    <tr>
        <td height="25" background="images/web/br_lbg.jpg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="br_lZ">
                        最新公告
                    </td>
                    <td valign="bottom">
                        <a href="/Bulletin_list.aspx?NewsType=<%= Pbzx.Common.Input.Encrypt("7") %>" target="_blank">
                            更多>></a></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td bgcolor="#EFF8FE">
            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                <tr>
                    <td align="left">
                        <uc1:Bulletin_r ID="Bulletin_r1" runat="server" TitleLength="15" IntChannelID="12" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#86BEF0"
    class="MT">
    <tr>
        <td height="25" background="images/web/br_lbg.jpg">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="br_lZ">
                        在线客服
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td bgcolor="#EFF8FE">
            <table width="100%" border="0" cellpadding="0" cellspacing="0" style=" padding-top:5px; padding-bottom:2px;">
                <tr>
                    <td align="left">
                       <uc5:UC_QQa ID="UC_QQa1" runat="server" />
                        </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
