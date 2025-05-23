<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChippedName.aspx.cs" Inherits="Pinble_Chipped.admin.ChippedName" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>合买详情</title>
        <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />   
    <style>
    body {
	font-family: "宋体";
	margin: 0px;
	padding: 12px;
	font-size: 12px;
	font-style: normal;
	line-height: 170%;
	font-weight: normal;
	color: #000000;
	background-color: #AFDAF0;
	overflow:scroll;
	overflow-x:hidden;
}
    </style>

    <script src="../js/GridView.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0" style="width: 728px" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 69px; height: 36px">
                        <strong>方案号：</strong>
                    </td>
                    <td style="width: 227px; height: 36px">
                        &nbsp;<asp:Label ID="lblQNumber" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 36px">
                        <strong>方案金额：</strong></td>
                    <td style="width: 110px; height: 36px">
                        ￥<asp:Label ID="lblAtotalMoney" runat="server" Text="Label"></asp:Label>元</td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 34px;">
                        <strong>发布人：</strong></td>
                    <td style="width: 227px; height: 34px;">
                        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 34px;">
                        <strong>份数：</strong></td>
                    <td style="width: 110px; height: 34px;">
                        <asp:Label ID="lblShare" runat="server" Text="Label"></asp:Label>
                        份</td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 30px;">
                        <strong>发布时间：</strong></td>
                    <td style="width: 227px; height: 30px;">
                        <asp:Label ID="lblLaunchTime" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 30px;">
                        <strong>认购份数：</strong></td>
                    <td style="width: 110px; height: 30px;">
                        <asp:Label ID="lblBuyShare" runat="server" Text="Label"></asp:Label>
                        份</td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 31px;">
                        <strong>彩种： </strong>
                    </td>
                    <td style="width: 227px; height: 31px;">
                        <asp:Label ID="lbllottName" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 31px;">
                        <strong>保底：</strong></td>
                    <td style="width: 110px; height: 31px;">
                        <asp:Label ID="lblProtect" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 32px;">
                        <strong>期号：</strong></td>
                    <td style="width: 227px; height: 32px;">
                        <asp:Label ID="lblExpectNum" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 32px;">
                        <strong>状态：</strong></td>
                    <td style="width: 110px; height: 32px;">
                        <asp:Label ID="labState" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 32px;">
                        <strong>方案标题：</strong></td>
                    <td style="width: 227px; height: 32px;">
                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 32px;">
                    </td>
                    <td style="width: 110px; height: 32px;">
                    </td>
                </tr>
                <tr>
                    <td style="width: 69px; height: 84px;">
                        <strong>方案内容：</strong></td>
                    <td style="width: 227px; height: 84px;">
                        <asp:Label ID="lblChoiceNum" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 73px; height: 84px;">
                    </td>
                    <td style="width: 110px; height: 84px;">
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="MyGridView" runat="server" AutoGenerateColumns="False" OnRowCreated="myGridView_RowCreated"
            OnRowDataBound="myGridView_RowDataBound" Width="407px">
            <FooterStyle CssClass="GridView_Footer" />
            <Columns>
                <asp:BoundField HeaderText="序号" />
                <asp:TemplateField HeaderText="合买人">
                    <ItemTemplate>
                        <%# Eval("ChippedName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="认购份数">
                    <ItemTemplate>
                        <%# Eval("ChippedShare")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="合买时间">
                    <ItemTemplate>
                        <%# Eval("ChippedTime") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="GridView_Pager" />
            <HeaderStyle CssClass="GridView_Header" Font-Bold="True" />
            <AlternatingRowStyle CssClass="GridView_AlternatingRow" />
            <RowStyle CssClass="GridView_Row" />
            <PagerSettings Mode="NumericFirstLast" Visible="False" />
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td style="height: 48px">
                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoTextAlign="Center"
                        FirstPageText="首页" LastPageText="尾页" NextPageText="下页" OnPageChanged="AspNetPager1_PageChanged"
                        PrevPageText="上页" ShowCustomInfoSection="Right" ShowInputBox="Always" ShowNavigationToolTip="True"
                        Width="100%" BackColor="Transparent" CustomInfoStyle='vertical-align:middle;'
                        class="pagestyle" CustomInfoSectionWidth="35%" HorizontalAlign="Center" PageSize="20">
                    </webdiyer:AspNetPager>
                    <asp:Literal ID="litContent" runat="server"></asp:Literal></td>
            </tr>
        </table>
    </form>
</body>
</html>
