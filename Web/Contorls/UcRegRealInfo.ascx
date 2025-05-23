<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcRegRealInfo.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcRegRealInfo" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<!---注册内容---->
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
-->
</style>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td height="32" valign="bottom" background="images/web/U_bg1.gif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr bgcolor="#FBFDFF">
                    <td style="padding-top: 5px;">
                        <span class="color2">高级用户注册：</span><span class="color1">*为必填内容，请您认真填写，以便需要我们及时的和您联系。
                        </span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td height="27" background="/Images/web/U_bg2.gif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr bgcolor="#F4F8FF">
                    <td width="4%" height="24">
                        <img src="/images/web/U_li1.gif" width="14" height="14" alt="" /></td>
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
                    <td width="27%" align="right" valign="top">
                        用户名：</td>
                    <td width="21%" align="left">
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
                    <td width="52%" align="left" valign="top" class="color3">
                    </td>
                </tr>
                <%--                            <tr>
                                <td align="right">
                                    密码提示问题：</td>
                                <td align="left">
                                  <asp:DropDownList ID="ddlQuest" runat="server">
                                        <asp:ListItem>我儿时居住地的地址？</asp:ListItem>
                                        <asp:ListItem>我最喜爱的电影？</asp:ListItem>
                                        <asp:ListItem>我中学校名全称？</asp:ListItem>
                                        <asp:ListItem>我最喜爱的电影？</asp:ListItem>
                                        <asp:ListItem>我手机号码的后6位？</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="left" class="color3">
                                    非常重要，当您要找回密码时候使用！</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 32px">
                                    提示问题回答：</td>
                                <td align="left" style="height: 32px">
                                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>*</td>
                                <td align="left" class="color3" style="height: 32px">
                                    非常重要，当您要找回密码时候使用！</td>
                            </tr>--%>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td height="27" background="/Images/web/U_bg2.gif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr bgcolor="#F4F8FF">
                    <td width="4%" height="24">
                        <img src="/images/web/U_li1.gif" width="14" height="14" alt="" /></td>
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
                    <td width="27%" align="right" valign="top">
                        真实姓名：</td>
                    <td width="21%" align="left" valign="top">
                        <asp:TextBox ID="txtRealName" runat="server" MaxLength="6"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRealName"
                                ErrorMessage="请填写真实姓名" SetFocusOnError="true" ValidationGroup="Base" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    <td width="52%" align="left">
                        <span style="color: Red;">重要提醒：这是您提款的重要依据，提款时银行卡的户名必须是 这里填写的真实姓名。真实姓名一旦提交将不可更改。</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        出生年月：</td>
                    <td align="left">
                        <asp:TextBox ID="txtBirthday" onfocus="calendar();" runat="server" MaxLength="20"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBirthday"
                                ErrorMessage="请选择出生日期" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    <td align="left">
                        <span style="color: Red;">重要提醒：出生年月设置了就不能修改。</span></td>
                </tr>
                <tr>
                    <td align="right" style="height: 51px">
                        性别：</td>
                    <td align="left" style="height: 51px">
                        <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                            <asp:ListItem Value="1">女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left" class="color3" style="height: 51px">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        交易密码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtTPWD" runat="server" TextMode="Password" Width="149" MaxLength="16"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtTPWD"
                                ErrorMessage="密码必须是6-16位的字母和数字" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                                SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left" class="color3">
                        请输入6-16位的字母和数字的组合，来确保交易密码的安全。</td>
                </tr>
                <tr>
                    <td align="right">
                        确认交易密码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtReTPWD" runat="server" TextMode="Password" Width="149" MaxLength="16"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtTPWD"
                                ControlToValidate="txtReTPWD" ErrorMessage="两次密码输入不一致" SetFocusOnError="true"
                                Display="Dynamic"></asp:CompareValidator></span></td>
                    <td align="left" class="color3">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        交易密码密保问题：</td>
                    <td align="left">
                        <asp:UpdatePanel ID="upTradePWD" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtQuestion" runat="server" Visible="false" MaxLength="100"></asp:TextBox>
                                <asp:DropDownList ID="ddlPassWordQuestion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPassWordQuestion_SelectedIndexChanged"
                                    Width="155px">
                                </asp:DropDownList>&nbsp;<span style="color: #ff0000">*</span>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left">
                        <span class="font_gray" id="spQuestionTS" runat="server">请选择您常用的密码问题，以便您在忘记交易密码后根据问题取回密码
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        交易密码密保答案：</td>
                    <td align="left">
                        <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" MaxLength="100"></asp:TextBox>&nbsp;<font
                            color="red">*</font><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWordAnswer"
                            ErrorMessage=" 交易密码答案不能为空" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="color3">
                        <span class="font_gray">请输入您的交易密码密保答案</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        身份证号码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtCardID" runat="server" MaxLength="18"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCardID"
                                ErrorMessage="请填写身份证号码" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCardID"
                                ErrorMessage="身份证号码格式不正确" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left">
                        <span style="color: Red;">重要提醒：一旦需要修改你的一些重要信息，要核对身份证号码，此提交后不能更改。</span></td>
                </tr>
                <tr>
                    <td align="right">
                        联系电话：</td>
                    <td align="left">
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="15"></asp:TextBox><%--<span style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="请填写联系电话" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="联系电话格式不正确" ValidationExpression="((\(\d{3}\)|\d{3}-)|(\(\d{4}\)|\d{4}-))?(\d{8}|\d{7})" Display="Dynamic"></asp:RegularExpressionValidator></span>--%></td>
                    <td align="left" class="color3">
                        电话号码中应包括区号，如：010-62132803</td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码：</td>
                    <td align="left">
                        <asp:TextBox ID="txtMobile" runat="server" MaxLength="11"></asp:TextBox>&nbsp;<font
                            color="red">*</font>
                            <script>
                                if (document.getElementById("UcRegRealInfo1_txtMobile") != null) {
                                    if (document.getElementById("UcRegRealInfo1_txtMobile").value != "") {
                                        document.getElementById("UcRegRealInfo1_txtMobile").readOnly = true;
                                        document.getElementById("UcRegRealInfo1_txtMobile").style.backgroundColor = "#cccccc";
                                        
                                    }
                                }
                            </script>
                            </td>
                    <td align="left" class="color3">
                        手机号码必填。</td>
                </tr>
                <tr>
                    <td align="right" style="height: 30px">
                        真实Email：</td>
                    <td align="left" style="height: 30px">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="35"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span></td>
                    <td align="left" class="color3" style="height: 30px">
                        非常重要，方便我们给您发送通知信息（当您提交之后，请登录拼搏在线彩神通软件进入用户中心在我的资料下面的真实资料管理里面去验证您的邮件）</td>
                </tr>
                <tr>
                    <td align="right" style="height: 30px">
                        QQ号码：</td>
                    <td align="left" style="height: 30px">
                        <asp:TextBox ID="txtQQ" runat="server" MaxLength="15"></asp:TextBox></td>
                    <td align="left" class="color3" style="height: 30px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        MSN：</td>
                    <td align="left">
                        <asp:TextBox ID="txtMSN" runat="server" MaxLength="30"></asp:TextBox></td>
                    <td align="left" class="color3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        省份：</td>
                    <td align="left" class="color3" colspan="2">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <asp:UpdatePanel ID="UpProvince" runat="server">
                                        <ContentTemplate>
                                            <span style="width: 350px; text-align: left;">
                                                <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlCity" runat="server">
                                                </asp:DropDownList>
                                                <span style="color: #ff0000">*</span> </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        邮编：</td>
                    <td align="left">
                        <asp:TextBox ID="txtPostCode" runat="server" MaxLength="6"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                                ErrorMessage="邮编格式不正确" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode" ErrorMessage="请填写邮编"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td align="left" class="color3">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        详细地址：</td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" Width="360px" MaxLength="50"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="请填写详细地址" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td height="27" background="/Images/web/U_bg2.gif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr bgcolor="#F4F8FF">
                    <td width="4%" height="24">
                        <img src="/images/web/U_li1.gif" width="14" height="14" alt="" /></td>
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
                    <td width="27%" align="right">
                        发卡银行：</td>
                    <td width="76%" colspan="2" align="left">
                        <asp:RadioButtonList ID="rblBankList" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        开户行：</td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtBankInfo" runat="server" Width="360px" MaxLength="50"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBankInfo"
                            ErrorMessage="请填写开户行"></asp:RequiredFieldValidator><br />
                        <span class="color3">例如：北京市中国建设银行铁道专业支行官园南里储蓄所 注意：无论您的银行卡的发卡银行和地区怎样选择，请您务必填写‘银行卡开户银行’。其格式如上例子所示，XX省XX银行XX市XX支行(营业部)</span></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        卡号：</td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtAccountNumber" runat="server" Width="200px" MaxLength="20"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAccountNumber"
                            ErrorMessage="请填写卡号"></asp:RequiredFieldValidator><br />
                        <span class="color3" style="color: Red;">此处填写的发卡银行所属开户行和卡号必须与您的银行卡真实信息完全一致。如由您提交的银行卡信息资料不准确，造成的任何资金往来损失，您将承担全部责任。</span></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="MT">
    <tr>
        <td height="27" background="/Images/web/U_bg2.gif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr bgcolor="#F4F8FF">
                    <td width="4%" height="24">
                        <img src="/images/web/U_li1.gif" width="14" height="14" alt="" /></td>
                    <td width="63%" align="left" valign="bottom" class="title1">
                        高级用户注册协议<span class="color1"></span></td>
                    <td width="33%">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="60%" border="0" align="center" cellpadding="8" cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="RegeditAgreementGao" runat="server" Height="220px" TextMode="MultiLine"
                            Width="820" ReadOnly="True" BackColor="White"></asp:TextBox></td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<script type="text/javascript"></script>

<!--注册内容end---->
