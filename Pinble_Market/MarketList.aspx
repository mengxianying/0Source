<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MarketList.aspx.cs" Inherits="Pinble_Market.MarketList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>彩种项目列表</title>
    <link href="Css/index.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
.table_title{
		width:763px;
		height:25px;
		background-image:url(images/daohang.jpg);
		background-repeat:repeat-x;
		margin-top:2px;
		float:left;
		}


</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="biaoge">
            <div class="table_title">
                <div class="wenzi">
                    项目服务信息</div>
            </div>
            <table width="763" border="0" align="left" cellspacing="1" bgcolor="#97BEE7">
                <asp:Repeater ID="LotteryList" runat="server">
                    <HeaderTemplate>
                        <tr height="24">
                            <td >
                                序号</td>
                            <td >
                                彩种</td>
                            <td >
                                名称</td>
                            <td >
                                发布人</td>
                            <td >
                                收费标准</td>
                            <td >
                                最新预测</td>
                            <td >
                                查看历史</td>
                            <td >
                                简介</td>
                            <td >
                                操作</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr height="24">
                            <td >
                                <%# Container.ItemIndex+1 %>
                            </td>
                            <td >
                                <%# Eval("NvarName") %>
                            </td>
                            <td >
                                <%# Eval("NvarName") %><%# Eval("TypeName")%>
                            </td>
                            <td >
                                <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                    <%# Eval("UserName")%>
                                </a>
                            </td>
                            <td >
                                <%# Eval("Price")%>
                            </td>
                            <td >
                                最新</td>
                            <td >
                                历史简介</td>
                            <td >
                                简介</td>
                            <td >
<%--                                <a href='Market_buy.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("id").ToString()) %>&price=<%#Pbzx.Common.Input.Encrypt(Eval("Price").ToString()) %>&appendId=<%#Pbzx.Common.Input.Encrypt(Eval("appendid").ToString())%>'
                                    target="mainFrame">购买 </a>|关注--%>
                                    <asp:LinkButton ID="Btn_buy" runat="server" CommandArgument='<%# Eval("appendid") %>' OnCommand="Btn_buy_Command">购买 |</asp:LinkButton>
                                    <asp:LinkButton ID="Btn_Attention" runat="server" CommandArgument='<%# Eval("appendid") %>' OnCommand="Btn_Attention_Command">关注 |</asp:LinkButton>
                                   <asp:LinkButton ID="Btn_Collection"  runat="server" CommandArgument='<%# Eval("appendid") %>' OnCommand="Btn_Collection_Commend" >收藏</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:Label ID="litContent" runat="server"></asp:Label>
                <tr>
                    <td colspan="9" style="background-color: #FFFFFF;">
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
</body>
</html>
