<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Stat.aspx.cs" Inherits="Pinble_Market.admin.Stat" %>

<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商户统计</title>
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <uc1:head ID="Head1" runat="server" />
        <div id="wrap">
            <div class="Title">
                <div class="return_title">
                  商户 <font color='red'>
                        <%= Pbzx.Common.Method.Get_UserName.ToString() %> </font> 销售统计</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <table border="0" cellspacing="1" style="text-align: center; width: 99%; margin-top: 10px;
                margin-bottom: 10px;">
                <tr>
                    <td>
                        总出售项目：<font color='red'><asp:Label ID="lab_FullItem" runat="server">0</asp:Label></font>
                        个
                    </td>
                    <td>
                        总收入：<font color='red'><asp:Label ID="lab_earning" runat="server">0</asp:Label></font>
                        金币
                    </td>
                    <td>
                        本月出售条件：<font color='red'>
                            <asp:Label ID="lab_NonceItem" runat="server" Text="Label"></asp:Label></font>
                        个
                    </td>
                    <td>
                        本月收入：<font color='red'><asp:Label ID="lab_NonceMonth" runat="server">0</asp:Label>
                        </font>金币
                    </td>
                </tr>
            </table>
            <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7" style="margin-top: 10px;
                margin-bottom: 10px;">
                <asp:Repeater ID="My_rep" runat="server" OnItemDataBound="My_rep_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="form">
                            <td>
                                条件名称
                            </td>
                            <td>
                                价格
                            </td>
                            <td>
                                总订购人数
                            </td>
                            <td>
                                共售出价格
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                <%# Eval("NvarName") %>
                                <%# Eval("TypeName")%>
                            </td>
                            <td>
                                <%#  Eval("Price")%>
                            </td>
                            <td>
                                <asp:Label ID="lab_HumanNum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lab_FullPricer" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="4" style="background-color: #FFFFFF;">
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
