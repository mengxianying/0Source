<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWebBuletion_xml.aspx.cs" Inherits="Pbzx.Web.PB_Manage.AddWebBuletion_xml" %>

<%@ Register Assembly="DotNetTextBox" Namespace="DotNetTextBox" TagPrefix="DNTB" %>
<html>
<head id="Head1" runat="server">
    <title>订单信息</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
    <link href="E:\Pinble.Net\0Source\Web/system_dntb/skin/default/toolbar.css" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#7694D2"
                class="MT">
                <tr>
                    <td bgcolor="#F3F3F3">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="Right_bg1">
                                    <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                        <tr>
                                            <td width="91%" align="left">
                                                当前位置：配置管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                            <td style="width:20%"> 
                            购物车通知公告：
                            </td>
                            <td style="width:80%"> 
                                <DNTB:WebEditor ID="weCartNotice" runat="server" />                                
                            </td>
                            </tr>
                              <tr bgcolor="#F2F8FB">
                            <td>
                            
                            </td>
                             <td>
                            
                            </td>
                            </tr>
                              <tr bgcolor="#F2F8FB">
                            <td>
                            
                            </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td colspan="4" align="center">
                                    &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定修改" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>