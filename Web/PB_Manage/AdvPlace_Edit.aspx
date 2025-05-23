<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AdvPlace_Edit.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.AdvPlace_Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加编辑广告位</title>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />
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
                                    <a href="Ad_Manage.aspx" class="zilan">广告管理</a> | <a href="Ad_Edit.aspx" class="zilan">
                                        添加广告信息</a> | <a href="AdvPlace_Manage.aspx" class="zilan">广告位列表</a> | <a href="AdvPlace_Edit.aspx" class="zilan">添加广告位</a></td>
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
                                                当前位置：广告位管理&gt;&gt;添加广告位</td>
                                            <td width="9%" align="right">
                                               </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellpadding="2" cellspacing="1" bgcolor="#CED7F7">
                            <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    <strong>类别：</strong></td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rbtTypeID" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList></td>
                            </tr>
                                 <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    <strong>栏目：</strong></td>
                                <td align="left">
                                    <asp:ListBox ID="Channel" runat="server" Height="120px" Style="width: 220px"></asp:ListBox></td>
                            </tr>
                                 <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    <strong>位置：</strong></td>
                                <td align="left">
                                    <asp:TextBox ID="txtPlaceName" runat="server" Width="401px"></asp:TextBox></td>
                            </tr>
                                         <tr bgcolor="#f2f8fb">
                                <td align="right">
                                    <strong></strong></td>
                                <td align="left">
                                    <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="保存" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
