<%@ Page Language="C#" AutoEventWireup="true" Codebehind="LeTouType.aspx.cs" Inherits="Pbzx.Web.LeTouType" EnableEventValidation="false"  %>

<%@ Register Src="Contorls/UcShuang.ascx" TagName="UcShuang" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>数据图表_拼搏在线彩神通软件</title>
    <meta name="keywords" content="图表,走势图,体彩,福彩,福利彩票,体育彩票" />
    <meta name="description" content="" />
    <link href="/css/graph.css" rel="stylesheet" type="text/css" />
</head>
<body  STYLE='OVERFLOW:SCROLL;OVERFLOW-Y:HIDDEN'>
    <form id="form1" runat="server">
        <div>
        
             <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0"  bgcolor="#EEEEEE">
                                <tr>
                                    <td width="3%" style="height: 26px">
                                        <strong>
                                            <img src="images/web/G_li2.gif" width="21" height="18" hspace="6" align="absmiddle" /></strong></td>
                                    <td align="left" valign="bottom" class="G_title14" style="height: 26px; width: 79%;">
                                        <table width="100%">
                                            <tr>
                                                <td width="49%" valign="bottom" >
                                                    <strong>
                                                  <asp:Label ID="lblName" runat="server"></asp:Label>开奖号码分布图</strong>
                                              </td>
                                                <td align="right" valign="bottom" width="51%">
                                                    <div style="float: right; margin-right: 3px;">
                                                     <%-- <table style="width: 100%" cellpadding="2">
                                                            <tr>
                                                                <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chbAddXuHao" runat="server" Checked="true" Text="显示序号" AutoPostBack="True" OnCheckedChanged="chbAddXuHao_CheckedChanged" Visible="False" />&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chbAddCode" runat="server" Checked="true" Text="显示开奖号码" AutoPostBack="True" OnCheckedChanged="chbAddCode_CheckedChanged" Visible="False" />&nbsp;
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
                                        <strong>显示最近：</strong>
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
        </div>
        <uc1:UcShuang ID="UcShuang1" runat="server" />
    </form>
</body>

</html>
