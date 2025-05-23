<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserShow.aspx.cs" Inherits="Pinble_Ask.UserShow" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户信息中心_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript"  src="/javascript/CustomService.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="132" align="right">
                        <table width="158px" height="72px" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="158" height="72" align="center">
                                    <a href='http://www.pinble.com/'><img border='0' src='/Images/Web/PinbleLogo.gif'  width='158' height='72'></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="100">
                        <a href="<%=Pbzx.Common.WebInit.ask.WebUrl%>">
                            <img src="/images/A_Logo.jpg" width="120" height="58" border="0" /></a></td>
                    <td width="745" style="padding-top: 18px;">
                        <table width="100%" border="0" cellpadding="1" cellspacing="0" bgcolor="#E5ECF9">
                            <tr>
                                <td width="94%" align="left" class="f14blackB">
                                    &nbsp;用户信息中心</td>
                                <td width="6%">
                                    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="3" cellspacing="0">
                <tr>
                    <td width="17" height="25">
                        <img src="images/Uy_li.jpg" width="15" height="18" /></td>
                    <td width="953" align="left" valign="bottom">
                        <span class="f14blackB">
                            <%=userName %>
                        </span>注册时间：<%=userRegTime %>
                        积分：<span class="yellow"><%=userJF %></span> 头衔：<span class="yellow"><%=userTitle %></span></td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="27" valign="bottom" background="images/Uy_bg1.jpg">
                        <table width="98%" border="0" align="center" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="57%" align="left">
                                    <strong>积分明细</strong></td>
                                <td width="43%" align="left">
                                    <strong style="margin-left: 15px;">回答统计</strong></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td background="images/Uy_bg2.jpg">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="57%">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td width="20%">
                                                总分</td>
                                            <td width="30%">
                                                奖励得分</td>
                                            <td width="30%">
                                                历史付出
                                            </td>
                                            <td width="20%">
                                                处 罚</td>
                                        </tr>
                                        <tr>
                                            <td class="yellow">
                                                <asp:Label ID="lblTotalPoint" runat="server">0</asp:Label></td>
                                            <td class="yellow">
                                                <asp:Label ID="lblAnswerPoint" runat="server">0</asp:Label></td>
                                            <td class="yellow">
                                                <asp:Label ID="lblXSPoint" runat="server">0</asp:Label></td>
                                            <td class="yellow" style="width: 95px">
                                                <asp:Label ID="lblPointpenalty" runat="server">0</asp:Label>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="43%">
                                    <table width="93%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                回答总数</td>
                                            <td>
                                                回答被采纳</td>
                                            <td>
                                                回答被采纳率</td>
                                        </tr>
                                        <tr>
                                            <td class="yellow">
                                                <asp:Label ID="lblAnswerCount" runat="server"></asp:Label></td>
                                            <td class="yellow">
                                                <asp:Label ID="lblBestAnswer" runat="server"></asp:Label></td>
                                            <td class="yellow">
                                                <asp:Label ID="lblRat" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/Uy_bg3.jpg" width="970" height="5" /></td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="4" cellspacing="0">
                <tr>
                    <td height="25" align="left" valign="bottom" class="f14blackB">
                        &nbsp;用户贡献</td>
                </tr>
            </table>
            <table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="27" valign="bottom" background="images/Uy_bg1.jpg">
                        <table width="97%" border="0" align="center" cellpadding="1" cellspacing="0">
                            <tr>
                                <td width="52%" align="left">
                                    <strong>标题</strong></td>
                                <td width="10%">
                                    <strong>回答数</strong></td>
                                <td width="10%">
                                    <strong>状态</strong></td>
                                <td width="10%">
                                    <strong>被采纳</strong></td>
                                <td width="18%">
                                    <strong>提问时间</strong></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td background="images/Uy_bg2.jpg">
                        <asp:GridView ID="MyGridView1" runat="server" AutoGenerateColumns="False" Width="97%"
                            CssClass="mMT" HorizontalAlign="Center" ShowHeader="False" BorderWidth="0px"
                            GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="标题">
                                    <ItemTemplate>
                                        <a href='Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>' target="_blank"
                                            class="Linl14" title='<%#Eval("Title") %>'>
                                                         <%# Convert.ToBoolean(Eval("IsCommend")) ? "<font color='red'>[精]</font>" : "" %> ·<%#StrFormat.CutStringByNum(Eval("Title"),30*2)%>
                                        </a>
                                    </ItemTemplate>
                                    <ItemStyle Width="52%" Height="22px" BorderWidth="0px" HorizontalAlign="Left" />
                                    <ControlStyle CssClass="f14black list_xia2" />
                                    <HeaderStyle Width="52%" Height="27px" CssClass="tdBackground" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="回答数">
                                    <ItemTemplate>
                                        <%#Eval("Replys")%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" BorderWidth="0px" />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle Width="10%" Height="27px" CssClass="tdBackground" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <img src='images/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                        BorderWidth="0px" />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle Height="27px" Width="10%" CssClass="tdBackground" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="被采纳">
                                    <ItemTemplate>
                                        <%# FormatIsBest(Eval("Id"))%>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" HorizontalAlign="Center" CssClass="list_xia2" BorderWidth="0px" />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle Width="10%" Height="27px" CssClass="tdBackground" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="提问时间">
                                    <ItemTemplate>
                                        <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                    </ItemTemplate>
                                    <ItemStyle Width="18%" CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                    <ControlStyle CssClass="list_xia2" />
                                    <HeaderStyle Width="18%" Height="27px" CssClass="tdBackground" HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                            OnPageChanged="AspNetPager2_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                            ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/Uy_bg3.jpg" width="970" height="5" /></td>
                </tr>
            </table>
            <asp:Label ID="litContent1" runat="server"></asp:Label>
        </div>
        <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
