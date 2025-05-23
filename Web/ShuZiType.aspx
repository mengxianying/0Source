<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShuZiType.aspx.cs" Inherits="Pbzx.Web.ShuZiType" EnableEventValidation="false" %>

<%@ Register Src="Contorls/TempletDanHao.ascx" TagName="TempletDanHao" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml">
<head runat="server">
    <title>数据图表_拼搏在线彩神通软件</title>
    <meta name="keywords" content="福彩3D,体彩排列三,数字彩票,图表,走势图" />
    <meta name="description" content="" />
    <link href="/css/graph.css" rel="stylesheet" type="text/css" />
    		<style type="text/css">
		 v\:* { BEHAVIOR: url(#default#VML) }
		</style>
    <script language="javascript" src="/javascript/Line.js"></script>
</head>
<body style='overflow: SCROLL; overflow-y: HIDDEN'>
    <form id="form1" runat="server">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#EEEEEE">
            <tr>
                <td width="3%">
                    <img src="images/web/G_li2.gif" width="21" height="18" hspace="6" align="absmiddle" /></td>
                <td align="left" valign="bottom" class="G_title14" style="width: 79%;">
                    <table width="100%">
                        <tr>
                            <td valign="bottom" style="width: 42%">
                                <strong>
                                    <asp:Label ID="lblName" runat="server"></asp:Label>开奖号码分布图</strong>
                            </td>
                            <td align="right" valign="bottom" style="width: 60%">
                                <div style="float: right; margin-right: 3px;">
                                    <%--   <table style="width: 100%" cellpadding="2">
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chbZB" runat="server" Checked="true" Text="指标区" AutoPostBack="True" OnCheckedChanged="chbZB_CheckedChanged" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;<asp:CheckBox ID="chbKD" runat="server" Checked="true" Text="跨度走势" AutoPostBack="True" OnCheckedChanged="chbKD_CheckedChanged" />
                                                                </td>
                                                                <td>
                                                                    &nbsp;<asp:CheckBox ID="chbHZ" runat="server" Checked="true" Text="尾数和值走势" AutoPostBack="True" OnCheckedChanged="chbHZ_CheckedChanged" />
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chbYL" runat="server" Checked="true" Text="遗漏" AutoPostBack="True" OnCheckedChanged="chbYL_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                        </table>--%>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    显示最近：
                    <asp:DropDownList ID="ddlQushu" runat="server" Width="94px" AutoPostBack="True" OnSelectedIndexChanged="qushu_SelectedIndexChanged">
                        <asp:ListItem Value="10">10期</asp:ListItem>
                        <asp:ListItem Value="20" Selected="True">20期</asp:ListItem>
                        <asp:ListItem Value="30">30期</asp:ListItem>
                        <asp:ListItem Value="50">50期</asp:ListItem>
                        <asp:ListItem Value="100">100期</asp:ListItem>
                        <asp:ListItem Value="200">200期</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
        <uc1:TempletDanHao ID="TempletDanHao1" runat="server" />
    </form>
</body>
</html>
