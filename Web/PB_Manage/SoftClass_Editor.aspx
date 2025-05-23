<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SoftClass_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.SoftClass_Editor" %>

<html>
<head id="Head1" runat="server">
    <title>商品资源类别编辑</title>
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
                                    <div id="chanID" runat="server" visible="false">
                                        <a href="SoftClass_Manage.aspx?classType=chan" class="zilan">商品类别管理</a> |&nbsp; <a href="SoftClass_Editor.aspx?strTyp=0"  class="zilan">
                                            添加商品类别</a></div>
                                    <div id="yuanID" runat="server" visible="false">
                                        <a href="SoftClass_Manage.aspx?classType=yuan"  class="zilan">资源下载类别管理</a> |&nbsp; <a href="SoftClass_Editor.aspx?strTyp=1"  class="zilan">
                                            添加资源下载类别</a></div>
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
                                                当前位置：<asp:Label ID="lblAction" runat="server"></asp:Label>类别管理</td>
                                            <td width="9%" align="right">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="2" cellspacing="1" width="100%" bgcolor="#CED7F7">
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>所属类别：</strong></td>
                                <td style="height: 24px">
                                    <asp:DropDownList ID="ddlParent" runat="server" Width="282px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>类别名称：</strong></td>
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtNvarClassName" runat="server" Width="275px"></asp:TextBox></td>
                            </tr>
                            <tr bgcolor="#F1F1F1" id="Tr1" runat="server" visible="true">
                                <td align="right">
                                    <strong>类别说明： </strong>
                                </td>
                                <td style="height: 30px">
                                    <asp:TextBox ID="txtNvarReadme" runat="server" Width="275px" Height="70px" TextMode="MultiLine"></asp:TextBox><span
                                        style="color: #333;">鼠标移至栏目名称上时将显示设定的说明文字</span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1" id="Tr2" runat="server" visible="true">
                                <td align="right">
                                    <strong>是否启用：</strong></td>
                                <td>
                                    <asp:RadioButtonList ID="rblBitIsElite" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList><span style="color: #333;">推荐栏目将在首页及此栏目的父栏目上显示软件列表</span></td>
                            </tr>
                            <tr bgcolor="#F1F1F1" runat="server" visible="true">
                                <td align="right">
                                    <strong>是否显示：</strong></td>
                                <td>
                                    <asp:RadioButtonList ID="rblIsShowInTop" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                    </asp:RadioButtonList><span style="color: #333;">此选项只对一级栏目有效。</span></td>
                            </tr>
                            <%--                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>栏目图片地址：</strong></td>
                                <td>
                                    <asp:TextBox ID="txtNvarClassPicUrl" runat="server" Width="68px" Enabled="False"></asp:TextBox>
                                    (暂无此功能)图片会显示在栏目前面</td>
                            </tr>--%>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>栏目链接地址：</strong></td>
                                <td style="height: 21px">
                                    <asp:TextBox ID="txtNvarLinkUrl" runat="server" Width="274px"></asp:TextBox><span
                                        style="color: #333;">如果想将栏目链接到外部地址，请输入完整的URL地址，否则请保持为空。</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>栏目浏览权限：</strong></td>
                                <td>
                                    <asp:DropDownList ID="ddlIntBrowsePurview" runat="server" Width="150px">
                                        <asp:ListItem Selected="True" Value="9999">游客</asp:ListItem>
                                        <asp:ListItem Value="999">注册用户</asp:ListItem>
                                        <asp:ListItem Value="99">收费用户</asp:ListItem>
                                        <asp:ListItem Value="9">VIP用户</asp:ListItem>
                                        <asp:ListItem Value="5">管理员</asp:ListItem>
                                    </asp:DropDownList><span style="color: #333;">只有具有相应权限的人才能浏览此栏目中的软件。</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td align="right">
                                    <strong>栏目发表软件权限： </strong>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIntAddPurview" runat="server" Width="150px">
                                        <asp:ListItem Value="999">注册用户</asp:ListItem>
                                        <asp:ListItem Value="99">收费用户</asp:ListItem>
                                        <asp:ListItem Value="9">VIP用户</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="5">管理员</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: #333;">只有具有相应权限的人才能在此栏目中发表软件。</span></td>
                            </tr>
                            <tr bgcolor="#F2F8FB">
                                <td class="Manage_Title">
                                </td>
                                <td>
                                    <span style="height: 30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_Save"
                                        runat="server" CssClass="K2046_Button" Text="保存" OnClick="btn_Save_Click" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="K2046_Button" Text="取消" OnClientClick="history.back();return false;" />
                                        <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                                    </span>
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
