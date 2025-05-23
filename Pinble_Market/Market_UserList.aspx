<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Market_UserList.aspx.cs"
    Inherits="Pinble_Market.Market_UserList" %>

<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>

<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>彩种项目列表</title>
    <link rel="stylesheet" href="Css/head.css" type="text/css" />
    <style type="text/css">
.img {
	border: 1px solid #CCCCCC;
	padding: 2px;
	width: 158px;
	margin-top: 5px;
	margin-right: 5px;
	margin-bottom: 5px;
	margin-left: 5px;
}
.td_line{
	border-bottom-width: 1px;
	border-bottom-style: dashed;
	border-bottom-color: #999999;
	text-align: left;
	color: #0D3257;
	font-weight: normal;
	font-size:16px;
}


.table_title1{
	width:99%;
	background-repeat:repeat-x;
	border: 1px solid #c0c0c0;
	margin-bottom: 2px;
	margin-top:10px;
}


</style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="Head2" runat="server" />
        <div id="wrap">
            <div class="table_title1 " >
                <table width="99%" border="0">
                    <tr>
                        <td width="195" rowspan="4">
                            <img src="image/logo.jpg" width="158" height="72" /></td>
                        <td class="td_line">
                            商户名称：
                            <asp:Label ID="Lab_Name" runat="server" ForeColor="red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;<asp:ImageButton ID="Img_Btn_coll" runat="server" ImageUrl="~/image/shoucang.jpg" OnClick="Img_Btn_coll_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="Img_Btn_attention" runat="server" ImageUrl="~/image/guanzhu.jpg" OnClick="Img_Btn_attention_Click" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="td_line">
                            商户已被&nbsp;&nbsp;<font color="red"><asp:Label ID="Lab_CollNum" runat="server"></asp:Label></font>&nbsp;
                            人收藏 &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;发布项目个数： <font color="red">
                                <asp:Label ID="Lab_Num" runat="server"></asp:Label>
                            </font>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_line">
                            已有&nbsp; &nbsp;<font color="red" font-size="14"><asp:Label ID="Lab_peopNum" runat="server"></asp:Label>
                            </font>人购买  &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;被关注次数： 
                            <font color="red"><asp:Label ID="lab_attNum" runat="server"></asp:Label></font>次
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 99%; margin-bottom:5px; margin-top:5px;">
                <table width="100%" border="0" align="left" cellspacing="1" bgcolor="#97BEE7">
                    <asp:Repeater ID="LotteryList" runat="server" OnItemDataBound="LotteryList_ItemDataBound">
                        <HeaderTemplate>
                            <tr class="form">
                                <td >
                                    序号</td>
                                <td >
                                    彩种</td>
                                <td >
                                    名称</td>
                                <td >
                                    收费标准</td>
                                <td >
                                    最新</td>
                                <td >
                                    最新预测</td>
                                <td >
                                    历史</td>
                                <td >
                                    操作</td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#daeff6"%>'>
                                <td >
                                    <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                                </td>
                                <td >
                                    
                                <a href='Condi.aspx?name=<%#Pbzx.Common.Input.Encrypt(Eval("NvarName").ToString()) %>&lott=<%# Pbzx.Common.Input.Encrypt("0")%>'><%# Eval("NvarName") %></a>
                                </td>
                                <td>
                                   <a href='ConditionStor.aspx?name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>'><%# Eval("TypeName")%></a>
                                </td>
                                <td >
                                    <asp:Label ID="lab_price" runat="server"><%# Eval("Price")%>/月</asp:Label>
                                </td>
                                <td >
                                    <asp:Label ID="lab_new" runat="server"></asp:Label></td>
                                <td align="left" >
                                    <asp:Label ID="lab_newGut" runat="server"></asp:Label></td>
                                <td >
                                   <a href='History.aspx?lottery=<%#Pbzx.Common.Input.Encrypt(Eval("NvarName").ToString()) %>&name=<%# Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString()) %>&user=<%#Pbzx.Common.Input.Encrypt(Eval("UserId").ToString())  %>'
                                                                target="_blank">查看</a></td>
                                <td >
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
                    <asp:Label ID="litContent" runat="server"></asp:Label><tr>
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
           
        </div> 
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
