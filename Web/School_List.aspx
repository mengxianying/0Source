<%@ Page Language="C#" AutoEventWireup="true" Codebehind="School_List.aspx.cs" Inherits="Pbzx.Web.School_List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="/Contorls/UcJsADs.ascx" TagName="UcJsADs" TagPrefix="uc7" %>
<%@ Register Src="/Contorls/UcPicAds.ascx" TagName="UcPicAds" TagPrefix="uc6" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>软件学院内容列表_拼搏在线彩神通软件</title>
    <meta name="keywords" content="彩票知识,软件方法" />
    <meta name="description" content="彩票知识软件方法" />
   <meta name="robots" content="all" />
   <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/school.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="xin" class="C_c2">
            <div class="title">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="4%">
                        <img src="Images/Web/school_wei.jpg"  border="0"/>
                        </td>
                        <td width="96%">
                            <div id="spPosition" style="font-size: 12px;">
                                当前位置：<a href='#' onclick="top.location='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>';"
                                    class="school">拼博在线彩神通软件</a> >> <a href='School_List.aspx' class="school">软件学院</a><asp:Label
                                        ID="lblType" runat="server" Text=""></asp:Label></div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="content">
                <div>
                    <asp:Repeater ID="RptList" runat="server">
                        <HeaderTemplate>
                            <table width="95%" border="0" cellpadding="1" cellspacing="0" align="center">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td width="88%" align="left" class="C_xia">
                                    ·<a href="<%# Eval("SavePath") %>" class="schoollink" target="_blank"><%# Pbzx.Common.StrFormat.CutStringByNum(Eval("NvarTitle"), 70)%></a></td>
                                <td width="12%" align="left" class="C_xia">
                                    <%#Eval("DatDateAndTime", "{0:yyyy-MM-dd}")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Label ID="litContent" runat="server"></asp:Label>
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1">
                        <tr>
                            <td height="25" align="center">
                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                    FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" NumericButtonCount="3"
                                    OnPageChanged="AspNetPager1_PageChanged" PrevPageText="上一页" ShowCustomInfoSection="Right"
                                    ShowInputBox="Always" ShowNavigationToolTip="True" Width="100%" BackColor="Transparent"
                                    CustomInfoStyle='vertical-align:middle;' CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                                </webdiyer:AspNetPager>
                            </td>
                        </tr>
                    </table>
                </div>
                    <uc6:UcPicAds id="UcPicAdsRight1" runat="server" PlaceType="软件学院首页中一">
                    </uc6:UcPicAds>
                    <uc7:UcJsADs id="UcJsADsRight1" runat="server" PlaceType="软件学院首页中一JS">
                    </uc7:UcJsADs>
            </div>
        </div>
    </form>
</body>
</html>
