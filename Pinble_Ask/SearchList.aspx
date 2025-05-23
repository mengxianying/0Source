<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchList.aspx.cs" Inherits="Pinble_Ask.SearchList" %>

<%@ Register Src="Contorls/UcMark.ascx" TagName="UcMark" TagPrefix="uc5" %>
<%@ Register Src="Contorls/UcSearch.ascx" TagName="UcSearch" TagPrefix="uc3" %>
<%@ Register Src="Contorls/Bulletin_r.ascx" TagName="Bulletin_r" TagPrefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="Contorls/UcAskFoot.ascx" TagName="UcAskFoot" TagPrefix="uc2" %>
<%@ Register Src="Contorls/UcAskHead.ascx" TagName="UcAskHead" TagPrefix="uc1" %>
<%@ Import Namespace="Pbzx.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>问题搜索_拼搏吧_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />    
    <link href="css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!---顶部--->
            <uc1:UcAskHead ID="UcAskHead1" runat="server" />
            <!---当前位置----->
            <div class="main">
                <div align="left">
                    <a href="Default.aspx" class="Link_Xia">拼搏吧</a> > 搜索结果
                </div>
            </div>
            <!---主体开始----->
            <div class="main">
                <!----左边开始---->
                <div class="Listl">
                    <div class="As_list_qiebg">
                        <%=myChange[0]%>
                        <%=myChange[1]%>
                        <%=myChange[2]%>
                    </div>
                    <asp:GridView ID="MyGridView" Width="99%" runat="server" AutoGenerateColumns="False"
                        BorderWidth="0px" ShowHeader="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="8">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href='Question.aspx?question=<%# Input.Encrypt(Eval("Id").ToString()) %>' target="_blank"
                                                    class="Linl14 Link_Xia">
                                                    <%#FormartTitle(Eval("Title"))%>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%#FormartContent(Eval("Content"))%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="f12gray">
                                                提问者：<%# Convert.ToBoolean(Eval("IsAnonymous")) ? "匿名" : "<a href='UserShow.aspx?name=" + Input.Encrypt(Eval("AskerId").ToString()) + "' target='_blank' class='Link_Xia'>" + Eval("Asker") + "</a>"%>
                                                <%#Eval("AskTime")%>
                                                <%# GetBestAnswer(Eval("AnswererId"), Eval("Answerer"))%>
                                                <%#GetNavigation(Eval("TypeID"))%>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                                <ItemStyle BorderWidth="0px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="litContent" runat="server"></asp:Label>
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td bgcolor="#83B5E2" style="height: 2px">
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                    ShowNavigationToolTip="True" Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                    CustomInfoSectionWidth="35%" HorizontalAlign="Center" CssClass="Link_Xia">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                    <table width="98%" border="0" align="center" cellpadding="4" cellspacing="0" bgcolor="#D7E4F5"
                        class="mMT">
                        <tr>
                            <td>
                                <uc3:UcSearch ID="UcSearch1" runat="server"></uc3:UcSearch>
                            </td>
                        </tr>
                    </table>
                </div>
                <!----中间开始---->
                <!----右边开始---->
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
                        <uc4:Bulletin_r ID="Bulletin_r1" runat="server" Count="8" TitleLength="18" ClassCss="Linl12Green"
                            IntChannelID="13"></uc4:Bulletin_r>
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
                        <img src="images/A_list_rbg6.jpg" /></div>
                </div>
            </div>
            <!---版权开始----->
            <uc2:UcAskFoot ID="UcAskFoot1" runat="server" />
        </div>
    </form>
</body>
<!-- <script src="/javascript/kf/PinbleService.js"></script> -->
</html>
