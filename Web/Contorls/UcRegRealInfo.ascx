<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcRegRealInfo.ascx.cs"
    Inherits="Pbzx.Web.Contorls.UcRegRealInfo" %>

<script src="/javascript/calendar.js" type="text/javascript"></script>

<!---ע������---->
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
                        <span class="color2">�߼��û�ע�᣺</span><span class="color1">*Ϊ�������ݣ�����������д���Ա���Ҫ���Ǽ�ʱ�ĺ�����ϵ��
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
                        �û�������Ϣ</td>
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
                        �û�����</td>
                    <td width="21%" align="left">
                        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
                    <td width="52%" align="left" valign="top" class="color3">
                    </td>
                </tr>
                <%--                            <tr>
                                <td align="right">
                                    ������ʾ���⣺</td>
                                <td align="left">
                                  <asp:DropDownList ID="ddlQuest" runat="server">
                                        <asp:ListItem>�Ҷ�ʱ��ס�صĵ�ַ��</asp:ListItem>
                                        <asp:ListItem>����ϲ���ĵ�Ӱ��</asp:ListItem>
                                        <asp:ListItem>����ѧУ��ȫ�ƣ�</asp:ListItem>
                                        <asp:ListItem>����ϲ���ĵ�Ӱ��</asp:ListItem>
                                        <asp:ListItem>���ֻ�����ĺ�6λ��</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="left" class="color3">
                                    �ǳ���Ҫ������Ҫ�һ�����ʱ��ʹ�ã�</td>
                            </tr>
                            <tr>
                                <td align="right" style="height: 32px">
                                    ��ʾ����ش�</td>
                                <td align="left" style="height: 32px">
                                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>*</td>
                                <td align="left" class="color3" style="height: 32px">
                                    �ǳ���Ҫ������Ҫ�һ�����ʱ��ʹ�ã�</td>
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
                        �û���ϸ��Ϣ</td>
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
                        ��ʵ������</td>
                    <td width="21%" align="left" valign="top">
                        <asp:TextBox ID="txtRealName" runat="server" MaxLength="6"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRealName"
                                ErrorMessage="����д��ʵ����" SetFocusOnError="true" ValidationGroup="Base" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    <td width="52%" align="left">
                        <span style="color: Red;">��Ҫ���ѣ�������������Ҫ���ݣ����ʱ���п��Ļ��������� ������д����ʵ��������ʵ����һ���ύ�����ɸ��ġ�</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        �������£�</td>
                    <td align="left">
                        <asp:TextBox ID="txtBirthday" onfocus="calendar();" runat="server" MaxLength="20"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBirthday"
                                ErrorMessage="��ѡ���������" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
                    <td align="left">
                        <span style="color: Red;">��Ҫ���ѣ��������������˾Ͳ����޸ġ�</span></td>
                </tr>
                <tr>
                    <td align="right" style="height: 51px">
                        �Ա�</td>
                    <td align="left" style="height: 51px">
                        <asp:RadioButtonList ID="rdlSex" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">��</asp:ListItem>
                            <asp:ListItem Value="1">Ů</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left" class="color3" style="height: 51px">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        �������룺</td>
                    <td align="left">
                        <asp:TextBox ID="txtTPWD" runat="server" TextMode="Password" Width="149" MaxLength="16"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RegularExpressionValidator ID="cpassword" runat="server" ControlToValidate="txtTPWD"
                                ErrorMessage="���������6-16λ����ĸ������" ValidationExpression="^[a-zA-Z0-9_]{6,18}$" ValidationGroup="baseinfo"
                                SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left" class="color3">
                        ������6-16λ����ĸ�����ֵ���ϣ���ȷ����������İ�ȫ��</td>
                </tr>
                <tr>
                    <td align="right">
                        ȷ�Ͻ������룺</td>
                    <td align="left">
                        <asp:TextBox ID="txtReTPWD" runat="server" TextMode="Password" Width="149" MaxLength="16"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtTPWD"
                                ControlToValidate="txtReTPWD" ErrorMessage="�����������벻һ��" SetFocusOnError="true"
                                Display="Dynamic"></asp:CompareValidator></span></td>
                    <td align="left" class="color3">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ���������ܱ����⣺</td>
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
                        <span class="font_gray" id="spQuestionTS" runat="server">��ѡ�������õ��������⣬�Ա��������ǽ���������������ȡ������
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ���������ܱ��𰸣�</td>
                    <td align="left">
                        <asp:TextBox ID="txtPassWordAnswer" runat="server" ValidationGroup="baseinfo" MaxLength="100"></asp:TextBox>&nbsp;<font
                            color="red">*</font><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWordAnswer"
                            ErrorMessage=" ��������𰸲���Ϊ��" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left" class="color3">
                        <span class="font_gray">���������Ľ��������ܱ���</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ���֤���룺</td>
                    <td align="left">
                        <asp:TextBox ID="txtCardID" runat="server" MaxLength="18"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCardID"
                                ErrorMessage="����д���֤����" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCardID"
                                ErrorMessage="���֤�����ʽ����ȷ" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic"></asp:RegularExpressionValidator></span></td>
                    <td align="left">
                        <span style="color: Red;">��Ҫ���ѣ�һ����Ҫ�޸����һЩ��Ҫ��Ϣ��Ҫ�˶����֤���룬���ύ���ܸ��ġ�</span></td>
                </tr>
                <tr>
                    <td align="right">
                        ��ϵ�绰��</td>
                    <td align="left">
                        <asp:TextBox ID="txtTel" runat="server" MaxLength="15"></asp:TextBox><%--<span style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="����д��ϵ�绰" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                                ErrorMessage="��ϵ�绰��ʽ����ȷ" ValidationExpression="((\(\d{3}\)|\d{3}-)|(\(\d{4}\)|\d{4}-))?(\d{8}|\d{7})" Display="Dynamic"></asp:RegularExpressionValidator></span>--%></td>
                    <td align="left" class="color3">
                        �绰������Ӧ�������ţ��磺010-62132803</td>
                </tr>
                <tr>
                    <td align="right">
                        �ֻ����룺</td>
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
                        �ֻ�������</td>
                </tr>
                <tr>
                    <td align="right" style="height: 30px">
                        ��ʵEmail��</td>
                    <td align="left" style="height: 30px">
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="35"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span></td>
                    <td align="left" class="color3" style="height: 30px">
                        �ǳ���Ҫ���������Ǹ�������֪ͨ��Ϣ�������ύ֮�����¼ƴ�����߲���ͨ��������û��������ҵ������������ʵ���Ϲ�������ȥ��֤�����ʼ���</td>
                </tr>
                <tr>
                    <td align="right" style="height: 30px">
                        QQ���룺</td>
                    <td align="left" style="height: 30px">
                        <asp:TextBox ID="txtQQ" runat="server" MaxLength="15"></asp:TextBox></td>
                    <td align="left" class="color3" style="height: 30px">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        MSN��</td>
                    <td align="left">
                        <asp:TextBox ID="txtMSN" runat="server" MaxLength="30"></asp:TextBox></td>
                    <td align="left" class="color3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ʡ�ݣ�</td>
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
                        �ʱࣺ</td>
                    <td align="left">
                        <asp:TextBox ID="txtPostCode" runat="server" MaxLength="6"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPostCode"
                                ErrorMessage="�ʱ��ʽ����ȷ" ValidationExpression="\d{6}" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPostCode" ErrorMessage="����д�ʱ�"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                        </span>
                    </td>
                    <td align="left" class="color3">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        ��ϸ��ַ��</td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" Width="360px" MaxLength="50"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*<br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="����д��ϸ��ַ" Display="Dynamic"></asp:RequiredFieldValidator></span></td>
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
                        ������Ϣ<span class="color1"></span></td>
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
                        �������У�</td>
                    <td width="76%" colspan="2" align="left">
                        <asp:RadioButtonList ID="rblBankList" runat="server" RepeatDirection="Horizontal">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        �����У�</td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtBankInfo" runat="server" Width="360px" MaxLength="50"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtBankInfo"
                            ErrorMessage="����д������"></asp:RequiredFieldValidator><br />
                        <span class="color3">���磺�������й�������������רҵ֧�й�԰���ﴢ���� ע�⣺�����������п��ķ������к͵�������ѡ�����������д�����п��������С������ʽ����������ʾ��XXʡXX����XX��XX֧��(Ӫҵ��)</span></td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        ���ţ�</td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtAccountNumber" runat="server" Width="200px" MaxLength="20"></asp:TextBox>&nbsp;<span
                            style="color: #ff0000">*</span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAccountNumber"
                            ErrorMessage="����д����"></asp:RequiredFieldValidator><br />
                        <span class="color3" style="color: Red;">�˴���д�ķ����������������кͿ��ű������������п���ʵ��Ϣ��ȫһ�¡��������ύ�����п���Ϣ���ϲ�׼ȷ����ɵ��κ��ʽ�������ʧ�������е�ȫ�����Ρ�</span></td>
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
                        �߼��û�ע��Э��<span class="color1"></span></td>
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

<!--ע������end---->
