<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BuyLog.aspx.cs" Inherits="Pinble_Market.admin.BuyLog" %>

<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商户出售记录</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
    <link href="../Css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../Css/demos.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
        <div id="wrap">
        <div class="Title">
                <div class="return_title">
                    用户 <font color='red'>
                        <%= Pbzx.Common.Method.Get_UserName.ToString() %>
                    </font> 售出记录</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
        <table width="99%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 10px">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="关键字：会员名、价格、条件" />
                                <asp:ImageButton ID="Ibtn_scout" runat="server"  ImageUrl="../image/ieaarchBtn.gif" CssClass="isearchBtn" OnClick="Ibtn_scout_Click"/>
                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                根据时间段搜索：开始时间
                                <input id="Text1" type="text" />
                                结束时间 
                                <input id="Text2" type="text" /> <img alt="" src="../image/ieaarchBtn.gif" class="isearchBtn" />
                                &nbsp;
                            </div>
                            <div class="keyword">
                                <img src="../image/hot.gif" width="22" height="10" />
                                <span id="super_list" style="color: #FF0000">说明： (出售条件的历史记录，查看具体哪些会员购买了条件。)
                                </span>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7" style="margin-top: 10px;
                margin-bottom: 10px; text-align: center">
                <asp:Repeater ID="MyRep_buyLog" runat="server" OnItemDataBound="MyRep_buyLog_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="form">
                            <td>
                                彩种
                            </td>
                            <td>
                                条件名称
                            </td>
                            <td>
                                价格
                            </td>
                            <td>
                                购买用户
                            </td>
                            <td>
                                到期时间
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                 <asp:Label ID="lab_NvarName" runat="server">     </asp:Label>
                            </td>
                            <td>
                               <%# Eval("LotteryType")%>
                            </td>
                            <td>
                                <%# Eval("Price") %>
                            </td>
                            <td>
                                <%# Eval("buyUserId") %>
                            </td>
                            <td>
                                <%#Convert.ToDateTime(Eval("EndTime")).ToString("yyyy-MM-dd") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="5" style="background-color: #FFFFFF;">
                        <asp:Label ID="litContent" runat="server"></asp:Label>
                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                            FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" OnPageChanged="AspNetPager1_PageChanged"
                            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                            Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
