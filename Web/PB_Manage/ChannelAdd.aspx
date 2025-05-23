<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChannelAdd.aspx.cs" Inherits="Pbzx.Web.ChannelAdd" %>

<html>
<head runat="server">
     <title>WebSite</title>
    <link type="text/css" rel="Stylesheet" href="StyleCss/css.css" />
<script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="Right_bg1">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                            <tr>
                                <td align="CENTER">
                                    <%--<asp:LinkButton ID="LinkButton3" runat="server" OnClick="btn_gl_Click" Font-Bold="True" ForeColor="White">管理频道信息</asp:LinkButton>
                                    |&nbsp;
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="btn_add_Click" Font-Bold="True" ForeColor="White">添加频道信息</asp:LinkButton>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
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
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>频道信息</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#A4D5EE">
                            <tr bgcolor="#F2F8FB">
                                <td class="bold" width="25%">
                                   频道名称:</td>
                                <td width="75%">
                                    <asp:TextBox ID="txtPageName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                    频道类别:</td>
                                <td>
                                    <asp:DropDownList ID="ddlParent" runat="server" DataTextField="PageName" DataValueField="MapID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                  Aspx页面地址:</td>
                                <td>
                                  <asp:TextBox ID="txtAspx" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                                 <tr bgcolor="#F2F8FB">
                                <td class="bold">
                                 最终html页面地址:</td>
                                <td>
                                  <asp:TextBox ID="txtHtml" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                                
                            <tr bgcolor="#F2F8FB">
                                <td colspan="2" align="center" style="height: 30px">
                                    <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消"  />
                                    <asp:HiddenField ID="hfID" runat="server" Value="0" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
     
    </div>
    </form>
</body>
</html>
