<%@ Page Language="C#" AutoEventWireup="true" Codebehind="History.aspx.cs" Inherits="Pinble_Market.History" %>

<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查看历史</title>
    <style type="text/css">
       #wq {   
 BACKGROUND: #ffffff; WIDTH: expression(this.offsetParent.clientWidth<800?"800px":"1024px"); min-width: 800px; overflow:hidden;  
}
    </style>
</head>
<body style="text-align: center;">
    <div id="wq" >
        
        <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="newtable" style="margin-top: 5px;
                margin-bottom: 5px;">
                <tr>
                    <td class="tdr" align="center">
                        <span class="newblue">彩种：<a href='/Condi.aspx?name=<%= NvarName %>&lott=<%# Pbzx.Common.Input.Encrypt("0") %> '><asp:Label ID="lab_NvarName" runat="server"></asp:Label></a> </span>
                        <span class="newblue">条件：<asp:Label ID="lab_TypeName" runat="server"></asp:Label>
                        </span><span class="newblue">费用：<asp:Label ID="lab_price" runat="server"></asp:Label></span>
                        <span class="newblue">发布会员：<asp:Label ID="lab_username" runat="server"></asp:Label></span>
                        <span class="newbtn">
                            <asp:LinkButton ID="Btn_buy" runat="server" OnCommand="Btn_buy_Command">购买 |</asp:LinkButton>
                        </span><span class="newbtn">
                            <asp:LinkButton ID="Btn_Attention" runat="server" OnCommand="Btn_Attention_Command">关注 |</asp:LinkButton></span>
                        <span class="newbtn">
                            <asp:LinkButton ID="Btn_Collection" runat="server" OnCommand="Btn_Collection_Commend">收藏</asp:LinkButton>
                        </span>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="1" bgcolor="#97BEE7" style="margin-bottom:5px">
                <asp:Repeater ID="myGridView" runat="server" OnItemDataBound="myGridView_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="form">
                            <td>
                                序号</td>
                            <td>
                                名称</td>
                            <td>
                                期号
                            </td>
                            <td>
                                条件内容
                            </td>
<%--                            <td>
                                发布人</td>--%>
                            <td>
                                好评率</td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                            <td>
                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                            </td>
                            <td align="left">
                                <a href="/ConditionStor.aspx?name=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>" target="_blank"><%# Eval("TypeName")%></a>
                                <%# Eval("itemradio") %>
                            </td>
                            <td>
                                <%# Eval("ExpectNum")%>
                            </td>
                            <td align="left">
                                <asp:Label ID="lab_viscera" runat="server"></asp:Label>
                            </td>
<%--                            <td>
                                <a href='Market_UserList.aspx?id=<%#Pbzx.Common.Input.Encrypt(Eval("userid").ToString()) %>'>
                                    <%#Eval("UserId")%>
                                </a>
                            </td>--%>
                            <td>
                                <img src="image/gold.gif" /><img src="image/gold.gif" /><img src="image/gold.gif" /><img
                                    src="image/silver.gif" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="8" style="background-color: #FFFFFF;">
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
            <uc2:MakFooter ID="MakFooter1" runat="server" />
        </form>
        
    </div>
</body>
</html>
