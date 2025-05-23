<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProductPrice_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.ProductPrice_Editor" %>

<html  xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品价格</title>
    <link type="text/css" rel="stylesheet" href="stylecss/Admin-darkgreen.css" />

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellpadding="0" cellspacing="0" border="0" class="Manage_Table" style="top: 20px;
                width: 100%;">
                <tr>
                    <td colspan="2" class="Manage_Header" style="height: 30px">
                        <asp:Label ID="lblAction" runat="server"></asp:Label>产品价格</td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%;">
                       软件所属类别：</td>
                    <td style="height: 24px">
                        <asp:DropDownList ID="ddlParent" runat="server" Width="282px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%;">
                        软件名称：</td>
                    <td style="height: 30px">
                        <asp:TextBox ID="txtPb_SoftName" runat="server" Width="275px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%">
                        软件所属版本：
                    </td>
                    <td style="height: 30px">
                        <asp:DropDownList ID="ddlSoftVersion" runat="server" Width="200px">
                        </asp:DropDownList></td>
                </tr>
                <tr id="Tr1" runat="server" visible="true">
                    <td colspan="2" rowspan="2" style="height: 30px;" align="center">
                        <strong>网络注册方式</strong>
                    </td>
                </tr>
                <tr id="Tr2" runat="server" visible="true">
                </tr>
                <tr runat="server" visible="true">
                    <td class="Manage_Title" style="width: 27%">
                        使用时间：
                    </td>
                    <td>
                        &nbsp;<asp:ListBox ID="ListBox1" runat="server" Height="120px" Width="184px">
                            <asp:ListItem>三个月</asp:ListItem>
                            <asp:ListItem>六个月</asp:ListItem>
                            <asp:ListItem>一年</asp:ListItem>
                        </asp:ListBox></td>
                </tr>
                <tr runat="server" visible="true">
                    <td class="Manage_Title" style="width: 27%">
                        价格：
                    </td>
                    <td>
                        <asp:TextBox ID="txtVarNetPrice" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr id="Tr3" runat="server" visible="true">
                    <td colspan="2" style="height:30px;" align="center">
                        <strong>单机注册方式</strong></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%">
                       使用时间</td>
                    <td><asp:DropDownList ID="ddlVarUseTime1" runat="server" Width="200px">
                        <asp:ListItem>终身</asp:ListItem>
                        <asp:ListItem>一年</asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%;">
                        价格：</td>
                    <td style="height: 21px">
                        &nbsp;<asp:TextBox ID="txtVarNetPrice1" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%;">
                        软件狗价格：</td>
                    <td style="height: 30px">
                        &nbsp;<asp:TextBox ID="txtSoftdog" runat="server" Width="93px"></asp:TextBox><span style="color:Red;">（注：只是软件狗的价格，一旦改变所有软件狗注册方式价格都改变）</span><asp:Button
                            ID="btnReset" runat="server" Text="重设" OnClick="btnReset_Click" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%">
                        排序编号：</td>
                    <td>
                        <asp:TextBox ID="txtOrderID" runat="server" Width="200px">10</asp:TextBox><span style="color:Red;">（注：请填写数字，数字越小越靠前）</span></td>
                </tr>
                <tr>
                    <td class="Manage_Title" style="width: 27%">
                        价格更新时间：</td>
                    <td>
                        <asp:TextBox ID="txtDatUpdateTime" runat="server" Width="200px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="height: 30px">
                        <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClientClick="history.back();return false;" />
                        <asp:HiddenField ID="hfPriceID" runat="server" Value="0" />
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
