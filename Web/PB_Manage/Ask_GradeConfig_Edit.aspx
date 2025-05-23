<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ask_GradeConfig_Edit.aspx.cs" Inherits="Pbzx.Web.PB_Manage.Ask_GradeConfig_Edit" %>

<html>
<head runat="server">
    <title>添加编辑等级信息 - 拼搏吧</title>
      <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

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
                                       <a href="Ask_GradeConfig.aspx" class="zilan">管理等级信息</a>
                                        |&nbsp;
                                         <a href="Ask_GradeConfig_Edit.aspx" class="zilan">添加等级信息</a>                                    
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
                                                    当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>等级</td>
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
                                        等级名称:</td>
                                    <td width="75%">
                                        &nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        最小积分:</td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtMinPoint" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        最大积分:</td>
                                    <td>
                                        &nbsp;<asp:TextBox ID="txtMaxPoint" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td colspan="2" align="center" style="height: 30px">
                                        <asp:Button ID="btn_Save" runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClientClick="history.back();return false;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
