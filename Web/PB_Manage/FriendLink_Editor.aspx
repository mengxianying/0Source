<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FriendLink_Editor.aspx.cs"
    Inherits="Pbzx.Web.PB_Manage.FriendLink_Editor" %>

<html>
<head id="Head1" runat="server">
    <title>添加编辑友情链接</title>
    <link type="text/css" rel="stylesheet" href="stylecss/css.css" />

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Prototype.js"></script>

    <script language="JavaScript" type="text/javascript" src="/configuration/js/Public.js"></script>

    <script language="javascript" src="JScript/javascript.js" type="text/javascript"></script>

    <script src="../../javascript/calendar.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="Right_bg1">
                            <table width="98%" border="0" cellspacing="0" cellpadding="0" align="center">
                                <tr>
                                    <td align="CENTER">
                                        <a href="FriendLink_Manage.aspx" class="zilan">友情链接管理</a> |&nbsp; <a href="FriendLink_Editor.aspx"
                                            class="zilan">添加友情链接</a>
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
                                                    当前位置：友情链接管理&gt;&gt;
                                                    <asp:Label ID="lblAction" runat="server"></asp:Label>友情链接</td>
                                                <td width="9%" align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="2" cellspacing="1" bgcolor="#CED7F7" border="0" width="100%"
                                class="Manage_Table">
                                <tr bgcolor="#F2F8FB">
                                    <td c class="bold">
                                        &nbsp; &nbsp;链接类型：</td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server">
                                            <asp:ListItem Value="1" Selected="True">文字链接</asp:ListItem>
                                            <asp:ListItem Value="0">图片链接</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp; &nbsp; 网站名称：</td>
                                    <td>
                                        <asp:TextBox ID="txtTitle" runat="server" Width="110px" MaxLength="8"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; &nbsp;联系人：</td>
                                    <td>
                                        <asp:TextBox ID="txtAdmin" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; &nbsp;联系电话：</td>
                                    <td>
                                        <asp:TextBox ID="txtTel" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; &nbsp;电子邮件：</td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" Width="200px" MaxLength="30"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; &nbsp;QQ：</td>
                                    <td>
                                        <asp:TextBox ID="txtQQ" runat="server" Width="200px" MaxLength="30"></asp:TextBox></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; &nbsp;链接地址：</td>
                                    <td>
                                        <asp:TextBox ID="txtLinkUrl" runat="server" Width="300px" MaxLength="80"></asp:TextBox>
                                        <span style="color: #ff0000">*</span></td>
                                </tr>
                                <%--    <tr id="Tr1" runat="server" visible="true" bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; 网站Logo：</td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <div style="position: relative; z-index: 99">
                                                        <asp:TextBox ID="txtLogo" runat="server" Width="257px"></asp:TextBox></div>
                                                </td>
                                                <td>
                                                    <div style="width: 80px; overflow: hidden;">
                                                        <div style="left: -155px; position: relative; z-index: 9">
                                                            <asp:FileUpload ID="FileUploadLogo" runat="server" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnUp" runat="server" Text="上传" OnClick="btnUp_Click" />
                                                </td>
                                                <td>
                                                    <span id="LogoImageState" class="Upload_Selected">已选择 <a onclick="Upload_Clear(this,'FileUploadLogo','txtLogo');">
                                                        清除</a></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>--%>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        网站Logo：
                                    </td>
                                    <td style="height: 58px">
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr bgcolor="#F2F8FB">
                                                <td>
                                                    <span onmouseover="javascript:ShowDivPic(this,document.form1.txtThumb.value,'.jpg',1);"
                                                        onmouseout="javascript:hiddDivPic();" style="cursor: pointer;">
                                                        <asp:TextBox ID="txtThumb" runat="server" Width="268px" MaxLength="80"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                    <div style="width: 200px; padding-left: 5px;">
                                                        <div style="margin-left: -8px;">
                                                            &nbsp;&nbsp;<img src="/Images/Web/s.gif" alt="选择已有图片" border="0" style="cursor: pointer;"
                                                                onclick="selectFile('pic',document.form1.txtThumb,480,600);document.form1.txtThumb.focus();" />
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    图片大小88*31</td>
                                </tr>
                                <tr id="Tr2" runat="server" visible="true" bgcolor="#F2F8FB">
                                    <td class="bold" valign="top">
                                        &nbsp;&nbsp; &nbsp;简 介：</td>
                                    <td>
                                        <asp:TextBox ID="txtContent" runat="server" Width="400px" TextMode="MultiLine" Rows="6" MaxLength="800"></asp:TextBox>(对外显示)<br />
                                    </td>
                                </tr>
                                <tr runat="server" bgcolor="#f2f8fb" visible="true">
                                    <td class="bold" valign="top">
                                        备 注：</td>
                                    <td>
                                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="510" Rows="6" TextMode="MultiLine"
                                            Width="400px"></asp:TextBox>(内部使用，不对外显示)<br />
                                    </td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; 链接排序：</td>
                                    <td>
                                        <asp:TextBox ID="txtSortOrder" runat="server" Width="60px" MaxLength="5"></asp:TextBox>&nbsp;
                                        <span style="color: #ff0000">* </span>值越小则排在越前面</td>
                                </tr>
                            <%--    <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; 更新时间：</td>
                                    <td>
                                        <asp:TextBox ID="txtModifyTime" runat="server" onfocus="calendar();" MaxLength="20"></asp:TextBox></td>
                                </tr>--%>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; 审核：</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbtState" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">已通过</asp:ListItem>
                                            <asp:ListItem Value="0">未通过</asp:ListItem>
                                            <asp:ListItem Value="2">未审核</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td class="bold">
                                        &nbsp;&nbsp; 推荐到首页：</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbtIsGood" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="1">已推荐</asp:ListItem>
                                            <asp:ListItem Value="0">不推荐</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                                <tr bgcolor="#F2F8FB">
                                    <td colspan="2" align="center">
                                        <asp:Button ID="btn_Save" runat="server" Text="保存" OnClick="btn_Save_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="取消" OnClientClick="history.back();return false;" />
                                        <asp:HiddenField ID="hfFriendLinkID" runat="server" Value="0" />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
