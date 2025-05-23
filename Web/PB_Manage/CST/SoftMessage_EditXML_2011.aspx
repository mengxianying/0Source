<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftMessage_EditXML_2011.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.CST.SoftMessage_EditXML_2011" %>
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>软件消息XML添加编辑页</title>
    <style type="text/css"">
    body,td,th {
	font-size: 12px;
}
    </style>
    <link type="text/css" rel="stylesheet" href="../stylecss/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1" style="width: 788px; height: 18px;">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center" style="height: 20px">
                            <tr>
                                <td width="91%" align="left" style="height: 20px">
                                    当前位置：软件消息配置XML添加修改</td>
                                <td width="9%" align="right" style="height: 20px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table border="1" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="text-align: center; width: 96px;">
                        ID:</td>
                    <td style="width: 208px; height: 23px; text-align: left;">
                        <asp:TextBox ID="Txtnumber" runat="server" Width="149px" MaxLength="20"></asp:TextBox>
                        <asp:DropDownList ID="Droplist" runat="server" DataSourceID="XmlDataSource1" DataTextField="name"
                            DataValueField="number" Visible="False">
                        </asp:DropDownList><asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/xml/Msg_SortOne.xml">
                        </asp:XmlDataSource>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 96px;">
                        名称:</td>
                    <td style="width: 208px; text-align: left;" >
                        <asp:TextBox ID="Txtname" runat="server" MaxLength="20"></asp:TextBox>
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td style="text-align: center; width: 96px;">
                        <asp:Label ID="Label1" runat="server" Text="时间间隔：" Visible="False"></asp:Label></td>
                    <td style="width: 208px; text-align: left;">
                        <asp:TextBox ID="txtMsg_Minute" runat="server" Visible="False" Width="65px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 28px; text-align: center;" colspan="2">
                        <asp:Button ID="btnOk" runat="server" Text="保 存" OnClick="btnOk_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="Btnreset" runat="server" Text="取消" Width="61px"
                            OnClick="Btnreset_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
