<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Collention_user.aspx.cs"
    Inherits="Pinble_Market.admin.Collention_user" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>收藏用户</title>
    <link type="text/css" rel="stylesheet" href="../Css/head.css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <uc1:head ID="Head2" runat="server" />
        <div id="wrap" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="Title">
                <div class="return_title">
                    商户收藏</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
                BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True"
                OnRowDeleting="myGridView_RowDeleting">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <FooterStyle CssClass="GridView_Footer" />
                <Columns>
                    <asp:TemplateField HeaderText="商户名称">
                        <ItemTemplate>
                            <%# Eval("appName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="收藏时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("appTime")).Substring(0, 10) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="关注">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lb_Btn_Attention" runat="server">关注</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                </Columns>
                <HeaderStyle Font-Bold="True" CssClass="form" />
            </asp:GridView>
            <table cellpadding="0" cellspacing="0" border="0" width="98%">
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
        <uc2:MakFooter ID="MakFooter1" runat="server" />
    </form>
</body>
</html>
