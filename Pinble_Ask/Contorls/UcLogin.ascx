<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UcLogin.ascx.cs" Inherits="Pinble_Ask.Contorls.UcLogin" %>
<script type="text/javascript"  src="/javascript/SearchAjax.js"></script>
<div id="Login1" runat="server">
    <table width="83%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="right" height="30">
                用户名：</td>
            <td align="left">
                <asp:TextBox ID="txtName" runat="server" Width="130px" MaxLength="12"></asp:TextBox>&nbsp; <a style="cursor: pointer;"
                    href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>Register.aspx" tabindex="-1">
                    免费注册</a></td>
        </tr>
        <tr>
            <td align="right" height="30">
                密&nbsp;&nbsp;码：</td>
            <td align="left">
                <asp:TextBox ID="txtPWD" runat="server" MaxLength="16" Width="130px" TextMode="Password"></asp:TextBox>&nbsp;<a
                    style="cursor: pointer;" href="<%=Pbzx.Common.WebInit.webBaseConfig.WebUrl %>RecoverPasswd1.aspx"
                    target="_blank" tabindex="-2">密码找回</a></td>
        </tr>
        <tr>
            <td align="right" height="30">
                验证码：</td>
            <td align="left">
                <asp:TextBox ID="txtCode" MaxLength="4" runat="server" Width="46px" onkeyup="CheckYZM(this.value,'1','','imgOKL','imgErrorL')"></asp:TextBox>         
                <img src="/publicPage/VerifyCode.aspx" alt="看不清？点击更换" name="imgVerify" align="absmiddle" 
                    id="imgVerify" onclick="this.src=this.src+'?'" style="width: 62px; height: 23px" />
                <img alt="正确" src="/Images/Web/note_ok.gif" id="imgOKL" style="display: none;" />
                <img alt="错误" src="/Images/Web/note_error.gif" id="imgErrorL" style="display: none;" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" height="30">
                <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="loginbtn" OnClick="btnLogin_Click" />
                <asp:Button ID="btnreset" runat="server" Text="重置" CssClass="loginbtn2" OnClick="btnreset_Click" />
                &nbsp;<a href="zRecoverPasswd1.aspx" target="_top" class="blue"><asp:CheckBox ID="cbState"
                    runat="server" Text="保存登录状态" />
            </td>
        </tr>
    </table>
</div>
<div id="hasLogin" runat="server" visible="false">
    <table cellspacing="4" cellpadding="4" width="85%" align="center" border="0">
        <tbody>
            <tr>
                <td align="left">
                    <b>欢迎您：</b>
                    <asp:Label ID="lblUName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <a href='/User.aspx'>&nbsp;&nbsp;进入我的拼搏吧</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    <%--                                <asp:Button ID="btnExit" runat="server" Text="退出" CssClass="loginbtn" OnClick="btnExit_Click" />--%>
                    <asp:LinkButton ID="lblTC" runat="server" OnClick="lblTC_Click">退出</asp:LinkButton></td>
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

