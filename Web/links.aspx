<%@ Page Language="C#" AutoEventWireup="true" Codebehind="links.aspx.cs" Inherits="Pbzx.Web.links" %>

<%@ Register Src="Contorls/AboutMenu.ascx" TagName="AboutMenu" TagPrefix="uc1" %>
<%@ Register Src="Contorls/Head.ascx" TagName="Head" TagPrefix="uc2" %>
<%@ Register Src="Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>友情链接_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/about.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/css/start/jquery-ui-1.7.2.custom.css" rel="stylesheet" />

    <script type="text/javascript" src="/javascript/jquery-1.3.2.js"></script>

    <script type="text/javascript" src="/javascript/jquery.blockUI.js"></script>

    <script type="text/javascript" src="/javascript/jquery-ui-1.7.2.custom.min.js"></script>

    <script type="text/javascript" src="/javascript/Header.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc2:Head ID="Head1" runat="server" />
            <table width="990" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                <tr>
                    <td width="190" valign="top" background="images/web/AB_lbg1.jpg">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/web/AB_l1.jpg" width="190" height="30" /></td>
                            </tr>
                        </table>
                        <table width="190" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10">
                                    &nbsp;
                                </td>
                                <td width="180" valign="top">
                                    <uc1:AboutMenu ID="AboutMenu1" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="10">
                    </td>
                    <td width="790" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="images/web/AB_banner.jpg" width="790" height="90" /></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="2%" height="25">
                                    <img src="images/web/AB_li.jpg" width="14" height="13" /></td>
                                <td width="98%" align="left" valign="bottom">
                                    你的当前位置：拼搏在线&gt;&gt;友情链接</td>
                            </tr>
                        </table>
                        <table width="100%" height="28" border="0" cellpadding="0" cellspacing="0" background="images/web/AB_weibg.jpg">
                            <tr>
                                <td width="5%">
                                    &nbsp;
                                </td>
                                <td width="95%" align="left" style="padding-top: 4px;">
                                    <strong>友情链接</strong></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="6" runat="server" id="shenqing">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left">
                                                <span class="A14Red">欢迎世界排名在4万以内的网站在线申请友情链接，如有问题请联系拼搏在线彩神通软件客服。</span><br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;<span class="A12Bule"> 注意：请先在自己的网站加上“拼搏在线彩神通软件”的链接，再在下面提出友情链接的申请，否则将不会审查通过。</span><br />
                                                <br />
                                                <table width="90%" border="0" cellspacing="0" cellpadding="2" align="center">
                                                    <tr>
                                                        <td width="25%" align="right">
                                                            请选择链接类型：</td>
                                                        <td width="75%" align="left">
                                                            <%--  <asp:RadioButtonList ID="rtbType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="0">文字链接 </asp:ListItem>
                                                        <asp:ListItem Value="1">图片链接</asp:ListItem>
                                                    </asp:RadioButtonList>--%>
                                                            <asp:DropDownList ID="ddlType" runat="server">
                                                                <asp:ListItem Selected="True" Value="1">文字链接</asp:ListItem>
                                                                <asp:ListItem Value="0">图片链接</asp:ListItem>
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            网站地址：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSiteUrl" runat="server" Width="220px" MaxLength="80">http://</asp:TextBox><font
                                                                color="red">*</font>
                                                            <asp:RegularExpressionValidator ID="gshiurl" runat="server" ControlToValidate="txtSiteUrl"
                                                                ErrorMessage="网址格式不对" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="right">
                                                            LOGO地址：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtLogoUrl" runat="server" Width="220px" MaxLength="80"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%" align="right">
                                                            网站名称：</td>
                                                        <td width="75%" align="left">
                                                            <asp:TextBox ID="txtSiteName" runat="server" Width="110px" MaxLength="8"></asp:TextBox><font
                                                                color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="rq1" runat="server" ControlToValidate="txtSiteName"
                                                                ErrorMessage="请输入网站名称！"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            联&nbsp;系&nbsp;人：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSiteAdmin" runat="server" Width="220px" MaxLength="20"></asp:TextBox><font
                                                                color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="rq2" runat="server" ControlToValidate="txtSiteAdmin"
                                                                ErrorMessage="请输入联系人姓名！"></asp:RequiredFieldValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            联系电话：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTel" runat="server" Width="220px" MaxLength="30"></asp:TextBox><font
                                                                color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="rqqq" runat="server" ControlToValidate="txtTel" ErrorMessage="请输入电话！"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            电子邮件：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtEmail" runat="server" Width="220px" MaxLength="30"></asp:TextBox><font
                                                                color="red">*</font>
                                                            <asp:RegularExpressionValidator ID="gshi2" runat="server" ControlToValidate="txtEmail"
                                                                ErrorMessage="电子邮件格式不正确！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            QQ：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtQQ" runat="server" Width="220px" MaxLength="30"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="top">
                                                            网站简介：</td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSiteIntro" runat="server" Rows="5" TextMode="MultiLine" Width="350px"
                                                                Height="120" MaxLength="800"></asp:TextBox><%--<font color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="rq3" runat="server" ControlToValidate="txtSiteIntro"
                                                                ErrorMessage="请输入网站简介！"></asp:RequiredFieldValidator>--%></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            验证码：
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTry" runat="server" MaxLength="4" TextMode="Password" Width="50px"
                                                                onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvtry" runat="server" ControlToValidate="txtTry"
                                                                ErrorMessage="请输入验证码" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle"
                                                                id="imgVerify" onclick="this.src=this.src+'?'" height="23" width="62" />
                                                            <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                            <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp; &nbsp;&nbsp;
                                                            <asp:Button ID="btAdd" runat="server" Text="提交申请" OnClick="btAdd_Click" />&nbsp;&nbsp;<asp:Button
                                                                ID="btCancel" runat="server" Text="重置" OnClick="btCancel_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="6" runat="server" id="cheng"
                            visible="false">
                            <tr>
                                <td height="50">
                                    添加广告自助链接成功，请等管理员验证通过。[<asp:LinkButton ID="btBack" runat="server" OnClick="btBack_Click">返回</asp:LinkButton>]
                                </td>
                            </tr>
                        </table>
                        <table width="90%" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#CCCCCC"
                            class="MT2">
                            <tr>
                                <td width="16%" bgcolor="#FFFFFF">
                                    &nbsp;本站名称：</td>
                                <td width="60%" align="left" bgcolor="#FFFFFF">
                                    &nbsp;拼搏在线彩神通软件</td>
                                <td bgcolor="#FFFFFF">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    &nbsp;本站域名：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    &nbsp;http://www.pinble.com</td>
                                <td bgcolor="#FFFFFF" style="width: 167px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    &nbsp;LOGO链接地址：</td>
                                <td align="left" bgcolor="#FFFFFF">
                                    &nbsp;<a href="http://image.pinble.com/images/pinble.gif" target="_blank">http://image.pinble.com/images/pinble.gif</a></td>
                                <td bgcolor="#FFFFFF" align="center">
                                    <img src="Images/Web/pinble.gif" /></td>
                            </tr>
                        </table>
                        <table width="90%" border="0" cellpadding="4" cellspacing="2" bgcolor="#84D3FF" align="center"
                            class="MT">
                            <tr>
                                <td align="center" bgcolor="#FFFFFF">
                                    <asp:DataList ID="dtLinks" runat="server" RepeatColumns="8" RepeatDirection="Horizontal"
                                        Width="100%">
                                        <ItemTemplate>
                                            <a href='<%# Eval("NteSiteUrl")%>' title='网站名称：<%# Eval("IntSiteName")%>&#13;网站地址：<%# Eval("NteSiteUrl")%>&#13;网站简介：<%# Eval("NteSiteIntro")%>'
                                                target="_blank">
                                                <%# Eval("IntSiteName")%>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:DataList></td>
                            </tr>
                        </table>
                        <table width="30%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <table width="90%" border="0" cellpadding="4" cellspacing="2" bgcolor="#84D3FF" align="center">
                            <tr>
                                <td align="center" bgcolor="#FFFFFF">
                                    <asp:DataList ID="dlPic" runat="server" RepeatDirection="Horizontal" RepeatColumns="8"
                                        Width="100%">
                                        <ItemTemplate>
                                            <a href=" <%#Eval("NteSiteUrl")%>" title="<%#Eval("IntSiteName")%>" target="_blank">
                                                <img src='<%#Eval("NteLogoUrl")%>' border="0" width="85" height="31" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc3:Footer ID="Footer1" runat="server" />
    </form>
</body>

<!-- <script src="/javascript/kf/PinbleService.js"></script> -->

</html>
