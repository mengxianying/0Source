<%@ Page Language="C#" AutoEventWireup="true" Codebehind="QuestionList.aspx.cs" Inherits="Pinble_Ask.QuestionList1" %>

<%@ Register Src="Contorls/UcMark.ascx" TagName="UcMark" TagPrefix="uc5" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc4" %>
<%@ Register Src="Contorls/UcSearch.ascx" TagName="UcSearch" TagPrefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Import Namespace="Pbzx.Common" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>问题列表_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/demos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <uc1:UcAskHead ID="UcAskHead1" runat="server" />
            <div class="main">
                <div align="left">
                    <div class="Link_Xia">
                        <asp:Label ID="lblLink" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <div class="main">
                <div class="Listl">
                    <div class="class_title">
                        <%=fTypeName %>
                    </div>
                    <div class="class_content">
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">
                                    <asp:DataList ID="dlTypes" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            ·<%# GetTypeInfo(Eval("Id"), Eval("TypeName"))%>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="f14black" />
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <img alt="" src="/images/A_list_classbg3.jpg" /></td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mMT">
                                <tr>
                                    <td height="28" valign="bottom" background="/images/A_List_bg1.jpg">
                                        <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="70" align="center" valign="bottom" style="height: 22px">
                                                    <%=myChange[0] %>
                                                </td>
                                                <td width="15" style="height: 22px">
                                                    &nbsp;</td>
                                                <td width="70" align="center" valign="bottom" style="height: 22px">
                                                    <%=myChange[1] %>
                                                </td>
                                                <td width="15" style="height: 22px">
                                                    &nbsp;</td>
                                                <td width="70" align="center" valign="bottom" style="height: 22px">
                                                    <%=myChange[2] %>
                                                </td>
                                                <td width="15" style="height: 22px">
                                                    &nbsp;</td>
                                                <td width="70" align="center" valign="bottom" style="height: 22px">
                                                    <%=myChange[3] %>
                                                </td>
                                                <td width="15" style="height: 22px">
                                                    &nbsp;</td>
                                                <td width="70" align="center" valign="bottom" style="height: 22px">
                                                    <%=myChange[4] %>
                                                </td>
                                                <td width="291" style="height: 22px">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td background="/images/A_list_classbg2.jpg">
                                        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" Width="95%"
                                            CssClass="mMT" HorizontalAlign="Center" BorderWidth="0px" GridLines="None">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&amp;nbsp;标题">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        <img alt="" src="/images/icn_ps.gif" width="12" height="11" /><span title='悬赏<%#Eval("LargessPoint") %>积分'><%#Eval("LargessPoint") %></span>
                                                        <a href='Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>' target="_blank"
                                                            class="Linl14" title='<%#Eval("Title") %>'>
                                                         <%# Convert.ToBoolean(Eval("IsCommend")) ? "<font color='red'>[精]</font>" : "" %>   <%#StrFormat.CutStringByNum(Eval("Title"),23*2)%>
                                                        </a>[<span class="f14gray"><a href='QuestionList.aspx?type=<%# Input.Encrypt(Eval("TypeID").ToString()) %>'
                                                            target="_self"><%#Eval("TypeName") %></a></span>]
                                                    </ItemTemplate>
                                                    <ItemStyle Width="62%" Height="22px" CssClass="list_xia2" BorderWidth="0px" />
                                                    <ControlStyle CssClass="f14black list_xia2" />
                                                    <HeaderStyle CssClass="list_xia2" BorderWidth="0px" HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="回答数">
                                                    <ItemTemplate>
                                                        <%#Eval("Replys")%>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="11%" HorizontalAlign="Center" CssClass="list_xia2" BorderWidth="0px" />
                                                    <ControlStyle CssClass="list_xia2" />
                                                    <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="状态">
                                                    <ItemTemplate>
                                                        <img src='images/State_<%#Eval("State") %>.gif' width="16" height="16" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="9%" HorizontalAlign="Center" CssClass="list_xia2" Font-Bold="True"
                                                        BorderWidth="0px" />
                                                    <ControlStyle CssClass="list_xia2" />
                                                    <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="提问时间">
                                                    <ItemTemplate>
                                                        <%# Eval("AskTime","{0:yyyy-MM-dd HH:mm:ss}") %>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="18%" CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                    <ControlStyle CssClass="list_xia2" />
                                                    <HeaderStyle CssClass="list_xia2" HorizontalAlign="Center" BorderWidth="0px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="litContent" runat="server"></asp:Label>
                                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td bgcolor="#83B5E2" style="height: 2px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" height="27" valign="bottom">
                                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                                        OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                                        ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img alt="" src="images/A_list_classbg3.jpg" width="730" height="7" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="mMT">
                        <tr>
                            <td style="height: 7px">
                                <img alt="" src="/images/A_List_bg2.jpg" width="730" height="7" /></td>
                        </tr>
                        <tr>
                            <td background="/images/A_list_classbg2.jpg">
                                <uc3:UcSearch ID="UcSearch1" runat="server"></uc3:UcSearch>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="/images/A_list_classbg3.jpg" width="730" height="7" /></td>
                        </tr>
                    </table>
                </div>
                <div class="mr">
                    <div class="Listr_title">
                        <table width="93%" cellpadding="0" cellspacing="0" border="0" align="center">
                            <tr>
                                <td style="width: 40%">
                                    &nbsp;<font color="#E57B01"><b>最新公告</b></font>
                                </td>
                                <td style="width: 60%" align="right">
                                    <a href="/Bulletin_Ask.aspx" target="_blank"><font color="#E57B01">更多>></font></a>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Listr_content">
                        <uc4:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" TitleLength="18" 
                            ClassCss="Linl12Green" IntChannelID="13"></uc4:Bulletin_r>
                    </div>
                    <div>
                        <img src="images/A_list_rbg3.jpg" /></div>
                    <div class="Listr2_title mMT">
                        <table width="93%" cellpadding="0" cellspacing="0" border="0" align="center">
                            <tr>
                                <td style="width: 40%">
                                    <font color="#003399"><b>积分排行榜</b></font>
                                </td>
                                <td style="width: 60%" align="right">
                                    <a href="TopScore.aspx" target="_blank">更多>></a>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="Listr2_content">
                        <uc5:UcMark ID="UcMark1" runat="server" />
                    </div>
                    <div>
                        <img alt="" src="images/A_list_rbg6.jpg" /></div>
                </div>
            </div>
            <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
