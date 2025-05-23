<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Attention.aspx.cs" Inherits="Pinble_Market.admin.Attention" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>关注项目</title>
    <link type="text/css" rel="stylesheet" href="../Css/head.css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <uc1:head ID="Head2" runat="server" />
        <div id="wrap">
            <div class="Title">
                <div class="return_title">
                   关注的项目</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <div style="margin-bottom: 10px; margin-top: 10px;">
<%--                <a href="Attention.aspx">关注的项目</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a
                    href="Attention_User.aspx">关注的商户</a>--%>
                <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
                    BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True"
                    OnRowDeleting="myGridView_RowDeleting" OnRowDataBound="myGridView_RowDataBound"
                    Style="text-align: center;">
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <Columns>
                        <asp:TemplateField HeaderText="项目名称">
                            <ItemTemplate>
                                <asp:Label ID="Lab_ItemName" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="添加时间">
                            <ItemTemplate>
                                <%# string.Format("{0:u}", Eval("appTime")).Substring(0, 10) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最新">
                            <ItemTemplate>
                                <asp:Label ID="lab_Num" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="购买">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_buy" runat="server" OnCommand="lbtn_buy_Command">购买</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="加入收藏">
                            <ItemTemplate>
                                <asp:LinkButton ID="Lb_Btn_Collection" runat="server" OnCommand="Lb_Btn_Collection_Command">收藏</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle Font-Bold="True" CssClass="form" />
                </asp:GridView>
                
                <table cellpadding="0" cellspacing="0" border="0" width="94%" style="margin-bottom: 5px;
                    margin-top: 5px">
                    <tr>
                        <td>
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                                FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                                PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                                Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                                class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                            </webdiyer:AspNetPager>
                            <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
                    </tr>
                </table>
            </div>
        </div>
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
