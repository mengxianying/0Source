<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLogin.ascx.cs" Inherits="Pinble_Ask.Contorls.UcLogin" %>
<script type="text/javascript"  src="/javascript/SearchAjax.js"></script>
<div id="Login1" runat="server">
    <table width="83%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" height="30">
                �û�����</td>
            <td align="left">
                <asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>&nbsp; <a style="cursor: pointer;"
                    href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx" tabindex="-1">
                    ���ע��</a></td>
        </tr>
        <tr>
            <td align="right" height="30">
                ��&nbsp;&nbsp;�룺</td>
            <td align="left">
                <asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px" TextMode="Password"></asp:TextBox>&nbsp;<a
                    style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx"
                    target="_blank" tabindex="-2">�����һ�</a></td>
        </tr>
        <tr>
            <td align="right" height="30">
                ��֤�룺</td>
            <td align="left">
                <asp:TextBox ID="txtCode" MaxLength="4" runat="server" Width="46px" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>         
                <img src="/publicPage/VerifyCode.aspx" alt="�����壿�������" name="imgVerify" align="absmiddle" 
                    id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                <img alt="��ȷ" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                <img alt="����" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" height="30">
                <asp:Button ID="btnLogin" runat="server" Text="��¼" CssClass="loginbtn" OnClick="btnLogin_Click" />
                <asp:Button ID="btnreset" runat="server" Text="����" CssClass="loginbtn2" OnClick="btnreset_Click" />
                &nbsp;<a href="zRecoverPasswd1.aspx" target="_top" class="blue"><asp:CheckBox ID="cbState"
                    runat="server" Text="�����¼״̬" />
            </td>
        </tr>
    </table>
</div>
<div id="hasLogin" runat="server" visible="false">
    <table cellspacing="4" cellpadding="4" width="85%" align="center" border="0">
        <tbody>
            <tr>
                <td align="left">
                    <b>��ӭ����</b>
                    <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <a href='/User.aspx'>&nbsp;&nbsp;�����ҵ�ƴ����</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    <%--                                <asp:Button ID="btnExit" runat="server" Text="�˳�" CssClass="loginbtn" OnClick="btnExit_Click" />--%>
                    <asp:LinkButton ID="lblTC" runat="server" OnClick="lblTC_Click">�˳�</asp:LinkButton></td>
            </tr>
            <tr>
                <td align="center">
                </td>
            </tr>
        </tbody>
    </table>
</div>

<script type="text/javascript" language="javascript">
    function denglu()
    {
        if(event.keyCode==13)
        {
            document.getElementById('<%=btnLogin.ClientID%>').click();            
        }
    }
</script>

