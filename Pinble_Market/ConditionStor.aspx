<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ConditionStor.aspx.cs"
    Inherits="Pinble_Market.ConditionStor" %>

<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>项目条件列表</title>
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <uc1:head ID="Head1" runat="server" />
    <form id="form1" runat="server">
          <div id="wrap">
            <div class="Title">
                <div class="return_title">
                  条件列表</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7"  style="margin-top: 5px;
                margin-bottom: 5px;">
                <asp:Repeater ID="myGridView" runat="server" OnItemDataBound="myGridView_ItemDataBound">
                    <HeaderTemplate>
                        <tr height="24" class="form">
                            <td >
                                序号</td>
                            <td >
                                彩种</td>
                            <td >
                                条件</td>
                            <td>
                                最新
                            </td>
                            <td>
                                内容
                            </td>
                            <td >
                                发布人</td>
                            <td >
                                好评</td>
                            <td >
                                收费标准</td>
                            <td >
                                历史</td>
                            <td >
                                操作</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                            </td>
                            <td>
                                <%# Eval("NvarName") %>
                            </td>
                            <td align="left">
                                <%# Eval("TypeName")%>
                            </td>
                            <td>
                                <asp:Label ID="lab_num" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lab_gut" runat="server"></asp:Label>
                            </td>
                            <td>
                                <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                    <%#Eval("UserId")%>
                                </a>
                            </td>
                            <td>
                                <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                    src="image/silver.gif" />
                            </td>
                            <td>
                                <asp:Label ID="lab_price" runat="server"><%# Eval("Price").ToString().Split('.')[0]%>金币/月</asp:Label>
                            </td>
                            <td>
                                <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt(Eval("NvarName").ToString()) %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
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
                            CustomInfoSectionWidth="35%" HorizontalAlign="Center">
                        </webdiyer:AspNetPager>
                    </td>
                </tr>
            </table>
           
        </div>
    </form>
     <uc2:MakFooter ID="MakFooter1" runat="server" />
</body>
</html>
