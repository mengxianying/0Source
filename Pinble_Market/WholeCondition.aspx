<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WholeCondition.aspx.cs"
    Inherits="Pinble_Market.WholeCondition" %>

<%@ Register Src="Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="Css/title.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
        <div id="wrap">
            <div class="Title">
                <div class="return_title">
                    条件列表</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回</a>
                </div>
            </div>
            <table width="99%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left" valign="top">
                        <div class="isearch">
                            <div class="bg">
                                搜索：
                                <input id="susername" name="username" type="text" class="n" title="请输入会员名或条件名查询" autocomplete="off" />
                                <asp:ImageButton ID="Ibtn_img" runat="server" ImageUrl="image/ieaarchBtn.gif" OnClick="Ibtn_img_Click" />
                                (说明：输入彩种和条件的名称查询)
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <table width="99%" border="0" cellspacing="1" bgcolor="#97BEE7" style="margin-top: 10px;
                margin-bottom: 10px">
                <asp:Repeater ID="MyRep" runat="server" OnItemDataBound="MyRep_ItemDataBound">
                    <HeaderTemplate>
                        <tr class="form">
                            <td>
                                序号</td>
                            <td>
                                彩种</td>
                            <td>
                                条件</td>
                            <td>
                                推荐
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style='background-color: <%#(Container.ItemIndex%2==0) ? "#FFFFFF":"#E2F0F5"%>'>
                            <td>
                                <%# (Container.ItemIndex + 1) + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize%>
                            </td>
                            <td>
                                <asp:LinkButton ID="lab_NvarName" runat="server" OnCommand="lab_NvarName_Command"></asp:LinkButton>
                            </td>
                            <td>
                                <a href="ConditionStor.aspx?name=<%#Pbzx.Common.Input.Encrypt(Eval("TypeName").ToString())%>"
                                    target="mainFrame">
                                    <%# Eval("TypeName")%>
                                </a>
                            </td>
                            <td>
                                <font color="red">推荐</font>
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
