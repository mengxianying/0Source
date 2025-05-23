<%@ Page Language="C#" AutoEventWireup="true" Codebehind="rightFrom.aspx.cs" Inherits="Pinble_Market.rightFrom" %>

<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩票超市条件</title>
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache,  must-revalidate" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="stylesheet" type="text/css" href="Css/input.css" />
    <link type="text/css" rel="stylesheet" href="Css/soft.css" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
        <div id="wrap">
            <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="关键字：彩种、条件名称、收费、免费" autocomplete="off" />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/ieaarchBtn.gif" OnClick="ImageButton1_Click" />
                                (说明：关键字：彩种、条件名称、收费、免费)
                            </div>
                            <div class="keyword">
                                <img src="image/hot.gif" width="22" height="10" alt="" />
                                <span id="super_list" style="color: #FF0000">说明： (选择条件购买，购买的单个条件每一期都有商户发布的不同的条件内容可以查看。免费的条件可以直接查看)
                                </span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            
            <div id="focus" style="height: 520px;">
                <!-- focus begin-->
                <div id="tag_contain">
                    <div id="nav">
                        <ul>
                            <li class="tag_label_on" id="mynav0" onclick="javascript:qiehuan(0)" style="border-left-width: 0px">
                                3D</li>
                            <li class="tag_label" onclick="javascript:qiehuan(1)" id="mynav1">双色球</li>
                            <li class="tag_label" onclick="javascript:qiehuan(2)" id="mynav2">七星彩</li>
                            <li class="tag_label" onclick="javascript:qiehuan(3)" id="mynav3">大乐透</li>
                            <li class="tag_label" onclick="javascript:qiehuan(4)" id="mynav4">排列三</li>
                            <li class="tag_label" onclick="javascript:qiehuan(5)" id="mynav5">排列五</li>
                            <li class="tag_label" onclick="javascript:qiehuan(6)" id="mynav6">22选5</li>
                            <li class="tag_label" onclick="javascript:qiehuan(7)" id="mynav7">七乐彩</li>
                        </ul>
                    </div>
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                    <div class="Content_pd">
                        <div id="qh_con0" style="display: block">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="Item3D" runat="server" OnItemDataBound="Item3D_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            期号
                                                        </td>
                                                       <td class="f_1 form_title">
                                                            上期内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr class="form1" style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("3D") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_num" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_gut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_odds" runat="server"><img src="image/gold.gif" alt=""/><img src="image/gold.gif"  alt=""/><img src="image/gold.gif" alt="" /><img src="image/silver.gif" alt=""/> </asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lab_price" runat="server"><%# Eval("Price").ToString().Split('.')[0] %>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("3D") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buy" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buy_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_Attention" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_Attention_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_Collection" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_Collection_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="litContent" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con1" style="display: none;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemSeq" runat="server" OnItemDataBound="ItemSeq_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr height="24" class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager2.CurrentPageIndex - 1) * AspNetPager2.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("双色球") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_seqnum" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_seqgut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_seqPrice" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("双色球") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buySeq" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buySeq_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionSeq" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionSeq_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionSeq" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionSeq_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="lab_seq" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager2" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager2_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con2" style="display: none">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemQxc" runat="server" OnItemDataBound="ItemQxc_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr height="24" class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                       <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager3.CurrentPageIndex - 1) * AspNetPager3.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("七星彩") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_qxcnum" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_qxcgut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_QxcPrice" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("七星彩") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buyQxc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buyQxc_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionQxc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionQxc_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionQxc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionQxc_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="labQxc" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager3" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager3_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con3" style="display: none">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemDlt" runat="server" OnItemDataBound="ItemDlt_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr height="24" class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                       <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager4.CurrentPageIndex - 1) * AspNetPager4.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("大乐透") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_dltnum" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_dltgut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_DltPrice" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("大乐透") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buyDlt" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buyDlt_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionDlt" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionDlt_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionDlt" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionDlt_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="labDlt" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager4" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager4_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con4" style="display: none">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemPl3" runat="server" OnItemDataBound="ItemPl3_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#dbf0f7"%>'>
                                                        <td>
                                                            <%--<%# (Container.ItemIndex + 1) + (AspNetPager5.CurrentPageIndex - 1) * AspNetPager5.PageSize%>--%>
                                                            <%# Container.ItemIndex+1 %>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("排列3") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_pl3num" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_pl3gut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_Pl3Price" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("排列三") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buyPl3" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buyPl3_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionPl3" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionPl3_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionPl3" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionPl3_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <%--                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                                                                        <asp:Label ID="labPl3" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager5" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager5_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                                    </webdiyer:AspNetPager>
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con5" style="display: none;">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemPl5" runat="server" OnItemDataBound="ItemPl5_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager6.CurrentPageIndex - 1) * AspNetPager6.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("排列5") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_pl5num" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_pl5gut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_Pl5Price" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("排列五") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buyPl5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_buyPl5_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionPl5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionPl5_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionPl5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionPl5_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="labPl5" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager6" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager6_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con6" style="display: none">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="Item22x5" runat="server" OnItemDataBound="Item22x5_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr height="24" class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager7.CurrentPageIndex - 1) * AspNetPager7.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("排列5") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_22x5num" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_22x5gut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_22x5Price" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("22选5") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_22x5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_22x5_Command">购买 |</asp:LinkButton>
                                                            <%--<asp:LinkButton ID="Btn_Attention22x5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_Attention22x5_Command">关注 |</asp:LinkButton>--%>
                                                            <asp:LinkButton ID="Btn_Collection22x5" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionPl5_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="lab22x5" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager7" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager7_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="qh_con7" style="display: none">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7">
                                            <asp:Repeater ID="ItemQlc" runat="server" OnItemDataBound="ItemQlc_ItemDataBound">
                                                <HeaderTemplate>
                                                    <tr height="24" class="form">
                                                        <td class="f_1 form_title">
                                                            序号</td>
                                                        <td class="f_1 form_title">
                                                            条件</td>
                                                        <td class="f_1 form_title">
                                                            发布人</td>
                                                        <td class="f_1 form_title">
                                                            介绍</td>
                                                        <td class="f_1 form_title">
                                                            最新
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            内容
                                                        </td>
                                                        <td class="f_1 form_title">
                                                            好评</td>
                                                        <td class="f_1 form_title">
                                                            收费标准</td>
                                                        <td class="f_1 form_title">
                                                            历史</td>
                                                        <td class="f_1 form_title">
                                                            操作</td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                                        <td>
                                                            <%# (Container.ItemIndex + 1) + (AspNetPager8.CurrentPageIndex - 1) * AspNetPager8.PageSize%>
                                                        </td>
                                                        <td>
                                                            <a href='Condi.aspx?lott=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>&name=<%#Pbzx.Common.Input.Encrypt("七乐彩") %>'>
                                                                <%# Eval("TypeName")%>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                                                <%#Eval("UserId")%>
                                                            </a>
                                                        </td>
                                                        <td align="left">
                                                            <span title='<%#Eval("say") %>'>
                                                                <%#Pbzx.Common.Input.GetSubString(Eval("say").ToString(),20) %>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_qlcnum" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lab_qlcgut" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                                                src="image/silver.gif" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lab_QlcPrice" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                                                        </td>
                                                        <td>
                                                            <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt("七乐彩") %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                                        <td>
                                                            <asp:LinkButton ID="Btn_buyQlc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_BuyQlc_Command">购买 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_AttentionQlc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_AttentionQlc_Command">关注 |</asp:LinkButton>
                                                            <asp:LinkButton ID="Btn_CollectionQlc" runat="server" CommandArgument='<%# Eval("appendid") %>'
                                                                OnCommand="Btn_CollectionQlc_Commend">收藏</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" style="background-color: #FFFFFF;">
                                                    <asp:Label ID="labQlc" runat="server"></asp:Label>
                                                    <webdiyer:AspNetPager ID="AspNetPager8" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                                        FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager8_PageChanged"
                                                        PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                                        CustomInfoSectionWidth="35%" HorizontalAlign="Center" SubmitButtonClass="buttoncss"
                                                        InputBoxClass="asptext">
                                                    </webdiyer:AspNetPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
