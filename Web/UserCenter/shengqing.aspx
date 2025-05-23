<%@ Page Language="C#" AutoEventWireup="true" Codebehind="shengqing.aspx.cs" Inherits="Pbzx.Web.shengqing" %>

<%@ Register Src="../Contorls/Agent_AD.ascx" TagName="Agent_AD" TagPrefix="uc5" %>
<%@ Register Src="../Contorls/Agent_menu.ascx" TagName="Agent_menu" TagPrefix="uc3" %>
<%@ Register Src="../Contorls/Head.ascx" TagName="Head" TagPrefix="uc1" %>
<%@ Register Src="../Contorls/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>代理商申请_拼搏在线彩神通软件</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
    <link href="/css/agent.css" rel="stylesheet" type="text/css" />
    <link href="/css/user.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="/javascript/SearchAjax.js"> </script>

    <script src="/javascript/calendar.js" type="text/javascript"></script>

    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
    <link href="/css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <uc1:Head ID="Head1" runat="server" />
            <uc5:Agent_AD ID="Agent_AD1" runat="server" />
            <div class="bodyw MT">
                <!--左边---->
                <div class="A_l">
                    <uc3:Agent_menu ID="Agent_menu1" runat="server" />
                    &nbsp;</div>
                <!--右边---->
                <div class="A_r">
                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#CCCCCC">
                        <tr>
                            <td bgcolor="#f5f5f5">
                                <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="87%" height="25" valign="bottom" class="A_biao">
                                            当前位置：<a href='<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl%>'><span class="A_biao">拼博在线彩神通软件</span></a>
                                            >> <a href="/Agent.aspx"><span class="A_biao">代理专区</span></a> >> 代理商申请
                                        </td>
                                        <td width="13%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr bgcolor="#4099F2">
                            <td height="2" bgcolor="#69B2F6">
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="2" cellspacing="1" bgcolor="#CCCCCC">
                        <tr bgcolor="#FFFFFF">
                            <td bgcolor="#FFFFFF" class="red12">
                                <table width="96%" border="0" align="center" cellpadding="6" cellspacing="0">
                                    <tr>
                                        <td align="center">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="28" valign="bottom">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr bgcolor="#FBFDFF">
                                                                <td>
                                                                    <span class="color2"><span style="font-size: 9pt">代理注册</span>：</span><span class="color1">
                                                                        <asp:Label ID="tishi" runat="server" Text="*为必填内容，请您认真填写，以便需要我们及时的和您联系。"></asp:Label><asp:Label
                                                                            ID="already" runat="server" Visible="false" Text="您的真实信息已经注册过了，请审核一下您的真实信息，提交申请就可以了。"></asp:Label>
                                                                    </span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="pnlBroker" runat="server">
                                                <!---注册内容---->
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                                                    <tr>
                                                        <td height="27" background="/Images/web/U_bg2.gif">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr bgcolor="#F4F8FF">
                                                                    <td width="4%" height="24">
                                                                        <img src="/Images/web/U_li1.gif" width="14" height="14" alt="" /></td>
                                                                    <td width="63%" align="left" valign="bottom" bgcolor="#F4F8FF" class="title1">
                                                                        用户基本信息</td>
                                                                    <td width="33%">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="97%" border="0" cellspacing="0" cellpadding="3">
                                                                <tr>
                                                                    <td width="24%" align="right" valign="top">
                                                                        用户名：</td>
                                                                    <td width="27%" align="left">
                                                                        <span style="color: #ff0000">
                                                                            <asp:TextBox ID="txtUserName" runat="server" Enabled="False"></asp:TextBox></span></td>
                                                                    <td width="49%" align="left" valign="top" class="color3">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
                                                                        验证码：</td>
                                                                    <td align="left">
                                                                        <asp:TextBox ID="txtYz" runat="server" Width="50px" MaxLength="4" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')" ></asp:TextBox>
                                                                        <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" width="65"
                                                                            height="23" align="absmiddle" id="imgVerify" onclick="this.src=this.src+'?'" />
                                                                             <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                                                            <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
                                                                            </td>
                                                                    <td align="left" class="color3">
                                                                        请输入验证码
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" id="really" runat="server">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                                                                <tr>
                                                                    <td height="27" background="/Images/web/U_bg2.gif">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr bgcolor="#F4F8FF">
                                                                                <td width="4%" height="24">
                                                                                    <img src="/Images/web/U_li1.gif" width="14" height="14" /></td>
                                                                                <td width="63%" align="left" valign="bottom" class="title1">
                                                                                    用户详细信息</td>
                                                                                <td width="33%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="97%" border="0" cellspacing="0" cellpadding="3">
                                                                            <tr>
                                                                                <td width="24%" align="right">
                                                                                    真实姓名：</td>
                                                                                <td width="28%" align="left">
                                                                                    <asp:TextBox ID="txtRealName" runat="server" Width="180px" MaxLength="20"></asp:TextBox>&nbsp;<span
                                                                                        style="color: #ff0000">*<br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRealName"
                                                                                            ErrorMessage="请填写真实姓名" SetFocusOnError="true" ValidationGroup="Base" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                                                                                <td width="48%" align="left" class="color3">
                                                                                    请输入您的真实姓名，方便客户跟您联系。
                                                                                </td>
                                                                            </tr>
                                                                            <%--   <tr>
                                                                            <td align="right">
                                                                                出生年月：</td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtBirthday" onfocus="calendar();" runat="server"></asp:TextBox><span
                                                                                    style="color: #ff0000">*<br />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBirthday"
                                                                                        ErrorMessage="请选择出生日期" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                                                                            <td align="left" class="color3">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                性别：</td>
                                                                            <td align="left">
                                                                                <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal">
                                                                                    <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                                                                                    <asp:ListItem Value="1">女</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </td>
                                                                            <td align="left" class="color3">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                交易密码：</td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtTPWD" runat="server" TextMode="Password" Width="149"></asp:TextBox><span
                                                                                    style="color: #ff0000">*<br />
                                                                                    <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtTPWD"
                                                                                        ErrorMessage="密码必须是6-16位的字母和数字" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                                                                                        SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                                                                            <td align="left" class="color3">
                                                                                请设置交易密码，建议使用6-16位的字母或数字.</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                确认交易密码：</td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtReTPWD" runat="server" TextMode="Password" Width="149"></asp:TextBox><span
                                                                                    style="color: #ff0000">*<br />
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtTPWD"
                                                                                        ControlToValidate="txtReTPWD" ErrorMessage="两次密码输入不一致" SetFocusOnError="true"
                                                                                        Display="Dynamic"></asp:CompareValidator></span></td>
                                                                            <td align="left" class="color3">
                                                                            </td>
                                                                        </tr>
                                                                           <tr>
                                                                                <td align="right">
                                                                                    身份证号码：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtCardID" runat="server"></asp:TextBox><span style="color: #ff0000">*<br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCardID"
                                                                                            ErrorMessage="请填写身份证号码" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCardID"
                                                                                            ErrorMessage="身份证号码格式不正确" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                                                                                <td align="left" class="color3">
                                                                                    非常重要，一旦需要修改一些重要信息，要核对身份证号码，提交之后不能更改。</td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    联系电话：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtTel" runat="server" Width="180px" MaxLength="15"></asp:TextBox><%--<span style="color: #ff0000">*<br /><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTel" ErrorMessage="请填写联系电话"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="联系电话格式不正确" ValidationExpression="^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$" Display="Dynamic"></asp:RegularExpressionValidator></span>--%></td>
                                                                                <td align="left" class="color3">
                                                                                    电话号码中应包括区号，如：010-62132803</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    手机号码：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtMobile" runat="server" Width="180px" MaxLength="13"></asp:TextBox></td>
                                                                                <td align="left" class="color3">
                                                                                    方便客户与您直接联系。</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    传真号码：</td>
                                                                                <td align="left" colspan="2">
                                                                                    <asp:TextBox ID="txtFax" runat="server" Width="180px" MaxLength="13"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    E-mail：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtEmail" runat="server" Width="180px" MaxLength="50"></asp:TextBox>&nbsp;<span
                                                                                        style="color: #ff0000">*<br />
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtEmail"
                                                                                            ErrorMessage="Email格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                            Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                                                                                <td align="left" class="color3">
                                                                                    请输入常用的邮箱！</td>
                                                                            </tr>
                                                                            <%--                                              <tr>
                                                                                <td align="right">
                                                                                    密码提示问题：</td>
                                                                                <td align="left" colspan="2">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="35%">
                                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <asp:TextBox ID="txtQuestion" runat="server" Visible="false"></asp:TextBox>
                                                                                                        <asp:DropDownList ID="ddlPassWordQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPassWordQuestion_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                        <font color="red">*</font>
                                                                                                    </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </td>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td width="65%" align="left">
                                                                                                <span class="font_gray" id="spQuestionTS" runat="server">请选择常用的密码问题，当您忘记交易密码时根据问题取回交易密码
                                                                                                </span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <%--                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            
                        <asp:TextBox ID="txtQuestion" runat="server" MaxLength="40" Visible="false" onblur="if(this.value==''){document.getElementById('spQuestion').innerHTML='请输入密码提示问题'};" Width="210px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                                                                                    <br />
                                                                                    <span id="spQuestion" style="color: Red"></span>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    密码问题答案：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" MaxLength="100"></asp:TextBox><font
                                                                                        color="red">*</font><asp:RequiredFieldValidator ID="vPasswordanswer" runat="server"
                                                                                            ControlToValidate="txtPassWordAnswer" ValidationGroup="baseinfo" SetFocusOnError="True">*</asp:RequiredFieldValidator><br />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWordAnswer"
                                                                                        ErrorMessage="密码答案不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td align="left">
                                                                                    <span class="font_gray">请输入您的密码答案</span></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    QQ号码：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtQQ" runat="server" Width="180px"></asp:TextBox></td>
                                                                                <td align="left" class="color3">
                                                                                    &nbsp; 方便网上交流。</td>
                                                                            </tr>
                                                                           <tr>
                                                                                <td align="right" style="height: 30px">
                                                                                    MSN：</td>
                                                                                <td align="left" style="height: 30px">
                                                                                    <asp:TextBox ID="txtMSN" runat="server" Width="180px"></asp:TextBox></td>
                                                                                <td align="left" class="color3" style="height: 30px">&nbsp;
                                                                                    
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    省份：</td>
                                                                                <td align="left">
                                                                                    <table width="100%">
                                                                                        <tr>
                                                                                            <td width="25%">
                                                                                                <asp:DropDownList ID="ddlProvince" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td>
                                                                                                <%--<asp:DropDownList ID="ddlCity" runat="server">
                                                                                                    <asp:ListItem Value="110100">北京市</asp:ListItem>
                                                                                                </asp:DropDownList>--%>
                                                                                                <span style="color: #ff0000">*</span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td align="left" class="color3">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    邮编：</td>
                                                                                <td align="left">
                                                                                    <asp:TextBox ID="txtPostCode" runat="server" Width="180px" MaxLength="6"></asp:TextBox>&nbsp;<span
                                                                                        style="color: #ff0000">*<br />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode"
                                                                                            ErrorMessage="请填写邮编" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                                                                                            ErrorMessage="邮编格式不正确" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                                                                                <td align="left" class="color3">
                                                                                    邮编： 100000</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    公司名称：</td>
                                                                                <td colspan="2" align="left">
                                                                                    <asp:TextBox ID="txtCompany" runat="server" Width="180px" MaxLength="128"></asp:TextBox><span class="color3"></span></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    详细地址：</td>
                                                                                <td align="left" colspan="2">
                                                                                    <asp:TextBox ID="txtAddress" runat="server" Width="250px" MaxLength="128"></asp:TextBox>&nbsp;<span
                                                                                        style="color: #ff0000">*<asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                                                                            runat="server" ControlToValidate="txtAddress" ErrorMessage="请填写详细地址" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="97%" border="0" cellpadding="3" cellspacing="0">
                                                                            <tr>
                                                                                <td width="24%" align="right" valign="top">
                                                                                    代理简介：</td>
                                                                                <td width="76%" align="left">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:TextBox ID="txtRemark" runat="server" Rows="6" TextMode="MultiLine" Width="400px" MaxLength="1020"></asp:TextBox></td>
                                                                                            <td>
                                                                                                <span class="color3">为了让更多的彩民，请您详细填写自己熟悉的彩种技巧；</span></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <%--<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                                                                <tr>
                                                                    <td height="27" background="/Images/web/U_bg2.gif">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr bgcolor="#F4F8FF">
                                                                                <td width="4%" height="24">
                                                                                    <img src="/Images/web/U_li1.gif" width="14" height="14" alt="" /></td>
                                                                                <td width="63%" align="left" valign="bottom" class="title1">
                                                                                    银行信息<span class="color1"></span></td>
                                                                                <td width="33%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="97%" border="0" cellspacing="0" cellpadding="3">
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    发卡银行：</td>
                                                                                <td colspan="2" align="left">
                                                                                    <asp:RadioButtonList ID="rblBankList" runat="server" RepeatDirection="Horizontal">
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top">
                                                                                    开户行：</td>
                                                                                <td colspan="2" align="left">
                                                                                    <asp:TextBox ID="txtBankInfo" runat="server" Width="360px"></asp:TextBox><span style="color: #ff0000">*</span>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBankInfo"
                                                                                        ErrorMessage="请填写开户行"></asp:RequiredFieldValidator><br />
                                                                                    <span class="color3">例如：北京市中国建设银行铁道专业支行官园南里储蓄所 注意：无论您的银行卡的发卡银行和地区怎样选择，请您务必填写‘银行卡开户银行’。其格式如上例子所示，XX省XX银行XX市XX支行(营业部)</span></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top">
                                                                                    卡号：</td>
                                                                                <td colspan="2" align="left">
                                                                                    <asp:TextBox ID="txtAccountNumber" runat="server" Width="200px"></asp:TextBox><span
                                                                                        style="color: #ff0000">*</span>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAccountNumber"
                                                                                        ErrorMessage="请填写卡号"></asp:RequiredFieldValidator><br />
                                                                                    <span class="color3">此处银行卡的户名必须与注册的真实姓名保持一致。此处必须填写数字，如为招行则此处必须填写一卡通卡号。为了您的资金安全，此处银行卡的户名必须与注册的真实姓名保持一致。</span></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!--注册内容end---->
                                            </asp:Panel>
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
                                                <tr>
                                                    <td height="27" background="/Images/web/U_bg2.gif">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr bgcolor="#F4F8FF">
                                                                <td width="4%" height="24">
                                                                    <img src="/Images/web/U_li1.gif" width="14" height="14" alt="" /></td>
                                                                <td width="63%" align="left" valign="bottom" class="title1">
                                                                    注册协议<span class="color1"></span></td>
                                                                <td width="33%">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="BrokerAgreement" runat="server" ReadOnly="True" Rows="8" TextMode="MultiLine"
                                                            Width="650px"></asp:TextBox>
                                                        &nbsp;&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px">
                                                        <asp:CheckBox ID="ChkBroker"  Checked="false" runat="server" Text="我同意《彩神通代理注册协议》" /><span
                                                            style="color: #ff0000">*</span></td>
                                                </tr>
                                            </table>
                                            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr bgcolor="#cccccc">
                                                    <td style="height: 1px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="38">
                                                        &nbsp;<asp:Button ID="btsave" runat="server" Text="注册成为代理" OnClick="btsave_Click" />&nbsp;&nbsp;
                                                        <asp:Button ID="btcanl" runat="server" Text="重置" OnClick="btcanl_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
