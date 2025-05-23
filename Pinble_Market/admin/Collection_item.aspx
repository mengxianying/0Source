<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Collection_item.aspx.cs"
    Inherits="Pinble_Market.admin.Collection_item" %>

<%@ Register Src="../Contorls/MakFooter.ascx" TagName="MakFooter" TagPrefix="uc2" %>
<%@ Register Src="../Contorls/head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>收藏项目</title>
    <meta http-equiv="pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache,  must-revalidate">
    <meta http-equiv="expires" content="0">
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link href="../Css/head.css" rel="stylesheet" type="text/css" />
    <link href="../Css/title.css" rel="Stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/GridView.js"></script>

</head>
<body onload="GridViewColor();">
    <form id="form1" runat="server">
        <uc1:head ID="Head1" runat="server" />
        <div id="wrap" style="margin-top: 10px; margin-bottom: 10px;">
            <div class="Title">
                <div class="return_title">
                    项目收藏</div>
                <div class="return_re">
                    <a href="javascript:history.go(-1);">返回上一页</a>
                </div>
            </div>
            <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="False" CellPadding="3"
                BackColor="#97BEE7" CellSpacing="1" GridLines="None" Width="99%" AllowPaging="True"
                OnRowDataBound="myGridView_RowDataBound" OnRowDeleting="myGridView_RowDeleting">
                <PagerSettings Mode="NumericFirstLast" Visible="False" />
                <Columns>
                    <asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>
                            <asp:Label ID="Lab_ItemName" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="收藏时间">
                        <ItemTemplate>
                            <%# string.Format("{0:u}", Eval("appTime")).Substring(0, 10) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="关注">
                        <ItemTemplate>
                            <asp:LinkButton ID="Lb_Btn_Attention" runat="server" OnCommand="Lb_Btn_Attention_Command">关注</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="购买">
                        <ItemTemplate>
                           <asp:LinkButton ID="lbtn_buy" runat="server" CommandArgument='<%# Eval("appName") %>' OnCommand="lbtn_buy_Command">购买</asp:LinkButton>
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
